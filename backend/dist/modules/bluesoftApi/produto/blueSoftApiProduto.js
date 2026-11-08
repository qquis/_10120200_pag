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
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const bluesoftApiUrl_1 = __importDefault(require("../url/bluesoftApiUrl"));
class blueSoftApiProduto {
    constructor() {
        this.dataUltimaAlteracao = Tools_1.default._dataConvertStrtoDate("01/01/1900");
    }
    listall() {
        return __awaiter(this, void 0, void 0, function* () {
            return this.list();
        });
    }
    listUltAlteracaoD1() {
        return __awaiter(this, void 0, void 0, function* () {
            //console.log(`DATA TESTE ${myTools._dataformatgetstr("", "DD/MM/YYYY")}`)
            //return this.list(true, myTools._dataformatgetstr("", "DD/MM/YYYY"))
            const dataOntem = new Date();
            dataOntem.setDate(((new Date()).getDate() - 1));
            return this.list(true, Tools_1.default._dataformatgetDATEtoSTR(dataOntem, "DD/MM/YYYY"));
        });
    }
    list() {
        return __awaiter(this, arguments, void 0, function* (UltimaAlteracao = false, data_alteracao = "") {
            try {
                let resultobject = [];
                let result;
                let numPag = 0;
                let numPagMax = 100;
                const pagSize = 100;
                if (UltimaAlteracao)
                    numPagMax = 5;
                for (numPag = 0; numPag <= numPagMax; numPag++) {
                    //console.log(`processando a pagina ${numPag}`)
                    result = {};
                    let url = ``;
                    if (UltimaAlteracao) {
                        url = `/comercial/produtos?pageSize=${pagSize}&currentPage=${numPag}&ultimaAlteracao=${data_alteracao}`;
                    }
                    else {
                        url = `/comercial/produtos?pageSize=${pagSize}&currentPage=${numPag}`;
                    }
                    result = yield bluesoftApiUrl_1.default.api_get(url);
                    if (result) {
                        for (const [key, value] of Object.entries(result.data.data)) {
                            resultobject.push(value);
                        }
                    }
                }
                return resultobject;
            }
            catch (e) {
                Tools_1.default.pagConsole(`bluesoftapi \n ${e}`, true);
            }
        });
    }
}
exports.default = blueSoftApiProduto;
