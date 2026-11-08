import { Router } from 'express';


const m1000_informe = Router();

import serviceInformeRouter from './service';
import reportInformeRouter from './report';
import modelInformeRouter from './model';

m1000_informe.use('/service', serviceInformeRouter);
m1000_informe.use('/report', reportInformeRouter);
m1000_informe.use('/model', modelInformeRouter);



export default m1000_informe;