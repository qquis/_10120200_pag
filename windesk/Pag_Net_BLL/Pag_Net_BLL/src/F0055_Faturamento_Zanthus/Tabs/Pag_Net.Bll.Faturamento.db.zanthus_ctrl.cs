using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0055_Faturamento_Zanthus
{
    public class tbfaturamentozanthus_ctrl
    {
            public DateTime     fat_zanthus_data_m00af                          { get; set; }
	        public int          fat_zanthus_sat_ecf_m00ac 			            { get;set;}
            public int          fz_cupom_qtde                                   { get; set;  }
            public int          fz_cupom_inicial                                { get; set; }
            public int          fz_cupom_final                                  { get; set; }
            public double       fz_valor { get; set; }
            public int          fz_pag_cupom_qtde                               { get; set; }
            public int          fz_pag_cupom_inicial                            { get; set; }
            public int          fz_pag_cupom_final                              { get; set; }
            public double       fz_pag_valor                                  { get; set; }
            public int          fat_cupom_qtde                                  { get; set;  }
            public int          fat_cupom_inicial                               { get; set; }
            public int          fat_cupom_final                                 { get; set; }
            public double       fat_cupom_valor                                 { get; set; }
            
            
        public tbfaturamentozanthus_ctrl() 
        {
              fat_zanthus_data_m00af                    =        DateTime.Now;
              fat_zanthus_sat_ecf_m00ac 			    = 0 ;
              fz_cupom_qtde                             = 0;       
              fz_cupom_inicial                          = 0;  
              fz_cupom_final                            = 0;  
              fz_valor                            = 0;  
              fz_pag_cupom_qtde                         = 0;  
              fz_pag_cupom_inicial                      = 0;  
              fz_pag_cupom_final                        = 0;  
              fz_pag_valor                        = 0;  


        }

        public tbfaturamentozanthus_ctrl(DataRow i)
        {

            fat_zanthus_data_m00af = Convert.ToDateTime(i["fat_zanthus_data_m00af"].ToString());
            fat_zanthus_sat_ecf_m00ac = Convert.ToInt32(i["fat_zanthus_sat_ecf_m00ac"].ToString());
            fz_cupom_qtde = Convert.ToInt32(i["fz_cupom_qtde"].ToString());
            fz_cupom_inicial = Convert.ToInt32(i["fz_cupom_inicial"].ToString());
            fz_cupom_final = Convert.ToInt32(i["fz_cupom_final"].ToString());
            fz_valor = Convert.ToDouble(i["fz_valor"].ToString());
            fz_pag_cupom_qtde = Convert.ToInt32(i["fz_pag_cupom_qtde"].ToString());
            fz_pag_cupom_inicial = Convert.ToInt32(i["fz_pag_cupom_inicial"].ToString());
            fz_pag_cupom_final = Convert.ToInt32(i["fz_pag_cupom_final"].ToString());
            fz_pag_valor = Convert.ToDouble(i["fz_pag_valor"].ToString());
            fat_cupom_qtde   = Convert.ToInt32(i["fat_cupom_qtde"].ToString());     
            fat_cupom_inicial    = Convert.ToInt32(i["fat_cupom_inicial"].ToString());     
            fat_cupom_final    = Convert.ToInt32(i["fat_cupom_final"].ToString());
            fat_cupom_valor = Convert.ToDouble(i["fat_cupom_valor"].ToString());              

        }

        public void _ToCheck(Pag_Net.Models.modelSistemaUsuario _MyConnect) 
        {
            try
            {
                string sqlCheck = "Select * from f0055_10_1011998_faturamentozanthus_ctrl( " +
                            "   sqlcommand:= 'TOCHECK' " +
                            ",	vfat_zanthus_sat_ecf_m00ac:= " + this.fat_zanthus_sat_ecf_m00ac.ToString() +
                            ",	vfat_zanthus_data_m00af:= '" + this.fat_zanthus_data_m00af.ToString("yyyy-MM-dd") + "'" +
                            ",	vfz_cupom_qtde:= " + this.fz_cupom_qtde.ToString() +
                            ",	vfz_cupom_inicial:=	" + this.fz_cupom_inicial.ToString() +
                            ",	vfz_cupom_final:= " + this.fz_cupom_final.ToString() +
                            ",	vfz_valor:= " + this.fz_valor.ToString("0.00").Replace(",", ".") +
                            ",	vfz_pag_cupom_qtde:= " + this.fz_pag_cupom_qtde.ToString() +
                            ",	vfz_pag_cupom_inicial:=	" + this.fz_pag_cupom_inicial.ToString() +
                            ",	vfz_pag_cupom_final:= " + this.fz_pag_cupom_final.ToString() +
                            ",	vfz_pag_valor:= " + this.fz_pag_valor.ToString("0.00").Replace(",", ".") + ")";
                DataTable DT_ECF_CTRL = BDCommand.get_DataTable(_MyConnect, sqlCheck);
                
                this.fz_pag_cupom_qtde = Convert.ToInt32(DT_ECF_CTRL.Rows[0]["fz_pag_cupom_qtde"].ToString());
                this.fz_pag_cupom_inicial = Convert.ToInt32(DT_ECF_CTRL.Rows[0]["fz_pag_cupom_inicial"].ToString());
                this.fz_pag_cupom_final = Convert.ToInt32(DT_ECF_CTRL.Rows[0]["fz_pag_cupom_final"].ToString());
                this.fz_pag_valor = Convert.ToDouble(DT_ECF_CTRL.Rows[0]["fz_pag_valor"].ToString());
                this.fat_cupom_qtde = Convert.ToInt32(DT_ECF_CTRL.Rows[0]["fat_cupom_qtde"].ToString());
                this.fat_cupom_inicial = Convert.ToInt32(DT_ECF_CTRL.Rows[0]["fat_cupom_inicial"].ToString());
                this.fat_cupom_final = Convert.ToInt32(DT_ECF_CTRL.Rows[0]["fat_cupom_final"].ToString());
                this.fat_cupom_valor = Convert.ToDouble(DT_ECF_CTRL.Rows[0]["fat_cupom_valor"].ToString());  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        
        
        }

    
    }
}
