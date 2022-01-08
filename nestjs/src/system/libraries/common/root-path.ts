import * as fs from "fs";

import * as path from "path";

let rootPath: string = "";
let found = false;
const pathArr = getPathArr();
const arraySlice = Array.prototype.slice;

// find package.json from the inside out
while (pathArr.length > 0) {
  rootPath = pathArr.join(path.sep);
  if (fs.existsSync(path.join(rootPath, "package.json"))) {
    found = true;
    break;
  }
  pathArr.pop();
}

if (!found) {
  throw new Error("cannot find any package.json file");
}

export default function (...args: string[]) {
  switch (args.length) {
    case 1:
      return path.join(rootPath, args[0]);
    case 0:
      return rootPath;
    default:
      const arg = arraySlice.call(args);
      arg.unshift(rootPath);
      return path.join.apply(arg);
  }
}

function getPathArr() {
  let dirname = __dirname;
  // make sure the path is outside node_modules directory
  const index = dirname.indexOf(path.sep + "node_modules" + path.sep);
  if (index !== -1) {
    dirname = dirname.slice(0, index);
  }
  return dirname.split(path.sep);
}
