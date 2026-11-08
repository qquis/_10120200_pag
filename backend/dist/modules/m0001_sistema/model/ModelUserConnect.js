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
const reportSistemaPermissaoList_1 = __importDefault(require("../report/reportSistemaPermissaoList"));
class ModelUserConnect extends modelbase_1.clsBase {
    constructor() {
        super();
        this.sis_us_seq = 0;
        this.email_main = '';
        this.password = '';
        this.user_name = '';
        this.cdparticipante = 0;
        this.cdpessoabluesoft = 0;
        this.nome_razao = ``;
        this.PermissaoList = [];
    }
    consultar(sis_us_seq, sis_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (sis_us_seq == 0)
                    throw new Error(`ModelUserConnect | Consultar : sis_us_seq não informado`);
                let sql = `SELECT        u.sis_us_seq 
                            ,         u.user_name 
                            ,         u.data_cadastro 
                            ,         p.cdparticipante 
                            ,         p.nome_razao 
                            ,         p.cdpessoabluesoft 
                            ,         p.email_main 
                        FROM          tbsistema_usuario       u 
                        inner join    tbparticipante_bluesoft b on b.cdpessoabluesoft = u.cdpessoabluesoft 
                        inner join    tbparticipante          p on p.cdparticipante = b.cdparticipante 
                        where         sis_us_seq = ${sis_us_seq}
                       `;
                let resultItem = yield this.myDataBase.RecordItem(yield this.myDataBase.pag.DataGet(sql), 0);
                if (resultItem) {
                    this.sis_us_seq = resultItem === null || resultItem === void 0 ? void 0 : resultItem.sis_us_seq;
                    this.email_main = resultItem === null || resultItem === void 0 ? void 0 : resultItem.email_main;
                    this.user_name = resultItem === null || resultItem === void 0 ? void 0 : resultItem.user_name;
                    this.nome_razao = resultItem === null || resultItem === void 0 ? void 0 : resultItem.nome_razao;
                    this.cdparticipante = resultItem === null || resultItem === void 0 ? void 0 : resultItem.cdparticipante;
                    this.cdpessoabluesoft = resultItem === null || resultItem === void 0 ? void 0 : resultItem.cdpessoabluesoft;
                    yield this.permissoesGet(sis_cd);
                }
            }
            catch (e) {
                this.myTools.PagErrorException('ModelUserConnect', 'consultar', e);
            }
        });
    }
    permissoesGet(sis_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.PermissaoList = yield reportSistemaPermissaoList_1.default.getModel({ sis_us_seq: this.sis_us_seq, sis_cd: sis_cd });
            }
            catch (e) {
                this.myTools.PagErrorException('ModelUserConnect', 'consultar', e);
            }
        });
    }
}
exports.default = ModelUserConnect;
