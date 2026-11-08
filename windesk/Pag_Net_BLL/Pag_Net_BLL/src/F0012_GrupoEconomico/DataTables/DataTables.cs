using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0012_GrupoEconomico
{
    public static class Dts
    {
        public static DBDataTable F0012_60_GrupoEconomicoList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTER)
        {
            try
            {


                string Script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0012_GrupoEconomico.F0012_60_GrupoParticipante_list._VERSION() +
                                                    "(  vcdgrupoeconomico:= " + FILTER.cdgrupoeconomico.ToString() +  		
                                                    " , vdescricao:= '" + FILTER.descricao.ToString().Replace("'", "")  + "'" + 
                                                    " , vjohnson_cliente_top:= " + FILTER.johnson_cliente_top.ToString() + 
                                                    " , vgrupoeconomico_status:= " + FILTER.grupoeconomico_status.ToString() + 
                                                    ") "    );


                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Script)); 

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0012_GrupoEconomico: \n" + ex.Message);
            }
        }
      
    }

}

