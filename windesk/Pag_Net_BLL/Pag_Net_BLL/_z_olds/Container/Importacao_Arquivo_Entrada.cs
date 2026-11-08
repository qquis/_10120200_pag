using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Pag_Net.Bll.Container
{
    public class Importacao_Arquivo_Entrada
    {

        //Publics
        public int LinhaInicial = 1;
        public List<string> _logResult;
        public int LinhasProcessadas = 0;
        public int LinhasNaoValidada = 0;

        //Privates
        public  Pag_Net.Tools.ManagerFileInfo ArquivoDeEntrada;
        private Pag_Net.Tools.ManagerFile _ManagerFile;

        int NCol_DataEntrada = 0;
        int NCol_Fornecedor = 1;
        int NCol_NumeroDocumentoFiscal = 2;
        int NCol_CodigoBarra = 3;
        int NCol_CdProdutoBlueSoft = 4;
        int NCol_DescricaoImportacao = 5;
        int NCol_EmbalagemEstoqueQtde = 6;
        int NCol_ValorCustoBruto = 7;
        int NCol_ValorCustoLiquido = 8;
        int NCol_CFOP = 17;

        DataTable Result;

        public Importacao_Arquivo_Entrada()
        {
            ArquivoDeEntrada = new Pag_Net.Tools.ManagerFileInfo();
            _ManagerFile = new Pag_Net.Tools.ManagerFile();
        }

        public DataTable Import(string ArquivoEntrada)
        {
            try
            {

                /* Ajuste parametro de linha inicial para considerar primeira linha como linha zero */
                if (LinhaInicial >= 1)
                    LinhaInicial = LinhaInicial - 1;
                /* -------------------------------------------------------------------------------- */
                

                Result = null;
                _logResult = new List<string>();

                _logResult.Add("Inicializando processamento...");
                _logResult.Add("Validando Existência do Arquivo: ");

                if (!File.Exists(ArquivoEntrada))
                {
                    _logResult.Add("Arquivo " + ArquivoEntrada + " Não existe no caminho indicado");
                }
                else
                {
                    System.IO.FileInfo ObjIoFileEstoque = new FileInfo(ArquivoEntrada);
                    ObjIoFileEstoque.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                    ArquivoDeEntrada = _ManagerFile.FileOut(ObjIoFileEstoque);
                    ArquivoDeEntrada.TipoArquivo = "ENTRADA";
                    Result = FileRead();

                }
                return Result;
            }
            catch (Exception ex)
            {
                _logResult.Add(ex.Message);
                return Result;
            }
        }


        public DataTable FileRead()
        {
            int i = 0;
            string[] linhas = Pag_Net.Tools.LogFile.ReadLine(ArquivoDeEntrada.FileName);
            

            DataTable dt = new DataTable("TabTxt");
            try
            {
                dt.Columns.Add("NumeroLinha", typeof(Int32));
                dt.Columns.Add("Valid", typeof(Boolean));
                dt.Columns.Add("Content", typeof(String));

                dt.Columns.Add("DataEntrada", typeof(DateTime));
                dt.Columns.Add("Fornecedor", typeof(String));
                dt.Columns.Add("NumeroDocumentoFiscal", typeof(Int32));
                dt.Columns.Add("CodigoBarra", typeof(String));
                dt.Columns.Add("CdProdutoBlueSoft", typeof(Int32));

                dt.Columns.Add("DescricaoImportacao", typeof(String));
                dt.Columns.Add("EmbalagemEstoqueQtde", typeof(Decimal));
                dt.Columns.Add("ValorCustoBruto", typeof(Decimal));
                dt.Columns.Add("ValorCustoLiquido", typeof(Decimal));
                dt.Columns.Add("CFOP", typeof(String));


                char[] delimiterChars = { ';' };

                for (i = 0; i < linhas.Count(); i++)
                {

                    string linhaRead = linhas[i].ToString();
                    string[] colunas = linhaRead.Split(delimiterChars);
                    DataRow row = dt.NewRow();
                    row["NumeroLinha"] = i;
                    row["Content"] = linhas[i].ToString();
                    row["Valid"] = false;

                    if (i >= LinhaInicial)
                    {

                        try
                        {
                            if (ValidLinha(colunas, i, linhas[i].ToString()))
                            {
                                row["Valid"] = true;
                                row["DataEntrada"] = Convert.ToDateTime(colunas[NCol_DataEntrada]);
                                row["Fornecedor"] = colunas[NCol_Fornecedor].ToString();
                                row["NumeroDocumentoFiscal"] = Convert.ToInt32(colunas[NCol_NumeroDocumentoFiscal]);
                                row["CodigoBarra"] = colunas[NCol_CodigoBarra].ToString();
                                row["CdProdutoBlueSoft"] = Convert.ToInt32(colunas[NCol_CdProdutoBlueSoft]);
                                row["DescricaoImportacao"] = colunas[NCol_DescricaoImportacao].ToString();
                                row["EmbalagemEstoqueQtde"] = Convert.ToDouble(colunas[NCol_EmbalagemEstoqueQtde]);
                                row["ValorCustoBruto"] = Convert.ToDouble(colunas[NCol_ValorCustoBruto]);
                                row["ValorCustoLiquido"] = Convert.ToDouble(colunas[NCol_ValorCustoLiquido]);
                                row["CFOP"] = colunas[NCol_CFOP].ToString();
                            }
                        }
                        catch (Exception ex1)
                        {
                            _logResult.Add(ex1.Message);
                        }
                    }
                    if (!Convert.ToBoolean(row["Valid"]))
                        this.LinhasNaoValidada = this.LinhasNaoValidada + 1;
                    this.LinhasProcessadas = LinhasProcessadas + 1;
                    dt.Rows.Add(row);
                }
                return dt;
            }
            catch (Exception ex)
            {
                _logResult.Add(ex.Message);
                return dt;
            }
        }




        private bool ValidLinha(string[] linha, int NumeroLinha, string Content)
        {
            try
            {
                
                if (linha[NCol_DescricaoImportacao].Length < 1)
                {
                    _logResult.Add("Linha N.: " + NumeroLinha.ToString() + " Conteúdo [" + Content + "] Erro: Número de caracteres na descrição menor que 1");
                    _logResult.Add("");
                    return false;
                }
                if (!Pag_Net.Tools.PagToolsIsCdBarra.Valid(linha[NCol_CodigoBarra]))
                {
                    _logResult.Add("Linha N.: " + NumeroLinha.ToString() + " Conteúdo [" + Content + "] Erro: Códgo de Barra não é válido");
                    _logResult.Add("");
                    return false;
                }
                    
                try
                {
                    double valida_qtde = Convert.ToDouble(linha[NCol_EmbalagemEstoqueQtde]);
                    double valida_CustoBruto = Convert.ToDouble(linha[NCol_ValorCustoBruto]);
                    double valida_CustoLiquido = Convert.ToDouble(linha[NCol_ValorCustoLiquido]);
                    int CdProdutoBlueSoft = Convert.ToInt32(linha[NCol_CdProdutoBlueSoft]);
                    return true;
                }
                catch (Exception ex1) 
                {
                    _logResult.Add("Linha N.: " + NumeroLinha.ToString() + " Conteúdo [" + Content + "] Erro de Conversão DECIMAL: " + ex1.Message);
                    _logResult.Add("");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logResult.Add("Linha N.: " + NumeroLinha.ToString() + " Conteúdo [" + Content + "] Erro não definido: " + ex.Message);
                _logResult.Add("");
                return false;
            }
        }

    }
}

/* Lay out básico do arquivo de produtos */
/*
00.Data;
01.Fornecedor;
02.NF;
03.GTIN/PLU;
04.C¢digo do Produto;
05.Descri‡Æo;
06.Qtd;
07.C. Bruto da Compra;
08.C. L¡quido da Compra;
09.Pre‡o Normal;
10.Markup;
11.Custo PMZ;
12.Markup sobre custo PMZ;
13.Pre‡o sugerido;
14.Mg. Loja;
15.Mg. L¡q.;
16.Mg. PadrÆo;
17.CFOP
*/
