"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class f0055_15_faturamentozanthus_ctrl_consultar {
    static sqlScript_VERSION() { return `f0055_15_1012007_faturamentozanthus_ctrl_consultar`; }
    static SELECT(filter) {
        var _a, _b, _c;
        try {
            let SQL = `select * from ${f0055_15_faturamentozanthus_ctrl_consultar.sqlScript_VERSION()} ( 
                                vdatafaturamento_ini:= '${Tools_1.default.format_Date_toStr_ShortDataBase((_a = filter.filter) === null || _a === void 0 ? void 0 : _a.datafaturamento_ini)}'
                             ,  vdatafaturamento_fim:= '${Tools_1.default.format_Date_toStr_ShortDataBase((_b = filter.filter) === null || _b === void 0 ? void 0 : _b.datafaturamento_fim)}'
                             ,  vsat_ecf:= ${(_c = filter.filter) === null || _c === void 0 ? void 0 : _c.sat_ecf}
                             ,  vdiferenca:= 0 
                        )`;
            return SQL;
        }
        catch (e) {
            console.log(`f0055_15_faturamentozanthus_ctrl_consultar | ${e}`);
            return ``;
        }
    }
}
exports.default = f0055_15_faturamentozanthus_ctrl_consultar;
