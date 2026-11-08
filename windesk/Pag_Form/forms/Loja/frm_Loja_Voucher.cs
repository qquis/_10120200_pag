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
    
    public partial class frm_Loja_Voucher : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        int __Tipo_Voucher = 1;
        public frm_Loja_Voucher(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                //cmdEfetivar_Voucher.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\ok.ico");
                cmdlistar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
                tab_voucher.TabIndex = 0;
                dtgvoucher.AutoGenerateColumns = false;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private void _Screen_lotfocus(object sender, EventArgs e)
        {

        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {

                if (sender.GetType().Name == "Label")
                {

                }

                if (sender.GetType().Name == "TextBox")
                {


                }

                if (sender.GetType().Name == "DateTimePicker")
                {
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
                if (sender.GetType().Name == "TextBox")
                {
                    ((TextBox)sender).Text = "0";
                }
                MessageBox.Show(ErroMessage.Message);
            }
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

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtCPF_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCPF.Text != "")
            {
                try
                {
                    _DataBinding_Incluir();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void cmdEfetivar_Voucher_Click(object sender, EventArgs e)
        {
            __Tipo_Voucher = 1;
            _DataBinding_Incluir();
            
        }

        private void cmdEfetivar_Voucher_Primeira_Compra_Click(object sender, EventArgs e)
        {
            __Tipo_Voucher = 2;
            _DataBinding_Incluir();

        }


        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e) { }

        private void _DataBinding_Incluir()
        {
            try
            {

                if (txtCPF.Text == "" || txtCPF.Text == "0")
                {
                    return;
                }

                if (txtCPF.Text.Length < 11 && txtCPF.Text != "0")
                {
                    txtCPF.Text = "0";
                    MessageBox.Show("CPF INVÁLIDO");
                    return;
                }

                if (!Pag_Net.Bll.Voucher.Pool.Voucher_Valid_Insert(MyConnect, txtCPF.Text, __Tipo_Voucher))
                {
                    MessageBox.Show("Tipo de Voucher não permitido para este cliente");
                    return;
                }

                /*
                Pag_Net.Bll.Pessoa._model_pessoa Pessoa = Pag_Net.Bll.Pessoa.Pool.Consultar(MyConnect, txtCPF.Text);
                if (Pessoa.Dados.cdpessoa == 0)
                {
                    if (MessageBox.Show("Cadastro não constra na BASE OXAN, deseja incluir?", "PAG", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        frm_Pessoa_DadoBasico _FRM_PESSOA_CADASTRO = new frm_Pessoa_DadoBasico(MyConnect, txtCPF.Text, true);
                        _FRM_PESSOA_CADASTRO.ShowDialog();
                    }
                }*/


                _Screen_wait(cmdEfetivar_Voucher, true);
                if (Pag_Net.Bll.Voucher.Pool.NumeroVoucher(MyConnect, new Pag_Net.Bll.Voucher._model_parametro_filter(txtCPF.Text, "")) != "")
                {
                    _DataBinding_List();
                    _Screen_wait(cmdEfetivar_Voucher, false);
                    MessageBox.Show("* * VOUCHER NÃO LIBERADO * *" + "\n"  +"\n" + "Cliente de CPF Número " + txtCPF.Text + " já fez uso do VOUCHER hoje");
                }
                else
                {
                    Pag_Net.Bll.Voucher.Pool.Atualizar(MyConnect, txtCPF.Text, __Tipo_Voucher);
                    _DataBinding_List();
                    _Screen_wait(cmdEfetivar_Voucher, false);
                    MessageBox.Show("NÚMERO DO VOUCHER: " + Pag_Net.Bll.Voucher.Pool.NumeroVoucher(MyConnect, new Pag_Net.Bll.Voucher._model_parametro_filter(txtCPF.Text, "")).ToString());
                }
                
                txtCPF.Text = "";
            }

            catch (Exception ex)
            {
                txtCPF.Text = "";
                _Screen_wait(cmdEfetivar_Voucher, false);
                MessageBox.Show(ex.Message);
            }
        }

        private void _DataBinding_List()
        {
            try
            {
                dtgvoucher.DataSource = Pag_Net.Bll.Voucher.Pool.Listar(MyConnect, new Pag_Net.Bll.Voucher._model_parametro_filter(DateTime.Now));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdlistar_Click(object sender, EventArgs e)
        {
            _DataBinding_List();
        }



    }


}
