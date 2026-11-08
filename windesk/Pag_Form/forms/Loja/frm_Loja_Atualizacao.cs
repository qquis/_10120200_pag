using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms
{
    public partial class frm_Loja_Atualizacao : Form
    {

        Pag_Net.src.F9020_sistema_log._index wkLOG;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public frm_Loja_Atualizacao(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            _Screen_load();
        }


        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _Screen_load()
        {
            UserTools._Screen_Form_Open(this);
            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            cmddetalhe_processo_preco.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\detalhe.ico");
            cmdBalanca.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\detalhe.ico");
            cmdCargaLoja.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdPesquisarCargas.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\detalhe.ico");
            cmdAplicarNovaPrecificacao.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdDiretorioExportacaoMGV.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\open.ico");
            cmdExportarArquivoMGV.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdAtualizacaoGeralBluesoft.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdAtualizacaoPendenteBluesoft.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            UserTools._Screen_ButtonImage(cmdCargaNovaLogConsultar, UserTools.PagButtonsIcons.Atualiza);
            UserTools._Screen_Form_Format_DataGridView(dtgCARGANOVA);

            txtSENHA_NOVA_CARGA_COMPLETA.DataBindings.Add("Enabled", chkCargaJs_Completa, "Checked");

            UserTools._Screen_ButtonImage(cmdCargaJS, UserTools.PagButtonsIcons.Atualiza);

            wkLOG = new Pag_Net.src.F9020_sistema_log._index(MyConnect);
            
            cmdExportarArquivoMGV.Enabled = false;
            cmdDiretorioExportacaoMGV.Enabled = false;

            //chkAPI_BlueSoft_Todos.Enabled = false;
            cmdAtualizacaoGeralBluesoft.Enabled = false;
            cmdCargaJS.Enabled = false;
            chkCargaJs_Completa.Checked = false;
            chkCargaJs_Completa.Enabled = false;
            cmdCargaLoja.Enabled = false;

            if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 411001))
            {
                cmdExportarArquivoMGV.Enabled = true;
                cmdDiretorioExportacaoMGV.Enabled = true;

            }
            if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 411002))
            {
                //chkAPI_BlueSoft_Todos.Enabled = true;
                cmdAtualizacaoGeralBluesoft.Enabled = true;
            }


            if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 411003)) /*CARGA NOVA*/
            {
                cmdCargaJS.Enabled = true;
                if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 411004)) /*CARGA NOVA COMPLETA*/
                {
                    chkCargaJs_Completa.Enabled = true; 
                }       
            }

            if (Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 411005)) /*CARGA ANTIGA*/
            {
                cmdCargaLoja.Enabled = true;
            }

            string _Mgv_Diretorio_NomeArquivo = @Pag_Net.Bll.Sistema.Parametros.Value(MyConnect, 4110001);
            if (_Mgv_Diretorio_NomeArquivo.Trim() == "")
            {
                txtArquivo_MGV.Text = "C:\\TXITENS";
            }
            else
            {
                txtArquivo_MGV.Text = _Mgv_Diretorio_NomeArquivo;
            }


            dtgProcessos_Precos.AutoGenerateColumns = false;
            dtgprocesso_produto_precos.AutoGenerateColumns = false;

            dtpData_Proc_INI.Value = DateTime.Now.AddDays(-1);
            dtpData_Proc_FIM.Value = DateTime.Now;

            dtgProcessos_Precos.SelectionChanged += new System.EventHandler(this.DG_SelectionChanged);
            dtgprocesso_produto_precos.SelectionChanged += new System.EventHandler(this.DG_SelectionChanged);

            LBL_INFO_proc_log_seq.TextChanged += new System.EventHandler(this._Screen_changed);

            lblPIN.Text = DateTime.Now.ToString("yyyyMMdd") + "CARGA";

        }
        private void _databinding()
        {
            try
            {
                dtgProcessos_Precos.DataSource = Pag_Net.Bll.Processo.Consultar.LOG(
                    MyConnect,
                    dtpData_Proc_INI.Value,
                    dtpData_Proc_FIM.Value,
                    0,
                    0,
                    100);
                LBL_INFO_proc_log_seq.DataBindings.Clear(); LBL_INFO_proc_log_seq.DataBindings.Add("Text", dtgProcessos_Precos.DataSource, "proc_log_seq");
                LBL_INFO_user_name.DataBindings.Clear(); LBL_INFO_user_name.DataBindings.Add("Text", dtgProcessos_Precos.DataSource, "user_name");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void _databingind_precos()
        {
            if (LBL_INFO_proc_log_seq.Text != "")
            {
                dtgprocesso_produto_precos.DataSource = Pag_Net.Bll.Precos.Consultar.get(MyConnect, new Pag_Net.Bll.F0020_Produto.Defaut_Filter(0), 1, false, Convert.ToInt32(LBL_INFO_proc_log_seq.Text));
            }

        }

 

        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {

                if (sender.GetType().Name == "Label")
                {
                    
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
                            break;
                        case "txtcdprodutobluesoft":

                            break;
                        case "txtdescricao":

                            break;
                    }

                }

                if (sender.GetType().Name == "DateTimePicker")
                {
                    switch (((DateTimePicker)sender).Name)
                    {
                        case "dtpDataCadastroIni":

                            break;
                        case "dtpDataCadastroFim":
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
                            break;
                        /*
                    case "chkAgendamento_consulta":
                        if (chkAgendamento_consulta.Checked)
                        {
                            dtpData_Agendamento.Value = DateTime.Now.AddDays(1);
                        }
                        else
                        {
                            dtpData_Agendamento.Value = DateTime.Now;
                        }
                        BLL.Agendamento_Consulta = chkAgendamento_consulta.Checked;
                        break;
                        */

                    }

                }


                if (sender.GetType().Name == "ComboBox")
                {
                    switch (((ComboBox)sender).Name)
                    {
                        case "cmbDepartamento":
                            break;
                        case "cmbsecao":

                            break;
                        case "cmbgrupo":

                            break;
                        case "cmbTabelaPrecificacao":

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

        private void DG_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void cmddetalhe_processo_preco_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this, cmddetalhe_processo_preco, true);
                _databingind_precos();
                UserTools._Screen_Wait(this, cmddetalhe_processo_preco, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
                UserTools._Screen_Wait(this, cmddetalhe_processo_preco, false);
            }

        }

        private void cmdsair_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdBalanca_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this, cmdBalanca, true);
                frm_Loja_Atualizacao_Balanca frm = new frm_Loja_Atualizacao_Balanca(MyConnect);
                frm.ShowDialog();
                UserTools._Screen_Wait(this, cmdBalanca, false);
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdBalanca, false);
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdPesquisarCargas_Click(object sender, EventArgs e)
        {
            UserTools._Screen_Wait(this, cmdPesquisarCargas, true);
            _databinding();
            UserTools._Screen_Wait(this, cmdPesquisarCargas, false);
        }

        private void cmdAplicarNovaPrecificacao_Click(object sender, EventArgs e)
        {
            try
            {

                UserTools._Screen_Wait(this);

                if (AplicacaodePrecos())
                {
                    UserTools._Screen_MessageBox(this,UserTools.PagTipoMessageBox.Info, "Aplicação de PREÇO realizada com sucesso");
                }
                else
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Falha na Aplicação de Preços");
                }

                UserTools._Screen_Wait(this, false);
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                _LojaAtualizaao_Notificacao("PAG/Loja | Aplicação de Preços: FALHA na Aplicação de Preços da loja. \n" + ex.Message);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "FALHA na Aplicação de Preços da loja");
                MessageBox.Show("ERRO: " + ex.Message);
            }

        }

        private void cmdCargaLoja_Click(object sender, EventArgs e)
        {
            string _MENSAGEM_PROCESSO = "";
            try
            {
                if (txtSENHA_CARGA_ANTIGA.Text != "141722")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao,  "Senha INVÁLIDA!");
                    return;

                }

                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "Processo Inicializado...");
                
                /*MENSAGEM WHATSAPP LOJA - INICIO*/
                _LojaAtualizaao_Notificacao("LOJA | Pag - Atualização de dados \n ... Processo em andamento");
                


                UserTools._Screen_Wait(this, cmdCargaLoja, true);
                this.Refresh();
                this.Refresh();
                this.Refresh();

                //---------------------------------------------------------------------------------------
                _MENSAGEM_PROCESSO = "Reaplicação de Preço";
                Pag_Net.Bll.Precos.AplicarAlteracoes.Aplicar(MyConnect);

                //---------------------------------------------------------------------------------------
                _MENSAGEM_PROCESSO = "Processamento Inicial (Postgre)";
                Pag_Net.Bll.Loja.Carga.Processar(MyConnect);
                //---------------------------------------------------------------------------------------
                
                
                lbl_01_preparar_dados.ForeColor = Color.Red;
                this.Refresh();
                this.Refresh();
                this.Refresh();


                //---------------------------------------------------------------------------------------
                _MENSAGEM_PROCESSO = "Etapa 1 - Mercadoria ";
                Pag_Net.SPP0999.Bll.SqlServer.SPP0999_ZanthusCargaPostGre_01_tbpostgre_Tab_Mercadoria(MyConnect);
                lbl_02_atualizar_zanthus_01.ForeColor = Color.Red;
                this.Refresh();
                this.Refresh();
                this.Refresh();
                //---------------------------------------------------------------------------------------

                //---------------------------------------------------------------------------------------
                _MENSAGEM_PROCESSO = "Etapa 2 - Tributação ";
                Pag_Net.SPP0999.Bll.SqlServer.SPP0999_ZanthusCargaPostGre_02_tbpostgre_TabTributacao(MyConnect);
                lbl_02_atualizar_zanthus_02.ForeColor = Color.Red;
                this.Refresh();
                this.Refresh();
                this.Refresh();


                //---------------------------------------------------------------------------------------
                _MENSAGEM_PROCESSO = "Etapa 3 - Regra ICMS ";
                Pag_Net.SPP0999.Bll.SqlServer.SPP0999_ZanthusCargaPostGre_03_tbpostgre_Tab_Regra_Icms(MyConnect);
                lbl_02_atualizar_zanthus_03.ForeColor = Color.Red;
                this.Refresh();
                this.Refresh();
                this.Refresh();

                //---------------------------------------------------------------------------------------
                _MENSAGEM_PROCESSO = "Etapa 4 - Mercadoria Tipo Venda ";
                Pag_Net.SPP0999.Bll.SqlServer.SPP0999_ZanthusCargaPostGre_04_tbpostgre_Tab_Mercadoria_Tipo_Venda(MyConnect);
                lbl_02_atualizar_zanthus_04.ForeColor = Color.Red;
                this.Refresh();
                this.Refresh();
                this.Refresh();

                //---------------------------------------------------------------------------------------
                _MENSAGEM_PROCESSO = "Etapa 5 - Produto / Composição ";
                Pag_Net.SPP0999.Bll.SqlServer.SPP0999_ZanthusCargaPostGre_05_tbpostgre_tab_produto_decomposicao(MyConnect);
                lbl_02_atualizar_zanthus_05.ForeColor = Color.Red;
                this.Refresh();
                this.Refresh();
                this.Refresh();

                //---------------------------------------------------------------------------------------
                _MENSAGEM_PROCESSO = "Etapa X(50) - SQL Atualização GERAL";
                Pag_Net.SPP0999.Bll.SqlServer.SPP0999_ZanthusCargaPostGre_50_zeusretail_update(MyConnect);
                lbl_02_atualizar_zanthus_06.ForeColor = Color.Red;
                this.Refresh();
                this.Refresh();
                this.Refresh();

                //---------------------------------------------------------------------------------------
                _MENSAGEM_PROCESSO = "Etapa Exportação MGV";
                _Export_Mgv();
                lbl_03_Gerar_Arquivo_MGV.ForeColor = Color.Red;
                this.Refresh();
                this.Refresh();
                this.Refresh();

                //---------------------------------------------------------------------------------------
                _MENSAGEM_PROCESSO = "Atualização BLUEOSFT";
                Pag_Net.Bll.F0045_Preco.Wk WKPRECO = new Pag_Net.Bll.F0045_Preco.Wk(MyConnect);
                
                WKPRECO.BlueSoft_Update(95011,9);
                /*Integracao de Produtos Pendentes*/


                this.Refresh();
                this.Refresh();
                this.Refresh();
                lbl_04_AtualizacaoBLUESOFT.ForeColor = Color.Red;



                /*MENSAGEM WHATSAPP LOJA - INICIO*/
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "Processo Finalizado");

                _databinding();

                UserTools._Screen_Wait(this, cmdCargaLoja, false);

                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Carga concluída com sucesso");

                lbl_01_preparar_dados.ForeColor = Color.White;
                lbl_02_atualizar_zanthus_01.ForeColor = Color.White;
                lbl_02_atualizar_zanthus_02.ForeColor = Color.White;
                lbl_02_atualizar_zanthus_03.ForeColor = Color.White;
                lbl_02_atualizar_zanthus_04.ForeColor = Color.White;
                lbl_02_atualizar_zanthus_05.ForeColor = Color.White;
                lbl_02_atualizar_zanthus_06.ForeColor = Color.White;
                lbl_03_Gerar_Arquivo_MGV.ForeColor = Color.White;
                lbl_04_AtualizacaoBLUESOFT.ForeColor = Color.White;

            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdCargaLoja, false);
                _LojaAtualizaao_Notificacao("ATENÇÃO: ERRO CARGA LOJA | Processo em Andamento -> " + _MENSAGEM_PROCESSO, true);
                MessageBox.Show("* * * * * ATENÇÃO: ERRO * * * * * \n " + 
                                "\n" +
                                "----------------------------------------------------- \n" + 
                                "AVISAR O DEPARTAMENTO ADMINISTRATIVO: \n" +
                                "----------------------------------------------------- \n" + 
                                "Mensagem de Erro: " + ex.Message.ToString());
            }

        }

        private void _Export_Mgv()
        {

            if (txtArquivo_MGV.Text.Trim() == "")
            {
                MessageBox.Show("Arquivo para exportação MGV não informado, ERRO EXPORTAÇÃO MGV !!");
            }
            else
            {
                Pag_Net.Bll.Loja.BalancaMGV_Preco_Exportar.Execute(MyConnect, txtArquivo_MGV.Text);
            }

        }

        private void cmdDiretorioExportacaoMGV_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = @"c:\ARQUIVO_MGV_TESTE.TXT";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName.ToString() != "")
                {
                    txtArquivo_MGV.Text = saveFileDialog1.FileName.ToString();
                }
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, string.Format("Arquivo MGV {0} gerado com sucesso", saveFileDialog1.FileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdExportarArquivoMGV_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this, cmdExportarArquivoMGV, true);
                _Export_Mgv();
                UserTools._Screen_Wait(this, cmdExportarArquivoMGV, false);
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdExportarArquivoMGV, false);
                MessageBox.Show("Erro na exportação do Arquivo MGV: " + ex.Message);
            }
        }

        private void cmdAtualizacaoGeralBluesoft_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma solicitação de atualização de preços geral na bluesoft?"))
                {
                    UserTools._Screen_Wait(this, cmdAtualizacaoGeralBluesoft, true);
                    Pag_Net.Bll.F0045_Preco.Wk WKPRECO = new Pag_Net.Bll.F0045_Preco.Wk(MyConnect);
                    WKPRECO.BlueSoft_Update(45021,3);
                    UserTools._Screen_Wait(this, cmdAtualizacaoGeralBluesoft, false);
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Solicitação efetuada com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UserTools._Screen_Wait(this, cmdAtualizacaoGeralBluesoft, false);
            }

        }


        private void cmdAtualizacaoPendenteBluesoft_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma solicitação de atualização de preços pendentes na bluesoft?"))
                {
                    UserTools._Screen_Wait(this, cmdAtualizacaoGeralBluesoft, true);
                    Pag_Net.Bll.F0045_Preco.Wk WKPRECO = new Pag_Net.Bll.F0045_Preco.Wk(MyConnect);
                    WKPRECO.BlueSoft_Update(95011,9);
                    UserTools._Screen_Wait(this, cmdAtualizacaoGeralBluesoft, false);
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Solicitação efetuada com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UserTools._Screen_Wait(this, cmdAtualizacaoGeralBluesoft, false);
            }
        }

        private void _LojaAtualizaao_Notificacao(string mensagem) { _LojaAtualizaao_Notificacao(mensagem, false); }
        private void _LojaAtualizaao_Notificacao(string mensagem, bool erro)
        {
            int Notificacao_cd = 1000030010;
            if (erro) Notificacao_cd = 1000030091;

            try
            {
                Pag_Net.src.F0210_Notificacao.Notificacao.Procedimento(MyConnect, Notificacao_cd, DateTime.Now.ToString("dddd, dd/MM/yyyy - HH:mm:ss") + " - " + mensagem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CARGA LOJA | Processo de Notificação - ERRP: \n" + ex.Message);
            }

        }

        private void cmdCargaJS_Click(object sender, EventArgs e)
        {

            string _MENSAGEM_PROCESSO = "";
            try
            {

                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma Geração da Carga?"))
                {


                    if (chkCargaJs_Completa.Checked && txtSENHA_NOVA_CARGA_COMPLETA.Text != lblPIN.Text )
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao,  "PIN para CARGA COMPLETA INVÁLIDO | carga COMPLETA NÃO foi gerada e nenhuma operação foi realizada.");
                        return;
                    }

                    UserTools._Screen_Wait(this,cmdCargaJS, true );

                    
                    
                    //Fazendo uma NOTIFICAÇÃO de ENVIO de Carga Via PAG WIN_________________________________________________
                    _LojaAtualizaao_Notificacao("\n *Pag WINDOWS* "  
                           + "\n" 
                           + "\n *Carga de dados da LOJA* - Processamento será iniciado em instantes" 
                           + "\n "  
                           + "\n Usuário acionador: *" + MyConnect.user_name + "*"
                           );
                    //______________________________________________________________________________________________________

                    UserTools._Delay(2);


                    //Fazendo a Reaplicação de Preço________________________________________________________________________
                    AplicacaodePrecos();
                    //______________________________________________________________________________________________________



                    //****** CARGA ZANTHUS________________________________________________________________________
                    //______________________________________________________________________________________________________
                    Pag_Net.Bll.Log.register(MyConnect, 0, "PG.WIN.CARGALOJA", "Processo Inicializado...");

                    Pag_Net.src.F0085_zanthus.model.modelResultadoCarga carga = Pag_Net.src.F0085_zanthus.AtualizacaoPrecoZanthus.CargaLoja(MyConnect, chkCargaJs_Completa.Checked);

                    //var resultado = Pag_Net.src.F0085_zanthus.AtualizacaoPrecoZanthus.CargaLoja(MyConnect, chkCargaJs_Completa.Checked);
                    //______________________________________________________________________________________________________


                    //Exporta o Preço para o MGV____________________________________________________________________________
                    _MENSAGEM_PROCESSO = "Etapa Exportação MGV";
                    _Export_Mgv();
                    //______________________________________________________________________________________________________


                    //Gera um batch para a exportação de PREÇOS PARA A API BLUESOFT_________________________________________
                    _MENSAGEM_PROCESSO = "Atualização BLUEOSFT";
                    Pag_Net.Bll.F0045_Preco.Wk WKPRECO = new Pag_Net.Bll.F0045_Preco.Wk(MyConnect);
                    WKPRECO.BlueSoft_Update(95011, 9);
                    //______________________________________________________________________________________________________



                    Pag_Net.Bll.Log.register(MyConnect, 0, "PG.WIN.CARGALOJA", "Finalizado");


                    atualizaDadosLogCargaNova();
                    
                    if (carga.tipoCarga == "")
                    {
                        throw new Exception("ATENÇÃO!!! \n \n \n FALHA na Atualização dos dados da LOJA. \n \n FAVOR acionar o ADMNISTRATIVO \n  \n - De segunda a sexta (horário comercial) - Felipe \n - Todos os dias (Fora do Horário Comercial): Jocelio/Rafael");
                    }

                    if (carga.integracao_qtde_promocional == 0 && carga.tipoCarga != "")
                    {
                        throw new Exception("ATENÇÃO!!! \n \n \n FALHA na Atualização dos (PROMOCIONAIS). \n \n FAVOR acionar o ADMNISTRATIVO \n  \n - De segunda a sexta (horário comercial) - Felipe \n - Todos os dias (Fora do Horário Comercial): Jocelio/Rafael");
                    }


                    bool permissaoParaLimparCach = MyConnect.PermissaoConsultar(411006);

                    if (!permissaoParaLimparCach)
                    {
                        UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Atualização realizada com sucesso " +
                            " \n \n \n Tipo da Carga: " + carga.tipoCarga +
                            " \n \n \n Descricação da Carga: " + carga.integracao_tipo_descricao +
                            " \n \n \n Número de Registros Processados: " + carga.integracao_pendente_qtde.ToString() +
                            " \n \n \n Registros (EANS) Promocionais: " + carga.integracao_qtde_promocional

                            );
                    }
                    else
                    {
                        if( UserTools._Screen_MessageBox_OkCancel(this, "Atualização realizada com sucesso " +
                            " \n \n \n Tipo da Carga: " + carga.tipoCarga +
                            " \n \n \n Descricação da Carga: " + carga.integracao_tipo_descricao +
                            " \n \n \n Número de Registros Processados: " + carga.integracao_pendente_qtde.ToString() +
                            " \n \n \n Registros (EANS) Promocionais: " + carga.integracao_qtde_promocional + 
                            " \n \n \n " + 
                            " \n \n \n DESEJA LIMPAR O CACH DE PRODUTOS PENDENTES? "
                            ))
                        {
                            Pag_Net.src.F0085_zanthus.AtualizacaoPrecoZanthus.CargaLojaLimparCachProduto(MyConnect);
                        }
                            
                    }
                    UserTools._Screen_Wait(this, cmdCargaJS, false);
                }
                else
                {
                    UserTools._Screen_MessageBox(this, "Você optou por NÃO processar a carga! Obrigado");
                }


                
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdCargaJS, false);
                UserTools._Screen_MessageBox(this, ex + "\n " + _MENSAGEM_PROCESSO);
            }
        }

        private void atualizaDadosLogCargaNova()
        {
            try
            {
                string dataini = DateTime.Now.ToString("yyyy-MM-dd") + " 05:01:01";
                string datafim = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";

                wkLOG.ConsultarLogs(0, 0, "85002", "", 0, Convert.ToDateTime(dataini), Convert.ToDateTime(datafim), "");
                dtgCARGANOVA.DataSource = wkLOG.dbList_Sistema_Log.List;
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex.Message);
            }
        }

        private void cmdCargaNovaLogConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                atualizaDadosLogCargaNova();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex.Message);
            }
        }

        private void cmdBalanca_Click_1(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this, cmdBalanca, true);
                frm_Loja_Atualizacao_Balanca frm = new frm_Loja_Atualizacao_Balanca(MyConnect);
                frm.ShowDialog();
                UserTools._Screen_Wait(this, cmdBalanca, false);
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdBalanca, false);
                MessageBox.Show(ex.Message);
            }
        }


        private bool AplicacaodePrecos()
        {
            bool aplicadoComSucesso = false;
            try
            {
                aplicadoComSucesso = Pag_Net.src.F0045_Preco.service.AplicarAlteracoes.Aplicar(MyConnect).status;
                return aplicadoComSucesso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return false;
            }

        }

    }
}
