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
const modelfc_figurafiscal_1 = __importDefault(require("../model/modelfc_figurafiscal"));
const modelfc_regrafiscal_1 = __importDefault(require("../model/modelfc_regrafiscal"));
const myBase = new modelbase_1.clsBase();
class serviceFiguraFiscalRegraFiscal {
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                modelbase_1.clsTools.pagConsole('Modulo M0040 - Fiscal | serviceFiguraFiscalRegraFiscal.start - Iniciando...', false, false);
                let result = yield myBase.blueSoftApi.api_get('/fiscal/figurafiscal');
                let iControl = 0;
                let iControlMax = 50;
                let sqlinsert = '';
                //console.log(result.data)
                if (result && result.data) {
                    for (let itemData of result.data) {
                        let item = new modelfc_figurafiscal_1.default();
                        item.bindingApiBluesoft(itemData);
                        /* Atualiza o cadastro das regras fiscais*/
                        yield this.atualizarRegras(item.fc_figurafiscal_cd);
                        sqlinsert = item.script_insert();
                        if (iControl < iControlMax) {
                            yield myBase.myDataBase.pag.Execute(sqlinsert);
                            sqlinsert = '';
                            iControl = 0;
                        }
                        iControl++;
                    }
                    if (sqlinsert != '') {
                        yield myBase.myDataBase.pag.Execute(sqlinsert);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Figura', e);
            }
            finally {
                modelbase_1.clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.ImportarFigura.atualizarBasePag - Finalizado', false, false);
            }
        });
    }
    static atualizarRegras(codigoFiguraFISac) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let result = yield myBase.blueSoftApi.api_get(`fiscal/regrafiscal/completa?codigoFiguraFiscal=${codigoFiguraFISac}`);
                let sqlinsert = '';
                if (result && result.data.data) {
                    let lista = result.data.data;
                    for (let itemData of lista) {
                        let item = new modelfc_regrafiscal_1.default();
                        yield item.bindingApiBluesoft(itemData);
                        sqlinsert += item.scriptSqlRegraFiscal();
                        sqlinsert += item.ItemIcms.script_insert();
                    }
                }
                if (sqlinsert != '') {
                    //console.log(sqlinsert);
                    yield myBase.myDataBase.pag.Execute(sqlinsert);
                }
                else {
                    modelbase_1.clsTools.pagConsole(`Nenhuma regra fiscal encontrada para a figura fiscal: ${codigoFiguraFISac}`, false, false);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_ImportarFigura.atualizarRegras', e);
            }
        });
    }
}
exports.default = serviceFiguraFiscalRegraFiscal;
