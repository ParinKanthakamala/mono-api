import walkSync from "walk-sync";
import * as path from "path";
import * as fs from "fs";
import { directory_helper } from "./directory";
import ErrnoException = NodeJS.ErrnoException;

/*-
Create folder, sub folder - Upload file
- Copy file and folder
- Delete file and folder
- Rename file and folder
- File versioning
- Filter by name, extension
- Convert to PDF (from word, excel, image)
- File permission (specific user, group, all, public)
- File information (file type, file size)
- Log
- Upload to Local, FTP(s), Cloud Storage server (AWS3, DO Space)
*/
export function extension(filename: string): string {
  return filename.split(".").reverse()[0];
}

export async function file_list(
  dir: string,
  extensions: any = "*"
): Promise<any> {
  // let property = await file_property('./images/9789740214830.jpg');
  // console.log(JSON.stringify(property));
  return new Promise(async (resolve) => {
    const output: any = [];
    const files = fs.readdirSync(dir);
    for (const file of files) {
      const current = dir + "/" + file;
      // console.log(current.replace('//', '/'));
      if (is_file(current)) {
        // console.log(current.replace('//', '/'));
        if (extensions === "*") {
          output.push(current);
        } else {
          // const extension = extensions(file);
          if (
            Array.isArray(extensions) &&
            extensions.filter((e) => e === extensions).length > 0
          ) {
            output.push(current);
          }
        }
      } else if (is_directory(current)) {
        const lists = await file_list(current);
        // tslint:disable-next-line:no-shadowed-variable
        for (const list of lists) {
          output.push(list);
        }
      }
    }
    resolve(output);
  });
}

function copy(source: string, destination: string): Promise<boolean> {
  return new Promise((resolve) => {
    fs.copyFile(source, destination, (err: ErrnoException | null) => {
      // console.log('copy');
      // console.log('\tfrom ' + source);
      // console.log('\tto ' + destination);
      // console.log('complete');
      resolve(!err);
    });
  });
}

function copyFileSync(source: string, target: string) {
  let targetFile = target;
  if (fs.existsSync(target)) {
    if (fs.lstatSync(target).isDirectory()) {
      targetFile = path.join(target, path.basename(source));
    }
  }
  fs.writeFileSync(targetFile, fs.readFileSync(source));
}

function move(source: string, destination: string): boolean {
  directory_helper.read(source, async (filename: string) => {
    // console.log(filename);
    const realTarget: string = filename.replace(source, destination);
    const myfile = file_helper.info(realTarget);
    if (!myfile.is_exists) {
      directory_helper.create(myfile.where);
      await file_helper.copy(filename, realTarget);
      // console.log('move');
    }
  });

  return false;
}

export function file_remove(filePath: string): boolean {
  if (is_file(filePath)) {
    fs.unlinkSync(filePath);
  }
  // else if (is_directory(filePath)) {}
  return false;
}

export function rename(from: string, to: string): Promise<boolean> {
  return new Promise((resolve) => {
    fs.rename(from, to, (err: ErrnoException | null) => {
      resolve(!err);
    });
  });
}

export function exists(myPath: string): boolean {
  return fs.existsSync(myPath);
}

export function duplicate(src: string, target: string) {
  const files = walkSync(src);
  for (const file of files) {
    if (file !== ".DS_Store") {
      fs.copyFile(src + file, target + file, (err) => {
        if (err) {
          throw err;
        }
      });
    }
  }
}

export function mkdir(myPath: string, mode: number, callback: any) {
  myPath = exports.path.abspath(myPath);
  const dirs = myPath.split(path.sep);
  const walker = [dirs.shift()];

  // walk
  // @ds:  A list of directory names
  // @acc: An accumulator of walked dirs
  // @m:   The mode
  // @cb:  The callback
  const walk = (ds: any, acc: any, m: any, cb: any) => {
    if (ds.length > 0) {
      const d = ds.shift();

      acc.push(d);
      const dir = acc.join(path.sep);

      // look for dir on the fs, if it doesn't exist then create it, and
      // continue our walk, otherwise if it's a file, we have a name
      // collision, so exit.
      fs.stat(dir, (err: ErrnoException | null, stat: any) => {
        // if the directory doesn't exist then create it
        if (err) {
          // 2 means it's wasn't there
          if (err.errno === 2 || err.errno === 34) {
            fs.mkdir(dir, m, (erro: ErrnoException | null) => {
              if (erro && erro.errno !== 17 && erro.errno !== 34) {
                return cb(erro);
              } else {
                return walk(ds, acc, m, cb);
              }
            });
          } else {
            return cb(err);
          }
        } else {
          if (stat.isDirectory()) {
            return walk(ds, acc, m, cb);
          } else {
            return cb(new Error("Failed to mkdir " + dir + ": File exists\n"));
          }
        }
      });
    } else {
      return cb();
    }
  };
  return walk(dirs, walker, mode, callback);
}

