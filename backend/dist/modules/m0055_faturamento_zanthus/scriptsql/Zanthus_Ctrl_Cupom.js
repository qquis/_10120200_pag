"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class Zanthus_Ctrl_Cupom {
    static get(filter) {
        var _a, _b, _c;
        let select = `Select	fat_zanthus_data_m00af = A.M00AF                      
                                ,	fat_zanthus_sat_ecf_m00ac = A.M00AC                   
                                ,	fat_zanthus_cupomfiscal_m00ad = A.M00AD               
                                ,	fat_zanthus_conferencia = convert(int, 0 )
                                ,	fat_zanthus_processado = convert(int, 0 )
                                ,   fat_zanthus_pag = convert(int, 0 )
                                from		ZEUSRETAIL.DBO.ZAN_M45	A                             
                                WHERE		1 = 1                                              
                                AND A.M00AF >= '${Tools_1.default.format_Date_toStr_ShortDataBase((_a = filter.filter) === null || _a === void 0 ? void 0 : _a.datafaturamento_ini)}'
                                AND A.M00AF <= '${Tools_1.default.format_Date_toStr_ShortDataBase((_b = filter.filter) === null || _b === void 0 ? void 0 : _b.datafaturamento_fim)}'
                                AND A.M00AC = ${(_c = filter.filter) === null || _c === void 0 ? void 0 : _c.sat_ecf}  
                                `;
        console.log(select);
        return select;
        //`${result['color 5'] ? 'color 5 exists!' : 'color 5 does not exist!'}`
    }
}
exports.default = Zanthus_Ctrl_Cupom;
