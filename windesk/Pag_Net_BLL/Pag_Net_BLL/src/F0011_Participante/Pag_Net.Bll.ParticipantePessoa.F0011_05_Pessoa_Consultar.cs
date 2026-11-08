using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_ParticipantePessoa.F0011_05_Pessoa_Consultar
{

    public static class Postgre
    {

        public static string __Version () { return "f0011_05_1011915_Pessoa_Consultar"; }
        public static string Get(
                string CPF_CNPJ, 
                int vCdParticipante, 
                int vCdPessoaBlueSoft, 
                int vRh_Funcionario_Cd
            )
        {
            try
            {
                string _PostGre_GET = string.Format("SELECT * FROM " + __Version() +
                                                    "( '{0}', {1}, {2}, {3}) ",
                                                    CPF_CNPJ, 
                                                    vCdParticipante.ToString(), 
                                                    vCdPessoaBlueSoft.ToString(), 
                                                    vRh_Funcionario_Cd.ToString()
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
