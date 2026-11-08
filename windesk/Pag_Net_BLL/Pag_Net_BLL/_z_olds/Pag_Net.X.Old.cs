using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Linq;
using System.Reflection;
using Pag_Net.Models;
using Pag_Net.Dal;
using Pag_Net.Tools.CryptFile;
using Pag_Net.Tools.CryptPassWord;
using Pag_Net.Tools;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using Pag_Net.Bll.Tools;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data.SqlClient;




namespace Pag_Net.CO03.Bll.FaturamentoBlueSoft
{


    public static class RSTSPCO003_Select
    {

        public static Pag_Net.CO03.Models.FaturamentoBlueSoft[]
                get(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.CO03.Models.FaturamentoBlueSoft Parametros, Models.FaturamentoBlueSoft.Reports TypeReport)
        {

            try
            {
                List<Pag_Net.CO03.Models.FaturamentoBlueSoft> List = new List<Pag_Net.CO03.Models.FaturamentoBlueSoft>();
                DataTable DataT = dataTable(MyConnect, Parametros, TypeReport);
                foreach (DataRow dr in DataT.Rows)
                {
                    List.Add(new Pag_Net.CO03.Models.FaturamentoBlueSoft(dr));
                }
                return List.ToArray();
            }

            catch (Exception ex)
            {
                throw new Exception("CO0030.SMP002: " + ex.Message);
            }

        }


        public static DataTable
            dataTable(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.CO03.Models.FaturamentoBlueSoft Parametros, Pag_Net.CO03.Models.FaturamentoBlueSoft.Reports ReportType)
        {
            try
            {

                DataSet DX = new DataSet();
                switch (ReportType)
                {
                    case Models.FaturamentoBlueSoft.Reports.Header:
                        DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Parametros.RSTSPCO003001_Header, "");
                        break;
                    case Models.FaturamentoBlueSoft.Reports.RegistrosEmAberto:
                        DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Parametros.RSTSPCO003000_RegistrosEmAbertos, "");
                        break;
                    case Models.FaturamentoBlueSoft.Reports.RegistrosFaturados:
                        DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Parametros.RSTSPCO003000_RegistrosFaturados, "");
                        break;
                }

                return DX.Tables[0];
            }

            catch (Exception ex)
            {
                throw new Exception("RSTSPCO003001: " + ex.Message);
            }
        }

    }

    public static class SQLSPCO003
    {
        public static void DBInsert(DbUpdate SQLConnection, Pag_Net.CO03.Models.FaturamentoBlueSoft Item)
        {
            try
            {
                SQLConnection.Execute(Item.SQLSP, Item.SQLSPC0030_DBInsert.ToArray());
            }

            catch (Exception ex)
            {
                throw new Exception("SQLSPCO003000:" + ex.Message);
            }

        }
    }



    public static class Export
    {

        public static void SqlServer(modelSistemaUsuario MyConnect)
        {
            DateTime DataInicial = Convert.ToDateTime(DateTime.Now.AddDays(-30).ToShortDateString());
            DateTime DataFinal = Convert.ToDateTime(DateTime.Now.ToShortDateString()); ;

            Execute(MyConnect, RSTSPCO003_Select.dataTable(MyConnect, new Models.FaturamentoBlueSoft(DataInicial, DataFinal, 0), Models.FaturamentoBlueSoft.Reports.RegistrosEmAberto));
            //Execute(MyConnect, RSTSPCO003_Select.dataTable(MyConnect, Parametros, Models.FaturamentoBlueSoft.Reports.RegistrosFaturados));

        }

        private static void Execute(modelSistemaUsuario MyConnect, DataTable TbFaturamentoBlueSoft)
        {

            /* Var's */
            DbUpdate SQLConnection = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);

            /* Begin Command */
            SQLConnection.Begin();

            for (int i = 0; i <= TbFaturamentoBlueSoft.Rows.Count - 1; i++)
            {
                CO03.Models.FaturamentoBlueSoft Item = new Models.FaturamentoBlueSoft(TbFaturamentoBlueSoft.Rows[i]);
                SQLSPCO003.DBInsert(SQLConnection, Item);
            }
            /* Commit tran*/
            SQLConnection.Commit();

            /* Close*/
            SQLConnection.Close();
        }
    }





}

namespace Pag_Net.CO03.Bll.FaturamentoBlue
{


    public static class RedShift_HeaderSelect
    {

        public static Pag_Net.CO03.Models.FaturamentoBlueHeader[]
                get(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.CO03.Models.FaturamentoBlueHeader Parametros, Models.FaturamentoBlueHeader.Reports TypeReport)
        {

            try
            {
                List<Pag_Net.CO03.Models.FaturamentoBlueHeader> List = new List<Pag_Net.CO03.Models.FaturamentoBlueHeader>();
                DataTable DataT = dataTable(MyConnect, Parametros, TypeReport);
                foreach (DataRow dr in DataT.Rows)
                {
                    List.Add(new Pag_Net.CO03.Models.FaturamentoBlueHeader(dr));
                }
                return List.ToArray();
            }

            catch (Exception ex)
            {
                throw new Exception("CO0030.SMP002: " + ex.Message);
            }

        }


        public static DataTable
            dataTable(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.CO03.Models.FaturamentoBlueHeader Parametros, Pag_Net.CO03.Models.FaturamentoBlueHeader.Reports ReportType)
        {
            try
            {

                DataSet DX = new DataSet();
                switch (ReportType)
                {
                    case Models.FaturamentoBlueHeader.Reports.Header:
                        DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Parametros.RedShiftDbSelectHeader(), "");
                        break;
                }

                return DX.Tables[0];
            }

            catch (Exception ex)
            {
                throw new Exception("RSTSPCO003001: " + ex.Message);
            }
        }

    }


    public static class RedShift_ItemsSelect
    {

        public static Pag_Net.CO03.Models.FaturamentoBlueItens[]
                get(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.CO03.Models.FaturamentoBlueItens Parametros, Models.FaturamentoBlueItens.Reports TypeReport)
        {

            try
            {
                List<Pag_Net.CO03.Models.FaturamentoBlueItens> List = new List<Pag_Net.CO03.Models.FaturamentoBlueItens>();
                DataTable DataT = dataTable(MyConnect, Parametros, TypeReport);
                foreach (DataRow dr in DataT.Rows)
                {
                    List.Add(new Pag_Net.CO03.Models.FaturamentoBlueItens(dr));
                }
                return List.ToArray();
            }

            catch (Exception ex)
            {
                throw new Exception("CO0030.SMP002: " + ex.Message);
            }

        }


        public static DataTable
            dataTable(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.CO03.Models.FaturamentoBlueItens Parametros, Pag_Net.CO03.Models.FaturamentoBlueItens.Reports ReportType)
        {
            try
            {

                DataSet DX = new DataSet();
                switch (ReportType)
                {
                    case Models.FaturamentoBlueItens.Reports.Items:
                        DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Parametros.RedShiftDbSelectItems(), "");
                        break;
                }

                return DX.Tables[0];
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.CO03.Bll.FaturamentoBlue.RedShift_ItemsSelect: " + ex.Message);
            }
        }

    }


    public static class Export
    {

        public static void SqlServer(modelSistemaUsuario MyConnect)
        {
            try
            {
                DateTime DataInicial = Convert.ToDateTime(DateTime.Now.AddDays(-45).ToShortDateString());
                DateTime DataFinal = Convert.ToDateTime(DateTime.Now.ToShortDateString()); ;
                Execute(MyConnect, DataInicial, DataFinal);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.CO03.Bll.FaturamentoBlue.Export.SqlServer(Data_Default)" + Environment.NewLine +
                                    ex.Message);
            }

        }

        public static void SqlServer(modelSistemaUsuario MyConnect, DateTime DataInicial, DateTime DataFinal)
        {
            try
            {
                Execute(MyConnect, DataInicial, DataFinal);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.CO03.Bll.FaturamentoBlue.Export.SqlServer(Data Parameter): " + Environment.NewLine +
                                    ex.Message);
            }

        }

        private static void Execute(modelSistemaUsuario MyConnect, DateTime DataInicial, DateTime DataFinal)
        {


            DataTable FaturamentoBlueSoftHeader = RedShift_HeaderSelect.dataTable(MyConnect, new Models.FaturamentoBlueHeader(DataInicial, DataFinal), Models.FaturamentoBlueHeader.Reports.Header);
            DataTable FaturamentoBlueSoftItems = RedShift_ItemsSelect.dataTable(MyConnect, new Models.FaturamentoBlueItens(DataInicial, DataFinal), Models.FaturamentoBlueItens.Reports.Items);

            /* Var's */
            DbUpdate SQLConnection = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);

            /* Begin Command */
            SQLConnection.Begin();

            for (int i = 0; i <= FaturamentoBlueSoftHeader.Rows.Count - 1; i++)
            {
                CO03.Models.FaturamentoBlueHeader Header = new Models.FaturamentoBlueHeader(FaturamentoBlueSoftHeader.Rows[i]);
                //SqlServer_SPC03FaturamentoBlueHeader.DBInsert(SQLConnection, Header);
                SQLConnection.Execute(Header.SQLSP, Header.SqlServer_SPC03FaturamentoBlueHeader_DBINSERT.ToArray());

            }

            for (int x = 0; x <= FaturamentoBlueSoftItems.Rows.Count - 1; x++)
            {
                CO03.Models.FaturamentoBlueItens Item = new Models.FaturamentoBlueItens(FaturamentoBlueSoftItems.Rows[x]);
                SQLConnection.Execute(Item.SQLSP, Item.SqlServer_SPC03FaturamentoBlueItems_DBINSERT.ToArray());
            }

            /* Commit tran*/
            SQLConnection.Commit();

            /* Close*/
            SQLConnection.Close();

            //Execute(MyConnect, RSTSPCO003_Select.dataTable(MyConnect, Parametros, Models.FaturamentoBlueSoft.Reports.RegistrosFaturados));

        }


    }





}

namespace Pag_Net.Bll.SqlServer
{
    public static class SPR0050ServicesTimes
    {

        public static Pag_Net.Models.SPR0050ServicesTimes[] List(modelSistemaUsuario MyConnect, Models.SPR0050ServicesTimes Parametros)
        {
            try
            {
                return Pag_Net.Dal.SqlServer.SPR0050ServicesTimes.Data.GetModel(MyConnect, Parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("SPR0050ServicesTimes.List: " + ex.Message);
            }

        }

    }
}

namespace Pag_Net.Bll
{
    public class SP_ProdutoPrecos
    {
        private string SP_name = "SP_ProdutoPreco_k02";

        //MyConnect
        private modelSistemaUsuario MyConnect;

        //Filtros de Pesquisa
        //public int F_CdOperacao;
        public SP_ProdutoPreco_Parametros Parametros;

        //Construtor
        public SP_ProdutoPrecos(modelSistemaUsuario _MYCONNECT)
        {
            MyConnect = _MYCONNECT;
            Parametros = new SP_ProdutoPreco_Parametros("", 2);
        }

        //Metodos da SP
        public SP_ProdutoPreco_TbPreco[] getList_TbProdutoOperacaoPrecoSelect()
        {


            try
            {
                List<SP_ProdutoPreco_TbPreco> List = new List<SP_ProdutoPreco_TbPreco>();
                foreach (DataRow i in _getDataTable("TbProdutoOperacaoPrecoSelect").Rows)
                {
                    SP_ProdutoPreco_TbPreco Item = new SP_ProdutoPreco_TbPreco();
                    Item.TbProduto_CdProduto = Convert.ToInt32(i["TbProduto_CdProduto"].ToString());
                    Item.TbProduto_CdProdutoBlueSoft = Convert.ToInt32(i["TbProduto_CdProdutoBlueSoft"].ToString());
                    Item.TbProduto_Descricao = i["TbProduto_Descricao"].ToString();
                    Item.TbProduto_EmbalagemEstoque = i["TbProduto_EmbalagemEstoque"].ToString();
                    Item.TbEstoque_Qtde = Convert.ToDouble(i["TbEstoque_Qtde"]);
                    Item.TbProdutoOperacaoPreco_DataAtualizacaoEstoque = Convert.ToDateTime(i["TbProdutoOperacaoPreco_DataAtualizacaoEstoque"]);
                    Item.TbProdutoOperacaoPreco_DataAtualizacaoPreco = Convert.ToDateTime(i["TbProdutoOperacaoPreco_DataAtualizacaoPreco"]);
                    Item.TbProdutoOperacaoCusto_ValorCustoBruto = Convert.ToDouble(i["TbProdutoOperacaoCusto_ValorCustoBruto"]);
                    Item.TbProdutoOperacaoCusto_ValorCustoBrutoEntrada = Convert.ToDouble(i["TbProdutoOperacaoCusto_ValorCustoBrutoEntrada"]);
                    Item.TbProdutoOperacaoPreco_ValorPreco = Convert.ToDouble(i["TbProdutoOperacaoPreco_ValorPreco"]);
                    List.Add(Item);
                }
                return List.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public DataTable getDataTable_TbProdutoOperacaoPrecoSelect()
        {
            return _getDataTable("TbProdutoOperacaoPrecoSelect");
        }

        //Metodo padrao de Retorno de DataTable
        private DataTable _getDataTable(string _SQLCommand)
        {
            DataTable Tb;
            Parametros.SQLCommnd = _SQLCommand;
            Tb = Dal.DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SP_name, _Fill(Parametros)).Tables[0];
            return Tb;
        }
        private ParameterQuey[] _Fill(SP_ProdutoPreco_Parametros SP)
        {

            List<ParameterQuey> Parametros = new System.Collections.Generic.List<ParameterQuey>();
            Parametros.Clear();
            Parametros.Add(new Models.ParameterQuey("SQLCommand", SqlDbType.VarChar, true, SP.SQLCommnd));

            //Filtros
            Parametros.Add(new Models.ParameterQuey("F_CdOperacao", SqlDbType.Int, true, SP.F_CdOperacao));
            Parametros.Add(new Models.ParameterQuey("F_CdParticipante_Fabricante", SqlDbType.Int, true, SP.F_CdParticipante_Fabricante));
            Parametros.Add(new Models.ParameterQuey("F_Produto_Descricao", SqlDbType.VarChar, true, SP.F_Produto_Descricao));
            Parametros.Add(new Models.ParameterQuey("F_StatusProduto", SqlDbType.VarChar, true, SP.F_StatusProduto));

            Parametros.Add(new Models.ParameterQuey("F_CdProduto_List", SqlDbType.VarChar, true, SP.F_CdProduto_List));
            Parametros.Add(new Models.ParameterQuey("F_CdProdutoBlueSoft_List", SqlDbType.VarChar, true, SP.F_CdProdutoBlueSoft_List));
            Parametros.Add(new Models.ParameterQuey("F_CdProdutoTarget_List", SqlDbType.VarChar, true, SP.F_CdProdutoTarget_List));
            if (SP.F_FiltrarDataAlteracaoCusto)
            {
                Parametros.Add(new Models.ParameterQuey("F_FiltrarDataAlteracaoCusto", SqlDbType.Bit, true, 1));
            }
            else
            {
                Parametros.Add(new Models.ParameterQuey("F_FiltrarDataAlteracaoCusto", SqlDbType.Bit, true, 0));
            }
            Parametros.Add(new Models.ParameterQuey("F_DataAlteracaoCustoInicial", SqlDbType.SmallDateTime, true, SP.F_DataAlteracaoCustoInicial));
            Parametros.Add(new Models.ParameterQuey("F_DataAlteracaoCustoFinal", SqlDbType.SmallDateTime, true, SP.F_DataAlteracaoCustoFinal));
            Parametros.Add(new Models.ParameterQuey("F_CodigoBarra", SqlDbType.VarChar, true, SP.F_CodigoBarra));

            return Parametros.ToArray();

        }

    }
}

namespace Pag_Net.Bll
{
    public class SP_ProdutoBlueSoftComposicao
    {
        private modelSistemaUsuario MyConnect;

        public SP_ProdutoBlueSoftComposicao(modelSistemaUsuario myConnect)
        {
            MyConnect = myConnect;
        }


        protected virtual void OnExecute(PagSystemProgressInf e)
        {
            if (e.Changed)
            {
                EventHandler<PagSystemProgressInf> handler = PagProgress;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        public event EventHandler<PagSystemProgressInf> PagProgress;

        public void TbProdutoBlueSoftComposicao_Import()
        {
            DbUpdate ConnectionSqlExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);


            //Excluindo os registros da tabela 
            List<ParameterQuey> ParametrosQuery = new System.Collections.Generic.List<ParameterQuey>();
            ParametrosQuery.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, true, "TbProdutoBlueSoftComposicao_DeleteAll"));
            ConnectionSqlExecute.Execute(SPs.SPGetVersion("SP_ProdutoBlueSoftComposicao"), ParametrosQuery.ToArray());

            /*Buscando Novos Registros*/
            DataTable BlueRS_TbProduto = Pag_Net.Bll.BlueSoft.TbRedshift_Produtos_Composicao.Get(MyConnect);
            int i = 0;

            PagSystemProgressInf Args = new PagSystemProgressInf("Inserindo Produtos...", 0, BlueRS_TbProduto.Rows.Count);
            OnExecute(Args);

            foreach (DataRow Item in BlueRS_TbProduto.Rows)
            {


                ParametrosQuery.Clear();
                ParametrosQuery.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, true, "TbProdutoBlueSoftComposicao_Insert"));
                ParametrosQuery.Add(new ParameterQuey("SeqComposicaoBlueSoft", SqlDbType.Int, true, Convert.ToInt32(Item["SeqComposicaoBlueSoft"])));
                ParametrosQuery.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, true, Convert.ToInt32(Item["cdprodutobluesoft"])));
                ParametrosQuery.Add(new ParameterQuey("CdProdutoBlueSoftComposicao", SqlDbType.Int, true, Convert.ToInt32(Item["cdprodutobluesoftComposicao"])));
                ParametrosQuery.Add(new ParameterQuey("PercentualParticipacaoCompra", SqlDbType.Decimal, true, Convert.ToInt32(Item["PercentualParticipacaoCompra"])));
                ParametrosQuery.Add(new ParameterQuey("Qtde", SqlDbType.Decimal, true, Convert.ToDecimal(Item["Qtde"])));
                ParametrosQuery.Add(new ParameterQuey("SeqTipoComposicao", SqlDbType.Decimal, true, Convert.ToDecimal(Item["SeqTipoComposicao"])));
                ParametrosQuery.Add(new ParameterQuey("DescricaoTipoComposicao", SqlDbType.VarChar, true, Item["DescricaoTipoComposicao"]));
                ConnectionSqlExecute.Execute(SPs.SPGetVersion("SP_ProdutoBlueSoftComposicao"), ParametrosQuery.ToArray());

                Args.ValorAtual = i++;

                if (Args.Changed)
                {
                    OnExecute(Args);
                }

            }

        }
    }

}

namespace Pag_Net.Bll
{
    public class SP_Produto
    {
       //MyConnect
        private modelSistemaUsuario MyConnect;

