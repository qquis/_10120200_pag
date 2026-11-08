import {clsBase} from "../../../model/modelbase";
import ModelUserPermissao from "./modelUserPermissao";
import reportPermissaolist from "../report/reportSistemaPermissaoList";
export default class ModelUserConnect extends clsBase { 

        sis_us_seq: number
        user_name: string
        cdparticipante: number
        nome_razao: string 
        cdpessoabluesoft : number 
        email_main: string
        password: string

        PermissaoList : ModelUserPermissao[]
        ambiente: string

    constructor() {
            super()
    
            this.sis_us_seq = 0
            this.email_main = ''
            this.password = ''
            this.user_name = ''
            this.cdparticipante = 0
            this.cdpessoabluesoft = 0
            this.nome_razao = `` 


            this.PermissaoList = []
            this.ambiente = process.env.ENVIRONMENT || ''
    }

    public async consultar(sis_us_seq: number, sis_cd : number) : Promise<void> { 
        try { 
            

            if (sis_us_seq == 0)
                throw new Error(`ModelUserConnect | Consultar : sis_us_seq não informado`)

             let sql = `SELECT        u.sis_us_seq 
                            ,         u.user_name 
                            ,         u.data_cadastro 
                            ,         p.cdparticipante 
                            ,         p.nome_razao 
                            ,         p.cdpessoabluesoft 
                            ,         p.email_main 
                        FROM          tbsistema_usuario       u 
                        inner join    tbparticipante_bluesoft b on b.cdpessoabluesoft = u.cdpessoabluesoft 
                        inner join    tbparticipante          p on p.cdparticipante = b.cdparticipante 
                        where         sis_us_seq = ${sis_us_seq}
                       `


            let resultItem : any = await this.myDataBase.RecordItem(await this.myDataBase.pag.DataGet(sql),0)

            
            if (resultItem) 
            {
                this.sis_us_seq = resultItem?.sis_us_seq
                this.email_main = resultItem?.email_main
                this.user_name = resultItem?.user_name
                this.nome_razao = resultItem?.nome_razao
                this.cdparticipante = resultItem?.cdparticipante
                this.cdpessoabluesoft = resultItem?.cdpessoabluesoft
                await this.permissoesGet(sis_cd)

            }

        } catch(e) { 
            this.myTools.PagErrorException('ModelUserConnect', 'consultar', e)
        }
        
    }

    public async permissoesGet(sis_cd : number) : Promise<void> {
        try { 

            this.PermissaoList = await reportPermissaolist.getModel({sis_us_seq : this.sis_us_seq, sis_cd : sis_cd})
            
        }  catch (e) { 
                this.myTools.PagErrorException('ModelUserConnect', 'consultar', e)
        }

    }

}
