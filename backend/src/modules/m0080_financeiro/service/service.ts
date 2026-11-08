import { clsBase, clsTools } from "../../../model/modelbase";
import serviceAutorizacaoPgto from "./serviceAutorizacaoPgto";
import serviceMovimentoCaixaBluesoftImportar from "./serviceMovimentoCaixaBluesoft";
import modelsistema_nucleo_procedimento from "../../../modules/m9030_sistema_batch/model/modelsistema_nucleo_procedimento";
import serviceFinanceiroFormaPgto from "./service.Financeiro.FormaPgto";

export default class serviceFinanceiro { 
    static FinanceiroFormaPgto = serviceFinanceiroFormaPgto
    static async AutorizacaoPgtoAtualizar() : Promise<object> {
        return await serviceAutorizacaoPgto.Atualizar(0);
    }
    static async AutorizacaoPgtoAtualizarDuplicata(param: any) : Promise<object> {
        return await serviceAutorizacaoPgto.AtualizarDuplicata(param);
    }

    static async MovimentoCaixaBluesoftAtualizar() : Promise<object> {
        let nucleo_procedimento: modelsistema_nucleo_procedimento = new modelsistema_nucleo_procedimento();
        nucleo_procedimento.sis_nucleo_prc_cd = 8002;
        return await serviceMovimentoCaixaBluesoftImportar.start(nucleo_procedimento);
    }

}