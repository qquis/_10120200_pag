using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0021_ProdutoBluesoft
{
    public class _index
    {
        public reports._indexReport reports;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public _index(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            reports = new reports._indexReport(MyConnect);
        }
    }
}


namespace Pag_Net.Bll.F0021_ProdutoBlueSoft
{
    public class Wk
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
        }
    }
    public static class Service_PRC_002
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                _ImportProdutoBlueSoft(MyConnect); /*Importação do Cadastro de Produto*/
                _ImportProdutoBlueSoftGtins(MyConnect); /*Importação do Cadastro de Gtins*/
                _ImportProdutoBlueSoftComposicao(MyConnect); /*Importação do Composição*/
                _ImportProdutoBlueSoftTributacao(MyConnect); /*Importação de Tributação*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        private static void _ImportProdutoBlueSoft(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            string ErroEtapaInfo = "";
            try
            {
                int _sis_nucleo_prc_cd = 2;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);



                /*--- DOCUMENTO FISCAL ------------------------------------------------ */
                ErroEtapaInfo = "ProdutoBlueSoft Error";
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;
                DataSet DATASET_Contrato_Servico = new DataSet();

                DATASET_Contrato_Servico = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, F0021_01_ProdutoBlueSoft_CRUD.RedShift_Select(), "");

                _COUNT = DATASET_Contrato_Servico.Tables[0].Rows.Count;

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "Produto BlueSoft", string.Format("COUNT: {0}", _COUNT.ToString()));



                foreach (DataRow dr in DATASET_Contrato_Servico.Tables[0].Rows)
                {
                    ErroInfo = "Produto BlueSoft Seq.: " + dr[3].ToString();
                    try
                    {
                        _Command_All = _Command_All + F0021_01_ProdutoBlueSoft_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, new TbProdutoBlueSoft(dr)) + " ; ";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 500 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "Produto BlueSoft", string.Format("REG {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DATASET_Contrato_Servico.Dispose();



                /*---------------------------------*/
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0021_ProdutoBlueSoft | TbProduto " + ErroEtapaInfo + " Erro: " + ErroInfo + " - " + ex.Message);
            }
        }
        private static void _ImportProdutoBlueSoftGtins(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            string ErroEtapaInfo = "";
            try
            {
                int _sis_nucleo_prc_cd = 2;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);



                /*--- DOCUMENTO FISCAL ------------------------------------------------ */
                ErroEtapaInfo = "ProdutoBlueSoftGTINS Error";
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;
                DataSet DATASET_Contrato_Servico = new DataSet();

                DATASET_Contrato_Servico = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, F0021_02_ProdutoBlueSoftGtins_CRUD.RedShift_Select(), "");

                _COUNT = DATASET_Contrato_Servico.Tables[0].Rows.Count;

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "Produto BlueSoft", string.Format("COUNT: {0}", _COUNT.ToString()));



                foreach (DataRow dr in DATASET_Contrato_Servico.Tables[0].Rows)
                {
                    ErroInfo = "ProdutoBlueSoftGTINS Seq.: " + dr[0].ToString();
                    try
                    {
                        _Command_All = _Command_All + F0021_02_ProdutoBlueSoftGtins_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, new TbProdutoBlueSoftGtins(dr)) + " ; ";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 500 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "ProdutoBlueSoftGTINS", string.Format("REG {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DATASET_Contrato_Servico.Dispose();



                /*---------------------------------*/
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0021_ProdutoBlueSoft | ProdutoBlueSoftGTINS" + ErroEtapaInfo + " Erro: " + ErroInfo + " - " + ex.Message);
            }
        }
        private static void _ImportProdutoBlueSoftComposicao(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            string ErroEtapaInfo = "";
            try
            {
                int _sis_nucleo_prc_cd = 2;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);



                /*--- DOCUMENTO FISCAL ------------------------------------------------ */
                ErroEtapaInfo = "ProdutoBlueSoftComposicao Error";
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;
                DataSet DATASET_Contrato_Servico = new DataSet();

                DATASET_Contrato_Servico = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, F0021_03_ProdutoBlueSoftComposicao_CRUD.RedShift_Select(), "");

                _COUNT = DATASET_Contrato_Servico.Tables[0].Rows.Count;

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "ProdutoBlueSoftComposicao", string.Format("COUNT: {0}", _COUNT.ToString()));



                foreach (DataRow dr in DATASET_Contrato_Servico.Tables[0].Rows)
                {
                    ErroInfo = "ProdutoBlueSoftComposicao Seq.: " + dr[0].ToString();
                    try
                    {
                        _Command_All = _Command_All + F0021_03_ProdutoBlueSoftComposicao_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, new TbProdutoBlueSoftComposicao(dr)) + " ; ";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 500 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "ProdutoBlueSoftComposicao", string.Format("REG {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DATASET_Contrato_Servico.Dispose();



                /*---------------------------------*/
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0021_ProdutoBlueSoft | ProdutoBlueSoftComposicao" + ErroEtapaInfo + " Erro: " + ErroInfo + " - " + ex.Message);
            }
        }
        private static void _ImportProdutoBlueSoftTributacao(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            string ErroEtapaInfo = "";
            try
            {
                int _sis_nucleo_prc_cd = 7;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                ErroEtapaInfo = "Pag_Net.Bll.F0021_ProdutoBlueSoft | BDBlueSof_Import - Select RedShift";
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;
                DataSet DATASET_Contrato_Servico = new DataSet();




                DATASET_Contrato_Servico = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, Pag_Net.Bll.F0021_ProdutoBlueSoft.F0021_04_Produto_Tributacao_CRUD.RedShift_Select(), "");

                _COUNT = DATASET_Contrato_Servico.Tables[0].Rows.Count;

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "F0021_ProdutoBlueSoft ", string.Format("COUNT: {0}", _COUNT.ToString()));



                foreach (DataRow dr in DATASET_Contrato_Servico.Tables[0].Rows)
                {
                    ErroInfo = "";
                    try
                    {
                        _Command_All = _Command_All + Pag_Net.Bll.F0021_ProdutoBlueSoft.F0021_04_Produto_Tributacao_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, new Pag_Net.Bll.F0021_ProdutoBlueSoft.TbProdutoTributacao(dr)) + " ; ";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "F0021_ProdutoBlueSoft", string.Format("Produto Tributacao REG {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DATASET_Contrato_Servico.Dispose();



                /*---------------------------------*/
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0023_ProdutoTributacao " + ErroEtapaInfo + " Erro: " + ErroInfo + " - " + ex.Message);
            }
        }
    }

    public static class Service_PRC_003
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0021_90_ProdutoBlueSoftProcessamento.Post());
                //DbUpdate BDExecute;
                //BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                //BDExecute.Execute(F0021_90_ProdutoBlueSoftProcessamento.Post(), null, DataBaseName.ODBCOXAN);
                //BDExecute.Close(DataBaseName.ODBCOXAN);
                //BDExecute.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class Model_TbProdutoBluesoft : TbProdutoBlueSoft
    {
        public Model_TbProdutoBluesoft(DataRow i)
            : base(i)
        {

        }
    }

}
