using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Operacoes.Faturamento
{
    public partial class m4910_faturamentoBluesoft : Form
    {

        private static int _SIS_AC_CD = 4910;

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.F0050_Faturamento_BlueSoft._index F0050_FaturamentoBluesoft;


        Pag_Net.Bll.F0002_Enterprise.WkEmpresaOperacao _BLL_F0002_EmpresaOperacao;


        public m4910_faturamentoBluesoft(Pag_Net.Models.modelSistemaUsuario _Myconnect)
        {
            InitializeComponent();
            MyConnect = _Myconnect;
            _Screen_load();
        }
        private void _Screen_load()
        {
            F0050_FaturamentoBluesoft = new Pag_Net.src.F0050_Faturamento_BlueSoft._index(MyConnect);
            UserTools._Screen_Form_Open(this);
            UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
            UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);

            UserTools._Screen_Form_Format_DataGridView(dtgf);

            F0050_FaturamentoBluesoft.report.PropertyChanged += _databinding;


            //COMBOBOX EMPRESA OPERACAO -------------------------------------------------------------------


            _BLL_F0002_EmpresaOperacao = new Pag_Net.Bll.F0002_Enterprise.WkEmpresaOperacao(MyConnect);
            _BLL_F0002_EmpresaOperacao.Filter_EmpresaOperacao.sis_ac_cd = _SIS_AC_CD;
            _BLL_F0002_EmpresaOperacao.EmpresaOperacoes_User_List_DataBindings();

            cmbEmpresa.DisplayMember = "em_descricao";
            cmbEmpresa.ValueMember = "em_cdempresa";
            cmbEmpresa.DataSource = _BLL_F0002_EmpresaOperacao.List_User_Empresa;
            cmbEmpresa.SelectedIndex = 0;
            cmbEmpresa.SelectionChangeCommitted += _DataBindEmpresaSelect;

            cmbOperacao.DisplayMember = "op_descricao";
            cmbOperacao.ValueMember = "op_cdoperacao";
            _DataBindEmpresaSelect(null, null);
            // -----------------------------------------------------------------------------------------



            chkdata_pedidoemissao.DataBindings.Add("Enabled", optStatusFatBlue_FATURADO, "Checked");
            dtpdataPedidoEmissao_ini.DataBindings.Add("Enabled", chkdata_pedidoemissao, "Checked");
            dtpdataPedidoEmissao_fim.DataBindings.Add("Enabled", chkdata_pedidoemissao, "Checked");
            chkdata_pedidoemissao.Checked = true;
            dtpdataPedidoEmissao_ini.Value = F0050_FaturamentoBluesoft.report.filter.dataPedidoEmissao_ini;
            dtpdataPedidoEmissao_fim.Value = F0050_FaturamentoBluesoft.report.filter.dataPedidoEmissao_fim;


            chkdata_faturamento.DataBindings.Add("Checked", optStatusFatBlue_FATURADO, "Checked");
            dtpdataFaturamento_ini.DataBindings.Add("Enabled", chkdata_faturamento, "Checked");
            dtpdataFaturamento_fim.DataBindings.Add("Enabled", chkdata_faturamento, "Checked");

            chkdata_faturamento.Enabled = false;
            chkdata_faturamento.Checked = false;
            dtpdataFaturamento_ini.Value = F0050_FaturamentoBluesoft.report.filter.dataFaturamento_ini;
            dtpdataFaturamento_fim.Value = F0050_FaturamentoBluesoft.report.filter.dataFaturamento_fim;

            cmbFaturamentoBluesoftStatus.ValueMember = "fat_blue_status_cd";
            cmbFaturamentoBluesoftStatus.DisplayMember = "fat_blue_status_descricao"; 
            F0050_FaturamentoBluesoft.report.getFaturamentoStatus();

            optStatusFatBlue_SELECIONAR.Checked = true;
            cmbFaturamentoBluesoftStatus.DataBindings.Add("Enabled", optStatusFatBlue_SELECIONAR, "Checked");
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);



                F0050_FaturamentoBluesoft.report.filter.em_cdempresa = Convert.ToInt32(cmbEmpresa.SelectedValue.ToString());
                F0050_FaturamentoBluesoft.report.filter.op_cdoperacao = Convert.ToInt32(cmbOperacao.SelectedValue.ToString());

                F0050_FaturamentoBluesoft.report.filter.dataPedidoEmissao_filter = chkdata_pedidoemissao.Checked;
                F0050_FaturamentoBluesoft.report.filter.dataPedidoEmissao_ini = dtpdataPedidoEmissao_ini.Value;
                F0050_FaturamentoBluesoft.report.filter.dataPedidoEmissao_fim = dtpdataPedidoEmissao_fim.Value;

                F0050_FaturamentoBluesoft.report.filter.dataFaturamento_filter = chkdata_faturamento.Checked;
                F0050_FaturamentoBluesoft.report.filter.dataFaturamento_ini = dtpdataFaturamento_ini.Value;
                F0050_FaturamentoBluesoft.report.filter.dataFaturamento_fim = dtpdataFaturamento_fim.Value;


                F0050_FaturamentoBluesoft.report.filter.TipoStatusFiltro_fat_blue_status_cd = Convert.ToInt32(cmbFaturamentoBluesoftStatus.SelectedValue);

                if (optStatusFatBlue_SELECIONAR.Checked)
                    F0050_FaturamentoBluesoft.report.filter.TipoStatusFiltro = "SELECIONAR";
                if (optStatusFatBlue_ABERTO.Checked)
                    F0050_FaturamentoBluesoft.report.filter.TipoStatusFiltro = "ABERTO";
                if (optStatusFatBlue_FATURADO.Checked)
                    F0050_FaturamentoBluesoft.report.filter.TipoStatusFiltro = "FATURADO";

                F0050_FaturamentoBluesoft.report.getFaturamento();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _databinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {

                if (e.PropertyName == "dbList_Faturamento_Status")
                {
                    cmbFaturamentoBluesoftStatus.DataSource = F0050_FaturamentoBluesoft.report.dbList_Faturamento_Status.List;
                }


                if (e.PropertyName == "dbList_Faturamento")
                {
                    dtgf.DataSource = F0050_FaturamentoBluesoft.report.dbList_Faturamento.List;
                    lbltotal_registros_faturamento.Text = F0050_FaturamentoBluesoft.report.dbList_Faturamento.Count.ToString();

                    UserTools._Screen_DataBinding_Set_FromDataGrid(this, dtgf);
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _DataBindEmpresaSelect(object sender, EventArgs e)
        {
            cmbOperacao.DataSource = _BLL_F0002_EmpresaOperacao.Operacao_User_List_Get(((Pag_Net.Bll.F0002_Enterprise.TbEmpresa)cmbEmpresa.SelectedItem));
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
