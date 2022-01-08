import * as express from "express";
import { array_collapse } from "../helpers/array";
import { v4 as uuidv4 } from "uuid";
import { RMQPMessage, RMQPEmptyMessage } from "./rabbitmq/rabbitmq-message";
import { RPCServer } from "./rabbitmq/RPCServer";
import { RPCClient } from "./rabbitmq/RPCClient";

export class SharePoint {
  private static instance: SharePoint;
  public request: any;
  public response: any;
  public url: any;
  public name: string | undefined = undefined;

  public rawHeader: any = new Map<string, string>();
  public message: RMQPMessage = RMQPEmptyMessage();
  public server: RPCServer = new RPCServer();
  public client: RPCClient = new RPCClient();
  // public env = "";

  private constructor() {
    //
  }

  public ignoreFavicon(req, res, next) {
    if (req.originalUrl.includes("favicon.ico")) {
      res.status(204);
    }
    next();
  }

  public static get Instance() {
    // return (SharePoint.instance ??= new SharePoint());// info : why can not use this syntax
    if (SharePoint.instance) {
      return SharePoint.instance;
    }
    SharePoint.instance = new SharePoint();
    return SharePoint.instance;
  }

  uuid() {
    return uuidv4();
  }

  public use(request: express.Request, response: express.Response, next: any) {
    SharePoint.instance.manage(request, response);
    next();
  }

  public manage(request: express.Request, response: express.Response) {
    this.request = request;
    this.response = response;
    this.rawHeader = array_collapse(SharePoint.instance.request.rawHeaders);
  }
}

export const sharepoint: SharePoint = SharePoint.Instance;
