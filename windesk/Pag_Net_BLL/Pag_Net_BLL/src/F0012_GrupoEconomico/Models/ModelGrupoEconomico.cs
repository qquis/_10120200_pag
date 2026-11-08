using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0012_GrupoEconomico
{
    public class ModelGrupoEconomico: TbGrupoEconomico
    {

        public bool Local_bool_johnson_cliente_top
        {
            get
            {
                if (this.johnson_cliente_top == 1)
                    return true;
                else
                    return false;
            }
        }
        public ModelGrupoEconomico()
            : base()
        {

        }

        public ModelGrupoEconomico(int _cdGrupoEconomico, string _descricao )
        {
            _constructor();
            this.cdgrupoeconomico = _cdGrupoEconomico;
            this.descricao = descricao; 
        }

        public void _BlueSoft_Binding(DataRow i)
        {
            base._constructor();
            this.cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"].ToString()); 
            this.descricao = i["descricao"].ToString(); 
            this.grupoeconomico_status = Convert.ToInt32(i["grupoeconomico_status"].ToString());

        }

        public string _BlueSoft_Script_Integ_Get()
        {
            string sql_bluesoft_integ = "SELECT " + Pag_Net.Bll.F0012_GrupoEconomico.F0012_01_GrupoParticipante_Integ_Bluesoft._VERSION() +
                "(   vcdgrupoeconomico:= " + this.cdgrupoeconomico.ToString() +
                "  , vdescricao:= '" + this.descricao.ToString().Replace("'","") + "'" +
                "  , vgrupoeconomico_status:= " + this.grupoeconomico_status.ToString() + ");";

            return sql_bluesoft_integ;
         
        }
    }
}
