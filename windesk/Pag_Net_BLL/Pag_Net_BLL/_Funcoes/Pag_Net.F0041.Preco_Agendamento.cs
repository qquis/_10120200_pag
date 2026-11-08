using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0041;
using Pag_Net.F0041.Models;

namespace Pag_Net.F0041.Bll
{

    public static class Postgres
    {
        public static void CRUD(Pag_Net.Models.modelSistemaUsuario MyConnect, f0041_crud_tbpreco_agendamento item)
        {
            try {

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                string SQL_POSTGRE_EXEC = string.Format("SELECT f0041_crud_tbpreco_agendamento (	    " +
                                                               MyConnect.SEQUENCIAL_DE_PROCESSO.ToString() + 
                                                               "       ,   'DBINSERT'        " +
                                                               "       ,     {0}             " +
                                                               "       ,     {1}             " +
                                                               "       ,     {2}             " +
                                                               "       ,     {3}             " +
                                                               "       ,     {4}             " +
                                                               "       ,     {5}             " +
                                                               "       ,    '{6}'            " +
                                                               "       ,    '{7}'            " +
                                                               "       ,    '{8}'            " +
                                                               "       ,    'false'          )",
                                                        item.pr_cdproduto.ToString(),
                                                        item.pr_cdprodutobluesoft.ToString(),
                                                        item.tab_pre_cd.ToString(),
                                                        item.prca_valor.ToString().Replace(",","."),
                                                        item.prca_qtde_promocional.ToString().Replace(",","."),
                                                        item.prca_valor_promocional.ToString().Replace(",", "."),
                                                        item.prca_dt_validade_ini.ToString("yyyy-MM-dd"),
                                                        item.prca_dt_validade_fim.ToString("yyyy-MM-dd"),
                                                        item.prca_definitivo.ToString()
                                                               );
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);
                }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0041.Bll | Update: " + ex.Message);
            }
        }
    }
}

namespace Pag_Net.F0041.Models
{
    public class f0041_crud_tbpreco_agendamento
    {
        public int      pr_cdproduto            { get; set;}
        public int      pr_cdprodutobluesoft    { get; set; }
        public int      tab_pre_cd              { get; set; }
        public double   prca_valor              { get; set; }
        public double   prca_qtde_promocional   { get; set; }
        public double prca_valor_promocional { get; set; }
        public DateTime prca_dt_validade_ini    { get; set; }
        public DateTime prca_dt_validade_fim    { get; set; }
        public bool prca_definitivo { get; set; }

        public f0041_crud_tbpreco_agendamento(){}

        public f0041_crud_tbpreco_agendamento(
            
            int      _pr_cdproduto           ,
            int      _pr_cdprodutobluesoft   ,
            int      _tab_pre_cd             ,
            double   _prca_valor             ,
            double   _prca_qtde_promocional  ,
            double _prca_valor_promocional,
            DateTime _prca_dt_validade_ini   , 
            DateTime _prca_dt_validade_fim   , 
            bool     _prca_definitivo 
            )
        {
            if (_tab_pre_cd == 0)
            {
                _tab_pre_cd = 1; //Tabela Padrão//
            }

            pr_cdproduto            = _pr_cdproduto          ;
            pr_cdprodutobluesoft    = _pr_cdprodutobluesoft  ;
            tab_pre_cd              = _tab_pre_cd            ;
            prca_valor              = _prca_valor           ;
            prca_qtde_promocional   = _prca_qtde_promocional;
            prca_valor_promocional = _prca_valor_promocional;
            prca_dt_validade_ini    = _prca_dt_validade_ini;
            prca_dt_validade_fim    = _prca_dt_validade_fim;
            prca_definitivo         = _prca_definitivo;
        }
    }
}
