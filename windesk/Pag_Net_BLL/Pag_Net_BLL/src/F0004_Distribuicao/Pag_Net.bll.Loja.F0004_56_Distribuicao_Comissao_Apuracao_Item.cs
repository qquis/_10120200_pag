using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Distribuicao
{
    public class F0004_55_Distribuicao_Comissao_Apuracao_Item
    {
        private static string _VERSION() { return "f0004_56_1011980_distribuicao_comissao_apuracao_item"; }
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
