import pagApi from '@/api/api'

const urlFinanceiro = '/financeiro'
import { re_compentencia } from '@/api/m0002_enterprise/moduleEnterprise'
import moduleUserConnect from "../m0001_sistema/moduleUserConnect"

type tpAutorizacaoPagamentoPag = { 
        aut_pgto_pag_uuid: string 
        aut_pgto_pag_data: Date
        aut_pgto_pag_data_pgto: Date
        aut_pgto_pag_seq: number
        aut_pgto_pag_valor: number
        cdparticipante: number
        competencia_cd: number
        competencia_descricao: string
        dtlog_insert: Date
        em_cdempresa: number
        sis_us_seq: number
        user_name: string 
        r_conta_cd: number
        r_conta_descricao: string 
        aut_pgto_pag_cancelado: number 
        aut_pgto_pag_cancelado_data: Date 
        aut_pgto_pag_cancelado_sis_us_seq : number
        user_name_cancelador: string
        aut_pgto_pag_obs: string 
        debitocredito: number
        aut_pgto_pag_tipo_cd: number
}


type tpAutorizacaoPagamento = { 
        autpgto_seq_pk : number 
        autpgto_cdpessoabluesoft? : number
        cdparticipante?: number
        nome_razao?: string
        autpgto_dataemissao?: Date
        autpgto_datavencimento?: Date
        autpgto_dataquitacao?: Date
        autpgto_datapagamento?: Date
        autpgto_nf_numero?: number
        autpgto_numeroparcela?: number
        autpgto_status_cd?: number
        autpgto_status_bluesoft_cd?: number
        autpgto_status_descricao?: string
        plc_conta_cd?: number
        plc_conta_cd_destino?: number
        em_cdempresa?: number
        r_conta_cd?: number
        r_conta_descricao?: string
        competencia_cd?: number
        competencia_descricao?: string
        bluesoft_competencia_cd?: number
        competencia_bluesoft_descricao?: string

        competencia_vencimento_descricao?: string


        autpgto_cancelada?: number
        autpgto_tipo?: string 
        autpgto_valorfatura?: number
        autpgto_valortotal?: number
        autpgto_valorpago?: number 
        autpgto_valordescontofinanceiro?: number
        autpgto_valor_multa?: number
        autpgto_valor_abatimento?: number
        autpgto_valor_juros?: number
        autpgto_valor_juros_fixo?: number
        autpgto_valorliquido?: number


}

type tpAutorizacaoPagamentoTipo = { 
    autpgto_tipo: string 
    autpgto_tipo_descricao: string 
}


type tpfluxoCaixa = { 
    autpgto_seq_pk : number
    descricao: string
    autpgto_datavencimento: Date
    autpgto_dataquitacao: Date
    autpgto_datapagamento: Date
    qtde: number
    data_previsao: Date
    valor_cartao: number
    valor_receber: number
    valor_pagar: number
    valor_adm_previsao: number
    valor_executivo_previsao: number
    saldo: number
    saldo_executivo: number
    registro_adm: number

}

class moduleFinanceiroPag
{
    user : moduleUserConnect
    constructor(user: moduleUserConnect) {
        this.user = user;
    }

    async consultar(aut_pgto_pag_seq: number , aut_pgto_pag_uuid : string = `` ) : Promise<tpAutorizacaoPagamentoPag> { 
        let item : tpAutorizacaoPagamentoPag = await this.new()
        try { 

            if (aut_pgto_pag_seq > 0)
                item = await pagApi.get<tpAutorizacaoPagamentoPag>(`${urlFinanceiro}/model/autorizacaopagamentopag?aut_pgto_pag_seq=${aut_pgto_pag_seq}`)
            else 
                item = await pagApi.get<tpAutorizacaoPagamentoPag>(`${urlFinanceiro}/model/autorizacaopagamentopag?aut_pgto_pag_uuid=${aut_pgto_pag_uuid}`)
            
        } catch (e) { 
            throw new Error (`moduleFinanceiroPag | consultar | ${e}`)
        } finally { 
            return item;
        }
    }

    async new () : Promise<tpAutorizacaoPagamentoPag> {
        try {
            let itemNew : tpAutorizacaoPagamentoPag = await pagApi.get<tpAutorizacaoPagamentoPag>(`${urlFinanceiro}/model/autorizacaopagamentopag`)
            itemNew.r_conta_cd = 8601 // conta de fechamento padrão
            return itemNew
        } catch (e) { 
            throw new Error(`moduleFinanceiroPag | \n error ${e}`)
        }
    }

