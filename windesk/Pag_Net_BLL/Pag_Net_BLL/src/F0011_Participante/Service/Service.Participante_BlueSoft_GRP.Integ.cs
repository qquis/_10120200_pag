using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante.Service
{
    public static class Participante_BlueSoft_GRP
    {
        public static void Integ(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {

                int _sis_nucleo_prc_cd = 1103;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;


                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "Participante_BlueSoft_GRP", string.Format("RedShift - Leitura inicial", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));

                DX = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, RedShift_DBSelect(), "");

                _COUNT = DX.Tables[0].Rows.Count;

                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[1].ToString();

                    Pag_Net.Bll.F0011_Participante.ModelParticipante_BlueSoft_GRP ITEM = new ModelParticipante_BlueSoft_GRP();
                    ITEM._Binding_BaseBlueSoft(dr);

                    _Command_All = _Command_All + PostGre_DBInsert(Models.BDCommandTypes.DBINSERT, ITEM) + ";";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 250 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "Participante_BlueSoft_GRP", string.Format("Participante_BlueSoft_GRP {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DX.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("NP0011_03_PessoaBlueSoft | " + ErroInfo + " - " + ex.Message);
            }

        }
        private static string RedShift_DBSelect()
        {

            string SQL = " SELECT  cast( coalesce(c.cliente_grupo_economico_key,0) as int)  as participante_bluesoft_grp_cd " +
                         "       , cast( coalesce(c.grupo_economico_key,0) as int)          as cdgrupoeconomico " +
                         "       , cast( coalesce(c.vendedor_cadastro_key,0) as int)        as cdpessoabluesoft_vendedor " +
                         "       , cast( coalesce(c.cliente_key,0) as int)                  as cdpessoabluesoft_cliente " +
                         "       , cast( coalesce(gc.desconto_financeiro,0) as int)         as participante_bluesoft_grp_desc_fin " +
                         "       , cast( coalesce(gc.comissao_porcentagem,0) as int)        as participante_bluesoft_grp_comissao " +
                         "       FROM       cliente_grupo_economico      c " +
                         "       inner join grupo_economico_comissao gc on gc.cliente_grupo_economico_key = c.cliente_grupo_economico_key " +
                         " ; ";
            return SQL;


        }
        private static string PostGre_DBInsert(        
            BDCommandTypes BDCommnadType,
            ModelParticipante_BlueSoft_GRP ITEM
            )
        {

            string SQL_POSTGRE = "";
            try
            {
                SQL_POSTGRE =
                         "SELECT * FROM " + F0011_91_Participante_BlueSoft_GRP_Integ._VERSION() +
                         " (    vparticipante_bluesoft_grp_cd:= " + ITEM.participante_bluesoft_grp_cd.ToString() + 
                         "   ,  vcdgrupoeconomico:= " + ITEM.cdgrupoeconomico.ToString() + 
                         "   ,  vcdpessoabluesoft_vendedor:= " + ITEM.cdpessoabluesoft_vendedor.ToString() + 
                         "   ,  vcdpessoabluesoft_cliente:= " + ITEM.cdpessoabluesoft_cliente.ToString() + 
                         "   ,  vparticipante_bluesoft_grp_desc_fin:= " + ITEM.participante_bluesoft_grp_desc_fin.ToString("0.00").Replace(",", ".") +
                         "   ,  vparticipante_bluesoft_grp_comissao:= " + ITEM.participante_bluesoft_grp_comissao.ToString("0.00").Replace(",", ".") + 
                         "  ) ";
                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(" Participante_BlueSoft \n PostGre_DBInsert \n " + ex.Message + "\n Script SQL INSERT" + SQL_POSTGRE);
            }

        }

    }
}