        protected virtual void OnExecute(PagSystemProgressInf e)
        {
            if (e.Changed)
            {
                EventHandler<PagSystemProgressInf> handler = PagProgress;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        public event EventHandler<PagSystemProgressInf> PagProgress;


        //Filtros de Pesquisa
        public SP_Produto_Parametros Parametros;

        //Contrutor
        public SP_Produto(modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Parametros = new SP_Produto_Parametros();
        }
        //Metodos Publicos
        public DataTable getDataTable_TbProdutoSelect()
        {
            return _getDataTable("TbProdutoSelect");
        }
        public DataTable getDataTable_TbProdutoEmbalagemSelect()
        {
            return _getDataTable("TbProdutoEmbalagemSelect");
        }
        public DataTable getDataTable_TbProdutoEmbalagemCbSelect()
        {
            return _getDataTable("TbProdutoEmbalagemCbSelect");
        }
        public DataTable getDataTable_TbProdutoBlueSoftSelect()
        {
            return _getDataTable("TbProdutoBlueSoftSelect");
        }

        /// <summary>
        /// Importa dados do arquivo de Produtos da Bluesoft e atualiza a coluna CdProdutoBlueSoftUnitario da tabela TbProdutoBlueSoft"
        /// </summary>
        public void Execute_Import_FileTextBlueSoft_Produtos(DataTable TbBlue)
        {
            try
            {
                DbUpdate ConnectionSqlExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                ConnectionSqlExecute.Begin();
                _Execute_TbProdutoBlueSoft_CdProdutoBlueSoftUnitario_OnInFile(ConnectionSqlExecute, TbBlue);
                ConnectionSqlExecute.Commit();
                ConnectionSqlExecute.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Importa dados dos Produtos Base BlueSoft Redshift e insere no Ambiente Pag
        /// </summary>
        /// 

        public void Execute_Import_RedShiftBlueSoft_Tributacao()
        {
            try
            {
                DbUpdate ConnectionSqlExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                ConnectionSqlExecute.Begin();
                _Execute_TbProdutoBlueSoftTributacaoDeleteAll(ConnectionSqlExecute);
                _Execute_TbProdutoBlueSoftTributacaoInsert(ConnectionSqlExecute);
                ConnectionSqlExecute.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Execute_Import_RedShiftBlueSoft_Produtos()
        {
            try
            {

                DbUpdate ConnectionSqlExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);


                ConnectionSqlExecute.Begin();
                _Execute_TbProdutoBlueSoftEmbalagemDeleteAll(ConnectionSqlExecute);
                _Execute_TbProdutoBlueSoftEmbalagemInsert(ConnectionSqlExecute);
                ConnectionSqlExecute.Commit();

                ConnectionSqlExecute.Begin();
                _Execute_TbProdutoBlueSoftComplementoCategDeleteAll(ConnectionSqlExecute);
                _Execute_TbProdutoBlueSoftComplementoCategInsert(ConnectionSqlExecute);
                ConnectionSqlExecute.Commit();

                /*
                ConnectionSqlExecute.Begin();
                _Execute_TbProdutoBlueSoftTributacaoDeleteAll(ConnectionSqlExecute);
                _Execute_TbProdutoBlueSoftTributacaoInsert(ConnectionSqlExecute);
                ConnectionSqlExecute.Commit();*/

                ConnectionSqlExecute.Begin();
                _Execute_SQLRelacional(ConnectionSqlExecute);
                ConnectionSqlExecute.Commit();

                ConnectionSqlExecute.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        private void _Execute_SQLRelacional(DbUpdate _ConnectionSqlExecute)
        {

            PagSystemProgressInf Args = new PagSystemProgressInf("Atualização Geral", 0, 10);
            Args.ValorAtual = 9;
            OnExecute(Args);
            Parametros.SQLCommnd = "SQLUpdateProdutoRelacional";
            _ConnectionSqlExecute.Execute(SPs.SP_PRODUTO(), _Fill(Parametros));
            Args.ValorAtual = 10;
            OnExecute(Args);

        }
        private void _Execute_TbProdutoBlueSoftDeleteAll(DbUpdate _ConnectionSqlExecute)
        {
            Parametros.SQLCommnd = "TbProdutoBlueSoftDeleteAll";
            _ConnectionSqlExecute.Execute(SPs.SP_PRODUTO(), _Fill(Parametros));
        }
        private void _Execute_TbProdutoBlueSoftInsert(DbUpdate _ConnectionSqlExecute)
        {

            DataTable BlueRS_TbProduto = Pag_Net.Bll.BlueSoft.TbRedshift_Produtos.Get(MyConnect, "", "");
            int i = 0;

            PagSystemProgressInf Args = new PagSystemProgressInf("Inserindo Produtos...", 0, BlueRS_TbProduto.Rows.Count);
            OnExecute(Args);

            foreach (DataRow Item in BlueRS_TbProduto.Rows)
            {
                Parametros.SQLCommnd = "TbProdutoBlueSoftInsert";
                Parametros.SET_CdProduto = 0;
                Parametros.SET_CdProdutoBlueSoft = Convert.ToInt32(Item["CdProdutoBlueSoft"].ToString());
                Parametros.SET_CdProdutoBlueSoftUnitario = Convert.ToInt32(Item["CdProdutoBlueSoftUnitario"].ToString());
                Parametros.SET_Descricao = Item["Descricao"].ToString();
                Parametros.SET_CodigoBarraReferencia = Item["CodigoBarraReferencia"].ToString();
                Parametros.SET_EmbalagemEstoque = Item["EmbalagemEstoque"].ToString();
                Parametros.SET_FatorEstoque = Convert.ToDouble(Item["FatorEstoque"].ToString());
                Parametros.SET_CdProdutoBlueSoftControleEstoque = Convert.ToInt32(Item["CdProdutoBlueSoftControleEstoque"].ToString());
                Parametros.SET_CdProdutoBlueSoftControlePreco = Convert.ToInt32(Item["CdProdutoBlueSoftControlePreco"].ToString());
                Parametros.SET_DepartamentoKey = Convert.ToInt32(Item["DepartamentoKey"].ToString());
                Parametros.SET_SecaoKey = Convert.ToInt32(Item["SecaoKey"].ToString());
                Parametros.SET_GrupoKey = Convert.ToInt32(Item["GrupoProdutoKey"].ToString());
                Parametros.SET_SubGrupoKey = Convert.ToInt32(Item["SubGrupoKey"].ToString());
                Parametros.SET_DataUltimaAlteracao = Convert.ToDateTime(Item["DataUltimaAlteracao"].ToString());
                Parametros.SET_DataCadastro = Convert.ToDateTime(Item["DataCadastro"].ToString());
                Parametros.SET_FabricanteKey = Convert.ToInt32(Item["FabricanteKey"].ToString());
                Parametros.SET_EmbalagemCompra = Item["EmbalagemCompra"].ToString();
                Parametros.SET_EmbalagemCompraQtdeUnitaria = Convert.ToDouble(Item["EmbalagemCompraQtdeUnitaria"].ToString());
                _ConnectionSqlExecute.Execute(SPs.SP_PRODUTO(), _Fill(Parametros));

                Args.ValorAtual = i++;

                if (Args.Changed)
                {
                    OnExecute(Args);
                }
            }
        }
        private void _Execute_TbProdutoBlueSoftEmbalagemDeleteAll(DbUpdate _ConnectionSqlExecute)
        {
            Parametros.SQLCommnd = "TbProdutoBlueSoftEmbalagemDeleteAll";
            _ConnectionSqlExecute.Execute(SPs.SP_PRODUTO(), _Fill(Parametros));
        }
        private void _Execute_TbProdutoBlueSoftEmbalagemInsert(DbUpdate _ConnectionSqlExecute)
        {
            try
            {
                DataTable DT = Pag_Net.Bll.BlueSoft.TbRedshift_Produtos_Embalagem.Get(MyConnect, 0);


                PagSystemProgressInf Args = new PagSystemProgressInf("Inserindo Embalagens...", 0, DT.Rows.Count);
                OnExecute(Args);

                for (int NL = 0; NL <= DT.Rows.Count - 1; NL++)
                {
                    Parametros.SQLCommnd = "TbProdutoBlueSoftEmbalagemInsert";
                    Parametros.SET_CdProdutoBlueSoft = Convert.ToInt32(DT.Rows[NL]["CdProdutoBlueSoft"].ToString());
                    Parametros.SET_CodigoBarra = DT.Rows[NL]["CodigoBarra"].ToString();
                    Parametros.SET_Embalagem = DT.Rows[NL]["Embalagem"].ToString();
                    Parametros.SET_EmbalagemDescricao = DT.Rows[NL]["EmbalagemDescricao"].ToString();
                    Parametros.SET_Tipo = DT.Rows[NL]["Tipo"].ToString();
                    _ConnectionSqlExecute.Execute(SPs.SP_PRODUTO(), _Fill(Parametros));
                    Args.ValorAtual = NL;

                    if (Args.Changed)
                    {
                        OnExecute(Args);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        private void _Execute_TbProdutoBlueSoft_CdProdutoBlueSoftUnitario_OnInFile(DbUpdate _ConnectionSqlExecute, DataTable TbBlue)
        {
            string ErroMessageInfo = "Erro não identificado";
            Parametros.SQLCommnd = "TbProdutoBlueSoft_CdProdutoBlueSoftUnitario_OnInFile";
            try
            {
                /* SQL loop insert rows*/
                for (int i = 0; i <= TbBlue.Rows.Count - 1; i++)
                {
                    ErroMessageInfo = "ERRO IMPORTACAO ESTOQUE"; //string.Format("Registro seq for (i): {0} | CdParticipante: {1}, Nome: {2} ", i.ToString(), TbBlue.Rows[i]["CdParticipanteBlueSoft"].ToString(), TbBlue.Rows[i]["Nome"].ToString());
                    Parametros.SET_CdProdutoBlueSoft = Convert.ToInt32(TbBlue.Rows[i]["CdProdutoBlueSoft"].ToString());
                    Parametros.SET_CdProdutoBlueSoftUnitario = Convert.ToInt32(TbBlue.Rows[i]["CdProdutoBlueSoftUnitario"].ToString());
                    _ConnectionSqlExecute.Execute(SPs.SP_PRODUTO(), _Fill(Parametros));
                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message + "/" + ErroMessageInfo);
            }
        }
        private void _Execute_TbProdutoBlueSoftComplementoCategDeleteAll(DbUpdate _ConnectionSqlExecute)
        {
            Parametros.SQLCommnd = "TbProdutoBlueSoftComplementoCategDeleteAll";
            _ConnectionSqlExecute.Execute(SPs.SP_PRODUTO(), _Fill(Parametros));
        }
        private void _Execute_TbProdutoBlueSoftComplementoCategInsert(DbUpdate _ConnectionSqlExecute)
        {
            try
            {
                DataTable DT = Pag_Net.Bll.BlueSoft.TbRedshift_Produtos_Categorias.Get(MyConnect);
                PagSystemProgressInf Args = new PagSystemProgressInf("Cadastro Complementar...", 0, DT.Rows.Count);
                OnExecute(Args);

                for (int NL = 0; NL <= DT.Rows.Count - 1; NL++)
                {
                    Parametros.SQLCommnd = "TbProdutoBlueSoftComplementoCategInsert";
                    Parametros.SET_DepartamentoKey = Convert.ToInt32(DT.Rows[NL]["DepartamentoKey"].ToString());
                    Parametros.SET_DepartamentoDescricao = DT.Rows[NL]["DepartamentoDescricao"].ToString();
                    Parametros.SET_SecaoKey = Convert.ToInt32(DT.Rows[NL]["SecaoKey"].ToString());
                    Parametros.SET_SecaoDescricao = DT.Rows[NL]["SecaoDescricao"].ToString();
                    Parametros.SET_GrupoKey = Convert.ToInt32(DT.Rows[NL]["GrupoKey"].ToString());
                    Parametros.SET_GrupoDescricao = DT.Rows[NL]["GrupoDescricao"].ToString();
                    Parametros.SET_SubGrupoKey = Convert.ToInt32(DT.Rows[NL]["SubGrupoKey"].ToString());
                    Parametros.SET_SubGrupoDescricao = DT.Rows[NL]["SubGrupoDescricao"].ToString();
                    _ConnectionSqlExecute.Execute(SPs.SP_PRODUTO(), _Fill(Parametros));
                    Args.ValorAtual = Args.ValorAtual + 1;
                    OnExecute(Args);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        private void _Execute_TbProdutoBlueSoftTributacaoDeleteAll(DbUpdate _ConnectionSqlExecute)
        {
            Parametros.SQLCommnd = "TbProdutoBlueSoftTributacaoDeleteAll";
            _ConnectionSqlExecute.Execute(SPs.SP_PRODUTO(), _Fill(Parametros));
        }
        private void _Execute_TbProdutoBlueSoftTributacaoInsert(DbUpdate _ConnectionSqlExecute)
        {
            try
            {


                DataTable DT = Pag_Net.Bll.BlueSoft.TbRedshift_Produtos_Tributacoes.Get(MyConnect);

                PagSystemProgressInf Args = new PagSystemProgressInf("Inserindo Tributação...", 0, DT.Rows.Count);
                OnExecute(Args);

                for (int NL = 0; NL <= DT.Rows.Count - 1; NL++)
                {
                    Parametros.SQLCommnd = "TbProdutoBlueSoftTributacaoInsert";
                    Parametros.SET_CdProdutoBlueSoft = Convert.ToInt32(DT.Rows[NL]["CdProdutoBlueSoft"].ToString());
                    Parametros.SET_CdOperacao = Convert.ToInt32(DT.Rows[NL]["CdOperacao"].ToString());
                    Parametros.SET_CdRegraFiscal = Convert.ToInt32(DT.Rows[NL]["CdRegraFiscal"].ToString());
                    Parametros.SET_CdRegraFiscalVersao = Convert.ToInt32(DT.Rows[NL]["CdRegraFiscalVersao"].ToString());
                    Parametros.SET_RegimeTributario = DT.Rows[NL]["RegimeTributario"].ToString();
                    Parametros.SET_CFOP = DT.Rows[NL]["CFOP"].ToString();
                    Parametros.SET_PIS_Entrada_CST = DT.Rows[NL]["PIS_ENTRADA_CST"].ToString();
                    Parametros.SET_PIS_Saida_CST = DT.Rows[NL]["PIS_SAIDA_CST"].ToString();
                    Parametros.SET_COFINS_Entrada_CST = DT.Rows[NL]["COFINS_ENTRADA_CST"].ToString();
                    Parametros.SET_COFINS_Saida_CST = DT.Rows[NL]["COFINS_SAIDA_CST"].ToString();
                    Parametros.SET_ICMS_Saida_CST = DT.Rows[NL]["ICMS_SAIDA_CST"].ToString();
                    Parametros.SET_ICMS_Entrada_CST = DT.Rows[NL]["ICMS_Entrada_CST"].ToString();
                    Parametros.SET_NCM = DT.Rows[NL]["NCM"].ToString();
                    Parametros.SET_CEST = DT.Rows[NL]["CEST"].ToString();
                    Parametros.SET_ICMS_Reducao = Convert.ToDouble(DT.Rows[NL]["ICMS_Reducao"].ToString());
                    Parametros.SET_PIS_Entrada_Aliquota = Convert.ToDouble(DT.Rows[NL]["PIS_ENTRADA_ALIQUOTA"]);
                    Parametros.SET_PIS_Saida_Aliquota = Convert.ToDouble(DT.Rows[NL]["PIS_SAIDA_ALIQUOTA"]);
                    Parametros.SET_COFINS_Entrada_Aliquota = Convert.ToDouble(DT.Rows[NL]["COFINS_ENTRADA_ALIQUOTA"]);
                    Parametros.SET_COFINS_Saida_Aliquota = Convert.ToDouble(DT.Rows[NL]["COFINS_SAIDA_ALIQUOTA"]);
                    Parametros.SET_ICMS_Aliquota_Interna = Convert.ToDouble(DT.Rows[NL]["ICMS_ALIQUOTA_INTERNA"]);
                    Parametros.SET_ST_IVA = Convert.ToDouble(DT.Rows[NL]["ST_IVA"].ToString());
                    Parametros.SET_Dados_Adicionais = Convert.ToString(DT.Rows[NL]["DADOS_ADICIONAIS"].ToString());
                    Parametros.SET_Observacao_Fiscal = Convert.ToString(DT.Rows[NL]["OBSERVACAO_FISCAL"].ToString());

                    _ConnectionSqlExecute.Execute(SPs.SP_PRODUTO(), _Fill(Parametros));
                    Args.ValorAtual = Args.ValorAtual + 1;
                    OnExecute(Args);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }



        //Metodo padrao de Retorno de DataTable
        private DataTable _getDataTable(string _SQLCommand)
        {
            DataTable Tb;
            Parametros.SQLCommnd = _SQLCommand;
            Tb = Dal.DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SPs.SP_PRODUTO(), _Fill(Parametros)).Tables[0];
            return Tb;
        }

        //_Fill ParameterQuey
        private ParameterQuey[] _Fill(SP_Produto_Parametros SP)
        {
            List<ParameterQuey> ParametrosQuery = new System.Collections.Generic.List<ParameterQuey>();
            ParametrosQuery.Clear();
            ParametrosQuery.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, true, SP.SQLCommnd));
            ParametrosQuery.Add(new ParameterQuey("F_CdProduto", SqlDbType.Int, true, SP.F_CdProduto));
            ParametrosQuery.Add(new ParameterQuey("F_CdProdutoList", SqlDbType.VarChar, true, SP.F_CdProdutoList));
            ParametrosQuery.Add(new ParameterQuey("F_CdProdutoBlueSoftList", SqlDbType.VarChar, true, SP.F_CdProdutoBlueSoftList));
            ParametrosQuery.Add(new ParameterQuey("F_CdProdutoTargetList", SqlDbType.VarChar, true, SP.F_CdProdutoTargetList));
            ParametrosQuery.Add(new ParameterQuey("F_Descricao", SqlDbType.VarChar, true, SP.F_Descricao));
            ParametrosQuery.Add(new ParameterQuey("F_StatusProduto", SqlDbType.VarChar, true, SP.F_StatusProduto));
            ParametrosQuery.Add(new ParameterQuey("F_CodigoBarraAssociado", SqlDbType.VarChar, true, SP.F_CodigoBarraAssociado));
            ParametrosQuery.Add(new ParameterQuey("SET_CodigoBarra", SqlDbType.VarChar, true, SP.SET_CodigoBarra));
            ParametrosQuery.Add(new ParameterQuey("SET_Embalagem", SqlDbType.VarChar, true, SP.SET_Embalagem));
            ParametrosQuery.Add(new ParameterQuey("SET_EmbalagemDescricao", SqlDbType.VarChar, true, SP.SET_EmbalagemDescricao));
            ParametrosQuery.Add(new ParameterQuey("SET_Tipo", SqlDbType.VarChar, true, SP.SET_Tipo));
            ParametrosQuery.Add(new ParameterQuey("SET_RegimeTributario", SqlDbType.VarChar, true, SP.SET_RegimeTributario));
            ParametrosQuery.Add(new ParameterQuey("SET_CFOP", SqlDbType.VarChar, true, SP.SET_CFOP));
            ParametrosQuery.Add(new ParameterQuey("SET_DepartamentoDescricao", SqlDbType.VarChar, true, SP.SET_DepartamentoDescricao));
            ParametrosQuery.Add(new ParameterQuey("SET_SecaoDescricao", SqlDbType.VarChar, true, SP.SET_SecaoDescricao));
            ParametrosQuery.Add(new ParameterQuey("SET_GrupoDescricao", SqlDbType.VarChar, true, SP.SET_GrupoDescricao));
            ParametrosQuery.Add(new ParameterQuey("SET_SubGrupoDescricao", SqlDbType.VarChar, true, SP.SET_SubGrupoDescricao));




            ParametrosQuery.Add(new ParameterQuey("SET_CdProduto", SqlDbType.Int, false, Parametros.SET_CdProduto));
            ParametrosQuery.Add(new ParameterQuey("SET_CdOperacao", SqlDbType.Int, false, Parametros.SET_CdOperacao));
            ParametrosQuery.Add(new ParameterQuey("SET_CdRegraFiscal", SqlDbType.Int, false, Parametros.SET_CdRegraFiscal));
            ParametrosQuery.Add(new ParameterQuey("SET_CdRegraFiscalVersao", SqlDbType.Int, false, Parametros.SET_CdRegraFiscalVersao));
            ParametrosQuery.Add(new ParameterQuey("SET_CdProdutoBlueSoft", SqlDbType.Int, false, Parametros.SET_CdProdutoBlueSoft));
            ParametrosQuery.Add(new ParameterQuey("SET_CdProdutoBlueSoftUnitario", SqlDbType.Int, false, Parametros.SET_CdProdutoBlueSoftUnitario));
            ParametrosQuery.Add(new ParameterQuey("SET_Descricao", SqlDbType.VarChar, false, Parametros.SET_Descricao));
            ParametrosQuery.Add(new ParameterQuey("SET_CodigoBarraReferencia", SqlDbType.VarChar, false, Parametros.SET_CodigoBarraReferencia));
            ParametrosQuery.Add(new ParameterQuey("SET_EmbalagemEstoque", SqlDbType.VarChar, false, Parametros.SET_EmbalagemEstoque));
            ParametrosQuery.Add(new ParameterQuey("SET_FatorEstoque", SqlDbType.Decimal, false, Parametros.SET_FatorEstoque));
            ParametrosQuery.Add(new ParameterQuey("SET_CdProdutoBlueSoftControleEstoque", SqlDbType.Int, false, Parametros.SET_CdProdutoBlueSoftControleEstoque));
            ParametrosQuery.Add(new ParameterQuey("SET_CdProdutoBlueSoftControlePreco", SqlDbType.Int, false, Parametros.SET_CdProdutoBlueSoftControlePreco));
            ParametrosQuery.Add(new ParameterQuey("SET_DepartamentoKey", SqlDbType.Int, false, Parametros.SET_DepartamentoKey));
            ParametrosQuery.Add(new ParameterQuey("SET_SecaoKey", SqlDbType.Int, false, Parametros.SET_SecaoKey));
            ParametrosQuery.Add(new ParameterQuey("SET_GrupoKey", SqlDbType.Int, false, Parametros.SET_GrupoKey));
            ParametrosQuery.Add(new ParameterQuey("SET_SubGrupoKey", SqlDbType.Int, false, Parametros.SET_SubGrupoKey));
            //ParametrosQuery.Add(new ParameterQuey("SET_DataUltimaAlteracao", SqlDbType.Date, false, Parametros.SET_DataUltimaAlteracao));
            //ParametrosQuery.Add(new ParameterQuey("SET_DataCadastro", SqlDbType.Date, false, Parametros.SET_DataCadastro));

            ParametrosQuery.Add(new ParameterQuey("SET_FabricanteKey", SqlDbType.Int, false, Parametros.SET_FabricanteKey));
            ParametrosQuery.Add(new ParameterQuey("SET_ProdutoStatus", SqlDbType.Bit, false, Parametros.SET_ProdutoStatus));
            ParametrosQuery.Add(new ParameterQuey("SET_VendaExterna", SqlDbType.Bit, false, Parametros.SET_VendaExterna));
            ParametrosQuery.Add(new ParameterQuey("SET_EmbalagemCompra", SqlDbType.VarChar, false, Parametros.SET_EmbalagemCompra));
            ParametrosQuery.Add(new ParameterQuey("SET_EmbalagemCompraQtdeUnitaria", SqlDbType.Decimal, false, Parametros.SET_EmbalagemCompraQtdeUnitaria));

            ParametrosQuery.Add(new ParameterQuey("SET_PIS_Entrada_CST", SqlDbType.VarChar, false, Parametros.SET_PIS_Entrada_CST));
            ParametrosQuery.Add(new ParameterQuey("SET_PIS_Saida_CST", SqlDbType.VarChar, false, Parametros.SET_PIS_Saida_CST));
            ParametrosQuery.Add(new ParameterQuey("SET_COFINS_Entrada_CST", SqlDbType.VarChar, false, Parametros.SET_COFINS_Entrada_CST));
            ParametrosQuery.Add(new ParameterQuey("SET_COFINS_Saida_CST", SqlDbType.VarChar, false, Parametros.SET_COFINS_Saida_CST));
            ParametrosQuery.Add(new ParameterQuey("SET_ICMS_Saida_CST", SqlDbType.VarChar, false, Parametros.SET_ICMS_Saida_CST));
            ParametrosQuery.Add(new ParameterQuey("SET_ICMS_Entrada_CST", SqlDbType.VarChar, false, Parametros.SET_ICMS_Entrada_CST));

            ParametrosQuery.Add(new ParameterQuey("SET_PIS_Entrada_Aliquota", SqlDbType.Decimal, false, Parametros.SET_PIS_Entrada_Aliquota));
            ParametrosQuery.Add(new ParameterQuey("SET_PIS_Saida_Aliquota", SqlDbType.Decimal, false, Parametros.SET_PIS_Saida_Aliquota));
            ParametrosQuery.Add(new ParameterQuey("SET_COFINS_Entrada_Aliquota", SqlDbType.Decimal, false, Parametros.SET_COFINS_Entrada_Aliquota));
            ParametrosQuery.Add(new ParameterQuey("SET_COFINS_Saida_Aliquota", SqlDbType.Decimal, false, Parametros.SET_COFINS_Saida_Aliquota));
            ParametrosQuery.Add(new ParameterQuey("SET_ICMS_Aliquota_Interna", SqlDbType.Decimal, false, Parametros.SET_ICMS_Aliquota_Interna));
            ParametrosQuery.Add(new ParameterQuey("SET_ICMS_Reducao", SqlDbType.Decimal, false, Parametros.SET_ICMS_Reducao));

            ParametrosQuery.Add(new ParameterQuey("SET_NCM", SqlDbType.VarChar, false, Parametros.SET_NCM));
            ParametrosQuery.Add(new ParameterQuey("SET_CEST", SqlDbType.VarChar, false, Parametros.SET_CEST));
            ParametrosQuery.Add(new ParameterQuey("SET_Observacao_Fiscal", SqlDbType.VarChar, false, Parametros.SET_Observacao_Fiscal));
            ParametrosQuery.Add(new ParameterQuey("SET_Dados_Adicionais", SqlDbType.VarChar, false, Parametros.SET_Dados_Adicionais));

            ParametrosQuery.Add(new ParameterQuey("SET_ST_IVA", SqlDbType.Decimal, false, Parametros.SET_ST_IVA));


            return ParametrosQuery.ToArray();
        }
    }
}

namespace Pag_Net.Bll
{
    public class SP_Integracao
    {
        private string SP_name = "SP_Integracao_K4";

        //MyConnect
        private modelSistemaUsuario MyConnect;

        protected virtual void OnExecute(PagSystemProgressInf e)
        {
            EventHandler<PagSystemProgressInf> handler = PagProgress;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<PagSystemProgressInf> PagProgress;


        //Filtros de Pesquisa
        public SP_Integracao_Parametro Parametros;

        //Contrutor
        public SP_Integracao(modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Parametros = new SP_Integracao_Parametro();
        }
        //Metodos Publicos
        public DataTable getDataTable_TbIntegracaoSelect()
        {
            return _getDataTable("TbIntegracaoSelect");
        }


        //Metodo padrao de Retorno de DataTable
        private DataTable _getDataTable(string _SQLCommand)
        {
            DataTable Tb;
            Parametros.SQLCommnd = _SQLCommand;
            Tb = Dal.DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SP_name, _Fill(Parametros)).Tables[0];
            return Tb;
        }

        //_Fill ParameterQuey
        private ParameterQuey[] _Fill(SP_Integracao_Parametro SP)
        {
            List<ParameterQuey> ParametrosQuery = new System.Collections.Generic.List<ParameterQuey>();
            ParametrosQuery.Clear();
            ParametrosQuery.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, true, SP.SQLCommnd));
            ParametrosQuery.Add(new ParameterQuey("F_SeqIntgracao", SqlDbType.Int, true, SP.F_Seq));
            ParametrosQuery.Add(new ParameterQuey("F_Descricao", SqlDbType.VarChar, true, SP.F_Descricao));

            return ParametrosQuery.ToArray();
        }
    }
}

namespace Pag_Net.Bll.Integration.RedShiftSqlServer
{



    public static class SPC5000TbDocumentosFiscais
    {

        //Execute Import / Export
        public static void Execute(modelSistemaUsuario _MyConnect, Models.SPC5000TbDocumentosFiscais _ModelParametros)
        {

            modelSistemaUsuario MyConnect;
            Pag_Net.Models.SPC5000TbDocumentosFiscais Parametros;
            List<Pag_Net.Models.SPC5000TbDocumentosFiscais> List;
            DataTable redShift_SPC5000TbDocumentosFiscais;


            try
            {

                MyConnect = _MyConnect;
                Parametros = _ModelParametros;
                //Array Model
                List = new List<Models.SPC5000TbDocumentosFiscais>();
                //Var
                //PagSystemProgressInf EventInfo = new PagSystemProgressInf();
                DbUpdate SqlServerUpdateManager = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);

                //Step 1 - Importação RedShift
                //EventInfo.Set("Buscando informações na BASE RedShift - BLUESOFT", 0, 10);
                redShift_SPC5000TbDocumentosFiscais = Pag_Net.Dal.RedShift.SPC5000TbDocumentosFiscais.Data.GetDataTable(MyConnect, Parametros);
                //2 - Validação dos Dados RedShift
                if (redShift_SPC5000TbDocumentosFiscais.Rows.Count > 0)
                {
                    foreach (DataRow i in redShift_SPC5000TbDocumentosFiscais.Rows)
                    {
                        List.Add(new Models.SPC5000TbDocumentosFiscais(i));
                    }

                }
                else
                {
                    throw new Exception("Base RedShift Vazia: Sem dados de Notas Fiscais para a Importação");
                }

                //Begin tran 
                SqlServerUpdateManager.Begin();
                Pag_Net.Dal.SqlServer.SPC5000TbDocumentosFiscais.Data.Execute(DataTypeExecute.DbDeleteAll, SqlServerUpdateManager, Parametros);
                try
                {
                    for (int i = 0; i <= List.Count() - 1; i++)
                    {
                        Pag_Net.Dal.SqlServer.SPC5000TbDocumentosFiscais.Data.Execute(DataTypeExecute.DbInsert, SqlServerUpdateManager, List[i]);
                    }
                    SqlServerUpdateManager.Commit();
                }
                catch (Exception ex)
                {
                    SqlServerUpdateManager.RollBack();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}

namespace Pag_Net.Bll.Integration.RedShiftSqlServer
{
    public class SPC0015TbProdutoBlueSoft
    {
        //Privates Vars

        private modelSistemaUsuario MyConnect;
        //Evento
        protected virtual void OnExecute(PagSystemProgressInf e)
        {
            if (e.Changed)
            {
                EventHandler<PagSystemProgressInf> handler = PagProgress;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        public event EventHandler<PagSystemProgressInf> PagProgress;



        private List<Pag_Net.Models.SPC0015TbProdutoBlueSoft> List;
        private DataTable redShift_SPC0015TbProdutoBlueSoft;


        //Contrutor
        public SPC0015TbProdutoBlueSoft(modelSistemaUsuario _MyConnect)
        {
            //Array Model
            List = new List<Models.SPC0015TbProdutoBlueSoft>();
            MyConnect = _MyConnect;
        }


        //Execute Import / Export
        public void Execute()
        {
            try
            {
                //Var
                //PagSystemProgressInf EventInfo = new PagSystemProgressInf();
                DbUpdate SqlServerUpdateManager = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);

                //Step 1 - Importação RedShift
                PagSystemProgressInf EventInfo = new PagSystemProgressInf("Buscando informações na BASE RedShift - BLUESOFT", 0, 10);
                //EventInfo.Set("Buscando informações na BASE RedShift - BLUESOFT", 0, 10);
                OnExecute(EventInfo);


                EventInfo.ValorAtual = 5;
                if (EventInfo.Changed)
                {
                    OnExecute(EventInfo);
                }

                //OnExecute(EventInfo);


                Step01_ImportFromRedShiftFind(EventInfo);
                EventInfo.ValorAtual = 10;
                OnExecute(EventInfo);



                //Step 2 - Leitura
                if (redShift_SPC0015TbProdutoBlueSoft.Rows.Count > 0)
                {
                    EventInfo.Set("Integration.RedShiftSqlServer: Leitura de Validação dos dados RedShift", 0, redShift_SPC0015TbProdutoBlueSoft.Rows.Count - 1);
                    OnExecute(EventInfo);
                    Step02_ValidationRedShift(EventInfo);
                }
                else
                {
                    throw new Exception("Base RedShift Vazia: Sem dados de Produtos para a Importação");
                }

                //Begin tran 
                SqlServerUpdateManager.Begin();

                //Step 3,4 - Excluindo os dados e Salvando os novos dados.
                EventInfo.Set("Integration.RedShiftSqlServer: Exportação para o Sql Server", 0, List.Count);
                OnExecute(EventInfo);

                try
                {

                    Step03_SqlServerDeleteAll(EventInfo, SqlServerUpdateManager);
                    Step04_ExportToSqlServer(EventInfo, SqlServerUpdateManager);
                    SqlServerUpdateManager.Commit();
                }
                catch (Exception ex)
                {
                    SqlServerUpdateManager.RollBack();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        private void Step01_ImportFromRedShiftFind(PagSystemProgressInf _Event)
        {
            try
            {
                //Event Info
                _Event.ValorAtual = 2; OnExecute(_Event);
                //Void
                redShift_SPC0015TbProdutoBlueSoft = Pag_Net.Dal.RedShift.SPC0015TbProdutoBlueSoft.Data.GetDataTable(MyConnect, new Models.SPC0015TbProdutoBlueSoft());
                //Event Info
                _Event.ValorAtual = _Event.ValorFinal; OnExecute(_Event);

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Integration.RedShiftSqlServer.SPC0015TbProdutoBlueSoft.Step01_ImportFromRedShiftFind: " + ex.Message);
            }
        }

        private void Step02_ValidationRedShift(PagSystemProgressInf _Event)
        {
            try
            {
                //Evento 
                foreach (DataRow i in redShift_SPC0015TbProdutoBlueSoft.Rows)
                {
                    List.Add(new Models.SPC0015TbProdutoBlueSoft(i));
                    _Event.ValorAtual = _Event.ValorAtual + 1;
                    OnExecute(_Event);


                    if (_Event.Changed)
                    {
                        OnExecute(_Event);
                    }


                }
                OnExecute(_Event);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Integration.RedShiftSqlServer.SPC0015TbProdutoBlueSoft.Step01_ImportFromRedShiftFind: " + ex.Message);
            }

        }

        private void Step03_SqlServerDeleteAll(PagSystemProgressInf _Event, DbUpdate _SqlServerUpdateManager)
        {
            try
            {
                //Evento 
                _Event.ValorAtual = 2;
                OnExecute(_Event);
                Pag_Net.Dal.SqlServer.SPC0015TbProdutoBlueSoft.Data.Execute(DataTypeExecute.DbDeleteAll, _SqlServerUpdateManager, List[0]);
                _Event.ValorAtual = _Event.ValorFinal;
                OnExecute(_Event);

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Integration.RedShiftSqlServer.SPC0015TbProdutoBlueSoft.Step03_ValidationRedShift: " + ex.Message);
            }
        }

        private void Step04_ExportToSqlServer(PagSystemProgressInf _Event, DbUpdate _SqlServerUpdateManager)
        {
            try
            {
                //Evento 
                _Event.ValorAtual = 0;
                OnExecute(_Event);
                for (int i = 0; i <= List.Count() - 1; i++)
                {
                    Pag_Net.Dal.SqlServer.SPC0015TbProdutoBlueSoft.Data.Execute(DataTypeExecute.DbInsert, _SqlServerUpdateManager, List[i]);
                    _Event.ValorAtual = _Event.ValorAtual + 1;
                    OnExecute(_Event);
                }
                OnExecute(_Event);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Integration.RedShiftSqlServer.SPC0015TbProdutoBlueSoft.Step03_ValidationRedShift: " + ex.Message);
            }
        }


    }
}


namespace Pag_Net.Bll.BlueSoft
{
    /// <summary>
    /// Retorna Base de Recebimentos BlueSoft
    /// </summary>
    public class TbRedshift_Recebimentos
    {
        public static DataTable _SELECT(modelSistemaUsuario _MYCONNECT, DateTime F_DtRecebimentoInicial, DateTime F_DtRecebimentoFinal)
        {
            try
            {
                return _SELECT(_MYCONNECT, "", "", F_DtRecebimentoInicial, F_DtRecebimentoFinal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public static DataTable _SELECT(modelSistemaUsuario _MYCONNECT, string F_ListCdProdutoKey, string F_DescricaoBlueSoft, DateTime F_DtRecebimentoInicial, DateTime F_DtRecebimentoFinal)
        {
            try
            {
                string SqlRedSHIFT = "SELECT        it.nota_fiscal_item_key                                         as SeqRecebimentoItem " +
                                     "          ,   nf.fornecedor_key                                               as FornecedorKey " +
                                     "          ,   fn.nome_razao                                                   as RazaoSocial " +
                                     "          ,   fn.cpf_cnpj                                                     as CNPJCPF " +
                                     "          ,   nf.nf_numero                                                    as NumeroNotaFiscal " +
                                     "          ,   nf.codigo_operacao_fiscal                                       as CFOP " +
                                     "          ,   nf.data_emissao                                                 as DataEmissao " +
                                     "          ,   isnull(nf.data_recebimento,'1999-01-01')                        as DataRecebimento " +
                                     "          ,   it.produto_key                                                  as CdProdutoBlueSoft " +
                                     "          ,   pr.descricao                                                    as Descricao " +
                                     "          ,   isnull(pr.embalagem_key,'')                                     as EmbalagemCompra " +
                                     "          ,   isnull(it.custo_embalagem_final,0)                              as ValorCusto " +
                                     "          ,   isnull((it.custo_embalagem_final * it.quantidade_faturada),0)   as ValorCustoTotal " +
                                     "          ,   isnull(it.ni_fator_estoque,0)                                   as FatorEstoque " +
                                     "          ,   isnull(it.quantidade_faturada,0)                                as EmbalagemCompraQtde " +
                                     "          ,   isnull(it.quantidade_faturada * it.ni_fator_estoque,0)          as EmbalagemEstoqueQtde " +
                                     "          ,   isnull(it.quantidade_devolvida,0)                               as EmbalagemEstoqueQtde_Devolvida " +
                                     "          ,   isnull(it.ni_base_calculo_icms_st,0)                            as ValorBaseST " +
                                     "          ,   convert(numeric(13,2),0)                                        as ValorST " +
                                     "          ,   isnull(((it.custo_embalagem_final * it.quantidade_faturada) / (it.quantidade_faturada * it.ni_fator_estoque)),0) AS EmbalagemEstoqueValorCusto " +
                                     "          ,   isnull(ax.ap_count,0)                                           as NumeroAps  " +
                                     "          ,   isnull(ax.ap_maximo,'1999-01-01')                               as DataVencimentoMaximo " +
                                     "          ,   isnull(ax.ap_minimo,'1999-01-01')                               as DataVencimentoMinimo " +
                                     "          ,   convert(int, 0)                                                 as CdParticipante " +
                                     "          ,   convert(int, 0)                                                 as CdProduto" +
                                     "  from        fato_nota_fiscal      it " +
                                     "  inner join  produto_d             pr on pr.produto_key = it.produto_key " +
                                     "  inner join  nota_fiscal           nf on nf.nf_key = it.nf_key and nf.loja_key = it.loja_key " +
                                     "  inner join  pessoa                fn on fn.pessoa_key = nf.fornecedor_key " +
                                     "  left join   (     select      fa.nf_key                         as nf_key " +
                                     "                             ,  count(ap.ap_key)                  as ap_count " +
                                     "                             ,  max(ap.data_vencimento)           as ap_maximo " +
                                     "                             ,  min(ap.data_vencimento)           as ap_minimo " +
                                     "                    from        AUTORIZACAO_PAGAMENTO                ap " +
                                     "                    inner join  nota_fiscal_fatura                   fa on fa.fatura_key = ap.fatura_key " +
                                     "                    where       DATA_EMISSAO >= '2019-01-01'  " +
                                     "                    AND         CANCELADA = 0  " +
                                     "                    group by    fa.nf_key " +
                                     "              ) ax on ax.nf_key = nf.nf_key   " +
                                     "  where       nf.loja_key = 1 " +
                                     "  and         nf.data_emissao >= '2019-01-01' " +
                                     "  and         nf.data_recebimento >= '" + F_DtRecebimentoInicial.ToString("yyyy-MM-dd") + "'" +
                                     "  and         nf.data_recebimento <= '" + F_DtRecebimentoFinal.ToString("yyyy-MM-dd") + "'";

                if (F_DescricaoBlueSoft != "")
                {
                    SqlRedSHIFT += "  and         pr.descricao like '%" + F_DescricaoBlueSoft.Replace("'", "").ToString() + "'";
                }

                if (F_ListCdProdutoKey != "")
                {
                    SqlRedSHIFT += "  and         it.produto_key in ( " + F_ListCdProdutoKey.ToString() + ")";
                }

                SqlRedSHIFT +=
                              "  and         it.nf_tipo_descricao like 'Nota fiscal de recebimento de mercadorias' " +
                              "  and         it.tipo_operacao_nota_fiscal = 'Entrada' " +
                              "  order by    it.produto_key asc , nf.data_recebimento desc";

                /*Data Base BlueSoft RedShift*/
                DataSet DX = DbSelect.GetDataSet(_MYCONNECT, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

namespace Pag_Net.Bll.BlueSoft
{
    /// <summary>
    /// Retorna Tributacoes 
    /// </summary>
    public static class TbRedshift_Produtos_Tributacoes
    {
        public static DataTable Get(modelSistemaUsuario _myConnect)
        {
            return Get(_myConnect, 0);
        }
        public static DataTable Get(modelSistemaUsuario _myConnect, int CdProdutoKey)
        {
            try
            {

                string SqlRedSHIFT = "  SELECT     convert(int, 2)                                        AS CdOperacao     " +
                                     "         ,   convert(int,X.PRODUTO_KEY)                             AS CdProdutoBlueSoft     " +
                                     "         ,   convert(int,99999)                                     AS CdRegraFiscal     " +
                                     "         ,   convert(int,99999)                                     AS CdRegraFiscalVersao     " +
                                     "         ,   convert(char(1), 'X')                                  AS RegimeTributario     " +
                                     "         ,   convert(char(4), '5102')                               AS CFOP     " +
                                     "         ,   convert(char(2), PISE.CST_PIS_COFINS_KEY)              AS PIS_ENTRADA_CST     " +
                                     "         ,   convert(numeric(13,2), ISNULL(PISE.ALIQUOTA,0))        AS PIS_ENTRADA_ALIQUOTA     " +
                                     "         ,   convert(char(2), PISS.CST_PIS_COFINS_KEY)              AS PIS_SAIDA_CST     " +
                                     "         ,   convert(numeric(13,2), ISNULL(PISS.ALIQUOTA,0))        AS PIS_SAIDA_ALIQUOTA     " +
                                     "         ,   convert(char(2), COFE.CST_PIS_COFINS_KEY)              AS COFINS_ENTRADA_CST     " +
                                     "         ,   convert(numeric(13,2), ISNULL(COFE.ALIQUOTA,0))        AS COFINS_ENTRADA_ALIQUOTA     " +
                                     "         ,   convert(char(2), COFS.CST_PIS_COFINS_KEY)              AS COFINS_SAIDA_CST     " +
                                     "         ,   convert(numeric(13,2), ISNULL(COFS.ALIQUOTA,0))        AS COFINS_SAIDA_ALIQUOTA     " +
                                     "         ,   convert(numeric(13,2), ISNULL(ICM_SAIDA.ALIQUOTA,0))   AS ICMS_ALIQUOTA_INTERNA     " +
                                     "         ,   convert(numeric(13,2),ICM_SAIDA.REDUCAO)               AS ICMS_REDUCAO     " +




                                     "         ,   case char_length(ICM_SAIDA.CODIGO_TRIBUTACAO) " +
                                     "                             when  1 then CAST(ICM_SAIDA.CODIGO_ORIGEM AS VARCHAR(1)) + '0' +  CAST(ICM_SAIDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                                     "                             when  2 then CAST(ICM_SAIDA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_SAIDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                                     "                             else         CAST(ICM_SAIDA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_SAIDA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                                     "                             end          AS ICMS_SAIDA_CST     " +


                                     "         ,   case char_length(ICM_ENTRADA.CODIGO_TRIBUTACAO) " +
                                     "                             when  1 then CAST(ICM_ENTRADA.CODIGO_ORIGEM AS VARCHAR(1)) + '0' +  CAST(ICM_ENTRADA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                                     "                             when  2 then CAST(ICM_ENTRADA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_ENTRADA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                                     "                             else         CAST(ICM_ENTRADA.CODIGO_ORIGEM AS VARCHAR(1)) + CAST(ICM_ENTRADA.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                                     "                             end          AS ICMS_ENTRADA_CST     " +



                                     "         ,   convert(varchar(8), CLAS.NCM)                          AS NCM     " +
                                     "         ,   convert(varchar(7), CEST.codigo)                       AS CEST     " +
                                     "         ,   convert(numeric(17,4), ISNULL(FX.IVA_ST,0))            AS ST_IVA     " +
                                     "         ,   convert(varchar(1), '')                                as DADOS_ADICIONAIS " +
                                     "         ,   convert(varchar(1), '')                                as OBSERVACAO_FISCAL " +
                                     " FROM        PRODUTO_D                       X     " +
                                     " INNER JOIN  FIGURA_FISCAL_ESTADUAL          FX          ON FX.PRODUTO_KEY = X.PRODUTO_KEY AND FX.ESTADO_SIGLA = 'SP'     " +
                                     " INNER JOIN  ICM                             ICM_SAIDA   ON ICM_SAIDA.ICM_KEY = FX.ICM_KEY     " +
                                     " INNER JOIN  ICM                             ICM_ENTRADA ON ICM_ENTRADA.ICM_KEY = FX.icm_entrada_key     " +
                                     " INNER JOIN  PIS                             PISS        ON PISS.PIS_KEY = X.PIS_KEY     " +
                                     " INNER JOIN  PIS                             PISE        ON PISE.PIS_KEY = X.PIS_ENTRADA_KEY     " +
                                     " INNER JOIN  COFINS                          COFS        ON COFS.COFINS_KEY = X.COFINS_KEY     " +
                                     " INNER JOIN  COFINS                          COFE        ON COFE.COFINS_KEY = X.COFINS_ENTRADA_KEY     " +
                                     " INNER JOIN  CLASSIFICACAO_FISCAL            CLAS        ON CLAS.CLASSIFICACAO_FISCAL_KEY = X.CLASSIFICACAO_FISCAL_KEY     " +
                                     " LEFT  JOIN  CEST                            CEST        ON CEST.CEST_KEY = X.CEST_KEY     " +
                                     " WHERE x.produto_key > 0     " +
                                     " UNION     " +
                                     " select     convert(int,1)                                   as CdOperacao     " +
                                     "        ,   convert(int,pd.produto_key)                      as CdProdutoBlueSoft     " +
                                     "        ,   convert(int,rs.regra_fiscal_saida_key)           AS CdRegraFiscal " +
                                     "        ,   convert(int,rg.regra_fiscal_saida_versao_key)    AS CdRegraFiscalVersao " +
                                     "        ,   convert(char(1), left(tb.regime_tributario,1))   AS RegimeTributario " +
                                     "        ,   convert(char(4), tb.cfop_key)                    AS CFOP     " +
                                     "        ,   CONVERT(VARCHAR(2), '00')                        AS PIS_ENTRADA_CST     " +
                                     "        ,   CONVERT(NUMERIC(13,2), 0)                        AS PIS_ENTRADA_ALIQUOTA     " +
                                     "        ,   convert(char(2), PS.CST_PIS_COFINS_KEY)          AS PIS_SAIDA_CST     " +
                                     "        ,   convert(numeric(13,2), ps.aliquota)              AS PIS_SAIDA_ALIQUOTA     " +
                                     "        ,   CONVERT(VARCHAR(2), '00')                        AS COFINS_ENTRADA_CST     " +
                                     "        ,   CONVERT(NUMERIC(13,2), 0)                        AS COFINS_ENTRADA_ALIQUOTA     " +
                                     "        ,   convert(char(2), CS.cst_pis_cofins_key)          AS COFINS_SAIDA_CST     " +
                                     "        ,   convert(numeric(13,2), cs.aliquota)              AS COFINS_SAIDA_ALIQUOTA     " +
                                     "        ,   CONVERT(NUMERIC(13,2), ic.aliquota)              AS ICMS_ALIQUOTA_INTERNA     " +
                                     "        ,   CONVERT(NUMERIC(13,2), IC.REDUCAO)               AS ICMS_REDUCAO " +
                                     "        ,   case char_length(IC.CODIGO_TRIBUTACAO) " +
                                     "                             when  1 then CAST(IC.CODIGO_ORIGEM AS VARCHAR(1)) + '0' + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                                     "                             when  2 then CAST(IC.CODIGO_ORIGEM AS VARCHAR(1))       + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                                     "                             else         CAST(IC.CODIGO_ORIGEM AS VARCHAR(1))       + CAST(IC.CODIGO_TRIBUTACAO AS VARCHAR(2)) " +
                                     "                             end                             AS ICMS_SAIDA_CST     " +
                                     "        ,   CONVERT(VARCHAR(3), '000')                       AS ICMS_ENTRADA_CST     " +
                                     "        ,   CONVERT(VARCHAR(8), '00000000')                  AS NCM     " +
                                     "        ,   CONVERT(VARCHAR(7), '0000000')                   AS CEST     " +
                                     "        ,   CONVERT(NUMERIC(13,2),0)                         AS ST_IVA     " +
                                     "        ,   tb.dados_adicionais                              AS DADOS_ADICIONAIS " +
                                     "        ,   tb.observacoes                                   AS OBSERVACAO_FISCAL " +
                                     "  from       regra_fiscal_saida_produto    pd     " +
                                     "  inner join regra_fiscal_saida_versao     rg  on rg.regra_fiscal_saida_key = pd.regra_fiscal_saida_key     " +
                                     "  inner join (  select     rg1.regra_fiscal_saida_key                as  regra_fiscal_saida_key     " +
                                     "                        ,  max(rg1.regra_fiscal_saida_versao_key)    as  regra_fiscal_saida_versao_key     " +
                                     "                from       regra_fiscal_saida_versao             rg1     " +
                                     "                inner join (   select    regra_fiscal_saida_key        as regra_fiscal_saida_key,     " +
                                     "                                         max(data_inicio_vigencia)     as data_inicio_vigencia     " +
                                     "                               from      regra_fiscal_saida_versao     " +
                                     "                               group by  regra_fiscal_saida_key     " +
                                     "                            )  rg2 on rg2.regra_fiscal_saida_key = rg1.regra_fiscal_saida_key and rg2.data_inicio_vigencia = rg1.data_inicio_vigencia     " +
                                     "                group by rg1.regra_fiscal_saida_key     " +
                                     "             ) rg_versao_atual on rg.regra_fiscal_saida_versao_key = rg_versao_atual.regra_fiscal_saida_versao_key     " +
                                     "  inner join regra_fiscal_saida               rs on rs.regra_fiscal_saida_key = rg.regra_fiscal_saida_key     " +
                                     "  inner join regra_fiscal_saida_trib          tb on tb.regra_fiscal_saida_versao_key = rg.regra_fiscal_saida_versao_key     " +
                                     "  inner join ICM                              ic on ic.icm_key = tb.icm_key     " +
                                     "  inner join PIS                              ps on ps.pis_key = rg.pis_key     " +
                                     "  inner join COFINS                           cs on cs.COFINS_key = rg.COFINS_key  ";

                if (CdProdutoKey > 0)
                {
                    SqlRedSHIFT = SqlRedSHIFT + " AND produto_key = " + CdProdutoKey.ToString();
                }

                DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }

}

namespace Pag_Net.Bll.BlueSoft
{

    /// <summary>
    /// Retorna Embalagens da BASE BlueSoft
    /// </summary>
    public static class TbRedshift_Produtos_Embalagem
    {
        public static DataTable Get(modelSistemaUsuario _myConnect, int CdProdutoKeyUnitarioKey)
        {
            try
            {
                string SqlRedSHIFT = "SELECT    p.produto_key             CdProdutoBlueSoft " +
                                     "        , p.descricao               EmbalagemProdutoDescricao " +
                                     "        , p.fator_estoque           EmbalagemProdutoFator_Estoque " +
                                     "        , i.barra_key               CodigoBarra " +
                                     "        , e.embalagem_key           Embalagem " +
                                     "        , e.nome                    EmbalagemDescricao " +
                                     "        , p.status                  statusproduto " +
                                     "        , CASE WHEN len(i.barra_key) = 8  THEN 'EAN8' " +
                                     "               WHEN len(i.barra_key) = 13 THEN 'EAN13' " +
                                     "               WHEN len(i.barra_key) = 14 THEN 'DUN14' " +
                                     "               ELSE 'PLU' " +
                                     "          END tipo " +
                                     " FROM item i  " +
                                     " left JOIN produto_d p on i.produto_key = p.produto_key " +
                                     " left JOIN embalagem e ON e.embalagem_key = p.embalagem_key " +
                                     " WHERE p.produto_key > 0 ";

                if (CdProdutoKeyUnitarioKey > 0)
                {
                    SqlRedSHIFT = SqlRedSHIFT + " AND produto_unitario_key = " + CdProdutoKeyUnitarioKey.ToString();
                }

                SqlRedSHIFT = SqlRedSHIFT + " ORDER BY  CODIGOBARRA ASC ";

                DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}

namespace Pag_Net.Bll.BlueSoft
{
    /// <summary>
    /// Retorna Base de Recebimentos BlueSoft
    /// </summary>
    public class TbRedshift_Produtos_Composicao
    {
        public static DataTable Get(modelSistemaUsuario _MYCONNECT)
        {
            try
            {
                string SqlRedSHIFT = " SELECT   X.COMPOSICAO_KEY       AS SeqComposicaoBlueSoft " +
                                     "        , X.PRODUTO_FINAL        AS CdProdutoBlueSoft" +
                                     "        , X.PRODUTO_PARTE        AS CdProdutoBlueSoftComposicao" +
                                     "        , X.QUANTIDADE           AS Qtde" +
                                     "        , A.TIPO_COMPOSICAO_KEY  AS SeqTipoComposicao " +
                                     "        , T.DESCRICAO            AS DescricaoTipoComposicao " +
                                     "        , isnull(X.PERCENTUAL_DO_ITEM_NA_COMPRA,0) AS PercentualParticipacaoCompra" +
                                     " FROM      COMPOSICAO      X " +
                                     " inner join (     select    produto_final         as produto_final , " +
                                     "                  max(ultima_alteracao) as ultima_alteracao " +
                                     "                  from      composicao " +
                                     "                  group by  produto_final " +
                                     "                  ) cp on x.produto_final = cp.produto_final and x.ultima_alteracao = cp.ultima_alteracao " +
                                     " LEFT JOIN PRODUTO_D       A ON A.PRODUTO_KEY = X.PRODUTO_FINAL " +
                                     " LEFT JOIN PRODUTO_D       I ON I.PRODUTO_KEY = X.PRODUTO_PARTE " +
                                     " LEFT JOIN TIPO_COMPOSICAO T ON T.TIPO_COMPOSICAO_KEY = A.TIPO_COMPOSICAO_KEY ";




                /*Data Base BlueSoft RedShift*/
                DataSet DX = DbSelect.GetDataSet(_MYCONNECT, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}

namespace Pag_Net.Bll.BlueSoft
{

    /// <summary>
    /// Retorna Categorias 
    /// </summary>
    public static class TbRedshift_Produtos_Categorias
    {
        public static DataTable Get(modelSistemaUsuario _myConnect)
        {
            try
            {
                string SqlRedSHIFT = "SELECT         DEPARTAMENTO_KEY        as DepartamentoKey  " +
                                     "           ,   DEPARTAMENTO            as DepartamentoDescricao " +
                                     "           ,   SECAO_KEY               as SecaoKey " +
                                     "           ,   SECAO                   as SecaoDescricao " +
                                     "           ,   GRUPO_PRODUTO_KEY       as GrupoKey " +
                                     "           ,   GRUPO                   as GrupoDescricao " +
                                     "           ,   SUB_GRUPO_PRODUTO_KEY   as SubGrupoKey " +
                                     "           ,   SUBGRUPO                as SubGrupoDescricao " +
                                     "           FROM        PRODUTO_D " +
                                     "           WHERE       departamentokey > 0 " +
                                     "             and       secaokey > 0 " +
                                     "             and       grupo_produto_key > 0 " +
                                     "             and       grupo > 0 " +
                                     "           GROUP BY       DEPARTAMENTO_KEY " +
                                     "                      ,   DEPARTAMENTO " +
                                     "                      ,   SECAO_KEY " +
                                     "                      ,   SECAO " +
                                     "                      ,   GRUPO_PRODUTO_KEY " +
                                     "                      ,   GRUPO " +
                                     "                      ,   SUB_GRUPO_PRODUTO_KEY " +
                                     "                      ,   SUBGRUPO ";


                DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}

namespace Pag_Net.Bll.BlueSoft
{
    /// <summary>
    /// Retorna Base de Notas Fiscais gerais registradas no ambiente BlueSoft
    /// </summary>
    public class TbRedshift_DocumentosFiscaisItensBlueSoft
    {
        public static DataTable Get(modelSistemaUsuario _MYCONNECT)
        {
            try
            {
                string SqlRedSHIFT = " SELECT    it.LOJA_KEY                         As LojaKey " +
                                     "         , it.NF_KEY                           As SeqNotaFiscal " +
                                     "         , it.NOTA_FISCAL_ITEM_KEY             As SequencialItem " +
                                     "         , it.NF_NUMERO                        As NumeroNotaFiscal " +
                                     "         , it.NF_SERIE                         As Serie " +
                                     "         , it.DATA_EMISSAO                     As DataEmissao " +
                                     "         , it.DATA_SAIDA                       As DataSaida " +
                                     "         , it.PRODUTO_KEY                      As CdProdutoBlueSoft " +
                                     "         , it.DESCRICAO                        As Descricao " +
                                     "         , it.NI_VALOR_BRUTO                   As ValorBruto " +
                                     "         , it.NI_VALOR_BRUTO_TOTAL             As ValorBrutoTotal " +
                                     "         , it.NI_FATOR_ESTOQUE                 As FatorEstoque " +
                                     "         , it.CUSTO_EMBALAGEM_FINAL            As ValorLiquido " +
                                     "         , it.QUANTIDADE_FATURADA              As QuantidadeFaturada " +
                                     "         , it.NI_UNIDADE_MEDIDA_FATURAMENTO    AS EmbalagemFaturamento " +
                                     "         , it.nf_tipo_descricao                As TipoDocumentoFiscalDescricao " +
                                     "         , nf.fornecedor_key                   as fornecedor_key " +
                                     " FROM      fato_nota_fiscal                it " +
                                     " LEFT JOIN nota_fiscal                     nf on nf.nf_key = it.nf_key " +
                                     " LEFT JOIN PESSOA                          PS ON PS.PESSOA_KEY = NF.FORNECEDOR_KEY " +
                                     " WHERE     nf.DATA_EMISSAO >= '2019-08-01' " +
                                     " and       nf.DATA_EMISSAO <= '2019-08-30' " +
                                     " AND       it.PRODUTO_KEY = 59259 ";
                DataSet DX = DbSelect.GetDataSet(_MYCONNECT, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

    }
}

namespace Pag_Net.Bll.BlueSoft.ProdutoEstoqueCusto
{
    public class Update_Estoque
    {
        public int Start(modelSistemaUsuario _myConnect, DataTable TbBlue, int SeqArquivo)
        {

            string ErroMessageInfo = "Erro não identificado";

            DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);

            try
            {

                /* Var's */

                List<ParameterQuey> Parametros = new List<ParameterQuey>();

                /* Begin Command */
                x.Begin();

                /* SQL Command Clear Table*/
                // Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "DELETE")); 
                // x.Execute("SP_ParticipanteBluesoft", Parametros.ToArray());

                /* Limpa os parametros para um novo insert*/
                Parametros.Clear();

                /* SQL loop insert rows*/
                for (int i = 0; i <= TbBlue.Rows.Count - 1; i++)
                {
                    Parametros.Clear();


                    if (Convert.ToBoolean(TbBlue.Rows[i]["Valid"]))
                    {
                        ErroMessageInfo = "ERRO IMPORTACAO ESTOQUE | Código do Produto: " + TbBlue.Rows[i]["CdProdutoBlueSoft"].ToString() + (Char)13 +
                                            "Número da LInha: " + i.ToString() + (Char)13 +
                                            "Descrição do Produto: " + TbBlue.Rows[i]["DescricaoImportacao"].ToString();



                        //string.Format("Registro seq for (i): {0} | CdParticipante: {1}, Nome: {2} ", i.ToString(), TbBlue.Rows[i]["CdParticipanteBlueSoft"].ToString(), TbBlue.Rows[i]["Nome"].ToString());


                        //Data fields 
                        Parametros.Add(new ParameterQuey("Data", SqlDbType.SmallDateTime, false, DateTime.Now.ToShortDateString()));


                        //int fields 
                        Parametros.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, false, TbBlue.Rows[i]["CdProdutoBlueSoft"].ToString()));
                        Parametros.Add(new ParameterQuey("SeqImportacao", SqlDbType.Int, false, SeqArquivo.ToString()));
                        Parametros.Add(new ParameterQuey("NumeroLinha", SqlDbType.Int, false, TbBlue.Rows[i]["NumeroLinha"].ToString()));
                        //Parametros.Add(new ParameterQuey("SeqImportacao", SqlDbType.Int, false, TbBlue.Rows[i]["SeqImportacao"].ToString()));

                        //chars fields 
                        Parametros.Add(new ParameterQuey("DescricaoImportacao", SqlDbType.VarChar, false, TbBlue.Rows[i]["DescricaoImportacao"].ToString()));
                        Parametros.Add(new ParameterQuey("CodigoBarra", SqlDbType.VarChar, false, TbBlue.Rows[i]["CodigoBarra"].ToString()));

                        //decimals fields
                        Parametros.Add(new ParameterQuey("EmbalagemEstoqueQtde", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["EmbalagemEstoqueQtde"].ToString())));
                        Parametros.Add(new ParameterQuey("ValorCustoBruto", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ValorCustoBruto"].ToString())));
                        Parametros.Add(new ParameterQuey("ValorCustoLiquido", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ValorCustoLiquido"].ToString())));


                        //bit -int fields

                        //if (TbBlue.Rows[i]["ClienteStatus"].ToString().Trim() == "1")
                        //{
                        //    Parametros.Add(new ParameterQuey("ClienteStatus", SqlDbType.Bit, false, 1));
                        //}
                        //else
                        //{
                        //    Parametros.Add(new ParameterQuey("ClienteStatus", SqlDbType.Bit, false, 0));
                        //}

                        //Proc Execute
                        Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "UPDATE_ESTOQUE"));
                        x.Execute("SP_ProdutoEstoqueCustoBlueSoft", Parametros.ToArray());
                    }
                }


                Parametros.Clear();

                /* Commit tran*/
                x.Commit();

                /* Close*/
                x.Close();


                return 0;
            }
            catch (Exception ex)
            {
                x.Close();
                throw new Exception(ErroMessageInfo + " - " + ex.Message);

            }

        }
    }

    public class Update_Entradas
    {
        public int Start(modelSistemaUsuario _myConnect, DataTable TbBlue, int SeqArquivo)
        {
            string ErroMessageInfo = "Erro não identificado";
            try
            {
                //string ErrorCdProduto = "";

                /* Var's */
                DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
                List<ParameterQuey> Parametros = new List<ParameterQuey>();


                /* Begin Command */
                x.Begin();

                /* SQL Command Clear Table*/
                // Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "DELETE")); 
                // x.Execute("SP_ParticipanteBluesoft", Parametros.ToArray());

                /* Limpa os parametros para um novo insert*/
                Parametros.Clear();

                /* SQL loop insert rows*/
                for (int i = 0; i <= TbBlue.Rows.Count - 1; i++)
                {

                    if (Convert.ToBoolean(TbBlue.Rows[i]["Valid"]))
                    {

                        Parametros.Clear();
                        ErroMessageInfo = "";
                        ErroMessageInfo = "Erro Importação de Entrada Codigo do item: " + TbBlue.Rows[i]["CdProdutoBlueSoft"]; //string.Format("Registro seq for (i): {0} | CdParticipante: {1}, Nome: {2} ", i.ToString(), TbBlue.Rows[i]["CdParticipanteBlueSoft"].ToString(), TbBlue.Rows[i]["Nome"].ToString());


                        //Data fields 
                        Parametros.Add(new ParameterQuey("Data", SqlDbType.SmallDateTime, false, DateTime.Now.ToShortDateString()));


                        //int fields 
                        Parametros.Add(new ParameterQuey("NumeroDocumentoFiscal", SqlDbType.Int, false, TbBlue.Rows[i]["NumeroDocumentoFiscal"].ToString()));
                        Parametros.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, false, TbBlue.Rows[i]["CdProdutoBlueSoft"].ToString()));
                        Parametros.Add(new ParameterQuey("SeqImportacao", SqlDbType.Int, false, SeqArquivo.ToString()));
                        Parametros.Add(new ParameterQuey("NumeroLinha", SqlDbType.Int, false, TbBlue.Rows[i]["NumeroLinha"].ToString()));
                        //Parametros.Add(new ParameterQuey("SeqImportacao", SqlDbType.Int, false, TbBlue.Rows[i]["SeqImportacao"].ToString()));

                        //chars fields 
                        Parametros.Add(new ParameterQuey("DescricaoImportacao", SqlDbType.VarChar, false, TbBlue.Rows[i]["DescricaoImportacao"].ToString()));
                        Parametros.Add(new ParameterQuey("CodigoBarra", SqlDbType.VarChar, false, TbBlue.Rows[i]["CodigoBarra"].ToString()));
                        Parametros.Add(new ParameterQuey("CFOP", SqlDbType.VarChar, false, TbBlue.Rows[i]["CFOP"].ToString()));

                        //decimals fields
                        Parametros.Add(new ParameterQuey("EmbalagemEstoqueQtde", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["EmbalagemEstoqueQtde"].ToString())));
                        Parametros.Add(new ParameterQuey("ValorCustoBruto", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ValorCustoBruto"].ToString())));
                        Parametros.Add(new ParameterQuey("ValorCustoLiquido", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ValorCustoLiquido"].ToString())));


                        //bit -int fields

                        //if (TbBlue.Rows[i]["ClienteStatus"].ToString().Trim() == "1")
                        //{
                        //    Parametros.Add(new ParameterQuey("ClienteStatus", SqlDbType.Bit, false, 1));
                        //}
                        //else
                        //{
                        //    Parametros.Add(new ParameterQuey("ClienteStatus", SqlDbType.Bit, false, 0));
                        //}

                        //Proc Execute
                        Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "UPDATE_ENTRADA"));
                        x.Execute("SP_ProdutoEstoqueCustoBlueSoft", Parametros.ToArray());
                    }


                }

                Parametros.Clear();

                /* Commit tran*/
                x.Commit();

                /* Close*/
                x.Close();

                return 0;
            }

            catch (Exception ex)
            {
                throw new Exception(ErroMessageInfo + ex.Message.ToString());
            }

        }
    }

    public static class Update
    {
        public static int Start(modelSistemaUsuario _myConnect)
        {
            /*Ajustes Gerais de Custos / Estoques*/
            DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
            List<ParameterQuey> Parametros = new List<ParameterQuey>();
            Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "UPDATE"));
            x.Execute("SP_ProdutoEstoqueCustoBlueSoft", Parametros.ToArray());
            return 0;
        }

    }

    public static class Update_Pag
    {
        public static int Start(modelSistemaUsuario _myConnect)
        {
            try
            {
                /*Ajustes Gerais de Custos / Estoques*/
                DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
                List<ParameterQuey> Parametros = new List<ParameterQuey>();
                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "UPDATE_IMPORT"));
                x.Execute("SP_ProdutoEstoqueCustoBlueSoft", Parametros.ToArray());
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Aplicação de Custos no Ambiente PAG" + ex.Message);
            }
        }

    }

    public static class Update_Target
    {
        public static int Start(modelSistemaUsuario _myConnect)
        {
            try
            {
                /*Ajustes Gerais de Custos / Estoques*/
                DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
                List<ParameterQuey> Parametros = new List<ParameterQuey>();
                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "UPDATE_TGT"));
                x.Execute("SP_ProdutoEstoqueCustoBlueSoft", Parametros.ToArray());
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Aplicação de Custos no Ambiente TARGET" + ex.Message);
            }
        }

    }

    public static class Select
    {

        public static DataTable List(modelSistemaUsuario _myConnect)
        {
            List<ParameterQuey> Parametros = new List<ParameterQuey>();
            Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "SELECT"));
            DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.DBAMAINADM, "SP_ProdutoEstoqueCustoBlueSoft", Parametros.ToArray());
            return DX.Tables[0];

        }

    }
}

namespace Pag_Net.Bll.BlueSoft
{

    /// <summary>
    /// Retorna um Datatable de Produtos da Base BlueSoft RedShift
    /// </summary>
    public static class TbRedshift_Produtos
    {
        public static DataTable Get(modelSistemaUsuario _myConnect, string CdProdutoKey, string DescricaoBlueSoft)
        {
            try
            {
                string SqlRedSHIFT = "SELECT        ISNULL(X.PRODUTO_KEY,0)                      AS  CdProdutoBlueSoft" +
                                     "           ,  X.DESCRICAO                                  AS  Descricao" +
                                     "           ,  X.GTIN_PRINCIPAL                             AS  CodigoBarraReferencia" +
                                     "           ,  X.EMBALAGEM_KEY                              AS  EmbalagemEstoque" +
                                     "           ,  ISNULL(X.PRODUTO_UNITARIO_KEY,0)             AS  CdProdutoBlueSoftUnitario" +
                                     "           ,  ISNULL(X.FATOR_ESTOQUE,1)                    AS  FatorEstoque" +
                                     "           ,  ISNULL(X.CONTROLE_ESTOQUE,0)                 AS  CdProdutoBlueSoftControleEstoque" +
                                     "           ,  ISNULL(X.PRECO_EQUIVALENTE,0)                AS  CdProdutoBlueSoftControlePreco" +
                                     "           ,  ISNULL(X.DEPARTAMENTO_KEY,0)                 AS  DepartamentoKey" +
                                     "           ,  ISNULL(X.SECAO_KEY,0)                        AS  SecaoKey" +
                                     "           ,  ISNULL(X.GRUPO_PRODUTO_KEY,0)                AS  GrupoProdutoKey" +
                                     "           ,  ISNULL(X.SUB_GRUPO_PRODUTO_KEY,0)            AS  SubGrupoKey" +
                                     "           ,  ISNULL(X.ULTIMA_ALTERACAO,'1900-01-01')      AS  DataUltimaAlteracao" +
                                     "           ,  ISNULL(x.DATA_CADASTRO,'1900-01-01')         AS  DataCadastro" +
                                     "           ,  ISNULL(X.FABRICANTE_KEY,0)                   AS  FabricanteKey" +
                                     "           ,  ISNULL(X.STATUS,0)                           AS  ProdutoStatus" +
                                     "           ,  ISNULL(X1.EMBALAGEM_KEY,X.EMBALAGEM_KEY)     AS  EmbalagemCompra " +
                                     "           ,  ISNULL(X1.FATOR_ESTOQUE,1)                   AS  EmbalagemCompraQtdeUnitaria " +
                                     "           ,  ISNULL(vx.VendaExterna,0)                    AS  VendaExterna " +
                                     " FROM         PRODUTO_D     X " +
                                     " LEFT JOIN    FORNECEDOR_PRODUTO           FP ON FP.FORNECEDOR_PRODUTO_KEY = X.FORNECEDOR_PRODUTO_PADRAO_KEY " +
                                     " LEFT JOIN    PRODUTO_D                    X1 ON X1.PRODUTO_KEY = FP.PRODUTO_KEY" +
                                     " LEFT JOIN    (   SELECT   produto_key            as CdProdutoBlueSoft " +
                                     "                         , convert(int, 1)        as VendaExterna " +
                                     "                  FROM     produto_loja_venda_externa   " +
                                     "                  GROUP BY Produto_key " +
                                     "              ) vx on vx.CdProdutoBlueSoft = ISNULL(X.PRODUTO_KEY,0) " +
                                     " WHERE        x.produto_key > 0 ";

                if (DescricaoBlueSoft.ToString() != "")
                {
                    SqlRedSHIFT = SqlRedSHIFT +
                                            "   AND         DESCRICAO LIKE '" + DescricaoBlueSoft.ToString() + "'";
                }


                if (CdProdutoKey != "")
                {

                    int CDProdutoINT = Convert.ToInt32(CdProdutoKey);

                    SqlRedSHIFT = SqlRedSHIFT +
                                            "   AND         PRODUTO_KEY = " + CDProdutoINT.ToString();
                }

                SqlRedSHIFT = SqlRedSHIFT + " ORDER BY DESCRICAO ASC ";


                /*Data Base BlueSoft RedShift*/
                DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}

/*--------------------------------------------------------------------------------------------------------------------------*/

namespace Pag_Net.Bll
{
    public class USPDataContext
    {

        private object[] _ViewData;
        public object[] ViewData
        {
            get
            {
                return _ViewData;
            }
            set
            {
                if (_ViewData != value)
                {
                    _ViewData = value;
                    this.OnPropertyChanged(this, new PropertyChangedEventArgs("Registros"));
                }
            }
        }
        public DataSet DataViews { get; set; }
        public DataTable DataTableResult { get; set; }
        private Models.modelSistemaUsuario _MyConnect;
        public event PropertyChangedEventHandler PropertyChanged;

        public USPDataContext(Models.modelSistemaUsuario _myConnect)
        {
            _MyConnect = _myConnect;
        }

        public void Select()
        {
            try
            {
                Select(DataBaseName.DBAMAINADM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void Select(DataBaseName Banco)
        {

            try
            {

                Models.ParameterQuey[] listParametros;
                listParametros = ListParametros();
                if (listParametros == null)
                {
                    listParametros = ListParametros(Models.Command.Select);
                }
                DataViews = Dal.DbSelect.GetDataSet(_MyConnect, Banco, SQLCommnad(), listParametros);
                DataTableResult = DataViews.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString() + "\n Comando executado: ");
            }

            //ViewData = Dados.Tables[0];
            //ViewData.DefaultView.AllowNew = false;

        }

        public void Insert()
        {
            Dal.DbUpdate DalUpdate = new DbUpdate(_MyConnect, DataBaseName.DBAMAINADM);
            DalUpdate.Begin();
            DalUpdate.Execute(SQLCommnad(), ListParametros(Models.Command.Insert));
            DalUpdate.Commit();
        }


        public void Update()
        {
            Dal.DbUpdate DalUpdate = new DbUpdate(_MyConnect, DataBaseName.DBAMAINADM);
            DalUpdate.Begin();
            DalUpdate.Execute(SQLCommnad(), ListParametros(Models.Command.Update));
            DalUpdate.Commit();
        }


        public void Delete()
        {
            Dal.DbUpdate DalUpdate = new DbUpdate(_MyConnect, DataBaseName.DBAMAINADM);
            DalUpdate.Begin();
            DalUpdate.Execute(SQLCommnad(), ListParametros(Models.Command.Delete));
            DalUpdate.Commit();
        }

        public virtual object GetParametros()
        {
            return null;
        }
        public virtual Models.ParameterQuey[] ListParametros()
        {
            return null;
        }

        public virtual Models.ParameterQuey[] ListParametros(Models.Command __command)
        {
            List<ParameterQuey> listParametro = new List<ParameterQuey>();
            if (GetParametros() != null)
            {
                object MyObject = GetParametros();
                Type myType = MyObject.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                foreach (PropertyInfo prop in props)
                {
                    //Console.WriteLine(prop.Name.ToString() + "-" + prop.GetValue(Parametros, null) + " - " + prop.PropertyType.Name);
                    if (prop.PropertyType.Name == "Int32") listParametro.Add(new ParameterQuey(prop.Name.ToString(), SqlDbType.Int, false, prop.GetValue(MyObject, null)));
                    if (prop.PropertyType.Name == "String") listParametro.Add(new ParameterQuey(prop.Name.ToString(), SqlDbType.VarChar, false, prop.GetValue(MyObject, null)));
                    if (prop.PropertyType.Name == "DateTime")
                    {
                        if (Convert.ToDateTime(prop.GetValue(MyObject, null)) == Convert.ToDateTime("01/01/0001"))
                        {
                            listParametro.Add(new ParameterQuey(prop.Name.ToString(), SqlDbType.Date, false, null));
                        }
                        else
                        {
                            listParametro.Add(new ParameterQuey(prop.Name.ToString(), SqlDbType.Date, false, prop.GetValue(MyObject, null)));
                        }
                    }
                    if (prop.PropertyType.Name == "Double") listParametro.Add(new ParameterQuey(prop.Name.ToString(), SqlDbType.Decimal, false, prop.GetValue(MyObject, null)));
                    if (prop.PropertyType.Name == "bool") listParametro.Add(new ParameterQuey(prop.Name.ToString(), SqlDbType.Bit, false, prop.GetValue(MyObject, null)));
                    if (prop.PropertyType.Name == "Boolean") listParametro.Add(new ParameterQuey(prop.Name.ToString(), SqlDbType.Bit, false, prop.GetValue(MyObject, null)));
                }
            }
            if (__command == Models.Command.Insert) listParametro.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "INSERT"));
            if (__command == Models.Command.Update) listParametro.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "UPDATE"));
            if (__command == Models.Command.Delete) listParametro.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "DELETE"));
            // if (__command == Models.Command.Select) listParametro.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "SELECT"));
            return listParametro.ToArray();
        }

        public virtual string SQLCommnad()
        {
            return null;
        }
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }


    }
    public class PRDataContext
    {
        public string ProcedureName { get; set; }

        private object[] _ViewData;
        public object[] ViewData
        {
            get
            {
                return _ViewData;
            }

            set
            {
                if (_ViewData != value)
                {
                    _ViewData = value;
                    this.OnPropertyChanged(this, new PropertyChangedEventArgs("Registros"));
                }
            }
        }
        public DataSet DataViews { get; set; }
        public DataTable DataTableResult { get; set; }
        private Models.modelSistemaUsuario _MyConnect;
        public event PropertyChangedEventHandler PropertyChanged;
        public PRDataContext(Models.modelSistemaUsuario _myConnect)
        {
            _MyConnect = _myConnect;
        }

        public void Select()
        {
            try
            {
                Select(DataBaseName.DBAMAINADM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void Select(DataBaseName Banco)
        {
            try
            {
                List<Models.ParameterQuey> Parametros = ListParametros().ToList();
                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "SELECT"));

                DataViews = Dal.DbSelect.GetDataSet(_MyConnect, Banco, SQLCommnad(), Parametros.ToArray());
                DataTableResult = DataViews.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            //ViewData = Dados.Tables[0];
            //ViewData.DefaultView.AllowNew = false;

        }

        public void Update()
        {
            Update(DataBaseName.DBAMAINADM);
        }
        public void Update(DataBaseName __banco)
        {
            try
            {
                Execute(__banco, "UPDATE");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Insert()
        {
            Insert(DataBaseName.DBAMAINADM);
        }
        public void Insert(DataBaseName __banco)
        {
            try
            {
                Execute(__banco, "INSERT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Execute(DataBaseName Banco, string __TipoExecucao)
        {
            try
            {

                List<Models.ParameterQuey> Parametros = ListParametros().ToList();
                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, __TipoExecucao));
                Dal.DbUpdate _Update = new DbUpdate(_MyConnect, Banco);
                _Update.Execute(SQLCommnad(), Parametros.ToArray());
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public virtual Models.ParameterQuey[] ListParametros()
        {
            return null;
        }
        public virtual string SQLCommnad()
        {
            return ProcedureName;
        }
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }

    }

    public static class Util
    {
        public static int TiposGetSeq(object itemSelected)
        {
            if (itemSelected == null)
            {
                return 0;
            }
            else
            {
                TbSysTbTipos x = (TbSysTbTipos)itemSelected;
                return x.SeqTipo;
            }
        }
        public static System.Data.DataTable TiposGetDataView(TbSysTbTipos[] __tipos, string __tabela, string __campo)
        {
            List<Models.TbSysTbTipos> list = TiposGet(__tipos, __tabela, __campo).ToList();
            DataTable table = new DataTable();
            table.Columns.Add("SeqTipo", typeof(int));
            table.Columns.Add("DescricaoTipo", typeof(string));
            table.Columns.Add("Campo", typeof(string));
            table.Columns.Add("Cd_Parametro", typeof(string));
            table.Columns.Add("ObservacaoTipo", typeof(string));
            table.Columns.Add("Tabela", typeof(string));
            table.Columns.Add("CdTipo", typeof(string));
            foreach (Models.TbSysTbTipos item in list)
            {
                DataRow row = table.NewRow();
                row["SeqTipo"] = Convert.ToInt32(item.SeqTipo.ToString());
                row["DescricaoTipo"] = item.DescricaoTipo.ToString();
                row["Campo"] = item.Campo.ToString();
                //row["Cd_Parametro"] = item.Cd_Parametro.ToString(); 
                row["CdTipo"] = item.CdTipo.ToString();
                //row["ObservacaoTipo"] = item.ObservacaoTipo.ToString();
                row["Tabela"] = item.Tabela.ToString();

                table.Rows.Add(row);
            }
            return table;
        }
        public static TbSysTbTipos[] TiposFill(modelSistemaUsuario __myConnect)
        {
            List<TbSysTbTipos> L = new List<TbSysTbTipos>();
            Pag_Net.Bll.Cadastros.UspTipos BLLTipos = new Cadastros.UspTipos(__myConnect);

            foreach (object item in BLLTipos.ViewData)
            {
                L.Add((Models.TbSysTbTipos)item);
            }
            return L.ToArray();
        }
        public static TbSysTbTipos[] TiposGet(TbSysTbTipos[] Tipos, string __tabela, string __campo)
        {
            List<TbSysTbTipos> L = new List<TbSysTbTipos>();
            int CountTipos = 0;
            foreach (TbSysTbTipos item in Tipos)
            {
                if (item.Campo.Trim().ToUpper() == __campo.Trim().ToUpper() && item.Tabela.Trim().ToUpper() == __tabela.Trim().ToUpper())
                {
                    CountTipos = CountTipos + 1;
                }
            }
            if (CountTipos > 1)
            {
                TbSysTbTipos TipoZero = new TbSysTbTipos();
                TipoZero.Campo = __campo;
                TipoZero.Tabela = __tabela;
                TipoZero.DescricaoTipo = "* TODOS";
                TipoZero.SeqTipo = 0;
                TipoZero.CdTipo = "";
                L.Add(TipoZero);
            }

            foreach (TbSysTbTipos item in Tipos)
            {
                if (item.Campo.Trim() == __campo.Trim() && item.Tabela.Trim() == __tabela.Trim())
                {
                    L.Add(item);

                }
            }


            return L.ToArray();


        }
        public static int TiposGetSeq(TbSysTbTipos[] Tipos, string __tabela, string __campo, string __cdtipo)
        {
            int SeqTipo = 0;
            foreach (TbSysTbTipos item in Tipos)
            {

                if (item.CdTipo.Trim() == __cdtipo.Trim() && item.Tabela.Trim() == __tabela && item.Campo.Trim() == __campo.Trim())
                {
                    SeqTipo = item.SeqTipo;

                }
            }

            return SeqTipo;

        }

        /*
        public static ModelTbOperacoes[] OperacoesFill(ModelSystemUserInfoConnect __myConnect)
        {
            List<ModelTbOperacoes> L = new List<ModelTbOperacoes>();
            Pag_Net.Bll.Cadastros.UspOperacoes BLLOperacoes = new Cadastros.UspOperacoes(__myConnect);
            foreach (object item in BLLOperacoes.ViewData)
            {
                L.Add((Models.ModelTbOperacoes)item);

            }
            return L.ToArray();
        }

        public static ModelTbOperacoes[] OperacoesGet(ModelTbOperacoes[] __operacoes, string __cdtipo, int __cdEmpresa)
        {
            List<ModelTbOperacoes> L = new List<ModelTbOperacoes>();
            foreach(ModelTbOperacoes item in __operacoes)
            {

                if ((__cdtipo != "" && item.CdTipo.Trim()  == __cdtipo.Trim()) || (__cdEmpresa > 0 && item.CdEmpresa == __cdEmpresa) )
                {
                    L.Add(item);
                }
                else
                {
                    L.Add(item);
                }

            }

            if (L.Count > 1)
            {
                ModelTbOperacoes l1 = new ModelTbOperacoes();
                l1.CdTipo = __cdtipo;
                l1.CdEmpresa = __cdEmpresa;
                l1.DescricaoTipoOperacao = "* Todos";
                l1.SeqTipoOperacao = 0;
                l1.CdOperacao = 0;
                L.Add(l1);

            }


            return L.ToArray();

        }
        */

        public static Nullable<Int32> ToDbInt32(string value)
        {
            int x = 0;
            if (value == "")
            {
                return null;
            }
            else if (!Int32.TryParse(value, out x))
            {
                throw new Exception("Valor inválido: " + value.ToString());
            }
            return x;
        }
        public static Nullable<DateTime> ToDbDateTime(string value)
        {
            DateTime x;
            if (value == "")
            {
                return null;
            }
            else if (!DateTime.TryParse(value, out x))
            {
                throw new Exception("valor inválido: " + value.ToString());
            }
            return x;


        }
        public static void ExportFileText(Models.ModelExportFile[] _ExportFile)
        {
            ExportFileText(_ExportFile, "");
        }
        public static void ExportFileText(Models.ModelExportFile[] _ExportFile, string _dirPath)
        {

            try
            {

                //LogFile LogFile = new LogFile();
                ArrayList _linhas = new ArrayList();
                int _count = _ExportFile.Count();
                int _seq = 0;
                string _NomeArquivo = _ExportFile[0].NomeArquivo.ToString().Trim();
                if (_dirPath.Trim().Length > 2)
                {
                    if (_dirPath.Substring(_dirPath.Length - 1, 1) != @"\")
                    {
                        _dirPath = _dirPath.Trim() + @"\";
                    }
                    if (!System.IO.Directory.Exists(_dirPath))
                    {
                        throw new Exception("Diretório para Exportação não acessível");
                    }
                }
                else
                {
                    _dirPath = "";
                }
                foreach (Models.ModelExportFile item in _ExportFile)
                {
                    _seq = _seq + 1;
                    _linhas.Add(item.Linha.Trim().ToString());
                    if (item.NomeArquivo.ToString().Trim() != _NomeArquivo || _seq == _count)
                    {
                        LogFile.Write(@_dirPath + _NomeArquivo, "", _linhas, FileMode.Create, FileAccess.ReadWrite);
                        _linhas.Clear();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bll - Export File: " + ex.Message.ToString());

            }

        }
        public static string GetValueParametro(modelSistemaUsuario _MyConnection, string _Parametro, string _FormularioMenu)
        {
            string Valor = "";
            foreach (Models.TbSysUserAccess x in _MyConnection.ListAccess)
            {
                if (x.DescParametro.Trim() == _Parametro.Trim() && x.Menu.Trim() == _FormularioMenu.Trim())
                {
                    Valor = x.Valor;
                }

            }
            return Valor;
        }
        public static string ErrorString(Exception _exception, string message)
        {
            return _exception.Source.ToString() + " - " + _exception.Message.ToString() + " - " + message.ToString();
        }
        public static Object[] AddItemList(Object[] _list, Object _item)
        {
            List<Object> x = new List<object>();
            if (_list != null)
            {
                x = _list.ToList(); ;
            }
            x.Add(_item);
            return x.ToArray();
        }
        public static bool IsInt(string _int)
        {
            try
            {
                int.Parse(_int);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsDouble(string _double)
        {
            try
            {
                Double.Parse(_double);
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
    public static class Operacoes
    {
        public static TbSysTbOperacoes[] Fill(modelSistemaUsuario __myConnect)
        {
            List<TbSysTbOperacoes> L = new List<TbSysTbOperacoes>();
            Pag_Net.Bll.Cadastros.UspOperacoes BLLOperacoes = new Cadastros.UspOperacoes(__myConnect);
            foreach (object item in BLLOperacoes.ViewData)
            {
                L.Add((Models.TbSysTbOperacoes)item);
            }
            return L.ToArray();
        }

        public static TbSysTbOperacoes[] Get(TbSysTbOperacoes[] __operacoes, string __formularioMenu)
        {
            try
            {
                List<TbSysTbOperacoes> L = new List<TbSysTbOperacoes>();

                int NumeroDeOperacoes = 0;

                foreach (TbSysTbOperacoes item in __operacoes)
                {
                    if (item.Menu.Trim() == __formularioMenu.ToString().Trim())
                        NumeroDeOperacoes = NumeroDeOperacoes + 1;
                }


                if (NumeroDeOperacoes == 0)
                {
                    string Message = "Você não possui acesso de Operações para esse formulário [Menu: " + __formularioMenu.ToString() + "]";
                    throw new Exception(Message);
                }


                if (NumeroDeOperacoes > 1)
                {
                    TbSysTbOperacoes l1 = new TbSysTbOperacoes();
                    l1.CdTipo = "";
                    l1.CdEmpresa = 0;
                    l1.DescricaoTipoOperacao = "* Todos";
                    l1.SeqTipoOperacao = 0;
                    l1.CdOperacao = 0;
                    L.Add(l1);
                }
                foreach (TbSysTbOperacoes item in __operacoes)
                {
                    if (item.Menu.Trim().ToUpper() == __formularioMenu.ToString().Trim().ToUpper())
                    {
                        L.Add(item);
                    }
                }

                return L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public static class PrCollectionSelect
    {
        public static DataTable Get(Pag_Net.Models.modelSistemaUsuario __myConnect, string __objeto)
        {
            DataSet DataViews;
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("Objeto", SqlDbType.VarChar, true, __objeto));
            DataViews = Dal.DbSelect.GetDataSet(__myConnect, DataBaseName.DBAMAINADM, "PRCollection", ListParameters.ToArray());
            return DataViews.Tables[0];
        }
    }
    public class bllWindowOpen
    {
        public modelSistemaUsuario MyConnect { get; set; }
        public string WindowType { get; set; }
        public string MenuClick { get; set; }
        public bllWindowOpen(modelSistemaUsuario myConnect, string menuClick, string windowType)
        {
            this.MyConnect = myConnect;
            this.WindowType = windowType.ToString();
            this.MenuClick = menuClick.ToString().ToUpper().Trim();

        }
        public void OpenPag(string pathexe)
        {
            try
            {

                //List<ModelSystemUserAccess> objlstMSystemUsrAccess = MyConnect.ListAccess.ToList();
                //ModelSystemUserAccess objMSystemUsrAccessSel = objlstMSystemUsrAccess.Find(delegate(ModelSystemUserAccess objMSystemUsrAccess) { return objMSystemUsrAccess.Menu == MenuClick.ToString(); });


                if (this.WindowType == "EXTERNAL")
                {
                    string strParPrgExterno = "";
                    string usr_pag = "";
                    string usr_moi = "";
                    string pws_pag = "";
                    string pws_moi = "";


                    TbSysDatabase ConnectionERP = dalConfig.GetConnection(this.MyConnect, DataBaseName.DATABASE_ERP);
                    TbSysDatabase ConnectionAUT = dalConfig.GetConnection(this.MyConnect, DataBaseName.DATABASE_AUT);

                    usr_pag = ConnectionAUT.UsrDataBase.ToString();
                    usr_moi = ConnectionERP.UsrDataBase.ToString();

                    pws_pag = ConnectionAUT.PwdDataBase.ToString();
                    pws_moi = ConnectionERP.PwdDataBase.ToString();


                    strParPrgExterno = usr_pag.Trim() + string.Concat(System.Collections.ArrayList.Repeat("@", 10 - usr_pag.Length).ToArray()); ;
                    strParPrgExterno += usr_moi.Trim() + string.Concat(System.Collections.ArrayList.Repeat("@", 10 - usr_moi.Length).ToArray()); ;
                    strParPrgExterno += pws_pag.Trim() + string.Concat(System.Collections.ArrayList.Repeat("@", 20 - pws_pag.Length).ToArray());
                    strParPrgExterno += pws_moi.Trim() + string.Concat(System.Collections.ArrayList.Repeat("@", 20 - pws_moi.Length).ToArray());
                    System.Diagnostics.Process.Start(@pathexe, strParPrgExterno + "@@FRMVND_GPORTO");


                }

            }

            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Open Windows" + ex.Message.ToString());
            }



        }








    }
    /*
    public class bllPackageConnection : TbSysUserInfo
    {
        public bllPackageConnection(string system_id, string user_id, string user_environment, string network, string user_password, string _FileXMLConnectionCrypt)
        {

            try
            {
                Cryptf PagToolCrypt = new Cryptf();
                //string XMLConnection = PagToolCrypt.FileDecryptToString(@_FileXMLConnectionCrypt, "00141722");
                string XMLConnection = PagToolCrypt.FileDecryptToString(@_FileXMLConnectionCrypt);

                dalUserAccess Acesso = new dalUserAccess();


                Pag_Net.Tools.CryptPassWord.Criptp cr = new Criptp(CryptProvider.TripleDES);
                //cr.Key = "141722P";

                string cryptpassword = cr.Encrypt(user_password);

                TbSysUserInfo MyConnection = Acesso.OpenUserAcess(system_id,
                                                                                user_environment,
                                                                                network,
                                                                                user_id,
                                                                                cryptpassword,
                                                                                XMLConnection);
                this.NetWork = network;
                this.System_id = system_id;
                this.User_id = user_id;
                this.User_environment = user_environment;
                this.User_password = user_password;
                this.ListAccess = MyConnection.ListAccess;
                this.ListConnections = MyConnection.ListConnections;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }

    }
    */
    
    public static class bllParameter
    {
        public static string blLogFileetValue(modelSistemaUsuario _MyConnection, string _systemid, string _descformproc, string _desctarefa, string _descparameter)
        {

            TbSysUserAccess[] x = _MyConnection.ListAccess;

            TbSysUserAccess ParameterSelect = Array.Find(x,
                element => element.System_Id == _systemid &
                           element.DescFormProc == _descformproc &
                           element.DescTarefa.TrimEnd() == _desctarefa &
                           element.DescParametro == _descparameter);
            if (ParameterSelect == null)
            {
                return null;
            }
            else
            {
                return ParameterSelect.Valor.ToString();
            }
        }

    }
       
    public class bllClientes
    {
        private modelSistemaUsuario myConnect;
        public bllClientes(modelSistemaUsuario MyConnect)
        {
            myConnect = MyConnect;
        }

        public TbClientes[] GetListClientes(int cd_clien,
                                                string nome,
                                                DateTime dt_cad_ini,
                                                DateTime dt_cad_fim)
        {
            try
            {

                DaClientes dalclsClientes = new DaClientes(myConnect);
                return dalclsClientes.GetList(cd_clien);


            }
            catch (Exception ex)
            {
                throw (new Exception("Erro na classe TBCLIENTES:" + ex.Message.ToString()));
            }
        }
    }
    public class bllServicesTime
    {
        private modelSistemaUsuario MyConnect;
        public bllServicesTime(modelSistemaUsuario myconnect)
        {
            MyConnect = myconnect;
        }
        public TbServicesTime[] GetListTbServicesTime(string _ServiceOwner)
        {
            string logerroservice = "Inicializando GetTbSERVICETIME";
            SqlCommand sqlcmdServicesTime = new SqlCommand("prServicesTime");
            sqlcmdServicesTime.CommandType = CommandType.StoredProcedure;
            sqlcmdServicesTime.Parameters.AddWithValue("@processo", "SELECT");
            sqlcmdServicesTime.Parameters.AddWithValue("@ServiceOwner", _ServiceOwner.Trim());
            try
            {
                logerroservice = "TryCatch - Criando connection";
                dalConnectX dalx = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, sqlcmdServicesTime, IsolationLevel.Unspecified);
                logerroservice = "TryCatch - executando";
                SqlDataReader sqlDRTbServicesTimes = dalx.SqlDataReader_Select();
                logerroservice = "TryCatch - list";
                List<TbServicesTime> lstModelTbServicesTime = new List<TbServicesTime>();

                //int intCount = Convert.ToInt32(sqlDRTbServicesTimes.RecordsAffected.ToString());

                //if (intCount > 0)
                //{
                logerroservice = "TryCatch - read";
                while (sqlDRTbServicesTimes.Read())
                {
                    lstModelTbServicesTime.Add(new TbServicesTime(sqlDRTbServicesTimes["serviceid"].ToString(),
                                                                       sqlDRTbServicesTimes["servicetimeid"].ToString(),
                                                                       sqlDRTbServicesTimes["dateini"].ToString(),
                                                                       sqlDRTbServicesTimes["datefim"].ToString(),
                                                                       sqlDRTbServicesTimes["hour"].ToString(),
                                                                       sqlDRTbServicesTimes["minute"].ToString(),
                                                                       sqlDRTbServicesTimes["second"].ToString(),
                                                                       sqlDRTbServicesTimes["weekday"].ToString(),
                                                                       sqlDRTbServicesTimes["ScriptSQL_BI_RedShiftImport"].ToString()));
                    logerroservice = "TryCatch - read-item";
                }
                //}
                logerroservice = "TryCatch - read-return";
                return lstModelTbServicesTime.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro GetTbServicesTime: " + ex.Message.ToString() + " Error point: " + logerroservice);
            }

        }
    }
    public class bllAcessList
    {
        public List<string> MyAccess(string _SystemId, string _UserId)
        {
            List<string> _MyAcess = new List<string>();
            tbSystemUserAccessList _AccessList = new tbSystemUserAccessList(_SystemId, _UserId);
            _MyAcess = _AccessList.AccessList();
            return _MyAcess;

        }
    }
    public class bllMailClassPagNet
    {
        public bool process(
            string _email_para)
        {
            SmtpClient client = new SmtpClient("smtp.uol.com.br");
            client.Credentials = new NetworkCredential("eliassilva@uol.com.br", "x130580");
            MailMessage message = new MailMessage("eliassilva@uol.com.br", _email_para);
            message.Subject = "TESTE";
            string _email_anexo = @"D:\Teste\JESUS.TXT";
            Attachment att = new Attachment(_email_anexo);
            message.Attachments.Add(att);
            client.Send(message);
            return true;
        }

    }
    public class bllInterfaceSystem : IDisposable
    {
        public string UserId { get; set; }
        public bllInterfaceSystem(string UserId)
        {
            this.UserId = UserId.ToString();
        }

        public ModelEnumTypeProcess tpProc;


        public void ExportFile_kimberly(string _FileName, string _path)
        {
            string Myfilepath = _path + _FileName + ".TXT";

            using (StreamWriter _MyFile = new StreamWriter(Myfilepath, false, Encoding.ASCII))
            {
                using (tbSystemInterface _dbInterfaceSystem = new tbSystemInterface(this.UserId))
                {

                    DataSet _MyListRecord = new DataSet();
                    _MyListRecord = _dbInterfaceSystem.ProcessKimberly(ModelEnumTypeProcess.Read, _FileName);
                    string linha = ""; int x = 0; int y = 0;
                    for (x = 0; x <= _MyListRecord.Tables[0].Rows.Count - 1; x++)
                    {
                        y = 1;
                        linha = "";
                        for (y = 1; y <= _MyListRecord.Tables[0].Columns.Count - 1; y++)
                        {
                            linha += _MyListRecord.Tables[0].Rows[x][y].ToString();
                        }
                        linha = linha.Replace("Á", "A");
                        linha = linha.Replace("É", "E");
                        linha = linha.Replace("Ó", "O");
                        linha = linha.Replace("&", "E");
                        linha = linha.Replace("Ç", "C");
                        linha = linha.Replace("'", " ");
                        linha = linha.Replace("Ã", "A");
                        linha = linha.Replace("Õ", "O");
                        linha = linha.Replace("Ô", "O");
                        linha = linha.Replace("*", " ");
                        linha = linha.Replace("Í", "I");
                        linha = linha.Replace("Ú", "U");
                        linha = linha.Replace("Ê", "E");
                        linha = linha.Replace("Â", "A");
                        _MyFile.WriteLine(linha);
                    }
                    _dbInterfaceSystem.ProcessKimberly(ModelEnumTypeProcess.Write, _FileName); /*Marca _FileName como processado*/
                }
                _MyFile.Close();
            }
        }
        public DataSet ListFilesKimberly()
        {
            using (tbSystemInterface _dbInterfaceSystem = new tbSystemInterface(this.UserId))
            {
                return _dbInterfaceSystem.ProcessKimberly(ModelEnumTypeProcess.List, "");
            }
        }
        ~bllInterfaceSystem() { }
        public void Dispose() { }
    }
    public class bllMarketingCli_AE : ModelMarketingCli_AE, IDisposable
    {
        private string getInterfaceMessage;
        public string GetInterfaceMessage { get { return getInterfaceMessage; } }
        public string UserId { get; set; }

        public bllMarketingCli_AE(string UserId)
        {
            this.UserId = UserId;
        }

        public bllMarketingCli_AE(string UserId, string Name, string Zip_code)
        {
            this.UserId = UserId;
            base.Name = Name;
            base.Fone_code = "";
            base.Fone_number = "";
            base.Zip_code = Zip_code;
            base.Sex = "";
            base.StatusMaritalDescription = "";
            base.E_mail = "";
            base.RemarkTypeDescription = "";
            base.Remark = "";

        }

        public bllMarketingCli_AE(string UserId,
                            string Name,
                            string Fone_code,
                            string Fone_number,
                            string Zip_code,
                            string Sex,
                            string StatusMaritalDescription,
                            string E_mail,
                            string RemarkTypeDescription,
                            string Remark)
            : base(Name, Fone_code, Fone_number, Zip_code, Sex, StatusMaritalDescription, E_mail, RemarkTypeDescription, Remark)
        {
            this.UserId = UserId;

        }

        public bool Insert()
        {
            tbMarketingCli_AE _myDbMarketing_Cli_AE = new tbMarketingCli_AE("ELIAS");

            if (this.Name == null)
            {
                getInterfaceMessage = "Favor preencher o campo Nome!";
                return false;
            }


            if (this.Zip_code == null)
            {
                getInterfaceMessage = "FAVOR PREENCHER O CAMPO CEP!";
                return false;
            }

            try
            {
                /*
                _myDbMarketing_Cli_AE.Insert(new MarketingCli_AE(this.Name.ToString(),
                                                                 this.Fone_code.ToString(),
                                                                 this.Fone_number.ToString(),
                                                                 this.Zip_code.ToString(),
                                                                 this.Sex.ToString(),
                                                                 this.StatusMaritalDescription.ToString(),
                                                                 this.E_mail.ToString(),
                                                                 this.RemarkTypeDescription.ToString(),
                                                                 this.Remark.ToString()));*/
                if (_myDbMarketing_Cli_AE.Insert(this))
                {
                    getInterfaceMessage = "Seu cadastro foi efetuado com sucesso!";
                    return true;
                }
                else
                {
                    getInterfaceMessage = "Erro não identificado";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message.ToString());
            }

        }
        ~bllMarketingCli_AE() { }
        public void Dispose() { }
    }
    public class Encrypt
    {
        public string EncryptString(string StringToEncrypt)
        {
            Pag_Net.Tools.CryptPassWord.Criptp x = new Criptp(CryptProvider.TripleDES);
            return x.Encrypt(StringToEncrypt);
        }
    }
    public class Contratos : Bll.USPDataContext
    {
        public string DESCRICAO_CONTRATO = "";
        public Contratos(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {

        }
        public void Reflesh()
        {
            base.Select();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> pList = new List<ParameterQuey>();
            pList.Add(new ParameterQuey("@Command", System.Data.SqlDbType.VarChar, false, "SELECT"));
            pList.Add(new ParameterQuey("@DESCRICAO", System.Data.SqlDbType.VarChar, false, DESCRICAO_CONTRATO));
            return pList.ToArray();
        }


        public override object GetParametros()
        {
            return null;
        }
        public override string SQLCommnad()
        {
            return "SP_Contrato";
        }


    }




}

namespace Pag_Net.Bll.IFs
{

    public static class IF0017
    {
        public static int Start(modelSistemaUsuario _myConnect)
        {
            /*Ajustes Gerais de Custos / Estoques*/
            DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
            List<ParameterQuey> Parametros = new List<ParameterQuey>();
            x.Execute("SP_Notificacao_IF0017", Parametros.ToArray());
            return 0;
        }

    }
}



namespace Pag_Net.Bll.Participante
{
    public static class List
    {

        public static DataTable Start(modelSistemaUsuario MyConnect, string FilterTipoParticipante)
        {
            try
            {
                List<ParameterQuey> ListParamter = new List<ParameterQuey>();
                ListParamter.Add(new ParameterQuey("COMMAND", System.Data.SqlDbType.VarChar, true, "SELECT"));

                ListParamter.Add(new ParameterQuey("TIPO", System.Data.SqlDbType.VarChar, true, FilterTipoParticipante));

                DataSet DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, "SP_Participante", ListParamter.ToArray());
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Participante.List: " + ex.Message.ToString());
            }
        }
    }
    public static class BlueSoft_Select
    {

        public static DataTable List(modelSistemaUsuario _myConnect)
        {

            return List(_myConnect, "");
        }
        public static DataTable List(modelSistemaUsuario _myConnect, string _NOME)
        {
            try
            {


                //Alteração em 26/08/2020 Pag_1.01.09 - Script SQL

                string SqlRedSHIFT = "  SELECT        PS.PESSOA_KEY                         AS CdParticipanteBlueSoft " +
                                     "            ,   PS.NOME_RAZAO                         AS Nome " +
                                     "            ,   PS.CPF_CNPJ                           AS CNPJCPF " +
                                     "            ,   PS.ENDERECO_RUA                       AS EnderecoRua " +
                                     "            ,   PS.ENDERECO_NUMERO                    AS EnderecoNumero " +
                                     "            ,   PS.ENDERECO_COMPLEMENTO               AS EnderecoComplemento " +
                                     "            ,   PS.BAIRRO                             AS Bairro " +
                                     "            ,   PS.MUNICIPIO                          AS Municipio " +
                                     "            ,   PS.ESTADO_SIGLA                       AS Estado " +
                                     "            ,   convert(varchar(8), isnull(PS.CEP,0)) AS CEP " +
                                     "            ,   isnull(PS.LATITUDE,0.00)              AS Latitude " +
                                     "            ,   isnull(PS.LONGITUDE,0.00)             AS Longitude " +
                                     "            ,   PS.EMAIL_COMERCIAL                    AS Email " +
                                     "            ,   PS.USER_NAME                          AS UsuarioLogin " +
                                     "            ,   CASE WHEN FN.PESSOA_KEY > 0 THEN 1 ELSE 0 END " +
                                     "                                                      AS Fornecedor " +
                                     "            ,   isnull(CL.GRUPO_ECONOMICO_KEY,0)      AS ClienteGrupoEconomicoKey " +
                                     "            ,   CL.GRUPO_ECONOMICO_MATRIZ             AS ClienteGrupoEconomicoMatriz " +
                                     "            ,   CL.VENDEDOR_CNPJ                      AS ClienteVendedorCNPJ " +
                                     "            ,   CL.GRUPO_ECONOMICO                    AS ClienteGrupoEconomico " +
                                     "            ,   CASE WHEN CL.CLIENTE_STATUS = 'ATIVO' THEN 1 ELSE 0 END  " +
                                     "                                                      AS ClienteStatus " +
                                     "            ,   isnull(CL.CLIENTE_CREDITO_LIMITE,0.00) " +
                                     "                                                      AS ClienteLimiteCredito " +
                                     "            ,   CASE WHEN lx.PESSOA_KEY > 0 THEN 1 ELSE 0 END " +
                                     "                                                      AS CLiente " +
                                     "            ,   case when isnull(xf.pessoa_key,0) <> 0 then 1 else 0 END as FABRICANTE " +
                                     "   FROM      PESSOA                PS " +
                                     "   LEFT JOIN (     SELECT    PESSOA_KEY       AS PESSOA_KEY " +
                                     "                   FROM      FORNECEDOR_DADOS " +
                                     "                   GROUP BY  PESSOA_KEY " +
                                     "             ) FN ON FN.PESSOA_KEY = PS.PESSOA_KEY " +
                                     "  LEFT JOIN (     SELECT       GR.GRUPO_ECONOMICO_KEY        AS GRUPO_ECONOMICO_KEY " +
                                     "                          ,    GR.MATRIZ                     AS GRUPO_ECONOMICO_MATRIZ " +
                                     "                          ,    GR.CLIENTE_KEY                AS CLIENTE_KEY " +
                                     "                          ,    CL.NOME_RAZAO                 AS CLIENTE_NOME_RAZAO " +
                                     "                          ,    VE.CPF_CNPJ                   AS VENDEDOR_CNPJ " +
                                     "                          ,    VE.NOME_RAZAO                 AS VENDEDOR " +
                                     "                          ,    GE.DESCRICAO                  AS GRUPO_ECONOMICO " +
                                     "                          ,    CX.STATUS                     AS CLIENTE_STATUS " +
                                     "                          ,    CX.CREDITO_LIMITE             AS CLIENTE_CREDITO_LIMITE " +
                                     "                   FROM        CLIENTE_GRUPO_ECONOMICO       GR " +
                                     "                   INNER JOIN ( SELECT    MAX(X.VENDEDOR_EXTERNO_KEY)      AS VENDEDOR_EXTERNO_KEY " +
                                     "                                       ,  X.CLIENTE_GRUPO_ECONOMICO_KEY    AS CLIENTE_GRUPO_ECONOMICO_KEY  " + 
                                     "                                       ,  X.GRUPO_ECONOMICO_KEY            AS GRUPO_ECONOMICO_KEY " +
                                     "                                FROM      GRUPO_ECONOMICO_COMISSAO   X " +
                                     "                                GROUP BY  X.GRUPO_ECONOMICO_KEY " +
                                     "                                      ,   X.CLIENTE_GRUPO_ECONOMICO_KEY " + 
                                     "                               )                GX ON GX.GRUPO_ECONOMICO_KEY      = GR.GRUPO_ECONOMICO_KEY " +
                                     "                                                  AND GX.CLIENTE_GRUPO_ECONOMICO_KEY = GR.CLIENTE_GRUPO_ECONOMICO_KEY " + 
                                     "                   INNER JOIN  PESSOA           CL ON CL.PESSOA_KEY               = GR.CLIENTE_KEY " +
                                     "                   INNER JOIN  PESSOA           VE ON VE.PESSOA_KEY               = GX.VENDEDOR_EXTERNO_KEY " +
                                     "                   INNER JOIN  CLIENTE          CX ON CX.PESSOA_KEY               = CL.PESSOA_KEY " +
                                     "                   INNER JOIN  GRUPO_ECONOMICO  GE ON GE.GRUPO_ECONOMICO_KEY      = GR.GRUPO_ECONOMICO_KEY  " +
                                     "             ) CL ON CL.CLIENTE_KEY = PS.PESSOA_KEY " +
                                     "  LEFT JOIN (  select XL.PESSOA_KEY AS Pessoa_Key from cliente XL GROUP BY XL.PESSOA_kEY) LX ON LX.pessoa_key = ps.pessoa_key " +
                                     "  left join ( select fornecedor_key as pessoa_key from fornecedor_produto group by fornecedor_key ) xf on xf.pessoa_key = ps.pessoa_key " +
                                     "  WHERE PS.PESSOA_KEY > 0 ";
                if (_NOME != "")
                {
                    SqlRedSHIFT += " AND NOME LIKE '%" + _NOME.Replace("'", "").TrimStart().TrimEnd() + "%'";
                }

                SqlRedSHIFT = SqlRedSHIFT + " ORDER BY  NOME_RAZAO ASC ";

                DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
    public static class BlueSoft_Import
    {

        public static int Start(modelSistemaUsuario _myConnect)
        {
            try
            {
                /* Get datatable redshift */
                DataTable TbBlue = Pag_Net.Bll.Participante.BlueSoft_Select.List(_myConnect);


                /* Var's */
                DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
                List<ParameterQuey> Parametros = new List<ParameterQuey>();
                string ErroMessageInfo = "Erro não identificado";

                /* Begin Command */
                x.Begin();

                /* SQL Command Clear Table*/
                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "DELETE"));
                x.Execute("SP_ParticipanteBluesoft", Parametros.ToArray());

                /* Limpa os parametros para um novo insert*/
                Parametros.Clear();

                /* SQL loop insert rows*/
                for (int i = 0; i <= TbBlue.Rows.Count - 1; i++)
                {
                    Parametros.Clear();
                    ErroMessageInfo = string.Format("Registro seq for (i): {0} | CdParticipante: {1}, Nome: {2} ", i.ToString(), TbBlue.Rows[i]["CdParticipanteBlueSoft"].ToString(), TbBlue.Rows[i]["Nome"].ToString());
                    //int fields 
                    Parametros.Add(new ParameterQuey("CdParticipanteBlueSoft", SqlDbType.Int, false, TbBlue.Rows[i]["CdParticipanteBlueSoft"].ToString()));
                    Parametros.Add(new ParameterQuey("ClienteGrupoEconomicoKey", SqlDbType.Int, false, TbBlue.Rows[i]["ClienteGrupoEconomicoKey"].ToString()));
                    //chars fields 
                    Parametros.Add(new ParameterQuey("Nome", SqlDbType.VarChar, false, TbBlue.Rows[i]["Nome"].ToString()));
                    Parametros.Add(new ParameterQuey("CNPJCPF", SqlDbType.VarChar, false, TbBlue.Rows[i]["CNPJCPF"].ToString()));
                    Parametros.Add(new ParameterQuey("EnderecoRua", SqlDbType.VarChar, false, TbBlue.Rows[i]["EnderecoRua"].ToString()));
                    Parametros.Add(new ParameterQuey("EnderecoNumero", SqlDbType.VarChar, false, TbBlue.Rows[i]["EnderecoNumero"].ToString()));
                    Parametros.Add(new ParameterQuey("EnderecoComplemento", SqlDbType.VarChar, false, TbBlue.Rows[i]["EnderecoComplemento"].ToString()));
                    Parametros.Add(new ParameterQuey("Bairro", SqlDbType.VarChar, false, TbBlue.Rows[i]["Bairro"].ToString()));
                    Parametros.Add(new ParameterQuey("Municipio", SqlDbType.VarChar, false, TbBlue.Rows[i]["Municipio"].ToString()));
                    Parametros.Add(new ParameterQuey("Estado", SqlDbType.VarChar, false, TbBlue.Rows[i]["Estado"].ToString()));
                    Parametros.Add(new ParameterQuey("CEP", SqlDbType.VarChar, false, TbBlue.Rows[i]["CEP"].ToString()));
                    Parametros.Add(new ParameterQuey("email", SqlDbType.VarChar, false, TbBlue.Rows[i]["email"].ToString()));
                    Parametros.Add(new ParameterQuey("UsuarioLogin", SqlDbType.VarChar, false, TbBlue.Rows[i]["UsuarioLogin"].ToString()));
                    Parametros.Add(new ParameterQuey("ClienteVendedorCNPJ", SqlDbType.VarChar, false, TbBlue.Rows[i]["ClienteVendedorCNPJ"].ToString()));
                    Parametros.Add(new ParameterQuey("ClienteGrupoEconomico", SqlDbType.VarChar, false, TbBlue.Rows[i]["ClienteGrupoEconomico"].ToString()));

                    //decimals fields
                    Parametros.Add(new ParameterQuey("Latitude", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["Latitude"].ToString())));
                    Parametros.Add(new ParameterQuey("Longitude", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["Longitude"].ToString())));

                    //bit -int fields


                    if (TbBlue.Rows[i]["Fabricante"].ToString().Trim() == "1")
                    {
                        Parametros.Add(new ParameterQuey("@Fabricante", SqlDbType.Bit, false, 1));
                    }
                    else
                    {
                        Parametros.Add(new ParameterQuey("@Fabricante", SqlDbType.Bit, false, 0));
                    }

                    if (TbBlue.Rows[i]["ClienteStatus"].ToString().Trim() == "1")
                    {
                        Parametros.Add(new ParameterQuey("ClienteStatus", SqlDbType.Bit, false, 1));
                    }
                    else
                    {
                        Parametros.Add(new ParameterQuey("ClienteStatus", SqlDbType.Bit, false, 0));
                    }

                    if (TbBlue.Rows[i]["Fornecedor"].ToString().Trim() == "1")
                    {
                        Parametros.Add(new ParameterQuey("Fornecedor", SqlDbType.Bit, false, 1));
                    }
                    else
                    {
                        Parametros.Add(new ParameterQuey("Fornecedor", SqlDbType.Bit, false, 0));
                    }

                    if (TbBlue.Rows[i]["Cliente"].ToString().Trim() == "1")
                    {
                        Parametros.Add(new ParameterQuey("Cliente", SqlDbType.Bit, false, 1));
                    }
                    else
                    {
                        Parametros.Add(new ParameterQuey("Cliente", SqlDbType.Bit, false, 0));
                    }

                    if (TbBlue.Rows[i]["ClienteGrupoEconomicoMatriz"].ToString().Trim() == "1")
                    {
                        Parametros.Add(new ParameterQuey("ClienteGrupoEconomicoMatriz", SqlDbType.Bit, false, 1));
                    }
                    else
                    {
                        Parametros.Add(new ParameterQuey("ClienteGrupoEconomicoMatriz", SqlDbType.Bit, false, 0));
                    }

                    //Numeric Fileds
                    Parametros.Add(new ParameterQuey("ClienteLimiteCredito", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ClienteLimiteCredito"].ToString())));

                    //Proc Execute
                    Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "INSERT"));

                    x.Execute("SP_ParticipanteBluesoft", Parametros.ToArray());
                }

                /* Commit tran*/
                x.Commit();

                /* Close*/
                x.Close();


                return 0;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }
}

namespace Pag_Net.Bll.Produto_OLD
{
    public class List
    {

        public int FilterCdProduto;
        public string FilterCdProdutoList;
        public string FilterCdProdutoBlueSoftList;
        public string FilterCdProdutoTargettList;
        public string FilterDescricao = "";
        public string FilterStatusProduto = "";
        public string FilterCodigoBarraAssociado = "";
        public string FilterCdProdutoLista;

        public modelSistemaUsuario MyConnect;

        public List(modelSistemaUsuario _MyConnect)
        {

            MyConnect = _MyConnect;
        }

        public DataTable Start()
        {
            try
            {
                List<ParameterQuey> ListParamter = new List<ParameterQuey>();
                ListParamter.Add(new ParameterQuey("COMMAND", System.Data.SqlDbType.VarChar, true, "SELECT"));

                ListParamter.Add(new ParameterQuey("SELECT_CDPRODUTO", System.Data.SqlDbType.Int, true, FilterCdProduto));

                ListParamter.Add(new ParameterQuey("SELECT_CDPRODUTOLIST", System.Data.SqlDbType.VarChar, true, FilterCdProdutoList));
                ListParamter.Add(new ParameterQuey("SELECT_CDPRODUTOBLUESOFTLIST", System.Data.SqlDbType.VarChar, true, FilterCdProdutoBlueSoftList));


                ListParamter.Add(new ParameterQuey("SELECT_DESCRICAO", System.Data.SqlDbType.VarChar, true, FilterDescricao.ToString()));
                ListParamter.Add(new ParameterQuey("SELECT_STATUSPRODUTO", System.Data.SqlDbType.VarChar, true, FilterStatusProduto.ToString()));
                ListParamter.Add(new ParameterQuey("SELECT_CodigoBarraAssociado", System.Data.SqlDbType.VarChar, true, FilterCodigoBarraAssociado));
                DataSet DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, "SP_PRODUTO", ListParamter.ToArray());
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Produto.List: " + ex.Message.ToString());
            }
        }
    }
    public static class Update
    {
        public static string Start(modelSistemaUsuario _myConnect)
        {

            try
            {

                List<ParameterQuey> Parametros = new List<ParameterQuey>();

                DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
                x.Begin();

                /* Exclui todos os itens */
                Parametros.Clear();
                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "UPDATE_BASE"));
                x.Execute("sp_Produto", Parametros.ToArray());
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO Pag-Net.Bll.Produto.Update: " + ex.Message);

            }

        }
    }
    public class CodigoBarra
    {
        public int FilterCdProduto;
        public modelSistemaUsuario MyConnect;
        public CodigoBarra(modelSistemaUsuario _MyConnect)
        {

            MyConnect = _MyConnect;
        }

        public DataTable Start()
        {
            try
            {
                List<ParameterQuey> ListParamter = new List<ParameterQuey>();
                ListParamter.Add(new ParameterQuey("COMMAND", System.Data.SqlDbType.VarChar, true, "SELECT_CDBARRA"));
                ListParamter.Add(new ParameterQuey("SELECT_CDPRODUTO", System.Data.SqlDbType.Int, true, FilterCdProduto));
                DataSet DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, "SP_PRODUTO", ListParamter.ToArray());
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Produto.List: " + ex.Message.ToString());
            }
        }

    }
    public class Embalagens
    {
        public int FilterCdProduto;
        public modelSistemaUsuario MyConnect;
        public Embalagens(modelSistemaUsuario _MyConnect)
        {

            MyConnect = _MyConnect;
        }

        public DataTable Start()
        {
            try
            {
                List<ParameterQuey> ListParamter = new List<ParameterQuey>();
                ListParamter.Add(new ParameterQuey("COMMAND", System.Data.SqlDbType.VarChar, true, "SELECT_EMBAL"));
                ListParamter.Add(new ParameterQuey("SELECT_CDPRODUTO", System.Data.SqlDbType.Int, true, FilterCdProduto));
                DataSet DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, "SP_PRODUTO", ListParamter.ToArray());
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Produto.List: " + ex.Message.ToString());
            }
        }

    }
    public static class BlueSoft_Select
    {
        public static DataTable List(modelSistemaUsuario _myConnect, string CdProdutoKey, string DescricaoBlueSoft)
        {
            try
            {
                string SqlRedSHIFT = "SELECT        ISNULL(X.PRODUTO_KEY,0)                      AS  CdProdutoBlueSoft" +
                                     "           ,  X.DESCRICAO                                  AS  Descricao" +
                                     "           ,  X.GTIN_PRINCIPAL                             AS  CodigoBarraReferencia" +
                                     "           ,  X.EMBALAGEM_KEY                              AS  EmbalagemEstoque" +
                                     "           ,  ISNULL(X.PRODUTO_UNITARIO_KEY,0)             AS  CdProdutoBlueSoftUnitario" +
                                     "           ,  ISNULL(X.FATOR_ESTOQUE,1)                    AS  FatorEstoque" +
                                     "           ,  ISNULL(X.CONTROLE_ESTOQUE,0)                 AS  CdProdutoBlueSoftControleEstoque" +
                                     "           ,  ISNULL(X.PRECO_EQUIVALENTE,0)                AS  CdProdutoBlueSoftControlePreco" +
                                     "           ,  ISNULL(X.DEPARTAMENTO_KEY,0)                 AS  DepartamentoKey" +
                                     "           ,  ISNULL(X.SECAO_KEY,0)                        AS  SecaoKey" +
                                     "           ,  ISNULL(X.GRUPO_PRODUTO_KEY,0)                AS  GrupoProdutoKey" +
                                     "           ,  ISNULL(X.SUB_GRUPO_PRODUTO_KEY,0)            AS  SubGrupoKey" +
                                     "           ,  ISNULL(X.ULTIMA_ALTERACAO,'1900-01-01')      AS  DataUltimaAlteracao" +
                                     "           ,  ISNULL(x.DATA_CADASTRO,'1900-01-01')         AS  DataCadastro" +
                                     "           ,  ISNULL(X.FABRICANTE_KEY,0)                   AS  FabricanteKey" +
                                     "           ,  ISNULL(X.STATUS,0)                           AS  ProdutoStatus" +
                                     "           ,  ISNULL(X1.EMBALAGEM_KEY,X.EMBALAGEM_KEY)     AS  EmbalagemCompra " +
                                     "           ,  ISNULL(X1.FATOR_ESTOQUE,1)                   AS  EmbalagemCompraQtdeUnitaria " +
                                     "           ,  ISNULL(vx.VendaExterna,0)                    AS  VendaExterna " +
                                     " FROM         PRODUTO_D     X " +
                                     " LEFT JOIN    FORNECEDOR_PRODUTO           FP ON FP.FORNECEDOR_PRODUTO_KEY = X.FORNECEDOR_PRODUTO_PADRAO_KEY " +
                                     " LEFT JOIN    PRODUTO_D                    X1 ON X1.PRODUTO_KEY = FP.PRODUTO_KEY" +
                                     " LEFT JOIN    (   SELECT   produto_key            as CdProdutoBlueSoft " +
                                     "                         , convert(int, 1)        as VendaExterna " +
                                     "                  FROM     produto_loja_venda_externa   " +
                                     "                  GROUP BY Produto_key " +
                                     "              ) vx on vx.CdProdutoBlueSoft = ISNULL(X.PRODUTO_KEY,0) " +
                                     " WHERE        x.produto_key > 0 ";

                if (DescricaoBlueSoft.ToString() != "")
                {
                    SqlRedSHIFT = SqlRedSHIFT +
                                            "   AND         DESCRICAO LIKE '" + DescricaoBlueSoft.ToString() + "'";
                }


                if (CdProdutoKey != "")
                {

                    int CDProdutoINT = Convert.ToInt32(CdProdutoKey);

                    SqlRedSHIFT = SqlRedSHIFT +
                                            "   AND         PRODUTO_KEY = " + CDProdutoINT.ToString();
                }

                SqlRedSHIFT = SqlRedSHIFT + " ORDER BY DESCRICAO ASC ";


                /*Data Base BlueSoft RedShift*/
                DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
    public static class BlueSoft_Select_CodigoBarra
    {
        public static DataTable List(modelSistemaUsuario _myConnect, int CdProdutoKeyUnitarioKey)
        {
            try
            {
                string SqlRedSHIFT = "SELECT    p.produto_key             CdProdutoBlueSoft " +
                                     "        , p.descricao               EmbalagemProdutoDescricao " +
                                     "        , p.fator_estoque           EmbalagemProdutoFator_Estoque " +
                                     "        , i.barra_key               CodigoBarra " +
                                     "        , e.embalagem_key           Embalagem " +
                                     "        , e.nome                    EmbalagemDescricao " +
                                     "        , p.status                  statusproduto " +
                                     "        , CASE WHEN len(i.barra_key) = 8  THEN 'EAN8' " +
                                     "               WHEN len(i.barra_key) = 13 THEN 'EAN13' " +
                                     "               WHEN len(i.barra_key) = 14 THEN 'DUN14' " +
                                     "               ELSE 'PLU' " +
                                     "          END tipo " +
                                     "          FROM item i  " +
                                     " left JOIN produto_d p on i.produto_key = p.produto_key " +
                                     " left JOIN embalagem e ON e.embalagem_key = p.embalagem_key " +
                                     " WHERE p.produto_key > 0 ";

                if (CdProdutoKeyUnitarioKey > 0)
                {
                    SqlRedSHIFT = SqlRedSHIFT + " AND produto_unitario_key = " + CdProdutoKeyUnitarioKey.ToString();
                }

                SqlRedSHIFT = SqlRedSHIFT + " ORDER BY  CODIGOBARRA ASC ";

                DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
    public static class BlueSoft_Select_Tributacao
    {
        public static DataTable List(modelSistemaUsuario _myConnect, int CdProdutoKey)
        {
            try
            {
                string SqlRedSHIFT = "SELECT        X.PRODUTO_KEY                     AS CDPRODUTOBLUESOFT " +
                                      "         ,   PISE.CST_PIS_COFINS_KEY           AS PIS_ENTRADA_CST " +
                                      "         ,   ISNULL(PISE.ALIQUOTA,0)           AS PIS_ENTRADA_ALIQUOTA " +
                                      "         ,   PISS.CST_PIS_COFINS_KEY           AS PIS_SAIDA_CST         " +
                                      "         ,   ISNULL(PISS.ALIQUOTA,0)           AS PIS_SAIDA_ALIQUOTA " +
                                      "         ,   COFE.CST_PIS_COFINS_KEY           AS COFINS_ENTRADA_CST " +
                                      "         ,   ISNULL(COFE.ALIQUOTA,0)           AS COFINS_ENTRADA_ALIQUOTA " +
                                      "         ,   COFS.CST_PIS_COFINS_KEY           AS COFINS_SAIDA_CST " +
                                      "         ,   ISNULL(COFS.ALIQUOTA,0)           AS COFINS_SAIDA_ALIQUOTA " +
                                      "         ,   ISNULL(FX.ALIQUOTA_INTERNA,0)     AS ICMS_ALIQUOTA_INTERNA " +
                                      "         ,   ICM_SAIDA.CODIGO_TRIBUTACAO       AS ICMS_SAIDA_CST " +
                                      "         ,   ICM_ENTRADA.CODIGO_TRIBUTACAO     AS ICMS_ENTRADA_CST " +
                                      "         ,   CLAS.NCM                          AS NCM " +
                                      "         ,   CEST.codigo                       AS CEST " +
                                      "         ,   FX.IVA_ST                         AS ST_IVA  " +
                                      " FROM        PRODUTO_D                       X " +
                                      " INNER JOIN  FIGURA_FISCAL_ESTADUAL          FX          ON FX.PRODUTO_KEY = X.PRODUTO_KEY AND FX.ESTADO_SIGLA = 'SP' " +
                                      " INNER JOIN  ICM                             ICM_SAIDA   ON ICM_SAIDA.ICM_KEY = FX.ICM_KEY  " +
                                      " INNER JOIN  ICM                             ICM_ENTRADA ON ICM_ENTRADA.ICM_KEY = FX.icm_entrada_key  " +
                                      " INNER JOIN  PIS                             PISS        ON PISS.PIS_KEY = X.PIS_KEY  " +
                                      " INNER JOIN  PIS                             PISE        ON PISE.PIS_KEY = X.PIS_ENTRADA_KEY  " +
                                      " INNER JOIN  COFINS                          COFS        ON COFS.COFINS_KEY = X.COFINS_KEY " +
                                      " INNER JOIN  COFINS                          COFE        ON COFE.COFINS_KEY = X.COFINS_ENTRADA_KEY " +
                                      " INNER JOIN  CLASSIFICACAO_FISCAL            CLAS        ON CLAS.CLASSIFICACAO_FISCAL_KEY = X.CLASSIFICACAO_FISCAL_KEY " +
                                      " LEFT  JOIN  CEST                            CEST        ON CEST.CEST_KEY = X.CEST_KEY  " +
                                      " WHERE x.produto_key > 0 " +
                                      " order by x.produto_key asc ";


                if (CdProdutoKey > 0)
                {
                    SqlRedSHIFT = SqlRedSHIFT + " x.AND produto_unitario_key = " + CdProdutoKey.ToString();
                }

                DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
    public static class BlueSoft_Select_Categoria
    {
        public static DataTable List(modelSistemaUsuario _myConnect)
        {
            try
            {
                string SqlRedSHIFT = "SELECT         DEPARTAMENTO_KEY        as DepartamentoKey  " +
                                     "           ,   DEPARTAMENTO            as DepartamentoDescricao " +
                                     "           ,   SECAO_KEY               as SecaoKey " +
                                     "           ,   SECAO                   as SecaoDescricao " +
                                     "           ,   GRUPO_PRODUTO_KEY       as GrupoKey " +
                                     "           ,   GRUPO                   as GrupoDescricao " +
                                     "           ,   SUB_GRUPO_PRODUTO_KEY   as SubGrupoKey " +
                                     "           ,   SUBGRUPO                as SubGrupoDescricao " +
                                     "           FROM        PRODUTO_D " +
                                     "           WHERE       departamentokey > 0 " +
                                     "             and       secaokey > 0 " +
                                     "             and       grupo_produto_key > 0 " +
                                     "             and       grupo > 0 " +
                                     "           GROUP BY       DEPARTAMENTO_KEY " +
                                     "                      ,   DEPARTAMENTO " +
                                     "                      ,   SECAO_KEY " +
                                     "                      ,   SECAO " +
                                     "                      ,   GRUPO_PRODUTO_KEY " +
                                     "                      ,   GRUPO " +
                                     "                      ,   SUB_GRUPO_PRODUTO_KEY " +
                                     "                      ,   SUBGRUPO ";


                DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
    public static class BlueSoft_Import
    {
        public static int Start(modelSistemaUsuario _myConnect)
        {

            DataTable DT = BlueSoft_Select.List(_myConnect, "", "");
            List<SP_Produto_TbProdutoBlueSoft> XTbProduto = new List<SP_Produto_TbProdutoBlueSoft>();
            for (int NL = 0; NL <= DT.Rows.Count - 1; NL++)
            {
                //int CdProdutoBlueSoft = Convert.ToInt32(DataTableBlueSoftRedShift.Tables[0].Rows[NL][0].ToString());
                //String StringFind = "CdProdutoBlueSoft = " + CdProdutoBlueSoft.ToString();
                //DataRow[] y = DataTableBlueSoftRedShift.Tables[0].Select(StringFind);
                //y[0].ToString();
                SP_Produto_TbProdutoBlueSoft xItem = new SP_Produto_TbProdutoBlueSoft();
                xItem.CdProduto = 0;
                xItem.CdProdutoBlueSoft = Convert.ToInt32(DT.Rows[NL]["CdProdutoBlueSoft"].ToString());
                xItem.CdProdutoBlueSoftUnitario = Convert.ToInt32(DT.Rows[NL]["CdProdutoBlueSoftUnitario"].ToString());
                xItem.Descricao = DT.Rows[NL]["Descricao"].ToString();
                xItem.CodigoBarraReferencia = DT.Rows[NL]["CodigoBarraReferencia"].ToString();
                xItem.EmbalagemEstoque = DT.Rows[NL]["EmbalagemEstoque"].ToString();
                xItem.FatorEstoque = Convert.ToDouble(DT.Rows[NL]["FatorEstoque"].ToString());
                xItem.CdProdutoBlueSoftControleEstoque = Convert.ToInt32(DT.Rows[NL]["CdProdutoBlueSoftControleEstoque"].ToString());
                xItem.CdProdutoBlueSoftControlePreco = Convert.ToInt32(DT.Rows[NL]["CdProdutoBlueSoftControlePreco"].ToString());
                xItem.DepartamentoKey = Convert.ToInt32(DT.Rows[NL]["DepartamentoKey"].ToString());
                xItem.SecaoKey = Convert.ToInt32(DT.Rows[NL]["SecaoKey"].ToString());
                xItem.GrupoKey = Convert.ToInt32(DT.Rows[NL]["GrupoProdutoKey"].ToString());
                xItem.SubGrupoKey = Convert.ToInt32(DT.Rows[NL]["SubGrupoKey"].ToString());
                xItem.DataUltimaAlteracao = Convert.ToDateTime(DT.Rows[NL]["DataUltimaAlteracao"].ToString());
                xItem.DataCadastro = Convert.ToDateTime(DT.Rows[NL]["DataCadastro"].ToString());
                xItem.FabricanteKey = Convert.ToInt32(DT.Rows[NL]["FabricanteKey"].ToString());
                xItem.EmbalagemCompra = DT.Rows[NL]["EmbalagemCompra"].ToString();
                xItem.EmbalagemCompraQtdeUnitaria = Convert.ToDouble(DT.Rows[NL]["EmbalagemCompraQtdeUnitaria"].ToString());

                if (DT.Rows[NL]["ProdutoStatus"].ToString() == "1")
                {
                    xItem.ProdutoStatus = true;
                }
                else
                {
                    xItem.ProdutoStatus = false;
                }


                if (DT.Rows[NL]["VendaExterna"].ToString() == "1")
                {
                    xItem.VendaExterna = true;
                }
                else
                {
                    xItem.VendaExterna = false;
                }

                XTbProduto.Add(xItem);
            }

            List<ParameterQuey> Parametros = new List<ParameterQuey>();

            DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
            x.Begin();

            /* Exclui todos os itens */
            Parametros.Clear();
            Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUESOFT_CLEAR"));
            x.Execute("SP_PRODUTO_BLUESOFT", Parametros.ToArray());
            for (int xi = 0; xi <= XTbProduto.Count() - 1; xi++)
            {
                Parametros = new List<ParameterQuey>();
                Parametros.Add(new ParameterQuey("CdProduto", SqlDbType.Int, false, XTbProduto[xi].CdProduto));
                Parametros.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, false, XTbProduto[xi].CdProdutoBlueSoft));
                Parametros.Add(new ParameterQuey("CdProdutoBlueSoftUnitario", SqlDbType.Int, false, XTbProduto[xi].CdProdutoBlueSoftUnitario));
                Parametros.Add(new ParameterQuey("Descricao", SqlDbType.VarChar, false, XTbProduto[xi].Descricao));
                Parametros.Add(new ParameterQuey("CodigoBarraReferencia", SqlDbType.VarChar, false, XTbProduto[xi].CodigoBarraReferencia));
                Parametros.Add(new ParameterQuey("EmbalagemEstoque", SqlDbType.VarChar, false, XTbProduto[xi].EmbalagemEstoque));
                Parametros.Add(new ParameterQuey("FatorEstoque", SqlDbType.Decimal, false, XTbProduto[xi].FatorEstoque));
                Parametros.Add(new ParameterQuey("CdProdutoBlueSoftControleEstoque", SqlDbType.Int, false, XTbProduto[xi].CdProdutoBlueSoftControleEstoque));
                Parametros.Add(new ParameterQuey("CdProdutoBlueSoftControlePreco", SqlDbType.Int, false, XTbProduto[xi].CdProdutoBlueSoftControlePreco));
                Parametros.Add(new ParameterQuey("DepartamentoKey", SqlDbType.Int, false, XTbProduto[xi].DepartamentoKey));
                Parametros.Add(new ParameterQuey("SecaoKey", SqlDbType.Int, false, XTbProduto[xi].SecaoKey));
                Parametros.Add(new ParameterQuey("GrupoKey", SqlDbType.Int, false, XTbProduto[xi].GrupoKey));
                Parametros.Add(new ParameterQuey("SubGrupoKey", SqlDbType.Int, false, XTbProduto[xi].SubGrupoKey));
                Parametros.Add(new ParameterQuey("DataUltimaAlteracao", SqlDbType.Date, false, XTbProduto[xi].DataUltimaAlteracao));
                Parametros.Add(new ParameterQuey("DataCadastro", SqlDbType.Date, false, XTbProduto[xi].DataCadastro));
                Parametros.Add(new ParameterQuey("FabricanteKey", SqlDbType.Int, false, XTbProduto[xi].FabricanteKey));
                Parametros.Add(new ParameterQuey("ProdutoStatus", SqlDbType.Bit, false, XTbProduto[xi].ProdutoStatus));
                Parametros.Add(new ParameterQuey("VendaExterna", SqlDbType.Bit, false, XTbProduto[xi].VendaExterna));
                Parametros.Add(new ParameterQuey("EmbalagemCompra", SqlDbType.VarChar, false, XTbProduto[xi].EmbalagemCompra));
                Parametros.Add(new ParameterQuey("EmbalagemCompraQtdeUnitaria", SqlDbType.Decimal, false, XTbProduto[xi].EmbalagemCompraQtdeUnitaria));
                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUESOFT_INSERT"));
                x.Execute("SP_PRODUTO_BLUESOFT", Parametros.ToArray());
            }
            x.Commit();
            x.Close();
            return 1;
        }

    }
    public static class BlueSoft_Import_Val_Unit
    {

        public static string start(modelSistemaUsuario _myConnect, DataTable TbBlue)
        {
            try
            {


                /* Var's */
                DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
                List<ParameterQuey> Parametros = new List<ParameterQuey>();
                //string ErroMessageInfo = "Erro não identificado";

                /* Begin Command */
                x.Begin();

                /* SQL Command Clear Table*/
                // Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "DELETE")); 
                // x.Execute("SP_ParticipanteBluesoft", Parametros.ToArray());

                /* Limpa os parametros para um novo insert*/
                Parametros.Clear();

                /* SQL loop insert rows*/
                for (int i = 0; i <= TbBlue.Rows.Count - 1; i++)
                {
                    Parametros.Clear();

                    //ErroMessageInfo = "ERRO IMPORTACAO ESTOQUE"; //string.Format("Registro seq for (i): {0} | CdParticipante: {1}, Nome: {2} ", i.ToString(), TbBlue.Rows[i]["CdParticipanteBlueSoft"].ToString(), TbBlue.Rows[i]["Nome"].ToString());

                    //int fields 
                    Parametros.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, false, TbBlue.Rows[i]["CdProdutoBlueSoft"].ToString()));
                    Parametros.Add(new ParameterQuey("CdProdutoBlueSOftUnitario", SqlDbType.Int, false, TbBlue.Rows[i]["CdProdutoBlueSOftUnitario"].ToString()));
                    //Parametros.Add(new ParameterQuey("SeqImportacao", SqlDbType.Int, false, TbBlue.Rows[i]["SeqImportacao"].ToString()));

                    //Proc Execute
                    Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUESOFT_UP_UNI"));
                    x.Execute("sp_Produto_Bluesoft", Parametros.ToArray());
                }


                Parametros.Clear();

                /* Commit tran*/
                x.Commit();

                /* Close*/
                x.Close();

                return "";
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }

        }

    }
    public static class BlueSoft_Import_CodigoBarra
    {
        public static int Start(modelSistemaUsuario _myConnect)
        {

            try
            {

                DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
                List<ParameterQuey> Parametros = new List<ParameterQuey>();
                x.Begin();

                Parametros.Clear();
                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUE_EMB_CLR"));
                x.Execute("SP_PRODUTO_BLUESOFT", Parametros.ToArray());


                DataTable DT = BlueSoft_Select_CodigoBarra.List(_myConnect, 0);
                List<TbCodigoBarra> XTbCodigoBarra = new List<TbCodigoBarra>();
                for (int NL = 0; NL <= DT.Rows.Count - 1; NL++)
                {

                    TbCodigoBarra xItem = new TbCodigoBarra();
                    xItem.CdProdutoBlueSoft = Convert.ToInt32(DT.Rows[NL]["CdProdutoBlueSoft"].ToString());
                    xItem.CodigoBarra = DT.Rows[NL]["CodigoBarra"].ToString();
                    xItem.Embalagem = DT.Rows[NL]["Embalagem"].ToString();
                    xItem.EmbalagemDescricao = DT.Rows[NL]["EmbalagemDescricao"].ToString();
                    xItem.Tipo = DT.Rows[NL]["Tipo"].ToString();
                    XTbCodigoBarra.Add(xItem);
                    //Pag_Net.Tools.LogFile.Write("D:\\Projects\\Pag_1.0.10.j\\Spool\\TESTEi.TXT", xItem.CodigoBarra);
                }

                /* DataSet DS = DbSelect.GetDataSet(_myConnect, DataBaseName.DBAMAINADM, "sp_Produto_Bluesoft", "BLUESOFT_EMB");
                 List<TbCodigoBarra> lTbCodigoBarra = new List<TbCodigoBarra>();
                 for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
                 {
                     //Pag_Net.Tools.LogFile.Write("D:\\Projects\\Pag_1.0.10.j\\Spool\\TESTE.TXT", DS.Tables[0].Rows[i]["CodigoBarra"].ToString());

                     TbCodigoBarra Item = new TbCodigoBarra();
                     Item.CdProdutoBlueSoft = Convert.ToInt32(DS.Tables[0].Rows[i]["CdProdutoBlueSoft"].ToString());
                     Item.CodigoBarra = DS.Tables[0].Rows[i]["CodigoBarra"].ToString();
                     Item.Embalagem = DS.Tables[0].Rows[i]["Embalagem"].ToString();
                     Item.EmbalagemDescricao = DS.Tables[0].Rows[i]["EmbalagemDescricao"].ToString();
                     Item.Tipo = DS.Tables[0].Rows[i]["Tipo"].ToString();
                     lTbCodigoBarra.Add(Item);
                 }*/


                Int64 NumeroDeLinhas = 0;
                for (int xi = 0; xi <= XTbCodigoBarra.Count() - 1; xi++)
                {
                    NumeroDeLinhas = NumeroDeLinhas + 1;
                    //TbCodigoBarra ItemY = lTbCodigoBarra.Find(X => X.CodigoBarra.Trim() == XTbCodigoBarra[xi].CodigoBarra.Trim());

                    Parametros.Clear();
                    Parametros.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, false, XTbCodigoBarra[xi].CdProdutoBlueSoft));
                    Parametros.Add(new ParameterQuey("CodigoBarra", SqlDbType.VarChar, false, XTbCodigoBarra[xi].CodigoBarra));
                    Parametros.Add(new ParameterQuey("Embalagem", SqlDbType.VarChar, false, XTbCodigoBarra[xi].Embalagem));
                    Parametros.Add(new ParameterQuey("EmbalagemDescricao", SqlDbType.VarChar, false, XTbCodigoBarra[xi].EmbalagemDescricao));
                    Parametros.Add(new ParameterQuey("Tipo", SqlDbType.VarChar, false, XTbCodigoBarra[xi].Tipo));


                    Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUESOFT_EMB_IN"));
                    x.Execute("SP_PRODUTO_BLUESOFT", Parametros.ToArray());


                    /*if (ItemY == null)
                    {
                        Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUESOFT_EMB_IN"));
                        x.Execute("SP_PRODUTO_BLUESOFT", Parametros.ToArray());
                    }
                    else
                    {

                        if (ItemY.CdProdutoBlueSoft != XTbCodigoBarra[xi].CdProdutoBlueSoft || ItemY.Embalagem != XTbCodigoBarra[xi].Embalagem || ItemY.EmbalagemDescricao != XTbCodigoBarra[xi].EmbalagemDescricao ||
                            ItemY.Tipo != XTbCodigoBarra[xi].Tipo)
                        {
                            Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUESOFT_EMB_UP"));
                            x.Execute("SP_PRODUTO_BLUESOFT", Parametros.ToArray());
                        }
                        if (NumeroDeLinhas > 3000)
                        {
                            System.Threading.Thread.Sleep(1000);
                            NumeroDeLinhas = 0;
                        }
                    }*/


                }
                x.Commit();
                x.Close();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
    public static class BlueSoft_Import_Categoria
    {
        public static string Start(modelSistemaUsuario _myConnect)
        {
            string InfoProcessamento = "";

            try
            {

                DataTable TbBlueCategoria = BlueSoft_Select_Categoria.List(_myConnect);


                DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
                List<ParameterQuey> Parametros = new List<ParameterQuey>();

                x.Begin();

                /* EXCLUI DADOS DA TABELA BlueCateg*/
                InfoProcessamento = "Executando: " + "\n" +
                        "SP_PRODUTO_BLUESOFT @COMMAND = 'BLUE_CAT_CLR'";

                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUE_CAT_CLR"));
                x.Execute("SP_PRODUTO_BLUESOFT", Parametros.ToArray());



                /* Limpa os parametros para um novo insert*/
                Parametros.Clear();


                /* INCLUI OS DADOS NA TABELA */
                for (int i = 0; i <= TbBlueCategoria.Rows.Count - 1; i++)
                {
                    Parametros.Clear();

                    InfoProcessamento = string.Format("Executando: " + "\n" +
                            "SP_PRODUTO_BLUESOFT @COMMAND = 'BLUE_CAT_INS'" + "\n" +
                            "DepartamentoKey = '{0}'" + "\n" +
                            "SecaoKey = '{0}'" + "\n" +
                            "GrupoKey = '{0}'" + "\n" +
                            "SubGrupoKey = '{0}'" + "\n" +
                            "DepartamentoDescricao = '{0}'" + "\n" +
                            "SecaoDescricao = '{0}'" + "\n" +
                            "GrupoDescricao = '{0}'" + "\n" +
                            "SubGrupoDescricao = '{0}'", TbBlueCategoria.Rows[i]["DepartamentoKey"].ToString(),
                            TbBlueCategoria.Rows[i]["SecaoKey"].ToString(),
                            TbBlueCategoria.Rows[i]["GrupoKey"].ToString(),
                            TbBlueCategoria.Rows[i]["SubGrupoKey"].ToString(),
                            TbBlueCategoria.Rows[i]["DepartamentoDescricao"].ToString(),
                            TbBlueCategoria.Rows[i]["SecaoDescricao"].ToString(),
                            TbBlueCategoria.Rows[i]["GrupoDescricao"].ToString(),
                            TbBlueCategoria.Rows[i]["SubGrupoDescricao"].ToString());



                    Parametros.Add(new ParameterQuey("DepartamentoKey", SqlDbType.Int, false, Convert.ToInt32(TbBlueCategoria.Rows[i]["DepartamentoKey"].ToString())));
                    Parametros.Add(new ParameterQuey("SecaoKey", SqlDbType.Int, false, Convert.ToInt32(TbBlueCategoria.Rows[i]["SecaoKey"].ToString())));
                    Parametros.Add(new ParameterQuey("GrupoKey", SqlDbType.Int, false, Convert.ToInt32(TbBlueCategoria.Rows[i]["GrupoKey"].ToString())));
                    Parametros.Add(new ParameterQuey("SubGrupoKey", SqlDbType.Int, false, Convert.ToInt32(TbBlueCategoria.Rows[i]["SubGrupoKey"].ToString())));

                    Parametros.Add(new ParameterQuey("DepartamentoDescricao", SqlDbType.VarChar, false, TbBlueCategoria.Rows[i]["DepartamentoDescricao"].ToString()));
                    Parametros.Add(new ParameterQuey("SecaoDescricao", SqlDbType.VarChar, false, TbBlueCategoria.Rows[i]["SecaoDescricao"].ToString()));
                    Parametros.Add(new ParameterQuey("GrupoDescricao", SqlDbType.VarChar, false, TbBlueCategoria.Rows[i]["GrupoDescricao"].ToString()));
                    Parametros.Add(new ParameterQuey("SubGrupoDescricao", SqlDbType.VarChar, false, TbBlueCategoria.Rows[i]["SubGrupoDescricao"].ToString()));

                    Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUE_CAT_INS"));
                    x.Execute("SP_PRODUTO_BLUESOFT", Parametros.ToArray());
                }

                x.Commit();
                x.Close();
                return InfoProcessamento;
            }

            catch (Exception ex)
            {
                throw new Exception("ERRO: Pag_Net.Bll.Produto.BlueSoft_Import_Categoria.Start" + "\n" +
                                    "Último Processo: " + "\n" + "\n" + InfoProcessamento + "\n" +
                                    "ERRO SYSTEM:" + ex.Message);

            }


        }


    }
    public static class BlueSOft_Import_Tributacao
    {

        public static int Start(modelSistemaUsuario _myConnect)
        {

            DataTable TbBlue = BlueSoft_Select_Tributacao.List(_myConnect, 0);


            DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
            List<ParameterQuey> Parametros = new List<ParameterQuey>();

            x.Begin();

            /* EXCLUI DADOS DA TABELA BlueCateg*/
            Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUE_TRIB_CLR"));
            x.Execute("SP_PRODUTO_BLUESOFT", Parametros.ToArray());


            /* Limpa os parametros para um novo insert*/
            Parametros.Clear();

            /* INCLUI OS DADOS NA TABELA */
            for (int i = 0; i <= TbBlue.Rows.Count - 1; i++)
            {
                Parametros.Clear();
                Parametros.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["CdProdutoBlueSoft"].ToString())));
                Parametros.Add(new ParameterQuey("PIS_Entrada_CST", SqlDbType.VarChar, false, TbBlue.Rows[i]["PIS_ENTRADA_CST"].ToString()));
                Parametros.Add(new ParameterQuey("PIS_Saida_CST", SqlDbType.VarChar, false, TbBlue.Rows[i]["PIS_SAIDA_CST"].ToString()));
                Parametros.Add(new ParameterQuey("COFINS_Entrada_CST", SqlDbType.VarChar, false, TbBlue.Rows[i]["COFINS_ENTRADA_CST"].ToString()));
                Parametros.Add(new ParameterQuey("COFINS_Saida_CST", SqlDbType.VarChar, false, TbBlue.Rows[i]["COFINS_SAIDA_CST"].ToString()));
                Parametros.Add(new ParameterQuey("ICMS_Saida_CST", SqlDbType.VarChar, false, TbBlue.Rows[i]["ICMS_SAIDA_CST"].ToString()));
                Parametros.Add(new ParameterQuey("ICMS_Entrada_CST", SqlDbType.VarChar, false, TbBlue.Rows[i]["ICMS_Entrada_CST"].ToString()));
                Parametros.Add(new ParameterQuey("NCM", SqlDbType.VarChar, false, TbBlue.Rows[i]["NCM"].ToString()));
                Parametros.Add(new ParameterQuey("CEST", SqlDbType.VarChar, false, TbBlue.Rows[i]["CEST"].ToString()));


                Parametros.Add(new ParameterQuey("PIS_Entrada_Aliquota", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["PIS_ENTRADA_ALIQUOTA"].ToString())));
                Parametros.Add(new ParameterQuey("PIS_Saida_Aliquota", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["PIS_SAIDA_ALIQUOTA"].ToString())));
                Parametros.Add(new ParameterQuey("COFINS_Entrada_Aliquota", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["COFINS_ENTRADA_ALIQUOTA"].ToString())));
                Parametros.Add(new ParameterQuey("COFINS_Saida_Aliquota", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["COFINS_SAIDA_ALIQUOTA"].ToString())));
                Parametros.Add(new ParameterQuey("ICMS_Aliquota_Interna", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ICMS_ALIQUOTA_INTERNA"].ToString())));
                Parametros.Add(new ParameterQuey("ICMS_Aliquota_Interna", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ICMS_ALIQUOTA_INTERNA"].ToString())));
                Parametros.Add(new ParameterQuey("ST_IVA", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ST_IVA"].ToString())));
                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "BLUE_TRIB_INS"));
                x.Execute("SP_PRODUTO_BLUESOFT", Parametros.ToArray());
            }

            x.Commit();
            x.Close();


            return 0;

        }

    }

}

namespace Pag_Net.Bll.ProdutoEstoqueCusto
{
    public class List
    {
        public modelSistemaUsuario MyConnect;

        public List(modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
        }

        public DataTable start()
        {
            return start(false, Convert.ToDateTime("01/01/1900"), false, Convert.ToDateTime("01/01/1900"), false, "", 0, 0, 0);
        }

        public DataTable start(bool SelecionaDataInicial, DateTime DataInicial, bool SelecionaDataFinal, DateTime DataFinal, bool MargemNegativa, string Descricao, int CdProdutoPag, int CdProdutoBlueSoft, int CdProdutoTarget)
        {
            try
            {
                List<ParameterQuey> ListParamter = new List<ParameterQuey>();




                if (MargemNegativa)
                    ListParamter.Add(new ParameterQuey("SelectMargemNegativa", System.Data.SqlDbType.Bit, true, 1));


                if (SelecionaDataInicial)
                    ListParamter.Add(new ParameterQuey("SelectSelecionaDataInicial", System.Data.SqlDbType.Bit, true, 1));

                if (SelecionaDataFinal)
                    ListParamter.Add(new ParameterQuey("SelectSelecionaDataFinal", System.Data.SqlDbType.Bit, true, 1));

                ListParamter.Add(new ParameterQuey("SelectDataInicial", System.Data.SqlDbType.SmallDateTime, true, DataInicial.ToShortDateString()));
                ListParamter.Add(new ParameterQuey("SelectDataFinal", System.Data.SqlDbType.SmallDateTime, true, DataFinal.ToShortDateString()));


                ListParamter.Add(new ParameterQuey("Descricao", System.Data.SqlDbType.VarChar, true, Descricao));
                ListParamter.Add(new ParameterQuey("CdProduto", System.Data.SqlDbType.Int, true, CdProdutoPag));
                ListParamter.Add(new ParameterQuey("CdProdutoBlueSoft", System.Data.SqlDbType.Int, true, CdProdutoBlueSoft));


                ListParamter.Add(new ParameterQuey("COMMAND", System.Data.SqlDbType.VarChar, true, "SELECT"));
                DataSet DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, "SP_ProdutoEstoqueCusto", ListParamter.ToArray());
                return DX.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Produto.List: " + ex.Message.ToString());
            }
        }
    }
}



namespace Pag_Net.Bll
{

    public class Recebimentos
    {
        /*Variavel de Conexao*/
        private modelSistemaUsuario MyConnect;

        PagSystemProgressInf Args;
        protected virtual void OnExecute(PagSystemProgressInf e)
        {
            if (e.Changed)
            {
                EventHandler<PagSystemProgressInf> handler = PagProgress;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        public event EventHandler<PagSystemProgressInf> PagProgress;

        /*Filtros de Consulta*/
        public DateTime F_DtRecebimentoInicial;
        public DateTime F_DtRecebimentoFinal;
        public string F_CdProdutoBlueSoft_List;
        public string F_CdProduto_List;
        public string F_Descricao;

        public DataTable GetDataTable()
        {
            try
            {
                return SP_Recebimento();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /*prop */
        private TbRecebimento[] _list;
        public TbRecebimento[] List
        {
            get
            {

                try
                {
                    return Fill((DataTable)(SP_Recebimento(SP_OPTIONS._SELECT)));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }

            set
            {
                _list = value;

            }
        }

        /*Inicializador*/
        public Recebimentos(modelSistemaUsuario _MYCONNECT)
        {
            MyConnect = _MYCONNECT;
            Args = new PagSystemProgressInf("", 0, 0);

        }

        /*Importação de Dados*/
        public void Import()
        {
            try
            {

                _list = Fill(Pag_Net.Bll.BlueSoft.TbRedshift_Recebimentos._SELECT(MyConnect, F_DtRecebimentoInicial, F_DtRecebimentoFinal));

                SP_Recebimento(SP_OPTIONS._UPDATE);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /*Opções de Comandos DBA Stored Procedure*/
        private enum SP_OPTIONS
        {
            _UPDATE,
            _SELECT
        }


        private DataTable SP_Recebimento()
        {
            List<Models.ParameterQuey> Parametros = new List<Models.ParameterQuey>();
            try
            {
                Parametros.Add(new Models.ParameterQuey("COMMAND", SqlDbType.VarChar, true, "SELECT"));
                Parametros.Add(new Models.ParameterQuey("F_DtRecebimentoInicial", SqlDbType.SmallDateTime, true, F_DtRecebimentoInicial));
                Parametros.Add(new Models.ParameterQuey("F_DtRecebimentoFinal", SqlDbType.SmallDateTime, true, F_DtRecebimentoFinal));
                Parametros.Add(new Models.ParameterQuey("F_CdProdutoBlueSoft_List", SqlDbType.VarChar, true, F_CdProdutoBlueSoft_List));
                Parametros.Add(new Models.ParameterQuey("F_CdProduto_List", SqlDbType.VarChar, true, F_CdProduto_List));
                Parametros.Add(new Models.ParameterQuey("F_Descricao", SqlDbType.VarChar, true, F_Descricao));

                DataSet DX = Dal.DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, "SP_RECEBIMENTO", Parametros.ToArray());
                return DX.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*Procedures SQL*/
        private object SP_Recebimento(SP_OPTIONS _OPTION)
        {
            object obj = new object();



            List<Models.ParameterQuey> Parametros = new List<Models.ParameterQuey>();
            DbUpdate DbaUpdate = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
            try
            {

                switch (_OPTION)
                {
                    case SP_OPTIONS._SELECT:
                        DataTable Tb;
                        Parametros.Add(new Models.ParameterQuey("COMMAND", SqlDbType.VarChar, true, "SELECT"));
                        Parametros.Add(new Models.ParameterQuey("F_DtRecebimentoInicial", SqlDbType.SmallDateTime, true, F_DtRecebimentoInicial));
                        Parametros.Add(new Models.ParameterQuey("F_DtRecebimentoFinal", SqlDbType.SmallDateTime, true, F_DtRecebimentoFinal));
                        Parametros.Add(new Models.ParameterQuey("F_CdProdutoBlueSoft_List", SqlDbType.VarChar, true, F_CdProdutoBlueSoft_List));
                        Parametros.Add(new Models.ParameterQuey("F_Descricao", SqlDbType.VarChar, true, F_Descricao));
                        obj = Tb = Dal.DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, "SP_RECEBIMENTO", Parametros.ToArray()).Tables[0];
                        break;
                    case SP_OPTIONS._UPDATE:
                        DbaUpdate.Begin();
                        Parametros.Add(new Models.ParameterQuey("F_DtRecebimentoInicial", SqlDbType.SmallDateTime, true, F_DtRecebimentoInicial));
                        Parametros.Add(new Models.ParameterQuey("F_DtRecebimentoFinal", SqlDbType.SmallDateTime, true, F_DtRecebimentoFinal));
                        Parametros.Add(new Models.ParameterQuey("COMMAND", SqlDbType.VarChar, true, "DELETE"));
                        DbaUpdate.Execute("SP_RECEBIMENTO", Parametros.ToArray());
                        Args.Set("Inserindo registros", 0, _list.Count());
                        OnExecute(Args);
                        foreach (TbRecebimento Item in _list)
                        {
                            Parametros.Clear();
                            Parametros.Add(new ParameterQuey("CdParticipante", SqlDbType.Int, true, Item.CdParticipante));
                            Parametros.Add(new ParameterQuey("CdProduto", SqlDbType.Int, true, Item.CdProduto));
                            Parametros.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, true, Item.CdProdutoBlueSoft));
                            Parametros.Add(new ParameterQuey("CFOP", SqlDbType.VarChar, true, Item.CFOP));
                            Parametros.Add(new ParameterQuey("CNPJCPF", SqlDbType.VarChar, true, Item.CNPJCPF));
                            Parametros.Add(new ParameterQuey("DataEmissao", SqlDbType.SmallDateTime, true, Item.DataEmissao));
                            Parametros.Add(new ParameterQuey("DataRecebimento", SqlDbType.SmallDateTime, true, Item.DataRecebimento));
                            Parametros.Add(new ParameterQuey("DataVencimentoMaximo", SqlDbType.SmallDateTime, true, Item.DataVencimentoMaximo));
                            Parametros.Add(new ParameterQuey("DataVencimentoMinimo", SqlDbType.SmallDateTime, true, Item.DataVencimentoMinimo));
                            Parametros.Add(new ParameterQuey("Descricao", SqlDbType.VarChar, true, Item.Descricao));
                            Parametros.Add(new ParameterQuey("EmbalagemCompra", SqlDbType.VarChar, true, Item.EmbalagemCompra));
                            Parametros.Add(new ParameterQuey("EmbalagemCompraQtde", SqlDbType.Decimal, true, Item.EmbalagemCompraQtde));
                            Parametros.Add(new ParameterQuey("EmbalagemEstoqueQtde", SqlDbType.Decimal, true, Item.EmbalagemEstoqueQtde));
                            Parametros.Add(new ParameterQuey("EmbalagemEstoqueQtde_Devolvida", SqlDbType.Decimal, true, Item.EmbalagemEstoqueQtde_Devolvida));
                            Parametros.Add(new ParameterQuey("EmbalagemEstoqueValorCusto", SqlDbType.Decimal, true, Item.EmbalagemEstoqueValorCusto));
                            Parametros.Add(new ParameterQuey("FatorEstoque", SqlDbType.Decimal, true, Item.FatorEstoque));
                            Parametros.Add(new ParameterQuey("FornecedorKey", SqlDbType.Int, true, Item.FornecedorKey));
                            Parametros.Add(new ParameterQuey("NumeroAPS", SqlDbType.Int, true, Item.NumeroAPS));
                            Parametros.Add(new ParameterQuey("NumeroNotaFiscal", SqlDbType.Int, true, Item.NumeroNotaFiscal));
                            Parametros.Add(new ParameterQuey("RazaoSocial", SqlDbType.VarChar, true, Item.RazaoSocial));
                            Parametros.Add(new ParameterQuey("SeqRecebimentoItem", SqlDbType.Int, true, Item.SeqRecebimentoItem));
                            Parametros.Add(new ParameterQuey("ValorBaseST", SqlDbType.Decimal, true, Item.ValorBaseST));
                            Parametros.Add(new ParameterQuey("ValorCusto", SqlDbType.Decimal, true, Item.ValorCusto));
                            Parametros.Add(new ParameterQuey("ValorCustoTotal", SqlDbType.Decimal, true, Item.ValorCustoTotal));
                            Parametros.Add(new ParameterQuey("ValorST", SqlDbType.Decimal, true, Item.ValorST));
                            Parametros.Add(new Models.ParameterQuey("COMMAND", SqlDbType.VarChar, true, "UPDATE"));
                            Args.ValorAtual = Args.ValorAtual + 1;
                            //if (Args.Changed)
                           //{
                                OnExecute(Args);
                            //}
                            DbaUpdate.Execute("SP_RECEBIMENTO", Parametros.ToArray());
                        }
                        DbaUpdate.Commit();
                        DbaUpdate.Close();
                        break;
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Classe.............: BLL.SP_Recebimento " + Environment.NewLine +
                    "SQL PROCEDURE......: SP_RECEBIMENTO " + Environment.NewLine +
                    "Parâmetro..........: F_DtRecebimentoInicial | Valor: " + F_DtRecebimentoInicial.ToString() + Environment.NewLine +
                    "Parâmetro..........: F_DtRecebimentoFinal | Valor: " + F_DtRecebimentoFinal.ToString() + Environment.NewLine +
                    "Descrição do Erro..: " + ex.Message);
                DbaUpdate.Close();
            }
        }

        /*Retorno de Consulta*/
        private TbRecebimento[] Fill(DataTable Tb)
        {
            try
            {


                List<TbRecebimento> List = new List<TbRecebimento>();
                foreach (DataRow i in Tb.Rows)
                {
                    TbRecebimento Item = new TbRecebimento();
                    Item.CdParticipante = Convert.ToInt32(i["CdParticipante"]);
                    Item.CdProduto = Convert.ToInt32(i["CdProduto"]);
                    Item.CdProdutoBlueSoft = Convert.ToInt32(i["CdProdutoBlueSoft"]);
                    Item.CFOP = i["CFOP"].ToString();
                    Item.CNPJCPF = i["CNPJCPF"].ToString();
                    Item.DataEmissao = Convert.ToDateTime(i["DataEmissao"]);
                    Item.DataRecebimento = Convert.ToDateTime(i["DataRecebimento"]);
                    Item.DataVencimentoMaximo = Convert.ToDateTime(i["DataVencimentoMaximo"]);
                    Item.DataVencimentoMinimo = Convert.ToDateTime(i["DataVencimentoMinimo"]);
                    Item.Descricao = i["Descricao"].ToString();
                    Item.EmbalagemCompra = i["EmbalagemCompra"].ToString();
                    Item.EmbalagemCompraQtde = Convert.ToDouble(i["EmbalagemCompraQtde"].ToString());
                    Item.EmbalagemEstoqueQtde = Convert.ToDouble(i["EmbalagemEstoqueQtde"].ToString());
                    Item.EmbalagemEstoqueQtde_Devolvida = Convert.ToDouble(i["EmbalagemEstoqueQtde_Devolvida"].ToString());
                    Item.EmbalagemEstoqueValorCusto = Convert.ToDouble(i["EmbalagemEstoqueValorCusto"].ToString());
                    Item.FatorEstoque = Convert.ToDouble(i["FatorEstoque"].ToString());
                    Item.FornecedorKey = Convert.ToInt32(i["FornecedorKey"].ToString());
                    Item.NumeroAPS = Convert.ToInt32(i["NumeroAPS"].ToString());
                    Item.NumeroNotaFiscal = Convert.ToInt32(i["NumeroNotaFiscal"].ToString());
                    Item.RazaoSocial = i["RazaoSocial"].ToString();
                    Item.SeqRecebimentoItem = Convert.ToInt32(i["SeqRecebimentoItem"].ToString());
                    Item.ValorBaseST = Convert.ToDouble(i["ValorBaseST"].ToString());
                    Item.ValorCusto = Convert.ToDouble(i["ValorCusto"].ToString());
                    Item.ValorCustoTotal = Convert.ToDouble(i["ValorCusto"].ToString());
                    Item.ValorST = Convert.ToDouble(i["ValorST"].ToString());
                    List.Add(Item);
                }
                return List.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }

    public class ContratosX
    {
        private modelSistemaUsuario MyConnect;
        public DateTime F_DataInicio;
        public DateTime F_DataFim;
        public int F_SeqContrato;
        public int F_SeqTipoContrato;
        public ContratosX(modelSistemaUsuario _MYCONNECT)
        {
            MyConnect = _MYCONNECT;
        }
        public SP_Contrato_TbContrato[] ListContrato
        {
            get
            {

                try
                {
                    List<SP_Contrato_TbContrato> List = new List<SP_Contrato_TbContrato>();
                    foreach (DataRow i in _getDataTable("SELECT_CONTRATO").Rows)
                    {
                        SP_Contrato_TbContrato Item = new SP_Contrato_TbContrato();
                        Item.SeqContrato = Convert.ToInt32(i["SeqContrato"].ToString());
                        Item.CdParticipante = Convert.ToInt32(i["CdParticipante"]);
                        Item.Descricao = i["Descricao"].ToString();
                        Item.DataInicio = Convert.ToDateTime(i["DataInicio"].ToString());
                        Item.DataFim = Convert.ToDateTime(i["DataFim"].ToString());
                        Item.SeqTipoContrato = Convert.ToInt32(i["SeqTipoContrato"].ToString());
                        Item.Tipos_Descricao = i["Tipos_Descricao"].ToString();
                        Item.NumeroPedido = Convert.ToInt32(i["NumeroPedido"].ToString());
                        Item.NumeroNfe = Convert.ToInt32(i["NumeroNfe"].ToString());

                        List.Add(Item);
                    }
                    return List.ToArray();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

        }
        public SP_Contrato_TbContratoItem[] ListContratoItem
        {

            get
            {

                try
                {
                    List<SP_Contrato_TbContratoItem> List = new List<SP_Contrato_TbContratoItem>();
                    foreach (DataRow i in _getDataTable("SELECT_CONTRATO").Rows)
                    {
                        SP_Contrato_TbContratoItem Item = new SP_Contrato_TbContratoItem();
                        Item.CdProduto = Convert.ToInt32(i["CdProduto"]);
                        Item.Produto_Descricao = i["Produto_Descricao"].ToString();
                        List.Add(Item);
                    }
                    return List.ToArray();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }



        }
        public DataTable getDataTable_Contrato()
        {
            return _getDataTable("SELECT_CONTRATO");
        }
        public DataTable getDataTable_ContratoItem()
        {
            return _getDataTable("SELECT_ITEM");
        }
        private DataTable _getDataTable(string _SQLCommand)
        {
            DataTable Tb;
            Tb = Dal.DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, "SP_CONTRATO", _Fill(new SP_Contrato(_SQLCommand, F_DataInicio, F_DataFim, F_SeqContrato, F_SeqTipoContrato))).Tables[0];
            return Tb;
        }
        private ParameterQuey[] _Fill(SP_Contrato SP_CONTRATO)
        {

            List<ParameterQuey> Parametros = new System.Collections.Generic.List<ParameterQuey>();

            Parametros.Clear();

            Parametros.Add(new Models.ParameterQuey("SQLCommand", SqlDbType.VarChar, true, SP_CONTRATO.SQLCommnd));

            //Filtros
            Parametros.Add(new Models.ParameterQuey("F_DataInicio", SqlDbType.SmallDateTime, true, SP_CONTRATO.F_DataInicio));
            Parametros.Add(new Models.ParameterQuey("F_DataFim", SqlDbType.SmallDateTime, true, SP_CONTRATO.F_DataFim));
            Parametros.Add(new Models.ParameterQuey("F_SeqContrato", SqlDbType.Int, true, SP_CONTRATO.F_SeqContrato));
            Parametros.Add(new Models.ParameterQuey("F_SeqTipoContrato", SqlDbType.Int, true, SP_CONTRATO.F_SeqTipoContrato));

            //DateTimes
            Parametros.Add(new Models.ParameterQuey("DataLancamento", SqlDbType.SmallDateTime, true, SP_CONTRATO.Contrato.DataLancamento));
            Parametros.Add(new Models.ParameterQuey("DataInicio", SqlDbType.SmallDateTime, true, SP_CONTRATO.Contrato.DataInicio));
            Parametros.Add(new Models.ParameterQuey("DataFim", SqlDbType.SmallDateTime, true, SP_CONTRATO.Contrato.DataFim));

            //Int´s
            Parametros.Add(new Models.ParameterQuey("SeqContrato", SqlDbType.Int, true, SP_CONTRATO.Contrato.SeqContrato));
            Parametros.Add(new Models.ParameterQuey("CdOperacao", SqlDbType.Int, true, SP_CONTRATO.Contrato.CdOperacao));
            Parametros.Add(new Models.ParameterQuey("SeqTipoContrato", SqlDbType.Int, true, SP_CONTRATO.Contrato.SeqTipoContrato));
            Parametros.Add(new Models.ParameterQuey("NumeroPedido", SqlDbType.Int, true, SP_CONTRATO.Contrato.NumeroPedido));
            Parametros.Add(new Models.ParameterQuey("NumeroNfe", SqlDbType.Int, true, SP_CONTRATO.Contrato.NumeroNfe));
            Parametros.Add(new Models.ParameterQuey("Nfe", SqlDbType.Int, true, SP_CONTRATO.Contrato.Nfe));
            Parametros.Add(new Models.ParameterQuey("NumeroDocumentoFiscal", SqlDbType.Int, true, SP_CONTRATO.Contrato.NumeroDocumentoFiscal));
            Parametros.Add(new Models.ParameterQuey("CdParticipante", SqlDbType.Int, true, SP_CONTRATO.Contrato.CdParticipante));
            Parametros.Add(new Models.ParameterQuey("SeqContratoItem", SqlDbType.Int, true, SP_CONTRATO.ContratoItem.SeqContratoItem));
            Parametros.Add(new Models.ParameterQuey("CdProduto", SqlDbType.Int, true, SP_CONTRATO.ContratoItem.CdProduto));
            Parametros.Add(new Models.ParameterQuey("SeqItem", SqlDbType.Int, true, SP_CONTRATO.ContratoItem.SeqItem));

            //strings
            Parametros.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, SP_CONTRATO.Contrato.Descricao));
            Parametros.Add(new Models.ParameterQuey("CdTipoContrato", SqlDbType.VarChar, true, SP_CONTRATO.Contrato.CdTipoContrato));
            Parametros.Add(new Models.ParameterQuey("Observacao", SqlDbType.VarChar, true, SP_CONTRATO.Contrato.Observacao));
            Parametros.Add(new Models.ParameterQuey("CdFabricante", SqlDbType.VarChar, true, SP_CONTRATO.Contrato.CdFabricante));
            Parametros.Add(new Models.ParameterQuey("EmbalagemFaturamento", SqlDbType.VarChar, true, SP_CONTRATO.ContratoItem.EmbalagemFaturamento));

            //doubles
            Parametros.Add(new Models.ParameterQuey("ValorNegociado", SqlDbType.Decimal, true, SP_CONTRATO.Contrato.ValorNegociado));
            Parametros.Add(new Models.ParameterQuey("ValorAplicado", SqlDbType.Decimal, true, SP_CONTRATO.Contrato.ValorAplicado));
            Parametros.Add(new Models.ParameterQuey("ValorInvestimento", SqlDbType.Decimal, true, SP_CONTRATO.ContratoItem.ValorInvestimento));
            Parametros.Add(new Models.ParameterQuey("ValorInvestimentoTotal", SqlDbType.Decimal, true, SP_CONTRATO.ContratoItem.ValorInvestimentoTotal));
            Parametros.Add(new Models.ParameterQuey("EmbalagemEstoqueQtdeNegociada", SqlDbType.Decimal, true, SP_CONTRATO.ContratoItem.EmbalagemEstoqueQtdeNegociada));
            Parametros.Add(new Models.ParameterQuey("EmbalagemEstoqueQtdeAplicada", SqlDbType.Decimal, true, SP_CONTRATO.ContratoItem.EmbalagemEstoqueQtdeAplicada));

            return Parametros.ToArray();

        }

    }


}

namespace Pag_Net.Bll.BlueSoft.FVRegistros
{

    public class TbFVRegistros
    {
        private int numeropedido;
        public int NumeroPedido
        {
            get
            {
                return numeropedido;
            }
            set
            {
                if (numeropedido < 0)
                {
                    numeropedido = 0;
                }
                NumeroPedido = numeropedido;

            }

        }
        public int NotaFiscal { get; set; }
        public int NotaFiscalDevolucao { get; set; }
        public DateTime NotaFiscalDevolucaoDataEmissao { get; set; }
        public DateTime PedidoData { get; set; }
        public DateTime NFDataEmissao { get; set; }
        public string PedidoStatusDescricao { get; set; }
        public string PrazoPagamentoDescricao { get; set; }
        public int VendedorKey { get; set; }
        public string VendedorCNPJCPF { get; set; }
        public string VendedorNome { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteCNPJ { get; set; }
        public int PedidoProdutoKey { get; set; }
        public string PedidoProdutoDescricao { get; set; }
        public int NFProdutoKeyRelacionado { get; set; }
        public int VolumeFaturado { get; set; }
        public int PedidoProdutoKeyUnitario { get; set; }
        public double PedidoProdutoKeyFatorEstoque { get; set; }
        public double VolumeUnitarioCalculado { get; set; }
        public double ValorCustoUnitario { get; set; }
        public double ValorBrutoNotaFiscal { get; set; }
        public double DescontoFinanceiro { get; set; }
        public double ValorVerbaVendedor { get; set; }
        public double PercentualComissao { get; set; }
        public double ValorPrecoAplicado { get; set; }
        public double ValorPrecoTabela { get; set; }
        public string TipoVenda { get; set; }

        public TbFVRegistros()
        {

        }


    }

    public class List
    {
        public modelSistemaUsuario MyConnect { get; set; }

        public List(modelSistemaUsuario _myConnect)
        {
            MyConnect = _myConnect;
        }

        public DateTime DataConsultaInicial { get; set; }

        public DateTime DataConsultaFinal { get; set; }

        private static string SQLSELECT()
        {

            string SqlRedSHIFT = "SELECT    pd.pedido_forca_venda_cliente_key             AS NumeroPedido" +
                             "          ,   nf.NF_NUMERO                                  AS NotaFiscal" +
                             "          ,   dv.NF_NUMERO                                  AS NotaFiscalDevolucao " +
                             "          ,   dv.Data_emissao                               AS NotaFiscalDevolucaoDataEmissao" +
                             "          ,   pd.data_emissao                               as PedidoData" +
                             "          ,   pd.data_faturamento                           AS NFDataEmissao" +
                             "          ,   pd.status_pedido                              As PedidoStatusDescricao" +
                             "          ,   pd.prazo_pagamento                            As PrazoPagamentoDescricao" +
                             "          ,   pd.vendedor_key                               As VendedorKey" +
                             "          ,   ps.cpf_cnpj                                   As VendedorCNPJCPF" +
                             "          ,   ps.nome_razao                                 AS VendedorNome" +
                             "          ,   cl.nome_razao                                 AS ClienteNome" +
                             "          ,   cl.cpf_cnpj                                   AS ClienteCNPJ" +
                             "          ,   pd.produto_key                                AS PedidoProdutoKey" +
                             "          ,   pd.produto                                    AS PedidoProdutoDescricao" +
                             "          ,   pf.produto_origem_key                         AS NFProdutoKeyRelacionado" +
                             "          ,   pd.volume_faturado                            AS VolumeFaturado" +
                             "          ,   pr.produto_unitario_key                       As PedidoProdutoKeyUnitario" +
                             "          ,   pr.fator_estoque                              as ProdutoUnitarioFatorEstoque" +
                             "          ,   (pd.volume_faturado * pr.fator_estoque )      as VolumeUnitarioCalculado" +
                             "          ,   ct.CUSTO_UNITARIO_COM_ICM                     as ValorCustoUnitario" +
                             "          ,   (pf.ni_valor_bruto   / pr.fator_estoque )     AS ValorBrutoNotaFiscal" +
                             "          ,   isnull(pd.desconto_financeiro,0)              as ValorDescontoFinanceiro" +
                             "          ,   isnull(pd.valor_unitario_verba_vend,0)        as ValorVerbaVendedor" +
                             "          ,   pd.perc_est_comissao_vendedor                 as PercentualComissao" +
                             "          ,   pd.preco_aplicado                             as ValorPrecoAplicado" +
                             "          ,   pd.preco_tabela                               as ValorPrecoTabela" +
                             "          ,   pd.embalagem                                  as PedidoEmbalagem" +
                             "          ,   CASE " +
                             "                 WHEN pf.codigo_operacao_fiscal = '5102' THEN 'VENDA'" +
                             "                 WHEN pf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO'" +
                             "                 WHEN pf.codigo_operacao_fiscal = '5405' THEN 'VENDA'" +
                             "              END AS TipoVenda" +
                             "  FROM        fato_pedido_forca_venda pd" +
                             "  left  join  produto_d          pr on pr.produto_key = pd.produto_key" +
                             "  left  join  produto_d          pn on pn.produto_key = pr.produto_unitario_key" +
                             "  LEFT  JOIN  fornecedor_produto fp ON fp.fornecedor_produto_key = pn.fornecedor_produto_padrao_key" +
                             "  LEFT  JOIN  produto_d          cx ON cx.produto_key = fp.produto_key" +
                             "  inner join  pessoa             ps on ps.pessoa_key = pd.vendedor_key" +
                             "  inner join  nota_fiscal        nf on nf.nf_key = pd.nf_key " +
                             "  left  join  nota_fiscal        dv on dv.numero_documento_origem = nf.nf_numero" +
                             "  left  join  fato_nota_fiscal   pf on pf.nf_key = nf.nf_key and pf.produto_origem_key = pd.produto_key" +
                             "  left  join  produto_d          pe on pe.produto_key = pf.produto_origem_key" +
                             "  left  join  pessoa             cl on cl.pessoa_key = pd.cliente_key" +
                             "  LEFT JOIN   ESTOQUE_DIARIO     ct on ct.produto_key = pn.produto_key and ct.data = pd.data_Faturamento" +
                             "  where       pd.data_faturamento >= '2019-01-01'" +
                             "   and        pd.data_faturamento <= '2019-01-31'";
            return SqlRedSHIFT;
        }

        public DataTable getDataTable()
        {
            /*Data Base BlueSoft RedShift*/
            DataSet DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCBI32, SQLSELECT(), "");
            return DX.Tables[0];
        }

        public TbFVRegistros[] get()
        {
            DataTable DX = getDataTable();
            List<TbFVRegistros> XTbProduto = new List<TbFVRegistros>();
            for (int NL = 0; NL <= DX.Rows.Count - 1; NL++)
            {
                //int CdProdutoBlueSoft = Convert.ToInt32(DataTableBlueSoftRedShift.Tables[0].Rows[NL][0].ToString());
                //String StringFind = "CdProdutoBlueSoft = " + CdProdutoBlueSoft.ToString();
                //DataRow[] y = DataTableBlueSoftRedShift.Tables[0].Select(StringFind);
                //y[0].ToString();
                TbFVRegistros Item = new TbFVRegistros();
                Item.ClienteCNPJ = Convert.ToString(DX.Rows[NL]["ClienteCNPJ"].ToString());
                Item.ClienteNome = Convert.ToString(DX.Rows[NL]["ClienteNome"].ToString());
                Item.DescontoFinanceiro = Convert.ToDouble(DX.Rows[NL]["DescontoFinanceiro"].ToString());
                Item.NFDataEmissao = Convert.ToDateTime(DX.Rows[NL]["NFDataEmissao"].ToString());
                Item.NFProdutoKeyRelacionado = Convert.ToInt32(DX.Rows[NL]["NFProdutoKeyRelacionado"].ToString());
                Item.NotaFiscal = Convert.ToInt32(DX.Rows[NL]["NotaFiscal"].ToString());
                Item.NotaFiscalDevolucao = Convert.ToInt32(DX.Rows[NL]["NotaFiscalDevolucao"].ToString());
                Item.NotaFiscalDevolucaoDataEmissao = Convert.ToDateTime(DX.Rows[NL]["NotaFiscalDevolucao"].ToString());
                Item.NumeroPedido = Convert.ToInt32(DX.Rows[NL]["NumeroPedido"].ToString());
                Item.PedidoData = Convert.ToDateTime(DX.Rows[NL]["PedidoData"].ToString());
                Item.PedidoProdutoDescricao = DX.Rows[NL]["PedidoProdutoDescricao"].ToString();
                Item.PedidoProdutoKey = Convert.ToInt32(DX.Rows[NL]["PedidoProdutoKey"].ToString());
                Item.PedidoProdutoKeyFatorEstoque = Convert.ToDouble(DX.Rows[NL]["PedidoProdutoKeyFatorEstoque"].ToString());
                Item.PedidoProdutoKeyUnitario = Convert.ToInt32(DX.Rows[NL]["PedidoProdutoKeyUnitario"].ToString());
                Item.PedidoStatusDescricao = DX.Rows[NL]["PedidoStatusDescricao"].ToString();
                Item.PercentualComissao = Convert.ToDouble(DX.Rows[NL]["PedidoProdutoKeyUnitario"].ToString());
                Item.PrazoPagamentoDescricao = DX.Rows[NL]["PrazoPagamentoDescricao"].ToString();
                Item.TipoVenda = DX.Rows[NL]["TipoVenda"].ToString();
                XTbProduto.Add(Item);
            }
            return XTbProduto.ToArray();
        }


    }

    public class Update
    {
        public static int Start(modelSistemaUsuario _myConnect)
        {

            List Fv = new List(_myConnect);

            DataTable DtFvReg = Fv.getDataTable();




            DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
            List<ParameterQuey> Parametros = new List<ParameterQuey>();


            x.Begin();
            TbFVRegistros[] lst = Fv.get();
            foreach (TbFVRegistros i in lst)
            {
                Parametros.Add(new ParameterQuey("COMMAND", System.Data.SqlDbType.VarChar, false, "INSERT"));
                Parametros.Add(new ParameterQuey("NumeroPedidoBlueSoft", System.Data.SqlDbType.Int, false, i.NumeroPedido));
                x.Execute("SP_FaturamentoBlueSoft_Insert", Parametros.ToArray());
            }
            x.Commit();
            return 0;
        }
    }


}

namespace Pag_Net.Bll.Services
{
    public class PagService_Ped_Ele
    {
        /* ___ Publics ____ */
        public modelSistemaUsuario MyConnect;
        public string LogFilePath { get; set; }
        public string PedArqPath { get; set; }

        /* ___ Privates ____ */
        private ArrayList PedArqs = new ArrayList();
        //private LogFile LogFile = new LogFile();
        private ArrayList _LogProcess = new ArrayList();
        private ModelTbPedidosEletronicosEmAberto tbPedidosEletronicosEmAberto;
        /* __________________________________________________________________________________________________*/

        public void Process(modelSistemaUsuario myconnect, string logfilepath)
        {

            MyConnect = myconnect;
            LogFilePath = @logfilepath;


            _LogProcess.Add("PARAMETROS DE BANCO");
            LogFile.Write(@LogFilePath, "LOG", _LogProcess, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            _LogProcess.Clear();



            PedArqPath = @bllParameter.blLogFileetValue(MyConnect, "SER", "PagService_Ped_Ele", "PagService_Ped_Ele", "PagService_Ped_Ele_dir_export");

            PedArqs.Add("PEDIDOCAB.TXT");
            PedArqs.Add("ITENSPED.TXT");
            PedArqs.Add("PEDOBSERV.TXT");

            _LogProcess.Add("AVERIGUANDO ARQUIVOS NAO IMPORTADOS");
            LogFile.Write(@LogFilePath, "LOG", _LogProcess, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            _LogProcess.Clear();

            try
            {
                for (int ifile = 0; ifile <= PedArqs.Count - 1; ifile++)
                {
                    if (File.Exists(PedArqPath + @"\" + PedArqs[ifile].ToString().Trim()))
                    {
                        throw new Exception("ARQUIVOS GERADOS E NÃO IMPORTADOS");
                    }

                }

                _LogProcess.Add("ABERTURA DA CONEXAO");
                DaPedidosEletronicosEmAberto dalPedidosEletronicosEmAberto = new DaPedidosEletronicosEmAberto(MyConnect);

                _LogProcess.Add("LEITURA DOS REGISTROS");
                tbPedidosEletronicosEmAberto = dalPedidosEletronicosEmAberto.GetPedidosEletronicosEmAberto();

                LogFile.Write(@LogFilePath, "LOG", _LogProcess, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                _LogProcess.Clear();

                if (tbPedidosEletronicosEmAberto.ArrayListPedidos == null)
                {
                    _LogProcess.Add("a. NÃO EXISTE PEDIDOS A SEREM PROCESSADOS.");
                    LogFile.Write(@LogFilePath, "LOG", _LogProcess, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    return;
                }



                int intNumPedidos = Convert.ToInt32(tbPedidosEletronicosEmAberto.ArrayListPedidos.Count());
                int intNumItens = Convert.ToInt32(tbPedidosEletronicosEmAberto.ArrayListItens.Count());

                if (intNumPedidos == 0)
                {
                    _LogProcess.Add("b. NÃO EXISTE PEDIDOS A SEREM PROCESSADOS.");
                    LogFile.Write(@LogFilePath, "LOG", _LogProcess, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    return;
                }

                _LogProcess.Add("PEDIDOS..:  " + intNumPedidos.ToString());
                _LogProcess.Add("ITENS....:  " + intNumPedidos.ToString());

                _LogProcess.Add("PROCESSANDO..." + intNumPedidos.ToString());
                ArrayList Pedido_linha = new ArrayList();
                for (int x = 0; x <= intNumPedidos - 1; x++)
                {
                    string L = "";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Id.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Cd_Clien.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Dt_ped.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Dt_Ped_Hora + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Dt_Ped_Hora + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Dt_Prev_Fatu.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Dt_Entrega.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].FormPgto.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Cd_Tabela.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Seq_Prom.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Tp_Entrega.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Tp_Entrega.ToString() + "||";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Tp_Frete.ToString() + "||0.00|0.00||";
                    L += tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Tp_Ped.ToString() + "||1||";
                    Pedido_linha.Add(L);
                }
                ArrayList Item_Linha = new ArrayList();
                for (int x = 0; x <= intNumItens - 1; x++)
                {
                    string L = "";
                    L += tbPedidosEletronicosEmAberto.ArrayListItens[x].Id.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListItens[x].Cd_prod.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListItens[x].Qtde.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListItens[x].Preco_tabela.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListItens[x].Preco_unit.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListItens[x].Desc_apl.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListItens[x].Vl_verba.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListItens[x].Unid_ped.ToString() + "|";
                    L += tbPedidosEletronicosEmAberto.ArrayListItens[x].Bonificado.ToString() + "||||||0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00|0.00||0.00|";
                    Item_Linha.Add(L);
                }

                ArrayList Obs_Linha = new ArrayList();
                for (int x = 0; x <= intNumPedidos - 1; x++)
                {
                    if (tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Msg_Credito.ToString() != "")
                        Obs_Linha.Add(tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Id.ToString() + "|CRED|" + tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Msg_Credito.ToString());

                    if (tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Msg_Comercial.ToString() != "")
                        Obs_Linha.Add(tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Id.ToString() + "|GERV|" + tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Msg_Comercial.ToString());

                    if (tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Msg_Adm.ToString() != "")
                        Obs_Linha.Add(tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Id.ToString() + "|ADMV|" + tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Msg_Adm.ToString());

                    if (tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Msg_Fatur.ToString() != "")
                        Obs_Linha.Add(tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Id.ToString() + "|FATU|" + tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Msg_Fatur.ToString());

                    if (tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Msg_Expedicao.ToString() != "")
                        Obs_Linha.Add(tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Id.ToString() + "|EXPE|" + tbPedidosEletronicosEmAberto.ArrayListPedidos[x].Msg_Expedicao.ToString());

                }

                _LogProcess.Add("GERANDO ARQUIVOS..." + intNumPedidos.ToString());
                LogFile.Write(PedArqPath + @"\" + PedArqs[0].ToString().Trim(), "", Pedido_linha, FileMode.Create, FileAccess.Write);
                LogFile.Write(PedArqPath + @"\" + PedArqs[1].ToString().Trim(), "", Item_Linha, FileMode.Create, FileAccess.Write);
                if (Obs_Linha.Count > 0)
                    LogFile.Write(PedArqPath + @"\" + PedArqs[2].ToString().Trim(), "", Obs_Linha, FileMode.Create, FileAccess.Write);

                _LogProcess.Add("AJUSTANDO STATUS DE GERACAO " + intNumPedidos.ToString());
                dalPedidosEletronicosEmAberto.UpdateStatusAll(tbPedidosEletronicosEmAberto);


                for (int k = 0; k <= intNumPedidos - 1; k++)
                {
                    if (tbPedidosEletronicosEmAberto.ArrayListPedidos[k].StatusExportEletronico == "1")
                        _LogProcess.Add("PEDIDO: " + tbPedidosEletronicosEmAberto.ArrayListPedidos[k].Id.ToString() + " PROCESSADO");
                }
                _LogProcess.Add("FIM DO PROCESSAMENTO");
            }
            catch (Exception ex)
            {
                throw new Exception("PagService_Ped_Ele: " + ex.Message.ToString());
            }
            LogFile.Write(@LogFilePath, "LOG", _LogProcess, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }
    }
    public static class PagServiceZanthusProcessaEnvio
    {
        public static void Processa(modelSistemaUsuario Myconnect)
        {
            try
            {
                string dirExport = bllParameter.blLogFileetValue(Myconnect, "WPF", "Operacional - Loja - Execução - Atualização", "ACESSO_GERAL_m2114", "PagService_MGV_path_dir_txtitens");
                if (dirExport == null)
                {
                    throw new Exception("Parâmetro não encontrado na lista de acessos - PROCURE O ADMINISTRADOR DO SISTEMA. CARGA NÃO ENVIADA");
                }
                if (Directory.Exists(dirExport) == false)
                {
                    throw new Exception("O Diretório para exportação do Arquivo MGV não está acessível. Favor averiguar o acesso ao diretório: " + dirExport.ToString());
                }
                Dal.PagProcPackagesZanthus.ProcessaBancoZanthus(Myconnect);
                Util.ExportFileText(Dal.PagProcPackagesZanthus.ProcessaArquivo(Myconnect), dirExport);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public class PagServiceImportSitef
    {
        private modelSistemaUsuario MyConnect;
        private string _strCaminhoNomeArquivoAProcessar;
        private string _strCaminhoNomeArquivoLogItensProcessados = "";

        private String[] _strLinhasAProcessar;
        private List<TbSitefLogs> _TbSitefLogs = new List<TbSitefLogs>();
        private List<string> _strLogLinhasProcessadas = new List<string>();
        private ArrayList _Processamento = new ArrayList();
        private ArrayList _LogProcessamento = new ArrayList();
        private DateTime _DataProcessamento;
        public void Processa(modelSistemaUsuario myconnect, string _LogService)
        {
            Processa(myconnect, _LogService, DateTime.Now);
        }
        public void Processa(modelSistemaUsuario myconnect, string _LogService, DateTime dataprocessamento)
        {
            try
            {
                _DataProcessamento = dataprocessamento;
                MyConnect = myconnect;
                _LogProcessamento.Add("Variaveis definida");
                bool _processo1 = false;
                bool _processo3 = false;
                bool _processo4 = false;
                _LogProcessamento.Add("PROCESSO 1 - DEFINICAO DE ARQUIVOS");
                _processo1 = fArquivoLeitura();
                if (_processo1)
                {
                    _LogProcessamento.Add("PROCESSO 2 - CONFERINDO");
                    _processo3 = fArquivosAbertura();
                }
                if (_processo3)
                {
                    _LogProcessamento.Add("PROCESSO 4 - PROCESSAMENTO");
                    _processo4 = fProcessamento();
                }
                _LogProcessamento.Add("SERVICO CONCLUINDO GRAVANDO LOG");
                LogFile.Write(@_LogService, "LOG", _LogProcessamento, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            }
            catch (Exception ex)
            {
                _LogProcessamento.Add(string.Format("ERRO PROCESSAMENTO SITEF: {0}", ex.ToString()));
                LogFile.Write(@_LogService, "LOG", _LogProcessamento, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
        }
        private bool fArquivoLeitura()
        {
            try
            {
                this._strCaminhoNomeArquivoAProcessar = Pag_Net.Tools.StringPag.Replicate(_DataProcessamento.Month.ToString().Trim(), "0", StringPag.TypeReplicate.Prepend, 2 - _DataProcessamento.Month.ToString().Trim().Length);
                this._strCaminhoNomeArquivoAProcessar = _strCaminhoNomeArquivoAProcessar + Pag_Net.Tools.StringPag.Replicate(_DataProcessamento.Day.ToString().Trim(), "0", StringPag.TypeReplicate.Prepend, 2 - _DataProcessamento.Day.ToString().Trim().Length);
                this._strCaminhoNomeArquivoAProcessar = "LOG_" + _strCaminhoNomeArquivoAProcessar + ".PRN";
                this._strCaminhoNomeArquivoAProcessar = @bllParameter.blLogFileetValue(MyConnect, "SER", "PagService_SITEF", "PagService_SITEF", "PagService_SITEF_DirImport") + @"\" + _strCaminhoNomeArquivoAProcessar;
                _LogProcessamento.Add(string.Format("ARQUIVO DE LEITURA: {0}", _strCaminhoNomeArquivoAProcessar));
                if (!File.Exists(this._strCaminhoNomeArquivoAProcessar))
                {
                    throw new Exception("ARQUIVO NAO ENCONTRADO!");
                }
                return true;
            }
            catch (Exception ex)
            {
                _LogProcessamento.Add(string.Format("ERRO PROCESSO 1 - ABERTURA DE ARQUIVO DE LEITURA: {0} - {1}", _strCaminhoNomeArquivoAProcessar, ex.Message.ToString()));
                return false;
            }


        }
        private bool fArquivosAbertura()
        {
            try
            {
                _LogProcessamento.Add("LENDO ARQUIVOS...");
                _strLinhasAProcessar = Pag_Net.Tools.LogFile.ReadLine(_strCaminhoNomeArquivoAProcessar);
                return true;
            }
            catch (Exception ex)
            {
                _LogProcessamento.Add(string.Format("ERRO PROCESSO 3 - {0} - ABERTURA DOS ARQUIVOS SITEF/LOG DE PROCESSAMENTO {0}, {1}", ex.Message.ToString(), _strCaminhoNomeArquivoAProcessar, _strCaminhoNomeArquivoLogItensProcessados));
                return false;
            }

        }
        private bool fProcessamento()
        {

            Pag_Net.Bll.Financeiro.CartaoCredito.LogSitef LogSitef = new Financeiro.CartaoCredito.LogSitef(MyConnect);
            bool X = false;
            try
            {
                LogSitef.Importar.ArquivoSitefLog = this._strCaminhoNomeArquivoAProcessar;
                LogSitef.Importar.Processa();
                X = true;
            }
            catch (Exception ex)
            {

                _LogProcessamento.Add(string.Format("ERRO PROCESSO 4 - PROCESSAMENTO DE LEITURA: {0}", ex.Message.ToString()));
                X = false;
            }
            foreach (string i in LogSitef.Importar.ProcessamentoLog)
            {
                _LogProcessamento.Add(i);
            }
            return X;

        }


    }
    public static class PagServicePrecosOperacionais
    {
        public static void Processa(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            Dal.PagProcPrecosOperacionais.Processa(_myConnect);
        }
    }
    public static class PagServiceImportarArquivos
    {

        public static int Processar(Pag_Net.Models.modelSistemaUsuario _myConnect, ManagerFileInfo Arquivo)
        {
            return Processar(_myConnect, Arquivo, true);
        }


        public static int Processar(Pag_Net.Models.modelSistemaUsuario _myConnect, ManagerFileInfo Arquivo, bool RegistrarLinhas)
        {

            try
            {

                DataTable ArquivoLinhas;
                ManagerFile _ManagerFile = new ManagerFile();

                Dal.DbUpdate DalUpdate = new Dal.DbUpdate(_myConnect, Dal.DataBaseName.DBAMAINADM);
                DalUpdate.Begin();
                List<ParameterQuey> listParametroInfo = new List<ParameterQuey>();


                string FileRegistro = Convert.ToDateTime(Arquivo.FileDate.ToString()).ToString("yyyyMMdd") + Convert.ToInt32(Arquivo.FileLenth).ToString("0000000000000000");

                listParametroInfo.Add(new ParameterQuey("Command", SqlDbType.VarChar, false, "INSERT"));
                listParametroInfo.Add(new ParameterQuey("Descricao", SqlDbType.VarChar, false, Arquivo.FileName));
                listParametroInfo.Add(new ParameterQuey("Registro", SqlDbType.VarChar, false, FileRegistro));
                listParametroInfo.Add(new ParameterQuey("DataArquivo", SqlDbType.DateTime, false, Arquivo.FileDate));
                listParametroInfo.Add(new ParameterQuey("cd_usr_import", SqlDbType.VarChar, false, _myConnect.user_name));
                listParametroInfo.Add(new ParameterQuey("Numerolinhas", SqlDbType.Int, false, Arquivo.FileRows));
                listParametroInfo.Add(new ParameterQuey("NumeroColunas", SqlDbType.Int, false, Arquivo.FileColumns));
                listParametroInfo.Add(new ParameterQuey("Tamanho", SqlDbType.Int, false, Arquivo.FileLenth));
                listParametroInfo.Add(new ParameterQuey("TipoArquivo", SqlDbType.VarChar, false, Arquivo.TipoArquivo));

                if (!RegistrarLinhas)
                {
                    listParametroInfo.Add(new ParameterQuey("ArquivoProcessado", SqlDbType.Bit, false, 1));
                }


                DataSet Dados = DalUpdate.ExecuteGetDataset("SP_ArquivoImportacao", listParametroInfo.ToArray());
                int seqImportacao = Convert.ToInt32(Dados.Tables[0].Rows[0][0].ToString());

                if (RegistrarLinhas)
                {
                    ArquivoLinhas = _ManagerFile.View(Arquivo);

                    string linha = "";
                    for (int li = 0; li <= ArquivoLinhas.Rows.Count - 1; li++)
                    {

                        if (Arquivo.FileType == ".TXT")
                        {
                            linha = ArquivoLinhas.Rows[li][0].ToString();
                        }
                        else
                        {
                            for (int col = 0; col <= ArquivoLinhas.Columns.Count - 1; col++)
                            {
                                linha = linha + ArquivoLinhas.Rows[li][col].ToString().Replace(";", "").Replace("'", "");
                                if (col < ArquivoLinhas.Columns.Count - 1) linha = linha + ";";
                            }
                        }
                        List<ParameterQuey> listParametroInfoLinha = new List<ParameterQuey>();
                        listParametroInfoLinha.Add(new ParameterQuey("Command", SqlDbType.VarChar, false, "INSERT"));
                        listParametroInfoLinha.Add(new ParameterQuey("SeqImportacao", SqlDbType.Int, false, seqImportacao));
                        listParametroInfoLinha.Add(new ParameterQuey("NumeroLinha", SqlDbType.Int, false, li));
                        listParametroInfoLinha.Add(new ParameterQuey("Linha", SqlDbType.VarChar, false, linha));
                        DalUpdate.ExecuteGetDataset("SP_ArquivoImportacaoLinha", listParametroInfoLinha.ToArray());
                        linha = "";
                    }
                }
                DalUpdate.Commit();

                return seqImportacao;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }



}

namespace Pag_Net.Bll.Tools
{
    public class ManagerFilesImports : Bll.USPDataContext
    {
        public ManagerFilesImports(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {

        }
        public void Reflesh()
        {
            base.Select();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> pList = new List<ParameterQuey>();
            pList.Add(new ParameterQuey("@Command", System.Data.SqlDbType.VarChar, false, "SELECT"));
            return pList.ToArray();

        }


        public override object GetParametros()
        {
            return null;
        }
        public override string SQLCommnad()
        {
            return "SP_ArquivoImportacao";
        }


    }


  

    public static class ManagerFileProcess
    {
        public static int Proc(modelSistemaUsuario _myConnect)
        {
            int NumeroRegistros = 0;
            Pag_Net.Dal.DbUpdate clsUpdate = new DbUpdate(_myConnect, Dal.DataBaseName.DBAMAINADM);
            clsUpdate.Begin();
            NumeroRegistros = clsUpdate.Execute("SP_ArquivoImportacaoProcessar", null);
            clsUpdate.Commit();
            return NumeroRegistros;
        }

        public static int Arquivar(modelSistemaUsuario _myConnect, int _SequencialArquivo)
        {
            int NumeroRegistros = 0;
            if (_SequencialArquivo == 0)
            {
                throw new Exception("Valor de Sequencial de Arquivo Inválido");
            }
            else
            {
                Pag_Net.Dal.DbUpdate clsUpdate = new DbUpdate(_myConnect, Dal.DataBaseName.DBAMAINADM);
                clsUpdate.Begin();
                List<ParameterQuey> ListParametros = new List<ParameterQuey>();
                ListParametros.Add(new ParameterQuey("SeqImportacao", System.Data.SqlDbType.Int, false, _SequencialArquivo));
                NumeroRegistros = clsUpdate.Execute("SP_ArquivoImportacaoArquivar", ListParametros.ToArray());
                clsUpdate.Commit();
            }
            return NumeroRegistros;
        }



    }

   


    public class CmdLine
    {

        public static string Execute(string comando)
        {
            using (System.Diagnostics.Process processo = new System.Diagnostics.Process())
            {
                processo.StartInfo.FileName = Environment.GetEnvironmentVariable("CMD.EXE");

                // Formata a string para passar como argumento para o cmd.exe
                processo.StartInfo.Arguments = string.Format("/c {0}", comando);

                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.CreateNoWindow = true;

                processo.Start();
                processo.WaitForExit();

                string saida = processo.StandardOutput.ReadToEnd();
                return saida;
            }
        }

    }

}

