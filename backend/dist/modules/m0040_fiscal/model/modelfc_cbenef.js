"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfc_cbenef_1 = __importDefault(require("../tbs/tbfc_cbenef"));
class modelfc_cbenef extends tbfc_cbenef_1.default {
    constructor() {
        super();
    }
    getCbenefBLueApi(item) {
        if (item) {
            this.fc_cbenef_cd = item === null || item === void 0 ? void 0 : item.codigoBeneficioFiscal;
            this.fc_cbenef_bluesoft_cd = item === null || item === void 0 ? void 0 : item.beneficioFiscalKey;
            this.fc_cbenef_dispositivo = item === null || item === void 0 ? void 0 : item.descricao;
            this.fc_cbenef_objetivo = item === null || item === void 0 ? void 0 : item.observacao;
            this.fc_cbenef_bluesoft_dispositivo = item === null || item === void 0 ? void 0 : item.descricao;
            this.fc_cbenef_bluesoft_objetivo = item === null || item === void 0 ? void 0 : item.observacao;
            this.fc_cbenef_bluesoft = 1;
        }
    }
    sqlInserirDadosDeApi() {
        let sql = `insert into tbfc_cbenef 
                                    (fc_cbenef_cd,
                                    fc_cbenef_bluesoft_cd,
                                    fc_cbenef_dispositivo,
                                    fc_cbenef_objetivo,
                                    fc_cbenef_bluesoft_dispositivo,
                                    fc_cbenef_bluesoft_objetivo, 
                                    fc_cbenef_bluesoft


                                ) 
                                select   '${this.fc_cbenef_cd}', 
                                        ${this.fc_cbenef_bluesoft_cd},
                                        '${this.fc_cbenef_dispositivo}', 
                                        '${this.fc_cbenef_objetivo}', 
                                        '${this.fc_cbenef_bluesoft_dispositivo}', 
                                        '${this.fc_cbenef_bluesoft_objetivo}',            
                                        1
                                where not exists (select 1 from tbfc_cbenef where fc_cbenef_cd = '${this.fc_cbenef_cd}')
                                ;

                                update tbfc_cbenef
                                set  fc_cbenef_bluesoft_cd = ${this.fc_cbenef_bluesoft_cd},
                                        fc_cbenef_bluesoft_dispositivo = '${this.fc_cbenef_bluesoft_dispositivo}',
                                        fc_cbenef_bluesoft_objetivo = '${this.fc_cbenef_bluesoft_objetivo}',
                                        dtlog_update = current_timestamp
                                where fc_cbenef_cd = '${this.fc_cbenef_cd}'
                                ;`;
        return sql;
    }
}
exports.default = modelfc_cbenef;