export function is_file(filepath: string): boolean {
  return fs.lstatSync(filepath).isFile();
}

export function is_directory(filepath: string): boolean {
  return fs.lstatSync(filepath).isDirectory();
}

export function file_copy(source: string, target: string): Promise<boolean> {
  return new Promise((resolve) => {
    const directory: string = directory_object(target);
    if (!exists(directory)) {
      fs.mkdirSync(directory, { recursive: true });
    }

    fs.copyFile(source, target, (err) => {
      if (err) {
        resolve(false);
      } else {
        resolve(true);
      }
    });
  });
}

export function file_object(myPath: string) {
  return myPath.split("/").reverse()[0];
}

export function directory_object(myPath: string) {
  let parts = myPath.split("/").reverse();
  delete parts[0];
  parts = parts.reverse();
  return parts.join("/");
}

export async function subdirectory(myPath: string) {
  const lists = await file_list(myPath);
  return lists.filter((value: any, index: number, self: any) => {
    return self.indexOf(value) === index;
  });
}

export function remove_root(myPath: string) {
  const parts = myPath.split("/");

  if (parts[0] === ".") {
    parts.splice(0, 1);
  }
  parts.splice(0, 1);
  return parts.join("/");
}

// info : return as kilobyte
function file_size(filepath: string) {
  try {
    const stats = fs.statSync(filepath);
    const fileSizeInBytes = Math.round(stats.size);
    let fileSizeInMegabytes = fileSizeInBytes / 1000.0;
    fileSizeInMegabytes = fileSizeInBytes;
    // console.log(
    //   'size of ' +
    //     filepath.split('/').reverse()[0] +
    //     ' is ' +
    //     fileSizeInBytes +
    //     ' byte',
    // );
    // console.log('size of '+filepath.split('/').reverse()[0]+' is '+fileSizeInBytes+' byte');
    return fileSizeInMegabytes;
  } catch (ex) {
    // log.error(ex);
  }
  return 0;
}

function change_extension(filename: string, checker: string) {
  let ext: string = file_helper.extension(filename);
  const root: string = filename.substring(0, filename.length - ext.length);
  ext = !checker.startsWith(".")
    ? checker
    : checker.length > 0
    ? `.${checker}`
    : "";
  return root + ext;
}

function folder(filepath: string) {
  const parts: any = filepath.split("/");
  parts.pop();
  return parts.join("/");
}

function info(filepath: string) {
  const output: any = {
    is_exists: exists(filepath),
    size: file_size(filepath),
    extension: extension(filepath),
    where: folder(filepath),
    path: filepath,
  };
  return output;
}

export interface FileOption {
  baseDir: string;
  current: string;
  extension: string;
  log?: boolean;
  callback?: any;
}

function list(option: FileOption) {
  const combined = path.join(option.baseDir, option.current);

  const combinedStat = fs.statSync(combined);
  if (combinedStat.isDirectory()) {
    for (const entry of fs.readdirSync(combined)) {
      list({
        extension: "",
        baseDir: option.baseDir,
        current: path.join(option.current, entry),
        log: option.log,
        callback: option.callback,
      });
    }
  } else {
    // console.log("is file");
    option.callback(combined);
    // console.log(combined);
  }
}

function read(filepath: string): Promise<string> {
  return new Promise((resolve, reject) => {
    fs.readFile(filepath, (err: ErrnoException | null, data: Buffer) => {
      if (err) {
        reject(err);
      } else {
        resolve(data.toString());
      }
    });
  });
}
function create(targetFile: string) {
  fs.writeFileSync(targetFile, "");
}

// tslint:disable-next-line:variable-name
export const file_helper = {
  read,
  copy,
  move,
  size: file_size,
  create,
  extension,
  change_extension,
  exists,
  info,
  copyFileSync,
  remove: file_remove,
  list,
};
