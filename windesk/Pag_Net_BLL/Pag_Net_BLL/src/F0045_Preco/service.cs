using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.src.F0045_Preco.model;
using System.Data;

using Pag_Net.Bll.Operacionais.Varejo.Execucao;
using Pag_Net.Bll;

namespace Pag_Net.src.F0045_Preco.service
{
    public class Manutencao
    {

        public Pag_Net.Models.modelSistemaUsuario Myconnect;

        public Pag_Net.Bll.F0020_Produto.Defaut_Filter Filter_Produto;

        public int Tab_pre_cd { get; set; }
        public bool Agendamento_Consulta { get; set; }
        public DateTime Data_Agendamento { get; set; }
        public bool PrecoDefinitivo { get; set; }

        public bool Seleciona_Data_Mov_Entrada;
        public DateTime Dt_data_entrada_ini;
        public DateTime Dt_data_entrada_fim;

        private bool _orderbyCrecente;
        public model_preco[] Precos;
        public model_preco[] Precos_Unitarios;
        public model_preco[] Precos_Embalagens;
        public bool ExisteAlteracaoDePrecoPendente;
        public bool AlterarPrecoEmbalagensPesoFilhos;
        public double MargemMedia;
        public model_preco[] PrecosAlterados { get; set; }
        public Int16 Pr_status_comercial_preco_inativo = 0;

        public int Tipo_Visualizacao;


        public Manutencao(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            Myconnect = _myConnect;
            Filter_Produto = new Pag_Net.Bll.F0020_Produto.Defaut_Filter();
            Filter_Produto.Dt_cadastro_ini = Convert.ToDateTime("1900-01-01");
            Filter_Produto.Dt_cadastro_fim = Convert.ToDateTime("1900-01-01");
            ExisteAlteracaoDePrecoPendente = false;
            _orderbyCrecente = false;
        }

        public DataTable TabelasPrecosOperacionais()
        {
            return Pag_Net.R0023.Bll.Select.get_DataTable(Myconnect);
        }

        public void ConsultarPrecos()
        {
            try
            {
                Filter_Produto._ValidarFiltros();
                List<model_preco> _list_produto = new List<model_preco>();
                List<model_preco> _list_produto_preco_Unitario = new List<model_preco>();

                DataTable _dataTable_produto_preco = Pag_Net.Bll.BDCommand.get_DataTable(Myconnect,scripts.f0045_05_Report_ConsultarPreco.Get(
                                              Myconnect,
                                              Convert.ToInt32(Filter_Produto.CdProduto)
                                            , Convert.ToInt32(Filter_Produto.CdProdutoBluesoft)
                                            , Filter_Produto.Seleciona_Data_Cadastro
                                            , Filter_Produto.Dt_cadastro_ini
                                            , Filter_Produto.Dt_cadastro_fim
                                            , Filter_Produto.Descricao
                                            , Filter_Produto.Descricao_Fiscal
                                            , Filter_Produto.Status_Ativo
                                            , Filter_Produto.Status_Inativo
                                            , Filter_Produto.Prd_cddepartamento
                                            , Filter_Produto.Prd_cdsecao
                                            , Filter_Produto.Prd_cdgrupo
                                            , Filter_Produto.Prd_subcdgrupo
                                            , Tab_pre_cd
                                            , Agendamento_Consulta
                                            , Data_Agendamento
                                            , Seleciona_Data_Mov_Entrada
                                            , Dt_data_entrada_ini
                                            , Dt_data_entrada_fim
                                            , Pr_status_comercial_preco_inativo
                                            , Tipo_Visualizacao
                    ));
                /*
                DataTable _dataTable_produto_preco = Pag_Net.R0021.Bll.Select.get(Myconnect,
                                               Convert.ToInt32(Filter_Produto.CdProduto)
                                            , Convert.ToInt32(Filter_Produto.CdProdutoBluesoft)
                                            , Filter_Produto.Seleciona_Data_Cadastro
                                            , Filter_Produto.Dt_cadastro_ini
                                            , Filter_Produto.Dt_cadastro_fim
                                            , Filter_Produto.Descricao
                                            , Filter_Produto.Descricao_Fiscal
                                            , Filter_Produto.Status_Ativo
                                            , Filter_Produto.Status_Inativo
                                            , Filter_Produto.Prd_cddepartamento
                                            , Filter_Produto.Prd_cdsecao
                                            , Filter_Produto.Prd_cdgrupo
                                            , Filter_Produto.Prd_subcdgrupo
                                            , Tab_pre_cd
                                            , Agendamento_Consulta
                                            , Data_Agendamento
                                            , Seleciona_Data_Mov_Entrada 
                                            , Dt_data_entrada_ini  
                                            , Dt_data_entrada_fim
                                            );*/

                foreach (DataRow dr in _dataTable_produto_preco.Rows)
                {
                    model_preco _produto_preco = new model_preco(dr);
                    _list_produto.Add(_produto_preco);
                    if (_produto_preco.local_MARGEM_PRECIFICACAO > 0)
                        MargemMedia = MargemMedia + _produto_preco.local_MARGEM_PRECIFICACAO;

                }

                MargemMedia = MargemMedia / Convert.ToDouble(_dataTable_produto_preco.Rows.Count);

                Precos = _list_produto.ToArray();
                Precos_Unitarios = Array.FindAll(Precos, dados => dados.prb_cdprodutobluesoft == dados.prb_cdprodutobluesoft_unitario);


            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.layer_produto_precos.ConsultarPrecos + " + ex.Message.ToString());
            }

        }

