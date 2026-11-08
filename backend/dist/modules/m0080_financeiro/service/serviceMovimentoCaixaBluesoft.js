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
const modelmovimento_caixa_bluesoft_1 = require("../model/modelmovimento_caixa_bluesoft");
const redhisft_select_movimento_caixa_bluesoft_1 = __importDefault(require("../scriptpg/redhisft_select_movimento_caixa_bluesoft"));
const myClsBase = new modelbase_1.clsBase();
class serviceMovimentoCaixaBluesoftImportar {
    static start(nucleo_procedimento) {
        return __awaiter(this, void 0, void 0, function* () {
            if (!nucleo_procedimento.__atualizado)
                nucleo_procedimento.consultar();
            //await nucleo_procedimento.iniciarExecucao()
            let listMovimentoCaixaBluesoft = [];
            try {
                let dataInicial = yield nucleo_procedimento.dataInicial();
                let dataFinal = yield nucleo_procedimento.dataFinal();
                /*SELECIONANDO REGISTROS PENDENTES*/
                let result = yield myClsBase.myDataBase.redshift.DataGet(redhisft_select_movimento_caixa_bluesoft_1.default.get({ dataInicial: dataInicial, dataFinal: dataFinal }));
                //--------------------------------------------------
                let scriptsql = ``;
                let i = 0;
                let intContador = 0;
                let intTootalExecute = 100;
                for (const [key, value] of Object.entries(result)) {
                    let registroMovimentoCaixaBluesoft = new modelmovimento_caixa_bluesoft_1.modelmovimento_caixa_bluesoft();
                    registroMovimentoCaixaBluesoft.binding(value);
                    listMovimentoCaixaBluesoft.push(registroMovimentoCaixaBluesoft);
                    scriptsql += registroMovimentoCaixaBluesoft.integSql_get();
                    if (intContador >= intTootalExecute || intContador === result.length - 1) {
                        yield myClsBase.myDataBase.pag.Execute(scriptsql);
                        scriptsql = ``;
                        intContador = 0;
                    }
                    intContador++;
                    i++;
                }
                return listMovimentoCaixaBluesoft;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0080`, `ServiceFinanceiro | Atualizar`, e);
                nucleo_procedimento.ErrorMessage = `Error: ${e}`;
            }
            finally {
                //await nucleo_procedimento.finalizarExecucao()
                return listMovimentoCaixaBluesoft;
            }
        });
    }
}
exports.default = serviceMovimentoCaixaBluesoftImportar;
