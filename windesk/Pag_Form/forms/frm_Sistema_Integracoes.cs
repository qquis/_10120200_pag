using Pag_Net.Models;
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
    public partial class frm_Sistema_Integracoes : Form
    {
        public Pag_Net.Bll._Service BLL_SERVICE;
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public frm_Sistema_Integracoes(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            BLL_SERVICE = new Pag_Net.Bll._Service(MyConnect);
            _Screen_load();
        }

        private void _Screen_load()
        {

            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            cmdefetivar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
            cmdAtualiza.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
            cmdExecutarServicos.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
            cmdSql_PostGre.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
            cmdSql_PostGre_Faturamento.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
            cmdArquivoLog.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\open.ico");
            cmd_comercial_resumo_pre_pedido.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            this.dtgServicesTime.SelectionChanged += new System.EventHandler(this.DG_SelectionChanged);
            dtgServicosProcedimentos.AutoGenerateColumns = false;

            dtptemp_sql_post_ini.Value = DateTime.Now.AddDays(-1);
            dtptemp_sql_post_fim.Value = DateTime.Now.AddDays(-1);

            dtptemp_sql_post_ini.Value = Convert.ToDateTime("2021-01-02");
            dtptemp_sql_post_fim.Value = Convert.ToDateTime("2021-01-02");

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
        private void _Screen_changed(object sender, EventArgs e)
        {
   

        }
        private void _pesquisar()
        {
            _binding();
        }
        private void _binding()
        {
            try
            {
                BLL_SERVICE.ObterServicosTime();
                dtgServicesTime.AutoGenerateColumns = false;
                dtgServicesTime.DataSource = BLL_SERVICE.ListaDeServicosTimes;
                
                
                lbl_sis_servico_cd.DataBindings.Clear();
                lbl_sis_servico_data_fim.DataBindings.Clear();
                lbl_sis_servico_data_ini.DataBindings.Clear();
                lbl_sis_servico_descricao.DataBindings.Clear();
                lbl_sis_servico_diasemana.DataBindings.Clear();
                lbl_sis_servico_hora.DataBindings.Clear();
                lbl_sis_servico_minuto.DataBindings.Clear();
                lbl_sis_servico_segundo.DataBindings.Clear();
                
                
                
                lbl_sis_servico_cd.DataBindings.Add("Text", BLL_SERVICE.ListaDeServicosTimes, "sis_servico_cd");
                lbl_sis_servico_data_fim.DataBindings.Add("Text", BLL_SERVICE.ListaDeServicosTimes, "sis_servico_data_fim");
                lbl_sis_servico_data_ini.DataBindings.Add("Text", BLL_SERVICE.ListaDeServicosTimes, "sis_servico_data_ini");
                lbl_sis_servico_descricao.DataBindings.Add("Text", BLL_SERVICE.ListaDeServicosTimes, "sis_servico_descricao");
                lbl_sis_servico_diasemana.DataBindings.Add("Text", BLL_SERVICE.ListaDeServicosTimes, "sis_servico_diasemana");
                lbl_sis_servico_hora.DataBindings.Add("Text", BLL_SERVICE.ListaDeServicosTimes, "sis_servico_hora");
                lbl_sis_servico_minuto.DataBindings.Add("Text", BLL_SERVICE.ListaDeServicosTimes, "sis_servico_minuto");
                lbl_sis_servico_segundo.DataBindings.Add("Text", BLL_SERVICE.ListaDeServicosTimes, "sis_servico_segundo");

                DtgIntegracoesPostGre.AutoGenerateColumns = false;
                DtgIntegracoesPostGre.DataSource = Pag_Net.Services.Bll.Postgre.Tab.List(MyConnect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _bindingServicosProcedimentos()
        {
            try
            {
                Mdo_sis_ServiceTime SELECAO = (Mdo_sis_ServiceTime)(dtgServicesTime.CurrentRow.DataBoundItem);
                BLL_SERVICE.ObterServicosProcedimentos(SELECAO);
                dtgServicosProcedimentos.DataSource = BLL_SERVICE.ListaDeServicosProcedimentos;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);
            }


        }

        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            _pesquisar();
        }

        private void cmdefetivar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                this.Refresh();
                for (int li = 0; li <= DtgIntegracoesPostGre.Rows.Count - 1; li++)
                {
                    DataGridViewCheckBoxCell Chk = new DataGridViewCheckBoxCell();
                    Chk = (DataGridViewCheckBoxCell)DtgIntegracoesPostGre.Rows[li].Cells[0];
                    if (Convert.ToBoolean(Chk.Value) == true)
                    {
                        Pag_Net.Services.Bll.Postgre.Procedimentos.Execute(MyConnect, (Pag_Net.Services.Models.sistema_nucleo_procedimentos)DtgIntegracoesPostGre.Rows[li].DataBoundItem);
                    }
                }
                UserTools._Screen_Wait(this);
                UserTools._Screen_MessageBox(this, "Atualização Realizada com Sucesso");
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

        private void cmdSql_PostGre_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Confirma atualização? Os dados POSTGRE serão atualizados com a BASE SQL SERVER", "Pag - Atualização", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.Refresh();
                    this.Refresh();
                    this.Refresh();
                    this.Refresh();
                    this.Refresh();
                    this.Refresh();
                    
                    //Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_Produto_Clear_Postgre(MyConnect);
                    lbl_01_produto_excluir.ForeColor = Color.Red;
                    this.Refresh();
                    this.Refresh();
                    //Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_Produto(MyConnect);
                    lbl_02_produto_atualizar.ForeColor = Color.Red;
                    this.Refresh();
                    this.Refresh();
                    //Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_ProdutoEmbalagem(MyConnect);
                    lbl_03_produto_atualizar_embalagem.ForeColor = Color.Red;
                    this.Refresh();
                    this.Refresh();
                    //Pag_Net.P0005.Bll.Process.Execute(MyConnect); // PRODUTO
                    lbl_04_produto_atualizacao_geral.ForeColor = Color.Red;
                    this.Refresh();
                    this.Refresh();
                    //Pag_Net.P0010.Bll.Process.Execute(MyConnect); // ESTOQUE CUSTO
                    lbl_05_estoque.ForeColor = Color.Red;
                    this.Refresh();
                    this.Refresh();
                    //Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_Preco(MyConnect);
                    lbl_06_preco.ForeColor = Color.Red;
                    this.Refresh();
                    this.Refresh();
                    //Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_Custo(MyConnect);
                    lbl_07_custo.ForeColor = Color.Red;
                    this.Refresh();
                    this.Refresh();
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show("Atualização SQL -> POSTGRE (Produtos) realizada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void DG_SelectionChanged(object sender, EventArgs e)
        {
            _bindingServicosProcedimentos();
        
        }

        private void cmdExecutarServicos_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtARQUIVO_DE_LOG.Text == "")
                {
                    MessageBox.Show("Favor informar o diretório");
                    return;
                }
                Mdo_sis_ServiceTime SELECAO = (Mdo_sis_ServiceTime)(dtgServicesTime.CurrentRow.DataBoundItem);
                BLL_SERVICE.LogServiceFile = txtARQUIVO_DE_LOG.Text.ToString();
                BLL_SERVICE.ExecutarServicoProcedimento(SELECAO);
                //BLL_SERVICE.ProcessarServicosTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdArquivoLog_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                txtARQUIVO_DE_LOG.Text = saveFileDialog1.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void cmdSql_PostGre_Faturamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma atualização? Os dados POSTGRE serão atualizados com a BASE SQL SERVER", "Pag - Atualização", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.Refresh();
                    this.Refresh();
                    this.Refresh();
                    this.Refresh();
                    this.Refresh();
                    this.Refresh();
                    this.Refresh();

                    string info_old = lblintegra_base_sql.Text;

                    lblintegra_base_sql.Text = "Base de Faturamento...";
                    this.Refresh();
                    Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_Faturamento(MyConnect, dtptemp_sql_post_ini.Value, dtptemp_sql_post_fim.Value );

                    lblintegra_base_sql.Text = "Base de Faturamento Origem";
                    this.Refresh();
                    Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_FaturamentoOrigem(MyConnect, dtptemp_sql_post_ini.Value, dtptemp_sql_post_fim.Value);
                    lblintegra_base_sql.Text = "Base de Faturamento Itens";
                    this.Refresh();
                    Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_FaturamentoItens(MyConnect, dtptemp_sql_post_ini.Value, dtptemp_sql_post_fim.Value);
                    lblintegra_base_sql.Text = "Base de Faturamento Itens Embalagem";
                    this.Refresh();
                    Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_FaturamentoItens_Embalagem(MyConnect, dtptemp_sql_post_ini.Value, dtptemp_sql_post_fim.Value);
                    lblintegra_base_sql.Text = "Base de Faturamento Itens Contratos";
                    this.Refresh();
                    Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_FaturamentoItensContratos(MyConnect, dtptemp_sql_post_ini.Value, dtptemp_sql_post_fim.Value);
                    lblintegra_base_sql.Text = "Base de Faturamento Itens Info";
                    this.Refresh();
                    //Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_Faturamentoinfo(MyConnect, dtptemp_sql_post_ini.Value, dtptemp_sql_post_fim.Value);
                    //lblintegra_base_sql.Text = info_old;
                    //this.Refresh();
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show("Atualização SQL -> POSTGRE (Produtos) realizada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdVendasPostGre_Click(object sender, EventArgs e)
        {
            try
            {
                Pag_Net.Bll.Faturamento.Integration.Cupons(MyConnect);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);
            }
        }

    }
}



					