using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.rules
{
    public class CentroDr_Processamento
    {
        public List<string> ListProcess = new List<string>();
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public int CompetenciaCD;
        public CentroDr_Processamento(Pag_Net.Models.modelSistemaUsuario myConnect)
        {
            MyConnect = myConnect;
            ListProcess.Add("SELECT p0060_centrodr_processamento_folha ({0})");
            ListProcess.Add("SELECT p0050_centrodr_processamento ({0})");
            /*ListProcess.Add("SELECT p0051_centrodr_processamento_receita_100 ({0})");
            ListProcess.Add("SELECT p0052_centrodr_processamento_icms_105 ({0})");
            ListProcess.Add("SELECT p0053_centrodr_processamento_pis_110 ({0})");
            ListProcess.Add("SELECT p0054_centrodr_processamento_cofins_115 ({0})");
            ListProcess.Add("SELECT p0059_centrodr_processamento_cmv_500 ({0})");
            ListProcess.Add("SELECT p0056_centrodr_processamento_subsidios_300 ({0})");
            ListProcess.Add("SELECT p0057_centrodr_processamento_subsidios_PIS_310 ({0})");
            ListProcess.Add("SELECT p0058_centrodr_processamento_subsidios_COFINS_315 ({0})");
            ListProcess.Add("SELECT p0055_centrodr_processamento_descontofinanceiro_200 ({0})");
            ListProcess.Add("SELECT p0060_centrodr_processamento_folha ({0})");
            ListProcess.Add("sELECT p0061_centrodr_processamento_folha_cd_601 ({0})");
            ListProcess.Add("SELECT p0062_centrodr_processamento_folha_id_701 ({0})");
            ListProcess.Add("SELECT p0063_centrodr_processamento_variavel ({0})");
            ListProcess.Add("SELECT p0064_centrodr_processamento_resumo ({0})");
            ListProcess.Add("SELECT p0065_centrodr_processamento_despesa ({0})");*/
        }
        public void Execute()
        {
            try
            {
                for (int i = 0; i <= ListProcess.Count -1; i++)
                {
                    Pag_Net.Process.Execute(MyConnect, string.Format(ListProcess[i].ToString(), CompetenciaCD));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable Competencias()
        {
            try
            {
                return Pag_Net.Bll.R0005.Select._0001_competencia(MyConnect, 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
