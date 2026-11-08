using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0136_Contrato_Servico
{
    public class TbContrato_Servico
    {

	        public int          em_cdempresa						    {get ; set; }
	        public int          contrato_servico_seq				    {get ; set; }
	        public int          contrato_bluesoft_seq				    {get ; set; }
	        public int          cdpessoabluesoft					    {get ; set; }
	        public string       contrato_bluesoft_descritivo		    {get ; set; }
	        public int          contrato_bluesoft_status			    {get ; set; }
	        public double       contrato_bluesoft_valor			        {get ; set; }
	        public DateTime     contrato_bluesoft_dt_vigencia_ini	    {get ; set; }
	        public DateTime     contrato_bluesoft_dt_vigencia_fim	    {get ; set; }
	        public int          contrato_servico_permite_execucao 	    {get ; set; }
	        public string       contrato_servico_descritivo		        {get ; set; }
            public string       contrato_servico_observacao             { get; set; }

            public TbContrato_Servico() { }
            public TbContrato_Servico(DataRow i)
            {
                em_cdempresa = Convert.ToInt32(i["em_cdempresa"].ToString());
                contrato_servico_seq = Convert.ToInt32(i["contrato_servico_seq"].ToString());
                contrato_bluesoft_seq = Convert.ToInt32(i["contrato_bluesoft_seq"].ToString());
                cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());
                contrato_bluesoft_descritivo = i["contrato_bluesoft_descritivo"].ToString();
                contrato_bluesoft_status = Convert.ToInt32(i["contrato_bluesoft_status"].ToString());
                contrato_bluesoft_valor = Convert.ToDouble(i["contrato_bluesoft_valor"].ToString());
                contrato_bluesoft_dt_vigencia_ini = Convert.ToDateTime(i["contrato_bluesoft_dt_vigencia_ini"].ToString());
                contrato_bluesoft_dt_vigencia_fim = Convert.ToDateTime(i["contrato_bluesoft_dt_vigencia_fim"].ToString());
                contrato_servico_permite_execucao = Convert.ToInt32(i["contrato_servico_permite_execucao"].ToString());
                contrato_servico_descritivo = i["contrato_servico_descritivo"].ToString();
                contrato_servico_observacao = i["contrato_servico_observacao"].ToString();

            }


    }
}
