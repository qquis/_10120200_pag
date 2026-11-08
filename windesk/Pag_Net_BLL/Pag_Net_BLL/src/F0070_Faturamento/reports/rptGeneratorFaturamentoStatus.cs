using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0070_Faturamento.reports
{

    public class rptFaturamentoStatus
    {
        public DataTable report;
        public int Count;
        public rptFaturamentoStatus() { }
    }
    public static class rptGeneratorFaturamentoStatus
    {
        public static rptFaturamentoStatus Get(Pag_Net.Models.modelSistemaUsuario MyConnect, int faturamento_consolidado)
        {
            rptFaturamentoStatus RPT = new rptFaturamentoStatus();
            try
            {
                DBDataTable DB = BDCommand.DBDataTableGet(MyConnect, sql(faturamento_consolidado));
                RPT.report = DB.List;
                RPT.Count = DB.Count;
                return RPT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private static string sql(int faturamento_consolidado)
        {
            string sql = "Select CAST(0 AS INT) AS statusfaturamento , " +
                    "       '* TODOS *'    AS statusfaturamento_descricao " +
                    " UNION " +
                    " select statusfaturamento " +
                    "      , statusfaturamento_descricao  " +
                    " from   tbfaturamentostatus " +
                    " where  1 = 1 " +
                    (faturamento_consolidado == 1 ? " and statusfaturamento_consolidado = 1" : "").ToString() +
                    " order by 1 asc";
            return sql;
        }


    }
}
