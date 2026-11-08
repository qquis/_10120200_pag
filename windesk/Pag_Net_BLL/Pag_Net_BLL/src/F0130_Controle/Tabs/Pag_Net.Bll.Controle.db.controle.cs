using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle
    {
        public int controle_cd { get; set; }
        public string controle_descricao {get; set; }
        public int controle_etapa_final  {get; set;}
        public int controle_status_cd_inicial { get; set; }
        public int controle_status_pgto_cd_inicial { get; set;  }

    

        public TbControle()
        {
            controle_cd = 0;
            controle_descricao = "";
            controle_status_cd_inicial = 0;
            controle_status_pgto_cd_inicial = 0;

        }

        public TbControle(

             int _controle_cd,
             string _controle_descricao,
             int _controle_status_cd_inicial,
             int _controle_status_pgto_cd_inicial

            )
        {

            controle_cd = _controle_cd;
            controle_descricao = _controle_descricao;
            controle_status_cd_inicial = _controle_status_cd_inicial;
            controle_status_pgto_cd_inicial = _controle_status_pgto_cd_inicial;
        }


        public TbControle(DataRow i)
        {
            controle_cd = Convert.ToInt32(i["controle_cd"]);
            controle_descricao = i["controle_descricao"].ToString();
            controle_status_cd_inicial = Convert.ToInt32(i["controle_status_cd_inicial"].ToString());
            controle_status_pgto_cd_inicial = Convert.ToInt32(i["controle_status_pgto_cd_inicial"].ToString());
        }


    }
}
