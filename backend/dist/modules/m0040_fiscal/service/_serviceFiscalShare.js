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
const modelfc_ibs_1 = __importDefault(require("../model/modelfc_ibs"));
const modelfc_ibs_mun_1 = __importDefault(require("../model/modelfc_ibs_mun"));
const modelfc_class_trib_ibs_cbs_1 = __importDefault(require("../model/modelfc_class_trib_ibs_cbs"));
const modelfc_cbs_1 = __importDefault(require("../model/modelfc_cbs"));
const modelfc_cst_ibs_cbs_1 = __importDefault(require("../model/modelfc_cst_ibs_cbs"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M0040-Fiscal | SHARE (Funções Service Fiscal Compartilhadas)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceFiscalShare {
    constructor() {
        this.Complemento = new serviceFiscalShareComplemento();
    }
}
exports.default = serviceFiscalShare;
//CLASS COMPLEMENTARES
class serviceFiscalShareComplemento {
    constructor() {
        this.Ibs = new serviceFiscalShareIBS();
        this.IbsMun = new serviceFiscalShareIBSMun();
        this.ClassTribIbsCbs = new serviceFiscalShareClassTribIbsCbs();
        this.Cbs = new serviceFiscalShareCbs();
        this.cstIBSCBS = new serviceFiscalShareCstIbsCbs();
    }
    ProcessarReformaDadosComplementares(ItemAPI) {
        return __awaiter(this, void 0, void 0, function* () {
            this.Ibs.ibsAdicionarShareListFromAPI(ItemAPI);
            this.IbsMun.ibsMunAdicionarShareListFromAPI(ItemAPI);
            this.ClassTribIbsCbs.classTribAdicionarShareListFromAPI(ItemAPI);
            this.Cbs.cbsAdicionarShareListFromAPI(ItemAPI);
            this.cstIBSCBS.cstIbsCbsAdicionarShareListFromAPI(ItemAPI);
        });
    }
    SalvarDadosDosLists() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.Ibs.ibsSalvar();
            yield this.IbsMun.ibsMunSalvar();
            yield this.ClassTribIbsCbs.classTribSalvar();
            yield this.Cbs.cbsSalvar();
            yield this.cstIBSCBS.cstIbsCbsSalvar();
        });
    }
}
class serviceFiscalShareIBS {
    constructor() {
        this.listIBS = [];
        this.listIBS = [];
    }
    ibsAdicionarShareListFromAPI(ItemAPI) {
        const item = new modelfc_ibs_1.default();
        item.ObterDadosAPIBluesoft_NFCE_PorProduto(ItemAPI);
        if (item && item.ibs_cd && item.ibs_cd > 0) {
            if (!this.listIBS.find(x => x.ibs_cd == item.ibs_cd)) {
                this.listIBS.push(item);
            }
        }
    }
    ibsSalvar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = ``;
                for (const item of this.listIBS) {
                    sql += item.sql_CRUD();
                }
                if (sql.length > 0) {
                    yield this.shareDataBaseProcessar(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalShare.ibsSalvar', e);
            }
        });
    }
    shareDataBaseProcessar(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            const myBase = new modelbase_1.clsBase();
            try {
                if (scriptSQL.length > 0) {
                    yield myBase.myDataBase.pag.Execute(scriptSQL);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'shareDataBaseProcessar', e);
            }
        });
    }
}
class serviceFiscalShareIBSMun {
    constructor() {
        this.listIBSMun = [];
        this.listIBSMun = [];
    }
    ibsMunAdicionarShareListFromAPI(ItemAPI) {
        const item = new modelfc_ibs_mun_1.default();
        item.ObterDadosAPIBluesoft_NFCE_PorProduto(ItemAPI);
        if (item && item.ibs_mun_cd && item.ibs_mun_cd > 0) {
            if (!this.listIBSMun.find(x => x.ibs_mun_cd == item.ibs_mun_cd)) {
                this.listIBSMun.push(item);
            }
        }
    }
    ibsMunSalvar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = ``;
                for (const item of this.listIBSMun) {
                    sql += item.sql_CRUD();
                }
                if (sql.length > 0) {
                    yield this.shareDataBaseProcessar(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalShare.ibsMunSalvar', e);
            }
        });
    }
    shareDataBaseProcessar(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            const myBase = new modelbase_1.clsBase();
            try {
                if (scriptSQL.length > 0) {
                    yield myBase.myDataBase.pag.Execute(scriptSQL);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'shareDataBaseProcessar', e);
            }
        });
    }
}
class serviceFiscalShareClassTribIbsCbs {
    constructor() {
        this.listClassTribIbsCbs = [];
        this.listClassTribIbsCbs = [];
    }
    classTribAdicionarShareListFromAPI(ItemAPI) {
        const item = new modelfc_class_trib_ibs_cbs_1.default();
        item.ObterDadosAPIBluesoft_NFCE_PorProduto(ItemAPI);
        if (item && item.rt_codigo_class_trib_ibs_cbs && item.rt_codigo_class_trib_ibs_cbs !== '') {
            if (!this.listClassTribIbsCbs.find(x => x.rt_codigo_class_trib_ibs_cbs == item.rt_codigo_class_trib_ibs_cbs)) {
                this.listClassTribIbsCbs.push(item);
            }
        }
    }
    classTribSalvar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = ``;
                for (const item of this.listClassTribIbsCbs) {
                    sql += item.sql_CRUD();
                }
                if (sql.length > 0) {
                    yield this.shareDataBaseProcessar(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalShare.classTribSalvar', e);
            }
        });
    }
    shareDataBaseProcessar(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            const myBase = new modelbase_1.clsBase();
            try {
                if (scriptSQL.length > 0) {
                    yield myBase.myDataBase.pag.Execute(scriptSQL);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'shareDataBaseProcessar', e);
            }
        });
    }
}
class serviceFiscalShareCbs {
    constructor() {
        this.listCbs = [];
        this.listCbs = [];
    }
    cbsAdicionarShareListFromAPI(ItemAPI) {
        const item = new modelfc_cbs_1.default();
        item.ObterDadosAPIBluesoft_NFCE_PorProduto(ItemAPI);
        if (item && item.cbs_cd && item.cbs_cd !== 0) {
            if (!this.listCbs.find(x => x.cbs_cd == item.cbs_cd)) {
                this.listCbs.push(item);
            }
        }
    }
    cbsSalvar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = ``;
                for (const item of this.listCbs) {
                    sql += item.sql_CRUD();
                }
                if (sql.length > 0) {
                    yield this.shareDataBaseProcessar(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalShare.cbsSalvar', e);
            }
        });
    }
    shareDataBaseProcessar(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            const myBase = new modelbase_1.clsBase();
            try {
                if (scriptSQL.length > 0) {
                    yield myBase.myDataBase.pag.Execute(scriptSQL);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'shareDataBaseProcessar', e);
            }
        });
    }
}
class serviceFiscalShareCstIbsCbs {
    constructor() {
        this.listCstIbsCbs = [];
        this.listCstIbsCbs = [];
    }
    cstIbsCbsAdicionarShareListFromAPI(ItemAPI) {
        const item = new modelfc_cst_ibs_cbs_1.default();
        item.ObterDadosAPIBluesoft_NFCE_PorProduto(ItemAPI);
        if (item && item.rt_codigo_cst_ibs_cbs && item.rt_codigo_cst_ibs_cbs !== '') {
            if (!this.listCstIbsCbs.find(x => x.rt_codigo_cst_ibs_cbs == item.rt_codigo_cst_ibs_cbs)) {
                this.listCstIbsCbs.push(item);
            }
        }
    }
    cstIbsCbsSalvar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = ``;
                for (const item of this.listCstIbsCbs) {
                    sql += item.sql_CRUD();
                }
                if (sql.length > 0) {
                    yield this.shareDataBaseProcessar(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalShare.cstIbsCbsSalvar', e);
            }
        });
    }
    shareDataBaseProcessar(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            const myBase = new modelbase_1.clsBase();
            try {
                if (scriptSQL.length > 0) {
                    yield myBase.myDataBase.pag.Execute(scriptSQL);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, 'shareDataBaseProcessar', e);
            }
        });
    }
}
