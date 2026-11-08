using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;

namespace Pag_Net.SPC0010.Bll.Migration
{

    public static class FromRedShift
    {

        private static Pag_Net.SPC0010.Models.Pessoa[] _list(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, SPC0010.Models.BD.RedShift.Select(), "");
                List<Pag_Net.SPC0010.Models.Pessoa> List = new List<Models.Pessoa>();
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "Leitura do RedShift - Pessoa: " + dr["CdPessoaBlueSoft"];
                    List.Add(new Pag_Net.SPC0010.Models.Pessoa(dr));
                }
                return List.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.SPC00010.Bll | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }


        
        
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

            string ErroInfo = "";

            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                foreach(Pag_Net.SPC0010.Models.Pessoa item in _list(MyConnect))
                {
                    ErroInfo = "Registrando o item na Base de Dados - Pessoa Código: " + item.CdPessoaBlueSoft.ToString();
                    BDExecute.Execute(Pag_Net.SPC0010.Models.BD.Postgres.SqlExecute(item, Pag_Net.Models.BDCommandTypes.DBINSERT), null, DataBaseName.ODBCOXAN);
                }
                BDExecute.Commit(DataBaseName.ODBCOXAN);
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.SPC00110.Bll | Migration: " + ErroInfo + " - " + ex.Message);
            }

        }
    }



}
