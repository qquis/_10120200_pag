using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante.Tb
{




	public class ParticipantePessoa	
    {
		public 	int cdparticipante											{get; set; }
		public 	int cdpessoa												{get; set; }
		public 	int cdpessoabluesoft										{get; set; }
		public 	string cpf_cnpj 											{get; set; }
		public 	string nome_razao 											{get; set; }
        public string nome_abreviado { get; set; }
		public 	string email_main 											{get; set; }
		public 	int bluesoftcliente 										{get; set; }
		public 	int bluesoftvendedor										{get; set; }
		public 	int bluesoftfornecedor										{get; set; }
		public 	int bluesoftfabricante 										{get; set; }
		public 	int cdgrupoeconomico 										{get; set; }
		public 	int cdpessoabluesoft_vendedor								{get; set; }
		public 	int bluesoftclientestatus									{get; set; }
		public 	int bluesoftpessoastatus									{get; set; }
		public 	double bluesoftcliente_creditolimite_valor					{get; set; }
		public 	double bluesoftcliente_creditolimite_valor_reservado		{get; set; }
		public 	DateTime bluesoftpessoa_data_cadastro 						{get; set; }
		public 	int bluesoftcliente_creditostatus_cd						{get; set; }
		public 	int bluesoftcliente_ramoatividade_cd 						{get; set; }
		public 	int telefone_ddd_main										{get; set; }
		public 	int telefone_numero_main									{get; set; }
		public 	string instagram 											{get; set; }
		public 	string facebook 											{get; set; }
		public 	string documento_rg 										{get; set; }
		public 	string documento_cnh 										{get; set; }
        public DateTime documento_cnh_vencimento { get; set; }


        public ParticipantePessoa() 
        {
            cdparticipante = 0;
            cdpessoa = 0;
            cdpessoabluesoft = 0;
            bluesoftpessoa_data_cadastro = DateTime.Now;

        
        
        }
        public ParticipantePessoa(int _cdparticipante, int _cdpessoabluesoft, string _nome_razao) 
        {
			cdparticipante = _cdparticipante;
            cdpessoabluesoft = _cdpessoabluesoft;
            nome_razao = _nome_razao;
		}

        public ParticipantePessoa(int _cdparticipante, int _cdpessoabluesoft, string _nome_razao, string _nome_abreviado)
        {
            cdparticipante = _cdparticipante;
            cdpessoabluesoft = _cdpessoabluesoft;
            nome_razao = _nome_razao;
            nome_abreviado = _nome_abreviado;
        }        



    }

}


