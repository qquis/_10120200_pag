import { clsBase, clsTools } from '../../../model/modelbase'
//import {Request, Response, Router} from 'express'


export default class tbsistema_nucleo_procedimento extends clsBase {
        data_default_fim: number
        data_default_ini: number
        data_reprocessamento_default: Date
        data_reprocessamento_default_fim: Date
        dateadd_fim: number
        dateadd_ini: number
        dtlog_insert: Date
        dtlog_update: Date
        permite_execucao_manual: number
        script_app: number
        script_database: number
        sis_batch_cd: number
        sis_nucleo_cd_fk
        sis_nucleo_prc_cd: number
        sis_nucleo_prc_descricao: string
        sis_nucleo_prc_descritivo: string
        sis_nucleo_prc_ref: string
        sis_nucleo_prc_tipo: number
        notificacao_cd: number
        versao: number

        constructor() {
            super()
            this.data_default_fim= 0 
            this.data_default_ini= 0 
            this.data_reprocessamento_default_fim= this.__defaultDateNow 
            this.data_reprocessamento_default= this.__defaultDateNow 
            this.dateadd_fim= 0
            this.dateadd_ini= 0
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.permite_execucao_manual= 0 
            this.script_app= 0 
            this.script_database= 0 
            this.sis_batch_cd= 0
            this.sis_nucleo_cd_fk= ''
            this.sis_nucleo_prc_cd= 0
            this.sis_nucleo_prc_descricao= ''
            this.sis_nucleo_prc_descritivo= ''
            this.sis_nucleo_prc_ref= ''
            this.sis_nucleo_prc_tipo= 0 
            this.versao= 0
            this.notificacao_cd = 0

        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.data_default_fim = item?.data_default_fim
                this.data_default_ini = item?.data_default_ini
                this.data_reprocessamento_default_fim = item?.data_reprocessamento_default_fim
                this.data_reprocessamento_default = item?.data_reprocessamento_default
                this.dateadd_fim = item?.dateadd_fim
                this.dateadd_ini = item?.dateadd_ini
                this.permite_execucao_manual = item?.permite_execucao_manual
                this.script_app = item?.script_app
                this.script_database = item?.script_database
                this.sis_batch_cd = item?.sis_batch_cd
                this.sis_nucleo_cd_fk = item?.sis_nucleo_cd_fk
                this.sis_nucleo_prc_cd = item?.sis_nucleo_prc_cd
                this.sis_nucleo_prc_descricao = item?.sis_nucleo_prc_descricao
                this.sis_nucleo_prc_descritivo = item?.sis_nucleo_prc_descritivo
                this.sis_nucleo_prc_ref = item?.sis_nucleo_prc_ref
                this.sis_nucleo_prc_tipo = item?.sis_nucleo_prc_tipo
                this.versao = item?.versao
                this.notificacao_cd = item?.notificacao_cd

        }
    }
}