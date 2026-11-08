using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0095_Integracao.interfaces
{

    public class iF0095_Integracao
    {
        public int integracao_cd { get; set;  }
        public int integracao_tipo_cd { get; set;  }
        public int integracao_status_cd { get; set;  }
        

        public iF0095_Integracao()
        {
            integracao_cd = 0;
            integracao_tipo_cd = 0;
            integracao_status_cd = 0;
            

        }
    }

    public class iF0095_IntegracaoProduto_filter: iF0095_Integracao
    {
        public int pr_cdproduto { get; set; }
	    public int prb_cdprodutoBluesfotUnitario { get; set; }
        public int prb_cdprodutoBlueSoft { get; set;  }
        public int dtlog_insert_filter { get; set;  }
        public DateTime dtlog_insert_ini {get; set;}
        public DateTime dtlog_insert_fim {get; set;} 
        public int dtlog_update_filter  {get; set;} 
        public DateTime dtlog_update_ini {get; set; }
        public DateTime dtlog_update_fim { get; set; }
        public int integracao_produto_seq { get; set; }
        public iF0095_IntegracaoProduto_filter() : base()
        {

            this.pr_cdproduto = 0;
            this.prb_cdprodutoBluesfotUnitario = 0;
            this.prb_cdprodutoBlueSoft = 0;
            this.dtlog_insert_filter = 0;
            this.dtlog_insert_ini = DateTime.Now;
            this.dtlog_insert_fim = DateTime.Now;
            this.dtlog_update_filter = 0;
            this.dtlog_update_ini = DateTime.Now;
            this.dtlog_update_fim = DateTime.Now;
            this.integracao_produto_seq = 0;
        }
    }
}
