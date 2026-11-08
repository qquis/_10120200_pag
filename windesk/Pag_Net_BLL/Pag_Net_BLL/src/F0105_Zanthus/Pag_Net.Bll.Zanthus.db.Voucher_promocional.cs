using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0105_Zanthus
{
    public class tbzanthus_voucher_promocional
    {

	        public string   cod_voucher 	{get;set;}
            public string   descricao       { get; set; }
            public DateTime data_voucher    { get; set; }
            public DateTime data_validade_inicial { get; set; }
            public DateTime data_validade_final { get; set; }
            
            
        public tbzanthus_voucher_promocional() 
        {
            cod_voucher = "0";
            descricao   = ""; 
            data_voucher  = DateTime.Now;
            data_validade_inicial = DateTime.Now;
            data_validade_final = DateTime.Now;


        }
        public tbzanthus_voucher_promocional(
            string   _cod_voucher, 	
            string   _descricao   ,    
            DateTime _data_voucher    
            ) 
        {
            cod_voucher = _cod_voucher;
            descricao = _descricao;
            data_voucher = _data_voucher;
            data_validade_inicial = DateTime.Now;
            data_validade_final = DateTime.Now;
            
        }

        public tbzanthus_voucher_promocional(DataRow i)
        {
            cod_voucher = i["cod_voucher"].ToString();
            descricao = i["descricao"].ToString();
            data_voucher = Convert.ToDateTime(i["data_voucher"].ToString());
            data_validade_inicial = Convert.ToDateTime(i["data_validade_inicial"].ToString());
            data_validade_final = Convert.ToDateTime(i["data_validade_final"].ToString());
        }
    }
}

