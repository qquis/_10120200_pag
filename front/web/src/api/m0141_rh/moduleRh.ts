import pagApi from "@/api/api"
import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import { re_compentencia } from "../m0002_enterprise/moduleEnterprise"



type tpColumnOrderBy = { 
    columnNumber: number
    columnName: string
}

type tpOrderByDirection = {
    direction: 'asc' | 'desc'
}

type rh_tipo_contrato = { 
    rh_tipo_contrato_cd: number
    rh_tipo_contrato_descricao: string
}

type rh_setor_operacional = { 
    rh_setor_operacional_cd: number
    rh_setor_operacional_descricao: string
}

class moduleRh { 
    user: moduleUserConnect
    TipoContratoList: rh_tipo_contrato[] = []
    SetorOperacionalList: rh_setor_operacional[] = []
    folhaPorCompetencia : object = {}
    orderbycolumns: tpColumnOrderBy[] = []
    constructor(user: moduleUserConnect) {
        this.getTipoContrato()
        this.user = user;
        this.orderbycolumns.push({ columnNumber: 1, columnName: 'Competencia' })
        this.orderbycolumns.push({ columnNumber: 4, columnName: 'Registro' })
        this.orderbycolumns.push({ columnNumber: 6, columnName: 'Nome' })
        this.orderbycolumns.push({ columnNumber: 8, columnName: 'Tipo Contrato' })
        this.orderbycolumns.push({ columnNumber: 10, columnName: 'Setor' })
        this.orderbycolumns.push({ columnNumber: 14, columnName: 'Salário Base' })
        this.orderbycolumns.push({ columnNumber: 15, columnName: 'Pj' })
        this.orderbycolumns.push({ columnNumber: 16, columnName: 'Outros' })
        this.orderbycolumns.push({ columnNumber: 20, columnName: 'Previsão Total' })


        

    }

    async bindin() {
        await this.getTipoContrato()
        await this.getSetorOperacional()
    }

    async getFolhaCompetencia(parametros: any) : Promise<re_compentencia[]> {
        let list : re_compentencia[] = []
        try {
            list = await pagApi.pagApiget<re_compentencia[]>(this.user.user_credential, `/rh/report/competencia`)

        } catch (e) {
            throw new Error(`API ERROR: ${e}`);
            
        } finally {
            return list;
        }
    }



    async getFolhaPorCompetencia(parametros: any) : Promise<void> {
        try {
            let url = `/rh/report/folhaporcompetencia?tipo_relatorio=${parametros.tipo_relatorio}&rh_tipo_contrato_cd=${parametros.rh_tipo_contrato_cd}&rh_setor_operacional_cd=${parametros.rh_setor_operacional_cd}&competencia_cd=${parametros.competencia_cd}&r_conta_cd=${parametros.r_conta_cd}&orderbycolumnnumber=${parametros.orderbycolumnnumber}&orderbydirection=${parametros.orderbydirection}`;
            
            if (parametros.nome_razao) 
                url += `&nome_razao=${encodeURIComponent(parametros.nome_razao)}`
            
            
            this.folhaPorCompetencia = await this.user.get(url);
                
            

        } catch (e) {
            throw new Error(`API ERROR: ${e}`);
        }
    }

    async getTipoContrato() : Promise<rh_tipo_contrato[]> {
        try {
            this.TipoContratoList = await pagApi.get<rh_tipo_contrato[]>('/rh/report/tipo_contrato')
            return this.TipoContratoList;
        } catch (e) {
            throw new Error(`API ERROR: ${e}`);
        }
    }

    async getSetorOperacional() : Promise<rh_setor_operacional[]> {
        try {
            this.SetorOperacionalList = await pagApi.get<rh_setor_operacional[]>('/rh/report/setoroperacional')
            return this.SetorOperacionalList;
        } catch (e) {
            throw new Error(`API ERROR: ${e}`);
        }
    }
}





export { moduleRh, type rh_tipo_contrato, type rh_setor_operacional };