import tbpreco_agendamento from "../tbs/tbprecoagendamento";
import bluesoft_api from '../../Apis/bluesoftApi/url/bluesoftApiUrl'
import myTools from "../../../tools/Tools";


export default class modelprecoagendado extends tbpreco_agendamento {
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

    constructor () {
        super()

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
                this.prca_dt_aplicacao = myTools.pagDateTime_getDate(item.prca_dt_aplicacao?item.prca_dt_aplicacao:this.__defaultDateNow)

        }

        catch (e) { 
            myTools.pagConsoleLog(`modelprecoaplicacao | ERROR \n ${e}`, true)
        }
    }

    public async BlueSoftIntegrar() {

        

        let dadosApi = {
            "produtoKey": this.prb_cdprodutobluesoft,
            "dataInicialOferta": `${myTools._dataformatgetstr(this.prca_dt_aplicacao.toString())} 08:00:00`,
            "dataFinalOferta": `${myTools._dataformatgetstr(this.prca_dt_aplicacao.toString())} 23:00:00`,
            "lojasKeys": [
                    1
                ],
            "aplicarAosEquivalentes": true,
            "precoOferta": this.prc_valor
        }

        const ItemProcessamento = {
            prb_cdprodutobluesoft : this.prb_cdprodutobluesoft, 
            dados: dadosApi

        }


        console.log(dadosApi)

        //let ResultadoBlue = {}
        //ResultadoBlue = await bluesoft_api.api_post("vendas/precos/ofertas", ItemProcessamento)


    }
}