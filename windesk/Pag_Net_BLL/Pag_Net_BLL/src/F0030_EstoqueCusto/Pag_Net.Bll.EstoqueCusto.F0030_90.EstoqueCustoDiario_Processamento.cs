using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0030_EstoqueCusto;

namespace Pag_Net.Bll.F0030_EstoqueCusto
{
    public static class F0030_10_EstoqueCustoDiario_Processamento
    {
        private static string _VERSION() { return "f0030_90_1011950_estoquecustos_diario_processamento"; }
        public static string Post()
        {
            try
            {
                string RedShift_SELECT = String.Format("SELECT  " + _VERSION() + " ()");
                return RedShift_SELECT;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
   
    }
}
