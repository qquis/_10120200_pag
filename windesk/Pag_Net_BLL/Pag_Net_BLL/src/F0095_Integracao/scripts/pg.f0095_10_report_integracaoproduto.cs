using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0095_Integracao.scripts
{
    public class f0095_10_report_integracaoProduto
    {
        private static string _VERSION() { return "f0095_10_1012007_report_integracaoproduto"; }
        public static string Get(
                   Pag_Net.Models.modelSistemaUsuario MyConnect
                , interfaces.iF0095_IntegracaoProduto_filter filtro
     

               )
        {

            string SQL_POSTGRE = "";

            try
            {
                SQL_POSTGRE = string.Format("Select * " + 
                                                "FROM " + _VERSION()
                                                + "(  vintegracao_cd:=  " + filtro.integracao_cd.ToString() + 
                                                  " , vintegracao_tipo_cd:= " + filtro.integracao_tipo_cd.ToString() + 
                                                  " , vintegracao_status_cd:= " + filtro.integracao_status_cd.ToString() + 
                                                  " , vpr_cdproduto:= " + filtro.pr_cdproduto.ToString() +
                                                  " , vprb_cdprodutobluesoftunitario:=  " + filtro.prb_cdprodutoBluesfotUnitario.ToString() +
                                                  " , vprb_cdprodutobluesoft:= " + filtro.prb_cdprodutoBlueSoft.ToString() + 
                                                  " , vdtlog_insert_filter:= " + filtro.dtlog_insert_filter.ToString() +
                                                  " , vdtlog_insert_ini:= '" + filtro.dtlog_insert_ini.ToString("yyyy-MM-dd") + "'" +
                                                  " , vdtlog_insert_fim:= '" + filtro.dtlog_insert_fim.ToString("yyyy-MM-dd") + "'" +
                                                  " , vdtlog_update_filter:= " + filtro.dtlog_update_filter.ToString() +
                                                  " , vdtlog_update_ini:= '" + filtro.dtlog_update_ini.ToString("yyyy-MM-dd") + "'" +
                                                  " , vdtlog_update_fim:= '" + filtro.dtlog_update_fim.ToString("yyyy-MM-dd") + "'" + 
                                                   "   )") ;
                return SQL_POSTGRE;
            }
            catch (Exception Ex)
            {
                throw new Exception("F0095_Integracao.scripts " + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "ScriptSQL: " + SQL_POSTGRE + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "Erro Message: " + Ex.Message);
            }

        }
    }


 
}
