import pagApi from "@/api/api"

import moduleUserConnect from "../m0001_sistema/moduleUserConnect"


type TpProduto = {
    pr_cdproduto : number
    pr_descricao? : string 
    prb_cdprodutobluesoft? : number
    pr_embalagemestoque? : string
    pr_embalagemcompra? : string
    pr_embalagemcompra_fator? : number
    pr_cdbarra_principal? : string
    dtlog_insert? : string
    dtlog_update? : string
    dtlog_update_api? : string
    cdpessoabluesoft_fabricante? : number
    prb_cdproduto_compra_padrao? : number
    prsg_cdsubgrupo? : number
    pr_cesta? : boolean
    pr_status_comercial_preco_inativo? : boolean
    prb_status: number
    prb_vendaexterna: number
}

type TpProdutoCategoria = { 

    prsg_cdsubgrupo: number
    prsg_descricao: string
    prg_cdgrupo: number
    prg_descricao: string
    prs_cdsecao: number
    prs_descricao: string
    prd_cddepartamento: number
    prd_descricao: string


}

type TpProdutoDepartamento = {
    prd_cddepartamento: number
    prd_descricao: string
}

type TpProdutoSecao = {
    prs_cdsecao: number
    prs_descricao: string
    prd_cddepartamento: number
}

type TpProdutoGrupo = {
    prg_cdgrupo: number
    prg_descricao: string
    prd_cddepartamento: number    
    prs_cdsecao: number
}

type TpProdutoSubGrupo = {
    prsg_cdsubgrupo: number
    prsg_descricao: string
    prd_cddepartamento: number    
    prs_cdsecao: number    
    prg_cdgrupo: number    
}


type TpProdutoSubGrupoList = {
    selecionado: boolean

    prsg_cdsubgrupo: number
    prsg_descricao: string
    prd_descricao: string 
    prs_descricao: string    
    prg_descricao: string   
    qtdeproduto: number 
    fc_cbenef_cd: string 
    fc_cbenef_objetivo: string 
    cst_20: number
    cst_40: number
}



class moduleProdutoCategoria { 
    Categoria : TpProdutoCategoria[]
    Departamento : TpProdutoDepartamento[]
    Secao : TpProdutoSecao[]
    Grupo : TpProdutoGrupo[]
    SubGrupo : TpProdutoSubGrupo[]
    constructor(user: moduleUserConnect) {
        this.Categoria = []
        this.Departamento = []
        this.Secao = []
        this.Grupo = []
        this.SubGrupo = []
        
    }

    async getCategoria() : Promise<TpProdutoCategoria[]> {
        let list : TpProdutoCategoria[] = []
        try {
            const result = await pagApi.get<TpProdutoCategoria[]>(`/produto/report/categoria`)
            let dt : TpProdutoCategoria[] =  result;
            list = dt; 

            
            return list;
        } catch (e) {
            console.log(`erro ${e}`)
            return list
        }
        finally {
            this.Categoria = list
        }
    }

    async getDepartamento() : Promise<TpProdutoDepartamento[]> {
    
      let listDepartamentos : TpProdutoDepartamento[] = []

      try { 

       // Criar agrupamento de departamentos APÓS buscar as categorias
            const departamentosMap = this.Categoria.reduce((grupos, categoria) => {
                const chave = categoria.prd_cddepartamento;
                
                if (!grupos[chave]) {
                    grupos[chave] = {
                    prd_cddepartamento: categoria.prd_cddepartamento,
                    prd_descricao: categoria.prd_descricao // ou campo específico do departamento
                    };
                }
                    
                    return grupos;
            }, {} as { [key: number]: {prd_cddepartamento: number, prd_descricao: string} });

            listDepartamentos = Object.values(departamentosMap);



      } catch (e) {
        console.log(`erro ${e}`)
      } finally {

        this.Departamento = listDepartamentos
        return listDepartamentos
      }
    
    
    
    }

