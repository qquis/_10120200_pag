using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0135_Trasnporte_Ctrl
{
    public class TbTransporte_Ctrl
    {

        public int      controle_reg_seq                { get; set; }
        public int      tranporte_Ctrl_Seq              {get; set;}
        public int      veiculo_seq                     {get; set;}
        public int      pallet_qtde	                    {get; set;}
        public double   pallet_valor_unitario           { get; set;  }



        public TbTransporte_Ctrl()
        {
            controle_reg_seq            = 0;
            tranporte_Ctrl_Seq     =0;
            veiculo_seq                 =0;
   
            pallet_qtde	                = 0;
            pallet_valor_unitario       = 0;

        }

        public TbTransporte_Ctrl(

            int      _controle_reg_seq         
          ,  int      _Tranporte_Ctrl_Seq  
          ,  int      _veiculo_seq              
     
          ,  int      _pallet_qtde	             
          ,  double   _pallet_valor_unitario     

            )
        {

            controle_reg_seq              =   _controle_reg_seq         ;
            tranporte_Ctrl_Seq       =   _Tranporte_Ctrl_Seq  ;
            veiculo_seq                   =   _veiculo_seq              ;

            pallet_qtde	                  =   _pallet_qtde	            ;
            pallet_valor_unitario           = _pallet_valor_unitario; 

        }


        public TbTransporte_Ctrl(DataRow i)
        {
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());
            tranporte_Ctrl_Seq = Convert.ToInt32(i["Tranporte_Ctrl_Seq"].ToString());
            veiculo_seq = Convert.ToInt32(i["veiculo_seq"].ToString());
            pallet_qtde = Convert.ToInt32(i["pallet_qtde"].ToString());
            pallet_valor_unitario = Convert.ToDouble(i["pallet_valor_unitario"].ToString());
        }


    }
}
