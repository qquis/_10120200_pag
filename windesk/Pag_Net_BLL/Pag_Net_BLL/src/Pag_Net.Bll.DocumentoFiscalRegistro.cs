using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;

namespace Pag_Net.Bll.DocumentoFiscalRegistro
{
    public class Pool
    {
        public Pag_Net.Bll.DocumentoFiscalRegistro.TbDocumentoFiscalRegistro[] ListaDeDocumentosFiscais;
        public Pag_Net.Bll.DocumentoFiscalRegistro.TbDocumentoFiscalRegistro Item;

        public int           _DocumentoFiscalNAOProcessado;
        public int           _DocumentoFiscalNAORecebida;
        public int           _StatusNfManifestacao ;
        public DateTime      _Data_Inicial_Registro;
        public DateTime      _Data_Final_Registro;


        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Pool (Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            MyConnect = _myConnect;
            Item = new TbDocumentoFiscalRegistro();
        }

        public void RegistroLista_Clear()
        {
            List<TbDocumentoFiscalRegistro> _list = new List<TbDocumentoFiscalRegistro>();
            ListaDeDocumentosFiscais = _list.ToArray();
        }
        /*public void RegistroLista_Incluir()
        {
            try
            {

                if (
                        ( Item.dfr_nf_chave.Length < 44 || Item.dfr_nf_chave.Length == null ) 
                    &&  (      Item.dfr_nf_numero == 0 
                            && Item.dfr_cnpj_cpf == "0"
                            && Item.dfr_nf_serie == 0
                        )
                    )
                {
                    throw new Exception("Favor informar N. NF e CNPJ ou Chave da Nota Fiscal");
                    
                }
                List<Pag_Net.Bll.DocumentoFiscalRegistro.TbDocumentoFiscalRegistro> _list = new List<Pag_Net.Bll.DocumentoFiscalRegistro.TbDocumentoFiscalRegistro>();
                if (ListaDeDocumentosFiscais != null)
                {
                    if (ListaDeDocumentosFiscais.Count() > 0)
                    {
                        _list = ListaDeDocumentosFiscais.ToList();
                    }
                }


                _list.Add(Item);
                Item = new Pag_Net.Bll.DocumentoFiscalRegistro.TbDocumentoFiscalRegistro();
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
                string SQL_COMMAND = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;

                _COUNT = ListaDeDocumentosFiscais.Count();

                foreach (TbDocumentoFiscalRegistro item in ListaDeDocumentosFiscais)
                {
                    SQL_COMMAND = SQL_COMMAND + string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0060_03) + " (	    " +
                                   "           'DBINSERT'        " +
                                   "       ,     {0}             " +
                                   "       ,    '{1}'            " +
                                   "       ,    '{2}'            " +
                                   "       ,    '{3}'            " +
                                   "       ,    '{4}'            " +
                                   "       ,     {5}             " +
                                   "       ,     {6}             " +
                                   "       ,     {7}             " + 
                                   "       ,     {8}             )",
                                   item.dfr_nf_numero,
                                   item.dfr_nf_serie,
                                   item.dfr_nf_data_emissao.ToString("yyyy-MM-dd"),
                                   item.dfr_nf_chave,
                                   item.dfr_cnpj_cpf,
                                   item.df_seq,
                                   item.entrada_saida_seq,
                                   item.controle_reg_seq.ToString(),
                                   item.controle_etapa_cd) + "; ";
                    // _Command_All = _Command_All + Pag_Net.Bll.F0060_03.Postgres.post(MyConnect, "DBINSERT", false, new Pag_Net.Bll.F0060_03.Db(item.dfr_nf_numero, item.dfr_nf_serie, item.dfr_nf_chave, item.dfr_cnpj_cpf, item.df_seq, item.entrada_saida_seq, item.dfr_nf_data_emissao)) + " ; ";

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
                    }
                }
                RegistroLista_Clear();
                Pag_Net.Bll.F0060_DocumentoFiscal.Pool.DocumentoFiscalAutualizarStatusRecebimento(MyConnect);

            }
            catch (Exception ex)
            {
                throw new Exception("BLL_DocumentoFiscalRegistro | Efetivar(): " + ex.Message);
            }
        }*/
        public DataTable RegistroLista_Consultar()
        {
            try 
            {
            DataTable DT = Pag_Net.Bll.R0060.Select._0001_DocumentoFiscalRegistro(MyConnect,
                                                                   _DocumentoFiscalNAOProcessado, 
                                                                   _DocumentoFiscalNAORecebida,
                                                                   _StatusNfManifestacao,
                                                                   _Data_Inicial_Registro,
                                                                   _Data_Final_Registro
                                                                            );
            return DT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public class TbDocumentoFiscalRegistro
    {

        private int __dfr_nf_numero;
        private string __dfr_cnpj_cpf;
        private string __dfr_nf_chave;
        private int __dfr_nf_serie;

        public int dfr_nf_numero
        {
            get
            {
                return __dfr_nf_numero;
            }
            set
            {
                try
                {
                    __dfr_nf_numero = value;
                }
                catch (Exception)
                {
                    __dfr_nf_numero = 0;
                }
            }

        }
        public int dfr_nf_serie
        {
            get
            {
                return __dfr_nf_serie;
            }
            set
            {
                __dfr_nf_serie = value;
            }
        }
        public string dfr_nf_chave
        {
            get
            {
                return __dfr_nf_chave;
            }
            set
            {
                if (Pag_Net.Models.BDTools.nfe_chave_validar(value.ToString()))
                {
                    __dfr_nf_chave = value;
                    __dfr_cnpj_cpf = __dfr_nf_chave.Substring(6, 14);
                    __dfr_nf_serie = Convert.ToInt32(__dfr_nf_chave.Substring(22, 3));
                    __dfr_nf_numero = Convert.ToInt32(__dfr_nf_chave.Substring(25, 9));
                }
                else
                {
                    __dfr_nf_chave = "0";

                }
            }

        }
        public string dfr_cnpj_cpf
        {
            get
            {
                return __dfr_cnpj_cpf;
            }

            set
            {
                if (value.ToString() != "0")
                {
                    if (Pag_Net.Models.BDTools.DocCPF_CNPJ_Validar(value))
                    {
                        __dfr_cnpj_cpf = value;
                    }
                    else
                    {
                        __dfr_cnpj_cpf = "";
                        throw new Exception("Cnpj/CPF Incorreto");

                    }
                }
                else
                {
                    __dfr_cnpj_cpf = "0";
                }

            }

        }
        public DateTime dfr_nf_data_emissao { get; set; }
        public int df_seq { get; set; }
        public int entrada_saida_seq { get; set; }
        public int dfr_seq { get; set; }
        public string nome_razao { get; set; }
        public string df_cfop { get; set; }
        public string df_status_recebimento { get; set; }
        public int df_manifestacao { get; set; }
        public int controle_reg_seq { get; set; }
        public int controle_etapa_cd { get; set; }
        
        
        
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




        public TbDocumentoFiscalRegistro()
        {
            dfr_nf_numero = 0;
            dfr_nf_serie = 0;
            dfr_nf_chave = "0";
            dfr_cnpj_cpf = "0";
            dfr_nf_data_emissao = DateTime.Now;
            df_seq = 0;
            entrada_saida_seq = 0;
            controle_reg_seq = 0;
            controle_etapa_cd = 1;
        }

        public TbDocumentoFiscalRegistro(DataRow i)
        {
            dfr_nf_numero = Convert.ToInt32(i["dfr_nf_numero"].ToString());
            dfr_nf_serie = Convert.ToInt32(i["dfr_nf_serie"].ToString());
            df_seq = Convert.ToInt32(i["df_seq"].ToString());
            entrada_saida_seq = Convert.ToInt32(i["entrada_saida_seq"].ToString());
            dfr_seq = Convert.ToInt32(i["dfr_seq"].ToString());
            df_manifestacao = Convert.ToInt32(i["df_manifestacao"].ToString());
            dfr_nf_chave = i["dfr_nf_chave"].ToString();
            dfr_cnpj_cpf = i["dfr_cnpj_cpf"].ToString();
            nome_razao = i["nome_razao"].ToString();
            df_cfop = i["df_cfop"].ToString();
            df_status_recebimento = i["df_status_recebimento"].ToString();
            controle_reg_seq = 0;
            controle_etapa_cd = 1;
        }
    }

}



