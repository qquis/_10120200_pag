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
    public static class DaOperacaoSac
    {
        public static TbOperacoesSac Insert(modelSistemaUsuario MyConnect, TbOperacoesSac TbOperacaoSac)
        {
            Int32 _IdentityInsert = 0;
            if (TbOperacaoSac.Status == StatusRegistro.Inserted)
            {
                SqlCommand _SqlCommandInsert = new SqlCommand("properacaosac");
                _SqlCommandInsert.CommandType = CommandType.StoredProcedure;


                int? _cdpessoa = null;
                if (TbOperacaoSac.TbPessoa != null)
                {
                    _cdpessoa = TbOperacaoSac.TbPessoa.CdPessoa;
                }

                /* INSERINDO OPERACAO SAC *****************************************************************************************************************/
                dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "tipoprocessamento", "INSERT_OPERACAO", true, _SqlCommandInsert);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "TipoOperacaoSac", TbOperacaoSac.TipoOperacaoSac, true, _SqlCommandInsert);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdPessoaCliente", _cdpessoa, true, _SqlCommandInsert);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "Ecf", TbOperacaoSac.TbCupomFiscal.Ecf, true, _SqlCommandInsert);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CupomFiscal", TbOperacaoSac.TbCupomFiscal.Cupom, true, _SqlCommandInsert);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "ValorOperacao", TbOperacaoSac.ValorOperacao, true, _SqlCommandInsert);
                dalConnectX _SqldalConnectXInsert = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommandInsert, IsolationLevel.Unspecified);
                SqlDataReader _SqlDataReader = _SqldalConnectXInsert.SqlDataReader_Select();
                _SqlDataReader.Read();
                _IdentityInsert = Convert.ToInt32(_SqlDataReader["SEQOPERACAOSAC"].ToString());
                TbOperacaoSac.Status = StatusRegistro.Null;
                TbOperacaoSac.SeqOperacaoSac = _IdentityInsert;
                /* INSERINDO ITENS DA OPERAÇÃO************************************************************************************************************/




                if (TbOperacaoSac.TipoOperacaoSac == TbOperacoesSac.TiposOperacaoSac.Devolucao)
                {
                    int _intCupomFiscal = TbOperacaoSac.TbCupomFiscal.Cupom;
                    int _intEcf = TbOperacaoSac.TbCupomFiscal.Ecf;

                    foreach (TbCuponsItens i in TbOperacaoSac.TbCupomFiscalItens)
                    {
                        if (i.Devolucao)
                        {
                            SqlCommand _SqlCommandx = new SqlCommand("properacaosac");
                            _SqlCommandx.CommandType = CommandType.StoredProcedure;
                            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "tipoprocessamento", "INSERT_OPERACAO_CUPOM_FISCAL", true, _SqlCommandx);
                            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdProduto", i.CdProduto, true, _SqlCommandx);
                            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "ValorUnitario", i.Valor, true, _SqlCommandx);
                            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "Qtde", i.Qtde, true, _SqlCommandx);
                            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "QtdeDevolvida", i.QtdeDevolvida, true, _SqlCommandx);
                            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "CodigoBarra", i.CodigoBarra, true, _SqlCommandx);
                            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "SeqOperacaoSac", _IdentityInsert, true, _SqlCommandx);
                            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "Embalagem", i.Embalagem, true, _SqlCommandx);
                            Dal.dalConnectX _dalConnectX2 = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommandx, IsolationLevel.Unspecified);
                            _dalConnectX2.SqlExecuteCommandClosed();
                        }
                    }
                }
                SqlCommand _SqlCommandEfetiva = new SqlCommand("properacaosac");
                _SqlCommandEfetiva.CommandType = CommandType.StoredProcedure;
                dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "tipoprocessamento", "INSERT_OPERACAO_EFETIVA", true, _SqlCommandEfetiva);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "SeqOperacaoSac", _IdentityInsert, true, _SqlCommandEfetiva);
                Dal.dalConnectX _dalConnectEfetiva = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommandEfetiva, IsolationLevel.Unspecified);
                _dalConnectEfetiva.SqlExecuteCommandClosed();

                TbOperacaoSac.Status = StatusRegistro.Inserted;
            }
            return TbOperacaoSac;
        }
        public static TbOperacoesSac[] Select(modelSistemaUsuario MyConnect, int? Ecf, int? CupomFiscal, DateTime? _dataOperacaoSacIni, DateTime? _dataOperacaoSacFim, int? _cdoperador, int? tipooperacao)
        {
            SqlCommand _SqlCommandInsert = new SqlCommand("properacaosac");
            _SqlCommandInsert.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoProcessamento", "SELECT", true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "Ecf", Ecf, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CupomFiscal", CupomFiscal, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "DataOperacaoSacIni", _dataOperacaoSacIni, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "DataOperacaoSacFim", _dataOperacaoSacFim, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdOperador", _cdoperador, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "TipoOperacaoSac", tipooperacao, true, _SqlCommandInsert);
            dalConnectX _SqldalConnectXInsert = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommandInsert, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _SqldalConnectXInsert.SqlDataReader_Select();
            List<TbOperacoesSac> _list = new List<TbOperacoesSac>();
            while (_SqlDataReader.Read())
            {
                TbOperacoesSac X = new TbOperacoesSac();
                X.SeqOperacaoSac = Convert.ToInt32(_SqlDataReader["SeqOperacaoSac"]);
                X.Nfe = Convert.ToInt32(_SqlDataReader["Nfe"]);
                X.NfeStatus = Convert.ToBoolean(_SqlDataReader["NfeStatus"]);
                X.NumeroPedidoErpMoinho = Convert.ToInt32(_SqlDataReader["NfeNumeroPedido"]);
                X.DataLancamento = Convert.ToDateTime(_SqlDataReader["DataLancamento"]);
                X.TbCupomFiscal = new TbCupons(Convert.ToDateTime("2013-01-01"), Convert.ToInt32(_SqlDataReader["CdOperador"]), _SqlDataReader["NomeOperador"].ToString(), Convert.ToInt32(_SqlDataReader["ECF"]), Convert.ToInt32(_SqlDataReader["CupomFiscal"]), 0);
                X.ValorOperacao = Convert.ToDouble(_SqlDataReader["ValorOperacao"]);
                if (_SqlDataReader["TipoOperacaoSAC"].ToString() == "19") X.TipoOperacaoSac = TbOperacoesSac.TiposOperacaoSac.Devolucao;
                if (_SqlDataReader["TipoOperacaoSAC"].ToString() == "20") X.TipoOperacaoSac = TbOperacoesSac.TiposOperacaoSac.DevolucaoDinheiro;
                if (_SqlDataReader["TipoOperacaoSAC"].ToString() == "21") X.TipoOperacaoSac = TbOperacoesSac.TiposOperacaoSac.EmiteNfe;
                if (_SqlDataReader["TipoOperacaoSAC"].ToString() == "23") X.TipoOperacaoSac = TbOperacoesSac.TiposOperacaoSac.PagamentoPos;

                _list.Add(X);
            }
            return _list.ToArray();
        }

        public static TbItem[] SelectDevolucoes(modelSistemaUsuario MyConnect, int? Ecf, int? CupomFiscal, DateTime? _dataOperacaoSacIni, DateTime? _dataOperacaoSacFim, int? _cdoperador, int? tipooperacao)
        {
            SqlCommand _SqlCommandInsert = new SqlCommand("properacaosac");
            _SqlCommandInsert.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoProcessamento", "SELECT_DEVOLUCAO", true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "Ecf", Ecf, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CupomFiscal", CupomFiscal, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "DataOperacaoSacIni", _dataOperacaoSacIni, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "DataOperacaoSacFim", _dataOperacaoSacFim, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdOperador", _cdoperador, true, _SqlCommandInsert);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "TipoOperacaoSac", tipooperacao, true, _SqlCommandInsert);
            dalConnectX _SqldalConnectXInsert = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommandInsert, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _SqldalConnectXInsert.SqlDataReader_Select();
            List<TbItem> _list = new List<TbItem>();
            while (_SqlDataReader.Read())
            {
                TbItem X = new TbItem();
                X.CdProduto = Convert.ToInt32(_SqlDataReader["CdProduto"]);
                X.DescricaoProduto = _SqlDataReader["Descricao"].ToString();
                X.Qtde = Convert.ToDouble(_SqlDataReader["Qtde"]);
                X.ValorTotal = Convert.ToDouble(_SqlDataReader["ValorTotal"]);
                X.Embalagem = _SqlDataReader["Embalagem"].ToString();
                _list.Add(X);
            }
            return _list.ToArray();
        }



    }
}
