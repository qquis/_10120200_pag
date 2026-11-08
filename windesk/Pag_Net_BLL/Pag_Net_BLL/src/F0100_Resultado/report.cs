using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0100_Resultado
{

    public class _indexReport
    {

        public Pag_Net.src.F0100_Resultado.interfaces.Filter Filtro;
        Pag_Net.Models.modelSistemaUsuario MyConnect;



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbList_Despesas;
        public DBDataTable dbList_Despesas { 
                get { return __dbList_Despesas; } 
                set { __dbList_Despesas = value; 
                        RaisePropertyChanged("dbList_Despesas"); } }

        private DBDataTable __dbList_DespesasPorConta;
        public DBDataTable dbList_DespesasPorConta
        {
            get { return __dbList_DespesasPorConta; }
            set
            {
                __dbList_DespesasPorConta = value;
                RaisePropertyChanged("dbList_DespesasPorConta");
            }
        }
     

        public _indexReport(Pag_Net.Models.modelSistemaUsuario _MyConnect) { _constructor(_MyConnect); }


        private void _constructor(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            filtroClear();
        

        }
       
        public void filtroClear()
        {
            Filtro = new interfaces.Filter();
        }
        public void getDespesas()
        {
            try
            {
                dbList_Despesas = BDCommand.DBDataTableGet(MyConnect, Sql.DespesasGet(this.Filtro));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void getDespesasPorConta()
        {
            try
            {
                dbList_DespesasPorConta = BDCommand.DBDataTableGet(MyConnect, Sql.DespesasPorContaGet(this.Filtro));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public tbs.tbresultado_conta[] getContas(int r_grupo_origem_blue)
        {
            try
            {
                List<tbs.tbresultado_conta> list = new List<tbs.tbresultado_conta>();


                DBDataTable dblist = BDCommand.DBDataTableGet(MyConnect, Sql.ResultaContaListGet(r_grupo_origem_blue));
                foreach (DataRow item in dblist.List.Rows)
                {
                    tbs.tbresultado_conta i = new tbs.tbresultado_conta();
                    i.binding(item);
                    list.Add(i);
                }
                return list.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public static class Sql
    {
        public static string DespesasGet(Pag_Net.src.F0100_Resultado.interfaces.Filter filtro)
        {
            string sql = "	select 	    	pg.plc_conta_cd                 " +
                         "              ,	pl.plc_descricao	            " +
                         "              , 	pg.contrato_bluesoft_seq	    " +
                         "              ,	pg.autpgto_cdpessoabluesoft     " +
                         "              ,   p.cdparticipante                " + 
                         "              ,	ps.nome_razao                   " +
                         "              ,	pg.autpgto_dataemissao          " +
                         "              ,	pg.autpgto_datavencimento       " +
                         "              ,	d.descritivo                    " +
                         "              ,	pg.autpgto_seq_pk               " +
                         "              ,	pg.autpgto_valorfatura          " +
                         "              ,	pg.autpgto_valortotal           " +
                         "              ,	pg.autpgto_valorpago            " +
                         "              ,	pg.autpgto_datapagamento        " +
                         "              ,	pg.autpgto_valorliquido         " +
                         "              ,   coalesce(c.r_conta_cd,0)  as r_conta_cd      " +
                         "              ,	coalesce(c.r_conta_descricao,'NÃO DEFINIDA') as r_conta_descricao " +
                         "  from 		tbautorizacaopagamento              pg   " +
                         "  inner join  tbautorizacaopagamento_descritivo   d   on d.autpgto_seq_fk = pg.autpgto_seq_pk " +
                         "  left  join  tbplanocontacontabil                pl  on pl.plc_conta_cd = pg.plc_conta_cd " +
                         "  left join   tbpessoabluesoft                    ps on ps.cdpessoabluesoft = pg.autpgto_cdpessoabluesoft " +
                         "  left join   tbparticipante_bluesoft             p on p.cdpessoabluesoft = ps.cdpessoabluesoft " + 
                         "  left join   tbresultado_conta_origem            x on coalesce(x.plc_conta_cd,0) = pg.plc_conta_cd " + 
                                                                   " AND coalesce(pg.contrato_bluesoft_seq,0) = COALESCE(x.contrato_bluesoft_seq,0) " + 
                                                                   " AND coalesce(p.cdparticipante,0) = x.cdparticipante " + 
                                                                   " and coalesce(x.plc_conta_cd,0) > 0 " +
                         "  left join   tbresultado_conta c on c.r_conta_cd = x.r_conta_cd " +
                         "  where   1 = 1 ";


                        if (filtro.plc_conta_cd > 0)
                        {
                            sql += "  AND pg.plc_conta_cd = " + filtro.plc_conta_cd.ToString();
                        }

                        if (filtro.contrato_bluesoft_seq > 0)
                        {
                            sql += "  AND pg.contrato_bluesoft_seq = " + filtro.contrato_bluesoft_seq.ToString();
                        }
                         
                         
                         if (filtro.competencia_cd > 0)
                         {
                             sql += "  AND competencia_cd = " + filtro.competencia_cd.ToString();
                         }

                         if (filtro.bluesoft_competencia_cd > 0)
                         {
                             sql += "  AND bluesoft_competencia_cd = " + filtro.bluesoft_competencia_cd.ToString();
                         }

                         if (filtro.dataemissao_filter)
                         {
                             sql += " AND autpgto_dataemissao >= '" + filtro.dataemissao_filter_data_ini.ToString("YYYY-MM-DD") + "'";
                             sql += " AND autpgto_dataemissao <= '" + filtro.dataemissao_filter_data_fim.ToString("YYYY-MM-DD") + "'";
                         }

                         if (filtro.datavencimento_filter)
                         {
                             sql += " AND autpgto_datavencimento >= '" + filtro.datavencimento_filter_data_ini.ToString("YYYY-MM-DD") + "'";
                             sql += " AND autpgto_datavencimento <= '" + filtro.datavencimento_filter_data_fim.ToString("YYYY-MM-DD") + "'";
                         }

                         if (filtro.plc_descricao.Trim() != "")
                             sql += " AND UPPER(pl.plc_descricao) like '%" + filtro.plc_descricao.ToString().Replace("'", "").ToUpper() + "%'";

                         if (filtro.nome_razao.Trim() != "")
                             sql += " AND UPPER(ps.nome_razao)  like '%" + filtro.nome_razao.ToString().Replace("'", "").ToUpper() + "%'";

                         if (filtro.SemContaVinculada)
                         {
                             sql += " AND coalesce(c.r_conta_cd,0) = 0 ";
                         }


                         sql += 
                         "  and  pg.plc_conta_cd <> 2110 " +
                         "  and  pg.autpgto_tipo = 'P' " +
                         "  AND  pg.autpgto_cancelada = 0 " +
                         "  and  em_cdempresa = 1 " +
                         "  order by descritivo asc ";
            return sql;
        }
        public static string DespesasPorContaGet(Pag_Net.src.F0100_Resultado.interfaces.Filter filtro)
        {
            string sql = "	select 	    	pg.plc_conta_cd                 " +
                         "              ,	pl.plc_descricao	            " +
                         "              ,   coalesce(pg.contrato_bluesoft_seq,0) as contrato_bluesoft_seq           " + 
                         "              ,	SUM(pg.autpgto_valorfatura)   AS autpgto_valorfatura         " +
                         "              ,	SUM(pg.autpgto_valortotal)    AS autpgto_valortotal          " +
                         "              ,	SUM(pg.autpgto_valorpago)     AS autpgto_valorpago           " +
                         "              ,	SUM(pg.autpgto_valorliquido)  AS autpgto_valorliquido        " +
                         "  from 		tbautorizacaopagamento              pg   " +
                         "  left  join  tbplanocontacontabil                pl  on pl.plc_conta_cd = pg.plc_conta_cd " +
                         "  left join   tbpessoabluesoft ps on ps.cdpessoabluesoft = pg.autpgto_cdpessoabluesoft " +
                         "  left join   tbparticipante_bluesoft p on p.cdpessoabluesoft = ps.cdpessoabluesoft " + 
                         "  where   1 = 1 ";


            if (filtro.plc_conta_cd > 0)
            {
                sql += "  AND pg.plc_conta_cd not in (select xx.plc_conta_cd from tbresultado_conta_origem xx where coalesce(xx.plc_conta_cd,0) <> 0 ) ";
            }

            if (filtro.contrato_bluesoft_seq > 0)
            {
                sql += "  AND pg.contrato_bluesoft_seq = " + filtro.contrato_bluesoft_seq.ToString();
            }

            if (filtro.competencia_cd > 0)
            {
                sql += "  AND competencia_cd = " + filtro.competencia_cd.ToString();
            }

            if (filtro.bluesoft_competencia_cd > 0)
            {
                sql += "  AND bluesoft_competencia_cd = " + filtro.bluesoft_competencia_cd.ToString();
            }

            if (filtro.dataemissao_filter)
            {
                sql += " AND autpgto_dataemissao >= '" + filtro.dataemissao_filter_data_ini.ToString("YYYY-MM-DD") + "'";
                sql += " AND autpgto_dataemissao <= '" + filtro.dataemissao_filter_data_fim.ToString("YYYY-MM-DD") + "'";
            }

            if (filtro.datavencimento_filter)
            {
                sql += " AND autpgto_datavencimento >= '" + filtro.datavencimento_filter_data_ini.ToString("YYYY-MM-DD") + "'";
                sql += " AND autpgto_datavencimento <= '" + filtro.datavencimento_filter_data_fim.ToString("YYYY-MM-DD") + "'";
            }

            if (filtro.plc_descricao.Trim() != "")
                sql += " AND UPPER(pl.plc_descricao) like '%" + filtro.plc_descricao.ToString().Replace("'", "").ToUpper() + "%'";

            if (filtro.nome_razao.Trim() != "")
                sql += " AND UPPER(ps.nome_razao)  like '%" + filtro.nome_razao.ToString().Replace("'", "").ToUpper() + "%'";

            if (filtro.SemContaVinculada)
            {
                sql += " AND NOT EXISTS (SELECT 1  " + 
                                        " FROM  tbresultado_conta_origem XX " + 
                                        " WHERE 1 = 1 " + 
                                        " AND XX.plc_conta_cd = pg.plc_conta_cd " + 
                                        " AND XX.cdparticipante = p.cdparticipante " + 
                                        " AND coalesce(XX.contrato_bluesoft_seq,0)  =  coalesce(pg.contrato_bluesoft_seq,0) " + 
                                        ")" ;
            }

            sql +=
            "  and  pg.plc_conta_cd <> 2110 " +
            "  and  pg.autpgto_tipo = 'P' " +
            "  AND  pg.autpgto_cancelada = 0 " +
            "  and  em_cdempresa = 1 " +
            "  GROUP BY    pg.plc_conta_cd                 " +
            "            ,	pl.plc_descricao, coalesce(pg.contrato_bluesoft_seq,0)	            " +
            "  order by 2 asc ";
            return sql;
        }
        public static string ResultaContaListGet(int r_grupo_origem_blue)
        {
            string sql = "	 Select 		c.r_grupo_cd                  " +
                         "              ,	r_conta_cd                  " +
                         "              ,	r_conta_descricao           " +
                         "              ,	r_conta_lancamento_manual   " +
                         "              ,	debitocredito               " +
                         "              ,   g.r_grupo_descricao " + 
                         "              ,	coalesce(r_rateio_cd,0) as r_rateio_cd " +
                         "              ,   coalesce(g.r_grupo_origem_blue,0)  as r_grupo_origem_blue " +
                         "   from 		 tbresultado_conta c " +
                         "   inner join  tbresultado_grupo g on g.r_grupo_cd = c.r_grupo_cd " + 
                         "   where      1 = 1 ";
            if (r_grupo_origem_blue > 0) 
            {
                sql += " AND coalesce(r_grupo_origem_blue,0) > 0 ";
            }

            sql += " order by   g.r_grupo_descricao, r_conta_descricao asc ";
            return sql;
        }
    }


    public static class DBDataTables
    {

      

    }

    public static class ArrayTabs
    {


    }
}
