import { Router } from 'express';

const m0071_interface = Router();

import reportInterfaceRouter from './report';
import serviceInterfaceRouter from './service';

m0071_interface.use('/report', reportInterfaceRouter);
m0071_interface.use('/service', serviceInterfaceRouter);

export default m0071_interface;