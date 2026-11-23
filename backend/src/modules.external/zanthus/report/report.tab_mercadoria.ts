import { clsBase, clsTools } from "../../../model/modelbase";


export default class reportExternalZanthusTabMercadoria {
    public static async sql(filter: any): Promise<string> {

        let data_venda_ini = '1900-01-01';
        let data_venda_fim = '2100-01-01';

        if (filter.filtrar_data_venda) {
            data_venda_ini = filter.data_venda_ini ? filter.data_venda_ini : '1900-01-01';
            data_venda_fim = filter.data_venda_fim ? filter.data_venda_fim : '2100-01-01';
        }

        let sql = `
            WITH cte_regras_icms AS (
                SELECT cod_mercadoria
                     , COUNT(*) AS regra_count
                  FROM tab_regras_icms
                 GROUP BY cod_mercadoria
            ),
            cte_regras_icms_cbenef_invalido AS (
                SELECT cod_mercadoria
                     , COUNT(*) AS regra_count
                  FROM tab_regras_icms x
                 WHERE x.flg_tipo_imposto = '0'
                   AND TRIM(COALESCE(x.codigo_beneficio_fiscal, '')) = ''
                   AND LPAD(x.cst, 3, '0') IN ('020', '040')
                 GROUP BY cod_mercadoria
            )
            ${ filter.filtrar_data_venda ? `,
            cte_mercadorias_vendidas AS (
                SELECT DISTINCT LPAD(i.m43ah, 17, '0') AS cod_mercadoria
                  FROM zan_m43 i
                  LEFT JOIN ZAN_M45 A
                         ON a.m00af = i.m00af
                        AND a.m00ad = i.m00ad
                        AND a.m00ac = i.m00ac
                  LEFT JOIN tab_nota_header n
                         ON A.M45XD = N.NUMNOTA
                        AND A.M00AC = N.NUMPDV
                        AND A.M45XE = N.SERIE_NF
                 WHERE 1 = 1
                   AND i.m00af >= '${data_venda_ini}'
                   AND i.m00af <= '${data_venda_fim}'
                   ${ filter.numero_cupom && filter.numero_cupom !== '' ? ` AND i.m00ad = '${filter.numero_cupom}' ` : '' }
                   ${ filter.ecf && filter.ecf !== '' ? ` AND i.m00ac = '${filter.ecf}' ` : '' }
                   ${ filter.numero_nf && filter.numero_nf !== '' ? ` AND A.M45XD = '${filter.numero_nf}' ` : '' }
            )
            ` : '' }

            SELECT     m.cod_mercadoria
                     , m.descricao
                     , m.descricao_abr

                     , LPAD(CAST(m.cod_ncm AS VARCHAR(8)), 8, '0') AS cod_ncm
                     , m.cod_ex
                     , m.cod_departamento

                     , m.data_cadastro
                     , m.data_ultima_alteracao

                     , m.cfop
                     , m.cod_tributacao_mercadoria

                     , LPAD(m.cod_situacao_tributaria, 3, '0') AS cod_situacao_tributaria
                     , m.aliquota_interna_icms
                     , m.aliquota_icms
                     , m.percentual_reduz_b_calculo

                     , m.cod_sit_trib_pis
                     , m.aliquota_pis
                     , m.perc_reduz_b_calculo_pis

                     , m.cod_sit_trib_cofins
                     , m.aliquota_cofins
                     , m.perc_reduz_b_calculo_cofins

                     , m.cod_sit_tributaria_ibs_cbs
                     , m.cod_class_tributaria_is
                     , m.cod_class_tributaria_ibs_cbs
                     , m.per_aliquota_is
                     , m.per_aliquota_is_especifica
                     , m.per_aliquota_ibs_uf
                     , m.per_reducao_aliquota_ibs_uf
                     , m.per_diferimento_ibs_uf
                     , m.per_aliquota_ibs_mun
                     , m.per_reducao_aliquota_ibs_mun
                     , m.per_diferimento_ibs_mun
                     , m.per_aliquota_cbs
                     , m.per_diferimento_cbs
                     , m.per_reducao_aliquota_cbs
                     , m.per_cred_presumido_ibs_mono
                     , m.per_cred_presumido_cbs_mono
                     , coalesce(m.origem_cadastro, '0') AS origem_cadastro
                     , TRIM(COALESCE(m.codigo_beneficio_fiscal, '')) AS codigo_beneficio_fiscal
                     , COALESCE(c.regra_count, 0)          AS regra_count
                     , COALESCE(cicmsError.regra_count, 0) AS regra_icms_cbenef_invalido_count

              FROM tab_mercadoria m
              LEFT JOIN cte_regras_icms c
                     ON c.cod_mercadoria = m.cod_mercadoria
              LEFT JOIN cte_regras_icms_cbenef_invalido cicmsError
                     ON cicmsError.cod_mercadoria = m.cod_mercadoria
             WHERE 1 = 1
               ${ filter.cod_mercadoria       ? ` AND m.cod_mercadoria = LPAD('${filter.cod_mercadoria}', 17, '0') ` : '' }
               ${ filter.cod_mercadoria_like  ? ` AND m.cod_mercadoria LIKE '%${filter.cod_mercadoria_like}' ` : '' }
               ${ filter.descricao            ? ` AND m.descricao LIKE '%${filter.descricao}%' ` : '' }
               ${ filter.origem_cadastro      ? ` AND coalesce(m.origem_cadastro, '0')  = '${filter.origem_cadastro}' ` : '' }
        `;

        if (filter.regra_count && filter.regra_count !== '') {
            sql += ` AND c.regra_count < ${filter.regra_count} `;
        }

        if (filter.mercadoria_cbenef_invalido && filter.mercadoria_cbenef_invalido == 1) {
            sql += ` AND LPAD(cod_situacao_tributaria, 3, '0') IN ('020', '040')
                     AND COALESCE(m.codigo_beneficio_fiscal, '') = '' `;
        }

        if (filter.regraicms_cbenef_invalido && filter.regraicms_cbenef_invalido == 1) {
            sql += ` AND cicmsError.regra_count > 0 `;
        }

        if (filter.filtrar_data_venda) {
            sql += ` AND m.cod_mercadoria IN (SELECT cod_mercadoria FROM cte_mercadorias_vendidas) `;
        }

        sql += ` ORDER BY m.descricao ASC, m.cod_mercadoria ASC `;


        return sql;
    }

    public static async get(filter: any): Promise<any> {
        let listResultado: any;
        try {
            let myclassBase = new clsBase();
            listResultado = await myclassBase.myDataBase.zanthusPostgre.DataGet(await this.sql(filter));
        } catch (e) {
            clsTools.pagConsole(`M0085 - Zanthus | report.tab_mercadoria.ts | get
                                OBS..: Retorno vazio do itemConsultado mantido via finally
                                Error:
                                ${e}
                                `);
        } finally {
            return listResultado;
        }
    }
}