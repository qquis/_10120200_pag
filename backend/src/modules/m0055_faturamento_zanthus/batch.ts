import { ifilter_faturamento } from './wk'
import myTools from '../../tools/Tools'
import integrateZanthusPag from './services/Integrate/integratezanthuspag'



export default class batch_module_m0055 {
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {
        let filter : ifilter_faturamento =  {
               filter: 
                            {
                                    seqfaturamento: 0,
                                    seqfaturamentoorigem: 0,
                                    datafaturamento_ini: myTools.Date_br_current(),
                                    datafaturamento_fim: myTools.Date_br_current(),
                                    sat_ecf: 0,
                                    cupom_fiscal: 0,
                                    cdparticipantecliente: 0,
                                    cdparticipantevendedor: 0
                            }, 
            post_integracao: 
                {
                    integracao_tipo: "ZANTHUS",
                    integracao_registro: "PENDENTE",
                    sis_batch_run_seq: sis_batch_run_seq
                },
            get_zanthus: {
                           zanthus_base: "Zanthus", 
                           zanthus_tipo: "ctrlcupom" 
                    }

        }

        await integrateZanthusPag.Start(filter)
        return true 

    } catch (e) {
        return false;
    }


    }
}
