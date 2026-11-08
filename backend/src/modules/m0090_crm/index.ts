import { Router } from 'express';


const m0090_crm = Router();

import serviceCRMRouter from './service';
import reportCRMRouter from './report';
import modelCRMRouter from './model';

m0090_crm.use('/service', serviceCRMRouter);
m0090_crm.use('/report', reportCRMRouter);
m0090_crm.use('/model', modelCRMRouter);

export default m0090_crm;