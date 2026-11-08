using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class ModelParticipante_BlueSoft_GRP : TbParticipanteBlueSoft_GRP
    {




        public ModelParticipante_BlueSoft_GRP()
            : base() 
        {
            _Modelconstructor();
        
        }

     
  
     
        public void _Modelconstructor()
        {


            
            base._constructor();

            


        }

       

        public void _Binding_BaseBlueSoft(DataRow i)
        {
            try
            {
                _constructor();
                this.participante_bluesoft_grp_cd = Convert.ToInt32(i["participante_bluesoft_grp_cd"].ToString());
                this.cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"].ToString());
                this.cdpessoabluesoft_vendedor = Convert.ToInt32(i["cdpessoabluesoft_vendedor"].ToString());
                this.cdpessoabluesoft_cliente = Convert.ToInt32(i["cdpessoabluesoft_cliente"].ToString());
                this.participante_bluesoft_grp_desc_fin = Convert.ToDouble(i["participante_bluesoft_grp_desc_fin"].ToString());
                this.participante_bluesoft_grp_comissao = Convert.ToDouble(i["participante_bluesoft_grp_comissao"].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("_DataBinding_BaseBlueSoft | Erro \n " + ex.Message);
            }
        }



    

    }
}

