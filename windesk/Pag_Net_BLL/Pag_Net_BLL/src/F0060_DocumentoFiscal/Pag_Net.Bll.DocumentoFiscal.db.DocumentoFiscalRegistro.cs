using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0060_DocumentoFiscal.Db
{

    public class TbDocumentoFiscalRegistro
    {


        public DateTime dfr_data_registro { get; set;  }
        public int sis_us_seq { get; set;  }
        public int dfr_seq { get; set; }


        private int __dfr_nf_numero;
        public int dfr_nf_numero
        {
            get
            {
                return __dfr_nf_numero;
            }
            set
            {
                try
                {
                    __dfr_nf_numero = value;
                }
                catch (Exception)
                {
                    __dfr_nf_numero = 0;
                }
            }

        }


        private int __dfr_nf_serie;
        public int dfr_nf_serie
        {
            get
            {
                return __dfr_nf_serie;
            }
            set
            {
                __dfr_nf_serie = value;
            }
        }


        private string __dfr_cnpj_cpf;
        public string dfr_cnpj_cpf
        {
            get
            {

                int f = __dfr_cnpj_cpf.Length;
                string format_cnpj = string.Concat(Enumerable.Repeat("0", 14 - f)) + __dfr_cnpj_cpf;
                return format_cnpj;

            }

            set
            {
                if (value.ToString() != "0")
                {
                    if (Pag_Net.Models.BDTools.DocCNPJ_Validar(value))
                    {
                        __dfr_cnpj_cpf = value;

                    }
                    else
                    {
                        __dfr_cnpj_cpf = "";
                        throw new Exception("Cnpj/CPF Incorreto");

                    }
                }
                else
                {
                    __dfr_cnpj_cpf = "0";
                }

            }

        }        
        
        private string __dfr_nf_chave;
        public string dfr_nf_chave
        {
            get
            {
                return __dfr_nf_chave;
            }
            set
            {
                if (Pag_Net.Models.BDTools.nfe_chave_validar(value.ToString()))
                {
                    __dfr_nf_chave = value;
                    __dfr_cnpj_cpf = __dfr_nf_chave.Substring(6, 14);
                    __dfr_nf_serie = Convert.ToInt32(__dfr_nf_chave.Substring(22, 3));
                    __dfr_nf_numero = Convert.ToInt32(__dfr_nf_chave.Substring(25, 9));
                }
                else
                {
                    __dfr_nf_chave = "0";

                }
            }

        }

        public DateTime dfr_nf_data_emissao { get; set; }

        public int df_seq { get; set; }
        public int entrada_saida_seq { get; set; }
        public int controle_reg_seq { get; set; }
        public int controle_etapa_cd { get; set; }

        
        
 

        public TbDocumentoFiscalRegistro()
        {
            dfr_nf_numero = 0;
            dfr_nf_serie = 0;
            dfr_nf_chave = "0";
            dfr_cnpj_cpf = "0";
            dfr_nf_data_emissao = DateTime.Now;
            df_seq = 0;
            entrada_saida_seq = 0;
            controle_reg_seq = 0;
            controle_etapa_cd = 1;
        }

        public TbDocumentoFiscalRegistro(DataRow i)
        {
            dfr_nf_numero = Convert.ToInt32(i["dfr_nf_numero"].ToString());
            dfr_nf_serie = Convert.ToInt32(i["dfr_nf_serie"].ToString());
            df_seq = Convert.ToInt32(i["df_seq"].ToString());
//            entrada_saida_seq = Convert.ToInt32(i["entrada_saida_seq"]);
            dfr_seq = Convert.ToInt32(i["dfr_seq"].ToString());

            dfr_nf_data_emissao = Convert.ToDateTime(i["dfr_nf_data_emissao"]);
            dfr_nf_chave = i["dfr_nf_chave"].ToString();
            dfr_cnpj_cpf = i["dfr_cnpj_cpf"].ToString();

            controle_reg_seq = 0;
            controle_etapa_cd = 1;
        }
    }

}
