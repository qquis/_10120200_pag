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
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
let myBase = new modelbase_1.clsBase();
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 10050011;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0008-Financeiro | ServiceFinanceiroFormaPgto";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceFinanceiroFormaPgto {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myBase = new modelbase_1.clsBase();
                myBase.blueSoftApi = new modelbase_1.clsBase().blueSoftApi;
                let result = yield myBase.blueSoftApi.api_get(`modulos/financeiro/cadastros/tipos-forma-pagamento`);
                if (result && result.data) {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Dados obtidos com sucesso`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    let sql = ``;
                    for (let item of result.data) {
                        sql += `INSERT INTO tbforma_pgto_bluesoft (forma_pgto_cd, forma_pgto_descricao, forma_pgto_ref_blue) 
                                SELECT ${item.tipoFormaPagamentoKey}, '${item.descricao}', '${item.descricao}'
                                WHERE NOT EXISTS (SELECT 1 FROM tbforma_pgto_bluesoft WHERE forma_pgto_cd = ${item.tipoFormaPagamentoKey}) ; `;
                    }
                    yield myBase.myDataBase.pag.Execute(sql);
                }
                else {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Nenhum dado encontrado`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, `serviceFinanceiroFormaPgto.start()`, e, true);
                throw new Error(`modules | Financeiro | Error ${e.message}`);
            }
        });
    }
}
exports.default = serviceFinanceiroFormaPgto;
