using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0035_Ativo
{
    public class TbAtivoTipo : Pag_Net.Bll.Tb
    {

        public int at_tipo_cd { get; set; }

        public string at_tipo_descricao { get; set; }

        public TbAtivoTipo()
        {
            _constructor();
        }

        public void _constructor()
        {
            at_tipo_cd = 1;
            at_tipo_descricao = "* SEM TIPO *";
        }
        
    }

}

  



    
