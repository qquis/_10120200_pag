using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0137_CartaoAcesso
{
    public class tbcartao_acesso_registro
    {
        public DateTime dtlog_insert                        { get; set; }
        public DateTime dtlog_update                        { get; set; }
        public int      cartao_acesso_reg_seq               { get; set; }
        public int      cartao_acesso_seq                   { get; set;  }
        public int      controle_reg_pessoa_seq             { get; set;  }
        public int      cartao_acesso_reg_status            { get; set;  }
        public DateTime cartao_acesso_data { get; set; }

        public tbcartao_acesso_registro()
        {

            dtlog_insert                = DateTime.Now;
            dtlog_update                = DateTime.Now;
            cartao_acesso_reg_seq       = 0 ;
            cartao_acesso_seq           = 0; 
            controle_reg_pessoa_seq     = 0;
            cartao_acesso_reg_status    = 0;
            cartao_acesso_data = DateTime.Now;




        }

        public tbcartao_acesso_registro(DataRow i)
        {


            cartao_acesso_data = Convert.ToDateTime(i["cartao_acesso_data"].ToString());
            cartao_acesso_reg_seq = Convert.ToInt32(i["cartao_acesso_reg_seq"].ToString());
            cartao_acesso_seq = Convert.ToInt32(i["cartao_acesso_seq"].ToString());
            controle_reg_pessoa_seq = Convert.ToInt32(i["controle_reg_pessoa_seq"].ToString());
            cartao_acesso_reg_status = Convert.ToInt32(i["cartao_acesso_reg_status"].ToString());
        }
    }

}
