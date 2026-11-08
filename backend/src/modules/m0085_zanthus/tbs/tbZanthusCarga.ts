import { modelTb } from "../../../model/model"
import { clsTools } from "../../../model/modelbase";

export default class tbzanthus_carga extends modelTb {
        carga_uuid: string					
        carga_seq: number                       
        carga_data: Date                      
        carga_status_cd: number  
        carga_hora_ini: Date                  
        carga_hora_fim: Date                  
        carga_tipo_cd: number     
        carga_usr_seq_create: number              
        constructor() {
            super();
            this.carga_uuid = ``
            this.carga_seq = 0
            this.carga_data = this.__defaultDateNow
            this.carga_status_cd = 0
            this.carga_hora_ini = this.__defaultDateNow
            this.carga_hora_fim = this.__defaultDateNow
            this.carga_tipo_cd = 0
            this.carga_usr_seq_create = 0
        } 

        async binding(item: any): Promise<void> {
            try { 

                this.carga_uuid = item?.carga_uuid
                this.carga_seq = parseInt(item?.carga_seq)
                this.carga_data = item?.carga_data ? new Date(item.carga_data) : this.__defaultDateNow
                this.carga_status_cd = parseInt(item?.carga_status_cd)
                this.carga_hora_ini = item?.carga_hora_ini ? new Date(item.carga_hora_ini) : this.__defaultDateNow
                this.carga_hora_fim = item?.carga_hora_fim ? new Date(item.carga_hora_fim) : this.__defaultDateNow
                this.carga_tipo_cd = parseInt(item?.carga_tipo_cd)
                this.carga_usr_seq_create = parseInt(item?.carga_usr_seq_create)
                    


            } catch (e) { 
                clsTools.pagConsole(`M0085 _ Zanthus | tbZanthusCarga.binding Error: ${e}`, true)

            }
        }

        _Db_Pg_script_Insert(): string {
            return `
                        INSERT INTO		tbzanthus_carga (
                                            carga_uuid
                                        ,	carga_status_cd
                                        ,	carga_hora_ini
                                        ,	carga_hora_fim
                                        ,	carga_tipo_cd
                                        ,	carga_usr_seq_create
                                        )
    
                            SELECT			DISTINCT
                                            '${this.carga_uuid}'
                                        ,	1
                                        ,	'${clsTools._datemomentDateToStr(this.carga_hora_ini,'YYYY-MM-DD HH:mm:ss')}'::timestamp
                                        ,	'${clsTools._datemomentDateToStr(this.carga_hora_fim,'YYYY-MM-DD HH:mm:ss')}'::timestamp
                                        ,	${this.carga_tipo_cd}
                                        ,	${this.carga_usr_seq_create}
                            WHERE NOT EXISTS (
                                            SELECT 1
                                            FROM tbzanthus_carga
                                            WHERE carga_uuid = '${this.carga_uuid}'
                                        );
            `
        }

        _Db_Pg_script_Update(): string {
            return `
                        UPDATE  tbzanthus_carga
                           SET  carga_status_cd = ${this.carga_status_cd}
                            ,   carga_hora_ini = '${clsTools._datemomentDateToStr(this.carga_hora_ini,'YYYY-MM-DD HH:mm:ss')}'::timestamp
                            ,   carga_hora_fim = '${clsTools._datemomentDateToStr(this.carga_hora_fim,'YYYY-MM-DD HH:mm:ss')}'::timestamp
                            ,   dtlog_update = current_timestamp
                        WHERE   carga_uuid = '${this.carga_uuid}'
            `
        }
        




}

