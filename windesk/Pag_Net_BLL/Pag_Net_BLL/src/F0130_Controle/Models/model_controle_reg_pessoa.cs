using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class model_controle_reg_pessoa : TbControle_Reg_Pessoa
    {

        public Pag_Net.Bll.F0137_CartaoAcesso.model_cartao_acesso CartaoAcesso { get; set; }

        public DateTime controle_reg_data { get; set; }
        public int controle_cd { get; set; }
        public string controle_pessoa_descricao { get; set; }
        public int Local_CartaoAcessoNumero
        {
            get
            {
                return CartaoAcesso.cartao_acesso_numero;
            }
        }



        public model_controle_reg_pessoa(int _controle_reg_seq, int _controle_pessoa_cd, string _controle_pessoa_descricao)
            : base(_controle_reg_seq, _controle_pessoa_cd)
        {
            this.cpf_cnpj = "";
            this.nome_razao = "";
            controle_pessoa_descricao = _controle_pessoa_descricao;
            CartaoAcesso = new F0137_CartaoAcesso.model_cartao_acesso();
        }

        public model_controle_reg_pessoa(DataRow i)
            : base(i)
        {
            CartaoAcesso = new F0137_CartaoAcesso.model_cartao_acesso();
            controle_pessoa_descricao = i["controle_pessoa_descricao"].ToString();
            controle_reg_data = Convert.ToDateTime(i["controle_reg_data"].ToString());
            CartaoAcesso.cartao_acesso_numero = Convert.ToInt32(i["cartao_acesso_numero"].ToString());
            CartaoAcesso.Registro.cartao_acesso_reg_seq = Convert.ToInt32(i["cartao_acesso_reg_seq"].ToString());

        }


        public void Binding(Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                if (this.cpf_cnpj != "")
                {
                    Pag_Net.Bll.F0011_Participante.Wk PessoaParticipante = new F0011_Participante.Wk(MyConnect);
                    DataTable DataTable_PessoaParticipante = PessoaParticipante.Pessoa_Consultar(this.cpf_cnpj, this.cdparticipante, this.cdpessoabluesoft, this.rh_funcionario_cd);
                    if (DataTable_PessoaParticipante.Rows.Count > 0)
                    {
                        this.nome_razao = DataTable_PessoaParticipante.Rows[0]["nome_razao"].ToString();
                        this.endereco_cep = Convert.ToInt32(DataTable_PessoaParticipante.Rows[0]["endereco_cep"].ToString());
                        this.endereco_logradouro = DataTable_PessoaParticipante.Rows[0]["endereco_logradouro"].ToString();
                        this.endereco_numero = DataTable_PessoaParticipante.Rows[0]["endereco_numero"].ToString();
                        this.endereco_bairro = DataTable_PessoaParticipante.Rows[0]["endereco_bairro"].ToString();
                        this.endereco_municipio = DataTable_PessoaParticipante.Rows[0]["endereco_municipio"].ToString();
                        this.endereco_uf = DataTable_PessoaParticipante.Rows[0]["endereco_uf"].ToString();
                        this.endereco_complmento = DataTable_PessoaParticipante.Rows[0]["endereco_complmento"].ToString();
                        //this.CartaoAcesso.cartao_acesso_numero =  Convert.ToInt32( DataTable_PessoaParticipante.Rows[0]["cartao_acesso_numero"].ToString()); 	
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        public void Save(Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                DataTable _RESULT = BDCommand.get_DataTable(MyConnect,
                    F0130_33_Controle_Reg_Pessoa_CRUD.Post(MyConnect,
                                                            Models.BDCommandTypes.DBINSERT, this));
                this.controle_reg_pessoa_seq = Convert.ToInt32(_RESULT.Rows[0]["controle_reg_pessoa_seq"].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
