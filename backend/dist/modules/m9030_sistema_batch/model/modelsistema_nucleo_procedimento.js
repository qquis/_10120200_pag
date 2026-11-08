"use strict";
//import { Request } from 'express';
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
const _serviceNotificacao_1 = __importDefault(require("../../../modules/m0210_notificacao/service/_serviceNotificacao"));
let myClsBase = new modelbase_1.clsBase();
/*TABELAS */
const tbsistema_nucleo_procedimento_1 = __importDefault(require("../tbs/tbsistema_nucleo_procedimento"));
class modelsistema_nucleo_procedimento extends tbsistema_nucleo_procedimento_1.default {
    constructor() {
        super();
        this.ErrorMessage = ``;
    }
    dataInicial() {
        return __awaiter(this, void 0, void 0, function* () {
            let data = new Date(this.__defaultDateNow);
            try {
                data = yield this.data("inicial");
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.dataInicial Error`, e);
            }
            finally {
                return data;
            }
        });
    }
    dataFinal() {
        return __awaiter(this, void 0, void 0, function* () {
            let data = new Date(this.__defaultDateNow);
            try {
                data = yield this.data("final");
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.dataInicial Error`, e);
            }
            finally {
                return data;
            }
        });
    }
    data(type) {
        return __awaiter(this, void 0, void 0, function* () {
            let data = new Date(this.__defaultDateNow);
            try {
                let sql = ``;
                if (type === "inicial") {
                    sql = `
                     SELECT  case when coalesce(data_default_ini,0) = 1
                                  then coalesce(data_reprocessamento_default, current_date - 1)
                                  else coalesce(current_date - (-1 * dateadd_ini ), current_date - 1)
                                  end as data
                             , coalesce(data_default_ini,0) as data_manual 
                     FROM TBSISTEMA_NUCLEO_PROCEDIMENTO  
                     WHERE 1 = 1  
                     AND  SIS_NUCLEO_CD_FK = '${this.sis_nucleo_cd_fk}'  
                     AND  SIS_NUCLEO_PRC_CD = ${this.sis_nucleo_prc_cd} 
                     `;
                }
                else {
                    sql = `
                     SELECT  case when coalesce(data_default_fim,0) = 1
                                  then coalesce(data_reprocessamento_default_fim, current_date - 1)
                                  else coalesce(current_date - (-1 * dateadd_fim ), current_date - 1)
                                  end as data
                             , coalesce(data_default_fim,0) as data_manual 
                     FROM TBSISTEMA_NUCLEO_PROCEDIMENTO  
                     WHERE 1 = 1  
                     AND  SIS_NUCLEO_CD_FK = '${this.sis_nucleo_cd_fk}'  
                     AND  SIS_NUCLEO_PRC_CD = ${this.sis_nucleo_prc_cd} 
                     `;
                }
                let result = yield myClsBase.myDataBase.pag.DataGet(sql);
                if (result) {
                    data = modelbase_1.clsTools._datemomentDatStrToDate(result[0].data);
                    if (result[0].data_manual === 1) {
                        let sql_update = ``;
                        if (type === "inicial") {
                            sql_update = `update TBSISTEMA_NUCLEO_PROCEDIMENTO 
                            set data_reprocessamento_default = current_date -1
                                , data_default_ini = 0
                                , dtlog_update = current_timestamp
                             WHERE 1 = 1  
                                AND  SIS_NUCLEO_CD_FK = '${this.sis_nucleo_cd_fk}'  
                                AND  SIS_NUCLEO_PRC_CD = ${this.sis_nucleo_prc_cd} 
                    
                    `;
                        }
                        else {
                            sql_update = `update TBSISTEMA_NUCLEO_PROCEDIMENTO 
                            set data_reprocessamento_default_fim = current_date -1
                                , data_default_fim = 0
                                , dtlog_update = current_timestamp
                             WHERE 1 = 1  
                                AND  SIS_NUCLEO_CD_FK = '${this.sis_nucleo_cd_fk}'  
                                AND  SIS_NUCLEO_PRC_CD = ${this.sis_nucleo_prc_cd} 
                    
                    `;
                        }
                        yield myClsBase.myDataBase.pag.Execute(sql_update);
                    }
                }
                else {
                    data = this.__defaultDateNow;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.dataInicial Error`, e);
            }
            finally {
                return data;
            }
        });
    }
    consultar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = `
                        SELECT      m.sis_nucleo_cd_fk
                                ,   m.sis_nucleo_prc_cd
                                ,   m.sis_nucleo_prc_descricao
                                ,   m.sis_nucleo_prc_descritivo
                                ,   m.sis_nucleo_prc_tipo
                                ,   m.dateadd_ini
                                ,   m.dateadd_fim
                                ,   m.data_reprocessamento_default
                                ,   m.data_reprocessamento_default_fim
                                ,   m.permite_execucao_manual
                                ,   m.notificacao_cd
                        FROM        tbsistema_nucleo_procedimento m
                        WHERE       1 = 1 
                        and         m.sis_nucleo_prc_cd = ${this.sis_nucleo_prc_cd}
                `;
                let result = yield myClsBase.myDataBase.pag.DataGet(sql);
                if (result) {
                    yield this.binding(result[0]);
                    this.__atualizado = true;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.consultar Error`, e);
            }
        });
    }
    notificarExecucao() {
        return __awaiter(this, arguments, void 0, function* (start = false) {
            let message = ``;
            try {
                if (start) {
                    message = `🚀 Procedimento *${this.sis_nucleo_prc_cd} - ${this.sis_nucleo_prc_descricao} inicializado.*`;
                }
                else {
                    if (this.ErrorMessage || this.ErrorMessage === ``) {
                        message = `Procedimento *${this.sis_nucleo_prc_cd} - ${this.sis_nucleo_prc_descricao} foi executado com sucesso.✅ *`;
                    }
                    else {
                        message = `Procedimento ${this.sis_nucleo_prc_cd} - ${this.sis_nucleo_prc_descricao} foi executado com erro ❌`;
                    }
                }
                yield _serviceNotificacao_1.default.CriarNotificacaoNucleBatch(message);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.notificarExecucao Error`, e);
            }
            finally {
            }
        });
    }
    iniciarExecucao() {
        return __awaiter(this, void 0, void 0, function* () {
            if (this.notificacao_cd && this.notificacao_cd > 0) {
                this.notificarExecucao(true);
            }
            yield this.RegistrarLog(true);
        });
    }
    finalizarExecucao() {
        return __awaiter(this, void 0, void 0, function* () {
            if (this.notificacao_cd && this.notificacao_cd > 0) {
                this.notificarExecucao();
            }
            yield this.RegistrarLog(true);
        });
    }
    RegistrarLog(start_1) {
        return __awaiter(this, arguments, void 0, function* (start, erro = ``) {
            try {
                let sql = `insert into tbsistema_log (sis_nucleo_prc_cd, sis_log_tag, sis_log_info)
                values (${this.sis_nucleo_prc_cd}, 'NUCLEO_${this.sis_nucleo_cd_fk}_${this.sis_nucleo_prc_cd}', 'NUCLEO - ${start ? 'START' : `END ${erro ? ' _ ERROR' : ''}`} ' )
            `;
                yield myClsBase.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M9030`, `modelsistema_nucleo_procedimento.RegistrarLog Error`, e);
            }
        });
    }
}
exports.default = modelsistema_nucleo_procedimento;
