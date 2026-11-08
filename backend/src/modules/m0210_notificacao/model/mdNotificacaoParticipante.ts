import { clsTools } from "../../../model/modelbase"
//tbs
import tbnotificacao_participante from "../tbs/tbnotificacao_participante";

//submodels


export default class mdNotificacaoParticipante extends tbnotificacao_participante { 
    nome_razao : string 
    celular_dd : string
    celular_numero : string
    email_main : string
    isgroup : number
    constructor() {
        super()
        this.nome_razao = ''
        this.celular_dd = "0" 
        this.celular_numero = "0"
        this.nome_razao = ''
        this.email_main = ''
        this.isgroup = 0
    }

    bindingMd(item: any) {
        try { 
            if (item) {
                this.cdparticipante = parseInt(`${item.cdparticipante}`)
                this.nome_razao = `${item.nome_razao}`
                this.celular_dd = `${item.celular_dd}`
                this.celular_numero = `${item.celular_numero}`
                this.email_main = `${item.email_main}` 
                this.isgroup = parseInt(`${item?.isgroup}`)
            }
        } catch (e) {
            clsTools.PagErrorException('mdNotificacaoParticipante', 'bindingMd', e)
        }
    }
}