import 'dotenv/config' 
import myTools from './tools/Tools'
import nodeSchedule = require('node-schedule')
import ServicePatch from './service/service'

const packgeJoson = require('../package.json')



let myServicePatch = new ServicePatch(); 

let isRunning: number = 0 

const argsProcessService = process.argv.slice(1)





console.log(`Serviço informado ${argsProcessService[1]}`)

if (!argsProcessService[1]) {
    console.log("Favor informar o codigo do serviço")
    console.log(`Escolha uma das opções abaixo:
                    f5501_ImportVendaZanthus 5501
                    f8001_ImportFinanceiro   8001
                    f9501_ExportaPreco       9501
                    f9510_ImportProduto      9510
        `)
    process.exit()
}


let numeroServicePath = parseInt(`${argsProcessService[1]}`) 
if (!numeroServicePath || numeroServicePath == 0 ) {
    console.log("Favor informar o codigo do serviço")
    process.exit()
}
const customToken = process.env.PUBLIC_CUSTOM_TOKEN


myTools.pagConsoleLog(`----------------------------------------`, true)
myTools.pagConsoleLog(`Front Service - Start ${argsProcessService[1]} | Versão ${packgeJoson.version}`, true)
myTools.pagConsoleLog(`Custom Token: ${customToken}`, true)

const job = nodeSchedule.scheduleJob('*/60 * * * * *', async () => {
    
        console.log(Date())

        myTools.pagConsoleLog(`Serviço Em execução _ : ${numeroServicePath} `)
        
        
        myServicePatch.serviceProcess(numeroServicePath, isRunning);
        if (isRunning == 0)
        {
            isRunning = 1
            myServicePatch.serviceRun(numeroServicePath, isRunning)
                .then(() => {
                    isRunning = 0
                })
                .catch((err: Error) => {
                    isRunning = 0
                    myTools.pagConsoleLog( `Service TS | Error ${err}`, false) 
                })
        }
})
    