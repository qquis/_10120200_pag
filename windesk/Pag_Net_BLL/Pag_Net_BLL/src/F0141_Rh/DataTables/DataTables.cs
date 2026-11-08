using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh
{
    public static class Dts
    {
        public static DBDataTable RhTipoContrato_Get(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                string Script = "SELECT   rh_tipo_contrato_cd " +
                                "       , rh_tipo_contrato_descricao " +
                                "       , rh_tipo_contrato_legal " +
                                "FROM     tbrh_tipo_contrato  " +
                                "ORDER BY rh_tipo_contrato_descricao ASC ";
                                
                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Script)); 
            }
            catch (Exception ex)
            {
                throw new Exception("Dts.RhTipoContrato_Get Error \n " + ex.Message);
            }
        }

        public static DBDataTable RhSetorOperacional_Get(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                string Script = "SELECT   rh_setor_operacional_cd " +
                                "       , rh_setor_operacional_descricao " +
                                //"       , em_cdempresa " +
                                //"       , op_cdoperacao " + 
                                "FROM     tbrh_setor_operacional  " +
                                "ORDER BY rh_setor_operacional_descricao ASC ";

                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Script));
            }
            catch (Exception ex)
            {
                throw new Exception("Dts.RhTipoContrato_Get Error \n " + ex.Message);
            }
        }

        public static DBDataTable F0141_60_FuncionarioList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTER)
        {
            try
            {

                string Script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0141_Rh.F0141_60_FuncionarioList.VERSION() +
                                                    "( 	    vcdparticipante:= " + FILTER.cdparticipante.ToString() + 						
                                                     "   ,	vrh_funcionario_dv:= " + FILTER.rh_funcionario_dv.ToString() + 					
                                                     "   ,	vnome:= '" + FILTER.nome.ToString().Replace("'", "") + "'" + 
                                                     "   ,	vdata_admissao_filtrar:= " + FILTER.data_admissao_filtrar.ToString() +  	
                                                     "   ,	vdata_admissao_ini:= '" + FILTER.data_admissao_ini.ToString("yyyy-MM-dd") + "'" + 
                                                     "   ,	vdata_admissao_fim:= '" + FILTER.data_admissao_fim.ToString("yyyy-MM-dd") + "'" +  		
                                                     "   ,	vdata_rescisao_filtrar:= " + FILTER.data_rescicao_filtrar.ToString() + 	
                                                     "   ,	vdata_rescisao_ini:= '" + FILTER.data_rescisao_ini.ToString("yyyy-MM-dd") + "'" +  		 		
                                                     "   ,	vdata_rescisao_fim:= '" + FILTER.data_rescisao_fim.ToString("yyyy-MM-dd") + "'" +  		 		 		
                                                     "   ,	vrh_tipo_contrato_cd:= " + FILTER.rh_tipo_contrato_cd.ToString() +  	
                                                     "   ,	vrh_setor_operacional_cd:= " + FILTER.rh_setor_operacional_cd.ToString() +
                                                     "   ,	vrh_status_ativo:= " + FILTER.rh_status_ativo.ToString() +			
                                                     "   ,	vrh_status_inativo:= " + FILTER.rh_status_inativo.ToString() +
                                                     "   ,	vdtm_setor_descricao:= '" + FILTER.dtm_setor_descricao.ToString().Replace("'", "") + "'" +
                                                     "   ,	vdtm_secao_descricao:= '" + FILTER.dtm_secao_descricao.ToString().Replace("'", "") + "'" + 
	                                                 ")"    );


                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Script));


            }
            catch (Exception ex)
            {
                throw new Exception("Dts.F0011_Participante Error \n " + ex.Message);
            }
        }

        public static DBDataTable F0141_65_Salario_Contratado_List(Pag_Net.Models.modelSistemaUsuario MyConnect, string TipoRelatorio, Filter FILTER)
        {
            try
            {

                string Script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0141_Rh.F0141_65_Salario_Contratado_List.VERSION() +
                                                    "( 	    vtipo_relatorio:= '" + TipoRelatorio.ToString() + "'" + 
                                                    "    ,  vcdparticipante:= " + FILTER.cdparticipante.ToString() +
                                                     "   ,	vrh_tipo_contrato_cd:= " + FILTER.rh_tipo_contrato_cd.ToString() +
                                                     "   ,	vrh_setor_operacional_cd:= " + FILTER.rh_setor_operacional_cd.ToString() +
                                                     "   ,  vnome_razao:= '" + FILTER.nome + "'" + 
                                                     ")");


                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Script));


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}

