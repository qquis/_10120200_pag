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
class reportParticipanteVipList {
    static sql(par) {
        let sql = `select 	v.cdparticipante 
						,	v.vip_cpf_cnpj 
						,	v.vip_cpf
						,	v.vip_cnpj 
						,	v.vip_nome
						,	v.vip_sobre_nome
						,	v.vip_email
						,	v.vip_data_nascimento
					from 	tbparticipante_vip v
					where 		1 = 1
			${par.cdparticipante ? `and v.cdparticipante = ${par.cdparticipante}` : ''}
			${par.vip_cpf_cnpj ? `and LPAD(v.vip_cpf_cnpj,14,'0') = LPAD(${par.vip_cpf_cnpj},14,'0')` : ''}
			${par.nome_razao ? `and UPPER(v.vip_nome) like UPPER('%${par.nome_razao}%')` : ''}
			${par.email ? `and UPPER(v.vip_email) like UPPER('%${par.email}%')` : ''}

            `;
        if (par.data_aniversario_filter && par.data_aniversario_filter_ini) {
            sql += ` and coalesce(v.vip_data_nascimento,'1900-01-01') >= ${par.data_aniversario_filter_ini}`;
        }
        if (par.data_aniversario_filter && par.data_aniversario_filter_fim) {
            sql += ` and coalesce(v.vip_data_nascimento,'1900-01-01') <= ${par.data_aniversario_filter_fim}`;
        }
        return sql;
    }
    static get(par) {
        return __awaiter(this, void 0, void 0, function* () {
            //let myBase = new clsBase()
            try {
                let result = yield modelbase_1.clsTools.PagDataBaseGet(this.sql(par));
                return result;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('reportParticipanteList', 'get', e);
                throw new Error('Error in reportParticipanteList.get');
            }
        });
    }
}
exports.default = reportParticipanteVipList;
