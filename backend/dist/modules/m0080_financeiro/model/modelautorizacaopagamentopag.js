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
exports.modelautorizacaopagamentopag = exports.modelautorizacaoPagamentoPagRouter = void 0;
const modelbase_1 = require("../../../model/modelbase");
const express_1 = require("express");
const tbautorizacaopagamentopag_1 = __importDefault(require("../tbs/tbautorizacaopagamentopag"));
const myClsBase = new modelbase_1.clsBase();
const modelautorizacaoPagamentoPagRouter = (0, express_1.Router)();
exports.modelautorizacaoPagamentoPagRouter = modelautorizacaoPagamentoPagRouter;
modelautorizacaoPagamentoPagRouter.get("/", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let item = new modelautorizacaopagamentopag();
    try {
        if (req.query) {
            if (req.query.aut_pgto_pag_seq) {
                yield item.select({ aut_pgto_pag_seq: req.query.aut_pgto_pag_seq });
            }
        }
        else {
            yield item.new();
        }
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0080", "modelautorizacaoPagamentoPagRouter", e);
    }
    finally {
        return res.send(item);
    }
}));
modelautorizacaoPagamentoPagRouter.post("/", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    const modelautorizacaopagamentopagPost = new modelautorizacaopagamentopag();
    yield modelautorizacaopagamentopagPost.update(req.body);
    return res.send(modelautorizacaopagamentopagPost);
}));
class modelautorizacaopagamentopag extends tbautorizacaopagamentopag_1.default {
    constructor() {
        super();
        this.nome_razao = ``;
        this.descritivo = ``;
        this.r_conta_descricao = ``;
        this.user_name = ``;
        this.user_name_cancelador = ``;
        this.competencia_descricao = ``;
        this.new();
    }
    new() {
        return __awaiter(this, void 0, void 0, function* () {
            this.aut_pgto_pag_uuid = modelbase_1.clsTools.uuid(10, false);
        });
    }
    update(DataBory) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                this.binding(DataBory);
                if (this.aut_pgto_pag_seq == 0) {
                    sql = `insert into tbautorizacaopagamentopag
                            (	sis_us_seq	
                            ,   aut_pgto_pag_uuid	
                            ,	competencia_cd 			
                            ,	em_cdempresa		
                            ,   r_conta_cd 	
                            ,	aut_pgto_pag_data 		
                            ,	cdparticipante			
                            ,	aut_pgto_pag_data_pgto  
                            ,	aut_pgto_pag_valor		
                            ,   aut_pgto_pag_obs
                            ,   debitocredito
                            ,   aut_pgto_pag_tipo_cd 
                            )
                        SELECT 
                                ${this.sis_us_seq}
                            ,   '${this.aut_pgto_pag_uuid}'     
                            ,   ${this.competencia_cd}
                            ,   ${this.em_cdempresa}
                            ,   ${this.r_conta_cd}
                            ,   '${modelbase_1.clsTools._datemomentDateToStr(this.aut_pgto_pag_data, "YYYY-MM-DD")}'
                            ,   ${this.cdparticipante}
                            ,   '${modelbase_1.clsTools._datemomentDateToStr(this.aut_pgto_pag_data_pgto, "YYYY-MM-DD")}'
                            ,   ${this.aut_pgto_pag_valor}
                            ,   '${this.aut_pgto_pag_obs}'
                            ,   ${this.debitocredito}
                            ,   '${this.aut_pgto_pag_tipo_cd}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbautorizacaopagamentopag WHERE aut_pgto_pag_uuid = '${this.aut_pgto_pag_uuid}')
                        `;
                }
                else {
                    sql = `UPDATE tbautorizacaopagamentopag 
                        set   aut_pgto_pag_obs = '${this.aut_pgto_pag_obs}' 
                            where aut_pgto_pag_seq = ${this.aut_pgto_pag_seq}    
                        `;
                    if (this.aut_pgto_pag_cancelado == 1) {
                        sql = `update tbautorizacaopagamentopag 
                                set  aut_pgto_pag_cancelado = ${this.aut_pgto_pag_cancelado}
                                ,    aut_pgto_pag_cancelado_data = current_timestamp 
                                ,    aut_pgto_pag_cancelado_sis_us_seq = ${this.aut_pgto_pag_cancelado_sis_us_seq}
                                ,    aut_pgto_pag_obs = '${this.aut_pgto_pag_obs}' 
                            where aut_pgto_pag_seq = ${this.aut_pgto_pag_seq}
                        `;
                    }
                }
                yield myClsBase.myDataBase.pag.Execute(sql);
                yield this.select({ aut_pgto_pag_uuid: this.aut_pgto_pag_uuid });
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("M0080-Financeiro", "FinanceiroPag/Insert", e);
            }
        });
    }
    select(filtros) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = `SELECT   x.dtlog_insert 
                        ,   x.aut_pgto_pag_seq 
                        ,   x.sis_us_seq
                        ,   x.aut_pgto_pag_uuid	
                        ,	x.competencia_cd 			
                        ,	x.em_cdempresa		
                        ,   x.r_conta_cd 	
                        ,	x.aut_pgto_pag_data 		
                        ,	x.cdparticipante			
                        ,	x.aut_pgto_pag_data_pgto  
                        ,	x.aut_pgto_pag_valor	
                        ,   coalesce(r.r_conta_descricao,'') as r_conta_descricao 
                        ,   coalesce(p.nome_razao , '') as nome_razao 
                        ,   coalesce(x.aut_pgto_pag_cancelado,0) as aut_pgto_pag_cancelado
                        ,   coalesce(x.aut_pgto_pag_cancelado_data, current_timestamp) as aut_pgto_pag_cancelado_data
                        ,   coalesce(x.aut_pgto_pag_cancelado_sis_us_seq,0) as aut_pgto_pag_cancelado_sis_us_seq
                        ,   coalesce(aut_pgto_pag_obs, '') as aut_pgto_pag_obs
                   FROM         tbautorizacaopagamentopag x
                   LEFT JOIN    tbresultado_conta r on r.r_conta_cd = x.r_conta_cd 
                   LEFT JOIN    tbparticipante p on p.cdparticipante = x.cdparticipante 
                   where 1 = 1
                   ${(filtros.aut_pgto_pag_uuid) ? " and x.aut_pgto_pag_uuid = '" + filtros.aut_pgto_pag_uuid + "'" : ""}
                   ${(filtros.aut_pgto_pag_seq) ? " and x.aut_pgto_pag_seq = " + filtros.aut_pgto_pag_seq : ""}        
                `;
            let result = yield myClsBase.myDataBase.pag.DataGet(sql);
            let dataItem = yield myClsBase.myDataBase.RecordItem(result, 0);
            if (dataItem) {
                this.binding(dataItem);
                this.nome_razao = dataItem === null || dataItem === void 0 ? void 0 : dataItem.nome_razao;
                this.r_conta_descricao = dataItem === null || dataItem === void 0 ? void 0 : dataItem.r_conta_descricao;
                this.user_name = (dataItem === null || dataItem === void 0 ? void 0 : dataItem.user_name) || '';
                this.user_name_cancelador = (dataItem === null || dataItem === void 0 ? void 0 : dataItem.user_name_cancelador) || '';
                this.competencia_descricao = (dataItem === null || dataItem === void 0 ? void 0 : dataItem.competencia_descricao) || '';
            }
        });
    }
}
exports.modelautorizacaopagamentopag = modelautorizacaopagamentopag;
