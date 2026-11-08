import { Router, Request, Response } from "express";
export default class responseDefault { 
    static get(status : number, message: string = `OK`, data: any = {}) : object {
        return {
            status,
            message,
            data, 
            error: status >= 400 ? true : false,
            success: status < 400 ? true : false,
            
        }
    }
    static async send(res: Response, data: any = {}, message: string = `Sucesso`, status : number = 0)  {
        if (status == 0){
            status = 200;
        }
        res.status(status).send(responseDefault.get(status, message, data));   
    }
}
