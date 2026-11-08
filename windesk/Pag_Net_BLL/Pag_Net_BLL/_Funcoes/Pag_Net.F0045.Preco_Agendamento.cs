using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0041;
using Pag_Net.F0041.Models;

namespace Pag_Net.Bll.F0045
{

    public class Parametros
    {
        public bool agendamento { get; set; }
        public DateTime prca_dt_aplicacao { get; set; }
        public int prca_dt_aplicacao_definitiva { get; set; }
        public int pr_cdproduto { get; set; }
        public int pr_cdprodutobluesoft { get; set; }
        public int tab_pre_cd { get; set; }
        public double prc_valor { get; set; }
        public double prc_qtde_promocional { get; set; }
        public double prc_valor_promocional { get; set; }
        public double pre_fatorpreco { get; set; }

        public Parametros() { }

        public Parametros(
             bool _agendamento
          , DateTime _prca_dt_aplicacao
          , int _prca_dt_aplicacao_definitiva
          , int _pr_cdproduto
          , int _pr_cdprodutobluesoft
          , int _tab_pre_cd
          , double _prc_valor
          , double _prc_qtde_promocional
          , double _prc_valor_promocional
          , double _pre_fatorpreco

            )
        {
            if (_tab_pre_cd == 0)
            {
                _tab_pre_cd = 1; //Tabela Padrão//
            }

            agendamento = _agendamento;
            prca_dt_aplicacao = _prca_dt_aplicacao;
            prca_dt_aplicacao_definitiva = _prca_dt_aplicacao_definitiva;
            pr_cdproduto = _pr_cdproduto;
            pr_cdprodutobluesoft = _pr_cdprodutobluesoft;
            tab_pre_cd = _tab_pre_cd;
            prc_valor = _prc_valor;
            prc_qtde_promocional = _prc_qtde_promocional;
            prc_valor_promocional = _prc_valor_promocional;
            pre_fatorpreco = _pre_fatorpreco;


        }
    }


    public static class Postgres
    {
        /*public static void CRUD(Pag_Net.Models.TbSysUserInfo MyConnect, Pag_Net.F0045.Models.Db item)
        {
            try {

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                string SQL_POSTGRE_EXEC = string.Format("SELECT f0045_crud_tbpreco_agendamento (	    " +
                                                               MyConnect.SEQUENCIAL_DE_PROCESSO.ToString() + 
                                                               "       ,    '{0}'            " +
                                                               "       ,    '{1}'            " +
                                                               "       ,     {2}             " +
                                                               "       ,     {3}             " +
                                                               "       ,     {4}             " +
                                                               "       ,     {5}             " +
                                                               "       ,     {6}             " +
                                                               "       ,     {7}             " +
                                                               "       ,     {8}             " +
                                                               "       ,     {9}             )",
                                                        item.agendamento.ToString(),
                                                        item.prca_dt_aplicacao.ToString("yyyy-MM-dd"),
                                                        item.prca_dt_aplicacao_definitiva.ToString(),
                                                        item.pr_cdproduto.ToString(),
                                                        item.pr_cdprodutobluesoft.ToString(),
                                                        item.tab_pre_cd.ToString(),
                                                        item.prc_valor.ToString().Replace(",","."),
                                                        item.prc_qtde_promocional.ToString().Replace(",","."),
                                                        item.prc_valor_promocional.ToString().Replace(",", "."),
                                                        item.pre_fatorpreco.ToString().Replace(",", ".")
                                                               );
                    BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);
                }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0045.Bll | Update: " + ex.Message);
            }
        }*/
        public static string Post(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Bll.F0045.Parametros item)
        {

            
            string SQL_POSTGRE_EXEC = string.Format("SELECT f0045_01_1012003_precoagendamento_crud (	    " +
                                                           MyConnect.SEQUENCIAL_DE_PROCESSO.ToString() +
                                                           "       ,    '{0}'            " +
                                                           "       ,    '{1}'            " +
                                                           "       ,     {2}             " +
                                                           "       ,     {3}             " +
                                                           "       ,     {4}             " +
                                                           "       ,     {5}             " +
                                                           "       ,     {6}             " +
                                                           "       ,     {7}             " +
                                                           "       ,     {8}             " +
                                                           "       ,     {9}             )",
                                                    item.agendamento.ToString(),
                                                    item.prca_dt_aplicacao.ToString("yyyy-MM-dd"),
                                                    item.prca_dt_aplicacao_definitiva.ToString(),
                                                    item.pr_cdproduto.ToString(),
                                                    item.pr_cdprodutobluesoft.ToString(),
                                                    item.tab_pre_cd.ToString(),
                                                    item.prc_valor.ToString().Replace(",", "."),
                                                    item.prc_qtde_promocional.ToString().Replace(",", "."),
                                                    item.prc_valor_promocional.ToString().Replace(",", "."),
                                                    item.pre_fatorpreco.ToString().Replace(",", "."));
            /*
            string SQL_POSTGRE_EXEC = string.Format("SELECT f0045_crud_tbpreco_agendamento (	    " +
                                                           MyConnect.SEQUENCIAL_DE_PROCESSO.ToString() +
                                                           "       ,    '{0}'            " +
                                                           "       ,    '{1}'            " +
                                                           "       ,     {2}             " +
                                                           "       ,     {3}             " +
                                                           "       ,     {4}             " +
                                                           "       ,     {5}             " +
                                                           "       ,     {6}             " +
                                                           "       ,     {7}             " +
                                                           "       ,     {8}             " +
                                                           "       ,     {9}             )",
                                                    item.agendamento.ToString(),
                                                    item.prca_dt_aplicacao.ToString("yyyy-MM-dd"),
                                                    item.prca_dt_aplicacao_definitiva.ToString(),
                                                    item.pr_cdproduto.ToString(),
                                                    item.pr_cdprodutobluesoft.ToString(),
                                                    item.tab_pre_cd.ToString(),
                                                    item.prc_valor.ToString().Replace(",", "."),
                                                    item.prc_qtde_promocional.ToString().Replace(",", "."),
                                                    item.prc_valor_promocional.ToString().Replace(",", "."),
                                                    item.pre_fatorpreco.ToString().Replace(",", ".")
                                                           );
             * */
            return SQL_POSTGRE_EXEC;
        }
    }
}

namespace Pag_Net.F0045.Parametros
{
  
}
