using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0105_Zanthus;
using Pag_Net.Dal;

namespace Pag_Net.Bll.F0105_Zanthus
{
    public class Filter_Zanthus
    {
        public DateTime voucher_data { get; set;  }
        public string voucher_cliente { get; set; }
        public string voucher { get; set; }


        public Filter_Zanthus()
        {
            voucher_cliente = "";
            voucher = "";
            voucher_data = Convert.ToDateTime("1900-01-01");
        }
    }

    public class Wk
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Filter_Zanthus Filtros;
        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            Filtros = new Filter_Zanthus();
            MyConnect = _MyConnect;
        }

        public DataTable Voucher_Promocional_Consultar()
        {
            try
            {
                return Tool.Voucher_Promocional_Cli_Consultar(MyConnect, Filtros);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        public void Exportar(Zanthus_Processamento _zanthus_Processamento)
        {
            try
            {
                Tool.Exporta_SQLServer_PostGre(MyConnect, _zanthus_Processamento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
   
    public static class Tool
    {
        public static void Exporta_SQLServer_PostGre (Pag_Net.Models.modelSistemaUsuario MyConnect, Zanthus_Processamento _zanthus_Processamento)
        {
               
               string scriptSql =  "" ;
               int _SQL_REPROCESSAMENTO = 0; 
               if (_zanthus_Processamento.SQL_REPROCESSAMENTO)
               {
                   _SQL_REPROCESSAMENTO = 1;
               }

               if (MyConnect.User_environment == "DES")
               {
                   scriptSql = string.Format("EXEC DBAMAIN.DBO.DESENVOL_SP_Postgre_0100_FaturamentoZanthus_Export  " +
                                                " @data_processamento = '{0}', " +
                                                " @NUMERO_ECF = {1}, " +
                                                " @CUPOM_INICIAL = 0," +
                                                " @REPROCESSAMENTO_STATUS = {2}"
                  , _zanthus_Processamento.data.ToString("yyyy-MM-dd")
                  , _zanthus_Processamento.ecf.ToString()
                  , _SQL_REPROCESSAMENTO.ToString()
                   );
               }

               if (MyConnect.User_environment == "PRD")
               {
                   scriptSql = string.Format("EXEC DBAMAIN.DBO.SP_Postgre_0100_FaturamentoZanthus_Export  " +
                                                " @data_processamento = '{0}', " +
                                                " @NUMERO_ECF = {1}, " +
                                                " @CUPOM_INICIAL = 0," +
                                                " @REPROCESSAMENTO_STATUS = {2}"
                  , _zanthus_Processamento.data.ToString("yyyy-MM-dd")
                  , _zanthus_Processamento.ecf.ToString()
                  , _SQL_REPROCESSAMENTO.ToString()
                   );
               }

            try
            {
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                BDExecute.Execute(scriptSql, null, DataBaseName.DBAMAINADM, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Voucher_Promocional_Cli_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter_Zanthus _filter)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0105_20_Zanthus_Voucher_Cli_Consultar.Postgre.Get(_filter));
            }
            catch (Exception ex)
            {
                throw new Exception("F0105_20_Zanthus_Voucher_Cli_Consultar:" + ex.Message);
            }
        }

    }


    public class Zanthus_Processamento
    {
        public DateTime data { get; set; }
        public int ecf { get; set; }
        public bool SQL_REPROCESSAMENTO { get; set; }
        public Zanthus_Processamento() { }
        public Zanthus_Processamento(DateTime _data, int _ecf, int _cupomfiscal, bool _SQL_REPROCESSAMENTO)
        {
            SQL_REPROCESSAMENTO = _SQL_REPROCESSAMENTO;
            data = _data;
            ecf = _ecf;
        }
    }

}
