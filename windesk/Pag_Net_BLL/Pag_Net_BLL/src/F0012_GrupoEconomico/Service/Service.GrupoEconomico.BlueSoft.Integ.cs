using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0012_GrupoEconomico;

namespace Pag_Net.Bll.F0012_GrupoEconomico.Service
{
    public static class GrupoEconomico_BlueSoft
    {
        public static void Integ(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {

                int _sis_nucleo_prc_cd = 1201;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;


                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);


                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "Grupo Economico", string.Format("RedShift - Leitura inicial", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));

                /*RedShift BlueSoft SELECT */
                List<ModelGrupoEconomico> List = new List<ModelGrupoEconomico>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, RedShift_DBSelect(), "");

                _COUNT = DX.Tables[0].Rows.Count;


                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[1].ToString();

                    Pag_Net.Bll.F0012_GrupoEconomico.ModelGrupoEconomico ITEM = new Pag_Net.Bll.F0012_GrupoEconomico.ModelGrupoEconomico();
                    ITEM._BlueSoft_Binding(dr);

                    _Command_All = _Command_All + ITEM._BlueSoft_Script_Integ_Get();
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 250 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "Grupo Econômico", string.Format("Grupo Econômico {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DX.Dispose();


            }
            catch (Exception ex)
            {
                throw new Exception("F0005.Bll | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }

        private static string RedShift_DBSelect()
        {

            string SQL = " select   grupo_economico_key      as   cdgrupoeconomico " +
                         "    ,     left(descricao,80)       as   descricao        " +
                         "    ,     isnull(status,0)         as   grupoeconomico_status" +
                         " from     grupo_economico";
            return SQL;

        }

    }


}
