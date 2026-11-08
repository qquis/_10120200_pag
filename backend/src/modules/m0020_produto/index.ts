import { Router } from "express";


const m0020_produto = Router()


import serviceProdutoRouter from './service';
import reportProdutoRouter from './report';
import modelProdutoRouter from './model';

m0020_produto.use('/service', serviceProdutoRouter);
m0020_produto.use('/report', reportProdutoRouter);
m0020_produto.use('/model', modelProdutoRouter);






export default m0020_produto;




