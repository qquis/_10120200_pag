using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0045_Preco.scripts
{
    public static class f0045_01_Service_AtualizarPreco
    {
        public static string _VERSION() { return "f0045_01_1012003_service_atualizarpreco"; }
        public static string Get(
                    Pag_Net.Models.modelSistemaUsuario MyConnect,
                    bool agendamento,
                    DateTime prca_dt_aplicacao,
                    int prca_dt_aplicacao_definitiva,
                    int pr_cdproduto,
                    int pr_cdprodutobluesoft,
                    int tab_pre_cd,
                    double prc_valor,
                    double prc_qtde_promocional,
                    double prc_valor_promocional,
                    double pre_fatorpreco
            
            
            
            )
        {
            string SQL = string.Format("SELECT " + _VERSION() + " (	    " +
                                                              "   vsequencial_de_processo:= " + MyConnect.SEQUENCIAL_DE_PROCESSO.ToString() +
                                                              " , vagendamento:= '" + agendamento.ToString() +  "'" +
                                                              " , vprca_dt_aplicacao:=  '"  + prca_dt_aplicacao.ToString("yyyy-MM-dd") +    "'" +
                                                              " , vprca_aplicacao_definitiva:= " +    prca_dt_aplicacao_definitiva.ToString() +
                                                              " , vpr_cdproduto:= " + pr_cdproduto.ToString() + 
                                                              " , vprb_cdprodutobluesoft:= " + pr_cdprodutobluesoft.ToString() +
                                                              " , vtab_pre_cd:= " + tab_pre_cd.ToString() +
                                                              " , vprc_valor:= " + prc_valor.ToString().Replace(",", ".") +
                                                              " , vprc_qtde_promocional:= " + prc_qtde_promocional.ToString().Replace(",", ".") +
                                                              " , vprc_valor_promocional:= " + prc_valor_promocional.ToString().Replace(",", ".") +
                                                              " , vpre_fatorpreco:= " + pre_fatorpreco.ToString().Replace(",", ".") + 
                                                              ") ; ");

            return SQL;
        }
    }
}
