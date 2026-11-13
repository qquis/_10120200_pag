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
/*  CONSTANTES _________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ VOUCHER PROMOCIONAL *** ";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
const tbZanthusTabMercadoriaTipoVenda_1 = __importDefault(require("../tbs/tbZanthusTabMercadoriaTipoVenda"));
class serviceAtualizacaoDadosVoucherPromocional {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            var _a, e_1, _b, _c;
            let i = 0;
            let icount = 0;
            let icountTotal = 0;
            let ilimite_reg_bloq_update = 200;
            let sql = ``;
            this.__log(`Iniciando processamento de Voucher Promocional`);
            try {
                /* DADOS DO VOUCHER PROMOCIONAL - GERANDO O CODIGO_________________________________________________________ */
                let data_hoje = new Date();
                let cod_voucher = modelbase_1.clsTools._datemomentDateToStr(data_hoje, "YYYYMMDD");
                parametros.cod_voucher = cod_voucher;
                this.__log(`Código do voucher gerado: ${parametros.cod_voucher}`);
                /* Obtendo lista de mercadorias em promoção________________________________________________________________ */
                let listTabTipoVenda = [];
                /* _____________Lista de mercadorias em promoção___________________________________________________________ */
                listTabTipoVenda = yield this.getList(parametros);
                /* _____________Array de códigos de mercadoria em promoção_________________________________________________ */
                let listCodMercadoria = [];
                let stringListCodMercadoria = ``;
                if (listTabTipoVenda.length > 0) {
                    for (const item of listTabTipoVenda) {
                        if (item.tab_pre_cd == 2) {
                            listCodMercadoria.push(`'${item.cod_mercadoria}'`);
                        }
                    }
                    stringListCodMercadoria = listCodMercadoria.join(',');
                }
                /* _____________Limpar dados Promocionais__________________________________________________________________ */
                this.__log(`Limpeza dos dados promocionais`);
                this.LimpaDadosTipoVendaPromocional({ ListMercadoriaEmPromocao: stringListCodMercadoria });
                if (listTabTipoVenda.length === 0) {
                    yield this.__log(`ERROR PROMOCIONAL: Nenhuma mercadoria promocional encontrada `);
                    throw new Error(`Nenhuma mercadoria promocional encontrada`);
                }
                try {
                    for (var _d = true, listTabTipoVenda_1 = __asyncValues(listTabTipoVenda), listTabTipoVenda_1_1; listTabTipoVenda_1_1 = yield listTabTipoVenda_1.next(), _a = listTabTipoVenda_1_1.done, !_a; _d = true) {
                        _c = listTabTipoVenda_1_1.value;
                        _d = false;
                        const item = _c;
                        listCodMercadoria.push(`'${item.cod_mercadoria}'`);
                        sql += item.ZanthusPostGre_CRUD();
                        i++;
                        icount++;
                        if (i >= ilimite_reg_bloq_update) {
                            yield this.__log(`Atualizando TabTipoVenda - ${icount} / ${icountTotal} registros processados...`);
                            yield this.__dbExecuteZanthus(sql);
                            sql = ``;
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listTabTipoVenda_1.return)) yield _b.call(listTabTipoVenda_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql !== ``) {
                    yield this.__dbExecuteZanthus(sql);
                }
                /* _____________CRIANDO O VOUCHER PROMOCIONAL NA BASE ZANTHUS_________________________________________________ */
                yield this.__log(`Iniciando criação do voucher promocional na base Zanthus`);
                yield this.__dbExecuteZanthus(this.ScriptProcessarDadosPromocionais(parametros));
                yield this.__log(`Finalizada criação do voucher promocional na base Zanthus`);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0085_Zanthus`, `serviceAtualizacao.Dados.TipoVenda | getList`, e);
            }
        });
    }
    static getList(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            let listTabTipoVenda = [];
            try {
                this.__log(`Obtendo lista de mercadorias promocionais`);
                let result = yield this.__dbGet(this.ScriptListPromocional(parametro));
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let itemTbZanthusTabMercadoriaTipoVenda = new tbZanthusTabMercadoriaTipoVenda_1.default();
                        itemTbZanthusTabMercadoriaTipoVenda.binding(value);
                        listTabTipoVenda.push(itemTbZanthusTabMercadoriaTipoVenda);
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                if (listTabTipoVenda.length === 0) {
                    this.__log(`Nenhuma mercadoria promocional encontrada`);
                }
                else {
                    this.__log(`Total de mercadorias promocionais encontradas: ${listTabTipoVenda.length}`);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`M0085_Zanthus`, `serviceAtualizacao.Dados.TipoVenda | getList`, e);
            }
            finally {
                return listTabTipoVenda;
            }
        });
    }
    static LimpaDadosTipoVendaPromocional(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield this.__log(`Iniciando limpeza dos dados de TipoVenda Promocional`);
                let sql_delete = `delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2; 
                                delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2; `;
                if (parametro.ListMercadoriaEmPromocao && parametro.ListMercadoriaEmPromocao.length > 0) {
                    yield this.__log(`Uma vez que foram encontrados produtos promocionais, na base PAG/PRIME, será realizada apenas a exclusão dos produtos que não estão mais em promoção`);
                    sql_delete = `  delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2 and cod_mercadoria not in(${parametro.ListMercadoriaEmPromocao}); 
                                delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2 and cod_mercadoria not in(${parametro.ListMercadoriaEmPromocao}); 
                                `;
                }
                yield this.__dbExecuteZanthus(sql_delete);
            }
            catch (e) {
                yield this.__error(`Erro na LimpaDadosTipoVendaPromocional`, e);
            }
        });
    }
    static ScriptListPromocional(parametro = {}) {
        let sqlscript = ``;
        sqlscript =
            `select 	a.tab_pre_cd 
                        ,	a.pr_cdproduto				
                        ,	a.prb_cdprodutobluesoft						
                        ,	a.preg_cdbarra								
                        ,	a.cod_loja 									
                        ,	a.controle 									
                        ,	a.cod_mercadoria
                        ,	a.cod_tipo_venda 
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	coalesce(a.data_ultima_alteracao, current_timestamp) as data_ultima_alteracao
                        ,	a.preco_unitario 
                        ,	a.percentual_comissao_vendedor
                        ,   coalesce(a.preco_anterior,0) as preco_anterior
                from 		tbzanthustab_mercadoria_tipo_venda a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                                                                 and me.cod_mercadoria = a.cod_mercadoria
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 
                  and       a.tab_pre_cd = 2
                `;
        return sqlscript;
    }
    static ScriptProcessarDadosPromocionais(parametro) {
        let sql = ` 

                DELETE FROM tab_voucher_promocional_prod WHERE cod_voucher = '${parametro.cod_voucher}'
                ;

                INSERT INTO tab_voucher_promocional 
                    (
                            cod_voucher
                        ,	descricao_parceiro
                        ,	validade_inicial 
                        ,	validade_final
                        ,	minimo_venda
                        ,	tipo_desconto 
                        ,	tipo_utilizacao 
                        ,	tipo_aplicacao 
                        ,	valor_aplicacao
                        ,	flg_status --- >> 0 
                        ,	flg_ativo
                        ,	Dth_inclusao 
                        ,	Dth_alteracao 
                        ,	Idt_usuario_alteracao 
                        ,	limite_utilizacao 
                        ,	limite_utilizado 
                        ,	tipo_comportamento 
                        ,	limite_por_cliente
                        ,	cod_voucher_alternativo
                        ,	flg_fornecedor
                        ,	flags_manager
                        ,	tipo_venda 
                    )

                select		'${parametro.cod_voucher}'                           as cod_voucher				 
                        ,	'PROMOCAO DIA '  || '${parametro.cod_voucher}'     as descricao_parceiro		
                        ,	current_date                             as validade_inicial 		 
                        ,	current_date                             as validade_final			 
                        ,	1.00                                     as minimo_venda			 
                        ,	1                                        as tipo_desconto 			 
                        ,	0                                        as tipo_utilizacao			 
                        ,	1                                        as tipo_aplicacao			 
                        ,	NULL                                     as valor_aplicacao			 
                        ,	0                                        as flg_status				 
                        ,	'S'                                      as flg_ativo				 
                        ,	current_timestamp                        as Dth_inclusao			 
                        ,	current_timestamp                        as Dth_alteracao			     
                        ,	100                                      as Idt_usuario_alteracao	 
                        ,	0                                        as limite_utilizacao		     
                        ,	NULL                                     as limite_utilizado		     
                        ,	2                                        as tipo_comportamento		         
                        ,	0                                        as limite_por_cliente		         
                        ,	NULL                                     as cod_voucher_alternativo          
                        ,	'N'                                      as flg_fornecedor			         
                        ,	NULL                                     as flags_manager			             
                        ,	1                                        as tipo_venda				                         
                    WHERE NOT EXISTS (SELECT 1 FROM tab_voucher_promocional  WHERE cod_voucher  = '${parametro.cod_voucher}')
                ;

                INSERT INTO tab_voucher_promocional_prod
                        (
                                cod_voucher 
                            ,	cod_produto 
                            ,	qtd_maxima 
                            ,	tipo_aplicacao 
                            ,	valor_aplicacao 
                            ,	flg_ativo 
                            ,	Dth_inclusao 
                            ,	Dth_alteracao 
                            ,	Idt_usuario_alteracao 
                        )
                    select		
                                    '${parametro.cod_voucher}'                                                 as cod_voucher				 
                                ,	m.cod_mercadoria                                               as cod_produto				 
                                ,	0                                                              as qtd_maxima				     
                                ,	1                                                              as tipo_aplicacao			 
                                ,	cast(v1.preco_unitario - v2.preco_unitario as numeric(13,2))   as valor_aplicacao			 
                                ,	'S'                                                            as flg_ativo				 
                                ,	current_timestamp                                              as Dth_inclusao			  
                                ,	current_timestamp                                              as Dth_alteracao			     
                                ,	current_timestamp                                              as Idt_usuario_alteracao	     
                    from		tab_mercadoria				m
                    left join	tab_mercadoria_tipo_venda	v1 on v1.cod_mercadoria = m.cod_mercadoria and v1.cod_tipo_venda = '1'
                    left join   tab_mercadoria_tipo_venda	v2 on v2.cod_mercadoria = m.cod_mercadoria and v2.cod_tipo_venda = '2'
                    where		1 = 1
                    and		    cast(v1.preco_unitario as numeric(13,2)) > cast(v2.preco_unitario as numeric(13,2))

                ;
                
                INSERT INTO tab_voucher_promocional_loja
                        ( cod_voucher, cod_loja , flg_ativo, Dth_inclusao, Dth_alteracao, Idt_usuario_alteracao )
                        select '${parametro.cod_voucher}', 1, 'S', current_date, current_date, 100  
                                WHERE NOT EXISTS (SELECT 1 FROM tab_voucher_promocional_loja  WHERE cod_voucher = '${parametro.cod_voucher}')
                ;
                
                `;
        return sql;
    }
    static __dbGet(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            let result;
            try {
                let myClsBase = new modelbase_1.clsBase();
                result = yield myClsBase.myDataBase.pag.DataGet(sql);
            }
            catch (e) {
                yield this.__error(`Erro ao executar query: ${sql}`, e);
            }
            finally {
                return result;
            }
        });
    }
    static __dbExecute(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myClsBase = new modelbase_1.clsBase();
                yield myClsBase.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                yield this.__error(`Erro ao executar query na base Zanthus: ${sql}`, e);
            }
        });
    }
    static __dbExecuteZanthus(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myClsBase = new modelbase_1.clsBase();
                yield myClsBase.myDataBase.zanthusPostgre.Execute(sql);
            }
            catch (e) {
                yield this.__error(`Erro ao executar query na base Zanthus: ${sql}`, e);
            }
        });
    }
    static __error(message, e) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, message, e);
        });
    }
    static __log(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        });
    }
}
exports.default = serviceAtualizacaoDadosVoucherPromocional;
