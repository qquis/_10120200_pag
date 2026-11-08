import {Router, Response, Request} from 'express'

const m0100_Resultado = Router(); 

import ServiceResultado from './service'
import ReportResultado from './report'
import modelResultado from './model'


m0100_Resultado.use('/service', ServiceResultado);
m0100_Resultado.use('/report', ReportResultado);
m0100_Resultado.use('/model', modelResultado)

export default m0100_Resultado;

