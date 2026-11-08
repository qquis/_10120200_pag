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
    public static class DaSitefLog
    {
        public static void Insert(modelSistemaUsuario MyConnect, TbSitefLogs TbSitefLog)
        {
            SqlCommand _SqlCommandInsert = new SqlCommand("PrSitefLog");
            _SqlCommandInsert.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoProcessamento", "INSERT", true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "OrigemLancamento", TbSitefLog.OrigemLancamento, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.SmallDateTime, "DataEmissao", TbSitefLog.DataEmissao, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "Autorizador", TbSitefLog.Autorizador, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "HoraRegistro", TbSitefLog.DataHora, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "CdProdutoFinanceiro", TbSitefLog.CdProdutoFinanceiro, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "EstadoTransacao", TbSitefLog.EstadoTransacao, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "CartaoReferencia", TbSitefLog.CartaoReferencia, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "IdentificacaoPdv", TbSitefLog.IdentificacaoPdv, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "Valor", TbSitefLog.Valor, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "CodigoAutorizacao", TbSitefLog.CodigoAutorizacao, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CodigoEmpresa", TbSitefLog.CodigoEmpresa, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CupomFiscal", TbSitefLog.CupomFiscal, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "ECF", TbSitefLog.Ecf, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "SeqZanthusTransacao", TbSitefLog.SeqZanthusTransacao, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "NumeroCartaoIdentificador", TbSitefLog.NumeroCartaoIdentificador, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "NumeroCartaoIdentificadorDireito", TbSitefLog.NumeroCartaoIdentificadorDireito, true, _SqlCommandInsert);

            dalConnectX _SqldalConnectXInsert = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommandInsert, IsolationLevel.Unspecified);
            _SqldalConnectXInsert.SqlExecuteCommandClosed();
        }
        public static TbSitefLogs[] Select(modelSistemaUsuario _myConnect, DateTime _dtInicio, DateTime _dtFim, Int32? _ecf, Int32? _cupomFiscal, Int32? _cdOperador, double? _valorini, double? _valorfim, string _estadoTransacao, string _cartaoReferencia)
        {
            SqlCommand _SqlCommandInsert = new SqlCommand("PrSitefLog");
            _SqlCommandInsert.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoProcessamento", "SELECT", true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.SmallDateTime, "DataEmissaoIni", _dtInicio, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.SmallDateTime, "DataEmissaoFim", _dtFim, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "Ecf", _ecf, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CupomFiscal", _cupomFiscal, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdOperador", _cdOperador, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "vl_pgto_ini", _valorini, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "vl_pgto_fim", _valorfim, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "EstadoTransacao", _estadoTransacao, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "CartaoReferencia", _cartaoReferencia.Trim(), true, _SqlCommandInsert);


            dalConnectX _dalConnectX = new dalConnectX(_myConnect, DataBaseName.DBAMAINADM, _SqlCommandInsert, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();
            List<TbSitefLogs> _list = new List<TbSitefLogs>();

            while (_SqlDataReader.Read())
            {
                TbSitefLogs i = new TbSitefLogs();
                i.SeqSitefLog = Convert.ToInt32(_SqlDataReader["SeqSitefLog"].ToString());
                i.Autorizador = _SqlDataReader["Autorizador"].ToString();
                i.CartaoReferencia = _SqlDataReader["CartaoReferencia"].ToString();
                i.CdProdutoFinanceiro = _SqlDataReader["CdProdutoFinanceiro"].ToString();
                i.CodigoAutorizacao = _SqlDataReader["CodigoAutorizacao"].ToString();
                i.CodigoEmpresa = Convert.ToInt32(_SqlDataReader["CodigoEmpresa"].ToString());

                i.Ecf = Convert.ToInt32(_SqlDataReader["Ecf"].ToString());
                i.CupomFiscal = Convert.ToInt32(_SqlDataReader["CupomFiscal"].ToString());

                i.DataEmissao = Convert.ToDateTime(_SqlDataReader["DataEmissao"].ToString());
                i.DataHora = Convert.ToDateTime(_SqlDataReader["HoraRegistro"].ToString());
                i.DescricaoProdutoFinanceiro = _SqlDataReader["DescricaoProdutoFinanceiro"].ToString();
                i.EstadoTransacao = _SqlDataReader["EstadoTransacao"].ToString();
                i.Valor = Convert.ToDouble(_SqlDataReader["Valor"].ToString());
                i.OrigemLancamento = _SqlDataReader["OrigemLancamento"].ToString();
                i.LogNSUHost = _SqlDataReader["LogNSUHost"].ToString();
                i.LogTipoTransacao = _SqlDataReader["LogTipoTransacao"].ToString();

                _list.Add(i);
            }
            return _list.ToArray();

        }
    }

}
