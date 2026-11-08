//import { Request } from 'express';

import { clsBase, clsTools } from '../../../model/modelbase';

import serviceNotificacao from '../../../modules/m0210_notificacao/service/_serviceNotificacao';
let myClsBase = new clsBase();


/*TABELAS */
import tbsistema_nucleo_procedimento from '../tbs/tbsistema_nucleo_procedimento';



export default class modelsistema_nucleo_procedimento extends tbsistema_nucleo_procedimento  { 
    ErrorMessage: string
    constructor() { 
        super();
        this.ErrorMessage = ``
    }


    async dataInicial () : Promise<Date> { 
        let data = new Date(this.__defaultDateNow);
        try  { 
                data = await this.data("inicial")
        } catch (e) {
            clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.dataInicial Error`, e)
        } finally {
            return data;
        }
    }

    async dataFinal () : Promise<Date> { 
        let data = new Date(this.__defaultDateNow);
        try  { 
                data = await this.data("final")
        } catch (e) {
            clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.dataInicial Error`, e)
        } finally {
            return data;
        }
    }

    async data (type: string) : Promise<Date> { 
        let data = new Date(this.__defaultDateNow);

        try { 
            let sql = ``
            if (type === "inicial") {
                sql = `
                     SELECT  case when coalesce(data_default_ini,0) = 1
                                  then coalesce(data_reprocessamento_default, current_date - 1)
                                  else coalesce(current_date - (-1 * dateadd_ini ), current_date - 1)
                                  end as data
                             , coalesce(data_default_ini,0) as data_manual 
                     FROM TBSISTEMA_NUCLEO_PROCEDIMENTO  
                     WHERE 1 = 1  
                     AND  SIS_NUCLEO_CD_FK = '${this.sis_nucleo_cd_fk}'  
                     AND  SIS_NUCLEO_PRC_CD = ${this.sis_nucleo_prc_cd} 
                     `
                    ;
            } else { 
                sql = `
                     SELECT  case when coalesce(data_default_fim,0) = 1
                                  then coalesce(data_reprocessamento_default_fim, current_date - 1)
                                  else coalesce(current_date - (-1 * dateadd_fim ), current_date - 1)
                                  end as data
                             , coalesce(data_default_fim,0) as data_manual 
                     FROM TBSISTEMA_NUCLEO_PROCEDIMENTO  
                     WHERE 1 = 1  
                     AND  SIS_NUCLEO_CD_FK = '${this.sis_nucleo_cd_fk}'  
                     AND  SIS_NUCLEO_PRC_CD = ${this.sis_nucleo_prc_cd} 
                     `
            }


            let result = await myClsBase.myDataBase.pag.DataGet(sql);
            if (result) {
                
                data = clsTools._datemomentDatStrToDate(result[0].data);
                if (result[0].data_manual === 1) {
                    let sql_update = `` 

                    if (type === "inicial") {
                        sql_update = `update TBSISTEMA_NUCLEO_PROCEDIMENTO 
                            set data_reprocessamento_default = current_date -1
                                , data_default_ini = 0
                                , dtlog_update = current_timestamp
                             WHERE 1 = 1  
                                AND  SIS_NUCLEO_CD_FK = '${this.sis_nucleo_cd_fk}'  
                                AND  SIS_NUCLEO_PRC_CD = ${this.sis_nucleo_prc_cd} 
                    
                    ` }
                    else { 
                        sql_update = `update TBSISTEMA_NUCLEO_PROCEDIMENTO 
                            set data_reprocessamento_default_fim = current_date -1
                                , data_default_fim = 0
                                , dtlog_update = current_timestamp
                             WHERE 1 = 1  
                                AND  SIS_NUCLEO_CD_FK = '${this.sis_nucleo_cd_fk}'  
                                AND  SIS_NUCLEO_PRC_CD = ${this.sis_nucleo_prc_cd} 
                    
                    ` 
                    }


                    await myClsBase.myDataBase.pag.Execute(sql_update);
                }
            }
            else {
                data = this.__defaultDateNow;
            }

        } catch (e) {
            clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.dataInicial Error`, e)
        } finally {
            return data;
        }
    }

    async consultar() { 
        try { 

            let sql = `
                        SELECT      m.sis_nucleo_cd_fk
                                ,   m.sis_nucleo_prc_cd
                                ,   m.sis_nucleo_prc_descricao
                                ,   m.sis_nucleo_prc_descritivo
                                ,   m.sis_nucleo_prc_tipo
                                ,   m.dateadd_ini
                                ,   m.dateadd_fim
                                ,   m.data_reprocessamento_default
                                ,   m.data_reprocessamento_default_fim
                                ,   m.permite_execucao_manual
                                ,   m.notificacao_cd
                        FROM        tbsistema_nucleo_procedimento m
                        WHERE       1 = 1 
                        and         m.sis_nucleo_prc_cd = ${this.sis_nucleo_prc_cd}
                `;

            let result = await myClsBase.myDataBase.pag.DataGet(sql);
            if (result) {
                await this.binding(result[0])
                this.__atualizado = true;
            }

        } catch (e) { 
            clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.consultar Error`, e)
        }
    }

    async notificarExecucao(start: boolean = false) : Promise<void> { 
        let message = ``
        try { 

            if (start) { 
                message = `🚀 Procedimento *${this.sis_nucleo_prc_cd} - ${this.sis_nucleo_prc_descricao} inicializado.*`
            } else {
                if (this.ErrorMessage || this.ErrorMessage === ``) { 
                    message = `Procedimento *${this.sis_nucleo_prc_cd} - ${this.sis_nucleo_prc_descricao} foi executado com sucesso.✅ *`
                }
                else {
                    message = `Procedimento ${this.sis_nucleo_prc_cd} - ${this.sis_nucleo_prc_descricao} foi executado com erro ❌`
                }
            }
            await serviceNotificacao.CriarNotificacaoNucleBatch(message)
        } catch (e) { 
            clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.notificarExecucao Error`, e)
        } finally { 

        }

    }

    async iniciarExecucao() { 
        
        if (this.notificacao_cd && this.notificacao_cd > 0) {
            this.notificarExecucao(true)
        }
        await this.RegistrarLog(true)
    }
    async finalizarExecucao() { 
        if (this.notificacao_cd && this.notificacao_cd > 0) {
            this.notificarExecucao()
        }
        await this.RegistrarLog(true)
    }
    
    private async RegistrarLog(start: boolean, erro: string = `` ) { 
        try { 
            let sql = `insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info)
                values (${this.sis_nucleo_prc_cd}, 'NUCLEO_${this.sis_nucleo_cd_fk}_${this.sis_nucleo_prc_cd}', 'NUCLEO - ${start? 'START' : `END ${erro? ' _ ERROR': ''}` } ' )
            `
            await myClsBase.myDataBase.pag.Execute(sql)
        } catch (e) { 
            clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.RegistrarLog Error`, e)
        }
    }
}
