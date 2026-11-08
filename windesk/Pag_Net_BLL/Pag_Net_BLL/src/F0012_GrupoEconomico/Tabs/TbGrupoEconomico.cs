using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0012_GrupoEconomico
{
    public class TbGrupoEconomico : Pag_Net.Bll.Tb
    {
        public int cdgrupoeconomico { get; set; }
        public string descricao {get; set; }
        public string descricaoresumida { get; set;  }
        public string referencia { get; set;  }
        public int grupoeconomico_status  { get; set; }
        public int johnson_cliente_top { get; set; }
        public TbGrupoEconomico() { _constructor(); }

        public void _constructor()
        {
            cdgrupoeconomico = 0;
            descricao = "";
            descricaoresumida = "";
            referencia = "";
            grupoeconomico_status = 0;
            johnson_cliente_top = 0;
        }

        public override void __Binding(DataRow i)
        {
            this.cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"].ToString()); 
            this.descricao = i["descricao"].ToString();
            this.descricaoresumida = i["descricaoresumida"].ToString();
            this.referencia = i["referencia"].ToString();
            this.grupoeconomico_status = Convert.ToInt32(i["grupoeconomico_status"]);
            this.johnson_cliente_top = Convert.ToInt32(i["johnson_cliente_top"].ToString());

        }

        public TbGrupoEconomico(int _cdgrupoeconomico, string _descricao)
        {
            cdgrupoeconomico = _cdgrupoeconomico;
            descricao = _descricao;
        }

        public override string __Db_Pg_script(BDCommandTypes BDCommnadType)
        {
            string __Db_Pg_script = "";
            __Db_Pg_script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0012_GrupoEconomico.F0012_01_GrupoParticipante_Grud._VERSION() +
                "  (        sqlcommand:= '" + BDCommnadType.ToString() + "'" +
                "       ,   vcdgrupoeconomico:= " + this.cdgrupoeconomico + "" +
                "       ,   vdescricao:= '" + this.descricao + "'" +
                "       ,   vdescricaoresumida:= '" + this.descricaoresumida + "'" +
                "       ,   vreferencia:= '" + this.referencia + "'" +
                "       ,   vgrupoeconomico_status:= " + this.grupoeconomico_status + "" +
                "       ,   vjohnson_cliente_top:= " + this.johnson_cliente_top + "" +
                "  );");

            return __Db_Pg_script;
        }


    }

}




