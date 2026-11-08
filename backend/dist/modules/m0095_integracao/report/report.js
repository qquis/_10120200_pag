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
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const model_1 = require("../../../model/model");
/* Script */
const f0095_10_report_integracaoproduto_1 = __importDefault(require("../pgscripts/f0095_10_report_integracaoproduto"));
class reportIntegracao extends model_1.mdoReport {
    constructor(request) {
        super();
        this.IntegracaoFiltro = {
            integracao_cd: 0,
            integracao_tipo_cd: 0,
            integracao_status_cd: 0
        };
        this.IntegracaoProdutoFiltro = {
            integracao_cd: 0,
            integracao_tipo_cd: 0,
            integracao_status_cd: 0,
            pr_cdproduto: 0,
            prb_cdprodutobluesoftunitario: 0,
            prb_cdprodutobluesoft: 0
        };
        /*Averiguar Filtros no Body do Request*/
        this.getRequest(request);
        this.getRequest(request);
    }
    getRequest(request) {
        let integracao_cd = 0;
        let integracao_tipo_cd = 0;
        let integracao_status_cd = 0;
        let pr_cdproduto = 0;
        let prb_cdprodutobluesoftunitario = 0;
        let prb_cdprodutobluesoft = 0;
        if (request) {
            integracao_cd = request.body.integracao_cd ? parseInt(request.body.integracao_cd) : 0;
            integracao_tipo_cd = request.body.integracao_tipo_cd ? parseInt(request.body.integracao_tipo_cd) : 0;
            integracao_status_cd = request.body.integracao_status_cd ? parseInt(request.body.integracao_status_cd) : 0;
            pr_cdproduto = request.body.pr_cdproduto ? parseInt(request.body.pr_cdproduto) : 0;
            prb_cdprodutobluesoftunitario = request.body.prb_cdprodutobluesoftunitario ? parseInt(request.body.prb_cdprodutobluesoftunitario) : 0;
            prb_cdprodutobluesoft = request.body.prb_cdprodutobluesoft ? parseInt(request.body.prb_cdprodutobluesoft) : 0;
        }
        this.IntegracaoFiltro = {
            integracao_cd,
            integracao_tipo_cd,
            integracao_status_cd
        };
        this.IntegracaoProdutoFiltro = {
            integracao_cd,
            integracao_tipo_cd,
            integracao_status_cd,
            pr_cdproduto,
            prb_cdprodutobluesoftunitario,
            prb_cdprodutobluesoft
        };
    }
    reportIntegracaoTipoProduto() {
        const _super = Object.create(null, {
            dataPag_get: { get: () => super.dataPag_get }
        });
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const result = yield _super.dataPag_get.call(this, f0095_10_report_integracaoproduto_1.default.SELECT(this.IntegracaoProdutoFiltro));
                return result;
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`Reports | Error \n ${e}`);
                return [];
            }
        });
    }
}
exports.default = reportIntegracao;
