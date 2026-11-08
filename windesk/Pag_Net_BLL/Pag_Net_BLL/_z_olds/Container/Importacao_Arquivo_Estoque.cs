using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;


namespace Pag_Net.Bll.Container
{
    public class Importacao_Arquivo_Estoque
    {
        //Publics
        
        public int LinhaInicial = 0;
        public List<string> _logResult;
        public int LinhasProcessadas = 0;
        public int LinhasNaoValidada = 0;
        //Privates
        public Pag_Net.Tools.ManagerFileInfo ArquivoDeEstoque;
        private Pag_Net.Tools.ManagerFile _ManagerFile;


      
        int NCol_DescricaoImportacao = 0;
        int NCol_CdProdutoBlueSoft = 1;
        int NCol_CodigoBarra = 2;
        int NCol_Fornecedor = 3;
        int NCol_EmbalagemEstoqueQtde = 5;
        int NCol_ValorCustoBruto = 6;
        int NCol_ValorCustoLiquido = 7;


        DataTable Result;

        public Importacao_Arquivo_Estoque()
        {
            ArquivoDeEstoque = new Pag_Net.Tools.ManagerFileInfo();
            _ManagerFile = new Pag_Net.Tools.ManagerFile();
        }


        

        public DataTable Import(string ArquivoEstoque)
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

                if (!File.Exists(ArquivoEstoque))
                {
                    _logResult.Add("Arquivo " + ArquivoEstoque + " Não existe no caminho indicado");
                    _logResult.Add("");
                    _logResult.Add("");
                    _logResult.Add("");
                }
                else
                {
                    System.IO.FileInfo ObjIoFileEstoque = new FileInfo(ArquivoEstoque);
                    ObjIoFileEstoque.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                    ArquivoDeEstoque = _ManagerFile.FileOut(ObjIoFileEstoque);
                    ArquivoDeEstoque.TipoArquivo = "ESTOQUE";
                    Result = FileRead();
                    
                }
                return Result;
            }
            catch (Exception ex)
            {
                _logResult.Add("Inicialização do Processamento: " + ex.Message);
                return Result; 
            }
        }

        private DataTable FileRead()
        {
            int i = 0;
            string[] linhas = Pag_Net.Tools.LogFile.ReadLine(ArquivoDeEstoque.FileName);
            DataTable dt = new DataTable("TabTxt");
            try
            {
                dt.Columns.Add("NumeroLinha", typeof(Int32));
                dt.Columns.Add("Valid", typeof(Boolean));
                dt.Columns.Add("Content", typeof(String));
                dt.Columns.Add("DescricaoImportacao", typeof(String));
                dt.Columns.Add("CdProdutoBlueSoft", typeof(Int32));
                dt.Columns.Add("CodigoBarra", typeof(String));
                dt.Columns.Add("Fornecedor", typeof(String));
                dt.Columns.Add("EmbalagemEstoqueQtde", typeof(Decimal));
                dt.Columns.Add("ValorCustoBruto", typeof(Decimal));
                dt.Columns.Add("ValorCustoLiquido", typeof(Decimal));

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
                                row["DescricaoImportacao"] = colunas[NCol_DescricaoImportacao].ToString();
                                row["CdProdutoBlueSoft"] = Convert.ToInt32(colunas[NCol_CdProdutoBlueSoft]);
                                row["CodigoBarra"] = colunas[NCol_CodigoBarra].ToString();
                                row["Fornecedor"] = colunas[NCol_Fornecedor].ToString();
                                row["EmbalagemEstoqueQtde"] = Convert.ToDouble(colunas[NCol_EmbalagemEstoqueQtde]);
                                row["ValorCustoBruto"] = Convert.ToDouble(colunas[NCol_ValorCustoBruto]);
                                row["ValorCustoLiquido"] = Convert.ToDouble(colunas[NCol_ValorCustoLiquido]);
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
                _logResult.Add("Linha N.: " + i.ToString() + " Conteúdo [" + linhas[i].ToString() + "] Erro: " + ex.Message);
                _logResult.Add("");
                return dt;
            }
            
        }

        private bool ValidLinha(string[] linha, int NumeroLinha, string Content)
        {

            try
            {
                bool valid = true;

                if (linha[NCol_DescricaoImportacao].Length < 1)
                {
                    valid = false;
                    _logResult.Add("Linha N.: " + NumeroLinha.ToString() + " Conteúdo [" + Content + "] Erro: Número de caracteres na descrição menor que 1");
                    _logResult.Add("");
                }
                double valida_qtde = Convert.ToDouble(linha[NCol_EmbalagemEstoqueQtde]);
                double valida_CustoBruto = Convert.ToDouble(linha[NCol_ValorCustoBruto]);
                double valida_CustoLiquido = Convert.ToDouble(linha[NCol_ValorCustoLiquido]);
                int CdProdutoBlueSoft = Convert.ToInt32(linha[NCol_CdProdutoBlueSoft]);

                return valid;
            }
            catch (Exception ex)
            {
                _logResult.Add("Linha N.: " + NumeroLinha.ToString() + " Conteúdo [" + Content + "] Erro" +   ex.Message);
                _logResult.Add("");
                return false;
            }


        }

    }
}
