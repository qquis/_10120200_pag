using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Dal.RedShift.SPC0015TbProdutoBlueSoft
{
    public static class
        Info
    {
        public static string Base() { return "RedShift BlueSOFT"; }
        public static string ReadingTables() { return "PRODUTO_D, FORNECEDOR_PRODUTO, PRODUTO_LOJA_VENDA_EXTERNA"; }
        public static string RecordingTable() { return "*"; }
        public static string AccessProcedure() { return "String SELECT"; }
        public static string BusinessRuleModel() { return "5000TbProdutoBlueSoft"; }
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
              GetDataTable(ModelSysUserInfo _TbSysUserInfo, Pag_Net.Models.SPC0015TbProdutoBlueSoft _Model)
        {
            try
            {

                int CdBlueSOft = 0;
                string Descricao = "";

                if (_Model._SPParameterCdProdutoBlueSoft != 0)
                {
                    CdBlueSOft = _Model._SPParameterCdProdutoBlueSoft;
                }


                if (String.IsNullOrEmpty(_Model._SPParameterDescricao))
                {
                    Descricao = "";
                }
                else
                {
                    Descricao = _Model._SPParameterDescricao;
                }
                



                string SqlRedSHIFT = "SELECT        ISNULL(X.PRODUTO_KEY,0)                      AS  CdProdutoBlueSoft" +
                                     "           ,  0                                            AS  CdProduto" + 
                                     "           ,  X.DESCRICAO                                  AS  Descricao" +
                                     "           ,  X.GTIN_PRINCIPAL                             AS  CodigoBarraReferencia" +
                                     "           ,  X.EMBALAGEM_KEY                              AS  EmbalagemEstoque" +
                                     "           ,  ISNULL(X.PRODUTO_UNITARIO_KEY,0)             AS  CdProdutoBlueSoftUnitario" +
                                     "           ,  ISNULL(X.FATOR_ESTOQUE,1)                    AS  FatorEstoque" +
                                     "           ,  ISNULL(X.CONTROLE_ESTOQUE,0)                 AS  CdProdutoBlueSoftControleEstoque" +
                                     "           ,  ISNULL(X.PRECO_EQUIVALENTE,0)                AS  CdProdutoBlueSoftControlePreco" +
                                     "           ,  ISNULL(X.DEPARTAMENTO_KEY,0)                 AS  DepartamentoKey" +
                                     "           ,  ISNULL(X.SECAO_KEY,0)                        AS  SecaoKey" +
                                     "           ,  ISNULL(X.GRUPO_PRODUTO_KEY,0)                AS  GrupoKey" +
                                     "           ,  ISNULL(X.SUB_GRUPO_PRODUTO_KEY,0)            AS  SubGrupoKey" +
                                     "           ,  ISNULL(X.ULTIMA_ALTERACAO,'1900-01-01')      AS  DataUltimaAlteracao" +
                                     "           ,  ISNULL(x.DATA_CADASTRO,'1900-01-01')         AS  DataCadastro" +
                                     "           ,  ISNULL(X.FABRICANTE_KEY,0)                   AS  FabricanteKey" +
                                     "           ,  ISNULL(X.STATUS,0)                           AS  StatusProduto" +
                                     "           ,  ISNULL(X1.EMBALAGEM_KEY,X.EMBALAGEM_KEY)     AS  EmbalagemCompra " +
                                     "           ,  ISNULL(X1.FATOR_ESTOQUE,1)                   AS  EmbalagemCompraQtdeUnitaria " +
                                     "           ,  ISNULL(vx.VendaExterna,0)                    AS  VendaExterna " +
                                     " FROM         PRODUTO_D     X " +
                                     " LEFT JOIN    FORNECEDOR_PRODUTO           FP ON FP.FORNECEDOR_PRODUTO_KEY = X.FORNECEDOR_PRODUTO_PADRAO_KEY " +
                                     " LEFT JOIN    PRODUTO_D                    X1 ON X1.PRODUTO_KEY = FP.PRODUTO_KEY" +
                                     " LEFT JOIN    (   SELECT   produto_key            as CdProdutoBlueSoft " +
                                     "                         , convert(int, 1)        as VendaExterna " +
                                     "                  FROM     produto_loja_venda_externa   " +
                                     "                  GROUP BY Produto_key " +
                                     "              ) vx on vx.CdProdutoBlueSoft = ISNULL(X.PRODUTO_KEY,0) " +
                                     " WHERE        x.produto_key > 0 ";




                if (Descricao != "")
                {
                    SqlRedSHIFT = SqlRedSHIFT +
                                            "   AND         X.DESCRICAO LIKE '%" + Descricao.ToString() + "%'";
                }


                if (CdBlueSOft != 0)
                {
                    SqlRedSHIFT = SqlRedSHIFT +
                                            "   AND         X.PRODUTO_KEY = " + CdBlueSOft.ToString();
                }

                SqlRedSHIFT = SqlRedSHIFT + " ORDER BY DESCRICAO ASC ";

                return DbSelect.GetDataSet(_TbSysUserInfo, DataBaseName.ODBCBI32, SqlRedSHIFT, "").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(Info.Error("GetDataTable", ex.Message));
            }
        }

    }
}
