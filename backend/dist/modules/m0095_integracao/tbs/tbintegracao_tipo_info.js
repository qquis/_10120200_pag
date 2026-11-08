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
const model_1 = require("../../../model/model");
class tbintegracao_tipo_info extends model_1.modelTb {
    constructor() {
        super();
        this.integracao_tipo_cd = 0;
        this.script_select = ``;
        this.sis_batch_cd = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item) {
                    this.integracao_tipo_cd = item === null || item === void 0 ? void 0 : item.integracao_tipo_cd;
                    this.sis_batch_cd = item === null || item === void 0 ? void 0 : item.sis_batch_cd;
                    this.script_select = item === null || item === void 0 ? void 0 : item.script_select;
                }
            }
            catch (e) {
                Tools_1.default.pagConsole(`tbintegracao_tipo_info binding | \n ${e}`, true);
            }
        });
    }
}
exports.default = tbintegracao_tipo_info;
