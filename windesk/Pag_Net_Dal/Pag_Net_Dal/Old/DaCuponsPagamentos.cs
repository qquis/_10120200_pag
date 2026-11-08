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
    public static class DaCuponsPagamentos
    {
        public static TbCuponsPagamentos[] GetList(ModelSysUserInfo myconnect, int _ECF, int _CupomFiscal, DateTime _data)
        {
            int? ecfnull = _ECF;
            int? cupomnull = _CupomFiscal;
            return GetList(myconnect, ecfnull, cupomnull, null, null, _data , _data , null, null, null);
        }
        public static TbCuponsPagamentos[] GetList(ModelSysUserInfo myconnect, int _ECF, int _CupomFiscal, int? _cdFinalizadora)
        {
            int? ecfnull = _ECF;
            int? cupomnull = _CupomFiscal;
            return GetList(myconnect, ecfnull, cupomnull, _cdFinalizadora, null, null, null, null, null, null);
        }

        public static TbCuponsPagamentos[] GetList(ModelSysUserInfo myconnect, int _ECF, int _CupomFiscal, int? _cdFinalizadora, int? _seqZanthusTransacao)
        {
            int? ecfnull = _ECF;
            int? cupomnull = _CupomFiscal;
            return GetList(myconnect, ecfnull, cupomnull, _cdFinalizadora, _seqZanthusTransacao, null, null, null, null, null);
        }

        public static TbCuponsPagamentos[] GetList(ModelSysUserInfo myconnect, int? _ECF, int? _CupomFiscal, int? _cdFinalizadora, int? _seqZanthusTransacao, DateTime? _dataInicial, DateTime? _dataFinal, int? _operador, double? _valorinicial, double? _valorfinal)
        {
            try
            {
                SqlCommand _SqlCommand = new SqlCommand("PrCuponsPagamentos");
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "ecf", _ECF, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "cupom", _CupomFiscal, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdFinalizadora", _cdFinalizadora, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "SeqZanthusTransacao", _seqZanthusTransacao, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Date, "FiltroDataInicial", _dataInicial, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Date, "FiltroDataFinal", _dataFinal, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "FiltroOperador", _operador, true, _SqlCommand);

                dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "FiltroValorInicial", _valorinicial, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "FiltroValorFinal", _valorfinal, true, _SqlCommand);


                dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
                SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();
                List<TbCuponsPagamentos> _list = new List<TbCuponsPagamentos>();
                while (_SqlDataReader.Read())
                {
                    TbCuponsPagamentos x = new TbCuponsPagamentos(Convert.ToInt32(_SqlDataReader["Cdfinalizadora"].ToString()),
                                                        _SqlDataReader["DescricaoFinalizadora"].ToString(),
                                                        Convert.ToDouble(_SqlDataReader["Valor"].ToString()),
                                                        _SqlDataReader["autorizador"].ToString(),
                                                        Convert.ToInt32(_SqlDataReader["SeqProdutoFinanceiro"].ToString()),
                                                        _SqlDataReader["ProdutoFinanceiro"].ToString(),
                                                        _SqlDataReader["DescricaoProdutoFinanceiro"].ToString(),
                                                        _SqlDataReader["EstadoTransacao"].ToString(),
                                                        _SqlDataReader["DocumentoFinanceiro"].ToString(),
                                                        _SqlDataReader["CodigoAutorizacao"].ToString(),
                                                        Convert.ToDouble(_SqlDataReader["ValorTransacao"].ToString()));
                    x.CupomFiscal = Convert.ToInt32(_SqlDataReader["CupomFiscal"]);
                    x.Ecf = Convert.ToInt32(_SqlDataReader["ECF"]);
                    x.SeqZanthusTransacao = Convert.ToInt32(_SqlDataReader["SeqZanthusTransacao"].ToString());
                    x.DataEmissao = Convert.ToDateTime(_SqlDataReader["DataEmissao"].ToString());
                    x.NomeOperador = _SqlDataReader["NomeOperador"].ToString();
                    _list.Add(x);

                }
                _SqlDataReader.Close();
                return _list.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
