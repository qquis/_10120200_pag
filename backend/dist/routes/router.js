"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = require("express");
require("dotenv/config");
const modelbase_1 = require("../model/modelbase");
// ---- Rotas ---- /
const m0055_faturamento_zanthus_1 = __importDefault(require("../modules/m0055_faturamento_zanthus"));
const m0050_faturamento_bluesoft_1 = __importDefault(require("../modules/m0050_faturamento_bluesoft"));
const m0070_faturamento_1 = __importDefault(require("../modules/m0070_faturamento"));
const m0062_guardianticket_1 = __importDefault(require("../modules/m0062_guardianticket"));
const m0150_estatistica_1 = __importDefault(require("../modules/m0150_estatistica"));
const m0045_preco_1 = __importDefault(require("../modules/m0045_preco"));
const m0210_notificacao_1 = __importDefault(require("../modules/m0210_notificacao"));
const m9030_sistema_batch_1 = __importDefault(require("../modules/m9030_sistema_batch"));
const m9020_sistema_log_1 = __importDefault(require("../modules/m9020_sistema_log"));
const m0001_sistema_1 = __importDefault(require("../modules/m0001_sistema"));
const m0095_integracao_1 = __importDefault(require("../modules/m0095_integracao"));
//import bluesoftApi from "../modules/Apis/bluesoftApi";
const m0020_produto_1 = __importDefault(require("../modules/m0020_produto"));
// ---- Rotas com numeração ---- /
const Apis_1 = __importDefault(require("../modules/Apis"));
const m0002_enterprise_1 = __importDefault(require("../modules/m0002_enterprise"));
const m0141_rh_1 = __importDefault(require("../modules/m0141_rh"));
const m0100_resultado_1 = __importDefault(require("../modules/m0100_resultado"));
const m0080_financeiro_1 = __importDefault(require("../modules/m0080_financeiro"));
const m0011_participante_1 = __importDefault(require("../modules/m0011_participante"));
const m0090_crm_1 = __importDefault(require("../modules/m0090_crm"));
const m0040_fiscal_1 = __importDefault(require("../modules/m0040_fiscal"));
const m0021_produtobluesoft_1 = __importDefault(require("../modules/m0021_produtobluesoft"));
const m0051_faturamento_vip_1 = __importDefault(require("../modules/m0051_faturamento_vip"));
const m0085_zanthus_1 = __importDefault(require("../modules/m0085_zanthus"));
const m0004_forcavenda_1 = __importDefault(require("../modules/m0004_forcavenda"));
const m0030_EstoqueCusto_1 = __importDefault(require("../modules/m0030_EstoqueCusto"));
const m1000_informe_1 = __importDefault(require("../modules/m1000_informe"));
const m0005_forcavenda_meta_1 = __importDefault(require("../modules/m0005_forcavenda_meta"));
const m0071_interface_1 = __importDefault(require("../modules/m0071_interface"));
// BASE EXTERNA /
const index_1 = __importDefault(require("../modules.external/zanthus/index"));
const router = (0, express_1.Router)();
const middlewareUSER = (request, response, next) => __awaiter(void 0, void 0, void 0, function* () {
    try {
        let validarHeader = 1;
        validarHeader = parseInt(`${process.env.HEADER_TOCKEN_PERSIST ? process.env.HEADER_TOCKEN_PERSIST : 1}`);
        //console.log(request.headers.length)
        //console.log(request.headers)
        let usuario_login_uuid = request.headers.usuario_login_uuid || request.headers['usuario-login-uuid'];
        let user_name = request.headers.user_name || request.headers['user-name'];
        let user_credential = request.headers.user_credential || request.headers['user-credential'];
        let sis_ac_cd = request.headers.sis_ac_cd || request.headers['sis-ac-cd'];
        let sis_cd = request.headers.sis_cd || request.headers['sis-cd'];
        let sis_us_seq = request.headers.sis_us_seq || request.headers['sis-us-seq'];
        const systemUserConnect = {
            usuario_login_uuid: usuario_login_uuid,
            user_name: user_name,
            user_credential: `${user_credential}`.substring(0, 14),
            sis_ac_cd: sis_ac_cd,
            sis_cd: sis_cd,
            sis_us_seq: sis_us_seq
        };
        //console.log(request.headers)
        request.query.__systemUserConnect = systemUserConnect;
        if (validarHeader == 1) {
            //if(request.header("x-customtoken") === "10003ff9ec87814c80c505e8ccd80c43b6ff620b") {
            if (request.header("x-customtoken") === `${process.env.HEADER_TOCKEN}`) {
                next();
            }
            else {
                modelbase_1.clsTools.pagConsole(`Token inválido: ${request.header("x-customtoken")} User-Agent: ${request.header("User-Agent")}`, true);
                modelbase_1.clsTools.pagConsole(`Esperado: ${process.env.HEADER_TOCKEN} informado ${request.header("x-customtoken")}`, true);
                response.status(400).send({ status: 0, info: "tocket invalid" });
            }
        }
        else {
            next();
        }
    }
    catch (e) {
        response.status(400).send({ status: 0, info: "tocket invalid" });
    }
});
router.use('/', middlewareUSER);
router.get("/status", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    return response.status(200).send({ status: "1", info: "BackEnd - Ativo" });
}));
router.get("/", (request, response) => __awaiter(void 0, void 0, void 0, function* () {
    const help = [
        {
            url: "/login",
            info: "Informações sobre login"
        },
        {
            url: "/faturamento",
            info: "M0055 | faturamento - informações sobre faturamento"
        }
    ];
    return response.send(help);
}));
router.use('/', m0062_guardianticket_1.default);
router.use('/', m0150_estatistica_1.default);
router.use("/apis", Apis_1.default);
router.use('/sistema', m0001_sistema_1.default);
router.use('/faturamentozanthus', m0055_faturamento_zanthus_1.default);
router.use('/faturamentobluesoft', m0050_faturamento_bluesoft_1.default);
router.use('/faturamento', m0070_faturamento_1.default);
router.use('/preco/', m0045_preco_1.default);
router.use('/notificacao', m0210_notificacao_1.default);
router.use("/sistema_batch", m9030_sistema_batch_1.default);
router.use("/sistema_log", m9020_sistema_log_1.default);
router.use("/financeiro", m0080_financeiro_1.default);
router.use("/integracao", m0095_integracao_1.default);
router.use("/produto", m0020_produto_1.default);
router.use('/produtobluesoft', m0021_produtobluesoft_1.default);
router.use('/rh', m0141_rh_1.default);
router.use('/resultado', m0100_resultado_1.default);
router.use('/zanthus', m0085_zanthus_1.default);
router.use('/enterprise', m0002_enterprise_1.default);
router.use('/participante', m0011_participante_1.default);
router.use('/faturamentovip', m0051_faturamento_vip_1.default);
router.use('/crm', m0090_crm_1.default);
router.use('/fiscal', m0040_fiscal_1.default);
router.use('/forcavenda', m0004_forcavenda_1.default);
router.use('/external/zanthus', index_1.default);
router.use('/estoquecusto', m0030_EstoqueCusto_1.default);
router.use('/informativo', m1000_informe_1.default);
router.use('/forca-venda-meta', m0005_forcavenda_meta_1.default);
router.use('/interface', m0071_interface_1.default);
exports.default = router;
