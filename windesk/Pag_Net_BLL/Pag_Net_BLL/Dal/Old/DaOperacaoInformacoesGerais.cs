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
    public class DaOperacaoInformacoesGerais
    {
        private modelSistemaUsuario MyConnect;
        public DaOperacaoInformacoesGerais(modelSistemaUsuario myconnect)
        {
            MyConnect = myconnect;
        }
        public TbComercioInformacoesGerais[] GetList(bool _TotalRegistos,
                                                                    string _TipoConsulta,
                                                                    string _TipoVolume,
                                                                    string _TipoData,
                                                                    int? _CdEmpresa,
                                                                    int? _CdOperacao,
                                                                    DateTime _DataInicial,
                                                                    DateTime _DataFinal,
                                                                    int _fCdPessoaEquipeVendas,
                                                                    int _fCdPessoaVendedor,
                                                                    int _fCdPessoaCliente,
                                                                    int _fCdPessoaFabricante,
                                                                    string _fCdAreaVenda,
                                                                    int _fCepInit,
                                                                    int _fCepFim,
                                                                    int _fCdLinha,
                                                                    int _fCdSecao,
                                                                    int _fCdDepartamento,
                                                                    string _fListaCdProduto,
                                                                    string _fNomeCliente,
                                                                    string _fDescricaoProduto,
                                                                    int? _fQtdeIni,
                                                                    int? _fQtdeFim,
                                                                    double? _fVlPrecoAplicadoIni,
                                                                    double? _fVlPrecoAplicadoFim,
                                                                    double? _fVlTotalIni,
                                                                    double? _fVlTotalFim,
                                                                    decimal? _fMargemIniItem,
                                                                    decimal? _fMargemFimItem,
                                                                    decimal? _fMargemIniPesquisa,
                                                                    decimal? _fMargemFimPesquisa)
        {
            SqlCommand _SqlCommand = new SqlCommand("PrComercioInfoGeral");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Bit, "TotalRegistros", _TotalRegistos, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "TipoPesquisa", _TipoConsulta, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "TipoQuantidade", _TipoVolume, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "TipoData", _TipoData, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdEmpresa", _CdEmpresa, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdOperacao", _CdOperacao, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.SmallDateTime, "DataInicial", _DataInicial, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.SmallDateTime, "DataFinal", _DataFinal, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fcdpessoaequipevendas", _fCdPessoaEquipeVendas, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fcdpessoavendedor", _fCdPessoaVendedor, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fcdpessoacliente", _fCdPessoaCliente, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fcdpessoafabricante", _fCdPessoaFabricante, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "fCdAreaVenda", _fCdAreaVenda, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fCepIni", _fCepInit, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fCepFim", _fCepFim, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fCdLinha", _fCdLinha, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fCdSecao", _fCdSecao, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fCdDepartamento", _fCdDepartamento, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "fListaCdProduto", _fListaCdProduto, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "fNomeCliente", _fNomeCliente, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "fDescricaoProduto", _fDescricaoProduto, false, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fQtdeIni", _fQtdeIni, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "fQtdeFim", _fQtdeFim, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "fVlPrecoAplicadoIni", _fVlPrecoAplicadoIni, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "fVlPrecoAplicadoFim", _fVlPrecoAplicadoFim, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "fVlTotalIni", _fVlTotalIni, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "fVlTotalFim", _fVlTotalFim, true, _SqlCommand);

            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "fMargemIniItem", _fMargemIniItem, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "fMargemFimItem", _fMargemFimItem, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "fMargemIniPesquisa", _fMargemIniPesquisa, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "fMargemFimPesquisa", _fMargemFimPesquisa, true, _SqlCommand);




            //(_TipoVolume ? "1" : "0")



            //(_margem_item ? "1" : "0")
            dalConnectX _dalConnectX = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbComercioInformacoesGerais> _list = new List<TbComercioInformacoesGerais>();

            while (_SqlDataReader.Read())
            {
                TbComercioInformacoesGerais x = new TbComercioInformacoesGerais(_SqlDataReader["CODIGO"].ToString(),
                    _SqlDataReader["descricao"].ToString(), Convert.ToInt32(_SqlDataReader["POS"].ToString()),
                    Convert.ToInt32(_SqlDataReader["MIX"].ToString()), Convert.ToDouble(_SqlDataReader["VOluME"].ToString()), Convert.ToDouble(_SqlDataReader["VENDA"].ToString()),
                    Convert.ToDouble(_SqlDataReader["CUSTO"].ToString()),
                    Convert.ToInt32(_SqlDataReader["CLIENTEs"].ToString()), Convert.ToDouble(_SqlDataReader["Margem"].ToString()), Convert.ToDouble(_SqlDataReader["Participacao"].ToString()), "",
                    0, 0, 0);
                _list.Add(x);
            }
            return _list.ToArray();
        }
    }
}
