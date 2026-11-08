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
using Pag_Net.Models.ModeloBase;
using Pag_Net.Dal;
using System.Reflection;

namespace Pag_Net.Dal
{
    public class DaNotasFiscaisItem
    {
        public static TbNotasFiscaisItem[] Select(modelSistemaUsuario _myConnect,
                                                DateTime _datetimeDataInicial,
                                                DateTime _datetimeDataFinal,
                                                int _intNumeroNotaFiscal,
                                                int _intCodigoFornecedor

            )
        {
            try
            {
                SqlCommand _SqlCommandSelect = new SqlCommand("prNotasFiscaisItem");
                dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoProcessamento", "SELECT_FISCAL_ENTRADA_ITENS", true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "DataRecebimentoIni", _datetimeDataInicial, true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "DataRecebimentoFim", _datetimeDataFinal, true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CodigoFornecedor", _intCodigoFornecedor, true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "NumeroNotaFiscal", _intNumeroNotaFiscal, true, _SqlCommandSelect);


                _SqlCommandSelect.CommandType = CommandType.StoredProcedure;
                dalConnectX _dalConnectX = new dalConnectX(_myConnect, DataBaseName.DBAMAINERP, _SqlCommandSelect, IsolationLevel.Unspecified);
                SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();
                List<TbNotasFiscaisItem> _list = new List<TbNotasFiscaisItem>();
                while (_SqlDataReader.Read())
                {
                    TbNotasFiscaisItem objNotaFiscalItem = new TbNotasFiscaisItem();
                    objNotaFiscalItem.NumeroNotaFiscal = Convert.ToInt32(_SqlDataReader["NotaFiscal"].ToString());
                    objNotaFiscalItem.DataRecebimento = Convert.ToDateTime(_SqlDataReader["DataRecebimento"].ToString());
                    objNotaFiscalItem.CdProduto = Convert.ToInt32(_SqlDataReader["CdProduto"].ToString());
                    objNotaFiscalItem.Descricao = _SqlDataReader["Descricao"].ToString();
                    objNotaFiscalItem.EmbalagemEstoque = _SqlDataReader["EmbalagemEstoque"].ToString();
                    objNotaFiscalItem.QtdeEmbalagemEstoque = Convert.ToDouble(_SqlDataReader["QtdeEmbalagemEstoque"].ToString());
                    objNotaFiscalItem.EmbalagemNotaFiscal = _SqlDataReader["EmbalagemNotaFiscal"].ToString();
                    objNotaFiscalItem.QtdeNotaFiscal = Convert.ToDouble(_SqlDataReader["QtdeEmbalagemNotaFiscal"].ToString());
                    objNotaFiscalItem.EmbalagemCompraFator = Convert.ToDouble( _SqlDataReader["FatorCompra"].ToString());
                    objNotaFiscalItem.EmbalagemCompra = _SqlDataReader["EmbalagemCompraProduto"].ToString();
                    objNotaFiscalItem.ValorUnitario = Convert.ToDouble( _SqlDataReader["ValorItem"].ToString());
                    objNotaFiscalItem.ValorTotal = Convert.ToDouble( _SqlDataReader["ValorTotal"].ToString());



                    _list.Add(objNotaFiscalItem);

                }
                return _list.ToArray();
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Dal.DaNotasFiscais: " + ex.Message.ToString());
            }
        }

    }

}
