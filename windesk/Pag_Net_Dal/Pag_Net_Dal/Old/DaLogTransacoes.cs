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
    public class DaLogTransacoes
    {
        private ModelSysUserInfo MyConnect;
        public DaLogTransacoes(ModelSysUserInfo myconnect)
        {
            MyConnect = myconnect;
        }
        public ModelTbLogTransacoes[] GetList
            (int? _intSeqLogTransacao,
              DateTime? _datetimeDtTransacaoInicial,
              DateTime? _datetimeDtTransacaoFinal
            )
        {

            SqlParameter _SqlParameterDateTimeTransacaoInicial = dalUtil.SqlParameterCreator(SqlDbType.SmallDateTime, "dt_ini", _datetimeDtTransacaoInicial, true);
            SqlParameter _SqlParameterDateTimeTransacaoFinal = dalUtil.SqlParameterCreator(SqlDbType.SmallDateTime, "dt_fim", _datetimeDtTransacaoFinal, true);
            SqlCommand _SqlCommand = new SqlCommand("prLogTransacao");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.Parameters.Add(_SqlParameterDateTimeTransacaoFinal);
            _SqlCommand.Parameters.Add(_SqlParameterDateTimeTransacaoInicial);
            dalConnectX _dalConnectX = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _sqlDataReader = _dalConnectX.SqlDataReader_Select();
            List<ModelTbLogTransacoes> _list = new List<ModelTbLogTransacoes>();
            while (_sqlDataReader.Read())
            {
                ModelTbLogTransacoes x = new ModelTbLogTransacoes(Convert.ToInt32(_sqlDataReader["SeqLogTransacao"]), Convert.ToDateTime(_sqlDataReader["Data"]));
                x.ItensProcessados = Convert.ToInt32(_sqlDataReader["ItensProcessados"] == DBNull.Value ? 0 : _sqlDataReader["ItensProcessados"]);
                x.ItensAlterados = Convert.ToInt32(_sqlDataReader["ItensAlterados"] == DBNull.Value ? 0 : _sqlDataReader["ItensAlterados"]);
                x.ItensIncluidos = Convert.ToInt32(_sqlDataReader["ItensIncluidos"] == DBNull.Value ? 0 : _sqlDataReader["ItensIncluidos"]);
                x.ItensExcluidos = Convert.ToInt32(_sqlDataReader["ItensExcluidos"] == DBNull.Value ? 0 : _sqlDataReader["ItensExcluidos"]);
                x.TransacaoObservacao = _sqlDataReader["TransacaoObservacao"].ToString();
                x.TransacaoResultado = Convert.ToBoolean( _sqlDataReader["TransacaoResultado"]);
                x.CdTipo = _sqlDataReader["CdTipo"].ToString();
                x.TransacaoTipo = _sqlDataReader["TipoDescricao"].ToString();


                x.Usuario = _sqlDataReader["Usuario"].ToString();
                _list.Add(x);
            }
            return _list.ToArray();
        }
    }
}
