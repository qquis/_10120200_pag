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
    public class DaPedido
    {
        private modelSistemaUsuario MyConnect;
        private DateTime Dtini;
        private DateTime Dtfim;
        private int? NumeroPedido;
        private int? Codigocliente;
        private string Codigovendedor;
        private string DescricaoFabricante;
        private string NomeCliente;
        public DaPedido(modelSistemaUsuario myconnect, DateTime _dtini, DateTime _dtfim, int? _numeropedido, int? _codigocliente, string _codigovendedor, string _nomecliente, string _DescricaoFabricante)
        {
            MyConnect = myconnect;
            Dtini = _dtini;
            Dtfim = _dtfim;
            NumeroPedido = _numeropedido;
            Codigocliente = _codigocliente;
            Codigovendedor = _codigovendedor;
            NomeCliente = _nomecliente;
            DescricaoFabricante = _DescricaoFabricante;


        }
        public TbPedido[] PedidoGetList()
        {
            SqlCommand _SqlCommand = new SqlCommand("PrInfoPedidoRentabilidade");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "TIPO_CONSULTA", "PD", true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "dt_ini", Dtini, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "dt_fim", Dtfim, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "numeropedido", NumeroPedido, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "codigocliente", Codigocliente, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "codigovendedor", Codigovendedor, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "NomeCliente", NomeCliente, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "DescricaoFabricante", DescricaoFabricante, true, _SqlCommand);

            dalConnectX _dalConnectX = new dalConnectX(MyConnect, DataBaseName.DBAMAINERP, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbPedido> _list = new List<TbPedido>();



            while (_SqlDataReader.Read())
            {
                TbPedido x = new TbPedido();
                x.NumeroPedido = Convert.ToInt32(_SqlDataReader["numeropedido"].ToString());
                x.ValorFaturamentoBruto = Convert.ToDouble(_SqlDataReader["valorfaturamentobruto"].ToString());
                x.ValorFaturamento = Convert.ToDouble(_SqlDataReader["ValorFaturamento"].ToString());
                x.ValorFaturamentoAplicado = Convert.ToDouble(_SqlDataReader["ValorFaturamentoAplicado"].ToString());
                x.ValorFaturamentoFinanceiro = Convert.ToDouble(_SqlDataReader["ValorFaturamentoFinanceiro"].ToString());


                x.ValorDescontoTotal = Convert.ToDouble(_SqlDataReader["ValorDescontoTotal"].ToString());
                x.ValorDescontoFinanceiroTotal = Convert.ToDouble(_SqlDataReader["ValorDescontoFinanceiroTotal"].ToString());
                x.ValorVerbaTotal = Convert.ToDouble(_SqlDataReader["ValorVerbaGeral"].ToString());
                x.ValorVerbaFabricanteTotal = Convert.ToDouble(_SqlDataReader["ValorVerbaFabricanteTotal"].ToString());
                x.NomeVendedor = _SqlDataReader["NomeVendedor"].ToString();
                x.NomeCliente = _SqlDataReader["NomeCliente"].ToString();
                x.VolumeTotal = Convert.ToDouble(_SqlDataReader["VolumeTotal"].ToString());
                x.PrazoPagamento = _SqlDataReader["PrazoPagamento"].ToString();
                x.TipoEntrega = "";
                x.TipoPedido = _SqlDataReader["TipoPedido"].ToString();
                x.TipoTabela = _SqlDataReader["TipoTabela"].ToString();
                x.StatusPedido = _SqlDataReader["StatusPedido"].ToString();
                x.MargemBruta = Convert.ToDouble(_SqlDataReader["MargemBruta"].ToString());
                x.MargemFinanceira = Convert.ToDouble(_SqlDataReader["MargemFinanceira"].ToString());
                x.MargemAplicada = Convert.ToDouble(_SqlDataReader["MargemAplicada"].ToString());
                x.MargemAplicadaFinanceira = Convert.ToDouble(_SqlDataReader["MargemFinanceiraAplicada"].ToString());
                x.MargemLiquida = Convert.ToDouble(_SqlDataReader["MargemLiquida"].ToString());

                x.ValorVerbaTotal = Convert.ToDouble(_SqlDataReader["ValorVerbaGeral"].ToString());
                x.ValorVerbaFabricanteTotal = Convert.ToDouble(_SqlDataReader["ValorVerbaFabricanteTotal"].ToString());
                x.ValorPedido = Convert.ToDouble(_SqlDataReader["ValorPedido"].ToString());
                x.CodigoCliente = Convert.ToInt32(_SqlDataReader["CodigoCliente"].ToString());
                x.CodigoVendedor = _SqlDataReader["CodigoVendedor"].ToString();
                x.ValorCustoTotal = Convert.ToDouble(_SqlDataReader["CustoBrutoTotal"].ToString());


                _list.Add(x);

            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
        public TbPedidoItens[] PedidoItensGetList(int _NumeroPedido)
        {
            SqlCommand _SqlCommand = new SqlCommand("PrInfoPedidoRentabilidade");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "TIPO_CONSULTA", "IT", true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "dt_ini", Dtini, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "dt_fim", Dtfim, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "NumeroPedido", _NumeroPedido, true, _SqlCommand);




            dalConnectX _dalConnectX = new dalConnectX(MyConnect, DataBaseName.DBAMAINERP, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbPedidoItens> _list = new List<TbPedidoItens>();

            while (_SqlDataReader.Read())
            {
                TbPedidoItens x = new TbPedidoItens();
                x.NumeroPedido = Convert.ToInt32(_SqlDataReader["NumeroPedido"].ToString());
                x.CdProduto = Convert.ToInt32(_SqlDataReader["CdProduto"].ToString());
                x.DescricaoProduto = _SqlDataReader["Descricao"].ToString();

                x.ValorItemPrecoBasico = Convert.ToDouble(_SqlDataReader["ValorItemPrecoBasico"].ToString());
                x.ValorItemPrecoTabela = Convert.ToDouble(_SqlDataReader["ValorItemPrecoTabela"].ToString());
                x.ValorItemPrecoAplicado = Convert.ToDouble(_SqlDataReader["ValorItemPrecoAplicado"].ToString());
                x.ValorItemPrecoFinanceiroAplicado = Convert.ToDouble(_SqlDataReader["ValorItemPrecoFinanceiroAplicado"].ToString());

                x.CustoTotalItem = Convert.ToDouble(_SqlDataReader["CustoTotalItem"].ToString());

                x.Qtde = Convert.ToDouble(_SqlDataReader["Qtde"].ToString());

                x.PercentualDescontoAplicado = Convert.ToDecimal(_SqlDataReader["PercentualDescontoAplicado"].ToString());
                x.PercentualDescontoFinanceiro = Convert.ToDecimal(_SqlDataReader["PercentualDescontoFinanceiro"].ToString());
                x.PercentualDescontoGeral = Convert.ToDecimal(_SqlDataReader["PercentualDescontoGeral"].ToString());

                x.PercentualMargemBruta = Convert.ToDecimal(_SqlDataReader["PercentualMargemBruta"].ToString());
                x.PercentualMargemFinanceira = Convert.ToDecimal(_SqlDataReader["PercentualMargemFinanceira"].ToString());
                x.PercentualMargemAplicada = Convert.ToDecimal(_SqlDataReader["PercentualMargemAplicada"].ToString());
                x.PercentualMargemFinanceiraAplicada = Convert.ToDecimal(_SqlDataReader["PercentualMargemFinanceiraAplicada"].ToString());
                x.PercentualMargemLiquida = Convert.ToDecimal(_SqlDataReader["PercentualMargemLiquida"].ToString());

                x.ValorVerbaFornecedor = Convert.ToDouble(_SqlDataReader["ValorVerbaFornecedor"].ToString());
                x.ValorVerbaAplicada = Convert.ToDouble(_SqlDataReader["ValorVerbaAplicada"].ToString());








                _list.Add(x);
            }
            return _list.ToArray();
        }
        public TbPedidoFabricante[] PedidoFabricanteGetList(int _NumeroPedido)
        {
            SqlCommand _SqlCommand = new SqlCommand("PrInfoPedidoRentabilidade");
            _SqlCommand.CommandType = CommandType.StoredProcedure;

            dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "TIPO_CONSULTA", "FA", true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "dt_ini", Dtini, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.DateTime, "dt_fim", Dtfim, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "NumeroPedido", _NumeroPedido, true, _SqlCommand);
            dalConnectX _dalConnectX = new dalConnectX(MyConnect, DataBaseName.DBAMAINERP, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();

            List<TbPedidoFabricante> _list = new List<TbPedidoFabricante>();

            while (_SqlDataReader.Read())
            {
                TbPedidoFabricante x = new TbPedidoFabricante();
                x.NumeroPedido = Convert.ToInt32(_SqlDataReader["NumeroPedido"].ToString());
                x.Descricao = _SqlDataReader["Descricao"].ToString();
                x.NumeroItens = Convert.ToInt32(_SqlDataReader["NumeroDeItens"].ToString());
                x.Qtde = Convert.ToInt32(_SqlDataReader["VolumeTotal"].ToString());
                x.ValorVerbaAplicada = Convert.ToDouble(_SqlDataReader["VerbaVendedor"].ToString());
                x.ValorVerbaFornecedor = Convert.ToDouble(_SqlDataReader["VerbaFornecedor"].ToString());
                x.ValorVendaBruta = Convert.ToDouble(_SqlDataReader["ValorBruto"].ToString());
                x.ValorItemPrecoTabela = Convert.ToDouble(_SqlDataReader["ValorTabela"].ToString());
                x.ValorItemPrecoAplicado = Convert.ToDouble(_SqlDataReader["ValorAplicado"].ToString());
                x.ValorItemPrecoFinanceiroAplicado = Convert.ToDouble(_SqlDataReader["ValorFinanceiro"].ToString());
                x.CustoTotalItem = Convert.ToDouble(_SqlDataReader["CustoTotal"].ToString());
                x.PercentualMargemBruta = Convert.ToDecimal(_SqlDataReader["MargemBruta"].ToString());
                x.PercentualMargemFinanceira = Convert.ToDecimal(_SqlDataReader["MargemFinanceira"].ToString());
                x.PercentualMargemAplicada = Convert.ToDecimal(_SqlDataReader["MargemAplicada"].ToString());
                x.PercentualMargemFinanceiraAplicada = Convert.ToDecimal(_SqlDataReader["MargemFinanceiraAplicada"].ToString());
                x.PercentualMargemLiquida = Convert.ToDecimal(_SqlDataReader["Margemliquida"].ToString());

                _list.Add(x);
            }
            return _list.ToArray();

        }

    }
}
