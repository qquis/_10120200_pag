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
    public partial class frm_Loja_Etiqueta_Gondola : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0020_Produto.Defaut_Filter Filter_Produto;
        int __Numero_Etiquetas_Maximo = 5;
        DataTable _DataTable_Etiqueta;
        Pag_Net.R0022.Bll.Execute _ProdutoDepSecaoGrupoSubgrupo;
        public frm_Loja_Etiqueta_Gondola(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            Filter_Produto = new Pag_Net.Bll.F0020_Produto.Defaut_Filter();
            _ProdutoDepSecaoGrupoSubgrupo = new Pag_Net.R0022.Bll.Execute(MyConnect);
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {

                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                cmdAtualiza.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
                cmdSelecaoCANCELA.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\cima.ico");
                cmdSelecionaTUDO.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdefetivar_precos_alterados.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\print.ico");
                cmdFiltro_Alteracao.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");

                dtgEtiqueta_Precos.AutoGenerateColumns = false;

                dtgProcessos_Precos.AutoGenerateColumns = false;
                
                dtpDataCadastroIni.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");
                dtpDataCadastroFim.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");
                chkSeleciona_Data_Cadastro.Checked = false;

                
                //dtpDataAlteracaoPreco_Inicial.DataBindings.Add("Enabled", chkSelecionaDataAlteracaoPreco, "Checked");
                //dtpDataAlteracaoPreco_Final.DataBindings.Add("Enabled", chkSelecionaDataAlteracaoPreco, "Checked");
                grp_filtro_seq.DataBindings.Add("Enabled", chkSelecionaDataAlteracaoPreco, "Checked");
                chkSelecionaDataAlteracaoPreco.Checked = false;
                chkSelecionaDataAlteracaoPreco.Enabled = false;
 


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

                txt_CodigoBARRA.TextChanged += new EventHandler(_Screen_changed);
                txtcdproduto.TextChanged += new EventHandler(_Screen_changed);
                txtcdprodutobluesoft.TextChanged += new EventHandler(_Screen_changed);
                txtdescricao.TextChanged += new EventHandler(_Screen_changed);
                chkSeleciona_Data_Cadastro.CheckedChanged += new EventHandler(_Screen_changed);
                dtpDataCadastroIni.ValueChanged += new EventHandler(_Screen_changed);
                dtpDataCadastroFim.ValueChanged += new EventHandler(_Screen_changed);
                cmbDepartamento.TextChanged += new EventHandler(_Screen_changed);
                cmbsecao.TextChanged += new EventHandler(_Screen_changed);
                cmbgrupo.TextChanged += new EventHandler(_Screen_changed);
                cmbsubgrupo.TextChanged += new EventHandler(_Screen_changed);
                dtpDataCadastroIni.Value = DateTime.Now;
                dtpDataCadastroFim.Value = DateTime.Now;
                chkSelecionaDataAlteracaoPreco.CheckedChanged += new EventHandler(_Screen_changed);


                txt_CodigoBARRA.GotFocus += new EventHandler(_Screen_gotFocus);
                txt_CodigoBARRA.LostFocus += new EventHandler(_Screen_lostFocus);


                //if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 411101))
                if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 412001))
                {
                    __Numero_Etiquetas_Maximo = 0;
                }
                else 
                {
                    __Numero_Etiquetas_Maximo = 5;

                }

                //if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 411102))
                if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 412002))
                {
                    chkSelecionaDataAlteracaoPreco.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Inicializçaão do Formulário: " + ex.Message);
            }
                
                

        }
        private void _Screen_gotFocus(object sender, EventArgs e)
        {

            txt_CodigoBARRA.BackColor = Color.Yellow;

            //this.tGID.GotFocus += OnFocus;
            //this.tGID.LostFocus += OnDefocus;
        }
        private void _Screen_lostFocus(object sender, EventArgs e)
        {

            txt_CodigoBARRA.BackColor = Color.White;

            //this.tGID.GotFocus += OnFocus;
            //this.tGID.LostFocus += OnDefocus;
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {

                if (sender.GetType().Name == "Label")
                {
                    if (((Label)sender).Name == "lbl_pr_cdproduto")
                    {

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
                            Filter_Produto.Descricao = txtdescricao.Text.ToUpper();
                            break;
                        case "txt_CodigoBARRA":
                            if (txt_CodigoBARRA.Text.Length > 0)
                            {
                                Filter_Produto.Codigo_de_Barra = txt_CodigoBARRA.Text.ToString().Trim().Replace("F","").Replace("f","");
                            }
                            else
                            {
                                Filter_Produto.Codigo_de_Barra = "0";
                            }
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
                        case "chkSelecionaDataAlteracaoPreco":
                            if (!chkSelecionaDataAlteracaoPreco.Checked)
                            {
                                lbl_seq_alteracao_preco.Text = "0";
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
        private void _databinding()
        {
            _Screen_wait(cmdAtualiza, true);
            _DataTable_Etiqueta = Pag_Net.Bll.Loja.EtiquetaPrecos_Consultar.get(MyConnect, Filter_Produto,Convert.ToInt32(lbl_seq_alteracao_preco.Text), chkSelecionaDataAlteracaoPreco.Checked, dtpDataAlteracaoPreco_Inicial.Value, dtpDataAlteracaoPreco_Final.Value);

            dtgEtiqueta_Precos.DataSource = _DataTable_Etiqueta;
            lbl_info_Total_Etiquetas.Text = "";
            lbl_info_Total_Etiquetas.Text = _DataTable_Etiqueta.Rows.Count.ToString();

            /* Se o campo Código de barra foi utilziadao para a pesquisa e o número de etiqueras não superar o valor de 15 */
            if (txt_CodigoBARRA.Text.Trim() != "" && _DataTable_Etiqueta.Rows.Count <= 15)
            {
                /*Habilita todas as linhas localizadas para a impressão */
                for (int i = 0; i <= dtgEtiqueta_Precos.Rows.Count - 1; i++)
                {
                    dtgEtiqueta_Precos.Rows[i].Cells[0].Value = true;
                }
                /*Efetua a Impressão da etiqueta */
                _imprimir_Etiquetas();
                _clean_filtros();
                /*------------------------------ */
                dtgEtiqueta_Precos.DataSource = null;
                txt_CodigoBARRA.Text = "";
            }
            _Screen_wait(cmdAtualiza, false);
        }
        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                _databinding();
            }
            catch (Exception ex)
            {
                _Screen_wait(cmdAtualiza, false);
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdefetivar_precos_alterados_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                _imprimir_Etiquetas();
                _clean_filtros();
                UserTools._Screen_Wait(this);
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

         
        }
        private void txt_CodigoBARRA_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_CodigoBARRA.Text.Trim().Length > 0)
            {
                try
                {
                    _databinding();
                }
                catch (Exception ex)
                {
                    _Screen_wait(cmdAtualiza, false);
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void _imprimir_Etiquetas()
        {


            Pag_Net.Bll.Loja.EtiquetaPrecos_Imprimir IMPRIMIR = new Pag_Net.Bll.Loja.EtiquetaPrecos_Imprimir();

            double _TOTAL_ETIQUETAS =  dtgEtiqueta_Precos.Rows.Count - 1;
            
            if (__Numero_Etiquetas_Maximo != 0)
            {
                if (_TOTAL_ETIQUETAS > __Numero_Etiquetas_Maximo)
                    _TOTAL_ETIQUETAS = __Numero_Etiquetas_Maximo;

                int conta_impressao = 0;
                for (int i = 0; i <= dtgEtiqueta_Precos.Rows.Count - 1; i++)
                {

                    if (Convert.ToBoolean(dtgEtiqueta_Precos.Rows[i].Cells[0].Value) == true)
                    {
                        conta_impressao = conta_impressao + 1;
                        if (conta_impressao > __Numero_Etiquetas_Maximo)
                        {
                            _GridEtiquetaSELECAO(false);
                            MessageBox.Show("Operação Não Permitida: Número máximo de Etiqueta atingido", "PAG", MessageBoxButtons.OK);
                            
                        }
                    }
                }
            }

            

            for (int i = 0; i <= dtgEtiqueta_Precos.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(dtgEtiqueta_Precos.Rows[i].Cells[0].Value) == true)
                {
                    Pag_Net.Bll.Loja.Db.Etiqueta __ETIQUETA = new Pag_Net.Bll.Loja.Db.Etiqueta();
                    __ETIQUETA.CdProduto = Convert.ToInt32(dtgEtiqueta_Precos.Rows[i].Cells["dtgEtiqueta_Precos_prb_cdprodutoblueosft"].Value.ToString());
                    __ETIQUETA.Descricao = dtgEtiqueta_Precos.Rows[i].Cells["dtgEtiqueta_Precos_prb_descricao"].Value.ToString();
                    __ETIQUETA.Embalagem = dtgEtiqueta_Precos.Rows[i].Cells["dtgEtiqueta_Precos_pr_embalagemestoque"].Value.ToString();
                    __ETIQUETA.EmbalagemDescricao = dtgEtiqueta_Precos.Rows[i].Cells["dtgEtiqueta_Precos_prb_descricao"].Value.ToString();
                    __ETIQUETA.CodigoBarra = dtgEtiqueta_Precos.Rows[i].Cells["dtgEtiqueta_Precos_preg_cdbarra"].Value.ToString();
                    __ETIQUETA.ValorPreco = Convert.ToDouble(dtgEtiqueta_Precos.Rows[i].Cells["dtgEtiqueta_Precos_prc_valor"].Value.ToString());

                    if (__ETIQUETA.Embalagem == "UN")
                    {
                        __ETIQUETA.TipoCodigoBarra = "EAN13";
                    }


                    if (Convert.ToDouble(dtgEtiqueta_Precos.Rows[i].Cells["dtgEtiqueta_Precos_prc_qtde_promocional"].Value.ToString()) > 0)
                    {
                        __ETIQUETA.AtacadoQtdeMinima = Convert.ToDouble(dtgEtiqueta_Precos.Rows[i].Cells["dtgEtiqueta_Precos_prc_qtde_promocional"].Value.ToString());
                        __ETIQUETA.AtacadoQtdePromocional = Convert.ToDouble(dtgEtiqueta_Precos.Rows[i].Cells["dtgEtiqueta_Precos_prc_qtde_promocional"].Value.ToString());
                        __ETIQUETA.ValorPromocional = Convert.ToDouble(dtgEtiqueta_Precos.Rows[i].Cells["dtgEtiqueta_Precos_prc_valor_promocional"].Value.ToString());
                        __ETIQUETA.AtacadoEmbalagem = "CX";
                    }
                    else
                    {
                        __ETIQUETA.AtacadoQtdeMinima = 0;

                        __ETIQUETA.AtacadoQtdePromocional = 0;
                        __ETIQUETA.AtacadoEmbalagem = "";
                        __ETIQUETA.AtacadoCodigoBarra = "";
                    }
                    IMPRIMIR.Adicionar(__ETIQUETA);
                }
            }
            IMPRIMIR.Imprimir();
        }

        private void cmdSelecaoCANCELA_Click(object sender, EventArgs e)
        {
            _Screen_wait(cmdSelecaoCANCELA, true);
            _GridEtiquetaSELECAO(false);
            _Screen_wait(cmdSelecaoCANCELA, false);
        }

        private void cmdSelecionaTUDO_Click(object sender, EventArgs e)
        {
            _Screen_wait(cmdSelecionaTUDO, true);
            _GridEtiquetaSELECAO(true);
            _Screen_wait(cmdSelecionaTUDO, false);
        }

        private void _GridEtiquetaSELECAO( bool SELECAO )
        {
            Pag_Net.Bll.Loja.EtiquetaPrecos_Imprimir IMPRIMIR = new Pag_Net.Bll.Loja.EtiquetaPrecos_Imprimir();

            double _TOTAL_ETIQUETAS = dtgEtiqueta_Precos.Rows.Count - 1;
            if (SELECAO)
            {
                if (__Numero_Etiquetas_Maximo != 0)
                {
                    if (_TOTAL_ETIQUETAS > __Numero_Etiquetas_Maximo)
                        _TOTAL_ETIQUETAS = __Numero_Etiquetas_Maximo - 1;
                }
            }
            for (int i = 0; i <= _TOTAL_ETIQUETAS; i++)
            {

                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dtgEtiqueta_Precos.Rows[i].Cells[0];
                    chk.Value = SELECAO;
            }

        }

        private void _databinding_filtro()
        {
            try
            {
                dtgProcessos_Precos.DataSource = Pag_Net.Bll.Processo.Consultar.LOG(
                    MyConnect,
                    dtpDataAlteracaoPreco_Inicial.Value,
                    dtpDataAlteracaoPreco_Final.Value,
                    0,
                    100101,
                    100);
                    
                    lbl_seq_alteracao_preco.DataBindings.Clear();
                    lbl_seq_alteracao_preco.DataBindings.Add("Text", dtgProcessos_Precos.DataSource, "proc_log_seq");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdFiltro_Alteracao_Click(object sender, EventArgs e)
        {
            _databinding_filtro();

        }

        private void _clean_filtros()
        {
            txtdescricao.Text = "";
            txtcdproduto.Text = "";
            txtcdprodutobluesoft.Text = "";
            txt_CodigoBARRA.Text = "";
            cmbDepartamento.SelectedIndex = 0;
            dtgEtiqueta_Precos.DataSource = null;

        }


        private void cmdConsultarAlteracoEmLote_Click(object sender, EventArgs e)
        {
            try
            {
                Pag_Form.forms.Loja.frm_Loja_Agendamento_Lote frmAgendamentoLote = new Loja.frm_Loja_Agendamento_Lote(MyConnect);
                frmAgendamentoLote.ShowDialog();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdImprimirCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dtgEtiqueta_Precos.CurrentRow.Index > -1)
                {
                    //MessageBox.Show(dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prb_cdprodutoblueosft"].Value.ToString());

                    if (dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prb_cdprodutoblueosft"].Value.ToString() == "")
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Selecione um produto");
                        return;
                    }

                    /*
                    if (dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_pr_embalagemestoque"].Value.ToString() != "UN")
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Selecione um produto do tipo UN");
                        return;
                    }*/

                    int pr_cdproduto = Convert.ToInt32(dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prb_cdprodutoblueosft"].Value.ToString());
                    string prb_descricao = dtgEtiqueta_Precos.Rows[dtgEtiqueta_Precos.CurrentRow.Index].Cells["dtgEtiqueta_Precos_prb_descricao"].Value.ToString();



                    Loja.Frm_Loja_Etiqueta_Gondola_Caixa frm = new Loja.Frm_Loja_Etiqueta_Gondola_Caixa(MyConnect, pr_cdproduto, prb_descricao);
                    frm.ShowDialog();
                }
                else
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Selecione um produto");
                    return;

                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
    }
}
