using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{

    public static class F0011_10_ParticipanteConsultar
    {



        private static string __Version() { return "f0011_10_1011940_tbparticipante_consultar"; }
        public static string Get(
            
                string cpf_cnpj 
            ,   int cdparticipante 
            ,   int cdpessoabluesoft 
            ,   int rh_funcionario_cd 

            
            )
        {
            try
            {
                string _PostGre_GET = string.Format("SELECT * FROM " + __Version() +
                                                    "( {0}, '{1}', {2}, {3}) ",
                                                    cdparticipante.ToString(),
                                                    cpf_cnpj.ToString(),
                                                    cdpessoabluesoft.ToString(),
                                                    rh_funcionario_cd.ToString()
                   );
                return _PostGre_GET;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}

