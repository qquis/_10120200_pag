export default class apiUrlMapeBluesoft {

    static comercial_Produto(pageSize : number = 200, currentPage : number = 1, ultimaAlteracao: string = ``, produtoKey: number = 0) {
        let url = `/modulos/comercial/produto?pageSize=${pageSize}`
        
        if (currentPage > 1) {
            url += `&currentPage=${currentPage}`
        }
        
        if (ultimaAlteracao && ultimaAlteracao.trim() !== ``) {
            url += `&ultimaAlteracao=${encodeURIComponent(ultimaAlteracao)}`
        }

        if (produtoKey && produtoKey > 0) {
            url += `&produtoKey=${produtoKey}`
        }



        return url;

    }

    static fiscal_regrafiscal_pdv_nfes (tipoClienteKey: number, retornarProdutos: boolean, page: number) : string { 
        let url = `/modulos/fiscal/regra-fiscal/pdv/nfes?lojaKey=1&tipoClienteKey=${tipoClienteKey}&retornarProdutos=${retornarProdutos}&page=${page}`
        return url
    }

    static fiscal_regrafiscal_pdv_nfes_produto (page: number) : string { 
        let url = `/modulos/fiscal/regra-fiscal/pdv/nfes/produtos?page=${page}`
        return url
    }

}