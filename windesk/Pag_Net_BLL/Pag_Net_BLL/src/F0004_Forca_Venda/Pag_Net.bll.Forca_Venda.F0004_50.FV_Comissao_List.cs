using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class F0004_50_FV_Comissao_List
    {
        private static string _VERSION() { return "f0004_50_1011960_fv_comissao_list"; }
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
                    + " , vfvc_data_fechamento_ini:= '" + DataFechamentoInicial.ToString("yyyy-MM-dd") + "'"
                    + " , vfvc_data_fechamento_fim:= '" + DataFechamentoFinal.ToString("yyyy-MM-dd") + "'"
                    + ")" 
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
