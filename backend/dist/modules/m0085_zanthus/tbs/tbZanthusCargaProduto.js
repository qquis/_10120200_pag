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
class tbzanthus_carga_produto extends model_1.modelTb {
    constructor() {
        super();
        this.carga_uuid = ``;
        this.carga_produto_seq = 0;
        this.pr_cdproduto = 0;
        this.prb_cdprodutobluesoftunitario = 0;
        this.prb_cdprodutobluesoft = 0;
        this.cod_mercadoria = ``;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.carga_uuid = item === null || item === void 0 ? void 0 : item.carga_uuid;
                this.carga_produto_seq = parseInt(item === null || item === void 0 ? void 0 : item.carga_produto_seq);
                this.pr_cdproduto = item === null || item === void 0 ? void 0 : item.pr_cdproduto;
                this.prb_cdprodutobluesoftunitario = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoftunitario;
                this.prb_cdprodutobluesoft = item === null || item === void 0 ? void 0 : item.prb_cdprodutobluesoft;
                this.cod_mercadoria = item === null || item === void 0 ? void 0 : item.cod_mercadoria;
            }
            catch (e) {
                Tools_1.default.pagConsole(`M0085 _ Zanthus | tbZanthusCargaProduto.binding 
                    Error: 
                    ${e}    
                    `);
            }
        });
    }
    ZanthusPostGre_CRUD() {
        try {
            let scriptSQL = `
                INSERT INTO		tb_zanthus_carga_produto (
                                            carga_uuid
                                        ,	pr_cdproduto
                                        ,	prb_cdprodutobluesoftunitario
                                        ,	prb_cdprodutobluesoft
                                        ,	cod_mercadoria      
                                        )
    
                            SELECT			DISTINCT
                                            '${this.carga_uuid}'
                                        ,	${this.pr_cdproduto}
                                        ,	${this.prb_cdprodutobluesoftunitario}
                                        ,	${this.prb_cdprodutobluesoft}
                                        ,	'${this.cod_mercadoria}'
                            WHERE NOT EXISTS (
                                            SELECT 1
                                            FROM tb_zanthus_carga_produto
                                            WHERE carga_uuid = '${this.carga_uuid}'
                                              AND cod_mercadoria = '${this.cod_mercadoria}'
                                        );

                            
                            ;   
                `;
            return scriptSQL;
        }
        catch (e) {
            Tools_1.default.pagConsole(`M0085_ZANTHUS | tbZanthusCarga - ZanthusPostGre_CRUD
                                    Item ${this.carga_uuid} 
                                    Error \n ${e}
                                   `);
            return ``;
        }
    }
}
exports.default = tbzanthus_carga_produto;
