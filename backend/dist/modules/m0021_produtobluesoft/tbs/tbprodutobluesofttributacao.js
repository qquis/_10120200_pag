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
const F0021_04_ProdutoBlueSoft_Tributacao_CRUD_1 = __importDefault(require("../scriptpg/F0021_04_ProdutoBlueSoft_Tributacao_CRUD"));
class tbprodutobluesof_tributacao {
    constructor() {
        this.op_cdoperacao = 0;
        this.prb_cdprodutobluesoft = 0;
        this.prbt_regrafiscal = 0;
        this.prbt_regrafiscal_versao = 0;
        this.prbt_regimetributario = ``;
        this.prbt_cfop = ``;
        this.prbt_pis_entrada_cst = ``;
        this.prbt_pis_entrada_aliquida = 0;
        this.prbt_pis_saida_cst = ``;
        this.prbt_pis_saida_aliquota = 0;
        this.prbt_cofins_entrada_cst = ``;
        this.prbt_cofins_entrada_aliquida = 0;
        this.prbt_cofins_saida_cst = ``;
        this.prbt_cofins_saida_aliquota = 0;
        this.prbt_icms_saida_cst = ``;
        this.prbt_icms_entrada_cst = ``;
        this.prbt_icms_aliquota_interna = 0;
        this.prbt_icms_reducao = 0;
        this.prbt_st_iva = 0;
        this.prbt_icms_entrada_aliquota_interna = 0;
        this.prbt_icms_entrada_reducao = 0;
        this.prbt_icms_revenda_cst = ``;
        this.prbt_icms_revenda_aliquota_interna = 0;
        this.prbt_icms_revenda_reducao = 0;
        this.prbt_ncm = ``;
        this.prbt_cest = ``;
    }
    _Db_Pg_script(_stringCommand) {
        return __awaiter(this, void 0, void 0, function* () {
            let sqlScriptTributacao = ``;
            try {
                sqlScriptTributacao = `SELECT ${F0021_04_ProdutoBlueSoft_Tributacao_CRUD_1.default.sqlScript_VERSION()}
                        (   '${_stringCommand}',
                            2,
                            ${this.prb_cdprodutobluesoft},
                            99999,
                            99999,
                            'X',
                            '5102',
                            '000',
                            0.00,
                            '${this.prbt_pis_saida_cst}',
                            ${this.prbt_pis_saida_aliquota},
                            '000',
                            0.00,
                            '${this.prbt_cofins_saida_cst}',
                            ${this.prbt_cofins_saida_aliquota},
                            '000',
                            0.00,
                            0.00,
                            '${this.prbt_icms_saida_cst}', 
                            ${this.prbt_icms_aliquota_interna},
                            ${this.prbt_icms_reducao},
                            '000',
                            0.00,
                            0.00,
                            '${this.prbt_ncm}', 
                            '${this.prbt_cest}',              
                            0.00,
                            'true'
                                ); `;
                return sqlScriptTributacao;
            }
            catch (e) {
                throw new Error(` Classe modelProdutoBluesoft
                Método: getApiBluesoftSqlCRUD
                -----------------------------------------------------------
                Script SQL 
                -----------------------------------------------------------
                ${sqlScriptTributacao}
                -----------------------------------------------------------
                Error ${e} \n 
              `);
            }
        });
    }
}
exports.default = tbprodutobluesof_tributacao;
