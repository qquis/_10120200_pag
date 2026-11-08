using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class TbForca_Venda_Roteiro
    {
        public int      roteiro_seq				        {get; set; }
		public int      roteiro_cd				        {get; set;}
		public int      veiculo_bluesoft_cd 		    {get; set;}
		public int      cdpessoabluesoft_motorista		{get; set; }
        public string   roteiro_descricao { get; set;  }
		public DateTime	roteiro_data_lanc				{get; set;}
		public DateTime	roteiro_data_prev_entrega		{get; set;}
		public DateTime	roteiro_data_saida				{get; set;}
		public DateTime	roteiro_data_retorno			{get; set;}
        public int      roteiro_status                  { get; set;  }
        public DateTime roteiro_data_fechamento         { get; set; }

        public TbForca_Venda_Roteiro() {Binding();}
        public TbForca_Venda_Roteiro(DataRow i) {DataBinding(i);}

        public void Binding()
        {
            roteiro_seq = 0;
            roteiro_cd = 0;
            veiculo_bluesoft_cd = 0;
            cdpessoabluesoft_motorista = 0;
            roteiro_descricao = "";
            roteiro_data_lanc = Convert.ToDateTime("1900-01-01");			
            roteiro_data_prev_entrega = Convert.ToDateTime("1900-01-01");
            roteiro_data_saida = Convert.ToDateTime("1900-01-01");
            roteiro_data_retorno = Convert.ToDateTime("1900-01-01");
            roteiro_status = 0;
        }
        public void DataBinding(DataRow i)
        {
            try
            {
                Binding();
                roteiro_seq = Convert.ToInt32(i["roteiro_seq"].ToString());
                roteiro_cd = Convert.ToInt32(i["roteiro_cd"].ToString());
                veiculo_bluesoft_cd = Convert.ToInt32(i["veiculo_bluesoft_cd"].ToString());
                cdpessoabluesoft_motorista = Convert.ToInt32(i["cdpessoabluesoft_motorista"].ToString());
                roteiro_descricao = i["roteiro_descricao"].ToString();
                roteiro_data_lanc = Convert.ToDateTime(i["roteiro_data_lanc"].ToString());
                roteiro_data_prev_entrega = Convert.ToDateTime(i["roteiro_data_prev_entrega"].ToString());
                roteiro_data_saida = Convert.ToDateTime(i["roteiro_data_saida"].ToString());
                roteiro_data_retorno = Convert.ToDateTime(i["roteiro_data_retorno"].ToString());
                roteiro_status = Convert.ToInt32(i["roteiro_status"].ToString());
                roteiro_data_fechamento = Convert.ToDateTime(i["roteiro_data_fechamento"]);
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
                SQL = "SELECT " + F0004_Forca_Venda.F0004_30_FV_Roteiro_CRUD._VERSION() +
                            "(" +
                            "   sqlcommand:= '" + BDCommnadType.ToString() + "'" +
                            " ,	vroteiro_seq:= " + this.roteiro_seq.ToString() +
                            " ,	vroteiro_cd:= " + this.roteiro_cd.ToString() +
                            " ,	vveiculo_bluesoft_cd:= " + this.veiculo_bluesoft_cd.ToString() +
                            " ,	vcdpessoabluesoft_motorista:= " + this.cdpessoabluesoft_motorista.ToString() +
                            " ,	vroteiro_descricao:= '" + this.roteiro_descricao.ToString().Replace("'", "") + "'" +
                            " ,	vroteiro_data_lanc:= '" + this.roteiro_data_lanc.ToString("yyyy-MM-dd") + "'" +
                            " ,	vroteiro_data_prev_entrega:= '" + this.roteiro_data_prev_entrega.ToString("yyyy-MM-dd") + "'" +
                            " ,	vroteiro_data_saida:= '" + this.roteiro_data_saida.ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                            " ,	vroteiro_data_retorno:= '" + this.roteiro_data_retorno.ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                            " ,	vroteiro_status:= " + this.roteiro_status.ToString() +
                            " , vroteiro_data_fechamento:= '" + this.roteiro_data_fechamento.ToString("yyyy-MM-dd") + "'" +
                            ")" ;
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
