using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0035_Ativo
{
    public class TbAtivoVeiculo : Pag_Net.Bll.Tb
    {

        public int at_seq { get; set; }
        public int at_veiculo_seq { get; set; }
        public string at_veiculo_placa { get; set; }
        

        public TbAtivoVeiculo() { _constructor(); }

        public void _constructor()
        {
            try
            {
                at_seq = 0;
                at_veiculo_seq = 0;
                at_veiculo_placa = "";
                
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
                this._constructor();
                if (i != null)
                {
                    this.at_seq = Convert.ToInt32(i["at_seq"].ToString());
                    this.at_veiculo_placa = i["at_veiculo_placa"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("TbParticipantes _ Binding " + ex.Message);
            }
        }
        public override string __Db_Pg_script(BDCommandTypes BDCommnadType)
        {
            try
            {
                string SQL_CRUD = "SELECT * FROM " + f0035_05_Ativo_Veiculo_crud._VERSION() +
                            "(  sqlcommand:= '" + BDCommnadType.ToString() + "'" +
                            " , vat_seq:= " + this.at_seq.ToString() +
                            " , vat_veiculo_seq:= " + this.at_veiculo_seq.ToString() +
                            " , vat_veiculo_placa:= '" + this.at_veiculo_placa.ToString() + "'" +
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

  



    
