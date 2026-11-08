using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0025_EstoqueLocal
{
    public class tbestoquelocal_mov
    {
        public DateTime		dtlog_insert				        { get; set;  }
        public int			estlocal_mov_seq			        { get; set; }
        public DateTime		estlocal_mov_data			        { get; set;  }
        public int			pr_cdproduto				        { get; set;  }
        public string		pr_embalagemestoque			        { get; set;  }
        public double       estlocal_mov_embalagemestoque_qtde  { get; set; }
        public int proc_log_seq { get; set;  }


        public tbestoquelocal_mov()
        {
            estlocal_mov_data = DateTime.Now;
        }

		public tbestoquelocal_mov (
		
			int			_estlocal_mov_seq					,
			DateTime	_estlocal_mov_data					,
			int			_pr_cdproduto						,
			string		_pr_embalagemestoque				,
            double      _estlocal_mov_embalagemestoque_qtde			
            )
        {
			estlocal_mov_seq				= _estlocal_mov_seq				;
			estlocal_mov_data				= _estlocal_mov_data			;
			pr_cdproduto					= _pr_cdproduto					;
			pr_embalagemestoque				= _pr_embalagemestoque			;
            estlocal_mov_embalagemestoque_qtde = _estlocal_mov_embalagemestoque_qtde;

		}

        public tbestoquelocal_mov(DataRow i)
        {
            dtlog_insert			= Convert.ToDateTime(i["dtlog_insert"].ToString());       
            estlocal_mov_seq		= Convert.ToInt32(i["estlocal_mov_seq"].ToString());       	       
            estlocal_mov_data		= Convert.ToDateTime(i["estlocal_mov_data"].ToString());       	       
            pr_cdproduto		= Convert.ToInt32(i["estlocal_mov_seq"].ToString());       	       		       
            pr_embalagemestoque	=	i["estlocal_mov_seq"].ToString();	       
            estlocal_mov_embalagemestoque_qtde = Convert.ToDouble(i["estlocal_mov_seq"].ToString());   
        }
    }
}
