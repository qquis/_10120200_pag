import { clsBaseTb } from '../../../model/class.Base'
export default class tbgrupoeconomico extends clsBaseTb {
        cdgrupoeconomico: number
        descricao: string
        descricaoresumida: string
        referencia: string
        grupoeconomico_status: number
        forma_pgto_cd_padrao: number

        constructor() {
            super()
            this.cdgrupoeconomico = 0
            this.descricao = ''
            this.descricaoresumida = ''
            this.referencia = ''
            this.grupoeconomico_status = 0
            this.forma_pgto_cd_padrao = 0
        }
        
        async binding(item: any): Promise<void> {
            /*
                Le as informações do banco de dados 
            */
            if (item) {
                this.cdgrupoeconomico = item?.cdgrupoeconomico
                this.descricao = item?.descricao
                this.descricaoresumida = item?.descricaoresumida
                this.referencia = item?.referencia
                this.grupoeconomico_status = item?.grupoeconomico_status
                this.forma_pgto_cd_padrao = item?.forma_pgto_cd_padrao
            }
        }
        override script_CRUD(): string {
            return this.script_insert() + '\n' + this.script_update()
        }
        script_insert(): string {
            return `INSERT INTO tbgrupoeconomico 
                    (cdgrupoeconomico, descricao, descricaoresumida, referencia, grupoeconomico_status, forma_pgto_cd_padrao) 
                    SELECT      ${this.cdgrupoeconomico}
                            ,  '${this.descricao}'
                            ,  '${this.descricaoresumida}'
                            ,  '${this.referencia}'
                            ,   ${this.grupoeconomico_status}
                            ,   ${this.forma_pgto_cd_padrao}
                            WHERE NOT EXISTS (
                                    SELECT 1 
                                    FROM tbgrupoeconomico 
                                    WHERE cdgrupoeconomico = ${this.cdgrupoeconomico}
                                    )
                            ;`
        }

        script_update(): string {
            return `UPDATE tbgrupoeconomico 
                    SET descricao = '${this.descricao}'
                      , descricaoresumida = '${this.descricaoresumida}'
                      , referencia = '${this.referencia}'
                      , grupoeconomico_status = ${this.grupoeconomico_status} 
                    WHERE cdgrupoeconomico = ${this.cdgrupoeconomico}
                    ;
                    `
        }
}