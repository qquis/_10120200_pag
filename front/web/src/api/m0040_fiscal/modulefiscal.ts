import pagApi from "@/api/api"
import moduleDefault from "../module.default"
import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import {moduleProduto} from "../m0020_produto/moduleproduto"
import { urlToHttpOptions } from "node:url"

let urlmodulofiscal = '/fiscal'


type TpCbenefProduto = { 
            selecionado: boolean
            prg_descricao : string
            prd_cddepartamento : number
            prd_descricao : string 
            prsg_cdsubgrupo : number
            prsg_descricao : string
            pr_cdproduto : number
            prb_cdprodutobluesoft : number
            prb_descricao : string 
            prb_status: boolean
            prbt_icms_saida_cst: string
            icms_codigo_tributacao: number  
			fc_figurafiscal_descricao: string 
            subgrupo_fc_cbenef_cd: string
            cbenef_grupo_objetivo: string
            prb_blue_fc_cbenef_cd: string
            cbenef_blue_objetivo: string
            pr_pag_fc_cbenef_cd: string
            cbenef_pag_objetivo: string 
            ncm_codigo: string
            
               
}


class modulefiscal extends moduleDefault {
    myModuleProduto : moduleProduto 

    
    
    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
            super(user, '/fiscal', sis_ac_cd)   
      
        
        this.myModuleProduto = new moduleProduto(user)
    }

    async atualizarCadastroProdutoGeral(parametro: any) : Promise<boolean> {
        try { 
             let urlconsulta = `/produtobluesoft/model/importar?prb_cdProdutoBluesoft=${parametro.prb_cdprodutobluesoft_pk}`

             await pagApi.post(urlconsulta)
             return true

        } catch (e) {
            console.log(`erro ${e}`)
            return false
        }
    
    }

    async atualizarListFiguraRegraFiscal() : Promise<boolean> {
        try { 
             let urlconsulta = `${urlmodulofiscal}/service/figurafiscal/atualizar-figura-regra`

            let result : any = await pagApi.post(urlconsulta)

            if (result.data.success) {
                return true
            } else {
                return false
            }
          

        } catch (e) {
            console.log(`erro ${e}`)
            return false
        }
    
    }

    async atualizarFiguraFiscalPorProdutoUnitario() : Promise<boolean> {
        try { 
             let urlconsulta = `${urlmodulofiscal}/service/figurafiscal/atualizar-figura-produto-unitario`

            let result : any = await pagApi.post(urlconsulta)

            if (result.data.success) {
                return true
            } else {
                return false
            }
          

        } catch (e) {
            console.log(`erro ${e}`)
            return false
        }
    
    }

    async atualizarFiguraProdutoNfce() : Promise<boolean> {
        try { 
             let urlconsulta = `${urlmodulofiscal}/service/figurafiscal/atualizar-figura-produto-nfce`

            let result : any = await pagApi.post(urlconsulta)

            console.log(`result ${JSON.stringify(result)}`)
            if (result.data.success) {
                return true
            } else {
                return false
            }
          

        } catch (e) {
            console.log(`erro ${e}`)
            return false
        }
    
    }

    async atualizarFiguraProdutoNfe() : Promise<boolean> {
        try { 
             let urlconsulta = `${urlmodulofiscal}/service/figurafiscal/atualizar-figura-produto-nfe`

            let result : any = await pagApi.post(urlconsulta)

            console.log(`result ${JSON.stringify(result)}`)
            if (result.data.success) {
                return true
            } else {
                return false
            }
          

        } catch (e) {
            console.log(`erro ${e}`)
            return false
        }
    
    }

    async getListfiguraproduto(parametro: any) : Promise<any[]> {
        let list : any[] = []
        try {

            let urlconsulta = `${urlmodulofiscal}/report/figurafiscal-produto?filter=1`
            urlconsulta += this.getUrlFilterGet(parametro)
            
          

            const result = await pagApi.get<any[]>(urlconsulta)
            let dt : any[] =  result;
            list = dt; 
            
            return list;


        } catch (e) {
            console.log(`erro ${e}`)
            return list
        }
    }

    async getZanthusTributacaoIcmsPdv(parametro: any) : Promise<any[]> {
        let list : any[] = []
        try {

            let url = `${urlmodulofiscal}/report/zanthus-tributacao-icms-pdv?filter=1`
            url += await this._QueryParametros(url, parametro)
            const result = await  pagApi.get<any[]>(url)
            let dt : any[] =  result;
            list = dt; 
            

        } catch (e) {
            console.log(`erro ${e}`)
        }
        finally {
            return list;
        }
    }

    async getListfiguranfceproduto(parametro: any) : Promise<any[]> {
        let list : any[] = []
        try {

            let urlconsulta = `${urlmodulofiscal}/report/figurafiscal-nfce-produto?filter=1`
            urlconsulta += this.getUrlFilterGet(parametro)
            
          
            
            const result = await pagApi.get<any[]>(urlconsulta)
            let dt : any[] =  result;
            list = dt; 
            
            return list;


        } catch (e) {
            console.log(`erro ${e}`)
            return list
        }
    }    

    async getListfigura(parametro: any) : Promise<any[]> {
        let list : any[] = []
        try {

            let urlconsulta = `${urlmodulofiscal}/report/figurafiscal?filter=1`
            if (parametro.fc_figurafiscal_cd && parametro.fc_figurafiscal_cd !== 0) {
                urlconsulta += `&fc_figurafiscal_cd=${parametro.fc_figurafiscal_cd}`
            }
            if (parametro.fc_figurafiscal_descricao && parametro.fc_figurafiscal_descricao !== '') {
                urlconsulta += `&fc_figurafiscal_descricao=${parametro.fc_figurafiscal_descricao}`
            }

            if (parametro.filterQtdeRegraFiscal && parametro.filterQtdeRegraFiscal !== 0) {
                urlconsulta += `&filterQtdeRegraFiscal=${parametro.filterQtdeRegraFiscal}`
                urlconsulta += `&filterQtdeRegraFiscalIni=${parametro.filterQtdeRegraFiscalIni}`
                urlconsulta += `&filterQtdeRegraFiscalFim=${parametro.filterQtdeRegraFiscalFim}`
            }

            const result = await pagApi.get<any[]>(urlconsulta)
            let dt : any[] =  result;
            list = dt; 
            
            return list;
        } catch (e) {
            console.log(`erro ${e}`)
            return list
        }
    }



    async getListCbenefProduto(parametro: any) : Promise<TpCbenefProduto[]> {
        let list : TpCbenefProduto[] = []
        try {

            let urlconsulta = `${urlmodulofiscal}/report/cbenef-produto?filter=1`
            urlconsulta += this.myModuleProduto.getUrlListProdutoFilterPadrao(parametro)


            if (parametro.ComCbenefPAGFilter && parametro.ComCbenefPAGFilter === 1) {
                urlconsulta += `&ComCbenefPAGFilter=1`
            }

            if (parametro.cbenefpagFilter && parametro.cbenefpagFilter !== '') {
                urlconsulta += `&cbenefpagFilter=${parametro.cbenefpagFilter}`
            }

            if (parametro.ComCbenefBlueFilter && parametro.ComCbenefBlueFilter === 1) {
                urlconsulta += `&ComCbenefBlueFilter=1`
            }

            if (parametro.cbenefblueFilter && parametro.cbenefblueFilter !== '') {
                urlconsulta += `&cbenefblueFilter=${parametro.cbenefblueFilter}`
            }

            if (parametro.CSTFilter && parametro.CSTFilter !== 0) {
                urlconsulta += `&CSTFilter=${parametro.CSTFilter}`
            }

            if (parametro.SemCbenefBlueFilter && parametro.SemCbenefBlueFilter === 1) {
                urlconsulta += `&SemCbenefBlueFilter=1`
            }

 
            list = await pagApi.get<TpCbenefProduto[]>(urlconsulta)
   
        }
        catch (e) {
            console.log(`erro ${e}`)
            return list
        }
        return list
    }   

    async getListCbenef(parametro: any) : Promise<any[]> {
        let list : any[] = []
        try {

            let urlconsulta = `${urlmodulofiscal}/report/cbenef?filter=1`



            if (parametro.fc_cbenef_cd && parametro.fc_cbenef_cd !== 0) {
                urlconsulta += `&fc_cbenef_cd=${parametro.fc_cbenef_cd}`
            }
            if (parametro.fc_cbenef_dispositivo && parametro.fc_cbenef_dispositivo !== '') {
                urlconsulta += `&fc_cbenef_dispositivo=${parametro.fc_cbenef_dispositivo}`
            }
            if (parametro.fc_cbenef_objetivo && parametro.fc_cbenef_objetivo !== '') {
                urlconsulta += `&fc_cbenef_objetivo=${parametro.fc_cbenef_objetivo}`
            }
            if (parametro.fc_cbenef_bluesoftFilter && parametro.fc_cbenef_bluesoftFilter !== 0) {
                urlconsulta += `&fc_cbenef_bluesoftFilter=${parametro.fc_cbenef_bluesoftFilter}`
            }

            if (parametro.fc_cbenef_pag_qtde_Filter && parametro.fc_cbenef_pag_qtde_Filter !== 0) {
                urlconsulta += `&fc_cbenef_pag_qtde_Filter=${parametro.fc_cbenef_pag_qtde_Filter}`
            }

            if (parametro.fc_cbenef_blue_qtde_Filter && parametro.fc_cbenef_blue_qtde_Filter !== 0) {
                urlconsulta += `&fc_cbenef_blue_qtde_Filter=${parametro.fc_cbenef_blue_qtde_Filter}`
            }
 
            const result = await pagApi.get<any[]>(urlconsulta)
            let dt : any[] =  result;
            list = dt;
        }
        catch (e) {
            console.log(`erro ${e}`)
            return list
        }
        return list
        }   
        
    async getListCbenefCst(parametro: any) : Promise<any[]> {
        let list : any[] = []
        try {

            let urlconsulta = `${urlmodulofiscal}/report/cbenef-cst?filter=1`



            if (parametro.fc_cbenef_cd && parametro.fc_cbenef_cd !== 0) {
                urlconsulta += `&fc_cbenef_cd=${parametro.fc_cbenef_cd}`
            }

 
            const result = await pagApi.get<any[]>(urlconsulta)
            let dt : any[] =  result;
            list = dt;
        }
        catch (e) {
            console.log(`erro ${e}`)
            return list
        }
        return list
    }   
    
    getUrlFilterGet(parametro: any) : string { 
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
            if (parametro.nfce_prodito_tipo_cd && parametro.nfce_prodito_tipo_cd !== 0) {
                urlconsulta += `&nfce_prodito_tipo_cd=${parametro.nfce_prodito_tipo_cd}`
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

            if (parametro.nfce_produto_tipo_cd && parametro.nfce_produto_tipo_cd !== 0) {
                urlconsulta += `&nfce_produto_tipo_cd=${parametro.nfce_produto_tipo_cd}`
            }

            if (parametro.apenasunitario && parametro.apenasunitario !== 0) {
                urlconsulta += `&apenasunitario=${parametro.apenasunitario}`
            }

            if (parametro.prb_cdprodutobluesoft && parametro.prb_cdprodutobluesoft !== 0) {
                urlconsulta += `&prb_cdprodutobluesoft=${parametro.prb_cdprodutobluesoft}`
            }

            return urlconsulta

    } 
  
    async AtualizarProdutoCbenefPag(parametro: any) : Promise<void> {

        try { 
            await pagApi.post(`${urlmodulofiscal}/service/cbenefAtualizarProdutoPag`, parametro)
        } catch (e) {
            console.log(`erro ${e}`)
        }
        
    }

    async ExportaProdutoCbenefPagParaBluesoft(parametro: any) : Promise<void> {

        try { 
            await pagApi.post(`${urlmodulofiscal}/service/cbenefExportarProdutoBluesoft`, parametro)
        } catch (e) {
            console.log(`erro ${e}`)
        }
        
    }

    async cbenefImportarListBluesoft() : Promise<void> {

        try { 
            await pagApi.post(`${urlmodulofiscal}/service/cbenefImportarBluesoft`, {})
        } catch (e) {
            console.log(`erro ${e}`)
        }
    }

    async cbenefAtualizarZanthus() : Promise<void> {

        try { 
            await pagApi.post(`zanthus/service/atualizacao-cbenef`, {})
        } catch (e) {
            console.log(`erro ${e}`)
        }
    }

}

class modulefiscalConst { 
    static getTipoCliente() : any[] {
        return [
            {tipo: 'TIPO_REVENDA', descricao: 'Revenda'},
            {tipo: 'TIPO_SIMPLES_NACIONAL', descricao: 'Simples Nacional'},
            {tipo: 'TIPO_CONSUMIDOR', descricao: 'Consumidor'},
        ]
    }
    static getregrafiscal_nfce_produto_tipo() : any[] {
        return [
            {nfce_produto_tipo_cd: 1, nfce_produto_tipo_descricao: 'NFCE'},
            {nfce_produto_tipo_cd: 3, nfce_produto_tipo_descricao: 'REVENDA'},

        ]
    }
}

export {  modulefiscal , type TpCbenefProduto, modulefiscalConst }



/*


 

*/