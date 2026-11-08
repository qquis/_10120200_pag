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
const tbparticipante_crm_1 = __importDefault(require("../tbs/tbparticipante_crm"));
const f0011_20_ParticipanteCrm_CRUD_1 = __importDefault(require("../script/f0011_20_ParticipanteCrm_CRUD"));
let myDataBase = new modelbase_1.clsBase();
class modelParticipante_Crm extends tbparticipante_crm_1.default {
    constructor() {
        super();
    }
    consultar(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result;
            try {
                let crm_email = (parametro === null || parametro === void 0 ? void 0 : parametro.crm_email) || '';
                if (!crm_email) {
                    throw new Error("E-mail do CRM não informado");
                }
                let sql = `select 	c.crm_seq					
                            ,	c.crm_status_cd			
                            ,	c.crm_email				
                            ,	c.crm_dt_cadastro			
                            ,	c.cpf						
                            ,	c.cdparticipante 			
                            ,	c.nome					
                            ,	c.sobre_nome
                            ,   c.data_nascimento				
                            ,   c.pf_sexo
                            ,   x.pf_sexo_descricao
                        from        tbparticipante_crm c
                        left join   tbparticipante_pf_sexo x on x.pf_sexo = coalesce(c.pf_sexo, 'N')   
                        where 1 = 1
                        and   crm_email = '${crm_email}'
                        `;
                result = yield myDataBase.myDataBase.RecordItem(yield myDataBase.myDataBase.pag.DataGet(sql), 0);
                this.binding(result);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("M0090_ParticipanteCRM", "modelParticipanteCrm _ consultar", e);
                throw e;
            }
            finally {
                if (result) {
                    this.binding(result);
                }
            }
        });
    }
    checkExists(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let chekExist = false;
            try {
                this.crm_seq = 0;
                yield this.consultar(parametro);
                if (this.crm_seq > 0) {
                    chekExist = true;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("M0090_ParticipanteCRM", "modelParticipanteCrm _ conferirCadastro", e);
                throw e;
            }
            finally {
                return chekExist;
            }
        });
    }
    incluir(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let registroIncluidoComSucesso = false;
            try {
                let result = yield myDataBase.myDataBase.RecordItem(yield myDataBase.myDataBase.pag.DataGet(f0011_20_ParticipanteCrm_CRUD_1.default.get(parametro)), 0);
                if (result) {
                    this.binding(result);
                    registroIncluidoComSucesso = true;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("M0090_ParticipanteCRM", "modelParticipanteCrm _ incluir", e);
                throw e;
            }
            finally {
                return registroIncluidoComSucesso;
            }
        });
    }
}
exports.default = modelParticipante_Crm;
