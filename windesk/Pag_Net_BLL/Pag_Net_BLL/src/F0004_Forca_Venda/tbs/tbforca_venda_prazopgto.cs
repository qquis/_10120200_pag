using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0004_Forca_Venda.tbs
{
    public class tbforca_venda_prazopgto : Pag_Net.Bll.Tb
    {
        public int fv_prazopgto_cd { get; set; }
        public string fv_prazopgto_descricao { get; set; }
        public tbforca_venda_prazopgto()
        {
            _constructor();
        }
        public void _constructor() 
        {
            fv_prazopgto_cd = 0;
            fv_prazopgto_descricao = "";
        }
    }
}
