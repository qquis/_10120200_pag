using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh
{
    public class TbRh_Tipo_Contrato: Pag_Net.Bll.Tb
    {
        public int rh_tipo_contrato_cd { get; set; }
        public string rh_tipo_contrato_descricao { get; set; }
        public int rh_tipo_contrato_legal { get; set;  }


        public TbRh_Tipo_Contrato() 
        {

            _constructor();

        }
        public TbRh_Tipo_Contrato(

            int _rh_tipo_contrato_cd,
            string _rh_tipo_contrato_descricao 

            ) 
        {
            _constructor();
            rh_tipo_contrato_cd = _rh_tipo_contrato_cd;
            rh_tipo_contrato_descricao = _rh_tipo_contrato_descricao;
        }
        public void _constructor()
        {

            this.rh_tipo_contrato_cd = 0;
            this.rh_tipo_contrato_descricao = "TIPO DE CONTRATO NÃO DEFINIDO";
            this.rh_tipo_contrato_legal = 1;
        }
        public void __Binding(DataRow i)
        {

            rh_tipo_contrato_cd = Convert.ToInt32(i["rh_tipo_contrato_cd"].ToString());
            rh_tipo_contrato_descricao = i["rh_tipo_contrato_descricao"].ToString();
            rh_tipo_contrato_legal = Convert.ToInt32(i["rh_tipo_contrato_legal"].ToString());
        }

    }
}
