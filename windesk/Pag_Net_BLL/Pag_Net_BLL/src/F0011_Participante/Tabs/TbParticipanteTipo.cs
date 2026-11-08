using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipanteTipo : Pag_Net.Bll.Tb
    {
       
        public int participante_tipo_cd { get; set; }
        public string participante_tipo_descricao { get; set; }

        public TbParticipanteTipo() { _constructor(); }

        public void _constructor()
        {
            participante_tipo_cd = 0;
            participante_tipo_descricao = "INFORME O TIPO DE PARTICIPANTE";
        }
        public override void __Binding(DataRow i)
        {
            try
            {
                _constructor();
                participante_tipo_cd = Convert.ToInt32(i["participante_tipo_cd"].ToString());
                participante_tipo_descricao = i["participante_tipo_descricao"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("TbParticipante_Tipo | Error \n " + ex.Message);
            }

        }



    }
}
