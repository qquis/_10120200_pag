import { Router, Response, Request} from 'express'
import { clsTools } from '../../../model/modelbase';
import serviceResultado from './serviceResultado';

const ServiceDRE = Router(); 

ServiceDRE.post(`/processarfechamento`, async(req: Request, res: Response) => {
    let resultado: any = {"status": "0", "message": "Processamento falhou"}
    try { 

        let dados : any = req.query? req.query : {}
        await serviceResultado.ProcessarFechamento(dados);
        resultado = {"status": "1", "message": "Processamento finalizado com sucesso"}
        return res.status(200).send(resultado);
        
    } catch(e) { 
        clsTools.PagErrorException('ServiceNotificacao', 'inativarfuncionariopag', e)            
        return res.status(500).send(resultado);
    } 
})

export default ServiceDRE;