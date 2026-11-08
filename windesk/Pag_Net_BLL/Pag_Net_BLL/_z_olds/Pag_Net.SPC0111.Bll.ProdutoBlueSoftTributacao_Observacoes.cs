using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;

namespace Pag_Net.SPC0111.Bll.Migration
{

    public static class FromRedShift
    {

        private static Pag_Net.SPC0111.Models.ProdutoBlueSoftTributacaoObservacoes[] _list(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, SPC0111.Models.BD.RedShift.Select(), "");
                List<Pag_Net.SPC0111.Models.ProdutoBlueSoftTributacaoObservacoes> List = new List<Models.ProdutoBlueSoftTributacaoObservacoes>();
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "Leitura do RedShift - Produto: " + dr["CdProdutoBlueSoft"];
                    List.Add(new Pag_Net.SPC0111.Models.ProdutoBlueSoftTributacaoObservacoes(dr));
                }
                return List.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.SPC00111.Bll | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }


        
        
        public static void ToSqlServer(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

            string ErroInfo = "";

            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                //BDExecute.Begin();
                foreach (Pag_Net.SPC0111.Models.ProdutoBlueSoftTributacaoObservacoes item in _list(MyConnect))
                {
                    ErroInfo = "Registrando o item na Base de Dados - Produto Código: " + item.CdProdutoBlueSoft.ToString(); 
                    BDExecute.Execute(Pag_Net.SPC0111.Models.BD.SqlServer.SqlProcedureName(), Pag_Net.SPC0111.Models.BD.SqlServer.Fill(item,Pag_Net.Models.BDCommandTypes.DBINSERT));
                }
                //BDExecute.Commit();
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.SPC00111.Bll | Migration: " + ErroInfo + " - " + ex.Message);
            }

        }
    }



}
