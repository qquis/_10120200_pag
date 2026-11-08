using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0035_Ativo
{
    public class TbAtivo : Pag_Net.Bll.Tb
    {
        public TbAtivoTipo AtivoTipo;
        public int at_seq { get; set; }
        public string at_descricao { get; set; }
        public int at_status { get; set; }
        public int at_tipo_cd { get; set; }
        public int at_bluesoft_patrimonio_item { get; set; }
    
        public TbAtivo() { _constructor(); }

        public void _constructor()
        {
            try
            {
                at_seq = 0;
                at_descricao = "";
                at_status = 1;
                at_tipo_cd = 0;
                at_bluesoft_patrimonio_item = 0;
                AtivoTipo = new TbAtivoTipo();
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
                if (i != null)
                {
                    this.at_seq = Convert.ToInt32(i["at_seq"].ToString());
                    this.at_descricao = i["at_descricao"].ToString();
                    this.at_status = Convert.ToInt32(i["at_status"].ToString());
                    this.at_tipo_cd = Convert.ToInt32(i["at_tipo_cd"].ToString());
                    this.at_bluesoft_patrimonio_item = Convert.ToInt32(i["at_bluesoft_patrimonio_item"].ToString());
                    this.AtivoTipo.at_tipo_cd = Convert.ToInt32(i["at_tipo_cd"].ToString());
                    this.AtivoTipo.at_tipo_descricao = i["at_tipo_descricao"].ToString();
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
                string SQL_CRUD = "SELECT * FROM " + f0035_05_Ativo_crud._VERSION() +
                            "( sqlcommand:= '" + BDCommnadType.ToString() + "'," +
                            "   vat_seq:= " + this.at_seq.ToString() + 
                            " , vat_descricao:= '" + this.at_descricao.ToString() + "'" +
                            " , vat_status:= " + this.at_status.ToString() +
                            " , vat_tipo_cd:= " + this.at_tipo_cd.ToString() +
                            " , vat_bluesoft_patrimonio_item:= " + this.at_bluesoft_patrimonio_item.ToString() + 
	                        " ) "
                            ;
                return SQL_CRUD;
           
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }
      
    }

}

  



    
