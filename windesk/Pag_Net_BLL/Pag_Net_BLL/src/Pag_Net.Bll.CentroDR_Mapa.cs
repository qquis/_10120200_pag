using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.rules
{
    public class CentroDr_Mapa
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        public CentroDr_Mapa(Pag_Net.Models.modelSistemaUsuario myConnect)
        {
            MyConnect = myConnect;
        }


        public DataTable Consultar_CentroDR_Resumo_item(int vcentrodr_resumo)
        {

            try
            {
                return Pag_Net.Bll.R0077.Select.get(MyConnect, vcentrodr_resumo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable Consultar_CentroDR_Resumo(int vcdr_tipo_Cd)
        {

            try
            {
                return Pag_Net.Bll.R0075.Select.get(MyConnect, vcdr_tipo_Cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable Consultar_CentroDR_Resumo_Tipo()
        {

            try
            {
                return Pag_Net.Bll.R0078.Select.get(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public DataTable Consultar_CentroDr_Mapa(int vcentrodr_resumo_cd)
        {
            try
            {
                return Pag_Net.Bll.R0052.Select.get(MyConnect, vcentrodr_resumo_cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Consultar_CentroDr_Tipo(int setor_operacional)
        {
            try
            {
                return Pag_Net.Bll.R0076.Select.get(MyConnect, setor_operacional);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 

    }
}
