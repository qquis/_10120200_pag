using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class TbForca_Venda_Roteiro_Item
    {
        public int roteiro_item_seq { get; set;  }
        public int      cdpessoabluesoft_cliente         { get; set; }
		public int      roteiro_cd                       { get; set; }
        public int      roteiro_item_cd                  { get; set;  }
        public int      df_nf_seq_blue                   { get; set;  }

        public int      numeropedido                     { get; set; }
        public string   roteiro_obs                     { get; set;  }
        public double   roteiro_frete_percentual        { get; set;  }
        public double   roteiro_frete_valor             { get; set;  }
        public string   roteiro_tipo_calculo            { get; set;  }
        public int      roteiro_remunerar_nao_entregue   { get; set;  }
        public int      roteiro_ordem                    { get; set;  }
        public string   roteiro_tipo_origem             { get; set;  }
        public string   roteiro_status_entrega          { get; set;  }
        public int      roteiro_obs_key                  { get; set;  }
        public string   roteiro_obs_nao_entregue        { get; set;  }

        public TbForca_Venda_Roteiro_Item() {Binding();}
        public TbForca_Venda_Roteiro_Item(DataRow i) {DataBinding(i);}

        public void Binding()
        {
            roteiro_cd = 0;
            cdpessoabluesoft_cliente = 0;
            roteiro_cd = 0;
            roteiro_item_cd = 0;
            df_nf_seq_blue = 0;

            numeropedido = 0;
            roteiro_obs = "";
            roteiro_frete_percentual = 0;
            roteiro_frete_valor = 0;
            roteiro_tipo_calculo = "";
            roteiro_remunerar_nao_entregue = 0;
            roteiro_ordem = 0;
            roteiro_tipo_origem = "";
            roteiro_status_entrega = "";
            roteiro_obs_key = 0;
            roteiro_obs_nao_entregue = "";

        }
        public void DataBinding(DataRow i)
        {
            try
            {
                Binding();
                roteiro_cd = Convert.ToInt32(i["roteiro_cd"].ToString());
                cdpessoabluesoft_cliente = Convert.ToInt32(i["cdpessoabluesoft_cliente"].ToString());
                roteiro_item_cd = Convert.ToInt32(i["roteiro_item_cd"].ToString());
                numeropedido = Convert.ToInt32(i["numeropedido"].ToString());
                df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
                
                roteiro_obs = i["roteiro_obs"].ToString();
                roteiro_frete_percentual = Convert.ToDouble(i["roteiro_frete_percentual"].ToString());
                roteiro_frete_valor = Convert.ToDouble(i["roteiro_frete_valor"].ToString());
                //roteiro_tipo_calculo = i["roteiro_tipo_calculo"].ToString();
                roteiro_remunerar_nao_entregue = 0;
                //roteiro_ordem = Convert.ToInt32(i["roteiro_ordem"].ToString());
                //roteiro_tipo_origem = i["roteiro_tipo_origem"].ToString();
                roteiro_status_entrega = i["roteiro_status_entrega"].ToString();
                //roteiro_obs_key = Convert.ToInt32(i["roteiro_obs_key"].ToString());
                //roteiro_obs_nao_entregue = i["roteiro_obs_nao_entregue"].ToString();
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
                SQL = "SELECT " + F0004_Forca_Venda.F0004_31_FV_Roteiro_Item_CRUD._VERSION() +
                            "(" +
                            "     sqlcommand:= '" + BDCommnadType.ToString() + "'" +
                            " ,   vroteiro_item_seq:= " + this.roteiro_item_seq.ToString() +
                            " ,   vcdpessoabluesoft_cliente:= " + this.cdpessoabluesoft_cliente.ToString() + 
                            " ,	  vroteiro_cd:= " + this.roteiro_cd.ToString() + 								
                            " ,	  vroteiro_item_cd:= " + this.roteiro_item_cd.ToString() + 
                            " ,	  vnumeropedido:= " + numeropedido.ToString() + 
                            " ,	  vdf_nf_seq_blue:= " + df_nf_seq_blue.ToString() +
                            " ,	  vroteiro_obs:= '" + roteiro_obs.ToString().Replace("'", "") + "'" + 
                            " ,	  vroteiro_frete_percentual:= " + roteiro_frete_percentual.ToString("0.00").Replace(",", ".") + 
                            " ,	  vroteiro_frete_valor:= "  + roteiro_frete_valor.ToString("0.00").Replace(",", ".") +  
                            " ,	  vroteiro_tipo_calculo:= '" + roteiro_tipo_calculo.ToString() + "'" + 
                            " ,	  vroteiro_remunerar_nao_entregue:= " + roteiro_remunerar_nao_entregue.ToString() + 
                            " ,	  vroteiro_ordem:= " + roteiro_ordem.ToString() +  
                            " ,	  vroteiro_tipo_origem:= '" + roteiro_tipo_origem.ToString() + "'" + 
                            " ,	  vroteiro_status_entrega:= '" + roteiro_status_entrega.ToString() + "'" + 
                            " ,	  vroteiro_obs_key:= " + roteiro_obs_key.ToString() + 
                            " ,	  vroteiro_obs_nao_entregue:= '" + roteiro_obs_nao_entregue.ToString().Replace("'", "") + "'" + 
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
