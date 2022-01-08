import HttpStatusCode from "../common/statuscode";
import { config } from "../../helpers/environment";
export enum RMQPType {
  REQUEST = "request",
  RESPONSE = "response",
}
export interface RMQPMessage {
  type: string;
  event: any;
  from: string;
  to: string;
  status_code: number;
  token?: string;
  body?: any;
  params?: any;
  message?: string;
  reference: any;
  method: string;
  query?: any;
  version: string;
}
export function RMQPErrorMessage(content: RMQPMessage) {
  const message: RMQPMessage = {
    reference: new Array<string>(),
    query: {},
    type: RMQPType.REQUEST,
    event: "common/error",
    from: content.from,
    to: content.to,
    status_code: HttpStatusCode.GATEWAY_TIMEOUT,
    token: "",
    body: {},
    method: "error",
    version: "1.0",
  };
  return message;
}
export function RMQPResponseMessage() {
  const output: RMQPMessage = {
    query: {},
    event: "common/default",
    from: config.rabbitmq.name,
    to: "",
    method: "error",
    status_code: 0,
    type: RMQPType.RESPONSE,
    reference: new Array<string>(),
    version: "1.0",
  };
  return output;
}
export function RMQPEmptyMessage() {
  const output: RMQPMessage = {
    query: undefined,
    from: config.rabbitmq.name,
    to: "",
    method: "empty",
    event: undefined,
    status_code: HttpStatusCode.NOT_FOUND,
    type: "",
    reference: new Array<string>(),
    version: "1.0",
  };
  return output;
}
