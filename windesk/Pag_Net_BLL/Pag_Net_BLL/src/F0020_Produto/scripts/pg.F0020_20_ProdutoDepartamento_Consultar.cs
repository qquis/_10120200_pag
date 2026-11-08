using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0020_Produto
{
    public static class F0020_21_ProdutoDepartamentoConsultar
    {



        private static string _VERSION() { return "f0020_20_1011924_produtodepartamento_consultar"; }
        public static string Get(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            int sis_ac_cd

            )
        {
            try
            {
                string SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + "( {0}, {1}) ",
                            MyConnect.sis_us_seq.ToString(),
                            sis_ac_cd.ToString()
                    );
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}