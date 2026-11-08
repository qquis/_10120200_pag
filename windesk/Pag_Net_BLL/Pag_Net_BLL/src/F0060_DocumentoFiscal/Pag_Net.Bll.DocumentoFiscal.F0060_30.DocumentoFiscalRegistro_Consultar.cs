using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0060_DocumentoFiscal
{
    public class F0060_30_DocumentoFiscalRegistroList_Filter
    {
        public int              DocumentoFiscalNAOProcessado             {get;set;}
        public int              DocumentoFiscalNAORecebida               {get;set;}
        public int              StatusNfManifestacao                     {get;set;}
        public string           Entrada_Saida                            {get;set;}
        public int              em_cdempresabluesoft                     {get;set;}
        public DateTime         Data_Inicial_Registro                    {get;set;}
        public DateTime         Data_Final_Registro                      {get;set;}
        public DateTime         Data_Emissao_Inicial                     {get;set;}
        public DateTime         Data_Emissao_Final                       {get;set;}
        public int              Controle_Reg_Seq                         {get;set;}
        public string           CHAVE_NFE                                {get;set;}
        public int dfr_nf_numero { get; set;  }
        public int dfr_nf_serie { get; set;  }
        public string dfr_cnpj_cpf { get; set; }

        private string __VERSION() { return "f0060_30_1011922_documentofiscalregistro_consultar"; }

        public F0060_30_DocumentoFiscalRegistroList_Filter()
        {
            DocumentoFiscalNAOProcessado   = 0;
            DocumentoFiscalNAORecebida     =0;
            StatusNfManifestacao           =0;
            Data_Inicial_Registro          = DateTime.Now;
            Data_Final_Registro            = DateTime.Now;
            Data_Emissao_Inicial = DateTime.Now;
            Data_Emissao_Final = DateTime.Now;
            Controle_Reg_Seq = 0;
            Entrada_Saida = "";
            em_cdempresabluesoft = 0;
            CHAVE_NFE = "";
            dfr_cnpj_cpf = "";
            dfr_nf_numero = 0;
            dfr_nf_serie = 0;
        }
        public F0060_30_DocumentoFiscalRegistroList_Filter(string _chave_nfe)
        {
            CHAVE_NFE = _chave_nfe;

            DocumentoFiscalNAOProcessado = 0;
            DocumentoFiscalNAORecebida = 0;
            StatusNfManifestacao = 0;
            Data_Inicial_Registro = Convert.ToDateTime("1900-01-01");
            Data_Final_Registro = Convert.ToDateTime("2150-12-01");
            Data_Emissao_Inicial = Convert.ToDateTime("1900-01-01");
            Data_Emissao_Final = Convert.ToDateTime("2150-12-01");
            Controle_Reg_Seq = 0;
            Entrada_Saida = "";
            em_cdempresabluesoft = 0;


        }
        public string sql_Get()
        {
            try
            {


                string _PostGre = string.Format("SELECT * FROM " + __VERSION() + "( {0}, {1}, {2}, '{3}', '{4}', {5}, '{6}', {7}, {8}, '{9}') ",
                            DocumentoFiscalNAOProcessado,
                            DocumentoFiscalNAORecebida,
                            StatusNfManifestacao,
                            Data_Inicial_Registro.ToString("yyyy-MM-dd"),
                            Data_Final_Registro.ToString("yyyy-MM-dd"),
                            Controle_Reg_Seq.ToString(),
                            CHAVE_NFE.ToString(),
                            dfr_nf_numero.ToString(),
                            dfr_nf_serie.ToString(),
                            dfr_cnpj_cpf.ToString()
                    );
                return _PostGre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}