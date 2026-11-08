using Pag_Net.Bll;
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
    public partial class frm_ProdutoPreco_Listagem : Form
    {
        public Pag_Net.Models.modelSistemaUsuario Myconnect;
        Pag_Net.R0022.Bll.Execute _ProdutoDepSecaoGrupoSubgrupo;
        Pag_Net.Bll.F0020_Produto.Defaut_Filter Filter_Produto;

        DataTable DATATABLE_dtgProdutoPrecoListagem;
        //DataTable DATATABLE_Agendamento;


        int Tab_pre_cd = 0;


        public frm_ProdutoPreco_Listagem(Pag_Net.Models.modelSistemaUsuario myconnect)
        {
            InitializeComponent();
            Myconnect = myconnect;
            Filter_Produto = new Pag_Net.Bll.F0020_Produto.Defaut_Filter();
            _ProdutoDepSecaoGrupoSubgrupo = new Pag_Net.R0022.Bll.Execute(Myconnect);
            _Screen_load();
        }


        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(cmdAtualiza, true);


                DATATABLE_dtgProdutoPrecoListagem = Pag_Net.Bll.Precos.Consultar.get(Myconnect, Filter_Produto, Tab_pre_cd, true, 0, chkpreco_definido.Checked);
                dtg_agendamento_geral.DataSource = Pag_Net.Bll.Precos.ConsultarAgendamentos.get(Myconnect, Filter_Produto, Tab_pre_cd, false, 0, dtpData_Agendamento_Inicial.Value, dtpData_Agendamento_final.Value);
 
                _databinding();
                _Screen_wait(cmdAtualiza, false);
            }
            catch (Exception ex)
            {
                _Screen_wait(cmdAtualiza, false);
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _Screen_load()
        {
            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            cmdAtualiza.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
            cmdDetalheEmbalagem.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\detalhe.ico");
            //cmdefetivar_precos_alterados.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\ok.ico");
            //cmdDetalhe.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\detalhe.ico");

            /* Text Box Format All */


            /* DataGrid - Format */

            dtgAgendamento.AutoGenerateColumns = false; 
            dtgProdutoPrecoListagem_Embalagem.AutoGenerateColumns = false;
            dtgProdutoPrecoListagem.AutoGenerateColumns = false;
            dtgProdutoPrecoListagem.SelectionChanged += new System.EventHandler(this.DG_SelectionChanged);
            chkSeleciona_Data_Cadastro.Checked = false;

            dtpData_Agendamento_Inicial.Value = DateTime.Now;
            dtpData_Agendamento_final.Value = DateTime.Now.AddDays(15);

            //dtpData_Agendamento.DataBindings.Add("Enabled", chkAgendamento_consulta, "Checked");
            //BLL.Data_Agendamento = dtpData_Agendamento.Value;

            dtpDataCadastroIni.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");
            dtpDataCadastroFim.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");

            dtg_agendamento_geral.AutoGenerateColumns = false;


            cmbTabelaPrecificacao.DisplayMember = "tab_pre_descricao";
            cmbTabelaPrecificacao.ValueMember = "tab_pre_cd";
            cmbTabelaPrecificacao.DataSource = Pag_Net.Bll.Precos.TabelasdePrecos.Get(Myconnect);

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


            txtcdproduto.TextChanged += new EventHandler(_Screen_changed);
            txtcdprodutobluesoft.TextChanged += new EventHandler(_Screen_changed);
            txtdescricao.TextChanged += new EventHandler(_Screen_changed);
            chkSeleciona_Data_Cadastro.CheckedChanged += new EventHandler(_Screen_changed);
            //chkAgendamento_consulta.CheckedChanged += new EventHandler(_Screen_changed);
            dtpDataCadastroIni.ValueChanged += new EventHandler(_Screen_changed);
            dtpDataCadastroFim.ValueChanged += new EventHandler(_Screen_changed);
            cmbDepartamento.TextChanged += new EventHandler(_Screen_changed);
            cmbsecao.TextChanged += new EventHandler(_Screen_changed);
            cmbgrupo.TextChanged += new EventHandler(_Screen_changed);
            cmbsubgrupo.TextChanged += new EventHandler(_Screen_changed);
            cmbTabelaPrecificacao.TextChanged += new EventHandler(_Screen_changed);
            //dtpData_Agendamento.TextChanged += new EventHandler(_Screen_changed);
            lbl_pr_cdproduto.TextChanged += new EventHandler(_Screen_changed);
            chkpreco_definido.CheckedChanged += new EventHandler(_Screen_changed);

            //dtgProdutoPrecoListagem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DG_CellFormatting);
            //dtgProdutoPrecoListagem.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(DG_ColumnHeaderMouseClick);

            /*
             * this.dtgProduto.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellValueChanged);
             * this.dtgProdutoPrecoEmbalagem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellValueChanged);
             */

            cmbTabelaPrecificacao.SelectedIndex = 0;

            //dtpData_Agendamento.Value = DateTime.Now;
            dtpDataCadastroIni.Value = DateTime.Now;
            dtpDataCadastroFim.Value = DateTime.Now;

            cmbTabelaPrecificacao.SelectedIndex = 0;
            //chkAgendamento_consulta.Checked = false;
            Tab_pre_cd = Convert.ToInt32(cmbTabelaPrecificacao.SelectedValue);

            chkpreco_definido.Checked = true;
        }
        private void _databinding()
        {
            try
            {
                lbl_contagem.Text = "0";
                dtgProdutoPrecoListagem.DataSource = DATATABLE_dtgProdutoPrecoListagem;
                lbl_contagem.Text = DATATABLE_dtgProdutoPrecoListagem.Rows.Count.ToString();
                //dtg_agendamento_geral.DataSource = Pag_Net.Bll.Precos.ConsultarAgendamentos.get(Myconnect, new Pag_Net.Models.Filter.Produto(0), Tab_pre_cd, true,0, dtpData_Agendamento_Inicial.Value, dtpData_Agendamento_final.Value);
                lbl_pr_cdproduto.DataBindings.Clear();
                lbl_pr_descricao.DataBindings.Clear();
                lbl_pr_cdproduto.DataBindings.Add("Text", DATATABLE_dtgProdutoPrecoListagem, "pr_cdproduto");
                lbl_pr_descricao.DataBindings.Add("Text", DATATABLE_dtgProdutoPrecoListagem, "pr_descricao");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
                        dtgProdutoPrecoListagem_Embalagem.DataSource = null;
                        dtgAgendamento.DataSource = null;
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
                    switch (((TextBox)sender).Name)
                    {
                        case "txtcdproduto":
                            Filter_Produto.CdProduto = txtcdproduto.Text;
                            break;
                        case "txtcdprodutobluesoft":
                            Filter_Produto.CdProdutoBluesoft = txtcdprodutobluesoft.Text;
                            break;
                        case "txtdescricao":
                            Filter_Produto.Descricao = txtdescricao.Text;
                            break;
                    }

                }

                if (sender.GetType().Name == "DateTimePicker")
                {
                    switch (((DateTimePicker)sender).Name)
                    {
                        case "dtpDataCadastroIni":
                            Filter_Produto.Dt_cadastro_ini = dtpDataCadastroIni.Value;
                            break;
                        case "dtpDataCadastroFim":
                            Filter_Produto.Dt_cadastro_fim = dtpDataCadastroFim.Value;
                            break;
                        //case "dtpData_Agendamento":
                        //    BLL.Data_Agendamento = dtpData_Agendamento.Value;
                        //    break;

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
                            Filter_Produto.Seleciona_Data_Cadastro = chkSeleciona_Data_Cadastro.Checked;
                            break;

                        case "chkpreco_definido":
                            if (chkpreco_definido.Checked)
                            {
                                lbl_preco_definido_chk.Text = "Consulta apenas Itens que possuem Preço";
                            }
                            else
                            {
                                lbl_preco_definido_chk.Text = "Consulta TODOS os itens";
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
                        case "cmbTabelaPrecificacao":
                            Tab_pre_cd = Convert.ToInt32(cmbTabelaPrecificacao.SelectedValue);
                            break;

                    }

                    Filter_Produto.Prd_cddepartamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
                    Filter_Produto.Prd_cdsecao = Convert.ToInt32(cmbsecao.SelectedValue);
                    Filter_Produto.Prd_cdgrupo = Convert.ToInt32(cmbgrupo.SelectedValue);
                    Filter_Produto.Prd_subcdgrupo = Convert.ToInt32(cmbsubgrupo.SelectedValue);

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
        private void DG_SelectionChanged(object sender, EventArgs e)
        {
       
        }

        private void cmdDetalheEmbalagem_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(cmdAtualiza, true);
                dtgProdutoPrecoListagem_Embalagem.DataSource = Pag_Net.Bll.Precos.Consultar.get(Myconnect, new Pag_Net.Bll.F0020_Produto.Defaut_Filter(Convert.ToInt32(lbl_pr_cdproduto.Text)), Tab_pre_cd, false);
                dtgAgendamento.DataSource = Pag_Net.Bll.Precos.ConsultarAgendamentos.get(Myconnect, new Pag_Net.Bll.F0020_Produto.Defaut_Filter(Convert.ToInt32(lbl_pr_cdproduto.Text)), Tab_pre_cd, true);
                _databinding();
                _Screen_wait(cmdAtualiza, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

    }
}



					
					
					
					
					
					
					
					
					
					
					
					
					