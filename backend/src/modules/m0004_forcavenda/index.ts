import { Router } from "express";

import modelForcaVendaRouter from "./model";
import serviceForcaVendaRouter from "./service";
import reportForcaVendaRouter from "./report";


const M0104_ForcaVenda = Router();

M0104_ForcaVenda.use('/model', modelForcaVendaRouter)
M0104_ForcaVenda.use('/service', serviceForcaVendaRouter)
M0104_ForcaVenda.use('/report', reportForcaVendaRouter)

export default M0104_ForcaVenda