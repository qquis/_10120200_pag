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
const f0055_13_faturamento_zanthus_item_1 = __importDefault(require("../scriptspg/f0055_13_faturamento_zanthus_item"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const model_1 = require("../../../model/model");
class tbfaturamentozanthusitem extends model_1.modelTb {
    constructor() {
        super();
        this.fat_zanthus_seq = 0;
        this.fat_zanthus_data_m00af = new Date('1900-01-01');
        this.fat_zanthus_sat_ecf_m00ac = 0;
        this.fat_zanthus_cupomfiscal_m00ad = 0;
        this.fat_zanthus_item_seq_m43eg = 0;
        this.fat_zanthus_item_cdbarra_m43ah = ``;
        this.fat_zanthus_item_cdbarra_M43BK_m43ah = ``;
        this.fat_zanthus_item_qtde_m43ao = 0;
        this.fat_zanthus_item_valor_m43ap = 0;
        this.fat_zanthus_m43bk = ``;
        this.fat_zanthus_m43ah = ``;
        this.fat_zanthus_Decomp_Insumo = 0;
        this.fat_zanthus_val_liquido = 0;
        this.fat_zanthus_item_valor_desconto_m43aq = 0;
        this.fat_zanthus_qtde = 0;
    }
    _Db_Pg_script(_stringCommand) {
        const script = `Select * from ${f0055_13_faturamento_zanthus_item_1.default.sqlScript_VERSION()}
    (           sqlcommand:= '${_stringCommand}'
            ,	vfat_zanthus_data_m00af:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this === null || this === void 0 ? void 0 : this.fat_zanthus_data_m00af)}'        
            ,	vfat_zanthus_sat_ecf_m00ac:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_sat_ecf_m00ac}
            ,   vfat_zanthus_cupomfiscal_m00ad:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_cupomfiscal_m00ad}
            ,   vfat_zanthus_item_seq_m43eg:= ${this.fat_zanthus_item_seq_m43eg}
            ,   vfat_zanthus_item_cdbarra_m43ah:= '${this.fat_zanthus_item_cdbarra_m43ah}' 
            ,	vfat_zanthus_item_cdbarra_M43BK_m43ah:= '${this.fat_zanthus_item_cdbarra_M43BK_m43ah}' 
            ,   vfat_zanthus_item_qtde_m43ao:= ${this.fat_zanthus_item_qtde_m43ao}  
            ,   vfat_zanthus_item_valor_m43ap:= ${this.fat_zanthus_item_valor_m43ap}  
            ,   vfat_zanthus_item_valor_desconto_m43aq:= ${this.fat_zanthus_item_valor_desconto_m43aq}  
            ,	vfat_zanthus_M43BK:= '${this.fat_zanthus_m43bk}' 
            ,	vfat_zanthus_Decomp_Insumo:= ${this.fat_zanthus_Decomp_Insumo}
            ,	vfat_zanthus_val_liquido:= ${this.fat_zanthus_val_liquido}
            ,	vfat_zanthus_qtde:= ${this.fat_zanthus_qtde}
        );`;
        return script;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined) {
                    const data_string = item.fat_zanthus_data_m00af;
                    this.fat_zanthus_data_m00af = Tools_1.default.Date_br_timestamp(data_string ? data_string : '1900-01-01');
                    this.fat_zanthus_sat_ecf_m00ac = item === null || item === void 0 ? void 0 : item.fat_zanthus_sat_ecf_m00ac;
                    this.fat_zanthus_cupomfiscal_m00ad = item === null || item === void 0 ? void 0 : item.fat_zanthus_cupomfiscal_m00ad;
                    this.fat_zanthus_item_seq_m43eg = item === null || item === void 0 ? void 0 : item.fat_zanthus_item_seq_m43eg;
                    this.fat_zanthus_item_cdbarra_m43ah = item === null || item === void 0 ? void 0 : item.fat_zanthus_item_cdbarra_m43ah;
                    this.fat_zanthus_item_cdbarra_M43BK_m43ah = item === null || item === void 0 ? void 0 : item.fat_zanthus_item_cdbarra_m43bk_m43ah;
                    this.fat_zanthus_item_qtde_m43ao = item === null || item === void 0 ? void 0 : item.fat_zanthus_item_qtde_m43ao;
                    this.fat_zanthus_item_valor_m43ap = item === null || item === void 0 ? void 0 : item.fat_zanthus_item_valor_m43ap;
                    this.fat_zanthus_item_valor_desconto_m43aq = item === null || item === void 0 ? void 0 : item.fat_zanthus_item_valor_desconto_m43aq;
                    this.fat_zanthus_m43bk = item === null || item === void 0 ? void 0 : item.fat_zanthus_m43bk;
                    this.fat_zanthus_m43ah = item === null || item === void 0 ? void 0 : item.fat_zanthus_item_cdbarra_m43ah;
                    this.fat_zanthus_Decomp_Insumo = item === null || item === void 0 ? void 0 : item.fat_zanthus_decomp_insumo;
                    this.fat_zanthus_val_liquido = item === null || item === void 0 ? void 0 : item.fat_zanthus_val_liquido;
                    this.fat_zanthus_qtde = item === null || item === void 0 ? void 0 : item.fat_zanthus_qtde;
                }
            }
            catch (e) {
                throw `tbfaturamentozanthus | ${e}`;
            }
        });
    }
}
exports.default = tbfaturamentozanthusitem;
