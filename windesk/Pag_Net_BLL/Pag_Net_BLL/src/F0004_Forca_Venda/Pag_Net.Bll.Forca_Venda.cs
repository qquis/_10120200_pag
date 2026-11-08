using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.src.F0210_Notificacao;
using System.Data;
using Pag_Net.Bll.F0004_Forca_Venda;
using Pag_Net.Dal;
namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class Wk
    {
        
    }


    

    public class WKFrete
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public ModelTbForca_Venda_Frete Frete;

        public WKFrete( Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Frete = new ModelTbForca_Venda_Frete();
        }

        public static void ImprimirFechamento(Pag_Net.Models.modelSistemaUsuario MyConnect, int CompetenciaCd, ModelTbForca_Venda_Roteiro[] Roteiros)
        {
            

        }
    }

    public static class BDBlueSoft_Import
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            //string ErroEtapaInfo = "";
            string ErroInfo = "";
            try
            {
                int _sis_nucleo_prc_cd = 100040010;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                DateTime Fv_Dt_Import_Ini = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, "F0004", _sis_nucleo_prc_cd);
                DateTime Fv_Dt_Import_Fim = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, "F0004", _sis_nucleo_prc_cd);
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "FV", string.Format("FV Data Fim: {0} ", Fv_Dt_Import_Ini.ToShortDateString()));
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "FV", string.Format("FV Data Ini: {0} ", Fv_Dt_Import_Fim.ToShortDateString()));


                /*--- ROTEIRO ------------------------------------------------ */
                //ErroEtapaInfo = "Roteiros ";
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;
                DataSet DataSet_ROTEIRO_BASE = new DataSet();
                string ScriptFV_Roteiro = Pag_Net.Bll.F0004_Forca_Venda.F0004_30_FV_Roteiro_CRUD.RedShift_Select(Fv_Dt_Import_Ini, Fv_Dt_Import_Fim);
                DataSet_ROTEIRO_BASE = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, ScriptFV_Roteiro, "");
                
                _COUNT = DataSet_ROTEIRO_BASE.Tables[0].Rows.Count;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "FV - Roteiro", string.Format("COUNT: {0}", _COUNT.ToString()));



                foreach (DataRow dr in DataSet_ROTEIRO_BASE.Tables[0].Rows)
                {
                    ErroInfo = "FV ROTEIRO: " + dr[0].ToString();
                    try
                    {
                        TbForca_Venda_Roteiro Item = new TbForca_Venda_Roteiro(dr);
                        _Command_All = _Command_All + Item.__SqlDBINSERT() + ";";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("BDBlueSoft_Import - Força de Venda [ROTEIRO] \n" + ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT)
                    {
                        try
                        {
                            Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "FV - Roteiro", string.Format("Item {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                            BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                            System.Threading.Thread.Sleep(250);
                            _Command_All = ""; _SEQ_UPDATE = 0;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Data Execute \n " +
                                                 "Error: " + ex.Message +
                                                 "\n" +
                                                 "---------------------------------------" +
                                                 _Command_All
                                                 );
                        }
                        
                    }
                }
                DataSet_ROTEIRO_BASE.Dispose();

                /*--- ROTEIRO ITEM ------------------------------------------------ */
                //ErroEtapaInfo = "Roteiro ITEM";
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;

                DataSet DataSet_ROTEIRO_ITEM = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Pag_Net.Bll.F0004_Forca_Venda.F0004_31_FV_Roteiro_Item_CRUD.RedShift_Select(Fv_Dt_Import_Ini, Fv_Dt_Import_Fim), "");

                _COUNT = DataSet_ROTEIRO_ITEM.Tables[0].Rows.Count;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "FV - Roteiro ITEM", string.Format("COUNT: {0}", _COUNT.ToString()));



                foreach (DataRow dr in DataSet_ROTEIRO_ITEM.Tables[0].Rows)
                {
                    ErroInfo = "FV ROTEIRO ITEM: " + dr[0].ToString();
                    try
                    {
                        TbForca_Venda_Roteiro_Item Item = new TbForca_Venda_Roteiro_Item(dr);
                        _Command_All = _Command_All + Item.__SqlDBINSERT() + ";";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("BDBlueSoft_Import - Força de Venda [ROTEIRO ITEM] \n" + ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT)
                    {
                        try
                        {
                            Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "FV - Roteiro ITEM", string.Format("Item {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                            BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                            System.Threading.Thread.Sleep(250);
                            _Command_All = ""; _SEQ_UPDATE = 0;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Data Execute \n " +
                                                 "Error: " + ex.Message +
                                                 "\n" +
                                                 "---------------------------------------" +
                                                 _Command_All
                                                 );
                        }

                    }
                }
                DataSet_ROTEIRO_ITEM.Dispose();

                /*--- ROTEIRO COMPLEMENTO ------------------------------------------------ */
                //ErroEtapaInfo = "Roteiro COMPL";
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;

                DataSet DataSet_ROTEIRO_COPL = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Pag_Net.Bll.F0004_Forca_Venda.F0004_32_FV_Roteiro_Compl_CRUD.RedShift_Select(Fv_Dt_Import_Ini, Fv_Dt_Import_Fim), "");

                _COUNT = DataSet_ROTEIRO_COPL.Tables[0].Rows.Count;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "FV - Roteiro COMPLEMENTO", string.Format("COUNT: {0}", _COUNT.ToString()));



                foreach (DataRow dr in DataSet_ROTEIRO_COPL.Tables[0].Rows)
                {
                    ErroInfo = "FV ROTEIRO COMPL: " + dr[0].ToString();
                    try
                    {
                        TbForca_Venda_Roteiro_Compl Item = new TbForca_Venda_Roteiro_Compl(dr);
                        _Command_All = _Command_All + Item.__SqlDBINSERT() + ";";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("BDBlueSoft_Import - Força de Venda [ROTEIRO COMPL] \n" + ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT)
                    {
                        try
                        {
                            Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "FV - Roteiro COMPL", string.Format("Item {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                            BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                            System.Threading.Thread.Sleep(250);
                            _Command_All = ""; _SEQ_UPDATE = 0;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Data Execute \n " +
                                                 "Error: " + ex.Message +
                                                 "\n" +
                                                 "---------------------------------------" +
                                                 _Command_All
                                                 );
                        }

                    }
                }
                DataSet_ROTEIRO_COPL.Dispose();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

    public static class Comissao
    {
        public static DataTable List(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia, int cdParticipanteVendedor, DateTime DataFechamentoInicial , DateTime DataFechamentoFinal)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_50_FV_Comissao_List.Get(competencia, cdParticipanteVendedor, DataFechamentoInicial , DataFechamentoFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Premio_List(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia, int cdParticipanteVendedor)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_70_FV_Premio_List.Get(competencia, cdParticipanteVendedor));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Detalhe(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia, int cdParticipanteVendedor, int fvc_seq)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_51_FV_Comissao_Detalhe.Get(competencia, cdParticipanteVendedor, fvc_seq));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Apuracao(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia, int cdParticipanteVendedor, DateTime DataFaturamentoInicial, DateTime DataFaturamentoFinal)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_55_FV_Comissao_Apuracao.Get(competencia, cdParticipanteVendedor, DataFaturamentoInicial, DataFaturamentoFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Apuracao_Item(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia, int cdParticipanteVendedor, DateTime DataFaturamentoInicial, DateTime DataFaturamentoFinal)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_55_FV_Comissao_Apuracao_Item.Get(competencia, cdParticipanteVendedor, DataFaturamentoInicial, DataFaturamentoFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Consolidar(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia, int cdParticipanteVendedor, DateTime DataFaturamentoInicial, DateTime DataFaturamentoFinal)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0004_60_FV_Comissao_Consolidar.Post(competencia, cdParticipanteVendedor, DataFaturamentoInicial, DataFaturamentoFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Alterar_Item(Pag_Net.Models.modelSistemaUsuario MyConnect, int vfvc_it_seq, double vpercentual_valor)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0004_20_FV_Comissao_Alterar_Item.Post(vfvc_it_seq, vpercentual_valor));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Alterar(Pag_Net.Models.modelSistemaUsuario MyConnect, int vfvc_seq, 
            double vfvc_fat_valor_pgto_complemento,
            double vfvc_fat_valor_pgto_impostos,
            double vfvc_fat_valor_pgto_adiantamentos

            
            )
        {
            try
            {
                BDCommand.Execute(MyConnect, F0004_21_FV_Comissao_Alterar.Post(vfvc_seq, vfvc_fat_valor_pgto_complemento, vfvc_fat_valor_pgto_impostos, vfvc_fat_valor_pgto_adiantamentos));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public static class Frete
    {
        public static DataTable Roteiros(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia_cd, int cdParticipanteMotorista, DateTime DataFechamentoInicial , DateTime DataFechamentoFinal)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect,  F0004_33_FV_roteiro_consultar.Get(competencia_cd, cdParticipanteMotorista, DataFechamentoInicial, DataFechamentoFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable RoteirosComplementos(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia_cd, int cdParticipanteMotorista, DateTime DataFechamentoInicial, DateTime DataFechamentoFinal, int roteiro_cd)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_35_FV_roteiro_compl_consultar.Get(competencia_cd, cdParticipanteMotorista, DataFechamentoInicial, DataFechamentoFinal, roteiro_cd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable RoteirosItem(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia_cd, int cdParticipanteMotorista, DateTime DataFechamentoInicial, DateTime DataFechamentoFinal, int roteiro_cd)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_34_FV_Roteiro_Item_Consultar.Get(competencia_cd, cdParticipanteMotorista, DataFechamentoInicial, DataFechamentoFinal, roteiro_cd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void FreteConsolidar(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia_cd, int cdParticipanteMotorista, DateTime DataFechamentoInicial, DateTime DataFechamentoFinal)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0004_40_FV_frete_consolidar.Post(competencia_cd, cdParticipanteMotorista, DataFechamentoInicial, DataFechamentoFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable FreteConsultar(Pag_Net.Models.modelSistemaUsuario MyConnect, int competencia_cd, int cdParticipanteMotorista, int fv_frete_seq)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_41_FV_frete_Consultar.Get(competencia_cd, cdParticipanteMotorista, fv_frete_seq));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  
        public static void FreteAtualizar(  Pag_Net.Models.modelSistemaUsuario MyConnect
                                        ,      int fv_frete_seq			 	
                                        ,	double fv_frete_valor			 	
                                        ,	double fv_frete_vl_compl	 		
                                        ,	double fv_frete_vl_base	 		
                                        ,	double fv_frete_vl_inss		 	
                                        ,	double fv_frete_vl_irpf		 	
                                        ,	double fv_frete_vl_sest		 	
                                        ,	double fv_frete_vl_senat		 	
                                        ,	double fv_frete_valor_liq			
                                        ,	double fv_frete_vl_antec_bb	 	
                                        ,	double fv_frete_vl_antec_especie	)
        {

        }

    }



    public class ModelTbForca_Venda_Roteiro: TbForca_Venda_Roteiro
    {
        public string nome_razao { get; set;  }
        public string cpf_cnpj { get; set;  }
        public double fv_frete_valor { get; set;  }
        public double fv_frete_ajuste_adicional { get; set;  }
        public double fv_frete_ajuste_desconto { get; set;  }
        public double fv_frete_vl_base { get; set;  }
        public ModelTbForca_Venda_Roteiro() : base()
        { 
        
        }
    }

    public class ModelTbForca_Venda_Roteiro_Item: TbForca_Venda_Roteiro_Item
    {
        public string nome_razao {get; set;}
        public string nome_razao_X { get; set; }
        public string cpf_cnpj { get; set;  }
        public DateTime roteiro_data_saida { get; set; }
        public int df_nf_numero { get; set; }
        public double fv_frete_valor { get; set;  }


        public ModelTbForca_Venda_Roteiro_Item(): base() 
        {
            nome_razao = "";
            cpf_cnpj = "";
            roteiro_data_saida = Convert.ToDateTime("1900-01-01");
            df_nf_numero = 0;
        }

    }

    public class ModelTbforca_Venda_Compl: TbForca_Venda_Roteiro_Compl
    {
        public ModelTbforca_Venda_Compl() : base() { }
    }


    public class ModelTbForca_Venda_Frete: TbForca_Venda_Frete
    {

        public ModelTbforca_Venda_Compl[] Complementos;
        public ModelTbForca_Venda_Roteiro_Item[] Itens;
        public string nome_razao {get; set;}
        public string cpf_cnpj { get; set;  }
        public double LOCAL_Vl_Deposito_Motorista {get; set;}
        public ModelTbForca_Venda_Frete() : base()
        {
            
        }

        public void Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                DataTable DR = Frete.FreteConsultar(MyConnect, 0,0,this.fv_frete_seq);

                base.DataBinding(DR.Rows[0]);
                nome_razao = DR.Rows[0]["nome_razao"].ToString();
                cpf_cnpj = DR.Rows[0]["cpf_cnpj"].ToString();

                List<ModelTbforca_Venda_Compl> LIST_COMPLEMENTOS = new List<ModelTbforca_Venda_Compl>();
                List<ModelTbForca_Venda_Roteiro_Item> LIST_ITENS = new List<ModelTbForca_Venda_Roteiro_Item>();



                DataTable DT_Complementos = Frete.RoteirosComplementos(MyConnect, this.competencia_cd, this.cdparticipante_motorista, this.fv_frete_dt_fechamento_ini, this.fv_frete_dt_fechamento_fim, 0);

                foreach (DataRow r in DT_Complementos.Rows)
                {
                    ModelTbforca_Venda_Compl ComplementoItem = new ModelTbforca_Venda_Compl();
                    ComplementoItem.DataBinding(r);
                    LIST_COMPLEMENTOS.Add(ComplementoItem);
                }
                this.Complementos = LIST_COMPLEMENTOS.ToArray();

                DataTable DT_ITENS = Frete.RoteirosItem(MyConnect, this.competencia_cd, this.cdparticipante_motorista, this.fv_frete_dt_fechamento_ini, this.fv_frete_dt_fechamento_fim, 0);

                foreach(DataRow x in DT_ITENS.Rows)
                {
                    ModelTbForca_Venda_Roteiro_Item RoteiroItem = new ModelTbForca_Venda_Roteiro_Item();
                    RoteiroItem.DataBinding(x);
                    RoteiroItem.nome_razao = x["nome_razao"].ToString();
                    RoteiroItem.cpf_cnpj = x["cpf_cnpj"].ToString();
                    RoteiroItem.roteiro_data_saida = Convert.ToDateTime(x["roteiro_data_saida"]);
                    RoteiroItem.df_nf_numero = Convert.ToInt32(x["df_nf_numero"].ToString());
                    RoteiroItem.fv_frete_valor = Convert.ToDouble(x["fv_frete_valor"].ToString());
                    LIST_ITENS.Add(RoteiroItem);
                }
                Itens = LIST_ITENS.ToArray();

            }

            catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
