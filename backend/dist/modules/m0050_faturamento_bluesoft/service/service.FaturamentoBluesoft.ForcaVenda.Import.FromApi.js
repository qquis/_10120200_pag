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
const tbfaturamento_bluesoft_fv_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv"));
const tbfaturamento_bluesoft_fv_cliente_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv_cliente"));
const tbfaturamento_bluesoft_fv_nf_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv_nf"));
const tbfaturamento_bluesoft_fv_item_1 = __importDefault(require("../tbs/tbfaturamento_bluesoft_fv_item"));
const modelFaturamentoBluesoft_processo_1 = __importDefault(require("../model/modelFaturamentoBluesoft_processo"));
const reportFaturamentoBluesoftProcesso_1 = __importDefault(require("../report/reportFaturamentoBluesoftProcesso"));
const myBase = new modelbase_1.clsBase();
class serviceFaturamentoBluesoftForcaVendaImportFromApi {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametro = {}) {
            yield this.faturamentoBlueSoft_Fv_GetApi(parametro);
            yield this.FaturamentoBlueSosft_Processar();
            yield this.FaturamentoBluesoft_gerarProcessos(parametro);
            yield this.FaturamentoBluesoft_ProcessarNotificacoes(parametro);
        });
    }
    static faturamentoBlueSoft_Fv_GetApi() {
        return __awaiter(this, arguments, void 0, function* (parametro = {}) {
            var _a;
            try {
                console.log("teste");
                let pagei = 1;
                let pageMax = 9999;
                let url = ``;
                let dataInicial = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataInicial}`, `YYYY-MM-DD`);
                let dataFinal = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataFinal}`, `YYYY-MM-DD`);
                for (; pagei <= pageMax; pagei++) {
                    console.log(`Número da Pagina Procesada ${pagei}`);
                    if (parametro.tipo_periodo == "EMISSAO") {
                        url = `forca-de-vendas/pedidos?dataEmissaoInicial=${modelbase_1.clsTools._datemomentDateToStr(dataInicial, "DD/MM/YYYY")} 00:01&dataEmissaoFinal=${modelbase_1.clsTools._datemomentDateToStr(dataFinal, "DD/MM/YYYY")} 23:59&currentPage=${pagei}`;
                    }
                    if (parametro.tipo_periodo == "ALTERACAO") {
                        url = `forca-de-vendas/pedidos?dataUltimaAlteracao=${modelbase_1.clsTools._datemomentDateToStr(dataInicial, "DD/MM/YYYY")} 00:01&currentPage=${pagei}`;
                    }
                    let result = yield myBase.blueSoftApi.api_get(url);
                    let ListPedidos = (_a = result === null || result === void 0 ? void 0 : result.data) === null || _a === void 0 ? void 0 : _a.data;
                    if (ListPedidos.length == 0) {
                        modelbase_1.clsTools.pagConsole(`Nenhum pedido encontrado na página ${pagei}. Finalizando importação.`, false, false);
                        break;
                    }
                    yield this.faturamentoBlueSoft_Fv_ProcessarPedidos(ListPedidos);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("faturamentoBlueSoft_Fv_GetApi", "fromApi", e);
            }
        });
    }
    static faturamentoBlueSoft_Fv_ProcessarPedidos(ListPedidos) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, ListPedidos_1, ListPedidos_1_1;
            var _b, e_1, _c, _d, _e, e_2, _f, _g, _h, e_3, _j, _k;
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
                        /* Le o cabeçalho dos itens PEDIDO FORÇA DE VENDA */
                        let itemTbFaturamentoBluesoftFv = new tbfaturamento_bluesoft_fv_1.default();
                        yield itemTbFaturamentoBluesoftFv.bindingFromApiForcaVenda(pedidoForcaVenda);
                        sql += yield itemTbFaturamentoBluesoftFv.scriptSqlInsert();
                        try {
                            /* Le os Pedidos dos clientes filhos do GRUPO ECONOMICO */
                            for (var _l = true, _m = (e_2 = void 0, __asyncValues(pedidoForcaVenda.clientes)), _o; _o = yield _m.next(), _e = _o.done, !_e; _l = true) {
                                _g = _o.value;
                                _l = false;
                                const pedidoCliente = _g;
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
                                        for (var _p = true, _q = (e_3 = void 0, __asyncValues(pedidoForcaVenda.itens)), _r; _r = yield _q.next(), _h = _r.done, !_h; _p = true) {
                                            _k = _r.value;
                                            _p = false;
                                            const itemPedido = _k;
                                            itemPedido.pedidoForcaVendaClienteKey = pedidoCliente === null || pedidoCliente === void 0 ? void 0 : pedidoCliente.pedidoForcaVendaClienteKey;
                                            itemPedido.clienteKey = pedidoCliente === null || pedidoCliente === void 0 ? void 0 : pedidoCliente.clienteKey;
                                            let itemTbFaturamentoBluesoftFvItem = new tbfaturamento_bluesoft_fv_item_1.default();
                                            yield itemTbFaturamentoBluesoftFvItem.bindingFromApiForcaVenda(itemPedido, itemTbFaturamentoBluesoftFv.numeropedido_fv);
                                            sql += yield itemTbFaturamentoBluesoftFvItem.scriptSqlInsert();
                                        }
                                    }
                                    catch (e_3_1) { e_3 = { error: e_3_1 }; }
                                    finally {
                                        try {
                                            if (!_p && !_h && (_j = _q.return)) yield _j.call(_q);
                                        }
                                        finally { if (e_3) throw e_3.error; }
                                    }
                                }
                            }
                        }
                        catch (e_2_1) { e_2 = { error: e_2_1 }; }
                        finally {
                            try {
                                if (!_l && !_e && (_f = _m.return)) yield _f.call(_m);
                            }
                            finally { if (e_2) throw e_2.error; }
                        }
                        //Adicionar um sequencial ao processamento (por pedido_fv)
                        i++;
                        if (i >= imax) {
                            yield myBase.myDataBase.pag.Execute(sql);
                            i = 0;
                            sql = ``;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = ListPedidos_1.return)) yield _c.call(ListPedidos_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql) {
                    yield myBase.myDataBase.pag.Execute(sql);
                }
                /* ------------------------------------------------------------------------------------------------------------------ */
                /* ------------------------------------------------------------------------------------------------------------------ */
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "fromApi", e);
            }
        });
    }
    static FaturamentoBlueSosft_Processar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                modelbase_1.clsTools.pagConsole("Processamento do faturamento bluesoft dos dados IMPORTADOS DA API FORÇA DE VENDA - INSERINDO NOVOS REGISTROS", false, false);
                yield myBase.myDataBase.pag.Execute(this.script_processar_faturamento_bluesoft_insert({}));
                modelbase_1.clsTools.pagConsole("Processamento do faturamento bluesoft dos dados IMPORTADOS DA API FORÇA DE VENDA - ATUALIZANDO REGISTROS EXISTENTES", false, false);
                yield myBase.myDataBase.pag.Execute(this.script_processar_faturamento_bluesoft_update({}));
                modelbase_1.clsTools.pagConsole("Processamento do faturamento bluesoft dos dados IMPORTADOS DA API FORÇA DE VENDA - INSERINDO ITENS", false, false);
                yield myBase.myDataBase.pag.Execute(this.script_processar_faturamento_bluesoft_item_insert({}));
                modelbase_1.clsTools.pagConsole("Processamento do faturamento bluesoft dos dados IMPORTADOS DA API FORÇA DE VENDA - ATUALIZANDO ITENS", false, false);
                yield myBase.myDataBase.pag.Execute(this.script_processar_faturamento_bluesoft_item_update({}));
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
					group by xx.numeropedido 
						,	xx.numeropedido_fv 
		
					) xc on xc.numeropedido = pc.numeropedido and xc.numeropedido_fv = pc.numeropedido_fv
		where not exists (select 1 
							from tbfaturamento_bluesoft aaa
							where 1 = 1
							  and aaa.numeropedido = pc.numeropedido 
							  and aaa.numeropedido_fv = p.numeropedido_fv 
						) 
        
        `;
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
                    AND	B.numeropedido_fv = a.numeropedido_fv 
                `;
        return sql;
    }
    static script_processar_faturamento_bluesoft_item_insert(parametro) {
        let sql = `
        
        
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
	
                    from 		tbfaturamento_bluesoft_fv_item 				i
                    inner join 	tbfaturamento_bluesoft_fv_cliente 			pc on pc.numeropedido = i.numeropedido and pc.numeropedido_fv = i.numeropedido_fv
                    inner join  tbfaturamento_bluesoft						f  on f.numeropedido = pc.numeropedido and f.numeropedido_fv = pc.numeropedido_fv
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
                `;
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
        /*      campos retirados da atualização
                ,	valor_verba 					= B.valor_verba
                ,	valor_verba_gerencia 			= B.valor_verba_gerencia
                ,	valor_verba_calculada 			= B.valor_verba_calculada
                ,	valor_desconto_financeiro 		= B.valor_desconto_financeiro
                ,	valor_nf_item_bruto 			= B.valor_nf_item_bruto
                ,	valor_nf_item 					= B.valor_nf_item
        */
        return sql;
    }
    static FaturamentoBluesoft_gerarProcessos(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
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
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "FaturamentoBluesoft_FV_Notificaoes", e);
            }
        });
    }
    static FaturamentoBluesoft_ProcessarNotificacoes(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_4, _b, _c;
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
                catch (e_4_1) { e_4 = { error: e_4_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_4) throw e_4.error; }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftImport", "FaturamentoBluesoft_FV_Notificaoes", e);
            }
        });
    }
}
exports.default = serviceFaturamentoBluesoftForcaVendaImportFromApi;
