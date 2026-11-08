using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0040;
using Pag_Net.F0040.Models;

namespace Pag_Net.F0040.Bll
{

    public static class Postgres
    {
        public static void CRUD(Pag_Net.Models.modelSistemaUsuario MyConnect, f0040_crud_tbpreco item )
        {
            try {

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                string SQL_POSTGRE_EXEC = string.Format("SELECT f0040_crud_tbpreco (	     " +
                                                               MyConnect.SEQUENCIAL_DE_PROCESSO.ToString() +    
                                                               "       ,   'DBINSERT'        " +
                                                               "       ,     {0}             " +
                                                               "       ,     {1}             " +
                                                               "       ,     {2}             " +
                                                               "       ,     {3}             " +
                                                               "       ,     {4}             " +
                                                               "       ,     {5}             " +
                                                               "       ,    'false'         )",
                                                        item.pr_cdproduto.ToString(),
                                                        item.pr_cdprodutobluesoft.ToString(),
                                                        item.tab_pre_cd.ToString(),
                                                        item.prc_valor.ToString().Replace(",","."),
                                                        item.prc_qtde_promocional.ToString().Replace(",","."),
                                                        item.prc_valor_promocional.ToString().Replace(",",".")
                                                               );
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);
                }
            catch (Exception ex)
            {
                throw new Exception("F0040.Bll | Update: " + ex.Message);
            }
        }
    }
}

namespace Pag_Net.F0040.Models
{
    public class f0040_crud_tbpreco
    {
        public int      pr_cdproduto            { get; set;}
        public int      pr_cdprodutobluesoft    { get; set; }
        public int      tab_pre_cd              { get; set; }
        public double   prc_valor               { get; set; }
        public double   prc_qtde_promocional    { get; set; }
        public double   prc_valor_promocional   { get; set; }

        public f0040_crud_tbpreco(){}

        public f0040_crud_tbpreco(
            
            int      _pr_cdproduto           ,
            int      _pr_cdprodutobluesoft   ,
            int      _tab_pre_cd             ,
            double   _prc_valor              ,
            double   _prc_qtde_promocional   ,
            double   _prc_valor_promocional   
            )
        {
            if (_tab_pre_cd == 0)
            {
                _tab_pre_cd = 1; //Tabela Padrão//
            }

            pr_cdproduto            = _pr_cdproduto          ;
            pr_cdprodutobluesoft    = _pr_cdprodutobluesoft  ;
            tab_pre_cd              = _tab_pre_cd            ;
            prc_valor               = _prc_valor             ;
            prc_qtde_promocional    = _prc_qtde_promocional    ;
            prc_valor_promocional = _prc_valor_promocional;
        }
    }
}
