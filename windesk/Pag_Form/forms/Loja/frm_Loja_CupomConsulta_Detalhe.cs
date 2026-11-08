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
    public partial class frm_Loja_CupomConsulta_Detalhe : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0055_Faturamento_Zanthus.WkFaturamento_Zanthus_CupomFiscal WkFaturamento_Zanthus_CupomFiscal;



        public frm_Loja_CupomConsulta_Detalhe(Pag_Net.Models.modelSistemaUsuario _MyConnect, int _ECF_SAT_Numero, int _NumeroCupom, DateTime _DataCUPOM)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load();

            

            WkFaturamento_Zanthus_CupomFiscal = new Pag_Net.Bll.F0055_Faturamento_Zanthus.WkFaturamento_Zanthus_CupomFiscal(MyConnect);

            txtNumeroCupomFiscal.Text = _NumeroCupom.ToString();
            cmbECF_SAT.Text = _ECF_SAT_Numero.ToString();
            dtpDataCupomFiscal.Value = _DataCUPOM;
            Binding();
        }
        private void _Screen_load()
        {
            try
            {
                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                dtpDataCupomFiscal.Value = DateTime.Now;
                dtpDataCupomFiscal.ValueChanged += new EventHandler(_Screen_changed);
                txtNumeroCupomFiscal.TextChanged += new EventHandler(_Screen_changed);
                cmbECF_SAT.TextChanged += new EventHandler(_Screen_changed);
                dtgZanthusCupomItens.AutoGenerateColumns = false;

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }


        private void Binding()
        {
            try
            {
                _Screen_wait(true);

                dtgZanthusCupomItens.DataSource = null;
                lblseqfaturamento.Text = "";
                lblfat_zanthus_data_m00af.Text = "";
                lblfat_zanthus_cupomfiscal_m00ad.Text = "";

                WkFaturamento_Zanthus_CupomFiscal.Consultar();

                lblseqfaturamento.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.seqfaturamento.ToString();
                lblfat_zanthus_data_m00af.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_data_m00af.ToString("dd/MM/yyyy");
                lblfat_zanthus_sat_ecf_m00ac.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_sat_ecf_m00ac.ToString();
                lblfat_zanthus_cupomfiscal_m00ad.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_cupomfiscal_m00ad.ToString();
                txtfat_zanthus_notafiscal_chave_m45xb.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_notafiscal_chave_m45xb.ToString();

                

                lblfat_zanthus_hora_ini_m45ai.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_hora_ini_m45ai.ToString("HH:mm");
                lblfat_zanthus_hora_fim_m45au.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_hora_fim_m45au.ToString("HH:mm");

                lblTempoPedagio.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.Tempo_de_Pedagio.ToString("mm");
                lblcpf.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_cpf_cnpj_m45bv.ToString(); 

                lblfat_zanthus_voucher_cod_m50ar.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_voucher_cod_m50ar.ToString();
                lblfat_zanthus_voucher_count_m50ag.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_voucher_count_m50ag.ToString();
                lblfat_zanthus_voucher_valor_m50at.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_voucher_valor_m50at.ToString("0.00");
                lblfat_zanthus_item_valor_desconto_m43aq.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_item_valor_desconto_m43aq.ToString("0.00");
                lblfat_zanthus_item_valor_m43ap.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_item_valor_m43ap.ToString("0.00");
                lblfat_zanthus_cupomfiscal_valor_m45ak.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.fat_zanthus_cupomfiscal_valor_m45ak.ToString("0.00");
                lblvoucher_descricao.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.voucher_descricao.ToString();
                lblzanthus_nome_funcionario.Text = WkFaturamento_Zanthus_CupomFiscal.CupomFiscal.zanthus_nome_funcionario.ToString();
                dtgZanthusCupomItens.DataSource = WkFaturamento_Zanthus_CupomFiscal.Itens;

                /*
                lblseqfaturamento.DataBindings.Clear();
                lblseqfaturamento.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "seqfaturamento");

 

                lblfat_zanthus_data_m00af.DataBindings.Clear();
                lblfat_zanthus_data_m00af.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_data_m00af", true, DataSourceUpdateMode.Never, null, "dd/MM/yyyy");

                lblfat_zanthus_sat_ecf_m00ac.DataBindings.Clear();
                lblfat_zanthus_sat_ecf_m00ac.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_sat_ecf_m00ac");
                lblfat_zanthus_cupomfiscal_m00ad.DataBindings.Clear();
                lblfat_zanthus_cupomfiscal_m00ad.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_cupomfiscal_m00ad");
                txtfat_zanthus_notafiscal_chave_m45xb.DataBindings.Clear();
                txtfat_zanthus_notafiscal_chave_m45xb.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_notafiscal_chave_m45xb");
                lblfat_zanthus_hora_ini_m45ai.DataBindings.Clear();
                lblfat_zanthus_hora_ini_m45ai.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_hora_ini_m45ai", true, DataSourceUpdateMode.Never, null, "HH:mm");
                lblfat_zanthus_hora_fim_m45au.DataBindings.Clear();
                lblfat_zanthus_hora_fim_m45au.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_hora_fim_m45au", true, DataSourceUpdateMode.Never, null, "HH:mm");

                lblzanthus_nome_funcionario.DataBindings.Clear();
                lblzanthus_nome_funcionario.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "zanthus_nome_funcionario", true, DataSourceUpdateMode.Never, null, "HH:mm");

                lblfat_zanthus_voucher_cod_m50ar.DataBindings.Clear();
                lblfat_zanthus_voucher_cod_m50ar.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_voucher_cod_m50ar");

                lblfat_zanthus_voucher_count_m50ag.DataBindings.Clear();
                lblfat_zanthus_voucher_count_m50ag.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_voucher_count_m50ag");

                lblfat_zanthus_voucher_valor_m50at.DataBindings.Clear();
                lblfat_zanthus_voucher_valor_m50at.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_voucher_valor_m50at", true, DataSourceUpdateMode.Never, null, "#,##0.00");

                lblfat_zanthus_item_valor_desconto_m43aq.DataBindings.Clear();
                lblfat_zanthus_item_valor_desconto_m43aq.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_item_valor_desconto_m43aq", true, DataSourceUpdateMode.Never, null, "#,##0.00");

                lblfat_zanthus_item_valor_m43ap.DataBindings.Clear();
                lblfat_zanthus_item_valor_m43ap.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_item_valor_m43ap", true, DataSourceUpdateMode.Never, null, "#,##0.00");


                lblfat_zanthus_cupomfiscal_valor_m45ak.DataBindings.Clear();
                lblfat_zanthus_cupomfiscal_valor_m45ak.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_cupomfiscal_valor_m45ak", true, DataSourceUpdateMode.Never, null, "#,##0.00");

                lblvoucher_descricao.DataBindings.Clear();
                lblvoucher_descricao.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "voucher_descricao");
                 */



                _Screen_wait(false);
            }
            catch (Exception ex)
            {
                _Screen_wait(false);
                MessageBox.Show(ex.Message);
            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {

                if (sender.GetType().Name == "RadioButton") { }
                if (sender.GetType().Name == "Label") { if (((Label)sender).Name == "") { } }
                if (sender.GetType().Name == "TextBox")
                {
                    if (((TextBox)sender).Name == "txtNumeroCupomFiscal")
                    {
                        if (txtNumeroCupomFiscal.Text.Trim() != "")
                        {
                            WkFaturamento_Zanthus_CupomFiscal.NumeroCupomFiscal = Convert.ToInt32(txtNumeroCupomFiscal.Text);
                        }
                    }
                }
                if (sender.GetType().Name == "DateTimePicker")
                {
                    if (((DateTimePicker)sender).Name == "dtpDataCupomFiscal")
                    {
                        WkFaturamento_Zanthus_CupomFiscal.Data = dtpDataCupomFiscal.Value;
                    }
                }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox") 
                {

                    if (((ComboBox)sender).Name == "cmbECF_SAT")
                    {
                        if (cmbECF_SAT.Text.Trim() != "")
                        WkFaturamento_Zanthus_CupomFiscal.Sat_ECF = Convert.ToInt32(cmbECF_SAT.Text);
                    }                  
                
                }

            }

            catch (Exception ErroMessage)
            {
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

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Binding();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
