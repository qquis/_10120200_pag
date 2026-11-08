using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0006;
using Pag_Net.Models;

namespace Pag_Net.F0006.Bll.Migration
{
    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                List<Models.TbUsuario> List = new List<Models.TbUsuario>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Models.BD.RedShift.Select(), "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "Leitura do RedShift - Pessoa: " + dr["CdPessoaBlueSoft"];
                    List.Add(new Models.TbUsuario(dr));
                }







                //BDExecute.Begin(DataBaseName.ODBCOXAN);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                int x = 1;
                int seq = 0;
                int count = List.Count();
                foreach (Models.TbUsuario item in List)
                {
                    if (x == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }


                    ErroInfo = "ID: " + item.cdpessoabluesoft.ToString();
                    BDExecute.Execute(Models.BD.Postgres.ScriptFuncion(Pag_Net.Models.BDCommandTypes.DBINSERT, item, true), null, DataBaseName.ODBCOXAN);

                    x = x + 1;
                    seq = seq + 1;

                    if (x > 10000)
                    {
                        x = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        x = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                //BDExecute.Commit(DataBaseName.ODBCOXAN);







            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0006.Bll.Migration | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}

namespace Pag_Net.F0006.Models.BD
{
    public static class Postgres
    {
        public static string ScriptFuncion(Pag_Net.Models.BDCommandTypes _Type, TbUsuario item, bool ApiMigration) 
        {
            string SQL_POSTGRE_EXEC = string.Format("SELECT f0006_crud_tbusuario (	    " +
                                               "           'DBINSERT'     " +
                                               "       ,     {0}          " +
                                               "       ,    '{1}'         " +
                                               "       ,    '{2}'         " +
                                               "       ,    '{3}'         " +
                                               "       ,    '{4}'         " +
                                               "       ,    '{5}'         " +
                                               "       ,    '{6}'         " +
                                               "       ,    '{7}'         )",
                                 item.cdpessoabluesoft,
                                 item.status_bluesoft,
                                 item.user_name.Replace("'", "´"),
                                 item.passwd,
                                 item.hash,
                                 item.data_cadastro.ToString("yyyy-MM-dd"),
                                 item.data_ultima_troca.ToString("yyyy-MM-dd"),
                                 ApiMigration ? "True" : "False"
                                 );
            return SQL_POSTGRE_EXEC;
        
        }
        public static void CRUD(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Models.BDCommandTypes _Type, TbUsuario item)
        {
            CRUD(MyConnect, _Type, item, true);
        }
        public static void CRUD(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Models.BDCommandTypes _Type, TbUsuario item, bool ApiMigration )
        {

            try
            {
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(ScriptFuncion( _Type, item, ApiMigration) , null, DataBaseName.ODBCOXAN);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0006.Bll.Usuario | Update: " + ex.Message);
            }

        }

    }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = " select     usuario_key                            as cdpessoabluesoft " + 
                         "        ,   coalesce(status,'APROVADO')            as status_bluesoft " + 
                         "        ,   coalesce(user_name,'X')                as user_name " + 
                         "        ,   '*'                                    as passwd" + 
                         "        ,   coalesce(hash,'X')                     as hash " + 
                         "        ,   coalesce(data_cadastro,'1900-01-01')   as data_cadastro " + 
                         "        ,   coalesce(ultima_troca,'1900-01-01')    as data_ultima_troca " + 
                         " from      usuario " + 
                         " order by  usuario_key asc";
            //"        where pessoa_key = 1 ";
            return SQL;
        }
    }

}

namespace Pag_Net.F0006.Models
{
    public class TbUsuario
    {
        public int      cdpessoabluesoft { get; set; }
        public string   status_bluesoft { get; set; }
        public string   user_name { get; set; }
        public string   passwd { get; set; }
        public string   hash { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ultima_troca { get; set; }


        public TbUsuario()
        {

        }

        public TbUsuario(System.Data.DataRow i)
        {
            string errorString = i["CdPessoaBlueSoft"].ToString();
            try
            {
                cdpessoabluesoft = Convert.ToInt32(i["CdPessoaBlueSoft"]);
                status_bluesoft = Convert.ToString(i["status_bluesoft"]);
                user_name = Convert.ToString(i["user_name"]);
                passwd = Convert.ToString(i["passwd"]);
                hash = Convert.ToString(i["hash"]);
                data_cadastro = Convert.ToDateTime(i["data_cadastro"]);
                data_ultima_troca = Convert.ToDateTime(i["data_ultima_troca"]);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }
        }


    }

}

