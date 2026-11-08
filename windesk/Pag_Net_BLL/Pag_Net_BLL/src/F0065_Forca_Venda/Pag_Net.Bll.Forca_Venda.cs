using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.src.F0210_Notificacao;
using System.Data;
using Pag_Net.Bll.F0003_Loja;
using Pag_Net.Dal;
namespace Pag_Net.Bll.F0065_Forca_Venda
{
    public class Wk
    {

    }

    public static class Service
    {
        public static void ImportaTabPrecos(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

            try
            {
                int _sis_nucleo_prc_cd = 60;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;

                DataSet DataSelect = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, Pag_Net.Bll.F0065_Forca_Venda.F0065_15_ForcaVenda_TabPreco_CRUD.RedShift_Select(), "");

                
                _COUNT = DataSelect.Tables[0].Rows.Count;


                foreach (DataRow dr in DataSelect.Tables[0].Rows)
                {
                    try
                    {
                        _Command_All = _Command_All + Pag_Net.Bll.F0065_Forca_Venda.F0065_15_ForcaVenda_TabPreco_CRUD.Post
                            (   Models.BDCommandTypes.DBINSERT, 
                                Convert.ToInt32(dr["fv_tabelapreco_cd"].ToString()), 
                                dr["fv_tabelapreco_descricao"].ToString(), 
                                Convert.ToInt32(dr["fv_tabelapreco_status"].ToString())
                            
                            );
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 5 || _SEQ_COUNT >= _COUNT )
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0; 
                    }
                }
                DataSelect.Dispose();
                BDExecute.Dispose();

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
