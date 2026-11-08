using Pag_Net.Bll;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0095_Integracao.scripts
{
    public class f0095_15_integracaoProduto_CRUD 
    {
        private static string _VERSION() { return "f0095_15_1012007_integracao_produto_crud"; }
        public static string Get(
                BDCommandTypes BDCommnadType,
                model.modelintegracao_produto item
     

               )
        {

            string SQL_POSTGRE = "";

            try
            {
                SQL_POSTGRE = string.Format("Select * " + 
                                                "FROM " + _VERSION()
                                                + "(  sqlcommand:= '" + BDCommnadType.ToString() + "'" + 
                                                  " , vintegracao_tipo_cd:= " + item.integracao_tipo_cd.ToString() + 
                                                  " , vintegracao_status_cd:= " + item.integracao_status_cd.ToString() + 
                                                  " , vintegracao_produto_seq:= " + item.integracao_produto_seq.ToString() + 
                                                  " , vpr_cdproduto:= " + item.pr_cdproduto.ToString() +
                                                  " , vprb_cdprodutobluesoftunitario:=  " + item.prb_cdprodutobluesoftunitario.ToString() + 
                                                  " , vprb_cdprodutobluesoft:= " + item.prb_cdprodutobluesoft.ToString() + 
                                                   "   ) ;") ;
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
