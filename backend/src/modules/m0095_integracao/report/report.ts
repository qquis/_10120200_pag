import { Request } from "express"; 
import { iIntegracao, iIntegracaoProduto, typeIntegracaoProduto } from "../interfaces";
import myTools from "../../../tools/Tools";
import bluesoftApi from "../../Apis/bluesoftApi/url/bluesoftApiUrl"

import { mdoReport, modelReport } from '../../../model/model';


/* Script */
import f0095_10_report_integracaoproduto from '../pgscripts/f0095_10_report_integracaoproduto'
import script_select_integracao_produto_20004501 from '../pgscripts/scripts.select_integracao_produto_20004501';
import script_select_integracao_produto_20004502 from '../pgscripts/scripts.select_integracao_produto_20004502';



export default class reportIntegracao extends mdoReport {
    
    IntegracaoFiltro : iIntegracao
    IntegracaoProdutoFiltro : iIntegracaoProduto


    constructor(request?: Request) {

        super(); 
        this.IntegracaoFiltro = { 
              integracao_cd : 0
            , integracao_tipo_cd : 0
            , integracao_status_cd : 0
        }


        this.IntegracaoProdutoFiltro = { 
              integracao_cd : 0
            , integracao_tipo_cd : 0
            , integracao_status_cd : 0
            , pr_cdproduto: 0
            , prb_cdprodutobluesoftunitario: 0
            , prb_cdprodutobluesoft: 0
        }

        
        /*Averiguar Filtros no Body do Request*/
        this.getRequest(request)

        this.getRequest(request);

    }

    getRequest(request?: Request)  {
        let integracao_cd : number = 0 
        let integracao_tipo_cd : number = 0  
        let integracao_status_cd : number = 0
        let pr_cdproduto: number = 0 
        let prb_cdprodutobluesoftunitario: number = 0
        let prb_cdprodutobluesoft: number = 0

        if (request)
        {
            integracao_cd = request.body.integracao_cd? parseInt(request.body.integracao_cd) : 0
            integracao_tipo_cd = request.body.integracao_tipo_cd? parseInt(request.body.integracao_tipo_cd) : 0
            integracao_status_cd = request.body.integracao_status_cd? parseInt(request.body.integracao_status_cd) : 0
            pr_cdproduto = request.body.pr_cdproduto? parseInt(request.body.pr_cdproduto) : 0
            prb_cdprodutobluesoftunitario = request.body.prb_cdprodutobluesoftunitario? parseInt(request.body.prb_cdprodutobluesoftunitario) : 0
            prb_cdprodutobluesoft = request.body.prb_cdprodutobluesoft? parseInt(request.body.prb_cdprodutobluesoft) : 0
        }

        this.IntegracaoFiltro = {
                integracao_cd
            ,   integracao_tipo_cd
            ,   integracao_status_cd
        }

        this.IntegracaoProdutoFiltro =  {
              integracao_cd  
            , integracao_tipo_cd   
            , integracao_status_cd 
            , pr_cdproduto 
            , prb_cdprodutobluesoftunitario
            , prb_cdprodutobluesoft
        }
    }

    async reportIntegracaoTipoProduto() : Promise<object> {
        try {
            const result = await super.dataPag_get(f0095_10_report_integracaoproduto.SELECT(this.IntegracaoProdutoFiltro)); 
            return result; 

        } catch (e) {
            myTools.pagConsoleLog(`Reports | Error \n ${e}`)
            return [];
        }
    }

 
    
}