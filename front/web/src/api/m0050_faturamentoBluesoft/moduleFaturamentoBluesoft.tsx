import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from '../module.default'



type tpFaturamentoBlueSoftStatus = { 
    statusfaturamento: number
    statusfaturamento_descricao: string
    fat_blue_status_cd: number
    fat_blue_status_descricao: string
}


class moduleFaturamentoBluesoft extends moduleDefault { 
    listFaturamentoBluesoftStatus : tpFaturamentoBlueSoftStatus[]
    listFaturamentoStatusPersonalizado : tpFaturamentoBlueSoftStatus[]

    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/faturamentobluesoft', sis_ac_cd)   

        this.listFaturamentoBluesoftStatus = []
        this.listFaturamentoStatusPersonalizado = []

   
    }
    async getFaturamentoList(parametros: any = {}) : Promise<any[]> {
        
            try {
                let url =  `/report/list?filter=1`
                if (parametros.op_cdoperacao) { 
                    url += `&op_cdoperacao=${encodeURIComponent(parametros.op_cdoperacao)}`
                }

                if (parametros.statusfaturamentoFiltrar || parametros.statusfaturamentoFiltrar == 0) {
                    url += `&statusfaturamentoFiltrar=${encodeURIComponent(parametros.statusfaturamentoFiltrar)}`
                }

                if (parametros.statusfaturamento || parametros.statusfaturamento == 0) {
                    url += `&statusfaturamento=${encodeURIComponent(parametros.statusfaturamento)}`
                }

                if (parametros.fat_blue_status_cd || parametros.fat_blue_status_cd == 0) {
                    url += `&fat_blue_status_cd=${encodeURIComponent(parametros.fat_blue_status_cd)}`
                }



                if(parametros.dataPedidoEmissao_filter == 1) {
                    url += `&dataPedidoEmissao_filter=${encodeURIComponent(parametros.dataPedidoEmissao_filter)}`
                    url += `&dataPedidoEmissao_ini=${encodeURIComponent(parametros.dataPedidoEmissao_ini)}`
                    url += `&dataPedidoEmissao_fim=${encodeURIComponent(parametros.dataPedidoEmissao_fim)}`
                }
                if(parametros.dataFaturamento_filter == 1) {
                    url += `&dataFaturamento_filter=${encodeURIComponent(parametros.dataFaturamento_filter)}`
                    url += `&dataFaturamento_ini=${encodeURIComponent(parametros.dataFaturamento_ini)}`
                    url += `&dataFaturamento_fim=${encodeURIComponent(parametros.dataFaturamento_fim)}`
                }
                if (parametros.cdparticipantevendedor) {
                    url += `&cdparticipantevendedor=${encodeURIComponent(parametros.cdparticipantevendedor)}`
                }
    
                if (parametros.descricaogrupoeconomico) {
                    url += `&descricaogrupoeconomico=${encodeURIComponent(parametros.descricaogrupoeconomico)}`
                }
                

                if (parametros.numeropedido) {
                    url += `&numeropedido=${encodeURIComponent(parametros.numeropedido)}`
                }

                

                let result = await this._getAPI<any[]>(url)

                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async getFaturamentoBluesoftConsultar(parametro: any) : Promise<any> {
        try { 

            let url =  `/model/consultar?`
            if (parametro.op_cdoperacao) { 
                url += `&op_cdoperacao=${encodeURIComponent(parametro.op_cdoperacao)}`
            }

            if (parametro.numeropedido) {
                url += `&numeropedido=${encodeURIComponent(parametro.numeropedido)}`
            }

            if (parametro.numeropedido_fv) {
                url += `&numeropedido_fv=${encodeURIComponent(parametro.numeropedido_fv)}`
            }

            let result = await this._getAPI<any>(url)
            
            return result


        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }

    }

    async BindingFaturamentoStatus() : Promise<void> {
            try {
                let url =  `/report/statusList?filter=1`
                this.listFaturamentoBluesoftStatus = await this._getAPI<tpFaturamentoBlueSoftStatus[]>(url)

                // Agrupa por statusfaturamento e statusfaturamento_descricao



                const map = new Map<string, tpFaturamentoBlueSoftStatus>()
                for (const item of this.listFaturamentoBluesoftStatus) {
                    const key = `${item.statusfaturamento}_${item.statusfaturamento_descricao}`
                    if (!map.has(key)) {
                        map.set(key, item)
                    }
                }
                this.listFaturamentoStatusPersonalizado = Array.from(map.values())
                
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }

    }
    async getFaturamentoBlueSoftFilter(faturamentoStatus: number) : Promise<tpFaturamentoBlueSoftStatus[]> { 

        let list : tpFaturamentoBlueSoftStatus[] = [] 
            list = this.listFaturamentoBluesoftStatus.filter(item => item.statusfaturamento == faturamentoStatus)
            
            let itemAll : tpFaturamentoBlueSoftStatus
            itemAll = {
                statusfaturamento: faturamentoStatus,
                statusfaturamento_descricao: 'Todos',
                fat_blue_status_cd: 0,
                fat_blue_status_descricao: 'Todos'
            }
            list.unshift(itemAll)


        return list
    }
    async getFaturamentoBluesoftProcessoConsultar(parametro: any) : Promise<any> {
        try {

            let url =  `/report/processos?filtro=1`

            if (parametro.op_cdoperacao) { 
                url += `&op_cdoperacao=${encodeURIComponent(parametro.op_cdoperacao)}`
            }

            if (parametro.dataInicial) { 
                url += `&dataInicial=${encodeURIComponent(parametro.dataInicial)}`
            }

            if (parametro.dataFinal) { 
                url += `&dataFinal=${encodeURIComponent(parametro.dataFinal)}`
            }

            if (parametro.numeropedido) {
                url += `&numeropedido=${encodeURIComponent(parametro.numeropedido)}`
            }

            if (parametro.numeropedido_fv) {
                url += `&numeropedido_fv=${encodeURIComponent(parametro.numeropedido_fv)}`
            }

            let result = await this._getAPI<any>(url)
            
            return result   
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }

    async postAtualizarBaseFromRedShift(parametro: any) : Promise<void> {
        try { 

            let url =  `/service/redshift-processar?filtro=1`
            if (parametro.dataInicial) { 
                url += `&dataInicial=${encodeURIComponent(parametro.dataInicial)}`
            }

            if (parametro.dataFinal) {
                url += `&dataFinal=${encodeURIComponent(parametro.dataFinal)}`
            }

            if (parametro.executeoverwrite && parametro.executeoverwrite == "1") {
                url += `&executeoverwrite=1`
            }

            await this._postAPI(url, {})

        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }

    }

    async postAtualizarBaseFromApi(parametro: any) : Promise<void> {
        try { 

            let url =  `/service/apibluesoft-processar?filtro=1`
            if (parametro.dataInicial) { 
                url += `&dataInicial=${encodeURIComponent(parametro.dataInicial)}`
            }

            if (parametro.dataFinal) {
                url += `&dataFinal=${encodeURIComponent(parametro.dataFinal)}`
            }
            if (parametro.tipo_periodo) { 
                url += `&tipo_periodo=${encodeURIComponent(parametro.tipo_periodo)}`
            }

            await this._postAPI(url, {})

        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }



    async postAtualizarPendente(parametro: any = {}) : Promise<void> {
        try { 

            let url =  `/service/processar-pendente?filtro=1`


            await this._postAPI(url, {})

        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }

    async getLogFaturamentoBluesoft(parametro: any) : Promise<any> {
        try {

            let url =  `/report/log?filtro=1`

            if (parametro.dtlog_insert_inicial) { 
                url += `&dtlog_insert_inicial=${encodeURIComponent(parametro.dtlog_insert_inicial)}`
            }

            if (parametro.dtlog_insert_final) { 
                url += `&dtlog_insert_final=${encodeURIComponent(parametro.dtlog_insert_final)}`
            }

            let result = await this._getAPI<any>(url)
            
            return result   
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }

    async getFaturamentoBluesoftFVPedidoComCorte(parametros: any = {}) : Promise<any[]> {
        
       try {
                let url =  `/report/forca-venda/pedido-com-corte?filter=1`
                if (parametros.op_cdoperacao) { 
                    url += `&op_cdoperacao=${encodeURIComponent(parametros.op_cdoperacao)}`
                }

                if (parametros.statusfaturamentoFiltrar || parametros.statusfaturamentoFiltrar == 0) {
                    url += `&statusfaturamentoFiltrar=${encodeURIComponent(parametros.statusfaturamentoFiltrar)}`
                }

                if (parametros.statusfaturamento || parametros.statusfaturamento == 0) {
                    url += `&statusfaturamento=${encodeURIComponent(parametros.statusfaturamento)}`
                }

                if (parametros.fat_blue_status_cd || parametros.fat_blue_status_cd == 0) {
                    url += `&fat_blue_status_cd=${encodeURIComponent(parametros.fat_blue_status_cd)}`
                }



                if(parametros.dataPedidoEmissao_filter == 1) {
                    url += `&dataPedidoEmissao_filter=${encodeURIComponent(parametros.dataPedidoEmissao_filter)}`
                    url += `&dataPedidoEmissao_ini=${encodeURIComponent(parametros.dataPedidoEmissao_ini)}`
                    url += `&dataPedidoEmissao_fim=${encodeURIComponent(parametros.dataPedidoEmissao_fim)}`
                }
                if(parametros.dataFaturamento_filter == 1) {
                    url += `&dataFaturamento_filter=${encodeURIComponent(parametros.dataFaturamento_filter)}`
                    url += `&dataFaturamento_ini=${encodeURIComponent(parametros.dataFaturamento_ini)}`
                    url += `&dataFaturamento_fim=${encodeURIComponent(parametros.dataFaturamento_fim)}`
                }
                if (parametros.cdparticipantevendedor) {
                    url += `&cdparticipantevendedor=${encodeURIComponent(parametros.cdparticipantevendedor)}`
                }
    
                if (parametros.descricaogrupoeconomico) {
                    url += `&descricaogrupoeconomico=${encodeURIComponent(parametros.descricaogrupoeconomico)}`
                }
                

                if (parametros.numeropedido) {
                    url += `&numeropedido=${encodeURIComponent(parametros.numeropedido)}`
                }

                if (parametros.mail && parametros.mail == "1") {
                    url += `&mail=1`
                    if (parametros.mail_to) {
                        url += `&mail_to=${encodeURIComponent(parametros.mail_to)}`
                    }
                }
                
                if (parametros.view) {
                    url += `&view=${encodeURIComponent(parametros.view)}`
                }

                let result = await this._getAPI<any[]>(url)


                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }
}




export { moduleFaturamentoBluesoft, type tpFaturamentoBlueSoftStatus }


