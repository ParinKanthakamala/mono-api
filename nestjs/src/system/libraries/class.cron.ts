import { CronJob } from "cron";
import express from "express";
// yarn add cron
// yarn add @types/cron

export function cron_test() {
  const job = new CronJob(
    "*/10 * * * * *",
    () => {
      //
      // console.log('You will see this message every second');
      // console.log('show count : ' + count++);
      //
    },
    null,
    true,
    "America/Los_Angeles"
  );
  job.start();
}

// Setup crons.

const cronJobs: Map<string, CronJob> = new Map<string, CronJob>();

const secCronJob = new CronJob("* * * * * *", () => {
  // console.log("I am cron Job 'sec' and I just ran!");
});

cronJobs.set("sec", secCronJob);

const tenSecCronJob = new CronJob("*/10 * * * * *", () => {
  // console.log("I am cron Job 'sec' and I just ran!");
});

cronJobs.set("10sec", tenSecCronJob);
// cronJobs.forEach((v: CronJob, k: string) => v.start());

const app = express();
app.get("/stop-job/:name", (req, res) => {
  const cron = cronJobs.get(req.params.name);

  if (cron) {
    cron.stop();
    res.send(`Cron job ${req.params.name} stopped`);
  } else {
    res.send(`Cron job ${req.params.name} could not be found`);
  }
});

app.get("/start-job/:name", (req, res) => {
  const cron = cronJobs.get(req.params.name);

  if (cron) {
    cron.start();
    res.send(`Cron job ${req.params.name} started`);
  } else {
    res.send(`Cron job ${req.params.name} could not be found`);
  }
});

app.get("/exec-job/:name", (req, res) => {
  const cron = cronJobs.get(req.params.name);

  if (cron) {
    cron.fireOnTick();
    res.send(`Cron job ${req.params.name} executed`);
  } else {
    res.send(`Cron job ${req.params.name} could not be found`);
  }
});

app.get("/job/:name", (req, res) => {
  const cron = cronJobs.get(req.params.name);
  if (cron) {
    res.send(
      `Cron job '${req.params.name}' will run next on ${cron.nextDate()}`
    );
  } else {
    res.send(`Cron job '${req.params.name}' could not be found`);
  }
});

app.listen(8080);
