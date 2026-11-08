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
Object.defineProperty(exports, "__esModule", { value: true });
/*  CONSTANTES _________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ TABMERCADORIA (JS ServiceAtualizacao.tabMercadoria)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const modelbase_1 = require("../../../model/modelbase");
class serviceAtualizacaoDadosVoucherPromocional {
    static start() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            try {
                let myData = new modelbase_1.clsBase();
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Iniciando o processamento de Voucher Promocional`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                let data_hoje = new Date();
                let cod_voucher = modelbase_1.clsTools._datemomentDateToStr(data_hoje, "YYYYMMDD");
                parametros.cod_voucher = cod_voucher;
                yield myData.myDataBase.zanthusPostgre.Execute(serviceAtualizacaoDadosVoucherPromocional.scriptSql(parametros));
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "PROCESSO DE VOUCHER PROMOCIONAL COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static scriptSql(parametro) {
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
}
exports.default = serviceAtualizacaoDadosVoucherPromocional;
