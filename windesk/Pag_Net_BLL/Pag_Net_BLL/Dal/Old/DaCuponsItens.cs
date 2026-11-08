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
    public static class DaCuponsItens
    {
        public static TbCuponsItens[] GetList(modelSistemaUsuario myconnect, int _ECF, int _CupomFiscal, DateTime _data)
        {

            try
            {
                SqlCommand _SqlCommand = new SqlCommand("PrCuponsItens");
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "ecf", _ECF, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "cupom", _CupomFiscal, true, _SqlCommand);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Date, "Data", _data, true, _SqlCommand);


                dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
                SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();
                List<TbCuponsItens> _list = new List<TbCuponsItens>();
                while (_SqlDataReader.Read())
                {
                    TbCuponsItens x = new TbCuponsItens(Convert.ToInt32(_SqlDataReader["cdproduto"].ToString()),
                                                        _SqlDataReader["descricaoproduto"].ToString(),
                                                        _SqlDataReader["codigobarra"].ToString(),
                                                        _SqlDataReader["Embalagem"].ToString(),
                                                        Convert.ToDecimal(_SqlDataReader["qtde"].ToString()),
                                                        Convert.ToDecimal(_SqlDataReader["Valor"].ToString()),
                                                        Convert.ToDecimal(_SqlDataReader["desconto"].ToString()),
                                                        Convert.ToDecimal(_SqlDataReader["valortotal"].ToString()));
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
