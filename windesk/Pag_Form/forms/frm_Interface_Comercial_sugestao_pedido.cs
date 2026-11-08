using Pag_Net.Bll.Interface.Comercial;
using System;
using System.Collections;
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
    public partial class frm_Interface_Comercial_sugestao_pedido : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        int __FABRICANTE_CDPESSOABLUESOFT = 0;
        int __CONTROLE_REG_SEQ;
        int __CONTROLE_REG_FILA_SEQ;
        int __CONTROLE_ETAPA_CD;
        int __STATUS_CONTROLE_CONSULTA_PEDIDO = 0;
        string __CONTROLE_ETAPA_DESCRICAO;
        //Boolean __VISUALIZAR_PEDIDOS;

        Pag_Net.Bll.Interface.Comercial.Pre_Pedido BLL;


        public frm_Interface_Comercial_sugestao_pedido(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            _Screen_load();
        }

        private void _Screen_load()
        {

            try
            {

                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                cmdAtualiza.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
                cmd_pre_ped.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\novo.ico");
                CmdGerarNovaFolha.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\novo.ico");
                cmdETAPA_FINALIZA_02.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdETAPA_FINALIZA_02_RECUSAR.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdETAPA_FINALIZA_03.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdETAPA_FINALIZA_04.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                CmdGerarNovaFolha.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdcomercial_pre_ped_abrir.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\open.ico");

                dtg_pre_pedido_listx.AutoGenerateColumns = false;
                //dtg_pre_pedido_listx_item.AutoGenerateColumns = false;
                dtg_etapa.AutoGenerateColumns = false;
                dtgSugestaoCompra.AutoGenerateColumns = false;

                this.dtgSugestaoCompra.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);

                

                cmbcontrole_status.SelectedValueChanged += new EventHandler(_Screen_changed);
                cmbcontrole_status.DisplayMember = "controle_status_descricao";
                cmbcontrole_status.ValueMember = "controle_status_cd";
                cmbcontrole_status.DataSource = Pag_Net.Bll.Controle.Comercial_PrePedido._Status_de_pedido(MyConnect);

                cmdETAPA_FINALIZA_02.Click += new EventHandler(_cmd_etapa);
                cmdETAPA_FINALIZA_03.Click += new EventHandler(_cmd_etapa);
                cmdETAPA_FINALIZA_04.Click += new EventHandler(_cmd_etapa);
                cmdETAPA_FINALIZA_02_RECUSAR.Click += new EventHandler(_cmd_etapa);

                foreach (DataGridViewColumn i in dtgSugestaoCompra.Columns)
                {
                    i.ReadOnly = true;
                }


                CmdGerarNovaFolha.Enabled = false;
                if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 611091)) CmdGerarNovaFolha.Enabled = true;
                

                dtgSugestaoCompra.Columns["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].ReadOnly = false;

                CMB_Forca_Venda_Fabricantes.DataSource = Pag_Net.Bll.Cadastros_Gerais.Poll.Get_DataTable_Fabricantes_Distribuicao(MyConnect);
                CMB_Forca_Venda_Fabricantes.ValueMember = "fv_fabricante_cdpessoabluesoft";
                CMB_Forca_Venda_Fabricantes.DisplayMember = "fv_fabricante_descricao";

                lbl_cm_pre_ped_seq.TextChanged += new EventHandler(_text_changed);
                lbl_controle_reg_seq.TextChanged += new EventHandler(_text_changed);
                lbl_pr_cdproduto.TextChanged += new EventHandler(_text_changed);

                _buttons_binding();
                //_screen_view_option(false);

                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "Label")
            {
    
            }
            if (sender.GetType().Name == "ComboBox")
            {
                if (((ComboBox)sender).Name == "cmbcontrole_status")
                {
                    __STATUS_CONTROLE_CONSULTA_PEDIDO = Convert.ToInt32(cmbcontrole_status.SelectedValue);
                }
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
            __FABRICANTE_CDPESSOABLUESOFT = Convert.ToInt32(CMB_Forca_Venda_Fabricantes.SelectedValue);
            /* Posição para Consulta de Estoque */

            _buttons_binding();

            //if (__VISUALIZAR_PEDIDOS)
            /// {

            DataTable _Comercial_pre_pedido_list = Pag_Net.Bll.Interface.Comercial.Tool.Comercial_pre_pedido_list(MyConnect, dtpdata_inicial.Value, dtpdata_fim.Value, Convert.ToInt32(CMB_Forca_Venda_Fabricantes.SelectedValue), __STATUS_CONTROLE_CONSULTA_PEDIDO);
            dtg_pre_pedido_listx.DataSource = _Comercial_pre_pedido_list;
            //dtg_pre_pedido_listx_item.DataSource = null;
            __CONTROLE_REG_FILA_SEQ = 0;
            __CONTROLE_ETAPA_CD = 0;
            __CONTROLE_ETAPA_DESCRICAO = "";

            _buttons_binding();


            lbl_controle_etapa_cd.Text = "";
            lbl_controle_etapa_descricao.Text = "";


            lbl_fabricante_cdpessoabluesoft.Text = "";
            lbl_fabricante_cdpessoabluesoft.DataBindings.Clear();
            lbl_fabricante_cdpessoabluesoft.DataBindings.Add("Text", dtg_pre_pedido_listx.DataSource, "fabricante_cdpessoabluesoft");

            lbl_cm_pre_ped_seq.Text = "";
            lbl_cm_pre_ped_seq.DataBindings.Clear();
            lbl_cm_pre_ped_seq.DataBindings.Add("Text", dtg_pre_pedido_listx.DataSource, "cm_pre_ped_seq");

            lbl_controle_reg_seq.Text = "";
            lbl_controle_reg_seq.DataBindings.Clear();
            lbl_controle_reg_seq.DataBindings.Add("Text", dtg_pre_pedido_listx.DataSource, "controle_reg_seq");

            lbl_fabricante_fornecedor.Text = "";
            lbl_fabricante_fornecedor.DataBindings.Clear();
            lbl_fabricante_fornecedor.DataBindings.Add("Text", dtg_pre_pedido_listx.DataSource, "nome_razao");


            lbl_status.Text = "";
            lbl_status.DataBindings.Clear();
            lbl_status.DataBindings.Add("Text", dtg_pre_pedido_listx.DataSource, "controle_status_descricao");

            //}
            //else
            //{
            /* Posição para Consulta de Estoque */

            BLL = new Pre_Pedido(MyConnect, new Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido(0, 0, Convert.ToDateTime("1900-01-01"), Convert.ToInt32(CMB_Forca_Venda_Fabricantes.SelectedValue), 0, 0));

            //DataTable _Posicao_Dados_de_Sugestao_De_Compra = Pag_Net.Bll.Interface.Comercial.Tool.Posicao(MyConnect, 0, __FABRICANTE_CDPESSOABLUESOFT, 0);
            //lbl_seq_res.Text = _Posicao_Dados_de_Sugestao_De_Compra.Rows[0]["fat_res_seq"].ToString();


            dtgSugestaoCompra.DataSource = BLL.Obter_Faturamento_Resumido_Comercial("", "");



            _Item_DataBindings();
            _screen_grid_totalizador();


        }
        private void _databinding_item_pedido(int _cm_pre_ped_seq_SELECIONADO)
        {
            try
            {
                _Screen_wait(true);
                //DataTable DataTable_pre_pedido_listx_item = Pag_Net.Bll.Interface.Comercial.Tool.Comercial_pre_pedido_item_list(MyConnect, __cm_pre_ped_seq);
                DataTable DataTable_pre_pedido_listx_item = Pag_Net.Bll.Interface.Comercial.Tool.Posicao(MyConnect, 0, __FABRICANTE_CDPESSOABLUESOFT, _cm_pre_ped_seq_SELECIONADO);
                //dtg_pre_pedido_listx_item.DataSource = DataTable_pre_pedido_listx_item;
                dtgSugestaoCompra.DataSource = Pag_Net.Bll.Interface.Comercial.Tool.Posicao(MyConnect, 0, __FABRICANTE_CDPESSOABLUESOFT, _cm_pre_ped_seq_SELECIONADO);

                for (int i = 0; i <= dtgSugestaoCompra.Rows.Count - 1; i++)
                {
                    dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_Valor_Oferecido_Total"].Value = 0;

                    dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_Valor_Oferecido_Total"].Value =
                        Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value) * Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_valor"].Value);


                    dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_Valor_Autorizao"].Value = "0";

                    dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_Valor_Autorizao"].Value =
                        Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value) * Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_valor"].Value);


                }



                _Item_DataBindings();
                _Screen_wait(false);
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
                dtg_etapa.DataSource = Pag_Net.Bll.Controle.Pool.Controle_etapa_lista(MyConnect, controle_reg_seq, controle_reg_fila_seq);
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

                lbl_pr_descricao.Text = "";
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

                
                lbl_fat_res_data.Text = "";
                lbl_res_comercial_item_estoque_dias_cobertura.Text = "";

                if (dtgSugestaoCompra.DataSource == null)
                    return;
           
                lbl_pr_descricao.DataBindings.Clear();
                lbl_pr_descricao.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "pr_descricao");

                lbl_fat_res_data.DataBindings.Clear();
                lbl_fat_res_data.DataBindings.Add("Text", dtgSugestaoCompra.DataSource, "fat_res_data");

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




                    if (((Label)sender).Name == "lbl_cm_pre_ped_seq")
                    {
                        if (lbl_cm_pre_ped_seq.Text != "")
                        {
                            //_databinding_item_pedido(Convert.ToInt32(lbl_cm_pre_ped_seq.Text));
                            //_screen_grid_totalizador();
                        }
                    }
                    if (((Label)sender).Name == "lbl_controle_reg_seq")
                    {
                        if (lbl_controle_reg_seq.Text != "")
                        {
                            __CONTROLE_REG_SEQ = Convert.ToInt32(lbl_controle_reg_seq.Text);
                            __CONTROLE_REG_FILA_SEQ = 0;
                            __CONTROLE_ETAPA_CD = 0;
                            __CONTROLE_ETAPA_DESCRICAO = "";
                            DataTable _INFO_CONTROLE = Pag_Net.Bll.Controle.Pool.Controle_etapa_atual_list(MyConnect, 11, 1101, 0, __CONTROLE_REG_SEQ, 0, Convert.ToDateTime("1900-01-01"));

                            if (_INFO_CONTROLE.Rows.Count > 0)
                            {
                                __CONTROLE_REG_FILA_SEQ = Convert.ToInt32(_INFO_CONTROLE.Rows[0]["controle_reg_fila_seq"].ToString());
                                __CONTROLE_ETAPA_CD = Convert.ToInt32(_INFO_CONTROLE.Rows[0]["controle_etapa_cd"].ToString());
                                __CONTROLE_ETAPA_DESCRICAO = _INFO_CONTROLE.Rows[0]["controle_etapa_descricao"].ToString();
                            }

                            lbl_controle_etapa_cd.Text = __CONTROLE_ETAPA_CD.ToString();
                            lbl_controle_etapa_descricao.Text = __CONTROLE_ETAPA_DESCRICAO;
                            _Etapa_DataBindings(__CONTROLE_REG_SEQ, __CONTROLE_REG_FILA_SEQ);

                            _buttons_binding();
                        }
                        else
                        {
                            __CONTROLE_REG_FILA_SEQ = 0;
                            __CONTROLE_ETAPA_CD = 0;
                            __CONTROLE_ETAPA_DESCRICAO = "";

                            lbl_controle_etapa_cd.Text = "";
                            lbl_controle_etapa_descricao.Text = "";
                            lbl_cm_pre_ped_seq.Text = "";

                            _buttons_binding();

                            dtg_etapa.DataSource = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

                    case "cmdETAPA_FINALIZA_02_RECUSAR":
                        _status_pre_pedido = 4;
                        _etapa_a_considerar = 4;
                        break;
                    case "cmdETAPA_FINALIZA_02":
                        _etapa_a_considerar = 3;
                        _status_pre_pedido = 1;


                        Boolean _Algum_item_com_qtde_autorizada = false;
                        for (int i = 0; i <= dtgSugestaoCompra.Rows.Count - 1; i++)
                        {
                            double _qtde_autorizada = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value.ToString());
                            if (_qtde_autorizada > 0)
                            {
                                _Algum_item_com_qtde_autorizada = true;
                            }
                        }

                        if (!_Algum_item_com_qtde_autorizada)
                        {
                            if (MessageBox.Show("Nenhum item com quantidade autorizada maior que zero, deseja autorizar todos os itens?", "PAG", MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.No)
                            {
                                _Screen_wait(false);
                                return;
                            }
                            else
                            {

                                for (int i = 0; i <= dtgSugestaoCompra.Rows.Count - 1; i++)
                                {
                                    dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value.ToString());
                                }

                            }
                        }

                        if (MessageBox.Show("Confirma autorização?", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }

                        for (int i = 0; i <= dtgSugestaoCompra.Rows.Count -1 ; i++)
                        {
                            int _COMERCIAL_PRE_PEDIDO_SEQ = Convert.ToInt32(lbl_cm_pre_ped_seq.Text);
                            int _pr_cdproduto = Convert.ToInt32(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_pr_cdproduto"].Value.ToString());
                            double _qtde = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value.ToString());
                            double _qtde_autorizada = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value.ToString());
                            Pag_Net.Bll.Interface.Comercial.Tool.Pre_pedido_item_qtde_autorizada(MyConnect, _COMERCIAL_PRE_PEDIDO_SEQ, _pr_cdproduto, _qtde_autorizada);
                        }
                        break;
                    case "cmdETAPA_FINALIZA_03":
                        
                        string _NOME_ARQUIVO =  DateTime.Now.ToString("yyyyMMdd") + "_PRE_PED_" + lbl_cm_pre_ped_seq.Text + ".txt";
                        saveFileDialog_ped_pre.FileName = _NOME_ARQUIVO;
                        saveFileDialog_ped_pre.ShowDialog();

                        _NOME_ARQUIVO = saveFileDialog_ped_pre.FileName;

                        string imprimir_fabricante_cdpessoabluesoft = lbl_fabricante_cdpessoabluesoft.Text;
                        for (int i = 0; i <= dtgSugestaoCompra.Rows.Count - 1; i++)
                        {
                            string imprimir_prb_cdprodutobluesoft_compra = dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_prb_cdprodutobluesoft_compra"].Value.ToString();
                            string imprimir_qtde_autorizada = Math.Round(Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value.ToString()),0).ToString().Replace(",","").Replace(".","") + "00";


                            string __linha = string.Format ("{0}{1}{2}{3}        {4}",  
                                            DateTime.Now.ToString("ddMMyyyy") 
                                            , "001" 
                                            , Pag_Net.Tools.StringPag.Replicate(imprimir_prb_cdprodutobluesoft_compra.ToString(), "0", Pag_Net.Tools.StringPag.TypeReplicate.Prepend, 8 - imprimir_prb_cdprodutobluesoft_compra.ToString().Length)
                                            , Pag_Net.Tools.StringPag.Replicate(imprimir_qtde_autorizada, "0", Pag_Net.Tools.StringPag.TypeReplicate.Prepend, 10 - imprimir_qtde_autorizada.Length)
                                            , Pag_Net.Tools.StringPag.Replicate(imprimir_fabricante_cdpessoabluesoft.ToString(), "0", Pag_Net.Tools.StringPag.TypeReplicate.Prepend, 5 - imprimir_fabricante_cdpessoabluesoft.ToString().Length)
                                            )
                                ;
                            Pag_Net.Tools.LogFile.Write(_NOME_ARQUIVO, "NO-LOG", null, System.IO.FileMode.Append, System.IO.FileAccess.Write, __linha, Encoding.Default);
                        }
                        _status_pre_pedido = 1;
                        _etapa_a_considerar = 4;
                        break;
                    case "cmdETAPA_FINALIZA_04":
                        _status_pre_pedido = 2;
                        for (int i = 0; i <= dtgSugestaoCompra.Rows.Count - 1; i++)
                        {
                            double _qtde = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value.ToString());
                            double _qtde_autorizada = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value.ToString());
                            if (_qtde != _qtde_autorizada)
                            {
                                _status_pre_pedido = 3;
                            }
                        }
                        break;
                }

                Pag_Net.Bll.Controle.Pool.Controle_etapa_finalizar(MyConnect, __CONTROLE_REG_SEQ, __CONTROLE_REG_FILA_SEQ, __CONTROLE_ETAPA_CD, _etapa_a_considerar, _status_pre_pedido);
                _databinding();
                _Screen_wait(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _Screen_wait(false);
            }
            
        }

        private void _buttons_binding()
        {


            switch (__CONTROLE_ETAPA_CD)
            {
                case 2:
                    if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 611010)) cmdETAPA_FINALIZA_02.Enabled = true;
                    if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 611020)) cmdETAPA_FINALIZA_02_RECUSAR.Enabled = true;
                    cmdETAPA_FINALIZA_03.Enabled = false;
                    cmdETAPA_FINALIZA_04.Enabled = false;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut.ReadOnly = false;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = true;
                    break;
                case 3:
                    cmdETAPA_FINALIZA_02_RECUSAR.Enabled = false;
                    cmdETAPA_FINALIZA_02.Enabled = false;
                    if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 611030)) cmdETAPA_FINALIZA_03.Enabled = true;
                    cmdETAPA_FINALIZA_04.Enabled = false;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut.ReadOnly = true;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = true;
                    
                    break;
                case 4:
                    cmdETAPA_FINALIZA_02_RECUSAR.Enabled = false;
                    cmdETAPA_FINALIZA_02.Enabled = false;
                    cmdETAPA_FINALIZA_03.Enabled = false;
                    if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 611040)) cmdETAPA_FINALIZA_04.Enabled = true;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut.ReadOnly = true;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = true;
                    break;
                default:
                    cmdETAPA_FINALIZA_02_RECUSAR.Enabled = false;
                    cmdETAPA_FINALIZA_02.Enabled = false;
                    cmdETAPA_FINALIZA_03.Enabled = false;
                    cmdETAPA_FINALIZA_04.Enabled = false;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut.ReadOnly = true;
                    dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = false;
                    break;
            }
            cmdETAPA_FINALIZA_02_RECUSAR.BackColor = cmdETAPA_FINALIZA_02.Enabled ? Color.Red : Color.Silver;
            cmdETAPA_FINALIZA_02.BackColor = cmdETAPA_FINALIZA_02.Enabled ? Color.Green : Color.Silver;
            cmdETAPA_FINALIZA_03.BackColor = cmdETAPA_FINALIZA_03.Enabled ? Color.Green : Color.Silver;
            cmdETAPA_FINALIZA_04.BackColor = cmdETAPA_FINALIZA_04.Enabled ? Color.Green : Color.Silver;
        }
        
        private void cmdConsultar_Pedido_Click(object sender, EventArgs e)
        {
            if (lbl_cm_pre_ped_seq.Text != "")
            _databinding_item_pedido(Convert.ToInt32(lbl_cm_pre_ped_seq.Text));
        }
        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                tab.TabIndex = 0;
                _Screen_wait(cmdAtualiza, true);
               _databinding();
               _Screen_wait(cmdAtualiza, false);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
        /*
        private void cmdEfetivar_gerar_pre_pedido_Click(object sender, EventArgs e)
        {
            ///var datatable_copy_dtgSugestaoCompra = ((DataTable)dtgSugestaoCompra.DataSource).Copy();
            try
            {
                Boolean Algum_item_com_qtde = false;
                int __count = dtgSugestaoCompra.Rows.Count - 1;
                for (int i = 0; i <= __count; i++)
                {
                       if (Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value.ToString()) > 0)
                       {
                           Algum_item_com_qtde = true;
                       }
                }

                if (!Algum_item_com_qtde)
                {
                    MessageBox.Show("Nenhum item c/ qtde");
                    return;
                }

                if ( MessageBox.Show("Confirma a inclusão da sugestão do novo pedido?", "PAG", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                List<Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item> __list = new List<Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item>();
                for (int i = 0; i <= __count; i++)
                {

                    if (Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value.ToString()) > 0)
                    {
                        Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item item = new Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item();
                        item.cm_pre_ped_seq = 0;
                        item.cm_pre_ped_seq_item = 0;
                        item.pr_cdproduto = Convert.ToInt32(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_pr_cdproduto"].Value.ToString());
                        item.prb_cdprodutobluesoft = Convert.ToInt32(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_prb_cdprodutobluesoft"].Value.ToString());
                        item.prb_embalagemestoque = dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_prb_embalagemestoque"].Value.ToString();
                        item.prb_cdprodutobluesoft_compra = Convert.ToInt32(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_prb_cdprodutobluesoft_compra"].Value.ToString());
                        item.prb_embalagemcompra = dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_prb_embalagemcompra"].Value.ToString();
                        item.prb_fatorestoque = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_prb_fatorestoque"].Value.ToString());

                        item.ec_embalagemcompra_qtde = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_ec_embalagemcompra_qtde"].Value.ToString());
                        item.ec_embalagemestoque_qtde = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_ec_embalagemestoque_qtde"].Value.ToString());

                        item.cm_pre_ped_item_embalagemestoque_qtde = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemestoque_qtde"].Value.ToString());
                        item.cm_pre_ped_item_embalagemcompra_qtde = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value.ToString());
                        item.cm_pre_ped_item_valor = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_valor"].Value.ToString());
                        item.pr_descricao = dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_pr_descricao"].Value.ToString();
                        __list.Add(item);
                    }
                }
                

                //DataGridViewRowCollection tmpRowCollection = dtgSugestaoCompra.Rows;
                //DataGridViewRow[] _arraydatagridview_dtgsugestaocompra = new DataGridViewRow[tmpRowCollection.Count];
                //dtgSugestaoCompra.Rows.CopyTo(_arraydatagridview_dtgsugestaocompra, 0);
                //List<Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item> __list = new List<Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item>();
                frm_Interface_Comercial_Pre_Pedido frm = new frm_Interface_Comercial_Pre_Pedido(MyConnect, __list.ToArray(), Convert.ToInt32(CMB_Forca_Venda_Fabricantes.SelectedValue), CMB_Forca_Venda_Fabricantes.Text, Convert.ToInt32(lbl_seq_res.Text));
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */

