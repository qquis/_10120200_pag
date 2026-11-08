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

namespace Pag_Form.forms.Loja.Preco
{
    public partial class frm_ProdutoPreco_Listagem : Form
    {
        public Pag_Net.Models.modelSistemaUsuario Myconnect;
        Pag_Net.R0022.Bll.Execute _ProdutoDepSecaoGrupoSubgrupo;

        Pag_Net.src.F0045_Preco.reports._indexReport F0045_PRECO;

        int Tab_pre_cd = 0;

        public frm_ProdutoPreco_Listagem(Pag_Net.Models.modelSistemaUsuario myconnect)
        {
            InitializeComponent();
            Myconnect = myconnect;

            F0045_PRECO = new Pag_Net.src.F0045_Preco.reports._indexReport(Myconnect);

            _ProdutoDepSecaoGrupoSubgrupo = new Pag_Net.R0022.Bll.Execute(Myconnect);
            _Screen_load();
        }
        private void _Screen_load()
        {

            UserTools._Screen_Form_Open(this);
            UserTools._Screen_ButtonImage(cmdAtualiza, UserTools.PagButtonsIcons.Atualiza);
            UserTools._Screen_ButtonImage(cmdDetalheEmbalagem, UserTools.PagButtonsIcons.Detalhe);
            UserTools._Screen_Form_Format_DataGridView(dtgPrecoListagem);
            UserTools._Screen_Form_Format_DataGridView(dtgPrecoAgendamentoListagem);
            UserTools._Screen_Form_Format_DataGridView(dtgAgendamento);
            UserTools._Screen_Form_Format_DataGridView(dtgProdutoPrecoListagem_Embalagem);



            chkSeleciona_Data_Cadastro.Checked = false;

            dtpData_Agendamento_Inicial.Value = DateTime.Now;
            dtpData_Agendamento_final.Value = DateTime.Now.AddDays(15);


            dtpDataCadastroIni.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");
            dtpDataCadastroFim.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");



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


            cmbDepartamento.TextChanged += new EventHandler(_Screen_changed);
            cmbsecao.TextChanged += new EventHandler(_Screen_changed);
            cmbgrupo.TextChanged += new EventHandler(_Screen_changed);
            cmbsubgrupo.TextChanged += new EventHandler(_Screen_changed);
            cmbTabelaPrecificacao.TextChanged += new EventHandler(_Screen_changed);
            lbl_pr_cdproduto.TextChanged += new EventHandler(_Screen_changed);
            chkpreco_definido.CheckedChanged += new EventHandler(_Screen_changed);


            cmbTabelaPrecificacao.SelectedIndex = 0;

            dtpDataCadastroIni.Value = DateTime.Now;
            dtpDataCadastroFim.Value = DateTime.Now;

            cmbTabelaPrecificacao.SelectedIndex = 0;
            Tab_pre_cd = Convert.ToInt32(cmbTabelaPrecificacao.SelectedValue);

            chkpreco_definido.Checked = true;


            F0045_PRECO.PropertyChanged += _databinding;

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

                }

                if (sender.GetType().Name == "DateTimePicker")
                {

                }


                if (sender.GetType().Name == "CheckBox")
                {


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
        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                F0045_PRECO.filterClear();
                F0045_PRECO.filtro.tab_pre_cd = Convert.ToInt32(cmbTabelaPrecificacao.SelectedValue); 


                if (txtcdproduto.Text != "")
                    F0045_PRECO.filtro.cdproduto = Convert.ToInt32(txtcdproduto.Text);

                if (txtcdprodutobluesoft.Text != "")
                    F0045_PRECO.filtro.cdprodutobluesoft = Convert.ToInt32(txtcdprodutobluesoft.Text);

                if (txtdescricao.Text != "")
                    F0045_PRECO.filtro.descricao = txtdescricao.Text;

                if (chkSeleciona_Data_Cadastro.Checked)
                {
                    F0045_PRECO.filtro.seleciona_data_cadastro = 1;
                    F0045_PRECO.filtro.dt_cadastro_ini = dtpDataCadastroIni.Value;
                    F0045_PRECO.filtro.dt_cadastro_fim = dtpDataCadastroFim.Value;
                }

                F0045_PRECO.filtro.dt_agendamento_ini = dtpData_Agendamento_Inicial.Value;
                F0045_PRECO.filtro.dt_agendamento_fim = dtpData_Agendamento_final.Value;

                F0045_PRECO.filtro.prd_cddepartamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
                F0045_PRECO.filtro.prs_cdsecao = Convert.ToInt32(cmbsecao.SelectedValue);
                F0045_PRECO.filtro.prg_cdgrupo = Convert.ToInt32(cmbgrupo.SelectedValue);
                F0045_PRECO.filtro.prsg_cdsubgrupo = Convert.ToInt32(cmbsubgrupo.SelectedValue);

                UserTools._Screen_Wait(this);
                F0045_PRECO.PrecoListagemConsultar();
                F0045_PRECO.PrecoAgendamentoListagemConsultar();
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
        private void cmdDetalheEmbalagem_Click(object sender, EventArgs e)
        {
            try
            {
                //UserTools._Screen_Wait(this);
                //dtgProdutoPrecoListagem_Embalagem.DataSource = Pag_Net.Bll.Precos.Consultar.get(Myconnect, new Pag_Net.Bll.F0020_Produto.Defaut_Filter(Convert.ToInt32(lbl_pr_cdproduto.Text)), Tab_pre_cd, false);
                //dtgAgendamento.DataSource = Pag_Net.Bll.Precos.ConsultarAgendamentos.get(Myconnect, new Pag_Net.Bll.F0020_Produto.Defaut_Filter(Convert.ToInt32(lbl_pr_cdproduto.Text)), Tab_pre_cd, true);
                //_databinding();
                //_Screen_wait(cmdAtualiza, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        private void _databinding(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dbList_PrecoListagem")
            {
                dtgPrecoListagem.DataSource = F0045_PRECO.dbList_PrecoListagem.List;
                lbl_contagem.Text = F0045_PRECO.dbList_PrecoListagem.Count.ToString();
                UserTools._Screen_DataBinding_Set(lbl_pr_cdproduto, F0045_PRECO.dbList_PrecoListagem.List, "pr_cdproduto");
            }

            if (e.PropertyName == "dbList_PrecoListagemAgendamento")
            {
                dtgPrecoAgendamentoListagem.DataSource = F0045_PRECO.dbList_PrecoListagemAgendamento.List;
                
            }
        }


 





    }
}



					
					
					
					
					
					
					
					
					
					
					
					
					