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
const F0021_02_ProdutoBlueSoft_gTins_CRUD_1 = __importDefault(require("../scriptpg/F0021_02_ProdutoBlueSoft_gTins_CRUD"));
class tbprodutobluesoft_gtins {
    constructor() {
        //super();
        this.prb_cdprodutobluesoft = 0;
        this.prbg_cdbarra_pk = ``;
        this.prbg_embalagem = ``;
        this.prbg_embalagemdescricao = ``;
    }
    _Db_Pg_script(_stringCommand) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                sql = `SELECT ${F0021_02_ProdutoBlueSoft_gTins_CRUD_1.default.sqlScript_VERSION()}
                (  sqlcommand:= '${_stringCommand}',
                   vprbg_cdbarra_pk:= '${this.prbg_cdbarra_pk}',
                   vprb_cdprodutobluesoft:= ${this.prb_cdprodutobluesoft},
                   vprbg_embalagem:= '${this.prbg_embalagem}',
                   vprbg_embalagemdescricao:= '${this.prbg_embalagemdescricao}', 
                   vcommand_api:= 'true'
                    ); `;
                return sql;
            }
            catch (e) {
                throw new Error(` Classe modelProdutoBluesoft
                Método: getApiBluesoftSqlCRUD
                -----------------------------------------------------------
                Script SQL 
                -----------------------------------------------------------
                ${sql}
                -----------------------------------------------------------
                Error ${e} \n 
              `);
            }
        });
    }
}
exports.default = tbprodutobluesoft_gtins;
