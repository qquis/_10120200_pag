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
    public partial class frm_Loja_CupomConsulta : Form
    {
        bool tarefa_414101_Permite_Processamento = false;
        bool tarefa_414102_Permite_Excluir_SEQ_PROCESSAMENTO = false;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0055_Faturamento_Zanthus.WkFaturamento_Zanthus WKFaturamento_Zanthus;
        Pag_Net.Bll.F0105_Zanthus.Wk WkZanthus;
        public frm_Loja_CupomConsulta( Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {

            InitializeComponent();
            MyConnect = _MyConnect;
            WKFaturamento_Zanthus = new Pag_Net.Bll.F0055_Faturamento_Zanthus.WkFaturamento_Zanthus(MyConnect);
            WkZanthus = new Pag_Net.Bll.F0105_Zanthus.Wk(MyConnect);
            _Screen_load();
        }


        private void _Screen_load()
        {
            try
            {
                tarefa_414101_Permite_Processamento = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 414101);
                tarefa_414102_Permite_Excluir_SEQ_PROCESSAMENTO = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 414102);


                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                cmdConsultarVouchers.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdConsultar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
                cmbDetalheCupom.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\detalhe.ico");
                cmdAtualizacao.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdExcluirPag_Faturamento.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\delete.ico");
                dtpdata_m00af_inicial.ValueChanged += new EventHandler(_Screen_changed);
                dtpdata_m00af_final.ValueChanged += new EventHandler(_Screen_changed);
                txtvalor_cupom_ini.TextChanged += new EventHandler(_Screen_changed);
                txtvalor_cupom_fim.TextChanged += new EventHandler(_Screen_changed);
                txtvalor_desconto_ini.TextChanged += new EventHandler(_Screen_changed);
                txtvalor_desconto_fim.TextChanged += new EventHandler(_Screen_changed);
                txtcupomfiscal_m00ad.TextChanged += new EventHandler(_Screen_changed);
                cmbSat_Ecf_m00ac.TextChanged += new EventHandler(_Screen_changed);

                chkCancelado.CheckedChanged += new EventHandler(_Screen_changed);
                chkComCPF.CheckedChanged += new EventHandler(_Screen_changed);
                chkSem_Lancamento_PAG.CheckedChanged += new EventHandler(_Screen_changed);
                
                chkCancelado.Checked = false;
                chkComCPF.Checked = false;
                chkSem_Lancamento_PAG.Checked = false;

                dtpdata_m00af_inicial.Value = DateTime.Now;
                dtpdata_m00af_final.Value = DateTime.Now;
                dtgZanthusCupom.AutoGenerateColumns = false;
                dtgECF.AutoGenerateColumns = false;

                cmdAtualizacao.Enabled = false;
                cmdExcluirPag_Faturamento.Enabled = false;

                if (tarefa_414101_Permite_Processamento) cmdAtualizacao.Enabled = true;
                if (tarefa_414102_Permite_Excluir_SEQ_PROCESSAMENTO) cmdExcluirPag_Faturamento.Enabled = true;

                dtgZanthusCupom.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(DG_ColumnHeaderMouseClick);

                optgrafico_dado_Venda.Checked = true;
                opttipo_grafico_venda_hora.Checked = true;

                opttipo_grafico_venda_hora.CheckedChanged += new EventHandler(_Screen_changed);
                opttipo_grafico_venda_voucher.CheckedChanged += new EventHandler(_Screen_changed);
                optgrafico_dado_clientes.CheckedChanged += new EventHandler(_Screen_changed);
                optgrafico_dado_Venda.CheckedChanged += new EventHandler(_Screen_changed);

          
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void DataBinding()
        {
            try
            {
                _Screen_wait(true);
                if (txt_cd_barra_item_contem.Text.Trim() != "")
                {
                    WKFaturamento_Zanthus.Filtros.cd_barra_item_contem = txt_cd_barra_item_contem.Text;
                }
                else
                {
                    WKFaturamento_Zanthus.Filtros.cd_barra_item_contem = "";
                }



                WKFaturamento_Zanthus.Binding();
                dtgZanthusCupom.DataSource = WKFaturamento_Zanthus.Cupons_List;
                dtgECF.DataSource = WKFaturamento_Zanthus.ECF_Operadora_List;
                
                Binding_Grafico();
                Binding();
                

                _Screen_wait(false);
            }
            catch (Exception ex)
            {
                _Screen_wait(false);
                MessageBox.Show(ex.Message);
            }

        }

        private void Binding_Grafico()
        {
            try
            {

                if (optgrafico_dado_Venda.Checked)
                chart_venda_hora.Series[0].YValueMembers = "fat_zanthus_cupomfiscal_valor_m45ak";
                if (optgrafico_dado_clientes.Checked)
                chart_venda_hora.Series[0].YValueMembers = "fat_zanthus_cupomfiscal_m00ad";


                chart_venda_hora.DataSource = null;
                if (opttipo_grafico_venda_hora.Checked)
                    chart_venda_hora.DataSource = WKFaturamento_Zanthus.HORA_List;
                if (opttipo_grafico_venda_voucher.Checked)
                    chart_venda_hora.DataSource = WKFaturamento_Zanthus.Voucher_List;
                chart_venda_hora.DataBind();

                
             
            }
            catch (Exception ex)
            {
                _Screen_wait(false);
                MessageBox.Show(ex.Message);
            }

        }


        private void Binding()
        {
            try
            {
                _Screen_wait(true);

                //WKFaturamento_Zanthus.Cupons_List[0].fat_zanthus_data_m00af

                lblfat_zanthus_data_m00af.DataBindings.Clear();
                lblfat_zanthus_data_m00af.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_data_m00af", true, DataSourceUpdateMode.Never, null, "dd/MM/yyyy");

                lblfat_zanthus_cpf_cnpj_m45bv.DataBindings.Clear();
                lblfat_zanthus_cpf_cnpj_m45bv.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_cpf_cnpj_m45bv");
                lblseqfaturamento.DataBindings.Clear();
                lblseqfaturamento.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "seqfaturamento");
                lblfat_zanthus_sat_ecf_m00ac.DataBindings.Clear();
                lblfat_zanthus_sat_ecf_m00ac.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_sat_ecf_m00ac");
                lblfat_zanthus_cupomfiscal_m00ad.DataBindings.Clear();
                lblfat_zanthus_cupomfiscal_m00ad.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_cupomfiscal_m00ad");
                txtfat_zanthus_notafiscal_chave_m45xb.DataBindings.Clear();
                txtfat_zanthus_notafiscal_chave_m45xb.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_notafiscal_chave_m45xb");
                lblfat_zanthus_hora_ini_m45ai.DataBindings.Clear();
                lblfat_zanthus_hora_ini_m45ai.DataBindings.Add("Text", WKFaturamento_Zanthus.Cupons_List, "fat_zanthus_hora_ini_m45ai",true,DataSourceUpdateMode.Never, null, "HH:mm");
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
                

                lblvalor_base_total.Text = WKFaturamento_Zanthus.valor_base_total.ToString("#,###,##0.00");
                lblvalor_desconto_total.Text = WKFaturamento_Zanthus.valor_desconto_total.ToString("#,###,##0.00");
                lblvalor_total.Text = WKFaturamento_Zanthus.valor_total.ToString("#,###,##0.00");
                lbltotalcupons.Text = WKFaturamento_Zanthus.Cupons_List.Count().ToString();
                _Screen_wait(false);

            }
            catch (Exception ex)
            {
                _Screen_wait(false);
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            DataBinding();
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {

                if (sender.GetType().Name == "RadioButton") 
                { 
                      Binding_Grafico();
                
                }

                if (sender.GetType().Name == "Label") { if (((Label)sender).Name == "") { } }
                if (sender.GetType().Name == "TextBox")
                {


                    if (((TextBox)sender).Name == "txtcupomfiscal_m00ad")
                    {
                        if (txtcupomfiscal_m00ad.Text.Trim() != "")
                        {
                            WKFaturamento_Zanthus.Filtros.cupomfiscal_m00ad = Convert.ToInt32(txtcupomfiscal_m00ad.Text);
                        }
                        else
                        {
                            WKFaturamento_Zanthus.Filtros.cupomfiscal_m00ad = 0;
                        }
                    }


                    if (((TextBox)sender).Name == "txtvalor_cupom_ini")
                    {
                        if (txtvalor_cupom_ini.Text != "") 
                        {
                            WKFaturamento_Zanthus.Filtros.vvalor_cupom_ini = Convert.ToDouble(txtvalor_cupom_ini.Text);
                        }
                        else 
                        {
                            WKFaturamento_Zanthus.Filtros.vvalor_cupom_ini =0;
                        }
                    }
                    

                    if (((TextBox)sender).Name == "txtvalor_cupom_fim")
                    {
                        if (txtvalor_cupom_fim.Text != "") 
                        {
                            WKFaturamento_Zanthus.Filtros.vvalor_cupom_fim = Convert.ToDouble(txtvalor_cupom_fim.Text);
                        }
                        else 
                        {
                            WKFaturamento_Zanthus.Filtros.vvalor_cupom_fim =0;
                        }
                    }


                    if (((TextBox)sender).Name == "txtvalor_desconto_ini")
                    {
                        if (txtvalor_desconto_ini.Text != "")
                        {
                            WKFaturamento_Zanthus.Filtros.vvalor_desconto_ini = Convert.ToDouble(txtvalor_desconto_ini.Text);
                        }
                        else
                        {
                            WKFaturamento_Zanthus.Filtros.vvalor_desconto_ini = 0;
                        }
                    }

                    if (((TextBox)sender).Name == "txtvalor_desconto_fim")
                    {
                        if (txtvalor_desconto_fim.Text != "")
                        {
                            WKFaturamento_Zanthus.Filtros.vvalor_desconto_fim = Convert.ToDouble(txtvalor_desconto_fim.Text);
                        }
                        else
                        {
                            WKFaturamento_Zanthus.Filtros.vvalor_desconto_fim = 0;
                        }
                    }    
                }
                if (sender.GetType().Name == "DateTimePicker")
                {
                    if (((DateTimePicker)sender).Name == "dtpdata_m00af_inicial")
                    {
                        WKFaturamento_Zanthus.Filtros.data_m00af_inicial = dtpdata_m00af_inicial.Value;
                    }
                    if (((DateTimePicker)sender).Name == "dtpdata_m00af_final")
                    {
                        WKFaturamento_Zanthus.Filtros.data_m00af_final = dtpdata_m00af_final.Value;
                    }
                }
                if (sender.GetType().Name == "CheckBox") 
                { 
                    
                    if (((CheckBox)sender).Name == "chkCancelado")
                    {
                        if (chkCancelado.Checked)
                        {
                            WKFaturamento_Zanthus.Filtros.status_cancelado = 1;
                        }
                        else
                        {
                            WKFaturamento_Zanthus.Filtros.status_cancelado = 0;
                        }
                    }


                    if (((CheckBox)sender).Name == "chkComCPF")
                    {
                        if (chkComCPF.Checked)
                        {
                            WKFaturamento_Zanthus.Filtros.vstatus_com_cpf = 1;
                        }
                        else
                        {
                            WKFaturamento_Zanthus.Filtros.vstatus_com_cpf = 0;
                        }
                    }

                    if (((CheckBox)sender).Name == "chkSem_Lancamento_PAG")
                    {
                        if (chkSem_Lancamento_PAG.Checked)
                        {
                            WKFaturamento_Zanthus.Filtros.vstatus_processamento = 1;
                        }
                        else
                        {
                            WKFaturamento_Zanthus.Filtros.vstatus_processamento = 0;
                        }
                    }
                
                
                }
                if (sender.GetType().Name == "ComboBox") 
                {
    

                    if (((ComboBox)sender).Name == "cmbSat_Ecf_m00ac")
                    {
                        if (cmbSat_Ecf_m00ac.Text.Trim() != "")
                        {
                            WKFaturamento_Zanthus.Filtros.Sat_ECF_m00ac = Convert.ToInt32(cmbSat_Ecf_m00ac.Text);
                        }
                        else
                        {
                            WKFaturamento_Zanthus.Filtros.Sat_ECF_m00ac = 0;
                        }
                    }
                
                }
                
            }

            catch (Exception ErroMessage)
            {
                if (sender.GetType().Name == "TextBox") { ((TextBox)sender).Text = "0"; }
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

        private void cmdConsultarVouchers_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(true);
                WkZanthus.Filtros.voucher_cliente = lblfat_zanthus_cpf_cnpj_m45bv.Text;
                dtgvoucher.DataSource = WkZanthus.Voucher_Promocional_Consultar();
                _Screen_wait(false);
            }
            catch (Exception ex)
            {
                _Screen_wait(false);
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdExcluirPag_Faturamento_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Confirma Exclusão do Relacionamento PAG? ", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                _Screen_wait(true);
                int _seqfaturamento = Convert.ToInt32(lblseqfaturamento.Text);
                WKFaturamento_Zanthus.Excluir(_seqfaturamento);
                _Screen_wait(false);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdAtualizacao_Click(object sender, EventArgs e)
        {
            try
            {
                //frm_Loja_CupomProcessamento frm = new frm_Loja_CupomProcessamento(MyConnect);
                //frm.ShowDialog();
                    frm_Loja_CupomECF_Processamento frmproc = new frm_Loja_CupomECF_Processamento(MyConnect);
                    frmproc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DG_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                _Screen_wait(true);
                string strColumnName = dtgZanthusCupom.Columns[e.ColumnIndex].DataPropertyName;
                WKFaturamento_Zanthus.OrderBy(strColumnName);
                dtgZanthusCupom.DataSource = WKFaturamento_Zanthus.Cupons_List;
                Binding();
                _Screen_wait(false);
            }
            catch (Exception ex)
            {
                _Screen_wait(false);
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbDetalheCupom_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {

                if (lblfat_zanthus_sat_ecf_m00ac.Text.Trim() != "" && lblfat_zanthus_cupomfiscal_m00ad.Text.Trim() != "") 
                {
                    error = "Não foi possível indicar o Número ECF (label info): " + lblfat_zanthus_sat_ecf_m00ac.Text;
                    int NUMERO_ECF = Convert.ToInt32(lblfat_zanthus_sat_ecf_m00ac.Text);
                    error = "Não foi possível indicar o Número Cupom (label info): " + lblfat_zanthus_cupomfiscal_m00ad.Text;
                    int NUMERO_CUPOM = Convert.ToInt32(lblfat_zanthus_cupomfiscal_m00ad.Text);
                    error = "";
                    error = "Não foi possível indicar a data do cupom (label info): " + lblfat_zanthus_data_m00af.Text;
                    DateTime DataCUPOM = Convert.ToDateTime(lblfat_zanthus_data_m00af.Text);

                    _Screen_wait(true);
                    frm_Loja_CupomConsulta_Detalhe _frm_Loja_CupomConsulta_Detalhe = new frm_Loja_CupomConsulta_Detalhe(MyConnect, NUMERO_ECF, NUMERO_CUPOM, DataCUPOM);
                    _Screen_wait(false);
                    _frm_Loja_CupomConsulta_Detalhe.ShowDialog();

                }
                else 
                {
                    _Screen_wait(false);
                    MessageBox.Show("Número ECF/Cupom Fiscal não indicado");
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n" + error);
            }
        }

        private void cmdReprocessarECF_Click(object sender, EventArgs e)
        {

        }

    }
}
