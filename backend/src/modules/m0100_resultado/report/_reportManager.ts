
import {clsTools} from '../../../model/modelbase'
import reportFechamento from './reportFechamento'
import reportCentroOperacionalList from './reportCentroOperacionalList'
import reportContaList from './reportContaList'
import reportRateioList from './reportRateioList'
import reportResponsavelList from './reportResponsavelList'
import reportOperacaoList from './reportOperacao'
import reportResultado from './reportResultado'
import reportCompetenciaResultado from './reportCompetenciaResultado'
import reportResultadoGruopoList from './reportResultadoGrupoList'
import reportFechamentoLanc from './reportFechamentoLanc'

export default class reportManagerResultado { 
    static async fechamento(parametros: any) { 
        try { 
            return await reportFechamento.get(parametros)
        } catch(e) { 
            clsTools.PagErrorException('reportDRE', 'fechamento', e)
        }
    }
    static async CentroOperacionalListGet() { 
        return await reportCentroOperacionalList.get()
    }
    static async ResultadoContaListGet(parametros: any = {}) { 
        return await reportContaList.get(parametros)
    }    
    static async ResultadoRateioListGet(parametros: any = {}) {
        return await reportRateioList.get(parametros)
    }
    static async ResultadoResposavelListGet(parametros: any = {}) {
        return await reportResponsavelList.get(parametros)
    }
    static async ResultadoOperacaoListGet(parametros: any = {}) {
        return await reportOperacaoList.get(parametros)
    }    
    static async ResultadoGet(parametros: any = {}) {
        return await reportResultado.get(parametros);
    }    
    static async CompetenciaGet(parametros: any = {}) {
        return await reportCompetenciaResultado.get(parametros)
    }
    static async ResultadoGrupoListGet(parametros: any = {}) {
        return await reportResultadoGruopoList.get(parametros)
    }
    static async ResultadoFechamentoLancGet(parametros: any = {}) {
        return await reportFechamentoLanc.get(parametros)
    }

}