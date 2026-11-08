using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh
{
    public class ModelParticipanteFuncionario : Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario
    {
        public string nome_razao { get; set; }
        public double LOCAL_total_prev { get; set;  }
        public double LOCAL_rh_vl_folha_brt_previsao { get; set; }
        public double LOCAL_rh_vl_pj_previsao { get; set; }
        public double LOCAL_rh_vl_outros { get; set; }


        /*
        public double LOCAL_total_prev
        {
            get
            {
                return LOCAL_rh_vl_folha_brt_previsao + LOCAL_rh_vl_pj_previsao + LOCAL_rh_vl_outros;
            }
        }
        public double LOCAL_rh_vl_folha_brt_previsao
        {
            get
            {
                if (this.rh_vl_folha_brt > 0)
                {
                    return this.rh_vl_folha_brt * 2;
                }
                else
                {
                    return 0;
                }

            }
        }
        public double LOCAL_rh_vl_pj_previsao
        {
            get
            {
                if (this.rh_vl_pj > 0)
                {
                    return this.rh_vl_pj + (((this.rh_vl_pj / 3) + this.rh_vl_pj) /12) ;
                }
                else
                {
                    return 0;
                }

            }
        }
        public double LOCAL_rh_vl_outros
        {
            get
            {
                if (this.rh_vl_outros > 0)
                {
                    return this.rh_vl_outros + (((this.rh_vl_outros / 3) + this.rh_vl_outros) / 12);
                }
                else
                {
                    return 0;
                }

            }
        }*/


        public ModelParticipanteFuncionario()
            : base()
        {
            nome_razao = "";
        }
        public string UpdateScript_Setor_Operacional()
        {
            string sql = " SELECT " + Pag_Net.Bll.F0141_Rh.f0011_50_tbparticipante_funcionario_setor_operacional.VERSION() +
                   " (        vrh_funcionario_cd:= " + this.rh_funcionario_cd.ToString() +
                   "   ,      vrh_setor_operacional_cd:= " + this.SetorOperacional.rh_setor_operacional_cd + 
                   "  ) ";

            return sql;
        }
    }
}
