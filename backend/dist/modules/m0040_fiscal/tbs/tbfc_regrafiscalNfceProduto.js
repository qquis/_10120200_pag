"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class tbfc_regrafiscal_nfce_produto extends modelbase_1.clsBase {
    constructor() {
        super();
        this.prb_cdprodutobluesoft = 0;
        this.nfce_produto_tipo_cd = 0;
        this.cbs_aliquota = 0;
        this.cbs_aliquota_ad_rem = 0;
        this.cbs_aliquota_desoneracao = 0;
        this.cbs_aliquota_efetiva = 0;
        this.cbs_cd = 0;
        this.cbs_descricao = '';
        this.cbs_descricao_abreviada = '';
        this.cbs_percentual_credito_presumido = 0;
        this.cbs_percentual_credito_presumido_monofasico = 0;
        this.cbs_percentual_diferimento = 0;
        this.cbs_percentual_diferimento_monofasico = 0;
        this.cbs_percentual_reducao = 0;
        this.cfop = 0;
        this.codigo_figura_regra_fiscal = 0;
        this.codigo_regra_fiscal = 0;
        this.cofins_aliquota = 0;
        this.cofins_cst = 0;
        this.data_hora_geracao = this.__defaultDateNow;
        this.data_referencia = '';
        this.dtlog_insert = this.__defaultDateNow;
        this.dtlog_update = this.__defaultDateNow;
        this.fc_rf_nfce_seq = 0;
        this.ibs_aliquota = 0;
        this.ibs_aliquota_ad_rem = 0;
        this.ibs_aliquota_desoneracao = 0;
        this.ibs_aliquota_efetiva = 0;
        this.ibs_cd = 0;
        this.ibs_descricao = '';
        this.ibs_descricao_abreviada = '';
        this.ibs_percentual_credito_presumido = 0;
        this.ibs_percentual_credito_presumido_monofasico = 0;
        this.ibs_percentual_diferimento = 0;
        this.ibs_percentual_diferimento_monofasico = 0;
        this.ibs_percentual_reducao = 0;
        this.ibs_mun_aliquota_ad_rem = 0;
        this.ibs_mun_aliquota_desoneracao = 0;
        this.ibs_mun_aliquota_efetiva = 0;
        this.ibs_mun_aliquota = 0;
        this.ibs_mun_cd = 0;
        this.ibs_mun_descricao_abreviada = '';
        this.ibs_mun_descricao = '';
        this.ibs_mun_percentual_credito_presumido_monofasico = 0;
        this.ibs_mun_percentual_credito_presumido = 0;
        this.ibs_mun_percentual_diferimento_monofasico = 0;
        this.ibs_mun_percentual_diferimento = 0;
        this.ibs_mun_percentual_reducao = 0;
        this.icms_aliquota = 0;
        this.icms_aliquota_desoneracao = 0;
        this.icms_aliquota_efetiva = 0;
        this.icms_aliquota_final = 0;
        this.icms_aliquota_interna = 0;
        this.icms_codigo_icms = 0;
        this.icms_codigo_origem = 0;
        this.icms_codigo_tributacao = 0;
        this.icms_codigo_tributacao_final = 0;
        this.icms_csosn = '';
        this.icms_decreto_de_lei = '';
        this.icms_desconto_icms_desonerado = '';
        this.icms_fcp_agregado = 0;
        this.icms_fcp_segregado = 0;
        this.icms_percentual_diferimento = 0;
        this.icms_reducao = 0;
        this.icms_reducao_aliquota_efetiva = 0;
        this.ipi_aliquota = 0;
        this.ipi_cst = 0;
        this.ncm_codigo = '';
        this.ncm_excecao = 0;
        this.ncm_variacao = 0;
        this.pis_aliquota = 0;
        this.pis_cst = 0;
        this.rt_codigo_class_trib_ibs_cbs = '';
        this.rt_codigo_cst_ibs_cbs = '';
        this.rt_descricao_class_trib_ibs_cbs = '';
        this.rt_descricao_cst_ibs_cbs = '';
        this.LOCAL_STATUS_API = 0;
    }
    sql_CRUD() {
        return this.sql_insert() + this.sql_update();
    }
    sql_insert() {
        let sql = `INSERT INTO tbfc_regrafiscal_nfce_produto (
                                    api_ncm,
                                    nfce_produto_tipo_cd,
                                    prb_cdprodutobluesoft,
                                    prb_cdprodutobluesoftunitario, 
                                    pr_cdproduto, 
                                    cfop,
                                    

                                    icms_codigo_origem,
                                    icms_codigo_tributacao,
                                    icms_codigo_tributacao_final,
                                    icms_percentual_diferimento,
                                    icms_aliquota_interna,
                                    icms_fcp_agregado,
                                    icms_fcp_segregado,
                                    icms_codigo_icms,
                                    icms_reducao_aliquota_efetiva,
                                    icms_aliquota_efetiva,
                                    icms_aliquota,
                                    icms_reducao,
                                    icms_aliquota_final,
                                    icms_csosn,
                                    icms_aliquota_desoneracao,
                                    icms_decreto_de_lei,
                                    icms_desconto_icms_desonerado,
                                    
                                    cofins_aliquota,
                                    cofins_cst,
                                    
                                    pis_aliquota,
                                    pis_cst,
                                    
                                    ipi_aliquota,
                                    ipi_cst,
                                    
                                    ncm_codigo,
                                    ncm_excecao,
                                    ncm_variacao,
                                    
                                    data_hora_geracao,
                                    data_referencia,
                                    codigo_figura_regra_fiscal,
                                    codigo_regra_fiscal,
                                    
                                    rt_codigo_cst_ibs_cbs,
                                    rt_codigo_class_trib_ibs_cbs,

                                    
                                    ibs_cd,
                                    ibs_aliquota,
                                    ibs_aliquota_efetiva,
                                    ibs_percentual_credito_presumido,
                                    ibs_percentual_diferimento,
                                    ibs_percentual_reducao,
                                    ibs_aliquota_desoneracao,
                                    ibs_aliquota_ad_rem,
                                    ibs_percentual_credito_presumido_monofasico,
                                    ibs_percentual_diferimento_monofasico,

                                
                                    ibs_mun_cd,
                                    ibs_mun_aliquota,
                                    ibs_mun_aliquota_efetiva,
                                    ibs_mun_percentual_credito_presumido,
                                    ibs_mun_percentual_diferimento,
                                    ibs_mun_percentual_reducao,
                                    ibs_mun_aliquota_desoneracao,
                                    ibs_mun_aliquota_ad_rem,
                                    ibs_mun_percentual_credito_presumido_monofasico,
                                    ibs_mun_percentual_diferimento_monofasico,                
                                    
                                    cbs_cd,
                                    cbs_aliquota,
                                    cbs_aliquota_efetiva,
                                    cbs_percentual_credito_presumido,
                                    cbs_percentual_diferimento,
                                    cbs_percentual_reducao,
                                    cbs_aliquota_desoneracao,
                                    cbs_aliquota_ad_rem,
                                    cbs_percentual_credito_presumido_monofasico,
                                    cbs_percentual_diferimento_monofasico
                                ) 
            SELECT
                 0 as api_ncm,
                ${this.nfce_produto_tipo_cd},
                ${this.prb_cdprodutobluesoft},
                coalesce(prb.prb_cdprodutobluesoftunitario,0), 
                coalesce(pr.pr_cdproduto,0),
                ${this.cfop},
                
                ${this.icms_codigo_origem},
                ${this.icms_codigo_tributacao},
                ${this.icms_codigo_tributacao_final},
                ${this.icms_percentual_diferimento},
                ${this.icms_aliquota_interna},
                ${this.icms_fcp_agregado},
                ${this.icms_fcp_segregado},
                ${this.icms_codigo_icms},
                ${this.icms_reducao_aliquota_efetiva},
                ${this.icms_aliquota_efetiva},
                ${this.icms_aliquota},
                ${this.icms_reducao},
                ${this.icms_aliquota_final},
                '${this.icms_csosn}',
                ${this.icms_aliquota_desoneracao},
                '${this.icms_decreto_de_lei}',
                '${this.icms_desconto_icms_desonerado}',
                
                ${this.cofins_aliquota},
                ${this.cofins_cst},
                
                ${this.pis_aliquota},
                ${this.pis_cst},
                
                ${this.ipi_aliquota},
                ${this.ipi_cst},
                '${this.ncm_codigo}',
                ${this.ncm_excecao},
                ${this.ncm_variacao},
                ${this.data_hora_geracao ? `'${this.myTools._datemomentDateToStr(this.data_hora_geracao, 'YYYY-MM-DD HH:mm:ss')}'` : 'NULL'},
                '${this.data_referencia}',
                ${this.codigo_figura_regra_fiscal},
                ${this.codigo_regra_fiscal},
                '${this.rt_codigo_cst_ibs_cbs}',

                '${this.rt_codigo_class_trib_ibs_cbs}',

                ${this.ibs_cd},
                ${this.ibs_aliquota},
                ${this.ibs_aliquota_efetiva},
                ${this.ibs_percentual_credito_presumido},
                ${this.ibs_percentual_diferimento},
                ${this.ibs_percentual_reducao},
                ${this.ibs_aliquota_desoneracao},
                ${this.ibs_aliquota_ad_rem},
                ${this.ibs_percentual_credito_presumido_monofasico},
                ${this.ibs_percentual_diferimento_monofasico},
                
                ${this.ibs_mun_cd},
                ${this.ibs_mun_aliquota},
                ${this.ibs_mun_aliquota_efetiva},
                ${this.ibs_mun_percentual_credito_presumido},
                ${this.ibs_mun_percentual_diferimento},
                ${this.ibs_mun_percentual_reducao},
                ${this.ibs_mun_aliquota_desoneracao},
                ${this.ibs_mun_aliquota_ad_rem},
                ${this.ibs_mun_percentual_credito_presumido_monofasico},
                ${this.ibs_mun_percentual_diferimento_monofasico},
                
                ${this.cbs_cd},
                ${this.cbs_aliquota},
                ${this.cbs_aliquota_efetiva},
                ${this.cbs_percentual_credito_presumido},
                ${this.cbs_percentual_diferimento},
                ${this.cbs_percentual_reducao},
                ${this.cbs_aliquota_desoneracao},
                ${this.cbs_aliquota_ad_rem},
                ${this.cbs_percentual_credito_presumido_monofasico},
                ${this.cbs_percentual_diferimento_monofasico}
            FROM        tbprodutobluesoft       prb 
            LEFT JOIN   tbproduto               pr ON pr.prb_cdprodutobluesoft = prb.prb_cdprodutobluesoftunitario 
            WHERE       PRB.prb_cdprodutobluesoft_pk = ${this.prb_cdprodutobluesoft}
            AND NOT EXISTS (
                    SELECT 1 
                    FROM tbfc_regrafiscal_nfce_produto 
                    WHERE prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft} 
                    and nfce_produto_tipo_cd = ${this.nfce_produto_tipo_cd}
                    )
            ;`;
        return sql;
    }
    sql_update() {
        let sql = `
            UPDATE tbfc_regrafiscal_nfce_produto SET
                api_ncm = 0,
                cfop = ${this.cfop},
                icms_codigo_origem = ${this.icms_codigo_origem},
                icms_codigo_tributacao = ${this.icms_codigo_tributacao},
                icms_codigo_tributacao_final = ${this.icms_codigo_tributacao_final},
                icms_percentual_diferimento = ${this.icms_percentual_diferimento},
                icms_aliquota_interna = ${this.icms_aliquota_interna},
                icms_fcp_agregado = ${this.icms_fcp_agregado},
                icms_fcp_segregado = ${this.icms_fcp_segregado},
                icms_codigo_icms = ${this.icms_codigo_icms},
                icms_reducao_aliquota_efetiva = ${this.icms_reducao_aliquota_efetiva},
                icms_aliquota_efetiva = ${this.icms_aliquota_efetiva},
                icms_aliquota = ${this.icms_aliquota},
                icms_reducao = ${this.icms_reducao},
                icms_aliquota_final = ${this.icms_aliquota_final},
                icms_csosn = '${this.icms_csosn}',
                icms_aliquota_desoneracao = ${this.icms_aliquota_desoneracao},
                icms_decreto_de_lei = '${this.icms_decreto_de_lei}',
                icms_desconto_icms_desonerado = '${this.icms_desconto_icms_desonerado}',
                cofins_aliquota = ${this.cofins_aliquota},
                cofins_cst = ${this.cofins_cst},
                pis_aliquota = ${this.pis_aliquota},
                pis_cst = ${this.pis_cst},
                ipi_aliquota = ${this.ipi_aliquota},
                ipi_cst = ${this.ipi_cst},
                ncm_codigo = '${this.ncm_codigo}',
                ncm_excecao = ${this.ncm_excecao},
                ncm_variacao = ${this.ncm_variacao},
                data_hora_geracao = ${this.data_hora_geracao ? `'${this.myTools._datemomentDateToStr(this.data_hora_geracao, 'YYYY-MM-DD HH:mm:ss')}'` : 'NULL'},
                data_referencia = '${this.data_referencia}',
                codigo_figura_regra_fiscal = ${this.codigo_figura_regra_fiscal},
                codigo_regra_fiscal = ${this.codigo_regra_fiscal},
                rt_codigo_cst_ibs_cbs = '${this.rt_codigo_cst_ibs_cbs}',
                rt_codigo_class_trib_ibs_cbs = '${this.rt_codigo_class_trib_ibs_cbs}',
                
                ibs_cd = ${this.ibs_cd},
                ibs_aliquota = ${this.ibs_aliquota},
                ibs_aliquota_efetiva = ${this.ibs_aliquota_efetiva},
                ibs_percentual_credito_presumido = ${this.ibs_percentual_credito_presumido},
                ibs_percentual_diferimento = ${this.ibs_percentual_diferimento},
                ibs_percentual_reducao = ${this.ibs_percentual_reducao},
                ibs_aliquota_desoneracao = ${this.ibs_aliquota_desoneracao},
                ibs_aliquota_ad_rem = ${this.ibs_aliquota_ad_rem},
                ibs_percentual_credito_presumido_monofasico = ${this.ibs_percentual_credito_presumido_monofasico},
                ibs_percentual_diferimento_monofasico = ${this.ibs_percentual_diferimento_monofasico},


                ibs_mun_cd = ${this.ibs_mun_cd},
                ibs_mun_aliquota = ${this.ibs_mun_aliquota},
                ibs_mun_aliquota_efetiva = ${this.ibs_mun_aliquota_efetiva},
                ibs_mun_percentual_credito_presumido = ${this.ibs_mun_percentual_credito_presumido},
                ibs_mun_percentual_diferimento = ${this.ibs_mun_percentual_diferimento},
                ibs_mun_percentual_reducao = ${this.ibs_mun_percentual_reducao},
                ibs_mun_aliquota_desoneracao = ${this.ibs_mun_aliquota_desoneracao},
                ibs_mun_aliquota_ad_rem = ${this.ibs_mun_aliquota_ad_rem},
                ibs_mun_percentual_credito_presumido_monofasico = ${this.ibs_mun_percentual_credito_presumido_monofasico},
                ibs_mun_percentual_diferimento_monofasico = ${this.ibs_mun_percentual_diferimento_monofasico},




                cbs_cd = ${this.cbs_cd},
                cbs_aliquota = ${this.cbs_aliquota},
                cbs_aliquota_efetiva = ${this.cbs_aliquota_efetiva},
                cbs_percentual_credito_presumido = ${this.cbs_percentual_credito_presumido},
                cbs_percentual_diferimento = ${this.cbs_percentual_diferimento},
                cbs_percentual_reducao = ${this.cbs_percentual_reducao},
                cbs_aliquota_desoneracao = ${this.cbs_aliquota_desoneracao},
                cbs_aliquota_ad_rem = ${this.cbs_aliquota_ad_rem},
                cbs_percentual_credito_presumido_monofasico = ${this.cbs_percentual_credito_presumido_monofasico},
                cbs_percentual_diferimento_monofasico = ${this.cbs_percentual_diferimento_monofasico},
                dtlog_update = current_timestamp
            WHERE prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft}
              and nfce_produto_tipo_cd = ${this.nfce_produto_tipo_cd}
            ; `;
        if (this.nfce_produto_tipo_cd == 1) {
            sql += `
                    update tbfc_figurafiscal_produto set regrafiscal_nfce = 1
                        ,  fc_figurafiscal_cd = ${this.codigo_figura_regra_fiscal}
                        ,  dtlog_update = current_timestamp
                    where prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft}
                    and prb_cdprodutobluesoft in (select prb_cdprodutobluesoft from tbfc_regrafiscal_nfce_produto)
                    ;

                `;
        }
        return sql;
    }
}
exports.default = tbfc_regrafiscal_nfce_produto;
