import { clsBase } from '../../../model/modelbase'
export default class tbresultado_conta_origem extends clsBase {
        contrato_bluesoft_seq: number
        op_cdoperacao: number
        plc_conta_cd: number
        prd_cddepartamento: number
        prs_cdsecao: number
        r_centro_op_cd: number
        r_conta_cd: number
        r_conta_origem_tipo_cd: number
        rh_setor_operacional_cd: number
        r_resp_cd: number
        constructor() {
            super()
            this.contrato_bluesoft_seq= 0
            this.op_cdoperacao= 0
            this.plc_conta_cd= 0
            this.prd_cddepartamento= 0
            this.prs_cdsecao= 0
            this.r_centro_op_cd= 0
            this.r_conta_cd= 0
            this.r_conta_origem_tipo_cd= 0
            this.rh_setor_operacional_cd= 0
            this.r_resp_cd= 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.contrato_bluesoft_seq = item?.contrato_bluesoft_seq
                this.op_cdoperacao = item?.op_cdoperacao
                this.plc_conta_cd = item?.plc_conta_cd
                this.prd_cddepartamento = item?.prd_cddepartamento
                this.prs_cdsecao = item?.prs_cdsecao
                this.r_centro_op_cd = item?.r_centro_op_cd
                this.r_conta_cd = item?.r_conta_cd
                this.r_conta_origem_tipo_cd = item?.r_conta_origem_tipo_cd
                this.rh_setor_operacional_cd = item?.rh_setor_operacional_cd
                this.r_resp_cd = item?.r_resp_cd
        }
    }
}