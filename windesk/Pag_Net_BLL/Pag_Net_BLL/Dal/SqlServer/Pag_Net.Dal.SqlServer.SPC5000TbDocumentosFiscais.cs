using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;
using Pag_Net.Models;



namespace Pag_Net.Dal.SqlServer.SPC5000TbDocumentosFiscais
{
    public static class
        Info 
    {
        public static string Base() { return "SQL SERVER"; }
        public static string ReadingTables() { return "TbDocumentosFiscais"; }
        public static string RecordingTable() { return "TbDocumentosFiscais"; }
        public static string AccessProcedure() { return "SPC5000TbDocumentosFiscais"; }
        public static string BusinessRuleModel() { return "SPC5000TbDocumentosFiscais"; }
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


        public static Pag_Net.Models.SPC5000TbDocumentosFiscais[]
                      GetModel(modelSistemaUsuario _TbSysUserInfo, Pag_Net.Models.SPC5000TbDocumentosFiscais _Model)
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
                      GetDataTable(modelSistemaUsuario _TbSysUserInfo, Pag_Net.Models.SPC5000TbDocumentosFiscais _Model)
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
                      Execute(Pag_Net.Dal.DataTypeExecute _DataTypeExecute, DbUpdate _ConnectionSqlExecute, Pag_Net.Models.SPC5000TbDocumentosFiscais _Model)
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
                      ParameterFill(string SqlCommand, Pag_Net.Models.SPC5000TbDocumentosFiscais _Model)
        {
            List<ParameterQuey> ParametrosQuery = new System.Collections.Generic.List<ParameterQuey>();
            ParametrosQuery.Clear();

            //Sql Command Execute
            ParametrosQuery.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, true, SqlCommand));

            //Parametrs 
            ParametrosQuery.Add(new ParameterQuey("_SPParameterDestinatarioCNPJ", SqlDbType.VarChar, true, _Model._SPParameterDestinatarioCNPJ));
            ParametrosQuery.Add(new ParameterQuey("_SPParameterRemetenteCNPJ", SqlDbType.VarChar, true, _Model._SPParameterRemetenteCNPJ));
            ParametrosQuery.Add(new ParameterQuey("_SPParameterNfe", SqlDbType.Int, true, _Model._SPParameterNfe));
            ParametrosQuery.Add(new ParameterQuey("_SPParameterSerie", SqlDbType.VarChar, true, _Model._SPParameterSerie));

            
            ParametrosQuery.Add(new ParameterQuey("_SPParameterDataFaturamentoInicial", SqlDbType.SmallDateTime, false, _Model._SPParameterDataFaturamentoInicial ));
            ParametrosQuery.Add(new ParameterQuey("_SPParameterDataFaturamentoFinal", SqlDbType.SmallDateTime, false, _Model._SPparameterDataFaturamentoFinal ));
            

            //Model reader 
            //Model reader 
            //ParametrosQuery.Add(new ParameterQuey("SeqDocumentoFiscal", SqlDbType.Int, false, _Model.SeqDocumentoFiscal));



