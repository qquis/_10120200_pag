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
const modelbase_1 = require("../../../model/modelbase");
const modelOperacao_1 = __importDefault(require("../model/modelOperacao"));
class rptEnterpriseEmpresaOperacaoList {
    static sql(parametros = {}) {
        let sql = `
                        select 		i.sis_ta_cd 
                            ,		i.em_cdempresa
                            ,		e.em_descricao 
                            ,		i.op_cdoperacao
                            ,		o.op_descricao 
                            ,		p.sis_ac_cd
                            ,		u.user_name
                            ,		u.sis_us_seq 
                        from 		tbsistema_tarefa_inter 	i
                        inner join 	tbsistema_tarefa 	t on t.sis_ta_cd = i.sis_ta_cd 
                        inner join  tbsistema_permissao p on p.sis_ta_cd = t.sis_ta_cd 
                        inner join  tbsistema 			s on s.sis_cd_pk = p.sis_cd
                        inner join  tbsistema_funcao 	f on f.sis_fc_cd = p.sis_fc_Cd 
                        inner join  tbsistema_usuario   u on u.sis_fc_cd = f.sis_fc_cd 
                        inner join  tboperacao  		o on o.op_cdoperacao = i.op_cdoperacao 
                        inner join  tbempresa   		e on e.em_cdempresa = i.em_cdempresa 
                        where		1 = 1
            `;
        if (parametros.em_cdempresa) {
            sql += ` and i.em_cdempresa = ${parametros.em_cdempresa}`;
        }
        if (parametros.op_cdoperacao) {
            sql += ` and i.op_cdoperacao = ${parametros.op_cdoperacao}`;
        }
        if (parametros.__systemUserConnect && parametros.relatorio == 0) {
            if (parametros.__systemUserConnect.user_name !== '' && parametros.__systemUserConnect.user_name !== undefined) {
                sql += ` and u.user_name = '${parametros.__systemUserConnect.user_name}'`;
            }
            if (parametros.__systemUserConnect.user_credential !== ''
                && parametros.__systemUserConnect.user_credential !== 'undefined'
                && parametros.__systemUserConnect.usuario_login_uuid !== ''
                && parametros.__systemUserConnect.usuario_login_uuid !== 'undefined') {
                sql += ` and u.sis_us_seq = (select max(x.sis_us_seq) 
                                              from tbsistema_usuario_login x
                                              where 1 = 1 
                                                and x.usuario_login_uuid = '${parametros.__systemUserConnect.usuario_login_uuid}'
                                                and x.user_credential = '${parametros.__systemUserConnect.user_credential}')`;
            }
            if (parametros.__systemUserConnect.sis_ac_cd !== '' && parametros.__systemUserConnect.sis_ac_cd !== undefined) {
                sql += ` and p.sis_ac_cd = ${parametros.__systemUserConnect.sis_ac_cd}`;
            }
            if (parametros.__systemUserConnect.sis_cd !== '' && parametros.__systemUserConnect.sis_cd !== undefined) {
                sql += ` and s.sis_cd_pk = ${parametros.__systemUserConnect.sis_cd}`;
            }
        }
        return sql;
    }
    static get() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            let result = {};
            try {
                const myTools = new modelbase_1.clsBase();
                result = yield myTools.myDataBase.pag.DataGet(this.sql(parametros));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportDRresultado`, 'sql', e);
            }
            finally {
                return result;
            }
        });
    }
    static getModelOperacao() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            let list = [];
            const myTools = new modelbase_1.clsBase();
            try {
                let result = yield this.get(parametros);
                if (result && result.length > 0) {
                    for (const [key, value] of Object.entries(result)) {
                        let item = new modelOperacao_1.default();
                        yield item.binding(value);
                        list.push(item);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportDRresultado`, 'sql', e);
            }
            finally {
                return list;
            }
        });
    }
}
exports.default = rptEnterpriseEmpresaOperacaoList;
