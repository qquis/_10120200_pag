import { clsBase, clsTools } from "../../../model/modelbase";
import tbzanthus_carga from "../tbs/tbZanthusCarga";
import model_zanthus_carga_produto from "./model_zanthus_carga_produto";


export default class model_zanthus_carga extends tbzanthus_carga  {
    /* CHAVES */
  
    zanthusCargaProduto: model_zanthus_carga_produto

    constructor() {
        super();
        this.zanthusCargaProduto = new model_zanthus_carga_produto()

    }

    scriptAtualizarStatusIniciar(): string {
        return `Update tbzanthus_carga
                SET carga_status_cd = 2
                ,   dtlog_update = current_timestamp
                ,   carga_hora_ini = current_timestamp
                WHERE carga_uuid = '${this.carga_uuid}'`
    }

    scriptAtualizarStatusFinalizar(): string {
        return `Update tbzanthus_carga
                SET carga_status_cd = 3
                ,   dtlog_update = current_timestamp
                ,   carga_hora_fim = current_timestamp
                WHERE carga_uuid = '${this.carga_uuid}'`
    }


 
}