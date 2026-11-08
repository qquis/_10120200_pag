import { Router} from "express";

import serviceFaturamentoVipRouter from "./service";
import reportFaturamentoVipRouter from "./report";
import modelFaturamentoVipRouter from "./model";


const m0051_faturamentoVip = Router();

m0051_faturamentoVip.use("/service", serviceFaturamentoVipRouter);
m0051_faturamentoVip.use("/report", reportFaturamentoVipRouter);
m0051_faturamentoVip.use("/model", modelFaturamentoVipRouter);

export default m0051_faturamentoVip;