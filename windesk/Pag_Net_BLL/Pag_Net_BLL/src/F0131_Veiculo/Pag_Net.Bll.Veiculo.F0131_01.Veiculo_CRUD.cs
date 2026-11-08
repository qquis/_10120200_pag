using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Pag_Net.Bll.F0131_Veiculo
{

    public static class f0131_01_veiculo_modelo_CRUD
    {                                              
        private static string _VERSION() { return "f0131_01_1011915_veiculo_grud"; }
        public static string Get(
            Pag_Net.Bll.F0131_Veiculo.TbVeiculo _Veiculo
            
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + string.Format("('DBINSERT', 0, '{0}', {1}, '', 0 )",
                            _Veiculo.veiculo_placa.ToString().ToUpper(), 
                            _Veiculo.veiculo_modelo_cd.ToString()
                        
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


