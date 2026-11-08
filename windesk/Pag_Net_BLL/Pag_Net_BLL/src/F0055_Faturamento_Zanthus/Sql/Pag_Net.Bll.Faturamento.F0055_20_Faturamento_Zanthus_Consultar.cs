using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0055_Faturamento_Zanthus.F0055_20_Faturamento_Zanthus_Consultar
{
    

    public static class RedShift
    {
        public static string get()
        {
            return "";
        }
    }

    public static class Postgre
    {

        public static string Version() { return "f0055_20_1012008_faturamento_zanthus_consultar"; }
        public static string Get(
             Pag_Net.Bll.F0055_Faturamento_Zanthus.Filter_Zanthus _filter,
             Wk_RelatorioZanthus_Tipo Tipo
            )
        {
            try
            {

                string _TipoRelatorio = "C";
                switch (Tipo)
                {
                    case Wk_RelatorioZanthus_Tipo.DataCupom:
                        _TipoRelatorio = "C";
                        break;
                    case Wk_RelatorioZanthus_Tipo.ECF:
                        _TipoRelatorio = "E";
                        break;
                    case Wk_RelatorioZanthus_Tipo.Hora:
                        _TipoRelatorio = "H";
                        break;

                }

                string _PostGre = string.Format("SELECT * FROM " +
                    Version() + "( '{0}', '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, '{10}', {11}, '{12}') ",
                        _filter.data_m00af_inicial.ToString("yyyy-MM-dd"), 
                        _filter.data_m00af_final.ToString("yyyy-MM-dd"), 
                        _filter.status_cancelado.ToString(),
                        _filter.cupomfiscal_m00ad.ToString(), 
                        _filter.vvalor_cupom_ini.ToString("0.00").Replace(",","."), 
                        _filter.vvalor_cupom_fim.ToString("0.00").Replace(",","."),
                        _filter.vvalor_desconto_ini.ToString("0.00").Replace(",","."),
                        _filter.vvalor_desconto_fim.ToString("0.00").Replace(",","."),
                        _filter.vstatus_processamento.ToString(),
                        _filter.vstatus_com_cpf.ToString(),
                        _TipoRelatorio.ToString(), 
                        _filter.Sat_ECF_m00ac.ToString(),
                        _filter.cd_barra_item_contem.ToString().Replace("'", "")

                    );
                return _PostGre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
