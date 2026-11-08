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
const f0021_03_ProdutobluesoftComposicao_Crud_1 = __importDefault(require("../scriptpg/f0021_03_ProdutobluesoftComposicao_Crud"));
class tbprodutobluesoft_composicao {
    constructor() {
        //super();
        this.prb_cdprodutobluesoft = 0;
        this.prb_cdprodutobluesoft_unitario = 0;
        this.prbc_descricao = ``;
        this.prbc_percentual_composicao = 0;
        this.prbc_qtde = 0;
        this.prbc_data = new Date();
        this.prbc_bluesoft_seq = 0;
        this.gtinPrincipal = ``;
    }
    _Db_Pg_script(_stringCommand) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                sql = `SELECT ${f0021_03_ProdutobluesoftComposicao_Crud_1.default.sqlScript_VERSION()}
                (  sqlcommand:= '${_stringCommand}',
                    vprb_cdprodutobluesoft:= ${this.prb_cdprodutobluesoft},
                    vprb_cdprodutobluesoft_unitario:= ${this.prb_cdprodutobluesoft_unitario},
                    vprbc_qtde:= ${this.prbc_qtde},
                    vprbc_descricao:= '${this.prbc_descricao.substring(0, 30).replace("'", "")}',
                    vprbc_percentual_composicao:= ${this.prbc_percentual_composicao},
                    vgtin_principal:= '${this.gtinPrincipal}',
                    vcommand_api:= 'true'
                    ); `;
                return sql;
            }
            catch (e) {
                throw new Error(` ERROR Classe tbprodutobluesoft_composicao ${e} `);
            }
        });
    }
}
exports.default = tbprodutobluesoft_composicao;
