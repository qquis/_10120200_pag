//www.luiztools.com.br/post/como-usar-nodjs-postgresql
//Instruções de como fazer um deploy: https://www.digitalocean.com/community/tutorials/how-to-set-up-a-node-js-application-for-production-on-ubuntu-18-04-pt

require ('dotenv/config')
//const cron = require('node-cron')

const nodeSchedule = require('node-schedule')
var pjson = require('./package.json');

const servicepag = require('./src/bll/servicepag')
const Tools = require('./src/tools/Tools')


Tools.pagConsoleLog(`-`)
Tools.pagConsoleLog(`Start ServiceJS _ Versão ${pjson.version}`, true)

console.log(`Arquivo de Log Service ${process.env.PATH_FILE_LOG}`)

const job = nodeSchedule.scheduleJob('*/1 * * * *', async () => {
    await servicepag();

});

