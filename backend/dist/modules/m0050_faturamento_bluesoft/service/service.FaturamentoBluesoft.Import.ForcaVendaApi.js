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
const service_SistemaLog_1 = __importDefault(require("../../m9020_sistema_log/service/service.SistemaLog"));
const tbfaturamento_bluesoft_fv_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv"));
const tbfaturamento_bluesoft_fv_cliente_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv_cliente"));
const tbfaturamento_bluesoft_fv_nf_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv_nf"));
const tbfaturamento_bluesoft_fv_item_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv_item"));
const myBase = new modelbase_1.clsBase();
const SIS_NUCLEO_PRC_CD = 10050011;
class serviceFaturamentoBluesoftImportForcaVendaApi {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametro = {}) {
            let messageLogNucleoProcedimento = `FaturamentoBluesoft - Importação API FV ${modelbase_1.clsTools._datemomentDateToStr(new Date(), "YYYY-MM-DD HH:mm:ss")}`;
            try {
                let ListPedidos = [];
                /*Obtendo os dados da API conforme o tipo de processamento*/
                switch (parametro.tipo_periodo) {
                    case "EMISSAO":
                        ListPedidos = yield this.faturamentoBlueSoft_Fv_GetApi(parametro);
                        break;
                    case "ALTERACAO":
                        ListPedidos = yield this.faturamentoBlueSoft_Fv_GetApi(parametro);
                        break;
                    case "REPROCESSAR_PENDENTE":
                        ListPedidos = yield this.faturamentoBlueSoft_Fv_ReprocessamentoPendentes(parametro);
                        break;
                }
                if (ListPedidos.length == 0) {
                    yield modelbase_1.clsTools.pagConsole(`Nenhum pedido encontrado para o período informado. Finalizando importação.`, false, false);
                }
                /*  Processamento dos pedidos
                    Binding dos dados da api
                    Atualizando as tabelas tbfaturamento_bluesoft_fv_cliente, tbfaturamento_bluesoft_fv_item, tbfaturamento_bluesoft_fv*
                */
                if (ListPedidos.length > 0)
                    yield this.faturamentoBlueSoft_Fv_ProcessarListFromApi(ListPedidos);
                /*  Inserindo e atualizando a tabela oficial de faturamento bluesoft
                    Binding dos dados da api
                    Atualizando as tabelas tbfaturamento_bluesoft_fv_cliente, tbfaturamento_bluesoft_fv_item, tbfaturamento_bluesoft_fv*
                */
                if (ListPedidos.length > 0)
                    yield this.FaturamentoBlueSosft_Fv_AtualizarBaseDados();
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImportForcaVendaApi", "start", e);
                messageLogNucleoProcedimento += " - Erro durante o processamento. Verificar logs para mais detalhes.";
            }
            finally {
                yield service_SistemaLog_1.default.Registrar.submit({
                    sis_nucleo_prc_cd: SIS_NUCLEO_PRC_CD,
                    sis_log_tag: "FAT_BLUE_IMP_API",
                    sis_log_info: messageLogNucleoProcedimento,
                    sis_batch_run_seq: 0,
                    proc_log_seq: 0,
                    sis_log_seq: 0,
                    uuid_start: "",
                    uuid: ""
                });
            }
        });
    }
    static faturamentoBlueSoft_Fv_GetApi() {
        return __awaiter(this, arguments, void 0, function* (parametro = {}) {
            var _a;
            let ListPedidos = [];
            try {
                let pagei = 0;
                let pageMax = 9999;
                let url = ``;
                let dataInicial = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataInicial}`, `YYYY-MM-DD`);
                let dataFinal = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataFinal}`, `YYYY-MM-DD`);
                for (; pagei <= pageMax; pagei++) {
                    if (parametro.tipo_periodo == "EMISSAO") {
                        url = `forca-de-vendas/pedidos?dataEmissaoInicial=${modelbase_1.clsTools._datemomentDateToStr(dataInicial, "DD/MM/YYYY")} 00:01`;
                        url += `&dataEmissaoFinal=${modelbase_1.clsTools._datemomentDateToStr(dataFinal, "DD/MM/YYYY")} 23:59`;
                        url += `&currentPage=${pagei}`;
                    }
                    if (parametro.tipo_periodo == "ALTERACAO") {
                        url = `forca-de-vendas/pedidos?dataUltimaAlteracao=${modelbase_1.clsTools._datemomentDateToStr(dataInicial, "DD/MM/YYYY")} 00:01`;
                        url += `&currentPage=${pagei}`;
                    }
                    console.log(`Importação API FV - Lendo página ${pagei} - url: ${url}`);
                    let result = yield myBase.blueSoftApi.api_get(url);
                    ListPedidos = (_a = result === null || result === void 0 ? void 0 : result.data) === null || _a === void 0 ? void 0 : _a.data;
                    if (ListPedidos.length == 0) {
                        modelbase_1.clsTools.pagConsole(`Nenhum pedido encontrado na página ${pagei}. Finalizando importação.`, false, false);
                        break;
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("faturamentoBlueSoft_Fv_GetApi", "fromApi", e);
            }
            finally {
                return ListPedidos;
            }
        });
    }
    static faturamentoBlueSoft_Fv_ReprocessamentoPendentes() {
        return __awaiter(this, arguments, void 0, function* (parametro = {}) {
            var _a, e_1, _b, _c, _d, e_2, _e, _f;
            let ListPedidos = [];
            try {
                let sqlSelectPendentes = `   
                                                                  SELECT    a.op_cdoperacao 
                                         , a.numeropedido
                                         , a.numeropedido_fv
                                         , a.fat_blue_status_cd
                                         , st.fat_blue_status_descricao
                                         , a.data_emissao
                                         , a.df_nf_seq_blue
                                    FROM   tbfaturamento_bluesoft A
                                    left join tbfaturamento_bluesoft_status st on st.fat_blue_status_cd = a.fat_blue_status_cd
                                    WHERE  1 = 1 
                                      AND  NOT EXISTS (SELECT 1
                                    FROM   tbfaturamento_bluesoft_item B
                                    WHERE  A.numeropedido = B.numeropedido
                                      AND A.numeropedido_fv = B.numeropedido_fv
                                      AND B.op_cdoperacao = 1)
                                      AND   a.op_cdoperacao = 1
                                      AND   a.data_emissao >= '2020-01-01'
                                      AND   a.df_nf_seq_blue = 0 
                                      and a.numeropedido_fv = 424287

                                    union 

                                    select 	op_cdoperacao 
                                        ,	numeropedido
                                        ,	numeropedido_fv
                                        ,	x.fat_blue_status_cd
                                        ,	s.fat_blue_status_descricao 
                                        ,   x.data_emissao
                                        ,   x.df_nf_seq_blue
                                    from tbfaturamento_bluesoft  x
                                    left join tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = x.fat_blue_status_cd 
                                    where not exists ( 
                                                select 1
                                                from tbfaturamento_bluesoft_item a
                                                where 1 = 1
                                                and a.op_cdoperacao = x.op_cdoperacao 
                                                and a.numeropedido = x.numeropedido 
                                                and a.numeropedido_fv = x.numeropedido_fv

                                            )
                                    and x.op_cdoperacao = 1
                                    and x.numeropedido_fv = 424287

                                    

                                `;
                let ListPedidos = yield myBase.myDataBase.pag.DataGet(sqlSelectPendentes);
                let sql = ``;
                let icount = ListPedidos.length;
                let icountMax = 100;
                let i = 0;
                try {
                    for (var _g = true, _h = __asyncValues(ListPedidos), _j; _j = yield _h.next(), _a = _j.done, !_a; _g = true) {
                        _c = _j.value;
                        _g = false;
                        const itemReprocessar = _c;
                        sql += `
                    delete from tbfaturamento_bluesoft_fv_cliente where numeropedido_fv = ${itemReprocessar.numeropedido_fv};
                    delete from tbfaturamento_bluesoft_fv_item where numeropedido_fv = ${itemReprocessar.numeropedido_fv};
                    delete from tbfaturamento_bluesoft_fv_nf where numeropedido_fv = ${itemReprocessar.numeropedido_fv};
                `;
                        if (i >= icountMax) {
                            yield myBase.myDataBase.pag.Execute(sql);
                            i = 0;
                            sql = ``;
                        }
                        i++;
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_g && !_a && (_b = _h.return)) yield _b.call(_h);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql) {
                    console.log(`Executando SQL de limpeza dos pedidos pendentes na tabela de integração com a API FV`);
                    yield myBase.myDataBase.pag.Execute(sql);
                }
                try {
                    for (var _k = true, _l = __asyncValues(ListPedidos), _m; _m = yield _l.next(), _d = _m.done, !_d; _k = true) {
                        _f = _m.value;
                        _k = false;
                        const itemReprocessar = _f;
                        let url = `forca-de-vendas/pedidos/${itemReprocessar.numeropedido_fv}`;
                        console.log(`Processando ${i}/${icount} - Numero do pedido a processar ${itemReprocessar.numeropedido_fv} | url ${url}`);
                        let pedidoForcaVenda = yield myBase.blueSoftApi.api_get(url);
                        console.log(pedidoForcaVenda.data);
                        console.log(`Processando o pedido ${itemReprocessar.numeropedido_fv}`);
                        sql += yield this.faturamentoBlueSoft_Fv_ProcessarPedido(pedidoForcaVenda.data);
                        i++;
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_k && !_d && (_e = _l.return)) yield _e.call(_l);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                yield modelbase_1.clsTools.pagConsole(sql, false, true, "TESTE_SQL");
                yield myBase.myDataBase.pag.Execute(sql);
                console.log(`Processamento dos pedidos da API FV - FINALIZADO`);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("faturamentoBlueSoft_Fv_ReprocessarPedidos", "fromApi", e);
            }
            finally {
                return [];
            }
        });
    }
    static faturamentoBlueSoft_Fv_ProcessarListFromApi(ListPedidos) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, ListPedidos_1, ListPedidos_1_1;
            var _b, e_3, _c, _d;
            try {
                let i = 0;
                let imax = 100;
                let sql = ``;
                try {
                    /* LENDO OS PEDIDOS DA PAGE ----------------------------------------------------------------------------------------- */
                    /* ------------------------------------------------------------------------------------------------------------------ */
                    /* ------------------------------------------------------------------------------------------------------------------ */
                    for (_a = true, ListPedidos_1 = __asyncValues(ListPedidos); ListPedidos_1_1 = yield ListPedidos_1.next(), _b = ListPedidos_1_1.done, !_b; _a = true) {
                        _d = ListPedidos_1_1.value;
                        _a = false;
                        const pedidoForcaVenda = _d;
                        sql += yield this.faturamentoBlueSoft_Fv_ProcessarPedido(pedidoForcaVenda);
                        i++;
                        if (i >= imax) {
                            yield myBase.myDataBase.pag.Execute(sql);
                            i = 0;
                            sql = ``;
                        }
                    }
                }
                catch (e_3_1) { e_3 = { error: e_3_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = ListPedidos_1.return)) yield _c.call(ListPedidos_1);
                    }
                    finally { if (e_3) throw e_3.error; }
                }
                if (sql) {
                    yield myBase.myDataBase.pag.Execute(sql);
                }
                /* ------------------------------------------------------------------------------------------------------------------ */
                /* ------------------------------------------------------------------------------------------------------------------ */
                console.log(`Processamento dos pedidos da API FV - FINALIZADO`);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "fromApi", e);
            }
        });
    }
    static faturamentoBlueSoft_Fv_ProcessarPedido(pedidoForcaVenda) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_4, _b, _c, _d, e_5, _e, _f;
            let sql = ``;
            try {
                /* Le o cabeçalho dos itens PEDIDO FORÇA DE VENDA */
                let itemTbFaturamentoBluesoftFv = new tbfaturamento_bluesoft_fv_1.default();
                yield itemTbFaturamentoBluesoftFv.bindingFromApiForcaVenda(pedidoForcaVenda);
                sql += yield itemTbFaturamentoBluesoftFv.scriptSqlInsert();
                try {
                    /* Le os Pedidos dos clientes filhos do GRUPO ECONOMICO */
                    for (var _g = true, _h = __asyncValues(pedidoForcaVenda.clientes), _j; _j = yield _h.next(), _a = _j.done, !_a; _g = true) {
                        _c = _j.value;
                        _g = false;
                        const pedidoCliente = _c;
                        /*Tabela tbforca_venda_pedido_cliente - para controle de pedidos x clientes */
                        let itemTbFaturamentoBluesoftFvCliente = new tbfaturamento_bluesoft_fv_cliente_1.default();
                        yield itemTbFaturamentoBluesoftFvCliente.bindingFromApiForcaVenda(pedidoCliente, itemTbFaturamentoBluesoftFv.numeropedido_fv);
                        sql += yield itemTbFaturamentoBluesoftFvCliente.scriptSqlInsert();
                        /*Tabela de Faturamento FV - Nota Fiscal */
                        let itemTbFaturamentoBluesoftFvNf = new tbfaturamento_bluesoft_fv_nf_1.default();
                        if (pedidoCliente === null || pedidoCliente === void 0 ? void 0 : pedidoCliente.nfKey) { //se existir nf
                            if ((pedidoCliente === null || pedidoCliente === void 0 ? void 0 : pedidoCliente.nfKey) > 0) {
                                yield itemTbFaturamentoBluesoftFvNf.bindingFromApiForcaVenda(pedidoCliente, itemTbFaturamentoBluesoftFv.numeropedido_fv);
                                sql += yield itemTbFaturamentoBluesoftFvNf.scriptSqlInsert();
                            }
                        }
                        /*Tabela unica de Processamento de Venda Bluesoft tbfaturamento_bluesoft */
                        //let FaturamentoBlueSoft : tbfaturamento_bluesoft = new tbfaturamento_bluesoft()
                        //await FaturamentoBlueSoft.bindingApiForcaVenda(pedidoCliente, pedidoForcaVenda)
                        //sql += await FaturamentoBlueSoft.ScriptFaturamentoBluesoft_RedSfhit()
                        if (pedidoForcaVenda.itens) {
                            try {
                                for (var _k = true, _l = (e_5 = void 0, __asyncValues(pedidoForcaVenda.itens)), _m; _m = yield _l.next(), _d = _m.done, !_d; _k = true) {
                                    _f = _m.value;
                                    _k = false;
                                    const itemPedido = _f;
                                    itemPedido.pedidoForcaVendaClienteKey = pedidoCliente === null || pedidoCliente === void 0 ? void 0 : pedidoCliente.pedidoForcaVendaClienteKey;
                                    itemPedido.clienteKey = pedidoCliente === null || pedidoCliente === void 0 ? void 0 : pedidoCliente.clienteKey;
                                    let itemTbFaturamentoBluesoftFvItem = new tbfaturamento_bluesoft_fv_item_1.default();
                                    yield itemTbFaturamentoBluesoftFvItem.bindingFromApiForcaVenda(itemPedido, itemTbFaturamentoBluesoftFv.numeropedido_fv);
                                    if (itemPedido.pedidoForcaVendaClienteKey === 484266) {
                                        console.log("processando item de pedido");
                                        //console.log(itemPedido)
                                        //console.log(itemTbFaturamentoBluesoftFvItem)
                                    }
                                    sql += yield itemTbFaturamentoBluesoftFvItem.scriptSqlInsert();
                                }
                            }
                            catch (e_5_1) { e_5 = { error: e_5_1 }; }
                            finally {
                                try {
                                    if (!_k && !_d && (_e = _l.return)) yield _e.call(_l);
                                }
                                finally { if (e_5) throw e_5.error; }
                            }
                        }
                    }
                }
                catch (e_4_1) { e_4 = { error: e_4_1 }; }
                finally {
                    try {
                        if (!_g && !_a && (_b = _h.return)) yield _b.call(_h);
                    }
                    finally { if (e_4) throw e_4.error; }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "faturamentoBlueSoft_Fv_ProcessarPedido", e);
            }
            finally {
                return sql;
            }
        });
    }
    static FaturamentoBlueSosft_Fv_AtualizarBaseDados() {
        return __awaiter(this, arguments, void 0, function* (parametro = {}) {
            try {
                modelbase_1.clsTools.pagConsole("Processamento do faturamento bluesoft dos dados IMPORTADOS DA API FORÇA DE VENDA - INSERINDO NOVOS REGISTROS", false, false);
                yield myBase.myDataBase.pag.Execute(this.script_processar_faturamento_bluesoft_insert(parametro));
                modelbase_1.clsTools.pagConsole("Processamento do faturamento bluesoft dos dados IMPORTADOS DA API FORÇA DE VENDA - ATUALIZANDO REGISTROS EXISTENTES", false, false);
                yield myBase.myDataBase.pag.Execute(this.script_processar_faturamento_bluesoft_update(parametro));
                modelbase_1.clsTools.pagConsole("Processamento do faturamento bluesoft dos dados IMPORTADOS DA API FORÇA DE VENDA - INSERINDO ITENS", false, false);
                yield myBase.myDataBase.pag.Execute(this.script_processar_faturamento_bluesoft_item_insert(parametro));
                modelbase_1.clsTools.pagConsole("Processamento do faturamento bluesoft dos dados IMPORTADOS DA API FORÇA DE VENDA - ATUALIZANDO ITENS", false, false);
                yield myBase.myDataBase.pag.Execute(this.script_processar_faturamento_bluesoft_item_update(parametro));
                modelbase_1.clsTools.pagConsole("Processamento do faturamento bluesoft dados PROCESSADOS COM SUCESSO", false, false);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "FaturamentoBlueSosft_Processar", e);
            }
        });
    }
    static script_processar_faturamento_bluesoft_insert(parametro) {
        let sql = `
        
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
		SELECT  1 
			,	pc.numeropedido
			,	p.numeropedido_fv
			,	coalesce(nf.df_nf_seq_blue,0) as df_nf_seq_blue
			,	0 as df_nf_seq_blue_dev 
			,	st.fat_blue_status_cd 
			,	t.fat_blue_tipo_cd 
			,	pc.cdpessoabluesoft_cliente 
			,	p.cdpessoabluesoft_vendedor
			,	p.tabelapreco_cd
			,	p.tabelapreco_versao_cd 
			,	p.fv_prazopgto_cd 
			,	''
			,	p.origem_pedido 
			,	p.data_emissao 				as data_solicitacao 
			,	p.data_emissao				as data_emissao 
			,	coalesce(nf.df_data_emissao, '1900-01-01')  as data_faturamento 
			,	xc.numero_itens
			,	xc.valor_pedido 
			,	coalesce(nf.df_valor,0) as valor_faturamento 
			,	p.descontofinanceiro 
		FROM 		tbfaturamento_bluesoft_fv_cliente 	pc
		inner join 	tbfaturamento_bluesoft_fv 			p  on p.numeropedido_fv = pc.numeropedido_fv
		inner join  tbfaturamento_bluesoft_status 		st on st.pedido_status_cd = pc.pedido_status_cd
		inner join  tbfaturamento_bluesoft_tipo         t  on t.pedido_tipo_cd = p.pedido_tipo_cd 
		left join   tbfaturamento_bluesoft_fv_nf		nf on nf.numeropedido = pc.numeropedido 
				and nf.numeropedido_fv = p.numeropedido_fv and nf.df_nf_tipo in( 104, 34)
		left join   (select xx.numeropedido 
						,	xx.numeropedido_fv 
						,	count(distinct(xx.prb_cdprodutobluesoft)) as numero_itens 
						,	sum(xx.valor_total) as valor_pedido 
					from 	tbfaturamento_bluesoft_fv_item xx
                    where   1 = 1
                    ${(parametro === null || parametro === void 0 ? void 0 : parametro.numeropedido_fv) && parseInt(parametro.numeropedido_fv) > 0 ? ` and xx.numeropedido_fv = ${parametro.numeropedido_fv} ` : ``}
					group by xx.numeropedido 
						,	xx.numeropedido_fv 
		
					) xc on xc.numeropedido = pc.numeropedido and xc.numeropedido_fv = pc.numeropedido_fv
		where not exists (select 1 
							from tbfaturamento_bluesoft aaa
							where 1 = 1
							  and aaa.numeropedido = pc.numeropedido 
							  and aaa.numeropedido_fv = p.numeropedido_fv 
						) 
          and st.statusfaturamento in (0,1) 
        
        `;
        if (parametro === null || parametro === void 0 ? void 0 : parametro.numeropedido_fv) {
            sql += ` and p.numeropedido_fv = ${parametro.numeropedido_fv} `;
        }
        return sql;
    }
    static script_processar_faturamento_bluesoft_update(parametro) {
        let sql = `
                    UPDATE tbfaturamento_bluesoft A
                    SET  	df_nf_seq_blue 		= B.df_nf_seq_blue
                    ,	   	df_nf_seq_blue_dev 	= B.df_nf_seq_blue_dev 
                    ,    	fat_blue_status_cd	= B.fat_blue_status_cd
                    ,		fat_blue_tipo_cd	= B.fat_blue_tipo_cd
                    ,		data_faturamento	= B.data_faturamento
                    , 	valor_faturamento 	= B.valor_faturamento
                    FROM (	SELECT  1 
                                ,	pc.numeropedido
                                ,	p.numeropedido_fv
                                ,	coalesce(nf.df_nf_seq_blue,0) as df_nf_seq_blue
                                ,	0 as df_nf_seq_blue_dev 
                                ,	st.fat_blue_status_cd 
                                ,	t.fat_blue_tipo_cd 
                                ,	pc.cdpessoabluesoft_cliente 
                                ,	p.cdpessoabluesoft_vendedor
                                ,	p.tabelapreco_cd
                                ,	p.tabelapreco_versao_cd 
                                ,	p.fv_prazopgto_cd 
                                ,	''
                                ,	p.origem_pedido 
                                ,	p.data_emissao 				as data_solicitacao 
                                ,	p.data_emissao				as data_emissao 
                                ,	coalesce(nf.df_data_emissao, '1900-01-01')  as data_faturamento 
                                ,	xc.numero_itens
                                ,	xc.valor_pedido 
                                ,	coalesce(nf.df_valor,0) as valor_faturamento 
                                ,	p.descontofinanceiro 
                            FROM 		tbfaturamento_bluesoft_fv_cliente 	pc
                            inner join 	tbfaturamento_bluesoft_fv 			p  on p.numeropedido_fv = pc.numeropedido_fv
                            inner join  tbfaturamento_bluesoft_status 		st on st.pedido_status_cd = pc.pedido_status_cd
                            inner join  tbfaturamento_bluesoft_tipo         t  on t.pedido_tipo_cd = p.pedido_tipo_cd 
                            left join   tbfaturamento_bluesoft_fv_nf		nf on nf.numeropedido = pc.numeropedido 
                                    and nf.numeropedido_fv = p.numeropedido_fv and nf.df_nf_tipo in( 104, 34)
                            left join   (select xx.numeropedido 
                                            ,	xx.numeropedido_fv 
                                            ,	count(distinct(xx.prb_cdprodutobluesoft)) as numero_itens 
                                            ,	sum(xx.valor_total) as valor_pedido 
                                        from 	tbfaturamento_bluesoft_fv_item xx
                                        group by xx.numeropedido 
                                            ,	xx.numeropedido_fv 
                            
                                        ) xc on xc.numeropedido = pc.numeropedido and xc.numeropedido_fv = pc.numeropedido_fv
                        ) B 
                    WHERE	1= 1
                    AND   B.numeropedido = A.numeropedido 
                    AND	  B.numeropedido_fv = a.numeropedido_fv 
                    AND   B.cdpessoabluesoft_cliente = A.cdpessoabluesoft_cliente
                `;
        if (parametro === null || parametro === void 0 ? void 0 : parametro.numeropedido_fv) {
            sql += ` and B.numeropedido_fv = ${parametro.numeropedido_fv} `;
        }
        return sql;
    }
    static script_processar_faturamento_bluesoft_item_insert(parametro) {
        let sql = `
        
        
                     insert into tbfaturamento_bluesoft_item (
                                 fat_blue_seq
                            ,    op_cdoperacao 
                            ,    numeropedido 
                            ,    numeropedido_fv
                            ,    df_nf_seq_blue
                            ,    cdpessoabluesoft_cliente
                            ,    prb_cdprodutobluesoft
                            ,    prb_cdprodutobluesoft_unitario
                            ,    prb_embalagem
                            ,    prb_fatorestoque
                            ,    embalagem_descricao
                            ,    qtde_unitaria_solicitada
                            ,    qtde_unitaria_faturada
                            ,    qtde_solicitada
                            ,    qtde_faturada
                            ,    valor_custo_com_icm_unit
                            ,    valor_custo_com_icm
                            ,    valor_custo
                            ,    valor_preco_tabela
                            ,    valor_preco 
                            ,    valor_preco_aplicado 
                            ,    valor_verba 
                            ,    valor_verba_gerencia 
                            ,    valor_verba_calculada 
                            ,    valor_desconto_financeiro 
                            ,    valor_nf_item_bruto 
                            ,    valor_nf_item 
                            ,    item_nf_bonificado 
                            ,    percentual_desconto_financeiro 
                )
                       select 		f.fat_blue_seq 
                            ,		1 											as op_cdoperacao 
                            ,		i.numeropedido 
                            ,		i.numeropedido_fv
                            ,		coalesce(nf.df_nf_seq_blue,0) 				as df_nf_seq_blue
                            ,		pc.cdpessoabluesoft_cliente					as cdpessoabluesoft_cliente
                            ,		i.prb_cdprodutobluesoft
                            ,		pb.prb_cdprodutobluesoftunitario 
                            ,		cast(left(pb.prb_embalagemestoque,2) as varchar(2)) as prb_embalagem
                            ,		pb.prb_fatorestoque 
                            ,		'' 											as embalagem_descricao
                            ,		pb.prb_fatorestoque * i.qtde_pedida 		as qtde_unitaria_solicitada
                            ,		pb.prb_fatorestoque * i.qtde_separada 		as qtde_unitaria_faturada
                            ,		i.qtde_pedida 								as qtde_solicitada
                            ,		i.qtde_separada 							as qtde_faturada
                            ,		0											as valor_custo_com_icm_unit
                            ,		0											as valor_custo_com_icm
                            ,		0											as valor_custo
                            ,		i.valor_preco								as valor_preco_tabela
                            ,		0           								as valor_preco 
                            ,		i.valor_preco_final 						as valor_preco_aplicado 
                            ,		0                                    		as valor_verba 
                            ,		0											as valor_verba_gerencia 
                            ,		0                                           as valor_verba_calculada 
                            ,		0 											as valor_desconto_financeiro 
                            ,		0											as valor_nf_item_bruto 
                            ,		0											as valor_nf_item 
                            ,		case when nf.df_nf_tipo = 34 
                                                then 1 
                                                else 0 end 						as item_nf_bonificado 
                            ,		p.descontofinanceiro 						as percentual_desconto_financeiro 
	
                    from 		tbfaturamento_bluesoft_fv_item 		i
                    inner join 	tbfaturamento_bluesoft_fv_cliente 	pc on pc.numeropedido = i.numeropedido and pc.numeropedido_fv = i.numeropedido_fv
                    inner join  tbfaturamento_bluesoft				f  on f.numeropedido = pc.numeropedido and f.numeropedido_fv = pc.numeropedido_fv
                    inner join 	tbfaturamento_bluesoft_fv 			p  on p.numeropedido_fv = pc.numeropedido_fv
                    inner join  tbfaturamento_bluesoft_status 		st on st.pedido_status_cd = pc.pedido_status_cd
                    inner join  tbfaturamento_bluesoft_tipo         t  on t.pedido_tipo_cd = p.pedido_tipo_cd 
                    left join   tbfaturamento_bluesoft_fv_nf		nf on nf.numeropedido = pc.numeropedido 
                                    and nf.numeropedido_fv = p.numeropedido_fv and nf.df_nf_tipo in( 104, 34)

                    inner join  tbprodutobluesoft 							pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft 
                    WHERE		1 = 1
                    AND			NOT EXISTS (	Select 1
                                                FROM 	tbfaturamento_bluesoft_item XX
                                                WHERE	XX.prb_cdprodutobluesoft = i.prb_cdprodutobluesoft 
                                                and   XX.numeropedido = i.numeropedido 
                                                and   xx.numeropedido_fv = i.numeropedido_fv 
                                    

                                            )
                    AND         st.statusfaturamento in (0,1)
                `;
        if (parametro === null || parametro === void 0 ? void 0 : parametro.numeropedido_fv) {
            sql += ` and p.numeropedido_fv = ${parametro.numeropedido_fv} `;
        }
        return sql;
    }
    static script_processar_faturamento_bluesoft_item_update(parametro) {
        let sql = ` 
        
        
        
            UPDATE tbfaturamento_bluesoft_item A
            set      	df_nf_seq_blue					= B.df_nf_seq_blue    
                    ,	qtde_unitaria_solicitada		= B.qtde_unitaria_solicitada
                    ,	qtde_unitaria_faturada			= B.qtde_unitaria_faturada
                    ,	qtde_solicitada					= B.qtde_solicitada
                    ,	qtde_faturada					= B.qtde_faturada
                    ,	valor_preco_tabela				= B.valor_preco_tabela
                    ,	valor_preco 					= case when B.valor_preco = 0 then A.valor_preco else B.valor_preco end
                    ,	valor_preco_aplicado 			= B.valor_preco_aplicado

                    ,	item_nf_bonificado 				= B.item_nf_bonificado
                    ,	percentual_desconto_financeiro  = B.percentual_desconto_financeiro
            FROM 	 (


				select 		f.fat_blue_seq 
					,		1 											as op_cdoperacao 
					,		i.numeropedido 
					,		i.numeropedido_fv
					,		coalesce(nf.df_nf_seq_blue,0) 				as df_nf_seq_blue
					,		pc.cdpessoabluesoft_cliente					as cdpessoabluesoft_cliente
					,		i.prb_cdprodutobluesoft
					,		pb.prb_cdprodutobluesoftunitario 
					,		pb.prb_embalagemestoque 					as prb_embalagem
					,		pb.prb_fatorestoque 
					,		'' 											as embalagem_descricao
					,		pb.prb_fatorestoque * i.qtde_pedida 		as qtde_unitaria_solicitada
					,		pb.prb_fatorestoque * i.qtde_separada 		as qtde_unitaria_faturada
					,		i.qtde_pedida 								as qtde_solicitada
					,		i.qtde_separada 							as qtde_faturada
					,		0											as valor_custo_com_icm_unit
					,		0											as valor_custo_com_icm
					,		0											as valor_custo
					,		i.valor_preco								as valor_preco_tabela
					,		cast(i.valor_preco * coalesce(pz.coefcustofinanceiro,0) as numeric(13,2)) as valor_preco 
					,		i.valor_preco_final 						as valor_preco_aplicado 
					,		0                                    		as valor_verba 
					,		0											as valor_verba_gerencia 
					,		0                                           as valor_verba_calculada 
					,		0 											as valor_desconto_financeiro 
					,		0											as valor_nf_item_bruto 
					,		0											as valor_nf_item 
					,		case when nf.df_nf_tipo = 34 
										then 1 
										else 0 end 						as item_nf_bonificado 
					,		p.descontofinanceiro 						as percentual_desconto_financeiro 
					
				from 		tbfaturamento_bluesoft_fv_item 				i
				inner join 	tbfaturamento_bluesoft_fv_cliente 			pc on pc.numeropedido = i.numeropedido and pc.numeropedido_fv = i.numeropedido_fv
				inner join  tbfaturamento_bluesoft						f  on f.numeropedido = pc.numeropedido and f.numeropedido_fv = pc.numeropedido_fv
						inner join 	tbfaturamento_bluesoft_fv 			p  on p.numeropedido_fv = pc.numeropedido_fv
						inner join  tbfaturamento_bluesoft_status 		st on st.pedido_status_cd = pc.pedido_status_cd
						inner join  tbfaturamento_bluesoft_tipo         t  on t.pedido_tipo_cd = p.pedido_tipo_cd 
						left join   tbfaturamento_bluesoft_fv_nf		nf on nf.numeropedido = pc.numeropedido 
								and nf.numeropedido_fv = p.numeropedido_fv and nf.df_nf_tipo in( 104, 34)
				
				inner join  tbprodutobluesoft 							pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft 
                left join   tbforca_venda_prazopgto                     pz on pz.fv_prazopgto_cd = p.fv_prazopgto_cd
				WHERE		1 = 1

		) B 
	WHERE 1 = 1 
	  and B.numeropedido = A.numeropedido
	  and B.numeropedido_fv = A.numeropedido_fv
	  and B.prb_cdprodutobluesoft = A.prb_cdprodutobluesoft	  
        
        ;       
        
        
        `;
        if (parametro === null || parametro === void 0 ? void 0 : parametro.numeropedido_fv) {
            sql += ` and B.numeropedido_fv = ${parametro.numeropedido_fv} `;
        }
        return sql;
    }
}
exports.default = serviceFaturamentoBluesoftImportForcaVendaApi;
