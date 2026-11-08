import { Router, Request, Response } from "express";
import { clsBase, clsTools } from "../../../model/modelbase";
import serviceInforme from "./service"; 
const serviceInformeRouter = Router();

serviceInformeRouter.use("/if0017", async (request: Request, response: Response) => {
    try {
        await serviceInforme.if0017.start(request.query)
        return response.status(200).send()
    } catch (e) {
        return response.status(400).send({status: 0, info: "Error fetching if0017 report"})
    }
})

serviceInformeRouter.use("/if0045", async (request: Request, response: Response) => {
    try {
        
        await serviceInforme.if0045.start(request.query)
        return response.status(200).send()
    } catch (e) {
        return response.status(400).send({status: 0, info: "Error fetching if0045 report"})
    }
})
serviceInformeRouter.use("/if0100", async (request: Request, response: Response) => {
    try {
        await serviceInforme.if0100.start(request.query)
        return response.status(200).send()
    } catch (e) {
        return response.status(400).send({status: 0, info: "Error fetching if0100 report"})
    }
})
serviceInformeRouter.use("/if0050", async (request: Request, response: Response) => {
    try {
        await serviceInforme.if0050.start(request.query)
        return response.status(200).send()
    } catch (e) {
        return response.status(400).send({status: 0, info: "Error fetching if0050 report"})
    }
})

serviceInformeRouter.use("/if0110", async (request: Request, response: Response) => {
    try {
        await serviceInforme.if0110.start(request.query)
        return response.status(200).send()
    } catch (e) {
        return response.status(400).send({status: 0, info: "Error fetching if0110 report"})
    }
})
export default serviceInformeRouter;