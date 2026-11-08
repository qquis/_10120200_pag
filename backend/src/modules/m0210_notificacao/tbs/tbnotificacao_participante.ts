import { modelTb } from "../../../model/model";

export default class tbnotificacao_participante extends modelTb {

    cdparticipante : number
    notificacao_cd : number

    constructor() {
        super();
        this.cdparticipante = 0;
        this.notificacao_cd = 0; 

    }

    async binding(item: any)  {
        try {
                if (item != undefined) {
                    this.notificacao_cd = item.notificacao; 
                    this.cdparticipante = item?.cdparticipante; 

                }
        } 
        catch (e) {
            throw new Error(`Erro ${e}`)
        }
    }

    _Db_Pg_script_Insert(): string {
        return ` INSERT INTO tbnotificacao_participante 
                        (
                            , cdparticipante 
                            , notificacao_cd 
                        )
                        values 
                        (   
                                ${this.cdparticipante} 
                             ,  ${this.notificacao_cd} 
                        )
        `
    }
}