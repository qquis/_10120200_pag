using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0055_Faturamento_Zanthus
{
    public class tbfaturamentozanthusitem
    {
        public int      fat_zanthus_seq                              { get; set; }
        public DateTime fat_zanthus_data_m00af                  { get; set; }
        public int      fat_zanthus_sat_ecf_m00ac                    { get; set; }
        public int      fat_zanthus_cupomfiscal_m00ad                { get; set; }
        public Double   fat_zanthus_item_seq_m43eg 	            {get;set;}
        public string   fat_zanthus_item_cdbarra_m43ah		    {get;set;}
        public string   fat_zanthus_item_cdbarra_M43BK_m43ah	    {get;set;}
        public Double   fat_zanthus_item_qtde_m43ao			    {get;set;}
        public Double   fat_zanthus_item_valor_m43ap			    {get;set;}
        public string   fat_zanthus_M43BK 					    {get;set;}
        public string   fat_zanthus_M43AH						    {get;set;}
        public Double   fat_zanthus_Decomp_Insumo				    {get;set;}
        public Double   fat_zanthus_val_liquido                   { get; set; }
        public Double   fat_zanthus_item_valor_desconto_m43aq     { get; set;  }


        public tbfaturamentozanthusitem()
        {
            fat_zanthus_seq = 0;
            fat_zanthus_data_m00af = DateTime.Now;
            fat_zanthus_sat_ecf_m00ac = 0;
            fat_zanthus_cupomfiscal_m00ad = 0;

            fat_zanthus_item_seq_m43eg 	= 0;
            fat_zanthus_item_cdbarra_m43ah		    = "0";
            fat_zanthus_item_cdbarra_M43BK_m43ah	= "0";
            fat_zanthus_item_qtde_m43ao			    = 0;
            fat_zanthus_item_valor_m43ap			= 0;
            fat_zanthus_M43BK 					    = "0";
            fat_zanthus_M43AH						= "0";
            fat_zanthus_Decomp_Insumo				= 0;
            fat_zanthus_val_liquido                 = 0;



        }
        public tbfaturamentozanthusitem(



               int _fat_zanthus_seq
            , DateTime _fat_zanthus_data
            , int _fat_zanthus_sat_ecf_m00ac
            , int _fat_zanthus_cupomfiscal_m00ad

            , Double _fat_zanthus_item_cupomfiscal_seqitem 	
            , string _fat_zanthus_item_cdbarra_m43ah		
            , string _fat_zanthus_item_cdbarra_M43BK_m43ah	
            , Double _fat_zanthus_item_qtde_m43ao			
            , Double _fat_zanthus_item_valor_m34ap			
            , string _fat_zanthus_M43BK 					
            , string _fat_zanthus_M43AH						
            , Double _fat_zanthus_Decomp_Insumo				
            , Double _fat_zanthus_val_liquido               





            )
        {

            fat_zanthus_seq = _fat_zanthus_seq;
            fat_zanthus_data_m00af = _fat_zanthus_data;
            fat_zanthus_sat_ecf_m00ac = _fat_zanthus_sat_ecf_m00ac;
            fat_zanthus_cupomfiscal_m00ad = _fat_zanthus_cupomfiscal_m00ad;


            fat_zanthus_item_seq_m43eg 	=       _fat_zanthus_item_cupomfiscal_seqitem   ;
            fat_zanthus_item_cdbarra_m43ah		    =       _fat_zanthus_item_cdbarra_m43ah		    ;
            fat_zanthus_item_cdbarra_M43BK_m43ah	=       _fat_zanthus_item_cdbarra_M43BK_m43ah   ;
            fat_zanthus_item_qtde_m43ao			    =       _fat_zanthus_item_qtde_m43ao			;
            fat_zanthus_item_valor_m43ap			=       _fat_zanthus_item_valor_m34ap		    ;
            fat_zanthus_M43BK 					    =       _fat_zanthus_M43BK 					    ;
            fat_zanthus_M43AH						=       _fat_zanthus_M43AH					    ;
            fat_zanthus_Decomp_Insumo				=       _fat_zanthus_Decomp_Insumo			    ;
            fat_zanthus_val_liquido                 = _fat_zanthus_val_liquido;



        }

        public tbfaturamentozanthusitem(DataRow i)
        {
            fat_zanthus_seq = Convert.ToInt32(i["fat_zanthus_seq"].ToString());
            fat_zanthus_data_m00af = Convert.ToDateTime(i["fat_zanthus_data"].ToString());
            fat_zanthus_sat_ecf_m00ac = Convert.ToInt32(i["fat_zanthus_sat_ecf_m00ac"].ToString());
            fat_zanthus_cupomfiscal_m00ad = Convert.ToInt32(i["fat_zanthus_cupomfiscal_m00ad"].ToString());
            fat_zanthus_item_seq_m43eg = Convert.ToDouble(i["fat_zanthus_item_cupomfiscal_seqitem"].ToString());
            fat_zanthus_item_cdbarra_m43ah = i["fat_zanthus_item_cdbarra_m43ah"].ToString();
            fat_zanthus_item_cdbarra_M43BK_m43ah = i["fat_zanthus_item_cdbarra_M43BK_m43ah"].ToString();
            fat_zanthus_item_qtde_m43ao = Convert.ToDouble(i["fat_zanthus_item_qtde_m43ao"].ToString());
            fat_zanthus_item_valor_m43ap = Convert.ToDouble(i["fat_zanthus_item_valor_m43ap"].ToString());
            //fat_zanthus_M43BK = i["fat_zanthus_M43BK"].ToString();
            fat_zanthus_M43AH = i["fat_zanthus_M43AH"].ToString();
            fat_zanthus_Decomp_Insumo = Convert.ToDouble(i["fat_zanthus_Decomp_Insumo"].ToString());
            fat_zanthus_val_liquido = Convert.ToDouble(i["fat_zanthus_val_liquido"].ToString());
        }
    }
}
