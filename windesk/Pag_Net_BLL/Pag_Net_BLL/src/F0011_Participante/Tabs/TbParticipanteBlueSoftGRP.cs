using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipanteBlueSoft_GRP : Pag_Net.Bll.Tb
    {
        public int participante_bluesoft_grp_seq { get; set; }	
        public int participante_bluesoft_grp_cd { get; set; }		
        public int cdgrupoeconomico	 { get; set; }		
        public int cdpessoabluesoft_vendedor { get; set; }
        public int cdpessoabluesoft_cliente { get; set; }  		
        public double participante_bluesoft_grp_desc_fin { get; set; }	
        public double participante_bluesoft_grp_comissao { get; set; }	

        public TbParticipanteBlueSoft_GRP() 
        {
            _constructor();
        
        }
        public TbParticipanteBlueSoft_GRP(DataRow i)
        {
            try
            {
                _constructor();
                __Binding(i);
            }
            catch (Exception ex )
            {
                throw new Exception("Pag_Net.Bll.F0011_Participante.TbPessoBluesoft: " + ex.Message);
            }
        }

        public void _constructor()
        {
            participante_bluesoft_grp_seq = 0;
            participante_bluesoft_grp_cd = 0;
            cdgrupoeconomico = 0;
            cdpessoabluesoft_vendedor = 0;
            cdpessoabluesoft_cliente = 0;
            participante_bluesoft_grp_desc_fin = 0;
            participante_bluesoft_grp_comissao = 0;


        }
        public override void __Binding(DataRow i)
        {
            try
            {
                this.participante_bluesoft_grp_seq = Convert.ToInt32(i["participante_bluesoft_grp_seq"].ToString());
                this.participante_bluesoft_grp_cd = Convert.ToInt32(i["participante_bluesoft_grp_cd"].ToString());
                this.cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"].ToString());
                this.cdpessoabluesoft_vendedor = Convert.ToInt32(i["cdpessoabluesoft_vendedor"].ToString());
                this.cdpessoabluesoft_cliente = Convert.ToInt32(i["cdpessoabluesoft_cliente"].ToString());
                this.participante_bluesoft_grp_desc_fin = Convert.ToDouble(i["participante_bluesoft_grp_desc_fin"].ToString());
                this.participante_bluesoft_grp_comissao = Convert.ToDouble(i["participante_bluesoft_grp_comissao"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


    }
}
