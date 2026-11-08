using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0050_Faturamento_BlueSoft.service
{
    public static class F0050_5001
    {
       
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

            DateTime dataInicial = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, "F0050", 5001);
            DateTime dataFinal = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, "F0050", 5001);

            try
            {
                Pag_Net.Bll.Log.register(MyConnect, 5001, "PAG.WIN IMP_FAT_BLUE", "IMP_FAT_BLUE - Inicializando");
                faturamento(MyConnect, dataInicial, dataFinal);

                Pag_Net.Bll.Log.register(MyConnect, 5001, "PAG.WIN IMP_FAT_BLUE", "IMP_FAT_BLUE_ITEM - Inicializando");
                faturamento_item(MyConnect, dataInicial, dataFinal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void faturamento(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime dataInicial, DateTime dataFinal)
        {

            try
            {



                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                string _Command_All = "";

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);



                /*PROCESSAMENTO BASE (FATURAMENTO + FATURAMENTO_ORIGEM) */
                DataSet DataSet_FaturamentoBlueSoft = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, scripts.redshift_SELECT_Faturamento_Bluesoft.SELECT(dataInicial, dataFinal), "");

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5001, "PAG.WIN IMP_FAT_BLUE", string.Format("IMP_FAT_BLUE | De {0} a {1}", dataInicial.ToString("dd/MM/yyyy"), dataFinal.ToString("dd/MM/yyyy")));

                _COUNT = DataSet_FaturamentoBlueSoft.Tables[0].Rows.Count;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5001, "PAG.WIN IMP_FAT_BLUE", string.Format("IMP_FAT_BLUE | Numero de Registros {0}", _COUNT.ToString()));


                foreach (DataRow dr in DataSet_FaturamentoBlueSoft.Tables[0].Rows)
                {
                    model.model_faturamento_bluesoft itemModel = new model.model_faturamento_bluesoft();
                    itemModel.binding_redShift_faturamento(dr);
                    _Command_All += itemModel.script_faturamento_crud(Models.BDCommandTypes.DBINSERT);
                    _SEQ_COUNT += 1;
                    _SEQ_UPDATE += 1;
                    if (_SEQ_UPDATE > 50 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5001, "PAG.WIN IMP_FAT_BLUE", string.Format("IMP_FAT_BLUE | Processando {0}/{1}", _SEQ_COUNT.ToString(), _COUNT.ToString()));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                BDExecute.Dispose();
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5001, "PAG.WIN IMP_FAT_BLUE", string.Format("IMP_FAT_BLUE | Processo finalizado com sucesso "));
            }
            catch (Exception ex)
            {
                Pag_Net.Bll.Log.register(MyConnect, 5001, "PAG.WIN IMP_FAT_BLUE", "Error: " + ex.Message.Replace("'", ""));
                throw new Exception(ex.Message);
            }
       }

        public static void faturamento_item(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime dataInicial, DateTime dataFinal)
        {

            try
            {
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                string _Command_All = "";

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);



                /*PROCESSAMENTO BASE (FATURAMENTO + FATURAMENTO_ORIGEM) */
                DataSet DataSet_FaturamentoBlueSoft_Item = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, scripts.redshift_SELECT_Faturamento_Bluesoft_Itens.SELECT(dataInicial, dataFinal), "");

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5001, "PAG.WIN IMP_FAT_BLUE", string.Format("IMP_FAT_BLUE_ITEM | De {0} a {1}", dataInicial.ToString("dd/MM/yyyy"), dataFinal.ToString("dd/MM/yyyy")));

                _COUNT = DataSet_FaturamentoBlueSoft_Item.Tables[0].Rows.Count;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5001, "PAG.WIN IMP_FAT_BLUE", string.Format("IMP_FAT_BLUE_ITEM | Numero de Registros {0}", _COUNT.ToString()));


                foreach (DataRow dr in DataSet_FaturamentoBlueSoft_Item.Tables[0].Rows)
                {
                    model.model_faturamento_bluesoft_item itemModel = new model.model_faturamento_bluesoft_item();
                    itemModel.binding_redShift_faturamento(dr);
                    _Command_All += itemModel.script_faturamento_item_crud(Models.BDCommandTypes.DBINSERT);
                    _SEQ_COUNT += 1;
                    _SEQ_UPDATE += 1;
                    if (_SEQ_UPDATE > 50 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5001, "PAG.WIN IMP_FAT_BLUE", string.Format("IMP_FAT_BLUE_ITEM | Processando {0}/{1}", _SEQ_COUNT.ToString(), _COUNT.ToString()));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                BDExecute.Dispose();
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5001, "PAG.WIN IMP_FAT_BLUE", string.Format("IMP_FAT_BLUE_ITEM | Processo finalizado com sucesso "));
            }
            catch (Exception ex)
            {
                Pag_Net.Bll.Log.register(MyConnect, 5001, "PAG.WIN IMP_FAT_BLUE", "Error: " + ex.Message.Replace("'", ""));
                throw new Exception(ex.Message);
            }
        }

    }
}
