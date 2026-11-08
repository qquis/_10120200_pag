using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Bll;
using Pag_Net.Models;



namespace Pag_Net.Bll.F0060_DocumentoFiscal
{

    public class F0060_03_DocumentoFiscalRegistro_CRUD
    {
        public static string _VERSION() { return "f0060_03_1011922_tbdocumentofiscalregistro_CRUD"; }
        public static string post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            Pag_Net.Bll.F0060_DocumentoFiscal.ModelDocumentoFiscalRegistro item)
        {


            string SQL_COMMAND = string.Format("SELECT * FROM " + _VERSION() +   "(" + 
                                  " '" + BDCommnadType.ToString() + "' " +
                                  "       ,     {0}             " +
                                  "       ,    '{1}'            " +
                                  "       ,    '{2}'            " +
                                  "       ,    '{3}'            " +
                                  "       ,    '{4}'            " +
                                  "       ,     {5}             " +
                                  "       ,     {6}             " +
                                  "       ,     {7}             " +
                                  "       ,     {8}             )",
                                  item.dfr_nf_numero,
                                  item.dfr_nf_serie,
                                  item.dfr_nf_data_emissao.ToString("yyyy-MM-dd"),
                                  item.dfr_nf_chave,
                                  item.dfr_cnpj_cpf,
                                  item.df_seq,
                                  item.entrada_saida_seq,
                                  item.controle_reg_seq.ToString(),
                                  item.controle_etapa_cd);


            return SQL_COMMAND;

        }



    }
 
}

