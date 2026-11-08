//import {clsBase} from '@modelbase'

import {clsTools} from '../../../model/modelbase'


//reports
import reportRhSetorOpercional from './reportRhSetorOpercional'
import rerporRhTipoContrato from './reportRhTipoContrato'
import reportRhFolhaContratada from './reportRhFolhaContratada'
import reportFolhaPorCompetencia from './reportRhFolhaPorCompetencia'
import reportRhCompetencia from './reportRhCompetencia'
import modelcompetencia from '../../m0002_enterprise/model/modelcompetencia'
//objectos
import tbrh_setor_operacional from '../tbs/tbrh_setor_operacional'
import tbrh_tipo_contrato from '../tbs/tbth_tipo_contrato'




export default class reportrh { 
    static async CompetenciaGet (parametros: any = {}) : Promise <any>{ 
        try { 
            return await reportRhCompetencia.get(parametros)
        
        } catch (e) {
            clsTools.PagErrorException('reportrh', 'competencia', e)
        }
    }
    static async FolhaContrataPorCompetenciaGet (parametros: any) : Promise <any> { 
        try { 
            return await reportFolhaPorCompetencia.get(parametros)
        
        } catch (e) {
            clsTools.PagErrorException('reportrh', 'folha_contratada', e)
        }
    }    
    static async FolhaContratadaGet (parametros: any) : Promise <any> { 
        try { 
            return await reportRhFolhaContratada.get(parametros)
        
        } catch (e) {
            clsTools.PagErrorException('reportrh', 'folha_contratada', e)
        }
    }

    static async SetorOperacional() : Promise <tbrh_setor_operacional[]> { 
        try {
                return await reportRhSetorOpercional.get()
        } catch (e) {
            clsTools.PagErrorException('reportrh', 'SetorOperacional', e)
            throw new Error(`Error in SetorOperacional: ${e}`);
        }

    }

    static async TipoContrato() : Promise <tbrh_tipo_contrato[]> { 
        try {
                return await rerporRhTipoContrato.get()
        } catch (e) {
            clsTools.PagErrorException('reportrh', 'SetorOperacional', e)
            throw new Error(`Error in SetorOperacional: ${e}`);
        }

    }

}