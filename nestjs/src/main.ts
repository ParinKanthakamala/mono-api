import { NestFactory } from '@nestjs/core';
import { log } from '@system/helpers/console';
import { AppModule } from './app.module';


NestFactory.create(AppModule)
  .then((app) => {
    app.listen(3000)
      .then(() => {
        //

      }).catch((err) => {
        //
        log.error(err);
      });
  }).catch(err => {
    log.error(err);
  });
