import * as fs from "fs";

const archiver = require("archiver");

export class Compress {
  private target: fs.WriteStream;
  private archive: any;

  // private buffer3: Buffer;

  constructor() {
    this.target = fs.createWriteStream(__dirname + "/example.zip");
    //Set the compression format to zip
  }

  example() {
    const test_buffer: Buffer = Buffer.from("buff it!");
    compress_instance
      .setTargetPath("example.zip")
      .append_file("filename.txt", "filepath.txt")
      .append_string("string.txt", "string content")
      .append_buffer("buffer.txt", test_buffer)
      .append_directory("./src", "./src")
      .finalize();
  }

  append_file(filename: string, filepath: string) {
    this.archive.append(fs.createReadStream(filepath), { name: filename });
    return this;
  }

  // append a file from string
  append_string(filename: string, content: string) {
    this.archive.append(content, { name: filename });
    return this;
  }

  append_buffer(filename: string, buffer: Buffer) {
    // append a file from buffer
    // this.buffer3 = Buffer.from('buff it!');
    this.archive.append(buffer, { name: filename });
    return this;
  }

  append_directory(source_dir: string, target_dir: string) {
    // append files from a sub-directory and naming it `new-subdir` within the archive
    this.archive.directory(source_dir, target_dir);
    return this;
  }

  finalize() {
    this.archive.finalize();
  }

  // create a file to stream archive data to.
  setTargetPath(target_file: string) {
    this.target = fs.createWriteStream(target_file);
    this.target.on("close", function () {
      console.log(archiver.pointer() + " total bytes");
      console.log(
        "archiver has been finalized and the this.target file descriptor has closed."
      );
    });
    // This event is fired when the data source is drained no matter what was the data source.
    // It is not part of this library but rather from the NodeJS Stream API.
    this.target.on("end", function () {
      console.log("Data has been drained");
    });
    this.archive = archiver("zip", {
      zlib: { level: 9 }, // Sets the compression level.
    });
    // listen for all archive data to be written
    // good practice to catch this error explicitly
    this.archive.on("error", function (err: any) {
      throw err;
    });
    // pipe archive data to the file
    this.archive.pipe(this.target);
    return this;
  }
}

export const compress_instance: Compress = new Compress();
