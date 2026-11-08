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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const serviceFiscal_Cbenef_ImportarBluesoft_1 = __importDefault(require("./serviceFiscal.Cbenef.ImportarBluesoft"));
const modelbase_1 = require("../../../model/modelbase");
const myBase = new modelbase_1.clsBase();
class serviceFiscal_Cbenef_ExportarProdutoBluesoft {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                modelbase_1.clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.Cbenef_ExportarProdutoBluesoft.start - Iniciando...', false, false);
                let myDataBase = new modelbase_1.clsBase();
                if (parametro.fc_cbenef_cd == null || parametro.fc_cbenef_cd.trim() === '') {
                    throw new Error('Código do Cbenef é obrigatório');
                }
                if (parametro.lista_produtos == null || parametro.lista_produtos.length === 0) {
                    throw new Error('Lista de produtos é obrigatória');
                }
                let sqlCBENEF_CONSULTA_BLUE = `Select fc_cbenef_bluesoft_cd from tbfc_cbenef where fc_cbenef_cd = '${parametro.fc_cbenef_cd}' `;
                let resultCBENEF_CONSULTA_BLUE = yield myDataBase.myDataBase.RecordItem(yield myDataBase.myDataBase.pag.DataGet(sqlCBENEF_CONSULTA_BLUE), 0);
                let fc_cbenef_bluesoft_cd = 0;
                if (resultCBENEF_CONSULTA_BLUE.fc_cbenef_bluesoft_cd && resultCBENEF_CONSULTA_BLUE.fc_cbenef_bluesoft_cd !== 0) {
                    fc_cbenef_bluesoft_cd = resultCBENEF_CONSULTA_BLUE.fc_cbenef_bluesoft_cd;
                }
                else {
                    modelbase_1.clsTools.pagConsole(`Nenhum código do ambiente Bluesoft encontrado para o CBENEF ${parametro.fc_cbenef_cd}. Realize a importação dos dados do ambiente Bluesoft para o sistema antes de realizar a exportação.`, true, false);
                    throw new Error(`Nenhum código do ambiente Bluesoft encontrado para o CBENEF ${parametro.fc_cbenef_cd}. Realize a importação dos dados do ambiente Bluesoft para o sistema antes de realizar a exportação.`);
                }
                let sql = `SELECT prb_cdprodutobluesoftunitario, prb_cdprodutobluesoft_pk 
                       FROM tbprodutobluesoft 
                       where prb_cdprodutobluesoftunitario in (${parametro.lista_produtos})
                       
                       `;
                let listaProdutos = [];
                let resultProduto = yield myDataBase.myDataBase.pag.DataGet(sql);
                let iexportCount = 0;
                let iExportMax = 10;
                try {
                    for (var _d = true, _e = __asyncValues(resultProduto), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const item = _c;
                        listaProdutos.push(item.prb_cdprodutobluesoft_pk);
                        iexportCount++;
                        if (iexportCount >= iExportMax) {
                            modelbase_1.clsTools.pagConsole(`Exportando produtos para o CBENEF ${parametro.fc_cbenef_cd}. Exportação em andamento | Inserindo bloco`, true, false);
                            yield this.exportList(parametro, fc_cbenef_bluesoft_cd, listaProdutos);
                            listaProdutos = [];
                            iexportCount = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (listaProdutos.length > 0) {
                    modelbase_1.clsTools.pagConsole(`Exportando produtos para o CBENEF ${parametro.fc_cbenef_cd}. Exportação em andamento | Inserindo bloco final`, true, false);
                    yield this.exportList(parametro, fc_cbenef_bluesoft_cd, listaProdutos);
                }
                /*
                let listToAPI = {
                    produtoKeys: listaProdutos
    
    
                }
    
                if (parametro.vincular && parametro.vincular === 1) {
                    await myBase.blueSoftApi.api_put(`/fiscal/beneficio-uf/${fc_cbenef_bluesoft_cd}/vincular-produtos`, listToAPI)
                } else { parametro.vincular === 0
                    await myBase.blueSoftApi.api_post(`/fiscal/beneficio-uf/${fc_cbenef_bluesoft_cd}/desvincular-produtos`, listToAPI)
                }*/
                /*ATUALIZANDO DADOS DO CADASTRO DE PRODUTO BLUESOFT*/
                //Atualiza os dados do cbenef e dos produtos relacionados ao cbenef específico que foi atualizado na Bluesoft, para garantir que os dados estejam atualizados para a consulta de exportação.
                yield serviceFiscal_Cbenef_ImportarBluesoft_1.default.start({ fc_cbenef_cd: parametro.fc_cbenef_cd });
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Cbenef_ExportarProdutoBluesoft', e);
            }
            finally {
                modelbase_1.clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.Cbenef_ExportarProdutoBluesoft.start - Finalizado', false, false);
            }
        });
    }
    static exportList(parametro, fc_cbenef_bluesoft_cd, lista_produtos) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let listToAPI = {
                    produtoKeys: lista_produtos
                };
                if (parametro.vincular && parametro.vincular === 1) {
                    yield myBase.blueSoftApi.api_put(`/fiscal/beneficio-uf/${fc_cbenef_bluesoft_cd}/vincular-produtos`, listToAPI);
                }
                else {
                    parametro.vincular === 0;
                    yield myBase.blueSoftApi.api_post(`/fiscal/beneficio-uf/${fc_cbenef_bluesoft_cd}/desvincular-produtos`, listToAPI);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Cbenef_ExportarProdutoBluesoft_exportList', e);
            }
        });
    }
}
exports.default = serviceFiscal_Cbenef_ExportarProdutoBluesoft;
