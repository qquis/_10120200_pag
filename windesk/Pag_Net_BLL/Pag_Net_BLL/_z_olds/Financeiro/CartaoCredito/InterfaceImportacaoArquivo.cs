using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Pag_Net.Models;


namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class InterfaceImportacaoArquivo: INotifyPropertyChanged
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        private Pag_Net.Dal.DbUpdate DalUpdate;


        public string ArquivoSitefInterface {get;set;}
        public int SeqArquivo { get; set; }
        public string Interface { get; set; }
        public string[] LinhasdoArquivo { get; set; }
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

        public InterfaceImportacaoArquivo(Pag_Net.Models.modelSistemaUsuario _myConnect)
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
                if (ProcessamentoStep1_LeituraDoArquivo() == false) { throw new Exception("Erro: Consulte a lista de Log"); }
                if (ProcessamentoStep2_InserirSeqArquivo() == false) { throw new Exception("Erro: Consulte a lista de Log"); }
                if (ProcessamentoStep3_InserirLinhasArquivo() == false) { throw new Exception("Erro: Consulte a lista de Log"); }
                if (ProcessamentoStep4_Processa_Registros() == false) { throw new Exception("Erro: Consulte a lista de Log"); }
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
        private bool ProcessamentoStep1_LeituraDoArquivo()
        {
            ProcessamentoLog.Add("Leitura do Arquivo");
            try
            {
                this.LinhasdoArquivo = Pag_Net.Tools.LogFile.ReadLine(@ArquivoSitefInterface);
            }
            catch(Exception ex)
            {
                ProcessamentoLog.Add("Erro Leitura do Arquivo: " + ex.Message.ToString());
                return false;
            }
            return true;
            
        }
        private bool ProcessamentoStep2_InserirSeqArquivo()
        {
            ProcessamentoLog.Add("Inserir Arquivo");
            try
            {
                List<ParameterQuey> listParametro = new List<ParameterQuey>();
                listParametro.Add(new ParameterQuey("TipoProcessamento", SqlDbType.VarChar, false, "INSERE_ARQUIVO"));
                // listParametro.Add(new ParameterQuey("Interface", SqlDbType.VarChar, false, "CIELO"));
                listParametro.Add(new ParameterQuey("ArquivoProcessado", SqlDbType.VarChar, false, this.ArquivoSitefInterface));
                listParametro.Add(new ParameterQuey("LinhaArquivo", SqlDbType.VarChar, true, this.LinhasdoArquivo[0].ToString()));

                DataSet Dados = DalUpdate.ExecuteGetDataset("PrSitefLogInterface", listParametro.ToArray());
                SeqArquivo = Convert.ToInt32(Dados.Tables[0].Rows[0][0].ToString());
                Interface = Dados.Tables[0].Rows[0][1].ToString();
                if (SeqArquivo == 0)
                {
                    ProcessamentoLog.Add("Arquivo não Processado: Averiguar possibilidade de o arquivo já existir na base de dados");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ProcessamentoLog.Add("Erro Inserir Arquivo: " + ex.Message.ToString());
                return false;
            }
            return true;

        }
        private bool ProcessamentoStep3_InserirLinhasArquivo()
        {
            ProcessamentoLog.Add("Processo Inserir Linhas");
            try
            {
                foreach (string i in LinhasdoArquivo)
                {

                    List<ParameterQuey> listParametro = new List<ParameterQuey>();
                    listParametro.Add(new ParameterQuey("TipoProcessamento", SqlDbType.VarChar, false, "INSERE_LINHA"));
                    listParametro.Add(new ParameterQuey("Interface", SqlDbType.VarChar, false, Interface));
                    listParametro.Add(new ParameterQuey("ArquivoProcessado", SqlDbType.VarChar, false, this.ArquivoSitefInterface));
                    listParametro.Add(new ParameterQuey("SeqArquivo", SqlDbType.Int, true, this.SeqArquivo));
                    listParametro.Add(new ParameterQuey("LinhaArquivo", SqlDbType.VarChar, true, i));
                    int RegistrosAffetados = DalUpdate.Execute("PrSitefLogInterface", listParametro.ToArray());

                }
            }
            catch (Exception ex)
            {
                ProcessamentoLog.Add("Erro Processo Inserir Linhas: " + ex.Message.ToString());
                return false;
            }
            return true;
        }

        private bool ProcessamentoStep4_Processa_Registros()
        {
            ProcessamentoLog.Add("Processamento de Registros");
            try
            {
                List<ParameterQuey> listParametro = new List<ParameterQuey>();
                listParametro.Add(new ParameterQuey("TipoProcessamento", SqlDbType.VarChar, false, "PROCESSA_LINHA"));
                listParametro.Add(new ParameterQuey("Interface", SqlDbType.VarChar, false, Interface));
                listParametro.Add(new ParameterQuey("ArquivoProcessado", SqlDbType.VarChar, false, this.ArquivoSitefInterface));
                listParametro.Add(new ParameterQuey("SeqArquivo", SqlDbType.Int, true, this.SeqArquivo));
                int RegistrosAffetados = DalUpdate.Execute("PrSitefLogInterface", listParametro.ToArray());
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
