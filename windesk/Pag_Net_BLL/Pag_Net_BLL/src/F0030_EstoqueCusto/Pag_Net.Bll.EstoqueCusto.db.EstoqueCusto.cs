using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0030_EstoqueCusto
{
    public class TbEstoqueCusto
    {

        public DateTime     dtlog_insert                            {get ; set ;}
        public DateTime     dtlog_update                            {get ; set ;}
        public DateTime     dtlog_update_api                        {get ; set ;}
        public double       ec_composicao_itens                     {get ; set ;}
        public double       ec_composicao_qtde                      {get ; set ;}
        public double       ec_composicao_vl_custo                  {get ; set ;}
        public double       ec_composicao_vl_custo_indireto         {get ; set ;}
        public double       ec_composicao_vl_mao_de_obra            {get ; set ;}
        public double       ec_composicao_vl_total                  {get ; set ;}
        public DateTime     ec_data_atualizacao_dia                 {get ; set ;}
        public DateTime     ec_data_atualizacao_online              {get ; set ;}
        public DateTime     ec_data_valor_custo_precificacao        {get ; set ;}
        public double       ec_embalagemestoque_fv_pendente         {get ; set ;}
        public double       ec_embalagemestoque_qtde                {get ; set ;}
        public double       ec_embalagemestoque_qtde_online         {get ; set ;}
        public double       ec_embalagemestoque_troca_cont_qtde     {get ; set ;}
        public double       ec_embalagemestoque_troca_ger_qtde      {get ; set ;}
        public double       ec_valor_custo_faturamento              {get ; set ;}
        public double       ec_valor_custo_precificacao             {get ; set ;}
        public double       ec_valor_customedio_comimposto          {get ; set ;}
        public double       ec_valor_customedio_semimposto          {get ; set ;}
        public double       ec_valor_ultimacompra_bruto             {get ; set ;}
        public double       ec_valor_ultimacompra_liq               {get ; set ;}
        public int          ecdb_seq                                {get ; set ;}
        public DateTime     eci_nf_data_entrada                     {get ; set ;}
        public int          pr_cdproduto                            {get ; set ;}
        public int          proc_log_arquivo_seq                    {get ; set ;}



        public TbEstoqueCusto()
        {
            try
            {
                EstoqueCusto_Binding();
            }
            catch( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public void EstoqueCusto_Binding()
        {
            try
            {
                dtlog_insert = Convert.ToDateTime("1900-01-01");
                dtlog_update = Convert.ToDateTime("1900-01-01");
                dtlog_update_api = Convert.ToDateTime("1900-01-01");
                ec_composicao_itens = 0;
                ec_composicao_qtde = 0;
                ec_composicao_vl_custo = 0;
                ec_composicao_vl_custo_indireto = 0;
                ec_composicao_vl_mao_de_obra = 0;
                ec_composicao_vl_total = 0;
                ec_data_atualizacao_dia = Convert.ToDateTime("1900-01-01");
                ec_data_atualizacao_online = Convert.ToDateTime("1900-01-01");
                ec_data_valor_custo_precificacao = Convert.ToDateTime("1900-01-01");
                ec_embalagemestoque_fv_pendente = 0;
                ec_embalagemestoque_qtde = 0;
                ec_embalagemestoque_qtde_online = 0;
                ec_embalagemestoque_troca_cont_qtde = 0;
                ec_embalagemestoque_troca_ger_qtde = 0;
                ec_valor_custo_faturamento = 0;
                ec_valor_custo_precificacao = 0;
                ec_valor_customedio_comimposto = 0;
                ec_valor_customedio_semimposto = 0;
                ec_valor_ultimacompra_bruto = 0;
                ec_valor_ultimacompra_liq = 0;
                ecdb_seq = 0;
                eci_nf_data_entrada = Convert.ToDateTime("1900-01-01");
                pr_cdproduto = 0;
                proc_log_arquivo_seq = 0;
            }
            catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public void EstoqueCusto_DataBinding(DataRow row, DataColumnCollection colArr)
        {
            try
            {


                if (!row.HasErrors)
                {

                    for (int i = 0; i < colArr.Count; i++)
                    {
                        if (colArr[i].ColumnName == "dtlog_insert") dtlog_insert = Convert.ToDateTime(row["dtlog_insert"].ToString());
                        if (colArr[i].ColumnName == "dtlog_update") dtlog_update = Convert.ToDateTime(row["dtlog_update"].ToString());
                        if (colArr[i].ColumnName == "dtlog_update_api") dtlog_update_api = Convert.ToDateTime(row["dtlog_update_api"].ToString());
                        if (colArr[i].ColumnName == "ec_composicao_itens") ec_composicao_itens = Convert.ToDouble(row["ec_composicao_itens"].ToString());
                        if (colArr[i].ColumnName == "ec_composicao_qtde") ec_composicao_qtde = Convert.ToDouble(row["ec_composicao_qtde"].ToString());
                        if (colArr[i].ColumnName == "ec_composicao_vl_custo") ec_composicao_vl_custo = Convert.ToDouble(row["ec_composicao_vl_custo"].ToString());
                        if (colArr[i].ColumnName == "ec_composicao_vl_custo_indireto") ec_composicao_vl_custo_indireto = Convert.ToDouble(row["ec_composicao_vl_custo_indireto"].ToString());
                        if (colArr[i].ColumnName == "ec_composicao_vl_mao_de_obra") ec_composicao_vl_mao_de_obra = Convert.ToDouble(row["ec_composicao_vl_mao_de_obra"].ToString());
                        if (colArr[i].ColumnName == "ec_composicao_vl_total") ec_composicao_vl_total = Convert.ToDouble(row["ec_composicao_vl_total"].ToString());
                        if (colArr[i].ColumnName == "ec_data_atualizacao_dia") ec_data_atualizacao_dia = Convert.ToDateTime(row["ec_data_atualizacao_dia"].ToString());
                        if (colArr[i].ColumnName == "ec_data_atualizacao_online") ec_data_atualizacao_online = Convert.ToDateTime(row["ec_data_atualizacao_online"].ToString());
                        if (colArr[i].ColumnName == "ec_data_valor_custo_precificacao") ec_data_valor_custo_precificacao = Convert.ToDateTime(row["ec_data_valor_custo_precificacao"].ToString());
                        if (colArr[i].ColumnName == "ec_embalagemestoque_fv_pendente") ec_embalagemestoque_fv_pendente = Convert.ToDouble(row["ec_embalagemestoque_fv_pendente"].ToString());
                        if (colArr[i].ColumnName == "ec_embalagemestoque_qtde") ec_embalagemestoque_qtde = Convert.ToDouble(row["ec_embalagemestoque_qtde"].ToString());
                        if (colArr[i].ColumnName == "ec_embalagemestoque_qtde_online") ec_embalagemestoque_qtde_online = Convert.ToDouble(row["ec_embalagemestoque_qtde_online"].ToString());
                        if (colArr[i].ColumnName == "ec_embalagemestoque_troca_cont_qtde") ec_embalagemestoque_troca_cont_qtde = Convert.ToDouble(row["ec_embalagemestoque_troca_cont_qtde"].ToString());
                        if (colArr[i].ColumnName == "ec_embalagemestoque_troca_ger_qtde") ec_embalagemestoque_troca_ger_qtde = Convert.ToDouble(row["ec_embalagemestoque_troca_ger_qtde"].ToString());
                        if (colArr[i].ColumnName == "ec_valor_custo_faturamento") ec_valor_custo_faturamento = Convert.ToDouble(row["ec_valor_custo_faturamento"].ToString());
                        if (colArr[i].ColumnName == "ec_valor_custo_precificacao") ec_valor_custo_precificacao = Convert.ToDouble(row["ec_valor_custo_precificacao"].ToString());
                        if (colArr[i].ColumnName == "ec_valor_customedio_comimposto") ec_valor_customedio_comimposto = Convert.ToDouble(row["ec_valor_customedio_comimposto"].ToString());
                        if (colArr[i].ColumnName == "ec_valor_customedio_semimposto") ec_valor_customedio_semimposto = Convert.ToDouble(row["ec_valor_customedio_semimposto"].ToString());
                        if (colArr[i].ColumnName == "ec_valor_ultimacompra_bruto") ec_valor_ultimacompra_bruto = Convert.ToDouble(row["ec_valor_ultimacompra_bruto"].ToString());
                        if (colArr[i].ColumnName == "ec_valor_ultimacompra_liq") ec_valor_ultimacompra_liq = Convert.ToDouble(row["ec_valor_ultimacompra_liq"].ToString());
                        if (colArr[i].ColumnName == "ecdb_seq") ecdb_seq = Convert.ToInt32(row["ecdb_seq"].ToString());
                        if (colArr[i].ColumnName == "eci_nf_data_entrada") eci_nf_data_entrada = Convert.ToDateTime(row["eci_nf_data_entrada"].ToString());
                        if (colArr[i].ColumnName == "pr_cdproduto") pr_cdproduto = Convert.ToInt32(row["pr_cdproduto"].ToString());
                        if (colArr[i].ColumnName == "proc_log_arquivo_seq") proc_log_arquivo_seq = Convert.ToInt32(row["proc_log_arquivo_seq"].ToString());
                    }
                }
            }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
    }
