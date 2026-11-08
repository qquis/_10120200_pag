using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0035_Ativo
{
    public class TbAtivoRegistroVeiculo : Pag_Net.Bll.Tb
    {

        public int at_reg_veiculo_seq { get; set; }
        public int at_reg_seq { get; set; }
        public int at_reg_veiculo_km { get; set; }


        public TbAtivoRegistroVeiculo() { _constructor(); }

        public void _constructor()
        {
            try
            {
                at_reg_veiculo_seq = 0;
                at_reg_seq = 0;
                at_reg_veiculo_km = 0;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void __Binding(DataRow i)
        {
            try
            {
                at_reg_veiculo_seq = Convert.ToInt32(i["at_reg_veiculo_seq"].ToString());
                at_reg_seq = Convert.ToInt32(i["at_reg_seq"].ToString());
                at_reg_veiculo_km = Convert.ToInt32(i["at_reg_veiculo_km"].ToString());
            }
            catch ( Exception ex)
            {
                resource.PagException(PagExceptionType.Error, ex);
            }

        }

        public override string __Db_Pg_script(BDCommandTypes BDCommnadType)
        {
            try
            {
                string SQL_CRUD = "SELECT * FROM " + f0035_31_Ativo_Registro_Veiculo_crud._VERSION() +
                            "(  sqlcommand:= '" + BDCommnadType.ToString() + "'" +
                            " , vat_reg_veiculo_seq:= " + this.at_reg_veiculo_seq.ToString() +
                            " , vat_reg_seq:= " + this.at_reg_seq.ToString() +
                            " , vat_reg_veiculo_km:= " + this.at_reg_veiculo_km.ToString() +
                            ") ";

                return SQL_CRUD;
            
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }
      
    }

}

  



    
