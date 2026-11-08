using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Comercial
{
    public class PrRepresentanteFabricante
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;

        public PrRepresentanteFabricante(Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            MyConnect = __myConnect;
        }
        public void Insert(int __cdRepresentante, string  __cdFabricante)
        {
            try
            {
                InsertDelete(__cdRepresentante, __cdFabricante, "INSERT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int __cdRepresentante, string __cdFabricante)
        {
            try
            {
                InsertDelete(__cdRepresentante, __cdFabricante, "DELETE");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
        private void InsertDelete(int __cdRepresentante, string __cdFabricante, string __cmd)
        {
            try
            {
                Pag_Net.Dal.DbUpdate DalUpdate = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);

                List<ParameterQuey> listParametro = new List<ParameterQuey>();
                listParametro.Add(new ParameterQuey("Processamento", SqlDbType.VarChar, false, __cmd));
                listParametro.Add(new ParameterQuey("CdRepresentante", SqlDbType.Int, false, __cdRepresentante));
                listParametro.Add(new ParameterQuey("CdFabricante", SqlDbType.Char, false, __cdFabricante));

                DalUpdate.Execute("PrRepresentanteFabricante", listParametro.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
