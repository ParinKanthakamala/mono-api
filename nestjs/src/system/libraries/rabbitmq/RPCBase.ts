import amqp from "amqplib/callback_api";
import { config } from "../../helpers/environment";
import { RMQPMessage, RMQPResponseMessage } from "./rabbitmq-message";
import { HashTable } from "../../listeners/hash_table";
import { sharepoint } from "@libraries/SharePoint";
import axios from "axios";
import { log } from "@system/helpers/console";

// let self: RPCBase;
class RMQPCollector {
  name = "";
  callback: any = new Function();
}

export abstract class RPCBase {
  public connection: any = undefined;
  public channel: any = undefined;
  public callback: any = new Function();
  abstract GetQueueName(): string;
  abstract OnMessage(data: RMQPMessage): RMQPMessage;
  public collectors: HashTable<RMQPCollector> = {};

  public GetUrl() {
    return "amqp://" + config.rabbitmq.host;
  }

  private curl(api: string) {
    return new Promise((resolve, reject) => {
      axios({
        method: "get",
        url: "http://guest:guest@" + config.rabbitmq.host + ":15672/" + api,
        headers: {},
      })
        .then(function (response) {
          resolve(response.data);
        })
        .catch(function (error) {
          reject(error);
        });
    });
  }

  public get queues() {
    return new Promise(async (resolve) => {
      resolve(await this.curl("api/queues"));
    });
  }
  //curl -i -u guest:guest 'http://localhost:15672/api/channels?sort=message_stats.publish_details.rate&sort_reverse=true&columns=name,message_stats.publish_details.rate,message_stats.deliver_get_details.rate'
  public get vhosts() {
    return new Promise(async (resolve) => {
      resolve(await this.curl("api/vhosts"));
    });
  }

  public exchange(name: string) {
    return new Promise(async (resolve) => {
      resolve(await this.curl("api/exchanges/" + name));
    });
  }

  public send(message: RMQPMessage): Promise<RMQPMessage> {
    //
    const channel = this.channel;
    return new Promise((resolve, reject) => {
      //
      channel.sendToQueue(message.to, Buffer.from(JSON.stringify(message)), {
        correlationId: config.rabbitmq.correlationId,
        replyTo: message.to,
      });
    });
  }

  public CreateConnection(): Promise<any> {
    ///
    return new Promise((resolve, reject) => {
      //
      log.info("start connect to : ");
      log.info(this.GetUrl());
      amqp.connect(this.GetUrl(), (error, connection) =>
        error ? reject(error) : resolve(connection)
      );
    });
  }

  public CreateChannel(connection: any) {
    return new Promise((resolve, reject) => {
      connection.createChannel((error, channel) => {
        error ? reject(error) : resolve(channel);
      });
    });
  }

  public Close() {
    this.channel.Close();
    this.connection.Close();
  }
  public Timeout() {
    setTimeout(() => this.connection.close(), config.rabbitmq.timeout);
  }
  public ManageMessage(data: any) {
    //
    log.info("incoming data is : ");
    log.info(JSON.parse(data.content.toString()));
    const message: RMQPMessage = JSON.parse(data.content.toString());
    try {
      if (message.to == config.rabbitmq.name) {
        sharepoint.response
          .status(message.status_code)
          .send(message.body)
          .end();
      }
    } catch (ex: any) {
      const error: RMQPMessage = RMQPResponseMessage();
      error.status_code = 500;
      error.message = "connection timeout";
      sharepoint.response.status(500).send(error.body).end();
    }
    // this.channel.ack(data);
  }

  public async start() {
    await this.CheckConnect();
  }

  public async CheckConnect() {
    if (this.connection === undefined) {
      this.connection = await this.CreateConnection();
    }
    if (this.channel == undefined) {
      this.channel = await this.CreateChannel(this.connection);
    }
    this.channel.assertQueue(this.GetQueueName(), {
      durable: false,
      exclusive: true,
    });

    this.channel.prefetch(1);
    this.channel.consume(this.GetQueueName(), this.ManageMessage, {
      noAck: true,
    });
  }
}
