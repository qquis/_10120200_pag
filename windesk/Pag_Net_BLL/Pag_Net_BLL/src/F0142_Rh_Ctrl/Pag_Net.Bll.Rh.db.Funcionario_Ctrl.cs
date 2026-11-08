using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh
{
    public class TbRhFuncionarioCtrl
    {
        public Pag_Net.Bll.F0130_Controle.model_controle_reg CONTROLE_REG;
		public int      rh_funcionario_ctrl_seq		{get; set; }
		public DateTime rh_funcionario_ctrl_data    {get; set; }
		public int      rh_funcionario_ctrl_tipo	{get; set; }
		public int      rh_funcionario_cd			{get; set; }
		public int      controle_reg_seq			{get; set; }
        public TbRhFuncionarioCtrl() 
        {
            rh_funcionario_ctrl_seq		= 0;
            rh_funcionario_ctrl_data    = DateTime.Now;
            rh_funcionario_ctrl_tipo	= 0;
            rh_funcionario_cd			= 0;
            controle_reg_seq			= 0;
            CONTROLE_REG = new F0130_Controle.model_controle_reg(15);
        }
        public TbRhFuncionarioCtrl(
            int      _rh_funcionario_ctrl_seq		,
            DateTime _rh_funcionario_ctrl_data       ,
            int      _rh_funcionario_ctrl_tipo	    ,
            int      _rh_funcionario_cd			    ,
            int      _controle_reg_seq			
            
            ) 
        {
            CONTROLE_REG = new F0130_Controle.model_controle_reg(15);
            rh_funcionario_ctrl_seq	     =       _rh_funcionario_ctrl_seq	;
            rh_funcionario_ctrl_data     =       _rh_funcionario_ctrl_data  ;
            rh_funcionario_ctrl_tipo     =       _rh_funcionario_ctrl_tipo	;
            rh_funcionario_cd		     =       _rh_funcionario_cd			;
            controle_reg_seq		     =       _controle_reg_seq			;
        }

        public TbRhFuncionarioCtrl(DataRow i)
        {
            CONTROLE_REG = new F0130_Controle.model_controle_reg(15);
            rh_funcionario_ctrl_seq = Convert.ToInt32(i["rh_funcionario_ctrl_seq"].ToString());
            rh_funcionario_ctrl_data = Convert.ToDateTime(i["rh_funcionario_ctrl_data"].ToString());
            rh_funcionario_ctrl_tipo = Convert.ToInt32(i["rh_funcionario_ctrl_tipo"].ToString());
            rh_funcionario_cd = Convert.ToInt32(i["rh_funcionario_cd"].ToString());
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());
        }

    }



}
