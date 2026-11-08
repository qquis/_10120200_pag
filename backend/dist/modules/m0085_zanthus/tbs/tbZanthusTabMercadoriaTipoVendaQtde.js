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
class tbZanthusTabMercadoriaTipoVendaQtde extends model_1.modelTb {
    constructor() {
        super();
        this.pr_cdproduto = 0;
        this.prb_cdprodutobluesoft = 0;
        this.preg_cdbarra = ``;
        this.cod_loja = 0;
        this.cod_mercadoria = ``;
        this.cod_tipo_venda = 0;
        this.qtde_venda = 0;
        this.flag_geral = 0;
        this.preco_unitario = 0;
        this.perc_desconto = 0;
        this.flg_ativo = "S";
        this.dth_inclusao = this.__defaultDateNow;
        this.dth_alteracao = this.__defaultDateNow;
        this.idt_usuario_alteracao = ``;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.pr_cdproduto = parseInt(item === null || item === void 0 ? void 0 : item.pr_cdproduto);
                this.prb_cdprodutobluesoft = parseInt(item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft);
                this.preg_cdbarra = item === null || item === void 0 ? void 0 : item.preg_cdbarra;
                this.cod_loja = parseInt(item === null || item === void 0 ? void 0 : item.cod_loja);
                this.cod_mercadoria = item === null || item === void 0 ? void 0 : item.cod_mercadoria;
                this.cod_tipo_venda = parseInt(item === null || item === void 0 ? void 0 : item.cod_tipo_venda);
                this.qtde_venda = parseFloat(item === null || item === void 0 ? void 0 : item.qtde_venda);
                this.flag_geral = 0;
                this.preco_unitario = parseFloat(item === null || item === void 0 ? void 0 : item.preco_unitario);
                this.perc_desconto = parseFloat(item === null || item === void 0 ? void 0 : item.perc_desconto);
                this.flg_ativo = "S";
                this.idt_usuario_alteracao = item === null || item === void 0 ? void 0 : item.usuario;
                this.dth_inclusao = this.__defaultDateNow;
                this.dth_alteracao = this.__defaultDateNow;
            }
            catch (e) {
                Tools_1.default.pagConsole(`M0085 _ Zanthus | tbZanthusTabMercadoriaTipoVendaQtde.binding 
                Error: 
                ${e}    
                `);
            }
        });
    }
    ZanthusPostGre_CRUD() {
        try {
            let script = `
                	INSERT INTO	tab_mercadoria_tipo_venda_qtde 
                            (	    cod_loja
                                ,	cod_mercadoria
                                ,	cod_tipo_venda
                                ,	flag_geral
                                ,	qtde_venda
                                ,	preco_unitario
                                ,	perc_desconto
                                ,	flag_ativo
                                ,	Dth_inclusao
                                ,	Dth_alteracao
                                ,	Idt_usuario_alteracao
                            )
                        SELECT			DISTINCT
                                        ${this.cod_loja}
                                    ,	'${this.cod_mercadoria}'
                                    ,	${this.cod_tipo_venda}
                                    ,   ${this.flag_geral}
                                    ,   ${this.qtde_venda}
                                    ,	${this.preco_unitario} 
                                    ,	${this.perc_desconto} 
                                    ,   '${this.flg_ativo}'
                                    ,	('${this.dth_inclusao}'::timestamp)
                                    ,	('${this.dth_alteracao}'::timestamp)
                                    ,	'${this.idt_usuario_alteracao}' 
                        WHERE NOT EXISTS ( SELECT 1 
                                           FROM   tab_mercadoria_tipo_venda_qtde a
                                           WHERE  a.cod_mercadoria = '${this.cod_mercadoria}' 
                                             AND  a.cod_tipo_venda = ${this.cod_tipo_venda}
                                          )
                        ;
                        UPDATE tab_mercadoria_tipo_venda_qtde x 
                        SET    preco_unitario = ${this.preco_unitario} 
                           ,   Dth_alteracao = ('${this.dth_alteracao}'::timestamp)
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
    ZanthusSQLServer_CRUD() {
        try {
            let script = `
                	INSERT INTO	ZeusRetail.dbo.tab_mercadoria_tipo_venda_qtde 
                            (	    cod_loja
                                ,	cod_mercadoria
                                ,	cod_tipo_venda
                                ,	flag_geral
                                ,	qtde_venda
                                ,	preco_unitario
                                ,	perc_desconto
                                ,	flag_ativo
                                ,	Dth_inclusao
                                ,	Dth_alteracao
                                ,	Idt_usuario_alteracao
                            )
                        SELECT			DISTINCT
                                        ${this.cod_loja}
                                    ,	'${this.cod_mercadoria}'
                                    ,	${this.cod_tipo_venda}
                                    ,   ${this.flag_geral}
                                    ,   ${this.qtde_venda}
                                    ,	${this.preco_unitario} 
                                    ,	${this.perc_desconto} 
                                    ,   '${this.flg_ativo}'
                                    ,	'${Tools_1.default._datemomentDateToStr(this.dth_inclusao, "yyyy-MM-DD hh:mm:ss")}'
                                    ,	'${Tools_1.default._datemomentDateToStr(this.dth_alteracao, "yyyy-MM-DD hh:mm:ss")}'
                                    ,	'${this.idt_usuario_alteracao}' 
                        WHERE NOT EXISTS ( SELECT 1 
                                           FROM   ZeusRetail.dbo.tab_mercadoria_tipo_venda_qtde a
                                           WHERE  a.cod_mercadoria = '${this.cod_mercadoria}' 
                                             AND  a.cod_tipo_venda = ${this.cod_tipo_venda}
                                          )
                        ;
                        UPDATE  x 
                        SET    preco_unitario = ${this.preco_unitario} 
                           ,   Dth_alteracao = '${Tools_1.default._datemomentDateToStr(this.dth_alteracao, "yyyy-MM-DD hh:mm:ss")}'
                        FROM   ZeusRetail.dbo.tab_mercadoria_tipo_venda_qtde x 
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
exports.default = tbZanthusTabMercadoriaTipoVendaQtde;
