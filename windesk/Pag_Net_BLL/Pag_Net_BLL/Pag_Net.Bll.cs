using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;
using RestSharp;
using System.ComponentModel;
using System.Xml;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.ComponentModel.DataAnnotations;
using Pag_Net.Tools.CryptFile;
using Pag_Net.Tools.CryptPassWord;

using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Windows.Controls;
using System.Data.OleDb;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;






/*
 * old defines 06/11/2024
 * 
*/

namespace Pag_Net.Bll
{
    public enum PagExceptionType{
        Info,
        Error
    }
    public class DBDataTable
    {
        public DataTable List { get; set; }
        public int Count { get; set; }
        public DBDataTable(DataTable __myList)
        {
            List = __myList;
            Count = __myList.Rows.Count;
        }

    }
    public static class BDCommand
    {
        public enum Name
        {
            R0031_01,
            F0020_20_ProdutoDepartamento_Consulta,
            F0020_21_Produto_Secao_Encarregado_Consultar,
            R0011_01,
            R0011_02,
            F0011_60_tbparticipantepessoa_list,
            F0012_05_tbgrupoeconomico_list,
            F0055_06_tbfaturamentoBlueSoft,
            F0055_07_tbfaturamentoBlueSoft_item,
            F0055_08_tbfaturamentoBlueSoft_origem,
            F0055_20_Faturamento_Zanthus_Consultar,
            R0110_01,
            R0110_02,
            R0130_01,
            R0130_02,
            
            R0130_04_controle_dados_historico,
            R0130_05_controle_reg_etapa_list,
            R0130_06_controle_reg_numero_proximo,

            R0131_01_Veiculo_Consulta,
            R0131_03,

            F0002_20_Empresa_Operacao_User_Consulta,
            F0011_01,            
            F0011_03,
            F0011_04,
            F0011_10_tbpessoabluesoft_consultar,
            
            F0060_01,
            F0060_02,
            F0060_03,
            F0060_04,
            F0060_07_DocumentoFiscalOrigem,
            F0060_08_documentofiscalregistro_excluir_procedimento,
            F0060_09_documentofiscalregistro_status_recebimento,
            F0060_30_documentofiscalregistro_consultar,
            F0060_40_documentofiscal_consultar,
            
            F0062_02_GuardianTicket_List, 
            
            /*Estoque CUSTO */
            F0030_01_TbEstoqueCusto_CRUD,
            F0030_90_EstoqueCustoDiario_Processamento,
            F0030_91_EstoqueCusto_Processamento,


            F0049_01,
            F0050_01,
            F0055_50_Faturamento_Relatorio_Analise_Basica,
            F0055_03_Faturamento_Excluir,
            F0053_01,

            F0105_20_zanthus_voucher_cli_consultar,

            F0110_01,
            F0130_01,
            F0130_02,
            F0130_03,
            F0130_04,
            F0130_05_controle_etapa_finalizar,
            F0130_06_controle_reg_pgto, 
            F0130_07_controle_dados_consultar,
            F0130_08_controle_reg_pgto_consultar,
            F0130_09_controle_status_consultar,
            F0130_10_controle_reg_list,
            F0131_01,
            F0132_01_tbfat_res_comercial_consulta_relacional, 
            F0132_02_comercial_pre_pedido_crud_result, 
            F0132_03_comercial_pre_pedido_item_update,
            F0132_04_tbcomercial_pre_pedido_list,
            F0132_05_tbcomercial_pre_pedido_item_list,
            F0132_06_comercial_pre_pedido_pgtos,
            F0132_90_processo_fat_res_comercial,
            F0133_10_Comercial_PedidoBlusoft_List,

            F0140_01_preco_list_select,
            F0140_02_preco_inativar_item_list,

            F0141_01_rh_funcionario,
            F0141_02_rh_funcionario_ctrl_crud,
            F0141_03_rh_funcionario_ctrl_list,

