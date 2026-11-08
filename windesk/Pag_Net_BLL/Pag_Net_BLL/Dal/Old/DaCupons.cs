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
    public static class DaCupons
    {
        public static TbCupons[] GetList(modelSistemaUsuario myconnect, DateTime _dtInicial, DateTime _dtFinal,
                                                        double? _VlCupomFiscalIni,
                                                        double? _VlCupomFiscalFim,
                                                        double? _VlCupomPagamentoIni,
                                                        double? _VlCupomPagamentoFim,
                                                        bool? _cancelados,
                                                        int? _CdOperador,
                                                        int? _ECF,
                                                        int? _CupomFiscal)
        {

            try
            {
                SqlCommand _SqlCommand = new SqlCommand("PrCupons");
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "dt_ini", _dtInicial, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "dt_fim", _dtFinal, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Bit, "CuponsCancelados", _cancelados, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "ValorCupomIni", _VlCupomFiscalIni, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "ValorCupomFim", _VlCupomFiscalFim, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "ValorPagamentoIni", _VlCupomPagamentoIni, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "ValorPagamentoFim", _VlCupomPagamentoFim, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CodigoOperador", _CdOperador, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "ECF", _ECF, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CupomFiscal", _CupomFiscal, true, _SqlCommand);
                dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
                SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();
                List<TbCupons> _list = new List<TbCupons>();
                while (_SqlDataReader.Read())
                {
                    TbCupons x = new TbCupons(Convert.ToDateTime(_SqlDataReader["DataCupom"].ToString()),
                                                        Convert.ToInt32(_SqlDataReader["CdOperador"].ToString()),
                                                        _SqlDataReader["NomeOperador"].ToString(),
                                                        Convert.ToInt32(_SqlDataReader["ECF"].ToString()),
                                                        Convert.ToInt32(_SqlDataReader["Cupom"].ToString()),
                                                        Convert.ToDouble(_SqlDataReader["Valor"].ToString()));
                    x.Devolucao = Convert.ToBoolean(_SqlDataReader["devolvido"]);
                    x.Nfe = Convert.ToBoolean(_SqlDataReader["nfe"]);
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
