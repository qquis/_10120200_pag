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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../../model/modelbase");
//Operações com os cupons zanthus
const reportCRMSorteioConsultarCupom_1 = __importDefault(require("../../report/ReportCRMSorteio/reportCRMSorteioConsultarCupom"));
class serviceCrmSorteioExportar {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            const LOGFILENAME = `.export_sorteio_${parametro.data_emissao ? parametro.data_emissao : "ERRO_DATA_NAO_INFORMADA.log"}`;
            try {
                const modeldb = new modelbase_1.clsBase();
                let listCupons = [];
                listCupons = yield reportCRMSorteioConsultarCupom_1.default.get({
                    status_envio_sorteio: 0,
                    data_emissao: parametro.data_emissao ? parametro.data_emissao : '',
                    crm_so_cupom_seq: parametro.crm_so_cupom_seq ? parametro.crm_so_cupom_seq : 0
                });
                if (listCupons.length == 0) {
                    modelbase_1.clsTools.pagConsole("Nenhum cupom pendente para envio ao sistema externo de sorteio.");
                    return;
                }
                let myLIST_itemSorteioExterno = [];
                let i = 0;
                let icontrolInsertMax = 200;
                let icontrolTotalBloco = listCupons.length / icontrolInsertMax;
                let icontrolBloco = 1;
                try {
                    for (var _d = true, listCupons_1 = __asyncValues(listCupons), listCupons_1_1; listCupons_1_1 = yield listCupons_1.next(), _a = listCupons_1_1.done, !_a; _d = true) {
                        _c = listCupons_1_1.value;
                        _d = false;
                        const itemCupom = _c;
                        myLIST_itemSorteioExterno.push(this.mapearPropriedades(itemCupom));
                        modelbase_1.clsTools.pagConsoleFile(`${modelbase_1.clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ Exportação SORTEIO EXTERNO SEQ ${itemCupom.crm_so_cupom_seq} _ CP ${itemCupom.numero_cupom} _ CPF ${itemCupom.cpf_cnpj}`, LOGFILENAME);
                        if (i >= icontrolInsertMax) {
                            yield this.ProcessarEnvio(myLIST_itemSorteioExterno, LOGFILENAME);
                            myLIST_itemSorteioExterno = [];
                            icontrolBloco++;
                            i = 0;
                        }
                        i++;
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listCupons_1.return)) yield _b.call(listCupons_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (myLIST_itemSorteioExterno.length > 0) {
                    yield this.ProcessarEnvio(myLIST_itemSorteioExterno, LOGFILENAME);
                }
            }
            catch (error) {
                modelbase_1.clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioAtualizarBase - start", error);
                throw error;
            }
            finally {
                modelbase_1.clsTools.pagConsole("Finalizando processo de exportação de cupons para sistema externo de sorteio.");
                modelbase_1.clsTools.pagConsoleFile(`${modelbase_1.clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ PROCESSO FINALIZADO`, LOGFILENAME);
            }
        });
    }
    static mapearPropriedades(itemCupom) {
        let itemSorteioExterno = {
            idorigem: itemCupom.crm_so_cupom_seq,
            doc_num: itemCupom.cpf_cnpj ? itemCupom.cpf_cnpj.substring(itemCupom.cpf_cnpj.length - 11) : '',
            loja: 1,
            cupom: itemCupom.numero_cupom ? itemCupom.numero_cupom : 0,
            data_hora: modelbase_1.clsTools._datemomentDateToStr(itemCupom.data_emissao_hora ? itemCupom.data_emissao_hora : new Date(), 'YYYY-MM-DD HH:mm:ss'),
            data: modelbase_1.clsTools._datemomentDateToStr(itemCupom.data_emissao ? itemCupom.data_emissao : new Date(), 'YYYY-MM-DD'),
            fidelidade: 0,
            tipo_venda: 1,
            valor: itemCupom.valor ? itemCupom.valor : 0
        };
        return itemSorteioExterno;
    }
    static ProcessarEnvio(myLIST_itemSorteioExterno, LOGFILENAME) {
        return __awaiter(this, void 0, void 0, function* () {
            let NaoProcessados = [];
            try {
                modelbase_1.clsTools.pagConsoleFile(`${modelbase_1.clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ ACESSANDO API`, LOGFILENAME);
                let apiSorteioExterno_envio = {
                    akey: "55bf55e11f060db80f2dd4ea885f1ce8592eb4edaf896dbe71e4cc6cf5ff044c",
                    data: myLIST_itemSorteioExterno
                };
                let myBase = new modelbase_1.clsBase();
                let result = yield myBase.sorteioExternoApi.sorteioExternoApi_post("/api-services/sales", apiSorteioExterno_envio);
                if (result.data.extra) {
                    modelbase_1.clsTools.pagConsoleFile(`${modelbase_1.clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ NÚMERO NÃO PROCESSADOS: ${result.data.extra.length}`, LOGFILENAME);
                    NaoProcessados = result.data.extra;
                    modelbase_1.clsTools.pagConsoleFile(`${modelbase_1.clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ Exportação SORTEIO EXTERNO - Não processados: ${JSON.stringify(NaoProcessados)}`, LOGFILENAME);
                }
                else {
                    modelbase_1.clsTools.pagConsoleFile(`${modelbase_1.clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ TODOS OS CUPONS FORAM PROCESSADOS COM SUCESSO. NÃO FOI ENCONTRADO O REGISTRO EXTRA`, LOGFILENAME);
                }
                yield this.RegistrarLogEnvio(myLIST_itemSorteioExterno, NaoProcessados);
            }
            catch (error) {
                modelbase_1.clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioExportar - ProcessarEnvio", error);
                throw error;
            }
            finally {
                console.log("Envio API - Finalizando [Não Processados", NaoProcessados);
                return NaoProcessados;
            }
        });
    }
    static RegistrarLogEnvio(myLIST_itemSorteioExterno, NaoProcessados) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, myLIST_itemSorteioExterno_1, myLIST_itemSorteioExterno_1_1;
            var _b, e_2, _c, _d;
            try {
                console.log("Iniciando registro de log de envio...");
                let iCountUpdateMax = 200;
                let iCount = 0;
                let sql = ``;
                try {
                    for (_a = true, myLIST_itemSorteioExterno_1 = __asyncValues(myLIST_itemSorteioExterno); myLIST_itemSorteioExterno_1_1 = yield myLIST_itemSorteioExterno_1.next(), _b = myLIST_itemSorteioExterno_1_1.done, !_b; _a = true) {
                        _d = myLIST_itemSorteioExterno_1_1.value;
                        _a = false;
                        const item = _d;
                        let statusNaoProcessado = NaoProcessados.find((x) => x == item.idorigem);
                        sql += `update tbcrm_sorteio_cupom 
                            set crm_so_externo_enviado = ${(statusNaoProcessado) ? 9 : 1}
                        ,   crm_so_externo_enviado_data = current_timestamp
                        where crm_so_cupom_seq = ${item.idorigem} ;

                    `;
                        if (iCount >= iCountUpdateMax) {
                            iCount = 0;
                            yield this.updateCupomExternoEnviado(sql);
                            sql = ``;
                        }
                        iCount++;
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = myLIST_itemSorteioExterno_1.return)) yield _c.call(myLIST_itemSorteioExterno_1);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                /*Execucao dos itens restantes*/
                if (sql != ``) {
                    yield this.updateCupomExternoEnviado(sql);
                }
            }
            catch (error) {
                modelbase_1.clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioExportar - RegistrarLogEnvio", error);
                throw error;
            }
        });
    }
    static updateCupomExternoEnviado(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const modeldb = new modelbase_1.clsBase();
                yield modeldb.myDataBase.pag.Execute(sql);
            }
            catch (error) {
                modelbase_1.clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioExportar - updateCupomExternoEnviado", error);
                throw error;
            }
        });
    }
}
exports.default = serviceCrmSorteioExportar;
