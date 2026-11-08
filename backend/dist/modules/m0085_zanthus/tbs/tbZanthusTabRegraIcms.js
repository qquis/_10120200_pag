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
/*  CONSTANTES ___________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0085 ZANTHUS _ tbZanthusTabRegrasIcms";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*________________________________________________________________________________________________*/
const model_1 = require("../../../model/model");
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class tbZanthusTabRegrasIcms extends model_1.modelTb {
    constructor() {
        super();
        this.pr_cdproduto = 0;
        this.prb_cdprodutobluesoft = 0;
        this.preg_cdbarra = ``;
        this.cod_loja = 0;
        this.cod_mercadoria = ``;
        this.cod_regras_icms = 0;
        this.descricao = ``;
        this.prioridade = 0;
        this.flg_registro = ``;
        this.cod_ncm_ini = 0;
        this.cod_ncm_final = 0;
        this.uf_origem = `SP`;
        this.uf_destino = `SP`;
        this.aliquota = 0;
        this.cst = ``;
        this.perc_substituicao = 0;
        this.perc_reducao = 0;
        this.flg_tipo_imposto = ``;
        this.flg_revenda = ``;
        this.dta_val_inicial = this.__defaultDateNow;
        this.dta_val_final = this.__defaultDateNow;
        this.cst_orig = ``;
        this.usuario = ``;
        this.data_cadastro = this.__defaultDateNow;
        this.data_ultima_alteracao = this.__defaultDateNow;
        this.aliquota_interestadual = 0;
        this.valor_imposto = 0;
        this.tipo_lista_st = 0;
        this.perc_reducao_st = 0;
        this.perc_diferimento = 0;
        this.exigibilidade_iss = ``;
        this.flg_incentivo_fiscal_iss = ``;
        this.tipo_documento = `01`;
        this.codigo_beneficio_fiscal = ``;
        this.cod_class_tributaria = 0;
        this.per_cred_presumido_ibs_mono = 0;
        this.per_cred_presumido_cbs_mono = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.pr_cdproduto = parseInt(item === null || item === void 0 ? void 0 : item.pr_cdproduto);
                this.prb_cdprodutobluesoft = parseInt(item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft);
                this.preg_cdbarra = item === null || item === void 0 ? void 0 : item.preg_cdbarra;
                this.cod_loja = parseInt(item === null || item === void 0 ? void 0 : item.cod_loja);
                this.cod_mercadoria = item === null || item === void 0 ? void 0 : item.cod_mercadoria;
                this.cod_regras_icms = item === null || item === void 0 ? void 0 : item.cod_regras_icms;
                this.descricao = item === null || item === void 0 ? void 0 : item.descricao;
                this.prioridade = parseInt(item === null || item === void 0 ? void 0 : item.prioridade);
                this.flg_registro = item === null || item === void 0 ? void 0 : item.flg_registro;
                this.cod_ncm_ini = parseInt(item === null || item === void 0 ? void 0 : item.cod_ncm_ini);
                this.cod_ncm_final = parseInt(item === null || item === void 0 ? void 0 : item.cod_ncm_final);
                this.uf_origem = item === null || item === void 0 ? void 0 : item.uf_origem;
                this.uf_destino = item === null || item === void 0 ? void 0 : item.uf_destino;
                this.aliquota = parseFloat(item === null || item === void 0 ? void 0 : item.aliquota);
                this.cst = (item === null || item === void 0 ? void 0 : item.cst) ? item === null || item === void 0 ? void 0 : item.cst.trim().padStart(3, '0') : ``;
                this.perc_substituicao = item === null || item === void 0 ? void 0 : item.perc_substituicao;
                this.perc_reducao = item === null || item === void 0 ? void 0 : item.perc_reducao;
                this.flg_tipo_imposto = item === null || item === void 0 ? void 0 : item.flg_tipo_imposto;
                this.flg_revenda = item === null || item === void 0 ? void 0 : item.flg_revenda;
                this.dta_val_inicial = item === null || item === void 0 ? void 0 : item.dta_val_inicial;
                this.dta_val_final = item === null || item === void 0 ? void 0 : item.dta_val_final;
                this.cst_orig = item === null || item === void 0 ? void 0 : item.cst_orig;
                this.usuario = item === null || item === void 0 ? void 0 : item.usuario;
                this.data_cadastro = this.__defaultDateNow;
                this.data_ultima_alteracao = this.__defaultDateNow;
                this.codigo_beneficio_fiscal = item === null || item === void 0 ? void 0 : item.codigo_beneficio_fiscal;
                this.cod_class_tributaria = parseInt(item === null || item === void 0 ? void 0 : item.cod_class_tributaria);
                this.per_cred_presumido_ibs_mono = parseFloat(item === null || item === void 0 ? void 0 : item.per_cred_presumido_ibs_mono);
                this.per_cred_presumido_cbs_mono = parseFloat(item === null || item === void 0 ? void 0 : item.per_cred_presumido_cbs_mono);
            }
            catch (e) {
                Tools_1.default.pagConsole(`${FLG_MODULO} Error: ${e} `);
            }
        });
    }
    ZanthusPostGre_CRUD() {
        try {
            let script_SQL_TAB_MERCADORIA = `
                	INSERT INTO tab_regras_icms 
                                (		
                                        cod_regras_icms
                                    ,	cod_mercadoria 
                                    ,	cod_loja 
                                    ,	descricao 
                                    ,	prioridade 
                                    ,	flg_registro 
                                    ,	cod_ncm_ini 
                                    ,	cod_ncm_final 
                                    ,	uf_origem 
                                    ,	uf_destino 
                                    ,	aliquota
                                    ,	cst
                                    ,	perc_substituicao 
                                    ,	perc_reducao 
                                    ,	flg_tipo_imposto 
                                    ,	flg_revenda 
                                    ,	dta_val_inicial 
                                    ,	dta_val_final 
                                    ,	cst_orig
                                    ,	usuario 
                                    ,	data_cadastro 
                                    ,	data_ultima_alteracao 
                                    ,	aliquota_interestadual 
                                    ,	valor_imposto 
                                    ,	tipo_lista_st 
                                    ,	perc_reducao_st 
                                    ,	perc_diferimento 
                                    ,	exigibilidade_iss 
                                    ,	flg_incentivo_fiscal_iss 
                                    ,	tipo_documento
                                    ,   codigo_beneficio_fiscal
                                    ,   cod_class_tributaria
                                    ,   per_cred_presumido_ibs_mono
                                    ,   per_cred_presumido_cbs_mono
                                        )

                            SELECT	     ${this.cod_regras_icms}
                                    ,	'${this.cod_mercadoria}' 
                                    ,	 ${this.cod_loja} 
                                    ,	'${this.descricao}' 
                                    ,	 ${this.prioridade} 
                                    ,	'${this.flg_registro}' 
                                    ,	 ${this.cod_ncm_ini} 
                                    ,	 ${this.cod_ncm_final} 
                                    ,	'${this.uf_origem}' 
                                    ,	'${this.uf_destino}' 
                                    ,	 ${this.aliquota}
                                    ,	'${this.cst.trim().padStart(3, '0')}'
                                    ,	 ${this.perc_substituicao} 
                                    ,	 ${this.perc_reducao} 
                                    ,	'${this.flg_tipo_imposto}' 
                                    ,	'${this.flg_revenda}' 
                                    ,	('1900-01-01'::date )
                                    ,	('2099-12-31'::date) 
                                    ,	'${this.cst_orig}'
                                    ,	'${this.usuario}' 
                                    ,	('${this.data_cadastro}'::timestamp)
                                    ,	('${this.data_ultima_alteracao}'::timestamp) 
                                    ,	 ${this.aliquota_interestadual} 
                                    ,	 ${this.valor_imposto} 
                                    ,	 ${this.tipo_lista_st} 
                                    ,	 ${this.perc_reducao_st} 
                                    ,	 ${this.perc_diferimento} 
                                    ,	'${this.exigibilidade_iss}' 
                                    ,	'${this.flg_incentivo_fiscal_iss}'
                                    ,   '${this.tipo_documento}' 
                                    ,   '${this.codigo_beneficio_fiscal}'
                                    ,   ${this.cod_class_tributaria}
                                    ,   ${this.per_cred_presumido_ibs_mono}
                                    ,   ${this.per_cred_presumido_cbs_mono}
                            WHERE  1 = 1
                              AND  NOT EXISTS ( SELECT 1 FROM tab_regras_icms a 
                                                WHERE  1 = 1
                                                  and  a.cod_mercadoria = '${this.cod_mercadoria}'
                                                  and  a.flg_tipo_imposto = '${this.flg_tipo_imposto}' 
                                                  and  a.flg_revenda = '${this.flg_revenda}'
                                              ); 
                            UPDATE  tab_regras_icms x
                               SET  cod_ncm_ini = ${this.cod_ncm_ini}
                                ,   cod_ncm_final = ${this.cod_ncm_final}
                                ,   aliquota = ${this.aliquota}
                                ,   cst = '${this.cst.trim().padStart(3, '0')}'
                                ,   perc_reducao = ${this.perc_reducao}
                                ,   data_ultima_alteracao  = ('${this.data_ultima_alteracao}'::timestamp)
                                ,   codigo_beneficio_fiscal = ${this.codigo_beneficio_fiscal == null ? null : `'${this.codigo_beneficio_fiscal}'`}
                                ,   cod_class_tributaria = ${this.cod_class_tributaria}
                                ,   per_cred_presumido_ibs_mono = ${this.per_cred_presumido_ibs_mono}
                                ,   per_cred_presumido_cbs_mono = ${this.per_cred_presumido_cbs_mono}
                            WHERE   x.cod_mercadoria = '${this.cod_mercadoria}'
                              AND   x.flg_tipo_imposto = '${this.flg_tipo_imposto}'
                              and   x.flg_revenda = '${this.flg_revenda}'
                            ;   
                `;
            return script_SQL_TAB_MERCADORIA;
        }
        catch (e) {
            Tools_1.default.pagConsole(`${FLG_MODULO} Error: ${e} `);
            return ``;
        }
    }
}
exports.default = tbZanthusTabRegrasIcms;
