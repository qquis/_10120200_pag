using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0060_DocumentoFiscal.Db
{

    public class DocumentoFiscalOrigem
    {
        public DateTime Dtlog_insert { get; set;  }
        public DateTime Dtlog_update { get; set; }
        public int Df_nf_origem_seq { get; set; }
        public int Df_nf_seq_blue { get; set; }
        public int Df_nf_seq_blue_origem { get; set; }

        public DocumentoFiscalOrigem() { }
        public DocumentoFiscalOrigem(
                    int df_nf_seq_blue
                    , int df_nf_seq_blue_origem
            ) 
        {
            Df_nf_seq_blue = df_nf_seq_blue;
            Df_nf_seq_blue_origem = df_nf_seq_blue_origem;
        }

        public DocumentoFiscalOrigem(DataRow i )
        {
            Df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
            Df_nf_seq_blue_origem = Convert.ToInt32(i["Df_nf_seq_blue_origem"].ToString());
        }

    }

}
