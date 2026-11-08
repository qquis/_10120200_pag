using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;

namespace Pag_Net.Bll.Pessoa
{
    public static class Pool
    {
        public static DataTable PessoaBlueSoft_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, int cdpessoabluesoft)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, Pag_Net.Bll.F0011_10.PostGre.Get(new Pag_Net.Bll.F0011_10.filter(cdpessoabluesoft)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void Atualizar(
                Pag_Net.Models.modelSistemaUsuario MyConnect,
                string cnpj_cpf,
                _model_dados Pessoa, 
                _model_endereco Endereco 

            )
        {
            try
            {
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(
                                        Pag_Net.Bll.F0011_01.Postgres.post(MyConnect, "DBINSERT", false, 
                                          Pessoa.cdpessoa
                                        , cnpj_cpf
                                        , Pessoa.nome_razao
                                        , Pessoa.sexo
                                        , Pessoa.data_nascimento
                                        , Pessoa.email_main
                                        , Pessoa.instagram
                                        , Pessoa.facebook
                                        , Pessoa.documento_rg
                                        , Pessoa.documento_cnh
                                        , Pessoa.documento_cnh_vencimento
                                        , Pessoa.PessoaJuridica
                                        , Pessoa.telefone_ddd_main
                                        , Pessoa.telefone_numero_main
                                        ), 
                                        null, 
                                        DataBaseName.ODBCOXAN
                                  );
                BDExecute.Execute(Pag_Net.Bll.F0011_04.Postgres.post(MyConnect, "DBINSERT", false,
                                                0,
                                                cnpj_cpf,
                                                0,
                                                0,
                                                1,
                                                Endereco.endereco_cep,
                                                Endereco.endereco_logradouro,
                                                Endereco.endereco_bairro,
                                                Endereco.endereco_numero,
                                                Endereco.endereco_municipio,
                                                Endereco.endereco_complemento,
                                                0,
                                                0,
                                                Endereco.endereco_uf 
                    
                    ),
                    null,
                    DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Listar(
                Pag_Net.Models.modelSistemaUsuario MyConnect,
                _model_dados Registro
            )
        {
            return Pag_Net.Bll.R0011_01.Postgre.get(MyConnect, 
                                    Registro.cdpessoa
                                ,   Registro.cdpessoabluesoft
                                ,   Registro.cdparticipante
                                ,   Registro.cpf_cnpj
                                ,   Registro.nome_razao
                                );
        }
        public static _model_pessoa Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, string CPF_CNPJ)
        {
            _model_pessoa _pessoa = new _model_pessoa();

            try
            {
                _model_pessoa _pessoa_retorno = new _model_pessoa(Consultar_Pessoa(MyConnect, CPF_CNPJ), Consultar_Endereco(MyConnect, CPF_CNPJ));
                if (_pessoa_retorno != null)
                    _pessoa = _pessoa_retorno;
                
                return _pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static _model_dados Consultar_Pessoa(Pag_Net.Models.modelSistemaUsuario MyConnect, string CNPJ)
        {
            try
            {
                DataTable Info_Pessoa = Pag_Net.Bll.R0011_02.Postgre.get(MyConnect, CNPJ);
                if (Info_Pessoa.Rows.Count > 0)
                {
                    return new _model_dados(Info_Pessoa.Rows[0]);
                }
                else
                {
                    return new _model_dados();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static _model_endereco Consultar_Endereco(Pag_Net.Models.modelSistemaUsuario MyConnect, string CNPJ)
        {
            try
            {
                DataTable Info_Pessoa =  Pag_Net.Bll.R0011_02.Postgre.get(MyConnect, CNPJ);
                if (Info_Pessoa.Rows.Count > 0)
                {
                    return new _model_endereco(Info_Pessoa.Rows[0]);
                }
                else 
                {
                    return new _model_endereco();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool ValidaDocumento_CPF_CNPJ (string CPF_CNPJ, bool PessoaJuridica)
        {

            if (PessoaJuridica)
                return Models.BDTools.DocCNPJ_Validar(CPF_CNPJ);
            else
                return Models.BDTools.DocCPF_Validar(CPF_CNPJ);
        }
    }
    public class _model_dados
    {
        public int cdpessoabluesoft { get; set; }
        public int cdparticipante { get; set; }

        public int          cdpessoa                    { get; set; }
        public string       cpf_cnpj                    { get; set; }
        public bool         PessoaJuridica              { get; set; }
        public string       nome_razao                  { get; set; }
        public string       sexo                        { get; set; }
        public DateTime     data_nascimento             { get; set; }
        public string       email_main                  { get; set; }
        public string       instagram                   { get; set; }
        public string       facebook                    { get; set; }
        public string       documento_rg                { get; set; }
        public string       documento_cnh               { get; set; }
        public string       telefone_ddd_main           { get; set; }
        public string       telefone_numero_main        { get; set; }
        public DateTime     documento_cnh_vencimento    { get; set; }


        public _model_dados()
        {
            data_nascimento = DateTime.Now;
            documento_cnh_vencimento = DateTime.Now;
            PessoaJuridica = false;


            cdpessoa                 = 0; 
            cpf_cnpj                 = "";
            PessoaJuridica           = false;
            nome_razao               = "";
            sexo                     = "M";
            email_main               = "";
            instagram                = "@";
            facebook                 = "";
            documento_rg             = "";
            documento_cnh            = "";
            telefone_ddd_main        = "";
            telefone_numero_main     = "";


        }

        public _model_dados(DataRow i) 
        { 
            cdpessoa = Convert.ToInt32(i["cdpessoa"]);
            cpf_cnpj = i["cpf_cnpj"].ToString();

            if (Convert.ToInt32(i["Juridica"].ToString()) == 1)
            {
                PessoaJuridica = true;
            }
            else 
            {
                PessoaJuridica = false;
            }

            nome_razao = i["nome_razao"].ToString();
            //sexo                      
            data_nascimento = Convert.ToDateTime(i["data_nascimento"]);
            email_main = i["email_main"].ToString();
            instagram = i["instagram"].ToString();
            facebook = i["facebook"].ToString();
            documento_rg = i["documento_rg"].ToString();
            documento_cnh = i["documento_cnh"].ToString();
            documento_cnh_vencimento = Convert.ToDateTime(i["documento_cnh_vencimento"].ToString());
            telefone_ddd_main = i["telefone_ddd_main"].ToString();
            telefone_numero_main = i["telefone_numero_main"].ToString();
            sexo = i["sexo"].ToString();


        }


        
    }
    public class _model_endereco
    {
        public string   cpf_cnpj                        { get; set;  }
        public int      endereco_cep                    {get;set;}
        public string   endereco_logradouro             {get;set;}
        public string   endereco_bairro                 {get; set; }
        public string   endereco_numero                 {get; set; }
        public string   endereco_municipio              {get; set; }
        public string   endereco_complemento            {get; set; }
        public string   endereco_uf                     {get; set; }

        public _model_endereco() 
        {
            //cpf_cnpj = "";
            endereco_cep = 0;
            endereco_logradouro = "";
            endereco_bairro = "";
            endereco_numero = "";
            endereco_municipio = "";
            endereco_complemento = "";
            endereco_uf = "";      
        
        }

        public _model_endereco(DataRow i)
        {
            endereco_cep = Convert.ToInt32(i["endereco_cep"]);
            endereco_logradouro = i["endereco_logradouro"].ToString();
            endereco_bairro = i["endereco_bairro"].ToString();
            endereco_municipio = i["endereco_municipio"].ToString();
            endereco_complemento = i["endereco_complemento"].ToString();
            endereco_uf = i["endereco_uf"].ToString();
            endereco_numero = i["endereco_numero"].ToString();
        }
    }
    public class _model_pessoa
    {
        public _model_dados Dados { get; set; }
        public _model_endereco Endereco { get; set; }
        public _model_pessoa() { }
        public _model_pessoa( _model_dados __model_dados, _model_endereco __model_endereco) 
        {
            Dados = __model_dados;
            Endereco = __model_endereco;

     
        
        }
    }
}

