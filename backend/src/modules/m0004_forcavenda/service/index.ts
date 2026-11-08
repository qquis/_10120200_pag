import { Router } from "express";

import serviceForcaVenda from "./service";

const serviceForcaVendaRouter = Router();



serviceForcaVendaRouter.post('/importar-prazoPgto', async (req, res) => {
    try {
        const prazoPgto = await serviceForcaVenda.prazoPgto.start()
        return res.status(200).send({status: 1, info: "Importação realizada com sucesso", prazoPgto})
    }
    catch (e) {
        return res.status(400).send({status: 0, info: `Erro ao importar prazo de pagamento ${e}`})
    }
}) 


serviceForcaVendaRouter.post('/importar-tabelaPreco', async (req, res) => {
    try {
        const tabelaPreco = await serviceForcaVenda.tabelaPreco.start()
        return res.status(200).send({status: 1, info: "Importação realizada com sucesso", tabelaPreco})
    }
    catch (e) {
        return res.status(400).send({status: 0, info: `Erro ao importar tabela de preço ${e}`})
    }
}) 


serviceForcaVendaRouter.post('/importar-baseGeralPreco', async (req, res) => {
    try {
        console.log(`Index/Post _ Atualização Geral do força de venda em execução`)
        await serviceForcaVenda.prazoPgto.start();
        await serviceForcaVenda.tabelaPreco.start();
        console.log(`Index/Post _ Atualização Geral do força de venda concluída`)

        return res.status(200).send({status: 1, info: "Importação realizada com sucesso"})
    }
    catch (e) {
        return res.status(400).send({status: 0, info: `Erro ao importar base geral de preços ${e}`})
    }
}) 
export default serviceForcaVendaRouter;

