using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;



/*
    10/02/2023 Criação - vindo da pasta funções
    11/02/2023 Adição dos campos  competencia_cd, plc_conta_cd, plc_conta_cd_destino
 
*/
namespace Pag_Net.src.F0095_Integracao.tbs
{
    public class TbIntegracaoProduto : Pag_Net.Bll.Tb
    {
        public int integracao_produto_seq { get; set;  }
        public int pr_cdproduto { get; set;  }
        public int prb_cdprodutobluesoftunitario { get; set;  }
        public int prb_cdprodutobluesoft { get; set;  }
        public int integracao_tipo_cd { get; set;  }
        public int integracao_status_cd { get; set;  }




        public TbIntegracaoProduto()
        {

            _constructor();

        }

        public void _constructor()
        {
            this.integracao_produto_seq = 0;
            this.pr_cdproduto = 0;
            this.prb_cdprodutobluesoftunitario = 0;
            this.prb_cdprodutobluesoft = 0;
            this.integracao_tipo_cd = 0;
            this.integracao_status_cd = 0;

        }

        public override void __Binding(DataRow i)
        {
            try
            {
    

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override string _Db_Pg_script_Select()
        {
            return "";            
        }

        public override string _Db_Pg_script_Update()
        {
            return "";
        }

        
    }
}

