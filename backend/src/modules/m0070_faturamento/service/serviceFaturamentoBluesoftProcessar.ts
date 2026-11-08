import { clsBase, clsTools } from '../../../model/modelbase';

import model_faturamento_controle from "../model/model_faturamento_controle";


import f0070_20_faturamentocontrole_processar from '../scriptdb/pg.f0070_20_faturamentocontrole_processar';
import f0070_21_faturamento_processar from '../scriptdb/pg.f0070_21_faturamentoprocessar';
import f0070_22_faturamentoorigem_processar from '../scriptdb/pg.f0070_22_faturamentoorigem_processar';


/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 100700010
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "M0070-FATURAMENTO | Faturamento Bluesoft Processamento"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    




export default class serviceFaturamentoBluesoftProcessar { 

    static async start(parametro: any): Promise<void>  {
        try {

            await this._log(`Iniciando processamento para data: ${parametro.data_processamento}`);
            await this.IntegrarHeaderGerarMovimentoPendente(parametro)
            await this.ProcessamentoPendente(parametro)





        } catch (e) {
            await clsTools.PagErrorException("serviceFaturamentoBluesoftProcessar", "start", e)
            throw new Error(`serviceFaturamento | processarFaturamento \n Error ${e}`);

        }
    }
    
    static async IntegrarHeaderGerarMovimentoPendente(parametro: any) {
        try {

                if (!parametro.data_processamento) {
                    throw new Error(`Parâmetro data_processamento é obrigatório`);
                }

                const myDatabase = new clsBase()

                let vdata_processamento: Date = clsTools._datemomentDatStrToDate(parametro.data_processamento, "YYYY-MM-DD")
                
                
                await clsTools.pagConsole(`${FLG_MODULO} | Processando Headers - CONTROLE FATURAMENTO`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDatabase.myDataBase.pag.Execute(f0070_20_faturamentocontrole_processar.get(parametro))

                await clsTools.pagConsole(`${FLG_MODULO} | Processando Headers - TBFATURAMENTO`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDatabase.myDataBase.pag.Execute(f0070_21_faturamento_processar.get(parametro))

                await clsTools.pagConsole(`${FLG_MODULO} | Processando Headers - TBFATURAMENTO ORIGEM`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDatabase.myDataBase.pag.Execute(f0070_22_faturamentoorigem_processar.get(parametro))

            
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "IntegrarHeaderGerarMovimentoPendente", e)

            
        }

    }
    
    
    static async ProcessamentoPendente(parametro: any): Promise<model_faturamento_controle[]> {
        let listAProcessar: model_faturamento_controle[] = []
        
        try {
            const myDatabase = new clsBase()
            let sqlProcessamentoPendente: string = `    
                    SELECT 		CAST(ct.seqfaturamento_uuid AS VARCHAR(40))
                            ,	ct.faturamento_controle_seq
                            ,	ct.op_cdoperacao 
                            ,	ct.dataemissao						
                            ,	ct.datafaturamento					
                            ,	ct.numeropedido 
                            ,   ct.numeropedido_fv					
                            ,	ct.df_nf_seq_blue
                            , 	ct.sat_ecf 						
                            ,	ct.cupomfiscal 					
                            ,	ct.cdpessoabluesoft_cliente
                            ,	ct.cdpessoabluesoft_vendedor
                            ,	CAST(ct.fat_controle_tipo_cd AS INT)
                            ,	ct.seqfaturamento 
                            ,	ct.seqfaturamentoorigem			
                    FROM 	    tbfaturamento_controle ct
                    LEFT JOIN   tbdocumentofiscal nf on nf.df_nf_seq_blue = ct.df_nf_seq_blue 
                    where   processamento_pendente = 1

   
                    
            `;
            //and     numeropedido = 512013
            
            
            
            let result = await myDatabase.myDataBase.pag.DataGet(sqlProcessamentoPendente) as any[]

            let RegistroTotal: number = result.length;
            let Registroitem: number = 0;

            clsTools.pagConsole(`${FLG_MODULO} | Número de registros a processar: ${RegistroTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

            for (let row of result as any[]) {
                let itemFaturamento = model_faturamento_controle.faturamentoControleBindingGet(row)
                


                await clsTools.pagConsole(`${FLG_MODULO} | Processando item de faturamento: ${itemFaturamento.numeropedido} | Item ${Registroitem}/${RegistroTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDatabase.myDataBase.pag.Execute(model_faturamento_controle.sqlProcessarFaturamentoPorControle(itemFaturamento))
                Registroitem++;
            }


            
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "ObterFaturamentoProcessamentoPendente", e)
            throw new Error(`serviceFaturamento | ObterFaturamentoProcessamentoPendente \n Error ${e}`);
        } finally {
            return listAProcessar;
        }
    }

    static async _log(message: string): Promise<void> {
        await clsTools.pagConsole(`${FLG_MODULO} | ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
    }



}