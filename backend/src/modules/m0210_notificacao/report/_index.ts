import { Request, Response, Router, NextFunction } from "express";
import ReportNotificacaox from "./_reportNotificacao"
import { clsTools } from '../../../model/modelbase'

import { ifilter } from "../interfaces";
const routerReport = Router(); 


let filterReport : ifilter

let myReport : ReportNotificacaox;

const middlewareReportNotificacaoGetFilterBody = async (request: Request, 
                                                response: Response, 
                                                next: NextFunction) => { 
    try {
        let filter: ifilter = {
            notificacao_send_seq: parseInt(`${request.body.notificacao_send_seq}`), 
            notificacao_send_data_ini: clsTools._datemomentDatStrToDate(`${request.body.notificacao_send_data_ini}`, `DD/MM/YYYY`)	,
            notificacao_send_data_fim: clsTools._datemomentDatStrToDate(`${request.body.notificacao_send_data_fim}`, `DD/MM/YYYY`)	, 
            notificacao_send_status_cd: parseInt(`${request.body.notificacao_send_status_cd}`), 
            notificacao_send_tipo_cd : parseInt(`${request.body.notificacao_send_tipo_cd}`), 
            notificacao_celular_dd_numero: `${request.body.notificacao_celular_dd_numero}`, 
            notificacao_email : `${request.body.notificacao_email}`, 
            notificacao_whatsapp: parseInt(`${request.body.notificacao_whatsapp}`), 
            notificacao_mail: parseInt(`${request.body.notificacao_mail}`),
            notificacao_whatsapp_gp: parseInt(`${request.body.notificacao_whatsapp_gp}`)               
                    }
        filterReport = filter;
        next()    

    } catch(e) {
        clsTools.PagErrorException('routerReport', 'middlewareReportNotificacaoGetFilterBody', e)
        response.status(500).send({error: `Erro ao processar o filtro`})
    }    

}

routerReport.get('/sendmessage/list',middlewareReportNotificacaoGetFilterBody, async(request: Request, response: Response) => {
    try {
        
        myReport = new ReportNotificacaox();
        response.send((await myReport.rptNotificacaoSendMessageGet(filterReport)).list)
    } 
    catch(e) {
        clsTools.PagErrorException('routerReport', 'get /sendmessage/list', e)
    }
})

export default routerReport;