    async atualizar(item : tpAutorizacaoPagamentoPag) : Promise<tpAutorizacaoPagamentoPag> {
        try {
            item.sis_us_seq = this.user.sis_us_seq
            await pagApi.post(`${urlFinanceiro}/model/autorizacaopagamentopag`, item )
            //return await this.consultar(0, item.aut_pgto_pag_uuid) 
            return item 
        } catch (e) { 
            throw new Error(`moduleFinanceiroPag | \n error ${e}`)
        }

    }


    async Cancelar(item : tpAutorizacaoPagamentoPag) : Promise<tpAutorizacaoPagamentoPag> { 
        try { 
            item.aut_pgto_pag_cancelado = 1;
            item.aut_pgto_pag_cancelado_data = new Date()
            item.aut_pgto_pag_cancelado_sis_us_seq = this.user.sis_us_seq
            await this.atualizar(item)
            return item
        } catch (e) { 
            throw new Error(`moduleFinanceiroPag | \n error ${e}`)
        }
    }
}




class moduleFinanceiroBluesoft {
    user: moduleUserConnect
    constructor(user: moduleUserConnect) {
        this.user = user;
    }
    async consultar(autpgto_seq_pk: number) : Promise<tpAutorizacaoPagamento> { 
        try { 
            let url =  `${urlFinanceiro}/model/autorizacaopagamento?autpgto_seq_pk=${autpgto_seq_pk}`
            let item : tpAutorizacaoPagamento = await pagApi.pagApiget<tpAutorizacaoPagamento>(this.user.user_credential, url)
            return item

        } catch (e) {
            throw new Error(`moduleFinanceiroBluesoft | consultar | ${e}`)
        }
    }

    async atualizar(item: tpAutorizacaoPagamento) : Promise<tpAutorizacaoPagamento> {
        try {
            
            let url = `${urlFinanceiro}/model/autorizacaopagamento?autpgto_seq_pk=${item.autpgto_seq_pk}&competencia_cd=${item.competencia_cd}&r_conta_cd=${item.r_conta_cd}`
            await pagApi.pagApipost(this.user.user_credential, url)
            return item
        } catch (e) {
            console.log(`moduleFinanceiroBluesoft | atualizar | ${e}`)
            throw new Error(`moduleFinanceiroBluesoft | atualizar | ${e}`)
        }
    }

    async CadastroFormaPgtoAtualizar(parametro: any) : Promise<any> {
        try {
            
            await pagApi.post(`${urlFinanceiro}/service/formapgto-atualizar`, {})
            return {}

        } catch (e) {
            
            throw new Error(`moduleFinanceiroPag | CadastroFormaPgto | ${e}`)
            return {}
        }
    }
    async CadastroFormaPgtoList(autpgto_seq_pk: number) : Promise<any[]> { 
        try { 
            let url =  `${urlFinanceiro}/report/formapgto-bluesoft?filter=1`
            let item : any[] = await pagApi.pagApiget<any[]>(this.user.user_credential, url)
            return item

        } catch (e) {
            throw new Error(`moduleFinanceiroBluesoft | consultar | ${e}`)
        }
    }


}
 



class moduleFinanceiro { 
    modulelancamentoPag : moduleFinanceiroPag
    moduleBluesoft: moduleFinanceiroBluesoft
    listOptionAutPgtoTipo: tpAutorizacaoPagamentoTipo[]
    user : moduleUserConnect
    constructor(user: moduleUserConnect) {
        this.user = user
        this.modulelancamentoPag = new moduleFinanceiroPag(this.user)
        this.moduleBluesoft = new moduleFinanceiroBluesoft(this.user)
        this.listOptionAutPgtoTipo = [
            { autpgto_tipo: "", autpgto_tipo_descricao: "Todos os tipos" },
            { autpgto_tipo: "P", autpgto_tipo_descricao: "Pagamento" },
            { autpgto_tipo: "R", autpgto_tipo_descricao: "Recebimento" }
        ]
    }
    async financeiroPagListGet(parametros: any = {}) : Promise<tpAutorizacaoPagamentoPag[]> {
        let list : tpAutorizacaoPagamentoPag[] = []
        try {
            let url =  `${urlFinanceiro}/report/autorizacaopgtopag?r_conta_cd=${(parametros.r_conta_cd)? parametros.r_conta_cd: "0"}
                &filtrar_data_pgto=${(parametros.filtrar_data_pgto)? parametros.filtrar_data_pgto: "0"} 
                &data_pgto_ini=${(parametros.data_pgto_ini)? parametros.data_pgto_ini: ""} 
                &data_pgto_fim=${(parametros.data_pgto_fim)? parametros.data_pgto_fim: ""} 
                &cancelado=${(parametros.cancelado)? parametros.cancelado: ""} 
                &competencia_cd=${(parametros.competencia_cd)? parametros.competencia_cd: "0"}
`
            
            
            list = (await pagApi.pagApiget<tpAutorizacaoPagamentoPag[]>(this.user.user_credential, url))
        } catch(e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return list
        }
    }  

