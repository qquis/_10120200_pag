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
const modelbase_1 = require("../../../model/modelbase");
const serviceSistemaNotificacao_1 = __importDefault(require("./serviceSistemaNotificacao"));
const f0001_01_sistema_start_1 = __importDefault(require("../scriptdb/f0001_01_sistema_start"));
let myBase = new modelbase_1.clsBase();
class serviceSistemaBackendStart {
    static defaultStartBackEnd() {
        return __awaiter(this, arguments, void 0, function* (enviroment = 'PRD', backend_mirror = `0`) {
            try {
                yield this.startbackend(enviroment, backend_mirror);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceSistema', 'defaultStartBackEnd', e);
                throw new Error('Error in serviceSistema.defaultStartBackEnd');
            }
        });
    }
    static startbackend(venvironment_1) {
        return __awaiter(this, arguments, void 0, function* (venvironment, backend_mirror = `0`) {
            try {
                let result = yield myBase.myDataBase.pag.Execute(f0001_01_sistema_start_1.default.get({ venvironment: venvironment, vbackend_mirror: backend_mirror }));
                if (result !== 0) {
                    if (venvironment == "DES") {
                        modelbase_1.clsTools.pagConsole(`------------------------------------------------`, true, true);
                        modelbase_1.clsTools.pagConsole(`AMBIENTE DE DESENVOLVIMENTO`, true, true);
                        modelbase_1.clsTools.pagConsole(` - Não será enviado WHATS de inicialização`, true, true);
                        modelbase_1.clsTools.pagConsole(`------------------------------------------------`, true, true);
                    }
                    else {
                        yield serviceSistemaNotificacao_1.default.notificar(`🖥️ Backend inicializado | ENV ${venvironment} TIPO: ${backend_mirror == "0" ? "PRINCIPAL" : "SECUNDARIO"} - ${new Date().toLocaleTimeString('pt-BR').slice(0, 8)}`);
                    }
                }
                else {
                    yield serviceSistemaNotificacao_1.default.notificar(`Erro na inicialização do Backend  + ${Date.now()}`);
                    throw new Error('Error in startbackend');
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('serviceSistema', 'startbackend', e);
                throw new Error('serviceSistema.startbackend');
            }
        });
    }
}
exports.default = serviceSistemaBackendStart;
