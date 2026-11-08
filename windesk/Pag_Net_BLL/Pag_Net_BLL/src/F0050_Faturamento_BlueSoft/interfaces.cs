using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0050_Faturamento_BlueSoft.interfaces
{

    public class iF0050_FaturamentoFilter
    {
        public int em_cdempresa { get; set;  }
        public int op_cdoperacao { get; set;  }
        public bool dataPedidoEmissao_filter { get; set;  }
        public DateTime dataPedidoEmissao_ini { get; set;  }
        public DateTime dataPedidoEmissao_fim { get; set;  }

        public bool dataFaturamento_filter { get; set;  }
        public DateTime dataFaturamento_ini { get; set;  }
        public DateTime dataFaturamento_fim { get; set;  }
        public string TipoStatusFiltro { get; set; }
        public int TipoStatusFiltro_fat_blue_status_cd { get; set;}


        public iF0050_FaturamentoFilter()
        {

            em_cdempresa = 0;
            op_cdoperacao = 0;
            dataPedidoEmissao_filter = false;
            dataPedidoEmissao_ini = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dataPedidoEmissao_fim = DateTime.Now;
            dataFaturamento_filter = false;
            dataFaturamento_ini = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); ;
            dataFaturamento_fim = DateTime.Now;
            TipoStatusFiltro = "SELECIONAR";

        }
    }
}
