using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms
{
    public partial class frm_portaria_recebimento : Form
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;

        Pag_Net.Bll.F0060_DocumentoFiscal.Db.TbDocumentoFiscalRegistro DocumentoFiscal_Inicial;
        
        
        Pag_Net.Bll.Controle.tbcontrole _CONTROLE;
        Pag_Net.Bll.Controle.tbcontrole_dados _CONTROLE_DADOS;
        Pag_Net.Bll.Veiculo.TbVeiculo _VEICULO;

        Pag_Form.user_control.frmUC_DocumentoFiscalRegistro frmUC_DocumentoFiscalRegistro;
        public frm_portaria_recebimento(Pag_Net.Models.modelSistemaUsuario _myConnect, Pag_Net.Bll.F0060_DocumentoFiscal.Db.TbDocumentoFiscalRegistro DocumentoFiscal)
        {
            InitializeComponent();

            MyConnect = _myConnect;

            /*USER CONTROL*/
            frmUC_DocumentoFiscalRegistro = new Pag_Form.user_control.frmUC_DocumentoFiscalRegistro(MyConnect, false, false);

            
            _CONTROLE = Pag_Net.Bll.Controle.Recebimento_Mercadoria.Registro(MyConnect);
            _CONTROLE_DADOS = new Pag_Net.Bll.Controle.tbcontrole_dados();
            _VEICULO = new Pag_Net.Bll.Veiculo.TbVeiculo();
                        
            DocumentoFiscal_Inicial = DocumentoFiscal;
            
            _Screen_load();
            

        }

        private void _Screen_load()
        {
            dtgControle_dados_historico.AutoGenerateColumns = false;
            lbl_controle_Seq.Text = _CONTROLE.controle_reg_numero.ToString();

            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");

            /*USER CONTROL*/
            frmUC_DocumentoFiscalRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            frmUC_DocumentoFiscalRegistro.Location = new System.Drawing.Point(1, 1);
            frmUC_DocumentoFiscalRegistro.Name = "frmUC_DocumentoFiscalRegistro";
            frmUC_DocumentoFiscalRegistro.Size = new System.Drawing.Size(782, 373);
            frmUC_DocumentoFiscalRegistro.TabIndex = 0;
            tabRecebimento.Controls.Add(frmUC_DocumentoFiscalRegistro);

            frmUC_DocumentoFiscalRegistro.EventHandler_Confirma_Lista += new EventHandler(_Efetiva_Lista);
            frmUC_DocumentoFiscalRegistro.__CONTROLE_REG_SEQ = _CONTROLE.controle_reg_seq;
            frmUC_DocumentoFiscalRegistro.__CONTROLE_ETAPA_CD = 2;
            frmUC_DocumentoFiscalRegistro._DocumentoFiscaisRegistroExterno_Incluir(DocumentoFiscal_Inicial);
            cmdFILA_MERCEARIA.Click += new EventHandler(_Efetiva_Controle);
            cmdFILA_PERECIVEIS.Click += new EventHandler(_Efetiva_Controle);
            cmdFILA_HORTIFRUTI.Click += new EventHandler(_Efetiva_Controle);
            cmdFILA_SUPRIMENTO.Click += new EventHandler(_Efetiva_Controle);

            txtControle_Reg_Transportadora_CNPJ.LostFocus += new EventHandler(_Screen_lostFocus);
            txtControle_Reg_Transportadora_RazaoSocial.LostFocus += new EventHandler(_Screen_lostFocus);
            txtControle_Reg_Motorista_CPF.LostFocus += new EventHandler(_Screen_lostFocus);
            txtControle_Reg_Motorista_Nome.LostFocus += new EventHandler(_Screen_lostFocus);
            txtControle_Reg_Motorista_CNH.LostFocus += new EventHandler(_Screen_lostFocus);
            txtControle_Reg_Veiculo_Placa.LostFocus += new EventHandler(_Screen_lostFocus);
            txtControle_reg_numero_pallet.LostFocus += new EventHandler(_Screen_lostFocus);
            CmbVeiculoModelo.LostFocus += new EventHandler(_Screen_lostFocus);

            CmbVeiculoModelo.ValueMember = "veiculo_modelo_cd";
            CmbVeiculoModelo.DisplayMember = "veiculo_modelo_descricao";
            CmbVeiculoModelo.DataSource = Pag_Net.Bll.Veiculo.Modelos.Obter_lista(MyConnect);
            _VEICULO.veiculo_modelo_cd = Convert.ToInt32(CmbVeiculoModelo.SelectedValue);

            TxtCNPJ_Consulta_Dados.Text = DocumentoFiscal_Inicial.dfr_cnpj_cpf.ToString();
            if (TxtCNPJ_Consulta_Dados.Text != "") _Historico_Entrada();

            

        }

        private void _Efetiva_Lista(object sender, EventArgs e)
        {
            MessageBox.Show("LISTA EFETIVADA");
        }

        private void _Screen_wait(Button cmd, bool ON)
        {
            if (ON)
            {
                cmd.Enabled = false;
                _Screen_wait(ON);
            }
            else
            {
                _Screen_wait(ON);
                cmd.Enabled = true;
            }
        }
        private void _Screen_wait(bool ON)
        {
            if (ON)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                this.Refresh();
            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {


        }
        private void _Screen_lostFocus(object sender, EventArgs e)
        {
            try
            {

                if (sender.GetType().Name == "ComboBox")
                {
                    if ( ((ComboBox)sender).Name == "CmbVeiculoModelo" ) 
                    {
                        _VEICULO.veiculo_modelo_cd = Convert.ToInt32(CmbVeiculoModelo.SelectedValue);
                    }
                }


                if (sender.GetType().Name == "TextBox")
                {
                    switch (((TextBox)sender).Name)
                    {
                        case "txtControle_Reg_Transportadora_CNPJ":
                            if (txtControle_Reg_Transportadora_CNPJ.Text != "")
                            {
                                if (txtControle_Reg_Transportadora_RazaoSocial.Text == "")
                                {
                                    txtControle_Reg_Transportadora_RazaoSocial.Text = Pag_Net.Bll.Pessoa.Pool.Consultar(MyConnect, _CONTROLE_DADOS.controle_reg_transportadora_cnpj).Dados.nome_razao;
                                }
                            }
                            break;
                        //case "txtControle_Reg_Transportadora_RazaoSocial":
                        //    _CONTROLE_DADOS.controle_reg_transportadora_razao_social = txtControle_Reg_Transportadora_RazaoSocial.Text;
                        //    break;
                        case "txtControle_Reg_Motorista_CPF":
                            _CONTROLE_DADOS.controle_reg_motorista_cpf = txtControle_Reg_Motorista_CPF.Text;
                            Pag_Net.Bll.Pessoa._model_pessoa _Motorista_Dados = Pag_Net.Bll.Pessoa.Pool.Consultar(MyConnect, _CONTROLE_DADOS.controle_reg_motorista_cpf);
                            txtControle_Reg_Motorista_Nome.Text = _Motorista_Dados.Dados.nome_razao;
                            txtControle_Reg_Motorista_CNH.Text = _Motorista_Dados.Dados.documento_cnh.ToString();
                            break;
                        //case "txtControle_Reg_Motorista_Nome":
                        //    _CONTROLE_DADOS.controle_reg_motorista_Nome = txtControle_Reg_Motorista_Nome.Text ;
                        //    break;

                        //case "txtControle_Reg_Motorista_CNH":
                        //    _CONTROLE_DADOS.controle_reg_motorista_documento_cnh = txtControle_Reg_Motorista_CNH.Text;
                        //    break;

                        case "txtControle_reg_numero_pallet":
                            if (txtControle_reg_numero_pallet.Text != "")
                            _CONTROLE_DADOS.controle_reg_numero_pallet = Convert.ToInt32(txtControle_reg_numero_pallet.Text);
                            break;

                        case "txtControle_Reg_Veiculo_Placa":
                            
                            if (txtControle_Reg_Veiculo_Placa.Text != "")
                            {
                                txtControle_Reg_Veiculo_Placa.Text = txtControle_Reg_Veiculo_Placa.Text.ToUpper();
                                Pag_Net.Bll.Veiculo.TbVeiculo _Veiculo_Consultado = Pag_Net.Bll.Veiculo.Pool.Veiculo_Consultar(MyConnect, txtControle_Reg_Veiculo_Placa.Text);
                                if (_Veiculo_Consultado.veiculo_seq > 0 )
                                {
                                    _VEICULO = _Veiculo_Consultado;
                                    CmbVeiculoModelo.Text = _Veiculo_Consultado.veiculo_modelo_descricao;
                                }
                                _VEICULO.veiculo_placa = txtControle_Reg_Veiculo_Placa.Text.ToString();
                            }
                            break;

                    }


                    //_Binding();
                }

                if (sender.GetType().Name == "DateTimePicker")
                {
                    //switch (((DateTimePicker)sender).Name)
                    //{
                    // }
                }

                if (sender.GetType().Name == "CheckBox")
                {

                }

                if (sender.GetType().Name == "ComboBox")
                {

                }


            }

            catch (Exception ErroMessage)
            {

                MessageBox.Show(ErroMessage.Message);

                if (sender.GetType().Name == "TextBox")
                {
                    ((TextBox)sender).Text = "0";
                    ((TextBox)sender).Focus();
                    ((TextBox)sender).SelectAll();

                }

            }

        }

        private void _Historico_Entrada()
        {
            try
            {

                DataTable DTGHistoricoEntrada = Pag_Net.Bll.Controle.Recebimento_Mercadoria.Historico_Entrada(MyConnect, TxtCNPJ_Consulta_Dados.Text);
                if (DTGHistoricoEntrada.Rows.Count > 0)
                {

                    dtgControle_dados_historico.DataSource = Pag_Net.Bll.Controle.Recebimento_Mercadoria.Historico_Entrada(MyConnect, TxtCNPJ_Consulta_Dados.Text);
                    txtControle_Reg_Transportadora_CNPJ.DataBindings.Clear();
                    txtControle_Reg_Transportadora_RazaoSocial.DataBindings.Clear();
                    txtControle_Reg_Motorista_CPF.DataBindings.Clear();
                    txtControle_Reg_Motorista_CNH.DataBindings.Clear();
                    txtControle_Reg_Motorista_Nome.DataBindings.Clear();
                    //txtControle_Reg_Veiculo_Placa.DataBindings.Clear();
                    //txtControle_reg_numero_pallet.DataBindings.Clear();

                    txtControle_Reg_Transportadora_CNPJ.DataBindings.Add("Text", dtgControle_dados_historico.DataSource, "controle_reg_transportadora_cnpj");
                    txtControle_Reg_Transportadora_RazaoSocial.DataBindings.Add("Text", dtgControle_dados_historico.DataSource, "controle_reg_transportadora_razao_social");
                    txtControle_Reg_Motorista_CPF.DataBindings.Add("Text", dtgControle_dados_historico.DataSource, "controle_reg_motorista_cpf");
                    txtControle_Reg_Motorista_CNH.DataBindings.Add("Text", dtgControle_dados_historico.DataSource, "controle_reg_motorista_documento_cnh");
                    txtControle_Reg_Motorista_Nome.DataBindings.Add("Text", dtgControle_dados_historico.DataSource, "controle_reg_motorista_nome");
                    //txtControle_Reg_Veiculo_Placa.DataBindings.Add("Text", dtgControle_dados_historico.DataSource, "controle_reg_transportadora_razao_social");
                    //txtControle_reg_numero_pallet.DataBindings.Add("Text", dtgControle_dados_historico.DataSource, "controle_reg_transportadora_razao_social");
                }
                else
                {
                    txtControle_Reg_Transportadora_CNPJ.Text = TxtCNPJ_Consulta_Dados.Text;
                    txtControle_Reg_Transportadora_RazaoSocial.Text = Pag_Net.Bll.Pessoa.Pool.Consultar(MyConnect, TxtCNPJ_Consulta_Dados.Text).Dados.nome_razao;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private bool _Binding()
        {

            bool validado = true;
            try
            {

                try
                {
                    if (txtControle_Reg_Transportadora_CNPJ.Text != "")
                    {
                        _CONTROLE_DADOS.controle_reg_transportadora_cnpj = txtControle_Reg_Transportadora_CNPJ.Text;
                        validado = true;
                    }
                    else
                    {
                        validado = false;
                        throw new Exception("Favor informar o CNPJ/CPF da Transportadora!");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                try
                {
                    if (txtControle_Reg_Transportadora_RazaoSocial.Text != "")
                    {
                        _CONTROLE_DADOS.controle_reg_transportadora_razao_social = txtControle_Reg_Transportadora_RazaoSocial.Text;
                        validado = true;
                    }
                    else
                    {
                        validado = false;
                        throw new Exception("Razão social do Fornecedor/Transportadora responsável. Favor indicar o nome");
                        
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }



                try
                {
                    if (txtControle_Reg_Motorista_CPF.Text != "")
                        _CONTROLE_DADOS.controle_reg_motorista_cpf = txtControle_Reg_Motorista_CPF.Text;

                }
                catch (Exception ex)
                {
                    validado = false;
                    throw new Exception("Erro CPF do morista: " + ex.Message);
                }

                if (_VEICULO.veiculo_placa == "")
                {
                    throw new Exception("Favor informar a placa do Veículo");
                }


                if (txtControle_Reg_Motorista_Nome.Text != "")
                    _CONTROLE_DADOS.controle_reg_motorista_Nome = txtControle_Reg_Motorista_Nome.Text;

                if (txtControle_Reg_Motorista_CNH.Text != "")
                    _CONTROLE_DADOS.controle_reg_motorista_documento_cnh = txtControle_Reg_Motorista_CNH.Text;

                try
                {
                    if (txtControle_reg_numero_pallet.Text != "")
                        _CONTROLE_DADOS.controle_reg_numero_pallet = Convert.ToInt32(txtControle_reg_numero_pallet.Text);
                }
                catch (Exception ex)
                {
                    validado = false;
                    throw new Exception("Formato inválido no campo Número de Pallet: INFORME 0 ou um número válido " + ex.Message);
                }


                try
                {
                    if (TXTcontrole_reg_numero_celular_dd.Text != "")
                        _CONTROLE_DADOS.controle_reg_numero_celular_dd = Convert.ToInt32(TXTcontrole_reg_numero_celular_dd.Text);
                }
                catch (Exception ex)
                {
                    validado = false;
                    throw new Exception("Formato inválido no campo DD:" + ex.Message);
                }

                try
                {
                    if (txtcontrole_reg_numero_celular_numero.Text != "")
                        _CONTROLE_DADOS.controle_reg_numero_celular_numero = Convert.ToInt32(txtcontrole_reg_numero_celular_numero.Text);
                }
                catch (Exception ex)
                {
                    validado = false;
                    throw new Exception("Formato inválido no campo Número do Telefone:" + ex.Message);
                }

                return validado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return validado;
                
            }
            

        }
        private void _Efetiva_Controle(object sender, EventArgs e)
        {

            try
            {

                if (!_Binding())
                {
                    _Screen_wait(false);
                    return;
                }
                
                if (_VEICULO.veiculo_placa != "" && _CONTROLE_DADOS.controle_reg_motorista_cpf != "")
                {

                    _Screen_wait(true);
                    this.Refresh();
                    int fila = 1001;
                    switch (((Button)sender).Name.ToString())
                    {
                        case "cmdFILA_MERCEARIA":
                            fila = 1001;
                            break;
                        case "cmdFILA_PERECIVEIS":
                            fila = 1002;
                            break;
                        case "cmdFILA_HORTIFRUTI":
                            fila = 1003;
                            break;
                        case "cmdFILA_SUPRIMENTO":
                            fila = 1003;
                            break;
                    }
                     frmUC_DocumentoFiscalRegistro.Efetivar();
                    Pag_Net.Bll.Controle.Recebimento_Mercadoria.Abertura(MyConnect, _CONTROLE, fila, _CONTROLE_DADOS, _VEICULO);
                    MessageBox.Show("Registro incluído com sucesso!");
                    _Screen_wait(false);
                    this.Refresh();
                    this.Close();
                }
            }

            catch (Exception ex)
            {
                _Screen_wait(false);
                MessageBox.Show("ERRO! INFORME O SETOR ADMINISTRATIVO \n" + ex.Message + "\n Class: _Efetiva_Controle");
            }
        }


        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    


    }
}


                        
						
						
						
						
						
						
						
						
						
						
						