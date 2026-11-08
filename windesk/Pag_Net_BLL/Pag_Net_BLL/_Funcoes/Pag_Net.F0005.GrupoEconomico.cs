using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0005;

namespace Pag_Net.F0005.Bll.Migration
{

    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                /*RedShift BlueSoft SELECT */
                List<Models.GrupoEconomico> List = new List<Models.GrupoEconomico>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Models.BD.RedShift.Select(), "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr["cdgrupoeconomico"];
                    List.Add(new Models.GrupoEconomico(dr));
                }
                /*Postgre INSERT */
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                
                foreach (Models.GrupoEconomico item in List)
                {
                    ErroInfo = "ID: " + item.cdgrupoeconomico.ToString();
                    BDExecute.Execute(Models.BD.Postgres.F0005_01PC_tbgrupoeconomico(item, Pag_Net.Models.BDCommandTypes.DBINSERT), null, DataBaseName.ODBCOXAN);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("F0005.Bll | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}
