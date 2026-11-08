using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0023_ProdutoTributacao
{
    public class WK
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public WK (Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
        }
    }

    public class BD
    {

    }
    public static class BDBlueSoft_Import
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
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

                ErroEtapaInfo = "Pag_Net.Bll.F0023_ProdutoTributacao | BDBlueSof_Import - Select RedShift";
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;
                DataSet DATASET_Contrato_Servico = new DataSet();




                DATASET_Contrato_Servico = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, Pag_Net.Bll.F0023_ProdutoTributacao.F0023_01_Produto_Tributacao_CRUD.RedShift_Select(), "");

                _COUNT = DATASET_Contrato_Servico.Tables[0].Rows.Count;

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "F0023_ProdTrib", string.Format("COUNT: {0}", _COUNT.ToString()));



                foreach (DataRow dr in DATASET_Contrato_Servico.Tables[0].Rows)
                {
                    ErroInfo = "";
                    try
                    {
                        _Command_All = _Command_All + Pag_Net.Bll.F0023_ProdutoTributacao.F0023_01_Produto_Tributacao_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, new Pag_Net.Bll.F0023_ProdutoTributacao.TbProdutoTributacao(dr)) + " ; ";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "F0023_ProdTrib", string.Format("Produto Tributacao REG {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
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
    public class Model_ProdutoTributacao:  TbProdutoTributacao
    {
        public Model_ProdutoTributacao () : base()
        {

        }

        public Model_ProdutoTributacao(DataRow i) : base (i)
        {

        }

    }
}
