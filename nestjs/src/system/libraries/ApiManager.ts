import { Request, Response, UploadedFiles } from "@nestjs/common";
import { Request as Req, Response as Res } from "express";
import { array_collapse } from "../helpers/array";

import * as qs from "qs";
import { is_empty } from "../helpers/string";
import { RMQPMessage, RMQPType } from "./rabbitmq/rabbitmq-message";

import * as e from "express";
import { config } from "../helpers/environment";
import { sharepoint } from "@libraries/SharePoint";
import { share } from "rxjs";
export class ApiManager {
  ///
  public request: e.Request; // tools : request of controller
  public response: e.Response; // tools : response of controller
  public result: any = { message: "no result." };
  ///
  public rawHeaders: any;

  params: any;
  body: any;
  public status = 0;
  public json: any = { message: "error" };
  segments: string[] = new Array<string>();
  private description: any;
  private data: any = {};

  public files: any = [];
  public referenceUrl = "#";
  private current: RMQPMessage;
  private references: Array<string> = new Array<string>();

  public constructor(
    @Request() request: Req,
    @Response() response: Res,
    @UploadedFiles() files: any[]
  ) {
    this.request = request;
    this.response = response;
    try {
      this.rawHeaders = array_collapse(this.request.rawHeaders);
      this.referenceUrl = this.request.baseUrl;
      this.segments = this.fetch_url(request.path);
    } catch (ex) {
      //
    }
    Object.entries(request.body).forEach(([key, value]) => {
      this.assign(key, value);
    });
  }

  public RoutePath() {
    const output = "";
    const url: string = this.request.url;
    let temp: any = url.split("?");
    if (temp.length === 1) {
      temp = temp[0].split("/").filter((item: string) => !is_empty(item));
      temp.shift();
    }
    for (let i = 0; i < temp.length; i++) {
      if (this.checkIfValidUUID(temp[i])) {
        this.references.push(temp[i]);
        temp[i] = "*";
      }
    }

    return temp.join("/");
  }

  public last() {
    let output = this.segments.reverse()[0];
    if (this.checkIfValidUUID(output)) {
      output = "uuid";
    } else {
      output = "";
    }

    return output;
  }

  public checkIfValidUUID(str: string) {
    // Regular expression to check if string is a valid UUID
    const regexExp =
      /^[0-9a-fA-F]{8}\b-[0-9a-fA-F]{4}\b-[0-9a-fA-F]{4}\b-[0-9a-fA-F]{4}\b-[0-9a-fA-F]{12}$/gi;
    return regexExp.test(str);
  }

  public get_uuid() {
    // const output = this.segments.reverse()[0];
    const output: string[] = new Array<string>();
    for (const segment of this.segments) {
      if (this.checkIfValidUUID(segment)) {
        output.push(segment);
      }
    }
    return output;
  }

  public method() {
    return this.request.method.toLowerCase();
  }

  public dataset() {
    const output: string = qs.stringify(this.data);
    return output;
    // return this.data;
  }

  public assign(key: string, value: any): ApiManager {
    this.data[key] = value;
    return this;
  }

  public api_name() {
    const output = this.segments[0];
    return output;
  }

  public path() {
    const temp = this.segments;
    delete temp[0];
    return temp.join("/");
  }

  public url() {
    const output =
      this.description.protocal +
      "://" +
      this.description.address +
      ":" +
      this.description.port +
      this.path();
    return output;
  }

  public segment_map() {
    const temp = this.segments;
    delete temp[0];
    const map: any = {};
    let currentKey = "";
    temp.forEach((item) => {
      if (currentKey === null) {
        map[item] = null;
        currentKey = item;
      } else {
        const value = item.split("?").filter((el: string) => {
          return el !== "";
        });
        map[currentKey] = value[0];
        currentKey = null;
      }
    });
    return map;
  }

  public token() {
    try {
      if (!this.rawHeaders.hasOwnProperty("Authorization")) {
        return "";
      }
      const Authorization = this.rawHeaders.Authorization;
      return Authorization.replace("Bearer ", "");
    } catch (ex: any) {
      return ex.message;
    }
  }
  sender() {
    if (this.description.type === "raw-data") {
      return JSON.stringify(this.body);
    }
    if (this.description.type === "x-www-form-urlencoded") {
      return qs.stringify(this.body);
    }
    if (this.description.type === "form-data") {
      return qs.stringify(this.body);
    }
  }

  QueryString() {
    const output: any = {};

    const route = this.request.url.split("?");
    if (route.length > 1) {
      const query = route[1].split("&");
      for (const parts of query) {
        const part = parts.split("=");
        if (part.length > 1) {
          output[part[0]] = part[1];
        } else {
          output[part[0]] = undefined;
        }
      }
    }
    return output;
  }

  GenerateMQ(): RMQPMessage {
    const output: RMQPMessage = {
      query: {},
      body: {},
      event: this.RoutePath(),
      from: config.myself.name,
      to: this.api_name() === undefined ? "" : this.api_name() + "-service",
      method: this.method(),
      status_code: 0,
      token: this.token(),
      type: RMQPType.REQUEST,
      reference: this.references,
      version: "1.0",
    };

    // const items = output.event.split("/");
    // for (const item of items) {
    //   if (this.checkIfValidUUID(item)) {
    //     output.reference.push(item);
    //   }
    // }
    this.current = output;
    return output;
  }

  public get isAvailable() {
    const checker = this.current.to;
    return new Promise(async (resolve, reject) => {
      const queues: any = await sharepoint.server.queues;
      for (const value of queues) {
        if (value.name == checker) {
          resolve(true);
        }
      }
      resolve(false);
    });
  }

  private fetch_url(url: string): string[] {
    return url.split("/").filter((el: string) => {
      return el !== "";
    });
  }
}
