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
    public partial class frm_Cartao_Acesso_Cadastro : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0137_CartaoAcesso.Wk WK;

        Ctrl_Transporte_Form_Action __Screen_Form_Action;

        public enum Ctrl_Transporte_Form_Action
        {
            Inclusao = 0,
            Consulta = 1
        }


        public frm_Cartao_Acesso_Cadastro(Pag_Net.Models.modelSistemaUsuario _MyConnect, int __cartao_acesso_seq)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            WK = new Pag_Net.Bll.F0137_CartaoAcesso.Wk(MyConnect);
            

            if (__cartao_acesso_seq != 0)
            {
                __Screen_Form_Action = Ctrl_Transporte_Form_Action.Consulta;
                WK.CartaAcessoItem.cartao_acesso_seq = __cartao_acesso_seq;
            }

            _Screen_load(true);

            if (__cartao_acesso_seq != 0)
            {
                _BindingCartao();
            }

        }
        private void frm_Cartao_Acesso_Cadastro_Shown(object sender, EventArgs e)
        {
            try
            {
                if (WK.CartaAcessoItem.cartao_acesso_seq != 0)
                    _ShowEAN();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _Screen_load(bool OpenForm)
        {
            try
            {
                if (OpenForm)
                {
                    cmbcartao_acesso_tipo.Enabled = false;


                    UserTools._Screen_Form_Open(this);
                    //UserTools._Screen_ButtonImage(cmdNovo_Cartao, UserTools.PagButtonsIcons.Novo);
                    //UserTools._Screen_ButtonImage(cmdConsultar_Cartao, UserTools.PagButtonsIcons.SetaDupla_Baixo);
                    cmbcartao_acesso_tipo.ValueMember = "cartao_acesso_tipo_cd";
                    cmbcartao_acesso_tipo.DisplayMember = "cartao_acesso_tipo_descricao";
                    cmbcartao_acesso_tipo.DataSource = WK.CartaoAcessoTipoList;
                    foreach (object i in this.Controls)
                    {
                        if (i.GetType().Name == "TextBox")
                        {
                            if (((TextBox)i).Tag != null)
                                if (((TextBox)i).Tag.ToString() != "")
                                    ((TextBox)i).LostFocus += new EventHandler(_Screen_lostFocus);

                            ((TextBox)i).Enabled = false;
                        }
                    }
        
                    foreach (object i in this.Controls) { if (i.GetType().Name == "Button") ((Button)i).Click += new EventHandler(_Screen_Click); }
                    chkfilter_cartao_acesso_status.Enabled = true;
                    dtpfilter_cartao_acesso_validade_ini.Value = DateTime.Now;
                    dtpfilter_cartao_acesso_validade_fim.Value = Convert.ToDateTime("2099-12-31");
                    txtcartao_acesso_seq.Enabled = false;
                    chkfilter_cartao_acesso_status.Enabled = false;
                    dtpfilter_cartao_acesso_validade_fim.Enabled = false;
                    dtpfilter_cartao_acesso_validade_ini.Enabled = false;
                    
                }

                if( __Screen_Form_Action == Ctrl_Transporte_Form_Action.Consulta )
                {

                    cmdefetivar.Enabled = false;
                }

                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Inclusao)
                {
                    chkfilter_cartao_acesso_status.Checked = true;
                    chkfilter_cartao_acesso_status.Enabled = false;
                    cmbcartao_acesso_tipo.Enabled = true;
                    dtpfilter_cartao_acesso_validade_fim.Enabled = false;
                    dtpfilter_cartao_acesso_validade_ini.Enabled = false;
                    cmbcartao_acesso_tipo.SelectedValueChanged += new EventHandler(_Screen_changed);
                    cmbcartao_acesso_tipo.LostFocus += new EventHandler(_Screen_lostFocus);
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }
        }

        private void _Screen_lostFocus(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "ComboBox")
                {

                    if (((ComboBox)sender).Name == "cmbContratoServico")
                    {


                    }
                }
                if (sender.GetType().Name == "TextBox")
                {

                    switch (((TextBox)sender).Name)
                    {

                        case "txtcpf_cnpj_Fornecedor":
                            break;

                    }

                }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox") { }
            }

            catch (Exception ErroMessage)
            {
                MessageBox.Show(ErroMessage.Message);
                if (sender.GetType().Name == "TextBox")
                {
                    ((TextBox)sender).Focus();
                    ((TextBox)sender).SelectAll();

                }

            }

        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label") { }
                if (sender.GetType().Name == "TextBox") { }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox"){}
                if (sender.GetType().Name == "ComboBox") { if (((ComboBox)sender).Name == "cmbcartao_acesso_tipo") _BindingCartaoAcessoTipo();  }
                if (sender.GetType().Name == "TabControl") { }
            }

            catch (Exception ex)
            {
                if (sender.GetType().Name == "TextBox")
                {
                    ((TextBox)sender).Text = "0";
                }
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _Screen_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "Button")
            {
                if (((Button)sender).Name == "cmdsair") { this.Close(); }
                if (((Button)sender).Name == "cmdefetivar") { _Efetivar(); }
                if (((Button)sender).Name == "cmdimprimir") { _ImprimirCartao(); }
            }
        }

        private void _Efetivar()
        {
            try
            {
                
                if (((Pag_Net.Bll.F0137_CartaoAcesso.TbCartaoAcessoTipo)cmbcartao_acesso_tipo.SelectedItem).cartao_acesso_tipo_cd ==0 )
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Favor informar o tipo de Cartão de Acesso");
                    return;
                }
                if (Convert.ToInt32((txt_cartao_acesso_numero.Text)) == 0 )
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Favor informar o Número do Cartão");
                    return;
                }

                if (txt_cartao_acesso_cdbr.Text  == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Código de Barra inválido");
                    return;
                }

                if (txt_cartao_acesso_cdbr.Text.Length != 13)
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Código de Barra inválido");
                    return;
                }

                WK.CartaAcessoItem.cartao_acesso_seq = Convert.ToInt32(txtcartao_acesso_seq.Text);
                WK.CartaAcessoItem.cartao_acesso_cdbr = txt_cartao_acesso_cdbr.Text;
                WK.CartaAcessoItem.cartao_acesso_data = DateTime.Now;
                WK.CartaAcessoItem.cartao_acesso_tipo_cd = ((Pag_Net.Bll.F0137_CartaoAcesso.TbCartaoAcessoTipo)cmbcartao_acesso_tipo.SelectedItem).cartao_acesso_tipo_cd;
                WK.CartaAcessoItem.cartao_acesso_numero = Convert.ToInt32((txt_cartao_acesso_numero.Text));
                WK.CartaAcessoItem.cartao_acesso_validade_ini = dtpfilter_cartao_acesso_validade_ini.Value;
                WK.CartaAcessoItem.cartao_acesso_validade_fim = dtpfilter_cartao_acesso_validade_fim.Value;
                WK.CartaAcessoItem.cdpessoabluesoft = Convert.ToInt32(txt_cdpessoabluesoft.Text);

                if (chkfilter_cartao_acesso_status.Checked)
                    WK.CartaAcessoItem.cartao_acesso_status = 1; 
                else
                {
                    WK.CartaAcessoItem.cartao_acesso_status = 0; 
                }


                UserTools._Screen_Wait(this);
                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Consulta)
                    WK.CartaAcessoItem._DbUpdate(MyConnect);
                else
                    WK.CartaAcessoItem._DbInsert(MyConnect);
                UserTools._Screen_Wait(this);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Registro efetivado com sucesso");

                if (__Screen_Form_Action == Ctrl_Transporte_Form_Action.Inclusao)
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                throw new Exception(ex.Message);
            }
        }
        private void _BindingCartao()
        {
            try
            {

                WK.CartaAcessoItem._Binding(MyConnect);

                txtcartao_acesso_seq.Text = WK.CartaAcessoItem.cartao_acesso_seq.ToString();
                txt_cartao_acesso_cdbr.Text = WK.CartaAcessoItem.cartao_acesso_cdbr.ToString();
                // = WK.CartaAcessoItem.cartao_acesso_data.ToString("yyyy-MM-dd");
                lbl_cartao_visita_tipo_cd.Text  = WK.CartaAcessoItem.cartao_acesso_tipo_cd.ToString();
                txt_cartao_acesso_numero.Text = WK.CartaAcessoItem.cartao_acesso_numero.ToString();
                dtpfilter_cartao_acesso_validade_ini.Value = WK.CartaAcessoItem.cartao_acesso_validade_ini;
                dtpfilter_cartao_acesso_validade_fim.Value = WK.CartaAcessoItem.cartao_acesso_validade_fim;
                txt_cdpessoabluesoft.Text = WK.CartaAcessoItem.cdpessoabluesoft.ToString();
                cmbcartao_acesso_tipo.Text = WK.CartaAcessoItem.cartao_acesso_tipo_descricao;
                lbl_cartao_visita_tipo_cd.Text = WK.CartaAcessoItem.cartao_acesso_tipo_cd.ToString();
                if (WK.CartaAcessoItem.cartao_acesso_status == 1)
                    chkfilter_cartao_acesso_status.Checked = true;
                else
                    chkfilter_cartao_acesso_status.Checked = false;

                _ShowEAN();

            }
            catch(Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _BindingCartaoAcessoTipo()
        {
            try
            {
                
                txt_cartao_acesso_numero.Enabled = false;
                lbl_cartao_visita_tipo_cd.Text = "0";
                txt_cartao_acesso_cdbr.Text = "";
                txt_cartao_acesso_numero.Text = "";
                //picBarcode.Image = null;

                WK.CartaAcessoItem.cartao_acesso_tipo_cd = ((Pag_Net.Bll.F0137_CartaoAcesso.TbCartaoAcessoTipo)cmbcartao_acesso_tipo.SelectedItem).cartao_acesso_tipo_cd;
                if (WK.CartaAcessoItem.cartao_acesso_tipo_cd == 0)
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Informe o Tipo de Cartão");
                    return;
                }
                lbl_cartao_visita_tipo_cd.Text = WK.CartaAcessoItem.cartao_acesso_tipo_cd.ToString();

                WK.CartaAcessoItem._Binding_CodigoBarraNew(MyConnect);
                if (WK.CartaAcessoItem.cartao_acesso_tipo_cd == 20)
                {
                    txt_cartao_acesso_numero.Text = "";
                    txt_cartao_acesso_numero.Enabled = false;
                    txt_cartao_acesso_numero.Text = WK.CartaAcessoItem.cartao_acesso_numero.ToString();
                    txt_cartao_acesso_cdbr.Text  = WK.CartaAcessoItem.cartao_acesso_cdbr.ToString();
                    _ShowEAN();
                }

            }

            catch ( Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _ShowEAN()
        {
            WK.CartaAcessoItem._Binding_EAN();
            System.Drawing.Graphics g = this.picBarcode.CreateGraphics();
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control),
                new Rectangle(0, 0, picBarcode.Width, picBarcode.Height));
            WK.CartaAcessoItem.EAN.Scale = (float)Convert.ToDecimal(2.0);
            WK.CartaAcessoItem.EAN.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
            g.Dispose();
        }

        private void _ImprimirCartao()
        {
            try
            {
                _ShowEAN();
                //string file_image = MyConnect.Path_Spool + "CdBarraPrint.jpg";
                //picBarcode.Image.Save(@file_image, System.Drawing.Imaging.ImageFormat.Jpeg);

                //Bitmap pic = new Bitmap(picBarcode.ClientSize.Width, picBarcode.ClientSize.Height);
                //using (Graphics g = Graphics.FromImage(pic))
                //{
                //    //PictureBox1_Render(g);
                //    pic.Save(@file_image, System.Drawing.Imaging.ImageFormat.Png);
               // }
                //UserReports.CartaoAcesso(MyConnect, WK.CartaAcessoItem, @"D:\\Projects\\Pag\\Bin\\Ico\\LOGO.png");
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

    }
}
