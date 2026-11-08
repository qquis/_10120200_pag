import { Router, Response, Request} from 'express'
import { clsTools } from '../../../model/modelbase';

const ServiceRh = Router(); 

ServiceRh.get(`/inativarfuncionariopag`, async() => {
    try { 

    } catch(e) { 
        clsTools.PagErrorException('ServiceNotificacao', 'inativarfuncionariopag', e)            
    }
})

export default ServiceRh;