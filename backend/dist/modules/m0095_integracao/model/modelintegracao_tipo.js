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
const tbintegracao_tipo_1 = __importDefault(require("../tbs/tbintegracao_tipo"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const tbintegracao_tipo_info_1 = __importDefault(require("../tbs/tbintegracao_tipo_info"));
const DataBase_1 = __importDefault(require("../../../database/DataBase"));
const model_1 = require("../../../model/model");
let myDATABASE = new DataBase_1.default();
class modelintegracao_tipo extends model_1.modelbase {
    constructor(item) {
        super();
        this.integracao_tipo = new tbintegracao_tipo_1.default();
        this.integracao_tipo_info = new tbintegracao_tipo_info_1.default();
        this.integracao_pendente_qtde = 0;
        this.script_select = ``;
        this.sis_batch_run_seq = 0;
        this.sis_batch_descricao = `NAO IDENTIFICADO`;
        if (item) {
            this.integracao_tipo.integracao_cd = item === null || item === void 0 ? void 0 : item.integracao_cd;
            this.integracao_tipo.integracao_tipo_cd = item === null || item === void 0 ? void 0 : item.integracao_tipo_cd;
            this.integracao_tipo.integracao_tipo_descricao = item === null || item === void 0 ? void 0 : item.integracao_tipo_descricao;
            this.integracao_tipo.zanthus = item === null || item === void 0 ? void 0 : item.zanthus;
            this.integracao_tipo.bluesoft_redshift = item === null || item === void 0 ? void 0 : item.bluesoft_redshift;
            this.integracao_tipo.bluesoft_api = item === null || item === void 0 ? void 0 : item.bluesoft_api;
            this.integracao_tipo.tipo_export = item === null || item === void 0 ? void 0 : item.tipo_export;
            this.integracao_tipo.sis_batch_cd = item === null || item === void 0 ? void 0 : item.sis_batch_cd;
            this.integracao_pendente_qtde = item === null || item === void 0 ? void 0 : item.integracao_pendente_qtde;
            this.script_select = item === null || item === void 0 ? void 0 : item.script_select;
            this.sis_batch_descricao = item === null || item === void 0 ? void 0 : item.sis_batch_descricao;
            if ((item === null || item === void 0 ? void 0 : item.sis_batch_run_seq) !== undefined)
                this.sis_batch_run_seq = item === null || item === void 0 ? void 0 : item.sis_batch_run_seq;
            this.integracao_tipo_info.script_select = item === null || item === void 0 ? void 0 : item.script_select;
            this.integracao_tipo_info.sis_batch_cd = item === null || item === void 0 ? void 0 : item.sis_batch_cd;
        }
    }
    FinalizarTodosIntegracaoDeProdutoPendentes() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let stringSQL = `UPDATE tbintegracao_produto 
                                set  integracao_status_cd = 1
                                   , dtlog_update = current_timestamp 
                              where  1 = 1
                                and  integracao_tipo_cd = ${this.integracao_tipo.integracao_tipo_cd}
                                and  integracao_status_cd = 2
                            `;
                yield myDATABASE.pag.Execute(stringSQL);
            }
            catch (e) {
                Tools_1.default.pagConsole(` (ERROR) F0095 | modelintegracao_tipo 
                                 Method FinalizarTodosRegistrosPendentes
                                 ${e}
                                `);
            }
        });
    }
    GerarPendenciaDePrecos() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (this.integracao_tipo.integracao_tipo_cd == 20008501) {
                    let sql = `
                INSERT INTO tbintegracao_produto 	
                            (
                                    pr_cdproduto 
                                ,	prb_cdprodutobluesoftunitario 
                                ,	prb_cdprodutobluesoft
                                ,	integracao_tipo_cd 
                                ,	integracao_status_cd 
                            )
                                SELECT 		pr.pr_cdproduto 
                                        ,	pr.prb_cdprodutobluesoft 
                                        ,	pr.prb_cdprodutobluesoft 
                                        ,	${this.integracao_tipo.integracao_tipo_cd}
                                        ,	2
                                from   		tbpreco_log pl
                                inner join  tbproduto   pr on pr.pr_cdproduto = pl.pr_cdproduto 
                                where       pr.pr_status = 'true'
                                and  		prc_data_aplicacao >= current_date - interval '1 day'
                                and         not exists ( 	select 1 
                                                            from   tbintegracao_produto x
                                                            where  x.pr_cdproduto = pr.pr_cdproduto 
                                                            and  x.prb_cdprodutobluesoftunitario  = pr.prb_cdprodutobluesoft 
                                                            and  x.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 		
                                                            and  x.integracao_tipo_cd = ${this.integracao_tipo.integracao_tipo_cd}
                                            )
                                group by    pr.pr_cdproduto 
                                        ,	pr.prb_cdprodutobluesoft

                            ;
                        
                        UPDATE 	tbintegracao_produto XX
                        SET   integracao_status_cd = 2
                            , dtlog_update = current_timestamp
                        FROM (
                                    SELECT 		pr.pr_cdproduto 
                                            ,	pr.prb_cdprodutobluesoft 
                                    from   		tbpreco_log pl
                                    inner join  tbproduto   pr on pr.pr_cdproduto = pl.pr_cdproduto 
                                    where       pr.pr_status = 'true'
                                    and  		prc_data_aplicacao >= current_date - interval '1 day'
                                    group by    pr.pr_cdproduto 
                                    ,	pr.prb_cdprodutobluesoft
                            ) AA
                        WHERE XX.integracao_tipo_cd = ${this.integracao_tipo.integracao_tipo_cd}
                        AND AA.pr_cdproduto = XX.pr_cdproduto 
                        AND AA.prb_cdprodutobluesoft = XX.prb_cdprodutobluesoftunitario 
                        AND AA.prb_cdprodutobluesoft = XX.prb_cdprodutobluesoft 
                    ;	
                `;
                    yield myDATABASE.pag.Execute(sql);
                }
            }
            catch (e) {
                Tools_1.default.PagErrorException("F0095 - modelintegracao_tipo", "GerarPendenciaDePrecos", e, true);
            }
        });
    }
}
exports.default = modelintegracao_tipo;
