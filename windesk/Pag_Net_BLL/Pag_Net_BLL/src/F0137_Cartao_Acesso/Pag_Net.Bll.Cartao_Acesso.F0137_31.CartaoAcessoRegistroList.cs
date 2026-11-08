using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0137_CartaoAcesso
{
    public class F0137_31_CartaoAcessoRegistroList
    {
        public int cartao_acesso_seq            { get; set; }
        public int cartao_acesso_reg_seq        { get; set; }
        public int cartao_acesso_reg_status     { get; set;  }
        public int controle_reg_seq             { get; set;  }

        public F0137_31_CartaoAcessoRegistroList()
        {
            cartao_acesso_seq = 0;
            cartao_acesso_reg_seq = 0;
            cartao_acesso_reg_status = 0;
            controle_reg_seq = 0;

        }
        public F0137_31_CartaoAcessoRegistroList(
                    int _cartao_acesso_seq    ,    
                    int _cartao_acesso_reg_seq ,   
                    int _cartao_acesso_reg_status ,
                    int _controle_reg_seq         
           )
        {
            cartao_acesso_seq = _cartao_acesso_seq;
            cartao_acesso_reg_seq = _cartao_acesso_reg_seq;
            cartao_acesso_reg_status = _cartao_acesso_reg_status;
            controle_reg_seq = _cartao_acesso_seq;
        }

        private string _VERSION() { return "f0137_31_1011922_cartao_acesso_registro_list"; }
        public string PostGre_Get_Function()
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("({0}, {1}, {2}, {3})",
                    cartao_acesso_seq.ToString(),
                    cartao_acesso_reg_seq.ToString(),
                    cartao_acesso_reg_status.ToString(),
                    controle_reg_seq.ToString()
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
