using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0035_Ativo
{
    public class TbAtivoRegistro : Pag_Net.Bll.Tb
    {
        public int at_reg_seq { get; set;  }
        public int controle_reg_etapa_seq { get; set;  }
        public int at_seq { get; set; }
        public int at_item_seq { get; set; }
        public string at_reg_descricao { get; set; }
        public int at_reg_tipo_cd { get; set; }
        public DateTime at_reg_data { get; set; }
        


        public TbAtivoRegistro() { _constructor(); }

        public void _constructor()
        {
            try
            {

                at_reg_seq = 0;
                controle_reg_etapa_seq = 0;
                at_seq = 0;
                at_item_seq = 0;
                at_reg_descricao = "";
                at_reg_tipo_cd = 0;
                at_reg_data = Convert.ToDateTime("1900-01-01");
                
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
                at_reg_seq = Convert.ToInt32(i["at_reg_seq"].ToString());
                controle_reg_etapa_seq = Convert.ToInt32(i["controle_reg_etapa_seq"].ToString());
                at_seq = Convert.ToInt32(i["at_seq"].ToString()); ;
                at_item_seq = Convert.ToInt32(i["at_item_seq"].ToString()); ;
                at_reg_descricao = i["at_reg_descricao"].ToString();
                at_reg_tipo_cd = Convert.ToInt32(i["at_reg_tipo_cd"].ToString()); ;
                at_reg_data = Convert.ToDateTime(i["at_reg_data"].ToString());
            } 
            catch (Exception ex)
            {
                resource.PagException(PagExceptionType.Error, ex);
            }
            
        }

        public override string __Db_Pg_script(BDCommandTypes BDCommnadType)
        {
            try
            {
                string SQL_CRUD = "SELECT * FROM " + f0035_30_Ativo_Registro_crud._VERSION() +
                            "( sqlcommand:= '" + BDCommnadType.ToString() + "'" +
                            " , vat_reg_seq:= " + this.at_reg_seq.ToString() +
                            " , vcontrole_reg_etapa_seq:= " + this.controle_reg_etapa_seq.ToString() +
                            " , vat_seq:= " + this.at_seq.ToString() +
                            " , vat_item_seq:= " + this.at_item_seq.ToString() +
                            " , vat_reg_descricao:= '" + this.at_reg_descricao.ToString() + "'" +
                            " , vat_reg_tipo_cd:= " + this.at_reg_tipo_cd.ToString() +
                            " , vat_reg_data:= '" + this.at_reg_data.ToString("yyyy-MM-dd") + "'" +
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

  



    
