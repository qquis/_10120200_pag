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
    public partial class frm_DocumentoFiscalRegistro : Form
    {
        Pag_Net.Models.modelSistemaUsuario Myconnect;
        Pag_Form.user_control.frmUC_DocumentoFiscalRegistro frmUC_DocumentoFiscalRegistro;

        //Pag_Net.Bll.DocumentoFiscalRegistro.Pool BLL;
        Pag_Net.Bll.F0060_DocumentoFiscal.WkDocumentoFiscalRegistro WK;

        public frm_DocumentoFiscalRegistro(Pag_Net.Models.modelSistemaUsuario _myconnect)
        {
            InitializeComponent();
            Myconnect = _myconnect;

            frmUC_DocumentoFiscalRegistro = new Pag_Form.user_control.frmUC_DocumentoFiscalRegistro(Myconnect, true, true );

            WK = new Pag_Net.Bll.F0060_DocumentoFiscal.WkDocumentoFiscalRegistro(Myconnect);

            _Screen_load();
        }

        private void _Screen_load()
        {
            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            cmdDocumentoFiscal_Registro_Consulta.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
            cmbStatusNfeManifestacao.DisplayMember = "statusNfe_descricao";
            cmbStatusNfeManifestacao.ValueMember = "statusNfe_id";
            cmbStatusNfeManifestacao.DataSource = Pag_Net.Models.ListStatusNfe.get();

            /*USER CONTROL*/
            frmUC_DocumentoFiscalRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            frmUC_DocumentoFiscalRegistro.Location = new System.Drawing.Point(60, 30);
            frmUC_DocumentoFiscalRegistro.Name = "frmUC_DocumentoFiscalRegistro";
            frmUC_DocumentoFiscalRegistro.Size = new System.Drawing.Size(782, 373);
            frmUC_DocumentoFiscalRegistro.TabIndex = 0;
            //this.Controls.Add(frmUC_DocumentoFiscalRegistro);

            tabRecebimento.Controls.Add(frmUC_DocumentoFiscalRegistro);

            dtp_registro_data_ini.ValueChanged += new EventHandler(_Screen_changed);
            dtp_registro_data_fim.ValueChanged += new EventHandler(_Screen_changed);


            chkLancada.Checked = false;
            
            WK.DocumentoFiscalRegistroList_Filter.DocumentoFiscalNAOProcessado = 0;
            chkRecebida.Checked = false;
            WK.DocumentoFiscalRegistroList_Filter.DocumentoFiscalNAORecebida = 0;
            
            chkLancada.CheckedChanged += new EventHandler(_Screen_changed);
            chkRecebida.CheckedChanged += new EventHandler(_Screen_changed);

            WK.DocumentoFiscalRegistroList_Filter.StatusNfManifestacao = 0;

            dtp_registro_data_ini.Value = DateTime.Now.AddDays(-15);
            WK.DocumentoFiscalRegistroList_Filter.Data_Inicial_Registro = dtp_registro_data_ini.Value;
            
            dtp_registro_data_fim.Value = DateTime.Now.AddDays(1);
            WK.DocumentoFiscalRegistroList_Filter.Data_Final_Registro = dtp_registro_data_fim.Value;

            dtgNotasFiscaisListas_Consulta.AutoGenerateColumns = false;


        }

        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "TextBox")
                {
                }

                if (sender.GetType().Name == "DateTimePicker")
                {
                    switch (((DateTimePicker)sender).Name)
                    {
                        case "dtp_registro_data_ini":
                            WK.DocumentoFiscalRegistroList_Filter.Data_Inicial_Registro = dtp_registro_data_ini.Value;
                            break;
                        case "dtp_registro_data_fim":
                            WK.DocumentoFiscalRegistroList_Filter.Data_Final_Registro = dtp_registro_data_fim.Value;
                            break;
                    }
                }

                if (sender.GetType().Name == "CheckBox")
                {
                    switch (((CheckBox)sender).Name)
                    {
                        case "chkLancada":
                            if (chkLancada.Checked)
                                WK.DocumentoFiscalRegistroList_Filter.DocumentoFiscalNAOProcessado = 1; 
                            else
                                WK.DocumentoFiscalRegistroList_Filter.DocumentoFiscalNAOProcessado = 0; 
                            break;
                        case "chkRecebida":
                            if (chkRecebida.Checked)
                                WK.DocumentoFiscalRegistroList_Filter.DocumentoFiscalNAORecebida = 1;
                            else
                                WK.DocumentoFiscalRegistroList_Filter.DocumentoFiscalNAORecebida = 0;
                            break;
                    }
                }


                if (sender.GetType().Name == "ComboBox")
                {
                    if ((((CheckBox)sender).Name) == "cmbStatusNfeManifestacao")
                        WK.DocumentoFiscalRegistroList_Filter.StatusNfManifestacao = Convert.ToInt32(cmbStatusNfeManifestacao.SelectedValue.ToString());

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

        private void cmdDocumentoFiscal_Registro_Consulta_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                dtgNotasFiscaisListas_Consulta.DataSource = WK.DocumentoFiscalRegistroList_Consultar();
                UserTools._Screen_Wait(this, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
