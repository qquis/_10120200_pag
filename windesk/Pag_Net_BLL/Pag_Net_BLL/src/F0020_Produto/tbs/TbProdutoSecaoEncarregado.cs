using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0002_Enterprise;

namespace Pag_Net.src.F0020_Produto.tbs
{
    public class TbProdutoSecaoEncarregado
    {
        public int em_cdempresa     { get; set; }
        public int op_cdoperacao    { get; set; }
        public int prs_cdsecao      { get; set; }
        public string prs_descricao { get; set; }
        public int cdpessoabluesoft { get; set; }
        public string nome_razao { get; set; }


        public TbProdutoSecaoEncarregado()
        {
            em_cdempresa        = 0;
            op_cdoperacao       = 0;
            prs_cdsecao         = 0;
            cdpessoabluesoft    = 0;
            prs_descricao = "";
            nome_razao = "";
        }
        public TbProdutoSecaoEncarregado(

            int _em_cdempresa    ,
            int _op_cdoperacao   ,
            int _prs_cdsecao     ,
            int _cdpessoabluesoft,
            string _prs_descricao,
            string _nome_razao
                
                )
        {
          em_cdempresa           =       _em_cdempresa          ;
          op_cdoperacao          =       _op_cdoperacao         ;
          prs_cdsecao            =       _prs_cdsecao           ;
          cdpessoabluesoft       =       _cdpessoabluesoft;
          prs_descricao          =       _prs_descricao;
          nome_razao             =       _nome_razao;
                

        }

        public TbProdutoSecaoEncarregado(DataRow i)
        {

            em_cdempresa = Convert.ToInt32(i["em_cdempresa"].ToString());
            op_cdoperacao = Convert.ToInt16(i["op_cdoperacao"].ToString());
            prs_cdsecao = Convert.ToInt32(i["prs_cdsecao"].ToString());
            cdpessoabluesoft= Convert.ToInt32(i["cdpessoabluesoft"].ToString());
            prs_descricao = i["prs_descricao"].ToString();
            nome_razao = i["nome_razao"].ToString();



        }
    }
}

