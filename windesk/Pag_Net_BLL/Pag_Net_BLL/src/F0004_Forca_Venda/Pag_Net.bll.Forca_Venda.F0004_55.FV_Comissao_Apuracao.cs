using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class F0004_55_FV_Comissao_Apuracao 
    {
        private static string _VERSION() { return "f0004_55_1011980_fv_comissao_apuracao"; }
        public static string Get(       int competencia
                                    ,   int cdParticipanteVendedor
                                    ,   DateTime DataFechamentoInicial
                                    ,   DateTime DataFechamentoFinal
            
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() 
                    + "("  
                    + "   vcompetencia:= " + competencia.ToString()
                    + " , vcdparticipantevendedor:= " + cdParticipanteVendedor.ToString()
                    + " , vdata_faturamento_ini:= '" + DataFechamentoInicial.ToString("yyyy-MM-dd") + "'"
                    + " , vdata_faturamento_fim:= '" + DataFechamentoFinal.ToString("yyyy-MM-dd") + "'"
                    + ") " 
                    );
                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
