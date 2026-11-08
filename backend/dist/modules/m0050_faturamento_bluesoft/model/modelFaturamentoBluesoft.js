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
const tbfaturamento_bluesoft_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft"));
const report_1 = __importDefault(require("../report/report"));
const reportFaturamentoBluesoftItemList_1 = __importDefault(require("../report/reportFaturamentoBluesoftItemList"));
class modelFaturamentoBluesoft extends tbfaturamento_bluesoft_1.default {
    constructor() {
        super();
        this.itens = [];
    }
    static Consultar(filtro) {
        return __awaiter(this, void 0, void 0, function* () {
            let faturamento = {};
            try {
                if (!filtro.op_cdoperacao || filtro.op_cdoperacao == 0) {
                    throw new Error("O filtro de código de operação é obrigatório para consulta de faturamento bluesoft");
                }
                if (!filtro.numeropedido_fv || filtro.numeropedido_fv == 0) {
                    throw new Error("O filtro de número do pedido fv é obrigatório para consulta de faturamento bluesoft");
                }
                if (!filtro.numeropedido || filtro.numeropedido == 0) {
                    throw new Error("O filtro de número do pedido é obrigatório para consulta de faturamento bluesoft");
                }
                let dadosFaturamento = yield report_1.default.list.get(filtro);
                if (dadosFaturamento && Array.isArray(dadosFaturamento) && dadosFaturamento.length > 0) {
                    faturamento = dadosFaturamento[0];
                    faturamento.itens = yield reportFaturamentoBluesoftItemList_1.default.get(filtro);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelFaturamentoBluesoft.Consultar", "Error: ", e);
            }
            finally {
                return faturamento;
            }
        });
    }
    model_binding(item) {
        try {
            if (item) {
                // Mapeamento automático de propriedades com mesmo nome
                Object.assign(this, item);
            }
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException("modelFaturamentoBluesoft", "model_binding", e);
        }
    }
    bindingRedshift(item) {
        try {
            if (item) {
                // Mapeamento automático de propriedades com mesmo nome
                Object.assign(this, item);
            }
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException("modelFaturamentoBluesoft", "bindingRedshift", e);
        }
    }
    bindingApiForcaVenda(dadosPedidoCliente, dadosPedidoForca) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            var _d;
            try {
                /*
                    pedido 369045 venda 414046
                    pedido 369045 venda 414067
        "clientes": [
                    {
                        "pedidoForcaVendaClienteKey": 397078,
                        "clienteKey": 19182,
                        "numeroPedidoCliente": "",
                        "quantidadeTotal": 204,
                        "valorTotal": 2331.960000,
                        "pedidoVendaStatusKey": 18,
                        "pedidoVendaStatus": "CANCELADO",
                        "statusNfe": "Autorizada",
                        "valorNf": 2331.96,
                        "nfKey": 885868,
                        "nfNumero": 168040,
                        "nfSerie": "3",
                        "nfChave": "35260357895328000130550030001680401747530636",
                        "nfDataEmissao": "12/03/2026",
                        "nfTipo": {
                            "notaFiscalTipoKey": 104,
                            "descricao": "Nota fiscal de venda a cliente do força de venda"
                        }
                    },
                    {
                        "pedidoForcaVendaClienteKey": 397078,
                        "clienteKey": 19182,
                        "numeroPedidoCliente": "",
                        "quantidadeTotal": 204,
                        "valorTotal": 2331.960000,
                        "pedidoVendaStatusKey": 18,
                        "pedidoVendaStatus": "CANCELADO",
                        "statusNfe": "Autorizada",
                        "valorNf": 2331.96,
                        "nfKey": 886467,
                        "nfNumero": 168097,
                        "nfSerie": "3",
                        "nfChave": "35260357895328000130550030001680971305173806",
                        "nfDataEmissao": "13/03/2026",
                        "nfTipo": {
                            "notaFiscalTipoKey": 27,
                            "descricao": "Nota fiscal de Recusa de Entrada"
                        }
                    }
    
    
                    pedidoForcaVendaKey": 376376,
                "tipoFormaPagamentoKey": 3,
                "prazoPagamentoFvKey": 125,
                "filialKey": 1,
    "numeroPedidoExterno": "105883",
                "pedidoVendaStatusKey": 2,
                "pedidoVendaStatus": "FECHADO",
                "grupoEconomicoKey": 3867,
                "tabelaPrecoVersao": 653,
                "tabelaPrecoVendaKey": 841,
                "vendedorExternoKey": 22413,
                "tipoFreteKey": 3,
                "prazoPagamentoVersao": 1,
                "clientes": [
                    {
                        "pedidoForcaVendaClienteKey": 420555,
                        "clienteKey": 9270,
                        "numeroPedidoCliente": "",
                        "quantidadeTotal": 74,
                        "valorTotal": 987.940000,
                        "pedidoVendaStatusKey": 19,
                        "pedidoVendaStatus": "EM_ANALISE_DE_CREDITO"
                    }
                ],
                "origemPedidoForcaVenda": "MOBILE",
                "dataEmissao": "28/04/2026 14:54",
                "canalVendaKey": 1,
                "descontoFinanceiro": 0.00,
                "custoFinanceiro": 1.0307736925,
                "usuarioKey": 22413,
                "vigenciaInicial": "28/04/2026 00:00",
                "vigenciaFinal": "03/05/2026 00:00",
                "motivoClienteBloqueado": "",
                "tipoPedidoVenda": "Venda",
                "tipoPedidoVendaKey": 1
    
                    */
                if (dadosPedidoCliente) {
                    this.op_cdoperacao = 1;
                    let tipoVenda = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.tipoPedidoVendaKey;
                    switch (tipoVenda) {
                        case 1:
                            this.fat_blue_tipo_cd = 10;
                            break;
                        case 2:
                            this.fat_blue_tipo_cd = 20;
                            break;
                        default:
                            this.fat_blue_tipo_cd = 10;
                            break;
                    }
                    let numero_itens = 0;
                    try {
                        for (var _e = true, _f = __asyncValues(dadosPedidoForca.itens), _g; _g = yield _f.next(), _a = _g.done, !_a; _e = true) {
                            _c = _g.value;
                            _e = false;
                            const itemProduto = _c;
                            if (itemProduto.clienteKey == (dadosPedidoCliente === null || dadosPedidoCliente === void 0 ? void 0 : dadosPedidoCliente.clienteKey))
                                numero_itens++;
                        }
                    }
                    catch (e_1_1) { e_1 = { error: e_1_1 }; }
                    finally {
                        try {
                            if (!_e && !_a && (_b = _f.return)) yield _b.call(_f);
                        }
                        finally { if (e_1) throw e_1.error; }
                    }
                    this.numero_itens = numero_itens;
                    this.numeropedido_fv = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.pedidoForcaVendaKey;
                    this.numeropedido = dadosPedidoCliente === null || dadosPedidoCliente === void 0 ? void 0 : dadosPedidoCliente.pedidoForcaVendaClienteKey;
                    this.cdpessoabluesoft_cliente = dadosPedidoCliente === null || dadosPedidoCliente === void 0 ? void 0 : dadosPedidoCliente.clienteKey;
                    this.cdpessoabluesoft_vendedor = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.vendedorExternoKey;
                    this.tabelapreco_cd = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.tabelaPrecoVendaKey;
                    this.tabelapreco_versao_cd = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.tabelaPrecoVersao;
                    this.data_emissao = modelbase_1.clsTools._datemomentDatStrToDate(dadosPedidoForca.dataEmissao, "DD/MM/YYYY HH:mm");
                    this.data_solicitacao = modelbase_1.clsTools._datemomentDatStrToDate(dadosPedidoForca.dataEmissao, "DD/MM/YYYY HH:mm");
                    this.fv_prazopgto_cd = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.prazoPagamentoFvKey;
                    this.descontofinanceiro = (dadosPedidoCliente === null || dadosPedidoCliente === void 0 ? void 0 : dadosPedidoCliente.descontoFinanceiro) ? dadosPedidoCliente.descontoFinanceiro : 0;
                    this.valor_pedido = dadosPedidoCliente === null || dadosPedidoCliente === void 0 ? void 0 : dadosPedidoCliente.valorTotal;
                    this.origem_pedido = dadosPedidoForca === null || dadosPedidoForca === void 0 ? void 0 : dadosPedidoForca.origemPedidoForcaVenda;
                    if (dadosPedidoCliente === null || dadosPedidoCliente === void 0 ? void 0 : dadosPedidoCliente.nfKey) {
                        if (((_d = dadosPedidoCliente === null || dadosPedidoCliente === void 0 ? void 0 : dadosPedidoCliente.nfTipo) === null || _d === void 0 ? void 0 : _d.notaFiscalTipoKey) == 27) {
                            this.df_nf_seq_blue_dev = dadosPedidoCliente.nfKey;
                            this.valor_faturamento = 0;
                        }
                        else {
                            this.df_nf_seq_blue_dev = 0;
                            this.df_nf_seq_blue = dadosPedidoCliente.nfKey;
                            this.data_faturamento = modelbase_1.clsTools._datemomentDatStrToDate(dadosPedidoCliente.nfDataEmissao, "DD/MM/YYYY");
                            this.valor_faturamento = (dadosPedidoCliente === null || dadosPedidoCliente === void 0 ? void 0 : dadosPedidoCliente.valorNf) ? dadosPedidoCliente.valorNf : 0;
                        }
                    }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`modelfaturamentobluesoft`, `bindingapi`, e, false, ``);
            }
        });
    }
    scriptFaturamentoBlueSoft_Update() {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                sql = ` update tbfaturamento_bluesoft
                    set df_nf_seq_blue = case when ${parseInt(this.df_nf_seq_blue.toString())} = 0 then df_nf_seq_blue else ${parseInt(this.df_nf_seq_blue.toString())} end
                    ,   df_nf_seq_blue_dev = case when ${parseInt(this.df_nf_seq_blue_dev.toString())} = 0 then df_nf_seq_blue_dev else ${parseInt(this.df_nf_seq_blue_dev.toString())} end
                    ,	cdpessoabluesoft_cliente = ${this.cdpessoabluesoft_cliente}
                    ,	cdpessoabluesoft_vendedor = ${this.cdpessoabluesoft_vendedor}	
                    ,	tabelapreco_cd = ${this.tabelapreco_cd}				
                    ,	tabelapreco_versao_cd = ${this.tabelapreco_versao_cd}		
                    ,	fv_prazopgto_cd	= ${this.fv_prazopgto_cd}			
                    ,	tipo_entrega_descricao = '${this.tipo_entrega_descricao}'		
                    ,	origem_pedido = '${this.origem_pedido}'				
                    ,	data_solicitacao = '${modelbase_1.clsTools._datemomentDateToStr(this.data_solicitacao, "YYYY-MM-DD")}'			
                    ,	data_emissao = '${modelbase_1.clsTools._datemomentDateToStr(this.data_emissao, "YYYY-MM-DD")}'				
                    ,	data_faturamento = case when  ${parseInt(this.df_nf_seq_blue.toString())} > 0 then '${modelbase_1.clsTools._datemomentDateToStr(this.data_faturamento, "YYYY-MM-DD")}' else data_faturamento end
                    ,	numero_itens = ${this.numero_itens}				
                    ,	valor_pedido = ${this.valor_pedido}
                    ,	valor_faturamento = ${this.valor_faturamento}
                    ,   descontofinanceiro = ${this.descontofinanceiro}
                    ,   dtlog_update = current_timestamp 
                    where numeropedido = ${this.numeropedido} 
                      and numeropedido_fv = ${this.numeropedido_fv}
                      and op_cdoperacao = ${this.op_cdoperacao}
                      ;
                 `;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("modelFaturamentoBluesoft", "script_update", e);
            }
            finally {
                return sql;
            }
        });
    }
    ScriptFaturamentoBluesoft_RedSfhit() {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                sql = `
                        INSERT INTO tbfaturamento_bluesoft
                        (			op_cdoperacao 
                                ,	numeropedido 				
                                ,	numeropedido_fv
                                ,	df_nf_seq_blue
                                ,	df_nf_seq_blue_dev 
                                ,	fat_blue_status_cd 			
                                ,	fat_blue_tipo_cd			
                                ,	cdpessoabluesoft_cliente	
                                ,	cdpessoabluesoft_vendedor	
                                ,	tabelapreco_cd				
                                ,	tabelapreco_versao_cd		
                                ,	fv_prazopgto_cd				
                                ,	tipo_entrega_descricao 		
                                ,	origem_pedido 				
                                ,	data_solicitacao 			
                                ,	data_emissao 				
                                ,	data_faturamento			
                                ,	numero_itens				
                                ,	valor_pedido				
                                ,	valor_faturamento
                                ,   descontofinanceiro 
                        )
                        SELECT      ${this.op_cdoperacao} AS op_cdoperacao
                                ,   ${this.numeropedido} AS numeropedido
                                ,   ${this.numeropedido_fv} AS numeropedido_fv
                                ,   ${parseInt(this.df_nf_seq_blue.toString())} AS df_nf_seq_blue
                                ,   ${parseInt(this.df_nf_seq_blue_dev.toString())} AS df_nf_seq_blue_dev
                                ,   ${this.fat_blue_status_cd} AS fat_blue_status_cd
                                ,   ${this.fat_blue_tipo_cd} AS fat_blue_tipo_cd
                                ,   ${this.cdpessoabluesoft_cliente} AS cdpessoabluesoft_cliente
                                ,   ${this.cdpessoabluesoft_vendedor} AS cdpessoabluesoft_vendedor
                                ,   ${this.tabelapreco_cd} AS tabelapreco_cd
                                ,   ${this.tabelapreco_versao_cd} AS tabelapreco_versao_cd
                                ,   ${this.fv_prazopgto_cd} AS fv_prazopgto_cd
                                ,   '${this.tipo_entrega_descricao}' AS tipo_entrega_descricao
                                ,   '${this.origem_pedido}' AS origem_pedido
                                ,   '${modelbase_1.clsTools._datemomentDateToStr(this.data_solicitacao, "YYYY-MM-DD HH:mm")}' AS data_solicitacao
                                ,   '${modelbase_1.clsTools._datemomentDateToStr(this.data_emissao, "YYYY-MM-DD")}' AS data_emissao
                                ,   '${modelbase_1.clsTools._datemomentDateToStr(this.data_faturamento, "YYYY-MM-DD")}' AS data_faturamento
                                ,   ${this.numero_itens} AS numero_itens
                                ,   ${this.valor_pedido} AS valor_pedido
                                ,   ${this.valor_faturamento} AS valor_faturamento
                                ,   ${this.descontofinanceiro} as descontofinanceiro 
                        WHERE NOT EXISTS (
                            SELECT 1 FROM tbfaturamento_bluesoft 
                            WHERE numeropedido = ${this.numeropedido} 
                            AND numeropedido_fv = ${this.numeropedido_fv}
                            AND op_cdoperacao = ${this.op_cdoperacao}
                        ) ; 
                         
            `;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("modelFaturamentoBluesoft", "script_insert", e);
            }
            finally {
                return sql;
            }
        });
    }
    scriptForcaVendaPedido_insert() {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                sql = `INSERT INTO tbforca_venda_pedido
                                (
                                    numeropedido 				
                                ,	numeropedido_fv 			
                                ,	cdpessoabluesoft_cliente	
                                ,	cdpessoabluesoft_vendedor	
                                ,	data_emissao				
                                ,	data_faturamento			
                                ,	pedido_status_cd			
                                )

                        SELECT      ${this.numeropedido} AS numeropedido
                                ,   ${this.numeropedido_fv} AS numeropedido_fv
                                ,   ${this.cdpessoabluesoft_cliente} AS cdpessoabluesoft_cliente
                                ,   ${this.cdpessoabluesoft_vendedor} AS cdpessoabluesoft_vendedor
                                ,   '${modelbase_1.clsTools._datemomentDateToStr(this.data_emissao, "YYYY-MM-DD")}' AS data_emissao
                                ,   '${modelbase_1.clsTools._datemomentDateToStr(this.data_faturamento, "YYYY-MM-DD")}' AS data_faturamento
                                ,   ${this.fat_blue_status_cd} AS pedido_status_cd
                        WHERE NOT EXISTS (
                            SELECT 1 FROM tbforca_venda_pedido 
                            WHERE numeropedido = ${this.numeropedido}
                            AND numeropedido_fv = ${this.numeropedido_fv}
                        ) ; 
                 
                 `;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("modelFaturamentoBluesoft", "scriptForcaVendaPedido_insert", e);
            }
            finally {
                return sql;
            }
        });
    }
}
exports.default = modelFaturamentoBluesoft;
