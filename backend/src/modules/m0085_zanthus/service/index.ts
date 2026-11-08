import { Router } from 'express';


const serviceZanthusRouter = Router();

import serviceAtualizacaoGeralFiscal from './serviceAtualizacaoGeralFiscal';
import serviceAtualizacaoCBNEF from './serviceAtualizacaoCBNEF';
//import serviceZanthusCargaOld from './serviceAtualizacao.Carga.Processar.old';
import serviceAtualizacaoClientes from './serviceAtualizacaoClientes';
import serviceZanthusCarga from './serviceAtualizacao.Carga.Processar.new';
import serviceAtualizacaoDeskTop from './serviceAtualizacao.Carga.DeskTop';









serviceZanthusRouter.post('/atualizacao-geral', async (req, res) => {
    let result = {}
    try {
       
        result = await serviceAtualizacaoDeskTop.start(req.query)
        res.status(200).json(result);
    } catch (e) {
        res.status(500).json(result);
    }
})


serviceZanthusRouter.post('/atualizacao-fiscal', async (req, res) => {
    try {
       
        await serviceAtualizacaoGeralFiscal.start(req.query)
        res.status(200).json({ message: 'Processamento concluído com sucesso.' });
    } catch (e) {
        res.status(500).json({ error: 'Ocorreu um erro durante o processamento.' });
    }
})


serviceZanthusRouter.post('/atualizacao-cbenef', async (req, res) => {
    try {
       
        await serviceAtualizacaoCBNEF.start(req.query)
        res.status(200).json({ message: 'Processamento concluído com sucesso.' });
    } catch (e) {
        res.status(500).json({ error: 'Ocorreu um erro durante o processamento.' });
    }
})


serviceZanthusRouter.post('/atualizacao-cliente', async (req, res) => {
    try {
       
        await serviceAtualizacaoClientes.start(req.query)
        res.status(200).json({ message: 'Processamento concluído com sucesso.' });
    } catch (e) {
        res.status(500).json({ error: 'Ocorreu um erro durante o processamento.' });
    }
})

serviceZanthusRouter.post('/carga-processar', async (req, res) => {
    try {
       
        await serviceZanthusCarga.start(req.query)
        res.status(200).json({ message: 'Processamento concluído com sucesso.' });
    } catch (e) {
        res.status(500).json({ error: 'Ocorreu um erro durante o processamento.' });
    }
})


export default serviceZanthusRouter;