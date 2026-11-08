using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using System.Data;
using System.Data.Odbc;
using Pag_Net.Bll;
using Pag_Net.Tools.CryptFile ;
using Pag_Net.Tools.CryptPassWord;
using System.Collections;
using System.Collections.Generic;
using Pag_Net.Tools;
using Pag_Net.Models;
using Pag_Net.Bll.BlueSoft;
using System.Linq;
using RestSharp;
using System.Reflection;
using System.Collections.Concurrent;
using System.Xml;
using PagConsole;
using System.Timers;



namespace Pag_Net.Cmd
{
    class PagConsole
    {
        static void Main(string[] args)
        {
            try
            {
                if (args[0] == "--HELP" || args[0].Trim() == @"/HELP" || args[0].Trim() == @"/" || args.Length == 0 || args[0] == null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("PagConsole.EXE Versao: " + Pag_Net.Models.PagInfo.VERSAO);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("1.  Processo..: Criptografia de Arquivo:");
                    Console.WriteLine("1.1 Objetivo..: Executa a criptografia de um arquivo texto");
                    Console.WriteLine("1.2 Comando N.: 1 [Arquivo_Origem] [Arquivo_Destino]");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("2.  Processo..: Descriptografia de Arquivos:");
                    Console.WriteLine("2.1 Objetivo..: Executa a Descriptografia de um arquivo texto");
                    Console.WriteLine("2.2 Comando N.: 2 [Arquivo_Origem] [Arquivo_Destino]");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("3.  Processo..: Definição de Usuário");
                    Console.WriteLine("3.1 Objetivo..: Criar USER Blue no Ambiente PAG.");
                    Console.WriteLine("3.2 Objetivo..: Obs: O usário deve estar cadastrada na bluesoft (BASE d+1):");
                    Console.WriteLine("3.3 Comando N.: 3 [Senha ADMIN-FULL] [USER BLUE] [SET PASSWORD] [CD FUNCTION]");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("4.  Processo..: Teste de Inicialização do ServicePag");
                    Console.WriteLine("4.1 Comando N.: 4");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("9.  Processo..: Testes de DESENVOLVIMENTO em Ambiente de Produção");
                    Console.WriteLine("9.1 Comando N.: 9");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("10.  Processo..: Export user web");
                    Console.WriteLine("10.1 Comando N.: Export user web");
                    Console.WriteLine(args[0].ToString());



                }


                if (args[0] == "0")
                {
                    PagConsoleOpcao_0();
                }
                if (args[0] == "1")
                {
                    PagConsoleOpcao_1(args[1], args[2]);
                }
                if (args[0] == "2")
                {
                    PagConsoleOpcao_2(args[1], args[2]);
                }
                if (args[0] == "3")
                {
                    PagConsoleOpcao_3(args[1], args[2], args[3], args[4]);
                    
                }

                if (args[0] == "4")
                {
                    PagConsoleOpcao_4();

                }

                if (args[0] == "5")
                {
                    PagConsoleOpcao_5();

                }

                if (args[0] == "10")
                {
                    PagConsoleOpcao_10(args[1]);

                }

                if (args[0] == "11")
                {
                    PagConsoleOpcao_11(args[1]);

                }

                if (args[0] == "TESTE")
                {
                    TESTEX();
                }


                Console.WriteLine("Process completed successfully...");
            }

            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("PagConsole.EXE Versao: " + Pag_Net.Models.PagInfo.VERSAO);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Erro: Digite 'PagConsole /' para acessar o Help do comando");
                Console.WriteLine("");
                Console.WriteLine("");

            }

        }


