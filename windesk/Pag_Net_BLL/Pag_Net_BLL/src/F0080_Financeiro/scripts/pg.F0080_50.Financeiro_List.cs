using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0080_Financeiro.scripts
{

    public static class f0080_50_financeiro_consulta_list
    {
        public static string _VERSION() { return "f0080_50_1012002_financeiro_consulta_list"; }
        public static string Get
            (
                    int                 vTipoConsulta 
			    ,   int                 vcompetencia 				
		        ,	string              vautpgto_tipo				
		        ,	int                 vautpgto_seq_pk				
		        ,	int                 vplc_conta_cd 				
		        ,	int                 vplc_conta_cd_destino 		
		        ,	int                 vfiltra_dataemissao 		
		        ,	DateTime            vautpgto_dataemissao_ini 	
		        ,	DateTime            vautpgto_dataemissao_fim 	
		        ,	int 		        vfiltra_datavencimento 		
		        ,	DateTime            vautpgto_datavencimento_ini 
		        ,	DateTime            vautpgto_datavencimento_fim 
		        ,	int 		        vfiltra_datapagamento 		
		        ,	DateTime            vautpgto_datapagamento_ini 	
		        ,	DateTime            vautpgto_datapagamento_fim 	
                ,   int                 cdpessoabluesoft
                ,   int                 autpgto_cancelada 
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                            string.Format("({0}, {1}, '{2}', {3}, {4}, {5}, {6}, '{7}', '{8}', {9}, '{10}', '{11}', {12}, '{13}', '{14}', {15}, {16} )", 
                            vTipoConsulta.ToString(),
                            vcompetencia.ToString(), 				
                            vautpgto_tipo.ToString(),				
                            vautpgto_seq_pk.ToString(),				
                            vplc_conta_cd.ToString(), 				
                            vplc_conta_cd_destino.ToString(), 		
                            vfiltra_dataemissao.ToString(), 		
                            vautpgto_dataemissao_ini.ToString("yyyy-MM-dd"),
                            vautpgto_dataemissao_fim.ToString("yyyy-MM-dd"),
                            vfiltra_datavencimento.ToString(),
                            vautpgto_datavencimento_ini.ToString("yyyy-MM-dd"),
                            vautpgto_datavencimento_fim.ToString("yyyy-MM-dd"),
                            vfiltra_datapagamento.ToString(),
                            vautpgto_datapagamento_ini.ToString("yyyy-MM-dd"),
                            vautpgto_datapagamento_fim.ToString("yyyy-MM-dd"), 
                            cdpessoabluesoft.ToString(),
                            autpgto_cancelada.ToString()
                    ));
                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

}