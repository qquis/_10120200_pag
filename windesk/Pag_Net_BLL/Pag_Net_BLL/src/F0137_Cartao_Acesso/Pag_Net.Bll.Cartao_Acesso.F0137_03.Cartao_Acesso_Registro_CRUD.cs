using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0137_CartaoAcesso
{
    public class F0136_03_CartaoAcessoRegistroCRUD
    {
        private static string _VERSION() { return "f0137_03_1011922_cartao_acesso_registro_CRUD"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            tbcartao_acesso_registro CartaoAcessoRegistro
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, '{3}', {4}, {5})",
                    BDCommnadType.ToString(),
                    CartaoAcessoRegistro.cartao_acesso_reg_seq.ToString(),
                    CartaoAcessoRegistro.cartao_acesso_reg_status.ToString(),
                    CartaoAcessoRegistro.cartao_acesso_data.ToString("yyyy-MM-dd"),
                    CartaoAcessoRegistro.cartao_acesso_seq.ToString(),
                    CartaoAcessoRegistro.controle_reg_pessoa_seq.ToString()
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
