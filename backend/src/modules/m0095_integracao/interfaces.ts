interface iIntegracao {
    integracao_cd : number 
    integracao_tipo_cd : number 
    integracao_status_cd : number 
}

interface iIntegracaoProduto {
    integracao_cd : number 
    integracao_tipo_cd : number 
    integracao_status_cd : number 
    pr_cdproduto: number 
    prb_cdprodutobluesoftunitario: number 
    prb_cdprodutobluesoft: number 
}


type typeIntegracaoProduto = {
    integracao_cd : 2000 
    integracao_tipo_cd : number 
    integracao_status_cd : number 
    pr_cdproduto: number 
    prb_cdprodutobluesoftunitario: number 
    prb_cdprodutobluesoft: number 
}


export { iIntegracao, iIntegracaoProduto, typeIntegracaoProduto}