"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbZanthusCargaProduto_1 = __importDefault(require("../tbs/tbZanthusCargaProduto"));
class model_zanthus_carga_produto extends tbZanthusCargaProduto_1.default {
    /* CHAVES */
    constructor() {
        super();
    }
    scriptProdutosPendente(carga_uuid, carga_tipo_cd) {
        let script_carga_produto = '';
        if (carga_tipo_cd == 1) {
            script_carga_produto = this.scriptProdutosCargaTipoPadrao_1(carga_uuid);
        }
        return script_carga_produto;
    }
    scriptProdutosCargaTipoPadrao_1(carga_uuid) {
        let sql = ``;
        sql += ` insert into tbzanthus_carga_produto 
                        (
                                 carga_uuid                            
                            ,    pr_cdproduto                          
                            ,    prb_cdprodutobluesoftunitario         
                            ,    prb_cdprodutobluesoft                 
                            ,    cod_mercadoria                        
                        )
                            select      
                                      '${carga_uuid}'
                                    ,   pr.pr_cdproduto
                                    ,	i.prb_cdprodutobluesoftunitario 	
                                    ,   m.prb_cdprodutobluesoft
                                    ,	m.cod_mercadoria 
                            from     	tbintegracao_produto i
                            inner join 	tbproduto pr on pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoftunitario
                            inner join  tbzanthustab_mercadoria m on m.pr_cdproduto = pr.pr_cdproduto 
                            where    	i.integracao_tipo_cd = 20008501
                            and         i.integracao_status_cd = 2
                            ;
                    `;
        sql += this.scriptProdutosTipoCestaBasica(carga_uuid);
        return sql;
    }
    scriptProdutosTipoCestaBasica(carga_uuid) {
        return ` insert into tbzanthus_carga_produto 
                        (
                                 carga_uuid                            
                            ,    pr_cdproduto                          
                            ,    prb_cdprodutobluesoftunitario         
                            ,    prb_cdprodutobluesoft                 
                            ,    cod_mercadoria                        
                        )

                        SELECT      '${carga_uuid}' as carga_uuid
                                ,   i.pr_cdproduto
                                ,   pb.prb_cdprodutobluesoftunitario 
                                ,   i.prb_cdprodutobluesoft
                                ,   i.cod_mercadoria 
                        FROM        TbZanthustab_produto_decomposicao i
                        inner join   tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
        
                            order by 1, 2, 3, 4 asc
                    ;
                    `;
    }
}
exports.default = model_zanthus_carga_produto;
