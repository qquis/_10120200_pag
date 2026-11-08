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
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class reportParticipanteTipoList {
    static sql(par) {
        let sql = `SELECT 	participante_tipo_cd 
						,	participante_tipo_descricao 
					FROM 	TBPARTICIPANTE_TIPO
					ORDER BY participante_tipo_descricao asc
            `;
        return sql;
    }
    static get(par) {
        return __awaiter(this, void 0, void 0, function* () {
            let myBase = new modelbase_1.clsBase();
            try {
                let result = yield myBase.myDataBase.pag.DataGet(this.sql(par));
                return result;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('reportParticipanteTipoList', 'get', e);
                throw new Error('Error in reportParticipanteTipoList.get');
            }
        });
    }
}
exports.default = reportParticipanteTipoList;
