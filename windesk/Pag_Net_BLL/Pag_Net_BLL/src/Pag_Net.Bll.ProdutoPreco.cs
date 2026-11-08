/*
 * 31/03/2022[1] - ConsultarPrecos_FiltroGRID | ALTERAÇÃO
 * */

using Pag_Net.Bll.Precos.Db;
using Pag_Net.Tools;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Pag_Net.Bll.Operacionais.Varejo.Execucao;
using Pag_Net.Dal;

namespace Pag_Net.Bll.Precos
{
    public class Manutencao 
    {

        public Pag_Net.Models.modelSistemaUsuario Myconnect;

        public F0020_Produto.Defaut_Filter Filter_Produto;

        public int Tab_pre_cd { get; set; }
        public bool Agendamento_Consulta { get; set; }
        public DateTime Data_Agendamento { get; set; }
        public bool PrecoDefinitivo { get; set; }

        public bool Seleciona_Data_Mov_Entrada;
        public DateTime Dt_data_entrada_ini;
        public DateTime Dt_data_entrada_fim;

        private bool _orderbyCrecente;
        public Mdo_ProdutoPreco[] Precos;
        public Mdo_ProdutoPreco[] Precos_Unitarios;
        public Mdo_ProdutoPreco[] Precos_Embalagens;
        public bool ExisteAlteracaoDePrecoPendente;
        public bool AlterarPrecoEmbalagensPesoFilhos;
        public double MargemMedia;
        public Mdo_ProdutoPreco[] PrecosAlterados { get; set; }
        public Int16 Pr_status_comercial_preco_inativo = 0;

        public int Tipo_Visualizacao;

        
        public Manutencao(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            Myconnect = _myConnect;
            Filter_Produto = new F0020_Produto.Defaut_Filter();
            Filter_Produto.Dt_cadastro_ini = Convert.ToDateTime("1900-01-01");
            Filter_Produto.Dt_cadastro_fim = Convert.ToDateTime("1900-01-01");
            ExisteAlteracaoDePrecoPendente = false;
            _orderbyCrecente = false;
        }

        public DataTable TabelasPrecosOperacionais()
        {
            return Pag_Net.R0023.Bll.Select.get_DataTable(Myconnect);
        }

