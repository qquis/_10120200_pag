using Pag_Net.Dal;
using Pag_Net.src.F0080_Financeiro.tbs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0080_Financeiro
{
    public static class services
    {
        public static void start(Pag_Net.Models.TbSysUserInfo MyConnect, int sis_nucleo_prc_cd)
        {
            try
            {
                if (sis_nucleo_prc_cd == 8001) prc_F0080_8001(MyConnect);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private static void prc_F0080_8001(Pag_Net.Models.TbSysUserInfo MyConnect)
        {
            string ErroInfo = "";
            try
            {
                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();


                string ScriptRedShift_SELECT = Pag_Net.src.F0080_Financeiro.scripts.redShift.AutorizacaoPagamentoSelect(
                                    Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, "F0080", 8001),
                                    Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, "F0080", 8001)
                    );
                DX = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, ScriptRedShift_SELECT, "");

                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = DX.Tables[0].Rows.Count;
                string _Command_All = "";

                Pag_Net.src.F9020_sistema_log.pool.GerarLog(MyConnect, 0, 8001, "AUTOPGTO", string.Format("INI {0}/{1}", _SEQ_COUNT, _COUNT), 0);

                foreach (DataRow dr in DX.Tables[0].Rows)
                {


                    model.model_AutorizacaoPagamento mAutorizaoPagamento = new model.model_AutorizacaoPagamento();
                    mAutorizaoPagamento.__Binding(dr);


                    ErroInfo = "ID: " + dr[1].ToString();
                    _Command_All = _Command_All + mAutorizaoPagamento.model_Script_RedShiftPostgre_Integ() + ";";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 100 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.src.F9020_sistema_log.pool.GerarLog(MyConnect, 0, 8001, "AUTOPGTO", string.Format("Reg {0}/{1}", _SEQ_COUNT, _COUNT), 0);

                        DbUpdate BDExecute;
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        BDExecute.Dispose();
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;

                    }
                }
                DX.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("prc_F0080_8001: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}
