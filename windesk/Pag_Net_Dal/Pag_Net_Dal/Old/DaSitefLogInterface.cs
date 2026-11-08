using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Xml;
using System.IO;
using System.Linq;
using Pag_Net.Models;
using Pag_Net.Dal;
using System.Reflection;

namespace Pag_Net.Dal
{
    public class DaSitefLogInterface
    {
        public static Int32 Insert(ModelSysUserInfo _myConnect,  string _interface, string _nomeArquivo)
        {
            SqlCommand _SqlCommandInsert = new SqlCommand("PrSitefLogInterface");
            _SqlCommandInsert.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoProcessamento", "INSERE_ARQUIVO", true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "Interface", _interface , true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "ArquivoProcessado", _nomeArquivo, true, _SqlCommandInsert);


            dalConnectX _dalConnectX = new dalConnectX(_myConnect, DataBaseName.DBAMAINADM, _SqlCommandInsert, IsolationLevel.Unspecified);
            SqlDataReader _sqlDataReader = _dalConnectX.SqlDataReader_Select();
            if (_sqlDataReader.Read())
            {
                return Convert.ToInt32(_sqlDataReader["SeqArquivo"]);
            }
            else
            {
                return 0;
            }


        }
        public static Int32 Insert(ModelSysUserInfo _myConnect, string _interface, string _nomeArquivo, int _seqArquivo, string _Linha)
        {
            SqlCommand _SqlCommandInsert = new SqlCommand("PrSitefLogInterface");
            _SqlCommandInsert.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoProcessamento", "INSERE_LINHA", true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "Interface", _interface, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "ArquivoProcessado", _nomeArquivo, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int , "SeqArquivo", _seqArquivo, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "LinhaArquivo", _Linha, true, _SqlCommandInsert);


            dalConnectX _dalConnectX = new dalConnectX(_myConnect, DataBaseName.DBAMAINADM, _SqlCommandInsert, IsolationLevel.Unspecified);
            SqlDataReader _sqlDataReader = _dalConnectX.SqlDataReader_Select();
            int _seqlinha = 0;
            if (_sqlDataReader.Read())
            {
                _seqlinha =  Convert.ToInt32(_sqlDataReader["SeqLinha"]);
            }
            else
            {
                _seqlinha =  0;
            }
            _sqlDataReader.Close();
            _dalConnectX.Close();
            return _seqlinha;

        }

    }

}
