using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;
using Pag_Net.Models;



namespace Pag_Net.Dal.SqlServer.SPC0015TbProdutoBlueSoft
{
    public static class
        Info 
    {
        public static string Base() { return "SQL SERVER"; }
        public static string ReadingTables() { return "TbProdutoBlueSoft"; }
        public static string RecordingTable() { return "TbProdutoBlueSoft"; }
        public static string AccessProcedure() { return "SPC0015TbProdutoBlueSoft"; }
        public static string BusinessRuleModel() { return "SPC0015TbProdutoBlueSoft"; }
        public static string DataBase() { return "*";  }
        public static string Get()
        {
            return string.Format("Base de Dados: {0} Tabela de Leitura {1} Tabela de Gravação: {2} Procedure de Acesso: {3}, Modelo da Regra de Negócio Destino: {4}",
                          DataBase(),
                          ReadingTables(),
                          RecordingTable(),
                          AccessProcedure(),
                          BusinessRuleModel());
        }
        public static string Error(string _Method, string _ComplementaryInformation)
        {
            return string.Format("Informações {0}, Método {1}, Erro: {2}", Get(), _Method, _ComplementaryInformation);
        }
    }
    public static class
        Data
    {


        public static Pag_Net.Models.SPC0015TbProdutoBlueSoft[]
                      GetModel(ModelSysUserInfo _TbSysUserInfo, Pag_Net.Models.SPC0015TbProdutoBlueSoft _Model)
        {
            try
            {
                return ModelFill(DbSelect.GetDataSet(_TbSysUserInfo, DataBaseName.DBAMAINADM, Info.AccessProcedure(), ParameterFill("DbSelect", _Model)).Tables[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(Info.Error("GetModel", ex.Message));
            }

        }

        public static DataTable
                      GetDataTable(ModelSysUserInfo _TbSysUserInfo, Pag_Net.Models.SPC0015TbProdutoBlueSoft _Model)
        {
            try
            {
                return DbSelect.GetDataSet(_TbSysUserInfo, DataBaseName.DBAMAINADM, Info.AccessProcedure(), ParameterFill("DbSelect", _Model)).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(Info.Error("GetModel", ex.Message));
            }
        }

        public static void
                      Execute(Pag_Net.Dal.DataTypeExecute _DataTypeExecute, DbUpdate _ConnectionSqlExecute, Pag_Net.Models.SPC0015TbProdutoBlueSoft _Model)
        {
            try
            {
                switch (_DataTypeExecute)
                {
                    case DataTypeExecute.DbInsert:
                        _ConnectionSqlExecute.Execute(Info.AccessProcedure(), ParameterFill("DbInsert", _Model));
                        break;
                    case DataTypeExecute.DbUpdate:
                        _ConnectionSqlExecute.Execute(Info.AccessProcedure(), ParameterFill("DbUpdate", _Model));
                        break;
                    case DataTypeExecute.DbDelete:
                        _ConnectionSqlExecute.Execute(Info.AccessProcedure(), ParameterFill("DbDelete", _Model));
                        break;
                    case DataTypeExecute.DbDeleteAll:
                        _ConnectionSqlExecute.Execute(Info.AccessProcedure(), ParameterFill("DbDeleteAll", _Model));
                        break;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(Info.Error(_DataTypeExecute.ToString(), ex.Message));
            }
        }

        private static ParameterQuey[]
                      ParameterFill(string SqlCommand, Pag_Net.Models.SPC0015TbProdutoBlueSoft _Model)
        {
            List<ParameterQuey> ParametrosQuery = new System.Collections.Generic.List<ParameterQuey>();
            ParametrosQuery.Clear();

            //Sql Command Execute
            ParametrosQuery.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, true, SqlCommand));

            //Parametrs 
            ParametrosQuery.Add(new ParameterQuey("_CdProdutoBlueSoft", SqlDbType.Int, true, _Model._SPParameterCdProdutoBlueSoft));
            ParametrosQuery.Add(new ParameterQuey("_Descricao", SqlDbType.VarChar, true, _Model._SPParameterDescricao));

            //Model reader 
            ParametrosQuery.Add(new ParameterQuey("CdProduto", SqlDbType.Int, false, _Model.CdProduto));
            ParametrosQuery.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, false, _Model.CdProdutoBlueSoft));
            ParametrosQuery.Add(new ParameterQuey("CdProdutoBlueSoftUnitario", SqlDbType.Int, false, _Model.CdProdutoBlueSoftUnitario));
            ParametrosQuery.Add(new ParameterQuey("Descricao", SqlDbType.VarChar, false, _Model.Descricao));
            ParametrosQuery.Add(new ParameterQuey("CodigoBarraReferencia", SqlDbType.VarChar, false, _Model.CodigoBarraReferencia));
            ParametrosQuery.Add(new ParameterQuey("EmbalagemEstoque", SqlDbType.VarChar, false, _Model.EmbalagemEstoque));
            ParametrosQuery.Add(new ParameterQuey("FatorEstoque", SqlDbType.Decimal, false, _Model.FatorEstoque));
            ParametrosQuery.Add(new ParameterQuey("CdProdutoBlueSoftControleEstoque", SqlDbType.Int, false, _Model.CdProdutoBlueSoftControleEstoque));
            ParametrosQuery.Add(new ParameterQuey("CdProdutoBlueSoftControlePreco", SqlDbType.Int, false, _Model.CdProdutoBlueSoftControlePreco));
            ParametrosQuery.Add(new ParameterQuey("DepartamentoKey", SqlDbType.Int, false, _Model.DepartamentoKey));
            ParametrosQuery.Add(new ParameterQuey("SecaoKey", SqlDbType.Int, false, _Model.SecaoKey));
            ParametrosQuery.Add(new ParameterQuey("GrupoKey", SqlDbType.Int, false, _Model.GrupoKey));
            ParametrosQuery.Add(new ParameterQuey("SubGrupoKey", SqlDbType.Int, false, _Model.SubGrupoKey));
            ParametrosQuery.Add(new ParameterQuey("FabricanteKey", SqlDbType.Int, false, _Model.FabricanteKey));
            ParametrosQuery.Add(new ParameterQuey("StatusProduto", SqlDbType.Bit, false, _Model.StatusProduto));
            ParametrosQuery.Add(new ParameterQuey("VendaExterna", SqlDbType.Bit, false, _Model.VendaExterna));
            ParametrosQuery.Add(new ParameterQuey("EmbalagemCompra", SqlDbType.VarChar, false, _Model.EmbalagemCompra));
            ParametrosQuery.Add(new ParameterQuey("EmbalagemCompraQtdeUnitaria", SqlDbType.Decimal, false, _Model.EmbalagemCompraQtdeUnitaria));
            ParametrosQuery.Add(new ParameterQuey("DataUltimaAlteracao", SqlDbType.DateTime, false, _Model.DataUltimaAlteracao));
            ParametrosQuery.Add(new ParameterQuey("DataCadastro", SqlDbType.DateTime, false, _Model.DataCadastro));

            return ParametrosQuery.ToArray();
        }


        private static Pag_Net.Models.SPC0015TbProdutoBlueSoft[] ModelFill(DataTable _Result)
        {
            List<Pag_Net.Models.SPC0015TbProdutoBlueSoft> list = new List<Models.SPC0015TbProdutoBlueSoft>();
            foreach (DataRow i in _Result.Rows)
            {
                list.Add(new Models.SPC0015TbProdutoBlueSoft(i));
            }
            return list.ToArray();
        }

    }


}