import tbresultado_conta_origem from "../tbs/tbresultado_conta_origem";



export default class modelResultaContaOrigem extends tbresultado_conta_origem {
    op_descricao: string  
    r_conta_origem_tipo_descricao: string 
    r_centro_op_descricao: string 
    plc_descricao: string 
    prd_descricao: string 
    prs_descricao: string 
    rh_setor_operacional_descricao: string 
    r_resp_descricao: string 
    cdparticipante?: number
    nome_razao?: string
    
    constructor() { 
        super() 
        this.op_descricao = `` 
        this.r_conta_origem_tipo_descricao = ``   
        this.r_centro_op_descricao = ``   
        this.plc_descricao = ``   
        this.prd_descricao = ``   
        this.prs_descricao = ``   
        this.rh_setor_operacional_descricao = ``
        this.r_resp_descricao = ``    
        this.cdparticipante = 0;
        this.nome_razao = ``;
        
    }

    async modelBinding(item: any) { 
        if (item) { 
            super.binding(item)
            this.op_descricao = item?.op_descricao
            this.r_conta_origem_tipo_descricao = item?.r_conta_origem_tipo_descricao
            this.r_centro_op_descricao = item?.r_centro_op_descricao
            this.plc_descricao = item?.plc_descricao
            this.prd_descricao = item?.prd_descricao
            this.prs_descricao = item?.prs_descricao
            this.rh_setor_operacional_descricao = item?.rh_setor_operacional_descricao
            this.r_resp_descricao = item?.r_resp_descricao
            this.cdparticipante = item?.cdparticipante
            this.nome_razao = item?.nome_razao
        }
    }
}