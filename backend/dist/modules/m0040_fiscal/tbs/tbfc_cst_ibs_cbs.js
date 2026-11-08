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
class tbfc_cst_ibs_cbs extends modelbase_1.clsBase {
    constructor() {
        super();
        this.rt_codigo_cst_ibs_cbs = '';
        this.cst_ibs_cbs_descricao = '';
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.rt_codigo_cst_ibs_cbs = item === null || item === void 0 ? void 0 : item.rt_codigo_cst_ibs_cbs;
                this.cst_ibs_cbs_descricao = item === null || item === void 0 ? void 0 : item.cst_ibs_cbs_descricao;
            }
        });
    }
    sql_CRUD() {
        return this.sql_insert() + this.sql_update();
    }
    sql_insert() {
        return `insert into tbfc_cst_ibs_cbs
                    (
                                rt_codigo_cst_ibs_cbs      					
                            ,	cst_ibs_cbs_descricao                    
        
                    )
                            SELECT  '${this.rt_codigo_cst_ibs_cbs.replace("'", "''")}'  
                            ,       '${this.cst_ibs_cbs_descricao.replace("'", "''")}'
                    WHERE NOT EXISTS (SELECT 1 
                                    FROM tbfc_cst_ibs_cbs 
                                    WHERE rt_codigo_cst_ibs_cbs = '${this.rt_codigo_cst_ibs_cbs.replace("'", "''")}' );`;
    }
    sql_update() {
        return `update tbfc_cst_ibs_cbs
        set 
                cst_ibs_cbs_descricao = '${this.cst_ibs_cbs_descricao.replace("'", "''")}'                    
            ,   dtlog_update = CURRENT_TIMESTAMP			
        where rt_codigo_cst_ibs_cbs = '${this.rt_codigo_cst_ibs_cbs.replace("'", "''")}';
        `;
    }
}
exports.default = tbfc_cst_ibs_cbs;
