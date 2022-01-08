import amqp, { Connection } from "amqplib/callback_api";

import { log } from "@system/helpers/console";
import { ManageRequest } from "@libraries/rabbitmq/rabbitmq-helpers";
import { RMQPMessage, RMQPType } from "@libraries/rabbitmq/rabbitmq-message";
import { config } from "@system/helpers/environment";

async function createConnection(): Promise<any> {
  return new Promise((resolve, rejects) => {
    amqp.connect(
      "amqp://" + config.rabbitmq.host,
      (error, connection: Connection) => {
        error ? rejects(error) : resolve(connection);
      }
    );
  });
}

async function createChannel(connection: any): Promise<any> {
  return new Promise((resolve, rejects) => {
    //
    connection.createChannel((error: any, channel: any) => {
      if (error) {
        rejects(error);
      } else {
        resolve(channel);
      }
    });
    //
  });
}

export async function receiver() {
  log.info("connect to : ");
  log.info("amqp://" + config.rabbitmq.host);

  const connection = await createConnection();
  const channel = await createChannel(connection);
  const my_name = config.rabbitmq.name;
  log.info("my name is : " + my_name);
  channel.assertQueue(my_name, {
    auto_delete: true,
    durable: false,
    // exclusive: true,
  });

  channel.consume(
    my_name,
    async (msg: any) => {
      const message: RMQPMessage = JSON.parse(msg.content.toString());
      // log.info(message.to);
      if (message.type === RMQPType.REQUEST && message.to == my_name) {
        const output = await ManageRequest(message);
        channel.sendToQueue(message.from, Buffer.from(JSON.stringify(output)), {
          correlationId: msg.properties.correlationId,
          replyTo: my_name,
        });
      }
    },
    { noAck: true }
  );
}
