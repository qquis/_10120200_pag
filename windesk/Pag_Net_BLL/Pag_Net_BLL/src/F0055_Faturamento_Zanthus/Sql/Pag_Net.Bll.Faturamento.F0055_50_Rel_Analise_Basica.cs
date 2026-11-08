using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0055_Faturamento_Zanthus.F0055_50_Relatorio_Analise_Basica
{
    public static class RedShift
    {
        public static string get()
        {
            return "";
        }
    }

    public static class Postgre
    {
        private static string _VERSION() { return "f0055_50_1012006_faturamento_rel_analise_basica"; }
        public static string Get(
             Pag_Net.Bll.F0055_Faturamento_Zanthus.Filter _filter
            )
        {
            try
            {
                string _PostGre = string.Format("SELECT * FROM " + _VERSION() + "( {0}, '{1}', '{2}', {3}, '{4}', '{5}', {6}, '{7}', '{8}', {9}, {10}, {11}, {12}, {13}, {14}, '{15}', {16}, {17}, {18}, {19}, '{20}', {21}, {22}, {23}, {24} ) ",
                            _filter.tipo_visualizacao.ToString(),
                            _filter.em_cdempresa_list.ToString() ,
                            _filter.op_cdoperacao_list.ToString() , 	  
                            _filter.filtra_data_faturamento.ToString() ,	  
                            _filter.datafaturamento_ini.ToString("yyyy-MM-dd") ,
                            _filter.datafaturamento_fim.ToString("yyyy-MM-dd"),	  
                            _filter.filtra_data_emissao.ToString() ,
                            _filter.dataemissao_ini.ToString("yyyy-MM-dd"),
                            _filter.dataemissao_fim.ToString("yyyy-MM-dd"), 
                            _filter.prd_cddepartamento.ToString() ,
                            _filter.prs_cdsecao.ToString() ,
                            _filter.prg_cdgrupo.ToString(),            
                            _filter.prsg_cdsubgrupo.ToString(), 
                            _filter.pr_cdproduto.ToString(), 
                            _filter.prb_cdprodutobluesoft.ToString(), 
                            _filter.pr_descricao.ToString().Replace("'", "").ToUpper(),
                            _filter.cdpessoabluesoft_secao_encarregado.ToString(), 
                            _filter.faturamento_cdparticipante_vendedor.ToString(),
                            _filter.faturamento_cdparticipante_cliente.ToString(),
                            _filter.cdgrupoeconomico.ToString(), 
                            _filter.nome_razao.ToString(), 
                            _filter.statusfaturamento.ToString(),
                            _filter.cdpessoabluesoft_fabricante.ToString(),
                            _filter.sis_us_seq.ToString(), 
                            _filter.grupo_economico_top.ToString()
                    );
                return _PostGre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
