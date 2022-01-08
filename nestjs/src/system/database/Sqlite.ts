import { log } from "@system/helpers/console";
import knex, { Knex } from "knex";

const sqlite3 = require("sqlite3");

export class Sqlite {
  public readonly db: Knex<any, unknown[]>;
  private readonly config: {
    useNullAsDefault: boolean;
    client: string;
    connection: { filename: string };
  };
  private conn: any;

  constructor(filename: string) {
    this.config = {
      client: "sqlite3",
      connection: {
        filename: filename,
      },
      useNullAsDefault: true,
    };
    this.conn = sqlite3.createConnection(this.config.connection);
    this.conn.connect((error: any) => {
      if (error) log.error(error);
      else log.info("Successfully connected to the database.");
    });
    this.db = knex(this.config);
  }

  public table(tablename: string) {
    return this.db(tablename);
  }
}
