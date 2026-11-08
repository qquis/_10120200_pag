using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0133_Comercial_PedidoBlueSoft.F0133_10_Comercial_PedidoBlusoft_List
{
    public static class RedShift
    {
        public static string get()
        {
            return "";
        }
    }

    public static class Postgre
    {
        public static string VERSION() { return "f0133_10_1011915_comercial_pedidoblusoft_list"; }
        public static string Get(
            Pag_Net.Models.modelSistemaUsuario MyConnect ,
            Filter _filter
             
            )
        {
            try
            {
                string _PostGre = string.Format("SELECT * FROM " + VERSION() + "( {0}, '{1}', '{2}', '{3}') ",
                        _filter.cm_pedblue_cdpessoabluesoft_fornecedor , 
                        _filter.cm_pedblue_dataemissao_inicial.ToString("yyyy-MM-dd"),
                        _filter.cm_pedblue_dataemissao_final.ToString("yyyy-MM-dd"), 
                        _filter.cnpj_cnpj.ToString()
                    );
                return _PostGre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
