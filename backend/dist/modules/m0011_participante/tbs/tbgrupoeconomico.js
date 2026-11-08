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
const class_Base_1 = require("../../../model/class.Base");
class tbgrupoeconomico extends class_Base_1.clsBaseTb {
    constructor() {
        super();
        this.cdgrupoeconomico = 0;
        this.descricao = '';
        this.descricaoresumida = '';
        this.referencia = '';
        this.grupoeconomico_status = 0;
        this.forma_pgto_cd_padrao = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            /*
                Le as informações do banco de dados
            */
            if (item) {
                this.cdgrupoeconomico = item === null || item === void 0 ? void 0 : item.cdgrupoeconomico;
                this.descricao = item === null || item === void 0 ? void 0 : item.descricao;
                this.descricaoresumida = item === null || item === void 0 ? void 0 : item.descricaoresumida;
                this.referencia = item === null || item === void 0 ? void 0 : item.referencia;
                this.grupoeconomico_status = item === null || item === void 0 ? void 0 : item.grupoeconomico_status;
                this.forma_pgto_cd_padrao = item === null || item === void 0 ? void 0 : item.forma_pgto_cd_padrao;
            }
        });
    }
    script_CRUD() {
        return this.script_insert() + '\n' + this.script_update();
    }
    script_insert() {
        return `INSERT INTO tbgrupoeconomico 
                    (cdgrupoeconomico, descricao, descricaoresumida, referencia, grupoeconomico_status, forma_pgto_cd_padrao) 
                    SELECT      ${this.cdgrupoeconomico}
                            ,  '${this.descricao}'
                            ,  '${this.descricaoresumida}'
                            ,  '${this.referencia}'
                            ,   ${this.grupoeconomico_status}
                            ,   ${this.forma_pgto_cd_padrao}
                            WHERE NOT EXISTS (
                                    SELECT 1 
                                    FROM tbgrupoeconomico 
                                    WHERE cdgrupoeconomico = ${this.cdgrupoeconomico}
                                    )
                            ;`;
    }
    script_update() {
        return `UPDATE tbgrupoeconomico 
                    SET descricao = '${this.descricao}'
                      , descricaoresumida = '${this.descricaoresumida}'
                      , referencia = '${this.referencia}'
                      , grupoeconomico_status = ${this.grupoeconomico_status} 
                    WHERE cdgrupoeconomico = ${this.cdgrupoeconomico}
                    ;
                    `;
    }
}
exports.default = tbgrupoeconomico;
