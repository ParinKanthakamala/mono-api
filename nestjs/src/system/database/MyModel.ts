import { Knex } from "knex";
import { MySql } from "./MySql";

export abstract class MyModel {
  public tablename = "";

  protected constructor(table: string) {
    this.tablename = table;
  }

  public get db(): Knex<any, unknown[]> {
    const mysql = new MySql();
    return mysql.db;
  }

  public today() {
    return this.db.fn.now();
  }

  // (no_property_id)?insert:modify;

  create<T>(dataset: T): Promise<T> {
    return new Promise((resolve, reject) => {
      this.db(this.tablename)
        .insert(dataset)
        .then((result: any) => {
          resolve(result);
        })
        // tslint:disable-next-line:no-shadowed-variable
        .catch((dataset: any) => {
          reject(dataset);
        });
    });
  }

  // info : not ready yet
  manage<T>(dataset: any, allowDuplicate): Promise<T> {
    // consol.log('',test1 | test2 | test3)

    // info : check for blank object
    return new Promise(async (resolve) => {
      // if haven't property id manage for insert
      if (
        (!dataset.hasOwnProperty("id") || dataset.id === undefined) && // info : if id is available
        Object.keys(dataset).length > 1 // info : not only id
      ) {
        if (allowDuplicate) {
          const command = this.create_return(dataset, "id");
          resolve(command);
        } else {
          const rows = await this.read_where<T>(dataset);
          if (rows !== undefined) {
            const command = this.create_return(dataset, "id");
            resolve(command);
          }
        }
        return;
      } else {
        // if haven't property id manage for update
        const id = dataset.id;
        delete dataset.id;
        await this.update(id, dataset);
        resolve(id);
        return;
      }
    });
  }

  create_return(dataset: object, value: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.db
        .table(this.tablename)
        .insert(dataset)
        .returning(value)
        .then((result: any) => {
          resolve(result);
        })
        // tslint:disable-next-line:no-shadowed-variable
        .catch((dataset: any) => {
          reject(dataset);
        });
    });
  }

  // info : get raw condition
  fetch<T>(condition: any, limit = 100, offset = 0): Promise<T> {
    return new Promise((resolve, reject) => {
      this.db
        .table(this.tablename)
        .select("*")
        .where(condition)
        .limit(limit)
        .offset(offset)
        .then((dataset: any) => {
          resolve(dataset);
        })
        .catch((dataset: any) => {
          reject(dataset);
        });
    });
  }

  // maxx : get data by id
  read<T>(name: string): Promise<T[]> {
    return new Promise((resolve, reject) => {
      this.db
        .table(this.tablename)
        .select("*")
        .from(this.tablename)
        .where("name", name)
        .then((dataset: T[]) => {
          resolve(dataset);
          return dataset;
        })
        .catch((dataset: any) => {
          reject(dataset);
        });
    });
  }

  // maxx : get_where({workspace:1,task:1},100,200);
  read_where<T>(condition: object, limit = 0, offset = 0): Promise<T> {
    return new Promise((resolve, reject) => {
      let temp = this.db.table(this.tablename).select("*").where(condition);
      if (limit > 0) {
        temp = temp.limit(0);
        // $this->limit($limit, $offset);
      }
      if (offset > 0) {
        temp = temp.offset(offset);
      }
      temp
        .then((dataset: any) => {
          resolve(dataset);
        })
        .catch((dataset: any) => {
          reject(dataset);
        });
    });
  }

  update(id: number, dataset: object): Promise<any> {
    return new Promise((resolve, reject) => {
      this.db
        .table(this.tablename)
        .where("id", id)
        .update(dataset)
        // tslint:disable-next-line:no-shadowed-variable
        .then((dataset: any) => {
          resolve(dataset);
        })
        // tslint:disable-next-line:no-shadowed-variable
        .catch((dataset: any) => {
          reject(dataset);
        });
    });
  }

  update_where(dataset: object, condition: object) {
    return new Promise((resolve, reject) => {
      this.db
        .table(this.tablename)
        .where(condition)
        .update(dataset)
        // tslint:disable-next-line:no-shadowed-variable
        .then((dataset: any) => {
          resolve(dataset);
        })
        // tslint:disable-next-line:no-shadowed-variable
        .catch((dataset: any) => {
          reject(dataset);
        });
    });
  }

  async undo_delete(id: number): Promise<any> {
    return await this.update_where({ visible: true }, { id });
  }

  // info : delete row by id
  async delete(id: number): Promise<any> {
    return await this.update_where({ visible: false }, { id });
  }

  // info : update by
  assigned(id: number, dataset: any): Promise<any> {
    return new Promise(async (resolve) => {
      Object.entries(dataset).forEach(([key, value]) => {
        // tslint:disable-next-line:prefer-const
        let row: any;
        row[key] = value;
        try {
          this.update_where(row, { id });
          resolve(true);
        } catch {
          // let model = Model.Instance;
          // model.Meta.set_value(this.tablename, key, id, value);
          resolve(false);
        }
      });
    });
  }
}
