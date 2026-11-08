using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0030_EstoqueCusto
{
    public class TbEstoqueCusto_DiarioBlueSoft
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
        public double ecdb_composicao_vl_mao_de_obra { get; set; }
        public double ecdb_composicao_vl_custo_indireto { get; set; }
        public double ecdb_composicao_itens { get; set; }
        public double ecdb_composicao_QTDE { get; set; }
        public double ecdb_composicao_vl_custo { get; set; }
        public double ecdb_embalagemestoque_troca_ger_qtde { get; set; }
        public double ecdb_embalagemestoque_troca_cont_qtde { get; set;  }



        public TbEstoqueCusto_DiarioBlueSoft() { }
        public TbEstoqueCusto_DiarioBlueSoft(DataRow i)
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
            ecdb_composicao_vl_mao_de_obra = Convert.ToDouble(i["ecdb_composicao_vl_mao_de_obra"].ToString());
            ecdb_composicao_vl_custo_indireto = Convert.ToDouble(i["ecdb_composicao_vl_custo_indireto"].ToString());
            ecdb_composicao_itens = Convert.ToDouble(i["ecdb_composicao_itens"].ToString());
            ecdb_composicao_QTDE = Convert.ToDouble(i["ecdb_composicao_QTDE"].ToString());
            ecdb_composicao_vl_custo = Convert.ToDouble(i["ecdb_composicao_vl_custo"].ToString());
            ecdb_embalagemestoque_troca_ger_qtde = Convert.ToDouble(i["ecdb_embalagemestoque_troca_ger_qtde"].ToString());
            ecdb_embalagemestoque_troca_cont_qtde = Convert.ToDouble(i["ecdb_embalagemestoque_troca_cont_qtde"].ToString());



        }
    }
}
