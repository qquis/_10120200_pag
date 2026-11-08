export default class tbsistemanucleoprocedimento {
                sis_nucleo_cd_fk: number
			  	sis_nucleo_prc_cd: number
			  	sis_nucleo_prc_descricao: string
			  	sis_nucleo_prc_tipo: number
			 	data_reprocessamento_default: Date
			 	data_reprocessamento_default_fim: Date
			    dateadd_ini: number 
			    dateadd_fim: number
			    data_default_ini: number 
			    data_default_fim: number
			    permite_execucao_manual: number
			 	notificacao_cd: number 
			 	limite_reg_bloq_update: number  
            
        constructor() {
                this.sis_nucleo_cd_fk = 0
                this.sis_nucleo_prc_cd = 0
                this.sis_nucleo_prc_descricao = ''
                this.sis_nucleo_prc_tipo = 0
                this.data_reprocessamento_default = new Date()
                this.data_reprocessamento_default_fim = new Date()
                this.dateadd_ini = 0
                this.dateadd_fim = 0
                this.data_default_ini = 0
                this.data_default_fim = 0
                this.permite_execucao_manual = 0
                this.notificacao_cd = 0
                this.limite_reg_bloq_update = 0
            }

        binding(item : any) { 
            if (item) {
                this.sis_nucleo_cd_fk = item?.sis_nucleo_cd_fk
                this.sis_nucleo_prc_cd = item?.sis_nucleo_prc_cd
                this.sis_nucleo_prc_descricao = item?.sis_nucleo_prc_descricao
                this.sis_nucleo_prc_tipo = item?.sis_nucleo_prc_tipo
                this.data_reprocessamento_default = item?.data_reprocessamento_default
                this.data_reprocessamento_default_fim = item?.data_reprocessamento_default_fim
                this.dateadd_ini = item?.dateadd_ini
                this.dateadd_fim = item?.dateadd_fim
                this.data_default_ini = item?.data_default_ini
                this.data_default_fim = item?.data_default_fim
                this.permite_execucao_manual = item?.permite_execucao_manual
                this.notificacao_cd = item?.notificacao_cd
                this.limite_reg_bloq_update = item?.limite_reg_bloq_update
            }
        }

        static sqlSelectLimiteRegBloqUpdate(sis_nucleo_prc_cd : number) : string {
            let sql : string = `SELECT coalesce(limite_reg_bloq_update,0) as limite_reg_bloq_update 
                        FROM tbsistema_nucleo_procedimento 
                        WHERE sis_nucleo_prc_cd = ${sis_nucleo_prc_cd}`
            return sql
        }
}