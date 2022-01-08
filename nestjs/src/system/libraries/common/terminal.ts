import { ExecException } from "child_process";

const { exec } = require("child_process");

export function terminal(command: string): Promise<any> {
  return new Promise((resolve) => {
    exec(command, (error: ExecException, stdout: string, stderr: string) => {
      if (error) {
        // reject(error);
        resolve("");
      } else if (stderr) {
        // reject(stderr);
        resolve("");
      } else {
        resolve(stdout);
      }
    });
  });
}
