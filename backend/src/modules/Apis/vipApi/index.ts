import { clsTools, clsBase } from '../../../model/modelbase';
import { Router } from "express";


const vipApi = Router();

import apiVip from './api';


vipApi.get("/", (req, res) => {


    const listmenu = [
        {
            methodo: "GET",
            url: "/clienteslist",
            info: "Exibe os dados da API VIP"
        },
    {
            methodo: "GET",
            url: "/clientesImport",
            info: "Importa dos dados da API VIP"
        },
    ]

    res.send(listmenu);
}) 


vipApi.get("/clientes", async (req, res) => {
    try { 

        const dataAtual = new Date();
        const dataInicial = new Date();
        dataInicial.setDate(dataAtual.getDate() - 60); // 7 dias atrás

        const pag : number = 1;
        const data_ultima_alteracao_ini : string =  clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD");
        const data_ultima_alteracao_fim : string =  clsTools._datemomentDateToStr(dataAtual, "YYYY-MM-DD");


        let result = await apiVip.clientes.get({page: pag
            , data_ultima_alteracao_ini: data_ultima_alteracao_ini
            , data_ultima_alteracao_fim: data_ultima_alteracao_fim})
   

        res.send(result) ;


    } catch (e: any) {
        clsTools.pagConsole(`modules | CRM VIP | Error \n ${e.message}`);
        res.status(500).send({ error: e.message });
    }
}) 



export default vipApi;