import {Request, Response, Router } from "express";
import {wk} from './wk'

import reportFaturamentoZanthusRouter from "./report";

const Wk = new wk();

const faturamentoZanthus = Router()

const filter = Router(); 
//const entity = Router(); 


faturamentoZanthus.get("/", async (request: Request, response: Response) => {
    return response.status(200).send({status : "1", info : "M0055 - Faturamento Zanthus - Ativo"})
})


faturamentoZanthus.use('/report', reportFaturamentoZanthusRouter);
faturamentoZanthus.use("/filter", filter)
//faturamento.get("/entity", entity)

/*opt filter*/ 




filter.get("/zanthus", async(request: Request, response: Response) => {
    try {

           return await Wk.Zanthus(request, response);
    }
    catch(e)
    {
        console.log(e)
    }
} )
filter.get("/integrate", async(request: Request, response: Response) => {
    try {
        return await Wk.integrateZanthusPag(request, response)
    }
    catch(e)
    {
        console.log(e)
    }
} )

filter.get("/integratedata", async(request: Request, response: Response) => {
    try {
        return await Wk.integrateZanthusData(request, response)
    }
    catch(e)
    {
        return {dados: `error na execução do /integratedata  ${e}`} 
    }
} )


filter.get("/integratectrl", async(request: Request, response: Response) => {
    try {
        console.log("Entrou no ctrl")
        return await Wk.integratectrl(request, response)
    }
    catch(e)
    {
        return {dados: `error na execução do /integratedata  ${e}`} 
    }
} )

filter.get("/integratependente", async(request: Request, response: Response) => {
    try {
        return await Wk.integrateZanthusPagPendentes(request, response)
    }
    catch(e)
    {
        console.log(e)
    }
} )

filter.get('/forcavenda', async(request: Request, response: Response) => {
    try {
        return await Wk.ForcaVenda(request, response);
    }
    catch(e)
    {
        console.log(e)
    }
})


export default faturamentoZanthus;