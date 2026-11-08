import { Router } from 'express';


const m0085_zanthus = Router();

import serviceZanthusRouter from './service';
import reportZanthusRouter from './report';
import modelZanthusRouter from './model';

m0085_zanthus.use('/service', serviceZanthusRouter);
m0085_zanthus.use('/report', reportZanthusRouter);
m0085_zanthus.use('/model', modelZanthusRouter);


export default m0085_zanthus;