using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0030_EstoqueCusto;

namespace Pag_Net.Bll.F0030_EstoqueCusto
{
    public class Wk
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Filter_Custo_Select Filter;
        public model_estoquecusto[] List;

        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Filter = new Filter_Custo_Select();
        }

        public model_estoquecusto[] EstoqueCusto_List_get()
        {
            try
            {
                List<model_estoquecusto> list = new List<model_estoquecusto>();

                DataTable Dt = BDCommand.get_DataTable(MyConnect, F0030_50_EstoqueCusto_list.Get(Filter));
                
                foreach(DataRow row in Dt.Rows)
                {
                    model_estoquecusto item = new model_estoquecusto();
                    item.model_estoquecusto_DataBinding(row, Dt.Columns);
                    list.Add(item);
                    
                }
                List = list.ToArray();
                return List;
                

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0030_EstoqueCusto | EstoqueCusto_List_get: " + ex.Message);
            }
        }

        public model_EstoqueCusto_Receita[] Consultar_Receitas (int pr_cdproduto)
        {
            try
            {
                DataTable DTG = BDCommand.get_DataTable(MyConnect, F0030_51_EstoqueCusto_Receita_list.Get(pr_cdproduto));
                List<model_EstoqueCusto_Receita> list = new List<model_EstoqueCusto_Receita>();
                foreach(DataRow i in  DTG.Rows)
                {
                    model_EstoqueCusto_Receita item = new model_EstoqueCusto_Receita();
                    item.EstoqueCusto_Receita_DataBinding(i);
                    list.Add(item);

                }

                return list.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


    public static class Service
    {

        public static void F0030_90_EstoqueCustosDiario_Processar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Pag_Net.Bll.Log.register(MyConnect, 3090, "F0030_90 Estoque Custo Diario", "<INICIO> Atualização Diária ");
                Pag_Net.Bll.BDCommand.Execute(MyConnect, Pag_Net.Bll.F0030_EstoqueCusto.F0030_10_EstoqueCustoDiario_Processamento.Post());
                Pag_Net.Bll.Log.register(MyConnect, 3090, "F0030_90 Estoque Custo Diario", "<FIM> Atualização Diária ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public static void F0030_91_EstoqueCustos_Processar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Pag_Net.Bll.Log.register(MyConnect, 3091, "F0030_91 Estoque Custo", "<INICIO> Atualização ");
                Pag_Net.Bll.BDCommand.Execute(MyConnect, BDCommand.Name.F0030_91_EstoqueCusto_Processamento);
                Pag_Net.Bll.Log.register(MyConnect, 3091, "F0030_91 Estoque Custo", "<FIM> Atualização ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void F0030_10_EstoqueCustosDiario_Importar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

            int _sis_nucleo_prc_cd = 3010;
            string _Command_All = "";
            int _SEQ_UPDATE = 0;
            int _SEQ_COUNT = 0;
            int _COUNT = 0;
            DbUpdate BDExecute;
            BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);


            string ErroInfo = "";
            try
            {

                DataSet DtSet_EstoqueCustoDiarioBlueSoft = new DataSet();

                DtSet_EstoqueCustoDiarioBlueSoft = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, F0030_EstoqueCusto.F0030_10_EstoqueCustoDiarioBlueSoft_CRUD.RedShift_Select(), "");

                _COUNT = DtSet_EstoqueCustoDiarioBlueSoft.Tables[0].Rows.Count;

                foreach (DataRow dr in DtSet_EstoqueCustoDiarioBlueSoft.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr["prb_cdprodutobluesoft"];
                    try
                    {
                        _Command_All = _Command_All + Pag_Net.Bll.F0030_EstoqueCusto.F0030_10_EstoqueCustoDiarioBlueSoft_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, new TbEstoqueCusto_DiarioBlueSoft(dr)) + ";";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 500 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "Estoque Diário", string.Format("REG {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("F0030_10_EstoqueCustosDiario_Importar - " + ErroInfo + " - " + ex.Message);
            }
        }
    }

    public class Filter_Custo_Select
    {
        public int CdProduto { get; set; }
        public int CdProdutoBluesoft { get; set; }
        public int Seleciona_Data_Cadastro { get; set; }
        public DateTime Dt_cadastro_ini { get; set; }
        public DateTime Dt_cadastro_fim { get; set; }
        public string Descricao { get; set; }
        public string Descricao_Fiscal { get; set; }
        public int Status_Ativo { get; set; }
        public int Status_Inativo { get; set; }
        public int Prd_cddepartamento { get; set; }
        public int Prd_cdsecao { get; set; }
        public int Prd_cdgrupo { get; set; }
        public int Prd_subcdgrupo { get; set; }
        public int Tab_pre_cd { get; set; }
        public int SelecionaDataEntradaCusto { get; set; }
        public DateTime DataEntradaCusto_Inicial { get; set; }
        public DateTime DataEntradaCusto_Final { get; set; }
        public Filter_Custo_Select()
        {
            Binding();
        }
        public void Binding()
        {
            CdProduto = 0;
            CdProdutoBluesoft = 0;
            Seleciona_Data_Cadastro = 0;
            Dt_cadastro_ini = Convert.ToDateTime("1900-01-01");
            Dt_cadastro_fim = Convert.ToDateTime("1900-01-01");
            Descricao = "";
            Descricao_Fiscal = "";
            Status_Ativo = 1;
            Status_Inativo = 0;
            Prd_cddepartamento = 0;
            Prd_cdsecao = 0;
            Prd_cdgrupo = 0;
            Prd_subcdgrupo = 0;
            Tab_pre_cd = 0;
            SelecionaDataEntradaCusto = 0;
            DataEntradaCusto_Inicial = Convert.ToDateTime("1900-01-01");
            DataEntradaCusto_Final = Convert.ToDateTime("1900-01-01");
        }


    }


    public class model_estoquecusto: TbEstoqueCusto
    {
        public int prb_cdprodutobluesoft { get; set; }
        public string pr_descricao {get; set; }
        public string pr_embalagemestoque { get; set;  }
        public double ec_valor_custo_precificacao_margem { get; set;  }
        public double ec_valor_custo_faturamento_margem { get; set;  }
        public double prc_valor { get; set;  }
        public string pr_cesta_char { get; set; }
        public string prb_tipo_composicao_cd_char { get; set;  }

        public model_EstoqueCusto_Receita[] List_TbEstoqueCusto_Receita { get; set; }
        public double List_TbEstoqueCusto_Receita_PRC_VALOR { get; set; }

        public model_estoquecusto () : base()
        {
            model_estoquecusto_Binding(0);
        }

        public void model_estoquecusto_Binding(int _prb_cdprodutobluesoft)
        {
            prb_cdprodutobluesoft = 0;
            pr_descricao = "";
            pr_embalagemestoque = "";
            prc_valor = 0;
            ec_valor_custo_precificacao_margem = 0;
            ec_valor_custo_faturamento_margem = 0;
            pr_cesta_char = "";
            prb_tipo_composicao_cd_char = "";
            base.EstoqueCusto_Binding();
            
        }

        public void model_estoquecusto_DataBinding(DataRow row, DataColumnCollection colArr)
        {
            try
            {
                base.EstoqueCusto_DataBinding(row, colArr);

                for (int i = 0; i < colArr.Count; i++)
                {
                    if (colArr[i].ColumnName == "prb_cdprodutobluesoft") prb_cdprodutobluesoft = Convert.ToInt32(row["prb_cdprodutobluesoft"].ToString());
                    if (colArr[i].ColumnName == "pr_descricao") pr_descricao = row["pr_descricao"].ToString();
                    if (colArr[i].ColumnName == "pr_cesta_char") pr_cesta_char = row["pr_cesta_char"].ToString();
                    if (colArr[i].ColumnName == "prb_tipo_composicao_cd_char") prb_tipo_composicao_cd_char = row["prb_tipo_composicao_cd_char"].ToString();
                    if (colArr[i].ColumnName == "pr_embalagemestoque") pr_embalagemestoque = row["pr_embalagemestoque"].ToString();
                    if (colArr[i].ColumnName == "prc_valor") prc_valor = Convert.ToDouble(row["prc_valor"].ToString());
                    if (colArr[i].ColumnName == "ec_valor_custo_precificacao_margem") ec_valor_custo_precificacao_margem = Convert.ToDouble(row["ec_valor_custo_precificacao_margem"].ToString());
                    if (colArr[i].ColumnName == "ec_valor_custo_faturamento_margem") ec_valor_custo_faturamento_margem = Convert.ToDouble(row["ec_valor_custo_faturamento_margem"].ToString());
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void model_estoquecusto_DataBinding(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Filter_Custo_Select Filter = new Filter_Custo_Select();
                Filter.CdProduto = this.pr_cdproduto;
                DataTable Dt = BDCommand.get_DataTable(MyConnect, F0030_50_EstoqueCusto_list.Get(Filter));
                this.model_estoquecusto_DataBinding(Dt.Rows[0], Dt.Columns);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CustoReceita_DataBinding(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            DataTable dt = BDCommand.get_DataTable(MyConnect, F0030_51_EstoqueCusto_Receita_list.Get(this.pr_cdproduto));
            List<model_EstoqueCusto_Receita> lst = new List<model_EstoqueCusto_Receita>();
            foreach(DataRow row in dt.Rows)
            {
                model_EstoqueCusto_Receita item = new model_EstoqueCusto_Receita();
                item.model_EstoqueCusto_Receita_DataBinding(row);
                lst.Add(item);
            }
            List_TbEstoqueCusto_Receita = lst.ToArray();
        }

        public model_EstoqueCusto_Receita CustoReceita_Item_new(Pag_Net.Models.modelSistemaUsuario MyConnect, int __prb_cdprodutobluesoft)
        {
            try
            {
                Pag_Net.src.F0020_Produto.tbs.TbProduto TbProdutoInformacao = new F0020_Produto.Model_Produto();
                Pag_Net.Bll.F0020_Produto.WkProduto WKProduto = new F0020_Produto.WkProduto(MyConnect);
                WKProduto.filters_produto.CdProdutoBluesoft = __prb_cdprodutobluesoft.ToString();
                WKProduto.Consultar();
                
                model_EstoqueCusto_Receita model_EstoqueCusto_Receita_new = new model_EstoqueCusto_Receita();
                model_EstoqueCusto_Receita_new.pr_cdproduto = this.pr_cdproduto; 
                model_EstoqueCusto_Receita_new.pr_descricao = WKProduto.Dt_Produto[0].pr_descricao.ToString();
                model_EstoqueCusto_Receita_new.prb_cdprodutobluesoft = WKProduto.Dt_Produto[0].prb_cdprodutobluesoft;
                model_EstoqueCusto_Receita_new.ecr_peso_total_item = WKProduto.Dt_Produto[0].prb_pesoliquido;

                model_estoquecusto ITEM_CUSTO = new model_estoquecusto();
                ITEM_CUSTO.pr_cdproduto = WKProduto.Dt_Produto[0].pr_cdproduto;
                ITEM_CUSTO.model_estoquecusto_DataBinding(MyConnect);
                model_EstoqueCusto_Receita_new.ecr_valor_custo_comercial = ITEM_CUSTO.ec_valor_custo_precificacao;
                model_EstoqueCusto_Receita_new.ecr_valor_custo_precificacao = ITEM_CUSTO.ec_valor_custo_precificacao;
                model_EstoqueCusto_Receita_new.ecr_valor_custo_faturamento = ITEM_CUSTO.ec_valor_custo_faturamento;

                return model_EstoqueCusto_Receita_new;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
                
            
        }

        public void _List_TbEstoqueCusto_Receita_Add(model_EstoqueCusto_Receita _item)
        {
            try
            {
                List<model_EstoqueCusto_Receita> _LIST = new List<model_EstoqueCusto_Receita>();
                List_TbEstoqueCusto_Receita_PRC_VALOR = 0;

                if (_item.ecr_valor_custo <= 0)
                    throw new Exception("Favor indicar o valor do custo");

                if (List_TbEstoqueCusto_Receita != null)
                {
                    if (List_TbEstoqueCusto_Receita.Count() > 0)
                    {
                        foreach (model_EstoqueCusto_Receita i in List_TbEstoqueCusto_Receita)
                        {
                            _LIST.Add(i);
                            List_TbEstoqueCusto_Receita_PRC_VALOR += i.ecr_valor_custo;
                        }
                    }
                }
                List_TbEstoqueCusto_Receita_PRC_VALOR += _item.ecr_valor_custo;
                _LIST.Add(_item);

                

                List_TbEstoqueCusto_Receita = _LIST.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void _List_TbEstoqueCusto_Efetivar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                /* Exclur lista atual */
                string SQL_Excluir_Lista = "Delete from tbestoquecusto_receita where pr_cdproduto = " + this.pr_cdproduto;
                BDCommand.Execute(MyConnect, SQL_Excluir_Lista);

                /* Incluir nova lista */
                foreach (model_EstoqueCusto_Receita item in List_TbEstoqueCusto_Receita)
                {
                    item._INSERT(MyConnect);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class model_EstoqueCusto_Receita: TbEstoqueCusto_Receita
    {
        public string pr_descricao { get; set; }
        public model_EstoqueCusto_Receita() : base() {}


        public void model_EstoqueCusto_Receita_DataBinding(DataRow i)
        {
            pr_descricao = i["pr_descricao"].ToString();
            base.EstoqueCusto_Receita_DataBinding(i);
        }


    }
    
}
