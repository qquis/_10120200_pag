using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;


namespace Pag_Net.Bll.Comercial.PedidoCompra
{
    public static class UspComercialPedidoCompraEmail
    {
        public static void Enviar(Models.modelSistemaUsuario MyConnect, int NumeroPedido, string email)
        {
            try
            {
                Pag_Net.Dal.DbUpdate DalUpdate = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);
                List<ParameterQuey> listParametroInfo = new List<ParameterQuey>();
                listParametroInfo.Add(new ParameterQuey("Email", SqlDbType.VarChar, false, email));
                listParametroInfo.Add(new ParameterQuey("NumeroPedido", SqlDbType.Int, false, NumeroPedido));
                DalUpdate.Execute("UspComercialPedidoCompraEmail", listParametroInfo.ToArray());
            }
            catch( Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
