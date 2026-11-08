/*
 * 31/03/2022[1] - Quinta feira: Inclusão do chebkbox - COM ESTOQUE
 * 31/03/2022[1] - Quinta feira: CHKCOMPRECO passa a ter a função de SEMPREÇO
 * 31/03/2022[1] - Alteração do layout da tela
 * */



using Pag_Net.Bll;
using Pag_Net.Bll.Precos.Db;
using Pag_Net.R0022.Models;
using Pag_Net.src.F0045_Preco.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Loja.Preco
{
    public partial class frm_ProdutoPreco : Form
    {

        
        //Pag_Net.Bll.Precos.Manutencao F0045_Preco;

        Pag_Net.src.F0045_Preco.service.Manutencao F0045_Preco;


        //Pag_Net.R0022.Bll.Execute _ProdutoDepto;
        //Pag_Net.Bll.Produto.Depto _ProdutoDepto;
        Pag_Net.Bll.F0020_Produto.WKDepto _ProdutoDepto;
        Pag_Net.Models.modelSistemaUsuario Myconnect;
        double __ValorMinimoMargemSinalizar = 10;

        Pag_Net.Bll.F0150_Estatistica.Wk wkEstatistica;

        public frm_ProdutoPreco(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            try
            {
                InitializeComponent();
                Myconnect = _myConnect;

                //F0045_Preco = new Pag_Net.Bll.Precos.Manutencao(Myconnect);
                F0045_Preco = new Pag_Net.src.F0045_Preco.service.Manutencao(Myconnect);


                //_ProdutoDepto = new Pag_Net.R0022.Bll.Execute(Myconnect);
                _ProdutoDepto = new Pag_Net.Bll.F0020_Produto.WKDepto(Myconnect, 2100);
                wkEstatistica = new Pag_Net.Bll.F0150_Estatistica.Wk(Myconnect);
                _Screen_load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frm_ProdutoPreco_Shown(object sender, EventArgs e)
        {
            this.Refresh();

        }
    

        private void _Screen_load()
        {
            try
            {
                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                cmdAtualiza.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
                lbl_embalagem_Seta.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");

                cmdefetivar_precos_alterados.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
                //cmdConsultar_Entradas.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\find.ico");
                cmdCANCELA_Atualiza.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\delete.ico");

                /* DataGrid - Format */
                lbl_efetivar_data_agendamento.DataBindings.Add("Text", dtpData_Agendamento, "Value");
                chkAplicacaoDefinitiva.Checked = false;

                chkComEstoque.Checked = false;
                chkComPreco.Checked = false;
                chkSemPreco.Checked = false;




                dtgProduto.AutoGenerateColumns = false;
                dtgProdutoPrecoEmbalagem.AutoGenerateColumns = false;
                DT_PrecosAlterados.AutoGenerateColumns = false;

                chkSeleciona_Data_Cadastro.Checked = false;

                dtpData_Agendamento.DataBindings.Add("Enabled", chkAgendamento_consulta, "Checked");
                F0045_Preco.Data_Agendamento = dtpData_Agendamento.Value;

                dtpDataCadastroIni.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");
                dtpDataCadastroFim.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");

                chkCUSTO_ENTRADA_DATA.Checked = false;
                dtp_Custo_Entrada_Data_Inicial.DataBindings.Add("Enabled", chkCUSTO_ENTRADA_DATA, "Checked");
                dtp_Custo_Entrada_Data_Final.DataBindings.Add("Enabled", chkCUSTO_ENTRADA_DATA, "Checked");

                dtp_Custo_Entrada_Data_Inicial.Value = DateTime.Now.AddDays(-1);
                dtp_Custo_Entrada_Data_Final.Value = DateTime.Now.AddDays(-1);

                cmbTabelaPrecificacao.DisplayMember = "tab_pre_descricao";
                cmbTabelaPrecificacao.ValueMember = "tab_pre_cd";
                cmbTabelaPrecificacao.DataSource = Pag_Net.Bll.Precos.TabelasdePrecos.Get(Myconnect);

                cmbDepartamento.DisplayMember = "prd_descricao";
                cmbsecao.DisplayMember = "prs_descricao";
                cmbDepartamento.ValueMember = "prd_cddepartamento";
                cmbDepartamento.DataSource = _ProdutoDepto.Departamento();
                cmbDepartamento.SelectedIndex = 0;

                cmbsecao.ValueMember = "prs_cdsecao";
                cmbsecao.DisplayMember = "prs_descricao";
                cmbsecao.DataSource = _ProdutoDepto.Secao(0);
                cmbsecao.SelectedIndex = 0;

                cmbgrupo.ValueMember = "prg_cdgrupo";
                cmbgrupo.DisplayMember = "prg_descricao";
                cmbgrupo.DataSource = _ProdutoDepto.Grupo(0, 0);
                cmbgrupo.SelectedIndex = 0;

                cmbsubgrupo.ValueMember = "prsg_cdsubgrupo";
                cmbsubgrupo.DisplayMember = "prsg_descricao";
                cmbsubgrupo.DataSource = _ProdutoDepto.SubGrupo(0, 0, 0);
                cmbsubgrupo.SelectedIndex = 0;

                txtValorMinimoMargemSinalizar.Text = __ValorMinimoMargemSinalizar.ToString();
                txtValorMinimoMargemSinalizar.TextChanged += new EventHandler(_Screen_changed);

                txtFILTRO_GRID_DESCRICAO.TextChanged += new EventHandler(_Screen_changed);
                txtcdproduto.TextChanged += new EventHandler(_Screen_changed);
                txtcdprodutobluesoft.TextChanged += new EventHandler(_Screen_changed);
                txtdescricao.TextChanged += new EventHandler(_Screen_changed);
                chkSeleciona_Data_Cadastro.CheckedChanged += new EventHandler(_Screen_changed);
                chkAgendamento_consulta.CheckedChanged += new EventHandler(_Screen_changed);
                chkAplicacaoDefinitiva.CheckedChanged += new EventHandler(_Screen_changed);
                dtpDataCadastroIni.ValueChanged += new EventHandler(_Screen_changed);
                dtpDataCadastroFim.ValueChanged += new EventHandler(_Screen_changed);
                cmbDepartamento.TextChanged += new EventHandler(_Screen_changed);
                cmbsecao.TextChanged += new EventHandler(_Screen_changed);
                cmbgrupo.TextChanged += new EventHandler(_Screen_changed);
                cmbsubgrupo.TextChanged += new EventHandler(_Screen_changed);
                cmbTabelaPrecificacao.TextChanged += new EventHandler(_Screen_changed);
                dtpData_Agendamento.TextChanged += new EventHandler(_Screen_changed);
                lbl_pr_embalagem.TextChanged += new EventHandler(_Screen_changed);
                chkCUSTO_ENTRADA_DATA.CheckedChanged += new EventHandler(_Screen_changed);
                dtp_Custo_Entrada_Data_Inicial.ValueChanged += new EventHandler(_Screen_changed);
                dtp_Custo_Entrada_Data_Final.ValueChanged += new EventHandler(_Screen_changed);
                lbl_prb_cdprodutobluesoft.TextChanged += new EventHandler(_Screen_changed);
                

                chkpr_status_comercial_preco_inativo.CheckedChanged += new EventHandler(_Screen_changed);
                chkComPreco.CheckedChanged += new EventHandler(_Screen_changed);
                chkSemPreco.CheckedChanged += new EventHandler(_Screen_changed);
                chkComEstoque.CheckedChanged += new EventHandler(_Screen_changed);
                chkAlterarPrecoEmbalagensPesoFilhos.CheckedChanged += new EventHandler(_Screen_changed); chkAlterarPrecoEmbalagensPesoFilhos.Checked = true; F0045_Preco.AlterarPrecoEmbalagensPesoFilhos = true;

                chkVisualizaçãoComercial.CheckedChanged += new EventHandler(_Screen_changed);
                chkVisualizaçãoComercial.Checked = false;
                chkVisualizaçãoComercial.Checked = true;

                /*
                 * this.dtgProduto.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellValueChanged);
                 * this.dtgProdutoPrecoEmbalagem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellValueChanged);
                 */

                cmbTabelaPrecificacao.SelectedIndex = 0;
                
                
                dtgProduto.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DG_CellFormatting);
                dtgProduto.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(DG_ColumnHeaderMouseClick);
                this.dtgProduto.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
                this.dtgProdutoPrecoEmbalagem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
                this.dtgProduto.SelectionChanged += new System.EventHandler(this.DG_SelectionChanged);



                lbl_tab_pre_descricao.Text = cmbTabelaPrecificacao.Text;


                dtpData_Agendamento.Value = DateTime.Now;
                dtpDataCadastroIni.Value = DateTime.Now;
                dtpDataCadastroFim.Value = DateTime.Now;




                cmbTabelaPrecificacao.SelectedIndex = 0;
                chkAgendamento_consulta.Checked = false;


                F0045_Preco.Tab_pre_cd = Convert.ToInt32(cmbTabelaPrecificacao.SelectedValue);

                dtp_Custo_Entrada_Data_Inicial.Checked = false;
                dtp_Custo_Entrada_Data_Final.Checked = false;
                



                if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(Myconnect, 210001))
                {
                    chkAgendamento_consulta.Enabled = true;
                }
                else
                {
                    chkAgendamento_consulta.Enabled = false;

                }


                if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(Myconnect, 210002))
                {
                    cmbTabelaPrecificacao.Enabled = true;
                }
                else
                {
                    cmbTabelaPrecificacao.Enabled = false;

                }
                

                cmdCANCELA_Atualiza.Enabled = false;
                grp_grid.Enabled = false;

                chkpr_status_comercial_preco_inativo.Checked = false;

                F0045_Preco.Filter_Produto.Prd_cddepartamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
                F0045_Preco.Filter_Produto.Prd_cdsecao = Convert.ToInt32(cmbsecao.SelectedValue);
                F0045_Preco.Filter_Produto.Prd_cdgrupo = Convert.ToInt32(cmbgrupo.SelectedValue);
                F0045_Preco.Filter_Produto.Prd_subcdgrupo = Convert.ToInt32(cmbsubgrupo.SelectedValue);

                /* Tipo de Visualização de Custo Padrão */

                lblest_satual_data_ini.Text = wkEstatistica.Info.est_satual_data_ini.ToString("dd");
                lblest_s1_data_ini.Text = wkEstatistica.Info.est_s1_data_ini.ToString("dd");
                lblest_s2_data_ini.Text = wkEstatistica.Info.est_s2_data_ini.ToString("dd");
                lblest_s2_data_ini.Text = wkEstatistica.Info.est_s2_data_ini.ToString("dd");
                lblest_s3_data_ini.Text = wkEstatistica.Info.est_s3_data_ini.ToString("dd");
                lblest_s4_data_ini.Text = wkEstatistica.Info.est_s4_data_ini.ToString("dd");

            }
            catch (Exception ex)
            {
                MessageBox.Show("* ERRO *: " + ex.Message);
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
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {

                /*if (sender.GetType().Name == "Label")
                {
                    switch (((Label)sender).Name)
                    {
                        case "lbl_prb_cdprodutobluesoft":
                            break;
                    }

                }*/


                if (sender.GetType().Name == "TextBox")
                {
                    if (((TextBox)sender).Name == "txtcdproduto" || ((TextBox)sender).Name == "txtcdprodutobluesoft")
                    {

                        if (((TextBox)sender).Text.Length == 0)
                        {
                            ((TextBox)sender).Text = "0";
                            _Screen_changed(sender, e);
                        }
                    }
                    switch (((TextBox)sender).Name)
                    {
                        case "txtValorMinimoMargemSinalizar":
                            try
                            {
                                __ValorMinimoMargemSinalizar = Convert.ToDouble(txtValorMinimoMargemSinalizar.Text);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(string.Format("Valor inválido {0}", ex.Message));
                                __ValorMinimoMargemSinalizar = 10;
                                txtValorMinimoMargemSinalizar.Text = "10";
                                
                            }
                            break;
                        case "txtcdproduto":
                            F0045_Preco.Filter_Produto.CdProduto = txtcdproduto.Text;
                            break;
                        case "txtcdprodutobluesoft":
                            F0045_Preco.Filter_Produto.CdProdutoBluesoft = txtcdprodutobluesoft.Text;
                            break;
                        case "txtdescricao":
                            F0045_Preco.Filter_Produto.Descricao = txtdescricao.Text;
                            break;
                        case "txtFILTRO_GRID_DESCRICAO":
                            if (grp_grid.Enabled)
                            {
                                _Screen_wait(true);
                                F0045_Preco.ConsultarPrecos_FiltroGRID(txtFILTRO_GRID_DESCRICAO.Text.ToUpper(),chkSemPreco.Checked, chkComPreco.Checked, chkComEstoque.Checked);
                                _databinding();
                                _Screen_wait(false);
                            }
                            break;
                    }

                }

                if (sender.GetType().Name == "DateTimePicker")
                {
                    switch (((DateTimePicker)sender).Name)
                    {
                        case "dtpDataCadastroIni":
                            F0045_Preco.Filter_Produto.Dt_cadastro_ini = dtpDataCadastroIni.Value;
                            break;
                        case "dtpDataCadastroFim":
                            F0045_Preco.Filter_Produto.Dt_cadastro_fim = dtpDataCadastroFim.Value;
                            break;
                        case "dtpData_Agendamento":
                            F0045_Preco.Data_Agendamento = dtpData_Agendamento.Value;
                            lbl_efetivar_data_agendamento.ForeColor = Color.Black;
                            if (dtpData_Agendamento.Value != DateTime.Now.Date)
                            {
                                lbl_efetivar_data_agendamento.ForeColor = Color.Red;

                            }
                            break;
                        case "dtp_Custo_Entrada_Data_Inicial":
                            F0045_Preco.Dt_data_entrada_ini = dtp_Custo_Entrada_Data_Inicial.Value;
                            break;
                        case "dtp_Custo_Entrada_Data_Final":
                            F0045_Preco.Dt_data_entrada_fim = dtp_Custo_Entrada_Data_Final.Value;
                            break;
                            
                    }
                }


                if (sender.GetType().Name == "CheckBox")
                {
                    switch (((CheckBox)sender).Name)
                    {
                        case "chkSeleciona_Data_Cadastro":

                            if (chkSeleciona_Data_Cadastro.Checked)
                            {
                                dtpDataCadastroIni.Value = DateTime.Now;
                                dtpDataCadastroFim.Value = DateTime.Now;
                            }
                            else
                            {
                                dtpDataCadastroIni.Value = Convert.ToDateTime("1900-01-01");
                                dtpDataCadastroFim.Value = Convert.ToDateTime("1900-01-01");
                            }
                            F0045_Preco.Filter_Produto.Seleciona_Data_Cadastro = chkSeleciona_Data_Cadastro.Checked;
                            break;
                        case "chkAgendamento_consulta":
                            if (chkAgendamento_consulta.Checked)
                            {
                                MessageBox.Show("Agendamento será considerado apenas para Preço e Qtde Promocional. Fator de preço de embalagem permanece inalterado.");
                                dtpData_Agendamento.Value = DateTime.Now.AddDays(1);
                                cmbTabelaPrecificacao.Enabled = true;
                                _conferirTabPrecoSelecionada();
                                //if (Convert.ToInt32(cmbTabelaPrecificacao.SelectedValue) == 1)
                                //{
                                //    chkAplicacaoDefinitiva.Enabled = true;
                                //}
                            }
                            else
                            {
                                cmbTabelaPrecificacao.SelectedIndex = 0;
                                dtpData_Agendamento.Value = DateTime.Now;
                                //chkAplicacaoDefinitiva.Enabled = false;
                            }
                            F0045_Preco.Agendamento_Consulta = chkAgendamento_consulta.Checked;
                            break;
                        case "chkAlterarPrecoEmbalagensPesoFilhos":
                            if (chkAlterarPrecoEmbalagensPesoFilhos.Checked)
                            {
                                F0045_Preco.AlterarPrecoEmbalagensPesoFilhos = true;
                            }
                            else
                            {
                                F0045_Preco.AlterarPrecoEmbalagensPesoFilhos = false;
                            }
                            break;


                        case "chkCUSTO_ENTRADA_DATA":
                            if (chkCUSTO_ENTRADA_DATA.Checked)
                            {
                                F0045_Preco.Seleciona_Data_Mov_Entrada = true;
                            }
                            else
                            {
                                F0045_Preco.Seleciona_Data_Mov_Entrada = false;
                            }
                            break;
                        case "chkAplicacaoDefinitiva":
                            if (chkAplicacaoDefinitiva.Checked)
                            {
                                F0045_Preco.PrecoDefinitivo = true;
                            }
                            else
                            {
                                F0045_Preco.PrecoDefinitivo = false;
                            }
                            break;

                        case "chkComPreco":
                            if (grp_grid.Enabled)
                            {
                                _Screen_wait(true);
                                F0045_Preco.ConsultarPrecos_FiltroGRID(txtFILTRO_GRID_DESCRICAO.Text.ToUpper(), chkSemPreco.Checked, chkComPreco.Checked, chkComEstoque.Checked);
                                _databinding();
                                _Screen_wait(false);
                            }
                            break;


                        case "chkSemPreco":

                            if (grp_grid.Enabled)
                            {
                                _Screen_wait(true);
                                F0045_Preco.ConsultarPrecos_FiltroGRID(txtFILTRO_GRID_DESCRICAO.Text.ToUpper(), chkSemPreco.Checked, chkComPreco.Checked, chkComEstoque.Checked);
                                _databinding();
                                _Screen_wait(false);
                            }
                            break;


                        case "chkComEstoque":
                            if (grp_grid.Enabled)
                            {
                                _Screen_wait(true);
                                F0045_Preco.ConsultarPrecos_FiltroGRID(txtFILTRO_GRID_DESCRICAO.Text.ToUpper(), chkSemPreco.Checked, chkComPreco.Checked, chkComEstoque.Checked);
                                _databinding();
                                _Screen_wait(false);
                            }
                            break;


                        case "chkpr_status_comercial_preco_inativo":
                            dtgProduto.DataSource = null;
                            if (chkpr_status_comercial_preco_inativo.Checked)
                            {
                                F0045_Preco.Pr_status_comercial_preco_inativo = 1;
                            }
                            else
                            {
                                F0045_Preco.Pr_status_comercial_preco_inativo = 0;
                            }
                            break;

                        case "chkVisualizaçãoComercial":
                            dtgProduto.DataSource = null;
                            dtgProdutoPrecoEmbalagem.DataSource = null;
                            _databinding_clear();
                            if (chkVisualizaçãoComercial.Checked)
                            {
                                //dtgProduto.DataSource = null;
                                F0045_Preco.Tipo_Visualizacao = 1;
                                dtgProduto.Columns[4].Visible = false;
                                dtgProduto.Columns[5].Visible = false;
                                dtgProduto.Columns[6].HeaderText = "Custo Comercial";

                                dtgProdutoPrecoEmbalagem.Columns[4].Visible = false;
                                dtgProdutoPrecoEmbalagem.Columns[5].Visible = false;
                                dtgProdutoPrecoEmbalagem.Columns[6].HeaderText = "Custo Comercial";

                                dtgProduto.Rows.Clear();
                                dtgProdutoPrecoEmbalagem.Rows.Clear();

                            }
                            else
                            {
                                F0045_Preco.Tipo_Visualizacao = 0;
                                dtgProduto.Columns[4].Visible = true;
                                dtgProduto.Columns[5].Visible = true;
                                dtgProduto.Columns[6].HeaderText = "Vl Ult Entrada";

                                dtgProdutoPrecoEmbalagem.Columns[4].Visible = true;
                                dtgProdutoPrecoEmbalagem.Columns[5].Visible = true;
                                dtgProdutoPrecoEmbalagem.Columns[6].HeaderText = "Vl Ult Entrada";
                            }
                            break;

                    }

                }


                if (sender.GetType().Name == "ComboBox")
                {
                    switch (((ComboBox)sender).Name)
                    {
                        case "cmbDepartamento":
                            cmbsecao.DataSource = _ProdutoDepto.Secao(Convert.ToInt32(cmbDepartamento.SelectedValue));
                            cmbgrupo.DataSource = _ProdutoDepto.Grupo(Convert.ToInt32(cmbDepartamento.SelectedValue), 0);
                            cmbsubgrupo.DataSource = _ProdutoDepto.SubGrupo(Convert.ToInt32(cmbDepartamento.SelectedValue), 0, 0);
                            break;
                        case "cmbsecao":
                            cmbgrupo.DataSource = _ProdutoDepto.Grupo(Convert.ToInt32(cmbDepartamento.SelectedValue), Convert.ToInt32(cmbsecao.SelectedValue));
                            cmbsubgrupo.DataSource = _ProdutoDepto.SubGrupo(Convert.ToInt32(cmbDepartamento.SelectedValue), Convert.ToInt32(cmbsecao.SelectedValue), 0);
                            break;
                        case "cmbgrupo":
                            cmbsubgrupo.DataSource = _ProdutoDepto.SubGrupo(Convert.ToInt32(cmbDepartamento.SelectedValue), Convert.ToInt32(cmbsecao.SelectedValue), Convert.ToInt32(cmbgrupo.SelectedValue));
                            break;
                        case "cmbTabelaPrecificacao":
                            lbl_tab_pre_descricao.Text = cmbTabelaPrecificacao.Text;
                            if (cmbTabelaPrecificacao.SelectedIndex == 1)
                            {
                                lbl_tab_pre_descricao.Text = cmbTabelaPrecificacao.Text + "\n Preços Promocionais "; 
                            }

                            _conferirTabPrecoSelecionada();


                            break;

                    }

                    F0045_Preco.Filter_Produto.Prd_cddepartamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
                    F0045_Preco.Filter_Produto.Prd_cdsecao = Convert.ToInt32(cmbsecao.SelectedValue);
                    F0045_Preco.Filter_Produto.Prd_cdgrupo = Convert.ToInt32(cmbgrupo.SelectedValue);
                    F0045_Preco.Filter_Produto.Prd_subcdgrupo = Convert.ToInt32(cmbsubgrupo.SelectedValue);

                }
            }

            catch (Exception ErroMessage)
            {
                _Screen_wait(false);
                if (sender.GetType().Name == "TextBox")
                {
                    ((TextBox)sender).Text = "0";
                }
                MessageBox.Show(ErroMessage.Message);
            }

        }


        private void _conferirTabPrecoSelecionada()
        {
            F0045_Preco.Tab_pre_cd = Convert.ToInt32(cmbTabelaPrecificacao.SelectedValue);

            if (chkAgendamento_consulta.Checked)
            {
                if (F0045_Preco.Tab_pre_cd == 1)
                {
                   chkAplicacaoDefinitiva.Checked = true;

                }
                if (F0045_Preco.Tab_pre_cd == 2)
                {
                    chkAplicacaoDefinitiva.Checked = false;
                }
            }
        }

        private void _pesquisar()
        {
            try
            {

                if (tabControlPreco.SelectedIndex == 0)
                {
                    if (F0045_Preco.ExisteAlteracaoDePrecoPendente)
                        if (MessageBox.Show("Existe alterações de preços pendentes, deseja continuar? Os preços já alterados serão desconsiderados!", "Pag | Alteração de Preços", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            return;
                        }
                    else
                        {
                            F0045_Preco.ExisteAlteracaoDePrecoPendente = false;
                        }
                }

                _Screen_wait(cmdAtualiza, true);



                if (tabControlPreco.SelectedIndex == 0)
                {
                    /*************************************** CONSULTAR PRECOS *********************************************************/
                    /******************************************************************************************************************/
                    /******************************************************************************************************************/
                    /******************************************************************************************************************/
                    /******************************************************************************************************************/
                    F0045_Preco.ConsultarPrecos();
                    /******************************************************************************************************************/
                    /******************************************************************************************************************/
                    /******************************************************************************************************************/
                    /******************************************************************************************************************/
                    _databinding();
                }

                if (tabControlPreco.SelectedIndex == 1)
                {
                    F0045_Preco.ConsultarPrecosAlterados();
                    DT_PrecosAlterados.DataSource = F0045_Preco.PrecosAlterados;
                }

                _Screen_wait(cmdAtualiza, false);
                txtValorMinimoMargemSinalizar.Enabled = false;
                cmdAtualiza.Enabled = false;
                grp_filtros.Enabled = false;
                cmdCANCELA_Atualiza.Enabled = true;
                grp_grid.Enabled = true;

            }
            catch (Exception ex)
            {
                _Screen_wait(cmdAtualiza, false);
                MessageBox.Show("Erro: " + ex.Message);
                grp_filtros.Enabled = true;
                cmdCANCELA_Atualiza.Enabled = false;
                grp_grid.Enabled = false;
            }

        }


        private void _databinding_clear()
        {
            lbl_pr_cdproduto.Text = "";
            lbl_prb_cdprodutobluesoft.Text = "";
            lbl_pr_descricao.Text = "";
            lbl_prc_valor.Text = "";
            lbl_LAYER_PRECO_ALTERADO.Text = "";
            lbl_TIPO_CESTA.Text = "";
            lbl_info_embalagemestoqueqtde.Text = "";
            lblec_valor_custo_faturamento.Text = "";
            lblconsulta_valor_custo_precificacao.Text = "";
            lbl_total_embalagens.Text = "";
            lbl_pr_descricao_Embalagem.Text = "";
            lbl_prc_valor_Embalagem.Text = "";
            lbl_LAYER_PRECO_ALTERADO_Embalagem.Text = "";

        }

        private void _databinding()
        {
            try
            {

                dtgProduto.DataSource = F0045_Preco.Precos_Unitarios;
                dtgProduto_bool_pr_status_comercial_preco_inativo.ReadOnly = true;
                if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(Myconnect, 210003))
                {
                    dtgProduto_bool_pr_status_comercial_preco_inativo.ReadOnly = false;
                }
                else
                {
                    dtgProduto_bool_pr_status_comercial_preco_inativo.ReadOnly = true;
                }

                lbl_info_total.Text = F0045_Preco.Precos_Unitarios.Count().ToString();
                lbl_margem_media.Text = Math.Round(F0045_Preco.MargemMedia, 2).ToString();

                lbl_pr_cdproduto.DataBindings.Clear();
                lbl_prb_cdprodutobluesoft.DataBindings.Clear();
                lbl_pr_descricao.DataBindings.Clear();
                lbl_prc_valor.DataBindings.Clear();
                lbl_LAYER_PRECO_ALTERADO.DataBindings.Clear();
                lbl_TIPO_CESTA.DataBindings.Clear();
                lbl_info_embalagemestoqueqtde.DataBindings.Clear();
                lblec_valor_custo_faturamento.DataBindings.Clear();
                lblconsulta_valor_custo_precificacao.DataBindings.Clear();
                


                lbl_TIPO_CESTA.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "local_TIPO_CESTA");
                lbl_pr_cdproduto.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "pr_cdproduto");
                lbl_prb_cdprodutobluesoft.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "prb_cdprodutobluesoft");
                lbl_pr_descricao.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "pr_descricao");
                lbl_prc_valor.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "prc_valor", true, DataSourceUpdateMode.Never, true, "0.00");
                lbl_LAYER_PRECO_ALTERADO.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "local_PRECO_ALTERADO", true, DataSourceUpdateMode.Never, true, "0.00");
                lbl_info_embalagemestoqueqtde.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "ec_embalagemestoque_qtde", true, DataSourceUpdateMode.Never, true, "0.000");

                lblec_valor_custo_faturamento.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "ec_valor_custo_faturamento", true, DataSourceUpdateMode.Never, true, "0.00");
                lblconsulta_valor_custo_precificacao.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "consulta_valor_custo_precificacao", true, DataSourceUpdateMode.Never, true, "0.00");
                //cmd_ativar_inativar_visualizacao.DataBindings.Add("Enabled", Class__Manutencao.Precos_Unitarios, ")


                //lblest_satual_data_ini.DataBindings.Clear();
               // lblest_satual_data_ini.DataBindings.Add("Text", Class__Manutencao.Precos_Unitarios, "est_satual_data_ini", true, DataSourceUpdateMode.Never, true, "dd");
                lblest_satual_embalagemestoqueqtde.DataBindings.Clear();
                lblest_satual_embalagemestoqueqtde.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_satual_embalagemestoqueqtde", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_satual_ec_valorcusto_faturamento_total.DataBindings.Clear();
                lblest_satual_ec_valorcusto_faturamento_total.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_satual_custo_medio", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_satual_valortotalfaturamentoliquido.DataBindings.Clear();
                lblest_satual_valortotalfaturamentoliquido.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_satual_valortotalfaturamentoliquido", true, DataSourceUpdateMode.Never, true, "0.00");
                lblcalc_est_satual_margem.DataBindings.Clear();
                lblcalc_est_satual_margem.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_satual_margem", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_satual_pontos.DataBindings.Clear();
                lblest_satual_pontos.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_satual_pontos", true, DataSourceUpdateMode.Never, true, "0");
                lblcalc_est_satual_preco_medio.DataBindings.Clear();
                lblcalc_est_satual_preco_medio.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_satual_preco_medio", true, DataSourceUpdateMode.Never, true, "0.00");

                //lblest_s4_data_ini.DataBindings.Clear();
                //lblest_s4_data_ini.DataBindings.Add("Text", Class__Manutencao.Precos_Unitarios, "est_s4_data_ini", true, DataSourceUpdateMode.Never, true, "dd");
                lblest_s4_embalagemestoqueqtde.DataBindings.Clear();
                lblest_s4_embalagemestoqueqtde.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s4_embalagemestoqueqtde", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s4_ec_valorcusto_faturamento_total.DataBindings.Clear();
                lblest_s4_ec_valorcusto_faturamento_total.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s4_custo_medio", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s4_valortotalfaturamentoliquido.DataBindings.Clear();
                lblest_s4_valortotalfaturamentoliquido.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s4_valortotalfaturamentoliquido", true, DataSourceUpdateMode.Never, true, "0.00");
                lblcalc_est_s4_margem.DataBindings.Clear();
                lblcalc_est_s4_margem.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s4_margem", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s4_pontos.DataBindings.Clear();
                lblest_s4_pontos.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s4_pontos", true, DataSourceUpdateMode.Never, true, "0");
                lblcalc_est_s4_preco_medio.DataBindings.Clear();
                lblcalc_est_s4_preco_medio.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s4_preco_medio", true, DataSourceUpdateMode.Never, true, "0.00");


                //lblest_s3_data_ini.DataBindings.Clear();
                //lblest_s3_data_ini.DataBindings.Add("Text", Class__Manutencao.Precos_Unitarios, "est_s3_data_ini", true, DataSourceUpdateMode.Never, true, "dd");
                lblest_s3_embalagemestoqueqtde.DataBindings.Clear();
                lblest_s3_embalagemestoqueqtde.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s3_embalagemestoqueqtde", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s3_ec_valorcusto_faturamento_total.DataBindings.Clear();
                lblest_s3_ec_valorcusto_faturamento_total.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s3_custo_medio", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s3_valortotalfaturamentoliquido.DataBindings.Clear();
                lblest_s3_valortotalfaturamentoliquido.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s3_valortotalfaturamentoliquido", true, DataSourceUpdateMode.Never, true, "0.00");
                lblcalc_est_s3_margem.DataBindings.Clear();
                lblcalc_est_s3_margem.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s3_margem", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s3_pontos.DataBindings.Clear();
                lblest_s3_pontos.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s3_pontos", true, DataSourceUpdateMode.Never, true, "0");
                lblcalc_est_s3_preco_medio.DataBindings.Clear();
                lblcalc_est_s3_preco_medio.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s3_preco_medio", true, DataSourceUpdateMode.Never, true, "0.00");

                //lblest_s2_data_ini.DataBindings.Clear();
                //lblest_s2_data_ini.DataBindings.Add("Text", Class__Manutencao.Precos_Unitarios, "est_s2_data_ini", true, DataSourceUpdateMode.Never, true, "dd");
                lblest_s2_embalagemestoqueqtde.DataBindings.Clear();
                lblest_s2_embalagemestoqueqtde.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s2_embalagemestoqueqtde", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s2_ec_valorcusto_faturamento_total.DataBindings.Clear();
                lblest_s2_ec_valorcusto_faturamento_total.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s2_custo_medio", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s2_valortotalfaturamentoliquido.DataBindings.Clear();
                lblest_s2_valortotalfaturamentoliquido.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s2_valortotalfaturamentoliquido", true, DataSourceUpdateMode.Never, true, "0.00");
                lblcalc_est_s2_margem.DataBindings.Clear();
                lblcalc_est_s2_margem.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s2_margem", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s2_pontos.DataBindings.Clear();
                lblest_s2_pontos.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s2_pontos", true, DataSourceUpdateMode.Never, true, "0");
                lblcalc_est_s2_preco_medio.DataBindings.Clear();
                lblcalc_est_s2_preco_medio.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s2_preco_medio", true, DataSourceUpdateMode.Never, true, "0.00");              
                



                //lblest_s1_data_ini.DataBindings.Clear();
                //lblest_s1_data_ini.DataBindings.Add("Text", Class__Manutencao.Precos_Unitarios, "est_s1_data_ini", true, DataSourceUpdateMode.Never, true, "dd");
                lblest_s1_embalagemestoqueqtde.DataBindings.Clear();
                lblest_s1_embalagemestoqueqtde.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s1_embalagemestoqueqtde", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s1_ec_valorcusto_faturamento_total.DataBindings.Clear();
                lblest_s1_ec_valorcusto_faturamento_total.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s1_custo_medio", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s1_valortotalfaturamentoliquido.DataBindings.Clear();
                lblest_s1_valortotalfaturamentoliquido.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s1_valortotalfaturamentoliquido", true, DataSourceUpdateMode.Never, true, "0.00");
                lblcalc_est_s1_margem.DataBindings.Clear();
                lblcalc_est_s1_margem.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s1_margem", true, DataSourceUpdateMode.Never, true, "0.00");
                lblest_s1_pontos.DataBindings.Clear();
                lblest_s1_pontos.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "est_s1_pontos", true, DataSourceUpdateMode.Never, true, "0");
                lblcalc_est_s1_preco_medio.DataBindings.Clear();
                lblcalc_est_s1_preco_medio.DataBindings.Add("Text", F0045_Preco.Precos_Unitarios, "calc_est_s1_preco_medio", true, DataSourceUpdateMode.Never, true, "0.00");              
                
                _EmbalagemHabilitaPreco();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_ProdutoPreco | _databinding" + ex.Message);
            }
        }
        private void _databinding_embalagens()
        {

            lbl_pr_descricao_Embalagem.Text = "";
            lbl_LAYER_PRECO_ALTERADO_Embalagem.Text = "";
            lbl_prc_valor_Embalagem.Text = "";

            //Mdo_ProdutoPreco SELECAO = (Mdo_ProdutoPreco)(dtgProduto.CurrentRow.DataBoundItem);

            Pag_Net.src.F0045_Preco.model.model_preco SELECAO = (model_preco)(dtgProduto.CurrentRow.DataBoundItem);

            F0045_Preco.ConsultarPrecosEmbalagens(SELECAO);
            dtgProdutoPrecoEmbalagem.DataSource = F0045_Preco.Precos_Embalagens;

            lbl_pr_descricao_Embalagem.DataBindings.Clear();
            lbl_LAYER_PRECO_ALTERADO_Embalagem.DataBindings.Clear();
            lbl_prc_valor_Embalagem.DataBindings.Clear();
            lbl_pr_embalagem.DataBindings.Clear();

            lbl_pr_descricao_Embalagem.DataBindings.Add("Text", F0045_Preco.Precos_Embalagens, "pr_descricao");
            lbl_LAYER_PRECO_ALTERADO_Embalagem.DataBindings.Add("Text", F0045_Preco.Precos_Embalagens, "local_PRECO_ALTERADO");
            lbl_prc_valor_Embalagem.DataBindings.Add("Text", F0045_Preco.Precos_Embalagens, "prc_valor");
            lbl_pr_embalagem.DataBindings.Add("Text", F0045_Preco.Precos_Embalagens, "pr_embalagemestoque");
        }
        private void _databinding_precos_alterados() 
        {
            try
            {
                F0045_Preco.ConsultarPrecosAlterados();
                DT_PrecosAlterados.DataSource = F0045_Preco.PrecosAlterados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DG_CellFormatting(object sender,System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "h_LAYER_MARGEM_PRECIFICACAO")
            {
                if (Convert.ToDouble(e.Value) < __ValorMinimoMargemSinalizar)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }

            
            

            if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "dtgProduto_MARGEM_PROMOCIONAL")
            {
                model_preco item = (model_preco)dtgProduto.Rows[e.RowIndex].DataBoundItem;
                if (Convert.ToDouble(e.Value) < __ValorMinimoMargemSinalizar)
                {
                    if (item.prc_valor_promocional > 0)
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                


                //Mdo_ProdutoPreco SELECAO_PRODUTO_UNITARIO = (Mdo_ProdutoPreco)(dtgProduto.CurrentRow.DataBoundItem);
                Pag_Net.src.F0045_Preco.model.model_preco SELECAO_PRODUTO_UNITARIO = (model_preco)(dtgProduto.CurrentRow.DataBoundItem);



                model_preco SELECAO = (model_preco)(((DataGridView)sender).CurrentRow.DataBoundItem);
                
                double valor_margem = 0;
                double valor_preco = 0;


                /* ALTERAÇÃO DE PREÇO VIA CAMPO MARGEM */
                if ((((DataGridView)sender).Name == "dtgProduto" && e.ColumnIndex == 7) || (((DataGridView)sender).Name == "dtgProdutoPrecoEmbalagem" && e.ColumnIndex == 7))
                {
                    F0045_Preco.AlterarMargem(SELECAO, SELECAO_PRODUTO_UNITARIO);
                }
                /* ALTERAÇÃO DE PREÇO VIA CAMPO PREÇO */
                if ((((DataGridView)sender).Name == "dtgProduto" && e.ColumnIndex == 8) || (((DataGridView)sender).Name == "dtgProdutoPrecoEmbalagem" && e.ColumnIndex == 8))
                {
                    valor_preco = ((model_preco)(((DataGridView)sender).CurrentRow.DataBoundItem)).local_PRECO_ALTERADO;
                    /*valor_margem = Math.Round( (valor_preco - SELECAO.ec_valor_custo_precificacao) / valor_preco * 100, 2);*/
                    valor_margem = Pag_Net.Tools.Calculo.MargemPreco.get(valor_preco, SELECAO.ec_valor_custo_precificacao);
                    SELECAO.local_MARGEM_PRECIFICACAO = valor_margem;
                    
                }

                // ALTERAÇÃO EM 11/03/2023 - NURE JUNIOR: ALTERAR PRECO PROMOCIONAL AUTOMATICAMENTE 

                if (SELECAO.LOCAL_prc_qtde_promocional == 1)
                {
                    MessageBox.Show("Qtde Promocional deve ser igual ou maior que 2 Unidades");
                    SELECAO.LOCAL_prc_qtde_promocional = SELECAO.prc_qtde_promocional;
                    SELECAO.LOCAL_prc_valor_promocional = SELECAO.prc_valor_promocional;
                    
                }

                if ((((DataGridView)sender).Name == "dtgProduto" && e.ColumnIndex == 8))
                {
                    if (SELECAO.LOCAL_prc_qtde_promocional > 0)
                    {
                        SELECAO.LOCAL_prc_valor_promocional = (SELECAO.prc_valor_promocional / SELECAO.prc_valor) * SELECAO.local_PRECO_ALTERADO;
                        ((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_valor_promocional"].Value = SELECAO.LOCAL_prc_valor_promocional.ToString("0.00");

                        ((DataGridView)sender).Rows[e.RowIndex].Cells["dtgProduto_MARGEM_PROMOCIONAL"].Value = SELECAO.LOCAL_prc_margem_promocional.ToString("0.00");
                    }

                }



                if ((((DataGridView)sender).Name == "dtgProduto" && e.ColumnIndex == 9))
                {

                    if (((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_qtde_promocional"].Value.ToString() == "")
                    {
                        ((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_valor_promocional"].Value = "0";
                    }

                    if (((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_qtde_promocional"].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_qtde_promocional"].Value) <= 0)
                            ((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_valor_promocional"].Value = "0";
                    }
                    ((DataGridView)sender).Rows[e.RowIndex].Cells["dtgProduto_MARGEM_PROMOCIONAL"].Value = SELECAO.LOCAL_prc_margem_promocional.ToString("0.00");
                }




                if ((((DataGridView)sender).Name == "dtgProduto" && e.ColumnIndex == 10))
                {

                    if ( ((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_valor_promocional"].Value.ToString() == "")
                    {
                        ((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_qtde_promocional"].Value = "0";
                    }

                    if (((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_valor_promocional"].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_valor_promocional"].Value) <= 0)
                            ((DataGridView)sender).Rows[e.RowIndex].Cells["__prca_qtde_promocional"].Value = "0";
                    }
                    ((DataGridView)sender).Rows[e.RowIndex].Cells["dtgProduto_MARGEM_PROMOCIONAL"].Value = SELECAO.LOCAL_prc_margem_promocional.ToString("0.00");
                }




                F0045_Preco.AlterarPreco(SELECAO, SELECAO_PRODUTO_UNITARIO);
                


                if (((DataGridView)sender).Name != "dtgProdutoPrecoEmbalagem")
                {
                    /*PRECIFICAÇÃO UNITARIA */
                    dtgProduto[5, e.RowIndex].Value = SELECAO.local_MARGEM_MEDIA.ToString("N4");
                    dtgProduto[8, e.RowIndex].Value = SELECAO.local_PRECO_ALTERADO.ToString("N2");
                    dtgProduto[7, e.RowIndex].Value = SELECAO.local_MARGEM_PRECIFICACAO.ToString("N2");
                    lbl_LAYER_PRECO_ALTERADO.Text = SELECAO.local_PRECO_ALTERADO.ToString("N2");
                    _databinding_embalagens();
                }
                else
                {

                    /* PRECIFICAÇÃO DA EMBALAGEM */
                    dtgProdutoPrecoEmbalagem[4, e.RowIndex].Value = SELECAO._local_FATORPRECO_ALTERADO.ToString("N4");
                    dtgProdutoPrecoEmbalagem[8, e.RowIndex].Value = SELECAO.local_PRECO_ALTERADO.ToString("N2");
                    dtgProdutoPrecoEmbalagem[7, e.RowIndex].Value = SELECAO.local_MARGEM_PRECIFICACAO.ToString("N2");

                    
                }

   

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na alteração do Preço" + ex.Message);
            }
        }


        private void dtgProduto_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dtgProduto_bool_pr_status_comercial_preco_inativo.ReadOnly)
                {
                    return;
                }
                if (dtgProduto.Columns[e.ColumnIndex].Name == "dtgProduto_bool_pr_status_comercial_preco_inativo")
                {
                    _Screen_wait(true);
                    model_preco SELECAO_INATIVAR = (model_preco)(dtgProduto.CurrentRow.DataBoundItem);
                    if (SELECAO_INATIVAR.bool_pr_status_comercial_preco_inativo)
                    {
                        SELECAO_INATIVAR.bool_pr_status_comercial_preco_inativo = false;
                    }
                    else
                    {
                        SELECAO_INATIVAR.bool_pr_status_comercial_preco_inativo = true;
                    }
                    F0045_Preco.InativarItemListaComercialPrecos(SELECAO_INATIVAR.pr_cdproduto, SELECAO_INATIVAR.bool_pr_status_comercial_preco_inativo);
                    _Screen_wait(false);
                }
            }
            catch (Exception ex)
            {
                _Screen_wait(false);
                MessageBox.Show(ex.Message);
            }
        }
        private void DG_SelectionChanged(object sender, EventArgs e)
        {
            _databinding_embalagens();
            _EmbalagemHabilitaPreco();
        }
        private void DG_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Screen_wait(true);
            string strColumnName = dtgProduto.Columns[e.ColumnIndex].DataPropertyName;
            F0045_Preco.OrderBy(strColumnName);
            _databinding();
            _Screen_wait(false);
        }
        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            if (cmbTabelaPrecificacao.SelectedIndex == 1 & !chkAgendamento_consulta.Checked)
            {
                MessageBox.Show("<PREÇO PROMOCIONAL> só é permitido para APLICAÇÕES AGENDADAS \n Clique em Agendamento e defina uma data futura de aplicação.", "PAG",MessageBoxButtons.OK);
                return;
            }

            if (cmbTabelaPrecificacao.SelectedIndex == 1 & dtpData_Agendamento.Value < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("<PREÇO PROMOCIONAL> só é permitido para APLICAÇÕES AGENDADAS \n Clique em Agendamento e defina uma data futura de aplicação.", "PAG", MessageBoxButtons.OK);
                return;
            }


            txtFILTRO_GRID_DESCRICAO.Text = "";
            chkComPreco.Checked = false;
            _pesquisar();
        }
        private void cmdlistar_alterados_Click(object sender, EventArgs e)
        {
            _databinding_precos_alterados(); 

        }
        private void cmdefetivar_precos_alterados_Click(object sender, EventArgs e)
        {
            try
            {
                //_databinding_precos_alterados();
                //_databinding_precos_alterados();
                if (!F0045_Preco.ExisteAlteracaoDePrecoPendente)
                {
                    MessageBox.Show("Não há registro de nenhum alteração de preço realizada!");
                    return;
                }
                if (tabControlPreco.SelectedIndex == 0)
                {
                    tabControlPreco.SelectedIndex = 1;
                }
                if (MessageBox.Show("Confirma a efetivação dos itens alterados?", "Pag | Alteração de Preços", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                    return;
                _Screen_wait(cmdefetivar_precos_alterados, true);
                _Screen_wait(cmdefetivar_precos_alterados, true);
                this.Refresh();
                this.Refresh();
                this.Refresh();

                /**** CLASS EFETIVAR ALTERAÇÃO DE PRODUTO **********/
                lbl_produto_info_alteracao.Visible = true;
                _Screen_wait(cmdefetivar_precos_alterados, true);
                this.Refresh();
                this.Refresh();
                this.Refresh();

                /***************************************************/
                /***************************************************/
                /***************************************************/

                /* APLICAÇÃO DE PREÇOS ___________________________________ */
                F0045_Preco.EfetivarAlteracoesDePreco();

                /* NOTIFICACAO __________________________________________ */
                Pag_Net.src.F0045_Preco.Notificar.Email_1100045001_NotificarAlteracaoPreco(Myconnect);

                /***************************************************/
                /***************************************************/
                /***************************************************/
                /***************************************************/

                lbl_produto_info_alteracao.Visible = false;
                this.Refresh();
                this.Refresh();
                this.Refresh();

                _Screen_wait(cmdefetivar_precos_alterados, false);
                MessageBox.Show("Alterações Efetivadas com sucesso. A tela será atualizada!");
                _Screen_wait(cmdefetivar_precos_alterados, true);
                tabControlPreco.SelectTab(0);
                
                _pesquisar();
                grp_filtros.Enabled = true;
                txtValorMinimoMargemSinalizar.Enabled =true;
                cmdAtualiza.Enabled = true;
                cmdCANCELA_Atualiza.Enabled = false;
                grp_grid.Enabled = false;

                txtFILTRO_GRID_DESCRICAO.Text = "";
                chkComPreco.Checked = false;
                _Screen_wait(cmdefetivar_precos_alterados, false);

                


                
            }
            catch (Exception ex)
            {
                _Screen_wait(cmdefetivar_precos_alterados, false);
                MessageBox.Show(ex.Message,"PAG", MessageBoxButtons.OK);
            }

        }
        private void tabControlPreco_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            switch (tabControlPreco.SelectedIndex)
            {
                case 1:
                _databinding_precos_alterados();
                break;

            }

        }
        private void DG_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmp_tab_produto_preco_Click(object sender, EventArgs e)
        {

        }

        private void cmdConsultar_Entradas_Click(object sender, EventArgs e)
        {

            try
            {
                frm_EstoqueCusto_Entrada frm;
                if (lbl_prb_cdprodutobluesoft.Text.Trim() != "")
                    frm = new frm_EstoqueCusto_Entrada(Myconnect, Convert.ToInt32(lbl_prb_cdprodutobluesoft.Text));
                else
                    frm = new frm_EstoqueCusto_Entrada(Myconnect);

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdCANCELA_Atualiza_Click(object sender, EventArgs e)
        {
            if (F0045_Preco.ExisteAlteracaoDePrecoPendente)
            {
                if (MessageBox.Show("Existe alterações de preços pendentes, deseja continuar? Os preços já alterados serão desconsiderados!", "Pag | Alteração de Preços", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    F0045_Preco.ExisteAlteracaoDePrecoPendente = false;
                }

            }
            
            
            _pesquisar();
            txtValorMinimoMargemSinalizar.Enabled = true;
            grp_filtros.Enabled = true;
            cmdAtualiza.Enabled = true;
            cmdCANCELA_Atualiza.Enabled = false;
            grp_grid.Enabled = false;
        }

        private void _EmbalagemHabilitaPreco()
        {
            dtgProdutoPrecoEmbalagem.Enabled = false;
            if (lbl_pr_embalagem.Text == "KG")
            {
                lbl_total_embalagens.Text = "Outras Embalagens para Precificação por KG - Embalagem";
                if (F0045_Preco.Precos_Embalagens.Count() > 0)
                {
                    if (lbl_LAYER_PRECO_ALTERADO.Text != "")
                    {
                        if (Convert.ToDouble(lbl_LAYER_PRECO_ALTERADO.Text) != 0)
                        {
                            dtgProdutoPrecoEmbalagem.Enabled = true;
                            lbl_total_embalagens.Text = string.Format("Total de Embalagens {0}", F0045_Preco.Precos_Embalagens.Count().ToString());
                        }
                        else
                        {
                            lbl_total_embalagens.Text = "Indique um preço no Código Unit para precificar as embalagens";
                        }
                    }

                }
                else
                {
                    lbl_total_embalagens.Text = "Produtos Sem embalagens";
                }
            }
            else
            {
                lbl_total_embalagens.Text = "Precificação por embalagem não permitida para 'UN'";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_pr_cdproduto.Text != "")
                {
                    forms.Loja.Preco.frm_ProdutoPrecoLog frmLog = new frm_ProdutoPrecoLog(Myconnect, Convert.ToInt32(lbl_pr_cdproduto.Text));
                    frmLog.ShowDialog(); 
                }

                   
            }
            catch (Exception ex)
            {

            }
        }

 





 
        
    }
}
