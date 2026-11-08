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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class scriptUpdateZanthusVoucherPromocional {
    static ScriptExecute(myDataBase_SERVER) {
        return __awaiter(this, void 0, void 0, function* () {
            let sqlscript = ``;
            if (myDataBase_SERVER == 'ZANTHUSPOSTGRE') {
                sqlscript = yield this.ZanthusPostGre_CRUD();
            }
            return sqlscript;
        });
    }
    static ZanthusPostGre_CRUD() {
        return __awaiter(this, void 0, void 0, function* () {
            /*
                28/09/2026 segunda-feira
                tipo_comportamento alterado de 2 para 0
            */
            let sql = ``;
            try {
                let data_hoje = new Date();
                let cod_voucher = Tools_1.default._datemomentDateToStr(data_hoje, "YYYYMMDD");
                sql = ` 

                DELETE FROM tab_voucher_promocional_prod WHERE cod_voucher = '${cod_voucher}'
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

                select		'${cod_voucher}'                           as cod_voucher				 
                        ,	'PROMOCAO DIA '  || '${cod_voucher}'     as descricao_parceiro		 
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
                    WHERE NOT EXISTS (SELECT 1 FROM tab_voucher_promocional  WHERE cod_voucher  = '${cod_voucher}')
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
                                    '${cod_voucher}'                                                 as cod_voucher				 
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
                        select '${cod_voucher}', 1, 'S', current_date, current_date, 100  
                                WHERE NOT EXISTS (SELECT 1 FROM tab_voucher_promocional_loja  WHERE cod_voucher = '${cod_voucher}')
                ;
                
                `;
                return sql;
            }
            catch (e) {
                Tools_1.default.pagConsole(`(Error) ScriptUpdateZanthusVoucherPromocional  - ZanthusPostGre_CRUD 
                                Message Error  
                                ${e}
                               `);
                throw new Error(`(Error) ScriptUpdateZanthusVoucherPromocional  - ZanthusPostGre_CRUD 
                                Message Error  
                                ${e}
                           `);
            }
        });
    }
}
exports.default = scriptUpdateZanthusVoucherPromocional;
