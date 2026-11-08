using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0031_01
{
    public class Parametros
    {
        public DateTime     data_recebimento_ini    { get; set; }
        public DateTime     data_recebimento_fim    { get; set; }
        public int          pr_cdproduto            { get; set; }
        public int          prb_cdprodutobluesoft   { get; set; }
        public string       descricao               { get; set; }
        public int          ece_nf_numero           { get; set; }
        public string       nome_razao              { get; set; }
        public Parametros(
                DateTime _data_recebimento_ini
              , DateTime _data_recebimento_fim
              , int _pr_cdproduto
              , int _prb_cdprodutobluesoft
              , string _descricao
              , int _ece_nf_numero
              , string _nome_razao
            )
        {

            data_recebimento_ini = _data_recebimento_ini;
            data_recebimento_fim = _data_recebimento_fim;
            pr_cdproduto = _pr_cdproduto;
            prb_cdprodutobluesoft = _prb_cdprodutobluesoft;
            descricao = _descricao;
            ece_nf_numero = _ece_nf_numero;
            nome_razao = _nome_razao;


        }
    }
    public static class Postgres
    {
        public static string Get(
    			Pag_Net.Bll.R0031_01.Parametros _parametros 
            )
        {

            try
            {
                string _strparametros = string.Format("           '{0}'     " + 
                                                   "          ,'{1}'     " + 
                                                   "          , {2}      " +  
                                                   "          , {3}      " +  
                                                   "          ,'{4}'     " +  
                                                   "          , {5}      "  +  
                                                   "          ,'{6}'     ",
                                                    _parametros.data_recebimento_ini.ToString("yyyy-MM-dd"),
                                                    _parametros.data_recebimento_fim.ToString("yyyy-MM-dd"),
                                                    _parametros.pr_cdproduto.ToString(),
                                                    _parametros.prb_cdprodutobluesoft.ToString(),
                                                    _parametros.descricao.ToString().Replace("'", ""),
                                                    _parametros.ece_nf_numero.ToString(),
                                                    _parametros.nome_razao.ToString().Replace("'", "")
                                                         );

                return Pag_Net.Bll.BDCommand.ScriptSql_Get(Pag_Net.Bll.BDCommand.Name.R0031_01, _strparametros);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}













