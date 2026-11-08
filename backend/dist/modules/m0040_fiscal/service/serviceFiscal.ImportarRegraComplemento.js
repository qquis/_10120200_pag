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
const modelbase_1 = require("../../../model/modelbase");
const myBase = new modelbase_1.clsBase();
const tbfc_cbs_1 = __importDefault(require("../tbs/tbfc_cbs"));
const tbfc_ibs_1 = __importDefault(require("../tbs/tbfc_ibs"));
const tbfc_class_trib_ibs_cbs_1 = __importDefault(require("../tbs/tbfc_class_trib_ibs_cbs"));
const tbfc_cst_ibs_cbs_1 = __importDefault(require("../tbs/tbfc_cst_ibs_cbs"));
class serviceFiscalImportarRegraComplemento {
    static dadaBaseProcessar(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (scriptSQL.length > 0) {
                    yield myBase.myDataBase.pag.Execute(scriptSQL);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.dadaBaseProcessar', e);
            }
        });
    }
    static IbsAddList(item, listIBS) {
        return __awaiter(this, void 0, void 0, function* () {
            let list = listIBS;
            try {
                if (item.reformaTributaria.ibs.ibsKey && item.reformaTributaria.ibs.ibsKey > 0) {
                    let itemIBS = new tbfc_ibs_1.default();
                    itemIBS.ibs_cd = item.reformaTributaria.ibs.ibsKey;
                    itemIBS.ibs_descricao = item.reformaTributaria.ibs.descricao;
                    itemIBS.ibs_descricao_abreviada = item.reformaTributaria.ibs.descricaoAbreviada;
                    if (!list.find(x => x.ibs_cd == itemIBS.ibs_cd)) {
                        list.push(itemIBS);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.IbsAddList', e);
            }
            return list;
        });
    }
    static CbsAddList(item, listCBS) {
        return __awaiter(this, void 0, void 0, function* () {
            let list = listCBS;
            try {
                if (item.reformaTributaria.cbs.cbsKey && item.reformaTributaria.cbs.cbsKey > 0) {
                    let itemCBS = new tbfc_cbs_1.default();
                    itemCBS.cbs_cd = item.reformaTributaria.cbs.cbsKey;
                    itemCBS.cbs_descricao = item.reformaTributaria.cbs.descricao;
                    itemCBS.cbs_descricao_abreviada = item.reformaTributaria.cbs.descricaoAbreviada;
                    if (yield !list.find(x => x.cbs_cd == itemCBS.cbs_cd)) {
                        list.push(itemCBS);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.CbsAddList', e);
            }
            return list;
        });
    }
    static CbsListaUpdate(listCBS) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, listCBS_1, listCBS_1_1;
            var _b, e_1, _c, _d;
            try {
                let i = 0;
                let iCount = 50;
                let sql = ``;
                try {
                    for (_a = true, listCBS_1 = __asyncValues(listCBS); listCBS_1_1 = yield listCBS_1.next(), _b = listCBS_1_1.done, !_b; _a = true) {
                        _d = listCBS_1_1.value;
                        _a = false;
                        const item = _d;
                        sql += `insert into tbfc_cbs
                        (
                                    cbs_cd      					
                                ,	cbs_descricao					
                                ,	cbs_descricao_abreviada			
            
                        )
                                SELECT  ${item.cbs_cd}  
                                ,       '${item.cbs_descricao}'
                                ,       '${item.cbs_descricao_abreviada}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_cbs WHERE cbs_cd = ${item.cbs_cd} );
                        ;
                        update tbfc_cbs
                        set 
                                    cbs_descricao = '${item.cbs_descricao}'					
                                ,	cbs_descricao_abreviada = '${item.cbs_descricao_abreviada}'			
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where cbs_cd = ${item.cbs_cd};
            `;
                        i++;
                        if (i >= iCount) {
                            yield this.dadaBaseProcessar(sql);
                            i = 0;
                            sql = ``;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = listCBS_1.return)) yield _c.call(listCBS_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql.length > 0) {
                    yield this.dadaBaseProcessar(sql);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.CbsListaUpdate', e);
            }
        });
    }
    static IbsListaUpdate(listIBS) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, listIBS_1, listIBS_1_1;
            var _b, e_2, _c, _d;
            try {
                let i = 0;
                let iCount = 50;
                let sql = ``;
                try {
                    for (_a = true, listIBS_1 = __asyncValues(listIBS); listIBS_1_1 = yield listIBS_1.next(), _b = listIBS_1_1.done, !_b; _a = true) {
                        _d = listIBS_1_1.value;
                        _a = false;
                        const item = _d;
                        sql += `insert into tbfc_ibs
                        (
                                    ibs_cd      					
                                ,	ibs_descricao					
                                ,	ibs_descricao_abreviada			
            
                        )
                                SELECT  ${item.ibs_cd}  
                                ,       '${item.ibs_descricao}'
                                ,       '${item.ibs_descricao_abreviada}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_ibs WHERE ibs_cd = ${item.ibs_cd} );
                        ;
                        update tbfc_ibs
                        set 
                                    ibs_descricao = '${item.ibs_descricao}'					
                                ,	ibs_descricao_abreviada = '${item.ibs_descricao_abreviada}'			
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where ibs_cd = ${item.ibs_cd};
            `;
                        i++;
                        if (i >= iCount) {
                            yield this.dadaBaseProcessar(sql);
                            i = 0;
                            sql = ``;
                        }
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = listIBS_1.return)) yield _c.call(listIBS_1);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                if (sql.length > 0) {
                    yield this.dadaBaseProcessar(sql);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.CbsListaUpdate', e);
            }
        });
    }
    static ClassTribAddList(item, listClassTribIbsCbs) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, _b;
            let list = listClassTribIbsCbs;
            try {
                if (item.reformaTributaria.codigoClassTribIbsCbs && item.reformaTributaria.codigoClassTribIbsCbs !== '') {
                    let itemClassTribIbsCbs = new tbfc_class_trib_ibs_cbs_1.default();
                    itemClassTribIbsCbs.rt_codigo_class_trib_ibs_cbs = ((_a = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _a === void 0 ? void 0 : _a.codigoClassTribIbsCbs) || '';
                    itemClassTribIbsCbs.rt_descricao_class_trib_ibs_cbs = ((_b = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _b === void 0 ? void 0 : _b.descricaoCstIbsCbs) || '';
                    if (itemClassTribIbsCbs.rt_codigo_class_trib_ibs_cbs.length > 0) {
                        if (!list.find(x => x.rt_codigo_class_trib_ibs_cbs == itemClassTribIbsCbs.rt_codigo_class_trib_ibs_cbs)) {
                            list.push(itemClassTribIbsCbs);
                        }
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.ClassTribAddList', e);
            }
            return list;
        });
    }
    static ClassTribListaUpdate(listClassTribIbsCbs) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, listClassTribIbsCbs_1, listClassTribIbsCbs_1_1;
            var _b, e_3, _c, _d;
            try {
                let i = 0;
                let iCount = 50;
                let sql = ``;
                try {
                    for (_a = true, listClassTribIbsCbs_1 = __asyncValues(listClassTribIbsCbs); listClassTribIbsCbs_1_1 = yield listClassTribIbsCbs_1.next(), _b = listClassTribIbsCbs_1_1.done, !_b; _a = true) {
                        _d = listClassTribIbsCbs_1_1.value;
                        _a = false;
                        const item = _d;
                        sql += `insert into tbfc_class_trib_ibs_cbs
                        (
                                    rt_codigo_class_trib_ibs_cbs      					
                                ,	rt_descricao_class_trib_ibs_cbs                    
            
                        )
                                SELECT  '${item.rt_codigo_class_trib_ibs_cbs}'  
                                ,       '${item.rt_descricao_class_trib_ibs_cbs}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_class_trib_ibs_cbs WHERE rt_codigo_class_trib_ibs_cbs = '${item.rt_codigo_class_trib_ibs_cbs}' );
                        ;
                        update tbfc_class_trib_ibs_cbs
                        set 
                                    rt_descricao_class_trib_ibs_cbs = '${item.rt_descricao_class_trib_ibs_cbs}'                    
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where rt_codigo_class_trib_ibs_cbs = '${item.rt_codigo_class_trib_ibs_cbs}';
            `;
                        i++;
                        if (i >= iCount) {
                            yield this.dadaBaseProcessar(sql);
                            i = 0;
                            sql = ``;
                        }
                    }
                }
                catch (e_3_1) { e_3 = { error: e_3_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = listClassTribIbsCbs_1.return)) yield _c.call(listClassTribIbsCbs_1);
                    }
                    finally { if (e_3) throw e_3.error; }
                }
                if (sql.length > 0) {
                    yield this.dadaBaseProcessar(sql);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.ClassTribListaUpdate', e);
            }
        });
    }
    static CstAddList(item, listCstIbsCbs) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, _b;
            let list = listCstIbsCbs;
            try {
                if (item.reformaTributaria.codigoCstIbsCbs && item.reformaTributaria.codigoCstIbsCbs !== '') {
                    let itemCstIbsCbs = new tbfc_cst_ibs_cbs_1.default();
                    itemCstIbsCbs.rt_codigo_cst_ibs_cbs = ((_a = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _a === void 0 ? void 0 : _a.codigoCstIbsCbs) || '';
                    itemCstIbsCbs.cst_ibs_cbs_descricao = ((_b = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _b === void 0 ? void 0 : _b.descricaoCstIbsCbs) || '';
                    if (itemCstIbsCbs.rt_codigo_cst_ibs_cbs.length > 0) {
                        if (!list.find(x => x.rt_codigo_cst_ibs_cbs == itemCstIbsCbs.rt_codigo_cst_ibs_cbs)) {
                            list.push(itemCstIbsCbs);
                        }
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.CstAddList', e);
            }
            return list;
        });
    }
    static CstListaUpdate(listCstIbsCbs) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, listCstIbsCbs_1, listCstIbsCbs_1_1;
            var _b, e_4, _c, _d;
            try {
                let i = 0;
                let iCount = 50;
                let sql = ``;
                try {
                    for (_a = true, listCstIbsCbs_1 = __asyncValues(listCstIbsCbs); listCstIbsCbs_1_1 = yield listCstIbsCbs_1.next(), _b = listCstIbsCbs_1_1.done, !_b; _a = true) {
                        _d = listCstIbsCbs_1_1.value;
                        _a = false;
                        const item = _d;
                        sql += `insert into tbfc_cst_ibs_cbs
                        (
                                    rt_codigo_cst_ibs_cbs      					
                                ,	cst_ibs_cbs_descricao                    
            
                        )
                                SELECT  '${item.rt_codigo_cst_ibs_cbs}'  
                                ,       '${item.cst_ibs_cbs_descricao}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_cst_ibs_cbs WHERE rt_codigo_cst_ibs_cbs = '${item.rt_codigo_cst_ibs_cbs}' );
                        ;
                        update tbfc_cst_ibs_cbs
                        set 
                                    cst_ibs_cbs_descricao = '${item.cst_ibs_cbs_descricao}'                    
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where rt_codigo_cst_ibs_cbs = '${item.rt_codigo_cst_ibs_cbs}';
            `;
                        i++;
                        if (i >= iCount) {
                            yield this.dadaBaseProcessar(sql);
                            i = 0;
                            sql = ``;
                        }
                    }
                }
                catch (e_4_1) { e_4 = { error: e_4_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = listCstIbsCbs_1.return)) yield _c.call(listCstIbsCbs_1);
                    }
                    finally { if (e_4) throw e_4.error; }
                }
                if (sql.length > 0) {
                    yield this.dadaBaseProcessar(sql);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.CstListaUpdate', e);
            }
        });
    }
}
exports.default = serviceFiscalImportarRegraComplemento;
