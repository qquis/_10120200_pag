using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh
{
    public class rh_funcionario_ctrl
    {
    
		public int      rh_funcionario_ctrl_seq		{get; set; }
		public DateTime rh_funcionario_ctrl_data    {get; set; }
		public int      rh_funcionario_ctrl_tipo	{get; set; }
		public int      rh_funcionario_cd			{get; set; }
		public int      controle_reg_seq			{get; set; }
        public rh_funcionario_ctrl() 
        {
            rh_funcionario_ctrl_seq		= 0;
            rh_funcionario_ctrl_data    = DateTime.Now;
            rh_funcionario_ctrl_tipo	= 0;
            rh_funcionario_cd			= 0;
            controle_reg_seq			= 0;
        }
        public rh_funcionario_ctrl(
            int      _rh_funcionario_ctrl_seq		,
            DateTime _rh_funcionario_ctrl_data       ,
            int      _rh_funcionario_ctrl_tipo	    ,
            int      _rh_funcionario_cd			    ,
            int      _controle_reg_seq			
            
            ) 
        {
            rh_funcionario_ctrl_seq	     =       _rh_funcionario_ctrl_seq	;
            rh_funcionario_ctrl_data     =       _rh_funcionario_ctrl_data  ;
            rh_funcionario_ctrl_tipo     =       _rh_funcionario_ctrl_tipo	;
            rh_funcionario_cd		     =       _rh_funcionario_cd			;
            controle_reg_seq		     =       _controle_reg_seq			;
        }

        public rh_funcionario_ctrl(DataRow i)
        {
            rh_funcionario_ctrl_seq = Convert.ToInt32(i["rh_funcionario_ctrl_seq"].ToString());
            rh_funcionario_ctrl_data = Convert.ToDateTime(i["rh_funcionario_ctrl_data"].ToString());
            rh_funcionario_ctrl_tipo = Convert.ToInt32(i["rh_funcionario_ctrl_tipo"].ToString());
            rh_funcionario_cd = Convert.ToInt32(i["rh_funcionario_cd"].ToString());
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());
        }

    }


    public class rh_funcionario_ctrl_list : rh_funcionario_ctrl
    {

        public string   rh_funcionario_ctrl_tipo_descricao  { get; set; }
        public string   rh_funcionario_nome                 {  get; set;  }
        public int      controle_etapa_cd                   { get; set;  }
        public string   controle_fila_descricao             { get; set; }
        public string   controle_etapa_descricao            { get; set; }
        public int      controle_reg_fila_seq               { get; set;  }
        public int controle_status_cd { get; set; }
        public string controle_status_descricao { get; set;  }
        public rh_funcionario_ctrl Rh_funcionario_ctrl
        {
            get
            {
                return new rh_funcionario_ctrl(rh_funcionario_ctrl_seq, rh_funcionario_ctrl_data, rh_funcionario_ctrl_tipo, rh_funcionario_cd, controle_reg_seq);
            }
        }


        public rh_funcionario_ctrl_list()
        {
            rh_funcionario_ctrl_seq = 0;
            rh_funcionario_ctrl_data = DateTime.Now;
            rh_funcionario_ctrl_tipo = 0;
            rh_funcionario_cd = 0;
            controle_reg_seq = 0;
        }


        public rh_funcionario_ctrl_list(DataRow i)
        {

            rh_funcionario_ctrl_seq = Convert.ToInt32(i["rh_funcionario_ctrl_seq"].ToString());
            rh_funcionario_ctrl_data = Convert.ToDateTime(i["rh_funcionario_ctrl_data"].ToString());
            rh_funcionario_ctrl_tipo = Convert.ToInt32(i["rh_funcionario_ctrl_tipo"].ToString());
            rh_funcionario_cd = Convert.ToInt32(i["rh_funcionario_cd"].ToString());
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());

            rh_funcionario_ctrl_tipo_descricao = i["rh_funcionario_ctrl_tipo_descricao"].ToString();
            rh_funcionario_nome = i["rh_funcionario_nome"].ToString();
            controle_etapa_cd = Convert.ToInt32(i["controle_etapa_cd"].ToString());
            controle_fila_descricao = i["controle_fila_descricao"].ToString();
            controle_etapa_descricao = i["controle_etapa_descricao"].ToString();
            controle_reg_fila_seq = Convert.ToInt32(i["controle_reg_fila_seq"].ToString());

            this.controle_status_cd = Convert.ToInt32(i["controle_status_cd"].ToString());
            this.controle_status_descricao = i["controle_status_descricao"].ToString();

        }

    }

}
