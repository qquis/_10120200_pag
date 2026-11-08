using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipanteContatoTipo : Pag_Net.Bll.Tb
    {

        public int contato_tipo_cd { get; set; }
        public string contato_tipo_descricao { get; set; }

        public TbParticipanteContatoTipo() { _constructor(); }

        public void _constructor()
        {
            contato_tipo_cd = 0;
            contato_tipo_descricao = "INFORME O TIPO DE PARTICIPANTE";
        }
        public override void __Binding(DataRow i)
        {
            try
            {
                _constructor();
                contato_tipo_cd = Convert.ToInt32(i["participante_tipo_cd"].ToString());
                contato_tipo_descricao = i["participante_tipo_descricao"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("TbParticipante_Tipo | Error \n " + ex.Message);
            }

        }


 
    }
}
