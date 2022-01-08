import { RMQPMessage } from "../rabbitmq-message";
type Route = (message: RMQPMessage) => any;
export type RouteOptions = Route;
export interface Resource {
  // middleware?: Middleware | Middleware[]
  delete?: RouteOptions;
  get?: RouteOptions;
  head?: RouteOptions;
  patch?: RouteOptions;
  post?: RouteOptions;
  put?: RouteOptions;
  options?: RouteOptions;
  error?: RouteOptions;
}
