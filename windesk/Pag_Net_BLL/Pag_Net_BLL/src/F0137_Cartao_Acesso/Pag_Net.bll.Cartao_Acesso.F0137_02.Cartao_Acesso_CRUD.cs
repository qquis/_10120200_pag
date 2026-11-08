using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0137_CartaoAcesso
{
    public class F0136_02_CartaoAcesso_CRUD
    {
        private static string _VERSION() { return "f0137_02_1011922_cartao_acesso_CRUD"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            tbcartao_acesso CartaoAcesso
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, '{2}', {3}, '{4}', {5}, '{6}', '{7}', {8}, {9}, {10}, {11})",
                    BDCommnadType.ToString(),
                    CartaoAcesso.cartao_acesso_seq.ToString(),  		
                    CartaoAcesso.cartao_acesso_data.ToString("yyyy-MM-dd"),
                    CartaoAcesso.cartao_acesso_numero.ToString(), 		
                    CartaoAcesso.cartao_acesso_cdbr.ToString(),			
                    CartaoAcesso.cartao_acesso_tipo_cd.ToString(),
                    CartaoAcesso.cartao_acesso_validade_ini.ToString("yyyy-MM-dd"),
                    CartaoAcesso.cartao_acesso_validade_fim.ToString("yyyy-MM-dd"),
                    CartaoAcesso.cartao_acesso_status.ToString(),		
                    CartaoAcesso.cdparticipante.ToString(),
                    CartaoAcesso.cdpessoabluesoft.ToString(),
                    CartaoAcesso.rh_funcionario_cd.ToString()
                    ));

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
