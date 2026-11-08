using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class F0004_41_FV_frete_Consultar
    {
        private static string _VERSION() { return "f0004_41_1011991_fv_frete_consultar"; }
        public static string Get(       int competencia_cd
                                    ,   int cdparticipante_motorista
                                    , int fv_frete_seq
            
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() 
                    + "("
                    + "   vcompetencia_cd:= " + competencia_cd.ToString()
                    + " , vcdparticipante_motorista:= " + cdparticipante_motorista.ToString()
                    + " , vfv_frete_seq:= " + fv_frete_seq.ToString()
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
