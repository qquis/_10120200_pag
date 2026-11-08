using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0030_EstoqueCusto;

namespace Pag_Net.Bll.F0035_Ativo
{
    public static class f0035_15_AtivoBlueSoft_crud
    {
        public static string _VERSION() { return "f0035_15_1011980_ativobluesoft_crud"; }
        public static string RedShift_Select()
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
