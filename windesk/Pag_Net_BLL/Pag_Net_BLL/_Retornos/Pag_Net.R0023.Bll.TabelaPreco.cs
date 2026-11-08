using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.R0023.Bll
{


    public static class Select
    {

        public static DataTable get_DataTable( Pag_Net.Models.modelSistemaUsuario MyConnect )
        {
            try
            {
                string SQL_POSTGRE = string.Format("SELECT * FROM r0023_0001_tabela_preco()");

                DataSet DT = new DataSet();
                DT = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DT.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }


}

namespace Pag_Net.R0023.Models
{
    public class r0023_tabelaprecos
    {
        public int tab_pre_cd { get; set; }
        public string tab_pre_descricao { get; set; }

        public r0023_tabelaprecos() { }

        public r0023_tabelaprecos(
                  int _tab_pre_cd                
                , string _tab_pre_descricao            
            )
        {

            tab_pre_cd = _tab_pre_cd;
            tab_pre_descricao = _tab_pre_descricao;

        }

        public r0023_tabelaprecos(DataRow i) 
        {
            tab_pre_cd = Convert.ToInt32(i["tab_pre_cd"]);
            tab_pre_descricao = i["tab_pre_descricao"].ToString();
        }

    }

}
