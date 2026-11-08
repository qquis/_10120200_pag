import { clsBase, clsTools } from "../../../model/modelbase";

import reportSistemalist from "./reportSistemaList";
import reportSistemaNucleo from "./reportSistemaNucleo";
import reportSistemaNucleoProcedimento from "./reportSistemaNucleoProcedimento";
import reportSistemaTarefa from "./reportSistemaTarefas";
import reportPermissaolist from "./reportSistemaPermissaoList";
import reportFuncaolist from "./reportSistemaFuncao";
import reportAcessolist from "./reportSistemaAcesso";
import reportSistemaParametro from "./reportSistemaParametro";
import reportSistemaUsuario from "./reportSistemaUsuario";
export default class reportSistema {
    static List = reportSistemalist;
    static Nucleo = reportSistemaNucleo;
    static NucleoProcedimento = reportSistemaNucleoProcedimento;
    static Tarefa = reportSistemaTarefa;
    static Permissao = reportPermissaolist;
    static Funcao = reportFuncaolist;
    static Acesso = reportAcessolist;
    static Parametro = reportSistemaParametro;
    static Usuario = reportSistemaUsuario;
}