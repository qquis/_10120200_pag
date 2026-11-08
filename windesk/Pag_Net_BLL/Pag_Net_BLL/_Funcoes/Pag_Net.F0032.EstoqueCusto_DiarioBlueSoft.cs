using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0032;
using Pag_Net.Models;

namespace Pag_Net.F0032.Bll.Migration
{

    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                /*RedShift BlueSoft SELECT */
                List<Models.EstoqueCusto_DiarioBlueSoft> List = new List<Models.EstoqueCusto_DiarioBlueSoft>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Models.BD.RedShift.Select(), "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr["prb_cdprodutobluesoft"];
                    List.Add(new Models.EstoqueCusto_DiarioBlueSoft(dr));
                }
                /*Postgre INSERT */
                
                //BDExecute.Begin(DataBaseName.ODBCOXAN);
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                int x = 1;
                int seq = 0;
                int count = List.Count();
                foreach (Models.EstoqueCusto_DiarioBlueSoft item in List)
                {
                    if (x == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }


                    ErroInfo = "ID: " + item.prb_cdprodutobluesoft.ToString();
                    BDExecute.Execute(Models.BD.Postgres.f0032_crud_tbestoquecusto_diariobluesoft (item, Pag_Net.Models.BDCommandTypes.DBINSERT), null, DataBaseName.ODBCOXAN);

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
                throw new Exception("F0021.Bll | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}

namespace Pag_Net.F0032.Models
{
    public class EstoqueCusto_DiarioBlueSoft
    {

        public int prb_cdprodutobluesoft { get; set; }
        public DateTime ecdb_data { get; set; }
        public double ecdb_embalagemestoque_qtde { get; set; }
        public double ecdb_embalagemestoque_qtde_online { get; set; }
        public double ecdb_embalagemestoque_fv_pendente { get; set; }
        public double ecdb_valor_custo_precificacao { get; set; }
        public double ecdb_valor_custo_faturamento { get; set; }
        public double ecdb_valor_customedio_comimposto { get; set; }
        public double ecdb_valor_customedio_semimposto { get; set; }
        public double ecdb_valor_ultimacompra_bruto { get; set; }
        public double ecdb_valor_ultimacompra_liq { get; set; }
        public double ecdb_composicao_vl_mao_de_obra  { get; set; } 
        public double ecdb_composicao_vl_custo_indireto  { get; set; } 
        public double ecdb_composicao_itens   { get; set; }
        public double ecdb_composicao_QTDE   { get; set; }
        public double ecdb_composicao_vl_custo { get; set; }



        public EstoqueCusto_DiarioBlueSoft() { }
        public EstoqueCusto_DiarioBlueSoft(DataRow i)
        {
            prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
            ecdb_data = Convert.ToDateTime(i["ecdb_data"].ToString());
            ecdb_embalagemestoque_qtde = Convert.ToDouble(i["ecdb_embalagemestoque_qtde"].ToString());
            ecdb_embalagemestoque_qtde_online = Convert.ToDouble(i["ecdb_embalagemestoque_qtde_online"].ToString());
            ecdb_embalagemestoque_fv_pendente = Convert.ToDouble(i["ecdb_embalagemestoque_fv_pendente"].ToString());
            ecdb_valor_custo_precificacao = Convert.ToDouble(i["ecdb_valor_custo_precificacao"].ToString());
            ecdb_valor_custo_faturamento = Convert.ToDouble(i["ecdb_valor_custo_faturamento"].ToString());
            ecdb_valor_customedio_comimposto = Convert.ToDouble(i["ecdb_valor_customedio_comimposto"].ToString());
            ecdb_valor_customedio_semimposto = Convert.ToDouble(i["ecdb_valor_customedio_semimposto"].ToString());
            ecdb_valor_ultimacompra_bruto = Convert.ToDouble(i["ecdb_valor_ultimacompra_bruto"].ToString());
            ecdb_valor_ultimacompra_liq = Convert.ToDouble(i["ecdb_valor_ultimacompra_liq"].ToString());
            ecdb_composicao_vl_mao_de_obra      = Convert.ToDouble(i["ecdb_composicao_vl_mao_de_obra"].ToString());
            ecdb_composicao_vl_custo_indireto   = Convert.ToDouble(i["ecdb_composicao_vl_custo_indireto"].ToString());
            ecdb_composicao_itens               = Convert.ToDouble(i["ecdb_composicao_itens"].ToString());
            ecdb_composicao_QTDE                = Convert.ToDouble(i["ecdb_composicao_QTDE"].ToString());
            ecdb_composicao_vl_custo            = Convert.ToDouble(i["ecdb_composicao_vl_custo"].ToString());



        }
    }
}

namespace Pag_Net.F0032.Models.BD
{
    public static class Postgres
    {
        public static string f0032_crud_tbestoquecusto_diariobluesoft(EstoqueCusto_DiarioBlueSoft item, Pag_Net.Models.BDCommandTypes _Type)
        {
            return string.Format("SELECT  f0032_crud_tbestoquecusto_diariobluesoft ('{0}', {1}, '{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, '{17}')",
                                             BDTools.SqlCommandType(_Type).ToString(),
                                             item.prb_cdprodutobluesoft,
                                             item.ecdb_data.ToString("yyyy-MM-dd"),
                                             item.ecdb_embalagemestoque_qtde.ToString().Replace(",", "."),
                                             item.ecdb_embalagemestoque_qtde_online.ToString().Replace(",", "."),
                                             item.ecdb_embalagemestoque_fv_pendente.ToString().Replace(",", "."),
                                             item.ecdb_valor_custo_precificacao.ToString().Replace(",", "."),
                                             item.ecdb_valor_custo_faturamento.ToString().Replace(",", "."),
                                             item.ecdb_valor_customedio_comimposto.ToString().Replace(",", "."),
                                             item.ecdb_valor_customedio_semimposto.ToString().Replace(",", "."),
                                             item.ecdb_valor_ultimacompra_bruto.ToString().Replace(",", "."),
                                             item.ecdb_valor_ultimacompra_liq.ToString().Replace(",", "."),
                                             item.ecdb_composicao_vl_mao_de_obra.ToString().Replace(",", "."),    
                                             item.ecdb_composicao_vl_custo_indireto.ToString().Replace(",", "."), 
                                             item.ecdb_composicao_itens.ToString().Replace(",", "."),             
                                             item.ecdb_composicao_QTDE.ToString().Replace(",", "."),
                                             item.ecdb_composicao_vl_custo.ToString().Replace(",", "."),          
                                             "false")

                ;
        }

    }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = "      select    cast(isnull(ES.produto_key,0)             as int)                 as prb_cdprodutobluesoft  " +
                         "             ,  ES.data                                                           as ecdb_data  " +
                         "             ,  cast(isnull(ES.quantidade,0)              as numeric(17,4))       as ecdb_embalagemestoque_qtde  " +
                         "             ,  cast(0                                    as numeric(17,4))       as ecdb_embalagemestoque_qtde_online  " +
                         "             ,  cast(0                                    as numeric(17,4))       as ecdb_embalagemestoque_fv_pendente  " +
                         "             ,  cast(0                                    as numeric(17,4))       as ecdb_valor_custo_precificacao  " +
                         "             ,  cast(isnull(ES.custo_unitario_com_icm,0)  as numeric(17,4))       as ecdb_valor_custo_faturamento  " +
                         "             ,  cast(isnull(ES.custo_unitario_com_icm,0)  as numeric(17,4))       as ecdb_valor_customedio_comimposto  " +
                         "             ,  cast(isnull(ES.custo_unitario,0)          as numeric(17,4))       as ecdb_valor_customedio_semimposto  " +
                         "             ,  cast(0                                    as numeric(17,4))       as ecdb_valor_ultimacompra_bruto   " +
                         "             ,  cast(0                                    as numeric(17,4))       as ecdb_valor_ultimacompra_liq  " +
                         "             ,  cast(data                                 as date)                as ecdb_data_atualizacao_dia  " +
                         "             ,  cast(data                                 as date)                as ecdb_data_atualizacao_online  " +
                         "             ,  cast(COALESCE(CPX.CUSTO_MAO_DE_OBRA,0)    AS numeric(17,4))       as ecdb_composicao_vl_mao_de_obra  " +
                         "             ,  cast(COALESCE(CPX.CUSTO_INDIRETO,0)       AS numeric(17,4))       as ecdb_composicao_vl_custo_indireto  " +
                         "             ,  cast(COALESCE(CP.COMPOSICAO_ITENS,0)      as numeric(17,4))       as ecdb_composicao_itens  " +
                         "             ,  cast(COALESCE(CP.COMPOSICAO_QTDE,0)       as numeric(17,4))       as ecdb_composicao_QTDE  " +
                         "             ,  cast(COALESCE(CP.COMPOSICAO_CUSTO,0)      as numeric(17,4))       as ecdb_composicao_vl_custo  " +
                         "             from      estoque_diario ES  " +
                         "             LEFT JOIN custos_produto_producao CPX ON CPX.PRODUTO_KEY = ES.PRODUTO_KEY  " +
                         "             LEFT JOIN (  " +
                         "                          SELECT        CP.PRODUTO_FINAL                    AS PRODUTO_KEY   " +
                         "                              ,         COUNT(DISTINCT(CP.PRODUTO_PARTE))   AS COMPOSICAO_ITENS  " +
                         "                              ,         SUM(CP.QUANTIDADE)                  AS COMPOSICAO_QTDE  " +
                         "                              ,         SUM(COALESCE(ED.CUSTO_UNITARIO_COM_ICM,0) * COALESCE(CP.QUANTIDADE,0))  AS COMPOSICAO_CUSTO  " +
                         "                          FROM          COMPOSICAO        CP  " +
                         "                          LEFT JOIN     ESTOQUE_DIARIO    ED ON ED.PRODUTO_KEY = CP.PRODUTO_PARTE AND ED.DATA = CURRENT_DATE -1   " +
                         "                          INNER JOIN    (  " +
                         "                                              SELECT      produto_final             PRODUTO_KEY  " +
                         "                                                  ,      max(ULTIMA_ALTERACAO)     COMPOSICAO_DATA  " +
                         "                                              FROM     composicao  " +
                         "                                              GROUP BY produto_final  " +
                         "                                         ) CM ON CM.PRODUTO_KEY = CP.PRODUTO_FINAL AND CM.COMPOSICAO_dATA = CP.ULTIMA_ALTERACAO   " +
                         "                          GROUP BY CP.PRODUTO_FINAL  " +
                         "                      )   CP ON CP.PRODUTO_KEY = ES.PRODUTO_KEY  " +
                         "             where     1 = 1	  " +
                         "             and       es.data = current_date -1   ";



            return SQL;
        }
    }

}

