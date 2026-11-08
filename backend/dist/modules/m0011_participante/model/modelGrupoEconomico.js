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
const tbgrupoeconomico_1 = __importDefault(require("../tbs/tbgrupoeconomico"));
class modelGrupoEconomico {
    constructor(filter) {
        this.itemGrupoEconomico = new tbgrupoeconomico_1.default();
        this.dadosApi = {};
    }
    lerApiBluesoft(itemApi) {
        return __awaiter(this, void 0, void 0, function* () {
            if (itemApi) {
                this.dadosApi.dados = itemApi;
                this.dadosApi.cdgrupoeconomico = itemApi === null || itemApi === void 0 ? void 0 : itemApi.grupoEconomicoKey;
                this.dadosApi.descricao = itemApi === null || itemApi === void 0 ? void 0 : itemApi.descricao.slice(0, 80).replace("'", "");
                yield this.lerApiBluesoftTiposPgto();
            }
        });
    }
    lerApiBluesoftTiposPgto() {
        return __awaiter(this, void 0, void 0, function* () {
            this.dadosApi.forma_pgto_ref_blue_padrao = `NAO DEFINIDA`;
            this.dadosApi.formaPgtos = [];
            if (this.dadosApi.dados) {
                if (this.dadosApi.dados) {
                    let formaPgtos = [];
                    if (this.dadosApi.dados.tiposDePagamento && this.dadosApi.dados.tiposDePagamento.length > 0) {
                        for (let itemFormaPgto of this.dadosApi.dados.tiposDePagamento) {
                            let item = {
                                forma_pgto_ref_blue: itemFormaPgto === null || itemFormaPgto === void 0 ? void 0 : itemFormaPgto.descricaoTipoPagamento,
                                forma_pgto_padrao: itemFormaPgto === null || itemFormaPgto === void 0 ? void 0 : itemFormaPgto.tipoPagamentoPadrao
                            };
                            if (item.forma_pgto_padrao) {
                                this.dadosApi.forma_pgto_ref_blue_padrao = item.forma_pgto_ref_blue;
                            }
                            formaPgtos.push(item);
                        }
                        this.dadosApi.formaPgtos = formaPgtos;
                    }
                }
            }
        });
    }
    script_update_from_api() {
        let sql = `
                WITH forma_pgto_lookup AS (
                    SELECT 
                        forma_pgto_cd
                    FROM tbforma_pgto_bluesoft
                    WHERE forma_pgto_descricao = '${this.dadosApi.forma_pgto_ref_blue_padrao}'
                    LIMIT 1
                )
                UPDATE tbgrupoeconomico x
                SET 
                        descricao = '${this.dadosApi.descricao.replace("'", "")}'
                    ,   forma_pgto_cd_padrao = (SELECT forma_pgto_cd FROM forma_pgto_lookup)
                    ,   dtlog_update = current_timestamp
                WHERE 
                    x.cdgrupoeconomico = '${this.dadosApi.cdgrupoeconomico}'
                ;
     
     `;
        return sql;
    }
}
exports.default = modelGrupoEconomico;
