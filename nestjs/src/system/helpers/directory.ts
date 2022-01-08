import * as path from "path";
import * as fs from "fs";
import { file_helper } from "./file";
import { log } from "@system/helpers/console";
//info : yarn add delete-empty

function create(dir: string) {
  // dir = './tmp/but/then/nested';
  try {
    // if (!fs.existsSync(dir)) {
    try {
      fs.mkdirSync(dir, { recursive: true });
    } catch (error) {
      log.error("directory_helper.create : ");
      log.error(error);
    }
    // }
  } catch (ex) {
    log.error(ex);
  }
}

export function by_extension(
  startPath: string,
  filter: string,
  callback: (filename: string) => any
) {
  log.info("Starting from dir " + startPath + "/");
  if (!fs.existsSync(startPath)) {
    log.error("no dir ", startPath);
    callback("no dir " + startPath);
    return;
  }
  const files = fs.readdirSync(startPath);
  for (let i = 0; i < files.length; i++) {
    const filename = path.join(startPath, files[i]);
    const stat = fs.lstatSync(filename);
    if (stat.isDirectory()) {
      by_extension(filename, filter, callback); //recurse
    } else if (
      filename
        .substring(filename.lastIndexOf("."), filename.length)
        .replace(".", "") == filter
    ) {
      log.info("-- found: ", filename);
      callback(filename);
    }
  }
}

function copy(source: string, target: string) {
  let files = [];

  // Check if folder needs to be created or integrated
  const targetFolder = path.join(target, path.basename(source));
  if (!fs.existsSync(targetFolder)) {
    fs.mkdirSync(targetFolder);
  }

  // Copy
  if (fs.lstatSync(source).isDirectory()) {
    files = fs.readdirSync(source);
    files.forEach(function (file) {
      const curSource = path.join(source, file);
      if (fs.lstatSync(curSource).isDirectory()) {
        copy(curSource, targetFolder);
      } else {
        file_helper.copyFileSync(curSource, targetFolder);
      }
    });
  }
}

function move(source: string, target: string) {
  //info : clear target
  directory_helper.read(source, function (filename: string) {
    log.info(filename.replace(source, target));
    const target_directory = directory_helper
      .from(filename)
      .replace(source, target);
    if (!directory_helper.exists(target_directory)) {
      directory_helper.create(target_directory);
    }
    file_helper.copy(filename, filename.replace(source, target));
    file_helper.remove(filename);
  });
}

function remove(directory_path: any, callback: () => any) {
  if (fs.existsSync(directory_path)) {
    const files = fs.readdirSync(directory_path);
    for (let i = 0; i < files.length; i++) {
      try {
        const filename = [directory_path, files[i]].join("/");
        const stat = fs.lstatSync(filename);
        if (stat.isDirectory()) {
          read(filename, callback); //recurse
        } else {
          fs.unlink(filename, () => {
            log.info("delete : " + filename);
          });
        }
        fs.unlink(filename, () => {
          log.info("delete : " + filename);
        });
      } catch (ex) {}
    }
  }
}

function read(startPath: string, callback: (filename: string) => any) {
  if (!fs.existsSync(startPath)) {
    return;
  }
  const files = fs.readdirSync(startPath);
  for (let i = 0; i < files.length; i++) {
    try {
      const filename = [startPath, files[i]].join("/");
      const stat = fs.lstatSync(filename);
      if (stat.isDirectory()) {
        read(filename, callback); //recurse
      } else {
        callback(filename);
      }
    } catch (ex) {
      log.error(ex);
    }
  }
}

function from(filepath: string) {
  const parts: any = filepath.split("/");
  parts.pop();
  return parts.join("/");
}

function exists(filepath: string): boolean {
  try {
    const stat = fs.lstatSync(filepath);
    return stat.isDirectory();
  } catch (ex) {
    return false;
  }
}

function copyFolderRecursiveSync(source: string, target: string) {
  let files = [];

  // Check if folder needs to be created or integrated
  const targetFolder = path.join(target, path.basename(source));
  if (!fs.existsSync(targetFolder)) {
    fs.mkdirSync(targetFolder);
  }

  // Copy
  if (fs.lstatSync(source).isDirectory()) {
    files = fs.readdirSync(source);
    files.forEach(function (file) {
      const curSource = path.join(source, file);
      if (fs.lstatSync(curSource).isDirectory()) {
        directory_helper.copyFolderRecursiveSync(curSource, targetFolder);
      } else {
        file_helper.copyFileSync(curSource, targetFolder);
      }
    });
  }
}

function replace(source: string, target: string) {
  //info : clear target
  directory_helper.read(source, async function (filename: string) {
    log.info(filename.replace(source, target));
    const target_directory = directory_helper
      .from(filename)
      .replace(source, target);
    if (!directory_helper.exists(target_directory)) {
      directory_helper.create(target_directory);
    }
    await file_helper.copy(filename, filename.replace(source, target));
  });
}

export const directory_helper = {
  from: from,
  create: create, // create recursive directory
  copy: copy, // copy recursive folder
  move: move,
  remove: remove,
  replace: replace,
  read: read,
  exists: exists,
  by_extension: by_extension,
  copyFolderRecursiveSync: copyFolderRecursiveSync,
};
