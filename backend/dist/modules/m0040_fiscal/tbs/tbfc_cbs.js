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
const modelbase_1 = require("../../../model/modelbase");
class tbfc_cbs extends modelbase_1.clsBase {
    constructor() {
        super();
        this.cbs_cd = 0;
        this.cbs_descricao = '';
        this.cbs_descricao_abreviada = '';
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.cbs_cd = item === null || item === void 0 ? void 0 : item.cbs_cd;
                this.cbs_descricao = item === null || item === void 0 ? void 0 : item.cbs_descricao;
                this.cbs_descricao_abreviada = item === null || item === void 0 ? void 0 : item.cbs_descricao_abreviada;
            }
        });
    }
    sql_CRUD() {
        return this.sql_insert() + ' ' + this.sql_update();
    }
    sql_insert() {
        let sql = `insert into tbfc_cbs
                    (
                                cbs_cd      					
                            ,	cbs_descricao					
                            ,	cbs_descricao_abreviada			
        
                    )
                            SELECT  ${this.cbs_cd}  
                            ,       '${this.cbs_descricao}'
                            ,       '${this.cbs_descricao_abreviada}'
                    WHERE NOT EXISTS (SELECT 1 FROM tbfc_cbs WHERE cbs_cd = ${this.cbs_cd} );
                    `;
        return sql;
    }
    sql_update() {
        let sql = `update tbfc_cbs
                           set cbs_descricao = '${this.cbs_descricao}',
                               cbs_descricao_abreviada = '${this.cbs_descricao_abreviada}'
                           where cbs_cd = ${this.cbs_cd};`;
        return sql;
    }
}
exports.default = tbfc_cbs;
