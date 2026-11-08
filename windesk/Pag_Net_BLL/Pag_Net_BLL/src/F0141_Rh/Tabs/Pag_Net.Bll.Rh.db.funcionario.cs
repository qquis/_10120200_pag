using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh
{
    public class TbRhFuncionario
    {
        public int      rh_funcionario_seq              {get ;set; }
        public int      rh_funcionario_cd               {get; set; }
        public int      rh_funcionario_cd_dg            {get; set; }
        public int      cdpessoabluesoft                {get; set; }
        public string   rh_funcionario_nome             {get; set; }
        public string   cpf_cnpj                        {get; set; }
        public int      operacao_setor_cd               {get; set; }
        public int      rh_funcionario_status_cd        {get; set; }
        public int      rh_funcionario_tipo_contrato_cd {get; set; }
        public DateTime rh_data_admissao                {get; set; }
        public int      rh_setor_operacional_Cd         {get; set; }
        



        public TbRhFuncionario() 
        {
            this.cdpessoabluesoft = 0;
            this.cpf_cnpj = "0";
            this.rh_funcionario_cd = 0;
            this.rh_funcionario_nome = "NÃO IDENTIFICADO";
            this.rh_funcionario_seq = 0;
            this.rh_funcionario_cd_dg = 0;
            this.operacao_setor_cd = 0;
            this.rh_funcionario_status_cd = 0;
            this.rh_setor_operacional_Cd = 0; 
         

        }
        public TbRhFuncionario(
            int      _rh_funcionario_seq ,
            int      _rh_funcionario_cd  ,
            int      _cdpessoabluesoft   ,
            int      _rh_funcionario_cd_dg , 
            string   _rh_funcionario_nome,
            string   _cpf_cnpj,
            int      _rh_setor_operacional_cd,
            int      _rh_funcionario_status_cd,
            int      _rh_funcionario_tipo_contrato_cd
            ) 
        {
            this.cdpessoabluesoft = _cdpessoabluesoft;
            this.cpf_cnpj = _cpf_cnpj;
            this.rh_funcionario_cd = _rh_funcionario_cd;
            this.rh_funcionario_nome = _rh_funcionario_nome;
            this.rh_funcionario_seq = _rh_funcionario_seq;
            this.rh_funcionario_cd_dg = _rh_funcionario_cd_dg;
            this.rh_funcionario_status_cd = _rh_funcionario_status_cd;

        }
            
        public TbRhFuncionario(DataRow i )
        {
             rh_funcionario_seq   = Convert.ToInt32( i["rh_funcionario_seq"].ToString());
             rh_funcionario_cd    = Convert.ToInt32( i["rh_funcionario_cd"].ToString());
             cdpessoabluesoft     = Convert.ToInt32( i["cdpessoabluesoft"].ToString());
             rh_funcionario_nome  = i["rh_funcionario_nome"].ToString();
             cpf_cnpj               = i["cpf_cnpj"].ToString();
             rh_funcionario_cd_dg = Convert.ToInt32(i["rh_funcionario_cd_dg"].ToString());
             rh_funcionario_status_cd = Convert.ToInt32(i["rh_funcionario_status_cd"].ToString());
        }

    }
}