        public void ConsultarPrecosEmbalagens(model_preco item)
        {
            Precos_Embalagens = Array.FindAll(Precos, dados => dados.prb_cdprodutobluesoft != dados.prb_cdprodutobluesoft_unitario
                                                                        && dados.prb_cdprodutobluesoft_unitario == item.prb_cdprodutobluesoft_unitario);
        }

        public void ConsultarPrecos_FiltroGRID(string _DESCRICAO, bool _Sem_Preco, bool _Com_Preco, bool _Com_Estoque)
        {

            Precos_Unitarios = Array.FindAll(Precos, dados => dados.prb_cdprodutobluesoft == dados.prb_cdprodutobluesoft_unitario);
            Precos_Unitarios = Array.FindAll(Precos_Unitarios, dados => dados.pr_descricao.Contains(_DESCRICAO));

            if (_Sem_Preco)
                Precos_Unitarios = Array.FindAll(Precos_Unitarios, dados => dados.local_PRECO_ALTERADO == 0);

            if (_Com_Preco)
                Precos_Unitarios = Array.FindAll(Precos_Unitarios, dados => dados.local_PRECO_ALTERADO > 0);

            if (_Com_Estoque)
                Precos_Unitarios = Array.FindAll(Precos_Unitarios, dados => dados.ec_embalagemestoque_qtde != 0);


            /*
            if (_Com_Preco)
            {
                Precos_Unitarios = Array.FindAll(Precos, dados => dados.prb_cdprodutobluesoft == dados.prb_cdprodutobluesoft_unitario);
                Precos_Unitarios = Array.FindAll(Precos_Unitarios, dados => dados.local_PRECO_ALTERADO != 0);
                Precos_Unitarios = Array.FindAll(Precos_Unitarios, dados => dados.pr_descricao.Contains(_DESCRICAO));
            }
            else
            {
                Precos_Unitarios = Array.FindAll(Precos, dados => dados.prb_cdprodutobluesoft == dados.prb_cdprodutobluesoft_unitario);
                Precos_Unitarios = Array.FindAll(Precos_Unitarios, dados => dados.pr_descricao.Contains(_DESCRICAO));
            }*/


        }

        public void ConsultarPrecos_ComValor(bool Ativo)
        {
            if (Ativo)
            {
                Precos_Unitarios = Array.FindAll(Precos, dados => dados.prb_cdprodutobluesoft == dados.prb_cdprodutobluesoft_unitario);
                Precos_Unitarios = Array.FindAll(Precos_Unitarios, dados => dados.local_PRECO_ALTERADO != 0);
            }
            else
            {
                Precos_Unitarios = Array.FindAll(Precos, dados => dados.prb_cdprodutobluesoft == dados.prb_cdprodutobluesoft_unitario);
            }

        }

