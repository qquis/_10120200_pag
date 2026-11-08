import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_regrafiscal_nfce_ncm extends clsBase {
       

        ncm_codigo: string
        ncm_excecao: number
        ncm_variacao: number    
    
        nfce_produto_tipo_cd: number
        cbs_aliquota_ad_rem: number
        cbs_aliquota_desoneracao: number
        cbs_aliquota_efetiva: number
        cbs_aliquota: number
        cbs_cd: number
        cbs_descricao_abreviada: string
        cbs_descricao: string
        cbs_percentual_credito_presumido_monofasico: number
        cbs_percentual_credito_presumido: number
        cbs_percentual_diferimento_monofasico: number
        cbs_percentual_diferimento: number
        cbs_percentual_reducao: number
        cfop: number
        codigo_figura_regra_fiscal: number
        codigo_regra_fiscal: number
        cofins_aliquota: number
        cofins_cst: number
        data_hora_geracao: Date
        data_referencia: string
        dtlog_insert: Date
        dtlog_update: Date
        fc_rf_nfce_seq: number
        ibs_aliquota_ad_rem: number
        ibs_aliquota_desoneracao: number
        ibs_aliquota_efetiva: number
        ibs_aliquota: number
        ibs_cd: number
        ibs_descricao_abreviada: string
        ibs_descricao: string
        ibs_percentual_credito_presumido_monofasico: number
        ibs_percentual_credito_presumido: number
        ibs_percentual_diferimento_monofasico: number
        ibs_percentual_diferimento: number
        ibs_percentual_reducao: number


        ibs_mun_aliquota_ad_rem: number
        ibs_mun_aliquota_desoneracao: number
        ibs_mun_aliquota_efetiva: number
        ibs_mun_aliquota: number
        ibs_mun_cd: number
        ibs_mun_descricao_abreviada: string
        ibs_mun_descricao: string
        ibs_mun_percentual_credito_presumido_monofasico: number
        ibs_mun_percentual_credito_presumido: number
        ibs_mun_percentual_diferimento_monofasico: number
        ibs_mun_percentual_diferimento: number
        ibs_mun_percentual_reducao: number


        icms_aliquota_desoneracao: number
        icms_aliquota_efetiva: number
        icms_aliquota_final: number
        icms_aliquota_interna: number
        icms_aliquota: number
        icms_codigo_icms: number
        icms_codigo_origem: number
        icms_codigo_tributacao_final: number
        icms_codigo_tributacao: number
        icms_csosn: string
        icms_decreto_de_lei: string
        icms_desconto_icms_desonerado: string
        icms_fcp_agregado: number
        icms_fcp_segregado: number
        icms_percentual_diferimento: number
        icms_reducao_aliquota_efetiva: number
        icms_reducao: number
        ipi_aliquota: number
        ipi_cst: number

        pis_aliquota: number
        pis_cst: number

        rt_codigo_class_trib_ibs_cbs: string
        rt_codigo_cst_ibs_cbs: string
        rt_descricao_class_trib_ibs_cbs: string
        rt_descricao_cst_ibs_cbs: string
        
        LOCAL_STATUS_API: number
        constructor() {
            super()


            
            
            this.nfce_produto_tipo_cd= 0
            this.cbs_aliquota= 0 
            this.cbs_aliquota_ad_rem= 0 
            this.cbs_aliquota_desoneracao= 0 
            this.cbs_aliquota_efetiva= 0 
            this.cbs_cd= 0
            this.cbs_descricao= ''
            this.cbs_descricao_abreviada= ''
            this.cbs_percentual_credito_presumido= 0 
            this.cbs_percentual_credito_presumido_monofasico= 0 
            this.cbs_percentual_diferimento= 0 
            this.cbs_percentual_diferimento_monofasico= 0 
            this.cbs_percentual_reducao= 0 
            this.cfop= 0
            this.codigo_figura_regra_fiscal= 0
            this.codigo_regra_fiscal= 0
            this.cofins_aliquota= 0 
            this.cofins_cst= 0
            this.data_hora_geracao= this.__defaultDateNow 
            this.data_referencia= ''
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.fc_rf_nfce_seq= 0
            this.ibs_aliquota= 0 
            this.ibs_aliquota_ad_rem= 0 
            this.ibs_aliquota_desoneracao= 0 
            this.ibs_aliquota_efetiva= 0 
            this.ibs_cd= 0
            this.ibs_descricao= ''
            this.ibs_descricao_abreviada= ''
            this.ibs_percentual_credito_presumido= 0 
            this.ibs_percentual_credito_presumido_monofasico= 0 
            this.ibs_percentual_diferimento= 0 
            this.ibs_percentual_diferimento_monofasico= 0 
            this.ibs_percentual_reducao= 0 

            this.ibs_mun_aliquota_ad_rem = 0
            this.ibs_mun_aliquota_desoneracao = 0
            this.ibs_mun_aliquota_efetiva = 0
            this.ibs_mun_aliquota = 0
            this.ibs_mun_cd = 0
            this.ibs_mun_descricao_abreviada = ''
            this.ibs_mun_descricao = ''
            this.ibs_mun_percentual_credito_presumido_monofasico = 0
            this.ibs_mun_percentual_credito_presumido = 0
            this.ibs_mun_percentual_diferimento_monofasico = 0
            this.ibs_mun_percentual_diferimento = 0
            this.ibs_mun_percentual_reducao = 0




            this.icms_aliquota= 0 
            this.icms_aliquota_desoneracao= 0
            this.icms_aliquota_efetiva= 0 
            this.icms_aliquota_final= 0 
            this.icms_aliquota_interna= 0 
            this.icms_codigo_icms= 0
            this.icms_codigo_origem= 0
            this.icms_codigo_tributacao= 0
            this.icms_codigo_tributacao_final= 0
            this.icms_csosn= ''
            this.icms_decreto_de_lei= ''
            this.icms_desconto_icms_desonerado= ''
            this.icms_fcp_agregado= 0 
            this.icms_fcp_segregado= 0 
            this.icms_percentual_diferimento= 0 
            this.icms_reducao= 0 
            this.icms_reducao_aliquota_efetiva= 0 
            this.ipi_aliquota= 0 
            this.ipi_cst= 0
            this.ncm_codigo= ''
            this.ncm_excecao= 0
            this.ncm_variacao= 0
            this.pis_aliquota= 0 
            this.pis_cst= 0

            this.rt_codigo_class_trib_ibs_cbs= ''
            this.rt_codigo_cst_ibs_cbs= ''
            this.rt_descricao_class_trib_ibs_cbs= ''
            this.rt_descricao_cst_ibs_cbs= ''
            this.LOCAL_STATUS_API= 0
        }
        sql_CRUD() { 
            return this.sql_insert() + this.sql_update();
        }


        sql_insert() : string {
            let sql = `INSERT INTO tbfc_regrafiscal_nfce_ncm (
                nfce_produto_tipo_cd,
                ncm_codigo,
                ncm_excecao,
                ncm_variacao,                

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
                ${this.nfce_produto_tipo_cd},
                '${this.ncm_codigo}',
                ${this.ncm_excecao},
                ${this.ncm_variacao},
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

                ${this.data_hora_geracao ? `'${this.myTools._datemomentDateToStr(this.data_hora_geracao, 'YYYY-MM-DD HH:mm:ss')}'` : 'NULL'},
                '${this.data_referencia}',
                ${this.codigo_figura_regra_fiscal},
                0,
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
            where NOT EXISTS (
                    SELECT 1 
                    FROM tbfc_regrafiscal_nfce_ncm
                    WHERE ncm_codigo = '${this.ncm_codigo}'
                    AND ncm_excecao = ${this.ncm_excecao}
                    AND ncm_variacao = ${this.ncm_variacao}
                    )
            ;`



            return sql 
        }

        sql_update() :string { 
            let sql = `
            UPDATE tbfc_regrafiscal_nfce_ncm SET
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
                data_hora_geracao = ${this.data_hora_geracao ? `'${this.myTools._datemomentDateToStr(this.data_hora_geracao, 'YYYY-MM-DD HH:mm:ss')}'` : 'NULL'},
                data_referencia = '${this.data_referencia}',
                codigo_figura_regra_fiscal = ${this.codigo_figura_regra_fiscal},
                codigo_regra_fiscal = 0,
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
            WHERE 1 = 1
              and ncm_codigo = '${this.ncm_codigo}'
              and ncm_excecao = ${this.ncm_excecao}
              and ncm_variacao = ${this.ncm_variacao}
              and nfce_produto_tipo_cd = ${this.nfce_produto_tipo_cd}
            ; `


            return sql;
        }
}
