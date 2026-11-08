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
/*Tabela Principal de Participante */
const tbparticipante_1 = __importDefault(require("../tbs/tbparticipante"));
const reportParticipanteRhList_1 = __importDefault(require("../report/reportParticipanteRhList"));
const serviceSistemaPermissao_1 = __importDefault(require("../../../modules/m0001_sistema/service/serviceSistemaPermissao"));
const reportParticipanteVipList_1 = __importDefault(require("../report/reportParticipanteVipList"));
const reportParticipanteBlueSoftList_1 = __importDefault(require("../report/reportParticipanteBlueSoftList"));
/*Tipos de Participantes*/
const dataManager = new modelbase_1.clsBase();
class modelParticipante extends tbparticipante_1.default {
    constructor(filter) {
        super();
        this.listInfo = [];
        this.filter = filter;
    }
    dataBinding() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield this.dataBindingListInfo();
                yield this.dataBindingBase();
                if (this.cdparticipante && this.cdparticipante > 0) {
                    yield this.dataBindingRh();
                    yield this.dataBindingVip();
                    yield this.dataBindingBlueSoft();
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBinding", e);
            }
        });
    }
    dataBindingListInfo() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.listInfo = [
                    { info: "BLUE", resume: "Informações BlueSoft" },
                    { info: "VIP", resume: "Informações VIP/E-commerce" }
                ];
                /* CONFERE SE O USUÁRIO TEM PERMISSÃO PARA VER INFORMAÇÕES RH / DATAMACE */
                if (yield serviceSistemaPermissao_1.default.getFindPermissaoTarefa(this.filter, 99915100)) {
                    this.listInfo.push({ info: "RH", resume: "Informações RH / DATAMACE" });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingListInfo", e);
            }
        });
    }
    dataBindingBase() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = `select 	cdparticipante 
                        ,	nome_razao 
                        ,	email_main
                        ,	celular_dd
                        ,	celular_numero
                    from tbparticipante t
                    where 1 = 1
                    and   t.cdparticipante = ${this.cdparticipante}
                    `;
                if (this.cdparticipante && this.cdparticipante > 0) {
                    let dataItem = yield dataManager.myDataBase.RecordItem(yield dataManager.myDataBase.pag.DataGet(sql), 0);
                    if (dataItem) {
                        this.binding(dataItem);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingBase", e);
            }
        });
    }
    dataBindingRh() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (this.cdparticipante && this.cdparticipante > 0) {
                    this.infoRh = yield reportParticipanteRhList_1.default.get({ cdparticipante: this.cdparticipante });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingRh", e);
            }
        });
    }
    dataBindingVip() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (this.cdparticipante && this.cdparticipante > 0) {
                    this.infoVip = yield reportParticipanteVipList_1.default.get({ cdparticipante: this.cdparticipante });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingVip", e);
            }
        });
    }
    dataBindingBlueSoft() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (this.cdparticipante && this.cdparticipante > 0) {
                    this.infoBlueSoft = yield reportParticipanteBlueSoftList_1.default.get({ cdparticipante: this.cdparticipante });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingBlueSoft", e);
            }
        });
    }
}
exports.default = modelParticipante;
