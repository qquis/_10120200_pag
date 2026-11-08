import { Router } from "express";


const externalZanthusRouter = Router()

import externalZanthusServiceRouter from "./service";
import externalZanthusReportRouter from "./report";
import externalZanthusModelRouter from "./model";


externalZanthusRouter.use('/service', externalZanthusServiceRouter);
externalZanthusRouter.use('/report', externalZanthusReportRouter);
externalZanthusRouter.use('/model', externalZanthusModelRouter);


export default externalZanthusRouter;