        public void ConsultarPrecos ()
        {
            try
            {
                Filter_Produto._ValidarFiltros();
                List<Mdo_ProdutoPreco> _list_produto = new List<Mdo_ProdutoPreco>();
                List<Mdo_ProdutoPreco> _list_produto_preco_Unitario = new List<Mdo_ProdutoPreco>();

                DataTable _dataTable_produto_preco = Pag_Net.Bll.BDCommand.get_DataTable(Myconnect, Pag_Net.Bll.F0140_01_Preco_List_Select.Postgre.Get(Myconnect,
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
                    Mdo_ProdutoPreco _produto_preco = new Mdo_ProdutoPreco(dr);
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

        public void ConsultarPrecosEmbalagens (Mdo_ProdutoPreco item)
        {
            Precos_Embalagens = Array.FindAll(Precos, dados => dados.prb_cdprodutobluesoft != dados.prb_cdprodutobluesoft_unitario 
                                                                        && dados.prb_cdprodutobluesoft_unitario == item.prb_cdprodutobluesoft_unitario );
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
            catch (Exception )
            {
                throw new Exception("Não há itens alterados");
            }

        }

        public void AlterarPreco(Mdo_ProdutoPreco item, Mdo_ProdutoPreco itemUnitario)
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
            
            if (item.pr_embalagemestoque.ToUpper().Trim() == "UN" || (item.pr_embalagemestoque.ToUpper().Trim() == "KG" && AlterarPrecoEmbalagensPesoFilhos == false ))
            {
                if (item.prb_cdprodutobluesoft == item.prb_cdprodutobluesoft_unitario)
                {
                    foreach (Mdo_ProdutoPreco item_embalagem in Precos_Embalagens)
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

        public void AlterarMargem(Mdo_ProdutoPreco item, Mdo_ProdutoPreco itemUnitario)
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

        private void AlterarFatorDePreco (Mdo_ProdutoPreco item)
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

            foreach (Mdo_ProdutoPreco _item in PrecosAlterados)
            {
                if (x == 0)
                {
                    BDExecute = new DbUpdate(Myconnect, DataBaseName.ODBCOXAN);
                }

                /*BDExecute.Execute(Models.BD.Postgres.f0022_01pc_tbprodutobluesoft_getins(item, Pag_Net.Models.BDCommandTypes.DBINSERT), null, DataBaseName.ODBCOXAN);*/

                BDExecute.Execute(Pag_Net.Bll.F0045.Postgres.Post(Myconnect, new F0045.Parametros(
                                    Agendamento_Consulta,
                                    Data_Agendamento,
                                    PrecoDefinitivo ? 1 : 0,
                                    _item.pr_cdproduto,
                                    _item.prb_cdprodutobluesoft,
                                    Tab_pre_cd,
                                    _item.local_PRECO_ALTERADO,
                                    _item.LOCAL_prc_valor_promocional == 0? 0: _item.LOCAL_prc_qtde_promocional,
                                    _item.LOCAL_prc_qtde_promocional == 0? 0: _item.LOCAL_prc_valor_promocional,
                                    _item._local_FATORPRECO_ALTERADO
                    )), null, DataBaseName.ODBCOXAN);

                /*
                Pag_Net.Bll.F0045.Postgres.CRUD(Myconnect, new Pag_Net.F0045.Models.Db(
                                    Agendamento_Consulta,
                                    Data_Agendamento,
                                    PrecoDefinitivo? 1: 0,
                                    _item.pr_cdproduto,
                                    _item.prb_cdprodutobluesoft,
                                    Tab_pre_cd,
                                    _item.local_PRECO_ALTERADO,
                                    _item.LOCAL_prc_qtde_promocional,
                                    _item.LOCAL_prc_valor_promocional, 
                                    _item._local_FATORPRECO_ALTERADO
                                   ));*/
                x = x + 1;
                seq = seq + 1;

                if (x > 250)
                {
                    x = 0;
                    BDExecute.Close(DataBaseName.ODBCOXAN);
                    System.Threading.Thread.Sleep(2000);
                }

                if (seq >= count)
                {
                    x = -1;
                    BDExecute.Close(DataBaseName.ODBCOXAN);
                    System.Threading.Thread.Sleep(500);
                }
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
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
                 
        }
    }
    public static class Consultar
    {
        public static DataTable get (
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            F0020_Produto.Defaut_Filter Filter_Produto,
            int Tab_pre_cd,
            bool Unitario
            )
        {
            return get(MyConnect, Filter_Produto, Tab_pre_cd, Unitario, 0, false);
        }

        public static DataTable get(
        Pag_Net.Models.modelSistemaUsuario MyConnect,
        F0020_Produto.Defaut_Filter Filter_Produto,
        int Tab_pre_cd,
        bool Unitario,
        int proc_log_seq
    )
        {
            return get(MyConnect, Filter_Produto, Tab_pre_cd, Unitario, proc_log_seq, false);
        }
       

        public static DataTable get (
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            F0020_Produto.Defaut_Filter Filter_Produto,
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
            F0020_Produto.Defaut_Filter Filter_Produto,
            int Tab_pre_cd,
            bool Unitario
            )
        {
            return get(MyConnect, Filter_Produto, Tab_pre_cd, Unitario, 0, Convert.ToDateTime("1900-01-01"),Convert.ToDateTime("2100-01-01") );
        }



        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            F0020_Produto.Defaut_Filter Filter_Produto,
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
        public static void Aplicar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                Pag_Net.Bll.P0070.Process.Execute(MyConnect);

                
            }
            catch (Exception EX)
            {
                throw new Exception("Pag_Net.Bll.Precos.Aplicar | " + EX.Message);
            }

        }
            

    }





}

namespace Pag_Net.Bll.Precos.Db
{
     public class Mdo_ProdutoPreco
    {
        public int      pr_cdproduto                    { get; set; }
        public int      prb_cdprodutobluesoft           { get; set; }
        public int      prb_cdprodutobluesoft_unitario  { get; set; }
        public string   pr_descricao                    { get; set; }
        public bool     pr_status                       { get; set; }
        public string   pr_embalagemestoque             { get; set; }
        public string   pre_embalagem                   { get; set; }
        public double   pre_fatorestoque                { get; set; }
        public double   prc_qtde_promocional           { get; set; }
        public double   LOCAL_prc_qtde_promocional { get; set; }
        public double   prc_valor_promocional          { get; set; }
        public double   LOCAL_prc_valor_promocional { get; set; }
        public double   pre_fatorpreco                  { get; set; }
        public double   _local_FATORPRECO_ALTERADO      { get; set; }
        public double   prc_valor                       { get; set; }
        public double   ec_valor_custo_precificacao     { get; set; }
        public double   ec_valor_custo_faturamento      { get; set; }
        public double   ec_embalagemestoque_qtde        { get; set; }
        public bool     pr_cesta                        { get; set; }
        public int      consulta_agendamento            { get; set; }
        public bool     bool_pr_status_comercial_preco_inativo { get; set; }
        public double consulta_valor_custo_precificacao { get; set; }
        public DateTime data_ultima_compra { get; set; }
        public DateTime data_ultima_venda { get; set; }


	 	public DateTime est_satual_data_ini							{ get; set; }
	 	public DateTime est_satual_data_fim							{ get; set; }
	 	public double   est_satual_embalagemcompraqtde				{ get; set; }
	 	public double   est_satual_embalagemestoqueqtde 			{ get; set; }
	 	public double   est_satual_ec_valorcusto_faturamento_total	{ get; set; }
	 	public double   est_satual_valortotalfaturamentoliquido		{ get; set; }
	 	public int      est_satual_clientes							{ get; set; }
	 	public int      est_satual_pontos							{ get; set; }
        public double calc_est_satual_margem 
        {
            get
            {
                if (est_satual_valortotalfaturamentoliquido > 0 )
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(est_satual_valortotalfaturamentoliquido, est_satual_ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            } 
        }
        public double calc_est_satual_preco_medio 
        {
            get
            {
                if (est_satual_valortotalfaturamentoliquido > 0)
                {
                    return est_satual_valortotalfaturamentoliquido / est_satual_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_satual_custo_medio
        {
            get
            {
                if (est_satual_ec_valorcusto_faturamento_total > 0)
                {
                    return est_satual_ec_valorcusto_faturamento_total / est_satual_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }


	 	public double    est_s4_embalagemcompraqtde					{ get; set; }
	 	public double    est_s4_embalagemestoqueqtde 				{ get; set; }
	 	public double    est_s4_ec_valorcusto_faturamento_total		{ get; set; }
	 	public double    est_s4_valortotalfaturamentoliquido		{ get; set; }
	 	public int       est_s4_clientes							{ get; set; }
	 	public int       est_s4_pontos								{ get; set; }
        public double       calc_est_s4_margem
        {
            get
            {
                if (est_s4_valortotalfaturamentoliquido > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(est_s4_valortotalfaturamentoliquido, est_s4_ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double       calc_est_s4_preco_medio
        {
            get
            {
                if (est_s4_valortotalfaturamentoliquido > 0)
                {
                    return est_s4_valortotalfaturamentoliquido / est_s4_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s4_custo_medio
        {
            get
            {
                if (est_s4_ec_valorcusto_faturamento_total > 0)
                {
                    return est_s4_ec_valorcusto_faturamento_total / est_s4_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
	 	
  
	 	public double    est_s3_embalagemcompraqtde					{ get; set; }
	 	public double    est_s3_embalagemestoqueqtde 				{ get; set; }
	 	public double    est_s3_ec_valorcusto_faturamento_total		{ get; set; }
	 	public double    est_s3_valortotalfaturamentoliquido		{ get; set; }
	 	public int       est_s3_clientes							{ get; set; }
	 	public int       est_s3_pontos								{ get; set; }
        public double calc_est_s3_margem
        {
            get
            {
                if (est_s3_valortotalfaturamentoliquido > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(est_s3_valortotalfaturamentoliquido, est_s3_ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s3_preco_medio
        {
            get
            {
                if (est_s3_valortotalfaturamentoliquido > 0)
                {
                    return est_s3_valortotalfaturamentoliquido / est_s3_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s3_custo_medio
        {
            get
            {
                if (est_s3_ec_valorcusto_faturamento_total > 0)
                {
                    return est_s3_ec_valorcusto_faturamento_total / est_s3_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }

   
	 	public double    est_s2_embalagemcompraqtde					{ get; set; }
	 	public double    est_s2_embalagemestoqueqtde 				{ get; set; }
	 	public double    est_s2_ec_valorcusto_faturamento_total		{ get; set; }
	 	public double    est_s2_valortotalfaturamentoliquido		{ get; set; }
	 	public int       est_s2_clientes							{ get; set; }
	 	public int       est_s2_pontos								{ get; set; }
        public double calc_est_s2_margem
        {
            get
            {
                if (est_s3_valortotalfaturamentoliquido > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(est_s2_valortotalfaturamentoliquido, est_s2_ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s2_preco_medio
        {
            get
            {
                if (est_s2_valortotalfaturamentoliquido > 0)
                {
                    return est_s2_valortotalfaturamentoliquido / est_s2_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s2_custo_medio
        {
            get
            {
                if (est_s2_ec_valorcusto_faturamento_total > 0)
                {
                    return est_s2_ec_valorcusto_faturamento_total / est_s2_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }

   
        public double est_s1_embalagemcompraqtde { get; set; }
        public double est_s1_embalagemestoqueqtde { get; set; }
        public double est_s1_ec_valorcusto_faturamento_total { get; set; }
        public double est_s1_valortotalfaturamentoliquido { get; set; }
        public int est_s1_clientes { get; set; }
        public int est_s1_pontos { get; set; }
        public double calc_est_s1_margem
        {
            get
            {
                if (est_s1_valortotalfaturamentoliquido > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(est_s1_valortotalfaturamentoliquido, est_s1_ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s1_preco_medio
        {
            get
            {
                if (est_s1_valortotalfaturamentoliquido > 0)
                {
                    return est_s1_valortotalfaturamentoliquido / est_s1_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s1_custo_medio
        {
            get
            {
                if (est_s1_ec_valorcusto_faturamento_total > 0)
                {
                    return est_s1_ec_valorcusto_faturamento_total / est_s1_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }

        

        public int dias_sem_venda 
        {
            get 
            {

                int date_diff = (DateTime.Now - this.data_ultima_venda).Days;
                if (date_diff > 730)
                    date_diff = -1;
                return date_diff;
            }
        
        }

        public int dias_sem_compra
        {
            get
            {
                int date_diff =  (DateTime.Now - this.data_ultima_compra).Days;
                if ( date_diff > 730 )
                    date_diff = -1;
                return date_diff;
            }

        }
      


        public string   local_TIPO_CESTA 
        {
            get
            {
                if (pr_cesta)
                    return "SIM";
                else
                    return "NÃO";
            }
        
        }
            
        public bool local_ITEM_ALTERADO {
            get
            {
                bool _preco_alterado = false;
                if (_local_PRECO_ALTERADO != prc_valor  || _local_FATORPRECO_ALTERADO != pre_fatorpreco || prc_qtde_promocional != LOCAL_prc_qtde_promocional || prc_valor_promocional  != LOCAL_prc_valor_promocional)
                {
                    _preco_alterado = true;
                }
                return _preco_alterado;
            }
        }
        public double local_MARGEM_MEDIA
        {
            get
            {
                double _margem_media = 0;
                /*if (_local_PRECO_ALTERADO != 0)
                {

                    if (_local_PRECO_ALTERADO != ec_valor_custo_faturamento)
                    {
                        _margem_media = (_local_PRECO_ALTERADO - ec_valor_custo_faturamento) / _local_PRECO_ALTERADO * 100;
                    }
                    else
                    {
                        _margem_media = 0;
                    }
                }
                else
                {
                    _margem_media = 0;
                }*/

                _margem_media = Pag_Net.Tools.Calculo.MargemPreco.get(_local_PRECO_ALTERADO, ec_valor_custo_faturamento);

                return _margem_media;
            }
        }


        private double _local_PRECO_ALTERADO;
        public double local_PRECO_ALTERADO
        {
            get
            {
                return _local_PRECO_ALTERADO;
                
            }

            set
            {
                _local_PRECO_ALTERADO = value;
            }
        }

        private double _local_MARGEM_PRECIFICACAO;
        public double local_MARGEM_PRECIFICACAO
        {
            get
            {
                 return _local_MARGEM_PRECIFICACAO;

                /*
                 double _margem_precificacao = 0;
                 if (_local_PRECO_ALTERADO > ec_valor_custo_faturamento)
                 {
                     _margem_precificacao = (_local_PRECO_ALTERADO - ec_valor_custo_precificacao) / _local_PRECO_ALTERADO * 100;
                 }
                 if (_local_PRECO_ALTERADO <= ec_valor_custo_precificacao)
                 {
                     _margem_precificacao = 0;
                 }
                 return _margem_precificacao;
                */


            }
            set
            {
                try
                {
                    if (Convert.ToDouble(value) > -100.00)
                    {
                        _local_MARGEM_PRECIFICACAO = value;
                    }
                   // else
                   // {
                   //     throw new Exception("Valor inválido");
                   // }
                }
                catch (Exception)
                {
                    throw new Exception("Valor inválido");
                }
            } 
        }


        public double LOCAL_prc_margem_promocional
        {
            get
            {
                try
                {
                    double _LOCAL_prc_margem_promocional;
                    if (LOCAL_prc_valor_promocional > 0)
                    {
                        _LOCAL_prc_margem_promocional = Math.Round(Pag_Net.Tools.Calculo.MargemPreco.get(LOCAL_prc_valor_promocional, ec_valor_custo_precificacao),2);

                    }
                    else
                    {
                        _LOCAL_prc_margem_promocional = 0;
                    }
                    return _LOCAL_prc_margem_promocional;
                }
                catch (Exception ex)
                {
                    throw new Exception("Pag_Net.Bll.ProdutoPreco...Local_prc_margem_promocional: " + ex.Message);
                }
            } 
          
        }

        public Mdo_ProdutoPreco() { }

        public Mdo_ProdutoPreco(
                 int     _pr_cdproduto                   
             ,   int     _prb_cdprodutobluesoft   
             ,   int     _prb_cdprodutobluesoft_unitario 
             ,   string  _pr_descricao                   
             ,   bool    _pr_status                      
             ,   string  _pr_embalagemestoque            
             ,   string  _pre_embalagem                  
             ,   double  _pre_fatorestoque               
             ,   double  _pre_fatorpreco     
             ,   double  _prc_valor                      
             ,   double  _ec_valor_custo_precificacao    
             ,   double  _ec_valor_custo_faturamento
             ,   double  _ec_embalagemestoque_qtde
             ,   bool    _pr_cesta 
             ,   int     _consulta_agendamento
             ,   double  _prc_qtde_promocional
             ,   double  _prc_valor_promocional 
            )
        {

            data_ultima_compra = Convert.ToDateTime("1900-01-01");
            data_ultima_venda = Convert.ToDateTime("1900-01-01");

            pr_cdproduto                    =          _pr_cdproduto                   ;
            prb_cdprodutobluesoft_unitario  =          _prb_cdprodutobluesoft_unitario ;
            prb_cdprodutobluesoft           =          _prb_cdprodutobluesoft          ;
            pr_descricao                    =          _pr_descricao;
            pr_status                       =          _pr_status                      ;
            pr_embalagemestoque             =          _pr_embalagemestoque            ;
            pre_embalagem                   =          _pre_embalagem                  ;
            pre_fatorestoque                =          _pre_fatorestoque               ;
            pre_fatorpreco                  =          _pre_fatorpreco                 ;
            prc_valor                       =          _prc_valor                      ;
            ec_valor_custo_precificacao     =          _ec_valor_custo_precificacao    ;
            ec_valor_custo_faturamento      =          _ec_valor_custo_faturamento;
            ec_embalagemestoque_qtde        =          _ec_embalagemestoque_qtde;
            pr_cesta                        =          _pr_cesta;
            consulta_agendamento            =          _consulta_agendamento;
            prc_qtde_promocional            =          _prc_qtde_promocional;
            prc_valor_promocional           =          _prc_valor_promocional;


        }

        
        public void _AlterarMargem( double _valorMargem )
        {
            if (_valorMargem == 0)
            {
                local_PRECO_ALTERADO = ec_valor_custo_precificacao;
            }
        }

 



        public Mdo_ProdutoPreco(DataRow i) 
        {
            
            string error_info = "";
            try
            {
                error_info = "pr_cdproduto"; pr_cdproduto = Convert.ToInt32(i["pr_cdproduto"]);
                error_info = "prb_cdprodutobluesoft"; prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"]);
                error_info = "prb_cdprodutobluesoft_unitario"; prb_cdprodutobluesoft_unitario = Convert.ToInt32(i["prb_cdprodutobluesoft_unitario"]);
                error_info = "pr_descricao"; pr_descricao = i["pr_descricao"].ToString();
                error_info = "pr_status"; pr_status = Pag_Net.Models.BDTools.boolColumnResult(i["pr_status"].ToString());
                error_info = "pr_embalagemestoque"; pr_embalagemestoque = i["pr_embalagemestoque"].ToString();
                error_info = "pre_embalagem"; pre_embalagem = i["pre_embalagem"].ToString();
                error_info = "pre_fatorestoque"; pre_fatorestoque = Convert.ToDouble(i["pre_fatorestoque"]);
                error_info = "pre_fatorpreco"; pre_fatorpreco = Convert.ToDouble(i["pre_fatorpreco"]);
                error_info = "_local_FATORPRECO_ALTERADO"; _local_FATORPRECO_ALTERADO = Convert.ToDouble(i["pre_fatorpreco"]);

                error_info = "prc_valor"; prc_valor = Convert.ToDouble(i["prc_valor"]);
                error_info = "_local_PRECO_ALTERADO"; _local_PRECO_ALTERADO = Convert.ToDouble(i["prc_valor"]);

                error_info = "prc_qtde_promocional"; prc_qtde_promocional = Convert.ToDouble(i["prc_qtde_promocional"]);
                error_info = "LOCAL_prc_qtde_promocional"; LOCAL_prc_qtde_promocional = Convert.ToDouble(i["prc_qtde_promocional"]);

                error_info = "prc_valor_promocional"; prc_valor_promocional = Convert.ToDouble(i["prc_valor_promocional"]);
                error_info = "LOCAL_prc_valor_promocional"; LOCAL_prc_valor_promocional = Convert.ToDouble(i["prc_valor_promocional"]);

                error_info = "ec_valor_custo_precificacao"; ec_valor_custo_precificacao = Convert.ToDouble(i["ec_valor_custo_precificacao"]);
                error_info = "ec_valor_custo_faturamento"; ec_valor_custo_faturamento = Convert.ToDouble(i["ec_valor_custo_faturamento"]);
                error_info = "ec_embalagemestoque_qtde"; ec_embalagemestoque_qtde = Convert.ToDouble(i["ec_embalagemestoque_qtde"]);
                error_info = "consulta_agendamento"; consulta_agendamento = Convert.ToInt32(i["consulta_agendamento"]);

                error_info = "pr_cesta"; pr_cesta = Pag_Net.Models.BDTools.boolColumnResult(i["pr_cesta"].ToString());

                error_info = "pr_status_comercial_preco_inativo"; 
                if (Convert.ToInt32(Pag_Net.Models.BDTools.boolColumnResult(i["pr_status_comercial_preco_inativo"].ToString())) == 0)
                {
                    bool_pr_status_comercial_preco_inativo = false;

                }
                else
                {
                    bool_pr_status_comercial_preco_inativo = true;
                }


                error_info = "_local_MARGEM_PRECIFICACAO"; _local_MARGEM_PRECIFICACAO = Pag_Net.Tools.Calculo.MargemPreco.get(_local_PRECO_ALTERADO, ec_valor_custo_precificacao);


                error_info = "consulta_valor_custo_precificacao"; consulta_valor_custo_precificacao = Convert.ToDouble(i["consulta_valor_custo_precificacao"]);
                error_info = "data_ultima_compra"; data_ultima_compra = Convert.ToDateTime(i["data_ultima_compra"]);
                error_info = "data_ultima_venda"; data_ultima_venda = Convert.ToDateTime(i["data_ultima_venda"]);


     
                error_info = "est_satual_embalagemcompraqtde"; est_satual_embalagemcompraqtde = Convert.ToDouble(i["est_satual_embalagemcompraqtde"].ToString());
                error_info = "est_satual_embalagemestoqueqtde"; est_satual_embalagemestoqueqtde = Convert.ToDouble(i["est_satual_embalagemestoqueqtde"].ToString());
                error_info = "est_satual_ec_valorcusto_faturamento_total"; est_satual_ec_valorcusto_faturamento_total = Convert.ToDouble(i["est_satual_ec_valorcusto_faturamento_total"].ToString());
                error_info = "est_satual_valortotalfaturamentoliquido"; est_satual_valortotalfaturamentoliquido = Convert.ToDouble(i["est_satual_valortotalfaturamentoliquido"].ToString());
                error_info = "est_satual_clientes"; est_satual_clientes = Convert.ToInt32(i["est_satual_clientes"].ToString());
                error_info = "est_satual_pontos"; est_satual_pontos = Convert.ToInt32(i["est_satual_pontos"].ToString());


       
                error_info = "est_s4_embalagemcompraqtde"; est_s4_embalagemcompraqtde = Convert.ToDouble(i["est_s4_embalagemcompraqtde"].ToString());
                error_info = "est_s4_embalagemestoqueqtde"; est_s4_embalagemestoqueqtde = Convert.ToDouble(i["est_s4_embalagemestoqueqtde"].ToString());
                error_info = "est_s4_ec_valorcusto_faturamento_total"; est_s4_ec_valorcusto_faturamento_total = Convert.ToDouble(i["est_s4_ec_valorcusto_faturamento_total"].ToString());
                error_info = "est_s4_valortotalfaturamentoliquido"; est_s4_valortotalfaturamentoliquido = Convert.ToDouble(i["est_s4_valortotalfaturamentoliquido"].ToString());
                error_info = "est_s4_clientes"; est_s4_clientes = Convert.ToInt32(i["est_s4_clientes"].ToString());
                error_info = "est_s4_pontos"; est_s4_pontos = Convert.ToInt32(i["est_s4_pontos"].ToString());

        
                error_info = "est_s3_embalagemcompraqtde"; est_s3_embalagemcompraqtde = Convert.ToDouble(i["est_s3_embalagemcompraqtde"].ToString());
                error_info = "est_s3_embalagemestoqueqtde"; est_s3_embalagemestoqueqtde = Convert.ToDouble(i["est_s3_embalagemestoqueqtde"].ToString());
                error_info = "est_s3_ec_valorcusto_faturamento_total"; est_s3_ec_valorcusto_faturamento_total = Convert.ToDouble(i["est_s3_ec_valorcusto_faturamento_total"].ToString());
                error_info = "est_s3_valortotalfaturamentoliquido"; est_s3_valortotalfaturamentoliquido = Convert.ToDouble(i["est_s3_valortotalfaturamentoliquido"].ToString());
                error_info = "est_s3_clientes"; est_s3_clientes = Convert.ToInt32(i["est_s3_clientes"].ToString());
                error_info = "est_s3_pontos"; est_s3_pontos = Convert.ToInt32(i["est_s3_pontos"].ToString());

      
                error_info = "est_s2_embalagemcompraqtde"; est_s2_embalagemcompraqtde = Convert.ToDouble(i["est_s2_embalagemcompraqtde"].ToString());
                error_info = "est_s2_embalagemestoqueqtde"; est_s2_embalagemestoqueqtde = Convert.ToDouble(i["est_s2_embalagemestoqueqtde"].ToString());
                error_info = "est_s2_ec_valorcusto_faturamento_total"; est_s2_ec_valorcusto_faturamento_total = Convert.ToDouble(i["est_s2_ec_valorcusto_faturamento_total"].ToString());
                error_info = "est_s2_valortotalfaturamentoliquido"; est_s2_valortotalfaturamentoliquido = Convert.ToDouble(i["est_s2_valortotalfaturamentoliquido"].ToString());
                error_info = "est_s2_clientes"; est_s2_clientes = Convert.ToInt32(i["est_s2_clientes"].ToString());
                error_info = "est_s2_pontos"; est_s2_pontos = Convert.ToInt32(i["est_s2_pontos"].ToString());


         
                error_info = "est_s1_embalagemcompraqtde"; est_s1_embalagemcompraqtde = Convert.ToDouble(i["est_s1_embalagemcompraqtde"].ToString());
                error_info = "est_s1_embalagemestoqueqtde"; est_s1_embalagemestoqueqtde = Convert.ToDouble(i["est_s1_embalagemestoqueqtde"].ToString());
                error_info = "est_s1_ec_valorcusto_faturamento_total"; est_s1_ec_valorcusto_faturamento_total = Convert.ToDouble(i["est_s1_ec_valorcusto_faturamento_total"].ToString());
                error_info = "est_s1_valortotalfaturamentoliquido"; est_s1_valortotalfaturamentoliquido = Convert.ToDouble(i["est_s1_valortotalfaturamentoliquido"].ToString());
                error_info = "est_s1_clientes"; est_s1_clientes = Convert.ToInt32(i["est_s1_clientes"].ToString());
                error_info = "est_s1_pontos"; est_s1_pontos = Convert.ToInt32(i["est_s1_pontos"].ToString());
            }

            catch (Exception ex)
            {
                error_info += " | pr_cdproduto: " + pr_cdproduto.ToString();
                throw new Exception("\n" + "\n" + "Pag_Net.Bll.ProdutoPreco.cs | Mdo_ProdutoPreco" + "\n" + "Função PostGRE [f0140_01_XXXXXXX_preco_list_select]): " + "\n" + "Erro: " +  ex.Message + "\n" + "\n" + "Binding Data: " + "\n" + error_info);
            }
        }

    }

}




/* 29/09/2021 192.168.1.18.61 - R2 _ public void EfetivarAlteracoesDePreco()
 * Não aplicar preços P0070 no momento em que a alteração é salva. Este comando estava aqui por esquecimento


*/