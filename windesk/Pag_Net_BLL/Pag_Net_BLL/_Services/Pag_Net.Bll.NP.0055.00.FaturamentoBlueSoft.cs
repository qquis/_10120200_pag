using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll
{
    public static class NP0055_00_FaturamentoBlueSoft
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                
                DateTime __DATA_MOVIMENTO_INICIAL = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, "F0055", 5500);
                DateTime __DATA_MOVIMENTO_FINAL = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, "F0055", 5500);

                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                string _Command_All = "";


                /*RedShift TBFATURAMENTOBLUESOFT */
                DataSet DataSet_TbFaturamentoBlueSoft = new DataSet();
                string ScriptRedShift_TbFaturamentoBlueSoft = Pag_Net.Bll.F0055_06.RedShift.get(
                            __DATA_MOVIMENTO_INICIAL,
                            __DATA_MOVIMENTO_FINAL
                    );
                DataSet_TbFaturamentoBlueSoft = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, ScriptRedShift_TbFaturamentoBlueSoft, "");
 

                _COUNT = DataSet_TbFaturamentoBlueSoft.Tables[0].Rows.Count;


                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5500, string.Format("RShift TbFat Dt INICIAL Select {0}", __DATA_MOVIMENTO_INICIAL.ToShortDateString()));
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5500, string.Format("RShift TbFat Dt FINAL Select {0}", __DATA_MOVIMENTO_FINAL.ToShortDateString()));
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5500, string.Format("RedShift TbFat N. de Peds {0}", _COUNT.ToString()));

                foreach (DataRow dr in DataSet_TbFaturamentoBlueSoft.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[1].ToString();
                    _Command_All = _Command_All + Pag_Net.Bll.F0055_06.Postgre.Post(MyConnect, "DBINSERT", false, new Pag_Net.Bll.F0055_06.Db(dr)) + " ; ";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;

                    if (_SEQ_UPDATE >= 300 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5500, string.Format("{0}_Fat|bloq: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DataSet_TbFaturamentoBlueSoft.Dispose();


                /*RedShift TBFATURAMENTOBLUESOFT_ORIGEM */
                DataSet DataSet_TbFaturamentoBlueSoft_Origem = new DataSet();
                string ScriptRedShift_TbFaturamentoBlueSoft_Origem = Pag_Net.Bll.F0055_08.RedShift.get(
                            __DATA_MOVIMENTO_INICIAL,
                            __DATA_MOVIMENTO_FINAL
                    );
                DataSet_TbFaturamentoBlueSoft_Origem = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, ScriptRedShift_TbFaturamentoBlueSoft_Origem, "");

                _SEQ_UPDATE = 0;
                _SEQ_COUNT = 0;
                _COUNT = DataSet_TbFaturamentoBlueSoft_Origem.Tables[0].Rows.Count;
                _Command_All = "";

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5500, string.Format("RedShift TbFat_Origem N. de Peds/NF {0}", _COUNT.ToString()));

                foreach (DataRow dr in DataSet_TbFaturamentoBlueSoft_Origem.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[1].ToString();
                    _Command_All = _Command_All + Pag_Net.Bll.F0055_08.Postgre.Post(MyConnect, "DBINSERT", false, new Pag_Net.Bll.F0055_08.Db(dr)) + " ; ";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;

                    if (_SEQ_UPDATE >= 300 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5500, string.Format("{0}_Fat_OR|bloq: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DataSet_TbFaturamentoBlueSoft.Dispose();

                /*RedShift TBFATURAMENTOBLUESOFT_ITEM */
                DataSet DataSet_TbFaturamentoBlueSoft_ITEM = new DataSet();
                string ScriptRedShift_TbFaturamentoBlueSoft_ITEM = Pag_Net.Bll.F0055_07.RedShift.get(
                            __DATA_MOVIMENTO_INICIAL,
                            __DATA_MOVIMENTO_FINAL
                    );

                DataSet_TbFaturamentoBlueSoft_ITEM = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, ScriptRedShift_TbFaturamentoBlueSoft_ITEM, "");

                _SEQ_UPDATE = 0;
                _SEQ_COUNT = 0;
                _COUNT = DataSet_TbFaturamentoBlueSoft_ITEM.Tables[0].Rows.Count;
                _Command_All = "";


                foreach (DataRow dr in DataSet_TbFaturamentoBlueSoft_ITEM.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[1].ToString();
                    _Command_All = _Command_All + Pag_Net.Bll.F0055_07.Postgre.Post(MyConnect, "DBINSERT", false, new Pag_Net.Bll.F0055_07.Db(dr)) + " ; ";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE >= 150 || _SEQ_COUNT >= _COUNT)
                    {

                        //string __log_control_insert = Pag_Net.Bll.F9010_01.Postgre.Post(MyConnect, "DBINSERT", false, new F9010_01.Db(5500, string.Format("{0}_FatItem_INSERT|bloq: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT))); 
                        //BDExecute.Execute(__log_control_insert, null, DataBaseName.ODBCOXAN);

                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, 5500, string.Format("{0}_FatItem_INSERT|bloq: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));

                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(450);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.NP.0055.06.FaturamentoBlueSoft: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}
