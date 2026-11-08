import { modelTb } from "src/model/model";

export default class tbnotificacao_grupo extends modelTb {

    notificacao_grupo_cd : number
    notificacao_cd : number
    notificacao_gp_whats : string 
    notificacao_gp_email : string 
    notificacao_grupo_descricao : string 
    notificacao_celular_dd_numero_registro : string 

    constructor() {
        super();
        this.notificacao_grupo_cd = 0;
        this.notificacao_cd = 0; 
        this.notificacao_gp_whats = ``; 
        this.notificacao_gp_email = ``; 
        this.notificacao_grupo_descricao = ``; 
        this.notificacao_celular_dd_numero_registro = ``;
    }

    async binding(item: any)  {
        try {
                if (item != undefined) {
                    this.notificacao_cd = item.notificacao; 
                    this.notificacao_grupo_cd = item?.notificacao_grupo_cd; 
                    this.notificacao_gp_whats = item?.notificacao_gp_whats;
                    this.notificacao_gp_email = item?.notificacao_gp_email;
                    this.notificacao_grupo_descricao = item?.notificacao_grupo_descricao;
                    this.notificacao_celular_dd_numero_registro = item?.notificacao_celular_dd_numero_registro;
                }
        } 
        catch (e) {
            throw new Error(`Erro ${e}`)
        }
    }

    _Db_Pg_script_Insert(): string {
        return ` INSERT INTO tbnotificacao_grupo 
                        (
                            , notificacao_grupo_cd 
                            , notificacao_cd 
                            , notificacao_gp_whats 
                            , notificacao_gp_email 
                            , notificacao_grupo_descricao 
                            , notificacao_celular_dd_numero_registro 

                        )
                        values 
                        (   
                               ${this.notificacao_grupo_cd} 
                            ,  ${this.notificacao_cd} 
                            , '${this.notificacao_gp_whats}'
                            , '${this.notificacao_gp_email}' 
                            , '${this.notificacao_grupo_descricao}'
                            , '${this.notificacao_celular_dd_numero_registro}'

                        )

        
            `
    }
}