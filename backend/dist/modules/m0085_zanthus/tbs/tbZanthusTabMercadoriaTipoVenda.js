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
const model_1 = require("../../../model/model");
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class tbZanthusTabMercadoriaTipoVenda extends model_1.modelTb {
    constructor() {
        super();
        this.tab_pre_cd = 1;
        this.pr_cdproduto = 0;
        this.prb_cdprodutobluesoft = 0;
        this.preg_cdbarra = ``;
        this.cod_loja = 0;
        this.controle = ``;
        this.cod_mercadoria = ``;
        this.cod_tipo_venda = 0;
        this.usuario = ``;
        this.data_cadastro = this.__defaultDateNow;
        this.data_ultima_alteracao = this.__defaultDateNow;
        this.preco_unitario = 0;
        this.percentual_comissao_vendedor = 0;
        this.preco_anterior = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.tab_pre_cd = parseInt(item === null || item === void 0 ? void 0 : item.tab_pre_cd);
                this.pr_cdproduto = parseInt(item === null || item === void 0 ? void 0 : item.pr_cdproduto);
                this.prb_cdprodutobluesoft = parseInt(item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft);
                this.preg_cdbarra = item === null || item === void 0 ? void 0 : item.preg_cdbarra;
                this.cod_loja = parseInt(item === null || item === void 0 ? void 0 : item.cod_loja);
                this.controle = item === null || item === void 0 ? void 0 : item.controle;
                this.cod_mercadoria = item === null || item === void 0 ? void 0 : item.cod_mercadoria;
                this.cod_tipo_venda = parseInt(item === null || item === void 0 ? void 0 : item.cod_tipo_venda);
                this.usuario = item === null || item === void 0 ? void 0 : item.usuario;
                this.data_cadastro = this.__defaultDateNow;
                this.data_ultima_alteracao = this.__defaultDateNow;
                this.preco_unitario = parseFloat(item === null || item === void 0 ? void 0 : item.preco_unitario);
                this.percentual_comissao_vendedor = parseFloat(item === null || item === void 0 ? void 0 : item.percentual_comissao_vendedor);
                this.preco_anterior = parseFloat(item === null || item === void 0 ? void 0 : item.preco_anterior);
            }
            catch (e) {
                Tools_1.default.pagConsole(`M0085 _ Zanthus | tbZanthusTab_Mercadoria_Tipo_Venda.binding 
                Error: 
                ${e}    
                `);
            }
        });
    }
    ZanthusPostGre_CRUD() {
        try {
            let script = `
                	INSERT INTO	TAB_MERCADORIA_TIPO_VENDA 
                            (	cod_loja,
                                controle,
                                cod_mercadoria,
                                cod_tipo_venda,
                                preco_unitario,
                                percentual_comissao_vendedor,
                                usuario,
                                data_cadastro,
                                data_ultima_alteracao )
                        SELECT			DISTINCT
                                        ${this.cod_loja}
                                    ,	'${this.controle}'
                                    ,	'${this.cod_mercadoria}'
                                    ,	${this.cod_tipo_venda}
                                    ,	${this.preco_unitario} 
                                    ,	${this.percentual_comissao_vendedor}
                                    ,	'${this.usuario}' 
                                    ,  ('${this.data_cadastro}'::timestamp)
                                    ,  ('${this.data_ultima_alteracao}'::timestamp)
                        WHERE NOT EXISTS ( SELECT 1 
                                           FROM   TAB_MERCADORIA_TIPO_VENDA a
                                           WHERE  a.cod_mercadoria = '${this.cod_mercadoria}' 
                                             AND  a.cod_tipo_venda = ${this.cod_tipo_venda}
                                          )

                        ;
                        
                        UPDATE TAB_MERCADORIA_TIPO_VENDA x 
                        SET    preco_unitario = ${this.preco_unitario} 
                           ,   percentual_comissao_vendedor = ${this.percentual_comissao_vendedor}
                           ,   data_ultima_alteracao = ('${this.data_ultima_alteracao}'::timestamp)
                        WHERE  1 = 1
                          AND  x.cod_mercadoria = '${this.cod_mercadoria}'
                          AND  x.cod_tipo_venda = ${this.cod_tipo_venda}
                        
                        ;
            `;
            return script;
        }
        catch (e) {
            Tools_1.default.pagConsole(`M0085_ZANTHUS | tbZanthusTabMercadoria - _Db_Pg_script_CRUD
                                Item ${this.pr_cdproduto} | cod_tipo_venda ${this.cod_tipo_venda} | preço : ${this.preco_unitario}
                                Error \n ${e}
                               `);
            return ``;
        }
    }
}
exports.default = tbZanthusTabMercadoriaTipoVenda;
