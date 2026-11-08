
import api from '../api';
const url = '/faturamentozanthus'
import moduleUserConnect from "../m0001_sistema/moduleUserConnect"

type tpFaturamentoZanthusCupom = {


        data: Date
        ecf: number
        numero_cupom: number
        id: number
        numero_cupom_cancelador: number
        nf_numero: number
        nf_serie: string
        nf_chave: string
        status_cancelado: number
        status_cancelado_descricao: string
        valor: number
        cpf_cnpj: string
        hora_ini: Date
        hora_fim: Date
        operador_codigo: number
        operador_nome: string
        voucher: string
        voucher_valor: number
        voucher_numero_itens: number
        numero_itens: number
        tiponota_codigo: number
        tiponota_descricao: string
        valor_efetivo: number
        item_qtde: number
        item_valor: number
        item_desconto: number
        item_valor_liquido: number       
}

type tpFaturamentoZanthusTipoNota = { 
    tiponota: number
    tiponota_descricao: string
}

type tpFaturamentoZanthusStatus_Cancelado = { 
    status_cancelado: number
    status_cancelado_descriao: string
}

class moduleFatutamentoZanthus { 
    user: moduleUserConnect
    TipoNotaLista: tpFaturamentoZanthusTipoNota[]
    TipoCancelamentoLista: tpFaturamentoZanthusStatus_Cancelado[]
    
        constructor(user: moduleUserConnect) {
        this.user = user
        this.TipoNotaLista = [
            { tiponota: 8, tiponota_descricao: 'NFCE' },
            { tiponota: 90, tiponota_descricao: 'Inutilizada' },
            { tiponota: 99, tiponota_descricao: 'Cancelada' }
        ]
        this.TipoCancelamentoLista = [
            { status_cancelado: 0, status_cancelado_descriao: 'Efetivado' },
            { status_cancelado: 1, status_cancelado_descriao: 'Cancelado/Estornado' },
            { status_cancelado: 9, status_cancelado_descriao: 'Estorno de Cupom' }, 
            { status_cancelado: 2, status_cancelado_descriao: 'Nf Cancelada (sis)' }, 
            { status_cancelado: 3, status_cancelado_descriao: 'Nf Inutilizada (sis)' }, 
        ]
        
    }


    static parametrosDefault(parametros: any) : string {

            let url_zanthus : string = ``
            
            
            if (parametros.filtrar_data_cupom && parametros.filtrar_data_cupom == 1) {
                url_zanthus += `&filtrar_data_cupom=1`
                url_zanthus += `&data_cupom_ini=${parametros.data_cupom_ini ? parametros.data_cupom_ini : ''}`
                url_zanthus += `&data_cupom_fim=${parametros.data_cupom_fim ? parametros.data_cupom_fim : ''}`
                
            }


            if (parametros.cpf_cnpj) { 
                url_zanthus += `&cpf_cnpj=${parametros.cpf_cnpj || ''}`
            }

            if (parametros.ecf) {
                url_zanthus += `&ecf=${parametros.ecf}`
            }
            if (parametros.numero_cupom) {
                url_zanthus += `&numero_cupom=${parametros.numero_cupom}`
            }

            if (parametros.tipo_nota) {
                url_zanthus += `&tipo_nota=${parametros.tipo_nota}`
            }

            if (parametros.status_cancelado !== undefined && parametros.status_cancelado !== null) {
                url_zanthus += `&status_cancelado=${parametros.status_cancelado}`
            }


            if (parametros.filtrarValorCupom && parametros.filtrarValorCupom == 1) {
                url_zanthus += `&filtrarValorCupom=1`

                if (parametros.valor_inicial !== undefined && parametros.valor_inicial !== null) {
                    url_zanthus += `&valor_inicial=${parametros.valor_inicial}`
                }

                if (parametros.valor_final !== undefined && parametros.valor_final !== null) {
                    url_zanthus += `&valor_final=${parametros.valor_final}`
                }
            }

            if (parametros.filtrarValorPgto && parametros.filtrarValorPgto == 1) {
                url_zanthus += `&filtrarValorPgto=1`
                if (parametros.valor_pgto_inicial !== undefined && parametros.valor_pgto_inicial !== null) {
                    url_zanthus += `&valor_pgto_inicial=${parametros.valor_pgto_inicial}`
                }

                if (parametros.valor_pgto_final !== undefined && parametros.valor_pgto_final !== null) {
                    url_zanthus += `&valor_pgto_final=${parametros.valor_pgto_final}`
                }
            }


            if (parametros.com_desconto) {
                url_zanthus += `&com_desconto=${parametros.com_desconto}`
            
            }
            if (parametros.com_voucher) {
                url_zanthus += `&com_voucher=${parametros.com_voucher}`
            }

            if (parametros.comDescontoSemVoucher) {
                url_zanthus += `&comDescontoSemVoucher=${parametros.comDescontoSemVoucher}`
            }

            if (parametros.finalizadora_cd) {
                url_zanthus += `&finalizadora_cd=${parametros.finalizadora_cd}`
            }

            return url_zanthus
    }

    async getCupom(parametros: any) : Promise<tpFaturamentoZanthusCupom[]> {
        try {

         

            let url_zanthus : string = `${url}/report/cupom?filter=1`
            
            url_zanthus += moduleFatutamentoZanthus.parametrosDefault(parametros)
            const response = await api.pagApiget<tpFaturamentoZanthusCupom[]>(this.user.usuario_login_uuid, url_zanthus)
            return response

        } catch (e) {
            throw e
        }
    }   

    async getCupomItem(parametros: any) : Promise<any[]> {
        try {


            let url_zanthus : string = `${url}/report/cupom-item?filter=1`
            
            url_zanthus += moduleFatutamentoZanthus.parametrosDefault(parametros)

            const response = await api.pagApiget<any[]>(this.user.usuario_login_uuid, url_zanthus)
            return response

        } catch (e) {
            throw e
        }
    }   


    async getPagamento(parametros: any) : Promise<any[]> {
        try {


            let url_zanthus : string = `${url}/report/pagamento?filter=1`
            
            url_zanthus += moduleFatutamentoZanthus.parametrosDefault(parametros)

            const response = await api.pagApiget<any[]>(this.user.usuario_login_uuid, url_zanthus)
            return response

        } catch (e) {
            throw e
        }
    }
}

export { moduleFatutamentoZanthus 
    , type tpFaturamentoZanthusCupom
    , type tpFaturamentoZanthusTipoNota 
    , type tpFaturamentoZanthusStatus_Cancelado
}