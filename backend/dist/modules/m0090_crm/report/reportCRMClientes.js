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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const model_ParticipanteCrm_1 = __importDefault(require("src/modules/m0011_participante/model/model_ParticipanteCrm"));
const _base_1 = require("@base");
class reportCRMClientes {
    static sql(parametros) {
        let sql = `
                        select      p.crm_seq
                                ,   p.cdparticipante
                                ,   p.crm_status_cd 
                                ,   s.crm_status_descricao
                                ,   p.crm_email 
                                ,   p.crm_dt_cadastro 
                                ,   p.cpf 
                                ,   p.nome 
                                ,   p.sobre_nome 
                                ,   p.data_nascimento 
                                ,   p.pf_sexo 
                                ,   p.endereco_cep 
                                ,   p.endereco_logradouro
                                ,   p.endereco_numero
                                ,   p.endereco_complemento
                                ,   p.endereco_municipio 
                                ,   p.endereco_uf
                        from       tbparticipante_crm p
                        left join  tbparticipante_crm_status s on s.crm_status_cd = p.crm_status_cd

                        where 1 = 1
                        ${parametros.cdparticipante ? ` and p.cdparticipante = ${parametros.cdparticipante} ` : ''}
                        ${parametros.crm_status_cd ? ` and p.crm_status_cd = ${parametros.crm_status_cd} ` : ''}
                        ${parametros.dt_cadastro_inicio ? ` and p.crm_dt_cadastro >= '${parametros.dt_cadastro_inicio}' ` : ''}
                        ${parametros.dt_cadastro_fim ? ` and p.crm_dt_cadastro <= '${parametros.dt_cadastro_fim}' ` : ''}
                        
                `;
        return sql;
    }
    static get(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let list = [];
            try {
                const modeldb = new _base_1.clsBase();
                let result = yield modeldb.myDataBase.pag.DataGet(this.sql(parametros));
                try {
                    for (var _d = true, _e = __asyncValues(result.entries()), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let model = new model_ParticipanteCrm_1.default();
                        model.binding(value);
                        list.push(model);
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
            }
            catch (e) {
            }
            finally {
                return list;
            }
        });
    }
}
exports.default = reportCRMClientes;
