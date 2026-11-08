using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0062_Guardian
{

    public class Filter
    {
		public string       gtk_uuid            {get; set; }
   		public int          gtk_numero          {get; set; }
		public string       gtk_placa           {get; set; }
		public DateTime     gtk_data_inicial    {get; set; }
		public DateTime     gtk_data_final      {get; set; }
        public Filter()
        {
            
             gtk_uuid           = "";
             gtk_numero = 0;
             gtk_placa          = "";
             gtk_data_inicial   = DateTime.Now;
             gtk_data_final     = DateTime.Now;



        }

        public Filter(
            
            string       _gtk_uuid            
            ,int          _gtk_numero          
            ,string       _gtk_placa           
            ,DateTime     _gtk_data_inicial    
            ,DateTime     _gtk_data_final      



            
            )
        {
         
            gtk_uuid         =   _gtk_uuid                  ;
            gtk_numero       =   _gtk_numero                ;
            gtk_placa        =   _gtk_placa                 ;
            gtk_data_inicial =   _gtk_data_inicial          ;
            gtk_data_final = _gtk_data_final;




        }


    }
    public class Wk
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Filter Filtros;
        public int NumeroDeRegistros = 0;
        
        public Wk( Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Filtros = new Filter();
        }

        public DataTable ObterList()
        {
            DataTable TicketList = Tool.GuardianTicket_List_Obter(MyConnect, Filtros);
            NumeroDeRegistros = TicketList.Rows.Count;
            return TicketList;
        }
    }
    public static class Tool
    {
        public static DataTable GuardianTicket_List_Obter(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter _filter)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0062_02_GuardianTicket_List.Postgre.Get(_filter));
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0141_Rh.Tool.Funcionario_list_Obter: \n" + ex.Message);
            }

        }
    }

}
