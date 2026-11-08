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
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const model_1 = require("../../../model/model");
const f0055_10_faturamentozanthus_ctrl_1 = __importDefault(require("../scriptspg/f0055_10_faturamentozanthus_ctrl"));
class tbfaturamentozanthus_ctrl extends model_1.modelTb {
    constructor() {
        super();
        this.dtlog_insert = new Date();
        this.dtlog_update = new Date();
        this.fat_zanthus_sat_ecf_m00ac = 0;
        this.fat_zanthus_data_m00af = new Date();
        this.fz_cupom_qtde = 0;
        this.fz_cupom_inicial = 0;
        this.fz_cupom_final = 0;
        this.fz_valor = 0;
        this.fz_pag_cupom_qtde = 0;
        this.fz_pag_cupom_inicial = 0;
        this.fz_pag_cupom_final = 0;
        this.fz_pag_valor = 0;
        this.fat_cupom_qtde = 0;
        this.fat_cupom_inicial = 0;
        this.fat_cupom_final = 0;
        this.fat_valor = 0;
        this.My_List_Cupom = [];
        this.My_List_Cupom_Item = [];
    }
    _Db_Pg_script(_stringCommandExecute) {
        let script = ``;
        script = `Select * from ${f0055_10_faturamentozanthus_ctrl_1.default.sqlScript_VERSION()}
    (           sqlcommand:= '${_stringCommandExecute}'
            ,	vfat_zanthus_sat_ecf_m00ac:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_sat_ecf_m00ac}
            ,	vfat_zanthus_data_m00af:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this === null || this === void 0 ? void 0 : this.fat_zanthus_data_m00af)}'
            ,	vfz_cupom_qtde:= ${this === null || this === void 0 ? void 0 : this.fz_cupom_qtde}
            ,	vfz_cupom_inicial:=	${this === null || this === void 0 ? void 0 : this.fz_cupom_inicial}
            ,	vfz_cupom_final:= ${this === null || this === void 0 ? void 0 : this.fz_cupom_final}
            ,	vfz_valor:= ${this === null || this === void 0 ? void 0 : this.fz_valor}
            ,	vfz_pag_cupom_qtde:= ${this === null || this === void 0 ? void 0 : this.fz_pag_cupom_qtde}
            ,	vfz_pag_cupom_inicial:=	${this === null || this === void 0 ? void 0 : this.fz_pag_cupom_inicial}
            ,	vfz_pag_cupom_final:= ${this === null || this === void 0 ? void 0 : this.fz_pag_cupom_final}
            ,	vfz_pag_valor:= ${this === null || this === void 0 ? void 0 : this.fz_pag_valor}
        )`;
        return script;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined) {
                    //console.log(`DATA SELECIONADA ${new Date(item.fat_zanthus_data_m00af).toLocaleDateString()} FORMATADA: ${Tools.Date_br_new(`${new Date(item.fat_zanthus_data_m00af).toLocaleDateString()}`)}`)
                    this.fat_zanthus_sat_ecf_m00ac = item.fat_zanthus_sat_ecf_m00ac;
                    const data_string = item.fat_zanthus_data_m00af;
                    this.fat_zanthus_data_m00af = Tools_1.default.Date_br_timestamp(data_string);
                    this.fz_cupom_qtde = item.fz_cupom_qtde;
                    this.fz_cupom_inicial = item.fz_cupom_inicial;
                    this.fz_cupom_final = item.fz_cupom_final;
                    this.fz_valor = item.fz_valor;
                    this.fz_pag_cupom_qtde = item.fz_pag_cupom_qtde;
                    this.fz_pag_cupom_inicial = item.fz_pag_cupom_inicial;
                    this.fz_pag_cupom_final = item.fz_pag_cupom_final;
                    this.fz_pag_valor = item.fz_pag_valor;
                    this.fat_cupom_qtde = item.fat_cupom_qtde;
                    this.fat_cupom_inicial = item.fat_cupom_inicial;
                    this.fat_cupom_final = item.fat_cupom_final;
                    this.fat_valor = item === null || item === void 0 ? void 0 : item.fat_valor;
                    //console.log(`Data ITEM ${item.fat_zanthus_data_m00af} - X - Data Objeto ${this.fat_zanthus_data_m00af}`)
                }
            }
            catch (e) {
                throw `tbnotificacao_send | ${e}`;
            }
        });
    }
}
exports.default = tbfaturamentozanthus_ctrl;
