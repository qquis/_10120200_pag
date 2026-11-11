import { Router, request, response} from 'express'


const serviceParticipanteRouter = Router();


import serviceParticipante from './Service';

serviceParticipanteRouter.post("/vipimport", async (request, response) => {
    try { 

        await serviceParticipante.vipimport.start(request.query)

        response.send({ message: "Processo de importação iniciado com sucesso." });

    } catch (e: any) {
        response.status(500).send({ error: e.message });
    }

})

serviceParticipanteRouter.post("/redshiftbluesoftimport", async (request, response) => {
    try {

        await serviceParticipante.RedShiftBlueSoftImport.start(request.query)

        response.send({ message: "Processo de importação iniciado com sucesso." });

    } catch (e: any) {
        response.status(500).send({ error: e.message });
    }

})

serviceParticipanteRouter.post("/apibluesoftimport", async (request, response) => {
    try {

        await serviceParticipante.APIBlueSoftImport.start(request.query)

        response.send({ message: "Processo de importação iniciado com sucesso." });

    } catch (e: any) {
        response.status(500).send({ error: e.message });
    }

})

serviceParticipanteRouter.post("/grupoeconomicoimport", async (request, response) => {
    try {

        await serviceParticipante.GrupoEconomicoImport.start(request.query)

        response.send({ message: "Processo de importação iniciado com sucesso." });

    } catch (e: any) {
        response.status(500).send({ error: e.message });
    }

})
serviceParticipanteRouter.post("/apibluesoftatualizarstatuscredito", async (request, response) => {
    try {

        await serviceParticipante.APIBlueSoftAtualizarStatusCredito.start(request.query)

        response.send({ message: "Processo de atualização de status de crédito iniciado com sucesso." });

    } catch (e: any) {
        response.status(500).send({ error: e.message });
    }

})

serviceParticipanteRouter.post("/credito-correcao", async (request, response) => {
    try {

        await serviceParticipante.APIBlueSoftAtualizarStatusCreditoCorrecao.start(request.query)

        response.send({ message: "Processo de correção de status de crédito iniciado com sucesso." });

    } catch (e: any) {
        response.status(500).send({ error: e.message });
    }

})


export default serviceParticipanteRouter;