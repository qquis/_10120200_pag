using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipanteEnderecoTipo : Pag_Net.Bll.Tb
    {

        public int endereco_tipo_cd { get; set; }
        public string endereco_tipo_descricao { get; set; }

        public TbParticipanteEnderecoTipo() { _constructor(); }

        public void _constructor()
        {
            endereco_tipo_cd = 0;
            endereco_tipo_descricao = "INFORME O TIPO DE PARTICIPANTE";
        }
        public override void __Binding(DataRow i)
        {
            try
            {
                _constructor();
                endereco_tipo_cd = Convert.ToInt32(i["participante_tipo_cd"].ToString());
                endereco_tipo_descricao = i["participante_tipo_descricao"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("TbParticipante_Tipo | Error \n " + ex.Message);
            }

        }


 
    }
}
