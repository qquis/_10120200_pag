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
class tbintegracao_tipo extends model_1.modelTb {
    constructor() {
        super();
        this.integracao_tipo_cd = 0;
        this.integracao_cd = 0;
        this.integracao_tipo_descricao = ``;
        this.zanthus = 0;
        this.bluesoft_redshift = 0;
        this.bluesoft_api = 0;
        this.tipo_export = 0;
        this.sis_batch_cd = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item) {
                    this.integracao_tipo_cd = item === null || item === void 0 ? void 0 : item.integracao_tipo_cd;
                    this.integracao_cd = item === null || item === void 0 ? void 0 : item.integracao_cd;
                    this.integracao_tipo_descricao = item === null || item === void 0 ? void 0 : item.integracao_tipo_cd;
                    this.zanthus = item === null || item === void 0 ? void 0 : item.zanthus;
                    this.bluesoft_redshift = item === null || item === void 0 ? void 0 : item.bluesoft_redshift;
                    this.bluesoft_api = item === null || item === void 0 ? void 0 : item.bluesoft_api;
                    this.tipo_export = item === null || item === void 0 ? void 0 : item.tipo_export;
                    this.sis_batch_cd = item === null || item === void 0 ? void 0 : item.sis_batch_cd;
                }
            }
            catch (e) {
                Tools_1.default.pagConsole(`tbintegracao_tipo binding | \n ${e}`, true);
            }
        });
    }
}
exports.default = tbintegracao_tipo;
