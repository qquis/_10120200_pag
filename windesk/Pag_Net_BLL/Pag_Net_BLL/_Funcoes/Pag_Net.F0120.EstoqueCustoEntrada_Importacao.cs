using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Bll.F0120
{
    public static class Postgres
    {
        public static void CRUD(
                 Pag_Net.Models.modelSistemaUsuario MyConnect
            ,    int        vproc_log_seq 				                		
		    ,	 int        vproc_log_arquivo_import_linha_seq	
		    ,	 int        veci_prb_cdprodutobluesoft		
	        ,    string     veci_descricao 
		    ,	 string     veci_cdbarra						
		    ,	 int        veci_nf_numero						
		    ,	 string     veci_nf_numero_serie				
		    ,	 DateTime   veci_nf_data_entrada				
		    ,	 double     veci_embalagemestoque_qtde			
		    ,	 double     veci_valorcustobruto 				
		    ,	 double     veci_valorcustoliquido				
		    ,	 string     vCFOP 								
		    ,	 int        veci_processamento 	
		    ,    string     veci_processamento_erro 

           )
        {

            try
            {

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                string SQL_POSTGRE_EXEC = string.Format("SELECT f0120_estoquecusto_entrada_importacao (	     " +
                                                                "          'DBINSERT'        " +
                                                               "       ,     {0}             " +
                                                               "       ,     {1}             " +
                                                               "       ,     {2}             " +
                                                               "       ,    '{3}'            " + 
                                                               "       ,    '{4}'             " +
                                                               "       ,     {5}             " +
                                                               "       ,    '{6}'            " +
                                                               "       ,    '{7}'            " +
                                                               "       ,     {8}             " +
                                                               "       ,     {9}             " +
                                                               "       ,     {10}             " +
                                                               "       ,    '{11}'           " +
                                                               "       ,     {12}            " + 
                                                               "       ,    '{13}'           )",
                                                                      vproc_log_seq.ToString()
                                                                    , vproc_log_arquivo_import_linha_seq.ToString()
                                                                    , veci_prb_cdprodutobluesoft.ToString()
                                                                    , veci_descricao.ToString().Replace("'", "")
                                                                    , veci_cdbarra.ToString()
                                                                    , veci_nf_numero.ToString()
                                                                    , veci_nf_numero_serie.ToString()
                                                                    , veci_nf_data_entrada.ToString("yyyy-MM-dd")
                                                                    , veci_embalagemestoque_qtde.ToString()
                                                                    , veci_valorcustobruto.ToString().Replace(",",".")
                                                                    , veci_valorcustoliquido.ToString().Replace(",", ".")
                                                                    , vCFOP.ToString()
                                                                    , veci_processamento.ToString()
                                                                    , veci_processamento_erro.ToString()

                                                               );
                BDExecute.Execute(SQL_POSTGRE_EXEC, null, DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F001001 | ERRO: " + ex.Message);
            }

        }

    
    }
}

