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
    public partial class frmUC_DocumentoFiscalRegistro : UserControl
    {

        public int __CONTROLE_REG_SEQ = 0;
        public int __CONTROLE_ETAPA_CD = 1;
        public Pag_Net.Bll.F0060_DocumentoFiscal.WkDocumentoFiscalRegistro WKDocumentoFiscal;
        
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        bool Exibe_CMD_Efetivar_lista;
        bool Exibe_CMD_Cancelar_Lista;

        public int __DocumentosFiscais_Count = 0;

        public event EventHandler EventHandler_Confirma_Lista;
        public event EventHandler EventHanlder_Incluir_Nota_Fiscal_No_Grid;

        public frmUC_DocumentoFiscalRegistro(Pag_Net.Models.modelSistemaUsuario _myConnect, bool _Exibe_CMD_Efetivar_lista, bool _Exibe_CMD_Cancelar_Lista)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            WKDocumentoFiscal = new Pag_Net.Bll.F0060_DocumentoFiscal.WkDocumentoFiscalRegistro(MyConnect);
            Exibe_CMD_Efetivar_lista = _Exibe_CMD_Efetivar_lista;
            Exibe_CMD_Cancelar_Lista = _Exibe_CMD_Cancelar_Lista;
            _Screen_load();
        }

        private void _Screen_load()
        {
            cmdnotasfiscais_incluir.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdnotasfiscais_efetivar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
            cmdlimpa.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\undo.ico");
            cmdcancela_lista.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\delete.ico");
            txtdfr_cnpj_cpf.LostFocus += new EventHandler(_Screen_lostFocus);
            txtdfr_nf_chave.LostFocus += new EventHandler(_Screen_lostFocus);
            txtdfr_nf_numero.LostFocus += new EventHandler(_Screen_lostFocus);
            txtdfr_nf_serie.LostFocus += new EventHandler(_Screen_lostFocus);
            dtpdata_emissao.LostFocus += new EventHandler(_Screen_lostFocus);
            dtgNotasFiscaisListas.AutoGenerateColumns = false;

            cmdcancela_lista.Visible = true;
            cmdnotasfiscais_efetivar.Visible = true;
            if (!Exibe_CMD_Cancelar_Lista) cmdcancela_lista.Visible = false;
            if (!Exibe_CMD_Efetivar_lista) cmdnotasfiscais_efetivar.Visible = false;

            dtpdata_emissao.Value = DateTime.Now;
            txtdfr_cnpj_cpf.Text = "0";
            txtdfr_nf_numero.Text = "0";
            txtdfr_nf_serie.Text = "0";
            txtdfr_nf_chave.Focus();

        }

        private void _Screen_lostFocus(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "TextBox")
                {
                    switch (((TextBox)sender).Name)
                    {
                        case "txtdfr_nf_chave":
                            WKDocumentoFiscal.Item.dfr_nf_chave = txtdfr_nf_chave.Text.ToString();
                            WKDocumentoFiscal.Item.dfr_nf_data_emissao = Convert.ToDateTime(dtpdata_emissao.Value.ToShortDateString());
                            break;
                        case "txtdfr_nf_numero":
                            WKDocumentoFiscal.Item.dfr_nf_numero = Convert.ToInt32(txtdfr_nf_numero.Text);
                            break;
                        case "txtdfr_nf_serie":
                            WKDocumentoFiscal.Item.dfr_nf_serie = Convert.ToInt32(txtdfr_nf_serie.Text);
                            break;
                        case "txtdfr_nf_data_emissao":
                            WKDocumentoFiscal.Item.dfr_nf_data_emissao = dtpdata_emissao.Value;
                            break;
                        case "txtdfr_cnpj_cpf":
                            WKDocumentoFiscal.Item.dfr_cnpj_cpf = txtdfr_cnpj_cpf.Text.ToString();
                            break;
                    }
                }

                if (sender.GetType().Name == "DateTimePicker")
                {
                    switch (((DateTimePicker)sender).Name)
                    {
                        case "dtpdata_emissao":
                            WKDocumentoFiscal.Item.dfr_nf_data_emissao = dtpdata_emissao.Value;
                            break;
                    }
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

        private void _pesquisar()
        {
            try
            {
                _databinding();

            }
            catch (Exception )
            {

            }

        }
        private void _databinding()
        {
            try
            {
                dtgNotasFiscaisListas.DataSource = WKDocumentoFiscal.ListaDeDocumentosFiscais;
                txtdfr_cnpj_cpf.Text = "0";
                txtdfr_nf_chave.Text = "0";
                txtdfr_nf_numero.Text = "0";
                txtdfr_nf_serie.Text = "0";
                txtdfr_nf_chave.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdnotasfiscais_incluir_Click(object sender, EventArgs e)
        {
            try
            {
                _DocumentoFiscaisRegistro_Incluir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO" + ex.Message);
            }

        }

        private void cmdnotasfiscais_efetivar_Click(object sender, EventArgs e)
        {
            try 
            {
                UserTools._Screen_Wait(this, true);
                Efetivar();
                UserTools._Screen_Wait(this, false);
                MessageBox.Show("Registros efetivados com sucesso");

                if (this.EventHandler_Confirma_Lista != null)
                {
                    this.EventHandler_Confirma_Lista(this, e);
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        public void Efetivar()
        {
            try
            {
                WKDocumentoFiscal.RegistroLista_Efetivar();
                WKDocumentoFiscal.RegistroLista_Clear();
                _databinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdlimpa_Click(object sender, EventArgs e)
        {
            _databinding();
        }

        private void cmdcancela_lista_Click(object sender, EventArgs e)
        {
            try
            {
                if ( MessageBox.Show("Deseja desconsiderar os itens lançados?", "PAG",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    WKDocumentoFiscal.RegistroLista_Clear();
                    _pesquisar();    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void txtdfr_nf_chave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13 )
            {
                try
                {
                    if (txtdfr_nf_chave.Text == "0" || txtdfr_nf_chave.Text.Trim() == "")
                    {
                        return;
                    }

                    WKDocumentoFiscal.Item.dfr_nf_chave = txtdfr_nf_chave.Text.ToString();
                    WKDocumentoFiscal.Item.dfr_nf_data_emissao = Convert.ToDateTime(dtpdata_emissao.Value.ToShortDateString());
                    _DocumentoFiscaisRegistro_Incluir();
                    txtdfr_nf_chave.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtdfr_nf_chave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtdfr_nf_chave.Text == "0" || txtdfr_nf_chave.Text.Trim() == "")
                    {
                        return;
                    }
                    WKDocumentoFiscal.Item.dfr_nf_chave = txtdfr_nf_chave.Text.ToString();
                    WKDocumentoFiscal.Item.dfr_nf_data_emissao = Convert.ToDateTime(dtpdata_emissao.Value.ToShortDateString());
                    _DocumentoFiscaisRegistro_Incluir();
                    txtdfr_nf_chave.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        
        
        public void _DocumentoFiscaisRegistroExterno_Incluir(Pag_Net.Bll.F0060_DocumentoFiscal.Db.TbDocumentoFiscalRegistro item)
        {
            WKDocumentoFiscal.Item.dfr_nf_chave = item.dfr_nf_chave;
            WKDocumentoFiscal.Item.dfr_nf_numero = item.dfr_nf_numero;
            WKDocumentoFiscal.Item.dfr_nf_serie = item.dfr_nf_serie;
            WKDocumentoFiscal.Item.dfr_nf_data_emissao = item.dfr_nf_data_emissao;
            WKDocumentoFiscal.Item.dfr_cnpj_cpf = item.dfr_cnpj_cpf;
            WKDocumentoFiscal.Item.controle_reg_seq = __CONTROLE_REG_SEQ;
            _DocumentoFiscaisRegistro_Incluir();
        }
        private void _DocumentoFiscaisRegistro_Incluir()
        {
            try
            {
                UserTools._Screen_Wait(this, true);
                WKDocumentoFiscal.RegistroLista_Incluir();
                _pesquisar();
                __DocumentosFiscais_Count = WKDocumentoFiscal.ListaDeDocumentosFiscais.Count();
                if (this.EventHanlder_Incluir_Nota_Fiscal_No_Grid != null)
                {
                    this.EventHanlder_Incluir_Nota_Fiscal_No_Grid(this, null);
                }
                UserTools._Screen_Wait(this, false);

            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                MessageBox.Show(ex.Message);
            }
        }
    }




}
