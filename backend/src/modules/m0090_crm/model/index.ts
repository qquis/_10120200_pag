import { Router, Request, Response } from "express";


const modelCRMRouter = Router();



const modelcrmSorteioRouter  = Router();
modelCRMRouter.use('/sorteio', modelcrmSorteioRouter);



import modelcrm_sorteio_cupom from './modelcrm_sorteio_cupom';    

modelcrmSorteioRouter.get('/consultar', async (req: Request, res: Response) => {
    let modelitem = new modelcrm_sorteio_cupom();
    try {

        modelitem = new modelcrm_sorteio_cupom();
        await modelitem.consultar(req.query);
    } catch (e: any) {
        res.status(500).send({ error: e.message });
    }
    finally {
        res.status(200).send(modelitem);
    }
});



modelcrmSorteioRouter.get('/registrarCupom', async (req: Request, res: Response) => {
    let modelitem = new modelcrm_sorteio_cupom();
    try {

        modelitem = new modelcrm_sorteio_cupom();


        if (!req.query.nf_chave) { 
            res.status(400).send({ error: "Parâmetro nf_chave é obrigatório." });
            return;
        }

        if (!req.query.crm_so_cpf) { 
            res.status(400).send({ error: "Parâmetro crm_so_cpf é obrigatório." });
            return;
        }


        await modelitem.consultar(req.query);
        console.log('item a registrar consultado', modelitem);
        if (modelitem.nf_chave) {
            modelitem.crm_so_cpf = String(req.query.crm_so_cpf);
            await modelitem.registrar_cupom();
        } else {
            res.status(404).send({ error: "Cupom não encontrado para a chave informada" });
            return;
        }

        
    } catch (e: any) {
        res.status(500).send({ error: e.message });
    }
    finally {
        res.status(200).send(modelitem);
    }
});



export default modelCRMRouter;