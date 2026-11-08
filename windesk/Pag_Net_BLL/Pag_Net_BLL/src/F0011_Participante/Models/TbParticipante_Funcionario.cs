using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{/*
    public class ModelParticipanteFuncionario 
    {

            public int          operacao_setor_cd               {get; set;}
            public int          rh_funcionario_cd_dg            {get; set; }
            public int          rh_setor_operacional_cd         {get; set; }
            public int          rh_funcionario_status_cd        {get; set; }
            public int          rh_funcionario_tipo_contrato_cd	{get; set; }
            public DateTime     rh_data_admissao                {get; set; }

        public ModelParticipanteFuncionario() { _start(); }

        public ModelParticipanteFuncionario(DataRow i)
        {
            try
            {
                _start();
                operacao_setor_cd                   = Convert.ToInt32(i["operacao_setor_cd"].ToString());        
                rh_funcionario_cd_dg                = Convert.ToInt32(i["rh_funcionario_cd_dg"].ToString());      
                rh_setor_operacional_cd             = Convert.ToInt32(i["rh_setor_operacional_cd"].ToString());   
                rh_funcionario_status_cd            = Convert.ToInt32(i["rh_funcionario_status_cd"].ToString());   
                rh_funcionario_tipo_contrato_cd     = Convert.ToInt32(i["rh_funcionario_tipo_contrato_cd"].ToString());
                rh_data_admissao                    =  Convert.ToDateTime(i["rh_data_admissao"].ToString());
           
            }
            catch (Exception ex )
            {
                throw new Exception("Pag_Net.Bll.F0011_Participante | RH FUNCIONARIO: " + ex.Message);
            }

        }


        public  void _start()
        {

            operacao_setor_cd = 0;
            rh_funcionario_cd_dg = 0;       
            rh_setor_operacional_cd =0;       
            rh_funcionario_status_cd  =0;     
            rh_funcionario_tipo_contrato_cd = 0;
            rh_data_admissao = DateTime.Now;              

        }

    }
  */
}
