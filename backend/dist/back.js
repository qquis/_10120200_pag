"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
require("dotenv/config");
const express_1 = __importDefault(require("express"));
const cors_1 = __importDefault(require("cors"));
const router_1 = __importDefault(require("./routes/router"));
const Tools_1 = __importDefault(require("./tools/Tools"));
//import myTools from '@myTool/Tools'
//import DataBase from './database/DataBase';
const serviceSistema_1 = __importDefault(require("./modules/m0001_sistema/service/serviceSistema"));
//import servicePatch from './modules/m9030_sistema_batch/service/service_sistema_batch';
const port = parseInt(`${process.env.SERVER_API_PORT}`);
const packgeJoson = require('../package.json');
//const myDataBase : DataBase = new DataBase()
//const myservicePatch : servicePatch = new servicePatch();
try {
    const app = (0, express_1.default)();
    // Configurar CORS
    /*const corsOptions = {
        origin: 'http://localhost:3000', // Substitua pela origem que deseja permitir
        optionsSuccessStatus: 200 // Para compatibilidade com navegadores mais antigos
    };*/
    app.use((0, cors_1.default)());
    app.use(express_1.default.json());
    app.use("/", router_1.default);
    app.listen(port);
    if (process.env.ENVIRONMENT == "DES") {
        console.log(``);
        console.log(``);
        console.log(``);
    }
    Tools_1.default.pagConsole(`Pag BackEnd - Start`, true, true);
    Tools_1.default.pagConsole(`------------------------------------------------`, true, true);
    Tools_1.default.pagConsole(`Enviroment........................: ${process.env.ENVIRONMENT}`, true, true);
    Tools_1.default.pagConsole(`Mirror............................: ${process.env.BACKEND_MIRROR}`, true, true);
    Tools_1.default.pagConsole(`Tocken Persist....................: ${process.env.HEADER_TOCKEN_PERSIST}`, true, true);
    Tools_1.default.pagConsole(`Running in port...................: ${port}`, true, true);
    Tools_1.default.pagConsole(`Version...........................: ${packgeJoson.version}`, true, true);
    Tools_1.default.pagConsole(`Utiliza Base ZANTHUS SQL SERVER...: ${Tools_1.default.myENV().BASE_ZANTHUS_SQL.toString()}`, true, true);
    Tools_1.default.pagConsole(`------------------------------------------------`, true, true);
    Tools_1.default.pagConsole(`Data Hora ${new Date().toLocaleString('pt-BR')}`, true, true);
    serviceSistema_1.default.BackendStart.defaultStartBackEnd(`${process.env.ENVIRONMENT}`, `${process.env.BACKEND_MIRROR}`)
        .catch((e) => { throw new Error(`Erro ao iniciar o sistema ${e}`); });
}
catch (e) {
    console.error(`Error BackEnd start ${e}`);
    process.exit(1);
}
