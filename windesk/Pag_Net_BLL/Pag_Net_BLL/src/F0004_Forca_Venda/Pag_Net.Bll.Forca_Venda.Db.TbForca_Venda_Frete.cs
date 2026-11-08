using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0004_Forca_Venda
{
    public class TbForca_Venda_Frete
    {
        public int fv_frete_seq { get; set; }
        public DateTime fv_frete_dt_Lancamento      { get; set;  }
        public DateTime fv_frete_dt_fechamento_ini  { get; set;  }
        public DateTime fv_frete_dt_fechamento_fim  { get; set; }
        public int cdparticipante_motorista     { get; set;  }
        public int competencia_cd               { get; set;  }
        public double fv_frete_valor            { get; set;  }
        public double fv_frete_ajuste_adicao    { get; set;  }
        public double fv_frete_ajuste_desconto { get; set; }
        public double fv_frete_vl_compl         { get; set;  }
        public double fv_frete_vl_base          { get; set; }
        public double fv_frete_vl_inss          { get; set; }		 	
        public double fv_frete_vl_irpf          { get; set; }		 	
        public double fv_frete_vl_sest          { get; set; }		 	
        public double fv_frete_vl_senat	        { get; set; }	 	
        public double fv_frete_valor_liq        { get; set; }			
        public double fv_frete_vl_antec_bb      { get; set; }
        public double fv_frete_vl_antec_especie { get; set; }



        public TbForca_Venda_Frete()
        {
            Binding();
        }

        public void Binding() 
        {
            fv_frete_seq = 0;

            fv_frete_dt_Lancamento = Convert.ToDateTime("1900-01-01");
            fv_frete_dt_fechamento_ini = Convert.ToDateTime("1900-01-01");
            fv_frete_dt_fechamento_fim = Convert.ToDateTime("1900-01-01");
            cdparticipante_motorista = 0;
            competencia_cd = 0;
            fv_frete_valor = 0;
            fv_frete_ajuste_adicao = 0;
            fv_frete_ajuste_desconto = 0;
            fv_frete_vl_compl = 0;
            fv_frete_vl_base = 0;
            fv_frete_vl_inss = 0;
            fv_frete_vl_irpf = 0;
            fv_frete_vl_sest = 0;
            fv_frete_vl_senat = 0;
            fv_frete_valor_liq = 0;
            fv_frete_vl_antec_bb = 0;
            fv_frete_vl_antec_especie = 0;

        }

        public void DataBinding(DataRow i)
        {
            try
            {
                Binding();
                fv_frete_seq = Convert.ToInt32(i["fv_frete_seq"].ToString());
                fv_frete_dt_Lancamento     = Convert.ToDateTime(i["fv_frete_dt_Lancamento"].ToString());
                fv_frete_dt_fechamento_ini = Convert.ToDateTime(i["fv_frete_dt_fechamento_ini"].ToString());
                fv_frete_dt_fechamento_fim = Convert.ToDateTime(i["fv_frete_dt_fechamento_fim"].ToString());
                cdparticipante_motorista = Convert.ToInt32(i["cdparticipante"].ToString());
                competencia_cd = Convert.ToInt32(i["competencia_cd"].ToString());
                fv_frete_valor = Convert.ToDouble(i["fv_frete_valor"].ToString());
                fv_frete_ajuste_adicao = Convert.ToDouble(i["fv_frete_ajuste_adicao"].ToString());
                fv_frete_ajuste_desconto = Convert.ToDouble(i["fv_frete_ajuste_desconto"].ToString());
                fv_frete_vl_compl = Convert.ToDouble(i["fv_frete_vl_compl"].ToString());
                fv_frete_vl_base = Convert.ToDouble(i["fv_frete_vl_base"].ToString());
                fv_frete_vl_inss = Convert.ToDouble(i["fv_frete_vl_inss"].ToString());
                fv_frete_vl_irpf = Convert.ToDouble(i["fv_frete_vl_irpf"].ToString());
                fv_frete_vl_sest = Convert.ToDouble(i["fv_frete_vl_sest"].ToString());
                fv_frete_vl_senat = Convert.ToDouble(i["fv_frete_vl_senat"].ToString());
                fv_frete_valor_liq = Convert.ToDouble(i["fv_frete_valor_liq"].ToString());
                fv_frete_vl_antec_bb = Convert.ToDouble(i["fv_frete_vl_antec_bb"].ToString());
                fv_frete_vl_antec_especie = Convert.ToDouble(i["fv_frete_vl_antec_especie"].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UPDATE(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                if (this.fv_frete_seq == 0)
                {
                    throw new Exception("Sequência de Frete não informado");
                }

                BDCommand.Execute(MyConnect, __SqlDBUPDATE());
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
                SQL = "SELECT " + F0004_Forca_Venda.F0004_42_FV_frete_CRUD._VERSION() 
                    + "(    sqlcommand:= '" + BDCommnadType.ToString() + "'"  
                    + "   , vfv_frete_seq:= 	" + fv_frete_seq.ToString()
                    + "   , vfv_frete_valor:= 	" + fv_frete_valor.ToString("0.00").Replace(",", ".")
                    + "   , vfv_frete_vl_compl:= 	" + fv_frete_vl_compl.ToString("0.00").Replace(",", ".")
                    + "   , vfv_frete_vl_base:= 	" + fv_frete_vl_base.ToString("0.00").Replace(",", ".")
                    + "   , vfv_frete_vl_inss:= 	" + fv_frete_vl_inss.ToString("0.00").Replace(",", ".")
                    + "   , vfv_frete_vl_irpf:= 	" + fv_frete_vl_irpf.ToString("0.00").Replace(",", ".")
                    + "   , vfv_frete_vl_sest:= 	" + fv_frete_vl_sest.ToString("0.00").Replace(",", ".")
                    + "   , vfv_frete_vl_senat:= 	" + fv_frete_vl_senat.ToString("0.00").Replace(",", ".")
                    + "   , vfv_frete_valor_liq:= 	" + fv_frete_valor_liq.ToString("0.00").Replace(",", ".")
                    + "   , vfv_frete_vl_antec_bb:= 	" + fv_frete_vl_antec_bb.ToString("0.00").Replace(",", ".")
                    + "   , vfv_frete_vl_antec_especie:= 	" + fv_frete_vl_antec_especie.ToString("0.00").Replace(",", ".")
                    + ")";

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

