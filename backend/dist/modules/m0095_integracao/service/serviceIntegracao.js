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
const model_service_OLD_1 = __importDefault(require("../../../model/model.service-OLD"));
const modelintegracao_tipo_1 = __importDefault(require("../model/modelintegracao_tipo"));
const integracao_produto_service_1 = __importDefault(require("./integracao.produto/integracao.produto.service"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const service_1 = __importDefault(require("../../../modules/m0085_zanthus/service/service"));
let myZanthusService = new service_1.default();
class serviceIntegracao extends model_service_OLD_1.default {
    constructor() {
        super();
        this.serviceLogTAG = "M0095_IntegCtrl";
        this.myListIntegracaoTipo = [];
    }
    processar(sis_batch_cd_1, sis_batch_run_seq_1) {
        return __awaiter(this, arguments, void 0, function* (sis_batch_cd, sis_batch_run_seq, uuid_start = ``, sis_nucleo_prc_cd = 0) {
            var _a, e_1, _b, _c;
            try {
                if (uuid_start !== ``)
                    this.serviceLoguuidStart = uuid_start;
                this.serviceSis_Batch_Run_Seq = sis_batch_run_seq;
                yield this._serviceLogRegister(`M0095_IntegCtrl Ctl B.Cd ${sis_batch_cd} Run Seq ${sis_batch_run_seq} | Init`);
                /*Buscar a lista de modelintegracao e atualizar o this.myListIntegracaoTipo */
                yield this.ObterTipoDeIntegracao(sis_batch_cd, sis_batch_run_seq, sis_nucleo_prc_cd);
                yield this._serviceLogRegister(`M0095_IntegCtrl Ctl B.Cd ${sis_batch_cd} Run Seq ${sis_batch_run_seq} | N. de Batchs detectados ${this.myListIntegracaoTipo.length}`);
                if (this.myListIntegracaoTipo.length > 0) {
                    try {
                        for (var _d = true, _e = __asyncValues(this.myListIntegracaoTipo), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                            _c = _f.value;
                            _d = false;
                            const integracaoTipo = _c;
                            yield this._serviceLogRegister(`M0095_IntegCtrl Ctl B.Cd ${sis_batch_cd} RS ${sis_batch_run_seq} | Start ${integracaoTipo.integracao_tipo.integracao_tipo_cd}_${integracaoTipo.integracao_tipo.integracao_tipo_descricao}`);
                            switch (integracaoTipo.integracao_tipo.integracao_cd) {
                                case 1000:
                                    break;
                                case 2000:
                                    const IntegracaoTipoProduto = new integracao_produto_service_1.default();
                                    yield IntegracaoTipoProduto.integrar(integracaoTipo, sis_batch_run_seq, this.serviceLoguuidStart);
                                    break;
                            }
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
                yield this._serviceLogRegister(`Control sis_batch_cd ${sis_batch_cd} sis_batch_run_seq ${sis_batch_run_seq} | Encerrado`);
                return this.myListIntegracaoTipo;
            }
            catch (e) {
                Tools_1.default.pagConsole(`Reports | Error \n ${e}`, true);
                throw new Error(`M0095 | Error \n ${e}`);
            }
        });
    }
    ClearCache(integracao_tipo_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                //Por enquanto serão processadas apenas clearcach de integração do tipo de produtos
                const IntegracaoTipoProduto = new integracao_produto_service_1.default();
                yield IntegracaoTipoProduto.CachClear(integracao_tipo_cd);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0095 | integracaoProduto | CachClear`, 'CachClear', e);
                throw new Error(`M0095 | integracaoProduto | CachClear | ${e}`);
            }
            finally {
                modelbase_1.clsTools.pagConsole(`M0095 | integracaoProduto CachClear da integração ${integracao_tipo_cd} executado`);
            }
        });
    }
    ObterTipoDeIntegracao(sis_batch_cd_1, sis_batch_run_seq_1) {
        return __awaiter(this, arguments, void 0, function* (sis_batch_cd, sis_batch_run_seq, sis_nucleo_prc_cd = 0, integracao_tipo_cd = 0) {
            var _a, e_2, _b, _c;
            let mylistIntegracaoTipo = [];
            try {
                let sql = ` select      tp.integracao_tipo_cd
                                        ,   tp.integracao_cd
                                        ,   tp.integracao_tipo_descricao
                                        ,   tp.zanthus 
                                        ,   tp.bluesoft_redshift
                                        ,   tp.bluesoft_api
                                        ,   tp.tipo_export
                                        ,   tp.tipo_import
                                        ,   x.sis_batch_cd
                                        ,   cast(0 as int) as integracao_pendente_qtde
                                        ,   x.script_select 
                                        ,   b.sis_batch_descricao 
                                from        tbintegracao_tipo       tp 
                                inner join  tbintegracao_tipo_info  x  on x.integracao_tipo_cd = tp.integracao_tipo_cd
                                left  join  tbsistema_batch         b  on b.sis_batch_cd = x.sis_batch_cd
                                where    1 = 1  
                                ${(sis_batch_run_seq !== 0 ? ` and x.sis_batch_cd in 
                                                                       ( select xx.sis_batch_cd 
                                                                         from   tbsistema_batch_run xx 
                                                                         where  1 = 1
                                                                         and    xx.sis_batch_run_seq = ${sis_batch_run_seq} ) 
                                                                         `
                    : ``)}  
                                                               
                                ${(sis_batch_cd !== 0 ? ` and x.sis_batch_cd = ${sis_batch_cd} ` : ``)} 

                                ${(sis_nucleo_prc_cd !== 0 ? ` and x.sis_nucleo_prc_cd = ${sis_nucleo_prc_cd} ` : ``)}

                                ${(integracao_tipo_cd !== 0 ? ` and tp.integracao_tipo_cd = ${integracao_tipo_cd} ` : ``)}

                                order by tp.integracao_tipo_cd asc `;
                let result = yield this.DataGet(sql);
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let itemModelIntegracao_Tipo = new modelintegracao_tipo_1.default(value);
                        yield mylistIntegracaoTipo.push(itemModelIntegracao_Tipo);
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                this.myListIntegracaoTipo = mylistIntegracaoTipo;
            }
            catch (e) {
                Tools_1.default.pagConsole(`Reports | Error \n ${e}`, true);
                throw new Error(`M0095 | Error \n ${e}`);
            }
        });
    }
    CargaLoja() {
        return __awaiter(this, arguments, void 0, function* (TipoCompleta = false) {
            let modelIntegracaoTipo = new modelintegracao_tipo_1.default();
            let resultadoCarga = {
                integracao_tipo_cd: 0,
                integracao_tipo_descricao: "NÃO IDENTIFICADA",
                tipoCarga: TipoCompleta ? `COMPLETA` : `PARCIAL`,
                integracao_pendente_qtde: 0,
                integracao_qtde_promocional: 0
            };
            try {
                let sis_batch_cd = 85002; /*CARHA PARCIAL*/
                if (TipoCompleta)
                    sis_batch_cd = 85001; /*CARGA COMPLETA*/
                let sis_batch_run_seq = 0;
                let result = yield this.processar(sis_batch_cd, sis_batch_run_seq);
                if (result.length > 0)
                    modelIntegracaoTipo = result[0];
                resultadoCarga.integracao_tipo_cd = modelIntegracaoTipo.integracao_tipo.integracao_tipo_cd;
                resultadoCarga.integracao_tipo_descricao = modelIntegracaoTipo.integracao_tipo.integracao_tipo_descricao;
                resultadoCarga.tipoCarga = TipoCompleta ? `COMPLETA` : `PARCIAL`;
                resultadoCarga.integracao_pendente_qtde = modelIntegracaoTipo.integracao_pendente_qtde;
                let qtdePromocional = yield myZanthusService.ZeusRetailConferirVoucher();
                resultadoCarga.integracao_qtde_promocional = qtdePromocional;
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`Reports | Error \n ${e}`, true);
                throw new Error(`M0095 | Error \n ${e}`);
            }
            finally {
                return resultadoCarga;
            }
        });
    }
}
exports.default = serviceIntegracao;
