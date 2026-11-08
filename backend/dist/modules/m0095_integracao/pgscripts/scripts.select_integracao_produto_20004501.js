"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class script_select_integracao_produto_20004501 {
    static get() {
        try {
            let SQL = ` SELECT 	        i.pr_cdproduto
                                ,       i.prb_cdprodutobluesoftunitario
                                ,       i.prb_cdprodutobluesoft
                                ,       i.integracao_tipo_cd 
                                ,       i.integracao_status_cd
                                ,       x.tab_pre_cd 
                                ,		x.preco_aplicacao_data 
                                ,		x.pr_cdproduto 
                                ,		x.prc_valor
                                ,		x.prc_qtde_promocional 
                                ,		x.prc_valor_promocional
                                ,       i.integracao_produto_seq
                            from 		tbpreco_aplicacao			 	x
                            inner join  tbproduto 						pr on pr.pr_cdproduto = x.pr_cdproduto 
                            inner join 	tbprodutobluesoft 				pb on pb.prb_cdprodutobluesoft_pk = x.prb_cdprodutobluesoft 
                            inner join  tbintegracao_produto	 		i  on 	i.pr_cdproduto = x.pr_cdproduto
                                                                        and		i.prb_cdprodutobluesoftunitario = x.prb_cdprodutobluesoft_unitario 
                                                                        and		i.prb_cdprodutobluesoft = x.prb_cdprodutobluesoft 
                            where 		1 = 1
                            and		i.integracao_tipo_cd = 20004501
                            and 	x.tab_pre_cd = 1
                            and		i.integracao_status_cd in (2,9)                                     
                `;
            return SQL;
        }
        catch (e) {
            return ``;
        }
    }
}
exports.default = script_select_integracao_produto_20004501;
