using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle_Pessoa
    {
        public int controle_cd { get; set; }
        public int controle_pessoa_cd { get; set; }
        public string controle_pessoa_descricao { get; set; }
    

        public TbControle_Pessoa()
        {
            controle_cd = 0;
            controle_pessoa_cd = 0;
            controle_pessoa_descricao = "";
        }

        public TbControle_Pessoa(

             int _controle_cd,
            int _controle_pessoa_Cd,
             string _controle_pessoa_descricao
            )
        {

            controle_cd = _controle_cd;
            controle_pessoa_cd = _controle_pessoa_Cd;
            controle_pessoa_descricao = _controle_pessoa_descricao.ToUpper();


        }


        public TbControle_Pessoa(DataRow i)
        {
            controle_cd = Convert.ToInt32(i["controle_cd"]);
            controle_pessoa_cd = Convert.ToInt32(i["controle_pessoa_cd"]);
            controle_pessoa_descricao = i["controle_pessoa_descricao"].ToString();
        }


    }
}
