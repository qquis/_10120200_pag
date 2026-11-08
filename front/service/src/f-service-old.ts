import 'dotenv/config' 
import myTools from './tools/Tools'
import nodeSchedule = require('node-schedule')
import ServicePatch from './service/service'

const packgeJoson = require('../package.json')





myTools.pagConsoleLog(`----------------------------------------`, true)
myTools.pagConsoleLog(`Front Service - Start`, true)
myTools.pagConsoleLog(`Version ${packgeJoson.version}`, true)

let myServicePatch = new ServicePatch(); 

let S4501_isRunning: number = 0 
let S4502_isRunning: number = 0 
let S5501_isRunning: number = 0 
let S8001_isRunning: number = 0 
let S9501_isRunning: number = 0 
let S9510_isRunning: number = 0 

let horario_reg: number = 0 

const job = nodeSchedule.scheduleJob('*/60 * * * * *', async () => {
    
        console.log(Date())

        let hora_atual = myTools.Right(myTools.pagDateTime_getDateStringLong(myTools.Date_br_current()),8)
        
        let horario: number = parseInt(myTools.Left(hora_atual, 2))
        let MinutoExecucao = myTools.Right(hora_atual, 4)

        
        
    
        if (horario_reg !== horario ) {
            horario_reg = horario
            myTools.pagConsoleLog(`Em EXECUÇÃO (08 - 23): Hora Atual ${horario} Minuto Execução ${MinutoExecucao}`, true)
        }
    

        myTools.pagConsoleLog(`Status _ S4501 : ${S4501_isRunning} | S4502 : ${S4502_isRunning} | S5501 : ${S5501_isRunning} | S8001 : ${S8001_isRunning} | S9501 : ${S9501_isRunning} | S9510 : ${S9510_isRunning}`)
        
        
        myServicePatch.serviceProcess(4501, S4501_isRunning);
        if (S4501_isRunning == 0)
        {
            S4501_isRunning = 1
            myServicePatch.serviceRun(4501, S4501_isRunning)
                .then(() => {
                    S4501_isRunning = 0
                })
                .catch((err: Error) => {
                    S4501_isRunning = 0
                    myTools.pagConsoleLog( `Service TS-S4501 | Error ${err}`, false) 
                })
        }
        

        myServicePatch.serviceProcess(4502, S4502_isRunning);
        if (S4502_isRunning == 0)
        {
            S4502_isRunning = 1
            myServicePatch.serviceRun(4502, S4502_isRunning)
                .then(() => {
                    S4502_isRunning = 0
                })
                .catch((err: Error) => {
                    S4502_isRunning = 0
                    myTools.pagConsoleLog( `Service TS-S4502 | Error ${err}`, false) 
                })
        }
        
        myServicePatch.serviceProcess(5501, S5501_isRunning);
        if (S5501_isRunning == 0)
        {
            S5501_isRunning = 1
            myServicePatch.serviceRun(5501, S5501_isRunning)
                .then(() => {
                    S5501_isRunning = 0
                })
                .catch((err: Error) => {
                    S5501_isRunning = 0
                    myTools.pagConsoleLog( `Service TS-S5501 | Error ${err}`, false) 
                })
        }
        

        myServicePatch.serviceProcess(8001, S8001_isRunning);
        if (S8001_isRunning == 0)
        {
            S8001_isRunning = 1
            myServicePatch.serviceRun(8001, S8001_isRunning)
                .then(() => {
                    S8001_isRunning = 0
                })
                .catch((err: Error) => {
                    S8001_isRunning = 0
                    myTools.pagConsoleLog( `Service TS-S8001 | Error ${err}`, false) 
                })
        }

        
        myServicePatch.serviceProcess(9501, S9501_isRunning);
        if (S9501_isRunning == 0)
        {
            S9501_isRunning = 1
            myServicePatch.serviceRun(9501, S9501_isRunning)
                .then(() => {
                    S9501_isRunning = 0
                })
                .catch((err: Error) => {
                    S9501_isRunning = 0
                    myTools.pagConsoleLog( `Service TS-S9501 | Error ${err}`, false) 
                })
        }

        myServicePatch.serviceProcess(9510, S9510_isRunning);
        if (S9510_isRunning == 0)
        {
            S9510_isRunning = 1
            myServicePatch.serviceRun(9510, S9510_isRunning)
                .then(() => {
                    S9510_isRunning = 0
                })
                .catch((err: Error) => {
                    S9510_isRunning = 0
                    myTools.pagConsoleLog( `Service TS-S9510 | Error ${err}`, false) 
                })
        }

        
        
    
    })
    