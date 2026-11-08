using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0060_DocumentoFiscal
{

    public class  F0060_40_DocumentoFiscalList_Filter
    {
        public DateTime Data_Emissao_Inicial { get; set;  }
        public DateTime Data_Emissao_Final { get; set; }
        public int em_cdempresabluesoft { get; set;  }
        public string Entrada_Saida { get; set;  }
        public F0060_40_DocumentoFiscalList_Filter() 
        {
            Data_Emissao_Inicial = DateTime.Now;
            Data_Emissao_Final = DateTime.Now;
            em_cdempresabluesoft = 1;
            Entrada_Saida = "S";
        }


        private string _VERSION() { return "f0060_40_1011911_documentofiscal_consultar"; }
        public string sql_Get()
        {
            string _PostGre = string.Format("SELECT * FROM " + _VERSION() + "( '{0}', '{1}', {2}, '{3}') ",
                             Data_Emissao_Inicial.ToString("yyyy-MM-dd"),
                             Data_Emissao_Final.ToString("yyyy-MM-dd"),
                             em_cdempresabluesoft.ToString(),
                             Entrada_Saida.ToString()
                     );
            return _PostGre;

        }
        
    }

}