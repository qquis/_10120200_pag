import { Request, Response } from 'express';
import myTools from '../../tools/Tools'
/*Data Base */

//Services
import Zanthus from './services/Zanthus/Zanthus'
import integrateZanthusPag from './services/Integrate/integratezanthuspag'
import faturamentoforcavenda from './services/FaturamentoForcaVenda/wk.faturamentoforcavenda';
import integrateZanthusCtrl from './services/Integrate/integratezanthusctrl';
import { Console } from 'console';


/*Interfaces */ 
interface ifilter_faturamento{


    filter?: {
        seqfaturamento?: number
        seqfaturamentoorigem?: number
        datafaturamento_ini?: Date,
        datafaturamento_fim?: Date, 
        sat_ecf?: number
        cupom_fiscal?: number 
        cdparticipantecliente?: number 
        cdparticipantevendedor?: number

    } 

post_integracao?: 
	{
		integracao_tipo?: string ,
		integracao_registro?: string,
        sis_batch_run_seq: number
	}
get_zanthus?: {
				zanthus_base?: string, 
				zanthus_tipo?: string 
		}

}

class wk {

    

    private FilterRequest_get(request?: Request): ifilter_faturamento {
        try {

            /* Filter padrão para processamento dos cupons pendentes de qualquer ecf */

            let seqfaturamento: number =  0  
            let seqfaturamentoorigem: number = 0 
            let datafaturamento_ini: Date = myTools.Date_br_current()
            let datafaturamento_fim: Date  = myTools.Date_br_current()
            let sat_ecf: number = 0 
            let cupom_fiscal: number = 0 
            let cdparticipantecliente: number = 0 
            let cdparticipantevendedor: number = 0
                
            let integracao_tipo: string = "ZANTHUS"
            let integracao_registro: string = "PENDENTE" 
            let sis_batch_run_seq: number = 0

            let zanthus_base: string = "Zanthus" 
            let zanthus_tipo: string = "ctrlcupom" 



            console.log(datafaturamento_ini)




            //filter 

            if (request) {
                seqfaturamento =  parseInt(`${request.body.filter.seqfaturamento}`)
                seqfaturamentoorigem =  parseInt(`${request.body.filter.seqfaturamentoorigem}`)
                datafaturamento_ini= myTools.Date_br_new(`${request.body.filter.datafaturamento_ini}`)
                datafaturamento_fim = myTools.Date_br_new(`${request.body.filter.datafaturamento_fim}`)
                sat_ecf  =  parseInt(`${request.body.filter.sat_ecf}`)
                cupom_fiscal = parseInt(`${request.body.filter.cupom_fiscal}`)
                cdparticipantecliente = parseInt(`${request.body.filter.cdparticipantecliente}`)
                cdparticipantevendedor = parseInt(`${request.body.filter.cdparticipantevendedor}`)
                integracao_tipo = `${request.body.post_integracao.integracao_tipo}`
                integracao_registro = `${request.body.post_integracao.integracao_registro}`
                zanthus_base = `${request.body.get_zanthus.zanthus_base}`
                zanthus_tipo = `${request.body.get_zanthus.zanthus_tipo}`
            }

            



            let filter : ifilter_faturamento = {
                filter: {
                    seqfaturamento,
                    seqfaturamentoorigem, 
                    datafaturamento_ini,
                    datafaturamento_fim,
                    sat_ecf,
                    cupom_fiscal, 
                    cdparticipantecliente, 
                    cdparticipantevendedor
            
                }, 
            
            post_integracao: 
                {
                    integracao_tipo,
                    integracao_registro, 
                    sis_batch_run_seq
                },
            get_zanthus: {
                            zanthus_base,
                            zanthus_tipo  
                    }
                                }
            return filter
        }
        catch(e) {
            console.log(`Service | FilterRequest_get: ${e}`)
            return {}
        }
    

    }

