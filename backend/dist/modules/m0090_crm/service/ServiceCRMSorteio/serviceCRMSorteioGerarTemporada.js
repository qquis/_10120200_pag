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
const modelbase_1 = require("../../../../model/modelbase");
const reportCRM_1 = __importDefault(require("../../report/reportCRM"));
class serviceCrmSorteioGerarTemporada {
    static start() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const list = this.criar_numero_sorteios();
                yield this.registrar(list);
            }
            catch (error) {
                throw error;
            }
        });
    }
    static registrar(list) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, list_1, list_1_1;
            var _b, e_1, _c, _d;
            try {
                const myBase = new modelbase_1.clsBase();
                let imodelcrm_sorteio_temporada = yield reportCRM_1.default.sorteio.Temporada.getTemporadaAtiva();
                let i = 0;
                let iNumberMaxInsert = 250;
                let sqlinsert = '';
                try {
                    for (_a = true, list_1 = __asyncValues(list); list_1_1 = yield list_1.next(), _b = list_1_1.done, !_b; _a = true) {
                        _d = list_1_1.value;
                        _a = false;
                        const item = _d;
                        let sql = `
                                insert into tbcrm_sorteio_numero
                                (
                                    	crm_so_temp_cd				
                                    ,	crm_so_numero_ordem			
                                    ,	numero						    
                                )
                                SELECT  ${imodelcrm_sorteio_temporada.crm_so_temp_cd}
                                    ,	${item.ordem_numero}
                                    ,	${item.numero_aleatorio}
                                WHERE NOT EXISTS (Select 1 from tbcrm_sorteio_numero where crm_so_temp_cd = ${imodelcrm_sorteio_temporada.crm_so_temp_cd} and numero = ${item.numero_aleatorio})
                                ;
                            `;
                        sqlinsert += sql;
                        i++;
                        if (i >= iNumberMaxInsert) {
                            yield myBase.myDataBase.pag.Execute(sqlinsert);
                            sqlinsert = '';
                            i = 0;
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_a && !_b && (_c = list_1.return)) yield _c.call(list_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sqlinsert != '') {
                    yield myBase.myDataBase.pag.Execute(sqlinsert);
                }
            }
            catch (error) {
                modelbase_1.clsTools.PagErrorException("M0090_CRM", "modelcrm_sorteio_temporada - registrar", error);
                throw error;
            }
        });
    }
    static criar_numero_sorteios() {
        try {
            const numerosGerados = new Set();
            const arrayNumeros = [];
            let ordem = 1;
            while (numerosGerados.size < 99999) {
                // 1) Criar os dois primeiros dígitos aleatoriamente (10-99)
                const primeiros2Digitos = Math.floor(Math.random() * 90) + 10;
                // 2) Criar os últimos 5 dígitos aleatoriamente (00000-99999)
                const ultimos5Digitos = Math.floor(Math.random() * 100000);
                // 3) Formatar os últimos 5 dígitos com zeros à esquerda
                const ultimos5DigitosFormatados = ultimos5Digitos.toString().padStart(5, '0');
                // 4) Juntar os dois primeiros com os 5 dígitos
                const numeroCompleto = primeiros2Digitos.toString() + ultimos5DigitosFormatados;
                // 5) Verificar se o número já existe (não repetir)
                if (!numerosGerados.has(numeroCompleto)) {
                    numerosGerados.add(numeroCompleto);
                    // 6) Adicionar ao array com ordem
                    arrayNumeros.push({
                        ordem_numero: ordem,
                        numero_aleatorio: numeroCompleto
                    });
                    ordem++;
                }
            }
            return arrayNumeros;
        }
        catch (error) {
            modelbase_1.clsTools.PagErrorException("M0090_CRM", "modelcrm_sorteio_temporada - criar_numero_sorteios", error);
            throw error;
        }
    }
    // Método auxiliar para gerar um único número (caso precise)
    static gerar_numero_unico(numerosExistentes) {
        let numeroGerado;
        let tentativas = 0;
        const maxTentativas = 1000;
        do {
            // Primeiros 2 dígitos (10-99)
            const primeiros2 = Math.floor(Math.random() * 90) + 10;
            // Últimos 5 dígitos (00000-99999)
            const ultimos5 = Math.floor(Math.random() * 100000).toString().padStart(5, '0');
            numeroGerado = primeiros2.toString() + ultimos5;
            tentativas++;
            if (tentativas > maxTentativas) {
                throw new Error('Não foi possível gerar número único após muitas tentativas');
            }
        } while (numerosExistentes.has(numeroGerado));
        return numeroGerado;
    }
    // Método para validar se um número está no formato correto
    static validar_numero_formato(numero) {
        // Deve ter exatamente 7 dígitos
        if (numero.length !== 7)
            return false;
        // Deve conter apenas números
        if (!/^\d{7}$/.test(numero))
            return false;
        // Os dois primeiros dígitos devem ser >= 10
        const primeiros2 = parseInt(numero.substring(0, 2));
        if (primeiros2 < 10)
            return false;
        return true;
    }
    // Método para ordenar os números gerados
    static ordenar_numeros(numeros, tipo = 'ordem') {
        return numeros.sort((a, b) => {
            if (tipo === 'ordem') {
                return a.ordem_numero - b.ordem_numero;
            }
            else {
                return a.numero_aleatorio.localeCompare(b.numero_aleatorio);
            }
        });
    }
}
exports.default = serviceCrmSorteioGerarTemporada;
