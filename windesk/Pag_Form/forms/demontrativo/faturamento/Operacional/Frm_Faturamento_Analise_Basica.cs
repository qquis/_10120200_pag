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
    public partial class Frm_Faturamento_Analise_Basica : Form
    {
        private static int _SIS_AC_CD = 5111;

        Pag_Net.src.F0070_Faturamento._indexReport F0070_Faturamento_Report;


        //Pag_Net.Bll.F0055_Faturamento_Zanthus.WkFaturamento_Relatorio_Analise_Basica _BLL_Faturamento;
        Pag_Net.Bll.F0002_Enterprise.WkEmpresaOperacao _BLL_F0002_EmpresaOperacao;
        Pag_Net.Bll.F0020_Produto.WkComplementos _BLL_Produto;
        //Pag_Net.Bll.Produto.Depto _BLL_ProdutoDepartamento;
        Pag_Net.Bll.F0020_Produto.WKDepto _BLL_ProdutoDepartamento;

        //Pag_Net.Bll.F0011_Participante.Wk _BLL_ParticipantePessoa;
        Pag_Net.Bll.F0012_GrupoEconomico.Wk _BLL_GrupoEconomico; 

        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public Frm_Faturamento_Analise_Basica(Pag_Net.Models.modelSistemaUsuario _Myconnect)
        {
            InitializeComponent();
            MyConnect = _Myconnect;
            //_BLL_Faturamento = new Pag_Net.Bll.F0055_Faturamento_Zanthus.WkFaturamento_Relatorio_Analise_Basica(MyConnect);
            _BLL_ProdutoDepartamento = new Pag_Net.Bll.F0020_Produto.WKDepto(MyConnect, _SIS_AC_CD);
            _BLL_Produto = new Pag_Net.Bll.F0020_Produto.WkComplementos(MyConnect, _SIS_AC_CD);
            //_BLL_ParticipantePessoa = new Pag_Net.Bll.F0011_Participante.Wk(Myconnect);
            _BLL_GrupoEconomico = new Pag_Net.Bll.F0012_GrupoEconomico.Wk(MyConnect);

            

            _Screen_load();
            

        }
        private void _Screen_load()
        {
            try
            {


                F0070_Faturamento_Report = new Pag_Net.src.F0070_Faturamento._indexReport(MyConnect);
                F0070_Faturamento_Report.PropertyChanged += _dataBinding;

                UserTools._Screen_Form_Open(this);
                UserTools._Screen_ButtonImage(cmdAtualiza, UserTools.PagButtonsIcons.Atualiza);

                chkDataFaturamento.CheckedChanged += new EventHandler(_Screen_changed);
                dtpdatafaturamento_ini.ValueChanged += new EventHandler(_Screen_changed);
                dtpdatafaturamento_ini.DataBindings.Add("Enabled", chkDataFaturamento, "Checked");
                dtpdatafaturamento_fim.ValueChanged += new EventHandler(_Screen_changed);
                dtpdatafaturamento_fim.DataBindings.Add("Enabled", chkDataFaturamento, "Checked");
                chkDataFaturamento.Checked = true;

                chkDataEmissao.CheckedChanged += new EventHandler(_Screen_changed);
                dtpDataEmissao_Ini.ValueChanged += new EventHandler(_Screen_changed);
                dtpDataEmissao_Ini.DataBindings.Add("Enabled", chkDataEmissao, "Checked");
                dtpDataEmissao_Fim.ValueChanged += new EventHandler(_Screen_changed);
                dtpDataEmissao_Fim.DataBindings.Add("Enabled", chkDataEmissao, "Checked");
                chkDataEmissao.Checked = false;

                dtgfaturamento_rel_analise_basica.AutoGenerateColumns = false;
                dtgfaturamento_rel_analise_basica.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(DG_ColumnHeaderMouseClick);
                

                _BLL_F0002_EmpresaOperacao = new Pag_Net.Bll.F0002_Enterprise.WkEmpresaOperacao(MyConnect);
                _BLL_F0002_EmpresaOperacao.Filter_EmpresaOperacao.sis_ac_cd = _SIS_AC_CD;
                _BLL_F0002_EmpresaOperacao.EmpresaOperacoes_User_List_DataBindings();

                cmbEmpresa.DataSource = _BLL_F0002_EmpresaOperacao.List_User_Empresa;
                cmbEmpresa.SelectedIndex = 0;

                _DataBindEmpresaSelect();
               
                cmbDepartamento.DataSource = _BLL_ProdutoDepartamento.Departamento();
                cmbDepartamento.SelectedIndex = 0;

                cmbsecao.DataSource = _BLL_ProdutoDepartamento.Secao(0);
                cmbsecao.SelectedIndex = 0;

                cmbgrupo.DataSource = _BLL_ProdutoDepartamento.Grupo(0, 0);
                cmbgrupo.SelectedIndex = 0;

                cmbsubgrupo.DataSource = _BLL_ProdutoDepartamento.SubGrupo(0, 0, 0);
                cmbsubgrupo.SelectedIndex = 0;

                //_BLL_Faturamento._filter.tipo_visualizacao = 10; /*ABRE O TIPO DE FILTRO EM PRODUTO*/

                cmbEmpresa.SelectedValueChanged += new EventHandler(_Screen_changed);
                cmbOpcaoVisualizacao.SelectedValueChanged += new EventHandler(_Screen_changed);
                cmbFaturamentoStatus.SelectedValueChanged += new EventHandler(_Screen_changed);
                cmbOperacao.SelectedValueChanged += new EventHandler(_Screen_changed);
                cmbDepartamento.TextChanged += new EventHandler(_Screen_changed);
                cmbsecao.TextChanged += new EventHandler(_Screen_changed);
                cmbgrupo.TextChanged += new EventHandler(_Screen_changed);
                cmbsubgrupo.TextChanged += new EventHandler(_Screen_changed);
                cmbTbPessoa_Produto_Encarregado.TextChanged += new EventHandler(_Screen_changed);
                txtpr_cdproduto.TextChanged += new EventHandler(_Screen_changed);
                txtprb_cdprodutobluesoft.TextChanged += new EventHandler(_Screen_changed);
                txtpr_descricao.TextChanged += new EventHandler(_Screen_changed);
                txtcliente_nome_razao.TextChanged += new EventHandler(_Screen_changed);


                cmbVendedor.DataSource = Pag_Net.Bll.F0011_Participante.ComboBox.Vendedores(MyConnect);
                cmbVendedor.SelectedValueChanged += new EventHandler(_Screen_changed);

                cmbfabricante.DataSource = Pag_Net.Bll.F0011_Participante.ComboBox.Fabricante(MyConnect);
                cmbfabricante.SelectedValueChanged += new EventHandler(_Screen_changed);
                
                /*BINDING FATURAMENTO STATUS _ INICIAR COMO FATURADO*/
                F0070_Faturamento_Report.getFaturamentoStatus(1);
                cmbFaturamentoStatus.SelectedIndex = 2;

                /*BINDING FATURAMENTO TIPO_VISUALIZACAO */
                F0070_Faturamento_Report.getFaturamentoTipoVisualizacao();
                cmbOpcaoVisualizacao.SelectedIndex = 0;

                /*BINDING GRUPO ECONOMICO */
                chkGrupoEconomicoTOP.Checked = false;
                DataBinding_cmbGrupoEconomico(0);

                _DataBindSecaoEncarregado();
                _DataTabControlPessoa();



                set_DTGVisible_Margem(MyConnect.PermissaoConsultar(511105));
              

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

                if (e.PropertyName == "rptfaturamentoStatus")
                {
                    cmbFaturamentoStatus.DataSource = F0070_Faturamento_Report.rptfaturamentoStatus.report;
                }

                if (e.PropertyName == "rpttipoVisualizacao")
                {
                    cmbOpcaoVisualizacao.DataSource = F0070_Faturamento_Report.rpttipoVisualizacao.report;
                }

                if (e.PropertyName == "rptFaturamentoAnalise")
                {
                    dtgfaturamento_rel_analise_basica.DataSource = F0070_Faturamento_Report.rptFaturamentoAnalise.report;
                    foreach (Control i in this.Controls)
                    {
                        string tipo = i.GetType().Name;
                        if (i.GetType().Name == "Label")
                        {
                            string _nome = ((Label)i).Name.ToString();
                            if (((Label)i).Name.ToString().Length >= 7)
                            {
                                if (((Label)i).Name.ToString().Substring(0, 7) == "lbl_db_")
                                {
                                    int _tamanho = ((Label)i).Name.ToString().Length;
                                    string string_nome_do_campo = ((Label)i).Name.ToString().Trim().Replace("lbl_db_", "");


                                    ((Label)i).DataBindings.Clear();
                                    ((Label)i).DataBindings.Add("Text"
                                        , dtgfaturamento_rel_analise_basica.DataSource
                                        , string_nome_do_campo
                                        , true
                                        , DataSourceUpdateMode.Never
                                        , 0.00
                                        , "#,###,##0.00");
                                }
                            }
                        }

                    }

                    lbl_info_Wk_Total_ec_valorcusto_faturamento_total.Text = F0070_Faturamento_Report.rptFaturamentoAnalise.__Wk_Total_ec_valorcusto_faturamento_total.ToString("#,###,#0.00");
                    lbl_info_Wk_Total_embalagemestoqueqtde.Text = F0070_Faturamento_Report.rptFaturamentoAnalise.__Wk_Total_embalagemestoqueqtde.ToString("#,###,#0.00");
                    lbl_info_Wk_Total_embalagemcompraqtde.Text = F0070_Faturamento_Report.rptFaturamentoAnalise.__Wk_Total_embalagemcompraqtde.ToString("#,###,#0.00");
                    lbl_info_Wk_Total_valortotalfaturamentobase.Text = F0070_Faturamento_Report.rptFaturamentoAnalise.__Wk_Total_valortotalfaturamentoBASE.ToString("#,###,#0.00");
                    lbl_info_Wk_MG_valortotalfaturamentobase.Text = F0070_Faturamento_Report.rptFaturamentoAnalise.__Wk_MG_valortotalfaturamentoBASE.ToString("#,###,#0.00");


                    lbl_info_Wk_Total_valortotalfaturamento.Text = F0070_Faturamento_Report.rptFaturamentoAnalise.__Wk_Total_valortotalfaturamento.ToString("#,###,#0.00");
                    lbl_info_Wk_Total_valortotalfaturamentoliquido.Text = F0070_Faturamento_Report.rptFaturamentoAnalise.__Wk_Total_valortotalfaturamentoliquido.ToString("#,###,#0.00");
                    lbl_info_Wk_MG_valortotalfaturamento.Text = F0070_Faturamento_Report.rptFaturamentoAnalise.__Wk_MG_valortotalfaturamento.ToString("#,###,#0.00");
                    lbl_info_Wk_MG_valortotalfaturamentoliquido.Text = F0070_Faturamento_Report.rptFaturamentoAnalise.__Wk_MG_valortotalfaturamentoliquido.ToString("#,###,#0.00");
                    lbl_info_Wk_Numero_Itens.Text = F0070_Faturamento_Report.rptFaturamentoAnalise.__Wk_Numero_Itens.ToString("0");
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
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
                        case "cmbDepartamento":
                            cmbsecao.DataSource = _BLL_ProdutoDepartamento.Secao(Convert.ToInt32(cmbDepartamento.SelectedValue));
                            cmbgrupo.DataSource = _BLL_ProdutoDepartamento.Grupo(Convert.ToInt32(cmbDepartamento.SelectedValue), 0);
                            cmbsubgrupo.DataSource = _BLL_ProdutoDepartamento.SubGrupo(Convert.ToInt32(cmbDepartamento.SelectedValue), 0, 0);
                            break;
                        case "cmbsecao":
                            cmbgrupo.DataSource = _BLL_ProdutoDepartamento.Grupo(Convert.ToInt32(cmbDepartamento.SelectedValue), Convert.ToInt32(cmbsecao.SelectedValue));
                            cmbsubgrupo.DataSource = _BLL_ProdutoDepartamento.SubGrupo(Convert.ToInt32(cmbDepartamento.SelectedValue), Convert.ToInt32(cmbsecao.SelectedValue), 0);
                            break;
                        case "cmbgrupo":
                            cmbsubgrupo.DataSource = _BLL_ProdutoDepartamento.SubGrupo(Convert.ToInt32(cmbDepartamento.SelectedValue), Convert.ToInt32(cmbsecao.SelectedValue), Convert.ToInt32(cmbgrupo.SelectedValue));
                            break;
                        case "cmbEmpresa":
                            _DataBindEmpresaSelect();
                            _DataBindSecaoEncarregado();
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

                lblOpcaoVisualizacao.Text = "Visualização por: " + cmbOpcaoVisualizacao.Text;
                lblEmpresa.Text = "Empresa: " + cmbEmpresa.Text;
                lblFaturamentoStatus.Text = "Status: " + cmbFaturamentoStatus.Text;
                lblOperacao.Text = "Operação: " + cmbOperacao.Text;
            }

            catch (Exception ErroMessage)
            {
                if (sender.GetType().Name == "TextBox") {((TextBox)sender).Text = "0";}
                MessageBox.Show(ErroMessage.Message);
            }
        }



        private void _DataBindEmpresaSelect()
        {
            cmbOperacao.DataSource = _BLL_F0002_EmpresaOperacao.Operacao_User_List_Get(((Pag_Net.Bll.F0002_Enterprise.TbEmpresa)cmbEmpresa.SelectedItem));
        }
        private void _DataBindSecaoEncarregado()
        {
            cmbTbPessoa_Produto_Encarregado.DataSource = _BLL_Produto.DataBindings_Encarregados(Convert.ToInt32(cmbEmpresa.SelectedValue), Convert.ToInt32(cmbOperacao.SelectedValue));
        }
        private void _DataTabControlPessoa()
        {
            if (Convert.ToInt32(cmbOperacao.SelectedValue) == 1) tabfiltropessoa.SelectedIndex = 1;
            if (Convert.ToInt32(cmbOperacao.SelectedValue) == 2) tabfiltropessoa.SelectedIndex = 0; 
        }

        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);

                if (Convert.ToInt32(cmbOperacao.SelectedValue) == 0)
                {
                    F0070_Faturamento_Report.filterFaturamento.op_cdoperacao_list = "";
                }
                else
                {
                    F0070_Faturamento_Report.filterFaturamento.op_cdoperacao_list = cmbOperacao.SelectedValue.ToString();
                }


                F0070_Faturamento_Report.filterFaturamento.pr_cdproduto = "";
                if (txtpr_cdproduto.Text != "")
                    F0070_Faturamento_Report.filterFaturamento.pr_cdproduto = txtpr_cdproduto.Text.ToString().Trim();


                F0070_Faturamento_Report.filterFaturamento.prb_cdprodutobluesoft = "";
                if (txtprb_cdprodutobluesoft.Text != "")
                    F0070_Faturamento_Report.filterFaturamento.prb_cdprodutobluesoft = txtprb_cdprodutobluesoft.Text.Trim();
                F0070_Faturamento_Report.filterFaturamento.pr_descricao = "";
                if (txtpr_descricao.Text != "")
                    F0070_Faturamento_Report.filterFaturamento.pr_descricao = txtpr_descricao.Text;
                F0070_Faturamento_Report.filterFaturamento.nome_razao = "";
                if (txtcliente_nome_razao.Text != "")
                    F0070_Faturamento_Report.filterFaturamento.nome_razao = txtcliente_nome_razao.Text.Replace("'", "").ToUpper();




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

                F0070_Faturamento_Report.filterFaturamento.prd_cddepartamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
                F0070_Faturamento_Report.filterFaturamento.prs_cdsecao = Convert.ToInt32(cmbsecao.SelectedValue);
                F0070_Faturamento_Report.filterFaturamento.prg_cdgrupo = Convert.ToInt32(cmbgrupo.SelectedValue);
                F0070_Faturamento_Report.filterFaturamento.prsg_cdsubgrupo = Convert.ToInt32(cmbsubgrupo.SelectedValue);
                F0070_Faturamento_Report.filterFaturamento.tipo_visualizacao = Convert.ToInt32(cmbOpcaoVisualizacao.SelectedValue);
                if (Convert.ToInt32(cmbEmpresa.SelectedValue) == 0)
                {
                    F0070_Faturamento_Report.filterFaturamento.em_cdempresa_list = "";
                }
                else
                {
                    F0070_Faturamento_Report.filterFaturamento.em_cdempresa_list = cmbEmpresa.SelectedValue.ToString();
                }
                F0070_Faturamento_Report.filterFaturamento.cdpessoabluesoft_secao_encarregado = Convert.ToInt32(cmbTbPessoa_Produto_Encarregado.SelectedValue);
                F0070_Faturamento_Report.filterFaturamento.cdpessoabluesoft_fabricante = Convert.ToInt32(cmbfabricante.SelectedValue);
                F0070_Faturamento_Report.filterFaturamento.faturamento_cdparticipante_vendedor = Convert.ToInt32(cmbVendedor.SelectedValue);
                F0070_Faturamento_Report.filterFaturamento.cdgrupoeconomico = Convert.ToInt32(cmbGrupoEconomico.SelectedValue);
                F0070_Faturamento_Report.filterFaturamento.statusfaturamento = Convert.ToInt32(cmbFaturamentoStatus.SelectedValue);


                int clienteTop = 0;
                if (chkGrupoEconomicoTOP.Checked)
                    clienteTop = 1;

                F0070_Faturamento_Report.filterFaturamento.grupo_economico_top = clienteTop;


                F0070_Faturamento_Report.filterFaturamento.numeroPedidoList = "";
                F0070_Faturamento_Report.filterFaturamento.numeroPedidoList = txtNumeroPedido.Text;

                F0070_Faturamento_Report.filterFaturamento.ECF = 0;
                F0070_Faturamento_Report.filterFaturamento.numeroCupomFiscalList = "";

                if (txtECF.Text != "")
                    F0070_Faturamento_Report.filterFaturamento.ECF = Convert.ToInt32(txtECF.Text);

                F0070_Faturamento_Report.filterFaturamento.numeroCupomFiscalList = txtNumeroCupom.Text.ToString();


                F0070_Faturamento_Report.getFaturamentoAnalise(true, "");

                UserTools._Screen_Wait(this);


                //_DataBind();
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

        private void DG_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UserTools._Screen_Wait(this);
            string strColumnName = dtgfaturamento_rel_analise_basica.Columns[e.ColumnIndex].DataPropertyName;
            F0070_Faturamento_Report.getFaturamentoAnalise(false, strColumnName);
            UserTools._Screen_Wait(this);
        }


        private void set_DTGVisible_Margem(bool habilitar)
        {
            DTG_static_faturamentoliquido_margem.Visible = habilitar;
            DTGec_valorcusto_faturamento_total.Visible = habilitar;
            DTG_static_faturamento_margem.Visible = habilitar;
            lbl_info_Wk_MG_valortotalfaturamentobase.Visible = habilitar;
            lbl_info_Wk_MG_valortotalfaturamento.Visible = habilitar;
            lbl_info_Wk_MG_valortotalfaturamentoliquido.Visible = habilitar;
            lbl_db__static_faturamentobase_margem.Visible = habilitar;
            lbl_db__static_faturamento_margem.Visible = habilitar;
            lbl_db__static_faturamentobruto_margem.Visible = habilitar;
            lbl_db__static_faturamentoliquido_margem.Visible = habilitar;
            lbllabel_custo.Visible = habilitar;
            lbl_info_Wk_Total_ec_valorcusto_faturamento_total.Visible = habilitar;

        }


        private void DataBinding_cmbGrupoEconomico(int clienteTop)
        {
            try
            {
                cmbGrupoEconomico.ValueMember = "cdgrupoeconomico";
                cmbGrupoEconomico.DisplayMember = "descricao";
                cmbGrupoEconomico.DataSource = Pag_Net.Bll.F0012_GrupoEconomico.ComboBox.GrupoEconomico(MyConnect, clienteTop);
                cmbGrupoEconomico.SelectedValueChanged += new EventHandler(_Screen_changed);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void chkGrupoEconomicoTOP_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int clienteTop = 0;
                if (chkGrupoEconomicoTOP.Checked)
                    clienteTop = 1;


                //_BLL_Faturamento._filter.grupo_economico_top = clienteTop;


                UserTools._Screen_Wait(this);
                DataBinding_cmbGrupoEconomico(clienteTop);
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmbOperacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (Convert.ToInt32(cmbOperacao.SelectedValue) == 1) tabfiltropessoa.SelectedIndex = 1;
                if (Convert.ToInt32(cmbOperacao.SelectedValue) == 2) tabfiltropessoa.SelectedIndex = 0;

                _DataBindSecaoEncarregado();
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}

