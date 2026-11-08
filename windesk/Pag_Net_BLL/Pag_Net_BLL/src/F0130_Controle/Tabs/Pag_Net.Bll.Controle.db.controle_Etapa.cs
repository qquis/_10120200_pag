using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle_Etapa
    {
        public int controle_cd { get; set; }
        public int controle_etapa_cd { get; set; }
        public string  controle_etapa_descricao { get; set; }



        public TbControle_Etapa()
        {

        }

        public TbControle_Etapa(int _controle_cd, int _controle_etapa_cd, string _controle_etapa_descricao)
        {

            controle_cd = _controle_cd;
            controle_etapa_cd = _controle_etapa_cd;
            controle_etapa_descricao = _controle_etapa_descricao;

        }


        public TbControle_Etapa(DataRow i)
        {
            controle_cd = Convert.ToInt32(i["controle_cd"]);
            controle_etapa_cd = Convert.ToInt32(i["controle_etapa_cd"]);
            controle_etapa_descricao = i["controle_etapa_descricao"].ToString();
        }


    }
}
