"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbdocumentofiscal_1 = __importDefault(require("../tbs/tbdocumentofiscal"));
class model_documentofiscal {
    constructor() {
        this.documentofiscal = new tbdocumentofiscal_1.default();
    }
}
exports.default = model_documentofiscal;
