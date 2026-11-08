using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Models
{
    public class ModelSistemaPermissoes
    {
        public int sis_cd;
        public int sis_fc_cd;
        public string sis_ac_descricao;
        public string sis_ac_menu;
        public int sis_ta_cd;
        public string sis_ta_descricao;

        public ModelSistemaPermissoes(DataRow i)
        {
            //sis_cd = Convert.ToInt32(i["sis_cd"].ToString());
            sis_fc_cd = Convert.ToInt32(i["sis_fc_cd"].ToString());
            sis_ac_descricao = Convert.ToString((i["sis_ac_descricao"].ToString()));
            sis_ac_menu = Convert.ToString((i["sis_ac_menu"].ToString()));
            sis_ta_cd = Convert.ToInt32(i["sis_ta_cd"].ToString());
            sis_ta_descricao = Convert.ToString((i["sis_ta_descricao"].ToString()));
        }
    }
}
