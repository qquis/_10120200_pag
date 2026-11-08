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
class reportParticipanteBlueSoftList {
    static sql(par) {
        let sql = `SELECT 	b.cdparticipante
						,	b.cdpessoabluesoft
						,	b.cpf_cnpj 
						,	b.pessoajuridica
						,	b.bluesoft_pessoa_data_cadastro 
						,	b.bluesoft_pessoa_status
						,	b.nome_razao 
						,	b.nome_abreviado
						,	b.bluesoftcliente
						,	b.bluesoftclientestatus
						,	b.cdgrupoeconomico 
						,	ge.descricao 
						,	b.cdpessoabluesoft_vendedor
						,   pv.nome_razao as nome_vendedor
						,	b.bluesoftvendedor
						,	b.bluesoftfornecedor
						,	b.bluesoftfabricante
						,	b.bluesoftmotorista
					from 	tbparticipante_bluesoft b
					left join tbgrupoeconomico ge on ge.cdgrupoeconomico = b.cdgrupoeconomico
					left join tbparticipante   pv on pv.cdpessoabluesoft = b.cdpessoabluesoft_vendedor AND b.cdpessoabluesoft_vendedor > 0 
					where 		1 = 1
			${par.cdparticipante ? `and b.cdparticipante = ${par.cdparticipante}` : ''}
			${par.cpf_cnpj ? `and LPAD(b.cpf_cnpj,14,'0') = LPAD(${par.cpf_cnpj},14,'0')` : ''}
			${par.nome_razao ? `and UPPER(b.nome_razao) like UPPER('%${par.nome_razao}%')` : ''}
			${par.bluesoft_motorista ? `and b.bluesoftmotorista = ${par.bluesoft_motorista}` : ''}

            `;
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
                modelbase_1.clsTools.PagErrorException('reportParticipanteBlueSoftList', 'get', e);
                throw new Error('Error in reportParticipanteBlueSoftList.get');
            }
        });
    }
}
exports.default = reportParticipanteBlueSoftList;
