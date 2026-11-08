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
const modelbase_1 = require("../../../model/modelbase");
const report_1 = __importDefault(require("src/modules/m0001_sistema/report/report"));
const modelFaturamentoBluesoft_processo_1 = __importDefault(require("../model/modelFaturamentoBluesoft_processo"));
const reportFaturamentoBluesoftProcesso_1 = __importDefault(require("../report/reportFaturamentoBluesoftProcesso"));
const myBase = new modelbase_1.clsBase();
class serviceFaturamentoBluesoft_Processo {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield this.ForcaVendaRegistrarCortes(parametro);
                yield this.GerarNotificacoesPendentes(parametro);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoft_Processo", "start", e);
            }
        });
    }
    static ForcaVendaRegistrarCortes(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let percentualValorCorte = yield report_1.default.Parametro.getParametroValue(100500010);
                let dataInicial = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataInicial}`, `YYYY-MM-DD`);
                let dataFinal = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataFinal}`, `YYYY-MM-DD`);
                let script_registro_processo = `
                        insert into tbfaturamento_bluesoft_processo
                                    (		op_cdoperacao 
                                        ,	numeropedido
                                        ,	numeropedido_fv
                                        ,	fat_blue_status_cd
                                        ,	fat_blue_processo_tipo_cd
                                    )
                                        
                                SELECT 		f.op_cdoperacao 
                                    ,		f.numeropedido
                                    ,		f.numeropedido_fv
                                    ,		f.fat_blue_status_cd
                                    ,		20
                                FROM 		tbfaturamento_bluesoft  f
                                left join 	tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = f.fat_blue_status_cd 
                                where	1 = 1
                                and		f.data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataInicial, `YYYY-MM-DD`)}'
                                and		f.data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataFinal, `YYYY-MM-DD`)}'
                                and		f.op_cdoperacao = 1
                                and		s.fat_blue_status_cd in (55, 70)
                                AND		F.VALOR_PEDIDO > F.VALOR_FATURAMENTO 
                                and     not exists (select 1 
                                                    from 	tbfaturamento_bluesoft_processo xx
                                                    where	xx.op_cdoperacao = f.op_cdoperacao 
                                                    and   xx.numeropedido = f.numeropedido 
                                                    and   xx.numeropedido_fv = f.numeropedido_fv 
                                                    and   xx.fat_blue_status_cd = f.fat_blue_status_cd
                                                    
                                                    )
                      `;
                /*INSERE OS ITENS QUE DEVERÃO SER ENVIADAS AS MENSAGENS*/
                yield myBase.myDataBase.pag.Execute(script_registro_processo);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoft_Processo", "ForcaVendaRegistrarCortes", e);
            }
        });
    }
    static GerarNotificacoesPendentes(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                let listNotificacoes = yield reportFaturamentoBluesoftProcesso_1.default.getFaturamentoFVNotificacoesPendentes(parametro);
                try {
                    for (var _d = true, _e = __asyncValues(listNotificacoes), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const itemNotificacao = _c;
                        let modelProcesso = new modelFaturamentoBluesoft_processo_1.default();
                        modelProcesso.binding(itemNotificacao);
                        yield modelProcesso.notificar_bluesoftfaturamento_fv(itemNotificacao);
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoft_Processo", "GerarNotificacoesPendentes", e);
            }
        });
    }
}
exports.default = serviceFaturamentoBluesoft_Processo;
