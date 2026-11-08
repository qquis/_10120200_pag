using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0130_Controle
{

    public static class F0130_60_Controle_Reg_List
    {
        public static string _VERSION() { return "f0130_60_1011950_controle_reg_list"; }
        public static string Get(
               int       controle_cd 				
            ,  int       controle_fila_cd 			
            ,  int       controle_reg_seq 			
            ,  int       controle_reg_fila_seq 		
            ,  DateTime  controle_reg_data_inicial 	
            ,  DateTime  controle_reg_data_final   	
            ,  string    controle_etapa_cd_list 	
            ,  int       controle_status_cd 

            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +

                    string.Format("({0}, {1}, {2}, {3}, '{4}', '{5}', '{6}', {7})",
                    controle_cd.ToString(), 
                    controle_fila_cd.ToString(),			
                    controle_reg_seq.ToString(),  			
                    controle_reg_fila_seq.ToString(), 		
                    controle_reg_data_inicial.ToString("yyyy-MM-dd"), 	
                    controle_reg_data_final.ToString("yyyy-MM-dd"),
                    controle_etapa_cd_list.ToString(), 
                    controle_status_cd.ToString()
                    ));
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}


