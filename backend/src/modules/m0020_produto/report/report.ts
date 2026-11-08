
import reportProdutoCadastro from "../report/reportProdutoCadastro";
import reportProdutoCategoria from "../report/reportprodutocategoria";
import reportProdutoSubGrupo from "../report/reportprodutoSubGrupoLIst";

export default class reportProduto { 
    static list = reportProdutoCadastro
    static categoria = reportProdutoCategoria
    static subgrupo = reportProdutoSubGrupo

}

