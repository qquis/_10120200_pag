using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0001_Sistema
{
    public class WkSistema
    {
        public static ModelSistemaPermissoes[] ConsultarPostgreAcessos(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Models.Filter.Login Filtros)
        {
            try
            {
                List<ModelSistemaPermissoes> _list = new List<ModelSistemaPermissoes>();
                DataTable DataTable_Produto = Pag_Net.Bll.R0001.Select._0001_login_acesso(MyConnect, Filtros);

                foreach (DataRow dr in DataTable_Produto.Rows)
                {
                    _list.Add(new ModelSistemaPermissoes(dr));
                    MyConnect.sis_us_seq = Convert.ToInt32(dr["sis_us_seq"].ToString());
                }
                return _list.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll | Connection " + ex.Message);
            }

        }
    }



}
