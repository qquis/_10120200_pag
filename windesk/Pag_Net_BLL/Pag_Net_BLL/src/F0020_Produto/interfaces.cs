using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.interfaces
{
    public class iF0020_Produto_filter
    {
        public int pr_cdproduto { get; set; }
	    public int prb_cdprodutoBluesfotUnitario { get; set; }
        public int prb_cdprodutoBlueSoft { get; set;  }
        public string preg_cdbarra { get; set;  }
        public string pr_descricao { get; set;  }
        public string prb_descricao { get; set;  }
        public string prb_descricao_fiscal { get; set;  }


        public bool Seleciona_Data_Cadastro { get; set; }
        public DateTime prb_dt_cadastro_ini { get; set;  }
        public DateTime prb_dt_cadastro_fim { get; set;  }
        public bool Status_Ativo { get; set;  }
        public bool Status_Inativo { get; set; }
        
        public string prbg_cdbarra_pk { get; set;  }

        public iF0020_Produto_filter() { _constructor(0); }
        public iF0020_Produto_filter(int _pr_cdproduto) { _constructor(_pr_cdproduto); }

        public void _constructor(int _pr_cdproduto)
        {
            this.pr_cdproduto = _pr_cdproduto;
            
            this.prb_cdprodutoBluesfotUnitario = 0;
            this.prb_cdprodutoBlueSoft = 0;
            this.preg_cdbarra = "";
            this.pr_descricao = ""; 
            this.prb_descricao = "";
            this.prb_descricao_fiscal = "";
            this.prb_dt_cadastro_ini = Convert.ToDateTime("1900-01-01");
            this.prb_dt_cadastro_fim = Convert.ToDateTime("1900-01-01");
            this.prbg_cdbarra_pk = "";
            this.Seleciona_Data_Cadastro = false;
        }
    }
}
