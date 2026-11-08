using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0105_Zanthus
{
    public class tbzanthus_voucher_promocional_cli
    {

	        public string   cod_voucher 	{get;set;}
            public DateTime data_voucher    { get; set; }
	        public string   cliente 	{get;set;}
            
        public tbzanthus_voucher_promocional_cli() 
        {
            cod_voucher = "0";
            data_voucher  = DateTime.Now;
        }
        public tbzanthus_voucher_promocional_cli(
            string   _cod_voucher, 	
            string   _cliente   ,    
            DateTime _data_voucher    
            ) 
        {
            cod_voucher = _cod_voucher;
            cliente = _cliente;
            data_voucher = _data_voucher;
        }

        public tbzanthus_voucher_promocional_cli(DataRow i)
        {
            cod_voucher = i["cod_voucher"].ToString();
            data_voucher = Convert.ToDateTime(i["data_voucher"].ToString());
            cliente = i["cliente"].ToString();

        }
    }
}

