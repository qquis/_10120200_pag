import { Request, Response, Router, NextFunction } from "express";
import { clsTools } from '../../../model/modelbase'
import ModelUserConnect from "./modelUserConnect";


const routerModelSistema = Router();


/* Router ModelUserConnect */



routerModelSistema.get("/userConnectGet", async(request: Request, response: Response) => {
    try {
        let myModelmyUserConnect : ModelUserConnect = new ModelUserConnect()
        let sis_us_seq : number = request.query.sis_us_seq ? parseInt(`${request.query.sis_us_seq}`) : 0 
            let sis_cd : number = request.query.sis_cd ? parseInt(`${request.query.sis_cd}`) : 0
            
            
            if (sis_us_seq == 0)
                throw new Error(`Código não informado`) 



            await myModelmyUserConnect.consultar(sis_us_seq, sis_cd)


            return response.send(myModelmyUserConnect)

    } catch (e) {
        clsTools.PagErrorException("ModelSistema", "userConnectGet", e)
        response.status(400).send({"status": "error"})
    }
})

routerModelSistema.get("/ambiente", async(request: Request, response: Response) => {
    try {
        return response.send({ ambiente: process.env.ENVIRONMENT })
    } catch (e) {
        clsTools.PagErrorException("ModelSistema", "ambiente", e)
        response.status(400).send({"status": "error"})
    }
})


export default routerModelSistema