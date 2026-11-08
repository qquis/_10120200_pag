import { Router } from 'express';


const m0030_estoquecusto = Router();

import reportEstoqueCustoRouter from './report';

m0030_estoquecusto.use('/report', reportEstoqueCustoRouter);



export default m0030_estoquecusto;