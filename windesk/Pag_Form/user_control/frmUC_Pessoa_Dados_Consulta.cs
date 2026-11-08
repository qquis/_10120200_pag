using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.user_control
{
    public partial class frmUC_Pessoa_Dados_Consulta : UserControl
    {
        Pag_Net.Bll.Pessoa._model_dados _dados;
        Pag_Net.Bll.Pessoa._model_endereco _endereco;
        public frmUC_Pessoa_Dados_Consulta()
        {
            InitializeComponent();
            _dados = new Pag_Net.Bll.Pessoa._model_dados();
            _endereco = new Pag_Net.Bll.Pessoa._model_endereco();

            dtp_CNH_Vencimento.Value = DateTime.Now;
            dtp_Data_Nascimento.Value = DateTime.Now;
            cmbSEXO.DisplayMember = "Text";
            cmbSEXO.ValueMember = "Value";
            cmbSEXO.DataSource = Pag_Net.Models.Model_info.TipoSexo();
        }

        public void Show(Pag_Net.Bll.Pessoa._model_pessoa __PESSOA)
        {
            _dados = __PESSOA.Dados;
            _endereco = __PESSOA.Endereco;
            _DataBinding();
        }

        private void _DataBinding()
        {


            txt_cpf_cnpj.Text = _dados.cpf_cnpj.ToString();
            txt_RazaoSocial_Nome.DataBindings.Clear();
            dtp_Data_Nascimento.DataBindings.Clear();
            txt_mail.DataBindings.Clear();
            txt_instagram.DataBindings.Clear();
            txt_facebook.DataBindings.Clear();
            txt_RG.DataBindings.Clear();
            txt_CNH.DataBindings.Clear();
            dtp_CNH_Vencimento.DataBindings.Clear();
            cmbSEXO.DataBindings.Clear();
            txt_logradouro.DataBindings.Clear();
            txt_numero.DataBindings.Clear();
            txt_bairro.DataBindings.Clear();
            txt_CEP.DataBindings.Clear();
            txt_telefone_ddd_main.DataBindings.Clear();
            txt_telefone_numero_main.DataBindings.Clear();

            //txt_CPF_CNPJ.DataBindings.Add("Text", _dados,, "cpf_cnpj");
            txt_RazaoSocial_Nome.DataBindings.Add("Text", _dados, "nome_razao");

            /*sexo ???*/

            txt_complemento.DataBindings.Clear();
            dtp_Data_Nascimento.DataBindings.Add("Value", _dados, "data_nascimento");
            txt_mail.DataBindings.Add("Text", _dados, "email_main");
            txt_instagram.DataBindings.Add("Text", _dados, "instagram");
            txt_facebook.DataBindings.Add("Text", _dados, "facebook");
            txt_RG.DataBindings.Add("Text", _dados, "documento_rg");
            txt_CNH.DataBindings.Add("Text", _dados, "documento_cnh");
            dtp_CNH_Vencimento.DataBindings.Add("Text", _dados, "documento_cnh_vencimento");
            //cmbSEXO.DataBindings.Add("SelectedValue", _dados, "sexo");
            txt_telefone_ddd_main.DataBindings.Add("Text", _dados, "telefone_ddd_main");
            txt_telefone_numero_main.DataBindings.Add("Text", _dados, "telefone_numero_main");

            if (_dados.sexo == "M")
                cmbSEXO.SelectedIndex = 0;
            else
                cmbSEXO.SelectedIndex = 1;

            if (_dados.sexo == null)
                cmbSEXO.SelectedIndex = 0;

            txt_logradouro.DataBindings.Add("Text", _endereco, "endereco_logradouro");
            txt_numero.DataBindings.Add("Text", _endereco, "endereco_numero");
            txt_bairro.DataBindings.Add("Text", _endereco, "endereco_bairro");
            txt_CEP.DataBindings.Add("Text", _endereco, "endereco_cep");
            txt_complemento.DataBindings.Add("Text", _endereco, "endereco_complemento");


        }
    

    }
}
