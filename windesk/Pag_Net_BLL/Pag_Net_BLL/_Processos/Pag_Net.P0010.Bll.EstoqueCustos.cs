using System;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;
using Pag_Net.Bll;
using System.Collections.Generic;

/* Data: 20/01/2021 
 * Objetivo: Executa a função Postgre p0010_EstoqueCustos_Update para todos os produtos da tabela Postgre.tbproduto
 * Obsevação: Atualização dos dados de custo da tabela tbprodutocusto conforme estoque diario (tbestoquecusto_diariobluesoft)
 * 
 */


namespace Pag_Net.P0010.Bll
{
    public static class Process
    {

        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
           
            string ErroInfo = "";
            try
            {

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                string SQL_POSTGRE_EXEC = string.Format("SELECT p0010_01_1011862_estoquecustos_processamento ()	");
                BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.P0010.PostGreSQL: " + ErroInfo + " - " + ex.Message);
            }

         }
    }
}
