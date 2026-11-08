using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll
{
    public static class NP0049_01_BancoContaBancaria
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                string ScriptRedShift_SELECT =  Pag_Net.Bll.F0049_01.RedShift.get(
                            Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, "F0049", 4901),
                            Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, "F0049", 4901)
                    
                    );
                DX = DbSelect.GetDataSet
                    (   MyConnect, Dal.DataBaseName.ODBCBI32, ScriptRedShift_SELECT,"");
                
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = DX.Tables[0].Rows.Count;
                string _Command_All = "";
                
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[1].ToString();
                    _Command_All = _Command_All + Pag_Net.Bll.F0049_01.Postgres.post(MyConnect, "DBINSERT", false, new Pag_Net.Bll.F0049_01.Db(dr)) + " ; ";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 100 || _SEQ_COUNT >= _COUNT)
                    {
                        DbUpdate BDExecute;
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                        //BDExecute.Execute(Pag_Net.Bll.F0060_02.Postgres.post(MyConnect, "DBINSERT", false, item), null, DataBaseName.ODBCOXAN);
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
                throw new Exception("Pag_Net.Bll.NP.0049.01.BancoContaBancaria: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}
