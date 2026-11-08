using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0011_Participante.Service;

namespace Pag_Net.Bll.F0035_Ativo.Service
{
    public static class F0035_3590
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Pag_Net.Bll.F0035_Ativo.Service.AtivoBlueSoft.Import(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
