using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using System.IO;
using System.Timers;
using Pag_Net.Models ;
using Pag_Net.Bll;
using Pag_Net.Tools;
using System.Xml;


//using System.Windows.Forms;

namespace Pag_Net
{
    public partial class ServicePag : ServiceBase
    {

        

        modelSistemaUsuario MyConnect;
        //TbServicesTime[] TbServiceTime;

        public string CONFIG_ENV = "PRD";
        public string CONFIG_FILE_ENV = "";

        Timer tProc = new Timer();
        string __ServicePagLogPathERROR = "";
        string __ServicePagLogPath = "";
        string __ServicePagLogName = "";
        string __DataBaseUser = "";
        string __DataBaseUserPassWord = "";
        string __SystemEnvironment = "";
        string __SystemId = "";
        string __SystemNetWork = "";
        string __InfoXfilePath = "";
        string __ServiceOwner = "";
        string __PagAPI = "";
        string __DataBaseService = "";
        string __DataBaseName = "";

        string __DiaSemanaInicial             = "";
        string __DiaSemanaFinal               = "";
        string __HoraInicial                  = "";
        string __HoraFinal                    = "";
        string __SystemSRRReprocessamento = "";    



        int _currentMinute = 0;
        int _currentSecond = 0;
        int _currentWeekday = 0;
        int _currentHor = 0;

        DateTime _currentDate;

        Pag_Net.Models.SPR0050ServicesTimes ModelParametros;
        Pag_Net.Models.SPR0050ServicesTimes[] SPR0050ServicesTimes;
        Pag_Net.Bll._Service BLL_SERVICE;

