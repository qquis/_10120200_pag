using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Pag_Net.Models;
namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class LogSitefImportacaoArquivo
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        private Pag_Net.Dal.DbUpdate DalUpdate;


        public string ArquivoSitefLog {get;set;}
        private string[] LinhasdoArquivo { get; set; }
        private List<string> _ProcessamentoLog;
        public List<string> ProcessamentoLog
        {
            get { return _ProcessamentoLog; }
            set
            {
                if (value  != null)
                {
                    _ProcessamentoLog = value;
                    this.OnPropertyChanged(this, new PropertyChangedEventArgs("ProcessamentoLog"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public LogSitefImportacaoArquivo(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            MyConnect = _myConnect;
            _ProcessamentoLog = new List<string>();
        }
        public void Processa()
        {
            try
            {
                ProcessamentoLog.Add("InterfaceImportacaoArquivo - Iniciando transação...");
                DalUpdate = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);
                this.DalUpdate.Begin();
                if (ProcessamentoStep1_Leitura() == false) { throw new Exception("Erro: Consulte a lista de Log"); }
                if (ProcessamentoStep2_InserirLinhas() == false) { throw new Exception("Erro: Consulte a lista de Log"); }
                if (ProcessamentoStep3_Processar() == false) { throw new Exception("Erro: Consulte a lista de Log"); }
                this.DalUpdate.Commit();
                this.DalUpdate.Close();
                ProcessamentoLog.Add("InterfaceImportacaoArquivo - Transação Concluida");
            }
            catch (Exception ex)
            {
                this.DalUpdate.RollBack();
                this.DalUpdate.Close();
                throw new Exception(ex.Message);
            }

        }
        private bool ProcessamentoStep1_Leitura()
        {
            ProcessamentoLog.Add("Leitura do Arquivo");
            try
            {
                this.LinhasdoArquivo = Pag_Net.Tools.LogFile.ReadLine(ArquivoSitefLog);
            }
            catch(Exception ex)
            {
                ProcessamentoLog.Add("Erro Leitura do Arquivo: " + ex.Message.ToString());
                return false;
            }
            return true;
            
        }
        private bool ProcessamentoStep2_InserirLinhas()
        {

            System.IO.FileInfo objf = new System.IO.FileInfo(this.ArquivoSitefLog);

            string NomeArquivo = objf.Name;
            DateTime LogDataHora;
            DateTime LogDataMovimento;
            

            LogDataHora = Convert.ToDateTime(LinhasdoArquivo[1].Substring(32, 10) + " " + LinhasdoArquivo[1].Substring(45, 8));
            LogDataMovimento = Convert.ToDateTime(LinhasdoArquivo[1].Substring(74, 10));
            string teste = LinhasdoArquivo[8].Substring(108, 9);
            ProcessamentoLog.Add("Processo Inserir Linhas");
            try
            {

                int NumeroLinha = 1;
                int UltimaLinhaProcessada = 0;
                DateTime UltimoProcessamento = DateTime.Now;

                List<ParameterQuey> listParametroInfo = new List<ParameterQuey>();
                listParametroInfo.Add(new ParameterQuey("TipoProcessamento", SqlDbType.VarChar, false, "STATUS_PROCESSAMENTO"));
                listParametroInfo.Add(new ParameterQuey("Arquivo", SqlDbType.VarChar, false, NomeArquivo ));
                DataSet Dados = DalUpdate.ExecuteGetDataset("UspSitefLogImportacao", listParametroInfo.ToArray());

                UltimaLinhaProcessada = Convert.ToInt32(Dados.Tables[0].Rows[0][0].ToString()) ;
                UltimoProcessamento = Convert.ToDateTime(Dados.Tables[0].Rows[0][1].ToString());

                if (UltimoProcessamento == LogDataHora)
                {
                    throw new Exception("Os registros desse arquivo ja foram processados...");
                }


                foreach (string i in LinhasdoArquivo)
                {
                    if (i.Length == 143)
                    {
                        string LinhaRegistro = i.Substring(132, 8);
                        if (LinhaRegistro == "0000002 ")
                        {
                            if (NumeroLinha > UltimaLinhaProcessada)
                            {
                                List<ParameterQuey> listParametro = new List<ParameterQuey>();
                                listParametro.Add(new ParameterQuey("TipoProcessamento", SqlDbType.VarChar, false, "INSERT"));
                                listParametro.Add(new ParameterQuey("Arquivo", SqlDbType.VarChar, false, NomeArquivo));
                                listParametro.Add(new ParameterQuey("Linha", SqlDbType.VarChar, true, i));
                                listParametro.Add(new ParameterQuey("LogDataHora", SqlDbType.DateTime, false, LogDataHora));
                                listParametro.Add(new ParameterQuey("LogDataMovimento", SqlDbType.DateTime, false, LogDataMovimento));
                                listParametro.Add(new ParameterQuey("SeqProcessamentoLinha", SqlDbType.Int, false, NumeroLinha));
                                int RegistrosAffetados = DalUpdate.Execute("UspSitefLogImportacao", listParametro.ToArray());
                            }
                        }
                    }
                    NumeroLinha += 1;
                }
            }
            catch (Exception ex)
            {
                ProcessamentoLog.Add("Erro Processo Inserir Linhas: " + ex.Message.ToString());
                return false;
            }
            return true;
        }
        private bool ProcessamentoStep3_Processar()
        {
            ProcessamentoLog.Add("Processamento de Registros");
            System.IO.FileInfo objf = new System.IO.FileInfo(this.ArquivoSitefLog);
            string NomeArquivo = objf.Name;
            try
            {
                List<ParameterQuey> listParametro = new List<ParameterQuey>();
                //listParametro.Add(new ParameterQuey("TipoProcessamento", SqlDbType.VarChar, false, "PROCESSAMENTO"));
                listParametro.Add(new ParameterQuey("Arquivo", SqlDbType.VarChar, false, NomeArquivo));
                int RegistrosAffetados = DalUpdate.Execute("UspSitefLogProcessamento", listParametro.ToArray());
            }
            catch (Exception ex)
            {
                ProcessamentoLog.Add("Erro Processamento de Registros: " + ex.Message.ToString());
                return false;
            }

            return true;
           
        }
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }
    }

}

