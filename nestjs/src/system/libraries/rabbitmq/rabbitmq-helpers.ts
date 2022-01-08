import { FileData } from "./listener/FileData";
import {
  RMQPMessage,
  RMQPErrorMessage,
  RMQPType,
  RMQPEmptyMessage,
} from "./rabbitmq-message";
import { file_helper } from "../../helpers/file";
import { extract, is_empty } from "../../helpers/string";
import { debug_log, log } from "../../helpers/console";
import { config } from "../../helpers/environment";
import { Resource } from "./listener/Resource";
import fs from "fs";
import path from "path";
import { HashTable } from "../../listeners/hash_table";
import { array_last } from "../../helpers/array";

export function escapeRegExp(str: string) {
  return str.replace(/[\-\[\]\/\{\}\(\)\+\?\.\\\^\$\|]/g, "\\$&");
}
export function compareTest(str: string, mask: string) {
  const regex = "^" + escapeRegExp(mask).replace(/\*/, ".*") + "$";
  const r = new RegExp(regex);
  return r.test(str);
}
export async function getModulePath(message: RMQPMessage): Promise<FileData> {
  return new Promise(async (resolve) => {
    let output: FileData = {
      isFile: false,
      module: "",
      name: "",
      path: "",
      pattern: "",
    };

    const rabbitmq = await ReadPath();
    if (rabbitmq.hasOwnProperty(message.to)) {
      const service = rabbitmq[message.to];
      const datas: FileData[] = service.filter((item: FileData) => {
        return item.pattern === message.event;
      });
      output = datas !== undefined && datas.length > 0 ? datas[0] : output;
      log.info(output.module);
      const check = output.module.replace("../../../", "./src/");
      if (
        file_helper.exists(check + "form.ts") ||
        file_helper.exists(check + ".js")
      ) {
        resolve(output);
      } else {
        if (is_empty(output.module)) {
          const reference = message.reference;
          const data = service.filter((item) =>
            compareTest(message.event, item.pattern)
          )[0];
          if (data !== undefined) {
            output.module = data.module;
            debug_log("[RMQ-Connection]", "matched found let's process");
            const items = extract(data.module, "{", "}");
            if (items.length > 0) message.params = {};
            for (const item of items) {
              message.params[item] = reference.shift();
            }
          }
        }
      }
      if (is_empty(output.module)) {
        // output.module = "common/error";
      }
    }
    resolve(output);
  });
}

export async function ManageRequest(content: RMQPMessage) {
  debug_log("someone told me something", content);
  const activeModule = await getModulePath(content);
  return new Promise((resolve) => {
    try {
      if (!is_empty(activeModule.module)) {
        debug_log("execute", activeModule.module);
        import(activeModule.module)
          .then(async (module: any) => {
            const resource: Resource = module.load();
            log.info(content.method);
            const result: RMQPMessage = await resource[content.method](content);
            result.from = config.rabbitmq.name;
            result.to = content.from;
            result.type = RMQPType.RESPONSE;
            resolve(result);
          })
          .catch((ex: any) => {
            //
            const result: RMQPMessage = RMQPEmptyMessage();
            result.from = config.rabbitmq.name;
            result.to = content.from;
            result.event = "exception";
            result.type = RMQPType.RESPONSE;
            result.body = ex.message;
            resolve(result);
          });
      }
    } catch (ex: any) {
      const output = RMQPErrorMessage(content);
      output.message = ex.message;
      resolve(output);
    }
  });
}

export function replaceParamsToken(token: string) {
  const regex = /{.+}/g;
  try {
    let result: any;
    while ((result = regex.exec(token)) !== null) {
      token =
        token.substring(0, result.index) +
        // result[0].replace("{", ":").replace("}", "") +
        token.substr(result.index + result[0].length);
      // let matchIndex = result.index;
      // let t = result[0].length;
      // matchRanges.push(new RegRange(matchIndex, t));
    }
  } catch (ex) {
    //
  }

  return token;
}

export function isAcceptableFile(file: string): boolean {
  const stat = fs.statSync(file);
  return (
    (file.endsWith(".js") || file.endsWith(".ts")) &&
    !path.basename(file).startsWith(".") &&
    !path.basename(file).startsWith("_") &&
    !file.endsWith(".map") &&
    !file.endsWith(".test.js") &&
    !file.endsWith(".test.ts") &&
    stat.isFile()
  );
}
export function ReadPath(): Promise<HashTable<FileData[]>> {
  const rabbitmq: HashTable<FileData[]> = {};
  return new Promise((resolve) => {
    file_helper.list({
      baseDir: "./src/rabbitmq",
      current: "",
      extension: "form.ts",
      log: false,
      callback: (filename: string) => {
        if (isAcceptableFile(filename)) {
          // debug_log("filename : " + filename);
          filename = filename.split(".")[0];
          const temp = filename.split("/").slice(2);
          const serviceName: string = temp.shift() + "";
          if (!rabbitmq.hasOwnProperty(serviceName)) {
            rabbitmq[serviceName] = new Array<FileData>();
          }
          const fileData: FileData = {
            isFile: true,
            name: array_last(temp),
            path: temp.join("/"),
            pattern: makePattern(temp),
            module: makeModulePath(serviceName, temp),
          };
          rabbitmq[serviceName].push(fileData);
        }
      },
    });
    resolve(rabbitmq);
  });
}

export function makePattern(parts: string[]): string {
  parts = parts.filter((obj) => obj !== "index.ts" && obj !== "index.js");

  for (let i = 0; i < parts.length; i++) {
    const part = parts[i];
    const pattern = "{(.*?)}";
    const r = new RegExp(pattern);
    if (r.test(part)) {
      parts[i] = "*";
    }

    if (part.endsWith("form.ts") || part.endsWith(".js")) {
      parts[i] = part.replace("form.ts", "").replace(".js", "");
    }
  }
  const output = parts.join("/");
  return pathToUrl(output);
}

export function pathToUrl(filePath: string) {
  let url = filePath
    .replace("form.ts", "")
    .replace(".js", "")
    .replace("/index", "");
  if (url.length === 1) {
    return url;
  }
  url = url
    .split(path.sep)
    .map((part) => replaceParamsToken(part))
    .join("/");
  return url;
}

export function makeModulePath(serviceName: string, array: string[]) {
  const modulePath: string = [
    // "..",
    "..",
    "..",
    "..",
    "rabbitmq",
    serviceName,
    array.join("/").split(".")[0],
  ].join("/");
  return modulePath;
}