            F9010_01_sistema_log,
            P0001_01,
            P0010_01, 
            P0010_02, 

        }
        public static string ScriptSQL(Name _function)
        {
            string _name_function = "";
            switch (_function)
            {
                //FUNCTIONS
                case Name.F0002_20_Empresa_Operacao_User_Consulta: _name_function = "f0002_20_1012008_empresa_operacao_user_consulta"; break;
                case Name.F0020_21_Produto_Secao_Encarregado_Consultar: _name_function = "f0020_21_1011900_produtosecao_encarregado"; break;



                case Name.F0030_01_TbEstoqueCusto_CRUD: _name_function = "f0030_01_1011859_crud_tbestoquecusto"; break;
                case Name.F0030_90_EstoqueCustoDiario_Processamento: _name_function = "f0030_90_1011921_estoquecustos_diario_processamento"; break;
                case Name.F0030_91_EstoqueCusto_Processamento: _name_function = "f0030_91_1011213_estoquecustos_processamento"; break;


                case Name.F0105_20_zanthus_voucher_cli_consultar: _name_function = "f0105_20_1011911_zanthus_voucher_cli_consultar"; break;


                //PESSOA
                case Name.R0011_01: _name_function = "r0011_01_1011870_pessoa_list"; break;
                case Name.R0011_02: _name_function = "r0011_02_1011870_pessoa_dados"; break;
                case Name.F0011_60_tbparticipantepessoa_list: _name_function = "f0011_60_1011911_tbparticipantepessoa_list"; break;
                case Name.F0012_05_tbgrupoeconomico_list: _name_function = "f0012_05_1011910_tbgrupoeconomico_list"; break;
                
                //FATURAMENTO
                case Name.F0055_06_tbfaturamentoBlueSoft: _name_function = "f0055_06_1011877_tbfaturamentoBlueSoft"; break;
                case Name.F0055_07_tbfaturamentoBlueSoft_item: _name_function = "f0055_07_1011877_tbfaturamentoBlueSoft_item"; break;
                case Name.F0055_08_tbfaturamentoBlueSoft_origem: _name_function = "f0055_08_1011881_tbfaturamentobluesoft_origem"; break;
                
                //CUSTO ENTRADA
                case Name.R0031_01: _name_function = "r0031_01_1011858_estoquecusto_entrada"; break;
                //PRODUTO DEPARTAMENTO
                case Name.F0020_20_ProdutoDepartamento_Consulta: _name_function = "f0020_20_1011900_produtodepartamento"; break;
                case Name.F0062_02_GuardianTicket_List: _name_function = "f0062_02_guardianticket_list"; break; 


                //PRODUTO VOUCHER
                case Name.R0110_01: _name_function = "r0110_01_1011870_voucher_list"; break;
                case Name.R0110_02: _name_function = "r0110_02_1011870_voucher_valid_insert"; break;

                case Name.R0130_01: _name_function = "r0130_01_1011870_controle_consulta"; break;
                case Name.R0130_02: _name_function = "r0130_02_1011870_controle_fila_consulta"; break;
                
                case Name.R0130_04_controle_dados_historico: _name_function = "r0130_04_controle_dados_historico"; break;
                case Name.R0130_05_controle_reg_etapa_list: _name_function = "r0130_05_1011873_controle_reg_etapa_list"; break;
                case Name.R0130_06_controle_reg_numero_proximo: _name_function = "r0130_06_1011870_controle_reg_numero_proximo"; break;
                case Name.F0130_08_controle_reg_pgto_consultar: _name_function = "f0130_08_1011870_controle_dados_pgto_consultar"; break; 
                case Name.R0131_01_Veiculo_Consulta: _name_function = "r0131_01_1011870_veiculo_consulta"; break;
                case Name.R0131_03: _name_function = "r0131_03_1011870_veiculo_modelo_list"; break;
                
                //PESSOA                
                case Name.F0011_01: _name_function = "f0011_01_0111870_tbpessoa"; break;
                case Name.F0011_03: _name_function = "f0011_03_0111870_tbpessoabluesoft"; break;
                case Name.F0011_04: _name_function = "f0011_04_0111870_tbparticipante_endereco"; break;
                case Name.F0011_10_tbpessoabluesoft_consultar: _name_function = "f0011_10_1011880_tbpessoabluesoft_consultar"; break;

                case Name.F0053_01: _name_function = "F0053_CRUD_TBFATURAMENTO_INTEGRACAO_ZANTHUS"; break;

                case Name.F0055_03_Faturamento_Excluir: _name_function = "f0055_03_1011911_faturamento_excluir"; break;
                case Name.F0055_50_Faturamento_Relatorio_Analise_Basica: _name_function = "f0055_50_1011911_faturamento_rel_analise_basica"; break;
                case Name.F0055_20_Faturamento_Zanthus_Consultar: _name_function = "f0055_20_1011911_faturamento_zanthus_consultar"; break;
                case Name.F0060_01: _name_function = "f0060_01_1011911_tbdocumentofiscal"; break;
                case Name.F0060_02: _name_function = "f0060_02_1011870_tbdocumentofiscalitem"; break;
                case Name.F0060_03: _name_function = "f0060_03_1011872_tbdocumentofiscalregistro"; break;
                case Name.F0060_04: _name_function = "f0060_04_1011870_documentofiscal_seq"; break;
                case Name.F0060_07_DocumentoFiscalOrigem: _name_function = "f0060_07_1011881_tbdocumentofiscal_origem_crud"; break;
                case Name.F0060_08_documentofiscalregistro_excluir_procedimento: _name_function = "f0060_08_1011912_documentofiscalregistro_excluir_procedimento"; break;
                case Name.F0060_09_documentofiscalregistro_status_recebimento: _name_function = "f0060_09_1011881_documentofiscalregistro_status_recebimento"; break;
                case Name.F0060_30_documentofiscalregistro_consultar: _name_function = "f0060_30_1011900_documentofiscalregistro_consultar"; break;
                case Name.F0060_40_documentofiscal_consultar: _name_function = "f0060_40_1011911_documentofiscal_consultar"; break;

                case Name.F0049_01: _name_function = "f0049_01_1011870_tbbanco_contabancaria"; break;
                case Name.F0050_01: _name_function = "f0050_01_1011870_tbautorizacaopgto"; break;
                case Name.F0110_01: _name_function = "f0110_01_1011870_voucher"; break;
                case Name.F0130_01: _name_function = "f0130_01_1011873_controle_reg"; break;
                case Name.F0130_02: _name_function = "f0130_02_1011870_controle_reg_fila"; break;
                case Name.F0130_03: _name_function = "f0130_03_1011870_controle_reg_etapa"; break;
                case Name.F0130_04: _name_function = "f0130_04_1011870_controle_reg_dados"; break;
                case Name.F0130_05_controle_etapa_finalizar: _name_function = "f0130_05_1011900_controle_reg_etapa_finalizar"; break;
                case Name.F0130_06_controle_reg_pgto: _name_function = "f0130_06_1011870_controle_reg_pgto"; break;
                case Name.F0130_07_controle_dados_consultar: _name_function = "f0130_07_1011870_controle_dados_consultar"; break;
                case Name.F0130_10_controle_reg_list: _name_function = "f0130_10_1011875_controle_reg_list"; break;
                case Name.F0140_01_preco_list_select: _name_function = "f0140_01_1011890_preco_list_select"; break;
                case Name.F0140_02_preco_inativar_item_list: _name_function = "f0140_02_1011878_preco_inativar_item_list"; break;

                case Name.F0131_01: _name_function = "f0131_01_1011870_veiculo"; break;
                case Name.F0132_01_tbfat_res_comercial_consulta_relacional: _name_function = "f0132_01_1011890_tbfat_res_comercial_consulta_relacional"; break;
                case Name.F0132_02_comercial_pre_pedido_crud_result: _name_function = "f0132_02_1011880_comercial_pre_pedido_crud_result"; break;
                case Name.F0132_03_comercial_pre_pedido_item_update: _name_function = "f0132_03_1011875_comercial_pre_pedido_item_update"; break;
                case Name.F0132_04_tbcomercial_pre_pedido_list: _name_function = "f0132_04_1011875_tbcomercial_pre_pedido_list"; break;
                case Name.F0132_05_tbcomercial_pre_pedido_item_list: _name_function = "f0132_05_1011875_tbcomercial_pre_pedido_item_list"; break;
                case Name.F0132_06_comercial_pre_pedido_pgtos: _name_function = "f0132_06_1011880_tbcomercial_pre_pedido_pgtos_crud"; break;
                case Name.F0132_90_processo_fat_res_comercial: _name_function = "f0132_90_1011877_processo_fat_res_comercial"; break;
                case Name.F0133_10_Comercial_PedidoBlusoft_List: _name_function = "f0133_10_1011900_comercial_pedidoblusoft_list"; break;



                case Name.F0130_09_controle_status_consultar: _name_function = "f0130_09_1011873_controle_status_consultar"; break;
                case Name.F0141_01_rh_funcionario: _name_function = "f0141_01_1011900_rh_funcionario"; break;
                case Name.F0141_02_rh_funcionario_ctrl_crud: _name_function = "f0141_02_1011900_rh_funcionario_ctrl_crud"; break;
                case Name.F0141_03_rh_funcionario_ctrl_list: _name_function = "f0141_03_1011900_rh_funcionario_ctrl_list"; break;



                case Name.F9010_01_sistema_log: _name_function = "f9010_01_1011891_sistema_log"; break;
                case Name.P0001_01: _name_function = "p0001_01_0111870_PessoaParticipante"; break;
                case Name.P0010_01: _name_function = "p0010_01_1011870_estoquecustos_diario_processamento"; break;
                case Name.P0010_02: _name_function = "p0010_02_1011870_estoquecustos_processamento"; break;

                default: return "";
                    
            }
            return _name_function;
        }
        public static string ScriptSql_Get(Name _function, string _parametros)
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + ScriptSQL(_function) + "(" + _parametros + ")");
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ScriptSql_POST(Name _function, string _parametros)
        {
            try
            {
                string SQL_POSTGRE = string.Format("SELECT " + ScriptSQL(_function) + "(" + _parametros + ")");
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable get_DataTable(Pag_Net.Models.modelSistemaUsuario MyConnect, Name _function, string _parametros)
        {
            try
            {
                string SQL_POSTGRE = string.Format("SELECT * FROM " + ScriptSQL(_function) + "(" + _parametros + ")");
                /*string SQL_POSTGRE = "";
                DataSet DT = new DataSet();
                DT = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DT.Tables[0];*/
                return get_DataTable(MyConnect, SQL_POSTGRE);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable get_DataTable(Pag_Net.Models.modelSistemaUsuario MyConnect, string _function )
        {
            try
            {
                DataSet DT = new DataSet();
                DT = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, _function, "");
                return DT.Tables[0];

            }
            catch (Exception ex)
            {
                Pag_Net.Tools.LogFile.Write(new Exception(ex.Message + "\n Script SQL: \n " + _function));
                throw new Exception(ex.Message);
            }
        }     
        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect, Name _function)
        {
            try
            {
                string SQL = "SELECT " + BDCommand.ScriptSQL(_function) + "()";
                Execute(MyConnect, SQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect, string sqlScript)
        {
            try
            {
                string SQL = sqlScript;
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                BDExecute.Execute(SQL, null, DataBaseName.ODBCOXAN);
                BDExecute.Commit(DataBaseName.ODBCOXAN);
            }
            catch (Exception ex)
            {
                Pag_Net.Tools.LogFile.Write(new Exception(ex.Message + "\n Script SQL: \n " + sqlScript));
                throw new Exception(ex.Message);
            }
        }
        public static void Post(Pag_Net.Models.modelSistemaUsuario MyConnect, BDCommand.Name _Function, string _Parametros)
        {
            DbUpdate BDExecute;
            BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
            BDExecute.Execute(Pag_Net.Bll.BDCommand.ScriptSql_POST(_Function, _Parametros), null, DataBaseName.ODBCOXAN);
            BDExecute.Close(DataBaseName.ODBCOXAN);
            BDExecute.Dispose();
        }
        public static void Post(Pag_Net.Models.modelSistemaUsuario MyConnect, string FUNCTION_PARAMETERS)
        {
            DbUpdate BDExecute;
            BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
            BDExecute.Execute(FUNCTION_PARAMETERS, null, DataBaseName.ODBCOXAN);
            BDExecute.Close(DataBaseName.ODBCOXAN);
            BDExecute.Dispose();
        }
        public static DBDataTable DBDataTableGet(Pag_Net.Models.modelSistemaUsuario MyConnect, string SqlSelect)
        {
            try
            {
                DBDataTable myDBdataTable = new DBDataTable(get_DataTable(MyConnect, SqlSelect));
                return myDBdataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }
    }

    public static class RESTAPI
    {
        public static object get(Pag_Net.Models.modelSistemaUsuario MyConnect, string url_metodo, object bodyitem)
        {
            try
            {
                string url = string.Format("{0}" + url_metodo, MyConnect.PAG_API);
                return get(url, bodyitem);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static object get(string url, object bodyitem)
        {
            try
            {
                
                RestClient client = new RestClient(url);
                client.UserAgent = "PAG - DESKTOP";
                client.AddDefaultHeader("X-Customtoken", "10003ff9ec87814c80c505e8ccd80c43b6ff620");

                RestRequest request = new RestRequest(Method.GET);
                //request.AddHeader("Accept", "application/json");

                client.Timeout = 100000000;

                if (bodyitem != null)
                {
                    request.AddJsonBody(bodyitem);
                }
                var response = client.Execute(request).Content;
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }


        public static object post(string url, object bodyitem)
        {
            return post(url, bodyitem, 3);
        }
        public static object post(string url, object bodyitem, int sis_us_seq)
        {
            return post(url, bodyitem, sis_us_seq, "");
        }

        public static object post(string url, object bodyitem, int sis_us_seq, string user_name)
        {
            try
            {
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest(Method.POST);
                request.AddHeader("sis_us_seq", sis_us_seq.ToString());
                request.AddHeader("user_name", user_name.ToString());
                client.Timeout = 100000000;
                

                if (bodyitem != null)
                {
                    request.AddJsonBody(bodyitem);
                }
                var response = client.Execute(request).Content;
                //var response = client.ExecuteAsync(request, null);

                //var dados = DeserializeJson<Dados>(response);

                return response;

                

            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
        public static T DeserializeJson<T>(string json)
        {
            using (var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }
    }

    [DataContract]
    public class Dados
    {
        [DataMember(Name = "propriedade")]
        public string Propriedade { get; set; }
    }




    public static class RESTAPI_BLUESOFT
    {

        public static object post(string url, object bodyitem)
        {
            try
            {
                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest(Method.POST);
                request.AddHeader("X-Customtoken", "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJ7XCJ1c2VyTmFtZVwiOlwiZWxpYXNcIixcInNlY3JldFwiOlwic2xkemZiVFJvb2ZaT2VwYkRUREd4VFRMWnVUb2lNWERIcFBndUlWb0FoXCJ9In0.n-WdvZ74zWuU8IRhDs03LzhBqpCZ4t8QcrdMSdM_ltentm7otBAlncUvEA43mlBXQdFP7QIENargRdA1eg9wDw");
                request.AddHeader("Cookie", "JSESSIONID=3A8AB5683885590635B7EBBB0847129A; AWSALB=+2KV4KIFsGK6LAciWzGYelsyTJsCPtth4idederLkvcPDNiJqSOfJ1aZCXoZcmiTHinYI6zfIRVgLVW15Xg3ElpUxIQPiUldbduNqHGtYJs+WnUOmzsquBdg9IFn; AWSALBCORS=+2KV4KIFsGK6LAciWzGYelsyTJsCPtth4idederLkvcPDNiJqSOfJ1aZCXoZcmiTHinYI6zfIRVgLVW15Xg3ElpUxIQPiUldbduNqHGtYJs+WnUOmzsquBdg9IFn");
                request.AddHeader("Content-Type", "application/json");

                //request.AddHeader("Accept", "application/json");
                string dados = request.JsonSerializer.Serialize(bodyitem);

                if (bodyitem != null)
                {
                    request.AddJsonBody(bodyitem);
                }
                var response = client.Execute(request).Content;
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

    }

    public class Tb : INotifyPropertyChanged
    {
        public DateTime dtlog_insert { get; set;  }
        public DateTime dtlog_update { get; set;  }
        public event PropertyChangedEventHandler PropertyChanged;
        public Tb()
        {
            this.dtlog_insert = DateTime.Now;
            this.dtlog_update = DateTime.Now;

        }
        public void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void _DBINSERT(Pag_Net.Models.modelSistemaUsuario MyConnect) { this.__DataPost(MyConnect, _Db_Pg_script_Insert()); }
        public void _DBUPDATE(Pag_Net.Models.modelSistemaUsuario MyConnect) { this.__DataPost(MyConnect, _Db_Pg_script_Update()); }
        public DataRow _DBSELECT(Pag_Net.Models.modelSistemaUsuario MyConnect) 
        {
            try
            {
                DBDataTable DTDBSELECT = this.__DataGet(MyConnect, _Db_Pg_script_Select());
                if (DTDBSELECT.Count > 0)
                    return DTDBSELECT.List.Rows[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        
        }
        public DataRow _DBCRUD(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

            try
            {
                return this.__DataGet(MyConnect, _Db_Pg_script_CRUD()).List.Rows[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        
        }
        
        public virtual string _Db_Pg_script_Insert() { return this.__Db_Pg_script(BDCommandTypes.DBINSERT); }
        public virtual string _Db_Pg_script_Update() { return this.__Db_Pg_script(BDCommandTypes.DBUPDATE); }
        public virtual string _Db_Pg_script_Select() { return this.__Db_Pg_script(BDCommandTypes.DBSELECT); }
        public virtual string _Db_Pg_script_CRUD() { return this.__Db_Pg_script(BDCommandTypes.DBCRUD); }
        

        public void __DataPost(Pag_Net.Models.modelSistemaUsuario MyConnect, string ScriptSQL) 
        {
            try
            {
                //BDCommand.get_DataTable(MyConnect, ScriptSQL);
                BDCommand.Execute(MyConnect, ScriptSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Tb | _Db_Pg_DataPost -> \n" + ex.Message + "\n" + ScriptSQL);
            }

        }
        public DBDataTable __DataGet(Pag_Net.Models.modelSistemaUsuario MyConnect, string ScriptSQL) 
        {
            try
            {
                return new DBDataTable(BDCommand.get_DataTable(MyConnect, ScriptSQL));
            }
            catch (Exception ex)
            {
                throw new Exception("Tb | _Db_Pg_DataGet -> \n" + ex.Message + "\n" + ScriptSQL);
            }
        }


        public virtual void __Binding(DataRow i){}
        public virtual string __Db_Pg_script(BDCommandTypes BDCommnadType) { return ""; }
        public void __Consultar(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                __Binding(_DBSELECT(_MyConnect));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void __Atualizar(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try { __Binding(this._DBCRUD(_MyConnect)); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
   


    }



    public static class resource
    {
        public static void PagException(PagExceptionType Type, Exception ex)
        {
            PagException(Type, ex.Message);
        }
        public static void PagException(PagExceptionType Type, string ERROR)
        {

           string Info = "----------------------" + "\n" +
                          ERROR;
            Exception ex = new Exception(ERROR);

            switch (Type)
            {
                case PagExceptionType.Info:
                    ex.HelpLink = "A";
                    break;
                case PagExceptionType.Error:
                    ex.HelpLink = "E";
                    break;
            }
           throw ex;
        }
    }

    public static class PagConnection
    {
        public static modelSistemaUsuario MyConnection(string system_id, string user_id, string user_environment, string network, string user_password, string _FileXMLConnectionCrypt)
        {
            try
            {
                Cryptf PagToolCrypt = new Cryptf();
                //string XMLConnection = PagToolCrypt.FileDecryptToString(@_FileXMLConnectionCrypt, "00141722");
                string XMLConnection = PagToolCrypt.FileDecryptToString(@_FileXMLConnectionCrypt);

                //dalUserAccess Acesso = new dalUserAccess();


                Pag_Net.Tools.CryptPassWord.Criptp cr = new Criptp(CryptProvider.TripleDES);
                //cr.Key = "141722P";

                string cryptpassword = cr.Encrypt(user_password);

                modelSistemaUsuario myPackageConnect = new modelSistemaUsuario();
                myPackageConnect.User_environment = user_environment;
                myPackageConnect.sis_cd = system_id;
                myPackageConnect.NetWork = network;
                myPackageConnect.user_name = user_id;
                myPackageConnect.passwd = cryptpassword;


                dalConfig x = new dalConfig();


                //List<TbSysDatabase> lstSystemDataBase = new List<TbSysDatabase>();
                //lstSystemDataBase.Add(x.AuthenticateConnection(user_environment, XMLConnection));
                //myPackageConnect.ListConnections = lstSystemDataBase.ToArray();



                return myPackageConnect;

                //return MyConnection;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public static ModelSistemaPermissoes[] ConsultarPostgreAcessos(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Models.Filter.Login Filtros)
        {
            try
            {
                List<ModelSistemaPermissoes> _list = new List<ModelSistemaPermissoes>();
                DataTable DataTable_Produto = Pag_Net.Bll.R0001.Select._0001_login_acesso(MyConnect, Filtros);

                foreach (DataRow dr in DataTable_Produto.Rows)
                {
                    _list.Add(new ModelSistemaPermissoes(dr));
                    MyConnect.sis_us_seq = Convert.ToInt32(dr["sis_us_seq"].ToString());
                }
                return _list.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll | Connection " + ex.Message);
            }

        }


        public static bool ConsultarPostgreTarefas(Pag_Net.Models.modelSistemaUsuario MyConnect, int vsis_ta_cd)
        {
            try
            {
                bool valor = false;

                List<Mod_Postgre_Tarefas> _list = new List<Mod_Postgre_Tarefas>();
                DataTable DataTable_Produto = Pag_Net.Bll.R0001_0002.Select.get(MyConnect, vsis_ta_cd);
                if (DataTable_Produto.Rows.Count == 0)
                {
                    valor = false;
                }
                else
                {
                    if (Convert.ToInt32(DataTable_Produto.Rows[0]["sis_ta_cd"].ToString()) == vsis_ta_cd)
                    {
                        valor = true;
                    }
                    else
                    {
                        valor = false;
                    }
                }

                return valor;
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll _ ConsultarPostgreTarefas |  " + ex.Message);
            }

        }

    }

    
}



namespace Pag_Net.Models
{
 

    public class Mod_Postgre_Tarefas
    {
        public int sis_ta_cd;
        public string sis_ta_descricao;

        public Mod_Postgre_Tarefas(DataRow i)
        {
            sis_ta_cd = Convert.ToInt32(i["sis_ta_cd"].ToString());
            sis_ta_descricao = i["sis_ta_descricao"].ToString();
        }


    }
    




}



