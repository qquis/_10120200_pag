using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;
using Pag_Net.Models;



namespace Pag_Net.Dal.SqlServer.SPR0050ServicesTimes
{
    public static class
        Info
    {
        public static string Base() { return "SQL SERVER"; }
        public static string ReadingTables() { return "TbServices, TbServicesTime"; }
        public static string RecordingTable() { return "TbDocumentosFiscais"; }
        public static string AccessProcedure() { return "SPR0050ServicesTimes"; }
        public static string BusinessRuleModel() { return "SPR0050ServicesTimes"; }
        public static string DataBase() { return "*"; }
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


        public static Pag_Net.Models.SPR0050ServicesTimes[]
                      GetModel(ModelSysUserInfo _TbSysUserInfo, Pag_Net.Models.SPR0050ServicesTimes _Model)
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
                      GetDataTable(ModelSysUserInfo _TbSysUserInfo, Pag_Net.Models.SPR0050ServicesTimes _Model)
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
                      Execute(Pag_Net.Dal.DataTypeExecute _DataTypeExecute, DbUpdate _ConnectionSqlExecute, Pag_Net.Models.SPR0050ServicesTimes _Model)
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
                      ParameterFill(string SqlCommand, Pag_Net.Models.SPR0050ServicesTimes _Model)
        {
            List<ParameterQuey> ParametrosQuery = new System.Collections.Generic.List<ParameterQuey>();
            ParametrosQuery.Clear();

            //Sql Command Execute
            ParametrosQuery.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, true, SqlCommand));
            ParametrosQuery.Add(new ParameterQuey("_SPParameterServiceOwner", SqlDbType.VarChar, true, _Model._SPParameterServiceOwner));

            return ParametrosQuery.ToArray();
        }


        private static Pag_Net.Models.SPR0050ServicesTimes[] ModelFill(DataTable _Result)
        {
            List<Pag_Net.Models.SPR0050ServicesTimes> list = new List<Models.SPR0050ServicesTimes>();
            foreach (DataRow i in _Result.Rows)
            {
                list.Add(new Models.SPR0050ServicesTimes(i));
            }
            return list.ToArray();
        }

    }


}