        public ServicePag()
        {
            try
            {
                InitializeComponent();
                //eventLOGPAG = new EventLog("SERVICEPAGlogX");
                //eventLOGPAG.Source = "SERVICEPAGlogX";
                //eventLOGPAG.Log = "MyServiceLog_ServiceX";
            }
            catch (Exception ex)
            {
                LogFile.Write(@"D:\TI\ERRO_SERVICE.txt", ex.Message.ToString());
            }
        }
        protected override void OnStart(string[] args)
        {
            /* Definindo Paths */

            _SetEnviroment();

            try
            {
                //eventLOGPAG.WriteEntry("OnStart Inicializado");

                ModelParametros = new Models.SPR0050ServicesTimes(@CONFIG.Default["ServiceOwner"].ToString().Trim());


                if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) _currentWeekday = 1;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Monday) _currentWeekday = 2;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday) _currentWeekday = 3;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday) _currentWeekday = 4;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday) _currentWeekday = 5;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday) _currentWeekday = 6;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday) _currentWeekday = 7;
                

                LogFile.Write(__ServicePagLogName, string.Format("Serviço WINDOWS {0}", Pag_Net.Models.PagInfo.Version_description));
                LogFile.Write(__ServicePagLogName, "Codigo do Sistema...............: " + __SystemId.ToString());
                LogFile.Write(__ServicePagLogName, "Ambiente........................: " + __SystemEnvironment.ToString());
                LogFile.Write(__ServicePagLogName, "Sistema em Operação.............: " + __ServiceOwner.ToString());
                LogFile.Write(__ServicePagLogName, "Rede............................: " + __SystemNetWork.ToString());
                LogFile.Write(__ServicePagLogName, "Path Arquivo de Log.............: " + __ServicePagLogPath.ToString());
                LogFile.Write(__ServicePagLogName, "Nome Arquivo de Log.............: " + __ServicePagLogName.ToString());
                LogFile.Write(__ServicePagLogName, "(Padrão) Base de Dados..........: " + __DataBaseName.ToString());
                LogFile.Write(__ServicePagLogName, "(Padrão) Base de Dados Info.....: " + __InfoXfilePath.ToString());
                LogFile.Write(__ServicePagLogName, "(Padrão) Usuario Database.......: " + __DataBaseUser.ToString());
                LogFile.Write(__ServicePagLogName, "(Padrão) Usuario Database pwd...: " + "*");
                LogFile.Write(__ServicePagLogName, "(Padrão) Execução Weekday INI...: " + __DiaSemanaInicial.ToString());
                LogFile.Write(__ServicePagLogName, "(Padrão) Execução Weekday FIM...: " + __DiaSemanaFinal.ToString());
                LogFile.Write(__ServicePagLogName, "(Padrão) Execução Hora Inicial..: " + __HoraInicial.ToString());
                LogFile.Write(__ServicePagLogName, "(Padrão) Execução Hora Final....: " + __HoraFinal.ToString());

                
                LogFile.Write(__ServicePagLogName, "-------------------------------------------------------------");
                LogFile.Write(__ServicePagLogName, "Dados específicos por Serviço ");
                LogFile.Write(__ServicePagLogName, "SRR Reprocessamento.............:" + __SystemSRRReprocessamento.ToString());
                LogFile.Write(__ServicePagLogName, "-------------------------------------------------------------");
                LogFile.Write(__ServicePagLogName, "Inicialização do Serviço");
                LogFile.Write(__ServicePagLogName, "Dia da Semana Identificado......:" + _currentWeekday.ToString());







                if (__SystemId == "SER")
                {
                    LogFile.Write(__ServicePagLogName, "-------------------------------------------------------------");
                    LogFile.Write(__ServicePagLogName, "INICIALIZADO O SERVIÇO: " + __SystemId);
                    LogFile.Write(__ServicePagLogName, " * * Preparando o pacote de Conexao");

                    //MyConnect = Pag_Net.Bll.PagConnection.MyConnection(__SystemId, __DataBaseUser, __SystemEnvironment, __SystemNetWork, __DataBaseUserPassWord, __InfoXfilePath);

                    MyConnect = new modelSistemaUsuario("3", CONFIG_ENV, "elias", "+17jesusbom");
                    
                    
                    MyConnect.PAG_API = __PagAPI;
                    MyConnect.Path_Spool = @"D:\TI\";  //@System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("ServicePag.exe", "") + @"spool\";

                    bool statusLOGIN = MyConnect.login("3", CONFIG_ENV, "elias", "+17jesusbom", true);
                    BLL_SERVICE = new _Service(MyConnect, __ServicePagLogName);
                    

                    /*
                    foreach (TbSysDatabase i in MyConnect.ListConnections)
                    {
                        LogFile.Write(__ServicePagLogName, " * * Servidor...............:" + i.DataSourceLAN);
                    }*/

                    if (statusLOGIN)
                    {
                        LogFile.Write(__ServicePagLogName, " * * Status Conexao.........: Ok");
                    }
                    else 
                    {
                        LogFile.Write(__ServicePagLogName, " * * Status Conexao.........: NO");
                    }

                    LogFile.Write(__ServicePagLogName, " * * Obtendo lista de servicos e horarios");
                    BLL_SERVICE.ObterServicosTime();
    
                    //SPR0050ServicesTimes = Pag_Net.Bll.SqlServer.SPR0050ServicesTimes.List(MyConnect, ModelParametros);
                    LogFile.Write(__ServicePagLogName, " * * Numero de Servicos.....: " + BLL_SERVICE.ListaDeServicosTimes.Length.ToString());
                    LogFile.Write(__ServicePagLogName, " * * Servico Windows em Execucao*");


                }

                tProc.Elapsed += new ElapsedEventHandler(tProc_Elapsed);
                tProc.Interval = 1000;
                tProc.Enabled = true;
                tProc.Start();


            }
            catch (Exception ex)
            {
                //eventLOGPAG.WriteEntry("Error: " + ex.Message);
                Console.WriteLine("ServicePAG OnStart Errro: " + ex.Message);
                LogFile.Write(@"D:\TI\ERRO_SERVICE.txt", ex.Message.ToString());
            }

            
            
        }

        private void tProc_Elapsed(object sender, EventArgs e)
        {
            try
            {

                int _currentHor = Convert.ToInt16(DateTime.Now.Hour.ToString());
                int _currentMinute = Convert.ToInt16(DateTime.Now.Minute.ToString());
                int _currentSecond = Convert.ToInt16(DateTime.Now.Second.ToString());
                DateTime _currentDate = DateTime.Now.Date;

                int _currentWeekday = 0;

                if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) _currentWeekday = 1;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Monday) _currentWeekday = 2;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday) _currentWeekday = 3;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday) _currentWeekday = 4;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday) _currentWeekday = 5;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday) _currentWeekday = 6;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday) _currentWeekday = 7;
               
                string minuto_str = _currentMinute.ToString();
                if (minuto_str.Length == 1) minuto_str = "0" + minuto_str;

                minuto_str = minuto_str.Substring(1, 1);


                if (__SystemId == "SER")
                {
                    if (minuto_str == "1")
                    {
                        if (_currentSecond == 0)
                        {
                            LogFile.Write(__ServicePagLogName, "Serviço ATIVO");
                        }
                    }
                    BLL_SERVICE.ProcessarServicosTime();
                }

                if (__SystemId == "SRR")
                {


                    if (_currentWeekday >= Convert.ToInt32(__DiaSemanaInicial) && _currentWeekday <= Convert.ToInt32(__DiaSemanaFinal))
                    {
                        if (_currentHor >= Convert.ToInt32(__HoraInicial) && _currentHor <= Convert.ToInt32(__HoraFinal))
                        {
                            if (minuto_str == "1" || minuto_str == "3" || minuto_str == "5" || minuto_str == "7" || minuto_str == "9")
                            {
                                if (_currentSecond == 0)
                                {
                                    LogFile.Write(__ServicePagLogName, "SRR | Serviço Serra do Sol em execução ...");
                                    ServicoSerraDoSol();
                                    LogFile.Write(__ServicePagLogName, "SRR | Serviço Serra do Sol Executado com sucesso ...");
                                }
                            }
                        }
                    }


                }
            }

            catch (Exception ex)
            {
                LogFile.Write(@"D:\TI\ERRO_SERVICE.txt", ex.Message.ToString());
            }
        }

        protected override void OnStop()
        {
            tProc.Stop();
            tProc.Enabled = false;
            try
            {
                LogFile.Write(__ServicePagLogName, "___ Servico Windows finalizado pelo Usuario ");
            }
            catch (Exception ex)
            {
                LogFile.Write(@"D:\TI\ERRO_SERVICE.txt", ex.Message.ToString());
            }

        }

        private void ServicoSerraDoSol()
        {
            try
            {
                DataSet DataSetReturn = new DataSet();
                LogFile.Write(__ServicePagLogName, "SRR | Acessando Base GUARDIAN");

                string _SCRIPT_SERRA_DO_SOL = "SELECT		    gtk_seq                     =   0 " + 
                                              "               , gtk_uuid                    =   '' " + 
                                              "               , gtk_numero				    =	a.tck_sequencial " +
                                              "               ,	gtk_placa					=	a.tck_placa_carreta " +
                                              "               ,	gtk_data					=	a.tck_data                                                                              " +
                                              "               ,	gtk_pesagemInicialHora   	=	convert(datetime, convert(varchar(25), isnull(x1.otk_data,'1900-01-01 01:01:01')))      " +
                                              "               ,	gtk_pesagemFinalHora    	=	convert(datetime, convert(varchar(25), isnull(x2.otk_data,'1900-01-01 01:01:01')))      " +
                                              "               ,	gtk_pesagemInicialPeso	    =	convert(numeric(13,0), isnull(x1.otk_peso,0))                                           " +
                                              "               ,	gtk_pesagemFinalPeso	    =	convert(numeric(13,0), isnull(x2.otk_peso,0))                                           " +
                                              "               ,	gtk_pesagemPesoLiquido	    =	convert(numeric(13,0), isnull(x2.otk_peso_liquido,0))                                   " +
                                              "   from			GUARDIAN.DBO.tbticket				a                                                                                   " +
                                              "   left join     GUARDIAN.DBO.tbOperacoesTicket		x1 on x1.tck_sequencial = a.tck_sequencial and x1.otk_codigo = 1                    " +
                                              "   left join     GUARDIAN.DBO.tbOperacoesTicket		x2 on x2.tck_sequencial = a.tck_sequencial and x2.otk_codigo = 2                    " +
                                              "   where			1 = 1 ";
                if (__SystemSRRReprocessamento.Trim() == "0")
                {
                    _SCRIPT_SERRA_DO_SOL = _SCRIPT_SERRA_DO_SOL +
                                     "   and			convert(char(8), a.tck_data, 112) = convert(char(8), GETDATE(), 112) ";
                }
                else 
                {
                     _SCRIPT_SERRA_DO_SOL = _SCRIPT_SERRA_DO_SOL + string.Format(
                                              "   and			convert(char(8), a.tck_data, 112) >= convert(char(8), GETDATE() - {0}, 112)"
                                              , __SystemSRRReprocessamento);
                }

                _SCRIPT_SERRA_DO_SOL = _SCRIPT_SERRA_DO_SOL + "   order by		3";


               /*_SCRIPT_SERRA_DO_SOL = "SELECT	TOP 10          gtk_seq = 0                                              " + 
                                             "               ,  gtk_uuid = '' " + 
                                             "               , 	gtk_numero = TicketNumero				                  " +
                                             "               ,	gtk_placa = TicketPlaca					                  " +
                                             "               ,	gtk_data = isnull(TicketData, '1900-01-01')               " +
                                             "               ,	gtk_pesagemInicialHora = isnull(OperacaoPesagemInicialHora, '1900-01-01')	      " +
                                             "               ,	gtk_pesagemFinalHora = isnull(OperacaoPesagemFinalHora, '1900-01-01')	          " +
                                             "               ,	gtk_pesagemInicialPeso = isnull(OperacaoPesagemInicialPeso	,0)      " +
                                             "               ,	gtk_pesagemFinalPeso = isnull(OperacaoPesagemFinalPeso,0)	          " +
                                             "               ,	gtk_pesagemPesoLiquido = isnull(OperacaoPesagemPesoLiquido,0)	      " +
                                             "   from			OXAN_EST.DBO.TbTicketGuardianResumo                       " +
                                             "   WHERE          TicketData >= CONVERT(varchar(8), getdate() - 10, 112)    " +
                                             "   order by		3";*/


                 
                  
                System.Data.SqlClient.SqlConnection CNN = new System.Data.SqlClient.SqlConnection(
                    string.Format(
                                    "Data Source = {0} ;" +
                                    "Initial Catalog = {1};" +
                                    "User Id= {2};" +
                                    "PassWord= {3};" +
                                    "Connection Timeout= 15", __DataBaseService, __DataBaseName, __DataBaseUser, __DataBaseUserPassWord));
                System.Data.SqlClient.SqlCommand sqlCommandExecute = new System.Data.SqlClient.SqlCommand(_SCRIPT_SERRA_DO_SOL);
                sqlCommandExecute.Connection = CNN;


                sqlCommandExecute.CommandTimeout = 25;

                LogFile.Write(__ServicePagLogName, "SRR | Executando Leitura");

                System.Data.SqlClient.SqlDataAdapter sqldtAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlCommandExecute);
                sqldtAdapter.Fill(DataSetReturn);

                LogFile.Write(__ServicePagLogName, "SRR | Exportando Registros");

                List<Pag_Net.Bll.F0062_Guardian.tbguardianticket> _list = new List<Bll.F0062_Guardian.tbguardianticket>();

                LogFile.Write(__ServicePagLogName, string.Format("SRR | Numero de Tickets lançados no dia: {0}", DataSetReturn.Tables[0].Rows.Count.ToString()));

                foreach (System.Data.DataRow i in DataSetReturn.Tables[0].Rows)
                {
                    Bll.F0062_Guardian.tbguardianticket item = new Bll.F0062_Guardian.tbguardianticket(i);

                    Pag_Net.Bll.RESTAPI.get(string.Format("{0}/m0062_guardianticket_incluir", __PagAPI), new Bll.F0062_Guardian.tbguardianticket(i)._PostAPI());
                    
                    LogFile.Write(__ServicePagLogName, string.Format("Ticket Exportado N. {0} - {1}", item.gtk_numero.ToString(), item._PostAPI()));
                    
                }

                LogFile.Write(__ServicePagLogName, "SRR | Fechando conexão com a base Guardian");
                sqlCommandExecute.Connection.Close();
                sqlCommandExecute.Dispose();
                sqldtAdapter.Dispose();
            }
            catch (Exception ex)
            {
                LogFile.Write(@"D:\TI\ERRO_SERVICE.txt", ex.Message.ToString());
            }
            

        }

        private void _SetEnviroment()
        {
            try
            {

                CONFIG_FILE_ENV = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("ServicePag.exe", "") + @"Configs\ENVS.XML";

                XmlDocument MyXml = new XmlDocument();
                MyXml.LoadXml(Pag_Net.Tools.PagToolsFileTxt.open(CONFIG_FILE_ENV));
                XmlNodeList x = MyXml.GetElementsByTagName("ENV");
                CONFIG_ENV = x.Item(0).Attributes["Environment"].Value.ToString();
                __PagAPI = x.Item(0).Attributes["PAG_API"].Value.ToString();


                __SystemId = CONFIG.Default["SystemId"].ToString().Trim();
                __SystemEnvironment = CONFIG.Default["SystemEnvironment"].ToString().Trim();
                __SystemNetWork = CONFIG.Default["SystemNetWork"].ToString().Trim();
                __ServiceOwner = @CONFIG.Default["ServiceOwner"].ToString().Trim();
                __ServicePagLogPath = @CONFIG.Default["ServicePagLogPath"].ToString();
                __ServicePagLogName = __ServicePagLogPath + @"\" + @CONFIG.Default["ServicePagLogName"].ToString();
                __InfoXfilePath = @CONFIG.Default["InfoXFilePath"].ToString().Trim();
                __DataBaseService = CONFIG.Default["DataBaseService"].ToString().Trim(); ;
                __DataBaseUser = CONFIG.Default["DataBaseUser"].ToString().Trim();
                __DataBaseUserPassWord = CONFIG.Default["DataBaseUserPassWord"].ToString().Trim();
                __PagAPI = CONFIG.Default["PagAPI"].ToString().Trim(); ;
                __DataBaseName = CONFIG.Default["DataBaseName"].ToString().Trim(); ;
                __DiaSemanaInicial = CONFIG.Default["DiaSemanaInicial"].ToString().Trim();
                __DiaSemanaFinal = CONFIG.Default["DiaSemanaFinal"].ToString().Trim();
                __HoraInicial = CONFIG.Default["HoraInicial"].ToString().Trim();
                __HoraFinal = CONFIG.Default["HoraFinal"].ToString().Trim();
                __SystemSRRReprocessamento = CONFIG.Default["SystemSRRReprocessamento"].ToString().Trim();

            }
            catch (Exception ex)
            {
                LogFile.Write(@"D:\TI\ERRO_SERVICE.txt", ex.Message.ToString());
            }

        }
    }
}


