import { clsTools } from "../../../model/modelbase";

import {modelTb} from '../../../model/model'
import myTools from "src/tools/Tools";

export default class tbfaturamentovip extends modelTb {
    cdpessoabluesoft_cliente: number

	        id : number
			centro_distribuicao_id : number
			filial_id : number 
			compra_status_id : number
			tipo_entrega_id : number
			cliente_id : number
			endereco_id : number
			usuario_id : number
			api_usuario_id : number
			external_compra_id : string
			cnpj_gerador_pedido : string
			foreign_key : string
			parent_id : number
			data_entrega : Date
			data_entregue : Date
			data_faturamento : Date
			faturamento : boolean
			tipo_fiscal : string
			numero_fiscal : string
			prevenda : boolean
			numero_prevenda : string
			frete : number
			taxa_de_servico : number
			valor_inicial : number
			valor_desconto : number
			observacoes_do_cliente : string
			observacoes_do_atendimento : string
			observacoes_na_entrega : string
			intervalo : number
			qtd_itens : number
			qtd_produtos : number
			valor_produtos : number
			retirada_loja : boolean
			notificacao_retirada : number
			antifraude_session_id : string
			score_priorizacao : number
			informacoes_cashback : string
			desconto_aplicado : boolean
			fonte_compra : string
			marketplace : number
			loja_autonoma : boolean
			livre_do_represamento : boolean
			valida : boolean
			created : Date
			modified : Date
			uuid : string
			codigo : string
			status : string
			valor_final : number
			tipo_pedido : string
			volumes_frios : number
			volumes_comuns : number


