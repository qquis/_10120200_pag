using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle_Reg_Transporte 
    {

        public int      controle_reg_seq             { get; set; }
        public int      controle_reg_transp_seq      {get; set;}
        public int      veiculo_seq                  {get; set;}
        public int      pallet_qtde	                {get; set;}
        public double   pallet_valor_unitario     { get; set;  }



        public TbControle_Reg_Transporte()
        {
            controle_reg_seq            = 0;
            controle_reg_transp_seq     =0;
            veiculo_seq                 =0;
   
            pallet_qtde	                = 0;
            pallet_valor_unitario       = 0;

        }

        public TbControle_Reg_Transporte(

            int      _controle_reg_seq         
          ,  int      _controle_reg_transp_seq  
          ,  int      _veiculo_seq              
     
          ,  int      _pallet_qtde	             
          ,  double   _pallet_valor_unitario     

            )
        {

            controle_reg_seq              =   _controle_reg_seq         ;
            controle_reg_transp_seq       =   _controle_reg_transp_seq  ;
            veiculo_seq                   =   _veiculo_seq              ;

            pallet_qtde	                  =   _pallet_qtde	            ;
            pallet_valor_unitario           = _pallet_valor_unitario; 

        }


        public TbControle_Reg_Transporte(DataRow i)
        {



            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());
            controle_reg_transp_seq = Convert.ToInt32(i["controle_reg_transp_seq"].ToString());
            veiculo_seq = Convert.ToInt32(i["veiculo_seq"].ToString());

            pallet_qtde = Convert.ToInt32(i["pallet_qtde"].ToString());
            pallet_valor_unitario = Convert.ToDouble(i["pallet_valor_unitario"].ToString());




        }


    }
}
