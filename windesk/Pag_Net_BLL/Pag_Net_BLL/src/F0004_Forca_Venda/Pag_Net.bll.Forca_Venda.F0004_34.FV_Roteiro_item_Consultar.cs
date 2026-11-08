using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class F0004_34_FV_Roteiro_Item_Consultar
    {
        private static string _VERSION() { return "f0004_34_1011991_fv_roteiro_item_consultar"; }
        public static string Get(       int competencia_cd
                                    ,   int cdparticipante_motorista
                                    , DateTime data_fechamento_ini
                                    , DateTime data_fechamento_fim
                                    , int vroteiro_cd 
            
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
                    + " , vroteiro_cd:= " + vroteiro_cd.ToString()
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
