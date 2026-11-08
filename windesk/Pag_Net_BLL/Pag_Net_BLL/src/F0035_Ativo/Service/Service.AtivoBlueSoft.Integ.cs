using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0035_Ativo.Service
{
    static class AtivoBlueSoft
    {
        public static void Import (Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            int _sis_nucleo_prc_cd = 3010;
            string _Command_All = "";
            int _SEQ_UPDATE = 0;
            int _SEQ_COUNT = 0;
            int _COUNT = 0;
            DbUpdate BDExecute;
            BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);


            string ErroInfo = "";
            try
            {

                DataSet DtSet = new DataSet();

                DtSet = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, RedShift_DBSelect(), "");

                _COUNT = DtSet.Tables[0].Rows.Count;

                foreach (DataRow dr in DtSet.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr["prb_cdprodutobluesoft"];
                    try
                    {
                        Pag_Net.Bll.F0035_Ativo.TbAtivoBlueSoft ITEM = new TbAtivoBlueSoft();
                        ITEM.TbAtivoBlueSoft_DataBinding(dr, DtSet.Tables[0].Columns);

                        _Command_All = _Command_All + ITEM.CRUD(Pag_Net.Models.BDCommandTypes.DBINSERT) + ";";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 500 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "F0135_90 - Ativos", string.Format("REG {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("F0030_10_EstoqueCustosDiario_Importar - " + ErroInfo + " - " + ex.Message);
            }
        }

        private static string RedShift_DBSelect()
        {

            string SQL = "           SELECT   " +
                    "    cast( 0 as int)                                                              as at_seq " +
                    " ,  left(coalesce(descricao_produto,''),60)                                      as at_descricao " +
                    " ,  cast(case when status_do_patrimonio = 'ATIVO' then 1 else 0 end as int)      as at_status " +
                    " ,  cast(0 as int)                                                               as at_tipo_cd " +
                    " ,  coalesce(patrimonio_item_key,0)                                              as at_bluesoft_patrimonio_item  " +
                    " ,  coalesce(produto_key,0)                                                      as prb_cdprodutobluesoft " +
                    " ,  left(descricao_produto,60)                                                   as at_bluesoft_descricao " +
                    " ,  left(coalesce(descricao_funcao_item,''),60)                                  as at_bluesoft_descricao_funcao_item " +
                    " ,  left(coalesce(chapa_key,''),25)                                              as at_bluesoft_chapa_key " +
                    " ,  left(coalesce(categoria,''),60)                                              as at_bluesoft_categoria " +
                    " ,  left(coalesce(grupo,''),60)                                                  as at_bluesoft_grupo " +
                    " ,  left(coalesce(subgrupo,''),60)                                               as at_bluesoft_subgrupo " +
                    " ,  cast(coalesce(valor_aquisicao,0) as numeric(13,2))                           as at_bluesoft_valoraquisicao " +
                    " ,  cast(coalesce(valor,0) as numeric(13,2))                                     as at_bluesoft_valor " +
                    " ,  cast(coalesce(nf_key,0) as int)                                              as df_nf_seq_blue " +
                    " FROM     PATRIMONIO_ITEM " +
                    " ORDER BY patrimonio_item_key asc";
            return SQL;

        }

    }
}
