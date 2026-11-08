using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public static class Dts
    {
        public static DBDataTable F0130_60_Controle_Reg_List_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter Filtro)
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + F0130_60_Controle_Reg_List._VERSION() +
                    " (  vcontrole_cd:= " + Filtro.controle_cd.ToString() + 
	                " ,  vcontrole_fila_cd:= " + Filtro.controle_fila_cd.ToString() + 
	                " ,  vcontrole_reg_seq:= " + Filtro.controle_reg_seq.ToString() + 
	                " ,  vcontrole_reg_fila_seq:= " + Filtro.controle_reg_fila_seq.ToString() + 
	                " ,  vcontrole_reg_data_inicial:= '" + Filtro.controle_reg_data_inicial.ToString("yyyy-MM-dd") + "'" + 
	                " ,  vcontrole_reg_data_final:= '" + Filtro.controle_reg_data_final.ToString("yyyy-MM-dd") + "'" + 
	                " ,  vcontrole_etapa_cd_list:= '" + Filtro.controle_etapa_cd_list.ToString() + "'" + 
	                " ,  vcontrole_status_cd:= " + Filtro.controle_status_cd.ToString() + 
                    ")");
                return new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL_POSTGRE));
            }
            catch (Exception ex)
            {
                throw new Exception("\n" + "ControleRegList_Get: " + ex.Message + "\n");
            }
        }
    }

}

