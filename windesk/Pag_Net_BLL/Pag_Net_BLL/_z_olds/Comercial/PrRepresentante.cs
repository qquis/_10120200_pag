using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Comercial
{
    public class PrRepresentante
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;

        public PrRepresentante(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            MyConnect = __myConnect;
        }
        public void Insert( string __descricaoRepresentante)
        {
            try
            {
                InsertDelete(__descricaoRepresentante, "INSERT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete( string __descricaoRepresentante)
        {
            try
            {
                InsertDelete(__descricaoRepresentante, "DELETE");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
        private void InsertDelete(string __descricaoRepresentante, string __cmd)
        {
            try
            {
                Pag_Net.Dal.DbUpdate DalUpdate = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);

                List<ParameterQuey> listParametro = new List<ParameterQuey>();
                listParametro.Add(new ParameterQuey("Processamento", SqlDbType.VarChar, false, __cmd));
                listParametro.Add(new ParameterQuey("Descricao", SqlDbType.VarChar, false, __descricaoRepresentante));

                DalUpdate.Execute("PrRepresentante", listParametro.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
