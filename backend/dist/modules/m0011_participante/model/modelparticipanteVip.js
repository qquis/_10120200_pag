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
const tbparticipanteVip_1 = __importDefault(require("../tbs/tbparticipanteVip"));
const f0011_15_ParticipanteVip_CRUD_1 = __importDefault(require("../script/f0011_15_ParticipanteVip_CRUD"));
const api_1 = __importDefault(require("../../Apis/vipApi/api"));
class modelparticipanteVip extends tbparticipanteVip_1.default {
    constructor() {
        super();
    }
    getApi(id) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let ClienteVipApi = yield api_1.default.clientes.get({ id: id, page: 1 });
                this.dataBindingAPI(ClienteVipApi);
                let myData = new modelbase_1.clsBase();
                yield myData.myDataBase.pag.Execute(this.vip_getSqlCrud());
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`F0011 - Participante`, `modelparticipante_vip.getApi()`, e, true);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
        });
    }
    dataBindingAPI(item) {
        if (item) {
            this.vip_id = item === null || item === void 0 ? void 0 : item.id;
            this.vip_cliente_id = item === null || item === void 0 ? void 0 : item.vipcommerce_cliente_id;
            this.vip_cpf_cnpj = (item === null || item === void 0 ? void 0 : item.cpf_cnpj) ? item === null || item === void 0 ? void 0 : item.cnpj : item === null || item === void 0 ? void 0 : item.cpf;
            this.vip_data_nascimento = modelbase_1.clsTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.data_nascimento, "YYYY-MM-DD");
            this.vip_nome = item === null || item === void 0 ? void 0 : item.nome;
            this.vip_sobre_nome = item === null || item === void 0 ? void 0 : item.sobrenome;
            this.vip_nome_completo = item === null || item === void 0 ? void 0 : item.nome_completo;
            this.vip_telefone_celular = item === null || item === void 0 ? void 0 : item.telefone_celular;
            this.vip_email = item === null || item === void 0 ? void 0 : item.email;
        }
    }
    vip_binding_api(item) {
        this.vip_cpf_cnpj = (item === null || item === void 0 ? void 0 : item.cpf_cnpj) ? item === null || item === void 0 ? void 0 : item.cnpj : item === null || item === void 0 ? void 0 : item.cpf;
        this.dataBindingAPI(item);
    }
    vip_getSqlCrud() {
        let parametros = {
            vip_id: this.vip_id,
            vip_cliente_id: this.vip_cliente_id,
            vvip_cpf_cnpj: this.vip_cpf_cnpj,
            vvip_nome_completo: this.vip_nome_completo,
            vvip_data_nascimento: this.vip_data_nascimento,
            vvip_cpf: this.vip_cpf,
            vvip_cnpj: this.vip_cnpj,
            vcdparticipante: 0,
            vvip_nome: this.vip_nome,
            vvip_sobre_nome: this.vip_sobre_nome,
            vvip_email: this.vip_email,
            vvip_telefone_celular: this.vip_telefone_celular
        };
        return f0011_15_ParticipanteVip_CRUD_1.default.get(parametros);
    }
}
exports.default = modelparticipanteVip;
