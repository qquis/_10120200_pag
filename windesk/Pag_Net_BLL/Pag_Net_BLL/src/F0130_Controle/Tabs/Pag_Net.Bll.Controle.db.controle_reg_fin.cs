using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class tbcontrole_reg_fin
    {
        public int proc_log_seq { get; set; }
        public int          controle_reg_seq            { get; set; }
        public int          controle_reg_fin_seq        { get; set; }
        public DateTime     controle_reg_fin_data       { get; set; }
        public int          autpgto_seq                 {get; set; }
        public int          fin_tipo_lancamento_cd      {get; set; }
        public int          fin_forma_pgto_cd           { get; set; }
        public string       controle_reg_fin_descritivo {get; set; }
        public double       controle_reg_fin_valor      {get; set; }



        public tbcontrole_reg_fin()
        {
            proc_log_seq = 0;
            controle_reg_seq = 0;
            controle_reg_fin_seq = 0;
            controle_reg_fin_data = DateTime.Now;
            autpgto_seq = 0;
            fin_tipo_lancamento_cd = 1;
            fin_forma_pgto_cd = 1;
            controle_reg_fin_descritivo = "DESCRITIVO NÃO INFORMADO";
            controle_reg_fin_valor = 0.00;


        }
        public tbcontrole_reg_fin(
                int _proc_log_seq,
                int _controle_reg_seq,
                int _controle_reg_fin_seq,
                DateTime _controle_reg_fin_data,
                int _autpgto_seq, 
                int _fin_tipo_lancamento_cd, 
                int _fin_forma_pgto_cd, 
                string _controle_reg_fin_descritivo, 
                double _controle_reg_fin_valor
            )
        {
            proc_log_seq = _proc_log_seq;
            controle_reg_seq = _controle_reg_seq;
            controle_reg_fin_seq = _controle_reg_fin_seq; 
            controle_reg_fin_data = _controle_reg_fin_data;
            autpgto_seq = _autpgto_seq;
            fin_tipo_lancamento_cd = _fin_tipo_lancamento_cd;
            controle_reg_fin_descritivo = _controle_reg_fin_descritivo;
            controle_reg_fin_valor = _controle_reg_fin_valor ;


        }
        public tbcontrole_reg_fin(DataRow i)
        {
            try
            {
                proc_log_seq = Convert.ToInt32(i["proc_log_seq"]);
               controle_reg_seq                 =      Convert.ToInt32(i["controle_reg_seq"].ToString());              
               controle_reg_fin_seq             =      Convert.ToInt32(i["controle_reg_fin_seq"].ToString());           
               controle_reg_fin_data            =      Convert.ToDateTime(i["controle_reg_fin_data"].ToString());          
               autpgto_seq                      =      Convert.ToInt32(i["autpgto_seq"].ToString());                    
               fin_tipo_lancamento_cd           =      Convert.ToInt32(i["fin_tipo_lancamento_cd"].ToString());         
               fin_forma_pgto_cd                =      Convert.ToInt32(i["fin_forma_pgto_cd"].ToString());                   
               controle_reg_fin_descritivo      =      i["controle_reg_fin_descritivo"].ToString();  
      
               
               controle_reg_fin_valor           =     fin_tipo_lancamento_cd == 1 ? -1 * Convert.ToDouble(i["controle_reg_fin_valor"].ToString()): Convert.ToDouble(i["controle_reg_fin_valor"].ToString() );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
