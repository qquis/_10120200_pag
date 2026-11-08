import { clsBase, clsTools } from "../../../model/modelbase";

import reportAutorizacaoPgtoPag from './reportAutorizacaoPgtoPag'
import reportAutorizacaoPgto from './reportAutorizacaoPgto'
import reportFluxoCaixa from './reportFluxoCaixa'
import reportFormaPgtoBlueSoft from './report.Financeiro.FormaPgtoBluesoft'

export default class reportFinanceiro {
    static formaPgtoBlueSoft = reportFormaPgtoBlueSoft
    static async autorizacaoPgtoPagGet(parms : any) { 
        try {
             return await reportAutorizacaoPgtoPag.get(parms)

        } catch (e) { 
            clsTools.PagErrorException("M0080", "autorizacaoPgtoPagGet", e)
        }
    }
    static async autorizacaoPgtoGet(parms : any) { 
        try {
             return await reportAutorizacaoPgto.get(parms)

        } catch (e) { 
            clsTools.PagErrorException("M0080", "autorizacaoPgtoGet", e)
        }
    }    
    static async fluxoCaixaGet(parms : any) { 
        try {
             return await reportFluxoCaixa.get(parms)

        } catch (e) { 
            clsTools.PagErrorException("M0080", "FluxoCaixaGet", e)
        }
    }        
}