    async getSecao(prd_cddepartamento: number) : Promise<TpProdutoSecao[]> {

        let listSecao : TpProdutoSecao[] = []
        try { 
            const categoriasFiltradas = prd_cddepartamento === 0 
                ? this.Categoria 
                : this.Categoria.filter(categoria => categoria.prd_cddepartamento === prd_cddepartamento);

            const secoesMap = categoriasFiltradas
                .reduce((grupos, categoria) => {
                    const chave = categoria.prs_cdsecao;
                    
                    if (!grupos[chave]) {
                        grupos[chave] = {
                        prs_cdsecao: categoria.prs_cdsecao,
                        prs_descricao: categoria.prs_descricao,
                        prd_cddepartamento: categoria.prd_cddepartamento
                        };
                    }
                        
                        return grupos;
                }, {} as { [key: number]: {prs_cdsecao: number, prs_descricao: string, prd_cddepartamento: number} });


                listSecao = Object.values(secoesMap).sort((a, b) => a.prs_descricao.localeCompare(b.prs_descricao));
        } catch (e) {
            console.log(`erro ${e}`)
        } finally {
            this.Secao = listSecao
            

            return listSecao
        }
    }   
    
    async getGrupo(prd_cddepartamento: number, prs_cdsecao: number) : Promise<TpProdutoGrupo[]> {
        let listGrupo : TpProdutoGrupo[] = []
        try { 
            const gruposMap = this.Categoria
                .filter(categoria => 
                    (prd_cddepartamento === 0 || categoria.prd_cddepartamento === prd_cddepartamento) && 
                    (prs_cdsecao === 0 || categoria.prs_cdsecao === prs_cdsecao)
                )
                .reduce((grupos, categoria) => {
                    const chave = categoria.prg_cdgrupo;
                    
                    if (!grupos[chave]) {
                        grupos[chave] = {
                        prg_cdgrupo: categoria.prg_cdgrupo,
                        prg_descricao: categoria.prg_descricao,
                        prd_cddepartamento: categoria.prd_cddepartamento,
                        prs_cdsecao: categoria.prs_cdsecao
                        };
                    }
                        
                        return grupos;
                }, {} as { [key: number]: {prg_cdgrupo: number, prg_descricao: string, prd_cddepartamento: number, prs_cdsecao: number} });

                listGrupo = Object.values(gruposMap);
        } catch (e) {
            console.log(`erro ${e}`)
        } finally {
            return listGrupo
        }
    }   

    async getSubGrupo(prd_cddepartamento: number, prs_cdsecao: number, prg_cdgrupo: number) : Promise<TpProdutoSubGrupo[]> {
        let listSubGrupo : TpProdutoSubGrupo[] = []
        try { 
            const subGruposMap = this.Categoria
                .filter(categoria => 
                    (prd_cddepartamento === 0 || categoria.prd_cddepartamento === prd_cddepartamento) && 
                    (prs_cdsecao === 0 || categoria.prs_cdsecao === prs_cdsecao) && 
                    (prg_cdgrupo === 0 || categoria.prg_cdgrupo === prg_cdgrupo)
                )
                .reduce((grupos, categoria) => {
                    const chave = categoria.prsg_cdsubgrupo;
                    
                    if (!grupos[chave]) {
                        grupos[chave] = {
                        prsg_cdsubgrupo: categoria.prsg_cdsubgrupo,
                        prsg_descricao: categoria.prsg_descricao,
                        prd_cddepartamento : categoria.prd_cddepartamento,         
                        prs_cdsecao : categoria.prs_cdsecao, 
                        prg_cdgrupo : categoria.prg_cdgrupo
                        };
                    }
                        
                        return grupos;
                }, {} as { [key: number]: {prsg_cdsubgrupo: number, prsg_descricao: string, prd_cddepartamento: number, prs_cdsecao: number, prg_cdgrupo: number} });

                listSubGrupo = Object.values(subGruposMap);
        } catch (e) {
            console.log(`erro ${e}`)
        } finally {
            return listSubGrupo
        }
    }

}


class moduleProduto {
    
    constructor(user: moduleUserConnect) {

    }

    async getProduto(pr_cdproduto: number) : Promise<any> {
        let produtoConsultado: any
        
        

        let urlConsulta = `produto/model/produto/${pr_cdproduto}`
        try {
            produtoConsultado = await pagApi.get<TpProduto>(urlConsulta)

        } catch (e) {
            console.log(`erro ${e}`)
            throw e
        }
        finally { 
            return produtoConsultado
        }
    }

