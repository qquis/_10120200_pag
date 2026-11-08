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
//Temporada ativa de Sorteio 
const modelcrm_soterio_temporada_1 = __importDefault(require("../../model/modelcrm_soterio_temporada"));
const reportCRMSorteioTemporada_1 = __importDefault(require("../../report/ReportCRMSorteio/reportCRMSorteioTemporada"));
//Operações com os cupons zanthus
const reportZanthusCupom_1 = __importDefault(require("../../../../modules/m0055_faturamento_zanthus/report/reportZanthusCupom"));
const modelcrm_sorteio_cupom_1 = __importDefault(require("../../model/modelcrm_sorteio_cupom"));
//Scripts
const modeldb = new modelbase_1.clsBase();
class serviceCrmSorteioAtualizarBase {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametro = null) {
            var _a, e_1, _b, _c;
            try {
                /*Processa as vendas do E-COMMERCE*/
                modelbase_1.clsTools.pagConsole(`Atualizando base de sorteiors | Cupons`);
                let iTemporadaAtiva = new modelcrm_soterio_temporada_1.default();
                iTemporadaAtiva = yield reportCRMSorteioTemporada_1.default.getTemporadaAtiva();
                modelbase_1.clsTools.pagConsole(`Atualizando base de sorteiors | E-commerce`);
                yield this.importEcommerceDataBaseBlueSoft(iTemporadaAtiva);
                let lresultZanthusCupom = [];
                if (parametro.data_emissao && parametro.data_emissao != '') {
                    let data_parametro = modelbase_1.clsTools._datemomentDatStrToDate(parametro.data_emissao, "YYYY-MM-DD");
                    lresultZanthusCupom = yield reportZanthusCupom_1.default.get({
                        filtrar_data_cupom: 1,
                        data_cupom_ini: data_parametro,
                        data_cupom_fim: data_parametro,
                        filtrar_valor: 1,
                        valor_inicial: iTemporadaAtiva.crm_so_temp_valor_minimo,
                        valor_final: 100000,
                        status_cancelado: 0
                    });
                }
                else {
                    lresultZanthusCupom = yield reportZanthusCupom_1.default.get({
                        filtrar_data_cupom: 1,
                        data_cupom_ini: iTemporadaAtiva.crm_so_temp_data_ini,
                        data_cupom_fim: iTemporadaAtiva.crm_so_temp_data_fim,
                        filtrar_valor: 1,
                        valor_inicial: iTemporadaAtiva.crm_so_temp_valor_minimo,
                        valor_final: 100000,
                        status_cancelado: 0
                    });
                }
                let numeroTotalCuponsZanthus = lresultZanthusCupom.length;
                let numerodeBlocos = Math.ceil(numeroTotalCuponsZanthus / 200);
                let numeroblocoo = 0;
                let icontrolInsert = 0;
                let icontrolInsertMax = 200;
                let icontrolInsertSQL = ``;
                try {
                    for (var _d = true, lresultZanthusCupom_1 = __asyncValues(lresultZanthusCupom), lresultZanthusCupom_1_1; lresultZanthusCupom_1_1 = yield lresultZanthusCupom_1.next(), _a = lresultZanthusCupom_1_1.done, !_a; _d = true) {
                        _c = lresultZanthusCupom_1_1.value;
                        _d = false;
                        const itemZanthusCupom = _c;
                        let imodelcrm_sorteio_cupom = new modelcrm_sorteio_cupom_1.default();
                        icontrolInsertSQL += imodelcrm_sorteio_cupom.script_insert_cupom_zanthus(iTemporadaAtiva.crm_so_temp_cd, iTemporadaAtiva.crm_so_temp_valor_minimo, itemZanthusCupom);
                        if (icontrolInsert >= icontrolInsertMax) {
                            yield modeldb.myDataBase.pag.Execute(icontrolInsertSQL);
                            icontrolInsertSQL = ``;
                            icontrolInsert = 0;
                            numeroblocoo += 1;
                        }
                        icontrolInsert += 1;
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = lresultZanthusCupom_1.return)) yield _b.call(lresultZanthusCupom_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (icontrolInsertSQL != ``) {
                    yield modeldb.myDataBase.pag.Execute(icontrolInsertSQL);
                    icontrolInsertSQL = ``;
                    icontrolInsert = 0;
                }
                modelbase_1.clsTools.pagConsole(`Atualização da base de sorteios realizada! NUmero de registros a processar ${lresultZanthusCupom.length}`);
            }
            catch (error) {
                modelbase_1.clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioAtualizarBase - start", error);
                throw error;
            }
        });
    }
    static importEcommerceDataBaseBlueSoft(iTemporadaAtiva) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let scriptSQL = `insert into tbcrm_sorteio_cupom
                                        (
                                                crm_so_temp_cd
                                            ,	numero_cupom 
                                            ,	numero_pedido 
                                            ,	data_emissao 
                                            ,	data_emissao_hora 
                                            ,	sat_ecf 
                                            ,	nf_numero
                                            ,	nf_data_emissao 
                                            ,	nf_chave
                                            , 	valor
                                            , 	cpf_cnpj 
                                        )
                                    select 	${iTemporadaAtiva.crm_so_temp_cd} as crm_so_temp_cd
                                        ,	nf.numeropedido as numero_cupom
                                        ,	nf.numeropedido as numero_pedido
                                        ,	nf.data_emissao as data_emissao
                                        ,	cast(nf.data_emissao || ' 08:01:01' as timestamp) as data_emissao_hora
                                        ,	99 as sat_ecf
                                        ,	df.df_nf_numero as nf_numero  
                                        ,	nf.data_faturamento as nf_data_emissao 
                                        ,	df.df_chave  as nf_chave
                                        ,  	nf.valor_faturamento as valor
                                        ,	ps.cpf_cnpj as cpf_cnpj 

                                    from 		tbfaturamento_bluesoft nf
                                    inner join 	tbpessoabluesoft ps on ps.cdpessoabluesoft = nf.cdpessoabluesoft_cliente
                                    inner join  tbdocumentofiscal df on df.df_nf_seq_blue = nf.df_nf_seq_blue 
                                    where op_cdoperacao = 4
                                    and data_faturamento >= '${modelbase_1.clsTools._datemomentDateToStr(iTemporadaAtiva.crm_so_temp_data_ini, 'YYYY-MM-DD')}'
                                    and valor_faturamento >= ${iTemporadaAtiva.crm_so_temp_valor_minimo}
                                    and not exists (select 1
                                                    from tbcrm_sorteio_cupom x 
                                                    where x.numero_pedido = nf.numeropedido
                                                    and x.sat_ecf = 99 
                                                )	
                                    ;                

                                    `;
                yield modeldb.myDataBase.pag.Execute(scriptSQL);
            }
            catch (error) {
                modelbase_1.clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioAtualizarBase - importEcommerceDataBaseBlueSoft", error);
                throw error;
            }
        });
    }
}
exports.default = serviceCrmSorteioAtualizarBase;
