import pagApi from '@/api/api'

const urlBaseResultado = '/resultado'
import { re_compentencia } from '@/api/m0002_enterprise/moduleEnterprise'

type re_fechamento = { 
	    r_grupo_cd: number
		r_grupo_descricao: string
		r_conta_cd: number
		r_conta_descricao: string 
        debitocredito: number
		distribuicao: number
		loja: number
		ecommerce: number
        total: number
        total_calc: number
        total_grupo: number
        percentual_conta_receito: number
}

type re_centrooperacional = { 
	    op_cdoperacao?: number
		op_descricao?: string
		r_centro_op_cd?: number
		r_centro_op_descricao?: string
		r_resp_cd?: number
		r_resp_descricao?: string
}

type re_resultado = {
    r_cd: number
    r_descricao?: string
}

type re_conta = { 
        r_conta_cd: number
        r_conta_descricao?: string
        r_conta_lancamento_manual?: number
        debitocredito?: number
        r_grupo_cd?: number
        r_rateio_cd?: number
        r_grupo_descricao?: string 
        r_rateio_descricao?: string 
        resultadoContaOrigemList: re_contaOrigem[]
        qtde_reg_vinculado?: number
}

type re_contaOrigem = { 
    contrato_bluesoft_seq?: number
    op_cdoperacao?: number
    plc_conta_cd?: number
    prd_cddepartamento?: number
    prs_cdsecao?: number
    r_centro_op_cd?: number
    r_conta_cd?: number
    r_conta_origem_tipo_cd?: number
    rh_setor_operacional_cd?: number
    r_resp_cd?: number    
    op_descricao?: string  
    r_conta_origem_tipo_descricao?: string 
    r_centro_op_descricao?: string 
    plc_descricao?: string 
    prd_descricao?: string 
    prs_descricao?: string 
    rh_setor_operacional_descricao?: string 
    r_resp_descricao: string 
    cdparticipante?: number
    nome_razao?: string 
}

type re_responsavel = { 
    r_resp_cd : number
    r_resp_descricao? : string 
    r_rateio_cd?: number

}


type re_operacao = { 
    op_cdoperacao : number
    op_descricao? : string 
}


class module_Conta { 
    constructor() {}
    async get (r_conta_cd: number) : Promise<re_conta> { 
        let item : re_conta = {r_conta_cd:0, resultadoContaOrigemList : []}
        try {
            item = await pagApi.get<re_conta>(`${urlBaseResultado}/model/conta?r_conta_cd=${r_conta_cd}`)
        } catch (e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return item
        } 

    }
    async post (item : re_conta) : Promise<re_conta> { 
        try {
            await pagApi.post(`${urlBaseResultado}/model/conta?r_conta_cd=${item.r_conta_cd}`, item)
        } catch (e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return item
        } 

    }
}


class moduleResultado { 
    dre_fechamento: re_fechamento[] = []
    dre_fechamentoValorResultado: number

    centroOperacionalList: re_centrooperacional[] = []
    apiDRE_Conta: module_Conta

    constructor() {
        this.apiDRE_Conta = new module_Conta()
        this.dre_fechamento = []
        this.centroOperacionalList = []
        this.dre_fechamentoValorResultado = 0;
    }

    async bindind() {

    }
    
    async getFechamento(    re_compentencia: re_compentencia
                        ,   re_operacao: re_operacao
                        ,   re_responsval: re_responsavel | null
                        ,   dre_centrooperacional: re_centrooperacional | null 
                        ,   dre_resultado: re_resultado | null 
                    
                    ) : Promise<re_fechamento[]> {
        let list : re_fechamento[] = []


        try {
            let url = `${urlBaseResultado}/report/fechamento?competencia_cd=${re_compentencia.competencia_cd}&op_cdoperacao=${re_operacao.op_cdoperacao}&r_resp_cd=${re_responsval?.r_resp_cd}&r_centro_op_cd=${dre_centrooperacional?.r_centro_op_cd}&r_cd=${dre_resultado?.r_cd}`
            list = await pagApi.get<re_fechamento[]>(url)

            this.dre_fechamentoValorResultado = list.reduce((total, item) => {
                    // Garante que total_calc seja tratado como número
                    const valor = Number(item.total_calc) || 0;
                    return total + valor;
                }, 0);


        } catch (e) {
            throw new Error(`API ERROR: ${e}`);
        }
        finally {
            return list;
        }
    }

