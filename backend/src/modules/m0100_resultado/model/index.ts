import {Request, Response, Router, NextFunction} from 'express'
import { clsTools } from '../../../model/modelbase'
import modelResultaConta from './modelresultado_conta'
import { error } from 'console'
const modelDRE = Router()
const modelDreConta = Router()


modelDRE.use("/conta", modelDreConta)



/*Modelos*/


let myResultadoConta : modelResultaConta = new modelResultaConta()

const middlewareConta = (async (req: Request, resp: Response, next : NextFunction) => {
    try { 
            if (!req.query.r_conta_cd)
                resp.status(400).send({"status": "código da conta não informado: r_conta_cd"})

            myResultadoConta = new modelResultaConta()
            const {r_conta_cd = 0} = req.query as { r_conta_cd?: number}
            await myResultadoConta.modelGet(r_conta_cd)

            next()

    } catch(e) { 
        clsTools.PagErrorException("m0100 | model/index", "Model/get", e)
    }
})
modelDreConta.get("/",middlewareConta, async (req: Request, resp: Response) => { 
    try { 
            resp.status(200).send(myResultadoConta)
    } catch (e) { 
        clsTools.PagErrorException("m0100 | model/index", "Model/get", e)
        resp.status(500).send({"status": `error ${e}`})
    }
})
modelDreConta.post("/",middlewareConta, async (req: Request, resp: Response) => { 
    
    try { 
            if (!req.body) throw new Error((req.body.status = "ERROR! Não contem body"));
            if(     !req.body.r_conta_cd 
                ||  !req.body.r_rateio_cd
            )  throw new Error((req.body.status = "ERROR! Bory incompleto"))
            await myResultadoConta.modelPost(req.body)
            

    } catch (e) { 
        clsTools.PagErrorException("m0100 | model/index", "Model/get", e)
        resp.status(500).send(req.body)

    } finally { 
        resp.status(200).send(myResultadoConta)
    }
})





export default modelDRE