using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle_Reg_Fila
    {
        public int controle_reg_fila_seq { get; set; }
        public int controle_reg_seq { get; set; }
        public int controle_fila_cd { get; set; }
        public string controle_fila_descricao { get; set; }
        public TbControle_Reg_Fila() 
        {

            controle_reg_fila_seq = 0;
            controle_reg_seq = 0;
            controle_fila_cd = 0;
            controle_fila_descricao = "";
        
        }

        public TbControle_Reg_Fila(TbControle_Fila _nova_Fila)
        {

            controle_reg_fila_seq = 0;
            controle_reg_seq = 0;
            controle_fila_cd = _nova_Fila.controle_fila_cd;
            controle_fila_descricao = _nova_Fila.controle_fila_descricao;

        }

        public TbControle_Reg_Fila(
            int _controle_reg_fila_seq,
            int _controle_reg_seq,
            int _controle_fila_cd,
            string _controle_fila_descricao
            )
        {
            controle_reg_fila_seq = _controle_reg_fila_seq;
            controle_reg_seq = _controle_reg_seq;
            controle_fila_cd = _controle_fila_cd;
            controle_fila_descricao = _controle_fila_descricao;
        }
        public TbControle_Reg_Fila(DataRow i)
        {
            controle_reg_fila_seq = Convert.ToInt32(i["controle_reg_fila_seq"].ToString());
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());
            controle_fila_cd = Convert.ToInt32(i["controle_fila_cd"].ToString());
            controle_fila_descricao = i["controle_fila_descricao"].ToString();
        }
    }
}
