import { Router } from 'express';


const m0040_fiscal = Router();

import serviceFiscalRouter from './service';
import reportFiscalRouter from './report';
import modelFiscalRouter from './model';


m0040_fiscal.use('/service', serviceFiscalRouter);
m0040_fiscal.use('/report', reportFiscalRouter);
m0040_fiscal.use('/model', modelFiscalRouter);



export default m0040_fiscal;