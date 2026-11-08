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
    public class TbIntegracao : Pag_Net.Bll.Tb
    {
        public int integracao_cd { get; set;  }
        public string integracao_descricao { get; set; }



        public TbIntegracao()
        {

            _constructor();

        }

        public void _constructor()
        {
            this.integracao_cd = 0;
            this.integracao_descricao = ""; 

        }

        public override void __Binding(DataRow i)
        {
            try
            {
                this.integracao_cd = Convert.ToInt32(i["integracao_cd"].ToString());
                this.integracao_descricao = i["integracao_descricao"].ToString();

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
    }
}

