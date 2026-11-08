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
Object.defineProperty(exports, "__esModule", { value: true });
const model_1 = require("src/model/model");
class tbnotificacao_grupo extends model_1.modelTb {
    constructor() {
        super();
        this.notificacao_grupo_cd = 0;
        this.notificacao_cd = 0;
        this.notificacao_gp_whats = ``;
        this.notificacao_gp_email = ``;
        this.notificacao_grupo_descricao = ``;
        this.notificacao_celular_dd_numero_registro = ``;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item != undefined) {
                    this.notificacao_cd = item.notificacao;
                    this.notificacao_grupo_cd = item === null || item === void 0 ? void 0 : item.notificacao_grupo_cd;
                    this.notificacao_gp_whats = item === null || item === void 0 ? void 0 : item.notificacao_gp_whats;
                    this.notificacao_gp_email = item === null || item === void 0 ? void 0 : item.notificacao_gp_email;
                    this.notificacao_grupo_descricao = item === null || item === void 0 ? void 0 : item.notificacao_grupo_descricao;
                    this.notificacao_celular_dd_numero_registro = item === null || item === void 0 ? void 0 : item.notificacao_celular_dd_numero_registro;
                }
            }
            catch (e) {
                throw new Error(`Erro ${e}`);
            }
        });
    }
    _Db_Pg_script_Insert() {
        return ` INSERT INTO tbnotificacao_grupo 
                        (
                            , notificacao_grupo_cd 
                            , notificacao_cd 
                            , notificacao_gp_whats 
                            , notificacao_gp_email 
                            , notificacao_grupo_descricao 
                            , notificacao_celular_dd_numero_registro 

                        )
                        values 
                        (   
                               ${this.notificacao_grupo_cd} 
                            ,  ${this.notificacao_cd} 
                            , '${this.notificacao_gp_whats}'
                            , '${this.notificacao_gp_email}' 
                            , '${this.notificacao_grupo_descricao}'
                            , '${this.notificacao_celular_dd_numero_registro}'

                        )

        
            `;
    }
}
exports.default = tbnotificacao_grupo;
