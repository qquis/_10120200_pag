using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipante_GrupoEconomico
    {

        public int cdgrupoeconomico { get; set; }
        public string descricao { get; set; }

        public TbParticipante_GrupoEconomico() { _constructor(); }


        public void _DataBinding(DataRow i)
        {
            try
            {
                _constructor();
                cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"].ToString());
                descricao = i["descricao"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("TbParticipante_GrupoEconomico | Error \n " + ex.Message);
            }

        }


        public void _constructor()
        {
            cdgrupoeconomico = 0;
            descricao = "";  
       }

    }
}
