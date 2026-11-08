import serviceNotificacao from "../../../modules/m0210_notificacao/service/_serviceNotificacao";
import { clsTools, clsBase } from '../../../model/modelbase';

import tbfaturamento_bluesoft_processo from '../tbs/tbfaturamento_bluesoft_processo';

const myBase = new clsBase();


export default class modelFaturamentoBluesoft_Processo extends tbfaturamento_bluesoft_processo {
  
   

    constructor() { 
        super();
    }


    async notificar() { 
        try { 

            let scriptAtualizaStatusNotificacao = `update tbfaturamento_bluesoft_processo set notificado = 1 where fat_blue_processo_seq = ${this.fat_blue_processo_seq} `

            await myBase.myDataBase.pag.Execute(scriptAtualizaStatusNotificacao)

        } catch (e) {   
            clsTools.PagErrorException(`M0050`, `modelFaturamentoBluesoft_Processo.notificar Error`, e)
        }

    }
   
    async notificar_bluesoftfaturamento_fv(item: any) : Promise<void> { 
        try { 

            this.binding(item)

            if (this.fat_blue_processo_seq && this.fat_blue_processo_seq > 0) {

                let message: string =  ``
                        
   
                message += `*Prime OXAN* 🧑‍💼 \n`
                message += `\n`
                message += `Ola ${item.vendedor_nome_razao} \n`
                message += `*Notificação do processo: ${item.fat_blue_processo_tipo_descricao}* \n`
                message += `\n`
                message += `O pedido abaixo indicado foi faturado com corte \n`
                message += `Pedido: *${this.numeropedido}* \n`
                message += `Cliente: ${item.cliente_nome_razao} \n`
                message += `Valor Pedido: R$ ${item.valor_pedido} \n`
                message += `Valor Faturado: R$ ${item.valor_faturamento} \n`
                message += `Qtde Total de Itens: ${item.qtde_itens} \n`
                message += `Qtde itens com corte: ${item.qtde_itens_corte} \n`
   
            
                /*Gera a mensagem WHATS APP (DEFAULT _ CELULAR DO JOCELIO)*/

                let numeroDD = item.celular_dd ? item.celular_dd : "11"
                let numeroCelular = item.celular_numero ? item.celular_numero : "947420272"
                if (numeroDD.length <= 1) { 
                    numeroDD = `11`
                    numeroCelular = `947420272`
                }
                
                
                await serviceNotificacao.Criar({
                            notificacao_cd : 1000000009,
                            notificacao_send_tipo_cd: 100, 
                            notificacao_email : "",
                            notificacao_email_subject : "",
                            notificacao_email_title : "",
                            notificacao_celular_dd_numero: parseInt(`${numeroDD}${numeroCelular}`),
                            notificacao_send_message : message                        
                    })
                
                
                /*Atualiza o status da Notificação para enviado */
                await this.notificar();

            }
            else { 
                throw new Error(`Processo sem sequencia de processo válida para notificação.`)
            }


        } catch (e) {
            clsTools.PagErrorException(`M0050`, `modelFaturamentoBluesoft.notificar Error`, e)
        }
    } 
}