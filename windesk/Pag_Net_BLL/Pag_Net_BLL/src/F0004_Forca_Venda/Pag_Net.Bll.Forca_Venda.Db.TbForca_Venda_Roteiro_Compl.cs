using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class TbForca_Venda_Roteiro_Compl
    {
        public int      roteiro_compl_seq           { get; set; }
		public int      roteiro_cd				        {get; set;}
        public int      roteiro_compl_cd            { get; set;  }
        public DateTime roteiro_compl_data          { get; set;  }
        public double   roteiro_compl_vl_adicional  { get; set;  }
        public double   roteiro_compl_vl_desconto   { get; set; }
        public string   roteiro_compl_motivo        { get; set; }
        public int      cdpessoabluesoft_usuario    { get; set; }

        public TbForca_Venda_Roteiro_Compl() {Binding();}
        public TbForca_Venda_Roteiro_Compl(DataRow i) { DataBinding(i); }

        public void Binding()
        {
            roteiro_compl_seq = 0;
            roteiro_cd = 0;
            roteiro_compl_cd = 0;
            roteiro_compl_data = Convert.ToDateTime("1900-01-01");
            roteiro_compl_vl_adicional = 0;
            roteiro_compl_vl_desconto = 0;
            roteiro_compl_motivo = "";
            cdpessoabluesoft_usuario = 0;
        }
        public void DataBinding(DataRow i)
        {
            try
            {
                Binding();
                roteiro_compl_seq = Convert.ToInt32(i["roteiro_compl_seq"].ToString());
                roteiro_cd = Convert.ToInt32(i["roteiro_cd"].ToString());
                roteiro_compl_cd = Convert.ToInt32(i["roteiro_compl_cd"].ToString());         
                roteiro_compl_data  = Convert.ToDateTime(i["roteiro_compl_data"].ToString());
                roteiro_compl_vl_adicional = Convert.ToDouble(i["roteiro_compl_vl_adicional"].ToString());
                roteiro_compl_vl_desconto   = Convert.ToDouble(i["roteiro_compl_vl_desconto"].ToString());
                roteiro_compl_motivo  = i["roteiro_compl_motivo"].ToString();
                //cdpessoabluesoft_usuario = Convert.ToInt32(i["cdpessoabluesoft_usuario"].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string __SqlDBINSERT(){return _DataStringSQL(BDCommandTypes.DBINSERT);}
        public string __SqlDBUPDATE() { return _DataStringSQL(BDCommandTypes.DBUPDATE); }
        private string _DataStringSQL(BDCommandTypes BDCommnadType)
        {
            string SQL = "";
            try
            {
                SQL = "SELECT " + F0004_Forca_Venda.F0004_32_FV_Roteiro_Compl_CRUD._VERSION() +
                            "(" +
                            "       sqlcommand:= '" + BDCommnadType.ToString() + "'" +
                            "	 ,  vroteiro_compl_seq:= " + roteiro_compl_seq.ToString()  + 				
                            "    ,	vroteiro_cd:= " + roteiro_cd.ToString() + 						
                            "    ,	vroteiro_compl_cd:= " + roteiro_compl_cd.ToString() + 		
                            "    ,	vroteiro_compl_data:= '" + roteiro_compl_data.ToString("yyyy-MM-dd") + "'" + 				
                            "    ,	vroteiro_compl_vl_adicional:= " + roteiro_compl_vl_adicional.ToString("0.00").Replace(",", ".") +
                            "    ,	vroteiro_compl_vl_desconto:= " + roteiro_compl_vl_desconto.ToString("0.00").Replace(",", ".") +  		
                            "    ,	vroteiro_compl_motivo:= '" + roteiro_compl_motivo.ToString().Replace("'","") + "'" + 
                            "    ,	vcdpessoabluesoft_usuario:= " + cdpessoabluesoft_usuario.ToString() + 
                            " )" ;
                return SQL;
            }
            catch (Exception ex)
            {
                return SQL;
                throw new Exception(ex.Message);
            }
        }
    }
}
