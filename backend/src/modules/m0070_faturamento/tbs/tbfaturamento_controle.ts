import { clsBase } from '../../../model/modelbase';

export default class tbfaturamento_controle extends clsBase {
    seqfaturamento_uuid : string  
    faturamento_controle_seq : number 
    dataemissao : Date 
    datafaturamento : Date 
    numeropedido : number 
    numeropedido_fv : number 
    df_nf_seq_blue : number 
    numeronfe : number
    sat_ecf : number 
    cupomfiscal : number 
    fat_controle_tipo_cd: number  
    seqfaturamento : number
    seqfaturamentoorigem : number 
    op_cdoperacao : number 
    cdpessoabluesoft_cliente : number 
    cdpessoabluesoft_vendedor : number 

    constructor () {
        super()
        this.seqfaturamento_uuid = `` 
        this.faturamento_controle_seq  = 0 
        this.dataemissao = new Date
        this.datafaturamento = new Date
        this.numeropedido = 0
        this.numeropedido_fv = 0
        this.df_nf_seq_blue = 0
        this.numeronfe = 0
        this.sat_ecf = 0
        this.cupomfiscal = 0
        this.fat_controle_tipo_cd = 0;
        this.seqfaturamento = 0
        this.seqfaturamentoorigem = 0
        this.op_cdoperacao = 0
        this.cdpessoabluesoft_cliente = 0
        this.cdpessoabluesoft_vendedor = 0
    }

    async binding(item: any): Promise<void> {
        try {

            if (item) {

                this.seqfaturamento_uuid = item?.seqfaturamento_uuid
                this.faturamento_controle_seq  = item?.faturamento_controle_seq
                this.dataemissao = item?.dataemissao //this.myTools._datemomentDatStrToDate(`${item?.dataemissao}`, 'YYYY-MM-DDTHH:mm:ss.SSSZ'), 
                this.datafaturamento =  item?.dataemissao // this.myTools._datemomentDatStrToDate(`${item?.datafaturamento}`, 'YYYY-MM-DDTHH:mm:ss.SSSZ'), 
                this.numeropedido = item?.numeropedido
                this.numeropedido_fv = item?.numeropedido_fv
                this.df_nf_seq_blue = item?.df_nf_seq_blue
                this.numeronfe = item?.numeronfe
                this.sat_ecf = item?.sat_ecf
                this.cupomfiscal = item?.cupomfiscal
                this.fat_controle_tipo_cd = item?.fat_controle_tipo_cd
                this.seqfaturamento = item?.seqfaturamento
                this.seqfaturamentoorigem = item?.seqfaturamentoorigem
                this.op_cdoperacao = item?.op_cdoperacao
                this.cdpessoabluesoft_cliente = item?.cdpessoabluesoft_cliente;
                this.cdpessoabluesoft_vendedor = item?.cdpessoabluesoft_vendedor;
            }


        } catch(e) { 
            this.myTools.pagConsole(`\n PAG ERROR ---------------------------------------------------- 
                             \n Class tbfaturamento_controle \n Binding \n Error description \n ${e}`)
            throw new Error(`\n PAG ERROR ---------------------------------------------------- 
                             \n Class tbfaturamento_controle \n Binding \n Error description \n ${e}`)
        }
    }
}