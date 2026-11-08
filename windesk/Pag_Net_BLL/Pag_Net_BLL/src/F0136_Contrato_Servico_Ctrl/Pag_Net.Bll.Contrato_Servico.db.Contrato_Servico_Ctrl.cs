using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0136_Contrato_Servico
{
    public class TbContrato_Servico_Ctrl
    {
        public Pag_Net.Bll.F0130_Controle.model_controle_reg CONTROLE_REG;
        public Pag_Net.Bll.F0136_Contrato_Servico.model_Contrato_Servico CONTRATO_SERVICO;

        
		public int 	        contrato_servico_ctrl_seq 			{get; set;}
		public int      	contrato_servico_seq				
        {
            get
            {
                return CONTRATO_SERVICO.contrato_servico_seq;
            }
        
        }
		public int 	        controle_reg_seq 					
        {
            get
            {
                return this.CONTROLE_REG.controle_reg_seq;
            }
            
        }
		public DateTime 	contrato_servico_ctrl_data			{get; set;}
		public string 	    contrato_servico_ctrl_descritivo	{get; set;}
        public string       contrato_servico_ctrl_observacao    { get; set; }

            public TbContrato_Servico_Ctrl() 
            {
                this.CONTROLE_REG = new F0130_Controle.model_controle_reg(15);
                this.CONTRATO_SERVICO = new model_Contrato_Servico();


                contrato_servico_ctrl_seq = 0;	
                contrato_servico_ctrl_data = DateTime.Now;
                contrato_servico_ctrl_descritivo = "EXECUÇÃO DE SERVIÇO";
                contrato_servico_ctrl_observacao = "";
            
            }
            public TbContrato_Servico_Ctrl(DataRow i)
            {

                this.CONTROLE_REG = new F0130_Controle.model_controle_reg(15);
                this.CONTRATO_SERVICO = new model_Contrato_Servico();

                CONTROLE_REG.controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());
                CONTRATO_SERVICO.contrato_servico_seq = Convert.ToInt32(i["contrato_servico_seq"].ToString());

                contrato_servico_ctrl_seq = Convert.ToInt32(i["contrato_servico_ctrl_seq"].ToString());
                contrato_servico_ctrl_data = Convert.ToDateTime(i["contrato_servico_ctrl_data"].ToString());
                contrato_servico_ctrl_descritivo = i["contrato_servico_ctrl_descritivo"].ToString();
                contrato_servico_ctrl_observacao = i["contrato_servico_ctrl_observacao"].ToString();

            }


    }
}
