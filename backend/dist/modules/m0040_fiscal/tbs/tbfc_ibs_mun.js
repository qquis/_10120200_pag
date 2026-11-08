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
class tbfc_ibs_mun extends modelbase_1.clsBase {
    constructor() {
        super();
        this.ibs_mun_cd = 0;
        this.ibs_mun_descricao = '';
        this.ibs_mun_descricao_abreviada = '';
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.ibs_mun_cd = item === null || item === void 0 ? void 0 : item.ibs_cd;
                this.ibs_mun_descricao = item === null || item === void 0 ? void 0 : item.ibs_descricao;
                this.ibs_mun_descricao_abreviada = item === null || item === void 0 ? void 0 : item.ibs_descricao_abreviada;
            }
        });
    }
    sql_CRUD() {
        let sql = this.sql_insert();
        sql += this.sql_update();
        return sql;
    }
    sql_update() {
        let sql = ``;
        sql += `update tbfc_ibs_mun
                        set 
                                    ibs_mun_descricao = '${this.ibs_mun_descricao}'					
                                ,	ibs_mun_descricao_abreviada = '${this.ibs_mun_descricao_abreviada}'			
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where ibs_mun_cd = ${this.ibs_mun_cd};
            `;
        return sql;
    }
    sql_insert() {
        let sql = ``;
        sql += `insert into tbfc_ibs_mun
                        (
                                    ibs_mun_cd      					
                                ,	ibs_mun_descricao					
                                ,	ibs_mun_descricao_abreviada			
            
                        )
                                SELECT  ${this.ibs_mun_cd}  
                                ,       '${this.ibs_mun_descricao}'
                                ,       '${this.ibs_mun_descricao_abreviada}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_ibs_mun WHERE ibs_mun_cd = ${this.ibs_mun_cd} );
                        ;
            `;
        return sql;
    }
}
exports.default = tbfc_ibs_mun;
