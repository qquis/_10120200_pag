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
const tbparticipanteBluesoft_1 = __importDefault(require("../tbs/tbparticipanteBluesoft"));
const f0011_01_ParticipanteBlueSoft_CRUD_1 = __importDefault(require("../script/f0011_01_ParticipanteBlueSoft_CRUD"));
const dataManager = new modelbase_1.clsBase();
/*reports*/
const reportParticipanteRhList_1 = __importDefault(require("../report/reportParticipanteRhList"));
const reportParticipanteVipList_1 = __importDefault(require("../report/reportParticipanteVipList"));
const reportParticipanteBlueSoftList_1 = __importDefault(require("../report/reportParticipanteBlueSoftList"));
/*services*/
const serviceSistemaPermissao_1 = __importDefault(require("../../m0001_sistema/service/serviceSistemaPermissao"));
class modelParticipanteRelational {
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
                console.log("modelbaseParticipante.Consultar: data", data);
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
    static getSqlIncluirParticipanteFromRedshift(itemRedShift) {
        return __awaiter(this, void 0, void 0, function* () {
            let script = "";
            try {
                let itemParticipanteBluesoft = new tbparticipanteBluesoft_1.default();
                yield itemParticipanteBluesoft.binding(itemRedShift);
                /*campos adicionais*/
                itemParticipanteBluesoft.email_main = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.email_main;
                itemParticipanteBluesoft.sexo = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.sexo;
                itemParticipanteBluesoft.data_nascimento = modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.data_nascimento, "YYYY-MM-DDTHH:mm:ss"), "YYYY-MM-DD");
                itemParticipanteBluesoft.endereco_cep = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.endereco_cep;
                itemParticipanteBluesoft.endereco_logradouro = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.endereco_logradouro;
                itemParticipanteBluesoft.endereco_numero = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.endereco_numero;
                itemParticipanteBluesoft.endereco_complemento = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.endereco_complemento;
                itemParticipanteBluesoft.endereco_bairro = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.endereco_bairro;
                itemParticipanteBluesoft.endereco_municipio = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.endereco_municipio;
                itemParticipanteBluesoft.endereco_uf = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.endereco_uf;
                itemParticipanteBluesoft.endereco_latitude = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.endereco_latitude;
                itemParticipanteBluesoft.endereco_longitude = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.endereco_longitude;
                itemParticipanteBluesoft.bluesoft_pessoa_data_cadastro = modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.bluesoftpessoa_data_cadastro, "YYYY-MM-DDTHH:mm:ss"), "YYYY-MM-DD");
                itemParticipanteBluesoft.bluesoftpessoastatus = itemRedShift === null || itemRedShift === void 0 ? void 0 : itemRedShift.bluesoftpessoastatus;
                script = f0011_01_ParticipanteBlueSoft_CRUD_1.default.get(itemParticipanteBluesoft);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "RedshiftDataBinding", e);
            }
            finally {
                return script;
            }
        });
    }
}
exports.default = modelParticipanteRelational;
