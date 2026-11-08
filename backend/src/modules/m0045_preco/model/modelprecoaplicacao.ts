import { Request } from 'express';
import myTools from "../../../tools/Tools";
import tbprecoaplicacao from '../tbs/tbprecoaplicacao';
import bluesoft_api from '../../Apis/bluesoftApi/url/bluesoftApiUrl'


export default class modelprecoaplicacao extends tbprecoaplicacao {

    prsg_cdsubgrupo: number 
    prsg_descricao: string 
    prg_cdgrupo: number
    prg_descricao: string 
    prs_cdsecao: number 
    prs_descricao: string 
    prd_cddepartamento: number 
    prd_descricao: string 
    cdpessoabluesoft: number
    nome_razao: string 
    email_main: string 
    celular_dd: number
    celular_numero: number 
    pr_descricao: string 
    prb_descricao: string 
    pre_embalagem: string
   
    /*
        preco_aplicacao_seq: number 
    preco_aplicacao_data: Date 
    tab_pre_cd: number
    pr_cdproduto: number
    pr_embalagemestoque: string 
    prc_valor_embalagemestoque: number 
    pre_fatorestoque: number 
    prb_cdprodutobluesoft: number 
    pre_embalagem: string
    prc_valor: number 
    preco_aplicacao_agendamento: boolean
    prca_seq: number 
    prc_qtde_promocional: number 
    prc_valor_promocional: number 
    prb_cdprodutobluesoft_unitario: number  
    */


    constructor(prb_cdprodutobluesoft: number) {
        super(prb_cdprodutobluesoft) 
   
        this.prsg_cdsubgrupo =  0
        this.prsg_descricao = `` 
        this.prg_cdgrupo = 0 
        this.prg_descricao = `` 
        this.prs_cdsecao = 0
        this.prs_descricao = `` 
        this.prd_cddepartamento = 0
        this.prd_descricao = `` 
        this.cdpessoabluesoft = 0 
        this.nome_razao = `` 
        this.email_main = `` 
        this.celular_dd = 0
        this.celular_numero = 0
        this.pr_descricao = `` 
        this.prb_descricao = `` 
        this.pre_embalagem = `` 
    }

    public async modelBindind(item: any) {
        try {
            if (item !== undefined)
                super.binding(item)
                this.prsg_cdsubgrupo = item.prsg_cdsubgrupo? parseInt(item.prsg_cdsubgrupo) : 0 
                this.prsg_descricao = item.prsg_descricao? item.prsg_descricao: `` 
                this.prg_cdgrupo = item.prg_cdgrupo? parseInt(item.prg_cdgrupo): 0 
                this.prg_descricao = item.prg_descricao? item.prg_descricao: ``
                this.prs_cdsecao = item.prs_cdsecao? parseInt(item.prs_cdsecao): 0
                this.prs_descricao = item.prs_descricao? item.prs_descricao: ``
                this.prd_cddepartamento = item.prd_cddepartamento? parseInt(item.prd_cddepartamento): 0
                this.prd_descricao = item.prd_descricao? item.prd_descricao: `` 
                this.cdpessoabluesoft = item.cdpessoabluesoft? parseInt(item.cdpessoabluesoft): 0
                this.nome_razao = item.nome_razao? item.nome_razao: ``
                this.email_main = item.email_main? item.email_main: `suporte@oxan.com.br` 
                this.celular_dd = item.celular_dd? item.celular_dd: 11
                this.celular_numero = item.celular_numero? item.celular_numero :  27825255
                this.pr_descricao = item.pr_descricao 
                this.prb_descricao = item.prb_descricao? item.prb_descricao: `` 
                this.pre_embalagem = item.pre_embalagem? item.pre_embalagem: `UN` 

        }

        catch (e) { 
            myTools.pagConsoleLog(`modelprecoaplicacao | ERROR \n ${e}`, true)
        }
    }

    public async modelBlueSoftAtualizar(request?: Request) {

        try { 
            if (request)
            {
                if (request.body !== undefined)
                {
                    this.prb_cdprodutobluesoft =  parseInt(`${request?.query.prb_cdprodutobluesoft}`)
                    this.prc_valor = Number(`${request?.query.prc_valor}`)
                }
            }


            if ( this.prb_cdprodutobluesoft !== 0 && this.prc_valor > 0  ) {
            
                const dados = {
                    "aplicarPrecoParaCaixa": true,
                    "dataInicialAVigorar": `${(new Date()).toLocaleString("pt-br").substring(0,10)} 08:01:01`,
                    "produtoKey": this.prb_cdprodutobluesoft,
                    "regioes": [
                                    {
                                    "precoAPartirDe": 0,
                                    "precoAtacado": 0,
                                    "precoFidelidade": 0,
                                    "precoVenda": this.prc_valor,
                                    "quantidadeAPartirDe": 0,
                                    "regiaoKey": 1
                                    }
                                ]           
                    }

                    const ItemProcessamento = {
                        prb_cdprodutobluesoft: this.prb_cdprodutobluesoft, 
                        dados: dados
                    }
                
                    
                    let ResultadoBlue = {}
                    ResultadoBlue = await bluesoft_api.api_post("vendas/precos", ItemProcessamento.dados )
                    await myTools.pagConsoleLog(`F0045 _ ModelPrecoAplicacao | modelBlueSoftAtualizar Produto: ${this.prb_cdprodutobluesoft} Preço: ${this.prc_valor}`)
                
            } else {
                await myTools.pagConsoleLog(`F0045 _ ModelPrecoAplicacao | modelBlueSoftAtualizar (ERROR: DADOS INCORRETOS) Produto: ${this.prb_cdprodutobluesoft} Preço: ${this.prc_valor}`)
            }
        }

        catch(e) {
            myTools.pagConsoleLog(`modelprecoaplicacao | modelBlueSoftAtualizar ERROR [Produto ${this.prb_cdprodutobluesoft} Preço ${this.prc_valor}] ${e}`)

        }
    }
}