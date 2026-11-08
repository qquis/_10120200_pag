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
class reportSistemaNucleoProcedimento {
    static sql(parametros = {}) {
        try {
            return `    select 		p.sis_nucleo_cd_fk                          as sis_nucleo_cd
                                ,	n.sis_nucleo_descricao                      as sis_nucleo_descricao         
                                ,	p.sis_nucleo_prc_cd                         as sis_nucleo_prc_cd
                                ,	coalesce(sis_nucleo_prc_descritivo, '')     as sis_nucleo_prc_descritivo
                                ,	coalesce(sis_nucleo_prc_tipo,0)             as sis_nucleo_prc_tipo
                                ,	p.data_default_ini                          as data_default_ini
                                ,	p.data_default_ini                          as data_default_fim
                                ,	p.dateadd_ini                               as dateadd_ini
                                ,	p.dateadd_fim                               as dateadd_fim
                                ,   p.data_reprocessamento_default              as data_reprocessamento_ini
                                ,   p.data_reprocessamento_default_fim          as data_reprocessamento_fim
                                ,	p.permite_execucao_manual                   as permite_execucao_manual
                                ,   coalesce(p.limite_reg_bloq_update, 0)       as limite_reg_bloq_update
                        from 		tbsistema_nucleo_procedimento p
                        left join   tbsistema_nucleo n on n.sis_nucleo_cd_pk = p.sis_nucleo_cd_fk
                        where       1 = 1
                        ${parametros.sis_nucleo_cd ? ` and p.sis_nucleo_cd_fk = '${parametros.sis_nucleo_cd}'` : ''}
        `;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);
            return '';
        }
    }
    static get() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}) {
            const myTools = new modelbase_1.clsBase();
            try {
                let result = yield myTools.myDataBase.pag.DataGet(this.sql(parametros));
                return result; //await myTools.myDataBase.pag.DataGet(this.sql(parametros));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0001 - Sistema`, 'reportSistemaNucleoProcedimento', e);
            }
        });
    }
}
exports.default = reportSistemaNucleoProcedimento;
