import * as dotenv from "dotenv";
const fs = require("fs");

dotenv.config();

function env_int(name: string, defaults: number): number {
  const value = process.env[name];
  if (!value) {
    return defaults;
  }
  return parseInt(value);
}

function env_boolean(name: string, defaults: boolean): boolean {
  const value = process.env[name];
  if (!value) {
    return defaults;
  }
  return value === "true";
}

function env_string(name: string, defaults: string): string {
  const value = process.env[name];
  if (!value) {
    return defaults;
  }
  return value;
}
function make(limit: any, default_value: number) {
  if (limit !== undefined) {
    parseInt(limit);
  }
  return default_value;
}

export const env = {
  number: env_int,
  boolean: env_boolean,
  string: env_string,
  make,
};

const appRoot = require("app-root-path");

function make_config() {
  const event: string = process.env.npm_lifecycle_event;
  const parts = event.split(":");

  return parts.filter((e) => e === "dev").length > 0
    ? "/config.dev.json"
    : "/config.prod.json";
}

export const config: any = require(appRoot + make_config());
