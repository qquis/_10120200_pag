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
Tools_1.default.pagConsoleLog(`----------------------------------------`, true);
Tools_1.default.pagConsoleLog(`Front Service - Start`, true);
Tools_1.default.pagConsoleLog(`Version ${packgeJoson.version}`, true);
let myServicePatch = new service_1.default();
let S4501_isRunning = 0;
let S4502_isRunning = 0;
let S5501_isRunning = 0;
let S8001_isRunning = 0;
let S9501_isRunning = 0;
let S9510_isRunning = 0;
let horario_reg = 0;
const job = nodeSchedule.scheduleJob('*/60 * * * * *', () => __awaiter(void 0, void 0, void 0, function* () {
    console.log(Date());
    let hora_atual = Tools_1.default.Right(Tools_1.default.pagDateTime_getDateStringLong(Tools_1.default.Date_br_current()), 8);
    let horario = parseInt(Tools_1.default.Left(hora_atual, 2));
    let MinutoExecucao = Tools_1.default.Right(hora_atual, 4);
    if (horario_reg !== horario) {
        horario_reg = horario;
        Tools_1.default.pagConsoleLog(`Em EXECUÇÃO (08 - 23): Hora Atual ${horario} Minuto Execução ${MinutoExecucao}`, true);
    }
    Tools_1.default.pagConsoleLog(`Status _ S4501 : ${S4501_isRunning} | S4502 : ${S4502_isRunning} | S5501 : ${S5501_isRunning} | S8001 : ${S8001_isRunning} | S9501 : ${S9501_isRunning} | S9510 : ${S9510_isRunning}`);
    myServicePatch.serviceProcess(4501, S4501_isRunning);
    if (S4501_isRunning == 0) {
        S4501_isRunning = 1;
        myServicePatch.serviceRun(4501, S4501_isRunning)
            .then(() => {
            S4501_isRunning = 0;
        })
            .catch((err) => {
            S4501_isRunning = 0;
            Tools_1.default.pagConsoleLog(`Service TS-S4501 | Error ${err}`, false);
        });
    }
    myServicePatch.serviceProcess(4502, S4502_isRunning);
    if (S4502_isRunning == 0) {
        S4502_isRunning = 1;
        myServicePatch.serviceRun(4502, S4502_isRunning)
            .then(() => {
            S4502_isRunning = 0;
        })
            .catch((err) => {
            S4502_isRunning = 0;
            Tools_1.default.pagConsoleLog(`Service TS-S4502 | Error ${err}`, false);
        });
    }
    myServicePatch.serviceProcess(5501, S5501_isRunning);
    if (S5501_isRunning == 0) {
        S5501_isRunning = 1;
        myServicePatch.serviceRun(5501, S5501_isRunning)
            .then(() => {
            S5501_isRunning = 0;
        })
            .catch((err) => {
            S5501_isRunning = 0;
            Tools_1.default.pagConsoleLog(`Service TS-S5501 | Error ${err}`, false);
        });
    }
    myServicePatch.serviceProcess(8001, S8001_isRunning);
    if (S8001_isRunning == 0) {
        S8001_isRunning = 1;
        myServicePatch.serviceRun(8001, S8001_isRunning)
            .then(() => {
            S8001_isRunning = 0;
        })
            .catch((err) => {
            S8001_isRunning = 0;
            Tools_1.default.pagConsoleLog(`Service TS-S8001 | Error ${err}`, false);
        });
    }
    myServicePatch.serviceProcess(9501, S9501_isRunning);
    if (S9501_isRunning == 0) {
        S9501_isRunning = 1;
        myServicePatch.serviceRun(9501, S9501_isRunning)
            .then(() => {
            S9501_isRunning = 0;
        })
            .catch((err) => {
            S9501_isRunning = 0;
            Tools_1.default.pagConsoleLog(`Service TS-S9501 | Error ${err}`, false);
        });
    }
    myServicePatch.serviceProcess(9510, S9510_isRunning);
    if (S9510_isRunning == 0) {
        S9510_isRunning = 1;
        myServicePatch.serviceRun(9510, S9510_isRunning)
            .then(() => {
            S9510_isRunning = 0;
        })
            .catch((err) => {
            S9510_isRunning = 0;
            Tools_1.default.pagConsoleLog(`Service TS-S9510 | Error ${err}`, false);
        });
    }
}));
