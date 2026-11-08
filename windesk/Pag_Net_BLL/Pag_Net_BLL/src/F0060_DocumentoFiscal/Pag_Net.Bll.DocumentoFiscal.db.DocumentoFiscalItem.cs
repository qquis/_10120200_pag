using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0060_DocumentoFiscal.Db
{

    public class DocumentoFiscalItem
    {

        public int df_nf_seq_blue { get; set; }
        public int df_nf_i_seq_blue { get; set; }
        public int prb_cdprodutobluesoft { get; set; }
        public int prb_cdprodutobluesoft_nf { get; set; }
        public string df_nf_i_embalagem { get; set; }
        public string df_nf_i_cfop { get; set; }
        public double df_nf_i_valor_total { get; set; }
        public double df_nf_i_qtde { get; set; }
        public double df_nf_i_custo_bruto_total { get; set; }
        public double df_nf_i_fator_estoque { get; set; }
        public double df_nf_valor_ipi { get; set; }
        public double df_nf_valor_icms { get; set; }
        public double df_nf_valor_pis { get; set; }
        public double df_nf_valor_cofins { get; set; }
        public double df_nf_base_icms_unitario { get; set; }
        public double df_nf_base_icms { get; set; }
        public double df_nf_base_icms_st { get; set; }
        public double df_nf_base_pis { get; set; }
        public double df_nf_base_cofins { get; set; }
        public double df_nf_custo_contabil { get; set; }
        public int trib_cd_icms { get; set; }
        public int trib_cd_pis { get; set; }
        public int trib_cd_cofins { get; set; }
        public int em_cdempresabluesoft { get; set; }

        public DocumentoFiscalItem() { }
        public DocumentoFiscalItem(DataRow i)
        {

            string error = "";
            string ID = "";
            try
            {
                
                error = "df_nf_seq_blue";
                df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
                error = "df_nf_i_seq_blue";
                df_nf_i_seq_blue = Convert.ToInt32(i["df_nf_i_seq_blue"].ToString());


                ID = df_nf_i_seq_blue.ToString();

                error = "prb_cdprodutobluesoft";
                prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
                error = "prb_cdprodutobluesoft_nf";
                prb_cdprodutobluesoft_nf = Convert.ToInt32(i["prb_cdprodutobluesoft_nf"].ToString());
                error = "df_nf_i_embalagem";
                df_nf_i_embalagem = i["df_nf_i_embalagem"].ToString();
                error = "df_nf_i_cfop";
                df_nf_i_cfop = i["df_nf_i_cfop"].ToString();
                error = "df_nf_i_valor_total";
                df_nf_i_valor_total = Convert.ToDouble(i["df_nf_i_valor_total"].ToString());
                error = "df_nf_i_qtde";
                df_nf_i_qtde = Convert.ToDouble(i["df_nf_i_qtde"].ToString());
                error = "df_nf_i_custo_bruto_total";
                df_nf_i_custo_bruto_total = Convert.ToDouble(i["df_nf_i_custo_bruto_total"].ToString());
                error = "df_nf_i_fator_estoque";
                df_nf_i_fator_estoque = Convert.ToDouble(i["df_nf_i_fator_estoque"].ToString());
                error = "df_nf_valor_ipi";
                df_nf_valor_ipi = Convert.ToDouble(i["df_nf_valor_ipi"].ToString());
                error = "df_nf_valor_icms";
                df_nf_valor_icms = Convert.ToDouble(i["df_nf_valor_icms"].ToString());
                error = "df_nf_valor_pis";
                df_nf_valor_pis = Convert.ToDouble(i["df_nf_valor_pis"].ToString());
                error = "df_nf_valor_cofins";
                df_nf_valor_cofins = Convert.ToDouble(i["df_nf_valor_cofins"].ToString());
                error = "df_nf_base_icms_unitario";
                df_nf_base_icms_unitario = Convert.ToDouble(i["df_nf_base_icms_unitario"].ToString());
                error = "df_nf_base_icms";
                df_nf_base_icms = Convert.ToDouble(i["df_nf_base_icms"].ToString());
                error = "df_nf_base_icms_st";
                df_nf_base_icms_st = Convert.ToDouble(i["df_nf_base_icms_st"].ToString());
                error = "df_nf_base_pis";
                df_nf_base_pis = Convert.ToDouble(i["df_nf_base_pis"].ToString());
                error = "df_nf_base_cofins";
                df_nf_base_cofins = Convert.ToDouble(i["df_nf_base_cofins"].ToString());
                error = "df_nf_custo_contabil";
                df_nf_custo_contabil = Convert.ToDouble(i["df_nf_custo_contabil"].ToString());
                error = "trib_cd_icms";
                trib_cd_icms = Convert.ToInt32(i["trib_cd_icms"].ToString());
                error = "trib_cd_pis";
                trib_cd_pis = Convert.ToInt32(i["trib_cd_pis"].ToString());
                error = "trib_cd_cofins";
                trib_cd_cofins = Convert.ToInt32(i["trib_cd_cofins"].ToString());
                error = "em_cdempresabluesoft";
                em_cdempresabluesoft = Convert.ToInt32(i["em_cdempresabluesoft"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Processamento do CAMPO " + error + " NO ID " + ID.ToString());
            }
        }
    }

}
