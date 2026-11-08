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
const f0055_11_faturamentozanthus_ctrl_cupom_1 = __importDefault(require("../scriptspg/f0055_11_faturamentozanthus_ctrl_cupom"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const model_1 = require("../../../model/model");
class tbfaturamentozanthus_ctrl_cupom extends model_1.modelTb {
    constructor() {
        super();
        this.dtlog_insert = new Date();
        this.dtlog_update = new Date();
        this.fat_zanthus_sat_ecf_m00ac = 0;
        this.fat_zanthus_data_m00af = new Date();
        this.fat_zanthus_cupomfiscal_m00ad = 0;
        this.fat_zanthus_conferencia = 0;
        this.fat_zanthus_processado = 0;
        this.fat_zanthus_pag = 0;
    }
    _Db_Pg_script(_stringCommand) {
        const script = `Select * from ${f0055_11_faturamentozanthus_ctrl_cupom_1.default.sqlScript_VERSION()}
    (           sqlcommand:= '${_stringCommand}'
            ,	vfat_zanthus_data_m00af:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this === null || this === void 0 ? void 0 : this.fat_zanthus_data_m00af)}'        
            ,	vfat_zanthus_sat_ecf_m00ac:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_sat_ecf_m00ac}
            ,   vfat_zanthus_cupomfiscal_m00ad:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_cupomfiscal_m00ad}
            ,   vfat_zanthus_conferencia:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_conferencia}
            ,   vfat_zanthus_processado:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_processado}
            ,   vfat_zanthus_pag:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_pag}
        )`;
        return script;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined) {
                    const data_string = item.fat_zanthus_data_m00af;
                    this.fat_zanthus_data_m00af = Tools_1.default.Date_br_timestamp(data_string);
                    this.fat_zanthus_sat_ecf_m00ac = item.fat_zanthus_sat_ecf_m00ac;
                    this.fat_zanthus_cupomfiscal_m00ad = item.fat_zanthus_cupomfiscal_m00ad;
                    this.fat_zanthus_conferencia = item.fat_zanthus_conferencia;
                    this.fat_zanthus_processado = item.fat_zanthus_processado;
                    this.fat_zanthus_pag = item.fat_zanthus_pag;
                }
            }
            catch (e) {
                throw `tbfaturamentozanthus_ctrl_cupom | ${e}`;
            }
        });
    }
}
exports.default = tbfaturamentozanthus_ctrl_cupom;
