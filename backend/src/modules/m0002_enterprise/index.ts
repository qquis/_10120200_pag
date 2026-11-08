import { Router, Response, Request } from "express";


const m0002_enterprise = Router();

import reportEnterpriseRouter from "./report";

m0002_enterprise.use("/report", reportEnterpriseRouter);

export default m0002_enterprise;