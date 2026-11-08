using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle_reg_etapa
    {

        public int      controle_reg_seq            { get; set; }
        public int      controle_reg_fila_seq       { get; set; }
        public int      controle_reg_etapa_seq      { get; set; }
        public DateTime controle_reg_etapa_data { get; set;  }
        public int      controle_etapa_cd           { get; set; }
        //public string   controle_etapa_descricao    { get; set;  }
        public int      controle_etapa_em_execucao  { get; set;  }
        public DateTime controle_etapa_inicio        { get; set;  }
        public DateTime controle_etapa_fim          { get; set; }
        public int      proc_log_seq                {get;set;}
        public string   user_name                   { get; set;  }
        public TbControle_reg_etapa()
        {
            
            controle_reg_seq = 0; 
            controle_reg_fila_seq = 0;      
            controle_reg_etapa_seq = 0;
            controle_reg_etapa_data = DateTime.Now;
            controle_etapa_cd = 0; 
            //controle_etapa_descricao = "";  
            controle_etapa_em_execucao = 0;
            controle_etapa_inicio = Convert.ToDateTime("1900-01-01 01:01:01");
            controle_etapa_fim = Convert.ToDateTime("1900-01-01 01:01:01");
            proc_log_seq = 0;
            user_name = "";                
        }

        public TbControle_reg_etapa(

            int      _controle_reg_seq                  ,
            int      _controle_reg_fila_seq             ,
            int      _controle_reg_etapa_seq            ,
            DateTime _controle_reg_etapa_data , 
            int      _controle_etapa_cd                 ,
            string   _controle_etapa_descricao          ,
            int      _controle_etapa_em_execucao        ,
            DateTime _controle_etapa_inicio             ,
            DateTime _controle_etapa_fim                ,
            string   _user_name                  
            )
        {
            controle_reg_seq            = _controle_reg_seq             ;
            controle_reg_fila_seq       = _controle_reg_fila_seq        ;
            controle_reg_etapa_seq      = _controle_reg_etapa_seq       ;
            controle_reg_etapa_data = _controle_reg_etapa_data;
            controle_etapa_cd           = _controle_etapa_cd            ;
            //controle_etapa_descricao    = _controle_etapa_descricao     ;
            controle_etapa_em_execucao  = _controle_etapa_em_execucao   ;
            controle_etapa_inicio       = _controle_etapa_inicio        ;
            controle_etapa_fim          = _controle_etapa_fim           ;
            user_name = _user_name;
        }

        public TbControle_reg_etapa(DataRow i)
        {
            controle_reg_seq            = Convert.ToInt32(i["controle_reg_seq"]);
            controle_reg_fila_seq       = Convert.ToInt32(i["controle_reg_fila_seq"]);
            controle_reg_etapa_data = Convert.ToDateTime(i["controle_reg_etapa_data"].ToString());
            controle_reg_etapa_seq      = Convert.ToInt32(i["controle_reg_etapa_seq"]);
            controle_etapa_cd           = Convert.ToInt32(i["controle_etapa_cd"]);
            controle_etapa_em_execucao = Convert.ToInt32(i["controle_etapa_em_execucao"]);
            controle_etapa_inicio = Convert.ToDateTime(i["controle_etapa_inicio"].ToString());
            controle_etapa_fim = Convert.ToDateTime(i["controle_etapa_fim"].ToString());
            proc_log_seq = Convert.ToInt32(i["proc_log_seq"].ToString());
        }


    }
}
