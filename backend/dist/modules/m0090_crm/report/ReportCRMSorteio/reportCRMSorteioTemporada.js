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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../../model/modelbase");
const modelcrm_soterio_temporada_1 = __importDefault(require("../../model/modelcrm_soterio_temporada"));
class reportCRMSorteioTemporada {
    static sql(parametros) {
        let sql = `
        
                select  	crm_so_temp_cd			
                            ,	crm_so_temp_descricao 	
                            ,	crm_so_temp_valor_minimo
                            ,   crm_so_temp_status	
                            ,   crm_so_temp_data_ini
                            ,   crm_so_temp_data_fim
                    from tbcrm_sorteio_temporada        
                where 1 = 1
                ${(parametros.crm_so_temp_descricao && parametros.crm_so_temp_descricao != '') ? ` and crm_so_temp_descricao like '%${parametros.crm_so_temp_descricao}%' ` : ``}
                ${(parametros.apenas_ativa && parametros.apenas_ativa == 1) ? ` and crm_so_temp_status = 1 ` : ``}
                  
            `;
        return sql;
    }
    static get(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            {
                let mylist = [];
                try {
                    //Apenas uma temporada pode estar ativa
                    const modeldb = new modelbase_1.clsBase();
                    let result = yield modeldb.myDataBase.pag.DataGet(this.sql(parametros));
                    try {
                        for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                            _c = _f.value;
                            _d = false;
                            const [key, value] = _c;
                            let item = new modelcrm_soterio_temporada_1.default();
                            Object.assign(item, value);
                            mylist.push(item);
                        }
                    }
                    catch (e_1_1) { e_1 = { error: e_1_1 }; }
                    finally {
                        try {
                            if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                        }
                        finally { if (e_1) throw e_1.error; }
                    }
                }
                catch (e) {
                    modelbase_1.clsTools.PagErrorException(`reportCRMSorteioTemporada.get`, `get`, e);
                }
                finally {
                    return mylist;
                }
            }
        });
    }
    static getTemporadaAtiva() {
        return __awaiter(this, void 0, void 0, function* () {
            let item = new modelcrm_soterio_temporada_1.default();
            try {
                let list = yield this.get({ apenas_ativa: 1 });
                if (list.length > 0) {
                    item = list[0];
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportCRMSorteioTemporada.getTemporadaAtiva`, `getTemporadaAtiva`, e);
            }
            finally {
                return item;
            }
        });
    }
}
exports.default = reportCRMSorteioTemporada;
