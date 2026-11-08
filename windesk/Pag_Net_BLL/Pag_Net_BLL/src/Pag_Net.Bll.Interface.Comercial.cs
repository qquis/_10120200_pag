/*
 * 31/03/2022[1] - Obter_Faturamento_Resumido_Comercial | Permitir o filtro do array via codigo de referencia 
 * 
 * 
 *
 * 
 * 
 */


using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Interface.Comercial
{
    public class Pre_Pedido
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        public tbcomercial_pre_pedido Comercial_Pre_Pedido;
        private tbfat_res_comercial[] Fataturamento_Resumido_Comercial;
        private bool _orderbyCrecente;
        public Pre_Pedido(Pag_Net.Models.modelSistemaUsuario _MyConnect, tbcomercial_pre_pedido _Comercial_Pre_Pedido)
        {
            MyConnect = _MyConnect;
            Comercial_Pre_Pedido = _Comercial_Pre_Pedido;
            Gerar_Faturamento_Resumido_Comercial();
            _orderbyCrecente = false;
        }

        public void ImportarSugestao(string ArquivoEntrada)
        {
            try
            {
                char[] delimiterChars = { ';' };
                int NCol_CdProdutoBlueSoft = 0;
                int NCol_EmbalagemCOMPRAQtde = 1;

                int CodigoProduto_ou_Referencia;
                double Qtde_Sugestao = 0;

                string linhaRead;
                linhaRead = "";
                if (File.Exists(ArquivoEntrada))
                {

                    Pag_Net.Tools.ManagerFileInfo Arquivo = new Pag_Net.Tools.ManagerFileInfo();
                    Pag_Net.Tools.ManagerFile _ManagerFile = new Pag_Net.Tools.ManagerFile();

                    System.IO.FileInfo _OpenFILE = new FileInfo(ArquivoEntrada);
                    _OpenFILE.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                    Arquivo = _ManagerFile.FileOut(_OpenFILE);

                    int SEQNOVOARQUIVO = Pag_Net.Bll.F001001.Postgres.getKey(MyConnect, DateTime.Now, ArquivoEntrada);

                    int i = 0;
                    string[] linhas = Pag_Net.Tools.LogFile.ReadLine(Arquivo.FileName);

                    for (i = 0; i < linhas.Count(); i++)
                    {

                        string[] _COLUNAS = linhas[i].Split(delimiterChars);
                        linhaRead = linhas[i].ToString();
                        CodigoProduto_ou_Referencia = Convert.ToInt32(_COLUNAS[NCol_CdProdutoBlueSoft]);
                        Qtde_Sugestao = Convert.ToDouble(_COLUNAS[NCol_EmbalagemCOMPRAQtde]);

                        int INDEX_LOCALIZACAO = Array.FindIndex(Fataturamento_Resumido_Comercial, row => row.prb_cdprodutobluesoft ==  CodigoProduto_ou_Referencia);
                        if (INDEX_LOCALIZACAO >= 0)
                        {
                            Fataturamento_Resumido_Comercial[INDEX_LOCALIZACAO].cm_pre_ped_item_embalagemcompra_qtde = Qtde_Sugestao;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Erro | Pag_Net.Bll.Interface.Comercial.Pre_Pedido.ImportarSugestao" + ex.Message);
            }

        }

        private void Gerar_Faturamento_Resumido_Comercial()
        {
            try
            {
                List<tbfat_res_comercial> _lst = new List<tbfat_res_comercial>();
                DataTable DataTable_Faturamento_Resumido = BDCommand.get_DataTable(MyConnect, Pag_Net.Bll.F0132_01.PostGre.Get(new F0132_01.filter(
                                                                Comercial_Pre_Pedido.fat_res_seq, 
                                                                Comercial_Pre_Pedido.fabricante_cdpessoabluesoft, 
                                                                Comercial_Pre_Pedido.cm_pre_ped_seq)));

                int __seq_array = 0;
                foreach (DataRow i in DataTable_Faturamento_Resumido.Rows)
                {
                    tbfat_res_comercial item = new tbfat_res_comercial(i);

                        
                    item.__seq_array = __seq_array;
                    _lst.Add(new tbfat_res_comercial(i));
                    __seq_array += 1;
                }
                Fataturamento_Resumido_Comercial = _lst.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public void Fataturamento_Resumido_Comercial_Update(int __seq_array, double cm_pre_ped_item_embalagemcompra_qtde, double cm_pre_ped_item_embalagemcompra_qtde_aut)
        {
            //rray_Precos_INDEX_PRODUTO_ALTERADO = Array.FindIndex(Precos, X => X.prb_cdprodutobluesoft == item_embalagem.prb_cdprodutobluesoft);

                    //            item.cm_pre_ped_item_embalagemcompra_qtde = 0;
                    // item.cm_pre_ped_item_embalagemcompra_qtde_aut = 0;

            int INDEX = Array.FindIndex(Fataturamento_Resumido_Comercial, dados => dados.pr_cdproduto == __seq_array);
            Fataturamento_Resumido_Comercial[INDEX].cm_pre_ped_item_embalagemcompra_qtde = cm_pre_ped_item_embalagemcompra_qtde;
            Fataturamento_Resumido_Comercial[INDEX].cm_pre_ped_item_embalagemcompra_qtde_aut = cm_pre_ped_item_embalagemcompra_qtde_aut;

        }
        public double ValorTotalSolicitado()
        {
            double valor_total_solicitado = 0;
            foreach (tbfat_res_comercial i in Fataturamento_Resumido_Comercial)
            {
                valor_total_solicitado += i._calc_valor_total_solicitado;
            }
            return valor_total_solicitado;
        }
        public double ValorTotalAutorizado()
        {
            double valor_total_autorizado = 0;
            foreach (tbfat_res_comercial i in Fataturamento_Resumido_Comercial )
            {
                valor_total_autorizado += i._calc_valor_total_autorizado;
            }
            return valor_total_autorizado;
        }
        public tbfat_res_comercial[] Obter_Faturamento_Resumido_Comercial(string _descricao, string _codigo_referencia)
        {
            tbfat_res_comercial[] _Array_Return;
            try
            {
                _Array_Return = Fataturamento_Resumido_Comercial;
                if (_descricao != "")
                {
                    _Array_Return = Array.FindAll(_Array_Return, dados => dados.pr_descricao.Contains(_descricao));
                }

                if (_codigo_referencia != "")
                {
                    _Array_Return = Array.FindAll(_Array_Return, dados => dados.prbf_codigo_referencia.Contains(_codigo_referencia));
                }
                return _Array_Return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public tbfat_res_comercial[] Obter_Faturamento_Resumido_Qtde_Solicitada()
        {
            return Array.FindAll(Fataturamento_Resumido_Comercial, dados => dados.cm_pre_ped_item_embalagemcompra_qtde > 0);
        }
        public tbfat_res_comercial[] Obter_Faturamento_Resumido_Qtde_Autorizada()
        {
            return Array.FindAll(Fataturamento_Resumido_Comercial, dados => dados.cm_pre_ped_item_embalagemcompra_qtde_aut > 0);
        }
        public tbfat_res_comercial[] Obter_Faturamento_Resumido_Qtde_Autorizada_Diferente_Solicitada()
        {
            return Array.FindAll(Fataturamento_Resumido_Comercial, dados => dados.cm_pre_ped_item_embalagemcompra_qtde_aut != dados.cm_pre_ped_item_embalagemcompra_qtde);
        }        
        public void Autorizar_Todas_As_Quantidades()
        {
            foreach(tbfat_res_comercial i in Fataturamento_Resumido_Comercial)
            {
                if (i.cm_pre_ped_item_embalagemcompra_qtde != 0)
                    i.cm_pre_ped_item_embalagemcompra_qtde_aut = i.cm_pre_ped_item_embalagemcompra_qtde;
            }
        }
        public tbcomercial_pre_pedido Pre_Pedido_Comercial_Incluir(tbcomercial_pre_pedido comercial_pre_pedido)
        {
            try
            {
                Comercial_Pre_Pedido = Tool.Pre_pedido_Inserir(MyConnect, comercial_pre_pedido);
                foreach( tbfat_res_comercial i in  Obter_Faturamento_Resumido_Qtde_Solicitada())
                {
                    Tool.Pre_pedido_item_update(MyConnect, Comercial_Pre_Pedido, new tbcomercial_pre_pedido_item(i));
                }
                return Comercial_Pre_Pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Pre_Pedido_Comercial_Quantidades_Autorizadas(tbcomercial_pre_pedido comercial_pre_pedido)
        {
            try
            {
                //int _COMERCIAL_PRE_PEDIDO_SEQ = Convert.ToInt32(lbl_cm_pre_ped_seq.Text);
                //int _pr_cdproduto = Convert.ToInt32(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_pr_cdproduto"].Value.ToString());
                //double _qtde = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value.ToString());
                //double _qtde_autorizada = Convert.ToDouble(dtgSugestaoCompra.Rows[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde_aut"].Value.ToString());
                foreach (tbfat_res_comercial i in Fataturamento_Resumido_Comercial)
                {
                    /* ler todos os registros com qtde SOLICITADA e gravar SOLICITADA e AUTORIZADA */
                    if (i.cm_pre_ped_item_embalagemcompra_qtde > 0)
                        Pag_Net.Bll.Interface.Comercial.Tool.Pre_pedido_item_qtde_autorizada(MyConnect, comercial_pre_pedido.cm_pre_ped_seq, i.pr_cdproduto, i.cm_pre_ped_item_embalagemcompra_qtde_aut);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public void OrderBy(string _columnName)
        {
            if (_orderbyCrecente)
            {
                _orderbyCrecente = false;
                switch (_columnName)
                {
                    case "pr_cdproduto":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.pr_cdproduto).ToArray();
                        break;
                    case "prbf_codigo_referencia":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.prbf_codigo_referencia).ToArray();
                        break;
                    case "pr_descricao":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.pr_descricao).ToArray();
                        break;
                    case "prb_embalagemestoque":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.prb_embalagemestoque).ToArray();
                        break;
                    case "prb_embalagemcompra":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.prb_embalagemcompra).ToArray();
                        break;
                    case "prb_fatorestoque":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.prb_fatorestoque).ToArray();
                        break;
                    case "ec_embalagemestoque_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.ec_embalagemestoque_qtde).ToArray();
                        break;
                    case "calc_ec_embalagemcompra_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.calc_ec_embalagemcompra_qtde).ToArray();
                        break;
                    case "ec_valor_custo_precificacao":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.ec_valor_custo_precificacao).ToArray();
                        break;
                    case "cm_pre_ped_item_embalagemcompra_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.cm_pre_ped_item_embalagemcompra_qtde).ToArray();
                        break;
                    case "_calc_valor_total_solicitado":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c._calc_valor_total_solicitado).ToArray();
                        break;
                    case "cm_pre_ped_item_embalagemcompra_qtde_aut":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.cm_pre_ped_item_embalagemcompra_qtde_aut).ToArray();
                        break;
                    case "_calc_valor_total_autorizado":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c._calc_valor_total_autorizado).ToArray();
                        break;
                    case "mes_base_anual_10_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.mes_base_anual_10_qtde).ToArray();
                        break;
                    case "mes_base_anual_11_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.mes_base_anual_11_qtde).ToArray();
                        break;
                    case "mes_base_anual_12_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.mes_base_anual_12_qtde).ToArray();
                        break;
                    case "mes_base_anual_13_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderBy(c => c.mes_base_anual_13_qtde).ToArray();
                        break;


                }


            }
            else
            {
                _orderbyCrecente = true;

                switch (_columnName)
                {
                    case "pr_cdproduto":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.pr_cdproduto).ToArray();
                        break;
                    case "prbf_codigo_referencia":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.prbf_codigo_referencia).ToArray();
                        break;
                    case "pr_descricao":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.pr_descricao).ToArray();
                        break;
                    case "prb_embalagemestoque":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.prb_embalagemestoque).ToArray();
                        break;
                    case "prb_embalagemcompra":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.prb_embalagemcompra).ToArray();
                        break;
                    case "prb_fatorestoque":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.prb_fatorestoque).ToArray();
                        break;
                    case "ec_embalagemestoque_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.ec_embalagemestoque_qtde).ToArray();
                        break;
                    case "calc_ec_embalagemcompra_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.calc_ec_embalagemcompra_qtde).ToArray();
                        break;
                    case "ec_valor_custo_precificacao":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.ec_valor_custo_precificacao).ToArray();
                        break;
                    case "cm_pre_ped_item_embalagemcompra_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.cm_pre_ped_item_embalagemcompra_qtde).ToArray();
                        break;
                    case "_calc_valor_total_solicitado":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c._calc_valor_total_solicitado).ToArray();
                        break;
                    case "cm_pre_ped_item_embalagemcompra_qtde_aut":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.cm_pre_ped_item_embalagemcompra_qtde_aut).ToArray();
                        break;
                    case "_calc_valor_total_autorizado":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c._calc_valor_total_autorizado).ToArray();
                        break;
                    case "mes_base_anual_10_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.mes_base_anual_10_qtde).ToArray();
                        break;
                    case "mes_base_anual_11_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.mes_base_anual_11_qtde).ToArray();
                        break;
                    case "mes_base_anual_12_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.mes_base_anual_12_qtde).ToArray();
                        break;
                    case "mes_base_anual_13_qtde":
                        Fataturamento_Resumido_Comercial = Fataturamento_Resumido_Comercial.OrderByDescending(c => c.mes_base_anual_13_qtde).ToArray();
                        break;

  

                }
            }




        }


    }

    public class PrePedido
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        public PrePedido(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            MyConnect = _myConnect;
        }
        public tbcomercial_pre_pedido __tbcomercial_pre_pedido;
        public tbcomercial_pre_pedido_item[] list_tbcomercial_pre_pedido_item;
        public void efetivar_pedido()
        {
            try
            {
                for (int i = 0; i <= list_tbcomercial_pre_pedido_item.Count() - 1; i++)
                {
                    Tool.Pre_pedido_item_update(MyConnect, __tbcomercial_pre_pedido, list_tbcomercial_pre_pedido_item[i]);

                }
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }
        }
    }

    public static class Tool
    {
        public static void Pagamentos_Inserir(Pag_Net.Models.modelSistemaUsuario MyConnect, int _cm_pre_ped_seq, int _cm_pre_ped_pgto_order, DateTime _data, double _valor)
        {
            try
            {
                BDCommand.Post(MyConnect, Pag_Net.Bll.F0132_06.Postgre.Post(new F0132_06.Db(_cm_pre_ped_seq,0, _cm_pre_ped_pgto_order, _data, _valor)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Posicao(Pag_Net.Models.modelSistemaUsuario MyConnect, int fat_res_seq, int fv_fabricante_cdpessoabluesoft, int cm_pre_ped_seq)
        {

            try
            {
                string sql = string.Format("{0}, {1}, {2}", fat_res_seq.ToString(), fv_fabricante_cdpessoabluesoft.ToString(), cm_pre_ped_seq);
                return Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, BDCommand.Name.F0132_01_tbfat_res_comercial_consulta_relacional, sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Comercial_pre_pedido_list(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime _data_inicial, DateTime _data_final, int fabricante_cdpessoabluesoft, int controle_status_pedido)
        {
            try
            {

                return 
                Pag_Net.Bll.BDCommand.get_DataTable(MyConnect,
                            BDCommand.Name.F0132_04_tbcomercial_pre_pedido_list,
                            string.Format(" '{0}', '{1}', {2}, {3}",
                            _data_inicial.ToString("yyyy-MM-dd"),
                            _data_final.ToString("yyyy-MM-dd"),
                            fabricante_cdpessoabluesoft.ToString(),
                            controle_status_pedido.ToString()
                            ));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void Gerar_Nova_Folha_de_Dados_Posicao(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

            try
            {
                int __NUMERO_RESUMO = Convert.ToInt32(Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, BDCommand.Name.F0132_90_processo_fat_res_comercial, "").Rows[0][0].ToString());

                if (MyConnect.User_environment.ToString() != "DES")
                {
                    DbUpdate BDExecute;
                    BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                    BDExecute.Execute(string.Format("EXEC DBAMAIN.DBO.SP_Postgre_0132_1011877_tbfat_res_comercial_update @FAT_RES_SEQ = {0} ", __NUMERO_RESUMO.ToString()), null, DataBaseName.DBAMAINADM, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public static DataTable Comercial_pre_pedido_item_list(Pag_Net.Models.modelSistemaUsuario MyConnect, int cm_pre_ped_seq)
        {
            try
            {

                return
                Pag_Net.Bll.BDCommand.get_DataTable(MyConnect,
                            BDCommand.Name.F0132_05_tbcomercial_pre_pedido_item_list,
                            string.Format(" {0}",
                            cm_pre_ped_seq.ToString()
                            ));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void Pre_pedido_item_update(Pag_Net.Models.modelSistemaUsuario MyConnect,tbcomercial_pre_pedido comercial_pre_pedido, tbcomercial_pre_pedido_item comercial_pre_pedido_item )
        {
            try
            {
                try
                {
                    Pag_Net.Bll.BDCommand.Post(MyConnect,
                            BDCommand.Name.F0132_03_comercial_pre_pedido_item_update,
                                string.Format(" 'DBINSERT', {0}, {1}, {2}, {3}, '{4}', {5}, '{6}', {7}, {8}, {9}, {10}, {11}"
                            , comercial_pre_pedido.cm_pre_ped_seq
                            , 0
                            , comercial_pre_pedido_item.pr_cdproduto
                            , comercial_pre_pedido_item.prb_cdprodutobluesoft
                            , comercial_pre_pedido_item.prb_embalagemestoque
                            , comercial_pre_pedido_item.prb_cdprodutobluesoft_compra
                            , comercial_pre_pedido_item.prb_embalagemcompra
                            , comercial_pre_pedido_item.prb_fatorestoque.ToString("0.00").Replace(",", ".")
                            , comercial_pre_pedido_item.cm_pre_ped_item_embalagemestoque_qtde.ToString("0.00").Replace(",", ".")
                            , comercial_pre_pedido_item.cm_pre_ped_item_embalagemcompra_qtde.ToString("0.00").Replace(",", ".")
                            , comercial_pre_pedido_item.cm_pre_ped_item_valor.ToString("0.00").Replace(",", ".")
                            , comercial_pre_pedido_item.cm_pre_ped_item_embalagemcompra_qtde_aut.ToString("0.00").Replace(",", ".")
                            ));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Pre_pedido_item_qtde_autorizada(Pag_Net.Models.modelSistemaUsuario MyConnect, int pre_pedido_seq, int _pr_cdproduto, double _cm_pre_ped_item_embalagemcompra_qtde_aut )
        {
            try
            {
                tbcomercial_pre_pedido _pre_pedido = new tbcomercial_pre_pedido();
                _pre_pedido.cm_pre_ped_seq = pre_pedido_seq;
                tbcomercial_pre_pedido_item _tbcomercial_pre_pedido_item = new tbcomercial_pre_pedido_item();
                _tbcomercial_pre_pedido_item.pr_cdproduto = _pr_cdproduto;
                _tbcomercial_pre_pedido_item.cm_pre_ped_item_embalagemcompra_qtde_aut = _cm_pre_ped_item_embalagemcompra_qtde_aut;
                Pre_pedido_item_update(MyConnect, _pre_pedido, _tbcomercial_pre_pedido_item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static tbcomercial_pre_pedido Pre_pedido_Inserir(Pag_Net.Models.modelSistemaUsuario MyConnect, tbcomercial_pre_pedido comercial_pre_pedido)
        {
            try
            {

                Pag_Net.Bll.Controle.tbcontrole __TbControle = Pag_Net.Bll.Controle.Comercial_PrePedido._Inserir_Novo_Controle(MyConnect);
                comercial_pre_pedido.proc_log_seq = __TbControle.proc_log_seq;
                comercial_pre_pedido.controle_reg_seq = __TbControle.controle_reg_seq;

                return new
                    tbcomercial_pre_pedido((Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, Pag_Net.Bll.F0132_02.Postgre.Post(comercial_pre_pedido))).Rows[0]);

                /*(Pag_Net.Bll.BDCommand.get_DataTable(MyConnect,
                        BDCommand.Name.F0132_02_comercial_pre_pedido_crud_result,
                        string.Format(" 'DBINSERT', {0}, {1}, {2}, '{3}', {4}, {5}, {6}",
                        __TbControle.proc_log_seq,
                        comercial_pre_pedido.cm_pre_ped_seq.ToString(),
                        comercial_pre_pedido.cm_pre_ped_cd.ToString(),
                        comercial_pre_pedido.cm_pre_ped_data.ToString("yyyy-MM-dd"),
                        comercial_pre_pedido.fabricante_cdpessoabluesoft.ToString(), 
                        comercial_pre_pedido.fat_res_seq.ToString(), 
                        __TbControle.controle_reg_seq.ToString()
                        )).Rows[0] */

                
                        ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static tbcomercial_pre_pedido Pre_pedido_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, tbcomercial_pre_pedido comercial_pre_pedido)
        {
            try
            {
                return new
                    tbcomercial_pre_pedido((Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, Pag_Net.Bll.F0132_02.Postgre.Get(comercial_pre_pedido))).Rows[0]);
               ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        
        public static tbfat_res_comercial_item_format_venda_qtde[] get_fat_res_comercial_item_format_venda_qtde(tbfat_res_comercial _fat_res_item)
        {
            List<tbfat_res_comercial_item_format_venda_qtde> _list = new List<tbfat_res_comercial_item_format_venda_qtde>();
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_01_qtde_desc.ToString(),Convert.ToDouble(_fat_res_item.mes_base_anual_01_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_02_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_02_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_03_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_03_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_04_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_04_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_05_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_05_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_06_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_06_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_07_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_07_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_08_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_08_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_09_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_09_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_10_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_10_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_11_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_11_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_12_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_12_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_base_anual_13_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_base_anual_13_qtde.ToString())));
            _list.Add(new tbfat_res_comercial_item_format_venda_qtde(_fat_res_item.mes_corrente_qtde_desc.ToString(), Convert.ToDouble(_fat_res_item.mes_corrente_qtde.ToString())));

            return _list.ToArray().OrderByDescending(c => c.mes_competencia).ToArray();

            //Precos_Unitarios = Precos_Unitarios.OrderBy(c => c.ec_valor_custo_precificacao).ToArray();
        }

    }

    public class tbcomercial_pre_pedido
    {
        public int cm_pre_ped_seq { get; set; }
        public      int cm_pre_ped_cd                   { get; set; }
        public      DateTime cm_pre_ped_data            { get; set; }
        public      int fabricante_cdpessoabluesoft     { get; set; }
        public int fat_res_seq { get; set; }
        public int controle_reg_seq { get; set;  }
        public int proc_log_seq { get; set;  }
        public int controle_status_cd { get; set; }
        public tbcomercial_pre_pedido()
        {
            cm_pre_ped_seq = 0;
            cm_pre_ped_cd = 0;
            cm_pre_ped_data = DateTime.Now;
            fabricante_cdpessoabluesoft = 0;
            fat_res_seq = 0;
            controle_reg_seq = 0;
            proc_log_seq = 0;
        }

        public tbcomercial_pre_pedido(
            int _cm_pre_ped_seq,
            int _cm_pre_ped_cd     ,         
            DateTime _cm_pre_ped_data       ,
            int _fabricante_cdpessoabluesoft,
            int _fat_res_seq,
            int _controle_reg_seq
            )
        {

            cm_pre_ped_seq = _cm_pre_ped_seq;
            cm_pre_ped_cd = _cm_pre_ped_cd;
            cm_pre_ped_data = _cm_pre_ped_data;
            fabricante_cdpessoabluesoft = _fabricante_cdpessoabluesoft;
            fat_res_seq = _fat_res_seq;
            controle_reg_seq = _controle_reg_seq;
            proc_log_seq = 0;

        }


        public tbcomercial_pre_pedido(
            int _cm_pre_ped_seq,
            int _cm_pre_ped_cd     ,         
            DateTime _cm_pre_ped_data       ,
            int _fabricante_cdpessoabluesoft,
            int _fat_res_seq,
            int _controle_reg_seq,
            int _proc_log_seq
            )
        {
            cm_pre_ped_seq = _cm_pre_ped_seq;
            cm_pre_ped_cd = _cm_pre_ped_cd;
            cm_pre_ped_data = _cm_pre_ped_data;
            fabricante_cdpessoabluesoft = _fabricante_cdpessoabluesoft;
            fat_res_seq = _fat_res_seq;
            controle_reg_seq = _controle_reg_seq;
            proc_log_seq = _proc_log_seq;

        }

        public tbcomercial_pre_pedido(DataRow i)
        {
            cm_pre_ped_seq = Convert.ToInt32(i["cm_pre_ped_seq"]);
            cm_pre_ped_cd = Convert.ToInt32(i["cm_pre_ped_cd"]);
            cm_pre_ped_data = Convert.ToDateTime(i["cm_pre_ped_data"]);
            fabricante_cdpessoabluesoft = Convert.ToInt32(i["fabricante_cdpessoabluesoft"]);
            fat_res_seq = Convert.ToInt32(i["fat_res_seq"]);
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"]);
            proc_log_seq = Convert.ToInt32(i["proc_log_seq"]);
            controle_status_cd = Convert.ToInt32(i["controle_status_cd"]);
        }
    }

    public class tbcomercial_pre_pedido_item
    {
        public int      cm_pre_ped_seq { get; set; }
        public int      cm_pre_ped_seq_item { get; set; }
        public int      pr_cdproduto { get; set; }
        public string   pr_descricao { get; set;  }
        public int      prb_cdprodutobluesoft { get; set; }
        public string   prb_embalagemestoque { get; set; }
        public int      prb_cdprodutobluesoft_compra { get; set; }
        public string   prb_embalagemcompra { get; set; }
        public double   prb_fatorestoque { get; set; }

        public double   ec_embalagemcompra_qtde { get; set; }
        public double   ec_embalagemestoque_qtde { get; set; }

        public double   cm_pre_ped_item_embalagemestoque_qtde { get; set; }
        public double   cm_pre_ped_item_embalagemestoque_qtde_aut { get; set; }
        public double   cm_pre_ped_item_embalagemcompra_qtde { get; set; }
        public double   cm_pre_ped_item_embalagemcompra_qtde_aut { get; set; }

        public double   cm_pre_ped_item_ec_valor_custo_precificacao { get; set; }
        public double   cm_pre_ped_item_ec_valor_custo_faturamento { get; set; }
        public double   cm_pre_ped_item_valor { get; set; }
        public tbcomercial_pre_pedido_item()
        {
            cm_pre_ped_seq = 0;
            cm_pre_ped_seq_item = 0;
            pr_cdproduto = 0;
            prb_cdprodutobluesoft = 0;
            prb_embalagemestoque = "UN";
            prb_cdprodutobluesoft_compra = 0;
            prb_embalagemcompra = "";
            prb_fatorestoque = 0;
            cm_pre_ped_item_embalagemestoque_qtde = 0;
            cm_pre_ped_item_embalagemestoque_qtde_aut = 0;
            cm_pre_ped_item_embalagemcompra_qtde = 0;
            cm_pre_ped_item_embalagemcompra_qtde_aut = 0;
            cm_pre_ped_item_ec_valor_custo_precificacao = 0;
            cm_pre_ped_item_ec_valor_custo_faturamento = 0;
            cm_pre_ped_item_valor = 0;
        }

        public tbcomercial_pre_pedido_item(DataRow i)
        {
            cm_pre_ped_seq                              = Convert.ToInt32(i["cm_pre_ped_seq"].ToString());
            cm_pre_ped_seq_item                         = Convert.ToInt32(i["cm_pre_ped_seq_item"].ToString());
            pr_cdproduto                                = Convert.ToInt32(i["pr_cdproduto"].ToString());
            prb_cdprodutobluesoft                       = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
            prb_embalagemestoque                        = i["prb_embalagemestoque"].ToString();
            prb_cdprodutobluesoft_compra                = Convert.ToInt32(i["prb_cdprodutobluesoft_compra"].ToString());
            prb_embalagemcompra                         = i["prb_embalagemcompra"].ToString();
            prb_fatorestoque                            = Convert.ToDouble(i["prb_fatorestoque"].ToString());
            cm_pre_ped_item_embalagemestoque_qtde       = Convert.ToDouble(i["cm_pre_ped_item_embalagemestoque_qtde"].ToString());
            cm_pre_ped_item_embalagemcompra_qtde        = Convert.ToDouble(i["cm_pre_ped_item_embalagemcompra_qtde"].ToString());
            cm_pre_ped_item_embalagemestoque_qtde_aut   = Convert.ToDouble(i["cm_pre_ped_item_embalagemestoque_aut"].ToString());
            cm_pre_ped_item_embalagemcompra_qtde_aut    = Convert.ToDouble(i["cm_pre_ped_item_embalagemcompra_aut"].ToString());

            cm_pre_ped_item_ec_valor_custo_precificacao = Convert.ToDouble(i["cm_pre_ped_item_ec_valor_custo_precificacao"].ToString());
            cm_pre_ped_item_ec_valor_custo_faturamento  = Convert.ToDouble(i["cm_pre_ped_item_ec_valor_custo_faturamento"].ToString());
            cm_pre_ped_item_valor                       = Convert.ToDouble(i["cm_pre_ped_item_valor"].ToString());
        }

        public tbcomercial_pre_pedido_item(tbfat_res_comercial i)
        {
            cm_pre_ped_seq = i.cm_pre_ped_seq;
            cm_pre_ped_seq_item = 0;
            pr_cdproduto                                = i.pr_cdproduto;
            prb_cdprodutobluesoft                       = i.prb_cdprodutobluesoft;
            prb_embalagemestoque                        = i.prb_embalagemestoque;
            prb_cdprodutobluesoft_compra                = i.prb_cdprodutobluesoft_compra;
            prb_embalagemcompra                         = i.prb_embalagemcompra;
            prb_fatorestoque                            = i.prb_fatorestoque;
            cm_pre_ped_item_embalagemestoque_qtde       = i.cm_pre_ped_item_embalagemestoque_qtde;
            cm_pre_ped_item_embalagemcompra_qtde        = i.cm_pre_ped_item_embalagemcompra_qtde;
            cm_pre_ped_item_embalagemcompra_qtde_aut = i.cm_pre_ped_item_embalagemcompra_qtde_aut;
            cm_pre_ped_item_ec_valor_custo_precificacao = i.ec_valor_custo_precificacao;
            cm_pre_ped_item_ec_valor_custo_faturamento = i.ec_valor_custo_precificacao;
            cm_pre_ped_item_valor                       = i.cm_pre_ped_item_valor;
        }

    }

    public class tbfat_res_comercial_item_format_venda_qtde
    {
        public string mes_competencia { get; set; }
        public double qtde { get; set; }
        public tbfat_res_comercial_item_format_venda_qtde (string _mes_competencia, double _qtde)
        {
            mes_competencia = _mes_competencia;
            qtde = _qtde;
        }

    }

    public class tbfat_res_comercial
    {

        public int          __seq_array                                 { get; set; }
        public int          fat_res_seq	                                {get; set; }                                                            
        public DateTime     fat_res_data	                            {get; set; }                                           
        public int          fv_fabricante_cdpessoabluesoft              { get; set; }                           
        public int          pr_cdproduto                                { get; set; }                                      
        public int          prb_cdprodutobluesoft                       { get; set; }                             
        public string       prb_embalagemestoque                        { get; set; }                           
        public int          prb_cdprodutobluesoft_compra                { get; set; }                      
        public string       prb_embalagemcompra                         { get; set; }                            
        public double       prb_fatorestoque                            { get; set; }                               
        public double       ec_embalagemestoque_qtde                    { get; set; }                       
        public double       ec_valor_custo_precificacao                 {get; set;}                      
        public double       ec_valor_custo_faturamento                  {get; set; }                      
        public int          ecd_seq                                     { get; set; }                                           
        public double       mes_base_anual_01_qtde                      { get; set;  }                        
        public double       mes_base_anual_02_qtde                      { get; set; }                         
        public double       mes_base_anual_03_qtde                      { get; set; }                         
        public double       mes_base_anual_04_qtde                      { get; set; }                         
        public double       mes_base_anual_05_qtde                      { get; set; }                         
        public double       mes_base_anual_06_qtde                      { get; set; }                         
        public double       mes_base_anual_07_qtde                      { get; set; }                         
        public double       mes_base_anual_08_qtde                      { get; set; }                         
        public double       mes_base_anual_09_qtde                      { get; set; }                         
        public double       mes_base_anual_10_qtde                      { get; set; }                         
        public double       mes_base_anual_11_qtde                      { get; set; }                         
        public double       mes_base_anual_12_qtde                      { get; set; }                         
        public double       mes_base_anual_13_qtde                      { get; set; }                         
        public double       mes_corrente_qtde                           { get; set; }                              
        public string       mes_base_anual_01_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_02_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_03_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_04_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_05_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_06_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_07_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_08_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_09_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_10_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_11_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_12_qtde_desc                 { get; set; }                    
        public string       mes_base_anual_13_qtde_desc                 { get; set; }                    
        public string       mes_corrente_qtde_desc                      { get; set; }                         
        public double       res_comercial_item_estoque_pendente         { get; set; }           
	    public double       res_comercial_item_estoque_disponivel       { get; set; }          
		public double       res_comercial_item_estoque_dias_cobertura   { get; set; }      
		public double       res_comercial_item_estoque_necessidade      { get; set; }         
        public DateTime     res_comercial_item_data_ult_venda           { get; set; }            
        public string       pr_descricao                                { get; set; }                                   
        public double       calc_ec_embalagemcompra_qtde                { get; set; }                   
        public string       prbf_codigo_referencia                      { get; set; }                         
        public int          cm_pre_ped_seq                              { get; set; }                               
                               
        public double       cm_pre_ped_item_embalagemestoque_qtde       { get; set; }          
        public double       cm_pre_ped_item_embalagemcompra_qtde        { get; set; }           
        public double       cm_pre_ped_item_valor                       { get; set; }                          
        public double       cm_pre_ped_item_embalagemcompra_qtde_aut     { get; set; }

        
        public double   _calc_valor_total_solicitado
        {
            get { return cm_pre_ped_item_valor * cm_pre_ped_item_embalagemcompra_qtde; }
        }

        public double   _calc_valor_total_autorizado
        {
            get { return cm_pre_ped_item_valor * cm_pre_ped_item_embalagemcompra_qtde_aut; }
        }

        public tbfat_res_comercial()
        {
         
        }

        public tbfat_res_comercial(DataRow i)
        {
          fat_res_seq	                                        = Convert.ToInt32(i["fat_res_seq"].ToString());
          fat_res_data	                                        = Convert.ToDateTime(i["fat_res_data"].ToString());
          fv_fabricante_cdpessoabluesoft                        = Convert.ToInt32(i["fv_fabricante_cdpessoabluesoft"].ToString());
          pr_cdproduto                                          = Convert.ToInt32(i["pr_cdproduto"].ToString());
          prb_cdprodutobluesoft                                 = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
          prb_embalagemestoque                                  = i["prb_embalagemestoque"].ToString();
          prb_cdprodutobluesoft_compra                          = Convert.ToInt32(i["prb_cdprodutobluesoft_compra"].ToString());
          prb_embalagemcompra                                   = i["prb_embalagemcompra"].ToString();                      
          prb_fatorestoque                                      = Convert.ToDouble(i["prb_fatorestoque"].ToString());
          ec_embalagemestoque_qtde                              = Convert.ToDouble(i["ec_embalagemestoque_qtde"].ToString());
          ec_valor_custo_precificacao                           = Convert.ToDouble(i["ec_valor_custo_precificacao"].ToString());
          ec_valor_custo_faturamento                            = Convert.ToDouble(i["ec_valor_custo_faturamento"].ToString());
          //ecd_seq                                               = Convert.ToInt32(i["ecd_seq"].ToString());
          ecd_seq = 0;
          mes_base_anual_01_qtde                                = Convert.ToDouble(i["mes_base_anual_01_qtde"].ToString()) ;
          mes_base_anual_02_qtde                                = Convert.ToDouble(i["mes_base_anual_02_qtde"].ToString()) ;
          mes_base_anual_03_qtde                                = Convert.ToDouble(i["mes_base_anual_03_qtde"].ToString()) ;
          mes_base_anual_04_qtde                                = Convert.ToDouble(i["mes_base_anual_04_qtde"].ToString()) ;
          mes_base_anual_05_qtde                                = Convert.ToDouble(i["mes_base_anual_05_qtde"].ToString())  ;
          mes_base_anual_06_qtde                                = Convert.ToDouble(i["mes_base_anual_06_qtde"].ToString())  ;
          mes_base_anual_07_qtde                                = Convert.ToDouble(i["mes_base_anual_07_qtde"].ToString())  ;
          mes_base_anual_08_qtde                                = Convert.ToDouble(i["mes_base_anual_08_qtde"].ToString())  ;
          mes_base_anual_09_qtde                                = Convert.ToDouble(i["mes_base_anual_09_qtde"].ToString())  ;
          mes_base_anual_10_qtde                                = Convert.ToDouble(i["mes_base_anual_10_qtde"].ToString())  ;
          mes_base_anual_11_qtde                                = Convert.ToDouble(i["mes_base_anual_11_qtde"].ToString())  ;
          mes_base_anual_12_qtde                                = Convert.ToDouble(i["mes_base_anual_12_qtde"].ToString())  ;
          mes_base_anual_13_qtde                                = Convert.ToDouble(i["mes_base_anual_13_qtde"].ToString()) ;
          mes_corrente_qtde                                     = Convert.ToDouble(i["mes_corrente_qtde"].ToString());
          mes_base_anual_01_qtde_desc                           = i["mes_base_anual_01_qtde_desc"].ToString();
          mes_base_anual_02_qtde_desc                           = i["mes_base_anual_02_qtde_desc"].ToString();
          mes_base_anual_03_qtde_desc                           = i["mes_base_anual_03_qtde_desc"].ToString();
          mes_base_anual_04_qtde_desc                           = i["mes_base_anual_04_qtde_desc"].ToString();
          mes_base_anual_05_qtde_desc                           = i["mes_base_anual_05_qtde_desc"].ToString();
          mes_base_anual_06_qtde_desc                           = i["mes_base_anual_06_qtde_desc"].ToString();
          mes_base_anual_07_qtde_desc                           = i["mes_base_anual_07_qtde_desc"].ToString();
          mes_base_anual_08_qtde_desc                           = i["mes_base_anual_08_qtde_desc"].ToString();
          mes_base_anual_09_qtde_desc                           = i["mes_base_anual_09_qtde_desc"].ToString();
          mes_base_anual_10_qtde_desc                           = i["mes_base_anual_10_qtde_desc"].ToString();              
          mes_base_anual_11_qtde_desc                           = i["mes_base_anual_11_qtde_desc"].ToString();              
          mes_base_anual_12_qtde_desc                           = i["mes_base_anual_12_qtde_desc"].ToString();              
          mes_base_anual_13_qtde_desc                           = i["mes_base_anual_13_qtde_desc"].ToString();              
          mes_corrente_qtde_desc                                = i["mes_corrente_qtde_desc"].ToString();                   
          res_comercial_item_estoque_pendente                   = Convert.ToDouble(i["res_comercial_item_estoque_pendente"].ToString()) ;      
          res_comercial_item_estoque_disponivel                 = Convert.ToDouble(i["res_comercial_item_estoque_disponivel"].ToString()) ;    
          res_comercial_item_estoque_dias_cobertura             = Convert.ToDouble(i["res_comercial_item_estoque_dias_cobertura"].ToString()) ;
          res_comercial_item_estoque_necessidade                = Convert.ToDouble(i["res_comercial_item_estoque_necessidade"].ToString()) ;   
          res_comercial_item_data_ult_venda                     = Convert.ToDateTime(i["res_comercial_item_data_ult_venda"].ToString()) ;        
          pr_descricao                                          = i["pr_descricao"].ToString();                          
          calc_ec_embalagemcompra_qtde                          = Convert.ToDouble(i["calc_ec_embalagemcompra_qtde"].ToString());
          prbf_codigo_referencia                                = i["prbf_codigo_referencia"].ToString();
          cm_pre_ped_seq                                        = Convert.ToInt32(i["cm_pre_ped_seq"].ToString());                           
          cm_pre_ped_item_embalagemestoque_qtde                 = Convert.ToDouble(i["cm_pre_ped_item_embalagemestoque_qtde"].ToString());   
          cm_pre_ped_item_embalagemcompra_qtde                  = Convert.ToDouble(i["cm_pre_ped_item_embalagemcompra_qtde"].ToString());
          cm_pre_ped_item_valor = ec_valor_custo_precificacao;
          cm_pre_ped_item_embalagemcompra_qtde_aut              = Convert.ToDouble(i["cm_pre_ped_item_embalagemcompra_qtde_aut"].ToString()); 





        }
    }

}




