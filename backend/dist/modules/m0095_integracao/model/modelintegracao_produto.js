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
const tbintegracao_produto_1 = __importDefault(require("../tbs/tbintegracao_produto"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
//import integracaoProduto from "../service/integracao.produto/integracao.produto.service";
const model_zanthus_produto_1 = __importDefault(require("../../m0085_zanthus/model/model_zanthus_produto"));
class modelintegracao_produto extends tbintegracao_produto_1.default {
    constructor(item) {
        super();
        this.ItemObjectIntegracao = item;
        this.ApiValidacao = false;
        this.integracao_tipo_cd = 0;
        this.model_zanthus_produto = new model_zanthus_produto_1.default();
        if (item) {
            this.integracao_produto_seq = parseInt(`${item.integracao_produto_seq ? item.integracao_produto_seq : 0}`);
            this.integracao_tipo_cd = parseInt(`${item.integracao_tipo_cd ? item.integracao_tipo_cd : 0}`);
            this.pr_cdproduto = parseInt(`${item.pr_cdproduto ? item.pr_cdproduto : 0}`);
            this.prb_cdprodutobluesoftunitario = parseInt(`${item.prb_cdprodutobluesoftunitario ? item.prb_cdprodutobluesoftunitario : 0}`);
            this.prb_cdprodutobluesoft = parseInt(`${item.prb_cdprodutobluesoft ? item.prb_cdprodutobluesoft : 0}`);
            /*TIPO ZANTHUS*/
            this.model_zanthus_produto.pr_cdproduto = this.pr_cdproduto;
            this.model_zanthus_produto.prb_cdprodutobluesoft = this.prb_cdprodutobluesoft;
        }
    }
    statusSetAtualizado() {
        return __awaiter(this, void 0, void 0, function* () { yield this._StatusAtualizar(1); });
    }
    statusSetPendente() {
        return __awaiter(this, void 0, void 0, function* () { yield this._StatusAtualizar(2); });
    }
    statusSetPreProcessamento() {
        return __awaiter(this, void 0, void 0, function* () { yield this._StatusAtualizar(5); });
    }
    statusSetError() {
        return __awaiter(this, void 0, void 0, function* () { yield this._StatusAtualizar(9); });
    }
    statusSetFinalizar() {
        return __awaiter(this, void 0, void 0, function* () { yield this._StatusAtualizar(99); });
    }
    _StatusAtualizar(integracao_status_cd) {
        const _super = Object.create(null, {
            _Db_Pg_DataPost: { get: () => super._Db_Pg_DataPost }
        });
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = ``;
                if (integracao_status_cd !== 99) {
                    sql = ` UPDATE tbintegracao_produto 
                                     set  integracao_status_cd = ${integracao_status_cd}
                                       ,  dtlog_update = current_timestamp
                                     where integracao_produto_seq = ${this.integracao_produto_seq}
                                    `;
                }
                else {
                    sql = ` UPDATE tbintegracao_produto 
                            set  integracao_status_cd = ${integracao_status_cd}
                              ,  dtlog_update = current_timestamp
                            where integracao_produto_seq = ${this.integracao_produto_seq}
                              and integracao_produto_seq != 9
                   `;
                }
                yield _super._Db_Pg_DataPost.call(this, sql);
            }
            catch (e) {
                Tools_1.default.pagConsole(`modelintegracao_produto | StatusAtualizar \n ${e}`);
            }
        });
    }
}
exports.default = modelintegracao_produto;
