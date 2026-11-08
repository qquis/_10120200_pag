using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0070_Faturamento.reports
{

    public class rptFaturamentoItensList
    {
        public DataTable report;
        public int Count;
        public rptFaturamentoItensList() { }
    }
    public static class rptGeneratorrptFaturamentoItensList
    {
        public static rptFaturamentoItensList Get(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.globalFilter filter)
        {
            rptFaturamentoItensList RPT = new rptFaturamentoItensList();
            try
            {
                DBDataTable DB = BDCommand.DBDataTableGet(MyConnect, sql(filter));
                RPT.report = DB.List;
                RPT.Count = DB.Count;

                return RPT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private static string sql(interfaces.globalFilter filter)
        {
            string sql = "	select 		    i.seqfaturamentoorigem "
                         + "           ,	i.seqfaturamentoitem "
                         + "           ,	i.seqitem "
                         + "           ,	i.pr_cdproduto "
                         + "           ,    pr.prb_cdprodutobluesoft "
                         + "           ,	coalesce(pr.pr_descricao, '') as  pr_descricao "
                         + "           ,	coalesce(pr.pr_embalagemestoque, '') as  pr_embalagemestoque "
                         + "           ,	coalesce(i.embalagemestoqueqtde,0) as  embalagemestoqueqtde "
                         + "           ,	coalesce(pr.pr_embalagemcompra,'') as  pr_embalagemcompra "
                         + "           ,	coalesce(i.embalagemcompraqtde,0) as  embalagemcompraqtde "
                         + "           ,	i.ec_valorcusto_faturamento_total  "
                         + "           ,	i.ec_valorcusto_precificacao_total "
                         + "           ,	i.valortotalfaturamentobase "
                         + "           ,	coalesce(i.valortotalsubsidioscorrentes,0) as  valortotalsubsidioscorrentes "
                         + "           ,	i.valortotalfaturamento "
                         + "           ,	coalesce(i.valortotaldescontofinanceiro,0) as  valortotaldescontofinanceiro "
                         + "           ,	coalesce(i.valortotalfaturamentobruto,0)  as valortotalfaturamentobruto "
                         + "           ,    coalesce(i.valortotalsubsidiosaplicados,0) as valortotalsubsidiosaplicados "
                         + "           ,	coalesce(i.valortotalfaturamentoliquido,0) as valortotalfaturamentoliquido "
                         + "           ,	coalesce(i.statusfaturamentoitem,0) as statusfaturamentoitem "
                         + "           ,    coalesce(st.statusfaturamentoitem_descricao,'') as statusfaturamentoitem_descricao"
                         + "   from 		tbfaturamentoitens  i "
                         + "   inner join 	tbfaturamentoorigem o on o.seqfaturamentoorigem = i.seqfaturamentoorigem "
                         + "   inner join   tbfaturamento       f on f.seqfaturamento = o.seqfaturamento "
                         + "   left  join   tbproduto			pr on pr.pr_cdproduto = i.pr_cdproduto "
                         + "   left  join   tbfaturamentostatusitem st on st.statusfaturamentoitem = i.statusfaturamentoitem "
                         + "   where		1 = 1 ";

                  sql += " and f.seqfaturamento = " + filter.seqfaturamento ;
            
            return sql;
        }


    }
}
