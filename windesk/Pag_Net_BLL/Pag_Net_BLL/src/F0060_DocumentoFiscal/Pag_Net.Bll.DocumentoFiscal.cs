using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0060_DocumentoFiscal.Db;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Bll.F0060_DocumentoFiscal;
namespace Pag_Net.Bll.F0060_DocumentoFiscal
{
    public class Wk 
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
        }
    }

    public class WkDocumentoFiscal: Wk
    {
        public ModeDocumentoFiscal[] DocumentoFiscais_List;
        public F0060_40_DocumentoFiscalList_Filter DocumentoFiscalConsultarFilter;

        public Int32 NumeroDeRegistors = 0 ;
        public double ValorMercadoriaTotal = 0;
        public double ValorMercadoriaNFTotal = 0;
        public double VolumeTotal = 0;        

        public WkDocumentoFiscal(Pag_Net.Models.modelSistemaUsuario _MyConnect) : base(_MyConnect)
        {
            DocumentoFiscalConsultarFilter = new F0060_40_DocumentoFiscalList_Filter();
        }
        public ModeDocumentoFiscal[] DocumentoFiscalList_Get()
        {
            ValorMercadoriaNFTotal = 0;
            ValorMercadoriaTotal = 0;
            VolumeTotal = 0;


            try
            {
                DataTable DtReportDocumentoFiscal = BD.DataTableDocumentoFiscalList_Select(MyConnect, DocumentoFiscalConsultarFilter);
                List<ModeDocumentoFiscal> listReportDocumentoFiscal = new List<ModeDocumentoFiscal>();

                foreach (DataRow i in DtReportDocumentoFiscal.Rows)
                {

                    ModeDocumentoFiscal x = new ModeDocumentoFiscal(i);
                    ValorMercadoriaNFTotal = ValorMercadoriaNFTotal + x.df_valor_total;
                    ValorMercadoriaTotal = ValorMercadoriaTotal + x.df_valor_total_mercadoria;
                    VolumeTotal = VolumeTotal + x.item_volume;
                    listReportDocumentoFiscal.Add(x);
                    
                }

                NumeroDeRegistors = listReportDocumentoFiscal.Count;

                return listReportDocumentoFiscal.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public class WkDocumentoFiscalRegistro : Wk
    {
        public ModelDocumentoFiscalRegistro[] ListaDeDocumentosFiscais;
        public ModelDocumentoFiscalRegistro Item;
        public ModelDocumentoFiscalRegistro ModelItem;
        public F0060_30_DocumentoFiscalRegistroList_Filter DocumentoFiscalRegistroList_Filter;

        public WkDocumentoFiscalRegistro(Pag_Net.Models.modelSistemaUsuario _MyConnect): base(_MyConnect)
        {

            DocumentoFiscalRegistroList_Filter = new F0060_30_DocumentoFiscalRegistroList_Filter();
            ModelItem = new ModelDocumentoFiscalRegistro();
            
            Item = new ModelDocumentoFiscalRegistro();
        }

        public TbDocumentoFiscalRegistro[] DocumentoFiscalRegistroList_Consultar()
        {

            DataTable DocumentoFiscalRegistro = BD.DataTableDocumentoFiscalRegistroList_Select(MyConnect, DocumentoFiscalRegistroList_Filter);
            List<ModelDocumentoFiscalRegistro> _List = new List<ModelDocumentoFiscalRegistro>();
            foreach(DataRow i in DocumentoFiscalRegistro.Rows)
            {
                _List.Add(new ModelDocumentoFiscalRegistro(i));
            }
            ListaDeDocumentosFiscais = _List.ToArray();
            return ListaDeDocumentosFiscais;
        }



        public void RegistroLista_Clear()
        {
            List<ModelDocumentoFiscalRegistro> _list = new List<ModelDocumentoFiscalRegistro>();
            ListaDeDocumentosFiscais = _list.ToArray();
        }
        public void RegistroLista_Incluir()
        {
            try
            {
                if (
                        (Item.dfr_nf_chave.Length < 44 || Item.dfr_nf_chave.Length == null)
                    && (Item.dfr_nf_numero == 0
                            && Item.dfr_cnpj_cpf == "0"
                            && Item.dfr_nf_serie == 0
                        )
                    )
                {
                    throw new Exception("Favor informar N. NF e CNPJ ou Chave da Nota Fiscal");

                }
                List<ModelDocumentoFiscalRegistro> _list = new List<ModelDocumentoFiscalRegistro>();
                if (ListaDeDocumentosFiscais != null)
                {
                    if (ListaDeDocumentosFiscais.Count() > 0)
                    {
                        _list = ListaDeDocumentosFiscais.ToList();
                    }
                }

                _list.Add(Item);
                Item = new ModelDocumentoFiscalRegistro();
                ListaDeDocumentosFiscais = _list.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro:" + ex.Message);
            }
        }
        public void RegistroLista_Efetivar()
        {
            try
            {
                /*
                string SQL_COMMAND = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                _COUNT = ListaDeDocumentosFiscais.Count();
                 */

                foreach (ModelDocumentoFiscalRegistro item in ListaDeDocumentosFiscais)
                {

                    /*SQL_COMMAND = SQL_COMMAND + Pag_Net.Bll.F0060_DocumentoFiscal._03_DocumentoFiscalRegistro.Postgres.post(MyConnect, item) + ";";

                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;

                    if (_SEQ_UPDATE > 100 || _SEQ_COUNT >= _COUNT)
                    {
                        _SEQ_UPDATE = 0;
                        DbUpdate BDExecute;
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                        BDExecute.Execute(SQL_COMMAND, null, DataBaseName.ODBCOXAN);
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        BDExecute.Dispose();
                        System.Threading.Thread.Sleep(250);
                        SQL_COMMAND = "";
                    }*/
                    item.DbInsert(MyConnect);
                }
                //RegistroLista_Clear();
                BD.DocumentoFiscalStatusRecebimento_Update(MyConnect);

            }
            catch (Exception ex)
            {
                throw new Exception("BLL_DocumentoFiscalRegistro | Efetivar(): " + ex.Message);
            }
        }
    }
    
    public static class BD
    {
        public static DataTable DataTableDocumentoFiscalList_Select(Pag_Net.Models.modelSistemaUsuario MyConnect, F0060_40_DocumentoFiscalList_Filter f0060_40 )
        {
                        try
            {
                return BDCommand.get_DataTable(MyConnect, f0060_40.sql_Get());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public static DataTable DataTableDocumentoFiscalRegistroList_Select(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Bll.F0060_DocumentoFiscal.F0060_30_DocumentoFiscalRegistroList_Filter f0060_30)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, f0060_30.sql_Get());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DocumentoFiscalStatusRecebimento_Update(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                BDExecute.Execute(Pag_Net.Bll.F0060_DocumentoFiscal._09_DocumentoFiscalStatusRecebimento.Postgre.Post(), null, DataBaseName.ODBCOXAN);
                BDExecute.Commit(DataBaseName.ODBCOXAN);
            }

            catch (Exception ex)
            {
                throw new Exception("Error Message: Pag_Net.Bll.F0060_DocumentoFiscal.Pool.DocumentoFiscalAutualizarStatusRecebimento " + ex.Message);
            }
        }
    }

    public static class BDBlueSoft_Import
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
                    _Command_All = _Command_All + "INSERT INTO tbdocumentofiscal_tipo (df_nf_tipo, df_nf_tipo_descricao) " +
                                                       string.Format("SELECT {0}, '{1}' WHERE NOT EXISTS (SELECT 1 FROM tbdocumentofiscal_tipo WHERE  df_nf_tipo = {0}) ;  " +
                                                       "UPDATE tbdocumentofiscal_tipo set df_nf_tipo_descricao = '{1}' WHERE df_nf_tipo = {0} ; ", dr[0].ToString(), dr[1].ToString().Replace("'", "").TrimEnd());
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
                string ScriptSELECT_DOCUMENTO_FISCAL = Pag_Net.Bll.F0060_DocumentoFiscal._01_DocumentoFiscal.RedShift.get(
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
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 300 || _SEQ_COUNT >= _COUNT)
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
                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "DocumentoFiscal", string.Format("60.DocF.Origem: {0}", _COUNT.ToString()));

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
                    ErroInfo = string.Format("Nota Fiscal NF KEY {0} ITEM KEY  {1} ", dr[1].ToString(), dr[2].ToString());
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
                throw new Exception("Pag_Net.Bll.DocumentoFiscal.P0060_Service Etapa " + ErroEtapaInfo + " Erro: " + ErroInfo + " - " + ex.Message);
            }
        }
    }

    public class ModeDocumentoFiscal : Db.DocumentoFiscal
    {
        public string nome_razao { get; set; }
        public string cpf_cnpj { get; set; }
        public string email_main { get; set; }
        public double item_mix { get; set; }
        public double item_volume { get; set; }

        public ModeDocumentoFiscal(DataRow i)
        {
            string error = "Open Register";
            try
            {
                this.df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
                error = "Registro NF N. " + df_nf_seq_blue.ToString();

                nome_razao = i["nome_razao"].ToString();
                cpf_cnpj = i["cpf_cnpj"].ToString();
                email_main = i["email_main"].ToString();

                this.df_nf_numero = Convert.ToInt32(i["df_nf_numero"].ToString());
                this.df_nf_serie = i["df_nf_serie"].ToString();
                this.df_cfop_generico = i["df_cfop_generico"].ToString();
                this.df_status_recebimento = i["df_status_recebimento"].ToString();
                this.df_manifestacao = Convert.ToInt32(i["df_manifestacao"].ToString());
                this.df_transportadora_descricao = i["df_transportadora_descricao"].ToString();
                this.df_transportadora_placa = i["df_transportadora_placa"].ToString();
                this.df_valor_total = Convert.ToDouble(i["df_valor_total"].ToString());
                this.df_valor_total_mercadoria = Convert.ToDouble(i["df_valor_total_mercadoria"].ToString());
                this.df_data_emissao = Convert.ToDateTime(i["df_data_emissao"].ToString());
                this.df_data_saida = Convert.ToDateTime(i["df_data_saida"].ToString());
                this.df_data_recebimento = Convert.ToDateTime(i["df_data_recebimento"].ToString());
                item_mix = Convert.ToDouble(i["item_mix"].ToString());
                item_volume = Convert.ToDouble(i["item_volume"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - " + error);
            }


        }
    }

    public class ModelDocumentoFiscalRegistro : Db.TbDocumentoFiscalRegistro
    {


        public string nome_razao { get; set; }
        public string df_cfop { get; set; }
        public string df_status_recebimento { get; set; }
        public int df_manifestacao { get; set; }

        public ModelDocumentoFiscalRegistro() : base() { }
        public ModelDocumentoFiscalRegistro(DataRow i) : base(i) 
        {
            df_manifestacao = Convert.ToInt32(i["df_manifestacao"].ToString());
            nome_razao = i["nome_razao"].ToString();
            df_cfop = i["df_cfop"].ToString();
            df_status_recebimento = i["df_status_recebimento"].ToString();
        
        }
        string df_status_descricao
        {

            get
            {
                string resultado = "NÃO INFORMADO";
                switch (df_manifestacao)
                {
                    case 1:
                        resultado = "SEM MANIFESTAÇÃO";
                        break;
                    case 2:
                        resultado = "CONFIRMAÇÃO DA OPERAÇÃO";
                        break;
                    case 3:
                        resultado = "CIÊNCIA DA OPERAÇÃO";
                        break;
                    case 4:
                        resultado = "DESCONHECIMENTO DA OPERAÇÃO";
                        break;
                    case 5:
                        resultado = "OPERAÇÃO NÃO REALIZADA";
                        break;
                }
                return resultado;
            }

        }

        public void DbInsert(Pag_Net.Models.modelSistemaUsuario MyConnect){try { DB(MyConnect, Models.BDCommandTypes.DBINSERT);} catch (Exception ex) {throw new Exception(ex.Message); }}
        
        public void DbUpdate(Pag_Net.Models.modelSistemaUsuario MyConnect) {try  { DB(MyConnect, Models.BDCommandTypes.DBUPDATE); } catch (Exception ex) {throw new Exception(ex.Message);} }

        public void DbSelect(Pag_Net.Models.modelSistemaUsuario MyConnect){try { DB(MyConnect, Models.BDCommandTypes.DBUPDATE); } catch (Exception ex) { throw new Exception(ex.Message); }}
        
        private void DB(Pag_Net.Models.modelSistemaUsuario MyConnect, Models.BDCommandTypes __BDCommandType)
        {
            try
            {
                DataTable DataTableDB = BDCommand.get_DataTable(MyConnect, Pag_Net.Bll.F0060_DocumentoFiscal.F0060_03_DocumentoFiscalRegistro_CRUD.post(MyConnect, __BDCommandType, this));
                TbDocumentoFiscalRegistro X = new TbDocumentoFiscalRegistro(DataTableDB.Rows[0]);
                this.controle_etapa_cd = X.controle_etapa_cd;
                this.controle_reg_seq = X.controle_reg_seq;
                this.df_seq = X.df_seq;
                this.dfr_nf_chave = X.dfr_nf_chave;
                this.dfr_nf_numero = X.dfr_nf_numero;
                this.dfr_nf_serie = X.dfr_nf_serie;
                this.dfr_nf_data_emissao = X.dfr_nf_data_emissao;
                this.dfr_seq = X.dfr_seq;
            }
            catch (Exception ex )
            {
                new Exception(ex.Message);
            }
        }
    }
}
