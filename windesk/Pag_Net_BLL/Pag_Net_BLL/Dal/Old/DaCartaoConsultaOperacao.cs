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
    public class DaCartaoConsultaOperacao
    {
        public enum TipoOperacao
        {
            ConsultaPosicaoFinalizadora,
            ConsultaPosicaoRegistros
        }
                    
        public static TbOperacaoCartaoCredito[] GetList(
                            modelSistemaUsuario myconnect,
                            TipoOperacao _tipoOperacao,
                            DateTime _dataEmissaoInicial, 
                            DateTime _dataEmissaoFinal /*, 
                            DateTime _dataPgtoContaVinculadaInicial,
                            DateTime _dataPgtoContaVinculadaFinal,
                            DateTime _dataPgtoContaCorrenteInicial,
                            DateTime _dataPgtoContaCorrenteFinal*/)

        {
            SqlCommand _SqlCommand = new SqlCommand("prcartaoconsultaoperacao");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            string _parametroTipoOperacao = "SELECT_ITEM";

            if (_tipoOperacao == TipoOperacao.ConsultaPosicaoFinalizadora)
            {
                _parametroTipoOperacao = "SELECT_FINALIZADORA";
            }

            if (_tipoOperacao == TipoOperacao.ConsultaPosicaoRegistros)
            {
                _parametroTipoOperacao = "SELECT_ITEM";
            }

            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoOperacao", _parametroTipoOperacao, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "dataemissaoini", _dataEmissaoInicial, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "dataemissaofim", _dataEmissaoInicial, true, _SqlCommand);


            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbOperacaoCartaoCredito> _list = new List<TbOperacaoCartaoCredito>();

            while (_SqlDataReader.Read())
            {
                TbOperacaoCartaoCredito x = new TbOperacaoCartaoCredito();

                x.DataFaturamento  = Convert.ToDateTime(_SqlDataReader["DataFaturamento"].ToString());
                x.ECF = Convert.ToInt32(_SqlDataReader["ECF"].ToString());
                x.CupomFiscal = Convert.ToInt32(_SqlDataReader["CupomFiscal"].ToString());
                x.DocumentoFiscal = Convert.ToInt32(_SqlDataReader["DocumentoFiscal"].ToString());
                x.Valor = Convert.ToDouble(_SqlDataReader["Valor"].ToString());
                x.ValorSitef = Convert.ToDouble(_SqlDataReader["ValorSitef"].ToString());
                x.StatusErro = Convert.ToBoolean(_SqlDataReader["StatusErro"]);
                x.Finalizadora = _SqlDataReader["Finalizadora"].ToString();
                x.StatusErroDescricao = _SqlDataReader["StatusErroDescricao"].ToString();
                _list.Add(x);

            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
