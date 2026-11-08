import { Router } from 'express';

import modelProdutoBluesoftRouter from './model';
import serviceProdutoBluesoftRouter from './service';
import reportProdutoBluesoftRouter from './report';


const m0021_produtobluesoft = Router();

m0021_produtobluesoft.use('/model', modelProdutoBluesoftRouter);
m0021_produtobluesoft.use('/service', serviceProdutoBluesoftRouter);
m0021_produtobluesoft.use('/report', reportProdutoBluesoftRouter);

export default m0021_produtobluesoft;