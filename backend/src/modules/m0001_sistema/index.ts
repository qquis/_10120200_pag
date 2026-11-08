import { Request, Response, Router } from "express";
//import routerReport from "./report/_index";
//import routerModelNotificacao from "./model/_index";


import routerServiceSistema from "./service";
import routerModelSistema from "./model";
import reportSistemaRouter from "./report";

const sistemaRouter = Router(); 


sistemaRouter.use("/service", routerServiceSistema)
sistemaRouter.use("/model", routerModelSistema)
sistemaRouter.use("/report", reportSistemaRouter)

//Notificacao.use("/report", routerReport)
//Notificacao.use("/model", routerModelNotificacao)
//Notificacao.use("/service", routerServiceNotificacao)

sistemaRouter.get("/", async (req: Request, resp: Response) => {
    return resp.send({ status: "1", info: "Modulo M0001 - Sistema" })
})


export default sistemaRouter


/*
    DESENHO PARA AS REQUISIÇÕES

    localhost/sistema/servise/startbackend
    localhost/sistema/servise/login

    localhost/sistema/model/Userget
    localhost/sistema/model/UserInativar


*/