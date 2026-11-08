using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0025_EstoqueLocal
{
   public static class F0025_05_EstoqueLocal_Mov_CRUD
    {
        private static string _VERSION() { return "f0025_05_1011915_estoquelocal_mov_crud"; }
        public static string Post(
                    Pag_Net.Models.modelSistemaUsuario MyConnect,
                    tbestoquelocal_mov localTbEstoqueLocal_Mov

            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + string.Format("('{0}', {1}, '{2}', {3}, {4})", 
                        localTbEstoqueLocal_Mov.estlocal_mov_data.ToString("yyyy-MM-dd"),
                        localTbEstoqueLocal_Mov.pr_cdproduto.ToString(), 
                        localTbEstoqueLocal_Mov.pr_embalagemestoque.ToString(), 
                        localTbEstoqueLocal_Mov.estlocal_mov_embalagemestoque_qtde.ToString(), 
                        localTbEstoqueLocal_Mov.proc_log_seq.ToString()
                    ));
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}

