import { Request, Response, Router } from "express";


import modelFinanceiroRouter from "./model";
import reportFinanceiroRouter from "./report";
import serviceFinanceiroRouter from "./service";


const m0080_financeiro = Router(); 

m0080_financeiro.get("/", (req: Request, resp: Response) => { 
    resp.send({"info": "Módulo Financeiro"})
})

m0080_financeiro.use("/model", modelFinanceiroRouter);
m0080_financeiro.use("/report", reportFinanceiroRouter);
m0080_financeiro.use("/service", serviceFinanceiroRouter);



export default m0080_financeiro; 