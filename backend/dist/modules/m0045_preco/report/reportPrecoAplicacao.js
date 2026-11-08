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
const model_1 = require("../../../model/model");
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const f0045_10_preco_aplicacao_list_1 = __importDefault(require("../pgscripts/f0045_10_preco_aplicacao_list"));
class reportPrecoAplicacao extends model_1.mdoReport {
    constructor() {
        super();
        this.Filtros = {
            tipo_relatorio: "PERSONALIZADO",
            tab_pre_cd: 0,
            data_log_filter: 0,
            data_log_ini: Tools_1.default.pagDateTime_getDate(),
            data_log_fim: Tools_1.default.pagDateTime_getDate(),
            pr_cdproduto: 0,
            prb_cdprodutobluesoft_unitario: 0,
            prb_cdprodutobluesoft: 0,
            pr_descricao: "",
            prb_descricao: "",
            tipo_produto: "UNITARIO",
            data_agendamento_filter: 0,
            data_agendamento_inicial: Tools_1.default.pagDateTime_getDate(),
            data_agendamento_final: Tools_1.default.pagDateTime_getDate()
        };
    }
    filterset(request) {
        var _a, _b;
        try {
            let tipo_relatorio = `INTEGRACAO_BLUESOFT_PENDENTE`;
            let tab_pre_cd = 0;
            let data_log_filter = 0;
            let data_log_ini = Tools_1.default.pagDateTime_getDate();
            let data_log_fim = Tools_1.default.pagDateTime_getDate();
            let pr_cdproduto = 0;
            let prb_cdprodutobluesoft_unitario = 0;
            let prb_cdprodutobluesoft = 0;
            let pr_descricao = ``;
            let prb_descricao = ``;
            let tipo_produto = `UNITARIO`;
            let data_agendamento_filter = 0;
            let data_agendamento_inicial = Tools_1.default.pagDateTime_getDate();
            let data_agendamento_final = Tools_1.default.pagDateTime_getDate();
            if (request) {
                if (request.body !== undefined) {
                    tipo_relatorio = request.body.tipo_relatorio ? request.body.tipo_relatorio : "LOG_BLUE_D1";
                    tab_pre_cd = request.body.tab_pre_cd ? request.body.tab_pre_cd : 0;
                    data_log_filter = request.body.data_log_filter ? parseInt(request.body.data_log_filter) : 0;
                    data_log_ini = request.body.data_log_ini ? Tools_1.default.Date_br_new(`${(_a = request.body) === null || _a === void 0 ? void 0 : _a.data_log_ini}`) : Tools_1.default.pagDateTime_getDate();
                    data_log_fim = request.body.data_log_fim ? Tools_1.default.Date_br_new(`${(_b = request.body) === null || _b === void 0 ? void 0 : _b.data_log_fim}`) : Tools_1.default.pagDateTime_getDate();
                    pr_cdproduto = request.body.pr_cdproduto ? parseInt(request.body.pr_cdproduto) : 0;
                    prb_cdprodutobluesoft_unitario = request.body.prb_cdprodutobluesoft_unitario ? parseInt(request.body.prb_cdprodutobluesoft_unitario) : 0;
                    prb_cdprodutobluesoft = request.body.prb_cdprodutobluesoft ? parseInt(request.body.prb_cdprodutobluesoft) : 0;
                    pr_descricao = request.body.pr_descricao ? request.body.pr_descricao : ``;
                    prb_descricao = request.body.prb_descricao ? request.body.pr_descricao : ``;
                    tipo_produto = request.body.tipo_produto ? request.body.tipo_produto : ``;
                }
            }
            this.Filtros = {
                tipo_relatorio,
                tab_pre_cd,
                data_log_filter,
                data_log_ini,
                data_log_fim,
                pr_cdproduto,
                prb_cdprodutobluesoft_unitario,
                prb_cdprodutobluesoft,
                pr_descricao,
                prb_descricao,
                tipo_produto,
                data_agendamento_filter,
                data_agendamento_inicial,
                data_agendamento_final
            };
        }
        catch (e) {
            throw Error(`Report | Filter_Get Error ${e}`);
        }
    }
    dataPag_get(request) {
        const _super = Object.create(null, {
            dataPag_get: { get: () => super.dataPag_get }
        });
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (request)
                    this.filterset(request);
                const result = yield _super.dataPag_get.call(this, f0045_10_preco_aplicacao_list_1.default.SELECT(this.Filtros));
                return result;
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`Reports | Error \n ${e}`);
                return [];
            }
        });
    }
}
exports.default = reportPrecoAplicacao;
