using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.src.F0080_Financeiro;
using Pag_Net.Bll;

namespace Pag_Net.src.F0080_Financeiro.pools
{
    public static class ArrayTabs
    {
        public static model.model_ComposicaoFinanceira_Tipo[] ComposicaoFinanceiraTipos() 
        {
            try
            {
                List<model.model_ComposicaoFinanceira_Tipo> mylist = new List<model.model_ComposicaoFinanceira_Tipo>(); 
                mylist.Add(new model.model_ComposicaoFinanceira_Tipo(0, "Por título")); 
                mylist.Add(new model.model_ComposicaoFinanceira_Tipo(1, "Por Conta Contábil"));
                mylist.Add(new model.model_ComposicaoFinanceira_Tipo(2, "Por Participante"));
                return mylist.ToArray();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        
        }
   
    

    

    }

    public static class DBDataTables
    {
        public static DBDataTable ConsultaPosicaoFinanceira(Pag_Net.Models.TbSysUserInfo MyConnect, interfaces.iFiltroConsultaAutorizacao filtro)
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + Pag_Net.src.F0080_Financeiro.scripts.f0080_50_financeiro_consulta_list._VERSION() +
                            string.Format("({0}, {1}, '{2}', {3}, {4}, {5}, {6}, '{7}', '{8}', {9}, '{10}', '{11}', {12}, '{13}', '{14}', {15}, {16} )",
                            filtro.TipoConsulta_Cd.ToString(), 
                            filtro.competencia.ToString(),
                            filtro.autpgto_tipo.ToString(),
                            filtro.autpgto_seq_pk.ToString(),
                            filtro.plc_conta_cd.ToString(),
                            filtro.plc_conta_cd_destino.ToString(),
                            filtro.filtra_dataemissao? "1": "0" ,
                            filtro.autpgto_dataemissao_ini.ToString("yyyy-MM-dd"),
                            filtro.autpgto_dataemissao_fim.ToString("yyyy-MM-dd"),
                            filtro.filtra_datavencimento? "1": "0",
                            filtro.autpgto_datavencimento_ini.ToString("yyyy-MM-dd"),
                            filtro.autpgto_datavencimento_fim.ToString("yyyy-MM-dd"),
                            filtro.filtra_datapagamento? "1": "0",
                            filtro.autpgto_datapagamento_ini.ToString("yyyy-MM-dd"),
                            filtro.autpgto_datapagamento_fim.ToString("yyyy-MM-dd"),
                            filtro.cdpessoabluesoft.ToString(),
                            filtro.autpgto_cancelada.ToString()
                    ));
                DBDataTable myDataTable = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL_POSTGRE));
                return myDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
    }

}
