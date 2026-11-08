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
const tboperacao_1 = __importDefault(require("../tbs/tboperacao"));
class modelOperacao extends tboperacao_1.default {
    constructor() {
        super();
        this.em_descricao = '';
    }
    binding(item) {
        const _super = Object.create(null, {
            binding: { get: () => super.binding }
        });
        return __awaiter(this, void 0, void 0, function* () {
            if (item) {
                _super.binding.call(this, item);
                this.em_descricao = item === null || item === void 0 ? void 0 : item.em_descricao;
            }
        });
    }
}
exports.default = modelOperacao;
