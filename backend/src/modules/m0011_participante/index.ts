import {Router, request, response} from 'express'

import serviceParticipanteRouter from './service';
import reportParticipanteRouter from './report';
import modelParticipanteRouter from './model';

const m0011_participante = Router();

m0011_participante.use("/service", serviceParticipanteRouter);
m0011_participante.use("/report", reportParticipanteRouter);
m0011_participante.use("/model", modelParticipanteRouter);

export default m0011_participante;



