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
const modelcrm_sorteio_cupom_1 = __importDefault(require("../../model/modelcrm_sorteio_cupom"));
class reportCRMSorteioConsultarCupom {
    static sql(parametro) {
        let data_emissao_filter = new Date('1900-01-01');
        if (parametro.data_emissao) {
            data_emissao_filter = modelbase_1.clsTools._datemomentDatStrToDate(parametro.data_emissao, "YYYY-MM-DD");
        }
        let sql = `
                    SELECT  			
                    	crm_so_temp_cd				
                    ,	crm_so_cupom_seq			
                    ,	numero_cupom				
                    ,	numero_pedido 				
                    ,	data_emissao	
                    ,   data_emissao_hora			
                    ,   sat_ecf						
                    ,	nf_numero					
                    ,	nf_data_emissao				
                    ,	nf_chave					
                    ,	valor						
                    ,	cpf_cnpj					
                    ,   cdparticipante				
                    ,   crm_so_cpf					
                    ,   crm_so_qtde_numero_sorteio   
                    ,   coalesce(crm_so_externo_enviado,0) as crm_so_externo_enviado
                    ,   coalesce(crm_so_externo_enviado_data , '1900-01-01') as crm_so_externo_enviado_data

                    FROM tbcrm_sorteio_cupom X
                    WHERE 1 = 1`;
        if (parametro.crm_so_cupom_seq && parametro.crm_so_cupom_seq > 0) {
            sql += ` AND crm_so_cupom_seq = ${Number(parametro.crm_so_cupom_seq)} `;
        }
        if (parametro.status_envio_sorteio || parametro.status_envio_sorteio == 0) {
            if (parametro.status_envio_sorteio == 99) {
                sql += ` AND coalesce(crm_so_externo_enviado,0) in (0,1,9) `;
            }
            else {
                sql += ` AND coalesce(crm_so_externo_enviado,0) = ${Number(parametro.status_envio_sorteio)} `;
                sql += ` AND cpf_cnpj != '00000000000000' `;
            }
            //sql += ` AND numero_cupom = 18887`
            sql += ` AND coalesce(cpf_cnpj,'0') != '0' `;
            sql += ` AND coalesce(valor,0) > 0 `;
            sql += ` AND data_emissao = '${parametro.data_emissao}' `;
            sql += ` AND crm_so_cupom_seq > 0`;
        }
        if (parametro.consultaCupomDisponivel && parametro.consultaCupomDisponivel == 1) {
            sql += `${(parametro.cpf_cnpj) ? ` AND ( LPAD(cpf_cnpj, 14, '0') = LPAD('${parametro.cpf_cnpj}', 14, '0') OR coalesce(cpf_cnpj,'0') = '0' ) OR coalesce(cpf_cnpj,'0') = '' ` : ``} 
                            ${(parametro.nf_chave) ? ` AND nf_chave = '${parametro.nf_chave}' ` : ``}
                            ${(parametro.nf_numero) ? ` AND nf_numero = ${parametro.nf_numero} ` : ``}
                            ${(parametro.data_emissao) ? ` AND data_emissao = '${modelbase_1.clsTools._datemomentDateToStr(data_emissao_filter, 'YYYY-MM-DD')}' ` : ``}
                            ${(parametro.ecf_sat) ? ` AND sat_ecf = ${parametro.ecf_sat} ` : ``}
                    `;
        }
        else if (parametro.consultaCupomDisponivel && parametro.consultaCupomDisponivel == 0) {
            sql += `
                    ${(parametro.validacpfcrm && parametro.validacpfcrm == 1) ?
                ` AND ( LPAD(cpf_cnpj, 14, '0') = LPAD('${this}', 14, '0') OR coalesce(cpf_cnpj,'0') = '0' ) ` : ``}
                    ${(parametro.cpf_cnpj) ? ` AND cpf_cnpj = '${parametro.cpf_cnpj}' ` : ``}
                    ${(parametro.numero_cupom) ? ` AND numero_cupom = '${parametro.numero_cupom}' ` : ``}
                    ${(parametro.crm_so_temp_cd) ? ` AND crm_so_temp_cd = ${Number(parametro.crm_so_temp_cd)} ` : ``}
                    ${(parametro.nf_chave) ? ` AND nf_chave = '${parametro.nf_chave}' ` : ``}
                    ${(parametro.crm_so_cpf) ? ` AND crm_so_cpf = '${parametro.crm_so_cpf}' ` : ``}
                    ${(parametro.data_emissao ? ` AND data_emissao = '${modelbase_1.clsTools._datemomentDateToStr(parametro.data_emissao, 'YYYY-MM-DD')}' ` : ``)}
                    ) `;
        }
        sql += ` ORDER BY crm_so_cupom_seq ASC `;
        if (parametro.limit && parametro.limit > 0) {
            sql += ` LIMIT ${Number(parametro.limit)} `;
        }
        return sql;
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let mylist = new Array();
            try {
                const modeldb = new modelbase_1.clsBase();
                let result = yield modeldb.myDataBase.pag.DataGet(this.sql(parametro));
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(result)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [i, itemData] = _c;
                        let item = new modelcrm_sorteio_cupom_1.default();
                        item.binding(itemData);
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
exports.default = reportCRMSorteioConsultarCupom;
