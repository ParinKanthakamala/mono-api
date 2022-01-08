import axios from "axios";
import { config } from "@system/helpers/environment";
import { log } from "@system/helpers/console";

function get(api: string) {
  return new Promise((resolve, reject) => {
    const account = config.rabbitmq.account;
    const password = config.rabbitmq.password;
    const auth = account + ":" + password;
    log.info(
      "http://" + auth + "@" + config.rabbitmq.host + ":15672/api/" + api
    );
    axios({
      method: "get",
      url: "http://" + auth + "@" + config.rabbitmq.host + ":15672/api/" + api,
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
function post(api: string) {
  return new Promise((resolve, reject) => {
    const account = config.rabbitmq.account;
    const password = config.rabbitmq.password;
    const auth = account + ":" + password;
    axios({
      method: "post",
      url: "http://" + auth + "@" + config.rabbitmq.host + ":15672/api/" + api,
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
function put(api: string) {
  return new Promise((resolve, reject) => {
    const account = config.rabbitmq.account;
    const password = config.rabbitmq.password;
    const auth = account + ":" + password;
    axios({
      method: "put",
      url: "http://" + auth + "@" + config.rabbitmq.host + ":15672/api/" + api,
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

function del(api: string) {
  return new Promise((resolve, reject) => {
    const account = config.rabbitmq.account;
    const password = config.rabbitmq.password;
    const auth = account + ":" + password;
    axios({
      method: "delete",
      url: "http://" + auth + "@" + config.rabbitmq.host + ":15672/api/" + api,
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

export const rmqp = {
  api: {
    overview: get("overview"),
  },
};
