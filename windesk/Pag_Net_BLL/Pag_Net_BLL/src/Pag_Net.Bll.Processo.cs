using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Processo
{
    public static class Registro
    {
        public static int Sequencial(Pag_Net.Models.modelSistemaUsuario Myconnect, int proc_tipo_cd)
        {
            try
            {
                return Convert.ToInt32(Pag_Net.Bll.R0010.Select.get(Myconnect, proc_tipo_cd).Rows[0].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Processo: " + ex.Message.ToString());
            }

        }
    }

    public static class Consultar
    {
        public static DataTable LOG (
                    Pag_Net.Models.modelSistemaUsuario MyConnect
                ,   DateTime    vdata_log_ini	
	            ,   DateTime	vdata_log_fim	
	            ,	int         vSIS_US_SEQ	
	            ,	int         vproc_tipo_cd
	            ,	int         vproc_cd	
            )
        {
            try
            {
                return Pag_Net.Bll.R0090.Select.get_DataTable(MyConnect,
                            vdata_log_ini,
                            vdata_log_fim, 
                            vSIS_US_SEQ,
                            vproc_tipo_cd, 
                            vproc_cd 
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Processo | " + ex.Message);
            }

        }
    }
}
