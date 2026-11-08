using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0016;
using Pag_Net.F0016.Models;

namespace Pag_Net.F0016.Bll
{


    public static class Postgres
    {
        public static void CRUD(Pag_Net.Models.modelSistemaUsuario MyConnect, f0016_CRUD_TbProdutoEmbalagem item)
        {
            try {
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(CRUD(item), null, DataBaseName.ODBCOXAN);
                }
            catch (Exception ex)
            {
                throw new Exception("F0040.Bll | Update: " + ex.Message);
            }
        }

        public static string CRUD(f0016_CRUD_TbProdutoEmbalagem item)
        {
            return string.Format("SELECT f0016_01_1011846_crud_tbprodutoembalagem (	    " +
                                                        "           'DBINSERT'        " +
                                                        "       ,     {0}             " +
                                                        "       ,     {1}             " +
                                                        "       ,    '{2}'            " +
                                                        "       ,     {3}             " +
                                                        "       ,     {4}             " +
                                                        "       ,    '{5}'            " +
                                                        "       ,    'false'         ) ",
                                                        item.pr_cdproduto.ToString(),
                                                        item.pr_cdprodutobluesoft.ToString(),
                                                        item.pre_embalagem.ToString(),
                                                        item.pre_fatorestoque.ToString("0.00").Replace(",","."),
                                                        item.pre_fatorpreco.ToString("0.00").Replace(",", "."),
                                                        item.pre_status.ToString());
        }
    }
}

namespace Pag_Net.F0016.Models
{
    public class f0016_CRUD_TbProdutoEmbalagem
    {
        public int      pr_cdproduto            { get; set; }
        public int      pr_cdprodutobluesoft    { get; set; }
        public string   pre_embalagem           { get; set; }
	    public double   pre_fatorestoque        { get; set; }
	    public double   pre_fatorpreco          { get; set; }
        public bool     pre_status              { get; set; }
        public string   pre_embalagem_descricao { get; set; }    

        public f0016_CRUD_TbProdutoEmbalagem(){}

        public f0016_CRUD_TbProdutoEmbalagem(
             
            int      _pr_cdproduto           ,
            int      _pr_cdprodutobluesoft   ,
            string   _pre_embalagem          ,
            double   _pre_fatorestoque       ,
            double   _pre_fatorpreco         ,
            bool     _pre_status             , 
            string   _pre_embalagem_descricao 
            )
        {
            

            pr_cdproduto           = _pr_cdproduto          ;
            pr_cdprodutobluesoft   = _pr_cdprodutobluesoft  ;
            pre_embalagem          = _pre_embalagem         ;
            pre_fatorestoque       = _pre_fatorestoque      ;
            pre_fatorpreco         = _pre_fatorpreco        ;
            pre_status             = _pre_status            ;
            pre_embalagem_descricao = _pre_embalagem_descricao;
        }
    }
}
