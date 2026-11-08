using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0002_Enterprise;

namespace Pag_Net.Bll.F0133_Comercial_PedidoBlueSoft
{
    public class TbComercial_PedidoBlueSoft
    {
        public int      cm_pedblue_seq                          {get;set;}
        public int      cm_pedblue_numeropedido                 {get;set;}
        public DateTime cm_pedblue_dataemissao                  {get;set;}
        public DateTime cm_pedblue_datafechamento               {get;set;}
        public DateTime cm_pedblue_dataentregainicial           {get;set;}
        public DateTime cm_pedblue_dataentregafinal             {get;set;}
        public int      cm_pedblue_cdpessoabluesoft_fornecedor  {get;set;}
        public int      cm_pedblue_divisao_cd                   {get;set;}
        public int      cm_pedblue_status_cd                    {get;set;}
        public string   cm_pedblue_status_bluesoft              {get;set;}




        public TbComercial_PedidoBlueSoft()
        {
            cm_pedblue_seq                                  = 0;
            cm_pedblue_numeropedido                         = 0;
            cm_pedblue_dataemissao = DateTime.Now;
            cm_pedblue_datafechamento                       = DateTime.Now;
            cm_pedblue_dataentregainicial                   = DateTime.Now;
            cm_pedblue_dataentregafinal                     = DateTime.Now;
            cm_pedblue_cdpessoabluesoft_fornecedor          = 0;
            cm_pedblue_divisao_cd                           = 0;
            cm_pedblue_status_cd                            = 0;
            cm_pedblue_status_bluesoft = "";

        }
        public TbComercial_PedidoBlueSoft(


            int      _cm_pedblue_seq,
            int      _cm_pedblue_numeropedido,
            DateTime _cm_pedblue_dataemissao,                
            DateTime _cm_pedblue_datafechamento,             
            DateTime _cm_pedblue_dataentregainicial,         
            DateTime _cm_pedblue_dataentregafinal,           
            int      _cm_pedblue_cdpessoabluesoft_fornecedor,
            int      _cm_pedblue_divisao_cd,
            int      _cm_pedblue_status_cd,
            string   _cm_pedblue_status_bluesoft
                
                )
        {
                  cm_pedblue_seq                                   = _cm_pedblue_seq;  
                  cm_pedblue_numeropedido                          = _cm_pedblue_numeropedido;
                  cm_pedblue_dataemissao                           = _cm_pedblue_dataemissao;                
                  cm_pedblue_datafechamento                        = _cm_pedblue_datafechamento;             
                  cm_pedblue_dataentregainicial                    = _cm_pedblue_dataentregainicial;         
                  cm_pedblue_dataentregafinal                      = _cm_pedblue_dataentregafinal;           
                  cm_pedblue_cdpessoabluesoft_fornecedor           = _cm_pedblue_cdpessoabluesoft_fornecedor;
                  cm_pedblue_divisao_cd                            = _cm_pedblue_divisao_cd;
                  cm_pedblue_status_cd                             = _cm_pedblue_status_cd;
                  cm_pedblue_status_bluesoft = _cm_pedblue_status_bluesoft;

        }

        public TbComercial_PedidoBlueSoft(DataRow i)
        {
            cm_pedblue_seq = Convert.ToInt32(i["cm_pedblue_seq"].ToString());
            cm_pedblue_numeropedido = Convert.ToInt32(i["cm_pedblue_numeropedido"].ToString());
            cm_pedblue_dataemissao = Convert.ToDateTime(i["cm_pedblue_dataemissao"].ToString());
            cm_pedblue_datafechamento = Convert.ToDateTime(i["cm_pedblue_datafechamento"].ToString());
            cm_pedblue_dataentregainicial = Convert.ToDateTime(i["cm_pedblue_dataentregainicial"].ToString());
            cm_pedblue_dataentregafinal = Convert.ToDateTime(i["cm_pedblue_dataentregafinal"].ToString());
            cm_pedblue_cdpessoabluesoft_fornecedor = Convert.ToInt32(i["cm_pedblue_cdpessoabluesoft_fornecedor"].ToString());
            cm_pedblue_divisao_cd = Convert.ToInt32(i["cm_pedblue_divisao_cd"].ToString());
            cm_pedblue_status_cd = Convert.ToInt32(i["cm_pedblue_status_cd"].ToString());
            cm_pedblue_status_bluesoft = i["cm_pedblue_status_bluesoft"].ToString();
        }
    }
}

