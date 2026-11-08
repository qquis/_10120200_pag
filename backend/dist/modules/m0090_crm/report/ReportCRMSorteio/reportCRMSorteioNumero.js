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
const modelcrm_soteio_numero_1 = __importDefault(require("../../model/modelcrm_soteio_numero"));
class reportCRMSorteioConsultarNumero {
    static sql(parametro) {
        console.log('reportCRMSorteioConsultarNumero - sql', parametro);
        let sql = `
                    SELECT  			
                        n.crm_so_temp_cd
                    ,   n.crm_so_numero_seq 
                    ,   n.crm_so_numero_ordem
                    ,   n.numero 				
                    ,	x.crm_so_cupom_seq			
                    ,	x.numero_cupom				
                    ,	x.numero_pedido 				
                    ,	x.data_emissao				
                    ,   x.sat_ecf						
                    ,	x.nf_numero					
                    ,	x.nf_data_emissao				
                    ,	x.nf_chave					
                    ,	x.valor						
                    ,	x.cpf_cnpj					
                    ,   x.cdparticipante				
                    ,   x.crm_so_cpf					
                    ,   x.crm_so_qtde_numero_sorteio    

                    FROM        tbcrm_sorteio_numero n
                    inner join   tbcrm_sorteio_cupom  X on n.crm_so_cupom_seq = x.crm_so_cupom_seq and n.crm_so_temp_cd = x.crm_so_temp_cd
                    WHERE 1 = 1
                    ${(parametro.crm_so_temp_cd) ? ` AND n.crm_so_temp_cd = ${Number(parametro.crm_so_temp_cd)} ` : ``}
                    ${parametro.nao_registrado ? ` AND coalesce(x.crm_so_registrado,0) in (0,1) ` : ` AND x.crm_so_registrado = 1 `}
                    ${(parametro.cpf_cnpj) ? ` AND cpf_cnpj = '${modelbase_1.clsTools.document.formatdb(parametro.cpf_cnpj)}' ` : ``}
                    ${(parametro.numero_cupom) ? ` AND x.numero_cupom = '${parametro.numero_cupom}' ` : ``}
                    ${(parametro.nf_chave) ? ` AND n.nf_chave = '${parametro.nf_chave}' ` : ``}
                    ${(parametro.crm_so_cpf) ? ` AND x.crm_so_cpf = '${modelbase_1.clsTools.document.formatdb(parametro.crm_so_cpf)}' ` : ``}
                    ${(parametro.crm_so_temp_cd && parametro.crm_so_temp_cd !== '0') ? ` AND n.crm_so_temp_cd = ${parametro.crm_so_temp_cd} ` : ``}
                ORDER BY x.crm_so_cupom_seq DESC
                ${(parametro.limit && parametro.limit > 0) ? ` LIMIT ${parametro.limit} ` : ``}
                
       `;
        return sql;
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let mylist = [];
            try {
                const modeldb = new modelbase_1.clsBase();
                let result = yield modeldb.myDataBase.pag.DataGet(this.sql(parametro));
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let item = new modelcrm_soteio_numero_1.default();
                        item.model_biding(value);
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
            catch (error) {
                modelbase_1.clsTools.PagErrorException("M0090_CRM", "reportCRMSorteioConsultarCupom - get", error);
                throw error;
            }
            finally {
                return mylist;
            }
        });
    }
}
exports.default = reportCRMSorteioConsultarNumero;
