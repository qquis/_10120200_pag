import { Request, Response, Router } from "express";
import routerReport from "./report/_index";
import routerModelNotificacao from "./model/_index";
import routerServiceNotificacao from "./service/_index";

const Notificacao = Router(); 

Notificacao.use("/report", routerReport)
Notificacao.use("/model", routerModelNotificacao)
Notificacao.use("/service", routerServiceNotificacao)




export default Notificacao


//get  http://localhost:57895/notificacao/listNotificacaoesObter 
//get  http://localhost:57895/notificacao/model/ 
//post http://localhost:57895/notificacao/model/ 
//post http://localhost:57895/notificacao/cmd/start 
//post http://localhost:57895/notificacao/cmd/send