    async getEmbalagemGtin(gtin: string) : Promise<any> {
        let embalagemGtinConsultado: any    
        let urlConsulta = `produto/model/ProdutoEmbalagemGtin/${gtin}`
        try {
            embalagemGtinConsultado = await pagApi.get<any>(urlConsulta)

        } catch (e) {
            embalagemGtinConsultado.message = `Dados para o GTIN ${gtin} não encontrado.`
            throw e
        }
        finally {
            console.log(embalagemGtinConsultado) 
            return embalagemGtinConsultado
        }
    }

    async  getList(parametro: any) : Promise<any[]> {
        let list : TpProduto[] = []
        try {

            let urlconsulta = `produto/report/list?filter=1`
            
            if (parametro.pr_cdproduto && parametro.pr_cdproduto !== 0) {
                urlconsulta += `&pr_cdproduto=${parametro.pr_cdproduto}`
            }
            
            if (parametro.pr_descricao && parametro.pr_descricao !== '') {
                urlconsulta += `&pr_descricao=${parametro.pr_descricao}`
            }

            if (parametro.prb_descricao && parametro.prb_descricao !== '') {
                urlconsulta += `&prb_descricao=${parametro.prb_descricao}`
            }

            if (parametro.prb_descricaofiscal && parametro.prb_descricaofiscal !== '') {
                urlconsulta += `&prb_descricaofiscal=${parametro.prb_descricaofiscal}`
            }

            if (parametro.prd_cddepartamento && parametro.prd_cddepartamento !== 0) {
                urlconsulta += `&prd_cddepartamento=${parametro.prd_cddepartamento}`
            }
            if (parametro.prs_cdsecao && parametro.prs_cdsecao !== 0) {
                urlconsulta += `&prs_cdsecao=${parametro.prs_cdsecao}`
            }
            if (parametro.prg_cdgrupo && parametro.prg_cdgrupo !== 0) {
                urlconsulta += `&prg_cdgrupo=${parametro.prg_cdgrupo}`
            }
            if (parametro.prsg_cdsubgrupo && parametro.prsg_cdsubgrupo !== 0) {
                urlconsulta += `&prsg_cdsubgrupo=${parametro.prsg_cdsubgrupo}`
            }
            if (parametro.filtrar_status_bluesoft && parametro.filtrar_status_bluesoft !== '') {
                urlconsulta += `&filtrar_status_bluesoft=${parametro.filtrar_status_bluesoft}`
            }
            if (parametro.filtrar_vendaexterna && parametro.filtrar_vendaexterna !== '') {
                urlconsulta += `&filtrar_vendaexterna=${parametro.filtrar_vendaexterna}`
            }

            if (parametro.filter_prb_dt_cadastro && parametro.filter_prb_dt_cadastro > 0) {
                urlconsulta += `&filter_prb_dt_cadastro=${parametro.filter_prb_dt_cadastro}`

                if (parametro.filtra_prb_dt_cadastro_ini && parametro.filtra_prb_dt_cadastro_ini !== '') {
                    urlconsulta += `&filtra_prb_dt_cadastro_ini=${parametro.filtra_prb_dt_cadastro_ini}`
                }

                if (parametro.filtra_prb_dt_cadastro_fim && parametro.filtra_prb_dt_cadastro_fim !== '') {
                    urlconsulta += `&filtra_prb_dt_cadastro_fim=${parametro.filtra_prb_dt_cadastro_fim}`
                }
            }
            



            if (parametro.filtrar_entrada_saida && parametro.filtrar_entrada_saida !== 0) {
                urlconsulta += `&filtrar_entrada_saida=${parametro.filtrar_entrada_saida}`

                if (parametro.filtrar_entrada_saida_tipo && parametro.filtrar_entrada_saida_tipo !== '') {
                    urlconsulta += `&filtrar_entrada_saida_tipo=${parametro.filtrar_entrada_saida_tipo}`
                }

                if (parametro.filtrar_entrada_saida_numero_mes && parametro.filtrar_entrada_saida_numero_mes !== 0) {
                    urlconsulta += `&filtrar_entrada_saida_numero_mes=${parametro.filtrar_entrada_saida_numero_mes}`
                }

            }


            console.log(`URL CONSULTA PRODUTO: ${urlconsulta}`)







            const result = await pagApi.get<any[]>(urlconsulta)
            let dt : any[] =  result;
            list = dt; 
            
            return list;


        } catch (e) {
            console.log(`erro ${e}`)
            return list
        }
    }

