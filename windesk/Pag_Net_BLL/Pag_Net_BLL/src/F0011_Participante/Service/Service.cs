using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0011_Participante.Service;

namespace Pag_Net.Bll.F0011_Participante.Service
{
    public static class F0011_1103
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Participante_BlueSoft_GRP.Integ(MyConnect);
                Participante_BlueSoft.Integ(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
