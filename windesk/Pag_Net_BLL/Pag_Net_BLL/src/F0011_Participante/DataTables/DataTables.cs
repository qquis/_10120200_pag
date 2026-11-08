using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public static class Dts
    {
        public static DBDataTable F0011_60_ParticipanteList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTER)
        {
            try
            {

                string Script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0011_Participante.F0011_60_ParticipanteList.VERSION() +
                                                    "( {0}, {1}, '{2}', '{3}', '{4}', {5}, {6}, {7}, {8}, {9}, {10}, '{11}', {12} ) ",
                                                    FILTER.cdparticipante.ToString(),
                                                    FILTER.cdpessoabluesoft.ToString(),
                                                    FILTER.cpf_cnpj.ToString(),
                                                    FILTER.nome_razao.ToString(),
                                                    FILTER.email_main.ToString(),
                                                    FILTER.bluesoftcliente.ToString(),
                                                    FILTER.bluesoftvendedor.ToString(),
                                                    FILTER.bluesoftfornecedor.ToString(),
                                                    FILTER.bluesoftfabricante.ToString(),
                                                    FILTER.bluesoftmotorista.ToString(),
                                                    FILTER.cdpessoabluesoft_vendedor.ToString(), 
                                                    FILTER.list_participante_tipo.ToString(),
                                                    FILTER.cdgrupoeconomico.ToString()

                   );


                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Script)); 


            }
            catch (Exception ex)
            {
                throw new Exception("Dts.F0011_Participante Error \n " + ex.Message);
            }
        }
        public static DBDataTable F0011_61_ParticipantesTipos_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTER)
        {
            try
            {
                
                string Script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0011_Participante.F0011_61_Participante_Tipo_List.VERSION() + " ('" + FILTER.list_participante_tipo.ToString() +  "')");
                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Script)); 

            }

            catch (Exception ex)
            {
                throw new Exception("Dts.F0011_ParticipanteTipos Error \n " + ex.Message);
            }

        }
    }

}

