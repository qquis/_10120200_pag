using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0070_Faturamento.interfaces
{
    public class globalFilter
    {
        public int sis_us_seq { get; set; }
        public int tipo_visualizacao { get; set; }
        public int seqfaturamento { get; set; }
        public int seqfaturamentoorigem { get; set; }
        public string em_cdempresa_list { get; set; }
        public string op_cdoperacao_list { get; set; }
        public int filtra_data_faturamento { get; set; }
        public DateTime datafaturamento_ini { get; set; }
        public DateTime datafaturamento_fim { get; set; }
        public int filtra_data_emissao { get; set; }
        public DateTime dataemissao_ini { get; set; }
        public DateTime dataemissao_fim { get; set; }
        public int prd_cddepartamento { get; set; }
        public int prs_cdsecao { get; set; }
        public int prg_cdgrupo { get; set; }
        public int prsg_cdsubgrupo { get; set; }
        public string pr_cdproduto { get; set; }
        public string prb_cdprodutobluesoft { get; set; }
        public string pr_descricao { get; set; }
        public int cdpessoabluesoft_secao_encarregado { get; set; }
        public int faturamento_cdparticipante_vendedor { get; set; }
        public int faturamento_cdparticipante_cliente { get; set; }
        public int cdgrupoeconomico { get; set; }
        public string nome_razao { get; set; }
        public int statusfaturamento { get; set; }
        public int cdpessoabluesoft_fabricante { get; set; }
        public int grupo_economico_top { get; set; }
        public string numeroPedidoList { get; set; }
        public string numeroNfeList { get; set;  }
        public int ECF { get; set;  }
        public string numeroCupomFiscalList { get; set; }

        public globalFilter()
        {
            seqfaturamento = 0;
            seqfaturamentoorigem = 0;
            tipo_visualizacao = 10;
            em_cdempresa_list = "1";
            op_cdoperacao_list = "";
            filtra_data_faturamento = 1;
            datafaturamento_ini = DateTime.Now;
            datafaturamento_fim = DateTime.Now;
            filtra_data_emissao = 0;
            dataemissao_ini = DateTime.Now;
            dataemissao_fim = DateTime.Now;

            prd_cddepartamento = 0;
            prs_cdsecao = 0;
            prg_cdgrupo = 0;
            prsg_cdsubgrupo = 0;
            pr_cdproduto = "";
            prb_cdprodutobluesoft = "";
            pr_descricao = "";
            cdpessoabluesoft_secao_encarregado = 0;
            faturamento_cdparticipante_vendedor = 0;
            faturamento_cdparticipante_cliente = 0;
            cdgrupoeconomico = 0;
            nome_razao = "";
            cdpessoabluesoft_fabricante = 0;
            grupo_economico_top = 0;
            numeroPedidoList = "";
            numeroNfeList = "";
            ECF = 0;
            numeroCupomFiscalList = "";



        }
        public globalFilter(

            int _tipo_visualizacao,
            string _em_cdempresa_list,
            string _op_cdoperacao_list,
            int _data_faturamento,
            DateTime _datafaturamento_ini,
            DateTime _datafaturamento_fim,
            int _data_emissao,
            DateTime _dataemissao_ini,
            DateTime _dataemissao_fim,
             int _prd_cddepartamento,
             int _prs_cdsecao,
             int _prg_cdgrupo,
             int _prsg_cdsubgrupo,
               string _pr_cdproduto,
               string _prb_cdprodutobluesoft,
               string _pr_descricao,
            int _cdpessoabluesoft_secao_encarregado,
            int _cdpessoabluesoft_fabricante

            )
        {
            seqfaturamento = 0;
            seqfaturamentoorigem = 0;
            tipo_visualizacao = _tipo_visualizacao;
            em_cdempresa_list = _em_cdempresa_list;
            op_cdoperacao_list = _op_cdoperacao_list;
            filtra_data_faturamento = _data_faturamento;
            datafaturamento_ini = _datafaturamento_ini;
            datafaturamento_fim = _datafaturamento_fim;
            filtra_data_emissao = _data_emissao;
            dataemissao_ini = _dataemissao_ini;
            dataemissao_fim = _dataemissao_fim;

            prd_cddepartamento = _prd_cddepartamento;
            prs_cdsecao = _prs_cdsecao;
            prg_cdgrupo = _prg_cdgrupo;
            prsg_cdsubgrupo = _prsg_cdsubgrupo;
            pr_cdproduto = _pr_cdproduto;
            prb_cdprodutobluesoft = _prb_cdprodutobluesoft;
            pr_descricao = _pr_descricao;
            cdpessoabluesoft_secao_encarregado = _cdpessoabluesoft_secao_encarregado;
            faturamento_cdparticipante_vendedor = 0;
            faturamento_cdparticipante_cliente = 0;
            cdgrupoeconomico = 0;
            nome_razao = "";

            cdpessoabluesoft_fabricante = _cdpessoabluesoft_fabricante;

            numeroPedidoList = "";
            numeroNfeList = "";
            ECF = 0;
            numeroCupomFiscalList = "";

        }
    }
}
