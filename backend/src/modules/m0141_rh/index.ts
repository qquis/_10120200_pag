import {Router, Response, Request} from 'express'

const m0141_Rh = Router(); 

import ServiceRh from './service'
import ReportRh from './report'


m0141_Rh.use('/service', ServiceRh);
m0141_Rh.use('/report', ReportRh);

export default m0141_Rh;

