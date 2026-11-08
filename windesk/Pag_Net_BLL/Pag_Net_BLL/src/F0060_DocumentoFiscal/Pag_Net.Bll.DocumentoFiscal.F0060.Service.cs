/*
    Pag_Net.Bll.DocumentoFiscal.P0060_Service
    27/03/2022[1] - Criação
    31/03/2022[1] - Ajuste 
 * 
 * 
 */

using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;



namespace Pag_Net.Bll.F0060_DocumentoFiscal
{

    public static class Service
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            string ErroEtapaInfo = "";
            try
            {
                int _sis_nucleo_prc_cd = 60;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                DateTime __DATA_MOVIMENTO_INICIAL = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, "F0060", _sis_nucleo_prc_cd);
                DateTime __DATA_MOVIMENTO_FINAL = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, "F0060", _sis_nucleo_prc_cd);
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF.DtIni: {0} ", __DATA_MOVIMENTO_INICIAL.ToShortDateString()));
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("00.DocF.DtFim: {0} ", __DATA_MOVIMENTO_FINAL.ToShortDateString()));



                /*--- DOCUMENTO FISCAL ------------------------------------------------ */

                ErroEtapaInfo = "TIPO DOCUMENTO FISCAL";
                _Command_All = "";
                _SEQ_UPDATE = 0;
                _SEQ_COUNT = 0;
                _COUNT = 0;
                DataSet DataSelect_TIPO_NF = new DataSet();

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("TIPO NF"));

                string ScriptSELECT_TIPO_NF = "select nf_tipo_key as df_nf_tipo, " + 
                                              "       descricao   as df_nf_tipo_descricao " + 
                                              "from   nota_fiscal_tipo order by 1 asc";

                DataSelect_TIPO_NF = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, ScriptSELECT_TIPO_NF, "");
                _COUNT = DataSelect_TIPO_NF.Tables[0].Rows.Count;
                
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, string.Format("TIPO NF", _COUNT.ToString()));
                
                _Command_All = "";
                foreach (DataRow dr in DataSelect_TIPO_NF.Tables[0].Rows)
                {
                    _Command_All = _Command_All + "INSERT tbdocumentofiscal_tipo (df_nf_tipo, df_nf_tipo_descricao) " +
                                                       string.Format("SELECT {0}, '{1}' WHERE NOT EXISTS (SELECT 1 FROM tbdocumentofiscal_tipo WHERE  df_nf_tipo = {0}) ;  " +
                                                       "UPDATE tbdocumentofiscal_tipo set df_nf_tipo_descriccao = '{1}' WHERE df_nf_tipo = {0} ; ", dr[0].ToString(), dr[1].ToString().Replace("'", "").TrimEnd());
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("Doc Fiscal Tipo - UPDATE/INSERT"));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(15);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }









      
                /*--- DOCUMENTO FISCAL ------------------------------------------------ */
                ErroEtapaInfo = "Documento Fiscal";
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;
                DataSet DataSelect_DocumentoFiscal = new DataSet();
                string ScriptSELECT_DOCUMENTO_FISCAL =  Pag_Net.Bll.F0060_DocumentoFiscal._01_DocumentoFiscal.RedShift.get(
                            __DATA_MOVIMENTO_INICIAL,
                            __DATA_MOVIMENTO_FINAL
                    );
                DataSelect_DocumentoFiscal = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, ScriptSELECT_DOCUMENTO_FISCAL, "");
                _COUNT = DataSelect_DocumentoFiscal.Tables[0].Rows.Count;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF.COUNT: {0}", _COUNT.ToString()));
                foreach (DataRow dr in DataSelect_DocumentoFiscal.Tables[0].Rows)
                {
                    ErroInfo = "Id Log | Redshift.nota_fiscal.nf_key / Postgre.tbdocumentofiscal.df_nf_seq_blue: " + dr[2].ToString();
                    try
                    {
                        _Command_All = _Command_All + Pag_Net.Bll.F0060_DocumentoFiscal._01_DocumentoFiscal.Postgres.post(MyConnect, "DBINSERT", false, new Pag_Net.Bll.F0060_DocumentoFiscal.Db.DocumentoFiscal(dr)) + " ; ";
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT )
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0; 
                    }
                }
                DataSelect_DocumentoFiscal.Dispose();



                /*--- DOCUMENTO FISCAL ORIGEM ------------------------------------------------ */
                ErroEtapaInfo = "Documento Fiscal ORIGEM";                
                _Command_All = "";
                _SEQ_UPDATE = 0;
                _SEQ_COUNT = 0;
                _COUNT = 0;
                _Command_All = ""; _SEQ_UPDATE = 0; _SEQ_COUNT = 0; _COUNT = 0;
                DataSet DataSelect_DocumentoFiscal_Origem = new DataSet();
                string ScriptSELECT_DOCUMENTO_FISCAL_ORIGEM = Pag_Net.Bll.F0060_DocumentoFiscal._07_DocumentoFiscalOrigem.RedShift.get(
                            __DATA_MOVIMENTO_INICIAL,
                            __DATA_MOVIMENTO_FINAL
                    );
                DataSelect_DocumentoFiscal_Origem = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, ScriptSELECT_DOCUMENTO_FISCAL_ORIGEM, "");

                _COUNT = DataSelect_DocumentoFiscal_Origem.Tables[0].Rows.Count;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd,"DocumentoFiscal", string.Format("60.DocF.Origem: {0}", _COUNT.ToString()));

                /* Block01 - Insert PostGre*/
                foreach (DataRow dr in DataSelect_DocumentoFiscal_Origem.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[1].ToString();
                    _Command_All = _Command_All + Pag_Net.Bll.F0060_DocumentoFiscal._07_DocumentoFiscalOrigem.Postgre.Post(MyConnect, "DBINSERT", false, new Pag_Net.Bll.F0060_DocumentoFiscal.Db.DocumentoFiscalOrigem(dr)) + " ; ";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;

                    if (_SEQ_UPDATE >= 300 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF.Origem(DEVOLUÇÕES/RECUSA) - {0} - : {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DataSelect_DocumentoFiscal_Origem.Dispose();


                /*--- DOCUMENTO FISCAL ITEM ------------------------------------------------ */
                ErroEtapaInfo = "Documento Fiscal Item";                
                _Command_All = "";
                _SEQ_UPDATE = 0;
                _SEQ_COUNT = 0;
                _COUNT = 0;
                DataSet DataSelect_DocumentoFiscal_ITEM = new DataSet();
                string ScriptRedShift_SELECT = Pag_Net.Bll.F0060_02.RedShift.get(
                            __DATA_MOVIMENTO_INICIAL,
                            __DATA_MOVIMENTO_FINAL
                    );
                DataSelect_DocumentoFiscal_ITEM = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, ScriptRedShift_SELECT, "");

                _COUNT = DataSelect_DocumentoFiscal_ITEM.Tables[0].Rows.Count;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF.Item.COUNT: {0}", _COUNT.ToString()));
                _Command_All = "";

                foreach (DataRow dr in DataSelect_DocumentoFiscal_ITEM.Tables[0].Rows)
                {
                    ErroInfo = string.Format( "Nota Fiscal NF KEY {0} ITEM KEY  {1} ",dr[1].ToString(), dr[2].ToString());
                    _Command_All = _Command_All + Pag_Net.Bll.F0060_DocumentoFiscal._02_DocumentoFiscalItem.Postgres.post(MyConnect, "DBINSERT", false, new Pag_Net.Bll.F0060_DocumentoFiscal.Db.DocumentoFiscalItem(dr)) + " ; ";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;

                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF.Iem: {0} - {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DataSelect_DocumentoFiscal_ITEM.Dispose();





                /*--- DOCUMENTO FISCAL SEQ ------------------------------------------------ */

                
                ErroEtapaInfo = "Documento Fiscal Seq";                
                _Command_All = "";
                _SEQ_UPDATE = 0;
                _SEQ_COUNT = 0;
                _COUNT = 0;
                DataSet DataSelect_DocumentoFiscal_SEQ = new DataSet();
                __DATA_MOVIMENTO_INICIAL = __DATA_MOVIMENTO_INICIAL.AddDays(-30);

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF.Seq Data Inicial Considerada {0} ", __DATA_MOVIMENTO_INICIAL.ToString("dd-MM-yyyy")));
                string ScriptSELECT_DOCUMENTO_FISCAL_SEQ = Pag_Net.Bll.F0060_DocumentoFiscal._04_DocumentoFiscalSeq.RedShift.get(__DATA_MOVIMENTO_INICIAL, __DATA_MOVIMENTO_FINAL);
                DataSelect_DocumentoFiscal_SEQ = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, ScriptSELECT_DOCUMENTO_FISCAL_SEQ, "");
                _COUNT = DataSelect_DocumentoFiscal_SEQ.Tables[0].Rows.Count;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, string.Format("60.DocF.Seq: {0} ", _COUNT.ToString()));
                _Command_All = "";
                foreach (DataRow dr in DataSelect_DocumentoFiscal_SEQ.Tables[0].Rows)
                {
                    _Command_All = _Command_All + Pag_Net.Bll.F0060_DocumentoFiscal._04_DocumentoFiscalSeq.Postgres.post(MyConnect, "DBINSERT", false, new Pag_Net.Bll.F0060_DocumentoFiscal.Db.DocumentoFiscalSeq(dr)) + " ; ";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF.Seq - {0} - : {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }


                /*--- ATUALIZAR STATUS----------- */
                _Command_All = "";
                _SEQ_UPDATE = 0;
                _SEQ_COUNT = 0;
                _COUNT = 0;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF.Atualizar.Status"));

                Pag_Net.Bll.F0060_DocumentoFiscal.BD.DocumentoFiscalStatusRecebimento_Update(MyConnect);
                //BDExecute.Execute("SELECT " + BDCommand.ScriptSQL(BDCommand.Name.F0060_09_documentofiscalregistro_status_recebimento) + "()", null, DataBaseName.ODBCOXAN);

                
                /*--- EXCLUIR CANCELADOS----------- */
                _Command_All = "";
                _SEQ_UPDATE = 0;
                _SEQ_COUNT = 0;
                _COUNT = 0;
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF.Seq.Excluir"));
                BDExecute.Execute("SELECT " + BDCommand.ScriptSQL(BDCommand.Name.F0060_08_documentofiscalregistro_excluir_procedimento) + "()", null, DataBaseName.ODBCOXAN);

                /*---------------------------------*/


                

            




                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.DocumentoFiscal.P0060_Service Etapa " + ErroEtapaInfo +  " Erro: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}
