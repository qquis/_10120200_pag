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
    public partial class frm_Recebimento_Comando : Form
    {


        System.Windows.Forms.Timer _TIMER_tProc;
        int _TIMER_EXECUTE;
        
        /*
        int _CONTROLE_REG_SEQ = 0;
        int _CONTROLE_REG_FILA_SEQ = 0;
        int _CONTROLE_ETAPA_CD = 0;
        int _CONTROLE_REG_NUMERO = 0;
        int _CONTROLE_REG_SEQ_ULTIMO_ALTERADO = 0;
         */


        bool tarefa_441010 = false;
        bool tarefa_441011 = false;
        bool tarefa_441030 = false;
        bool tarefa_441040 = false;
        bool tarefa_441050 = false;
        bool tarefa_441051 = false;
        bool tarefa_441060 = false;
        bool tarefa_441070 = false;
        bool tarefa_441080 = false;
        bool tarefa_441090 = false;
        Pag_Net.Models.modelSistemaUsuario MyConnect;


        Pag_Net.Bll.F0060_DocumentoFiscal.WkDocumentoFiscalRegistro _BLL_DocumentoFiscalRegistro;
        Pag_Net.Bll.F0133_Comercial_PedidoBlueSoft.WkComercial_PedidoBlueSoft _BLL_Comercial_PedidoBluesoft;


        Pag_Net.Bll.F0130_Controle.Wk WK;
        Pag_Net.Bll.F0130_Controle.Wk WKListGeral;


        int __Controle_Fila_cd_Option_Sel = 0;

        public frm_Recebimento_Comando(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            _BLL_DocumentoFiscalRegistro = new Pag_Net.Bll.F0060_DocumentoFiscal.WkDocumentoFiscalRegistro(MyConnect);
            _BLL_Comercial_PedidoBluesoft = new Pag_Net.Bll.F0133_Comercial_PedidoBlueSoft.WkComercial_PedidoBlueSoft(MyConnect);
            WK = new Pag_Net.Bll.F0130_Controle.Wk(MyConnect);
            WKListGeral = new Pag_Net.Bll.F0130_Controle.Wk(MyConnect);
            _Screen_load();
        }
        private void _Screen_load()
        {
            try
            {
                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                cmdbuscar_controles_pendentes.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
                cmdControle_Reg_Alterar_Etapa.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdDetalheControle_Reg.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");



                dtgControleListaGeral.AutoGenerateColumns = false;
                dtgCONTROLE_REG.AutoGenerateColumns = false;
                dtgNotasFiscaisListas.AutoGenerateColumns = false;
                dtg_comercial_pedidoblesoft.AutoGenerateColumns = false;

                cmdsair.Click += new EventHandler(_Screen_Click);
                cmdbuscar_controles_pendentes.Click += new EventHandler(_Screen_Click);
                cmdControle_Reg_Alterar_Etapa.Click += new EventHandler(_Screen_Click);
                cmdDetalheControle_Reg.Click += new EventHandler(_Screen_Click);

                WK.PropertyChanged += _Controle_DataBinding;
                WKListGeral.PropertyChanged += _ControleListGeral_DataBinding;

                //_Controle_Reg_Pendentes();

                lbl_controle_reg_seq.TextChanged += new EventHandler(_Screen_changed);
                lbl_controle_etapa_cd.TextAlignChanged += new EventHandler(_Screen_changed);


                _TIMER_tProc = new System.Windows.Forms.Timer();
                _TIMER_tProc.Tick += new EventHandler(tProc_Elapsed);
                _TIMER_tProc.Interval = 1000;
                _TIMER_tProc.Enabled = true;
                _TIMER_tProc.Start();
                _TIMER_EXECUTE = 0;

                optFila_Todos.Checked = true;
                __Controle_Fila_cd_Option_Sel = 0;

                optFila_Mercearia.CheckedChanged += new EventHandler(_Screen_changed);
                optFila_Pereciveis.CheckedChanged += new EventHandler(_Screen_changed);
                optFila_Todos.CheckedChanged += new EventHandler(_Screen_changed);
                optFila_Suprimento.CheckedChanged += new EventHandler(_Screen_changed);
                optFila_Hortifrute.CheckedChanged += new EventHandler(_Screen_changed);


                //cmdControle_Reg_RecusarEntrada.Enabled = false;
                cmdDetalheControle_Reg.Enabled = false;
                cmdControle_Reg_Alterar_Etapa.Enabled = false;

                tarefa_441010 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441010);
                tarefa_441011 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441011);
                tarefa_441030 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441030);
                tarefa_441040 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441040);
                tarefa_441050 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441050);
                tarefa_441051 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441051);
                tarefa_441060 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441060);
                tarefa_441070 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441070);
                tarefa_441080 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441080);
                tarefa_441090 = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 441090);
                

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private void _Screen_lostFocus(object sender, EventArgs e) { }
        private void _Screen_changed(object sender, EventArgs e)
        {
            _TIMER_EXECUTE = 0;
            try
            {

                if (sender.GetType().Name == "RadioButton") 
                {
                    if (((RadioButton)sender).Name == "optFila_Todos") { __Controle_Fila_cd_Option_Sel = 0; }
                    if (((RadioButton)sender).Name == "optFila_Mercearia") { __Controle_Fila_cd_Option_Sel = 1001; }
                    if (((RadioButton)sender).Name == "optFila_Pereciveis") { __Controle_Fila_cd_Option_Sel = 1002; }
                    if (((RadioButton)sender).Name == "optFila_Hortifrute") { __Controle_Fila_cd_Option_Sel = 1003; }
                    if (((RadioButton)sender).Name == "optFila_Suprimento") { __Controle_Fila_cd_Option_Sel = 1004; }
                    _Consultar();
                }
                if (sender.GetType().Name == "Label") 
                {

                    if (((Label)sender).Name == "lbl_controle_reg_seq") 
                    {
                        cmdDetalheControle_Reg.Enabled = false;
                        cmdControle_Reg_Alterar_Etapa.Enabled = false;
                        //cmdControle_Reg_RecusarEntrada.Enabled = false;
                        _Screen_Clear_lblinfo();
                        if (lbl_controle_reg_seq.Text != "")
                        {
                            cmdDetalheControle_Reg.Enabled = true;
                            cmdControle_Reg_Alterar_Etapa.Enabled = true;
                            
                        }
                    }
                
                }
                if (sender.GetType().Name == "TextBox") {}
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox") { }
                if (sender.GetType().Name == "TabControl") { }
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
        private void _Screen_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "Button")
            {
                if (((Button)sender).Name == "cmdsair") { this.Close(); }
                if (((Button)sender).Name == "cmdbuscar_controles_pendentes") { _Consultar(); }
                if (((Button)sender).Name == "cmdDetalheControle_Reg") { _Controle_Reg_Detalhe(); }
                if (((Button)sender).Name == "cmdControle_Reg_Alterar_Etapa") { _Controle_Reg_Alterar_Etapa(); }
                
            }
        }
        private void cmdRecibo_Click(object sender, EventArgs e)
        {
            Pag_Net.Bll.Controle.tbcontrole i = new Pag_Net.Bll.Controle.tbcontrole(1, 1, Convert.ToDateTime("09-02-2022"), 1, 1, 0);

            List<Pag_Net.Bll.Controle.tbcontrole> _l = new List<Pag_Net.Bll.Controle.tbcontrole>();
            _l.Add(i);



            Pag_Form.report.frmReportView frm = new report.frmReportView(_l.ToArray(), "Pag_Form.report.Rpt_Controle_Recebimento_Senha.rdlc", "DataSet_TbControle", null);
            // Pag_Wpf.ReportViewForm ReportBrandao = new ReportViewForm(BLL.Faturamento.ViewData, "Pag_Wpf.ReportForm.rptTbFaturamento.rdlc", "DataSetTbFaturamento");

            frm.ShowDialog();
        }

        private void _Etapa_Acao_Bindind()
        {
            //cmdControle_Reg_RecusarEntrada.Enabled = false;
            if (lbl_controle_etapa_cd.Text != "")
            {
                if (lbl_controle_etapa_cd.Text != "10003" )
                {
                    //cmdControle_Reg_RecusarEntrada.Enabled = true;
                }
            }
        }
        private void _Consultar()
        {
            try
            {
                _Screen_Clear_lbl();
                lblTotalControleEmAndamento.Text = "";
                UserTools._Screen_Wait(this);

                WKListGeral.__Filtro.controle_cd = 10;
                WKListGeral.__Filtro.controle_reg_data_inicial = DateTime.Now;
                WKListGeral.__Filtro.controle_reg_data_final = DateTime.Now;
                WKListGeral.__Filtro.controle_status_cd = 1;
                WKListGeral.ControleRegList_Get();


                WK.__Filtro.controle_reg_data_inicial = dtpdata_controle.Value;
                WK.__Filtro.controle_reg_data_final = dtpdata_controle.Value;
                WK.__Filtro.controle_status_cd = 1;
                WK.__Filtro.controle_fila_cd = __Controle_Fila_cd_Option_Sel;
                WK.ControleRegList_Get(Pag_Net.Bll.F0130_Controle.Wk.ControleTipoAtendimentos.Recebimento);
                UserTools._Screen_Wait(this);
                 
            }
            catch (Exception ex)
            {
                Pag_Form.UserTools._Screen_Wait(this, false);
                MessageBox.Show(ex.Message);
            }
        }
        private void _Controle_Reg_Detalhe()
        {
            try
            {
                if (lbl_controle_cd.Text == "")
                {
                    Pag_Form.UserTools._Screen_MessageBox(this, Pag_Form.UserTools.PagTipoMessageBox.Info, "Tipo de Controle Não informado, favor solicitar ajuda do suporte");
                    return;
                }

                if (lbl_controle_reg_seq.Text == "")
                {
                    Pag_Form.UserTools._Screen_MessageBox(this, Pag_Form.UserTools.PagTipoMessageBox.Info, "Sequêncial do Controle Não informado, favor solicitar ajuda do suporte");
                    return;
                }

                int controle_cd = Convert.ToInt32(lbl_controle_cd.Text);
                int controle_reg_seq = Convert.ToInt32(lbl_controle_reg_seq.Text);

                switch (controle_cd)
                {
                    case 10:
                        Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl TipoControle_10_Controle_Ctrl_WK = new Pag_Net.Bll.F0135_Trasnporte_Ctrl.Wk_Transporte_Ctrl(MyConnect);
                        TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Controle_Reg.controle_reg_seq = controle_reg_seq;
                        TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Binding(MyConnect);

                        //cmdControle_Reg_RecusarEntrada.Enabled =  TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Controle_Ctrl_Update_Validar(MyConnect, 0, 3);



                        //TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Controle_Reg.
                        lblinfo_ControleCtrl_fornecedor_cnpj.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Transportadora.cpf_cnpj.ToString();
                        lblinfo_ControleCtrl_fornecedor_RazaoSocial.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Transportadora.nome_razao.ToString();

                        lblinfo_ControleCtrl_motorista_cnpjcpf.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Motorista.cpf_cnpj.ToString();
                        lblinfo_ControleCtrl_motorista_nome.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Motorista.nome_razao.ToString();
                        lblinfo_ControleCtrl_motorista_cnh.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Motorista.documento_cnh.ToString();
                        lblinfo_ControleCtrl_veiculo.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Veiculo.veiculo_modelo_descricao + "Placa: " + TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.Veiculo.veiculo_placa.ToString();
                        lblinfo_ControleCtrl_carga_NumeroPallet.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.pallet_qtde.ToString();
                        lblinfo_ControleCtrl_carga_VALOR.Text = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.pallet_valor_unitario.ToString();

                        _BLL_Comercial_PedidoBluesoft.filter.cm_pedblue_dataemissao_inicial = dtpdata_controle.Value.AddDays(-15);
                        _BLL_Comercial_PedidoBluesoft.filter.cnpj_cnpj = lblinfo_ControleCtrl_fornecedor_cnpj.Text.ToString();
                        dtg_comercial_pedidoblesoft.DataSource = _BLL_Comercial_PedidoBluesoft.Consultar();
                        lblcm_pedblue_numeropedido.DataBindings.Clear();
                        lblcm_pedblue_numeropedido.DataBindings.Add("Text", dtg_comercial_pedidoblesoft.DataSource, "cm_pedblue_numeropedido");
                        dtgNotasFiscaisListas.DataSource = TipoControle_10_Controle_Ctrl_WK.Transporte_Ctrl.DocumentosFiscaisLancados(MyConnect);

                        break;
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Falha na localização do Tipo de controle informado", ex);
            }


        }
        private void _Controle_Reg_Alterar_Etapa()
        {
            try
            {
                if (lbl_controle_cd.Text != "")
                {
                    if (lbl_controle_cd.Text == "10")
                    {
                        UserTools._Screen_Wait(this, cmdControle_Reg_Alterar_Etapa, true);
                        frm_Transporte_Ctrl frm = new frm_Transporte_Ctrl(MyConnect, frm_Transporte_Ctrl.Ctrl_Transporte_Form_Action.Ctrl_Transporte_Etapa_Next_Externo, Convert.ToInt32(lbl_controle_reg_seq.Text), null);
                        UserTools._Screen_Wait(this, cmdControle_Reg_Alterar_Etapa, false);
                        frm.ShowDialog();
                        _Consultar();
                    }
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdControle_Reg_Alterar_Etapa, false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "", ex);
            }
        }
        private void tProc_Elapsed(object sender, EventArgs e)
        {
            try
            {
                _TIMER_EXECUTE += 1;
                if (_TIMER_EXECUTE >= 60)
                {
                    Pag_Form.UserTools._Screen_Wait(this, true);
                    _Consultar();
                    Pag_Form.UserTools._Screen_Wait(this, false);
                    _TIMER_EXECUTE = 0;
                }
                lblatualizacao_timer.Text = string.Format("Atualização em: {0}/60", _TIMER_EXECUTE.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _Screen_Clear_lbl()
        {
            foreach (Control item in this.Controls)
            {
                if (item.GetType().Name == "Label")
                {

                    if (item.Name.Length >= 4)
                    {
                        if (item.Name.Substring(0, 4) == "lbl_")
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }
        private void _Screen_Clear_lblinfo()
        {
            dtgNotasFiscaisListas.DataSource = null;
            dtg_comercial_pedidoblesoft.DataSource = null;
            lblinfo_ControleCtrl_carga_NumeroPallet.Text = "";
            lblinfo_ControleCtrl_carga_VALOR.Text = "";
            lblinfo_ControleCtrl_fornecedor_cnpj.Text = "";
            lblinfo_ControleCtrl_fornecedor_RazaoSocial.Text = "";
            lblinfo_ControleCtrl_motorista_celular.Text = "";
            lblinfo_ControleCtrl_motorista_cnh.Text = "";
            lblinfo_ControleCtrl_motorista_cnpjcpf.Text = "";
            lblinfo_ControleCtrl_motorista_nome.Text = "";
            lblinfo_ControleCtrl_veiculo.Text = "";
            lblcm_pedblue_numeropedido.Text = "";
            
        }

        private void cmdAbrirPedido_Click(object sender, EventArgs e)
        {
            if (lblcm_pedblue_numeropedido.Text != "")
                System.Diagnostics.Process.Start(string.Format("https://erp.bluesoft.com.br/oxan/comercial/consultaPedido/listarDetalheDoPedido.action?pedidoKey={0}", lblcm_pedblue_numeropedido.Text));
        }

        private void frm_Recebimento_Comando_MouseMove(object sender, MouseEventArgs e)
        {
            _TIMER_EXECUTE = 0;
        }
        private void _Controle_DataBinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                
                dtgCONTROLE_REG.DataSource = WK.dbList.List;
                foreach (Control item in this.Controls)
                {
                    if (item.Name.Substring(0, 4) == "lbl_")
                    {
                        string name = item.Name.Substring(4);
                        item.DataBindings.Clear();
                        item.DataBindings.Add("Text", dtgCONTROLE_REG.DataSource, name);
                    }
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _ControleListGeral_DataBinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                
                lblTotalControleEmAndamento.Text = WKListGeral.dbList.Count.ToString();
                dtgControleListaGeral.DataSource = WKListGeral.dbList.List;
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

    }
}

