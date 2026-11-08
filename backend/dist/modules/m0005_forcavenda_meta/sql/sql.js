"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const sql_forcaVenda_Meta_Fabricante_f0005_20_fv_meta_processar_1 = __importDefault(require("./sql.forcaVenda.Meta.Fabricante.f0005_20_fv_meta_processar"));
const sql_forcaVenda_Meta_Fabricante_f0005_30_fv_meta_fab_processar_1 = __importDefault(require("./sql.forcaVenda.Meta.Fabricante.f0005_30_fv_meta_fab_processar"));
class sqlForcaVenda {
}
sqlForcaVenda.f0005_30_fv_meta_fab_processar = sql_forcaVenda_Meta_Fabricante_f0005_30_fv_meta_fab_processar_1.default;
sqlForcaVenda.f0005_20_fv_meta_processar = sql_forcaVenda_Meta_Fabricante_f0005_20_fv_meta_processar_1.default;
exports.default = sqlForcaVenda;
