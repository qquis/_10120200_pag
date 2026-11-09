"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const reportSistemaList_1 = __importDefault(require("./reportSistemaList"));
const reportSistemaNucleo_1 = __importDefault(require("./reportSistemaNucleo"));
const reportSistemaNucleoProcedimento_1 = __importDefault(require("./reportSistemaNucleoProcedimento"));
const reportSistemaTarefas_1 = __importDefault(require("./reportSistemaTarefas"));
const reportSistemaPermissaoList_1 = __importDefault(require("./reportSistemaPermissaoList"));
const reportSistemaFuncao_1 = __importDefault(require("./reportSistemaFuncao"));
const reportSistemaAcesso_1 = __importDefault(require("./reportSistemaAcesso"));
const reportSistemaParametro_1 = __importDefault(require("./reportSistemaParametro"));
const reportSistemaUsuario_1 = __importDefault(require("./reportSistemaUsuario"));
const reportSistemaOperacional_1 = __importDefault(require("./reportSistemaOperacional"));
class reportSistema {
}
reportSistema.List = reportSistemaList_1.default;
reportSistema.Nucleo = reportSistemaNucleo_1.default;
reportSistema.NucleoProcedimento = reportSistemaNucleoProcedimento_1.default;
reportSistema.Tarefa = reportSistemaTarefas_1.default;
reportSistema.Permissao = reportSistemaPermissaoList_1.default;
reportSistema.Funcao = reportSistemaFuncao_1.default;
reportSistema.Acesso = reportSistemaAcesso_1.default;
reportSistema.Parametro = reportSistemaParametro_1.default;
reportSistema.Usuario = reportSistemaUsuario_1.default;
reportSistema.Operacional = reportSistemaOperacional_1.default;
exports.default = reportSistema;
