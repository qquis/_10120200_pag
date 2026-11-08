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
    public class DaErpZanthusLogProdutoPreco
    {
        private ModelSysUserInfo MyConnect;
        public DaErpZanthusLogProdutoPreco(ModelSysUserInfo myconnect)
        {

            MyConnect = myconnect;
        }
        public ModelTbErpZanthusLogProdutoPreco[] GetList
                        (int? _intSeqLogTransacao,
                          int? _intCodigoProduto,
                          String _stringDescricaoProduto,
                          int? _intSeqTipoLogTransacao,
                          DateTime? _datetimeDtTransacaoInicial,
                          DateTime? _datetimeDtTransacaoFinal,
                          String _stringCodigoBarra
                        )
        {
            SqlParameter _SqlParameterSeqLogTransacao = dalUtil.SqlParameterCreator(SqlDbType.Int, "Seq", _intSeqLogTransacao, true);
            SqlParameter _SqlParameterCdProduto = dalUtil.SqlParameterCreator(SqlDbType.Int, "cd_prod", _intCodigoProduto, true);
            SqlParameter _SqlParameterDescricao = dalUtil.SqlParameterCreator(SqlDbType.VarChar, "descricao", _stringDescricaoProduto, true);
            SqlParameter _SqlParameterDtTransacaoInicial = dalUtil.SqlParameterCreator(SqlDbType.SmallDateTime, "dttransacaoInicial", _datetimeDtTransacaoInicial, true);
            SqlParameter _SqlParameterDtTransacaoFinal = dalUtil.SqlParameterCreator(SqlDbType.SmallDateTime, "dttransacaoFinal", _datetimeDtTransacaoFinal, true);
            SqlParameter _SqlParameterCodigoBarra = dalUtil.SqlParameterCreator(SqlDbType.VarChar, "codigobarra", _stringCodigoBarra, true);
            SqlParameter _SqlParameterSeqTipoAlteracao = dalUtil.SqlParameterCreator(SqlDbType.Int, "SeqTipo", _intSeqTipoLogTransacao, true);

            SqlCommand _SqlCommand = new SqlCommand("prLogProdutoPreco");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            _SqlCommand.Parameters.Add(_SqlParameterSeqLogTransacao);
            _SqlCommand.Parameters.Add(_SqlParameterCdProduto);
            _SqlCommand.Parameters.Add(_SqlParameterDescricao);
            _SqlCommand.Parameters.Add(_SqlParameterDtTransacaoInicial);
            _SqlCommand.Parameters.Add(_SqlParameterDtTransacaoFinal);
            _SqlCommand.Parameters.Add(_SqlParameterCodigoBarra);
            _SqlCommand.Parameters.Add(_SqlParameterSeqTipoAlteracao);

            dalConnectX _dalConnectX = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<ModelTbErpZanthusLogProdutoPreco> _list = new List<ModelTbErpZanthusLogProdutoPreco>();

            while (_SqlDataReader.Read())
            {
                ModelTbErpZanthusLogProdutoPreco ItemTbErpZanthuslogProdutoPreco = new ModelTbErpZanthusLogProdutoPreco(
                    Convert.ToInt32(_SqlDataReader["seqlogtransacao"]),
                    Convert.ToDateTime(_SqlDataReader["data"].ToString()),
                    Convert.ToInt32(_SqlDataReader["codigoproduto"].ToString()),
                    Convert.ToString(_SqlDataReader["descricaoproduto"].ToString()),
                    Convert.ToString(_SqlDataReader["unidadevenda"].ToString()),
                    Convert.ToDouble(_SqlDataReader["PrecoAplicado"].ToString()),
                    Convert.ToDouble(_SqlDataReader["PrecoAnterior"].ToString()),
                    Convert.ToString(_SqlDataReader["DescricaoTipoAlteracao"].ToString()),
                    Convert.ToString(_SqlDataReader["CodigoBarra"].ToString()));
                _list.Add(ItemTbErpZanthuslogProdutoPreco);
            }
            _SqlDataReader.Close();
            return _list.ToArray();

        }
    }
}
