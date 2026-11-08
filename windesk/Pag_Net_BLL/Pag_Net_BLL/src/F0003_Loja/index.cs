using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.src.F0210_Notificacao;
using System.Data;
using Pag_Net.Bll.F0003_Loja;
namespace Pag_Net.Bll.F0003_Loja
{
    public class Wk
    {

    }



    public static class Loja
    {
        public static DataTable ArquivoMGV(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0003_50_precolistagem_balanca_mgv.Get());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
