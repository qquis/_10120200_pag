import { Request, Response, Router } from "express";
import guardianTicket from "./Service";
import tbguardian_ticket from "./tbguardian_ticket";
import pagToolsDate  from "../../tools/pagToolsDate"
import { intlFormat } from "date-fns";
import myTools from '../../tools/Tools';

const guardianticket = Router()

const __service = new guardianTicket();

export default guardianticket.post("/m0062_guardianticket_incluir", async(Request, Response ) =>{

    let tbguardian_ticket_result: tbguardian_ticket = new tbguardian_ticket(0,'', new Date(), new Date(),new Date(),0,0,0)
    try {

        //console.log(myTools._dataConvertStrtoDate(Request.body.gtk_pesagemInicialHora)) 

        const data_ini : Date = myTools._dataMomentoStrToDate(Request.body.gtk_data, 'DD/MM/YYYY HH:mm:ss')


        const {    
            gtk_numero, 
            gtk_placa, 
            gtk_data, 
            gtk_pesagemInicialHora, 
            gtk_pesagemFinalHora,
            gtk_pesagemInicialPeso, 
            gtk_pesagemFinalPeso, 
            gtk_pesagemPesoLiquido}  = Request.body;

       tbguardian_ticket_result = await __service.IncluirNovoTicket(
        new tbguardian_ticket(
                                gtk_numero, 
                                gtk_placa , 
                                myTools._dataMomentoStrToDate(gtk_data, 'DD/MM/YYYY HH:mm:ss'), 
                                myTools._dataMomentoStrToDate(gtk_pesagemInicialHora, 'DD/MM/YYYY HH:mm:ss'), 
                                myTools._dataMomentoStrToDate(gtk_pesagemFinalHora, 'DD/MM/YYYY HH:mm:ss'), 
                                gtk_pesagemInicialPeso, 
                                gtk_pesagemFinalPeso, 
                                gtk_pesagemPesoLiquido
                        )) as tbguardian_ticket
        
        return Response.json(tbguardian_ticket_result)

    }
    catch (e)
    {
        return Response.json(tbguardian_ticket_result)
    }
})



