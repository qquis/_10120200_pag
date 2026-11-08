import {Request, Response, Router} from 'express'

import { clsTools, clsBase} from '../../../model/modelbase';

const ReportRh = Router();

import reportrh from './reportRh';


ReportRh.get(`/competencia`, async (req: Request, res: Response) => {
    try {
        res.status(200).send(await reportrh.CompetenciaGet(req.query))
    } catch (e) {
        clsTools.PagErrorException('ReportRh', 'competencia', e);
        res.status(500).send({ error: 'An error occurred while generating the report' });
    }
});

ReportRh.get(`/folhacontratada`, async (req: Request, res: Response) => {
    try {
        
        res.status(200).send(await reportrh.FolhaContratadaGet(req.query));


    } catch (e) {
        clsTools.PagErrorException('ReportRh', 'relatorio', e);
        res.status(500).send({ error: 'An error occurred while generating the report' });
    }
});


ReportRh.get(`/folhaporcompetencia`, async (req: Request, res: Response) => {
    try {
    
        res.status(200).send(await reportrh.FolhaContrataPorCompetenciaGet(req.query))


    } catch (e) {
        clsTools.PagErrorException('ReportRh', 'relatorio', e);
        res.status(500).send({ error: 'An error occurred while generating the report' });
    }
});


ReportRh.get(`/tipo_contrato`, async (req: Request, res: Response) => {
    try {
        res.status(200).send(await reportrh.TipoContrato());

        //let sql = 'select * from tbrh_tipo_contrato order by rh_tipo_contrato_descricao';
        //const myTools = new clsBase();
        //const result = await myTools.myDataBase.pag.DataGet(sql);
        //res.status(200).send(result);

    } catch (e) {
        clsTools.PagErrorException('ReportRh', 'tipo_contrato', e);
        res.status(500).send({ error: 'An error occurred while generating the report' });
    }

})

ReportRh.get(`/setoroperacional`, async (req: Request, res: Response) => {
    try {
        // Implement the logic for generating the report here
        res.status(200).send(await reportrh.SetorOperacional());

    } catch (e) {
        clsTools.PagErrorException('ReportRh', 'tipo_contrato', e);
        res.status(500).send({ error: 'An error occurred while generating the report' });
    }
})


export default ReportRh;