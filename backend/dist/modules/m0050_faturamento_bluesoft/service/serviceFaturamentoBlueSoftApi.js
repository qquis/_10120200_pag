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
const apiFaturamebtoBluesoft_1 = __importDefault(require("../api/apiFaturamebtoBluesoft"));
class serviceFaturamentoBluesoftApi {
    static processarApi() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let result = yield apiFaturamebtoBluesoft_1.default.obterPedidosBluesoft("0");
                console.log(result);
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`serviceFaturamentoBluesoft | processarApi \n Error: ${e}`);
            }
        });
    }
}
exports.default = serviceFaturamentoBluesoftApi;