    public async Zanthus (request: Request, response: Response) : Promise<object> {
       
        let filter : ifilter_faturamento = this.FilterRequest_get(request)
        let result = {}


        switch (filter.get_zanthus?.zanthus_tipo)
        {
            case "ctrl":
                result = await Zanthus.Ctrl_Get(filter)
                break;
            case "ctrlcupom":
                    result = await Zanthus.CtrlCupom_Get(filter)
                    break;  
            case "cupom": 
                console.log("CupomGet")
                break;
            case "item":
                console.log("CupomGet")
                break;

        }
        return response.json(result)

    }

    public async integrateZanthusPag(request: Request, response: Response): Promise<object> {
        let result = {}
        try {
            let filter : ifilter_faturamento = this.FilterRequest_get(request)
            
            switch (filter.post_integracao?.integracao_tipo)
            {
                case "ZANTHUS":
                    result = await integrateZanthusPag.Start(this.FilterRequest_get(request)); 
                    break;
    
            }
            return response.json(result)

        } catch(e){
            return response.json(result)    
        }
    }

    public async integrateZanthusPagPendentes(request: Request, response: Response): Promise<object> {
        let result = {}
        try {



            result = await integrateZanthusPag.Start(this.FilterRequest_get()); 
            return response.json(result)

        } catch(e){
            return response.json(result)    
        }
    }

    public async integrateZanthusData(request: Request, response: Response): Promise<object> {
        let result = {}
        try {
            //result = await integrateZanthusPag.Start(this.FilterRequest_get()); 
            let data : Date = myTools.Date_br_new(`${request.query.data }`) 
            let satecf : number = parseInt(`${request.query.satecf}`)

            let processavendapendente : string = `${request.query.processavendapendente}`

            if (!processavendapendente) processavendapendente = "1"

            let filter : ifilter_faturamento =  {
                filter: 
                             {
                                     seqfaturamento: 0,
                                     seqfaturamentoorigem: 0,
                                     datafaturamento_ini: data,
                                     datafaturamento_fim: data,
                                     sat_ecf: satecf,
                                     cupom_fiscal: 0,
                                     cdparticipantecliente: 0,
                                     cdparticipantevendedor: 0
                             }, 
             post_integracao: 
                 {
                     integracao_tipo: "ZANTHUS",
                     integracao_registro: processavendapendente == "1"? "PENDENTE" : "ALL",
                     sis_batch_run_seq: 0
                 },
             get_zanthus: {
                            zanthus_base: "Zanthus", 
                            zanthus_tipo: "ctrlcupom" 
                     }
 
         }


         result = await integrateZanthusPag.Start(filter); 

         return response.json(result)

        } catch(e){
            return response.json(result)    
        }
    }

    public async integratectrl(request: Request, response: Response): Promise<object> { 
        let result = {}
        try {
            //result = await integrateZanthusPag.Start(this.FilterRequest_get()); 
            let data : Date = myTools.Date_br_new(`${request.query.data }`) 
            let processavendapendente : string = `${request.query.processavendapendente}`

            if (!processavendapendente) processavendapendente = "1"



            console.log(`data selecionada ${data}`)

            let filter : ifilter_faturamento =  {
                filter: 
                             {
                                     seqfaturamento: 0,
                                     seqfaturamentoorigem: 0,
                                     datafaturamento_ini: data,
                                     datafaturamento_fim: data,
                                     sat_ecf: 0,
                                     cupom_fiscal: 0,
                                     cdparticipantecliente: 0,
                                     cdparticipantevendedor: 0
                             }, 
             post_integracao: 
                 {
                     integracao_tipo: "ZANTHUS",
                     integracao_registro: processavendapendente == "1"? "PENDENTE" : "ALL",
                     sis_batch_run_seq: 0
                 },
             get_zanthus: {
                            zanthus_base: "Zanthus", 
                            zanthus_tipo: "ctrlcupom" 
                     }
 
         }

                  
         result = await integrateZanthusCtrl.start(filter);


         return response.json(result)

        } catch(e){
            return response.json(result)    
        }
    }

    public async ForcaVenda(request: Request, response: Response) : Promise<object> {
        return response.json(await faturamentoforcavenda.Obter())
    }

    public async batch (request: Request, response: Response) : Promise<object>{ 
        return []
    }

}

export { wk, ifilter_faturamento }