/*
        private void _screen_view_option(Boolean _visualizar_pedidos)
        {
            dtgSugestaoCompra.DataSource = null;
            _Item_DataBindings();
            __VISUALIZAR_PEDIDOS = _visualizar_pedidos;
            if (_visualizar_pedidos)
            {
                dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = true;
                tab.Visible = true;
                dtgSugestaoCompra.Location = new System.Drawing.Point(12, 300);
                dtgSugestaoCompra.Height = 210;
                cmdEfetivar_gerar_pre_pedido.Visible = false;
                cmdEfetivar_gerar_pre_pedido.Enabled = false;
                	
            }
            else
            {
                tab.Visible = false;
                _databinding();
                dtgSugestaoCompra.Location = new System.Drawing.Point(12, 82);
                dtgSugestaoCompra.Height = 420;
                cmdEfetivar_gerar_pre_pedido.Visible = true;
                cmdEfetivar_gerar_pre_pedido.Enabled = true;
                dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde.ReadOnly = false;
            }
        }
*/

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if ((((DataGridView)sender).Name == "dtgProduto" && e.ColumnIndex == 7)
            if (dtgSugestaoCompra.Columns[e.ColumnIndex].Name == "dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde" || dtgSugestaoCompra.Columns[e.ColumnIndex].Name == "dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut")
            {

                dtgSugestaoCompra.Rows[e.RowIndex].Cells["dtgSugestaoCompra_Valor_Oferecido_Total"].Value = 0;

                dtgSugestaoCompra.Rows[e.RowIndex].Cells["dtgSugestaoCompra_Valor_Oferecido_Total"].Value =
                    Convert.ToDouble(dtgSugestaoCompra.Rows[e.RowIndex].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value) * Convert.ToDouble(dtgSugestaoCompra.Rows[e.RowIndex].Cells["dtgSugestaoCompra_cm_pre_ped_item_valor"].Value);

                
                dtgSugestaoCompra.Rows[e.RowIndex].Cells["dtgSugestaoCompra_Valor_Autorizao"].Value = "0";

                dtgSugestaoCompra.Rows[e.RowIndex].Cells["dtgSugestaoCompra_Valor_Autorizao"].Value =
                    Convert.ToDouble(dtgSugestaoCompra.Rows[e.RowIndex].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value) * Convert.ToDouble(dtgSugestaoCompra.Rows[e.RowIndex].Cells["dtgSugestaoCompra_cm_pre_ped_item_valor"].Value);
            }
            _screen_grid_totalizador();
        }

        private void _screen_grid_totalizador()
        {
            lbl_total_sugestao_compra.Text = "";
            lbl_total_sugestao_compra_autorizado.Text = "";

            double __total_sugestao_compra = 0;
            double __total_sugestao_compra_autorizado = 0;

            for (int i = 0; i <= dtgSugestaoCompra.Rows.Count - 1; i++)
            {
                

                __total_sugestao_compra +=
                    Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value) * Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_valor"].Value);
                __total_sugestao_compra_autorizado +=
                    Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value) * Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_valor"].Value);

                //dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_valor"].Value = "0";

            }
            lbl_total_sugestao_compra.Text = __total_sugestao_compra.ToString("0.00");
            lbl_total_sugestao_compra_autorizado.Text = __total_sugestao_compra_autorizado.ToString("0.00");

            lbl_total_registros.Text = dtgSugestaoCompra.Rows.Count.ToString();

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

        private void CmdGerarNovaFolha_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(CmdGerarNovaFolha, true);
                Pag_Net.Bll.Interface.Comercial.Tool.Gerar_Nova_Folha_de_Dados_Posicao(MyConnect);
                _Screen_wait(CmdGerarNovaFolha, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmd_pre_ped_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Interface_Comercial_Pre_Ped _frm = new frm_Interface_Comercial_Pre_Ped(MyConnect,
                    new Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido(0, 0, DateTime.Now, Convert.ToInt32(CMB_Forca_Venda_Fabricantes.SelectedValue), 0, 0));
                _frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdcomercial_pre_ped_abrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_cm_pre_ped_seq.Text == "")
                {
                    MessageBox.Show("Selecione um Pedido");
                    return;
                }

                if (Convert.ToInt32(lbl_cm_pre_ped_seq.Text) != 0)
                {
                    frm_Interface_Comercial_Pre_Ped _frm = new frm_Interface_Comercial_Pre_Ped(MyConnect,
                        new Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido(Convert.ToInt32(lbl_cm_pre_ped_seq.Text), 0, DateTime.Now, Convert.ToInt32(CMB_Forca_Venda_Fabricantes.SelectedValue), 0, 0));
                    _frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selecione um Pedido Valido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


