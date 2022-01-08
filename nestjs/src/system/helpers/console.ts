import dayjs from "dayjs";
import logger from "pino";
// const logger = require("pino")();

export function debug_log(...items: any[]) {
  for (const item of items) {
    log.info(item);
  }
}

export const log = logger({
  // name: __filename,
  // level: process.env.LOG_LEVEL || "debug",
  prettyPrint: true,
  base: { pid: false },
  timestamp: () => `,"time" : "${dayjs().format("YYYY-MM-DD hh:mm:ss")}"`,
});
