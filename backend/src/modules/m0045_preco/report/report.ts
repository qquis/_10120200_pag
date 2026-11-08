import { Request } from 'express'

import reportPrecoAgendamento from "./reportPrecoAgendado";
import reportPrecoAplicacao from "./reportPrecoAplicacao";


export default class reportPreco  {
    __reportPrecoAplicado : reportPrecoAplicacao
    __reportPrecoAgendado : reportPrecoAgendamento
    constructor() {

        this.__reportPrecoAplicado = new reportPrecoAplicacao();
        this.__reportPrecoAgendado = new reportPrecoAgendamento(); 
    }

    async PrecosAplicados(request: any) : Promise<object> {
        return await this.__reportPrecoAplicado.dataPag_get(request);
    }

    async PrecosAplicadosIntegracaoBlueSoftPendente() : Promise<object> {
        this.__reportPrecoAplicado.Filtros.tipo_relatorio = "INTEGRACAO_BLUESOFT_PENDENTE"
        return await this.__reportPrecoAplicado.dataPag_get(null); 
    }

    async PrecosAplicadosIntegracaoBlueSoftGeral() : Promise<object> {
        this.__reportPrecoAplicado.Filtros.tipo_relatorio = "INTEGRACAO_BLUESOFT"
        return await this.__reportPrecoAplicado.dataPag_get(null); 
    }

    async PrecoAgendadoIntegracaoBlueSoftPendente() {
        this.__reportPrecoAgendado.Filtros.tipo_relatorio = "INTEGRACAO_BLUESOFT_PENDENTE"
        return await this.__reportPrecoAgendado.dataPag_get(null); 
    }

}