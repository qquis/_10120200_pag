import {Router, Request, Response, NextFunction } from "express";
import 'dotenv/config'
import { clsTools } from "../model/modelbase";

// ---- Rotas ---- /
import faturamentoZanthus  from '../modules/m0055_faturamento_zanthus'
import routerFaturamentoBluesoft from "../modules/m0050_faturamento_bluesoft";
import faturamento from "../modules/m0070_faturamento";
import guardianticket from '../modules/m0062_guardianticket'
import estatistica from "../modules/m0150_estatistica"
import preco from "../modules/m0045_preco"
import Notificacao from "../modules/m0210_notificacao";

import sistema_batch from "../modules/m9030_sistema_batch";
import sistema_log from "../modules/m9020_sistema_log"
import sistemaRouter from "../modules/m0001_sistema";


import Integracao from "../modules/m0095_integracao";
//import bluesoftApi from "../modules/Apis/bluesoftApi";
import m0020_produto from  "../modules/m0020_produto";



// ---- Rotas com numeração ---- /


import apis from "../modules/Apis";
import m0002_enterprise from "../modules/m0002_enterprise";
import m0141_Rh from "../modules/m0141_rh";
import m0100_Resultado from "../modules/m0100_resultado";
import m0080_financeiro from "../modules/m0080_financeiro";
import m0011_participante from "../modules/m0011_participante";
import m0090_crm from "../modules/m0090_crm";
import m0040_fiscal from "../modules/m0040_fiscal";
import m0021_produtobluesoft from "../modules/m0021_produtobluesoft";
import m0051_faturamentoVip from "../modules/m0051_faturamento_vip";
import m0085_zanthus from "../modules/m0085_zanthus";
import m0104_ForcaVenda from "../modules/m0004_forcavenda";
import m0030_estoquecusto from "../modules/m0030_EstoqueCusto";
import m1000_informe from "../modules/m1000_informe";
import m0005_forcaVendaMetaRouter from "../modules/m0005_forcavenda_meta";
import m0071_interface from "../modules/m0071_interface";

// BASE EXTERNA /
import externalZanthusRouter from "../modules.external/zanthus/index";

const router = Router();


const middlewareUSER = async (request: Request, response: Response, next: NextFunction) => {
    
    try {

        let validarHeader : number = 1
            validarHeader = parseInt(`${process.env.HEADER_TOCKEN_PERSIST? process.env.HEADER_TOCKEN_PERSIST : 1}`)

        //console.log(request.headers.length)
        //console.log(request.headers)


        let usuario_login_uuid = request.headers.usuario_login_uuid || request.headers['usuario-login-uuid'] 
        let user_name = request.headers.user_name || request.headers['user-name'] 
        let user_credential = request.headers.user_credential || request.headers['user-credential'] 
        let sis_ac_cd = request.headers.sis_ac_cd || request.headers['sis-ac-cd'] 
        let sis_cd = request.headers.sis_cd || request.headers['sis-cd'] 
        let sis_us_seq = request.headers.sis_us_seq || request.headers['sis-us-seq'] 

        
        const systemUserConnect = { 
            usuario_login_uuid : usuario_login_uuid as string,
            user_name : user_name as string,
            user_credential : `${user_credential}`.substring(0,14) as string,
            sis_ac_cd : sis_ac_cd as string,
            sis_cd: sis_cd as string,
            sis_us_seq: sis_us_seq as string
        }

        //console.log(request.headers)


        request.query.__systemUserConnect = systemUserConnect
        



        if (validarHeader == 1)
        {

            //if(request.header("x-customtoken") === "10003ff9ec87814c80c505e8ccd80c43b6ff620b") {
            if(request.header("x-customtoken") === `${process.env.HEADER_TOCKEN}`) {
                next() 
            }
            else {
                clsTools.pagConsole(`Token inválido: ${request.header("x-customtoken")} User-Agent: ${request.header("User-Agent")}`, true);
                clsTools.pagConsole(`Esperado: ${process.env.HEADER_TOCKEN} informado ${request.header("x-customtoken")}`, true);
                response.status(400).send({status: 0, info: "tocket invalid"})
            }

        } else {
            next();
        }
        

    } catch(e) {
        response.status(400).send({status: 0, info: "tocket invalid"})

    }
}



router.use('/', middlewareUSER)
router.get("/status", async(request: Request, response: Response) => {
    return response.status(200).send({status : "1", info : "BackEnd - Ativo"})
})
router.get("/", async(request: Request, response: Response) => {

    const help = [
        { 
            url : "/login", 
            info : "Informações sobre login"
        },
        {
            url : "/faturamento", 
            info : "M0055 | faturamento - informações sobre faturamento"
        } 
    ]

    return response.send(help)
})




router.use('/', guardianticket)
router.use('/', estatistica)
router.use("/apis", apis)
router.use('/sistema', sistemaRouter)
router.use('/faturamentozanthus', faturamentoZanthus) 
router.use('/faturamentobluesoft', routerFaturamentoBluesoft)
router.use('/faturamento', faturamento)
router.use('/preco/', preco)
router.use('/notificacao', Notificacao)
router.use("/sistema_batch", sistema_batch)
router.use("/sistema_log", sistema_log)
router.use("/financeiro", m0080_financeiro)
router.use("/integracao", Integracao)
router.use("/produto", m0020_produto)
router.use('/produtobluesoft', m0021_produtobluesoft);
router.use('/rh', m0141_Rh)
router.use('/resultado', m0100_Resultado)
router.use('/zanthus', m0085_zanthus)
router.use('/enterprise', m0002_enterprise);
router.use('/participante',m0011_participante);
router.use('/faturamentovip', m0051_faturamentoVip);
router.use('/crm', m0090_crm);
router.use('/fiscal', m0040_fiscal);
router.use('/forcavenda', m0104_ForcaVenda);
router.use('/external/zanthus', externalZanthusRouter);
router.use('/estoquecusto', m0030_estoquecusto);
router.use('/informativo', m1000_informe);
router.use('/forca-venda-meta', m0005_forcaVendaMetaRouter);
router.use('/interface', m0071_interface)


export default router;