using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pag_Net.Bll.F0030_EstoqueCusto;

namespace Pag_Form.forms
{
    public partial class frm_EstoqueCusto : Form
    {
        Pag_Net.Models.modelSistemaUsuario        MyConnect;
        Pag_Net.Bll.F0030_EstoqueCusto.Wk WK;
        Pag_Net.Bll.F0020_Produto.Defaut_Filter Filter_Produto;
        Pag_Net.R0022.Bll.Execute           _ProdutoDepSecaoGrupoSubgrupo;
        //DataTable                           DATATABLE_dtgEstoqueCusto;
        bool                                __310002_ACESSO_ALTERA_CUSTO = false;

        int Tab_pre_cd = 0;


        public frm_EstoqueCusto(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;

            WK = new Pag_Net.Bll.F0030_EstoqueCusto.Wk(MyConnect);

            _ProdutoDepSecaoGrupoSubgrupo = new Pag_Net.R0022.Bll.Execute(MyConnect);
            _Screen_load();
        }

        private void _Screen_load()
        {
            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            cmdAtualiza.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
            cmdImportarArquivoEntrada.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\direita.ico");
            cmdConsultar_Entradas.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\find.ico");
            cmdConsultaCadastro.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\find.ico");
            cmdAlterar_Custo.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\edit.ico");

            dtgProdutoEstoqueCusto.AutoGenerateColumns = false;
            dtgProdutoEstoqueCusto.SelectionChanged += new System.EventHandler(this.DG_SelectionChanged);
          
            
            /*DTG 

                | COlumns do Data Grid | 
                EC_VALOR_CUSTO_FATURAMENTO
                ec_valor_custo_faturamento_margem
                EC_VALOR_CUSTO_PRECIFICACAO
                ec_valor_custo_precificacao_margem
                PRC_VALOR
                EC_EMBALAGEMESTOQUE_QTDE
                EC_EMBALAGEMESTOQUE_QTDE_ONLINE
                EC_EMBALAGEMESTOQUE_FV_PENDENTE
                ec_data_atualizacao_dia
                ec_data_atualizacao_online
                dtlog_update
                proc_log_arquivo_seq
                dtlog_update_api
                pr_cesta_char
             
             
             */

            chkSeleciona_Data_Cadastro.Checked = false;

            dtpDataCadastroIni.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");
            dtpDataCadastroFim.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");

            cmbTabelaPrecificacao.DisplayMember = "tab_pre_descricao";
            cmbTabelaPrecificacao.ValueMember = "tab_pre_cd";
            cmbTabelaPrecificacao.DataSource = Pag_Net.Bll.Precos.TabelasdePrecos.Get(MyConnect);

            cmbDepartamento.DisplayMember = "prd_descricao";
            cmbsecao.DisplayMember = "prs_descricao";
            cmbDepartamento.ValueMember = "prd_cddepartamento";
            cmbDepartamento.DataSource = _ProdutoDepSecaoGrupoSubgrupo.Departamento();
            cmbDepartamento.SelectedIndex = 0;

            cmbsecao.ValueMember = "prs_cdsecao";
            cmbsecao.DisplayMember = "prs_descricao";
            cmbsecao.DataSource = _ProdutoDepSecaoGrupoSubgrupo.Secao(0);
            cmbsecao.SelectedIndex = 0;

            cmbgrupo.ValueMember = "prg_cdgrupo";
            cmbgrupo.DisplayMember = "prg_descricao";
            cmbgrupo.DataSource = _ProdutoDepSecaoGrupoSubgrupo.Grupo(0, 0);
            cmbgrupo.SelectedIndex = 0;

            cmbsubgrupo.ValueMember = "prsg_cdsubgrupo";
            cmbsubgrupo.DisplayMember = "prsg_descricao";
            cmbsubgrupo.DataSource = _ProdutoDepSecaoGrupoSubgrupo.SubGrupo(0, 0, 0);
            cmbsubgrupo.SelectedIndex = 0;


            chkSeleciona_Data_Cadastro.CheckedChanged += new EventHandler(_Screen_changed);

            cmbDepartamento.TextChanged += new EventHandler(_Screen_changed);
            cmbsecao.TextChanged += new EventHandler(_Screen_changed);
            cmbgrupo.TextChanged += new EventHandler(_Screen_changed);
            cmbsubgrupo.TextChanged += new EventHandler(_Screen_changed);
            cmbTabelaPrecificacao.TextChanged += new EventHandler(_Screen_changed);
            lbl_pr_cdproduto.TextChanged += new EventHandler(_Screen_changed);
            cmbTabelaPrecificacao.SelectedIndex = 0;
            dtpDataCadastroIni.Value = DateTime.Now;
            dtpDataCadastroFim.Value = DateTime.Now;
            cmbTabelaPrecificacao.SelectedIndex = 0;
            Tab_pre_cd = Convert.ToInt32(cmbTabelaPrecificacao.SelectedValue);


            dtp_Custo_Entrada_Data_Inicial.DataBindings.Add("Enabled", chkCUSTO_ENTRADA_DATA, "Checked");
            dtp_Custo_Entrada_Data_Final.DataBindings.Add("Enabled", chkCUSTO_ENTRADA_DATA, "Checked");
            chkCUSTO_ENTRADA_DATA.Checked = false;


            cmdImportarArquivoEntrada.Enabled = false;
            cmdAlterar_Custo.Enabled = false;

            if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 310001))
            {
                cmdImportarArquivoEntrada.Enabled = true;
            }

