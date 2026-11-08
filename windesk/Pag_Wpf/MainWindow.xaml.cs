using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Pag_Net.Bll ;
using Pag_Net.Models;
using System.Threading;
using System.Windows.Threading;
using System.Xml;
using System.IO;
using Pag_Net.Tools.CryptFile;
using Pag_Net.Bll.BlueSoft;


namespace Pag_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private bllPackageConnection myConnect;
        public Pag_Net.Models.modelSistemaUsuario Myconnect { get; set; }
        public String UsrCd = "";
        public String UsrEmail = "";
        public String UsrNome = "";
        public string CONFIG_ENV = "PRD";
        public string CONFIG_FILE_ENV = "";
        public string CONFIG_FILE_CONNECTIONS_SQLSERVER = "";
        public string CONFIG_FILE_ZEBRA = "";
        //string PagOldExe = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Wpf.exe", "") + @"PAG.EXE";
        string File_List_Env = "";



        public Pag_Net.Models.TbSysTbTipos[] Tipos;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            
            /* Abrindo arquivos de Configuração */
            SetConfigFiles();

            /* Definindo Enviroments */
            SetEnviroment();
            
            /* Desabilitar todos os Menus */
            SetMenuHiddenAll();

            this.Title = PagInfo.Version_models;

           
            LBLUsuario.Visibility = System.Windows.Visibility.Hidden;
            txtUserLogin.Focus();
        }
 
        private void cmdLogin_Click(object sender, RoutedEventArgs e)
        {
            string _strUserInfo = txtUserLogin.Text.ToString().ToUpper().Trim();
            string _strPassWordInfo = txtSenhaLogin.Password.ToString();
            try
            {
                //Myconnect = Pag_Net.Bll.GetConnection.MyConnection("WPF", _strUserInfo, CONFIG_ENV, "LAN", _strPassWordInfo, @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Wpf.exe", "") + @"\infox.dll");
                Myconnect = Pag_Net.Bll.PagConnection.MyConnection("WPF", _strUserInfo, CONFIG_ENV, "LAN", _strPassWordInfo, CONFIG_FILE_CONNECTIONS_SQLSERVER);

                 if ( Myconnect.ListAccess.Count() <= 0)
                 {
                     throw new Exception("Usuário sem acessos definidos");
                 }

                 m2400.IsEnabled = false;
                 m2410.IsEnabled = false;
                 m2420.IsEnabled = false;

                 Myconnect.Tipos = Pag_Net.Bll.Util.TiposFill(Myconnect);
                 Myconnect.Operacoes = Pag_Net.Bll.Operacoes.Fill(Myconnect);

                
                
                


                 
                /*
                 Pag_Net.Bll.Produto.BlueSoft_Import.Start(Myconnect);
                 MessageBox.Show("PRODUTOS IMPORTADOS");
                 Pag_Net.Bll.Produto.BlueSoft_Import_CodigoBarra.Start(Myconnect);
                 MessageBox.Show("CODIGO DE BARRAS IMPORTADOS");
                */


                for (int z = 0; z < ProjectMenu.Items.Count; z++)
                 {
                     MenuItem item = (MenuItem)ProjectMenu.Items[z];
                     foreach (MenuItem submenu in item.Items)
                     {
                         submenu.IsEnabled = false;
                     }
                 }


                 if (Convert.ToInt32(Myconnect.ListAccess.Count().ToString()) > 0)
                {
                    
                    //BorderPages.Visibility = System.Windows.Visibility.Visible;
                    ProjectMenu.Visibility = System.Windows.Visibility.Visible;
                    //StkpPages.Visibility = System.Windows.Visibility.Visible;
                    //GridButtons.Visibility = System.Windows.Visibility.Visible;
                    lblusuario.Visibility = System.Windows.Visibility.Hidden;
                    lblsenha.Visibility = System.Windows.Visibility.Hidden;
                    txtSenhaLogin.Visibility = System.Windows.Visibility.Hidden;
                    cmdlogin.Visibility = System.Windows.Visibility.Hidden;
                    txtUserLogin.Background = null;
                    txtUserLogin.Visibility = Visibility.Hidden;
                    txtUserLogin.Text = Myconnect.user_name;
                    LBLUsuario.Content = txtUserLogin.Text;
                    LBLUsuario.Visibility = System.Windows.Visibility.Visible;


                    /* Faz a Leitura das configurações ZEBRA */
                    SetZEBRAConfigs();



                     
                    if (Myconnect.ZEBRA == "1")
                    {
                        m2000.IsEnabled = true;
                        m2100.IsEnabled = true;
                        m2110.IsEnabled = true;
                        m2111.IsEnabled = true;
                        m2114.IsEnabled = true;
                        /* Habilita Porta de Impressora ZEBRA */
                        if (File.Exists(@Myconnect.ZEBRACMD))
                        {
                            System.Diagnostics.Process.Start("CMD.EXE", @"/C " + @Myconnect.ZEBRACMD);
                        }

                        /* Habilita o Leitor */
                        if (File.Exists(@Myconnect.ZEBRACMDL))
                        {
                            System.Diagnostics.Process.Start(@Myconnect.ZEBRACMDL);
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= Myconnect.ListAccess.Count() - 1; i++)
                        {
                            switch (Myconnect.ListAccess[i].Menu.Trim())
                            {
                                case "m1000":
                                    m1000.IsEnabled = true;
                                    break;
                                case "m1110":
                                    m1000.IsEnabled = true;
                                    m1100.IsEnabled = true;
                                    m1110.IsEnabled = true;
                                    break;

                                case "m1114":
                                    m1000.IsEnabled = true;
                                    m1100.IsEnabled = true;
                                    m1114.IsEnabled = true;
                                    break;

                                case "m1200":
                                    m1000.IsEnabled = true;
                                    m1200.IsEnabled = true;
                                    break;

                                /*case "m1300":
                                    m1000.IsEnabled = true;
                                    m1300.IsEnabled = true;
                                    break;*/

                                case "m2100":
                                    m2100.IsEnabled = true;
                                    break;

                                case "m2111":
                                    m2000.IsEnabled = true;
                                    m2100.IsEnabled = true;
                                    m2110.IsEnabled = true;
                                    m2111.IsEnabled = true;
                                    break;
                                case "m2114":
                                    m2000.IsEnabled = true;
                                    m2100.IsEnabled = true;
                                    m2110.IsEnabled = true;
                                    m2114.IsEnabled = true;
                                    break;

                                case "m2121":
                                    m2100.IsEnabled = true;
                                    m2120.IsEnabled = true;
                                    m2121.IsEnabled = true;
                                    break;

                                //case "m2131":
                                //  m2100.IsEnabled = true;
                                //  m2130.IsEnabled = true;
                                //  m2131.IsEnabled = true;
                                //  break;

                                //case "m2133":
                                //    m2100.IsEnabled = true;
                                //    m2130.IsEnabled = true;
                                //    m2133.IsEnabled = true;
                                //    break;

                                //case "m2141":
                                //    m2100.IsEnabled = true;
                                //    m2140.IsEnabled = true;
                                //    m2141.IsEnabled = true;
                                //    break;

                                case "m2210":
                                    m2200.IsEnabled = true;
                                    m2210.IsEnabled = true;
                                    break;


                                case "m2320":
                                    m2300.IsEnabled = true;
                                    //m2320.IsEnabled = true;
                                    break;

                                case "m2311":
                                    //m2300.IsEnabled = true;
                                    //m2310.IsEnabled = true;
                                    //m2311.IsEnabled = true;
                                    break;

                                case "m2312":
                                    //m2300.IsEnabled = true;
                                    //m2310.IsEnabled = true;
                                    //m2312.IsEnabled = true;
                                    break;


                                /*case "m2313":
                                    m2300.IsEnabled = true;
                                    m2310.IsEnabled = true;
                                    m2313.IsEnabled = true;
                                    break;*/


                                case "m2314":
                                    //m2300.IsEnabled = true;
                                    //m2310.IsEnabled = true;
                                    //m2314.IsEnabled = true;
                                    break;

                                /*      case "m2331":
                                          m2300.IsEnabled = true;
                                          m2330.IsEnabled = true;
                                          m2331.IsEnabled = true;
                                          break;

                                      case "m2332":
                                          m2300.IsEnabled = true;
                                          m2330.IsEnabled = true;
                                          m2332.IsEnabled = true;
                                          break;  */

                                case "m2411":
                                    m2400.IsEnabled = true;
                                    m2410.IsEnabled = true;
                                    m2411.IsEnabled = true;
                                    break;

                                case "m2412":
                                    m2400.IsEnabled = true;
                                    m2410.IsEnabled = true;
                                    m2412.IsEnabled = true;
                                    break;

                                case "m2413":
                                    m2400.IsEnabled = true;
                                    m2410.IsEnabled = true;
                                    m2413.IsEnabled = true;
                                    break;

                                case "m2414":
                                    m2400.IsEnabled = true;
                                    m2410.IsEnabled = true;
                                    m2414.IsEnabled = true;
                                    break;

                                case "m2500":
                                    m2500.IsEnabled = true;
                                    break;


                                case "m2512":
                                    m2500.IsEnabled = true;
                                    //m2512.IsEnabled = true;
                                    break;


                                case "m2710":
                                    m2700.IsEnabled = true;
                                    m2710.IsEnabled = true;
                                    break;

                                case "m2420":
                                    m2400.IsEnabled = true;
                                    m2420.IsEnabled = true;
                                    break;

                                case "m2810":
                                    m2800.IsEnabled = true;
                                    m2810.IsEnabled = true;
                                    break;

                                case "m2811":
                                    m2800.IsEnabled = true;
                                    m2811.IsEnabled = true;
                                    break;

                                case "m2910":
                                    m2900.IsEnabled = true;
                                    m2910.IsEnabled = true;
                                    break;

                                case "m2911":
                                    m2900.IsEnabled = true;
                                    m2911.IsEnabled = true;
                                    break;
                                case "m2912":
                                    m2900.IsEnabled = true;
                                    m2912.IsEnabled = true;
                                    break;

                                case "m4311":
                                    m4300.IsEnabled = true;
                                    m4311.IsEnabled = true;
                                    break;


                                case "m4312":
                                    m4300.IsEnabled = true;
                                    m4312.IsEnabled = true;
                                    break;

                                case "m4313":
                                    m4300.IsEnabled = true;
                                    m4313.IsEnabled = true;
                                    break;

                                case "m4314":
                                    m4300.IsEnabled = true;
                                    m4314.IsEnabled = true;
                                    break;

                                case "m4315":
                                    m4300.IsEnabled = true;
                                    m4315.IsEnabled = true;
                                    break;

                                case "m4410":
                                    m4000.IsEnabled = true;
                                    m4400.IsEnabled = true;
                                    m4410.IsEnabled = true;
                                    break;
                        

                                case "m8101":
                                    m8000.IsEnabled = true;
                                    m8100.IsEnabled = true;
                                    //m8101.IsEnabled = true;
                                    break;

                                case "m8106":
                                    m8000.IsEnabled = true;
                                    m8100.IsEnabled = true;
                                    m8106.IsEnabled = true;
                                    break;

                                case "m8202":
                                    m8000.IsEnabled = true;
                                    m8200.IsEnabled = true;
                                    m8202.IsEnabled = true;
                                    break;

                                case "m8203":
                                    m8000.IsEnabled = true;
                                    m8200.IsEnabled = true;
                                    m8203.IsEnabled = true;
                                    break;

                            }
                        }
                    }
                    


  

                }
                else
                {
                    txtSenhaLogin.Password = "";
                    MessageBox.Show("Login Incorreto: Usuário/Senha inválido");
                    txtSenhaLogin.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Falhou: " + ex.Message.ToString());
            }
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            try

            {
                string _TitleMenu = "";
                String nome = ((MenuItem)sender).Name;
                for (int i = 0; i <= Myconnect.ListAccess.Count() - 1; i++)
                {
                    if (Myconnect.ListAccess[i].Menu.Trim() == nome)
                    {
                        _TitleMenu = Myconnect.ListAccess[i].DescFormProc;
                    }
                }

                switch (nome)
                {
                    /*case "m1110": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Cadastro.UclProduto(Myconnect) }); break;*/

                    case "m1110":
                        //Pag_Wpf.Forms.FrmXProduto frmXProduto = new Forms.FrmXProduto(Myconnect);
                        //frmXProduto.ShowDialog();

                        Forms.FrmXProduto frmp = new Forms.FrmXProduto(Myconnect);
                        frmp.Show();

                        //Pag_Wpf.Forms.TESTE _frmpProduto = new Forms.TESTE();
                        //_frmpProduto.Show();
                        break;

                    case "m1114": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Cadastro.UclProdutoCategoria(Myconnect) }); break;
                    case "m1200": 
                        
                        /*MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Cadastros.UclParticipante(Myconnect) }); break;*/
                        Pag_Wpf.Forms.FrmXParticipanteBlueSoft frmxParticipante = new Forms.FrmXParticipanteBlueSoft(Myconnect);
                        frmxParticipante.ShowDialog();
                        break;

                    case "m1300": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Cadastro.UclAtivoImobilizado(Myconnect) }); break;
                    case "m2111": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Loja.Execucao.UclEtiquetaGondola(Myconnect) }); break;
                    case "m2114": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Loja.Execucao.UclAtualizacao(Myconnect) }); break;
                    case "m2121": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Loja.FrenteCaixa.UclCupomFiscal(Myconnect) }); break;
                    case "m2131": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Loja.Sac.UclSACFinanceiro(Myconnect) }); break;
                    case "m2133": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Loja.Sac.UclSACOperacoes(Myconnect) }); break;

                    case "m2311":

                        /*MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Cadastros.UclParticipante(Myconnect) }); break;*/
                        Pag_Wpf.Forms.FRMxProdutoCustos frmxProdutoCustos = new Forms.FRMxProdutoCustos(Myconnect);
                        frmxProdutoCustos.ShowDialog();
                        break;                    
                    case "m2312": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Produto.UclOperacaoProdutoPreco(Myconnect) }); break;
                    case "m2313": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Produto.UclProdutoInterfaceCusto(Myconnect) }); break;
                    case "m2331": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Produto.UclOperacaoProdutoRegistroPendentes(Myconnect) }); break;
                    case "m2332": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Produto.UclOperacaoProdutoRegistroLancados(Myconnect) }); break;
                    case "m2411": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Analise.UclFaturamentoVisaoGeral(Myconnect) }); break;
                    case "m2412": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Analise.UclFaturamentoData(Myconnect) }); break;
                    case "m2413":
                        Pag_Wpf.Forms.FrmXContratos fxContratos = new Forms.FrmXContratos(Myconnect);
                        fxContratos.Show();
                        break;
                    case "m2414":
                        Pag_Wpf.Forms.FrmXFaturamentoBlueSoft fXfaturamentoBlueSoft = new Pag_Wpf.Forms.FrmXFaturamentoBlueSoft(Myconnect);
                        fXfaturamentoBlueSoft.ShowDialog();
                        break;
                    case "m2431": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Analise.UclRegistroProduto(Myconnect) }); break;
                    case "m2432": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Analise.UclRegistroProdutoData(Myconnect) }); break;
                    case "m2500":
                        Forms.FrmXRecebimento frmxRecebimento = new Forms.FrmXRecebimento(Myconnect);
                        frmxRecebimento.ShowDialog();
                        break;               
                    //case "m2512": 
                    //    MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Expedicao.Entrada.UclNotasFiscais(Myconnect) })       ; 
                    //        break;                              ;
                    case "m2611": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Tesouraria.UclLogSitef(Myconnect) }); break;
                    case "m2710": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Faturamento.UclFaturamentoDocumento(Myconnect) }); break;
                    case "m2810":
                        Pag_Wpf.Forms.FrmXIntegracao fmrXIntegracao = new Forms.FrmXIntegracao(Myconnect);
                        fmrXIntegracao.ShowDialog();
                        break;

                    case "m2811":
                        Pag_Wpf.Forms.frmxIntegracaoPostgreSQL fmrXIntegracaoPostGre = new Forms.frmxIntegracaoPostgreSQL(Myconnect);
                        fmrXIntegracaoPostGre.ShowDialog();
                        break;

                    case "m2910": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Locacao.UclLocacao(Myconnect) }); break;
                    case "m2911": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Locacao.UclLocacaoParcelasFaturamento(Myconnect) }); break;
                    case "m2912": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Operacionais.Locacao.UclLocacaoParcelasFinanceiro(Myconnect) }); break;
                    case "m4311": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Comercial.Interface.UclInterfaceComercialEstoque(Myconnect) }); break;
                    case "m4312": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Comercial.Interface.UclInterfaceComercialFaturamento(Myconnect) }); break;
                    case "m4313": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Comercial.Interface.UclInterfaceComercialFaturamentoSimulado(Myconnect) }); break;
                    case "m4314": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Comercial.Interface.UclInterfaceComercialFaturamentoAnalise(Myconnect) }); break;
                    case "m4315": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Comercial.Interface.UclInterfaceComercialArquivos(Myconnect) }); break;
                    case "m4410": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Comercial.Analise.UclComAnaliseMercFabricProd6Meses(Myconnect) }); break;
                    case "m4510": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Comercial.Compras.UclPedidoCompra(Myconnect) }); break;
                    case "m5110": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Financeiro.CartaoCredito.UclInterfaceLogSitef(Myconnect) }); break;
                    case "m5120": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Financeiro.CartaoCredito.UclConsultaOperacoes(Myconnect) }); break;
                    case "m5131": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Financeiro.CartaoCredito.UclInterface(Myconnect) }); break;
                    case "m5132": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Financeiro.CartaoCredito.UclInterfaceConsultaRegistros(Myconnect) }); break;
                    case "m5210": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Financeiro.Titulo.UclTitulo(Myconnect) }); break;
                    case "m8106": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Sistema.UclSistemaAcessos(Myconnect) }); break;
                    case "m8202": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Sistema.UclProcessos(Myconnect) }); break;
                    case "m8203": MDIPag.Children.Add(new WPF.MDI.MdiChild() { Title = _TitleMenu, MaxHeight = 490, Content = new Sistema.UclManagarDataBaseSpWho(Myconnect) }); break;
                    case "m2314":
                        MessageBox.Show("Em desenvolvimento...");
                        Forms.FrmXProdutoPreco frmXPrecos = new Forms.FrmXProdutoPreco(Myconnect);
                        frmXPrecos.Show();
                        //Operacionais.Produto.OperacaoProdutoPrecoList frm = new Operacionais.Produto.OperacaoProdutoPrecoList(Myconnect);
                        //frm.ShowDialog();
                        break;
                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString());
            }
        }

        private void SetConfigFiles()
        {
            try
            {
                CONFIG_FILE_ENV = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Wpf.exe", "") + @"Configs\ENVS.XML";
                CONFIG_FILE_CONNECTIONS_SQLSERVER = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Wpf.exe", "") + @"Configs\infox.dll";
                CONFIG_FILE_ZEBRA = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Wpf.exe", "") + @"Configs\infom.dll";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Project Load | SetConfigFiles: " + ex.Message);
            }

        }
        private void SetEnviroment()
        {

            XmlDocument MyXml = new XmlDocument();
            MyXml.LoadXml(Pag_Net.Tools.PagToolsFileTxt.open(CONFIG_FILE_ENV));
            XmlNodeList x = MyXml.GetElementsByTagName("ENV");
            CONFIG_ENV = x.Item(0).Attributes["Environment"].Value.ToString();

        }
        private void SetMenuHiddenAll()
        {
            ProjectMenu.Visibility = System.Windows.Visibility.Hidden;
            for (int z = 0; z < ProjectMenu.Items.Count; z++)
            {
                MenuItem item = (MenuItem)ProjectMenu.Items[z];
                foreach (MenuItem submenu in item.Items)
                {
                    submenu.IsEnabled = false;
                    foreach (MenuItem ItemSubMenu in submenu.Items)
                    {
                        ItemSubMenu.IsEnabled = false;
                        foreach (MenuItem sItemSubMenu in ItemSubMenu.Items)
                        {
                            sItemSubMenu.IsEnabled = false;
                        }
                    }
                }
            }

        }
        private void SetZEBRAConfigs()
        {

            Myconnect.ZEBRA = "1";
            //String FileMenuAmbienteZebra = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Wpf.exe", "") + @"\infoM.dll";
            if (File.Exists(CONFIG_FILE_ZEBRA))
            {

                Cryptf PagToolCrypt = new Cryptf();
                string XMLConnection = PagToolCrypt.FileDecryptToString(CONFIG_FILE_ZEBRA);
                XmlDocument MyXml = new XmlDocument();
                MyXml.LoadXml(XMLConnection);
                XmlNodeList x = MyXml.GetElementsByTagName("CONFIG");
                foreach (XmlNode attr in x)
                {
                    Myconnect.ZEBRA = attr.Attributes["ZEBRA"].Value.ToString();
                    Myconnect.ZEBRACMD = attr.Attributes["ZEBRACMD"].Value.ToString();
                    Myconnect.ZEBRACMDL = attr.Attributes["ZEBRACMDL"].Value.ToString();
                }
            }
        }

    }
}
