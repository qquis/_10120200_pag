using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_ParticipantePessoa.F0011_60_ParticipantePessoaList
{

    public static class Postgre
    {

        public static string Get(
                Pag_Net.Models.TbSysUserInfo MyConnect,
                Filter _filter 
            
            )
        {
            try
            {
                string _PostGre_GET = string.Format("SELECT * FROM " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0011_60_tbparticipantepessoa_list) +
                                                    "( {0}, {1}, {2}, '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, {10}  ) ",
                                                    _filter.cdparticipante.ToString(),
                                                    _filter.cdpessoa.ToString(),					
                                                    _filter.cdpessoabluesoft.ToString(), 			
                                                    _filter.cpf_cnpj.ToString(), 					
                                                    _filter.nome_razao.ToString(), 				
                                                    _filter.email_main.ToString(), 				
                                                    _filter.bluesoftcliente.ToString(), 			
                                                    _filter.bluesoftvendedor.ToString(),			
                                                    _filter.bluesoftfornecedor.ToString(),
                                                    _filter.bluesoftfabricante.ToString(),			
                                                    _filter.cdpessoabluesoft_vendedor.ToString()
                                    
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
