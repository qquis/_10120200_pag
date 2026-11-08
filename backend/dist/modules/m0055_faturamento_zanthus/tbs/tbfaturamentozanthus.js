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
const f0055_12_faturamento_zanthus_1 = __importDefault(require("../scriptspg/f0055_12_faturamento_zanthus"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const model_1 = require("../../../model/model");
class tbfaturamentozanthus extends model_1.modelTb {
    constructor() {
        super();
        this.dtlog_insert = new Date('1900-01-01');
        this.dtlog_update = new Date('1900-01-01');
        this.fat_zanthus_seq = 0;
        this.fat_zanthus_data_m00af = new Date('1900-01-01');
        this.fat_zanthus_sat_ecf_m00ac = 0;
        this.fat_zanthus_cupomfiscal_m00ad = 0;
        this.fat_zanthus_cupomfiscalid_M00_id_unico = ``;
        this.fat_zanthus_cupomfiscal_cancelado_m45bo = 0;
        this.fat_zanthus_notafiscal_numnota = 0;
        this.fat_zanthus_notafiscal_serie_nf = 0;
        this.fat_zanthus_notafiscal_chave_m45xb = ``;
        this.fat_zanthus_status_cancelado = 0;
        this.fat_zanthus_cpf_cnpj_m45bv = ``;
        this.fat_zanthus_hora_ini_m45ai = new Date(`1900-01-01`);
        this.fat_zanthus_hora_fim_m45au = new Date(`1900-01-01`);
        this.fat_zanthus_cupomfiscal_valor_m45ak = 0;
        this.fat_zanthus_cod_funcionario_m45ah = 0;
        this.fat_zanthus_voucher_cod_m50ar = ``;
        this.fat_zanthus_voucher_valor_m50at = 0;
        this.fat_zanthus_voucher_count_m50ag = 0;
        this.fat_zanthus_conferencia = 0;
        this.fat_zanthus_processado = 0;
        this.fat_zanthus_pag = 0;
        this.tiponota = 0;
    }
    _Db_Pg_script(_stringCommand) {
        const script = `Select * from ${f0055_12_faturamento_zanthus_1.default.sqlScript_VERSION()}
    (           sqlcommand:= '${_stringCommand}'
            ,	vfat_zanthus_data_m00af:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this === null || this === void 0 ? void 0 : this.fat_zanthus_data_m00af)}'        
            ,	vfat_zanthus_sat_ecf_m00ac:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_sat_ecf_m00ac}
            ,   vfat_zanthus_cupomfiscal_m00ad:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_cupomfiscal_m00ad}
            ,   vfat_zanthus_cupomfiscalid_M00_id_unico:= '${this === null || this === void 0 ? void 0 : this.fat_zanthus_cupomfiscalid_M00_id_unico}'
            ,   vfat_zanthus_cupomfiscal_cancelado_m45bo:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_cupomfiscal_cancelado_m45bo}
            ,   vfat_zanthus_notafiscal_numnota:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_notafiscal_numnota}
            ,   vfat_zanthus_notafiscal_serie_nf:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_notafiscal_serie_nf}
            ,   vfat_zanthus_notafiscal_chave_m45xb:= '${this === null || this === void 0 ? void 0 : this.fat_zanthus_notafiscal_chave_m45xb}'
            ,   vfat_zanthus_status_cancelado:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_status_cancelado}
            ,   vfat_zanthus_cpf_cnpj_m45bv:= '${this === null || this === void 0 ? void 0 : this.fat_zanthus_cpf_cnpj_m45bv}'
            ,   vfat_zanthus_hora_ini_m45ai:= '${this === null || this === void 0 ? void 0 : this.fat_zanthus_hora_ini_m45ai}'
            ,   vfat_zanthus_hora_fim_m45au:= '${this === null || this === void 0 ? void 0 : this.fat_zanthus_hora_fim_m45au}'
            ,   vfat_zanthus_cupomfiscal_valor_m45ak:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_cupomfiscal_valor_m45ak}
            ,   vfat_zanthus_cod_funcionario_m45ah:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_cod_funcionario_m45ah}
            ,   vfat_zanthus_voucher_cod_m50ar:= '${this === null || this === void 0 ? void 0 : this.fat_zanthus_voucher_cod_m50ar}'
            ,   vfat_zanthus_voucher_valor_m50at:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_voucher_valor_m50at}
            ,   vfat_zanthus_voucher_count_m50ag:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_voucher_count_m50ag}
            ,   vfat_zanthus_conferencia:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_conferencia}
            ,   vfat_zanthus_processado:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_processado}
            ,   vfat_zanthus_pag:= ${this === null || this === void 0 ? void 0 : this.fat_zanthus_pag}
            ,   vtiponota:= ${this === null || this === void 0 ? void 0 : this.tiponota}
        ); `;
        return script;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item !== undefined) {
                    //console.log(`Fat ZANTHUS PAG ${item?.fat_zanthus_pag}`)
                    const data_string = item.fat_zanthus_data_m00af;
                    this.fat_zanthus_data_m00af = Tools_1.default.Date_br_timestamp(data_string ? data_string : '1900-01-01');
                    this.fat_zanthus_sat_ecf_m00ac = item === null || item === void 0 ? void 0 : item.fat_zanthus_sat_ecf_m00ac;
                    this.fat_zanthus_cupomfiscal_m00ad = item === null || item === void 0 ? void 0 : item.fat_zanthus_cupomfiscal_m00ad;
                    this.fat_zanthus_cupomfiscalid_M00_id_unico = item === null || item === void 0 ? void 0 : item.fat_zanthus_cupomfiscalid_M00_id_unico;
                    this.fat_zanthus_cupomfiscal_cancelado_m45bo = item === null || item === void 0 ? void 0 : item.fat_zanthus_cupomfiscal_cancelado_m45bo;
                    this.fat_zanthus_notafiscal_numnota = item === null || item === void 0 ? void 0 : item.fat_zanthus_notafiscal_numnota;
                    this.fat_zanthus_notafiscal_serie_nf = item === null || item === void 0 ? void 0 : item.fat_zanthus_notafiscal_serie_nf;
                    this.fat_zanthus_notafiscal_chave_m45xb = item === null || item === void 0 ? void 0 : item.fat_zanthus_notafiscal_chave_m45xb;
                    this.fat_zanthus_status_cancelado = item === null || item === void 0 ? void 0 : item.fat_zanthus_status_cancelado;
                    this.fat_zanthus_cpf_cnpj_m45bv = item === null || item === void 0 ? void 0 : item.fat_zanthus_cpf_cnpj_m45bv;
                    this.fat_zanthus_hora_ini_m45ai = item === null || item === void 0 ? void 0 : item.fat_zanthus_hora_ini_m45ai;
                    this.fat_zanthus_hora_fim_m45au = item === null || item === void 0 ? void 0 : item.fat_zanthus_hora_fim_m45au;
                    this.fat_zanthus_cupomfiscal_valor_m45ak = item === null || item === void 0 ? void 0 : item.fat_zanthus_cupomfiscal_valor_m45ak;
                    this.fat_zanthus_cod_funcionario_m45ah = item === null || item === void 0 ? void 0 : item.fat_zanthus_cod_funcionario_m45ah;
                    this.fat_zanthus_voucher_cod_m50ar = item === null || item === void 0 ? void 0 : item.fat_zanthus_voucher_cod_m50ar;
                    this.fat_zanthus_voucher_valor_m50at = item === null || item === void 0 ? void 0 : item.fat_zanthus_voucher_valor_m50at;
                    this.fat_zanthus_voucher_count_m50ag = item === null || item === void 0 ? void 0 : item.fat_zanthus_voucher_count_m50ag;
                    this.fat_zanthus_conferencia = item === null || item === void 0 ? void 0 : item.fat_zanthus_conferencia;
                    this.fat_zanthus_processado = item === null || item === void 0 ? void 0 : item.fat_zanthus_processado;
                    this.fat_zanthus_pag = item === null || item === void 0 ? void 0 : item.fat_zanthus_pag;
                    this.tiponota = item === null || item === void 0 ? void 0 : item.tiponota;
                }
            }
            catch (e) {
                throw `tbfaturamentozanthus | ${e}`;
            }
        });
    }
}
exports.default = tbfaturamentozanthus;
