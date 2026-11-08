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
class tbZanthusTabProdutoDecomposicaoInsum extends model_1.modelTb {
    constructor() {
        super();
        this.pr_cdproduto = 0;
        this.prb_cdprodutobluesoft = 0;
        this.preg_cdbarra_insumo = ``;
        this.cod_loja = 0;
        this.controle = `000`;
        this.cod_mercadoria = ``;
        this.cod_insumo = ``;
        this.percentual_insumo = 0;
        this.quantidade_insumo = 0;
        this.usuario = ``;
        this.data_cadastro = this.__defaultDateNow;
        this.data_ultima_alteracao = this.__defaultDateNow;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.pr_cdproduto = parseInt(item === null || item === void 0 ? void 0 : item.pr_cdproduto);
                this.prb_cdprodutobluesoft = parseInt(item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft);
                this.preg_cdbarra_insumo = item === null || item === void 0 ? void 0 : item.preg_cdbarra_insumo;
                this.cod_loja = parseInt(item === null || item === void 0 ? void 0 : item.cod_loja);
                this.controle = item === null || item === void 0 ? void 0 : item.controle;
                this.cod_mercadoria = item === null || item === void 0 ? void 0 : item.cod_mercadoria;
                this.cod_insumo = item === null || item === void 0 ? void 0 : item.cod_insumo;
                this.percentual_insumo = parseFloat(item === null || item === void 0 ? void 0 : item.percentual_insumo);
                this.quantidade_insumo = parseFloat(item === null || item === void 0 ? void 0 : item.quantidade_insumo);
                this.usuario = item === null || item === void 0 ? void 0 : item.usuario;
                this.data_cadastro = this.__defaultDateNow;
                this.data_ultima_alteracao = this.__defaultDateNow;
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
              		INSERT INTO		TAB_produto_decomposicao_insum
                        (	
                                cod_loja 
                            ,	controle 
                            ,	cod_mercadoria 
                            ,	cod_insumo
                            ,   percentual_insumo 
                            ,	quantidade_insumo 
                            ,	usuario 
                            ,	data_cadastro 
                            ,	data_ultima_alteracao 
			            )
                        SELECT			DISTINCT
                                         ${this.cod_loja}
                                    ,	'${this.controle}'
                                    ,	'${this.cod_mercadoria}'
                                    ,	'${this.cod_insumo}'                                    
                                    ,	 ${this.percentual_insumo}
                                    ,	 ${this.quantidade_insumo}
                                    ,	'${this.usuario}' 
                                    ,  ('${this.data_cadastro}'::timestamp)
                                    ,  ('${this.data_ultima_alteracao}'::timestamp)
                        WHERE NOT EXISTS ( SELECT 1 
                                           FROM   TAB_produto_decomposicao_insum a
                                           WHERE  a.cod_mercadoria = '${this.cod_mercadoria}' 
                                             and  a.cod_insumo = '${this.cod_insumo}'
                                          )

                        ;
                        UPDATE TAB_produto_decomposicao_insum x 
                        SET    percentual_insumo = ${this.percentual_insumo}
                           ,   quantidade_insumo = ${this.quantidade_insumo}
                           ,   data_ultima_alteracao = current_timestamp
                        WHERE  1 = 1
                          AND  x.cod_mercadoria = '${this.cod_mercadoria}'
                          AND  x.cod_insumo = '${this.cod_insumo}'
                        
                        ;
                `;
            return script;
        }
        catch (e) {
            Tools_1.default.pagConsole(`M0085_ZANTHUS | tbZanthusTabProdutoDecomposicaoInsum - ZanthusPostGre_CRUD
                                Item ${this.pr_cdproduto} | Cod insumo ${this.cod_insumo} | Cod mercadoria ${this.cod_mercadoria}
                                Error \n ${e}
                               `);
            return ``;
        }
    }
}
exports.default = tbZanthusTabProdutoDecomposicaoInsum;
