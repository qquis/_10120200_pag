import { Request, Response, Router } from "express";
import reportIntegracao from "./report";

let myreportIntegracao : reportIntegracao;

const routerReport = Router() 

routerReport.get("/produto", async(request: Request, response: Response) => {
    try {
        
        myreportIntegracao = new reportIntegracao(request)
        return response.send(await  myreportIntegracao.reportIntegracaoTipoProduto())

    } catch (E) {
        throw Error("F0095 _ Error")
    }
})

export default routerReport;