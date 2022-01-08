import * as jwt from "jsonwebtoken";

import { isFalsy } from "utility-types";
import { config } from "./environment";

export function get_token(uuid: string) {
  const expires: number = 60 * 60;
  const expiresAt: Date = new Date(Date.now() + expires * 1000);

  return {
    token: jwt.sign({ data: uuid }, config.secret.jwt, { expiresIn: expires }),
    token_type: "Bearer",
    expires_in: expires,
    expires_at: expiresAt,
  };
}

export function token_encode(uuid: string) {
  const expires: number = Math.floor(Date.now() / 1000) + 60 * 60;
  const expiresAt: Date = new Date(Date.now() + expires);

  return {
    token: jwt.sign({ data: uuid }, config.secret.jwt, { expiresIn: expires }),
    token_type: "Bearer",
    expires_in: Math.floor(Date.now() / 1000) + 60 * 60,
    expires_at: expiresAt,
  };
}

export function token_decode(token: string) {
  const decoded: any = jwt.verify(token, config.secret.jwt);
  return decoded;
}

export function escapeRegExp(str: string) {
  return str.replace(/[\-\[\]\/\{\}\(\)\+\?\.\\\^\$\|]/g, "\\$&");
}

export function fuzzyComparison(str: string, mask: string) {
  const regex = "^" + escapeRegExp(mask).replace(/\*/, ".*") + "$";
  const r = new RegExp(regex);
  return r.test(str);
}

export function extract_string(str: string, pattern: string) {
  const r = new RegExp(pattern);
  return r.exec(str);
}

export function extract(str: string, start = "{", stop = "}") {
  //
  const array = str.split("");
  let open = false;
  const output: any = [];
  let temp = "";
  do {
    const current = array.shift();
    switch (current) {
      case start:
        open = true;
        break;
      case stop:
        {
          open = false;
          output.push(temp);
          temp = "";
        }
        break;
      default: {
        temp += open ? current : "";
      }
    }
  } while (array.length > 0);
  return output;
}

export function is_empty(word: string) {
  return isFalsy(word);
}
