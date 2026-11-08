using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0018;

namespace Pag_Net.F0018.Bll.Migration
{

    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                /*RedShift BlueSoft SELECT */
                List<Models.produto_grupo> List = new List<Models.produto_grupo>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Models.BD.RedShift.Select(), "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[0];
                    List.Add(new Models.produto_grupo(dr));
                }
                /*Postgre INSERT */
                
                //BDExecute.Begin(DataBaseName.ODBCOXAN);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                int x = 1;
                int seq = 0;
                int count = List.Count();
                foreach (Models.produto_grupo item in List)
                {
                    if (x == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }
    

                    ErroInfo = "ID: " + item.prg_cdgrupo.ToString();
                    BDExecute.Execute(Models.BD.Postgres.CRUD(item, Pag_Net.Models.BDCommandTypes.DBINSERT), null, DataBaseName.ODBCOXAN);

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
                throw new Exception("F0018.Bll | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}
