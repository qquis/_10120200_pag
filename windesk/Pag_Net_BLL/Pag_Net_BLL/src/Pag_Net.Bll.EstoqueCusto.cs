using Pag_Net.Bll.Precos.Db;
using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.EstoqueCusto
{
    public static class Consulta
    {
        public static DataTable list(Pag_Net.Models.modelSistemaUsuario _myConnect, F0020_Produto.Defaut_Filter Filter_Produto, int _tab_pre_cd, bool _SelectionaDataCustoEntrada, DateTime _DataCustoEntradaInicial, DateTime _DataCustoEntradaFinal)
        {
            try
            {
                return Pag_Net.Bll.R0030.Select.get(_myConnect, Filter_Produto, _tab_pre_cd, _SelectionaDataCustoEntrada, _DataCustoEntradaInicial, _DataCustoEntradaFinal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
   
        }
    }

    public static class CustoEntrada
    {
        public static void Atualizar(
                    Pag_Net.Models.modelSistemaUsuario MyConnect
            ,       int pr_cdproduto
            ,       double valor_custo_precificacao
            )
        {

            MyConnect.SEQUENCIAL_DE_PROCESSO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(MyConnect, 201101);


            DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
            BDExecute.Execute(Pag_Net.Bll.BDCommand.ScriptSql_POST(BDCommand.Name.F0030_01_TbEstoqueCusto_CRUD, Pag_Net.Bll.F0030.Postgres.Post(
                "0030_01_VLPREC",
                false,
                new F0030.Db(
                    MyConnect.SEQUENCIAL_DE_PROCESSO,
                    pr_cdproduto,
                    0,
                    0,
                    0,
                    valor_custo_precificacao, 0, 0, 0, 0, 0)
                    )
                ), null, DataBaseName.ODBCOXAN);
        }
    }

    public static class ArquivoEntrada
    {
        public static void Importar(Pag_Net.Models.modelSistemaUsuario MyConnect, string ArquivoEntrada)
        {

            char[] delimiterChars = { ';' };
            int NCol_DataEntrada = 0;
            //int NCol_Fornecedor = 1;
            int NCol_NumeroDocumentoFiscal = 2;
            int NCol_CodigoBarra = 3;
            int NCol_CdProdutoBlueSoft = 4;
            int NCol_DescricaoImportacao = 5;
            int NCol_EmbalagemEstoqueQtde = 6;
            int NCol_ValorCustoBruto = 7;
            int NCol_ValorCustoLiquido = 8;
            int NCol_CFOP = 17;

            int         eci_prb_cdprodutobluesoft = 0;
            string      eci_descricao = "";
            string      eci_cdbarra = "";
            int         eci_nf_numero = 0;
            string      eci_nf_numero_serie = "";
            DateTime    eci_nf_data_entrada = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            double      eci_embalagemestoque_qtde = 0;
            double      eci_valorcustobruto = 0;
            double      eci_valorcustoliquido = 0;
            string      CFOP = "";

            try
            {
                int SeqARQUIVO = Pag_Net.Bll.Tools.ImportTXT.get(MyConnect, ArquivoEntrada);
                DataTable Linhas = Pag_Net.Bll.R001301.Select.get(MyConnect, SeqARQUIVO);
                foreach (DataRow i in Linhas.Rows)
                {

                    eci_prb_cdprodutobluesoft = 0;
                    eci_descricao = "";
                    eci_cdbarra = "";
                    eci_nf_numero = 0;
                    eci_nf_numero_serie = "";
                    eci_nf_data_entrada = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    eci_embalagemestoque_qtde = 0;
                    eci_valorcustobruto = 0;
                    eci_valorcustoliquido = 0;
                    CFOP = "";


                    string __LINHA = i["proc_log_arquivo_linha"].ToString();
                    string[] _COLUNAS = __LINHA.Split(delimiterChars);
                    string _ERRO = "";
                    bool _PROCESSAR = false;
                    try
                    {

                        _ERRO = "Código do Produto Inválido";
                        eci_prb_cdprodutobluesoft = Convert.ToInt32(_COLUNAS[NCol_CdProdutoBlueSoft]);

                        _ERRO = "Descrição Inválida";
                        eci_descricao = _COLUNAS[NCol_DescricaoImportacao];

                        _ERRO = "Código de Barra Inválido";
                        eci_cdbarra = Convert.ToDouble(_COLUNAS[NCol_CodigoBarra]).ToString();
                        _ERRO = "Nota Fiscal Inválida";
                        string _formata_nf = _COLUNAS[NCol_NumeroDocumentoFiscal].TrimEnd();
                        int _formata_nf_caracter =  _formata_nf.IndexOf("-");
                        eci_nf_numero = Convert.ToInt32(_formata_nf.Substring(0, _formata_nf_caracter));
                        eci_nf_numero_serie = _formata_nf.Substring(_formata_nf_caracter + 1, _formata_nf.Length - (_formata_nf_caracter + 1));
                        _ERRO = "Data de Entrada Inválida";
                        eci_nf_data_entrada = Convert.ToDateTime(_COLUNAS[NCol_DataEntrada]);
                        _ERRO = "Qtde Inválida";
                        eci_embalagemestoque_qtde = Convert.ToDouble(_COLUNAS[NCol_EmbalagemEstoqueQtde].Replace(",","."));
                        _ERRO = "Valor Custo Bruto Inválido";
                        eci_valorcustobruto = Convert.ToDouble(_COLUNAS[NCol_ValorCustoBruto]);
                        _ERRO = "Valor Custo líquido";
                        eci_valorcustoliquido = Convert.ToDouble(_COLUNAS[NCol_ValorCustoLiquido]);
                        CFOP = _COLUNAS[NCol_CFOP].Replace(".","");
                        _ERRO = "";

  
                        /*
                        ,	eci_nf_numero						int
                        ,	eci_nf_numero_serie					varchar(10)
                        ,	eci_nf_data_entrada					date 
                        ,	eci_embalagemestoque_qtde			numeric(17,4) 
                        ,	eci_valorcustobruto 				numeric(17,4)
                        ,	eci_valorcustoliquido				numeric(17,4)
                        ,	CFOP 								varchar(4) 

                         * */
                        _PROCESSAR = true;
                    }
                    catch (Exception ex)
                    {

                        _ERRO = _ERRO + " | " + ex.Message;
                        _PROCESSAR = false;

                        if (!_PROCESSAR)
                        {
                            Pag_Net.Bll.F0120.Postgres.CRUD(
                                MyConnect,
                                SeqARQUIVO,
                                Convert.ToInt32(i["proc_log_arquivo_linha_seq"].ToString()),
                                eci_prb_cdprodutobluesoft,
                                eci_descricao,
                                eci_cdbarra,
                                eci_nf_numero,
                                eci_nf_numero_serie,
                                eci_nf_data_entrada,
                                eci_embalagemestoque_qtde,
                                eci_valorcustobruto,
                                eci_valorcustoliquido,
                                CFOP,
                                0,
                                _ERRO.ToString()
                                );
                        }

                        continue;
                    }

                    if (_PROCESSAR)
                    {
                        Pag_Net.Bll.F0120.Postgres.CRUD(
                            MyConnect,
                            SeqARQUIVO,
                                                          Convert.ToInt32(i["proc_log_arquivo_linha_seq"].ToString()),
                                eci_prb_cdprodutobluesoft,
                                eci_descricao,
                                eci_cdbarra,
                                eci_nf_numero,
                                eci_nf_numero_serie,
                                eci_nf_data_entrada,
                                eci_embalagemestoque_qtde,
                                eci_valorcustobruto,
                                eci_valorcustoliquido,
                                CFOP,
                            1,
                            "Processamento Realizado com Sucesso");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Processar(Pag_Net.Models.modelSistemaUsuario MyConnect, int vproc_log_seq)
        {
            Pag_Net.Bll.F0121.Postgres.CRUD(MyConnect, vproc_log_seq);
        }
        public static DataTable List(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            return Pag_Net.Bll.R001300.Select.get(MyConnect, 0, 200101, 0);

        }
        public static DataTable Linhas(Pag_Net.Models.modelSistemaUsuario MyConnect, int SEQ_ARQUIVO)
        {
            try
            {
                return Pag_Net.Bll.R0031.Select.get(MyConnect, SEQ_ARQUIVO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

    public static class Entradas
    {
        public static DataTable List(                
            Pag_Net.Models.modelSistemaUsuario MyConnect,
    		Pag_Net.Bll.R0031_01.Parametros _Parametros 
            )
        {
            try {
                return Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, Pag_Net.Bll.R0031_01.Postgres.Get(_Parametros));
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
       
}
