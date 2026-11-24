import { Router } from 'express';
import { clsBase, clsTools } from "../../../model/modelbase";


import reportInterface from './report';
const reportInterfaceRouter = Router();

reportInterfaceRouter.get('/interface-dial-venda', async (req, res) => {
    try {
        const result = await reportInterface.reportInterfaceJohnson_Dial_Venda.get(req.query);
        res.send(clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result))
    } catch (e) {
        res.send(clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
});
reportInterfaceRouter.get('/interface-faturamento-item', async (req, res) => {
    try {
        const result = await reportInterface.reportInterfaceFaturamentoItem.get(req.query);
        res.send(clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result))
    } catch (e) {
        res.send(clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
});

reportInterfaceRouter.get('/interface-dial-cliente', async (req, res) => {
    try {
        const result = await reportInterface.reportInterfaceJohnson_Dial_Cliente.get(req.query);
        res.send(clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result))
    } catch (e) {
        res.send(clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
});

reportInterfaceRouter.get('/interface-dial-estoque', async (req, res) => {
    try {
        const result = await reportInterface.reportInterfaceJohnson_Dial_Estoque.get(req.query)
        res.send(clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result))
    } catch (e) {
        res.send(clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
});

reportInterfaceRouter.get('/interface-mtrix-venda', async (req, res) => {
    try {
        const result = await reportInterface.reportInterfaceJohnson_Mtrix_Venda.get(req.query)
        res.send(clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result))
    } catch (e) {
        res.send(clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
});


reportInterfaceRouter.get('/interface-mtrix-cliente', async (req, res) => {
    try {
        const result = await reportInterface.reportInterfaceJohnson_Mtrix_Cliente.get(req.query)
        res.send(clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result))
    } catch (e) {
        res.send(clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
});

reportInterfaceRouter.get('/interface-mtrix-forca-venda', async (req, res) => {
    try {
        const result = await reportInterface.reportInterfaceJohnson_Mtrix_ForcaVenda.get(req.query)
        res.send(clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result))
    } catch (e) {
        res.send(clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
});

reportInterfaceRouter.get('/interface-mtrix-produto', async (req, res) => {
    try {
        const result = await reportInterface.reportInterfaceJohnson_Mtrix_Produto.get(req.query)
        res.send(clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result))
    } catch (e) {
        res.send(clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
});

reportInterfaceRouter.get('/interface-mtrix-estoque', async (req, res) => {
    try {
        const result = await reportInterface.reportInterfaceJohnson_Mtrix_Estoque.get(req.query)
        res.send(clsTools.responseDefault.get(200, `Consulta realizada com sucesso`, result))
    } catch (e) {
        res.send(clsTools.responseDefault.get(500, `Erro ao realizar consulta: ${e}`, null));
    }
});



export default reportInterfaceRouter;