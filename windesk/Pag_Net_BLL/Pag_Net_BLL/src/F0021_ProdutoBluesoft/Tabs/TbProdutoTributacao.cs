using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0021_ProdutoBlueSoft
{
    public class TbProdutoTributacao
    {
        public string Tipo { get; set; }
        public int prb_CdProdutoBlueSoft { get; set; }
        public int op_cdoperacao { get; set; }
        public int prbt_RegraFiscal { get; set; }
        public int prbt_RegraFiscalVersao { get; set; }
        public string prbt_CFOP { get; set; }
        public string prbt_RegimeTributario { get; set; }
        public string prbt_PIS_Entrada_CST { get; set; }
        public double prbt_PIS_Entrada_Aliquota { get; set; }
        public string prbt_PIS_Saida_CST { get; set; }
        public double prbt_PIS_Saida_Aliquota { get; set; }
        public string prbt_COFINS_Entrada_CST { get; set; }
        public double prbt_COFINS_Entrada_Aliquota { get; set; }
        public string prbt_COFINS_Saida_CST { get; set; }
        public double prbt_COFINS_Saida_Aliquota { get; set; }

        public string prbt_ICMS_Entrada_CST { get; set; }
        public double prbt_ICMS_Entrada_Aliquota_Interna { get; set; }
        public double prbt_ICMS_Entrada_Reducao { get; set; }

        public string prbt_ICMS_Revenda_CST { get; set; }
        public double prbt_ICMS_Revenda_Aliquota_Interna { get; set; }
        public double prbt_ICMS_Revenda_Reducao { get; set; }


        public string prbt_ICMS_Saida_CST { get; set; }
        public double prbt_ICMS_Aliquota_Interna { get; set; }
        public double prbt_ICMS_Reducao { get; set; }

        public string prbt_NCM { get; set; }
        public string prbt_CEST { get; set; }
        public double prbt_ST_IVA { get; set; }


        public TbProdutoTributacao() { }
        public TbProdutoTributacao(DataRow i)
        {
            prb_CdProdutoBlueSoft = Convert.ToInt32(i["CdProdutoBlueSoft"]);
            op_cdoperacao = Convert.ToInt32(i["CdOperacao"]);
            prbt_RegraFiscal = Convert.ToInt32(i["CdRegraFiscal"]);
            prbt_RegraFiscalVersao = Convert.ToInt32(i["CdRegraFiscalVersao"]);
            prbt_CFOP = i["CFOP"].ToString();
            prbt_RegimeTributario = i["RegimeTributario"].ToString();
            prbt_PIS_Entrada_CST = i["PIS_Entrada_CST"].ToString();
            prbt_PIS_Entrada_Aliquota = Convert.ToDouble(i["PIS_Entrada_Aliquota"].ToString());
            prbt_PIS_Saida_CST = i["PIS_Saida_CST"].ToString();
            prbt_PIS_Saida_Aliquota = Convert.ToDouble(i["PIS_Saida_Aliquota"].ToString());
            prbt_COFINS_Entrada_CST = i["COFINS_Entrada_CST"].ToString();
            prbt_COFINS_Entrada_Aliquota = Convert.ToDouble(i["COFINS_Entrada_Aliquota"].ToString());
            prbt_COFINS_Saida_CST = i["COFINS_Saida_CST"].ToString();
            prbt_COFINS_Saida_Aliquota = Convert.ToDouble(i["COFINS_Saida_Aliquota"].ToString());

            prbt_ICMS_Entrada_CST = i["ICMS_Entrada_CST"].ToString();
            prbt_ICMS_Entrada_Aliquota_Interna = Convert.ToDouble(i["ICMS_Entrada_Aliquota_Interna"].ToString());
            prbt_ICMS_Entrada_Reducao = Convert.ToDouble(i["ICMS_Entrada_Reducao"].ToString());

            prbt_ICMS_Revenda_CST = i["ICMS_Revenda_CST"].ToString();
            prbt_ICMS_Revenda_Aliquota_Interna = Convert.ToDouble(i["ICMS_Revenda_Aliquota_Interna"].ToString());
            prbt_ICMS_Revenda_Reducao = Convert.ToDouble(i["ICMS_Revenda_Reducao"].ToString());

            prbt_ICMS_Saida_CST = i["ICMS_Saida_CST"].ToString();
            prbt_ICMS_Aliquota_Interna = Convert.ToDouble(i["ICMS_Aliquota_Interna"].ToString());
            prbt_ICMS_Reducao = Convert.ToDouble(i["ICMS_Reducao"].ToString());

            prbt_NCM = i["NCM"].ToString();
            prbt_CEST = i["CEST"].ToString();
            prbt_ST_IVA = Convert.ToDouble(i["ST_IVA"].ToString());



        }
    }
}
