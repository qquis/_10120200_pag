using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.rules
{
    public class Bll_DemonstrativoResultado_fpgto_Setor
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Bll_DemonstrativoResultado_fpgto_Setor(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;

        }

        public DataTable Consultar_FolhaPgto_SetorOperacional(int setor_operacional)
        {
            try
            {
                return Pag_Net.Bll.R0070.Select.get(MyConnect, setor_operacional);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable Consultar_FolhaPgto_SetorOperacional_Lista(int setor_operacional)
        {
            try
            {
                return Pag_Net.Bll.R0071.Select.get(MyConnect, setor_operacional);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable Consultar_CentroDr_Mapa(int setor_operacional)
        {
            try
            {
                return Pag_Net.Bll.R0052.Select.get(MyConnect, setor_operacional);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