    async getSubGrupoList(parametro: any) : Promise<TpProdutoSubGrupoList[]> {
        let list : TpProdutoSubGrupoList[] = []
        try {

            let urlconsulta = `produto/report/subgrupo?filter=1`
            
            if (parametro.prd_cddepartamento && parametro.prd_cddepartamento !== '') {
                urlconsulta += `&prd_cddepartamento=${parametro.prd_cddepartamento}`
            }
            
            if (parametro.prs_cdsecao && parametro.prs_cdsecao !== '') {
                urlconsulta += `&prs_cdsecao=${parametro.prs_cdsecao}`
            }

            if (parametro.prg_cdgrupo && parametro.prg_cdgrupo !== '') {
                urlconsulta += `&prg_cdgrupo=${parametro.prg_cdgrupo}`
            }

            if (parametro.comCbenefFilter !== undefined && parametro.comCbenefFilter == 1) {
                urlconsulta += `&comCbenefFilter=${parametro.comCbenefFilter}`
            }

            if (parametro.fc_cbenef_cd && parametro.fc_cbenef_cd !== '') {
                urlconsulta += `&fc_cbenef_cd=${parametro.fc_cbenef_cd}`
            }

            const result = await pagApi.get<TpProdutoSubGrupoList[]>(urlconsulta)
            let dt : any[] =  result;
            list = dt; 
            
            return list;
        }
        catch (e) {
            console.log(`erro ${e}`)
            return list 
        }
    }
        async postAssociarCbenefSubGrupo(parametro: any) : Promise<boolean> {
        try { 
             let urlconsulta = `produto/service/produto-subgrupo-associar-cbenef`
             await pagApi.post(urlconsulta, parametro)
             return true

        } catch (e) {
            console.log(`erro ${e}`)
            return false
        }
    }

