using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0132_02
{
    public static class RedShift
    {

    }

    public static class Postgre
    {
        public static string Post
            (
                Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido comercial_pre_pedido
            )
        {


            string _sql_post = string.Format("SELECT * FROM " +
                                             Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0132_02_comercial_pre_pedido_crud_result) +
                        string.Format(" ('DBINSERT', {0}, {1}, {2}, '{3}', {4}, {5}, {6})",
                        comercial_pre_pedido.proc_log_seq,
                        comercial_pre_pedido.cm_pre_ped_seq.ToString(),
                        comercial_pre_pedido.cm_pre_ped_cd.ToString(),
                        comercial_pre_pedido.cm_pre_ped_data.ToString("yyyy-MM-dd"),
                        comercial_pre_pedido.fabricante_cdpessoabluesoft.ToString(),
                        comercial_pre_pedido.fat_res_seq.ToString(),
                        comercial_pre_pedido.controle_reg_seq.ToString()
                        ));


            return _sql_post;

        }

        public static string Get
              (
                  Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido comercial_pre_pedido
              )
        {


            string _sql_post = string.Format("SELECT * FROM " +
                                             Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0132_02_comercial_pre_pedido_crud_result) +
                        string.Format(" ('DBSELECT', {0}, {1}, {2}, '{3}', {4}, {5}, {6})",
                        comercial_pre_pedido.proc_log_seq,
                        comercial_pre_pedido.cm_pre_ped_seq.ToString(),
                        comercial_pre_pedido.cm_pre_ped_cd.ToString(),
                        comercial_pre_pedido.cm_pre_ped_data.ToString("yyyy-MM-dd"),
                        comercial_pre_pedido.fabricante_cdpessoabluesoft.ToString(),
                        comercial_pre_pedido.fat_res_seq.ToString(),
                        comercial_pre_pedido.controle_reg_seq.ToString()
                        ));


            return _sql_post;

        }


    }

   

}