using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0035_Ativo
{
    public static class Dts
    {
        public static DBDataTable F0035_60_AtivoList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTER)
        {
            try
            {

                string Script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0035_Ativo.Sql.F0035_60_AtivoList.VERSION() +
                                                  "(  vat_tipo_cd:= " + FILTER.at_tipo_cd.ToString() +
                                                  " , vat_descricao:= '" + FILTER.at_descricao.ToString().Replace("'","") + "'" + 
                                                  ")"
                            );


                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Script)); 


            }
            catch (Exception ex)
            {
                throw new Exception("Dts.F0011_Participante Error \n " + ex.Message);
            }
        }
        public static DBDataTable F0035_61_AtivoVeiculoList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTER)
        {
            try
            {

                string Script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0035_Ativo.Sql.F0035_61_AtivoVeiculoList.VERSION() +
                                                  "(  vat_seq:= " + FILTER.at_seq.ToString() +
                                                  " , vat_descricao:= '" + FILTER.at_descricao.ToString().Replace("'", "") + "'" +
                                                  " , vat_veiculo_placa:= '" + FILTER.at_veiculo_placa.ToString().Replace("'", "") + "'" +
                                                  ") "
                            );

                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Script));


            }
            catch (Exception ex)
            {
                throw new Exception("Dts.F0011_Participante Error \n " + ex.Message);
            }
        }
        public static DBDataTable F0035_66_AtivoRegistroVeiculoList_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTER)
        {
            try
            {

                string Script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0035_Ativo.Sql.F0035_66_AtivoRegistroVeiculoList.VERSION() +
                                                  "(   vat_seq:= " + FILTER.at_seq.ToString() +
                                                  "  , vnome_razao:= '' " + 
                                                  ")"
                            );

                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Script));


            }
            catch (Exception ex)
            {
                throw new Exception("Dts.F0011_Participante Error \n " + ex.Message);
            }
        }
        public static DBDataTable TiposDeAtivos(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter FILTER)
        {

            try
            {
                List<TbAtivoTipo> TipoAtivos = new List<TbAtivoTipo>();
                string Select = "SELECT at_tipo_cd, " +
                                "       at_tipo_descricao " +
                                "FROM   tbativo_tipo " +
                                "where  1 = 1 ";

                if (FILTER.list_tipo_cd != "")
                    Select += " and    at_tipo_cd in (" + FILTER.list_tipo_cd + ")";

                return new DBDataTable(BDCommand.get_DataTable(MyConnect, Select));

               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}