            if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 310002))
            {
                __310002_ACESSO_ALTERA_CUSTO = true;
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

                if (sender.GetType().Name == "Label")
                {
                    if (((Label)sender).Name == "lbl_pr_cdproduto")
                    {
                      if (lbl_pr_cdproduto.Text != "")
                      {
                          if (__310002_ACESSO_ALTERA_CUSTO)
                          {
                              cmdAlterar_Custo.Enabled = true;
                          }
                      }
                      else
                      {
                          cmdAlterar_Custo.Enabled = false;
                      }
                    }
                }

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

                }

                if (sender.GetType().Name == "DateTimePicker")  {  }


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
                            break;
                    }

                }


                if (sender.GetType().Name == "ComboBox")
                {
                    switch (((ComboBox)sender).Name)
                    {
                        case "cmbDepartamento":
                            cmbsecao.DataSource = _ProdutoDepSecaoGrupoSubgrupo.Secao(Convert.ToInt32(cmbDepartamento.SelectedValue));
                            cmbgrupo.DataSource = _ProdutoDepSecaoGrupoSubgrupo.Grupo(Convert.ToInt32(cmbDepartamento.SelectedValue), 0);
                            cmbsubgrupo.DataSource = _ProdutoDepSecaoGrupoSubgrupo.SubGrupo(Convert.ToInt32(cmbDepartamento.SelectedValue), 0, 0);
                            break;
                        case "cmbsecao":
                            cmbgrupo.DataSource = _ProdutoDepSecaoGrupoSubgrupo.Grupo(Convert.ToInt32(cmbDepartamento.SelectedValue), Convert.ToInt32(cmbsecao.SelectedValue));
                            cmbsubgrupo.DataSource = _ProdutoDepSecaoGrupoSubgrupo.SubGrupo(Convert.ToInt32(cmbDepartamento.SelectedValue), Convert.ToInt32(cmbsecao.SelectedValue), 0);
                            break;
                        case "cmbgrupo":
                            cmbsubgrupo.DataSource = _ProdutoDepSecaoGrupoSubgrupo.SubGrupo(Convert.ToInt32(cmbDepartamento.SelectedValue), Convert.ToInt32(cmbsecao.SelectedValue), Convert.ToInt32(cmbgrupo.SelectedValue));
                            break;

                    }

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

        private void Consultar()
        {
            try
            {
                WK.Filter.Binding();

                if (txtcdproduto.Text.Trim() != "") WK.Filter.CdProduto = Convert.ToInt32(txtcdproduto.Text);
                if (txtcdprodutobluesoft.Text.Trim() != "") WK.Filter.CdProdutoBluesoft = Convert.ToInt32(txtcdprodutobluesoft.Text);
                if (txtdescricao.Text.Trim() != "") WK.Filter.Descricao = txtdescricao.Text;
                if (chkSeleciona_Data_Cadastro.Checked)
                {
                    WK.Filter.Seleciona_Data_Cadastro = 1;
                    WK.Filter.Dt_cadastro_ini = dtpDataCadastroIni.Value;
                    WK.Filter.Dt_cadastro_fim = dtpDataCadastroFim.Value;
                }
                else
                {
                    WK.Filter.Seleciona_Data_Cadastro = 0;
                }
                WK.Filter.Tab_pre_cd = Convert.ToInt32(cmbTabelaPrecificacao.SelectedValue);
                WK.Filter.Prd_cddepartamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
                WK.Filter.Prd_cdsecao = Convert.ToInt32(cmbsecao.SelectedValue);
                WK.Filter.Prd_cdgrupo = Convert.ToInt32(cmbgrupo.SelectedValue);
                WK.Filter.Prd_subcdgrupo = Convert.ToInt32(cmbsubgrupo.SelectedValue);
               
                lbl_contagem.Text = "0";

                dtgProdutoEstoqueCusto.DataSource = WK.EstoqueCusto_List_get();
                lbl_contagem.Text = WK.List.Count().ToString();

                UserTools._Screen_DataBinding_Set(lbl_pr_cdproduto, WK.List, "pr_cdproduto");
                UserTools._Screen_DataBinding_Set(lbl_pr_descricao, WK.List, "pr_descricao");
                UserTools._Screen_DataBinding_Set(lbl_ec_embalagemestoque_qtde, WK.List, "ec_embalagemestoque_qtde");
                UserTools._Screen_DataBinding_Set(lbl_ec_embalagemestoque_qtde_online, WK.List, "ec_embalagemestoque_qtde_online");


                UserTools._Screen_DataBinding_Set(lbl_ec_embalagemestoque_fv_pendente, WK.List, "ec_embalagemestoque_fv_pendente");
                UserTools._Screen_DataBinding_Set(lbl_prb_cdprodutobluesoft, WK.List, "prb_cdprodutobluesoft");
                UserTools._Screen_DataBinding_Set(lbl_prc_valor, WK.List, "prc_valor");
                UserTools._Screen_DataBinding_Set(lbl_pr_cesta_char, WK.List, "pr_cesta_char");
                UserTools._Screen_DataBinding_Set(lbl_ec_valor_custo_faturamento, WK.List, "ec_valor_custo_faturamento");
                UserTools._Screen_DataBinding_Set(lbl_ec_valor_custo_precificacao, WK.List, "ec_valor_custo_precificacao");

                UserTools._Screen_DataBinding_Set(lbl_ec_data_atualizacao_dia, WK.List, "ec_data_atualizacao_dia");
                UserTools._Screen_DataBinding_Set(lbl_dtlog_update_api, WK.List, "dtlog_update_api");
                UserTools._Screen_DataBinding_Set(lbl_dtlog_update, WK.List, "dtlog_update");
                UserTools._Screen_DataBinding_Set(lbl_proc_log_arquivo_seq, WK.List, "proc_log_arquivo_seq");

                UserTools._Screen_DataBinding_Set(lbl_ec_composicao_vl_mao_de_obra, WK.List, "ec_composicao_vl_mao_de_obra");
                UserTools._Screen_DataBinding_Set(lbl_ec_composicao_vl_custo_indireto, WK.List, "ec_composicao_vl_custo_indireto");
                UserTools._Screen_DataBinding_Set(lbl_ec_composicao_itens, WK.List, "ec_composicao_itens");
                UserTools._Screen_DataBinding_Set(lbl_ec_composicao_vl_custo, WK.List, "ec_composicao_vl_custo");
                UserTools._Screen_DataBinding_Set(lbl_prb_tipo_composicao_cd_char, WK.List, "prb_tipo_composicao_cd_char");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void DG_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(cmdAtualiza, true);

                Consultar();
                _Screen_wait(cmdAtualiza, false);
            }
            catch (Exception ex)
            {
                _Screen_wait(cmdAtualiza, false);
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void cmdImportarArquivoEntrada_Click(object sender, EventArgs e)
        {
            Frm_EstoqueCusto_Importacao frm = new Frm_EstoqueCusto_Importacao(MyConnect);
            frm.ShowDialog();

        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdConsultar_Entradas_Click(object sender, EventArgs e)
        {
            try
            {
                frm_EstoqueCusto_Entrada frm;
                if (lbl_prb_cdprodutobluesoft.Text.Trim() != "")
                    frm = new frm_EstoqueCusto_Entrada(MyConnect, Convert.ToInt32(lbl_prb_cdprodutobluesoft.Text));
                else
                    frm = new frm_EstoqueCusto_Entrada(MyConnect);

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdConsultaCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_pr_cdproduto.Text != "0" && lbl_pr_cdproduto.Text != "")
                {
                    _Screen_wait(cmdConsultaCadastro, true);
                    forms.Cadastros.Produto.frm_Produto frm = new forms.Cadastros.Produto.frm_Produto(MyConnect, Convert.ToInt32(lbl_pr_cdproduto.Text));
                    _Screen_wait(cmdConsultaCadastro, false);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdAlterar_Custo_Click(object sender, EventArgs e)
        {
            try
            {

                if ( Convert.ToInt32(lbl_pr_cdproduto.Text) == 0)
                {
                    MessageBox.Show("Produto NÃO identificado");
                    return;
                }
                _Screen_wait(cmdAlterar_Custo, true);


                model_estoquecusto SELECAO = (model_estoquecusto)(dtgProdutoEstoqueCusto.CurrentRow.DataBoundItem);

                frm_EstoqueCusto_Alteracao frm = new frm_EstoqueCusto_Alteracao(MyConnect, SELECAO);
                _Screen_wait(cmdAlterar_Custo, false);
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
