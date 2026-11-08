/*
 * 31/03/2022[1] - quinta feira: Alteração do binding das tarefas
 * 31/03/2022[1] - permitir que o comando de exportação de arquivo funcione em etapas diferentes do processamento
 * 
 * 
 * 
 * 
 */


using Pag_Net.Bll.Interface.Comercial;
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
    public partial class frm_Interface_Comercial_Pre_Ped : Form
    {

        tbcomercial_pre_pedido _TBCOMERCIAL_PRE_PEDIDO;
        Pag_Net.Bll.Interface.Comercial.Pre_Pedido BLL;
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        bool TAREFA_611010_FINALIZA_ETAPA_02 = false;
        bool TAREFA_611020_FINALIZA_ETAPA_02_RECUSAR = false;
        bool TAREFA_611030_FINALIZA_ETAPA_03 = false;
        bool TAREFA_611040_FINALIZA_ETAPA_04 = false;


        int __CONTROLE_REG_FILA_SEQ = 0;
        int __CONTROLE_ETAPA_CD = 0;
        int __FV_FABRICANTE_DIVISAO_CD = 0;
        string __CONTROLE_ETAPA_DESCRICAO = "";
        string __CONTROLE_STATUS_DESCRICAO = "";
        //int __CONTROLE_STATUS_CD = 0;

        public frm_Interface_Comercial_Pre_Ped(Pag_Net.Models.modelSistemaUsuario _MyConnect, tbcomercial_pre_pedido _TbComercial_Pre_Pedido)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _TBCOMERCIAL_PRE_PEDIDO = _TbComercial_Pre_Pedido;

            
            _Screen_load();
        }

        public void _Screen_load()
        {
            //___________________DataGrids_____________________________________
            dtg_etapa.AutoGenerateColumns = false;
            dtgSugestaoCompra.AutoGenerateColumns = false;
            dtgSugestaoCompra.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(DG_ColumnHeaderMouseClick);
            this.dtgSugestaoCompra.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);

            //___________________Public VAR ___________________________________


            //___________________CMDS _________________________________________
            cmdsolicitar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdETAPA_FINALIZA_02.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdETAPA_FINALIZA_02_RECUSAR.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdETAPA_FINALIZA_03.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdETAPA_FINALIZA_04.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdExportarArquivo.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\salva.ico");
            cmdExportarArquivo.Enabled = false;
            cmdsolicitar.Click += new EventHandler(_cmd_etapa);
            cmdETAPA_FINALIZA_02.Click += new EventHandler(_cmd_etapa);
            cmdETAPA_FINALIZA_02_RECUSAR.Click += new EventHandler(_cmd_etapa);
            cmdETAPA_FINALIZA_03.Click += new EventHandler(_cmd_etapa);
            cmdETAPA_FINALIZA_04.Click += new EventHandler(_cmd_etapa);



            TAREFA_611010_FINALIZA_ETAPA_02 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 611010);
            TAREFA_611020_FINALIZA_ETAPA_02_RECUSAR = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 611020);
            TAREFA_611030_FINALIZA_ETAPA_03 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 611030);
            TAREFA_611040_FINALIZA_ETAPA_04 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 611040);


            //___________________LABELS ________________________________________
            
            lbl_pr_cdproduto.TextChanged += new EventHandler(_text_changed);
            lbl_controle_etapa_cd.TextChanged += new EventHandler(_text_changed);

            //___________________TEXTS ________________________________________
            txtdescricao.Text = "";
            txtprbf_codigo_referencia.Text = "";
            txtfabricante_cdpessoabluesoft.Text = _TBCOMERCIAL_PRE_PEDIDO.fabricante_cdpessoabluesoft.ToString();
            txtfabricante_nomerazao.Text = Pag_Net.Bll.Pessoa.Pool.PessoaBlueSoft_Consultar(MyConnect, _TBCOMERCIAL_PRE_PEDIDO.fabricante_cdpessoabluesoft).Rows[0][2].ToString();
            txtdescricao.TextChanged += new EventHandler(_text_changed);
            txtprbf_codigo_referencia.TextChanged += new EventHandler(_text_changed);




            //___________________VALORES FIXOX______________________________
            DataTable Datatable_PesquisarCodigoDivisao = Pag_Net.Bll.Cadastros_Gerais.Poll.Get_DataTable_Fabricantes_Distribuicao(MyConnect, _TBCOMERCIAL_PRE_PEDIDO.fabricante_cdpessoabluesoft);
            if (Datatable_PesquisarCodigoDivisao.Rows.Count > 0)
            {
                __FV_FABRICANTE_DIVISAO_CD = Convert.ToInt32(Datatable_PesquisarCodigoDivisao.Rows[0]["fv_fabricante_divisao_cd"].ToString());
                txtfv_fabricante_divisao_cd.Text = __FV_FABRICANTE_DIVISAO_CD.ToString();
            }



            //___________________BINDINGS INICIAIS______________________________
            _Controle_Etapa_Consultar();

        }
        private void _text_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label")
                {
                    if (((Label)sender).Name == "lbl_pr_cdproduto")
                    {
                        if (((Label)sender).Text != "")
                        {
                            Pag_Net.Bll.Interface.Comercial.tbfat_res_comercial item_FAT_RES_COMERCIAL = (tbfat_res_comercial)dtgSugestaoCompra.Rows[dtgSugestaoCompra.SelectedRows[0].Index].DataBoundItem;
                            Pag_Net.Bll.Interface.Comercial.tbfat_res_comercial_item_format_venda_qtde[] __LISTA_QTDE = Pag_Net.Bll.Interface.Comercial.Tool.get_fat_res_comercial_item_format_venda_qtde(item_FAT_RES_COMERCIAL);

                            dtg_venda_mes_produto.DataSource = __LISTA_QTDE;
                            chart_venda_qtde.DataSource = null;
                            chart_venda_qtde.DataSource = __LISTA_QTDE;
                            if (__LISTA_QTDE.Count() > 10)
                                chart_venda_qtde.Series[0].IsValueShownAsLabel = false;
                            chart_venda_qtde.DataBind();
                        }
                    }
                }


                if (sender.GetType().Name == "Label")
                {
                    if (((Label)sender).Name == "lbl_controle_etapa_cd")
                    {
                            if (lbl_controle_etapa_cd.Text != "")
                            {
                                if (Convert.ToInt32(lbl_controle_etapa_cd.Text) >= 3)
                                {
                                    cmdExportarArquivo.Enabled = true;
                                }
                                else
                                {
                                    cmdExportarArquivo.Enabled = false;
                                }
                            }
                    }
                }

                

                if (sender.GetType().Name == "TextBox")
                {
                    if (((TextBox)sender).Name == "txtprbf_codigo_referencia")
                    {
                        _dtgSugestaoCompra_Binding();
                    }
                }

                if (sender.GetType().Name == "TextBox")
                {
                    if (((TextBox)sender).Name == "txtdescricao")
                    {
                        _dtgSugestaoCompra_Binding();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void _Controle_Etapa_Consultar()
        {

            
            
            if (_TBCOMERCIAL_PRE_PEDIDO.cm_pre_ped_seq != 0)
            {
                _TBCOMERCIAL_PRE_PEDIDO = Pag_Net.Bll.Interface.Comercial.Tool.Pre_pedido_Consultar(MyConnect, _TBCOMERCIAL_PRE_PEDIDO);
                __CONTROLE_REG_FILA_SEQ = 0;
                __CONTROLE_ETAPA_CD = 0;
                __CONTROLE_ETAPA_DESCRICAO = "";
                DataTable _INFO_CONTROLE = Pag_Net.Bll.Controle.Pool.Controle_etapa_atual_list(MyConnect, 11, 1101, 0, _TBCOMERCIAL_PRE_PEDIDO.controle_reg_seq, 0, Convert.ToDateTime("1900-01-01"));
                if (_INFO_CONTROLE.Rows.Count > 0)
                {
                    __CONTROLE_REG_FILA_SEQ         = Convert.ToInt32(_INFO_CONTROLE.Rows[0]["controle_reg_fila_seq"].ToString());
                    __CONTROLE_ETAPA_CD             = Convert.ToInt32(_INFO_CONTROLE.Rows[0]["controle_etapa_cd"].ToString());
                    __CONTROLE_ETAPA_DESCRICAO      = _INFO_CONTROLE.Rows[0]["controle_etapa_descricao"].ToString();
                    __CONTROLE_STATUS_DESCRICAO = _INFO_CONTROLE.Rows[0]["controle_status_descricao"].ToString();
                }
                lbl_controle_etapa_cd.Text = __CONTROLE_ETAPA_CD.ToString();
                lbl_controle_etapa_descricao.Text = __CONTROLE_ETAPA_DESCRICAO;
                lbl_controle_reg_seq.Text = _TBCOMERCIAL_PRE_PEDIDO.controle_reg_seq.ToString();
                
                DataTable DataTable_Etapas = Pag_Net.Bll.Controle.Pool.Controle_etapa_atual_list(MyConnect, 0, 0, 0, _TBCOMERCIAL_PRE_PEDIDO.controle_reg_seq, 0, Convert.ToDateTime("1900-01-01"));
                if (DataTable_Etapas.Rows.Count > 0)
                {
                    lbl_controle_etapa_cd.Text = Pag_Net.Bll.Controle.Pool.Controle_etapa_atual_list(MyConnect, 0, 0, 0, _TBCOMERCIAL_PRE_PEDIDO.controle_reg_seq, 0, Convert.ToDateTime("1900-01-01")).Rows[0]["controle_etapa_cd"].ToString();
                }
                DataTable_Etapas.Dispose();
                _Etapa_DataBindings(_TBCOMERCIAL_PRE_PEDIDO.controle_reg_seq, __CONTROLE_REG_FILA_SEQ);

                

            }
            
            BLL = new Pre_Pedido(MyConnect, _TBCOMERCIAL_PRE_PEDIDO);
            _screen_grid_totalizador();

            lbl_cm_pre_ped_seq.Text = _TBCOMERCIAL_PRE_PEDIDO.cm_pre_ped_seq.ToString();
            _buttons_binding();
            _dtgSugestaoCompra_Binding();
        }
        private void _dtgSugestaoCompra_Binding()
        {
            try
            {
                dtgSugestaoCompra.DataSource = null;
                dtgSugestaoCompra.DataSource = BLL.Obter_Faturamento_Resumido_Comercial(txtdescricao.Text, txtprbf_codigo_referencia.Text);
                
                dtgSugestaoCompra.Refresh();
                _Item_DataBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void _Item_DataBindings()
        {
            try
            {

                chart_venda_qtde.DataSource = null;
                lbl_pr_descricao.Text = "";
                lbl_mes_corrente_qtde.Text = "";
                lbl_mes_corrente_qtde_desc.Text = "";
                lbl_mes_corrente_qtde.Text = "";
                lbl_ec_embalagemestoque_qtde.Text = "";
                lbl_calc_ec_embalagemcompra_qtde.Text = "";
                lbl_res_comercial_item_estoque_pendente.Text = "";
                lbl_res_comercial_item_estoque_disponivel.Text = "";
                lbl_pr_cdproduto.Text = "";
                lbl_prb_cdprodutobluesoft.Text = "";
                lbl_prb_embalagemestoque.Text = "";
                lbl_prb_cdprodutobluesoft_compra.Text = "";
                lbl_prb_cdprodutobluesoft_compra.Text = "";
                lbl_prb_embalagemcompra.Text = "";
                lbl_prb_fatorestoque.Text = "";
                lbl_mes_base_anual_01_qtde.Text = "";
                lbl_mes_base_anual_02_qtde.Text = "";
                lbl_fat_res_data.Text = "";
                lbl_res_comercial_item_estoque_dias_cobertura.Text = "";
                lbl_prbf_codigo_referencia.Text = "";

                if (dtgSugestaoCompra.DataSource == null)
                    return;




                lbl_seq_res.DataBindings.Clear();
                lbl_seq_res.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "fat_res_seq");

                


                lbl_fat_res_data.DataBindings.Clear();
                lbl_fat_res_data.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "fat_res_data");

                lbl_pr_descricao.DataBindings.Clear();
                lbl_pr_descricao.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "pr_descricao");

                lbl_mes_corrente_qtde.DataBindings.Clear();
                lbl_mes_corrente_qtde.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "mes_corrente_qtde");

                lbl_mes_corrente_qtde_desc.DataBindings.Clear();
                lbl_mes_corrente_qtde_desc.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "mes_corrente_qtde_desc");

                lbl_pr_cdproduto.DataBindings.Clear();
                lbl_pr_cdproduto.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "pr_cdproduto");


                lbl_prb_cdprodutobluesoft.DataBindings.Clear();
                lbl_prb_cdprodutobluesoft.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "prb_cdprodutobluesoft");


                lbl_prb_embalagemestoque.DataBindings.Clear();
                lbl_prb_embalagemestoque.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "prb_embalagemestoque");


                lbl_prb_cdprodutobluesoft_compra.DataBindings.Clear();
                lbl_prb_cdprodutobluesoft_compra.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "prb_cdprodutobluesoft_compra");


                lbl_prb_cdprodutobluesoft_compra.DataBindings.Clear();
                lbl_prb_cdprodutobluesoft_compra.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "prb_cdprodutobluesoft_compra");


                lbl_prb_embalagemcompra.DataBindings.Clear();
                lbl_prb_embalagemcompra.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "prb_embalagemcompra");




                lbl_prb_fatorestoque.DataBindings.Clear();
                lbl_prb_fatorestoque.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "prb_fatorestoque");

                

                if (lbl_prb_fatorestoque.Text == "1")
                {
                    lbl_prb_fatorestoque.ForeColor = Color.Red;
                }
                else
                {
                    lbl_prb_fatorestoque.ForeColor = Color.White;
                }


                lbl_prbf_codigo_referencia.DataBindings.Clear();
                lbl_prbf_codigo_referencia.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "prbf_codigo_referencia");
                

                lbl_mes_corrente_qtde.DataBindings.Clear();
                lbl_mes_corrente_qtde.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "mes_corrente_qtde");

                lbl_ec_embalagemestoque_qtde.DataBindings.Clear();
                lbl_ec_embalagemestoque_qtde.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "ec_embalagemestoque_qtde");


                lbl_calc_ec_embalagemcompra_qtde.DataBindings.Clear();
                lbl_calc_ec_embalagemcompra_qtde.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "calc_ec_embalagemcompra_qtde");


                lbl_res_comercial_item_estoque_pendente.DataBindings.Clear();
                lbl_res_comercial_item_estoque_pendente.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "res_comercial_item_estoque_pendente");


                lbl_res_comercial_item_estoque_disponivel.DataBindings.Clear();
                lbl_res_comercial_item_estoque_disponivel.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "res_comercial_item_estoque_disponivel");

                lbl_res_comercial_item_estoque_dias_cobertura.DataBindings.Clear();
                lbl_res_comercial_item_estoque_dias_cobertura.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "cm_pre_ped_item_embalagemcompra_qtde");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if ((((DataGridView)sender).Name == "dtgProduto" && e.ColumnIndex == 7)
            if (dtgSugestaoCompra.Columns[e.ColumnIndex].Name == "dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde" || dtgSugestaoCompra.Columns[e.ColumnIndex].Name == "dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut")
            {

                tbfat_res_comercial item = (tbfat_res_comercial)dtgSugestaoCompra.Rows[e.RowIndex].DataBoundItem;
                dtgSugestaoCompra.Rows[e.RowIndex].Cells["dtgSugestaoCompra_Valor_Oferecido_Total"].Value = item._calc_valor_total_solicitado;
                dtgSugestaoCompra.Rows[e.RowIndex].Cells["dtgSugestaoCompra_Valor_Autorizao"].Value = item._calc_valor_total_autorizado;
                BLL.Fataturamento_Resumido_Comercial_Update(item.pr_cdproduto, item.cm_pre_ped_item_embalagemcompra_qtde, item.cm_pre_ped_item_embalagemcompra_qtde_aut);


            }
            _screen_grid_totalizador();
        }

        private void DG_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Screen_wait(true);
            string strColumnName = dtgSugestaoCompra.Columns[e.ColumnIndex].DataPropertyName;
            BLL.OrderBy(strColumnName);
            _dtgSugestaoCompra_Binding();
            _Screen_wait(false);
        }
        
        
        private void _cmd_etapa(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(true);
                int _status_pre_pedido = 1;
                int _etapa_a_considerar = 0;
                switch (((Button)sender).Name)
                {

                    case "cmdsolicitar":
                        if (BLL.Obter_Faturamento_Resumido_Qtde_Solicitada().Count() > 0)
                        {
                            if (MessageBox.Show ("Confirma Sugestão de Compra?", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {

                                if (Convert.ToInt32(lbl_seq_res.Text) == 0)
                                {
                                    MessageBox.Show("Sem código de Resumo: acione o departamento Administrativo");
                                    return;
                                }

                                _TBCOMERCIAL_PRE_PEDIDO.fat_res_seq = Convert.ToInt32(lbl_seq_res.Text);

                                //_TBCOMERCIAL_PRE_PEDIDO = Pag_Net.Bll.Interface.Comercial.Tool.Pre_pedido_Inserir(MyConnect, _TBCOMERCIAL_PRE_PEDIDO);
                                _TBCOMERCIAL_PRE_PEDIDO = BLL.Pre_Pedido_Comercial_Incluir(_TBCOMERCIAL_PRE_PEDIDO);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi indicada nenhuma sugestão");
                        }
                        break;
                    case "cmdETAPA_FINALIZA_02_RECUSAR":
                        _status_pre_pedido = 4;
                        _etapa_a_considerar = 4;
                        break;
                    case "cmdETAPA_FINALIZA_02":
                        _etapa_a_considerar = 3;
                        _status_pre_pedido = 1;
                        /*
                        Boolean _Algum_item_com_qtde_autorizada = false;
                        for (int i = 0; i <= dtgSugestaoCompra.Rows.Count - 1; i++)
                        {
                            double _qtde_autorizada = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value.ToString());
                            if (_qtde_autorizada > 0)
                            {
                                _Algum_item_com_qtde_autorizada = true;
                            }
                        }*/
                        if (BLL.Obter_Faturamento_Resumido_Qtde_Autorizada().Count() < 1)
                        {
                            if (MessageBox.Show("Nenhum item com quantidade autorizada maior que zero, deseja autorizar todos os itens?", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                            {
                                _Screen_wait(false);
                                return;
                            }
                            else
                            {
                                BLL.Autorizar_Todas_As_Quantidades();
                            }
                        }
                        if (MessageBox.Show("Confirma autorização?", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                        BLL.Pre_Pedido_Comercial_Quantidades_Autorizadas(_TBCOMERCIAL_PRE_PEDIDO);
                        break;
                    case "cmdETAPA_FINALIZA_03":

                        _EXPORTAR_ARQUIVO();
                        _status_pre_pedido = 1;
                        _etapa_a_considerar = 4;
                        break;

                    case "cmdETAPA_FINALIZA_04":
                        _status_pre_pedido = 2;
                        if (BLL.Obter_Faturamento_Resumido_Qtde_Autorizada_Diferente_Solicitada().Count() > 0)
                        _status_pre_pedido = 3;
                        break;
                }
                Pag_Net.Bll.Controle.Pool.Controle_etapa_finalizar(MyConnect, _TBCOMERCIAL_PRE_PEDIDO.controle_reg_seq, __CONTROLE_REG_FILA_SEQ, __CONTROLE_ETAPA_CD, _etapa_a_considerar, _status_pre_pedido);
                //_databinding();
                _Controle_Etapa_Consultar();
                _Screen_wait(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _Screen_wait(false);
            }

        }

        private void _EXPORTAR_ARQUIVO()
        {
            try
            {
                if (lbl_controle_etapa_cd.Text == "")
                {
                    MessageBox.Show("Etapa não identificada!");
                        return;
                }

                if (Convert.ToInt32(lbl_controle_etapa_cd.Text) < 3)
                {
                    MessageBox.Show("Geração do arquivo Não permitida para esta etapa");
                    return;
                }
                string _NOME_ARQUIVO = DateTime.Now.ToString("yyyyMMdd") + "_PRE_PED_" + lbl_cm_pre_ped_seq.Text + ".txt";
                saveFileDialog_ped_pre.FileName = _NOME_ARQUIVO;
                saveFileDialog_ped_pre.ShowDialog();

                _NOME_ARQUIVO = saveFileDialog_ped_pre.FileName;

                if( _NOME_ARQUIVO.Trim() == "" )
                {
                    return;
                }

                string imprimir_fabricante_cdpessoabluesoft = __FV_FABRICANTE_DIVISAO_CD.ToString();

                foreach (Pag_Net.Bll.Interface.Comercial.tbfat_res_comercial i in BLL.Obter_Faturamento_Resumido_Qtde_Autorizada())
                {
                    string imprimir_prb_cdprodutobluesoft_compra = i.prb_cdprodutobluesoft.ToString();  //dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_prb_cdprodutobluesoft_compra"].Value.ToString();
                    string imprimir_qtde_autorizada = (i.prb_fatorestoque * i.cm_pre_ped_item_embalagemcompra_qtde_aut).ToString().Replace(",", "").Replace(".", "") + "00";       // Math.Round(Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value.ToString()), 0).ToString().Replace(",", "").Replace(".", "") + "00";
                    string __linha = string.Format("{0}{1}{2}{3}{4}{5}",
                                    DateTime.Now.ToString("ddMMyyyy")
                                    , "001"
                                    , Pag_Net.Tools.StringPag.Replicate(imprimir_prb_cdprodutobluesoft_compra.ToString(), "0", Pag_Net.Tools.StringPag.TypeReplicate.Prepend, 8 - imprimir_prb_cdprodutobluesoft_compra.ToString().Length)
                                    , Pag_Net.Tools.StringPag.Replicate(imprimir_qtde_autorizada, "0", Pag_Net.Tools.StringPag.TypeReplicate.Prepend, 10 - imprimir_qtde_autorizada.Length)
                                    , "  	     "
                                    , Pag_Net.Tools.StringPag.Replicate(imprimir_fabricante_cdpessoabluesoft.ToString(), "0", Pag_Net.Tools.StringPag.TypeReplicate.Prepend, 5 - imprimir_fabricante_cdpessoabluesoft.ToString().Length)
                                    )
                        ;
                    Pag_Net.Tools.LogFile.Write(_NOME_ARQUIVO, "NO-LOG", null, System.IO.FileMode.Append, System.IO.FileAccess.Write, __linha, Encoding.Default);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _Etapa_DataBindings(int controle_reg_seq, int controle_reg_fila_seq)
        {
            try
            {
                DataTable ETAPA_LISTA = Pag_Net.Bll.Controle.Pool.Controle_etapa_lista(MyConnect, controle_reg_seq, controle_reg_fila_seq); 
                dtg_etapa.DataSource = ETAPA_LISTA;
                ETAPA_LISTA.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _buttons_binding()
        {

            if (_TBCOMERCIAL_PRE_PEDIDO.controle_status_cd != 1 && _TBCOMERCIAL_PRE_PEDIDO.cm_pre_ped_seq != 0)
            {
                __CONTROLE_ETAPA_CD = 99;
            }

            cmdsolicitar.Enabled = true;
            cmdETAPA_FINALIZA_02.Enabled = false;
            cmdETAPA_FINALIZA_02_RECUSAR.Enabled = false;
            cmdETAPA_FINALIZA_03.Enabled = false;
            cmdETAPA_FINALIZA_04.Enabled = false;
            dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = false;
            dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut.ReadOnly = false;
            
            
            switch (__CONTROLE_ETAPA_CD)
            {
                case 0:
                    cmdsolicitar.Enabled = true; 
                    cmdETAPA_FINALIZA_02.Enabled = false;
                    cmdETAPA_FINALIZA_02_RECUSAR.Enabled = false;
                    cmdETAPA_FINALIZA_03.Enabled = false;
                    cmdETAPA_FINALIZA_04.Enabled = false;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = false;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut.ReadOnly = true;
                    break;


                case 2:
                    cmdsolicitar.Enabled = false;
                    if (TAREFA_611010_FINALIZA_ETAPA_02) cmdETAPA_FINALIZA_02.Enabled = true;
                    if (TAREFA_611020_FINALIZA_ETAPA_02_RECUSAR) cmdETAPA_FINALIZA_02_RECUSAR.Enabled = true;
                    cmdETAPA_FINALIZA_03.Enabled = false;
                    cmdETAPA_FINALIZA_04.Enabled = false;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut.ReadOnly = false;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = true;
                    break;
                case 3:
                    cmdsolicitar.Enabled = false;
                    cmdETAPA_FINALIZA_02_RECUSAR.Enabled = false;
                    cmdETAPA_FINALIZA_02.Enabled = false;
                    if (TAREFA_611030_FINALIZA_ETAPA_03) cmdETAPA_FINALIZA_03.Enabled = true;
                    cmdETAPA_FINALIZA_04.Enabled = false;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut.ReadOnly = true;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = true;

                    break;
                case 4:
                    cmdsolicitar.Enabled = false;
                    cmdETAPA_FINALIZA_02_RECUSAR.Enabled = false;
                    cmdETAPA_FINALIZA_02.Enabled = false;
                    cmdETAPA_FINALIZA_03.Enabled = false;
                    if (TAREFA_611040_FINALIZA_ETAPA_04) cmdETAPA_FINALIZA_04.Enabled = true;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut.ReadOnly = true;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = true;
                    break;
                default:
                    cmdsolicitar.Enabled = false;
                    cmdETAPA_FINALIZA_02_RECUSAR.Enabled = false;
                    cmdETAPA_FINALIZA_02.Enabled = false;
                    cmdETAPA_FINALIZA_03.Enabled = false;
                    cmdETAPA_FINALIZA_04.Enabled = false;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut.ReadOnly = true;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = false;
                    break;
            }
            cmdsolicitar.BackColor = cmdsolicitar.Enabled ? Color.Green : Color.Silver;
            cmdETAPA_FINALIZA_02_RECUSAR.BackColor = cmdETAPA_FINALIZA_02.Enabled ? Color.Red : Color.Silver;
            cmdETAPA_FINALIZA_02.BackColor = cmdETAPA_FINALIZA_02.Enabled ? Color.Green : Color.Silver;
            cmdETAPA_FINALIZA_03.BackColor = cmdETAPA_FINALIZA_03.Enabled ? Color.Green : Color.Silver;
            cmdETAPA_FINALIZA_04.BackColor = cmdETAPA_FINALIZA_04.Enabled ? Color.Green : Color.Silver;
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
        private void _screen_grid_totalizador()
        {
            lbl_total_sugestao_compra.Text = "";
            lbl_total_sugestao_compra_autorizado.Text = "";

            double __total_sugestao_compra = BLL.ValorTotalSolicitado();
            double __total_sugestao_compra_autorizado = BLL.ValorTotalAutorizado();

            lbl_total_sugestao_compra.Text = __total_sugestao_compra.ToString("0.00");
            lbl_total_sugestao_compra_autorizado.Text = __total_sugestao_compra_autorizado.ToString("0.00");

            lbl_total_registros.Text = BLL.Obter_Faturamento_Resumido_Qtde_Autorizada().Count().ToString();

            lbl_total_sugestao_compra_autorizado.BackColor = Color.SlateGray;
            lbl_total_sugestao_compra_autorizado.ForeColor = Color.White;
            if (__total_sugestao_compra_autorizado > 0)
            {
                if (__total_sugestao_compra > __total_sugestao_compra_autorizado)
                {
                    lbl_total_sugestao_compra_autorizado.ForeColor = Color.Red;
                    lbl_total_sugestao_compra_autorizado.BackColor = Color.White;
                }
                else
                {
                    lbl_total_sugestao_compra_autorizado.BackColor = Color.SlateGray;
                    lbl_total_sugestao_compra_autorizado.ForeColor = Color.White;
                }
            }
        }
        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExportarArquivo_Click(object sender, EventArgs e)
        {
            _EXPORTAR_ARQUIVO();
        }

        private void cmdimportar_sugestao_txt_Click(object sender, EventArgs e)
        {

            try
            {
                string _NOME_ARQUIVO = "";
                openFileDialog_pre_import.ShowDialog();

                _NOME_ARQUIVO = openFileDialog_pre_import.FileName;

                if (_NOME_ARQUIVO.Trim() == "")
                {
                    MessageBox.Show("Arquivo não indicado ou não localizado");
                    return;
                }
                BLL.ImportarSugestao(_NOME_ARQUIVO);
                MessageBox.Show("Sugestão importada");
                _dtgSugestaoCompra_Binding();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
