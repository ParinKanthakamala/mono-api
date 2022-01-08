// config environment
import knex, { Knex } from "knex";
// import mysql from 'mysql';
const mysql = require("mysql");
import { config } from "../helpers/environment";
import { log } from "@system/helpers/console";

export class MySql {
  public readonly db: Knex<any, unknown[]>;
  // private readonly config: {
  //   client: string;
  //   connection: {
  //     password: string;
  //     database: string;
  //     port: number;
  //     host: string;
  //     user: string;
  //   };
  // };
  private conn: any;

  constructor() {
    try {
      this.conn = mysql.createConnection(config.connection);
      this.conn.connect((error: any) => {
        if (error) log.error(error);
        else log.info("Successfully connected to the database.");
      });
      this.db = knex({
        client: config.database.driver,
        connection: config.database.connection,
      });
    } catch (ex: any) {
      log.error("can not connect to database.");
      log.error(ex.message);
    }
  }

  public table(tablename: string) {
    return this.db(tablename);
  }
}
