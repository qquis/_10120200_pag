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
    public static class DaNotasFiscais
    {

        public static TbNotasFiscais[] Select(modelSistemaUsuario _myConnect, 
                                                DateTime _datetimeDataInicial,
                                                DateTime _datetimeDataFinal,
                                                int? _CdEmitente,
                                                int? _CdDestinatario,
                                                bool? _CheckSimBonificadas,
                                                bool? _CheckNaoBonificadas,
                                                double? _ValorInicial,
                                                double? _ValorFinal,
                                                string _NumeroNotasFiscais

                                                
           
            )
        {
            try
            {
                SqlCommand _SqlCommandSelect = new SqlCommand("PrNotasFiscais");
                dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoProcessamento", "NOTA_FISCAL_ENTRADA", true, _SqlCommandSelect);

                dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "data_ini", _datetimeDataInicial, true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "data_fim", _datetimeDataFinal, true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdEmitente", _CdEmitente, true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Bit, "CheckSimBonificadas", _CheckSimBonificadas, true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Bit, "CheckNaoBonificadas", _CheckNaoBonificadas, true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "ValorInicial", _ValorInicial, true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "ValorFinal", _ValorFinal, true, _SqlCommandSelect);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "NumerosNotasFiscais", _NumeroNotasFiscais, true, _SqlCommandSelect);



                _SqlCommandSelect.CommandType = CommandType.StoredProcedure;
                dalConnectX _dalConnectX = new dalConnectX(_myConnect, DataBaseName.DBAMAINERP, _SqlCommandSelect, IsolationLevel.Unspecified);
                SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();
                List<TbNotasFiscais> _list = new List<TbNotasFiscais>();
                while (_SqlDataReader.Read())
                {
                    TbNotasFiscais objNotaFiscal = new TbNotasFiscais();
                    objNotaFiscal.NumeroNotaFiscal = Convert.ToInt32(_SqlDataReader["NotaFiscal"].ToString());
                    objNotaFiscal.DataRecebimento = Convert.ToDateTime(_SqlDataReader["DataRecebimento"].ToString());
                    objNotaFiscal.ErpCdFornecedor = Convert.ToInt32(_SqlDataReader["CdFornec"].ToString());
                    objNotaFiscal.RazaoSocialEmissor = _SqlDataReader["RazaoSocialNome"].ToString();
                    objNotaFiscal.NotaFiscalBonificada = _SqlDataReader["Bonificacao"].ToString();
                    objNotaFiscal.ValorNotaFiscal = Convert.ToDouble(_SqlDataReader["Valor"].ToString());
                     

                    _list.Add(objNotaFiscal);

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
