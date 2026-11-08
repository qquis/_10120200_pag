using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0210_Notificacao.interfaces
{

    public class Filter
    {
        public int notificacao_cd { get; set;  }
        public bool notificacao_filter_data { get; set; }
        public DateTime notificacao_filter_data_ini { get; set; }
        public DateTime notificacao_filter_data_fim { get; set; }

        public Filter()
        {

            notificacao_cd = 0;
            notificacao_filter_data = false;
            notificacao_filter_data_ini = DateTime.Now; 
            notificacao_filter_data_fim = DateTime.Now;



        }
    }
}