        public void ConsultarPrecosAlterados()
        {
            try
            {
                PrecosAlterados = Array.FindAll(Precos, dados => dados.local_ITEM_ALTERADO == true);
            }
            catch (Exception)
            {
                throw new Exception("Não há itens alterados");
            }

        }

        public void AlterarPreco(model_preco item, model_preco itemUnitario)
        {



            int _Array_Precos_INDEX_PRODUTO_ALTERADO = Array.FindIndex(Precos, X => X.prb_cdprodutobluesoft == item.prb_cdprodutobluesoft);

            if (item.prb_cdprodutobluesoft == item.prb_cdprodutobluesoft_unitario)
            {
                Precos[_Array_Precos_INDEX_PRODUTO_ALTERADO].local_PRECO_ALTERADO = item.local_PRECO_ALTERADO;
            }
            else
            {
                if (Agendamento_Consulta == false)
                {
                    item._local_FATORPRECO_ALTERADO = Math.Round(item.local_PRECO_ALTERADO / (itemUnitario.local_PRECO_ALTERADO * item.pre_fatorestoque), 4);
                    Precos[_Array_Precos_INDEX_PRODUTO_ALTERADO]._local_FATORPRECO_ALTERADO = item._local_FATORPRECO_ALTERADO;
                }

                Precos[_Array_Precos_INDEX_PRODUTO_ALTERADO].local_PRECO_ALTERADO = item.local_PRECO_ALTERADO;

            }

            if (item.pr_embalagemestoque.ToUpper().Trim() == "UN" || (item.pr_embalagemestoque.ToUpper().Trim() == "KG" && AlterarPrecoEmbalagensPesoFilhos == false))
            {
                if (item.prb_cdprodutobluesoft == item.prb_cdprodutobluesoft_unitario)
                {
                    foreach (model_preco item_embalagem in Precos_Embalagens)
                    {
                        _Array_Precos_INDEX_PRODUTO_ALTERADO = Array.FindIndex(Precos, X => X.prb_cdprodutobluesoft == item_embalagem.prb_cdprodutobluesoft);
                        Precos[_Array_Precos_INDEX_PRODUTO_ALTERADO].local_PRECO_ALTERADO = item.local_PRECO_ALTERADO * item_embalagem.pre_fatorestoque * item_embalagem.pre_fatorpreco;
                        item_embalagem.local_PRECO_ALTERADO = Precos[_Array_Precos_INDEX_PRODUTO_ALTERADO].local_PRECO_ALTERADO;
                    }
                }
            }

            item.local_MARGEM_PRECIFICACAO = Math.Round((item.local_PRECO_ALTERADO - item.ec_valor_custo_precificacao) / item.local_PRECO_ALTERADO * 100, 2);

            if (item.prc_valor != item.local_PRECO_ALTERADO || item.prc_qtde_promocional != item.LOCAL_prc_qtde_promocional || item.prc_valor_promocional != item.LOCAL_prc_valor_promocional || item.pre_fatorpreco != item._local_FATORPRECO_ALTERADO)
            {
                ExisteAlteracaoDePrecoPendente = true;
            }

        }

        public void AlterarMargem(model_preco item, model_preco itemUnitario)
        {
            double valor_margem = 0;
            double valor_preco = 0;

            valor_margem = item.local_MARGEM_PRECIFICACAO;
            if (valor_margem <= 0)
            {
                valor_preco = item.ec_valor_custo_precificacao;
            }

            if (valor_margem >= 0)
            {
                valor_preco = item.ec_valor_custo_precificacao / (1 - (valor_margem / 100));
            }
            item.local_PRECO_ALTERADO = valor_preco;
        }

