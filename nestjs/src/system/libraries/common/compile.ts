import * as ts from "typescript";

function compile(code: string): Promise<any> {
  return new Promise((resolve) => {
    const result = ts.transpile(code);
    const runnable: any = eval(result);
    resolve(runnable);
  });
}

export const script = {
  compile: compile,
};

// const code = `({
//   Run: (data: string): string => {
//       console.log(data); return Promise.resolve("SUCCESS"); }
//   })`;
//
// const temp: any = await script.compile(code);
// temp.Run("message");
