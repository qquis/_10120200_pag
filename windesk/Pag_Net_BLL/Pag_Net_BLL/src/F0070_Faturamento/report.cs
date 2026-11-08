using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.src.F0070_Faturamento;

namespace Pag_Net.src.F0070_Faturamento
{   


    public class _indexReport
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;

        //Interface
        public interfaces.globalFilter filterFaturamento;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        /*Faturamento CONSULTA*/
        private reports.rptFaturamentoConsulta __rptfaturamentoConsulta;
        public reports.rptFaturamentoConsulta rptfaturamentoConsulta
        {
            get { return __rptfaturamentoConsulta; }
            set
            {
                __rptfaturamentoConsulta = value;
                RaisePropertyChanged("rptFaturamentoConsulta");
            }
        }
        /*Faturamento CONSULTA*/
        private reports.rptFaturamentoItensList __rptfaturamentoItensList;
        public reports.rptFaturamentoItensList rptfaturamentoItensList
        {
            get { return __rptfaturamentoItensList; }
            set
            {
                __rptfaturamentoItensList = value;
                RaisePropertyChanged("rptfaturamentoItensList");
            }
        }



        /*Faturamento STATUS*/
        private reports.rptFaturamentoStatus __rptfaturamentoStatus;
        public reports.rptFaturamentoStatus rptfaturamentoStatus
        {
            get { return __rptfaturamentoStatus; }
            set
            {
                __rptfaturamentoStatus = value;
                RaisePropertyChanged("rptfaturamentoStatus");
            }
        }

        /*Faturamento TIPO DE VISUALIZAÇÃO*/
        private reports.rptFaturamentoTipoVisualizacao __rpttipoVisualizacao;
        public reports.rptFaturamentoTipoVisualizacao rpttipoVisualizacao
        {
            get { return __rpttipoVisualizacao; }
            set
            {
                __rpttipoVisualizacao = value;
                RaisePropertyChanged("rpttipoVisualizacao");
            }
        }

      
        
        /*Faturamento ANALISE*/
        private reports.rptFaturamentoAnalise __rptFaturamentoAnalise;
        public reports.rptFaturamentoAnalise rptFaturamentoAnalise
        {
            get { return __rptFaturamentoAnalise; }
            set
            {
                __rptFaturamentoAnalise = value;
                RaisePropertyChanged("rptFaturamentoAnalise");
            }
        }
       
        public _indexReport(Pag_Net.Models.modelSistemaUsuario _MyConnect) { _constructor(_MyConnect); }
        private void _constructor(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            filterFaturamento = new interfaces.globalFilter();
        }

        public void filtroClear()
        {
            this.filterFaturamento = new interfaces.globalFilter();
        }
        
        
        /*Faturamento TIPO STATUS _ OBTER*/
        public void getFaturamentoStatus(int faturamento_consolidado)
        {
            try
            {
                this.rptfaturamentoStatus = reports.rptGeneratorFaturamentoStatus.Get(MyConnect, faturamento_consolidado);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*Faturamento TIPO VISUALIZACAO _ OBTER*/
        public void getFaturamentoTipoVisualizacao()
        {
            try
            {
                this.rpttipoVisualizacao = reports.rptGeneratorFaturamentoTipoVisualizacao.Get(MyConnect);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*Faturamento TIPO ANALISE _ OBTER*/
        public void getFaturamentoAnalise(bool opendados, string columnName )
        {
            try
            {
                if (opendados)
                {
                    rptFaturamentoAnalise = reports.rptGeneratorFaturamentoAnalise.Get(MyConnect, filterFaturamento);
                }
                else
                {
                    rptFaturamentoAnalise = reports.rptGeneratorFaturamentoAnalise.orderBy(rptFaturamentoAnalise, columnName);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*Faturamento Consulta _ OBTER*/
        public void getFaturamentoList()
        {
            try
            {
                rptfaturamentoConsulta = reports.rptGeneratorrptFaturamentoConsulta.List(MyConnect, filterFaturamento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void getFaturamento()
        {
            try
            {
                rptfaturamentoConsulta = reports.rptGeneratorrptFaturamentoConsulta.Get(MyConnect, filterFaturamento);
                getFaturamentoItensList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        
        /*Faturamento Itens List _ OBTER*/
        public void getFaturamentoItensList()
        {
            try
            {
                rptfaturamentoItensList = reports.rptGeneratorrptFaturamentoItensList.Get(MyConnect, filterFaturamento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}