    getUrlListProdutoFilterPadrao(parametro: any) : string {
        
         let urlconsulta = `` 

         if (parametro.pr_cdproduto && parametro.pr_cdproduto !== 0) {
                urlconsulta += `&pr_cdproduto=${parametro.pr_cdproduto}`
            }
            
            if (parametro.pr_descricao && parametro.pr_descricao !== '') {
                urlconsulta += `&pr_descricao=${parametro.pr_descricao}`
            }

            if (parametro.prb_descricaofiscal && parametro.prb_descricaofiscal !== '') {
                urlconsulta += `&prb_descricaofiscal=${parametro.prb_descricaofiscal}`
            }



            if (parametro.prb_descricao && parametro.prb_descricao !== '') {
                urlconsulta += `&prb_descricao=${parametro.prb_descricao}`
            }

            if (parametro.prb_descricao_fiscal && parametro.prb_descricao_fiscal !== '') {
                urlconsulta += `&prb_descricao_fiscal=${parametro.prb_descricao_fiscal}`
            }

            if (parametro.prd_cddepartamento && parametro.prd_cddepartamento !== 0) {
                urlconsulta += `&prd_cddepartamento=${parametro.prd_cddepartamento}`
            }
            if (parametro.prs_cdsecao && parametro.prs_cdsecao !== 0) {
                urlconsulta += `&prs_cdsecao=${parametro.prs_cdsecao}`
            }
            if (parametro.prg_cdgrupo && parametro.prg_cdgrupo !== 0) {
                urlconsulta += `&prg_cdgrupo=${parametro.prg_cdgrupo}`
            }
            if (parametro.prsg_cdsubgrupo && parametro.prsg_cdsubgrupo !== 0) {
                urlconsulta += `&prsg_cdsubgrupo=${parametro.prsg_cdsubgrupo}`
            }
            if (parametro.filtrar_status_bluesoft && parametro.filtrar_status_bluesoft !== '') {
                urlconsulta += `&filtrar_status_bluesoft=${parametro.filtrar_status_bluesoft}`
            }
            if (parametro.filtrar_vendaexterna && parametro.filtrar_vendaexterna !== '') {
                urlconsulta += `&filtrar_vendaexterna=${parametro.filtrar_vendaexterna}`
            }

            if (parametro.filter_prb_dt_cadastro && parametro.filter_prb_dt_cadastro > 0) {
                urlconsulta += `&filter_prb_dt_cadastro=${parametro.filter_prb_dt_cadastro}`

                if (parametro.filtra_prb_dt_cadastro_ini && parametro.filtra_prb_dt_cadastro_ini !== '') {
                    urlconsulta += `&filtra_prb_dt_cadastro_ini=${parametro.filtra_prb_dt_cadastro_ini}`
                }

                if (parametro.filtra_prb_dt_cadastro_fim && parametro.filtra_prb_dt_cadastro_fim !== '') {
                    urlconsulta += `&filtra_prb_dt_cadastro_fim=${parametro.filtra_prb_dt_cadastro_fim}`
                }
            }
            



            if (parametro.filtrar_entrada_saida && parametro.filtrar_entrada_saida !== 0) {
                urlconsulta += `&filtrar_entrada_saida=${parametro.filtrar_entrada_saida}`

                if (parametro.filtrar_entrada_saida_tipo && parametro.filtrar_entrada_saida_tipo !== '') {
                    urlconsulta += `&filtrar_entrada_saida_tipo=${parametro.filtrar_entrada_saida_tipo}`
                }

                if (parametro.filtrar_entrada_saida_numero_mes && parametro.filtrar_entrada_saida_numero_mes !== 0) {
                    urlconsulta += `&filtrar_entrada_saida_numero_mes=${parametro.filtrar_entrada_saida_numero_mes}`
                }

                if (parametro.filtrar_entrada_saida_negativo && parametro.filtrar_entrada_saida_negativo !== '') {
                    urlconsulta += `&filtrar_entrada_saida_negativo=${parametro.filtrar_entrada_saida_negativo}`
                }

            }

            if (parametro.distribuica_regime_tributacao && parametro.distribuica_regime_tributacao !== '') {
                urlconsulta += `&distribuica_regime_tributacao=${parametro.distribuica_regime_tributacao}`
            }

            if (parametro.fornecedor_razao_social && parametro.fornecedor_razao_social !== '') {
                urlconsulta += `&fornecedor_razao_social=${parametro.fornecedor_razao_social.replace("'", "")}`
            }            


            if (parametro.figurafiscalassociada && parametro.figurafiscalassociada !== 'T') {
                urlconsulta += `&figurafiscalassociada=${parametro.figurafiscalassociada}`
            }

            if (parametro.figurafiscal && parametro.figurafiscal !== '') {
                urlconsulta += `&figurafiscal=${parametro.figurafiscal.replace("'", "")}`
            }


            if (parametro.ncm && parametro.ncm !== '') {
                urlconsulta += `&ncm=${parametro.ncm.replace("'", "")}`
            }

            if (parametro.cest && parametro.cest !== '') {
                urlconsulta += `&cest=${parametro.cest.replace("'", "")}`
            }

            if (parametro.operacaoVisualizar && parametro.operacaoVisualizar !== '') {
                urlconsulta += `&operacaoVisualizar=${parametro.operacaoVisualizar}`
            }

            if (parametro.filtrarComRegraNfce && parametro.filtrarComRegraNfce !== 'T') {
                urlconsulta += `&filtrarComRegraNfce=${parametro.filtrarComRegraNfce}`
            }

            if (parametro.filtrarComRegraNfce && parametro.filtrarComRegraNfce !== 'T') {
                urlconsulta += `&filtrarComRegraNfce=${parametro.filtrarComRegraNfce}`
            }

            if (parametro.filtrarcomestoque && parametro.filtrarcomestoque !== 0) {
                urlconsulta += `&filtrarcomestoque=${parametro.filtrarcomestoque}`
            }
    
            return urlconsulta
    
    }

}

export {  moduleProduto
        , moduleProdutoCategoria
        , type TpProduto 
        , type TpProdutoCategoria
        , type TpProdutoDepartamento
        , type TpProdutoGrupo
        , type TpProdutoSecao
        , type TpProdutoSubGrupo
        , type TpProdutoSubGrupoList

    }
