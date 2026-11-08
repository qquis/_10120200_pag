import { clsBase } from '../../../model/modelbase';

export default class tbfaturamento extends clsBase {
    seqfaturamento : number
    datafaturamento : Date 
    dataemissao : Date 
    em_cdempresa : number
    op_cdoperacao : number 
    cdparticipantecliente : number 
    cdparticipantevendedor : number 
    statusfaturamento : number 
    seqfaturamento_uuid : number 

    constructor () {
        super()
        this.seqfaturamento = 0
        this.datafaturamento = this.__defaultDateNow;
        this.dataemissao = this.__defaultDateNow;
        this.em_cdempresa = 0
        this.op_cdoperacao = 0 
        this.cdparticipantecliente = 0 
        this.cdparticipantevendedor = 0 
        this.statusfaturamento = 0 
        this.seqfaturamento_uuid = 0
    }

    async binding(item: any): Promise<void> {
        try { 
        if (item) {
            this.seqfaturamento = item?.seqfaturamento
            this.datafaturamento = item?.datafaturamento //this.myTools._datemomentDatStrToDate(`${item?.datafaturamento}`, 'YYYY-MM-DDTHH:mm:ss.SSSZ'), 
            this.dataemissao = item?.dataemissao //this.myTools._datemomentDatStrToDate(`${item?.dataemissao}`, 'YYYY-MM-DDTHH:mm:ss.SSSZ'), 
            this.em_cdempresa = item?.em_cdempresa
            this.op_cdoperacao = item?.op_cdoperacao
            this.cdparticipantecliente = item?.cdparticipantecliente
            this.cdparticipantevendedor = item?.cdparticipantevendedor
            this.statusfaturamento = item?.statusfaturamento
            this.seqfaturamento_uuid = item?.seqfaturamento_uuid
        } 
        } catch (e) {
            this.myTools.pagConsole(`tbfaturamento | binding \n Error: ${e}`);
            throw new Error(`tbfaturamento | binding \n Error: ${e}`);
        }
    }

    
}