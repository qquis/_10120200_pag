using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0050_Faturamento_BlueSoft.tbs
{
    public class tbfaturamento_bluesoft_origem : Pag_Net.Bll.Tb
    {
        public int op_cdoperacao	{get; set;}					
        public int fat_blue_origem_seq {get; set;}
		public int numeropedido {get; set;}			 				
		public int numeropedido_fv {get; set;}
		public int df_nf_seq_blue	{get; set;}		
		public int df_nf_seq_blue_dev	{get; set;}

        public tbfaturamento_bluesoft_origem()
        {
            _constructor();
        }

        public void _constructor()
        {
            this.op_cdoperacao = 0;
            this.fat_blue_origem_seq = 0;
            this.numeropedido = 0;
            this.numeropedido_fv = 0;
            this.df_nf_seq_blue = 0;
            this.df_nf_seq_blue_dev = 0;
        }

        public void binding(DataRow i)
        {
            try
            {
                this.op_cdoperacao = Convert.ToInt32(i["op_cdoperacao"].ToString());
                this.fat_blue_origem_seq = Convert.ToInt32(i["fat_blue_origem_seq"].ToString());
                this.numeropedido = Convert.ToInt32(i["numeropedido"].ToString());
                this.numeropedido_fv = Convert.ToInt32(i["numeropedido_fv"].ToString());
                this.df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
                this.df_nf_seq_blue_dev = Convert.ToInt32(i["df_nf_seq_blue_dev"].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
