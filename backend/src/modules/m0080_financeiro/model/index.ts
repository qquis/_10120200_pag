import {Request, Response, Router, NextFunction} from 'express'
const modelFinanceiroRouter = Router()

import { modelautorizacaoPagamentoPagRouter } from './modelautorizacaopagamentopag';
import { modelAutorizacaoPagamentoRouter } from './modelAutorizacaoPagamento';

modelFinanceiroRouter.use("/autorizacaopagamentopag", modelautorizacaoPagamentoPagRouter)
modelFinanceiroRouter.use("/autorizacaopagamento", modelAutorizacaoPagamentoRouter)

export default modelFinanceiroRouter;