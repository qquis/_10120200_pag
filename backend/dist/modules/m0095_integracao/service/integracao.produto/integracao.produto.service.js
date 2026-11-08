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
const model_service_OLD_1 = __importDefault(require("../../../../model/model.service-OLD"));
const Tools_1 = __importDefault(require("../../../../tools/Tools"));
const integracao_produto_service_default_1 = __importDefault(require("./integracao.produto.service_default"));
/* Tipo de Integrações disponíveis */
const integracao_produto_service_20004501_1 = __importDefault(require("./integracao.produto.service_20004501"));
const integracao_produto_service_20004502_1 = __importDefault(require("./integracao.produto.service_20004502"));
const integracao_produto_service_20002090_1 = __importDefault(require("./integracao.produto.service_20002090"));
const integracao_produto_service_20008501_1 = __importDefault(require("./integracao.produto.service_20008501"));
const myDATABASE = new modelbase_1.clsBase();
class integracaoProduto extends model_service_OLD_1.default {
    // ---------------------------------------------------
    constructor() {
        super();
        this.listProdutosPendentes = [];
        this.myIntegracaoDeProduto = new integracao_produto_service_default_1.default({});
        this.myid_log = ``;
    }
    integrar(myIntegracaoProcessamento_1) {
        return __awaiter(this, arguments, void 0, function* (myIntegracaoProcessamento, sis_batch_run_seq = 0, uuid_start = ``) {
            if (uuid_start !== ``)
                this.serviceLoguuidStart = uuid_start;
            this.serviceSis_Batch_Run_Seq = sis_batch_run_seq;
            try {
                this.serviceLogTAG = `M0095_IntegCtrl_(2000)_B.CD_${myIntegracaoProcessamento.integracao_tipo.sis_batch_cd}/SQ_${sis_batch_run_seq}/T_${myIntegracaoProcessamento.integracao_tipo.integracao_tipo_cd}`;
                this.myid_log = `M0095_IntegCtrl_(2000)_${myIntegracaoProcessamento.integracao_tipo.sis_batch_cd}/${sis_batch_run_seq}/${myIntegracaoProcessamento.integracao_tipo.integracao_tipo_cd}`;
                yield this._serviceLogRegister(`M0095_IntegCtrl_(2000)_ INFORMAÇÕES | Sis Batch Cd: ${myIntegracaoProcessamento.integracao_tipo.sis_batch_cd} / RUN SEQ ${sis_batch_run_seq} / TIPO ${myIntegracaoProcessamento.integracao_tipo.integracao_tipo_cd}`);
                // DEFINIÇÃO DO TIPO DE INTEGRAÇÃO
                yield this.ProdutoServiceSetTipo(myIntegracaoProcessamento);
                // START 
                yield this.myIntegracaoDeProduto.openstart(this);
                if (!this._serviceBatchStatus())
                    return;
                /* OBTER PRODUTOS PENDENTES */
                yield this._serviceLogRegister(`${this.myid_log} _ Produtos Pendentes (localizando)...`);
                this.listProdutosPendentes = yield this.myIntegracaoDeProduto.obterProdutosPendentes(this);
                myIntegracaoProcessamento.integracao_pendente_qtde = this.listProdutosPendentes.length;
                /* PROCESSAR */
                yield this._serviceLogRegister(`${this.myid_log} _ Produtos Pendentes Qtde : ${this.listProdutosPendentes.length}`);
                this.myIntegracaoDeProduto.integracao_pendente_qtde = this.listProdutosPendentes.length;
                if (this.listProdutosPendentes.length > 0) {
                    /*INICIALIZAÇÃO _ APENAS SE TIVER PRODUTOS PENDENTE ------------------------------------*/
                    yield this._serviceLogRegister(`${this.myid_log} _ Inicialização`);
                    yield this.myIntegracaoDeProduto.Inicializar();
                    //await this.ProdutoServiceGetTipoMetodo(myIntegracaoProcessamento)
                    if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 1 && this.myIntegracaoDeProduto.integracao_tipo.bluesoft_api == 1) {
                        yield this._serviceLogRegister(`${this.myid_log} _ Exportação para API/BLUE | Processando ...`);
                        yield this.Export_toApiBluesoft();
                    }
                    /* ____________ Exportações para ZANTHUS ______________________________________*/
                    if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 1 && this.myIntegracaoDeProduto.integracao_tipo.zanthus == 1) {
                        yield this._serviceLogRegister(`${this.myid_log} _ Exportação para ZANTHUS | Processando ...`);
                        yield this.Export_toZanthus();
                    }
                    /* ____________ Importações ______________________________________*/
                    if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 0 && this.myIntegracaoDeProduto.integracao_tipo.bluesoft_api == 1) {
                        yield this._serviceLogRegister(`${this.myid_log} _ Importando da API BLUE | Processando ...`);
                        yield this.Import();
                    }
                    yield this._serviceLogRegister(`${this.myid_log} _ Finalização`);
                    yield this.myIntegracaoDeProduto.Finalizar();
                }
                else {
                    this._serviceLogRegister(`${this.myid_log} _ Sem Pendências/Registros a serem processadas`);
                }
                yield this._serviceLogRegister(`${this.myid_log} _ Concluído`);
            }
            catch (e) {
                yield Tools_1.default.pagConsole(`(ERROR) M0095 _ Integração integrar | Integracao.produto.service
                                      Method Integrar 
                                      Error Message \n ${e}`, true);
                yield this._serviceLogRegister(`${this.myid_log} _ (ERROR) ${e}`);
                throw new Error();
            }
        });
    }
    CachClear(integracao_tipo_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (!integracao_tipo_cd || integracao_tipo_cd == 0) {
                    throw new Error(`M0095 | integracaoProduto | CachClear | O código do tipo de integração deve ser informado`);
                }
                let sql = `delete from tbintegracao_produto where integracao_tipo_cd = ${integracao_tipo_cd} and integracao_status_cd = 1`;
                yield myDATABASE.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0095 | integracaoProduto | CachClear`, 'DBPAG DELETE', e);
                throw new Error(`M0095 | integracaoProduto | CachClear | ${e}`);
            }
            finally {
                modelbase_1.clsTools.pagConsole(`M0095 | integracaoProduto CachClear da integração ${integracao_tipo_cd} executado`);
            }
        });
    }
    Export_toApiBluesoft() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                // console.log(`QUANTIDADE DE ITEM A EXPORTAR ${this.listProdutosPendentes.length}` )
                for (let i = 0; i < this.listProdutosPendentes.length; i++) {
                    try {
                        if (yield this.myIntegracaoDeProduto.ApiItemValidar(this.listProdutosPendentes[i])) {
                            yield this.myIntegracaoDeProduto.ApiItemProcessar(this.listProdutosPendentes[i].ItemObjectIntegracao);
                            yield this.listProdutosPendentes[i].statusSetAtualizado();
                        }
                        else {
                            yield this.listProdutosPendentes[i].statusSetFinalizar();
                        }
                    }
                    catch (e) {
                        yield this.listProdutosPendentes[i].statusSetError();
                    }
                }
            }
            catch (e) {
                yield this._serviceLogRegister(`Service integracaoProduto _ ProcessarExportacoesAPI | Error \n ${e}`);
                yield Tools_1.default.pagConsole(`Service integracaoProduto _ ProcessarExportacoesAPI | Error \n ${e}`, true);
            }
        });
    }
    Export_toZanthus() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield this.myIntegracaoDeProduto.processamentoLocal(this.listProdutosPendentes, this);
            }
            catch (e) {
                yield this._serviceLogRegister(`Service integracaoProduto _ Export_toZanthus | Error \n ${e}`);
                yield Tools_1.default.pagConsole(`Service integracaoProduto _ Export_toZanthus | Error \n ${e}`, true);
            }
        });
    }
    Import() {
        const _super = Object.create(null, {
            _processPushScript: { get: () => super._processPushScript },
            _processCheck: { get: () => super._processCheck }
        });
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                //DEFINE EM QUAL BASE SERÁ LANÇADA 
                this.myDataBase_SERVER = "PAG";
                this.serviceRegistroTotal = this.listProdutosPendentes.length - 1;
                try {
                    for (var _d = true, _e = __asyncValues(this.listProdutosPendentes), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const produto = _c;
                        if (!(yield _super._processPushScript.call(this, yield this.myIntegracaoDeProduto.getStrCRUDPostGre(produto.ItemObjectIntegracao)))) {
                            yield this._serviceLogRegister(`Integração INTERROMPIDA - Status RUN FINALIZADO`);
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
                yield _super._processCheck.call(this, true);
            }
            catch (e) {
                yield this._serviceLogRegister(`Service integracaoProduto _ ProcessarImportacao | Error \n ${e}`);
                yield Tools_1.default.pagConsole(`Service integracaoProduto _ ProcessarImportacao | Error \n ${e}`, true);
            }
        });
    }
    ProdutoServiceSetTipo(myIntegracaoProcessamento) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this._serviceLogRegister(`${this.myid_log} _ constructor ${myIntegracaoProcessamento.integracao_tipo.integracao_tipo_cd}`);
            switch (myIntegracaoProcessamento.integracao_tipo.integracao_tipo_cd) {
                case 20004501:
                    this.myIntegracaoDeProduto = new integracao_produto_service_20004501_1.default(myIntegracaoProcessamento.integracao_tipo);
                    break;
                case 20004502:
                    this.myIntegracaoDeProduto = new integracao_produto_service_20004502_1.default(myIntegracaoProcessamento.integracao_tipo);
                    break;
                case 20008501:
                    this.myIntegracaoDeProduto = new integracao_produto_service_20008501_1.default(myIntegracaoProcessamento.integracao_tipo);
                    break;
                case 20002090:
                    this.myIntegracaoDeProduto = new integracao_produto_service_20002090_1.default(myIntegracaoProcessamento.integracao_tipo);
                    break;
                default:
                    this.myIntegracaoDeProduto = new integracao_produto_service_default_1.default(myIntegracaoProcessamento.integracao_tipo);
                    break;
            }
            this.myIntegracaoDeProduto.integracao_tipo_info.script_select = myIntegracaoProcessamento.integracao_tipo_info.script_select;
            this.myIntegracaoDeProduto.integracao_tipo_info.sis_batch_cd = myIntegracaoProcessamento.integracao_tipo_info.sis_batch_cd;
            //await this._serviceLogRegister(`${this.myid_log} _ Processando Tipo ${myIntegracaoProcessamento.integracao_tipo.integracao_tipo_descricao} (Batch) ${myIntegracaoProcessamento.sis_batch_descricao}`)
        });
    }
    ProdutoServiceGetTipoMetodo(myIntegracaoProcessamento) {
        return __awaiter(this, void 0, void 0, function* () {
            let TipoMetodo = Promise.resolve();
            try {
                /* ____________ Exportações para API ______________________________________*/
                if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 1 && this.myIntegracaoDeProduto.integracao_tipo.bluesoft_api == 1) {
                    yield this._serviceLogRegister(`${this.myid_log} _ A integração é do tipo EXportação | Processando ...`);
                    TipoMetodo = this.Export_toApiBluesoft();
                }
                /* ____________ Exportações para ZANTHUS ______________________________________*/
                if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 1 && this.myIntegracaoDeProduto.integracao_tipo.zanthus == 1) {
                    yield this._serviceLogRegister(`${this.myid_log} _ A integração é do tipo EXportação | Processando ...`);
                    TipoMetodo = this.Export_toZanthus();
                }
                /* ____________ Importações ______________________________________*/
                if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 0 && this.myIntegracaoDeProduto.integracao_tipo.bluesoft_api == 1) {
                    yield this._serviceLogRegister(`${this.myid_log} _ A integração é do tipo IMportação | Processando ...`);
                    TipoMetodo = this.Import();
                }
                return TipoMetodo;
            }
            catch (e) {
                return TipoMetodo;
            }
        });
    }
}
exports.default = integracaoProduto;
