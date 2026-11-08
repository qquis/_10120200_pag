import { clsTools, clsBase } from '../../../model/modelbase';
import f0070_25_faturamentocontrato_processar from '../scriptdb/pg.f0070_25_faturamentocontrato_processar';
import f0070_30_faturamentocontrato_apuracao from '../scriptdb/pg.f0070_25_faturamentocontrato_apuracao';

/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 100700015
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "M0070-FATURAMENTO | Faturamento Contrato Processamento"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    



type pFaturamentoContratoProcessar = { 
    faturamento_controle_seq: number
    contrato_seq: number
    competencia_cd: number
    data_val_ini: Date
    data_val_fim: Date
    reprocessaritem: boolean
}

export default class serviceFaturamentoContratoProcessarApurar { 

    static async start(parametro: pFaturamentoContratoProcessar | any): Promise<void>  {
        try {

            /*Se for passado o número do contrato ou Faturamento Controle, será processado e apurado o contrato específico */

            

            if (parametro.contrato_seq && Number(parametro.contrato_seq) > 0) { 

                await this.processarContrato(parametro);
                await this.apurarContratoOUCompetencia(parametro);
            } else { 
                const contratos = await this.apurarListaContratosDaCompetencia(parametro);
                /*Processando os contratos do tipo 1 e 3 da competência */

                for (const contrato of contratos) {
                    await this.processarContrato({
                        competencia_cd: parametro.competencia_cd,
                        contrato_seq: Number(contrato.contrato_seq),
                        data_val_ini: contrato.contrato_data_val_ini,
                        data_val_fim: contrato.contrato_data_val_fim,
                    });
                }

                /*fazendo a apuração geral dos contratos */

                await this.apurarContratoOUCompetencia(parametro);
                
            } 
        } catch (e) {
            throw new Error(`serviceFaturamento | processarFaturamento \n Error ${e}`);
        }
    }

    static async apurarListaContratosDaCompetencia(parametro: any) { 
        try {
            let sql = `
                          SELECT  contrato_seq 
                            ,   contrato_data_val_ini
                            ,   contrato_data_val_fim
                        FROM    tbfaturamentocontrato 
                        where   1 = 1 
                        AND     COMPETENCIA_CD = ${parametro.competencia_cd}
                        and     contrato_tipo_cd in (1,3)

                `
            return await this._dbGet(sql)
        } catch (e) {
            await this._log(`Error ${e}`)
            throw e;
        }
    }
        
    
    static async processarContrato(parametro: any) { 
        try { 

                let sql = f0070_25_faturamentocontrato_processar.get(parametro)
                await this._dbExecute(sql)

        } catch (e) {
            await this._log(`Error ${e}`)
            throw e;
        }
    }

    static async apurarContratoOUCompetencia(parametro: any) {
        try { 

                let sql = f0070_30_faturamentocontrato_apuracao.get(parametro)
                await this._dbExecute(sql)

        } catch (e) {
            await this._log(`Error ${e}`)
            throw e;
        }
    }
    
    
    
    static async _log(message: string): Promise<void> {
        await clsTools.pagConsole(`${FLG_MODULO} | ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
    }

    static async _dbGet(sql: string) : Promise<any> {
        try { 
            let myBase = new clsBase();
            return await myBase.myDataBase.pag.DataGet(sql)
        } catch (e) {
            await this._log(`Error ${e}`)
            throw e;
        }
    }
    static async _dbExecute(sql: string) : Promise<void> {
        try { 
            let myBase = new clsBase();
            await myBase.myDataBase.pag.Execute(sql); 
        } catch (e) {
            await this._log(`Error ${e}`)
            throw e;
        }
    }

}