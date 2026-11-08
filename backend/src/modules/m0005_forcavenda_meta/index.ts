import { Router } from "express";
import modelForcaVendaMetaRouter from "./model";
import reportForcaVendaMetaRouter from "./report";
import serviceForcaVendaMetaRouter from "./service";

const m0005_forcaVendaMetaRouter = Router();

m0005_forcaVendaMetaRouter.use("/model", modelForcaVendaMetaRouter);
m0005_forcaVendaMetaRouter.use("/report", reportForcaVendaMetaRouter);
m0005_forcaVendaMetaRouter.use("/service", serviceForcaVendaMetaRouter);

export default m0005_forcaVendaMetaRouter;