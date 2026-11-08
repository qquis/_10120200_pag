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
    public partial class frm_SerraSol_Ticket : Form
    {
        Pag_Net.Models.modelSistemaUsuario Myconnect;
        Pag_Net.Bll.F0062_Guardian.Wk WK;
        Pag_Net.Bll.F0060_DocumentoFiscal.WkDocumentoFiscal WkDocumentoFiscal;
        public frm_SerraSol_Ticket(Pag_Net.Models.modelSistemaUsuario _Myconnect)
        {
            InitializeComponent();
            Myconnect = _Myconnect;
            WK = new Pag_Net.Bll.F0062_Guardian.Wk(Myconnect);
            WkDocumentoFiscal = new Pag_Net.Bll.F0060_DocumentoFiscal.WkDocumentoFiscal(Myconnect);
            WkDocumentoFiscal.DocumentoFiscalConsultarFilter.em_cdempresabluesoft = 991;
            WkDocumentoFiscal.DocumentoFiscalConsultarFilter.Entrada_Saida = "S";
            
            _Screen_load();
            
        }

        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_Form_Open(this);
                UserTools._Screen_ButtonImage(cmdPesquisar, UserTools.PagButtonsIcons.SetaSimples_Baixo);

                dtpgtk_data_inicial.ValueChanged += new EventHandler(_Screen_changed);
                dtpgtk_data_final.ValueChanged += new EventHandler(_Screen_changed);
                dtpgtk_data_final.ValueChanged += new EventHandler(_Screen_changed);
                txtgtk_numero.TextChanged += new EventHandler(_Screen_changed);

                dtpgtk_data_inicial.Value = DateTime.Now;
                dtpgtk_data_final.Value = DateTime.Now;

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label")
                {
                    if (((Label)sender).Name == "")
                    {
                        
                    }
                }
                if (sender.GetType().Name == "TextBox")
                {
                    if (((TextBox)sender).Name == "txtgtk_numero")
                    {
                        try
                        {
                            if (txtgtk_numero.Text != "")
                            {
                                WK.Filtros.gtk_numero = Convert.ToInt32(txtgtk_numero.Text.Trim());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Valor Inválido: " + ex.Message);
                            txtgtk_numero.Text = "";
                        }
                    }
                }
                if (sender.GetType().Name == "DateTimePicker")
                {

                    if (((DateTimePicker)sender).Name == "dtpgtk_data_inicial")
                    {
                        WK.Filtros.gtk_data_inicial = dtpgtk_data_inicial.Value;
                        WkDocumentoFiscal.DocumentoFiscalConsultarFilter.Data_Emissao_Inicial = dtpgtk_data_inicial.Value;
                        
                    }
                    if (((DateTimePicker)sender).Name == "dtpgtk_data_final")
                    {
                        WK.Filtros.gtk_data_final = dtpgtk_data_final.Value;
                        WkDocumentoFiscal.DocumentoFiscalConsultarFilter.Data_Emissao_Final = dtpgtk_data_final.Value;
                    }
                
                }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox") { }
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

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            Binding();
        }

        public void Binding()
        {
            try
            {
                lblvolume_total.Text = "0";
                lblvalor_mercadoria.Text = "0";
                lblvalor_nf.Text = "0";
                lblNumeroNotas.Text = "0";
                lblNumeroTickets.Text = "0";

                UserTools._Screen_Wait(this);

                dtgSerraSol_Tickets.DataSource = WK.ObterList();
                dtgNotasFiscais_SERRADOSOL.DataSource = WkDocumentoFiscal.DocumentoFiscalList_Get();
                UserTools._Screen_Wait(this, false);

                lblvolume_total.Text = WkDocumentoFiscal.VolumeTotal.ToString("#");
                lblvalor_mercadoria.Text = WkDocumentoFiscal.ValorMercadoriaNFTotal.ToString("#,##0.00");
                lblvalor_nf.Text = WkDocumentoFiscal.ValorMercadoriaNFTotal.ToString("#,##0.00");
                lblNumeroNotas.Text = WkDocumentoFiscal.NumeroDeRegistors.ToString();
                lblNumeroTickets.Text = WK.NumeroDeRegistros.ToString();
                
                if (WkDocumentoFiscal.NumeroDeRegistors != WK.NumeroDeRegistros)
                {
                    lblNumeroNotas.ForeColor = Color.Red;
                    lblNumeroTickets.ForeColor = Color.Red;
                }
                else
                {
                    lblNumeroNotas.ForeColor = Color.White;
                    lblNumeroTickets.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