        private void AlterarFatorDePreco(model_preco item)
        {
            Pag_Net.F0016.Bll.Postgres.CRUD(Myconnect, new F0016.Models.f0016_CRUD_TbProdutoEmbalagem(
                                        item.pr_cdproduto,
                                        item.prb_cdprodutobluesoft,
                                        item.pre_embalagem,
                                        item.pre_fatorestoque,
                                        item._local_FATORPRECO_ALTERADO,
                                        true,
                                        ""));
        }

        public void OrderBy(string _columnName)
        {
            if (_orderbyCrecente)
            {
                _orderbyCrecente = false;
                switch (_columnName)
                {
                    case "pr_cdproduto":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.pr_cdproduto).ToArray();
                        break;
                    case "prb_cdprodutobluesoft":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.prb_cdprodutobluesoft).ToArray();
                        break;

                    case "prb_cdprodutobluesoft_unitario":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.prb_cdprodutobluesoft_unitario).ToArray();
                        break;
                    case "pr_descricao":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.pr_descricao).ToArray();
                        break;
                    case "pr_status":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.pr_status).ToArray();
                        break;
                    case "pr_embalagemestoque":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.pr_embalagemestoque).ToArray();
                        break;
                    case "pre_embalagem":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.pre_embalagem).ToArray();
                        break;
                    case "pre_fatorestoque":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.pre_fatorestoque).ToArray();
                        break;
                    case "pre_fatorpreco":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.pre_fatorpreco).ToArray();
                        break;
                    case "prc_valor":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.prc_valor).ToArray();
                        break;
                    case "ec_valor_custo_precificacao":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.ec_valor_custo_precificacao).ToArray();
                        break;
                    case "ec_valor_custo_faturamento":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.ec_valor_custo_faturamento).ToArray();
                        break;

                    case "local_MARGEM_MEDIA":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.local_MARGEM_MEDIA).ToArray();
                        break;

                    case "local_PRECO_ALTERADO":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.local_PRECO_ALTERADO).ToArray();
                        break;

                    case "local_MARGEM_PRECIFICACAO":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.local_MARGEM_PRECIFICACAO).ToArray();
                        break;

                    case "LOCAL_prc_qtde_promocional":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.prc_qtde_promocional).ToArray();
                        break;

                    case "LOCAL_prc_valor_promocional":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.prc_valor_promocional).ToArray();
                        break;
                    case "ec_embalagemestoque_qtde":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.ec_embalagemestoque_qtde).ToArray();
                        break;

                    case "LOCAL_prc_margem_promocional":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.LOCAL_prc_margem_promocional).ToArray();
                        break;
                    case "data_ultima_compra":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.data_ultima_compra).ToArray();
                        break;

                    case "data_ultima_venda":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.data_ultima_venda).ToArray();
                        break;
                    case "dias_sem_venda":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.dias_sem_venda).ToArray();
                        break;
                    case "dias_sem_compra":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.dias_sem_compra).ToArray();
                        break;
                    case "est_satual_embalagemestoqueqtde":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.est_satual_embalagemestoqueqtde).ToArray();
                        break;
                    case "calc_est_satual_margem":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.calc_est_satual_margem).ToArray();
                        break;

                    case "calc_est_satual_preco_medio":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.calc_est_satual_preco_medio).ToArray();
                        break;
                    case "est_satual_valortotalfaturamentoliquido":
                        Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.est_satual_valortotalfaturamentoliquido).ToArray();
                        break;
                }


            }
            else
            {
                _orderbyCrecente = true;

                switch (_columnName)
                {
                    case "pr_cdproduto":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.pr_cdproduto).ToArray();
                        break;
                    case "prb_cdprodutobluesoft":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.prb_cdprodutobluesoft).ToArray();
                        break;

                    case "prb_cdprodutobluesoft_unitario":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.prb_cdprodutobluesoft_unitario).ToArray();
                        break;
                    case "pr_descricao":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.pr_descricao).ToArray();
                        break;
                    case "pr_status":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.pr_status).ToArray();
                        break;
                    case "pr_embalagemestoque":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.pr_embalagemestoque).ToArray();
                        break;
                    case "pre_embalagem":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.pre_embalagem).ToArray();
                        break;
                    case "pre_fatorestoque":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.pre_fatorestoque).ToArray();
                        break;
                    case "pre_fatorpreco":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.pre_fatorpreco).ToArray();
                        break;
                    case "prc_valor":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.prc_valor).ToArray();
                        break;
                    case "ec_valor_custo_precificacao":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.ec_valor_custo_precificacao).ToArray();
                        break;
                    case "ec_valor_custo_faturamento":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.ec_valor_custo_faturamento).ToArray();
                        break;

                    case "local_MARGEM_MEDIA":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.local_MARGEM_MEDIA).ToArray();
                        break;

                    case "local_PRECO_ALTERADO":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.local_PRECO_ALTERADO).ToArray();
                        break;

                    case "local_MARGEM_PRECIFICACAO":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.local_MARGEM_PRECIFICACAO).ToArray();
                        break;

                    case "LOCAL_prc_qtde_promocional":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.prc_qtde_promocional).ToArray();
                        break;

                    case "LOCAL_prc_valor_promocional":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.prc_valor_promocional).ToArray();
                        break;
                    case "ec_embalagemestoque_qtde":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.ec_embalagemestoque_qtde).ToArray();
                        break;
                    case "LOCAL_prc_margem_promocional":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.LOCAL_prc_margem_promocional).ToArray();
                        break;
                    case "data_ultima_compra":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.data_ultima_compra).ToArray();
                        break;
                    case "data_ultima_venda":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.data_ultima_venda).ToArray();
                        break;
                    case "dias_sem_venda":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.dias_sem_venda).ToArray();
                        break;
                    case "dias_sem_compra":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.dias_sem_compra).ToArray();
                        break;
                    case "est_satual_embalagemestoqueqtde":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.est_satual_embalagemestoqueqtde).ToArray();
                        break;
                    case "calc_est_satual_margem":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.calc_est_satual_margem).ToArray();
                        break;

                    case "calc_est_satual_preco_medio":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.calc_est_satual_preco_medio).ToArray();
                        break;
                    case "est_satual_valortotalfaturamentoliquido":
                        Precos_Unitarios = Precos_Unitarios.OrderByDescending(c => c.est_satual_valortotalfaturamentoliquido).ToArray();
                        break;
                }
            }




        }

        public void EfetivarAlteracoesDePreco()
        {
            string ErroInfo = "";
            try
            {



                EfetivarAlteracoesDePreco_RegistroItem();
                ExisteAlteracaoDePrecoPendente = false;
                /*ErroInfo = "P0070 | Executando a atualização Geral de Dados de Preços Atuais";
                Pag_Net.Bll.P0070.Process.Execute(Myconnect);*/
                ErroInfo = "P0010 | Log de Produtos - Atualização";
                Pag_Net.Bll.F0010.Postgres.CRUD(Myconnect);
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Precos | EfetivarAlteracoesDePreco: " + ErroInfo + " ->> " + ex.Message);
            }

        }

        private void EfetivarAlteracoesDePreco_RegistroItem()
        {


            try
            {
                if (Data_Agendamento.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    /* PRECIFICAÇÃO VALIDA PARA O DIA */
                    Myconnect.SEQUENCIAL_DE_PROCESSO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(Myconnect, 100101);
                }
                else
                {
                    /* PRECIFICAÇÃO AGENDADA */
                    Myconnect.SEQUENCIAL_DE_PROCESSO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(Myconnect, 100102);
                }

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(Myconnect, DataBaseName.ODBCOXAN);
                int x = 1;
                int seq = 0;
                int count = PrecosAlterados.Count();


                string script_update = "";

                BDExecute = new DbUpdate(Myconnect, DataBaseName.ODBCOXAN);

                foreach (model_preco _item in PrecosAlterados)
                {



                    script_update += scripts.f0045_01_Service_AtualizarPreco.Get(
                                        Myconnect,
                                        Agendamento_Consulta,
                                        Data_Agendamento,
                                        PrecoDefinitivo ? 1 : 0,
                                        _item.pr_cdproduto,
                                        _item.prb_cdprodutobluesoft,
                                        Tab_pre_cd,
                                        _item.local_PRECO_ALTERADO,
                                        _item.LOCAL_prc_valor_promocional == 0 ? 0 : _item.LOCAL_prc_qtde_promocional,
                                        _item.LOCAL_prc_qtde_promocional == 0 ? 0 : _item.LOCAL_prc_valor_promocional,
                                        _item._local_FATORPRECO_ALTERADO
                        );

                    Pag_Net.src.F0095_Integracao.model.modelintegracao_produto itemIntegracao = new F0095_Integracao.model.modelintegracao_produto();
                    itemIntegracao.pr_cdproduto = _item.pr_cdproduto;
                    itemIntegracao.prb_cdprodutobluesoft = _item.prb_cdprodutobluesoft;
                    itemIntegracao.prb_cdprodutobluesoftunitario = _item.prb_cdprodutobluesoft_unitario;
                    itemIntegracao.integracao_status_cd = 2; //pendente 


                    if (Tab_pre_cd == 1)
                        script_update += itemIntegracao.GetScriptSqlCRUDPendente(F0095_Integracao.integracaoTipoCd.i20004501_export_api_produto_preco_padrao);

                    if (Tab_pre_cd == 2)
                        script_update += itemIntegracao.GetScriptSqlCRUDPendente(F0095_Integracao.integracaoTipoCd.i20004502_export_api_produto_preco_promocional);

                    script_update += itemIntegracao.GetScriptSqlCRUDPendente(F0095_Integracao.integracaoTipoCd.i20008501_export_zanthus_produto);
                    /*
                    BDExecute.Execute(scripts.f0045_01_Service_AtualizarPreco.Get(
                                        Myconnect,
                                        Agendamento_Consulta,
                                        Data_Agendamento,
                                        PrecoDefinitivo ? 1 : 0,
                                        _item.pr_cdproduto,
                                        _item.prb_cdprodutobluesoft,
                                        Tab_pre_cd,
                                        _item.local_PRECO_ALTERADO,
                                        _item.LOCAL_prc_valor_promocional == 0 ? 0 : _item.LOCAL_prc_qtde_promocional,
                                        _item.LOCAL_prc_qtde_promocional == 0 ? 0 : _item.LOCAL_prc_valor_promocional,
                                        _item._local_FATORPRECO_ALTERADO
                        ), null, DataBaseName.ODBCOXAN);*/


                    x = x + 1;
                    seq = seq + 1;

                    if (x > 250 || seq >= count)
                    {

                        BDExecute.Execute(script_update, null, DataBaseName.ODBCOXAN);
                        x = 0;
                        script_update = "";

                        System.Threading.Thread.Sleep(2000);
                    }

                    /*
                    if (seq >= count)
                    {
                        x = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(500);
                    }*/
                }
                BDExecute.Close(DataBaseName.ODBCOXAN);
            }
            catch (Exception e)
            {
                throw new Exception("F0045 PRECO | Atualização de Preços \n " + e.Message);
            }

        }

        public void InativarItemListaComercialPrecos(int pr_cdproduto, bool Inativar)
        {
            try
            {
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(Myconnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(Pag_Net.Bll.F0140_02.Postgre.Post(pr_cdproduto, Inativar ? 1 : 0), null, DataBaseName.ODBCOXAN);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
    public static class Consultar
    {
        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            Pag_Net.Bll.F0020_Produto.Defaut_Filter Filter_Produto,
            int Tab_pre_cd,
            bool Unitario
            )
        {
            return get(MyConnect, Filter_Produto, Tab_pre_cd, Unitario, 0, false);
        }

        public static DataTable get(
        Pag_Net.Models.modelSistemaUsuario MyConnect,
        Pag_Net.Bll.F0020_Produto.Defaut_Filter Filter_Produto,
        int Tab_pre_cd,
        bool Unitario,
        int proc_log_seq
    )
        {
            return get(MyConnect, Filter_Produto, Tab_pre_cd, Unitario, proc_log_seq, false);
        }


        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            Pag_Net.Bll.F0020_Produto.Defaut_Filter Filter_Produto,
            int Tab_pre_cd,
            bool Unitario,
            int proc_log_seq,
            bool ItensComPreco
            )
        {
            try
            {
                return Pag_Net.Bll.R0024.Select.get(MyConnect,
                                                  Convert.ToInt32(Filter_Produto.CdProduto)
                                                , Convert.ToInt32(Filter_Produto.CdProdutoBluesoft)
                                                , Filter_Produto.Seleciona_Data_Cadastro
                                                , Filter_Produto.Dt_cadastro_ini
                                                , Filter_Produto.Dt_cadastro_fim
                                                , Filter_Produto.Descricao
                                                , Filter_Produto.Descricao_Fiscal
                                                , Filter_Produto.Status_Ativo
                                                , Filter_Produto.Status_Inativo
                                                , Filter_Produto.Prd_cddepartamento
                                                , Filter_Produto.Prd_cdsecao
                                                , Filter_Produto.Prd_cdgrupo
                                                , Filter_Produto.Prd_subcdgrupo
                                                , Tab_pre_cd
                                                , Unitario
                                                , proc_log_seq
                                                , ItensComPreco
                                                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public static class TabelasdePrecos
    {
        public static DataTable Get(Pag_Net.Models.modelSistemaUsuario Myconnect)
        {
            try
            {
                return Pag_Net.R0023.Bll.Select.get_DataTable(Myconnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public static class ConsultarAgendamentos
    {
        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            Pag_Net.Bll.F0020_Produto.Defaut_Filter Filter_Produto,
            int Tab_pre_cd,
            bool Unitario
            )
        {
            return get(MyConnect, Filter_Produto, Tab_pre_cd, Unitario, 0, Convert.ToDateTime("1900-01-01"), Convert.ToDateTime("2100-01-01"));
        }



        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            Pag_Net.Bll.F0020_Produto.Defaut_Filter Filter_Produto,
            int Tab_pre_cd,
            bool Unitario,
            int proc_log_seq,
            DateTime dt_agendamento_inicial,
            DateTime dt_agendamento_final
            )
        {
            try
            {
                return Pag_Net.Bll.R0025.Select.get(MyConnect,
                                                  Convert.ToInt32(Filter_Produto.CdProduto)
                                                , Convert.ToInt32(Filter_Produto.CdProdutoBluesoft)
                                                , Filter_Produto.Seleciona_Data_Cadastro
                                                , Filter_Produto.Dt_cadastro_ini
                                                , Filter_Produto.Dt_cadastro_fim
                                                , Filter_Produto.Descricao
                                                , Filter_Produto.Descricao_Fiscal
                                                , Filter_Produto.Status_Ativo
                                                , Filter_Produto.Status_Inativo
                                                , Filter_Produto.Prd_cddepartamento
                                                , Filter_Produto.Prd_cdsecao
                                                , Filter_Produto.Prd_cdgrupo
                                                , Filter_Produto.Prd_subcdgrupo
                                                , Tab_pre_cd
                                                , Unitario
                                                , proc_log_seq
                                                , dt_agendamento_inicial
                                                , dt_agendamento_final
                                                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public static class AplicarAlteracoes
    {
        public static ModelBackEnd_Preco_Aplicar Aplicar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                var BackEndLoginCredenciais = new
                {
                    sis_id = MyConnect.sis_cd,
                    user_name = MyConnect.user_name,
                };

                ModelBackEnd_Preco_Aplicar Resultado = new ModelBackEnd_Preco_Aplicar();
                
                Resultado = Pag_Net.src.F0045_Preco.model.ModelBackEnd_Preco_Aplicar.getJson(MyConnect.apiGet("/preco/service/aplicar?user_name=" + MyConnect.user_name.ToString(), null).ToString());
                return Resultado;
                


                /*
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                BDExecute.Execute("select " + scripts.f0045_60_Produto_Preco_Aplicacao._VERSION() +  "()", null, DataBaseName.ODBCOXAN);
                BDExecute.Commit(DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);
                 */
            }
            catch (Exception EX)
            {
                throw new Exception("Pag_Net.Bll.Precos.Aplicar | " + EX.Message);
            }

        }


    }


}
