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
    public class TbIntegracaoTipo : Pag_Net.Bll.Tb
    {
        public int integracao_cd { get; set;  }
        public int integracao_tipo_cd { get; set; }
        public string integracao_tipo_descricao { get; set; }
        public int zanthus { get; set; }
        public int bluesoft_redshift { get; set; }
        public int bluesoft_api { get; set; }
        public int tipo_export { get; set; }
        public int tipo_import { get; set; }


        public TbIntegracaoTipo()
        {

            _constructor();

        }

        public void _constructor()
        {
            this.integracao_cd = 0;
            this.integracao_tipo_descricao = "";
            this.integracao_tipo_cd = 0;
            this.zanthus = 0;
            this.bluesoft_redshift = 0;
            this.bluesoft_api = 0;
            this.tipo_export = 0;
            this.tipo_import = 0;

        }

        public override void __Binding(DataRow i)
        {
            try
            {
                this.integracao_cd = Convert.ToInt32(i["integracao_cd"]);
                this.integracao_tipo_cd = Convert.ToInt32(i["integracao_tipo_cd"]);
                this.integracao_tipo_descricao = i["integracao_tipo_descricao"].ToString();
                this.zanthus = Convert.ToInt32(i["zanthus"]);
                this.bluesoft_api = Convert.ToInt32(i["bluesoft_api"]);
                this.tipo_export = Convert.ToInt32(i["tipo_export"]);
                this.tipo_import = Convert.ToInt32(i["tipo_import"]);

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

