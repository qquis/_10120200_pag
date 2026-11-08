using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Distribuicao
{
    public class F0004_51_Distribuicao_Comissao_Detalhe
    {
        private static string _VERSION() { return "f0004_51_1011980_distribuicao_comissao_detalhe"; }
        public static string Get(       int competencia
                                    ,   int cdParticipanteVendedor
                                    , int fvc_seq

            
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() 
                    + "("  
                    + "   vcompetencia:= " + competencia.ToString()
                    + " , vcdparticipantevendedor:= " + cdParticipanteVendedor.ToString()
                    + " , vfvc_seq:= " + fvc_seq.ToString()
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
