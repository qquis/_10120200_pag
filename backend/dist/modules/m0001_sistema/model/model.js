"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const model_Resources_1 = __importDefault(require("./model.Resources"));
class modelSistema {
}
modelSistema.resources = model_Resources_1.default;
modelSistema.tabs = null;
modelSistema.gets = null;
modelSistema.posts = null;
exports.default = modelSistema;
/*

model
- Tratativas de tabelas

modelXXXXX(objeto) - tratativas relacionadas apenas a um objeto específico
modelXXXXXrelacional - Operações envolvendo relacionamentos entre tabelas, joins, etc



*/ 
