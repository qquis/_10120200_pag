using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Pag_Net.Dal;
using Pag_Net.src.F0080_Financeiro;
using Pag_Net.Bll;
using System.ComponentModel;
namespace Pag_Net.src.F0080_Financeiro
{
    public class _index : INotifyPropertyChanged
    {
        /*MyConnect */
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbList_PosicaoFinanceira; 
        public DBDataTable dbList_PosicaoFinanceira { get { return __dbList_PosicaoFinanceira; } set { __dbList_PosicaoFinanceira = value; RaisePropertyChanged("dbList_PosicaoFinanceira"); } }

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public tbs.TbFin_Forma_Pgto[] Forma_Pgto_List;
        public interfaces.iFiltroConsultaAutorizacao Filtro;
        public model.model_ComposicaoFinanceira_Tipo[] TipoConsulta;
        public model.model_AutorizacaoPagamento AutorizacaoPagamento;


        public _index(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Filtro = new interfaces.iFiltroConsultaAutorizacao();
            TipoConsulta = reports.ArrayTabs.ComposicaoFinanceiraTipos();
            AutorizacaoPagamento = new model.model_AutorizacaoPagamento();

        }

        public void ConsultaPosicaoFinanceira()
        {
            try
            {
                dbList_PosicaoFinanceira = reports.DBDataTables.ConsultaPosicaoFinanceira(MyConnect, Filtro);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void ConsultarAutorizacaoPagamento(int autpgto_seq_pk)
        {
            try
            {
                AutorizacaoPagamento.autpgto_seq_pk = autpgto_seq_pk;
                AutorizacaoPagamento.model_Consultar(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


		public void Binding_Forma_Pgto_List()
        {
			try {

				DataTable local_DataTable_fin_forma_pgto = BDCommand.get_DataTable(MyConnect, scripts.f0080_20_1012006_fin_forma_pgto_list.Get());
				List<tbs.TbFin_Forma_Pgto> local_List_fin_forma_pgto = new List<tbs.TbFin_Forma_Pgto>();
				foreach(DataRow i in local_DataTable_fin_forma_pgto.Rows)
                {
					local_List_fin_forma_pgto.Add(new tbs.TbFin_Forma_Pgto(i));
				}
				Forma_Pgto_List = local_List_fin_forma_pgto.ToArray();
			}
			catch (Exception ex)
            {
				throw new Exception (ex.Message);
			}
		}
    }


    


  

}
