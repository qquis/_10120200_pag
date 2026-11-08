import { Router, request, response} from 'express'

const modelParticipanteRouter = Router();

export default modelParticipanteRouter;

import modelParticipanteBase from './model'
import modelParticipanteCrm from './modelParticipanteCrm';




/* Participante CRM */

const modelParticipanteCrmRouter = Router();

modelParticipanteRouter.get("/consultar", async(request, response) => {
    try {
        //let participante = new modelParticipante(request.query)
        if (request.query.cdparticipante) {
            let participante = await modelParticipanteBase.Consultar(request.query)
            
            response.status(200).json(participante)
        } else {
            throw new Error("Código do participante não informado")
        }
        
        
    } catch(e) {
        response.status(400).json({
            error: `erro ao consultar participante: ${e}`
        })
    }
})




/* PARTICIPANTE CRM */

    modelParticipanteRouter.use('/crm', modelParticipanteCrmRouter)

    modelParticipanteCrmRouter.get('/consultar', async (request, response) => {
        try { 

            let participante_crm = new modelParticipanteCrm()
            await participante_crm.consultar(request.query)


            response.status(200).json(participante_crm)

        } catch(e) {
            response.status(400).json({
                error: `erro ao consultar participante CRM: ${e}`
            })
        }
    }) 

    modelParticipanteCrmRouter.get('/checkexists', async (request, response) => {
        try { 

     let participante_crm = new modelParticipanteCrm()
            let exists = await participante_crm.checkExists(request.query)
            response.status(200).json({exists}) 
        } catch(e) {
            response.status(400).json({
                error: `erro ao consultar participante CRM: ${e}`
            })
        }
    }) 

    modelParticipanteCrmRouter.post('/incluir', async (request, response) => {
        try { 

            let participante = new modelParticipanteCrm()
            let sucessoInclusao : boolean = await participante.incluir(request.body)

            if (sucessoInclusao) {
                response.status(200).json(participante)    
            } else {

                response.status(400).json(participante)
            }

            
        } catch(e) {
            response.status(400).json({
                error: `erro ao criar participante CRM: ${e}`
            })
        }
    })

