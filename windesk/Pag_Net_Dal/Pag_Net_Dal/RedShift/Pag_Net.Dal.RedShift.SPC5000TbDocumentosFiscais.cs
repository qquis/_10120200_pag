using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;
using Pag_Net.Models;

namespace Pag_Net.Dal.RedShift.SPC5000TbDocumentosFiscais
{
    public static class
        Info
    {
        public static string Base() { return "RedShift BlueSOFT"; }
        public static string ReadingTables() { return "NOTA_FISCAL"; }
        public static string RecordingTable() { return "*"; }
        public static string AccessProcedure() { return "String SELECT"; }
        public static string BusinessRuleModel() { return "SPC5000TbProdutoBlueSoft"; }
        public static string DataBase() { return "*"; }
        public static string ClassName() { return "*";  }
        public static string Get()
        {
            return string.Format("Base de Dados: {0} Tabela de Leitura {1} Tabela de Gravação: {2} Procedure de Acesso: {3}, Modelo da Regra de Negócio Destino: {4}",
                          DataBase(),
                          ReadingTables(),
                          RecordingTable(),
                          AccessProcedure(),
                          BusinessRuleModel());
        }
        public static string Error(string _Method, string _ComplementaryInformation)
        {
            return string.Format("Informações {0}, Método {1}, Erro: {2}", Get(), _Method, _ComplementaryInformation);
        }
    }

    public static class 
        Data
    {


        public static DataTable
              GetDataTable(ModelSysUserInfo _TbSysUserInfo, Pag_Net.Models.SPC5000TbDocumentosFiscais _Model)
        {
            try
            {


                string _DataInicial = _Model._SPParameterDataFaturamentoInicial.ToString("yyyy-MM-dd");
                string _DataFinal = _Model._SPparameterDataFaturamentoFinal.ToString("yyyy-MM-dd");



                string SqlRedSHIFT = "SELECT       NF.LOJA_KEY                                          AS BlueSoftEmpresaId  " +
                                     "         ,   NF.nf_key                                            AS BlueSoftSequencial " +
                                     "         ,   case when isnull(nf.usuario_cancelamento_key,0) = 0                        " + 
                                     "                       then 0                                                           " +
                                     "                       else 1                                                           " +
                                     "                       end " + 
                                     "         ,   0                                                    AS TargetEmpresaId " +
                                     "         ,   0                                                    AS TargetSequencial   " +
                                     "         ,   NF.nf_numero                                         AS Nfe " +
                                     "         ,   NF.nf_serie                                          AS Serie " +
                                     "         ,   0                                                    AS SerieNumero " +
                                     "         ,   NF.data_emissao                                      AS DataFaturamento " +
                                     "         ,   NF.data_saida                                        AS DataSaida " +
                                     "         ,   NF.chave                                             AS ChaveNfe " +
                                     "         ,   CAST(NT.VALOR_TOTAL_MERCADORIAS AS NUMERIC(13,2))    AS ValorProdutos " +
                                     "         ,   CAST(NT.VALOR_TOTAL_NOTA AS NUMERIC(13,2))           AS ValorNotaFiscal " +
                                     "         ,   CAST(0 AS INT)                                       AS CdParticipanteRemetente " +
                                     "         ,   PE.CPF_CNPJ                                          AS RemetenteCNPJ " +
                                     "         ,   CAST(0 AS INT)                                       AS CdParticipanteDestinatario " +
                                     "         ,   PD.CPF_CNPJ                                          AS DestinatarioCNPJ " +
                                     "         ,   PD.ESTADO_SIGLA                                      AS DestinatarioUF " +
                                     "         ,   CAST(0 AS INT)                                       AS SistemaTarget " +
                                     "         ,   CAST(0 AS INT)                                       AS SistemaBlueSoft " +
                                     "         ,   CAST('AUT' AS CHAR(3))                               AS StatusDocumentoFiscal " +
                                     "         ,   0                                                    AS TargetSequencialOrigem " +
                                     "         ,   0                                                    AS BlueSoftSequencialOrigem " +
                                     "         ,   NF.NF_TIPO_KEY                                       AS BlueSoftNfCdTipo " +
                                     "         ,   TP.DESCRICAO                                         AS BlueSoftNFDescricaoTipo " +
                                     "         ,   CASE" +
                                     "               WHEN TP.ENTRADA_SAIDA = -1 THEN 1" +
                                     "               ELSE 0" +
                                     "             END                                                  AS Operacao" +
                                     "         ,   ISNULL(OX.ORIGEM_NF_KEY,0)                           AS SeqDocumentoFiscal_Origem" +
                                     "         ,   isnull(NF.usuario_cancelamento_key,0)                AS BlueSoftUsuarioCancelamento " +
                                     "         ,   isnull(NF.data_cancelamento,'1900-01-01')            AS BlueSoftDataCancelamento " + 
                                     "         ,   cast( 0 as int )                                     AS BlueSoftRegistroCancelado " + 
                                     "   FROM NOTA_FISCAL NF" +
                                     "     INNER JOIN NOTA_FISCAL_TOTAL NT ON NT.NF_KEY = NF.NF_KEY" +
                                     "     INNER JOIN PESSOA PD ON PD.pessoa_key = NF.FORNECEDOR_KEY" +
                                     "     INNER JOIN PESSOA PE ON PE.pessoa_key = NF.EMITENTE_KEY" +
                                     "     INNER JOIN NOTA_FISCAL_TIPO TP ON TP.NF_TIPO_KEY = NF.NF_TIPO_KEY" +
                                     "     LEFT JOIN NOTA_FISCAL_ORIGEM OX " +
                                     "               INNER JOIN NOTA_FISCAL NFX ON NFX.NF_KEY = OX.NF_KEY AND NFX.NF_TIPO_KEY = 27 " +
                                     "                                          ON OX.ORIGEM_NF_KEY = NF.NF_KEY " +
                                     "   WHERE 1 = 1 " +
                                     "     AND NF.data_emissao >= '" + _DataInicial + "'" +
                                     "     AND NF.data_emissao <= '" + _DataFinal + "'" +
                                     "     AND NF.tipo_status_nfe_key = 3 " +
                                     "   ORDER BY nf.loja_key, nf.nf_key asc ";

                return DbSelect.GetDataSet(_TbSysUserInfo, DataBaseName.ODBCBI32, SqlRedSHIFT, "").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(Info.Error("GetDataTable", ex.Message));
            }
        }

    }
}
