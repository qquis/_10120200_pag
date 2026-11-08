import myTools from "../../../tools/Tools"
import { iIntegracao, iIntegracaoProduto } from "../interfaces";


export default class script_select_integracao_produto_20004502 {
    static get() : string {
        
        try  {

          let SQL = ` select     i.pr_cdproduto
                             ,   i.prb_cdprodutobluesoftunitario
                             ,   i.prb_cdprodutobluesoft
                             ,   i.integracao_tipo_cd 
                             ,   i.integracao_status_cd
                             ,   ag.prca_dt_aplicacao 
                             ,   ag.tab_pre_cd 
                             ,   ag.prc_valor 
                             ,   i.integracao_produto_seq
                      from       tbintegracao_produto  i 
                      inner join tbproduto             pr on pr.pr_cdproduto = i.pr_cdproduto 
                                                         and pr.prb_cdprodutobluesoft = i.prb_cdprodutobluesoftunitario
                      inner join tbpreco_agendamento   ag  on i.pr_cdproduto = ag.pr_cdproduto 
                                                          and i.prb_cdprodutobluesoft = ag.prb_cdprodutobluesoft 
                      where      1 = 1
                      and        i.integracao_tipo_cd = 20004502
                      and        ag.tab_pre_cd  = 2
                      and        i.integracao_status_cd in (2,9)
                      and        ag.prca_dt_aplicacao >= current_date -2
                                         
                `

                return SQL;

        } catch (e) {
            return `` 
        }
        
        
    }  
}