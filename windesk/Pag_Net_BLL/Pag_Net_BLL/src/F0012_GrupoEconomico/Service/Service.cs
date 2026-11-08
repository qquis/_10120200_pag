using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0012_GrupoEconomico;

namespace Pag_Net.Bll.F0012_GrupoEconomico.Service
{
    public static class F0012_1250
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Service.GrupoEconomico_BlueSoft.Integ(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
