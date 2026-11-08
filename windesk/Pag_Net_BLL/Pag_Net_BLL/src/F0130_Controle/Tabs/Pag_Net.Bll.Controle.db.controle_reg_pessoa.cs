using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle_Reg_Pessoa
    {

        public int      controle_reg_pessoa_seq { get; set;  }
        public int      controle_reg_seq                { get; set; }
        public int      controle_pessoa_cd              {get; set; }
        public int      cdparticipante                  { get; set; }
        public int      cdpessoabluesoft	            { get; set; }		
        public int      rh_funcionario_cd               {get; set; }			
        public string   cpf_cnpj	                    {get; set; }				
        public string   nome_razao                       {get; set; }					
        public string   documento_cnh 	                {get; set; }			
        public DateTime documento_cnh_vencimento 	    {get; set; }
        public int      endereco_tipo_cd	            {get; set; }		
        public int      endereco_cep                    {get; set; }				
        public string   endereco_logradouro	            {get; set; }		
        public string   endereco_numero	                {get; set; }
        public string   endereco_bairro                 { get; set; }	
        public string   endereco_municipio              {get; set; }			
        public string   endereco_uf                     {get; set; }				
        public string   endereco_complmento	            {get; set; }
        public int celular_dd { get; set; }
        public int celular_numero { get; set; }

        public TbControle_Reg_Pessoa() { }
        public TbControle_Reg_Pessoa(
            int _controle_reg_seq,
            int _controle_pessoa_cd 
            
            )
        {
            controle_reg_seq = _controle_reg_seq;
            controle_pessoa_cd = _controle_pessoa_cd;
            documento_cnh_vencimento = Convert.ToDateTime("1900-01-01");
            cpf_cnpj	= "";    
            nome_razao      = "";
            documento_cnh = "";
            cdparticipante       = 0;
            cdpessoabluesoft	 = 0;
            rh_funcionario_cd = 0;
            celular_dd = 11;


        }
        public TbControle_Reg_Pessoa(DataRow i)
        {
            string _error_message = "";
            try
            {

                _error_message = "controle_reg_seq_pessoa";
                controle_reg_pessoa_seq = Convert.ToInt32(i["controle_reg_pessoa_seq"].ToString());

                _error_message = "controle_reg_seq";
                controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());
                _error_message = "controle_pessoa_cd";
                controle_pessoa_cd = Convert.ToInt32(i["controle_pessoa_cd"].ToString());
                _error_message = "cdparticipante";
                cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                _error_message = "cdpessoabluesoft";
                cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());
                _error_message = "rh_funcionario_cd";
                rh_funcionario_cd = Convert.ToInt32(i["rh_funcionario_cd"].ToString());
                _error_message = "cpf_cnpj";
                cpf_cnpj = i["cpf_cnpj"].ToString();
                _error_message = "nome_razao";
                nome_razao = i["nome_razao"].ToString();
                _error_message = "documento_cnh";
                documento_cnh = i["documento_cnh"].ToString();
                _error_message = "documento_cnh_vencimento";
                documento_cnh_vencimento = Convert.ToDateTime(i["documento_cnh_vencimento"].ToString());
                _error_message = "endereco_tipo_cd";
                endereco_tipo_cd = Convert.ToInt32(i["endereco_tipo_cd"].ToString());
                _error_message = "endereco_cep";
                endereco_cep = Convert.ToInt32(i["endereco_cep"].ToString());
                _error_message = "endereco_logradouro";
                endereco_logradouro = i["endereco_logradouro"].ToString();
                _error_message = "endereco_numero";
                endereco_numero = i["endereco_numero"].ToString();
                _error_message = "endereco_municipio";
                endereco_municipio = i["endereco_municipio"].ToString();
                _error_message = "endereco_uf";
                endereco_uf = i["endereco_uf"].ToString();
                _error_message = "endereco_complmento";
                endereco_complmento = i["endereco_complmento"].ToString();
                _error_message = "celular_dd";
                celular_dd = Convert.ToInt32(i["celular_dd"].ToString());
                _error_message = "celular_numero";
                celular_numero = Convert.ToInt32(i["celular_numero"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Field: " + _error_message);
            }

        }
    }
}
