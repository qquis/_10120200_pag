import { clsTools } from "../../../model/modelbase";
import tbfc_cbenef from "../tbs/tbfc_cbenef";

export default class modelfc_cbenef extends tbfc_cbenef { 

    constructor() {
        super()
    }

    getCbenefBLueApi(item: any) {
        if (item) {
            this.fc_cbenef_cd = item?.codigoBeneficioFiscal
            this.fc_cbenef_bluesoft_cd = item?.beneficioFiscalKey
            this.fc_cbenef_dispositivo = item?.descricao
            this.fc_cbenef_objetivo = item?.observacao
            this.fc_cbenef_bluesoft_dispositivo = item?.descricao
            this.fc_cbenef_bluesoft_objetivo = item?.observacao
            this.fc_cbenef_bluesoft = 1
        }
    }
    sqlInserirDadosDeApi() : string {
        let sql = `insert into tbfc_cbenef 
                                    (fc_cbenef_cd,
                                    fc_cbenef_bluesoft_cd,
                                    fc_cbenef_dispositivo,
                                    fc_cbenef_objetivo,
                                    fc_cbenef_bluesoft_dispositivo,
                                    fc_cbenef_bluesoft_objetivo, 
                                    fc_cbenef_bluesoft


                                ) 
                                select   '${this.fc_cbenef_cd}', 
                                        ${this.fc_cbenef_bluesoft_cd},
                                        '${this.fc_cbenef_dispositivo}', 
                                        '${this.fc_cbenef_objetivo}', 
                                        '${this.fc_cbenef_bluesoft_dispositivo}', 
                                        '${this.fc_cbenef_bluesoft_objetivo}',            
                                        1
                                where not exists (select 1 from tbfc_cbenef where fc_cbenef_cd = '${this.fc_cbenef_cd}')
                                ;

                                update tbfc_cbenef
                                set  fc_cbenef_bluesoft_cd = ${this.fc_cbenef_bluesoft_cd},
                                        fc_cbenef_bluesoft_dispositivo = '${this.fc_cbenef_bluesoft_dispositivo}',
                                        fc_cbenef_bluesoft_objetivo = '${this.fc_cbenef_bluesoft_objetivo}',
                                        dtlog_update = current_timestamp
                                where fc_cbenef_cd = '${this.fc_cbenef_cd}'
                                ;`
        return sql


    }
    


}