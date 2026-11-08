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
class tbfc_class_trib_ibs_cbs extends modelbase_1.clsBase {
    constructor() {
        super();
        this.rt_codigo_class_trib_ibs_cbs = "000";
        this.rt_descricao_class_trib_ibs_cbs = '';
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                this.rt_codigo_class_trib_ibs_cbs = item === null || item === void 0 ? void 0 : item.rt_codigo_class_trib_ibs_cbs;
                this.rt_descricao_class_trib_ibs_cbs = item === null || item === void 0 ? void 0 : item.rt_descricao_class_trib_ibs_cbs;
            }
        });
    }
    sql_CRUD() {
        let sql = this.sql_insert();
        sql += this.sql_update();
        return sql;
    }
    sql_update() {
        let sql = `update tbfc_class_trib_ibs_cbs
                        set 
                                    rt_descricao_class_trib_ibs_cbs = '${this.rt_descricao_class_trib_ibs_cbs}'                    
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where rt_codigo_class_trib_ibs_cbs = '${this.rt_codigo_class_trib_ibs_cbs}';
            `;
        return sql;
    }
    sql_insert() {
        let sql = `insert into tbfc_class_trib_ibs_cbs
                        (
                                    rt_codigo_class_trib_ibs_cbs      					
                                ,	rt_descricao_class_trib_ibs_cbs                    
            
                        )
                                SELECT  '${this.rt_codigo_class_trib_ibs_cbs}'  
                                ,       '${this.rt_descricao_class_trib_ibs_cbs}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_class_trib_ibs_cbs WHERE rt_codigo_class_trib_ibs_cbs = '${this.rt_codigo_class_trib_ibs_cbs}' );
                        ;
                        update tbfc_class_trib_ibs_cbs
                        set 
                                    rt_descricao_class_trib_ibs_cbs = '${this.rt_descricao_class_trib_ibs_cbs}'                    
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where rt_codigo_class_trib_ibs_cbs = '${this.rt_codigo_class_trib_ibs_cbs}';
            `;
        return sql;
    }
}
exports.default = tbfc_class_trib_ibs_cbs;
