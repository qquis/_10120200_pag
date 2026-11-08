import { clsTools, clsBase} from '../../../model/modelbase'



import apiVip from '../../Apis/vipApi/api';

import model_participante_vip from '../../m0011_participante/model/modelparticipanteVip';

import modelfaturamentovip from '../model/modelfaturamentovip';
import modelfaturamentovipNotificacao from '../model/modelfaturamentovipnotificacao';





export default class serviceFaturamentoVipImport { 
    static async start(parametros: any): Promise<void> {


        let resultSucess : number = 0;
        try { 
            clsTools.pagConsole(`F0051 - Faturamento VIP - Service serviceFaturamentoVipImport - Inicializado`)
            let param = {
                page: 1,
                start_created: (() => {
                    const now = new Date();
                    now.setDate(now.getDate() - 10);
                    const yyyy = now.getFullYear();
                    const mm = String(now.getMonth() + 1).padStart(2, '0');
                    const dd = String(now.getDate()).padStart(2, '0');
                    return `${yyyy}-${mm}-${dd} 01:01:01`;
                })(),
                end_created: (() => {
                    const now = new Date();
                    const yyyy = now.getFullYear();
                    const mm = String(now.getMonth() + 1).padStart(2, '0');
                    const dd = String(now.getDate()).padStart(2, '0');
                    const hh = String(now.getHours()).padStart(2, '0');
                    const min = String(now.getMinutes()).padStart(2, '0');
                    const ss = String(now.getSeconds()).padStart(2, '0');
                    return `${yyyy}-${mm}-${dd} ${hh}:${min}:${ss}`;
                })()
            }



            
            let numeroPaginas = await apiVip.faturamentoPedido.pagination(param)
            
            clsTools.pagConsole(`F0011 - Participante - Service serviceParticipanteVipImport - Inicializado _ N de Paginas: ${numeroPaginas}`)
            let i = 0;
            let maxInsert = 2
            let sqlinsertBlock = ''
            
            for (let p = 1; p <= numeroPaginas; p++) {

                param.page = p
                let result : object = await apiVip.faturamentoPedido.get(param)

                for await ( const[key, value] of Object.entries(result)) {
                    
                    let item = new modelfaturamentovip()
                    item.binding(value)
                    sqlinsertBlock += item.getCrudSql()
        
                    if (i >= maxInsert) {

                        await this.DataBaseExecute(sqlinsertBlock)
                        sqlinsertBlock = ''
                        i = 0
                    }
                    i++
               }                


            }
            
            if (sqlinsertBlock != '') {
                await this.DataBaseExecute(sqlinsertBlock)
                sqlinsertBlock = ''
            }

            //list.map(item => { console.log(item.participante_vip.vip_nome) } )
            clsTools.pagConsole(`F0051 - Faturamento VIP - Service serviceFaturamentoVipImport | Paginas: ${numeroPaginas} `)


            /* PROCESSAR NOTIFICAÇÕES */
            await serviceFaturamentoVipImport.Notificar()


        } catch (e: any) {
            clsTools.PagErrorException(`F0051 - Faturamento VIP`, `serviceFaturamentoVipImport.start()`, e, true);
            throw new Error(`modules | Faturamento VIP | Error ${e.message}`);
    
        }
    }

    static async Notificar(): Promise<void> {
        try { 


                /* Gerando as notificaçẽos pendentes */

                let sqlNotificacoesPendentes = `
                insert into tbfaturamento_vip_notificacao
                        (
                                id					
                            ,	notificacao_cd		
                            ,	compra_status_id 	
                            ,	notificado

                        )
                        select 			f.id
                                    ,	s.notificacao_cd 
                                    ,	f.compra_status_id
                                    ,	0
                        from 			tbfaturamento_vip f
                        left join 		tbfaturamento_vip_compra_status s on s.compra_status_id = f.compra_status_id
                        where			1 = 1 
                        and             f.created >= date_trunc('day', current_timestamp - interval '1 day') -- primeira hora do dia anterior
                        and				not exists
                                                ( 	select 	1 
                                                    from 	tbfaturamento_vip_notificacao aa
                                                    where	1 = 1
                                                    and     aa.id = f.id
                                                    and     aa.compra_status_id = f.compra_status_id
                                                    and     aa.notificacao_cd = s.notificacao_cd
                                                )
                        and				coalesce(s.notificacao_cd ,0) > 0
                
                
                `

                let myDATABASE = new clsBase();
                await myDATABASE.myDataBase.pag.Execute(sqlNotificacoesPendentes)


            /*Obtendo a lista de notificações pendentes*/
            let sqlNotificacoesPendentesList = `
                                select 	n.id
                                    ,	f.data_entrega
                                    ,	f.qtd_itens
                                    ,	f.qtd_produtos
                                    ,	coalesce(f.valor_final ,0) as valor_final 
                                    ,   n.faturamento_vip_notificacao_seq
                                    ,   n.notificacao_cd
                                    ,   n.compra_status_id
                                    ,   n.notificado
                                    ,   s.compra_status_descricao
                                    ,   f.cliente_id 
                                    ,   p.vip_nome
                            from 	tbfaturamento_vip_notificacao       n
                            inner join tbfaturamento_vip                f on f.id = n.id
                            inner join tbfaturamento_vip_compra_status  s on s.compra_status_id = n.compra_status_id
                            left join  tbparticipante_vip p on p.vip_id = f.cliente_id
                            where  1 = 1
                            and    n.notificado = 0 `
                 let resultListNotificacao = await myDATABASE.myDataBase.pag.DataGet(sqlNotificacoesPendentesList)

                    for await ( const[key, value] of Object.entries(resultListNotificacao)) {
                        let itemNotificacao = new modelfaturamentovipNotificacao()
                        itemNotificacao.modelBinding(value)
                        

                        if (itemNotificacao.vip_nome == null || itemNotificacao.vip_nome == '') {
                            let participanteVip = new model_participante_vip()
                            await participanteVip.getApi(itemNotificacao.cliente_id)
                            itemNotificacao.vip_nome = participanteVip.vip_nome_completo

                        }

                        await itemNotificacao.notificar()
                        
                    }


        } catch (e: any) {
            clsTools.PagErrorException(`F0051 - Faturamento VIP`, `serviceFaturamentoVipImport.Notificar()`, e, true);
            throw new Error(`modules | Faturamento VIP | Error ${e.message}`);
    
        }
    }

    static async DataBaseExecute(sql: string) :Promise<void> { 
        try { 

            let myDATABASE = new clsBase();
            await myDATABASE.myDataBase.pag.Execute(sql)

        } catch (e: any) {
            clsTools.PagErrorException(`F0051 - Faturamento VIP`, `serviceFaturamentoVipImport.DataBaseExecute()`, e, true);
            throw new Error(`modules | Faturamento VIP | Error ${e.message}`);
    
        }
    }

}
