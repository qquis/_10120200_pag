using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Cadastros_Gerais 
{
    public class Poll
    {

        public static DataTable Get_DataTable_Fabricantes_Distribuicao(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            return Get_DataTable_Fabricantes_Distribuicao(MyConnect, 0);
        }


        public static DataTable Get_DataTable_Fabricantes_Distribuicao(Pag_Net.Models.modelSistemaUsuario MyConnect, int fv_fabricante_cdpessoabluesoft)
        {
            try
            {
                string _sql = "";
                string _sql_user_filtro = string.Format("select a.cdpessoabluesoft " +
                                                        " from tbpessoabluesoft_user a " + 
                                                        " inner join tbsistema_usuario u on u.cdpessoabluesoft = a.cdpessoabluesoft_user " + 
                                                        " WHERE u.sis_us_seq = {0}", MyConnect.sis_us_seq ) ; 

                DataTable DT = Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, _sql_user_filtro);

                if (DT.Rows.Count < 1 )
                {

                    _sql = "     select 	 	   x.fv_fabricante_seq " +
                                "             ,    x.fv_fabricante_descricao " +
                                "             ,    x.fv_fabricante_referencia " +
                                "             ,    x.fv_fabricante_cdpessoabluesoft " +
                                "             ,    coalesce(x.fv_fabricante_divisao_cd,0) as  fv_fabricante_divisao_cd" + 
                                "     from tbforca_venda_fabricante x" +
                                "     where 1 = 1 " +
                                Convert.ToString( fv_fabricante_cdpessoabluesoft > 0? " and fv_fabricante_cdpessoabluesoft = " + fv_fabricante_cdpessoabluesoft.ToString(): "") +


                                "     order by fv_fabricante_descricao ASC ";

                }
                else
                {
                    _sql = string.Format( "     select 	 	   x.fv_fabricante_seq " +
                      "             ,    x.fv_fabricante_descricao " +
                      "             ,    x.fv_fabricante_referencia " +
                      "             ,    x.fv_fabricante_cdpessoabluesoft " +
                      "             ,    x.fv_fabricante_divisao_cd " + 
                      "     from tbforca_venda_fabricante x" +
                      "     where 1 = 1 " +
                      Convert.ToString(fv_fabricante_cdpessoabluesoft > 0 ? " and fv_fabricante_cdpessoabluesoft = " + fv_fabricante_cdpessoabluesoft.ToString() : "") +
                      "       AND  x.fv_fabricante_cdpessoabluesoft IN ( SELECT a.cdpessoabluesoft " +
                                                                         " from tbpessoabluesoft_user a " + 
                                                        " inner join tbsistema_usuario u on u.cdpessoabluesoft = a.cdpessoabluesoft_user " + 
                                                        " WHERE u.sis_us_seq = {0} )" + 
                      "     order by fv_fabricante_descricao ASC ", MyConnect.sis_us_seq.ToString());
                }





                DataTable Resultado =  Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, _sql);

                return Resultado;
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


    public class Forca_Venda_Fabricantes
    {



    }


}