            ParametrosQuery.Add(new ParameterQuey("BlueSoftEmpresaId", SqlDbType.Int, false, _Model.BlueSoftEmpresaId));
            ParametrosQuery.Add(new ParameterQuey("BlueSoftSequencial", SqlDbType.Int, false, _Model.BlueSoftSequencial));
            ParametrosQuery.Add(new ParameterQuey("BlueSoftUsuarioCancelamento", SqlDbType.Int, false, _Model.BlueSoftUsuarioCancelamento));
            ParametrosQuery.Add(new ParameterQuey("TargetEmpresaId", SqlDbType.Int, false, _Model.TargetEmpresaId));
            ParametrosQuery.Add(new ParameterQuey("TargetSequencial", SqlDbType.Int, false, _Model.TargetSequencial));
            ParametrosQuery.Add(new ParameterQuey("Nfe", SqlDbType.Int, false, _Model.Nfe));
            ParametrosQuery.Add(new ParameterQuey("SerieNumero", SqlDbType.Int, false, _Model.SerieNumero));
            ParametrosQuery.Add(new ParameterQuey("CdParticipanteRemetente", SqlDbType.Int, false, _Model.CdParticipanteRemetente));
            ParametrosQuery.Add(new ParameterQuey("CdParticipanteDestinatario", SqlDbType.Int, false, _Model.CdParticipanteDestinatario));
            ParametrosQuery.Add(new ParameterQuey("TargetSequencialOrigem", SqlDbType.Int, false, _Model.TargetSequencialOrigem));
            ParametrosQuery.Add(new ParameterQuey("BlueSoftSequencialOrigem", SqlDbType.Int, false, _Model.BlueSoftSequencialOrigem));
            ParametrosQuery.Add(new ParameterQuey("BlueSoftNfCdTipo", SqlDbType.Int, false, _Model.BlueSoftNfCdTipo));


            ParametrosQuery.Add(new ParameterQuey("DataFaturamento", SqlDbType.SmallDateTime, false, _Model.DataFaturamento));
            ParametrosQuery.Add(new ParameterQuey("DataSaida", SqlDbType.SmallDateTime, false, _Model.DataSaida));
            ParametrosQuery.Add(new ParameterQuey("BlueSoftDataCancelamento", SqlDbType.SmallDateTime, false, _Model.BlueSoftDataCancelamento));



            ParametrosQuery.Add(new ParameterQuey("Serie", SqlDbType.VarChar, false, _Model.Serie));
            ParametrosQuery.Add(new ParameterQuey("ChaveNfe", SqlDbType.VarChar, false, _Model.ChaveNfe));
            ParametrosQuery.Add(new ParameterQuey("RemetenteCNPJ", SqlDbType.VarChar, false, _Model.RemetenteCNPJ));
            ParametrosQuery.Add(new ParameterQuey("DestinatarioCNPJ", SqlDbType.VarChar, false, _Model.DestinatarioCNPJ));
            ParametrosQuery.Add(new ParameterQuey("DestinatarioUF", SqlDbType.VarChar, false, _Model.DestinatarioUF));
            ParametrosQuery.Add(new ParameterQuey("StatusDocumentoFiscal", SqlDbType.VarChar, false, _Model.StatusDocumentoFiscal));
            ParametrosQuery.Add(new ParameterQuey("BlueSoftNfDescricaoTipo", SqlDbType.VarChar, false, _Model.BlueSoftNfDescricaoTipo));

            ParametrosQuery.Add(new ParameterQuey("ValorNotaFiscal", SqlDbType.Decimal, false, _Model.ValorNotaFiscal));
            ParametrosQuery.Add(new ParameterQuey("ValorProdutos", SqlDbType.Decimal, false, _Model.ValorProdutos));

            ParametrosQuery.Add(new ParameterQuey("SistemaTarget", SqlDbType.Bit, false, _Model.SistemaTarget));
            ParametrosQuery.Add(new ParameterQuey("SistemaBlueSoft", SqlDbType.Bit, false, _Model.SistemaBlueSoft));
            ParametrosQuery.Add(new ParameterQuey("BlueSoftRegistroCancelado", SqlDbType.Bit, false, _Model.BlueSoftRegistroCancelado));

        


       

            return ParametrosQuery.ToArray();
        }


        private static Pag_Net.Models.SPC5000TbDocumentosFiscais[] ModelFill(DataTable _Result)
        {
            List<Pag_Net.Models.SPC5000TbDocumentosFiscais> list = new List<Models.SPC5000TbDocumentosFiscais>();
            foreach (DataRow i in _Result.Rows)
            {
                list.Add(new Models.SPC5000TbDocumentosFiscais(i));
            }
            return list.ToArray();
        }

    }


}