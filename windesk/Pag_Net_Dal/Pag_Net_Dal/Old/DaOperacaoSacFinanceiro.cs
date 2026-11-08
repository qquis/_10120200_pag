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
    public static class DaOperacaoSacFinanceiro
    {
        public static TbOperacoesSacFinanceiro[] Select(ModelSysUserInfo MyConnect, DateTime _dataOperacao, TbOperacoesSacFinanceiro.TipoInformacao _tipoRelatorio, int? _cdOperador, int? _eCF, int? _cupomFiscal)
        {
            SqlCommand _SqlCommand = new SqlCommand("PrOperacaoSacFinanceiro");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            string _tiporelatorioname = "";

            switch (_tipoRelatorio)
            {
                case TbOperacoesSacFinanceiro.TipoInformacao.DetalheRecebimentos:
                    _tiporelatorioname = "DET_PGTO";
                    break;
                case TbOperacoesSacFinanceiro.TipoInformacao.ResumoRecebimentoFinalizadora:
                    _tiporelatorioname = "RES_FINA";
                    break;
                case TbOperacoesSacFinanceiro.TipoInformacao.ResumoRecebimentoProdutoFinanceiro:
                    _tiporelatorioname = "RES_PROD";
                    break;
                case TbOperacoesSacFinanceiro.TipoInformacao.ResumoRecebimentoAutorizador:
                    _tiporelatorioname = "RES_AUTO";
                    break;
                case TbOperacoesSacFinanceiro.TipoInformacao.ResumoFinalizadoraProdutoFinanceiro:
                    _tiporelatorioname = "RES_FIPR";
                    break;
            }
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoRelatorio", _tiporelatorioname, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.SmallDateTime, "data", _dataOperacao, true, _SqlCommand);

            if (_cdOperador != null) dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdOperador", _cdOperador, true, _SqlCommand);
            if (_eCF != null) dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "Ecf", _eCF, true, _SqlCommand);
            if (_cupomFiscal != null) dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CupomFiscal", _cupomFiscal, true, _SqlCommand);


            dalConnectX _SqldalConnectXInsert = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _SqldalConnectXInsert.SqlDataReader_Select();
            List<TbOperacoesSacFinanceiro> _list = new List<TbOperacoesSacFinanceiro>();
            while (_SqlDataReader.Read())
            {
                TbOperacoesSacFinanceiro _operacaosacfinanceiro = new TbOperacoesSacFinanceiro();
                _operacaosacfinanceiro.Autorizador = _SqlDataReader["Autorizador"].ToString();
                _operacaosacfinanceiro.CartaoReferencia = _SqlDataReader["CartaoReferencia"].ToString();
                _operacaosacfinanceiro.CdOperador = Convert.ToInt32(_SqlDataReader["CdOperador"].ToString());
                _operacaosacfinanceiro.NomeOperador = _SqlDataReader["NomeOperador"].ToString();
                _operacaosacfinanceiro.DataEmissao = Convert.ToDateTime(_SqlDataReader["DataEmissao"].ToString());
                _operacaosacfinanceiro.CupomFiscal = Convert.ToInt32(_SqlDataReader["CupomFiscal"].ToString());
                _operacaosacfinanceiro.Finalizadora = _SqlDataReader["Finalizadora"].ToString();
                _operacaosacfinanceiro.ProdutoFinanceiro = _SqlDataReader["ProdutoFinanceiro"].ToString();
                _operacaosacfinanceiro.Valor = Convert.ToDouble(_SqlDataReader["Valor"].ToString());
                _operacaosacfinanceiro.ValorRecebido = Convert.ToDouble(_SqlDataReader["ValorRecebido"].ToString());
                _operacaosacfinanceiro.ValorDevolvido = Convert.ToDouble(_SqlDataReader["ValorDevolvido"].ToString());
                _operacaosacfinanceiro.ValorCancelado = Convert.ToDouble(_SqlDataReader["ValorCancelado"].ToString());
                _operacaosacfinanceiro.ValorLiquido = Convert.ToDouble(_SqlDataReader["ValorLiquido"].ToString());
                _list.Add(_operacaosacfinanceiro);
            }
            return _list.ToArray();
        }
    }
}
