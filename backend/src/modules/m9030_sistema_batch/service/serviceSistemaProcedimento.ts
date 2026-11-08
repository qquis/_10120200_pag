import { clsBase, clsTools } from "../../../model/modelbase";
import modelsistema_ServiceBatch from '../model/modelsistema_ServiceBatch';
import modelsistema_nucleo_procedimento from "../model/modelsistema_nucleo_procedimento";
import serviceNotificacao from '../../../modules/m0210_notificacao/service/_serviceNotificacao';

/* Serviços */
import batch_module_m0080 from '../../m0080_financeiro/batch'
import batch_module_m0095 from '../../m0095_integracao/batch'
import batch_module_m0045 from "../../../modules/m0045_preco/batch";
import batch_module_m0011 from '../../m0011_participante/batch'
import batch_module_m0004 from "../../m0004_forcavenda/batch";
import batch_module_m0150 from "../../m0150_estatistica/batch";
import batch_module_m0085 from '../../m0085_zanthus/batch';






export default class sistemaServiceProcedimento { 
    public static async startlist(modelsistema_batch_select : modelsistema_ServiceBatch) : Promise<void> { 


        await serviceNotificacao.CriarMailBasico( 
            'eliassilva@oxan.com.br', 
            `Batch (Com procedimentos)`,
            `Início da execução do Batch - ${modelsistema_batch_select.sistema_batch.sis_batch_descricao}`,
            `Número de Procedimentos - ${modelsistema_batch_select.listProcedimentos.length}`
        )
        


        try { 

            //console.log(modelsistema_batch_select.listProcedimentos)

            for (const item of modelsistema_batch_select.listProcedimentos) { 
                await this.start(item)
                await clsTools._wait(4000)
                
            }



            let message = modelsistema_batch_select.listProcedimentos.map((item) => { 
                return `Procedimento: ${item.sis_nucleo_prc_cd} - ${item.sis_nucleo_prc_descricao} - Error: ${item.ErrorMessage} \n`

            })

            await serviceNotificacao.CriarMailBasico( 
                'eliassilva@oxan.com.br', 
                `Batch (Com procedimentos)`,
                `Finalização do Batch - ${modelsistema_batch_select.sistema_batch.sis_batch_descricao}`,
                `Número de Procedimentos - ${message}`
            )


        } catch (e) {
            clsTools.PagErrorException(`M9030`, `sistemaServiceProcedimento.start Error`, e)
        } finally { 
            await clsTools._wait(2000)
            return;
        }
    }

    public static async start(nucleo_procedimento: modelsistema_nucleo_procedimento) : Promise<void> { 
        let statusExecucao: boolean = false;
        try { 

            if (!nucleo_procedimento.__atualizado)
                await nucleo_procedimento.consultar();
            
            
            
            await nucleo_procedimento.iniciarExecucao()
            switch(nucleo_procedimento.sis_nucleo_prc_cd) {

                //INTEGRAÇÃO _ IMPORTAÇÃO GERAL DE PRODUTOS
                case 95101: 
                    await this.localConsole(`Procedimento 95101 | Executando IMPORTAÇÃO GERAL DE PRODUTOS`)
                    statusExecucao = await batch_module_m0095.Procedimento(nucleo_procedimento)
                    break;

                //APLICAÇÃO DE PREÇOS 
                case 45060: 
                    await this.localConsole(`Procedimento 45060 | Executando APLICAÇÃO DE PREÇOS`)
                    statusExecucao = await batch_module_m0045.Procedimento(nucleo_procedimento)
                    break;                    

                //INTEGRAÇÃO _ EXPORTAÇÃO DE PRODUTOS PENDENTES PARA A ZANTHUS
                case 85002: 
                    await this.localConsole(`Procedimento 85002 | Executando EXPORTAÇÃO DE PRODUTOS PENDENTES PARA A ZANTHUS`)
                    statusExecucao = await batch_module_m0085.Procedimento(nucleo_procedimento)
                    break;   

                //INTEGRAÇÃO _ EXPORTAÇÃO DE PRODUTOS PENDENTES PARA A BLUESOFT _ API 
                case 95011: 
                    await this.localConsole(`Procedimento 95011 | Executando EXPORTAÇÃO DE PRODUTOS PENDENTES PARA A BLUESOFT _ API`)
                    statusExecucao = await batch_module_m0095.Procedimento(nucleo_procedimento)
                    break;                        

                //FINANCEIRO _ IMPORTAÇÃO DO MOVIMENTO CAIXA/FINANCEIRO DIÁRIO
                case 8002:
                    await this.localConsole(`Procedimento 8002 | Executando IMPORTAÇÃO DO MOVIMENTO CAIXA/FINANCEIRO`)
                    statusExecucao = await batch_module_m0080.Procedimento(nucleo_procedimento)
                    break;

                /*Importação de Participantes*/
                case 1105:
                    await this.localConsole(`Procedimento 1105 | Executando IMPORTAÇÃO DE PARTICIPANTES`)
                    statusExecucao = await batch_module_m0011.Procedimento(nucleo_procedimento)
                    break;

                case 10004001:
                    await this.localConsole(`Procedimento 10004001| Executando IMPORTAÇÃO DE DADOS DO FORÇA DE VENDA`)
                    statusExecucao = await batch_module_m0004.Procedimento(nucleo_procedimento)
                    break;

                case 10150010:
                    await this.localConsole(`Procedimento 10150010 - DADOS ESTATÍSTICOS`)
                    statusExecucao = await batch_module_m0150.startProcedimento(nucleo_procedimento)
                    break;
            
 

               
            }

            if (!statusExecucao) { 
                nucleo_procedimento.ErrorMessage = `Erro na execução do procedimento! Contate a equipe de suporte.`;
            } else { 
                nucleo_procedimento.ErrorMessage = ``;
            }
            
        } catch (e) { 
            clsTools.PagErrorException(`M9030`, `sistemaServiceProcedimento.start Error`, e)
        } finally { 
            await clsTools._wait(2000);
            await nucleo_procedimento.finalizarExecucao();
            await clsTools._wait(4000)
            return;
        }
    }


    public static async startProcedimento(parametro : any) : Promise<void> {
        try { 

                

                let nucleo_procedimento: modelsistema_nucleo_procedimento = new modelsistema_nucleo_procedimento();
                nucleo_procedimento.sis_nucleo_prc_cd = parametro.sis_nucleo_prc_cd;
                await nucleo_procedimento.consultar();
                await this.start(nucleo_procedimento);
           

        } catch (e) {
            clsTools.PagErrorException(`M9030`, `sistemaServiceProcedimento.startProcedimento Error`, e)
        }


    
    }


    static async localConsole(message: string) { 
        clsTools.pagConsole(`M9030 Sistema Batch (Execução de Procedimento via M9030) _ Procedimento:  ${message}`, false, false)
    }

}