    async postProcessarFechamento(parametros: any) : Promise<void> {
        try {
            await pagApi.post(`${urlBaseResultado}/service/processarfechamento?competencia_cd=${parametros.competencia_cd}`, {})
        } catch (e) {
            throw new Error(`API ERROR: ${e}`);
        }
    }
    async getListCentroOperacional() : Promise<re_centrooperacional[]> {
        let mylist : re_centrooperacional[] = []
        
        try {

            mylist = await pagApi.get<re_centrooperacional[]>(`${urlBaseResultado}/report/centrooperacionallistget`)
        } catch (e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return mylist
        } 
    }

    async getListConta(parametros: any) : Promise<re_conta[]> {
        let mylist : re_conta[] = []
        
        try {
            let urlPesquisaConta = `${urlBaseResultado}/report/resultadocontalistget?r_conta_cd=${(parametros.r_conta_cd)? parametros.r_conta_cd : "0"}&r_rateio_cd=${(parametros.r_rateio_cd)? parametros.r_rateio_cd : "0"}&r_grupo_cd=${(parametros.r_grupo_cd)? parametros.r_grupo_cd : "0"}&r_conta_lancamento_manual=${(parametros.r_conta_lancamento_manual)? parametros.r_conta_lancamento_manual : "0"}${(parametros.orderbycolunm)? "&orderbycolunm=" + parametros.orderbycolunm : ""}`
            if (parametros.r_conta_descricao) {
                urlPesquisaConta += `&r_conta_descricao=${parametros.r_conta_descricao}`
            }

            mylist = await pagApi.get<re_conta[]>(urlPesquisaConta)
        } catch (e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return mylist
        } 
    }

    async getListRateios(filtro: any = {}) : Promise<[]> {
        let url =  `${urlBaseResultado}/report/resultadorateiolistget`
        if (filtro.r_rateio_sistema)
            url =  `${urlBaseResultado}/report/resultadorateiolistget?r_rateio_sistema=${filtro.r_rateio_sistema}`
        return await pagApi.get(url)
    }
    async getListResponsavel(filtro: any = {}) : Promise<[]> {
        let url =  `${urlBaseResultado}/report/resultadoResposavellistget`
        return await pagApi.get(url)
    }

    async getListOperacao(filtro: any = {}) : Promise<[]> {
        let url =  `${urlBaseResultado}/report/resultadoOperacaolistget`
        return await pagApi.get(url)
    }

    async getListResultado(filtro: any = {}) : Promise<[]> {
        let url =  `${urlBaseResultado}/report/resultado`
        return await pagApi.get(url)
        
    }    

    async getListCompetencia(filtro: any = {}) : Promise<re_compentencia[]> {
        let list : re_compentencia[] = []
        try {
            let url =  `${urlBaseResultado}/report/competencia?fechamento=1`
            list =  await pagApi.get<re_compentencia[]>(url)
        } catch(e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return list
        }
        
    }  
    async getListResultadoGrupo(filtro: any = {}) : Promise<re_compentencia[]> {
        let list : re_compentencia[] = []
        try {
            let url =  `${urlBaseResultado}/report/resultadogrupo`
            list =  await pagApi.get(url)
        } catch(e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return list
        }
        
    } 

}

export { moduleResultado
    , type re_fechamento
    , type re_centrooperacional
    , type re_conta
    , type re_contaOrigem
    , type re_responsavel
    , type re_operacao
    , type re_resultado

};