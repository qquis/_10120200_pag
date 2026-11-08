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
const modelbase_1 = require("../../../model/modelbase");
const reportContaList_1 = __importDefault(require("../report/reportContaList"));
const reportContaOrigemList_1 = __importDefault(require("../report/reportContaOrigemList"));
const tbresultado_conta_1 = __importDefault(require("../tbs/tbresultado_conta"));
const moderesultado_conta_origem_1 = __importDefault(require("./moderesultado_conta_origem"));
const myclsBase = new modelbase_1.clsBase();
class modelResultaConta extends tbresultado_conta_1.default {
    constructor() {
        super();
        this.r_grupo_descricao = ``;
        this.r_rateio_descricao = ``;
        this.resultadoContaOrigemList = [];
    }
    modelBinding(item) {
        const _super = Object.create(null, {
            binding: { get: () => super.binding }
        });
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                _super.binding.call(this, item);
                this.r_grupo_descricao = item === null || item === void 0 ? void 0 : item.r_grupo_descricao;
                this.r_rateio_descricao = item === null || item === void 0 ? void 0 : item.r_rateio_descricao;
            }
        });
    }
    modelGet(r_conta_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let result = yield reportContaList_1.default.get({ r_conta_cd });
                yield this.modelBinding(result);
                yield this.getInfoResultadoContaOrigem(r_conta_cd);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('modelResultadoConta', "modelPost", e);
            }
        });
    }
    modelPost(dados) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (this.r_conta_cd) {
                    let sql = `UPDATE tbresultado_conta 
                            set r_conta_descricao = '${dados.r_conta_descricao}' 
                            ,   r_conta_lancamento_manual = ${dados.r_conta_lancamento_manual}
                            ,   debitocredito = ${dados.debitocredito}
                            ,   r_rateio_cd = ${dados.r_rateio_cd}
                    WHERE r_conta_cd = ${this.r_conta_cd}
                        `;
                    yield myclsBase.myDataBase.pag.Execute(sql);
                }
                yield this.modelGet(this.r_conta_cd);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('modelResultadoConta', "modelPost", e);
            }
        });
    }
    getInfoResultadoContaOrigem(r_conta_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let result = yield reportContaOrigemList_1.default.get({ r_conta_cd });
                for (const [key, value] of Object.entries(result)) {
                    let item = new moderesultado_conta_origem_1.default();
                    yield item.modelBinding(value);
                    this.resultadoContaOrigemList.push(item);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('modelResultadoConta', "getInfoResultadoContaOrigem", e);
            }
        });
    }
    atualizarCodigoRateio(r_rateio_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = `UPDATE tbresultado_conta SET r_rateio_cd = ${r_rateio_cd}
                       WHERE r_conta_cd = ${this.r_conta_cd}  
                    `;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('modelResultadoConta', "atualizarCodigoRteio", e);
            }
        });
    }
}
exports.default = modelResultaConta;
