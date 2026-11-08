using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Pag_Net.Models;

namespace Pag_Net.Dal
{
    /*
    public static class PagProcPackagesZanthus
    {
        public static void ProcessaBancoZanthus(ModelSystemUserInfoConnect myConnect)
        {
            //SqlParameter _SqlParameterCdUsr = dalUtil.SqlParameterCreator(SqlDbType.Char, "cd_usr", myConnect.User_id.Trim().ToString(), true);


            SqlCommand _SqlCommand = new SqlCommand("UspProdutoPrecoAplicacao");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            //_SqlCommand.Parameters.Add(_SqlParameterCdUsr);

            dalConnectX _dalConnectX = new dalConnectX(myConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            _dalConnectX.SqlExecuteCommandClosed();
        }

        public static ModelExportFile[] ProcessaArquivo(ModelSystemUserInfoConnect myConnect)
        {
            SqlCommand _SqlCommand = new SqlCommand("UspProdutoPrecoAplicacaoMgv");
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
        public static void Processa( Models.ModelSystemUserInfoConnect _myConnect)
        {
            SqlCommand _SqlCommand = new SqlCommand("PrPrecosOperacionais");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalConnectX _dalConnectX = new dalConnectX(_myConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            _dalConnectX.SqlExecuteCommandClosed();
        }
    }
     * */
}
