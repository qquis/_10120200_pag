using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.f0005_forca_venda_meta.dataStore
{
    public static class ArrayTabs
    {
        public static tbs.tbforca_venda_meta_tipo[] ForcaVendaMetaTipoList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, bool opcaoTodos)
        {
            try
            {
                List<tbs.tbforca_venda_meta_tipo> myList = new List<tbs.tbforca_venda_meta_tipo>(); 
                string SQL = "Select fv_meta_tipo_cd, fv_meta_tipo_descricao, fv_meta_regra_base_proporcional from Tbforca_venda_meta_tipo order by fv_meta_tipo_descricao ";

                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));

                if (opcaoTodos)
                {
                    tbs.tbforca_venda_meta_tipo itemTodos = new tbs.tbforca_venda_meta_tipo(); 
                    itemTodos.fv_meta_tipo_cd = 0; 
                    itemTodos.fv_meta_tipo_descricao = "";

                    myList.Add(itemTodos);
                }

                foreach (DataRow i in myDataTable.List.Rows)
                {
                    tbs.tbforca_venda_meta_tipo item  = new tbs.tbforca_venda_meta_tipo(); 
                    item.__Binding(i);
                    myList.Add(item);
                }
                return myList.ToArray(); 

            }
            catch (Exception ex)
            {
                throw new Exception("Dts.tbforca_venda_meta_tipo Error \n " + ex.Message);
            }
        }
        public static tbs.tbforca_venda_meta_composicao_tipo[] ForcaVendaMetaComposicaoTipo(Pag_Net.Models.modelSistemaUsuario MyConnect, bool opcaoTodos)
        {
            try
            {
                List<tbs.tbforca_venda_meta_composicao_tipo> myList = new List<tbs.tbforca_venda_meta_composicao_tipo>();
                if (opcaoTodos)
                {
                    tbs.tbforca_venda_meta_composicao_tipo itemTodos = new tbs.tbforca_venda_meta_composicao_tipo();
                    itemTodos.fv_meta_composicao_tipo_cd = 0; 
                    itemTodos.fv_meta_composicao_tipo_descricao = "*TODAS AS COMPOSIÇÕES*";

                    myList.Add(itemTodos);
                }
                foreach(DataRow i in dataStore.DBDataTables.ForcaVendaMetaComposicaoTipo(MyConnect).List.Rows)
                {
                    tbs.tbforca_venda_meta_composicao_tipo item = new tbs.tbforca_venda_meta_composicao_tipo();
                    item.__Binding(i);
                    myList.Add(item);
                }
                return myList.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public static class DBDataTables
    {
        public static DBDataTable ForcaVendaMetaGet(Pag_Net.Models.modelSistemaUsuario MyConnect, int fv_meta_tipo_cd, int competenciacd) {
            try {
                string SQL = "Select      m.fv_meta_cd           as fv_meta_cd " +
                             "        ,   m.fv_meta_tipo_cd       " +
                             "        ,   t.fv_meta_tipo_descricao " + 
                             "        ,   m.fv_meta_descricao    as fv_meta_descricao   " +
                             "        ,   m.fv_meta_data_ini      " +
                             "        ,   m.fv_meta_data_fim      " +
                             "        ,   coalesce(m.fv_meta_bonus_percentual,0) as fv_meta_bonus_percentual " +
                             "        ,   coalesce(m.fv_meta_bonus_percentual_proporcional,0) as fv_meta_bonus_percentual_proporcional " +
                             "        ,   coalesce(m.fv_meta_bonus_valor,0) as fv_meta_bonus_valor " +
                             "        ,   competencia_cd " +
                             "        ,   m.dtlog_insert " +
                             "        ,   coalesce(m.dtlog_update, m.dtlog_insert) as dtlog_update " +
                             " FROM       tbforca_venda_meta m " +
                             " INNER JOIN tbforca_venda_meta_tipo t on t.fv_meta_tipo_cd = m.fv_meta_tipo_cd " +
                             " WHERE 1 = 1 "; 
                if (fv_meta_tipo_cd != 0) {
                    SQL = SQL + " AND m.fv_meta_tipo_cd = " + fv_meta_tipo_cd.ToString(); 
                }

                if (competenciacd != 0)
                {
                    SQL = SQL + " AND m.competencia_cd = " + competenciacd.ToString();
                }

                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable; 

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public static DBDataTable ForcaVendaMetaVendedorGet(Pag_Net.Models.modelSistemaUsuario MyConnect, int fv_meta_cd, int fv_meta_cdparticipantevendedor)
        {
            try
            {
                string SQL = "Select      m.fv_meta_cd            " +
                             "        ,   mv.fv_meta_cdparticipantevendedor " +
                             "        ,   p.nome_razao " + 
                             "        ,   coalesce(mv.fv_meta_rq_pos_minimo,0) as fv_meta_rq_pos_minimo" + 
                             "        ,   coalesce(mv.fv_meta_rq_pos_maximo,0) as fv_meta_rq_pos_maximo " + 
                             "        ,   coalesce(mv.fv_meta_rq_pos,0) as fv_meta_rq_pos   " + 
                             "        ,   coalesce(mv.fv_meta_rq_qtde,0) as fv_meta_rq_qtde " + 
                             "        ,   coalesce(mv.fv_meta_rq_valor,0) as fv_meta_rq_valor " + 
                             "        ,   coalesce(mv.fv_meta_rz_pos,0) as fv_meta_rz_pos  " + 
                             "        ,   coalesce(mv.fv_meta_rz_qtde,0) as fv_meta_rz_qtde  " + 
                             "        ,   coalesce(mv.fv_meta_rz_valor,0) as fv_meta_rz_valor  " + 
                             "        ,   coalesce(mv.fv_meta_base_pos,0) as fv_meta_base_pos " + 
                             "        ,   coalesce(mv.fv_meta_base_qtde,0) as fv_meta_base_qtde  " + 
                             "        ,   coalesce(mv.fv_meta_base_valor,0) as fv_meta_base_valor  " +
                             "        ,   coalesce(mv.fv_meta_bonus_percentual,0) as fv_meta_bonus_percentual  " +
                             "        ,   coalesce(mv.fv_meta_bonus_valor,0) as fv_meta_bonus_valor " +
                             "        ,   coalesce(mv.fv_meta_resultado_valor,0) as fv_meta_resultado_valor " +  
                             "        ,   mv.dtlog_insert as dtlog_insert " + 
                             "        ,   coalesce(m.dtlog_update, m.dtlog_insert) as dtlog_update " +
                             " FROM       tbforca_venda_meta_vendedor mv " +
                             " INNER JOIN tbparticipante p on p.cdparticipante = mv.fv_meta_cdparticipantevendedor " + 
                             " INNER JOIN tbforca_venda_meta m ON m.fv_meta_cd = mv.fv_meta_cd " +
                             " INNER JOIN tbforca_venda_meta_tipo t on t.fv_meta_tipo_cd = m.fv_meta_tipo_cd " +
                             " WHERE 1 = 1 ";
                if (fv_meta_cd != 0)
                {
                    SQL = SQL + " AND m.fv_meta_cd = " + fv_meta_cd.ToString();
                }


                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DBDataTable ForcaVendaMetaRequisito(Pag_Net.Models.modelSistemaUsuario MyConnect, int fv_meta_cd, int fv_meta_cdparticipantevendedor)
        {
            try
            {
                string SQL = "Select      r.fv_meta_r_seq " + 
                             "          , r.fv_meta_cd " + 
                             "          , r.cdparticipantevendedor " + 
                             "          , v.nome_razao as LABEL_nome_vendedor " + 
                             "          , r.cdpessoabluesoft_fabricante " + 
                             "          , F.nome_razao as LABEL_nome_fabricante " + 
                             "          , r.cdgrupoeconomico " + 
                             "          , g.descricao as LABEL_descricao_grupo_economico " + 
                             "          , r.cdparticipantecliente " + 
                             "          , c.nome_razao as LABEL_nome_razao_cliente " + 
                             "          , r.pr_cdproduto " + 
                             "          , PR.pr_descricao as LABEL_pr_descricao " + 
                             " FROM       tbforca_venda_meta_requisito r " + 
                             " INNER JOIN tbforca_venda_meta m ON m.fv_meta_cd = r.fv_meta_cd  " + 
                             " LEFT JOIN  tbparticipante V on v.cdparticipante = r.cdparticipantevendedor" + 
                             " LEFT JOIN  tbpessoabluesoft F on F.cdpessoabluesoft = r.cdpessoabluesoft_fabricante " + 
                             " LEFT JOIN  tbgrupoeconomico G ON G.cdgrupoeconomico = r.cdgrupoeconomico " + 
                             " LEFT JOIN  tbparticipante C on C.cdparticipante = r.cdparticipantecliente " + 
                             " LEFT JOIN  tbproduto PR on PR.pr_cdproduto = r.pr_cdproduto " + 
                             " INNER JOIN tbforca_venda_meta_tipo t on t.fv_meta_tipo_cd = m.fv_meta_tipo_cd " +
                             " WHERE 1 = 1 ";
                if (fv_meta_cd != 0)
                {
                    SQL = SQL + " AND m.fv_meta_cd = " + fv_meta_cd.ToString();
                }

                if (fv_meta_cdparticipantevendedor != 0 )
                {
                    SQL = SQL + " AND r.cdparticipantevendedor  = " + fv_meta_cdparticipantevendedor.ToString(); 
                }
             
                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DBDataTable ForcaVendaMetaExclusao(Pag_Net.Models.modelSistemaUsuario MyConnect, int fv_meta_cd, int fv_meta_cdparticipantevendedor)
        {
            try
            {
                string SQL = "Select      r.fv_meta_ex_seq " +
                             "          , r.fv_meta_cd " +
                             "          , r.cdparticipantevendedor " +
                             "          , v.nome_razao as LABEL_nome_vendedor " +
                             "          , r.cdpessoabluesoft_fabricante " +
                             "          , F.nome_razao as LABEL_nome_fabricante " +
                             "          , r.cdgrupoeconomico " +
                             "          , g.descricao as LABEL_descricao_grupo_economico " +
                             "          , r.cdparticipantecliente " +
                             "          , c.nome_razao as LABEL_nome_razao_cliente " +
                             "          , r.pr_cdproduto " +
                             "          , PR.pr_descricao as LABEL_pr_descricao " +
                             " FROM       tbforca_venda_meta_exclusao r " +
                             " INNER JOIN tbforca_venda_meta m ON m.fv_meta_cd = r.fv_meta_cd  " +
                             " LEFT JOIN  tbparticipante V on v.cdparticipante = r.cdparticipantevendedor" +
                             " LEFT JOIN  tbpessoabluesoft F on F.cdpessoabluesoft = r.cdpessoabluesoft_fabricante " +
                             " LEFT JOIN  tbgrupoeconomico G ON G.cdgrupoeconomico = r.cdgrupoeconomico " +
                             " LEFT JOIN  tbparticipante C on C.cdparticipante = r.cdparticipantecliente " +
                             " LEFT JOIN  tbproduto PR on PR.pr_cdproduto = r.pr_cdproduto " +
                             " INNER JOIN tbforca_venda_meta_tipo t on t.fv_meta_tipo_cd = m.fv_meta_tipo_cd " +
                             " WHERE 1 = 1 ";
                if (fv_meta_cd != 0)
                {
                    SQL = SQL + " AND m.fv_meta_cd = " + fv_meta_cd.ToString();
                }

                if (fv_meta_cdparticipantevendedor != 0)
                {
                    SQL = SQL + " AND r.cdparticipantevendedor  = " + fv_meta_cdparticipantevendedor.ToString();
                }

                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DBDataTable ForcaVendaMetaBase(Pag_Net.Models.modelSistemaUsuario MyConnect, int fv_meta_cd, int fv_meta_cdparticipantevendedor)
        {
            try
            {
                string SQL = "Select      r.fv_meta_b_seq " +
                             "          , r.fv_meta_cd " +
                             "          , r.cdparticipantevendedor " +
                             "          , v.nome_razao as LABEL_nome_vendedor " +
                             "          , r.cdpessoabluesoft_fabricante " +
                             "          , F.nome_razao as LABEL_nome_fabricante " +
                             "          , r.cdgrupoeconomico " +
                             "          , g.descricao as LABEL_descricao_grupo_economico " +
                             "          , r.cdparticipantecliente " +
                             "          , c.nome_razao as LABEL_nome_razao_cliente " +
                             "          , r.pr_cdproduto " +
                             "          , PR.pr_descricao as LABEL_pr_descricao " +
                             " FROM       tbforca_venda_meta_base r " +
                             " INNER JOIN tbforca_venda_meta m ON m.fv_meta_cd = r.fv_meta_cd  " +
                             " LEFT JOIN  tbparticipante V on v.cdparticipante = r.cdparticipantevendedor" +
                             " LEFT JOIN  tbpessoabluesoft F on F.cdpessoabluesoft = r.cdpessoabluesoft_fabricante " +
                             " LEFT JOIN  tbgrupoeconomico G ON G.cdgrupoeconomico = r.cdgrupoeconomico " +
                             " LEFT JOIN  tbparticipante C on C.cdparticipante = r.cdparticipantecliente " +
                             " LEFT JOIN  tbproduto PR on PR.pr_cdproduto = r.pr_cdproduto " +
                             " INNER JOIN tbforca_venda_meta_tipo t on t.fv_meta_tipo_cd = m.fv_meta_tipo_cd " +
                             " WHERE 1 = 1 ";
                if (fv_meta_cd != 0)
                {
                    SQL = SQL + " AND m.fv_meta_cd = " + fv_meta_cd.ToString();
                }

                if (fv_meta_cdparticipantevendedor != 0)
                {
                    SQL = SQL + " AND r.cdparticipantevendedor  = " + fv_meta_cdparticipantevendedor.ToString();
                }

                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DBDataTable ForcaVendaMetaComposicaoTipo(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                string SQL = "Select fv_meta_composicao_tipo_cd, fv_meta_composicao_tipo_descricao from tbforca_venda_meta_composicao_tipo order by fv_meta_composicao_tipo_descricao asc ";
                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));

                return myDataTable; 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DBDataTable ForcaVendaMetaComposicao(Pag_Net.Models.modelSistemaUsuario MyConnect, int fv_meta_composicao_tipo_cd,  int fv_meta_cd, int fv_meta_cdparticipantevendedor)
        {
            try
            {
                string SQL = "Select      r.fv_meta_composicao_seq " +
                             "          , r.fv_meta_cd " +
                             "          , r.fv_meta_composicao_tipo_cd " +
                             "          , CT.fv_meta_composicao_tipo_descricao " +
                             "          , r.cdparticipantevendedor " +
                             "          , coalesce(v.nome_razao, 'TODOS OS VENDEDORES') as LABEL_nome_vendedor " +
                             "          , r.cdpessoabluesoftfabricante " +
                             "          , F.nome_razao as LABEL_nome_fabricante " +
                             "          , r.cdgrupoeconomico " +
                             "          , g.descricao as LABEL_descricao_grupo_economico " +
                             "          , r.cdparticipantecliente " +
                             "          , c.nome_razao as LABEL_nome_razao_cliente " +
                             "          , r.pr_cdproduto " +
                             "          , PR.pr_descricao as LABEL_pr_descricao " +
                             " FROM       tbforca_venda_meta_composicao r " +
                             " INNER JOIN tbforca_venda_meta_composicao_tipo CT ON CT.fv_meta_composicao_tipo_cd = r.fv_meta_composicao_tipo_cd" + 
                             " INNER JOIN tbforca_venda_meta m ON m.fv_meta_cd = r.fv_meta_cd  " +
                             " LEFT JOIN  tbparticipante V on v.cdparticipante = r.cdparticipantevendedor" +
                             " LEFT JOIN  tbpessoabluesoft F on F.cdpessoabluesoft = r.cdpessoabluesoftfabricante " +
                             " LEFT JOIN  tbgrupoeconomico G ON G.cdgrupoeconomico = r.cdgrupoeconomico " +
                             " LEFT JOIN  tbparticipante C on C.cdparticipante = r.cdparticipantecliente " +
                             " LEFT JOIN  tbproduto PR on PR.pr_cdproduto = r.pr_cdproduto " +
                             " INNER JOIN tbforca_venda_meta_tipo t on t.fv_meta_tipo_cd = m.fv_meta_tipo_cd " + 
                             " WHERE 1 = 1 ";
                if (fv_meta_composicao_tipo_cd != 0 ) {
                    SQL = SQL + " AND r.fv_meta_composicao_tipo_cd = " + fv_meta_composicao_tipo_cd.ToString(); 
                }
                if (fv_meta_cd != 0)
                {
                    SQL = SQL + " AND m.fv_meta_cd = " + fv_meta_cd.ToString();
                }

                if (fv_meta_cdparticipantevendedor != 0)
                {
                    SQL = SQL + " AND r.cdparticipantevendedor  = " + fv_meta_cdparticipantevendedor.ToString();
                }

                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL));
                return myDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
