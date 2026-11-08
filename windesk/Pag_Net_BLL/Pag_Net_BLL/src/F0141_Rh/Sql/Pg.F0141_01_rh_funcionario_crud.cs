using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh
{
    public class F0141_01_RhFuncionarioCRUD
    {
        private static string _VERSION() { return "f0141_01_1011925_rh_funcionario_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbRhFuncionario item
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, {3}, {4}, {5}, '{6}', {7}, {8}, '{9}', '{10}', {11}, '{12}', '{13}' )",
                    BDCommnadType.ToString(),
                    item.rh_funcionario_seq.ToString(), 
                    item.rh_funcionario_cd.ToString(), 
                    item.rh_funcionario_cd_dg.ToString(), 
                    item.cdpessoabluesoft.ToString(), 
                    item.rh_funcionario_nome.ToString(), 
                    item.cpf_cnpj.ToString(), 
                    item.rh_funcionario_status_cd.ToString(), 
                    "", 
                    "0"

                    ));

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static string RedShift_Select()
        {
            string RedShift_SELECT = "select      cast(0 as int)                                      as proc_log_seq                         " +
                                     "        ,   cast(case loja_key                                                                          " +
                                     "            when 1      then 1                                                                          " +
                                     "            when 991    then 6                                                                          " +
                                     "             else             0                                                                         " +
                                     "        end                                                                                             " +
                                     "               as int)                                          as em_cdempresa	    			      " +
                                     "                                                                                                        " +
                                     "        ,   cast(0 as int)                                      as contrato_servico_seq		          " +
                                     " ,   cast(contrato_servico_key as int)                          as contrato_bluesoft_seq				  " +
                                     " ,   cast(coalesce(pessoa_key,0) as int)                        as cdpessoabluesoft 					  " +
                                     " ,   cast(left(coalesce(descricao,''),60) as varchar(60))       as contrato_bluesoft_descritivo		  " +
                                     " ,   cast( case when coalesce(status,'I') = 'A' then 1 else 0 end as int)                               " +
                                     "                                                                as contrato_bluesoft_status			  " +
                                     " ,   cast( coalesce(estimativa,0)  as numeric(13,2))            as contrato_bluesoft_valor			  " +
                                     " ,   cast( coalesce(vigencia_inicial,'1900-01-01')  as date)    as contrato_bluesoft_dt_vigencia_ini	  " +
                                     " ,   cast( coalesce(vigencia_inicial,'2100-01-01')  as date)    as contrato_bluesoft_dt_vigencia_fim	  " +
                                     " ,   cast(0 as int)                                             as contrato_servico_permite_execucao 	  " +
                                     " ,   cast('' as varchar(60))                                    as contrato_servico_descritivo		  " +
                                     " ,   cast('' as varchar(60))                                    as contrato_servico_observacao 		  " +
                                     " from        contrato_servico ";
            return RedShift_SELECT;

        }
    }

}