        static void PagConsoleOpcao_0()
        {
            /*Start Pag com Atualização */
            System.Diagnostics.Process.Start("CMD.exe", @"net use \\192.168.1.6\Tec zhex9erbQEFKjlM /user:suporte");
            System.Diagnostics.Process.Start("CMD.exe", @"net use \\192.168.1.6\Tec zhex9erbQEFKjlM /user:suporte");
            System.Diagnostics.Process.Start("CMD.exe", @"copy \\192.168.1.6\\tec\\sistemas\\Pag\\PRD\\Pag_Net\\_rebuild\\* " + '\u0022' +  "C:\\Program Files (x86)\\Pag\\Pag_Net\\" + '\u0022' +  "/y");
            System.Diagnostics.Process.Start("CMD.exe", @"copy \\192.168.1.6\\tec\\sistemas\\Pag\\PRD\\Pag_Net\\Ico\\" + '\u0022' + "C:\\Program Files (x86)\\Pag\\Pag_Net\\Ico\\" + '\u0022' + "/y");
            System.Diagnostics.Process.Start("CMD.exe", @"net use * /delete /y");

        }
        static void PagConsoleOpcao_1(string file_origem, string file_destino)
        {
            Tools.CryptFile.Cryptf q = new Tools.CryptFile.Cryptf();
            //q.FileEncrypt(@file_origem, @file_destino, "00141722");
            q.FileEncrypt(@file_origem, @file_destino);
            Console.WriteLine("Arquivo ORIGEM: {0} para DESTINO: {1}", @file_origem, @file_destino);
            Console.WriteLine("PRESSIONE <ENTER> PARA FINALIZAR...");
            Console.ReadKey();
        }
        static void PagConsoleOpcao_2(string file_origem, string file_destino)
        {
            Tools.CryptFile.Cryptf q = new Tools.CryptFile.Cryptf();
            //q.FileEncrypt(@file_origem, @file_destino, "00141722");
            q.FileDecrypt(@file_origem, @file_destino);
            Console.WriteLine("Arquivo ORIGEM: {0} para DESTINO: {1}", @file_origem, @file_destino);
            Console.WriteLine("PRESSIONE <ENTER> PARA FINALIZAR...");
            Console.ReadKey();
        }
        static void PagConsoleOpcao_3(string PASSWORD_ADM_FULL, string USER, string PASSWORD, string CDFUNCAO)
        {
            try
            {

                if (PASSWORD_ADM_FULL != "Erj!57895")
                {
                    Console.WriteLine("Error PassWord Admin");
                    return;
                }

                if (USER.Trim() == "" || PASSWORD.Trim() == "" || CDFUNCAO.Trim() == "")
                {
                    Console.WriteLine("Parameter Invalid");
                    return;
                }

                string result_user;
                string CONFIG_PATH = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagConsole.exe", "") + @"Configs\";
                string CONFIG_FILE_ENV = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagConsole.exe", "") + @"Configs\ENVS.XML";
                string CONFIG_FILE_CONNECTIONS_SQLSERVER = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagConsole.exe", "") + @"Configs\infox.dll";

                string CONFIG_ENV = "PRD";

                XmlDocument MyXml = new XmlDocument();
                MyXml.LoadXml(Pag_Net.Tools.PagToolsFileTxt.open(CONFIG_FILE_ENV));
                XmlNodeList x = MyXml.GetElementsByTagName("ENV");
                CONFIG_ENV = x.Item(0).Attributes["Environment"].Value.ToString();

                Pag_Net.Models.modelSistemaUsuario Myconnect = Pag_Net.Bll.PagConnection.MyConnection("WPF", "elias", CONFIG_ENV, "LAN", "+17jesusbom", CONFIG_FILE_CONNECTIONS_SQLSERVER);


                //Myconnect.PAG_API = CONFIG_API;



                Cryptf PagToolCrypt = new Cryptf();
                Pag_Net.Tools.CryptPassWord.Criptp cr = new Criptp(CryptProvider.TripleDES);
                //cr.Key = "141722P";
                string cryptpassword_USER_SET = cr.Encrypt(PASSWORD);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("ENV................................:" + CONFIG_ENV);

                string _admin_password = "+17jesusbom";
                Pag_Net.Models.ModelSistemaPermissoes[] _Postgre_Acessos = Pag_Net.Bll.PagConnection.ConsultarPostgreAcessos(Myconnect, new Pag_Net.Models.Filter.Login("elias", cr.Encrypt(_admin_password), ""));
                if (_Postgre_Acessos.Count() < 1)
                {
                    Console.WriteLine("ADMIN LOGIN ERROR");
                    return;
                }

                string SCRIPT_SQL = string.Format(" select user_name, cdpessoabluesoft, dtlog_update from tbsistema_usuario where user_name = '{0}'  ", USER);
                DataTable DATATABLE_USER_OLD = BDCommand.get_DataTable(Myconnect, SCRIPT_SQL);
                result_user = string.Format("User name: {0}, Cd User: {1}, Date Update: {2}", DATATABLE_USER_OLD.Rows[0]["user_name"].ToString(), DATATABLE_USER_OLD.Rows[0]["cdpessoabluesoft"].ToString(), DATATABLE_USER_OLD.Rows[0]["dtlog_update"].ToString());

                if (DATATABLE_USER_OLD.Rows.Count < 1)
                {
                    Console.WriteLine("User Set not found");
                    return;
                }
                Console.WriteLine("Last User SET............: " + result_user);


                string SCRIPT_SQL_UPDATE = string.Format("UPDATE tbsistema_usuario set passwd = '{1}', sis_fc_cd = {2}, dtlog_update = current_timestamp where user_name = '{0}'  ", USER, cryptpassword_USER_SET, CDFUNCAO);

                BDCommand.Execute(Myconnect, SCRIPT_SQL_UPDATE);
                Console.WriteLine("PASSWORD SET PASSWD......: " + cryptpassword_USER_SET);

 
                DataTable DATATABLE_USER = BDCommand.get_DataTable(Myconnect, SCRIPT_SQL);
                
                if (DATATABLE_USER.Rows.Count < 1)
                {
                    Console.WriteLine("Error UPDATE");
                    return;
                }
                result_user = string.Format("User name: {0}, Cd User: {1}, Date Update: {2}", DATATABLE_USER.Rows[0]["user_name"].ToString(), DATATABLE_USER.Rows[0]["cdpessoabluesoft"].ToString(), DATATABLE_USER.Rows[0]["dtlog_update"].ToString());
                Console.WriteLine("Next UPDATE..............: " + result_user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error USER SET: " + ex.Message);
            }

        
        }
        static void PagConsoleOpcao_4()
        {
            try
            {

                modelSistemaUsuario MyConnect;
                //TbServicesTime[] TbServiceTime;

                Pag_Net.Models.SPR0050ServicesTimes ModelParametros;
                Pag_Net.Models.SPR0050ServicesTimes[] SPR0050ServicesTimes;



                //String UserService = @CONFIG.Default["UserService"].ToString();
                //String LogFile = @CONFIG.Default["ServicePagLog"].ToString();
                //String PedArqPath = @CONFIG.Default["ServicePagDirExport"].ToString();

                //LogFile LogFile = new LogFile();

                string LOG_PATH_DEFAULT = "";
                string _logServiceFile = "";
                string _UserDataBase = "";
                string _UserDataBasePassWord = "";
                string _Environment = "";
                string _SystemId = "";
                string _SystemNetWork = "";
                string _InfoXfilePath = "";
                string _ServiceOwner = "";

                int _currentMinute = 0;
                int _currentSecond = 0;
                int _currentWeekday = 0;
                int _currentHor = 0;
                DateTime _currentDate;



                LOG_PATH_DEFAULT = @"D:\Projects\Pag_1.0.16\BIN\spool";
                _logServiceFile = LOG_PATH_DEFAULT + @"\" + "ServiceLogs.txt";
                _SystemId = "SER";
                _UserDataBase = "USRSRV";
                _UserDataBasePassWord = "!usrserv729";
                _Environment = "PRD";
                _SystemNetWork = "LAN";
                _InfoXfilePath = @"D:\Projects\Pag_1.0.16\BIN\infox.dll";
                ModelParametros = new Models.SPR0050ServicesTimes("SRV03");
                


                LogFile.Write(_logServiceFile, "Codigo do Sistema: " + _SystemId.ToString());
                LogFile.Write(_logServiceFile, "Usuario Database: " + _UserDataBase.ToString());
                LogFile.Write(_logServiceFile, "Ambiente: " + _Environment.ToString());
                LogFile.Write(_logServiceFile, "Rede: " + _SystemNetWork.ToString());
                //LogFile.Write(_logServiceFile, "Password: " + _UserDataBasePassWord.ToString());
                LogFile.Write(_logServiceFile, "Arquivo Conexao: " + _InfoXfilePath.ToString());
                LogFile.Write(_logServiceFile, string.Format("INICIALIZANDO SERVICO: VERSAO {0}", Pag_Net.Models.PagInfo.Version_description));
                LogFile.Write(_logServiceFile, "PREPARANDO PACOTE DE CONEXAO");


                MyConnect = Pag_Net.Bll.PagConnection.MyConnection(_SystemId, _UserDataBase, _Environment, _SystemNetWork, _UserDataBasePassWord, _InfoXfilePath);
                foreach (TbSysDatabase i in MyConnect.ListConnections)
                {
                    LogFile.Write(_logServiceFile, i.DataSourceLAN + " - " + i.DataBase + " - " + i.UsrDataBase);
                }

                LogFile.Write(_logServiceFile, "TRANSACAO DE CONEXAO EFETUADA");
                LogFile.Write(_logServiceFile, "Lendo Servicos");


                //bllServicesTime ServicesTime = new bllServicesTime(MyConnection);


                SPR0050ServicesTimes = Pag_Net.Bll.SqlServer.SPR0050ServicesTimes.List(MyConnect, ModelParametros);




                LogFile.Write(_logServiceFile, "Numero de Servicos Agendados: " + SPR0050ServicesTimes.Length.ToString());

                DateTime DataInicial = DateTime.Now.Add(new TimeSpan(-15, 0, 0, 0)).Date;
                DateTime DataFinal = DateTime.Now.Date;
                Pag_Net.Bll.Integration.RedShiftSqlServer.SPC5000TbDocumentosFiscais.Execute(MyConnect, new Pag_Net.Models.SPC5000TbDocumentosFiscais(0, 0, 0, 0, DataInicial, DataFinal));


                LogFile.Write(_logServiceFile, "START");
                LogFile.Write(_logServiceFile, "DEFININDO TIME");



            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }





        }
        static void PagConsoleOpcao_5()
        {
            try
            {
                ServicePag TESTEServicePag = new ServicePag();
                TESTEServicePag.onStart();
            }
            catch (Exception ex)
            {
                Console.WriteLine("PAGConsole | TESTE SERVICE PAG ERROR: " + ex.Message);
            }

        }
        static void PagConsoleOpcao_10(string PASSWORD_ADM_FULL)
        {
            try
            {
                if (PASSWORD_ADM_FULL != "Erj!57895")
                {
                    Console.WriteLine("Error PassWord Admin");
                    return;
                }


                string CONFIG_PATH = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagConsole.exe", "") + @"Configs\";
                string CONFIG_FILE_ENV = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagConsole.exe", "") + @"Configs\ENVS.XML";
                string CONFIG_FILE_CONNECTIONS_SQLSERVER = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagConsole.exe", "") + @"Configs\infox.dll";

                string CONFIG_ENV = "PRD";

                XmlDocument MyXml = new XmlDocument();
                MyXml.LoadXml(Pag_Net.Tools.PagToolsFileTxt.open(CONFIG_FILE_ENV));
                XmlNodeList x = MyXml.GetElementsByTagName("ENV");
                CONFIG_ENV = x.Item(0).Attributes["Environment"].Value.ToString();

                Pag_Net.Models.modelSistemaUsuario Myconnect = Pag_Net.Bll.PagConnection.MyConnection("WPF", "elias", CONFIG_ENV, "LAN", "+17jesusbom", CONFIG_FILE_CONNECTIONS_SQLSERVER);

                string sql = "select sis_us_seq, passwd from tbsistema_usuario where passwd != '' and passwd != '*' ";
          
                DataTable DATATABLE_USER = BDCommand.get_DataTable(Myconnect, sql);
                Console.WriteLine("NUMERO DE USUARIOS COLETADOS PARA A ALTERAÇÃO DE SENHA " + DATATABLE_USER.Rows.Count.ToString());

                Cryptf PagToolCrypt = new Cryptf();
                string sqlupdate = "";
                foreach (DataRow item in DATATABLE_USER.Rows)
                {
                    Pag_Net.Tools.CryptPassWord.Criptp cr = new Criptp(CryptProvider.TripleDES);
                    sqlupdate += string.Format("update tbsistema_usuario set passwd_web = '{1}' where sis_us_seq = {0};", item["sis_us_seq"].ToString(), cr.Decrypt(item["passwd"].ToString().ToString()));
                }
                BDCommand.Execute(Myconnect, sqlupdate);
                Console.WriteLine("Processo pagN2011001 finalizado com sucesso");


            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            } 
        }
        static void PagConsoleOpcao_11(string PASSWORD_ADM_FULL)
        {
            try
            {
                if (PASSWORD_ADM_FULL != "Erj!57895")
                {
                    Console.WriteLine("Error PassWord Admin");
                    return;
                }


                string CONFIG_PATH = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagConsole.exe", "") + @"Configs\";
                string CONFIG_FILE_ENV = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagConsole.exe", "") + @"Configs\ENVS.XML";
                string CONFIG_FILE_CONNECTIONS_SQLSERVER = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagConsole.exe", "") + @"Configs\infox.dll";

                string CONFIG_ENV = "PRD";

                XmlDocument MyXml = new XmlDocument();
                MyXml.LoadXml(Pag_Net.Tools.PagToolsFileTxt.open(CONFIG_FILE_ENV));
                XmlNodeList x = MyXml.GetElementsByTagName("ENV");
                CONFIG_ENV = x.Item(0).Attributes["Environment"].Value.ToString();

                Pag_Net.Models.modelSistemaUsuario Myconnect = Pag_Net.Bll.PagConnection.MyConnection("WPF", "elias", CONFIG_ENV, "LAN", "+17jesusbom", CONFIG_FILE_CONNECTIONS_SQLSERVER);

                string sql = "select sis_us_seq, user_name, passwd from tbsistema_usuario where passwd != '' and passwd != '*' ";

                DataTable DATATABLE_USER = BDCommand.get_DataTable(Myconnect, sql);
                Console.WriteLine("NUMERO DE USUARIOS COLETADOS PARA A ALTERAÇÃO DE SENHA " + DATATABLE_USER.Rows.Count.ToString());

                Cryptf PagToolCrypt = new Cryptf();
                string sqlupdate = "";
                foreach (DataRow item in DATATABLE_USER.Rows)
                {
                    Pag_Net.Tools.CryptPassWord.Criptp cr = new Criptp(CryptProvider.TripleDES);
                    Console.WriteLine(item["user_name"].ToString() + " --- " + cr.Decrypt(item["passwd"].ToString().ToString()));
                }
                Console.WriteLine("Processo pagN2011001 finalizado com sucesso");


            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }
        }
        static void ReadCSV()
        {
            
            
            string[] linhas = Pag_Net.Tools.LogFile.ReadLine(@"D:\All\Teste\ENTRADAS.csv");



            

            //00.Data;
            //01.Fornecedor;
            //02.NF;
            //03.GTIN/PLU;
            //04.C¢digo do Produto;
            //05.Descri‡Æo;
            //06.Qtd;
            //07.C. Bruto da Compra;
            //08.C. L¡quido da Compra;
            //09.Pre‡o Normal;
            //10.Markup;
            //11.Custo PMZ;
            //12.Markup sobre custo PMZ;
            //13.Pre‡o sugerido;
            //14.Mg. Loja;
            //15.Mg. L¡q.;
            //16.Mg. PadrÆo;
            //17.CFOP
            int LinhaInicial = 1;
            int NCol_DataEntrada = 0;
            int NCol_Fornecedor = 1;
            int NCol_NumeroNotaFiscal = 2;
            int NCol_CdBarra = 3;
            int NCol_CdProduto = 4;
            int NCol_Descricao = 5;
            int NCol_Qtde = 6;
            int NCol_CustoBruto = 7;
            int NCol_CustoLiquido = 8;
            int NCol_CFOP = 17;

            DataTable dt = new DataTable("TabTxt");
            dt.Columns.Add("DataEntrada", typeof(DateTime));
            dt.Columns.Add("Fornecedor", typeof(String));
            dt.Columns.Add("NumeroNotaFiscal", typeof(Int32));
            dt.Columns.Add("CdBarra", typeof(String));
            dt.Columns.Add("CdProduto", typeof(Int32));
            
            dt.Columns.Add("Descricao", typeof(String));
            dt.Columns.Add("Qtde", typeof(Decimal));
            dt.Columns.Add("CustoBruto", typeof(Decimal));
            dt.Columns.Add("CustoLiquido", typeof(Decimal));
            dt.Columns.Add("CFOP", typeof(String));


            char[] delimiterChars = { ';' };
            
            for (int i = 0; i < linhas.Count(); i++)
            {

                string linhaRead = linhas[i].ToString();
                string[] colunas = linhaRead.Split(delimiterChars);

                if (i >= LinhaInicial)
                {

                    if (Pag_Net.Tools.IsDate.check(colunas[NCol_DataEntrada].ToString()))
                    {
                        DataRow row = dt.NewRow();
                        row["DataEntrada"] = Convert.ToDateTime(colunas[NCol_DataEntrada]);
                        row["Fornecedor"] = colunas[NCol_Fornecedor].ToString();
                        row["NumeroNotaFiscal"] = Convert.ToInt32(colunas[NCol_NumeroNotaFiscal]);
                        row["CdBarra"] = colunas[NCol_CdBarra].ToString();
                        row["CdProduto"] = Convert.ToInt32(colunas[NCol_CdProduto]);
                        row["Descricao"] = colunas[NCol_Descricao].ToString();
                        row["Qtde"] = Convert.ToDouble(colunas[NCol_Qtde]);
                        row["CustoBruto"] = Convert.ToDouble(colunas[NCol_CustoBruto]);
                        row["CustoLiquido"] = Convert.ToDouble(colunas[NCol_CustoLiquido]);
                        row["CFOP"] = colunas[NCol_CFOP].ToString();
                        dt.Rows.Add(row);
                    }
                }
            }

            /*
             *              for (int i = 0; i < linhas.Count(); i++)
                {
                    DataRow row = dt.NewRow();
                    row["Linha"] = linhas[i];
                    dt.Rows.Add(row);
                }
                ds.Tables.Add(dt);
             */


            



        }
        static void RedShiftConnection()
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            return;
            // Server, e.g. "examplecluster.xyz.us-west-2.redshift.amazonaws.com"
            string server = "aws-dw1.bluesoft.com.br";
            string port = "5432";
            string masterUsername = "oxan_bi";
            string masterUserPassword = "2htLrV8e*qe";
            string DBName = "oxan";
            string query = "select * from information_schema.tables;";
            try
            {
                // Create the ODBC connection string.
                //Redshift ODBC Driver - 64 bits
                //Pag_Net.Dal.DbUpdate Update = new DbUpdate(_myConnect,DataBaseName.DBAMAINERP);
                    string connString = "Driver={Amazon Redshift (x64)};" +
                    String.Format("Server={0};Database={1};" +
                    "UID={2};PWD={3};Port={4};SSL=true",
                /*string connString = "Driver={Amazon Redshift (x64)};" +
                    String.Format("Server={0};Database={1};" +
                    "UID={2};PWD={3};Port={4};SSL=true;Sslmode=Require",*/
                    server, DBName, masterUsername,
                    masterUserPassword, port);
                Console.WriteLine(connString);
                //Redshift ODBC Driver - 32 bits
                /*string connString = "Driver={Amazon Redshift (x86)};" +
                    String.Format("Server={0};Database={1};" +
                    "UID={2};PWD={3};Port={4};SSL=true;Sslmode=Require",
                    server, DBName, masterUsername,
                    masterUserPassword, port);*/
                // Make a connection using the psqlODBC provider.
                //OdbcConnection DbConnection = new OdbcConnection("DSN=BI");
                //OdbcConnection conn = new OdbcConnection(connString);
                OdbcConnection conn = new OdbcConnection("DSN=BI32");
                conn.Open();
                // Try a simple query.
                string sql = query;
                OdbcDataAdapter da = new OdbcDataAdapter(sql, conn);
                da.Fill(ds);
                dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["table_catalog"] + ", " + row["table_name"]);
                }
                conn.Close();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        static void TESTEX()
        {

            try
            {
                DataSet DataSetReturn = new DataSet();


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
                                              "   where			1 = 1 " +
                                              "   and			convert(char(8), a.tck_data, 112) = convert(char(8), GETDATE(), 112)                                               " +
                                              "   order by		3";


                _SCRIPT_SERRA_DO_SOL = "SELECT	TOP 10          gtk_seq = 0                                              " +
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
                                              "   order by		3";




                System.Data.SqlClient.SqlConnection CNN = new System.Data.SqlClient.SqlConnection(
                    string.Format(
                                    "Data Source = SRV02,1433;" +
                                    "Initial Catalog = DBAMAIN;" +
                                    "User Id= elias;" +
                                    "PassWord= swprej141722;" +
                                    "Connection Timeout= 15"));
                System.Data.SqlClient.SqlCommand sqlCommandExecute = new System.Data.SqlClient.SqlCommand(_SCRIPT_SERRA_DO_SOL);
                sqlCommandExecute.Connection = CNN;


                sqlCommandExecute.CommandTimeout = 25;


                System.Data.SqlClient.SqlDataAdapter sqldtAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlCommandExecute);
                sqldtAdapter.Fill(DataSetReturn);


                List<Pag_Net.Bll.F0062_Guardian.tbguardianticket> _list = new List<Bll.F0062_Guardian.tbguardianticket>();


                foreach (System.Data.DataRow i in DataSetReturn.Tables[0].Rows)
                {
                    Bll.F0062_Guardian.tbguardianticket item = new Bll.F0062_Guardian.tbguardianticket(i);

                    Pag_Net.Bll.RESTAPI.get(string.Format("{0}/m0062_guardianticket_incluir", "http://192.168.1.20:57895"), new Bll.F0062_Guardian.tbguardianticket(i)._PostAPI());
                    Console.WriteLine(new Bll.F0062_Guardian.tbguardianticket(i)._PostAPI());

                }

                sqlCommandExecute.Connection.Close();
                sqlCommandExecute.Dispose();
                sqldtAdapter.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("SRR Serra do Sol Service: " + ex.Message);
            }

        }
        






        static void TESTE()
        {
            try
            {
                Pag_Net.Models.SPC5000TbDocumentosFiscais x = new SPC5000TbDocumentosFiscais();

                foreach (PropertyInfo Columns in x.GetType().GetProperties())
                {
                    Console.WriteLine(Columns.Name.ToString());

                }


                Type t = typeof(SPC5000TbDocumentosFiscais);

                Console.WriteLine("The {0} type has the following properties: ",
                                  t.Name);

                foreach (var prop in x.GetType().GetProperties())
                {
                    Console.WriteLine("   {0} - {1} {2}", prop.Name,
                        prop.PropertyType.Name, "-");
                    //string.IsNullOrEmpty(prop.GetValue(x, null).ToString()) == true ? "" : "TEST"
                    if (prop.Name.ToUpper() == "VALORPRODUTOS")
                    {
                        PropertyInfo mprop = x.GetType().GetProperty(prop.Name);
                        mprop.SetValue(x, 10.00, null);
                    }
                }

                Console.WriteLine("Valor do campo {0}", x.ValorProdutos.ToString());


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        
        
    }


    public class ServicePag
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

        string __DiaSemanaInicial = "";
        string __DiaSemanaFinal = "";
        string __HoraInicial = "";
        string __HoraFinal = "";
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

        }


        public void onStart()
        {
            _SetEnviroment();

            try
            {

                Console.WriteLine("Consultando Parâmetros no MÓDULO ModelParametros");
                ModelParametros = new Pag_Net.Models.SPR0050ServicesTimes(@CONFIG.Default["ServiceOwner"].ToString().Trim());


                
                if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) _currentWeekday = 1;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Monday) _currentWeekday = 2;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday) _currentWeekday = 3;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday) _currentWeekday = 4;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday) _currentWeekday = 5;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday) _currentWeekday = 6;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday) _currentWeekday = 7;
                Console.WriteLine("Averiguando Current Day: " + _currentWeekday.ToString());


                Console.WriteLine("Gerando LOGS das variáveis");
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
                Console.WriteLine("Logs das variáveis gerados");





                Console.WriteLine("Processando o serviço: " + __SystemId.ToString());
                if (__SystemId == "SER")
                {
                    LogFile.Write(__ServicePagLogName, "-------------------------------------------------------------");
                    LogFile.Write(__ServicePagLogName, "INICIALIZADO O SERVIÇO: " + __SystemId);
                    LogFile.Write(__ServicePagLogName, " * * Preparando o pacote de Conexao");

                    //MyConnect = Pag_Net.Bll.PagConnection.MyConnection(__SystemId, __DataBaseUser, __SystemEnvironment, __SystemNetWork, __DataBaseUserPassWord, __InfoXfilePath);

                    Console.WriteLine("My Connect OPEN...");

                    MyConnect = new modelSistemaUsuario("3", CONFIG_ENV, "elias", "+17jesusbom");
                    MyConnect.PAG_API = __PagAPI;
                    MyConnect.Path_Spool = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Form.exe", "") + @"spool\";

                    Console.WriteLine("BLL_SERVICE Start...");
                    BLL_SERVICE = new _Service(MyConnect, __ServicePagLogName);


                    Console.WriteLine("BLL_SERVICE List Connection");
                    
                    /*
                    foreach (TbSysDatabase i in MyConnect.ListConnections)
                    {
                        LogFile.Write(__ServicePagLogName, " * * Servidor...............:" + i.DataSourceLAN);
                    }*/

                    LogFile.Write(__ServicePagLogName, " * * Status Conexao.........: Ok");
                    LogFile.Write(__ServicePagLogName, " * * Obtendo lista de servicos e horarios");

                    Console.WriteLine("Services Times");
                    BLL_SERVICE.ObterServicosTime();
                    SPR0050ServicesTimes = Pag_Net.Bll.SqlServer.SPR0050ServicesTimes.List(MyConnect, ModelParametros);
                    LogFile.Write(__ServicePagLogName, " * * Numero de Servicos.....: " + BLL_SERVICE.ListaDeServicosTimes.Length.ToString());
                    LogFile.Write(__ServicePagLogName, " * * Servico Windows em Execucao*");
                    Console.WriteLine("Numero de Serviço: " + BLL_SERVICE.ListaDeServicosTimes.Length.ToString());

                    
                    
                    Console.WriteLine("SERVICE PAG FUNCIONANDO");

                }

                /*
                tProc.Elapsed += new ElapsedEventHandler(tProc_Elapsed);
                tProc.Interval = 1000;
                tProc.Enabled = true;
                tProc.Start();
                */

            }
            catch (Exception ex)
            {
                Console.WriteLine("PAGConsole | TESTE SERVICE PAG ERROR: " + ex.Message);
            }

        }

        private void _SetEnviroment()
        {
            try
            {
                Console.WriteLine("Configurando CONFIG_FILE_ENV");
                CONFIG_FILE_ENV = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("PagConsole.exe", "") + @"Configs\ENVS.XML";
                Console.WriteLine("Configurando CONFIG_FILE_ENV: " + CONFIG_FILE_ENV);


                XmlDocument MyXml = new XmlDocument();

                Console.WriteLine("Configurando CONFIG_FILE_ENV | ENV _ Abrindo o XML ENVI");
                MyXml.LoadXml(Pag_Net.Tools.PagToolsFileTxt.open(CONFIG_FILE_ENV));
                XmlNodeList x = MyXml.GetElementsByTagName("ENV");

                CONFIG_ENV = x.Item(0).Attributes["Environment"].Value.ToString();
                Console.WriteLine("Configurando CONFIG_FILE_ENV | CONFIG_ENV _ Verificando o ENV: " + CONFIG_ENV);

                __PagAPI = x.Item(0).Attributes["PAG_API"].Value.ToString();
                Console.WriteLine("Configurando CONFIG_FILE_ENV | CONFIG_ENV _ Verificando o __PagAPI: " + __PagAPI);

                
                __SystemId = @CONFIG.Default["SystemId"].ToString().Trim();
                __SystemEnvironment = @CONFIG.Default["SystemEnvironment"].ToString().Trim();
                __SystemNetWork = @CONFIG.Default["SystemNetWork"].ToString().Trim();
                __ServiceOwner = @CONFIG.Default["ServiceOwner"].ToString().Trim();
                __ServicePagLogPath = @CONFIG.Default["ServicePagLogPath"].ToString();
                __ServicePagLogName = __ServicePagLogPath + @"\" + @CONFIG.Default["ServicePagLogName"].ToString();
                __InfoXfilePath = @CONFIG.Default["InfoXFilePath"].ToString().Trim();
                __DataBaseService = @CONFIG.Default["DataBaseService"].ToString().Trim(); ;
                __DataBaseUser = @CONFIG.Default["DataBaseUser"].ToString().Trim();
                __DataBaseUserPassWord = @CONFIG.Default["DataBaseUserPassWord"].ToString().Trim();
                __PagAPI = @CONFIG.Default["PagAPI"].ToString().Trim(); ;
                __DataBaseName = @CONFIG.Default["DataBaseName"].ToString().Trim(); ;
                __DiaSemanaInicial = @CONFIG.Default["DiaSemanaInicial"].ToString().Trim();
                __DiaSemanaFinal = @CONFIG.Default["DiaSemanaFinal"].ToString().Trim();
                __HoraInicial = @CONFIG.Default["HoraInicial"].ToString().Trim();
                __HoraFinal = @CONFIG.Default["HoraFinal"].ToString().Trim();
                __SystemSRRReprocessamento = @CONFIG.Default["SystemSRRReprocessamento"].ToString().Trim();

                Console.WriteLine("__SystemId " + __SystemId);
                Console.WriteLine("__SystemEnvironment " + __SystemEnvironment);
                Console.WriteLine("__SystemNetWork " + __SystemNetWork);
                Console.WriteLine("__ServiceOwner " + __ServiceOwner);
                Console.WriteLine("__ServicePagLogPath " + __ServicePagLogPath);
                Console.WriteLine("__ServicePagLogName " + __ServicePagLogName);
                Console.WriteLine("__InfoXfilePath " + __InfoXfilePath);
                Console.WriteLine("__DataBaseService " + __DataBaseService);

                Console.WriteLine("__DataBaseUser " + __DataBaseUser);
                Console.WriteLine("__DataBaseUserPassWord " + __DataBaseUserPassWord);
                Console.WriteLine("__PagAPI " + __PagAPI);
                Console.WriteLine("__DataBaseName " + __DataBaseName);
                Console.WriteLine("__DiaSemanaInicial " + __DataBaseName);
                Console.WriteLine("__DiaSemanaFinal " + __DiaSemanaFinal);

                Console.WriteLine("__HoraInicial " + __HoraInicial);
                Console.WriteLine("__HoraFinal " + __HoraFinal);
                Console.WriteLine("__SystemSRRReprocessamento " + __SystemSRRReprocessamento);

            }
            catch (Exception ex)
            {
                LogFile.Write(@"D:\\ERRO_SERVICE.txt", "ERROR \n" + ex.Message.ToString());
            }

        }
    }
}

