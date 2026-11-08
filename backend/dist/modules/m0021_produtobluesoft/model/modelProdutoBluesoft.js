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
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const tbprodutobluesoft_1 = __importDefault(require("../tbs/tbprodutobluesoft"));
const tbprodutobluesofttributacao_1 = __importDefault(require("../tbs/tbprodutobluesofttributacao"));
const tbprodutobluesoft_gtins_1 = __importDefault(require("../tbs/tbprodutobluesoft_gtins"));
const tbprodutobluesoft_composicao_1 = __importDefault(require("../tbs/tbprodutobluesoft_composicao"));
const modelfc_figura_produto_1 = __importDefault(require("../../../modules/m0040_fiscal/model/modelfc_figura_produto"));
const bluesoftApiUrl_1 = __importDefault(require("../../Apis/bluesoftApi/url/bluesoftApiUrl"));
const model_1 = __importDefault(require("../../m0040_fiscal/model/model"));
const modelbase_1 = require("../../../model/modelbase");
class modelProdutoBluesoft extends tbprodutobluesoft_1.default {
    constructor() {
        super();
        this.gtinsList = [];
        this.listCebef = [];
        this.Tributacao = new tbprodutobluesofttributacao_1.default();
        this.ComposicaoList = [];
    }
    LerOsDadosDaAPI(item) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c, _d, e_2, _e, _f;
            try {
                if (item) {
                    this.prb_cdprodutobluesoft_pk = parseInt(item.produtoKey);
                    this.prb_cdprodutobluesoftunitario = parseInt(item.produtoUnitarioKey);
                    this.prb_descricao = (item.descricao || "PRODUTO SEM DESCRICAO").replace(`'`, ``);
                    this.prb_embalagemestoque = item.embalagemKey;
                    this.prb_fatorestoque = item.fatorEstoque;
                    this.prb_status_embalagemcaixa = item.caixa;
                    this.prb_embalagemcompra = "";
                    this.prb_embalagemcompra_qtdeunitaria = 0;
                    this.prb_cdbarra_principal = item.gtinPrincipal;
                    this.prb_cdprodutobluesoft_controleestoque = 0;
                    this.prb_cdprodutobluesoft_controlepreco = 0;
                    this.prb_cdsubgrupo = item.subGrupoProdutoKey;
                    this.prb_dt_cadastro = Tools_1.default._dataConvertStrtoDate(item.dataCadastro);
                    this.prb_dt_ultimaalteracao = Tools_1.default._dataConvertStrtoDate(item.ultimaAlteracao);
                    this.prb_cdpessoabluesoft_fabricante = (item.fabricanteKey || 0);
                    this.prb_vendaexterna = false;
                    this.prb_cdproduto_compra_padrao = 0;
                    this.prbf_seq = 0;
                    this.prb_status = item.status;
                    this.prb_descricao_fiscal = (item.observacaoFiscal || "").replace(`'`, ``);
                    this.prb_descricao_gondola = (item.descricaoGondola || "").replace(`'`, ``);
                    this.prb_descricao_cupom = (item.descricaoCupom || "").replace(`'`, ``);
                    this.prb_descricao_balanca = (item.descricaoBalanca || "").replace(`'`, ``);
                    this.prb_pesobruto = item.pesoBruto || 0;
                    this.prb_pesoliquido = item.pesoLiquido || 0;
                    this.prb_pesoaproximado = item.pesoAproximado || 0;
                    this.prb_altura = item.altura || 0;
                    this.prb_largura = item.largura || 0;
                    this.prb_comprimento = item.comprimento || 0;
                    this.prb_ncm = item.ncm ? item.ncm : "00000000";
                    this.prb_cest = item.cest ? item.cest : "0000000";
                    /* OBTENDO TRIBUTAÇÃO DA API DA BLUESOFT */
                    const itemTributacao = item.tributacaoEstadual;
                    let itemTributacaoSP = {};
                    itemTributacao.map((dadosSP) => __awaiter(this, void 0, void 0, function* () {
                        if (dadosSP.uf == 'SP') {
                            //console.log(dadosSP)
                            let dadosSPClienteFINAL = dadosSP.icmsDeSaidaClienteFinal;
                            this.Tributacao.prb_cdprodutobluesoft = this.prb_cdprodutobluesoft_pk;
                            this.Tributacao.prbt_icms_saida_cst = dadosSPClienteFINAL.cst.length == 2 ? `0${dadosSPClienteFINAL.cst}` : dadosSPClienteFINAL.length == 1 ? `00${dadosSPClienteFINAL.cst}` : dadosSPClienteFINAL.cst;
                            this.Tributacao.prbt_icms_aliquota_interna = dadosSPClienteFINAL.aliquota;
                            this.Tributacao.prbt_icms_reducao = dadosSPClienteFINAL.reducao;
                        }
                    }));
                    let pisCofinsSaida = item.pisCofinsSaidaNaoCumulativo;
                    this.Tributacao.prbt_pis_saida_cst = pisCofinsSaida.cst;
                    this.Tributacao.prbt_pis_saida_aliquota = pisCofinsSaida.pisAliquota;
                    this.Tributacao.prbt_cofins_saida_cst = pisCofinsSaida.cst;
                    this.Tributacao.prbt_cofins_saida_aliquota = pisCofinsSaida.cofinsAliquota;
                    this.Tributacao.prbt_ncm = item.ncm ? item.ncm : "00000000";
                    this.Tributacao.prbt_cest = item.cest ? item.cest : "0000000";
                    let anyListItemgtins = item.gtins;
                    anyListItemgtins.map(x => {
                        let itemGtin = new tbprodutobluesoft_gtins_1.default();
                        itemGtin.prb_cdprodutobluesoft = this.prb_cdprodutobluesoft_pk;
                        itemGtin.prbg_embalagem = this.prb_embalagemestoque;
                        itemGtin.prbg_cdbarra_pk = x;
                        itemGtin.prbg_embalagemdescricao = ``;
                        if (x) {
                            if (`${x}`.length >= 1)
                                this.gtinsList.push(itemGtin);
                        }
                    });
                    if (item.beneficiosFiscais) {
                        try {
                            for (var _g = true, _h = __asyncValues(item.beneficiosFiscais), _j; _j = yield _h.next(), _a = _j.done, !_a; _g = true) {
                                _c = _j.value;
                                _g = false;
                                const itemBenefiicoFiscal = _c;
                                if (itemBenefiicoFiscal.uf === "SP") {
                                    this.listCebef.push(itemBenefiicoFiscal.codigoBeneficioFiscal);
                                }
                            }
                        }
                        catch (e_1_1) { e_1 = { error: e_1_1 }; }
                        finally {
                            try {
                                if (!_g && !_a && (_b = _h.return)) yield _b.call(_h);
                            }
                            finally { if (e_1) throw e_1.error; }
                        }
                    }
                    if (item.tipoComposicao === "Kits") {
                        if (item.composicaoItens) {
                            try {
                                for (var _k = true, _l = __asyncValues(item.composicaoItens), _m; _m = yield _l.next(), _d = _m.done, !_d; _k = true) {
                                    _f = _m.value;
                                    _k = false;
                                    const itemComposicao = _f;
                                    let composicao = new tbprodutobluesoft_composicao_1.default();
                                    composicao.prb_cdprodutobluesoft_unitario = this.prb_cdprodutobluesoftunitario;
                                    composicao.prb_cdprodutobluesoft = itemComposicao.produtoParteKey;
                                    composicao.prbc_qtde = itemComposicao.pesoBrutoQuantidade || 0;
                                    composicao.prbc_descricao = itemComposicao.descricao || 'SEM DESCRICAO';
                                    composicao.prbc_percentual_composicao = itemComposicao.participacaoKitCesta || 1;
                                    this.ComposicaoList.push(composicao);
                                }
                            }
                            catch (e_2_1) { e_2 = { error: e_2_1 }; }
                            finally {
                                try {
                                    if (!_k && !_d && (_e = _l.return)) yield _e.call(_l);
                                }
                                finally { if (e_2) throw e_2.error; }
                            }
                        }
                    }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('M0021', 'modelProdutoBluesoft.getApiBluesoft', e);
                throw new Error(` Classe modelProdutoBluesoft ${e}`);
            }
        });
    }
    LerDadosRedShift(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (!item)
                    return;
                const toBoolean = (value) => value === true || value === 1 || value === "1";
                this.prb_cdprodutobluesoft_pk = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft_pk;
                this.prb_cdprodutobluesoftunitario = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoftunitario;
                this.prb_descricao = item === null || item === void 0 ? void 0 : item.prb_descricao;
                this.prb_embalagemestoque = item === null || item === void 0 ? void 0 : item.prb_embalagemestoque;
                this.prb_fatorestoque = item === null || item === void 0 ? void 0 : item.prb_fatorestoque;
                this.prb_status_embalagemcaixa = item === null || item === void 0 ? void 0 : item.prb_status_embalagemcaixa;
                this.prb_embalagemcompra = item === null || item === void 0 ? void 0 : item.prb_embalagemcompra;
                this.prb_embalagemcompra_qtdeunitaria = item === null || item === void 0 ? void 0 : item.prb_embalagemcompra_qtdeunitaria;
                this.prb_cdbarra_principal = item === null || item === void 0 ? void 0 : item.prb_cdbarra_principal;
                this.prb_cdprodutobluesoft_controleestoque = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft_controleestoque;
                this.prb_cdprodutobluesoft_controlepreco = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft_controlepreco;
                this.prb_cdsubgrupo = item === null || item === void 0 ? void 0 : item.prb_cdsubgrupo;
                this.prb_dt_cadastro = modelbase_1.clsTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.prb_dt_cadastro, "YYYY-MM-DD");
                this.prb_dt_ultimaalteracao = modelbase_1.clsTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.prb_dt_ultimaalteracao, "YYYY-MM-DD");
                this.prb_cdpessoabluesoft_fabricante = item === null || item === void 0 ? void 0 : item.prb_cdpessoabluesoft_fabricante;
                this.prb_vendaexterna = item === null || item === void 0 ? void 0 : item.prb_vendaexterna;
                this.prb_descricao_fiscal = " - ";
                this.prb_cdproduto_compra_padrao = item === null || item === void 0 ? void 0 : item.prb_cdproduto_compra_padrao;
                this.prbf_seq = item === null || item === void 0 ? void 0 : item.prbf_seq;
                this.prb_status = item === null || item === void 0 ? void 0 : item.prb_status;
                this.prb_tipo_composicao_cd = item === null || item === void 0 ? void 0 : item.prb_tipo_composicao_cd;
                this.prb_descricao_gondola = item === null || item === void 0 ? void 0 : item.prb_descricao_gondola;
                this.prb_descricao_cupom = item === null || item === void 0 ? void 0 : item.prb_descricao_cupom;
                this.prb_descricao_balanca = item === null || item === void 0 ? void 0 : item.prb_descricao_balanca;
                this.prb_cdpessoabluesoft_fornecedor = item === null || item === void 0 ? void 0 : item.prb_cdpessoabluesoft_fornecedor;
                this.prb_cdpessoabluesoft_troca = item === null || item === void 0 ? void 0 : item.prb_cdpessoabluesoft_fornecedor_troca;
                this.prb_pesobruto = item === null || item === void 0 ? void 0 : item.prb_pesobruto;
                this.prb_pesoliquido = item === null || item === void 0 ? void 0 : item.prb_pesoliquido;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("M0021", "modelProdutoBluesoft.LerDadosRedShift", e);
                throw new Error(` Classe modelProdutoBluesoft ${e}`);
            }
        });
    }
    SqlDeAtualizacaoGeralProdutoBluesoftApi() {
        const _super = Object.create(null, {
            _Db_Pg_script: { get: () => super._Db_Pg_script }
        });
        return __awaiter(this, arguments, void 0, function* (_scriptSqlCommand = `DBINSERT_API`, parametro = {}) {
            let sqlScript = ``;
            let scriptRegraFiscal = ``;
            if (_scriptSqlCommand == "DBUPDATE") {
                let mfiguraFiscal = new modelfc_figura_produto_1.default();
                mfiguraFiscal.prb_cdprodutobluesoft = this.prb_cdprodutobluesoft_pk;
                scriptRegraFiscal = ``;
                scriptRegraFiscal = yield mfiguraFiscal.getInsertScriptByProdutoBluesoft(this.prb_cdprodutobluesoft_pk);
                _scriptSqlCommand = `DBINSERT_API`;
            }
            if (_scriptSqlCommand == ``)
                _scriptSqlCommand = `DBINSERT_API`;
            try {
                /*  CADASTRO BASICO DO PRODUTO BLUESOFT ----<<<<<<
                    ---------------------------------------------------------------------------
                    ---------------------------------------------------------------------------
                    ---------------------------------------------------------------------------
                */
                sqlScript = _super._Db_Pg_script.call(this, _scriptSqlCommand, parametro, 'true');
                /*  ---------------------------------------------------------------------------  */
                /*  DADOS COMPLEMENTARES
                    ---------------------------------------------------------------------------
                    ---------------------------------------------------------------------------
                    ---------------------------------------------------------------------------
                */
                if (!this.prb_status_embalagemcaixa) {
                    //Ler as tributações se não for do tipo caixa
                    sqlScript += yield this.Tributacao._Db_Pg_script(_scriptSqlCommand);
                }
                if (this.gtinsList) {
                    for (let i = 0; i <= this.gtinsList.length - 1; i++) {
                        sqlScript += yield this.gtinsList[i]._Db_Pg_script(_scriptSqlCommand);
                    }
                }
                if (this.ComposicaoList.length > 0) {
                    for (let i = 0; i <= this.ComposicaoList.length - 1; i++) {
                        sqlScript += yield this.ComposicaoList[i]._Db_Pg_script(_scriptSqlCommand);
                    }
                }
                /*  ---------------------------------------------------------------------------  */
                sqlScript += scriptRegraFiscal;
                sqlScript += model_1.default.sqlDELETE_tbfc_cbenef_produtobluesoft_PorProduto(this.prb_cdprodutobluesoft_pk);
                if (this.listCebef && this.listCebef.length > 0) {
                    sqlScript += yield model_1.default.sqlINSERT_TbFC_CBENEF_PRODUTO_FromList_PorProduto(this.listCebef, this.prb_cdprodutobluesoft_pk);
                }
                return sqlScript;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('M0021', 'modelProdutoBluesoft.getApiBluesoftSqlCRUD', e);
            }
            finally {
                return sqlScript;
            }
        });
    }
    AtualizarProdutoBluesoftComDadosDaApi(data) {
        return __awaiter(this, void 0, void 0, function* () {
            let prb_cdProdutoBluesoft = 0;
            try {
                if (data.prb_cdProdutoBluesoft && data.prb_cdProdutoBluesoft != 0) {
                    prb_cdProdutoBluesoft = parseInt(data.prb_cdProdutoBluesoft);
                }
                else {
                    throw new Error(` Classe modelProdutoBluesoft | Código do Produto Não informado `);
                }
                let url = `/comercial/produtos?produtoKey=${prb_cdProdutoBluesoft}`;
                const item = yield bluesoftApiUrl_1.default.api_get(url);
                let database = new modelbase_1.clsBase();
                this.LerOsDadosDaAPI(item.data.data[0]);
                let sqlScriptUpdate = yield this.SqlDeAtualizacaoGeralProdutoBluesoftApi(`DBUPDATE`);
                yield database.myDataBase.pag.Execute(sqlScriptUpdate);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('M0021', 'modelProdutoBluesoft.getApiBluesoft', e);
                throw new Error(` Classe modelProdutoBluesoft
                    Método: getApiBluesoft
                    -----------------------------------------------------------
                    Produto Bluesoft: ${prb_cdProdutoBluesoft}
                    -----------------------------------------------------------
                    Error ${e} \n 
                  `);
            }
        });
    }
}
exports.default = modelProdutoBluesoft;
