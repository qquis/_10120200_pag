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
const f0011_01_ParticipanteBlueSoft_CRUD_1 = __importDefault(require("../script/f0011_01_ParticipanteBlueSoft_CRUD"));
const dataManager = new modelbase_1.clsBase();
/*reports*/
const reportParticipanteRhList_1 = __importDefault(require("../report/reportParticipanteRhList"));
const reportParticipanteVipList_1 = __importDefault(require("../report/reportParticipanteVipList"));
const reportParticipanteBlueSoftList_1 = __importDefault(require("../report/reportParticipanteBlueSoftList"));
/*services*/
const serviceSistemaPermissao_1 = __importDefault(require("../../m0001_sistema/service/serviceSistemaPermissao"));
class modelParticipanteBase {
    static Consultar(par) {
        return __awaiter(this, void 0, void 0, function* () {
            let data = {};
            try {
                data = yield this.ConsultarParticipante(par);
                data.listInfo = yield this.ConsultarListInfo(par);
                if (data && data.cdparticipante && data.cdparticipante > 0) {
                    data.infoRh = yield this.ConsultarParticipanteRh(par);
                    data.infoVip = yield this.ConsultarParticipanteVIP(par);
                    data.infoBlueSoft = yield this.ConsultarParticipanteBlueSoft(par);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBinding", e);
            }
            finally {
                return data;
            }
        });
    }
    static ConsultarListInfo(par) {
        return __awaiter(this, void 0, void 0, function* () {
            let listInfo = [
                { info: "BLUE", resume: "Informações BlueSoft" },
                { info: "VIP", resume: "Informações VIP/E-commerce" }
            ];
            try {
                /* CONFERE SE O USUÁRIO TEM PERMISSÃO PARA VER INFORMAÇÕES RH / DATAMACE */
                if (yield serviceSistemaPermissao_1.default.getFindPermissaoTarefa(par, 99915100)) {
                    listInfo.push({ info: "RH", resume: "Informações RH / DATAMACE" });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingListInfo", e);
            }
            finally {
                return listInfo;
            }
        });
    }
    static ConsultarParticipante(par) {
        return __awaiter(this, void 0, void 0, function* () {
            let ParticipantePag = null;
            try {
                let sql = `select 	cdparticipante 
                        ,	nome_razao 
                        ,	email_main
                        ,	celular_dd
                        ,	celular_numero
                    from tbparticipante t
                    where 1 = 1
                    and   t.cdparticipante = ${par.cdparticipante}
                    `;
                if (par.cdparticipante && par.cdparticipante > 0) {
                    let dataItem = yield dataManager.myDataBase.RecordItem(yield dataManager.myDataBase.pag.DataGet(sql), 0);
                    if (dataItem) {
                        ParticipantePag = dataItem;
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingBase", e);
            }
            finally {
                return ParticipantePag;
            }
        });
    }
    static ConsultarParticipanteRh(par) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (par.cdparticipante && par.cdparticipante > 0) {
                    return yield reportParticipanteRhList_1.default.get({ cdparticipante: par.cdparticipante });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingRh", e);
            }
        });
    }
    static ConsultarParticipanteVIP(par) {
        return __awaiter(this, void 0, void 0, function* () {
            let ParticipanteVIP = null;
            try {
                if (par.cdparticipante && par.cdparticipante > 0) {
                    ParticipanteVIP = yield reportParticipanteVipList_1.default.get({ cdparticipante: par.cdparticipante });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingVip", e);
            }
            finally {
                return ParticipanteVIP;
            }
        });
    }
    static ConsultarParticipanteBlueSoft(par) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (par.cdparticipante && par.cdparticipante > 0) {
                    return yield reportParticipanteBlueSoftList_1.default.get({ cdparticipante: par.cdparticipante });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingBlueSoft", e);
            }
        });
    }
    static ScriptIncluirParticipanteBlueSoft(itemRedShift_1) {
        return __awaiter(this, arguments, void 0, function* (itemRedShift, source = "REDSHIFT") {
            let script = "";
            try {
                script = f0011_01_ParticipanteBlueSoft_CRUD_1.default.get(itemRedShift, source);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "ScriptIncluirParticipanteBlueSoft", e);
            }
            finally {
                return script;
            }
        });
    }
}
exports.default = modelParticipanteBase;
