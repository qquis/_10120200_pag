using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0060_DocumentoFiscal.Db
{

    public class DocumentoFiscalSeq
    {

        public int df_nf_seq_blue { get; set; }
        public int df_nf_numero { get; set; }
        public string df_nf_serie { get; set; }
        public int df_nf_tipo { get; set; }
        public int cdpessoabluesoft { get; set; }
        public DateTime df_data_emissao { get; set; }
        public int em_cdempresabluesoft { get; set; }


        public DocumentoFiscalSeq() { }
        public DocumentoFiscalSeq(DataRow i)
        {

            df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
            df_nf_numero = Convert.ToInt32(i["df_nf_numero"].ToString());
            df_nf_serie = i["df_nf_serie"].ToString();
            df_nf_tipo = Convert.ToInt32(i["df_nf_tipo"].ToString());
            cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());
            df_data_emissao = Convert.ToDateTime(i["df_data_emissao"]);
            em_cdempresabluesoft = Convert.ToInt32(i["em_cdempresabluesoft"]);


        }

    }
}
