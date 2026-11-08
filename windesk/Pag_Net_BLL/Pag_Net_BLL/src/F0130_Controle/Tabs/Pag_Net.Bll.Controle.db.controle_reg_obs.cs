using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle_Reg_Obs
    {
        public int controle_reg_seq { get; set; }
        public int controle_reg_obs_seq { get; set;  }
        public string controle_reg_obs { get; set; }
        

    

        public TbControle_Reg_Obs()
        {
            controle_reg_seq = 0;
            controle_reg_obs_seq = 0;
            controle_reg_obs = "";

        }

        public TbControle_Reg_Obs(

             int _controle_reg_seq,
             int _controle_reg_obs_seq,
             string _controle_reg_obs

            )
        {

            controle_reg_seq = _controle_reg_seq;
            controle_reg_obs_seq = _controle_reg_obs_seq;
            controle_reg_obs = _controle_reg_obs;
        }


        public TbControle_Reg_Obs(DataRow i)
        {
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"]);
            controle_reg_obs_seq = Convert.ToInt32(i["controle_reg_obs_seq"].ToString());
            controle_reg_obs = i["controle_reg_obs"].ToString();
            

        }


    }
}
