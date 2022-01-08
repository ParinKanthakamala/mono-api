import { RPCBase } from "./RPCBase";
import { config } from "../../helpers/environment";
import { RMQPEmptyMessage, RMQPMessage } from "./rabbitmq-message";
import amqp from "amqplib/callback_api";
import { log } from "@system/helpers/console";

export class RPCServer extends RPCBase {
  GetQueueName(): string {
    return config.rabbitmq.name;
  }
  OnMessage(data: RMQPMessage): RMQPMessage {
    return data;
  }

  public async load(message: RMQPMessage): Promise<RMQPMessage> {
    return new Promise((resolve) => {
      amqp.connect("amqp://" + config.rabbitmq.host, (error0, connection) => {
        if (error0) {
          throw error0;
        } else {
          connection.createChannel((error1, channel) => {
            const output: RMQPMessage = RMQPEmptyMessage();
            if (error1) {
              output.body = error1;
              resolve(output);
            } else {
              const queue = message.to;
              const msg = JSON.stringify(message);
              channel.assertQueue(queue, { durable: false });
              channel.sendToQueue(queue, Buffer.from(msg));
              log.info(" [x] Sent %s");
              log.info(message);
            }
          });
          setTimeout(function () {
            connection.close();
          }, config.rabbitmq.timeout);
        }
      });
    });
  }

  constructor() {
    super();
  }
}