    async financeiroFluxoCaixaGet(parametros: any = {}) : Promise<tpfluxoCaixa[]> {
        let list : tpfluxoCaixa[] = []
        try {
            let url =  `${urlFinanceiro}/report/fluxocaixa?tipovisualizacao=${(parametros.tipovisualizacao)? parametros.tipovisualizacao: "FLUXO"}
&filterdata=${(parametros.filterdata)? parametros.filterdata: "0"} 
&data_ini=${(parametros.data_ini)? parametros.data_ini: ""} 
&data_fim=${(parametros.data_fim)? parametros.data_fim: ""}`
            list = (await pagApi.pagApiget<tpfluxoCaixa[]>(this.user.user_credential, url))
        } catch(e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return list
        }
    }

    async financeiroBlueSoftListGet(parametros: any = {}) : Promise<tpAutorizacaoPagamento[]> {
        let list : tpAutorizacaoPagamento[] = []

        if ((!parametros.competencia_cd || parametros.competencia_cd == 0) && 
            (!parametros.bluesoft_competencia_cd || parametros.bluesoft_competencia_cd == 0)  &&
            (!parametros.filtrar_dataemissao || parametros.filtrar_dataemissao == 0) &&
            (!parametros.filtrar_datavencimento || parametros.filtrar_datavencimento == 0) &&
            (!parametros.filtrar_datapagamento || parametros.filtrar_datapagamento == 0) 
            &&
            (parametros.autpgto_seq_pk == 0)
      
        ) {

            throw new Error(`Parâmetros inválidos. É necessário informar pelo menos uma competência ou  um dos filtros de data.`);

        }

        try {
let url =  `${urlFinanceiro}/report/autorizacaopgto?tipovisualizacao=${(parametros.tipovisualizacao)? parametros.tipovisualizacao: "DP"}
&autpgto_tipo=${(parametros.autpgto_tipo)? parametros.autpgto_tipo: ""}
&autpgto_seq_pk=${(parametros.autpgto_seq_pk)? parametros.autpgto_seq_pk: "0"}
&r_conta_cd=${(parametros.r_conta_cd)? parametros.r_conta_cd: "0"}
&filtrar_dataemissao=${(parametros.filtrar_dataemissao)? parametros.filtrar_dataemissao: "0"}
&autpgto_dataemissao_ini=${(parametros.autpgto_dataemissao_ini)? parametros.autpgto_dataemissao_ini: ""}
&autpgto_dataemissao_fim=${(parametros.autpgto_dataemissao_fim)? parametros.autpgto_dataemissao_fim: ""}
&filtrar_datavencimento=${(parametros.filtrar_datavencimento)? parametros.filtrar_datavencimento: "0"}
&autpgto_datavencimento_ini=${(parametros.autpgto_datavencimento_ini)? parametros.autpgto_datavencimento_ini: ""}
&autpgto_datavencimento_fim=${(parametros.autpgto_datavencimento_fim)? parametros.autpgto_datavencimento_fim: ""}
&filtrar_datapagamento=${(parametros.filtrar_datapagamento)? parametros.filtrar_datapagamento: "0"}
&autpgto_datapagamento_ini=${(parametros.autpgto_datapagamento_ini)? parametros.autpgto_datapagamento_ini: ""}
&autpgto_datapagamento_fim=${(parametros.autpgto_datapagamento_fim)? parametros.autpgto_datapagamento_fim: ""}
&cancelado=${(parametros.cancelado)? parametros.cancelado: ""}
&filterdespesabluesoft=${(parametros.filterdespesabluesoft)? parametros.filterdespesabluesoft: "0"}
&competencia_cd=${(parametros.competencia_cd)? parametros.competencia_cd: "0"}
&bluesoft_competencia_cd=${(parametros.bluesoft_competencia_cd)? parametros.bluesoft_competencia_cd: "0"}
`
            list = (await pagApi.pagApiget<tpAutorizacaoPagamento[]>(this.user.user_credential, url))
        } catch(e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return list
        }
    }      
}

export {        moduleFinanceiro 
        , type  tpAutorizacaoPagamentoPag
        , type  tpAutorizacaoPagamento
        , type  tpAutorizacaoPagamentoTipo
        , type  tpfluxoCaixa

};