using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class F0004_40_FV_frete_consolidar
    {
        private static string _VERSION() { return "f0004_40_1011991_fv_frete_consolidar"; }
        public static string Post(       int competencia_cd
                                    ,   int cdparticipante_motorista
                                    , DateTime data_fechamento_ini
                                    , DateTime data_fechamento_fim
            
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() 
                    + "("
                    + "   vcompetencia_cd:= " + competencia_cd.ToString()
                    + " , vcdparticipante_motorista:= " + cdparticipante_motorista.ToString()
                    + " , vdata_fechamento_ini:= '" + data_fechamento_ini.ToString("yyyy-MM-dd") + "'"
                    + " , vdata_fechamento_fim:= '" + data_fechamento_fim.ToString("yyyy-MM-dd") + "'"
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
