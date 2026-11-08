using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.demontrativo.faturamento.Operacional
{
    public partial class m5112_Faturamento_Consulta_Listagem : Form
    {

        private static int _SIS_AC_CD = 5111;

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        
        
        /// <summary>
        /// CLASSES MANAGMENT 
        /// </summary>
        Pag_Net.Bll.F0002_Enterprise.WkEmpresaOperacao __srcEmpresaOperacao;
        Pag_Net.src.F0070_Faturamento._indexReport F0070_Faturamento_Report;
        
        
        
        public m5112_Faturamento_Consulta_Listagem(Pag_Net.Models.modelSistemaUsuario _Myconnect)
        {
            InitializeComponent();
            MyConnect = _Myconnect;
            _Screen_load();
        }


        /// <summary>
        /// Screen_FORMAT 
        /// </summary>
        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_Form_Open(this);
                _Screen_load_format();

                /*Class Management open*/
                F0070_Faturamento_Report = new Pag_Net.src.F0070_Faturamento._indexReport(MyConnect);
                F0070_Faturamento_Report.PropertyChanged += _dataBinding;

                __srcEmpresaOperacao = new Pag_Net.Bll.F0002_Enterprise.WkEmpresaOperacao(MyConnect);
                __srcEmpresaOperacao.Filter_EmpresaOperacao.sis_ac_cd = _SIS_AC_CD;
                __srcEmpresaOperacao.EmpresaOperacoes_User_List_DataBindings();

                cmbEmpresa.DataSource = __srcEmpresaOperacao.List_User_Empresa;
                cmbEmpresa.SelectedValueChanged += new EventHandler(_Screen_changed);
                cmbEmpresa.SelectedIndex = 0;
                _DataBinding_EmpresaSelect();

                cmbOperacao.SelectedValueChanged += new EventHandler(_Screen_changed);

                /*BINDING FATURAMENTO STATUS _ INICIAR COMO FATURADO*/
                F0070_Faturamento_Report.getFaturamentoStatus(1);
                cmbFaturamentoStatus.SelectedIndex = 2;
                cmbFaturamentoStatus.SelectedValueChanged += new EventHandler(_Screen_changed);

                /*Data Faturamento*/
                chkDataFaturamento.CheckedChanged += new EventHandler(_Screen_changed);
                dtpdatafaturamento_ini.ValueChanged += new EventHandler(_Screen_changed);
                dtpdatafaturamento_ini.DataBindings.Add("Enabled", chkDataFaturamento, "Checked");
                dtpdatafaturamento_fim.ValueChanged += new EventHandler(_Screen_changed);
                dtpdatafaturamento_fim.DataBindings.Add("Enabled", chkDataFaturamento, "Checked");
                chkDataFaturamento.Checked = true;

                /*Data Emissao*/
                chkDataEmissao.CheckedChanged += new EventHandler(_Screen_changed);
                dtpDataEmissao_Ini.ValueChanged += new EventHandler(_Screen_changed);
                dtpDataEmissao_Ini.DataBindings.Add("Enabled", chkDataEmissao, "Checked");
                dtpDataEmissao_Fim.ValueChanged += new EventHandler(_Screen_changed);
                dtpDataEmissao_Fim.DataBindings.Add("Enabled", chkDataEmissao, "Checked");
                chkDataEmissao.Checked = false;
   
            }
            catch (Exception ex) 
            {
                UserTools._Screen_MessageBox(this, ex);    
            }
        }
        private void _Screen_load_format()
        {
            foreach (System.Windows.Forms.DataGridViewColumn col in dtgf.Columns)
            {
                col.DataPropertyName = col.Name.Substring(5, col.Name.Length - 5);

            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {


                if (sender.GetType().Name == "ComboBox")
                {
                    switch (((ComboBox)sender).Name)
                    {
                      
                        case "cmbEmpresa":
                            _DataBinding_EmpresaSelect();
                            break;
                        case "cmbFaturamentoStatus":
                            //_BLL_Faturamento._filter.statusfaturamento = Convert.ToInt32(cmbFaturamentoStatus.SelectedValue);
                            switch (Convert.ToInt32(cmbFaturamentoStatus.SelectedValue))
                            {
                                case 0:
                                    chkDataFaturamento.Checked = false;
                                    chkDataFaturamento.Enabled = false;
                                    chkDataEmissao.Checked = true;
                                    chkDataEmissao.Enabled = false;
                                    break;
                                case 1:
                                    chkDataFaturamento.Checked = true;
                                    chkDataFaturamento.Enabled = false;
                                    chkDataEmissao.Checked = false;
                                    chkDataEmissao.Enabled = false;
                                    break;

                                case 99:
                                    chkDataFaturamento.Checked = true;
                                    chkDataFaturamento.Enabled = true;
                                    chkDataEmissao.Checked = false;
                                    chkDataEmissao.Enabled = true;
                                    break;
                            }
                            break;
                    }
                }

                lblEmpresa.Text = "Empresa: " + cmbEmpresa.Text;

                lblOperacao.Text = "Operação: " + cmbOperacao.Text;
            }

            catch (Exception ErroMessage)
            {
                if (sender.GetType().Name == "TextBox") { ((TextBox)sender).Text = "0"; }
                MessageBox.Show(ErroMessage.Message);
            }
        }


        private void _dataBinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "rptfaturamentoStatus")
                {
                    cmbFaturamentoStatus.DataSource = F0070_Faturamento_Report.rptfaturamentoStatus.report;
                }

                if (e.PropertyName == "rptFaturamentoConsulta")
                {
                    dtgf.DataSource = F0070_Faturamento_Report.rptfaturamentoConsulta.report;
                    lbl_total_registros.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.Count.ToString();
                    UserTools._Screen_DataBinding_Set(lbl_seqfaturamento, dtgf.DataSource, "seqfaturamento");
                    UserTools._Screen_DataBinding_Set(lbl_seqfaturamentoorigem, dtgf.DataSource, "seqfaturamentoorigem");
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _DataBinding_EmpresaSelect()
        {
            cmbOperacao.DataSource = __srcEmpresaOperacao.Operacao_User_List_Get(((Pag_Net.Bll.F0002_Enterprise.TbEmpresa)cmbEmpresa.SelectedItem));
        }



        /// <summary>
        /// Buttons
        /// </summary>
        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this, cmdAtualiza, true);

                F0070_Faturamento_Report.filterFaturamento.dataemissao_ini = dtpDataEmissao_Ini.Value;
                F0070_Faturamento_Report.filterFaturamento.dataemissao_fim = dtpDataEmissao_Fim.Value;
                F0070_Faturamento_Report.filterFaturamento.datafaturamento_ini = dtpdatafaturamento_ini.Value;
                F0070_Faturamento_Report.filterFaturamento.datafaturamento_fim = dtpdatafaturamento_fim.Value;


                F0070_Faturamento_Report.filterFaturamento.filtra_data_emissao = 0;
                if (chkDataEmissao.Checked) F0070_Faturamento_Report.filterFaturamento.filtra_data_emissao = 1;
                if (!chkDataEmissao.Checked) chkDataFaturamento.Checked = true;
                F0070_Faturamento_Report.filterFaturamento.filtra_data_faturamento = 0;
                if (chkDataFaturamento.Checked) F0070_Faturamento_Report.filterFaturamento.filtra_data_faturamento = 1;
                if (!chkDataFaturamento.Checked) chkDataEmissao.Checked = true;




                if (Convert.ToInt32(cmbEmpresa.SelectedValue) == 0)
                {
                    F0070_Faturamento_Report.filterFaturamento.em_cdempresa_list = "";
                }
                else
                {
                    F0070_Faturamento_Report.filterFaturamento.em_cdempresa_list = cmbEmpresa.SelectedValue.ToString();
                }
                F0070_Faturamento_Report.filterFaturamento.statusfaturamento = Convert.ToInt32(cmbFaturamentoStatus.SelectedValue);


                if (Convert.ToInt32(cmbEmpresa.SelectedValue) == 0)
                {
                    F0070_Faturamento_Report.filterFaturamento.em_cdempresa_list = "";
                }
                else
                {
                    F0070_Faturamento_Report.filterFaturamento.em_cdempresa_list = cmbEmpresa.SelectedValue.ToString();
                }

                if (Convert.ToInt32(cmbOperacao.SelectedValue) == 0)
                {
                    F0070_Faturamento_Report.filterFaturamento.op_cdoperacao_list = "";
                }
                else
                {
                    F0070_Faturamento_Report.filterFaturamento.op_cdoperacao_list = cmbOperacao.SelectedValue.ToString();
                }


                if (txtNumeroPedido.Text != "")
                {
                    F0070_Faturamento_Report.filterFaturamento.numeroPedidoList = txtNumeroPedido.Text;   
                }

                if (txtnf_numero.Text != "")
                {
                    F0070_Faturamento_Report.filterFaturamento.numeroNfeList = txtnf_numero.Text;
                }

                if (txtECF.Text != "")
                {
                    F0070_Faturamento_Report.filterFaturamento.ECF = Convert.ToInt32(txtECF.Text);
                }


                if (txtNumeroCupom.Text != "")
                {
                    F0070_Faturamento_Report.filterFaturamento.numeroCupomFiscalList = txtNumeroCupom.Text;
                }



                F0070_Faturamento_Report.getFaturamentoList();
                UserTools._Screen_Wait(this, cmdAtualiza, false);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            } 
                
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_seqfaturamento.Text != "")
                {
                    frm_faturamentoConsulta frm = new frm_faturamentoConsulta(MyConnect, Convert.ToInt32(lbl_seqfaturamento.Text));
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


    }
}
