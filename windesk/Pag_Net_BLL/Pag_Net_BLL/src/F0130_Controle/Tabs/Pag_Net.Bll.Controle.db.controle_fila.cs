using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle_Fila 
    {
        public int controle_cd { get; set; }
        public int controle_fila_cd { get; set; }
        public string controle_fila_descricao {get; set; }
    

        public TbControle_Fila()
        {
            controle_cd = 0;
            controle_fila_cd = 0;
            controle_fila_descricao = "";
        }

        public TbControle_Fila(

             int _controle_cd,
            int _controle_fila_cd,
             string _controle_descricao
            )
        {

            controle_cd = _controle_cd;
            controle_fila_cd = _controle_fila_cd;
            controle_fila_descricao = _controle_descricao;


        }


        public TbControle_Fila(DataRow i)
        {
            controle_cd = Convert.ToInt32(i["controle_cd"]);
            controle_fila_cd = Convert.ToInt32(i["controle_fila_cd"]);
            controle_fila_descricao = i["controle_fila_descricao"].ToString();
        }


    }
}
