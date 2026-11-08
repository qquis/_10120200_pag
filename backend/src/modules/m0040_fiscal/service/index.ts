import { Router } from "express";
import { clsTools, clsBase } from "../../../model/modelbase";

const serviceFiscalRouter = Router();

const LOG_FILE_NAME = 'M0041';

import serviceFiscal from "./service";



    serviceFiscalRouter.post('/figurafiscal/atualizar-figura-regra', async (req, res) => {
        let result : any
        try {
            await serviceFiscal.FiguraFiscalRegraFiscal.start();
            result = clsTools.responseDefault.get(200, "Base de Figura Fiscal atualizada com sucesso.", {})
            
            
        } catch (error) {
            await clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.post/figurafiscal/atualizar-figura-regra', error);
            result = clsTools.responseDefault.get(500, "Erro ao atualizar a base de Figura Fiscal.", {})
        }
        finally {
            res.status(result.status).send(result);
        }
    });

    serviceFiscalRouter.post('/figurafiscal/atualizar-figura-produto-unitario', async (req, res) => {
        let result : any
        try {
            await serviceFiscal.FiguraFiscalPorProdutoUnitario.start(req.query);
            result = clsTools.responseDefault.get(200, "atualizar-figura-produto-unitario atualizada com sucesso.", {})
        } catch (error) {
            await clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.get/figurafiscal/atualizar-figura-produto-unitario', error);
            result = clsTools.responseDefault.get(500, "Erro ao atualizar a base de atualizar-figura-produto-unitario.", {})
        }
        finally {
            res.status(result.status).send(result);
        }
    });  
    
    serviceFiscalRouter.post('/figurafiscal/atualizar-figura-produto-nfce', async (req, res) => {
        
        let result : any
        try {
            //console.log(`DADOS DA RQUERY: `, req.query);
            await serviceFiscal.FiguraFiscalPorProdutoNfce.start(req.query);
            result = clsTools.responseDefault.get(200, "atualizar-figura-produto-nfce atualizada com sucesso.", {})
           

        } catch (error) {
            await clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.get/figurafiscal/atualizar-figura-produto-nfce', error);
            result = clsTools.responseDefault.get(500, "Erro ao atualizar a base de atualizar-figura-produto-nfce.", {})
        }
        finally {
            res.status(result.status).send(result);
        }
    });  

    serviceFiscalRouter.post('/figurafiscal/atualizar-figura-produto-nfe', async (req, res) => {
        
        let result : any
        try {
            //console.log(`DADOS DA RQUERY: `, req.query);
            await serviceFiscal.FiguraFiscalPorProdutoNfe.start(req.query);
            result = clsTools.responseDefault.get(200, "atualizar-figura-produto-nfe atualizada com sucesso.", {})
           

        } catch (error) {
            await clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.get/figurafiscal/atualizar-figura-produto-nfe', error);
            result = clsTools.responseDefault.get(500, "Erro ao atualizar a base de atualizar-figura-produto-nfe.", {})
        }
        finally {
            res.status(result.status).send(result);
        }
    });      
    
    serviceFiscalRouter.post('/atualizacaogeral', async (req, res) => {
        let result : any
        try {
            
            await clsTools.pagConsole("AMBIENTE FISCAL _ Atualização Geral Iniciando...",false, false, LOG_FILE_NAME)

            /*PIS/COFINS*/
                await clsTools.pagConsole("AMBIENTE FISCAL | Base PIS/COFINS",false, false, LOG_FILE_NAME)

                await serviceFiscal.Pis.start();
                await serviceFiscal.Cofins.start();


            /*FIGURA FISCAL GERAL */
                await clsTools.pagConsole("AMBIENTE FISCAL | Base FIGURA FISCAL",false, false, LOG_FILE_NAME)
                await serviceFiscal.FiguraFiscalRegraFiscal.start();


            /*FIGURA NFCE */            
            await clsTools.pagConsole("AMBIENTE FISCAL | Atualizando base de NFEC e FIGURA FISCAL Produto...",false, false, LOG_FILE_NAME)
            await serviceFiscal.FiguraFiscalPorProdutoNfce.start({});

            /*MAPEAMENTO FISCAL */                        
            await clsTools.pagConsole("AMBIENTE FISCAL | Atualizando mapeamento fiscal...",false, false, LOG_FILE_NAME)
            await serviceFiscal.atualizaMapeamentoFiscal.start();

            result = clsTools.responseDefault.get(200, "Base de Figura Fiscal atualizada com sucesso.", {})
        } catch (error) {
            await clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.get/atualizacaogeral', error);
            result = clsTools.responseDefault.get(500, "Erro ao atualizar a base de Figura Fiscal.", {})
        }
        finally {
            res.status(result.status).send(result);
        }
    });      


    serviceFiscalRouter.post('/cbenefAtualizarProdutoPag', async (req, res) => {
        try {
            

            
            await serviceFiscal.cbenefAtualizarProdutoPag.start(req.body);
            
            res.status(200).send({ message: 'Atualização realizada com sucesso.' });
            
         
        } catch (error) {
            await clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.post/cbenefAtualizarProdutoPag', error);
            res.status(500).send({ error: 'Erro ao atualizar a base de Figura Fiscal.', details: error });
        }
    }); 
    
  serviceFiscalRouter.post('/cbenefImportarBluesoft', async (req, res) => {
        try {
            

            
            await serviceFiscal.cbenefImportarBluesoft.start(req.query);
            
            res.status(200).send({ message: 'Atualização realizada com sucesso.' });
            
         
        } catch (error) {
            await clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.post/cbenefImportarBluesoft', error);
            res.status(500).send({ error: 'Erro ao importar CBenef do Bluesoft.', details: error });
        }
    }); 

        
  serviceFiscalRouter.post('/cbenefExportarProdutoBluesoft', async (req, res) => {
        try {
            
            await clsTools.pagConsole("Iniciando exportação de produtos para o Bluesoft...",false, false, LOG_FILE_NAME)
            
            await serviceFiscal.cbenefExportarProdutoBluesoft.start(req.body);
            
            res.status(200).send({ message: 'Exportação realizada com sucesso.' });
            
         
        } catch (error) {
            await clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.post/cbenefExportarProdutoBluesoft', error);
            res.status(500).send({ error: 'Erro ao exportar produtos para o Bluesoft.', details: error });
        }
    }); 


  serviceFiscalRouter.post('/atualizacao-pis-cofins', async (req, res) => {
        try {
            
            await clsTools.pagConsole("AMBIENTE FISCAL _ PIS",false, false, LOG_FILE_NAME)

            /*PIS/COFINS*/
                
                await clsTools.pagConsole("AMBIENTE FISCAL | Base PIS",false, false, LOG_FILE_NAME)
                await serviceFiscal.Pis.start();

                await clsTools.pagConsole("AMBIENTE FISCAL | Base COFINS",false, false, LOG_FILE_NAME)
                await serviceFiscal.Cofins.start();

           

            res.status(200).send({ message: 'Base de PIS atualizada com sucesso.' });
        } catch (error) {
            await clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalRouter.post/atualizacao-pis-cofins', error);
            res.status(500).send({ error: 'Erro ao atualizar a base de PIS.', details: error });
        }
    });      


export default serviceFiscalRouter;