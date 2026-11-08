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
/*PRODUTO DECOMPOSICAO*/
const report_ZanthusTabMercadoria_Select_1 = __importDefault(require("./report.ZanthusTabMercadoria_Select"));
const report_ZanthusTabMercadoriaTipoVenda_Select_1 = __importDefault(require("./report.ZanthusTabMercadoriaTipoVenda_Select"));
const report_ZanthusTabRegrasIcms_Select_1 = __importDefault(require("./report.ZanthusTabRegrasIcms_Select"));
const report_ZanthusTabMercadoriaTipoVendaQtde_Select_1 = __importDefault(require("./report.ZanthusTabMercadoriaTipoVendaQtde_Select"));
const report_ZanthusTabProdutoDecomposicao_1 = __importDefault(require("./report.ZanthusTabProdutoDecomposicao"));
const report_ZanthusTabProdutoDecomposicaoInsum_1 = __importDefault(require("./report.ZanthusTabProdutoDecomposicaoInsum"));
class reportZanthusProduto {
    constructor() {
        this.listTabMercadoria = [];
        this.listTabMercadoriaTipoVenda = [];
        this.listTabRegrasIcms = [];
        this.listTabMercadoriaTipoVendaQtde = [];
        this.listTabProdutoDecomposicao = [];
        this.listTabProdutoDecomposicaoInsum = [];
    }
    Select(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let myreportZanthusTabMercadoria_Select = new report_ZanthusTabMercadoria_Select_1.default(filter);
            let myreportZanthusTabMercadoriaTipoVenda_Select = new report_ZanthusTabMercadoriaTipoVenda_Select_1.default(filter);
            let myreportZanthusTabRegrasIcms_Select = new report_ZanthusTabRegrasIcms_Select_1.default(filter);
            let myreportZanthusTabMercadoriaTipoVendaQtde_Select = new report_ZanthusTabMercadoriaTipoVendaQtde_Select_1.default(filter);
            let myreportZanthusTabProdutoDecomposicao_Select = new report_ZanthusTabProdutoDecomposicao_1.default(filter);
            let myreportZanthusTabProdutoDecomposicaoInsum_Select = new report_ZanthusTabProdutoDecomposicaoInsum_1.default(filter);
            try {
                this.listTabMercadoria = yield myreportZanthusTabMercadoria_Select.tblist_Get();
                this.listTabMercadoriaTipoVenda = yield myreportZanthusTabMercadoriaTipoVenda_Select.tblist_Get();
                this.listTabRegrasIcms = yield myreportZanthusTabRegrasIcms_Select.tblist_Get();
                this.listTabMercadoriaTipoVendaQtde = yield myreportZanthusTabMercadoriaTipoVendaQtde_Select.tblist_Get();
                this.listTabProdutoDecomposicao = yield myreportZanthusTabProdutoDecomposicao_Select.tblist_Get();
                this.listTabProdutoDecomposicaoInsum = yield myreportZanthusTabProdutoDecomposicaoInsum_Select.tblist_Get();
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`reportZanthus`, 'Select', e);
            }
        });
    }
}
exports.default = reportZanthusProduto;
