using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0137_CartaoAcesso
{
    public class TbCartaoAcessoTipo
    {
        public int cartao_acesso_tipo_cd { get; set;  }
        public string cartao_acesso_tipo_descricao { get; set; }

        public TbCartaoAcessoTipo()
        {
            cartao_acesso_tipo_cd = 0;
            cartao_acesso_tipo_descricao = "Selecione o Tipo de Cartão";
        }

		public TbCartaoAcessoTipo(DataRow i)
        {

            cartao_acesso_tipo_cd = Convert.ToInt32(i["cartao_acesso_tipo_cd"].ToString());
            cartao_acesso_tipo_descricao = i["cartao_acesso_tipo_descricao"].ToString();
        }
    }

	
}
