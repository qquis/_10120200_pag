"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
require("dotenv/config");
const Tools_1 = __importDefault(require("./tools/Tools"));
const nodeSchedule = require("node-schedule");
const service_1 = __importDefault(require("./service/service"));
const packgeJoson = require('../package.json');
let myServicePatch = new service_1.default();
let isRunning = 0;
const argsProcessService = process.argv.slice(1);
console.log(`Serviço informado ${argsProcessService[1]}`);
if (!argsProcessService[1]) {
    console.log("Favor informar o codigo do serviço");
    console.log(`Escolha uma das opções abaixo:
                    f5501_ImportVendaZanthus 5501
                    f8001_ImportFinanceiro   8001
                    f9501_ExportaPreco       9501
                    f9510_ImportProduto      9510
        `);
    process.exit();
}
let numeroServicePath = parseInt(`${argsProcessService[1]}`);
if (!numeroServicePath || numeroServicePath == 0) {
    console.log("Favor informar o codigo do serviço");
    process.exit();
}
const customToken = process.env.PUBLIC_CUSTOM_TOKEN;
Tools_1.default.pagConsoleLog(`----------------------------------------`, true);
Tools_1.default.pagConsoleLog(`Front Service - Start ${argsProcessService[1]} | Versão ${packgeJoson.version}`, true);
Tools_1.default.pagConsoleLog(`Custom Token: ${customToken}`, true);
const job = nodeSchedule.scheduleJob('*/60 * * * * *', () => __awaiter(void 0, void 0, void 0, function* () {
    console.log(Date());
    Tools_1.default.pagConsoleLog(`Serviço Em execução _ : ${numeroServicePath} `);
    myServicePatch.serviceProcess(numeroServicePath, isRunning);
    if (isRunning == 0) {
        isRunning = 1;
        myServicePatch.serviceRun(numeroServicePath, isRunning)
            .then(() => {
            isRunning = 0;
        })
            .catch((err) => {
            isRunning = 0;
            Tools_1.default.pagConsoleLog(`Service TS | Error ${err}`, false);
        });
    }
}));
