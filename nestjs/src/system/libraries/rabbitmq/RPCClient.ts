import { RPCBase } from "./RPCBase";
import { RMQPMessage } from "@libraries/rabbitmq/rabbitmq-message";

export class RPCClient extends RPCBase {
  GetQueueName(): string {
    return "";
  }

  OnMessage(data: RMQPMessage): RMQPMessage {
    return undefined;
  }
  constructor() {
    super();
  }
}
