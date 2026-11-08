import pagApi from '@/api/api'
import moduleUserConnect from '../m0001_sistema/moduleUserConnect';
import moduleDefault from '../module.default'

const urlBaseModulo = '/enterprise'
type re_compentencia = {
    competencia_cd: number
    competencia_descricao: string
}


class moduleEnterprise  extends moduleDefault { 
    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/enterprise', sis_ac_cd)    

    }
    async CompetenciaList(): Promise<re_compentencia[]> {
        try {
            const response = await pagApi.get<re_compentencia[]>(`${urlBaseModulo}/report/competencialistget?orderbycolunm=competencia_cd&orderby=desc`);
            return response;
        } catch (e) {
            throw new Error(`moduleEnterprise | re_compentencia | ${e}`);
        }
    }
    async getEmpresaOperacaoList(): Promise<any[]> {
        try {



            const response = await this._getAPI<any[]>(`/report/empresaoperacaolistget?relatorio=0`);
            return response;
        } catch (e) {
            throw new Error(`moduleEnterprise | getEmpresaOperacaoList | ${e}`);
        }
    }
}


export { moduleEnterprise, type re_compentencia }