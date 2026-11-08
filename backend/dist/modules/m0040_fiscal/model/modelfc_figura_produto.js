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
const modelbase_1 = require("../../../model/modelbase");
const tbfc_figurafiscal_produto_1 = __importDefault(require("../tbs/tbfc_figurafiscal_produto"));
const modelfc_regrafiscalNfceProduto_1 = __importDefault(require("./modelfc_regrafiscalNfceProduto"));
const myBase = new modelbase_1.clsBase();
class modelfc_figurafiscal_produto extends tbfc_figurafiscal_produto_1.default {
    constructor() {
        super();
        this.itemNFCE = new modelfc_regrafiscalNfceProduto_1.default();
    }
    script_atualizar() {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = `insert into tbfc_figurafiscal_produto 
        (
            	fc_figurafiscal_cd 			
            ,   fc_figurafiscal_versao
            ,   prb_cdprodutobluesoft 
            ,   regrafiscal_nfce					
         )
            SELECT     ${this.fc_figurafiscal_cd}
                    ,  ${this.fc_figurafiscal_versao}
                    ,  ${this.prb_cdprodutobluesoft}
                    ,  0
            WHERE NOT EXISTS ( SELECT 1 FROM tbfc_figurafiscal_produto WHERE prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft})
            ;

        UPDATE tbfc_figurafiscal_produto
            SET   fc_figurafiscal_cd = ${this.fc_figurafiscal_cd}
                , fc_figurafiscal_versao = ${this.fc_figurafiscal_versao}
                , dtlog_update = current_timestamp 
            WHERE prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft}
            ;

            `;
            /* NFCE - SCRIPT DO ITEM NFCE INCLUSAO / EXCLUSÃO*/
            /* ------------------------------------------------------------------------- */
            sql += yield this.itemNFCE.script_CRUD();
            /* ------------------------------------------------------------------------- */
            /* ------------------------------------------------------------------------- */
            return sql;
        });
    }
    bindingAPIbluesoft(prb_cdprodutobluesoft) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let item = yield myBase.blueSoftApi.api_get(`/fiscal/figurafiscal/produto/${prb_cdprodutobluesoft}`, false);
                if (item && item.data) {
                    this.fc_figurafiscal_versao = item.data.versao ? item.data.versao : 0;
                    this.fc_figurafiscal_cd = item.data.codigoFiguraFiscal ? item.data.codigoFiguraFiscal : 0;
                    this.prb_cdprodutobluesoft = prb_cdprodutobluesoft;
                    yield this.itemNFCE.ChamadaLeituraApiBlueSoftSatNfcePorProduto(prb_cdprodutobluesoft);
                }
                /*
                else {
                    clsTools.pagConsole(`F0040_Fiscal  | Atualizacao da figura fiscal do produto ${this.prb_cdprodutobluesoft} | Figura nao encontrada.`, true, false, 'M0040')
                }*/
            }
            catch (e) {
                //clsTools.pagConsole(`F0040 FISCAL _ modelfc_figurafiscal_produto _ bindingAPIbluesoft  | Atualizacao da figura fiscal do produto ${this.prb_cdprodutobluesoft} | Figura nao encontrada.`) 
                return;
            }
        });
    }
    getInsertScriptByProdutoBluesoft(prb_cdprodutobluesoft) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                yield this.bindingAPIbluesoft(prb_cdprodutobluesoft);
                if (this.fc_figurafiscal_versao !== 0 && this.fc_figurafiscal_cd !== 0) {
                    sql = yield this.script_atualizar();
                }
            }
            catch (e) {
                sql = ``;
            }
            finally {
                return sql;
            }
        });
    }
    atualizarFiguraFiscalProduto(prb_cdprodutobluesoft) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (!prb_cdprodutobluesoft || prb_cdprodutobluesoft == 0) {
                    throw new Error(`Código do produto bluesoft inválido.`);
                }
                yield this.bindingAPIbluesoft(prb_cdprodutobluesoft);
                if (this.fc_figurafiscal_versao !== 0 && this.fc_figurafiscal_cd !== 0) {
                    let sql = yield this.script_atualizar();
                    yield myBase.myDataBase.pag.Execute(sql);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'modelfc_figurafiscal_produto.atualizarFiguraFiscalProduto', e, false, "", "M0040");
            }
        });
    }
}
exports.default = modelfc_figurafiscal_produto;