    constructor() {
        super()
        this.cdpessoabluesoft_cliente= 0

        this.id = 0
            this.centro_distribuicao_id = 0
            this.filial_id = 0
            this.compra_status_id = 0
            this.tipo_entrega_id = 0
            this.cliente_id = 0
            this.endereco_id = 0
            this.usuario_id = 0
            this.api_usuario_id = 0
            this.external_compra_id = ''
            this.cnpj_gerador_pedido = ''
            this.foreign_key = ''
            this.parent_id = 0
            this.data_entrega = new Date()
            this.data_entregue = new Date()
            this.data_faturamento = new Date()
            this.faturamento = false
            this.tipo_fiscal = ''
            this.numero_fiscal = ''
            this.prevenda = false
            this.numero_prevenda = ''
            this.frete = 0
            this.taxa_de_servico = 0
            this.valor_inicial = 0
            this.valor_desconto = 0
            this.observacoes_do_cliente = ''
            this.observacoes_do_atendimento = ''
            this.observacoes_na_entrega = ''
            this.intervalo = 0
            this.qtd_itens = 0
            this.qtd_produtos = 0
            this.valor_produtos = 0
            this.retirada_loja = false
            this.notificacao_retirada = 0
            this.antifraude_session_id = ''
            this.score_priorizacao = 0
            this.informacoes_cashback = ''      
            this.desconto_aplicado = false
            this.fonte_compra = ''
            this.marketplace = 0
            this.loja_autonoma = false
            this.livre_do_represamento = false
            this.valida = false
            this.created = new Date()
            this.modified = new Date()
            this.uuid = ''
            this.codigo = ''
            this.status = ''
            this.valor_final = 0
            this.tipo_pedido = ''
            this.volumes_frios = 0
            this.volumes_comuns = 0


    }
    async binding(item: any): Promise<void> {
            if (item) {
            this.cdpessoabluesoft_cliente = item?.cdpessoabluesoft_cliente
            this.id = item?.id
            this.centro_distribuicao_id = item?.centro_distribuicao_id? item.centro_distribuicao_id : 0
            this.filial_id = item?.filial_id? item.filial_id : 0
            this.compra_status_id = item?.compra_status_id? item.compra_status_id : 0
            this.tipo_entrega_id = item?.tipo_entrega_id? item.tipo_entrega_id : 0
            this.cliente_id = item?.cliente_id? item.cliente_id : 0
            this.endereco_id = item?.endereco_id? item.endereco_id : 0
            this.usuario_id = item?.usuario_id? item.usuario_id : 0
            this.api_usuario_id = item?.api_usuario_id ? item.api_usuario_id : 0
            this.external_compra_id = item?.external_compra_id ? item.external_compra_id : ''
            this.cnpj_gerador_pedido = item?.cnpj_gerador_pedido    ? item.cnpj_gerador_pedido : ''
            this.foreign_key = item?.foreign_key    ? item.foreign_key : ''
            this.parent_id = item?.parent_id    ? item.parent_id : 0
            this.data_entrega = item?.data_entrega ? clsTools._datemomentDatStrToDate(item.data_entrega, "YYYY-MM-DDTH:mm:ss") : clsTools._datemomentDatStrToDate("1900-01-01 00:00:00", "YYYY-MM-DDTH:mm:ss")
            this.data_entregue = item?.data_entregue ? clsTools._datemomentDatStrToDate(item.data_entregue, "YYYY-MM-DDTH:mm:ss") : clsTools._datemomentDatStrToDate("1900-01-01 00:00:00", "YYYY-MM-DDTH:mm:ss")
            this.data_faturamento = item?.data_faturamento ? clsTools._datemomentDatStrToDate(item.data_faturamento, "YYYY-MM-DDTH:mm:ss") : clsTools._datemomentDatStrToDate("1900-01-01 00:00:00", "YYYY-MM-DDTH:mm:ss")
            this.faturamento = item?.faturamento? item.faturamento : 0
            this.tipo_fiscal = item?.tipo_fiscal    ? item.tipo_fiscal : ''
            this.numero_fiscal = item?.numero_fiscal    ? item.numero_fiscal : ''
            this.prevenda = item?.prevenda  ? item.prevenda : 0
            this.numero_prevenda = item?.numero_prevenda    ? item.numero_prevenda : ''
            this.frete = item?.frete    ? item.frete : 0
            this.taxa_de_servico = item?.taxa_de_servico    ? item.taxa_de_servico : 0
            this.valor_inicial = item?.valor_inicial    ? item.valor_inicial : 0
            this.valor_desconto = item?.valor_desconto  ? item.valor_desconto : 0
            this.observacoes_do_cliente = item?.observacoes_do_cliente  ? item.observacoes_do_cliente : ''
            this.observacoes_do_atendimento = item?.observacoes_do_atendimento  ? item.observacoes_do_atendimento : ''
            this.observacoes_na_entrega = item?.observacoes_na_entrega  ? item.observacoes_na_entrega : ''
            this.intervalo = item?.intervalo    ? item.intervalo : 0
            this.qtd_itens = item?.qtd_itens    ? item.qtd_itens : 0
            this.qtd_produtos = item?.qtd_produtos  ? item.qtd_produtos : 0
            this.valor_produtos = item?.valor_produtos ? item.valor_produtos : 0
            this.retirada_loja = item?.retirada_loja ? item.retirada_loja : 0
            this.notificacao_retirada = item?.notificacao_retirada ? item.notificacao_retirada : 0
            this.antifraude_session_id = item?.antifraude_session_id ? item.antifraude_session_id : ''
            this.score_priorizacao = item?.score_priorizacao ? item.score_priorizacao : 0
            this.informacoes_cashback = item?.informacoes_cashback ? item.informacoes_cashback : ''
            this.desconto_aplicado = item?.desconto_aplicado ? item.desconto_aplicado : 0
            this.fonte_compra = item?.fonte_compra ? item.fonte_compra : ''
            this.marketplace = item?.marketplace ? item.marketplace : 0
            this.loja_autonoma = item?.loja_autonoma ? item.loja_autonoma : 0
            this.livre_do_represamento = item?.livre_do_represamento ? item.livre_do_represamento : 0
            this.valida = item?.valida ? item.valida : 0
            this.created = clsTools._datemomentDatStrToDate(item?.created, "YYYY-MM-DDTH:mm:ss")
            this.modified = clsTools._datemomentDatStrToDate(item?.modified, "YYYY-MM-DDTH:mm:ss")
            this.uuid = item?.uuid ? item.uuid : ''
            this.codigo = item?.codigo ? item.codigo : ''
            this.status = item?.status ? item.status : ''
            this.valor_final = item?.valor_final ? item.valor_final : 0
            this.tipo_pedido = item?.tipo_pedido ? item.tipo_pedido : ''
            this.volumes_frios = item?.volumes_frios    ? item.volumes_frios : 0
            this.volumes_comuns = item?.volumes_comuns   ? item.volumes_comuns : 0
        }       

    }
}
