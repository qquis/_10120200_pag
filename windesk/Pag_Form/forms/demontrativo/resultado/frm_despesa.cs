using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.demontrativo.resultado
{
    public partial class frm_despesa : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.F0100_Resultado.WK F0100_Report;

        public frm_despesa(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_Form_Open(this);


                /*Class Management open*/
                F0100_Report = new Pag_Net.src.F0100_Resultado.WK(MyConnect);
                F0100_Report.REPORT.PropertyChanged += _dataBinding;

                cmb_resulta_conta.ValueMember = "r_conta_cd";
                cmb_resulta_conta.DisplayMember = "LOCAL_DESC_GRUPO";
                cmb_resulta_conta.DataSource = F0100_Report.REPORT.getContas(0);


                //if (txtSeqFaturamento.Text != "")


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

            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


        private void _dataBinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {


                if (e.PropertyName == "dbList_Despesas")
                {
                    dtgf.DataSource = F0100_Report.REPORT.dbList_Despesas.List;
                    lbltotal.Text = F0100_Report.REPORT.dbList_Despesas.Count.ToString();
                    UserTools._Screen_DataBinding_Set(lbl_plc_conta_cd, dtgf.DataSource, "plc_conta_cd");
                    UserTools._Screen_DataBinding_Set(lblplc_descricao, dtgf.DataSource, "plc_descricao");
                    UserTools._Screen_DataBinding_Set(lbl_contrato_bluesoft_seq, dtgf.DataSource, "contrato_bluesoft_seq");
                    UserTools._Screen_DataBinding_Set(lblnome_razao, dtgf.DataSource, "nome_razao");
                    UserTools._Screen_DataBinding_Set(lblcdparticipante, dtgf.DataSource, "cdparticipante");
                    
                }
                if (e.PropertyName == "dbList_DespesasPorConta")
                {
                    dtg.DataSource = F0100_Report.REPORT.dbList_DespesasPorConta.List;
                    UserTools._Screen_DataBinding_Set(lblResumoPlcContaCd, dtg.DataSource, "plc_conta_cd");
                    UserTools._Screen_DataBinding_Set(lblResumoContratoBluesoftSeq, dtg.DataSource, "contrato_bluesoft_seq");
                    lbltotal_conta.Text = F0100_Report.REPORT.dbList_DespesasPorConta.Count.ToString();
                    
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                filtrosBasicosAplicar();
                
                F0100_Report.REPORT.getDespesasPorConta();                  
                F0100_Report.REPORT.getDespesas();
  
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdVincularContaPag_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma atualização?"))
                {
                    UserTools._Screen_Wait(this);
                    foreach (DataGridViewRow row in dtgf.SelectedRows)
                    {
                        if (Convert.ToInt32(row.Cells["dtg_plc_conta_cd"].Value.ToString()) > 0 )
                            F0100_Report.Vinculo_ContaPag_ContaBlue_Add(Convert.ToInt32(row.Cells["dtg_contrato_bluesoft_seq"].Value.ToString()), Convert.ToInt32(row.Cells["dtg_plc_conta_cd"].Value.ToString()), Convert.ToInt32(row.Cells["dtg_cdparticipante"].Value.ToString()), ((Pag_Net.src.F0100_Resultado.tbs.tbresultado_conta)cmb_resulta_conta.SelectedItem));
                    }
                    F0100_Report.Vinculo_ContaPag_ContaBlue_Processar();
                    UserTools._Screen_Wait(this);
                }
                else
                {
                    F0100_Report.Vinculo_ContaPag_ContaBlue_Cancelar();
                }
                

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdConsultarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                filtrosBasicosAplicar();
                if (lblResumoContratoBluesoftSeq.Text != "")
                    F0100_Report.REPORT.Filtro.contrato_bluesoft_seq = Convert.ToInt32(lblResumoContratoBluesoftSeq.Text);

                if (lblResumoPlcContaCd.Text != "")
                    F0100_Report.REPORT.Filtro.plc_conta_cd = Convert.ToInt32(lblResumoPlcContaCd.Text);


                F0100_Report.REPORT.getDespesas();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void filtrosBasicosAplicar()
        {
            try
            {
                F0100_Report.REPORT.filtroClear();

                F0100_Report.REPORT.Filtro.dataemissao_filter = ChkDataVencimento.Checked;
                F0100_Report.REPORT.Filtro.dataemissao_filter_data_ini = dtpdataemissao_ini.Value;
                F0100_Report.REPORT.Filtro.dataemissao_filter_data_fim = dtpdataemissao_fim.Value;

                F0100_Report.REPORT.Filtro.datavencimento_filter = ChkDataVencimento.Checked;
                F0100_Report.REPORT.Filtro.datavencimento_filter_data_ini = dtpdatavencimento_ini.Value;
                F0100_Report.REPORT.Filtro.datavencimento_filter_data_fim = dtpdatavencimento_fim.Value;

                F0100_Report.REPORT.Filtro.nome_razao = txtnome_razao.Text;

                F0100_Report.REPORT.Filtro.plc_descricao = txtplc_descricao.Text;

                F0100_Report.REPORT.Filtro.SemContaVinculada = chkSemContaVinculada.Checked;

                if (txtcompetencia_cd.Text != "")
                    F0100_Report.REPORT.Filtro.competencia_cd = Convert.ToInt32(txtcompetencia_cd.Text);

                if (txtbluesoft_competencia_cd.Text != "")
                    F0100_Report.REPORT.Filtro.bluesoft_competencia_cd = Convert.ToInt32(txtbluesoft_competencia_cd.Text);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

  
    }
}
