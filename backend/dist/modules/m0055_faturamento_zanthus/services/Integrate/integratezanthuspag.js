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
const Tools_1 = __importDefault(require("../../../../tools/Tools"));
const modelsistema_ServiceBatch_1 = __importDefault(require("../../../m9030_sistema_batch/model/modelsistema_ServiceBatch"));
const integratezanthusctrl_1 = __importDefault(require("./integratezanthusctrl"));
class integrateZanthusPag {
    //public static async Ctrl_Get (filter: ifilter_faturamentoZanthus): Promise<object> {
    static Start(_filter) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            var _d, _e, _f, _g;
            try {
                /* Controle de Path */
                let imodelsistema_batch = new modelsistema_ServiceBatch_1.default(0);
                //__console.log(`Parâmetro sis_bath_run_seq repassado ${_filter.post_integracao?.sis_batch_run_seq}`)
                if (((_d = _filter.post_integracao) === null || _d === void 0 ? void 0 : _d.sis_batch_run_seq) !== 0)
                    yield imodelsistema_batch.modelConsultar(0, parseInt(`${(_e = _filter.post_integracao) === null || _e === void 0 ? void 0 : _e.sis_batch_run_seq}`));
                //__console.log(`M0055_Faturamento - SIS BATCH IDENTIFICADO: ${imodelsistema_batch.sistema_batch.sis_batch_cd}`)
                /*
                if (_filter.post_integracao?.sis_batch_run_seq) {
                    imodelsistema_batch.modelConsultar(0, parseInt(`${_filter.post_integracao?.sis_batch_run_seq}`));
                
                }*/
                /*Lista com Ecfs com dados Pendentes */
                let mylist_ECF_PENDENTES;
                /*Processar dados da ECF*/
                yield integratezanthusctrl_1.default._ECF_Atualizar_Integracao(_filter);
                /*Obter ECFS com dados Pendentes*/
                mylist_ECF_PENDENTES = yield integratezanthusctrl_1.default._ECF_Obter_Pendentes(_filter);
                yield Tools_1.default.pagConsoleLog(`Faturamento - Integração de Cupons | Numero de ECFS ${mylist_ECF_PENDENTES.length} `);
                try {
                    //console.log(`Faturamento - Integração de Cupons | Numero de ECFS ${mylist_ECF_PENDENTES.length} `)
                    //console.log(mylist_ECF_PENDENTES)
                    for (var _h = true, mylist_ECF_PENDENTES_1 = __asyncValues(mylist_ECF_PENDENTES), mylist_ECF_PENDENTES_1_1; mylist_ECF_PENDENTES_1_1 = yield mylist_ECF_PENDENTES_1.next(), _a = mylist_ECF_PENDENTES_1_1.done, !_a; _h = true) {
                        _c = mylist_ECF_PENDENTES_1_1.value;
                        _h = false;
                        let iTemECF_PENDENTE = _c;
                        yield Tools_1.default.pagConsoleLog(`Faturamento - Integração de Cupons | Processando ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac}`);
                        //console.log(`Faturamento - Integração de Cupons | Processando ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac} VALOR ZANTHUS ${iTemECF_PENDENTE.fz_valor} VALOR PAGA ${iTemECF_PENDENTE.fz_pag_valor}`)
                        let NCupomPendente = 0;
                        /*
                        let messagecomparacao = `Comparando dados do ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac} \n`
                        messagecomparacao += ` ZANTHUS CUPOM ${iTemECF_PENDENTE.fz_cupom_qtde}  \n`
                        messagecomparacao += ` ZANTHUS PAG ${iTemECF_PENDENTE.fz_pag_cupom_qtde} \n`
                        messagecomparacao += ` PAG ${iTemECF_PENDENTE.fat_cupom_qtde} \n `
        
        
                        messagecomparacao += `ZANTHUS - VALOR ${iTemECF_PENDENTE.fz_valor} \n`
                        messagecomparacao += `ZANTHUS PAG - VALOR ${iTemECF_PENDENTE.fz_pag_valor} \n`
                        messagecomparacao += `PAG - VALOR ${iTemECF_PENDENTE.fat_valor}`
        
                        await clsTools.pagConsole(messagecomparacao, true, false)
                        */
                        // Se as bases estão diferentes então faz o processamento
                        if (iTemECF_PENDENTE.fz_cupom_qtde !== iTemECF_PENDENTE.fz_pag_cupom_qtde
                            || iTemECF_PENDENTE.fz_pag_valor !== iTemECF_PENDENTE.fz_valor
                            || iTemECF_PENDENTE.fat_valor !== iTemECF_PENDENTE.fz_valor
                            || iTemECF_PENDENTE.fat_cupom_qtde !== iTemECF_PENDENTE.fz_cupom_qtde) {
                            if (((_f = _filter === null || _filter === void 0 ? void 0 : _filter.post_integracao) === null || _f === void 0 ? void 0 : _f.integracao_registro) == "PENDENTE") {
                                if (iTemECF_PENDENTE.fz_pag_cupom_final > 5)
                                    NCupomPendente = iTemECF_PENDENTE.fz_pag_cupom_final - 1;
                                //console.log(`Numero do cupom que vai processar: ${NCupomPendente}`)
                            }
                            if (imodelsistema_batch.sistema_batch.sis_batch_cd) {
                                let status = yield imodelsistema_batch.ModelStatus(parseInt(`${(_g = _filter.post_integracao) === null || _g === void 0 ? void 0 : _g.sis_batch_run_seq}`));
                                if (!status) {
                                    Tools_1.default.pagConsoleLog("M0055_Faturamento - Sisbatch está inativo e portando a execução será encerrada");
                                    return Promise.resolve(mylist_ECF_PENDENTES);
                                }
                                else {
                                    yield Tools_1.default.pagConsoleLog("M0055_Faturamento - Batch irá continuar BATCH ATIVO");
                                }
                            }
                            //__console.log(`Processando ECF ${itemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac}`)
                            /* ____ PROCESSANDO OS CUPONS ___ */
                            if (imodelsistema_batch.sistema_batch.sis_batch_cd)
                                yield imodelsistema_batch.ModelRegistrarLog(`5501_ZANTHUS`, `ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac} - Processando`);
                            yield iTemECF_PENDENTE.__CupomProcessar(_filter, NCupomPendente);
                            /* ____ FATURANDO OS CUPONS ___ */
                            if (imodelsistema_batch.sistema_batch.sis_batch_cd)
                                yield imodelsistema_batch.ModelRegistrarLog(`5501_ZANTHUS`, `ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac} - Faturando`);
                            yield iTemECF_PENDENTE.__CupomFaturar();
                            /* ____ ESTORNANDO OS CUPONS ___ */
                            if (imodelsistema_batch.sistema_batch.sis_batch_cd)
                                yield imodelsistema_batch.ModelRegistrarLog(`5501_ZANTHUS`, `ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac} - Estornando Cancelados`);
                            yield iTemECF_PENDENTE.__ProcessarCancelados();
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_h && !_a && (_b = mylist_ECF_PENDENTES_1.return)) yield _b.call(mylist_ECF_PENDENTES_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                yield integratezanthusctrl_1.default.CtrlUpdatePagFaturamento(_filter);
                return Promise.resolve(mylist_ECF_PENDENTES);
            }
            catch (e) {
                yield Tools_1.default.pagConsoleLog(`integrateZanthusPag | ${e}`);
                return Promise.reject({});
            }
        });
    }
}
exports.default = integrateZanthusPag;
