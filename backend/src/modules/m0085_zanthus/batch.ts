import { clsTools } from '../../model/modelbase';

import serviceAtualizacaoGeralFiscal from './service/serviceAtualizacaoGeralFiscal';
import serviceAtualizacaoGeralCliente from './service/serviceAtualizacaoClientes';

import serviceAtualizacaoDeskTop from './service/serviceAtualizacao.Carga.DeskTop';

export default class batch_module_m0085 { 
    
    static async Procedimento(nucleo_procedimento: any) : Promise<boolean> {
        try {
            await this.AtualizacaoDiaria();
            return true;
        } catch (e) {
            return false;
        }
        finally {
            return true
        }
    }

    static async AtualizacaoDiaria() : Promise<boolean> {
        try {
            
            //await serviceAtualizacaoGeralFiscal.start({});
            await serviceAtualizacaoGeralCliente.start({})
            await serviceAtualizacaoDeskTop.start({})
            

            return true;
        } catch (e) {
            return false;
        }
    }   

}