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
const modelUserPermissao_1 = __importDefault(require("../model/modelUserPermissao"));
class reportPermissaolist {
    static sql(parametros = {}) {
        try {
            if (!parametros.relatorio) {
                parametros.relatorio = 0;
            }
            let sql = `	SELECT 	s.sis_cd_pk	as sis_cd
                            ,   s.sis_descricao
                            ,   us.sis_us_seq 
   							,	us.sis_fc_cd
                            ,	fc.sis_fc_descricao
							,	ac.sis_ac_cd
							,	ac.sis_ac_descricao 
							,	ac.sis_ac_menu
							,	ta.sis_ta_cd
							,	ta.sis_ta_descricao 
							,	s.sis_cd_pk 
							,	ac.sis_ac_gmenu_cd
							,	sis_ac_gmenu			
							,	sis_ac_gmenu_sub		
							,	sis_ac_gmenu_sub_item	
                            ,   md.sis_ac_modulo_menu_cd
                            ,   md.sis_ac_modulo_menu_descricao 
                            ,   ac.sis_ac_href  							
					FROM 		TBSISTEMA_USUARIO 		us
					inner join  tbsistema_funcao 		fc on fc.sis_fc_cd = us.sis_fc_cd
					inner join  tbsistema_permissao     pm on pm.sis_fc_cd = fc.sis_fc_Cd 
					inner join  tbsistema_acesso        ac on ac.sis_ac_cd = pm.sis_ac_cd 
                                                and ac.sis_cd = pm.sis_cd
					inner join  tbsistema_tarefa        ta on ta.sis_ta_cd = pm.sis_ta_cd 
					inner join  tbsistema				 s on s.sis_cd_pk = ac.sis_cd 
					inner join  tbsistema_acesso_grupomenu x on x.sis_ac_gmenu_cd = ac.sis_ac_gmenu_cd
                    inner join  tbsistema_acesso_modulomenu md on md.sis_ac_modulo_menu_cd = x.sis_ac_modulo_menu_cd
					left  join  tbparticipante_bluesoft pb on pb.cdpessoabluesoft = us.cdpessoabluesoft 
					left  join  tbparticipante          p on p.cdparticipante = pb.cdparticipante 
					WHERE      	1 = 1
                        ${parametros.sis_us_seq ? `and us.sis_us_seq = ${parametros.sis_us_seq}` : ''}
                        ${parametros.sis_cd && parametros.sis_cd !== '0' ? `and pm.sis_cd = ${parametros.sis_cd}` : ''}
                        ${parametros.sis_fc_cd ? `and pm.sis_fc_cd = ${parametros.sis_fc_cd}` : ''}
                        ${parametros.sis_ac_cd ? `and pm.sis_ac_cd = ${parametros.sis_ac_cd}` : ''}                                
                        ${parametros.sis_ta_cd ? `and pm.sis_ta_cd = ${parametros.sis_ta_cd}` : ''}
                    `;
            if (parametros.__systemUserConnect && parametros.relatorio === 0) {
                if (parametros.__systemUserConnect.user_name !== '' && parametros.__systemUserConnect.user_name !== undefined) {
                    sql += ` and us.user_name = '${parametros.__systemUserConnect.user_name}'`;
                }
                if (parametros.__systemUserConnect.user_credential !== ''
                    && parametros.__systemUserConnect.user_credential !== 'undefined'
                    && parametros.__systemUserConnect.usuario_login_uuid !== ''
                    && parametros.__systemUserConnect.usuario_login_uuid !== 'undefined') {
                    sql += ` and us.sis_us_seq = (select max(x.sis_us_seq) 
                                              from tbsistema_usuario_login x
                                              where 1 = 1 
                                                and x.usuario_login_uuid = '${parametros.__systemUserConnect.usuario_login_uuid}'
                                                and x.user_credential = '${parametros.__systemUserConnect.user_credential}')`;
                }
                if (parametros.__systemUserConnect.sis_ac_cd !== '' && parametros.__systemUserConnect.sis_ac_cd !== undefined) {
                    sql += ` and ac.sis_ac_cd = ${parametros.__systemUserConnect.sis_ac_cd}`;
                }
                if (parametros.__systemUserConnect.sis_cd !== '' && parametros.__systemUserConnect.sis_cd !== undefined) {
                    sql += ` and s.sis_cd_pk = ${parametros.__systemUserConnect.sis_cd}`;
                }
            }
            return sql;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportPermissaolist`, 'sql', e);
            return '';
        }
    }
    static get() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            let list;
            try {
                const myTools = new modelbase_1.clsBase();
                list = yield myTools.myDataBase.pag.DataGet(this.sql(parametros));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportPermissaolist', e);
                throw new Error(`reportPermissaolist.get`);
            }
            finally {
                return list;
            }
        });
    }
    static getModel() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            let list = [];
            try {
                const myTools = new modelbase_1.clsBase();
                let data = yield this.get(parametros);
                if (data && data.length > 0) {
                    let item;
                    for (let i = 0; i < data.length; i++) {
                        item = new modelUserPermissao_1.default();
                        item.binding(data[i]);
                        list.push(item);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportPermissaolist', e);
                throw new Error(`reportPermissaolist.getModel`);
            }
            finally {
                return list;
            }
        });
    }
}
exports.default = reportPermissaolist;
