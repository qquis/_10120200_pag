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
const _serviceNotificacao_1 = __importDefault(require("../../m0210_notificacao/service/_serviceNotificacao"));
const f0045_60_aplicacao_1 = __importDefault(require("../pgscripts/f0045_60_aplicacao"));
let myDATABASE = new modelbase_1.clsBase();
class serviceAplicacao {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            let precoAplicadoComSucesso = false;
            try {
                yield myDATABASE.myDataBase.pag.Execute(f0045_60_aplicacao_1.default.SELECT());
                precoAplicadoComSucesso = true;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0045`, `servicePrecoAplicacao.start Error`, e);
                precoAplicadoComSucesso = false;
            }
            finally {
                yield _serviceNotificacao_1.default.Criar({ notificacao_cd: 1000030010,
                    notificacao_send_tipo_cd: 100,
                    notificacao_send_message: `🏷️ M0045 | A *Aplicação de Preço* ${parametros.user_name ? `realizada pelo Usuario: *` + parametros.user_name + "*, " : ""} foi concluída com ${precoAplicadoComSucesso ? 'SUCESSO ✅' : 'FALHA ❌ (CONSULTAR LOG)'}`
                });
                return precoAplicadoComSucesso;
            }
        });
    }
}
exports.default = serviceAplicacao;
