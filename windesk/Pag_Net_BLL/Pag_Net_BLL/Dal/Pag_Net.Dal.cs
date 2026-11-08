using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace Pag_Net.Dal
{
    public enum DataBaseName
    {
        DBAMAINADM = 0,
        DBAMAINERP = 1,
        DATABASE_AUT = 2,
        DATABASE_OPE = 3,
        DATABASE_MIN = 4,
        DATABASE_MAN = 5,
        DATABASE_ERP = 6,
        DATABASE_MOV = 7,
        DATABASE_ADM = 8,
        ODBCBI32 = 9,
        ODBCOXAN = 10,
        SqlServer_SerraDOSol = 11
    };
    public enum DataTypeExecute
    {
        DbUpdate = 0,
        DbInsert = 1,
        DbDelete = 2,
        DbDeleteAll = 3,
    }


    public class dalConfig
    {
        public TbSysDatabase AuthenticateConnection(string MyEnviroment, string strFileXml)
        {
            XmlDocument MyXml = new XmlDocument();
            MyXml.LoadXml(strFileXml);
            XmlNodeList x = MyXml.GetElementsByTagName("SERVER");
            List<TbSysDatabase> DataBasesList = new List<TbSysDatabase>();
            foreach (XmlNode attr in x)
            {
                DataBasesList.Add(new TbSysDatabase(
                    attr.Attributes["Id"].Value.ToString(),
                    attr.Attributes["Environment"].Value.ToString(),
                    attr.Attributes["TimeConnection"].Value.ToString(),
                    attr.Attributes["TimeCommand"].Value.ToString(),
                    attr.Attributes["DataSourceLAN"].Value.ToString(),
                    attr.Attributes["DataSourceWAN"].Value.ToString(),
                    attr.Attributes["LanPort"].Value.ToString(),
                    attr.Attributes["WanPort"].Value.ToString(),
                    attr.Attributes["DataBase"].Value.ToString(),
                    attr.Attributes["UsrDataBase"].Value.ToString(),
                    attr.Attributes["PwdDataBase"].Value.ToString(),
                    attr.Attributes["ref"].Value.ToString()));
            }
            var objListConnection_Query = from b in DataBasesList
                                          where b.Environment.Equals(MyEnviroment)
                                          select b;

            TbSysDatabase objListConnection = objListConnection_Query.FirstOrDefault();
            return objListConnection;
        }
        public static TbSysDatabase GetConnection(modelSistemaUsuario myConnect, DataBaseName dataBaseSel)
        {

            string strdatabaseselected;
            switch (dataBaseSel)
            {
                case DataBaseName.DATABASE_AUT:
                    strdatabaseselected = "DATABASE_AUT";
                    break;
                case DataBaseName.DATABASE_MIN:
                    strdatabaseselected = "DATABASE_MIN";
                    break;
                case DataBaseName.DATABASE_OPE:
                    strdatabaseselected = "DATABASE_OPE";
                    break;
                case DataBaseName.DATABASE_ERP:
                    strdatabaseselected = "DATABASE_ERP";
                    break;
                case DataBaseName.DATABASE_MOV:
                    strdatabaseselected = "DATABASE_MOV";
                    break;
                case DataBaseName.DATABASE_ADM:
                    strdatabaseselected = "DATABASE_ADM";
                    break;
                case DataBaseName.DBAMAINADM:
                    strdatabaseselected = "DBAMAINADM";
                    break;
                case DataBaseName.DBAMAINERP:
                    strdatabaseselected = "DBAMAINERP";
                    break;
                default:
                    strdatabaseselected = "DATABASE_AUT";
                    break;
            }
            var objListConnection_Query = from b in myConnect.ListConnections
                                          where b.Referencia.Equals(strdatabaseselected)
                                          select b;

            return objListConnection_Query.FirstOrDefault();


        }
    }
    public class dalConnectX
    {
        /* Public Var */
        public modelSistemaUsuario MyConnection { get; set; }
        public DataBaseName DataBaseSel { get; set; }
        public SqlCommand SqlCommandExecute { get; set; }
        public Int32 intTimeCommand { get; set; }

        /* Private Var */
        private string GetStringConnection()
        {
            string _StringConnection,
                   _DataSource,
                   _DataBase,
                   _UserId,
                   _TimeOutConnection;


            TbSysDatabase mSystemDataBase = dalConfig.GetConnection(MyConnection, DataBaseSel); //objListConnection_Query.FirstOrDefault();

            _DataBase = mSystemDataBase.DataBase.ToString();
            _DataSource = "";

            intTimeCommand = Convert.ToInt32(mSystemDataBase.TimeCommand);


            if (MyConnection.NetWork == "LAN" && mSystemDataBase.DataSourceLAN != "")
            {
                _DataSource = mSystemDataBase.DataSourceLAN.ToString();
            }
            if (MyConnection.NetWork == "WAN" && mSystemDataBase.DataSourceWAN != "")
            {
                _DataSource = mSystemDataBase.DataSourceWAN.ToString();
            }

            if (MyConnection.NetWork == "LAN" && mSystemDataBase.LanPort != "0")
                _DataSource += "," + mSystemDataBase.LanPort.ToString();

            if (MyConnection.NetWork == "WAN" && mSystemDataBase.WanPort != "0")
                _DataSource += "," + mSystemDataBase.WanPort.ToString();

            _TimeOutConnection = mSystemDataBase.TimeConnection.ToString();

            _UserId = mSystemDataBase.UsrDataBase.ToString();

            string _PassWord = _PassWord = mSystemDataBase.PwdDataBase.ToString();

            _StringConnection = "Data Source = " + _DataSource.ToString() + ";" +
                                "Initial Catalog = " + _DataBase + ";" +
                                "User Id= " + _UserId + ";" +
                                "PassWord= " + _PassWord + ";" +
                                "Connection Timeout= 100";
            return _StringConnection;
        }
        private SqlConnection SqlConnectionX;
        //private IsolationLevel SqlIsolationlevelX;
        //private SqlTransaction SqlTransactionX;
        public dalConnectX(
                            modelSistemaUsuario myConnection,
                            DataBaseName dataBaseSel,
                            SqlCommand sqlCommand,
                            IsolationLevel typeIsolationLevel
            )
        {
            MyConnection = myConnection;
            DataBaseSel = dataBaseSel;
            SqlCommandExecute = sqlCommand;

            SqlConnection sqlconnetionx = new SqlConnection(GetStringConnection());
            SqlConnectionX = sqlconnetionx;


            sqlconnetionx.Open();

            SqlCommandExecute.Connection = SqlConnectionX;
            SqlCommandExecute.CommandTimeout = 320; //intTimeCommand;


            //if (typeIsolationLevel != null)
            //{
            //    SqlIsolationlevelX = typeIsolationLevel;
            //    SqlTransactionX = SqlConnectionX.BeginTransaction(SqlIsolationlevelX, "PagConnectionTransaction");
            //
            //}


        }



        /* Get Var */
        public SqlDataReader SqlDataReader_Select()
        {
            try
            {
                //SqlCommandExecute.Connection = SqlConnectionX;
                //SqlCommandExecute.CommandTimeout = intTimeCommand;
                //SqlCommandExecute.Transaction = SqlTransactionX;
                SqlDataReader sqldtReader;
                sqldtReader = SqlCommandExecute.ExecuteReader(CommandBehavior.CloseConnection);
                return sqldtReader;
            }
            catch (Exception ex)
            {
                throw new Exception("Class SqlDataReader_Select" + ex.Message.ToString());
            }

        }
        public DataSet DataSet_Select()
        {
            try
            {
                //SqlCommandExecute.Connection = SqlConnectionX;
                //SqlCommandExecute.CommandTimeout = intTimeCommand;
                //SqlCommandExecute.Transaction = SqlTransactionX;
                SqlDataAdapter sqldtAdapter = new SqlDataAdapter(SqlCommandExecute);
                DataSet dtsetresult = new DataSet();
                sqldtAdapter.Fill(dtsetresult);
                return dtsetresult;
            }
            catch (Exception ex)
            {
                throw new Exception("Class DataSet" + ex.Message.ToString());
            }
        }
        public int SqlExecuteCommandClosed()
        {
            //SqlCommandExecute.Connection = SqlConnectionX;
            //SqlCommandExecute.CommandTimeout = intTimeCommand;
            int RecordAffected = SqlCommandExecute.ExecuteNonQuery();
            Close();
            return RecordAffected;
        }
        public void Close()
        {
            //if (SqlIsolationlevelX != IsolationLevel.Unspecified)
            //{
            //   SqlTransactionX.Commit();
            // }
            if (SqlConnectionX.State != ConnectionState.Closed) SqlConnectionX.Close();
            //SqlTransactionX.Dispose();
            SqlConnectionX.Dispose();
        }
    }

    public class DbUpdate : IDisposable
    {
        private int _TimeCommand;
        private SqlConnection _SqlConnection;
        private OdbcConnection _ODBCConnection;

        private OdbcTransaction _OdbcTransaction;
        private SqlTransaction _SqlTransaction;

        public DbUpdate(modelSistemaUsuario myConnection, DataBaseName dataBaseSel)
        {

            if (dataBaseSel == DataBaseName.ODBCBI32 || dataBaseSel == DataBaseName.ODBCOXAN)
            {

                _ODBCConnection = new OdbcConnection(StringConnection.ODBCConnectionGet(myConnection, dataBaseSel));
                _ODBCConnection.ConnectionTimeout = 20;
                _ODBCConnection.Open();
            }

            else
            {
                _SqlConnection = new SqlConnection(StringConnection.SQLServerConnectionGET(myConnection, dataBaseSel));
                _TimeCommand = TimeOutConnection.Get(myConnection, dataBaseSel);
                _SqlConnection.Open();
            }
        }


        public void Begin()
        {
            Begin(DataBaseName.DBAMAINADM);
        }
        public void Begin(DataBaseName dataBaseSel)
        {


            if (dataBaseSel == DataBaseName.ODBCBI32 || dataBaseSel == DataBaseName.ODBCOXAN)
            {
                _OdbcTransaction = _ODBCConnection.BeginTransaction(IsolationLevel.ReadCommitted);
            }

            else
            {
                _SqlTransaction = this._SqlConnection.BeginTransaction(IsolationLevel.ReadCommitted, this._SqlConnection.WorkstationId + "T");
            }




        }
        public int Execute(string sqlcommand, ParameterQuey[] listParameters)
        {
            return Execute(sqlcommand, listParameters, DataBaseName.DBAMAINADM);
        }
        public int Execute(string sqlcommand, ParameterQuey[] listParameters, DataBaseName dataBaseSel)
        {
            return Execute(sqlcommand, listParameters, dataBaseSel, false);
        }
        public int Execute(string sqlcommand, ParameterQuey[] listParameters, DataBaseName dataBaseSel, bool NotSqlServerTypeSP)
        {
            int intRegistrosAfetados = 0;

            string msg_error_screen;
            if (sqlcommand.Length > 120)
                msg_error_screen = "string command: " + sqlcommand.Substring(0, 115);
            else
                msg_error_screen = "string command: " + sqlcommand;


            string msg_error_file = "Erro no script abaixo \n" + sqlcommand;

            try
            {
                if (dataBaseSel == DataBaseName.ODBCBI32 || dataBaseSel == DataBaseName.ODBCOXAN)
                {
                    OdbcCommand command = new OdbcCommand();
                    command.CommandTimeout = 3200;
                    command.Connection = _ODBCConnection;
                    command.Transaction = _OdbcTransaction;
                    command.CommandText = sqlcommand;
                    command.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand sqlCommandExecute = new SqlCommand(sqlcommand, _SqlConnection, _SqlTransaction);
                    sqlCommandExecute.CommandTimeout = 600; //_TimeCommand; 16/04/2022
                    if (NotSqlServerTypeSP)
                    {
                        sqlCommandExecute.CommandType = CommandType.Text;

                    }
                    else
                    {
                        sqlCommandExecute.CommandType = CommandType.StoredProcedure;
                    }
                    if (listParameters != null)
                    {
                        foreach (ParameterQuey i in listParameters)
                        {
                            dalUtil.SqlParameterCreatorAdd(i.ParametroTipo, i.ParametroNome, i.Valor, i.ParametroNull, sqlCommandExecute);
                        }
                    }
                    //SqlConnection _connection = new SqlConnection(StringConnection.Get(myConnection, dataBaseSel));
                    //_connection.Open();
                    intRegistrosAfetados = sqlCommandExecute.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Tools.LogFile.Write(new Exception(ex.Message + "\n" + msg_error_file));
                throw new Exception(ex.Message + " | Erro na execução do script: " + msg_error_screen + "\n");

            }

            return intRegistrosAfetados;
        }
        public DataSet ExecuteGetDataset(string sqlcommand, ParameterQuey[] listParameters)
        {
            try
            {
                SqlCommand sqlCommandExecute = new SqlCommand(sqlcommand, _SqlConnection, _SqlTransaction);
                sqlCommandExecute.CommandType = CommandType.StoredProcedure;
                foreach (ParameterQuey i in listParameters)
                {
                    dalUtil.SqlParameterCreatorAdd(i.ParametroTipo, i.ParametroNome, i.Valor, i.ParametroNull, sqlCommandExecute);
                }

                //SqlConnection _connection = new SqlConnection(StringConnection.Get(myConnection, dataBaseSel));
                //_connection.Open();



                SqlDataAdapter sqldtAdapter = new SqlDataAdapter(sqlCommandExecute);
                DataSet DataSetReturn = new DataSet();
                sqldtAdapter.Fill(DataSetReturn);
                return DataSetReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void RollBack()
        {
            RollBack(DataBaseName.DBAMAINADM);
        }
        public void RollBack(DataBaseName dataBaseSel)
        {

            if (dataBaseSel == DataBaseName.ODBCBI32 || dataBaseSel == DataBaseName.ODBCOXAN)
            {
                _OdbcTransaction.Rollback();
            }

            else
            {
                this._SqlTransaction.Rollback();
            }

        }
        public void Commit()
        {
            Commit(DataBaseName.DBAMAINADM);
        }
        public void Commit(DataBaseName dataBaseSel)
        {
            if (dataBaseSel == DataBaseName.ODBCBI32 || dataBaseSel == DataBaseName.ODBCOXAN)
            {
                _OdbcTransaction.Commit();
            }

            else
            {
                this._SqlTransaction.Commit();
            }
        }
        public void Close()
        {
            Close(DataBaseName.DBAMAINADM);
        }
        public void Close(DataBaseName dataBaseSel)
        {
            try
            {
                if (dataBaseSel == DataBaseName.ODBCBI32 || dataBaseSel == DataBaseName.ODBCOXAN)
                {
                    //_OdbcTransaction.Dispose();
                    _ODBCConnection.Close();
                    _ODBCConnection.Dispose();
                }
                else
                {
                    //_SqlTransaction.Dispose();
                    _SqlConnection.Close();
                    _SqlConnection.Dispose();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        ~DbUpdate() { }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
    public static class DbSelect
    {

        public static DataSet GetDataSet(modelSistemaUsuario myConnection, DataBaseName dataBaseSel, string sqlcommand, string ParameterCommandValueString)
        {

            ParameterQuey xp = new ParameterQuey("COMMAND", System.Data.SqlDbType.VarChar, false, ParameterCommandValueString);
            return GetDataSet(myConnection, dataBaseSel, sqlcommand, xp);
        }
        public static DataSet GetDataSet(modelSistemaUsuario myConnection, DataBaseName dataBaseSel, string sqlcommand, ParameterQuey Parameter)
        {

            List<ParameterQuey> lParameters = new List<ParameterQuey>();
            lParameters.Add(Parameter);

            ParameterQuey[] x = lParameters.ToArray();

            return GetDataSet(myConnection, dataBaseSel, sqlcommand, x);
        }
        public static DataSet GetDataSet(modelSistemaUsuario myConnection, DataBaseName dataBaseSel, string sqlcommand, ParameterQuey[] listParameters)
        {
            return GetDataSet(myConnection, dataBaseSel, sqlcommand, listParameters, false);
        }
        public static DataSet GetDataSet(modelSistemaUsuario myConnection, DataBaseName dataBaseSel, string sqlcommand, ParameterQuey[] listParameters, bool NotSqlServerTypeSP)
        {
            try
            {
                DataSet DataSetReturn = new DataSet();
                if (dataBaseSel == DataBaseName.ODBCBI32 || dataBaseSel == DataBaseName.ODBCOXAN)
                {
                    OdbcConnection conn = new OdbcConnection(StringConnection.ODBCConnectionGet(myConnection, dataBaseSel));
                    conn.Open();

                    OdbcCommand cmd = new System.Data.Odbc.OdbcCommand(sqlcommand);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 150;

                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    da.Fill(DataSetReturn);
                    da.Dispose();
                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
                else
                {
                    SqlCommand sqlCommandExecute = new SqlCommand(sqlcommand);
                    if (NotSqlServerTypeSP)
                    {
                        sqlCommandExecute.CommandType = CommandType.Text;

                    }
                    else
                    {
                        sqlCommandExecute.CommandType = CommandType.StoredProcedure;
                    }


                    if (listParameters != null)
                    {
                        foreach (ParameterQuey i in listParameters)
                        {
                            dalUtil.SqlParameterCreatorAdd(i.ParametroTipo, i.ParametroNome, i.Valor, i.ParametroNull, sqlCommandExecute);
                        }
                    }

                    //SqlConnection _connection = new SqlConnection(StringConnection.Get(myConnection, dataBaseSel));
                    //_connection.Open();

                    sqlCommandExecute.Connection = new SqlConnection(StringConnection.SQLServerConnectionGET(myConnection, dataBaseSel));
                    sqlCommandExecute.CommandTimeout = 150; //TimeOutConnection.Get(myConnection, dataBaseSel);

                    SqlDataAdapter sqldtAdapter = new SqlDataAdapter(sqlCommandExecute);
                    sqldtAdapter.Fill(DataSetReturn);

                    sqlCommandExecute.Connection.Close();
                    sqlCommandExecute.Dispose();
                    sqldtAdapter.Dispose();
                }

                return DataSetReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString() + "\n Commando execute: " + sqlcommand);
            }
        }

    }

    public class dalConnect
    {
        private string userId; public string UserId { get { return userId; } set { userId = value; } }
        private string dbServer;
        private string dbTgtMoinho;
        private string dbTgtZanthus;
        public enum dataBase
        {
            Oxan_Sis,
            Oxan_Adm,
            Oxan_Ope,
            Oxan_Est,
            Tgt_Moinho,
            Zanthus_MovDb,
            Zanthus_Manager,


        }
        public string StringConnection(dataBase dataBase_Name)
        {
            dbServer = @"SRVOX";
            dbTgtMoinho = @"SRV_OXAN";
            dbTgtZanthus = @"SRV_ZANTHUS";
            if (UserId == null || UserId == string.Empty || UserId.Length == 0)
            {
                throw new ArgumentNullException();
            }
            string _dataBase_Name = "";
            string _server_Name = "";
            switch (dataBase_Name)
            {
                case dataBase.Oxan_Adm:
                    _dataBase_Name = "OXAN_ADM";
                    _server_Name = dbServer;
                    break;
                case dataBase.Oxan_Est:
                    _dataBase_Name = "OXAN_EST";
                    _server_Name = dbServer;
                    break;
                case dataBase.Oxan_Sis:
                    _dataBase_Name = "OXAN_SIS";
                    _server_Name = dbServer;
                    break;
                case dataBase.Oxan_Ope:
                    _dataBase_Name = "OXAN_OPE";
                    _server_Name = dbServer;
                    break;
                case dataBase.Tgt_Moinho:
                    _dataBase_Name = "MOINHO";
                    _server_Name = dbTgtMoinho;
                    break;
                case dataBase.Zanthus_MovDb:
                    _dataBase_Name = "ZEUSMOVDB";
                    _server_Name = dbTgtZanthus;
                    break;
                case dataBase.Zanthus_Manager:
                    _dataBase_Name = "ZEUSMANAGERWP";
                    _server_Name = dbTgtZanthus;
                    break;
            }
            return "Data Source=" + _server_Name + ";" +
                       "User Id=" + UserId.Trim().ToUpper() + ";" +
                       "PassWord=swprej141722;" +
                       "Initial Catalog=" + _dataBase_Name + ";" +
                       "Connect TimeOut=1500";

        }
        public DataSet dataSet_result(string sqlCommandBLL, dataBase DataBaseName)
        {
            try
            {
                SqlConnection c = new SqlConnection(StringConnection(DataBaseName));
                DataSet d = new DataSet();
                SqlDataAdapter a = new SqlDataAdapter(sqlCommandBLL, c);
                a.Fill(d);
                c.Close();
                return d;
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Elemento NULL DataSete_Result");
            }
            catch (SqlException e)
            {
                throw new Exception("Error Data Base:" + e.Message + " <- Result Command Sql -> ");
            }

        }
    }
    public class dalSqlParameterCreator
    {
        public static SqlParameter Creator(SqlDbType _type,
                                     string _NomeParametro,
                                     object _value,
                                     bool _setnull)
        {
            SqlParameter _sqlParameter = new SqlParameter(_NomeParametro, _type);
            _sqlParameter.IsNullable = _setnull;
            _sqlParameter.Value = _value;
            return _sqlParameter;
        }
    }
    public class dalUtil
    {
        public static SqlParameter SqlParameterCreator(SqlDbType _type,
                              string _NomeParametro,
                              object _value,
                              bool _setnull)
        {
            SqlParameter _sqlParameter = new SqlParameter(_NomeParametro, _type);
            _sqlParameter.IsNullable = _setnull;
            _sqlParameter.Value = _value;
            return _sqlParameter;
        }

        public static void SqlParameterCreatorAdd(SqlDbType _type,
                              string _NomeParametro,
                              object _value,
                              bool _setnull, SqlCommand _mysqlcommand)
        {
            SqlParameter _sqlParameter = new SqlParameter(_NomeParametro, _type);
            _sqlParameter.IsNullable = _setnull;
            _sqlParameter.Value = _value;
            _mysqlcommand.Parameters.Add(_sqlParameter);
        }



    }




    public static class dalfunctions
    {
        public static object DataValue(object value)
        {
            if (value == null)
                return DBNull.Value;
            else
                return value;
        }

    }

    static class TimeOutConnection
    {
        public static int Get(modelSistemaUsuario MyConnection, DataBaseName dataBaseSel)
        {
            return 150;
        }
    }
    static class StringConnection
    {
        public static string SQLServerConnectionGET(modelSistemaUsuario MyConnection, DataBaseName dataBaseSel)
        {
            string stringConnectioDES = "Data Source = 192.168.1.5,1433 ;" +
                        "Initial Catalog = DBAMAIN;" +
                        "User Id= sa;" +
                        "PassWord= moitgt2526;" +
                        "Connection Timeout= 15";

            string stringConnectioPRD = "Data Source = 192.168.1.10,1433 ;" +
                        "Initial Catalog = DBAMAIN;" +
                        "User Id= sa;" +
                        "PassWord= swp141722rej;" +
                        "Connection Timeout= 25";

            if (MyConnection.User_environment == "PRD")
                return stringConnectioPRD;
            else
                return stringConnectioDES;
        }

        public static string ODBCConnectionGet(modelSistemaUsuario MyConnection, DataBaseName dataBaseSel)
        {

            string ODBC_Key = "DSN=BIS32";

            string POSTGRE_ODBC = "PostgreOXAN";
            switch (MyConnection.User_environment)
            {
                case "PRD":
                    POSTGRE_ODBC = "DSN=PostgreOXAN";
                    break;
                case "QUA":
                    POSTGRE_ODBC = "DSN=PostgreOxan_HOMOLOG";
                    break;
                case "HOM":
                    POSTGRE_ODBC = "DSN=PostgreOxan_HOMOLOG";
                    break;
                case "DES":
                    POSTGRE_ODBC = "DSN=PostgreOXAN_DESENVOL";
                    break;
            }

            if (dataBaseSel == DataBaseName.ODBCBI32) ODBC_Key = "DSN=BIS32";
            if (dataBaseSel == DataBaseName.ODBCOXAN) ODBC_Key = POSTGRE_ODBC;

            return ODBC_Key;
        }
    }
}





/** OLD **/
namespace Pag_Net.Dal
{
    public static class PagProcPackagesZanthus
    {
        public static void ProcessaBancoZanthus(modelSistemaUsuario myConnect)
        {
            //SqlParameter _SqlParameterCdUsr = dalUtil.SqlParameterCreator(SqlDbType.Char, "cd_usr", myConnect.User_id.Trim().ToString(), true);


            SqlCommand _SqlCommand = new SqlCommand("SPP0060_ProdutoLojaCarga");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            //_SqlCommand.Parameters.Add(_SqlParameterCdUsr);

            dalConnectX _dalConnectX = new dalConnectX(myConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            _dalConnectX.SqlExecuteCommandClosed();
        }

        public static ModelExportFile[] ProcessaArquivo(modelSistemaUsuario myConnect)
        {
            SqlCommand _SqlCommand = new SqlCommand("SPP0065_ProdutoLojaCargaMGV");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            dalConnectX _dalConnectX = new dalConnectX(myConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _sqlDataReader = _dalConnectX.SqlDataReader_Select();
            List<Models.ModelExportFile> _list = new List<Models.ModelExportFile>();
            while (_sqlDataReader.Read())
            {
                Models.ModelExportFile x = new Models.ModelExportFile(_sqlDataReader["NomeDoArquivo"].ToString(), Convert.ToInt32(_sqlDataReader["SeqLinha"].ToString()), _sqlDataReader["Linha"].ToString());
                _list.Add(x);
            }
            return _list.ToArray();
        }

    }
    public static class PagProcPrecosOperacionais
    {
        public static void Processa(Models.modelSistemaUsuario _myConnect)
        {
            SqlCommand _SqlCommand = new SqlCommand("PrPrecosOperacionais");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalConnectX _dalConnectX = new dalConnectX(_myConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            _dalConnectX.SqlExecuteCommandClosed();
        }
    }
    public class tbMarketingCli_AE : dalConnect, IDisposable
    {
        public tbMarketingCli_AE(string _UserId)
        {
            base.UserId = _UserId;
        }
        public bool Insert(ModelMarketingCli_AE marketingCli_ae)
        {
            /* Tipo de dados Stored Procedure
             	    @TYPE_STEP		CHAR(6)				
	                @NOME			VARCHAR(60)			
	                @FONE_DDD		CHAR(2)				
	                @FONE_NUMERO	VARCHAR(10)		
	                @CEP			CHAR(8)			
	                @SEXO			CHAR(1)				
	                @ESTADO_CIVIL	CHAR(1)				
	                @E_MAIL			VARCHAR(40)			
	                @TIPO_OBS		CHAR(1)				
	                @OBSERVACAO		TEXT	
             * 
             * 
             * 
             * 
             */

            try
            {
                SqlConnection _sqlConnection = new SqlConnection(base.StringConnection(dataBase.Oxan_Est));
                _sqlConnection.Open();
                SqlCommand _sqlCommand = new SqlCommand("sp_marketing_cli_ae", _sqlConnection);
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("type_step", "INSERT");
                _sqlCommand.Parameters.Add(new SqlParameter("NOME", SqlDbType.Char, 60, ParameterDirection.Input, true, 0, 0, "@NOME", DataRowVersion.Current, DBNull.Value));
                _sqlCommand.Parameters.Add(new SqlParameter("FONE_DDD", SqlDbType.Char, 2, ParameterDirection.Input, true, 0, 0, "@FONE_DDD", DataRowVersion.Current, DBNull.Value));
                _sqlCommand.Parameters.Add(new SqlParameter("FONE_NUMERO", SqlDbType.Char, 10, ParameterDirection.Input, true, 0, 0, "@FONE_NUMERPO", DataRowVersion.Current, DBNull.Value));
                _sqlCommand.Parameters.Add(new SqlParameter("CEP", SqlDbType.Char, 8, ParameterDirection.Input, true, 0, 0, "@CEP", DataRowVersion.Current, DBNull.Value));
                _sqlCommand.Parameters.Add(new SqlParameter("SEXO", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "@SEXO", DataRowVersion.Current, DBNull.Value));
                _sqlCommand.Parameters.Add(new SqlParameter("ESTADO_CIVIL", SqlDbType.Char, 10, ParameterDirection.Input, true, 0, 0, "@ESTADO_CIVIL", DataRowVersion.Current, DBNull.Value));
                _sqlCommand.Parameters.Add(new SqlParameter("E_MAIL", SqlDbType.Char, 40, ParameterDirection.Input, true, 0, 0, "@E_MAIL", DataRowVersion.Current, DBNull.Value));
                _sqlCommand.Parameters.Add(new SqlParameter("TIPO_OBS", SqlDbType.Char, 60, ParameterDirection.Input, true, 0, 0, "@TIPO_OBS", DataRowVersion.Current, DBNull.Value));
                _sqlCommand.Parameters.Add(new SqlParameter("OBSERVACAO", SqlDbType.Text, 1000, ParameterDirection.Input, true, 0, 0, "@OBSERVACAO", DataRowVersion.Current, DBNull.Value));

                if (marketingCli_ae.Name != null) _sqlCommand.Parameters["NOME"].Value = marketingCli_ae.Name.ToString();
                if (marketingCli_ae.Fone_code != null) _sqlCommand.Parameters["FONE_DDD"].Value = marketingCli_ae.Fone_code.ToString();
                if (marketingCli_ae.Fone_number != null) _sqlCommand.Parameters["FONE_NUMERO"].Value = marketingCli_ae.Fone_number.ToString();
                if (marketingCli_ae.Zip_code != null) _sqlCommand.Parameters["CEP"].Value = marketingCli_ae.Zip_code.ToString();
                if (marketingCli_ae.StatusMaritalDescription != null) _sqlCommand.Parameters["ESTADO_CIVIL"].Value = marketingCli_ae.StatusMaritalDescription.ToString();
                if (marketingCli_ae.E_mail != null) _sqlCommand.Parameters["E_MAIL"].Value = marketingCli_ae.E_mail.ToString();
                if (marketingCli_ae.RemarkTypeDescription != null) _sqlCommand.Parameters["TIPO_OBS"].Value = marketingCli_ae.RemarkTypeDescription.ToString();
                if (marketingCli_ae.Remark != null) _sqlCommand.Parameters["OBSERVACAO"].Value = marketingCli_ae.Remark.ToString();

                _sqlCommand.ExecuteNonQuery();
                _sqlCommand.Dispose();
                _sqlConnection.Close();
                _sqlConnection.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("NameSpace: PagNetDal Class: dbMarketingCli_Ae/dbConnection: " + ex.Message.ToString());


            }


        }
        ~tbMarketingCli_AE() { }
        public void Dispose() { }
    }
    public class tbSystemInterface : dalConnect, IDisposable
    {
        /*public string UserId {set {base.UserId = value;}}*/
        public tbSystemInterface(string _UserId)
        {
            base.UserId = _UserId.ToString();

        }
        public DataSet ProcessKimberly(ModelEnumTypeProcess _TypeProcess, string _FileName)
        {
            DataSet _FileList = new DataSet();
            string IndicatorType_Process = "L";
            if (_TypeProcess == ModelEnumTypeProcess.Read)
            {
                IndicatorType_Process = "R";
            }
            if (_TypeProcess == ModelEnumTypeProcess.Write)
            {
                IndicatorType_Process = "W";
            }
            SqlCommand _SqlCommand = new SqlCommand("p_oxan_est_3001");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.Parameters.AddWithValue("TIPO_PROCESSAMENTO", IndicatorType_Process.ToString());
            _SqlCommand.Parameters.AddWithValue("NOME_DO_ARQUIVO", _FileName);
            _SqlCommand.Connection = new SqlConnection(StringConnection(dataBase.Oxan_Est));
            if (IndicatorType_Process == "L" || IndicatorType_Process == "R")
            {
                SqlDataAdapter _SqlAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlAdapter.Fill(_FileList);
                _SqlAdapter.Dispose();
                _SqlCommand.Dispose();
                return _FileList;
            }
            if (IndicatorType_Process == "W")
            {
                _SqlCommand.Connection.Open();
                _SqlCommand.ExecuteNonQuery();
                _SqlCommand.Connection.Close();
                _FileList = null;
            }
            return _FileList;
        }
        ~tbSystemInterface() { }
        public void Dispose() { }
    }
}