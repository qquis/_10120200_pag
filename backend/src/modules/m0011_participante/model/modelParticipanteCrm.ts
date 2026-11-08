import { Router, Request, Response } from 'express';
import { clsTools, clsBase} from '../../../model/modelbase'
import tbparticipanteCrm from '../tbs/tbparticipanteCrm';
import f0011_20_ParticipanteCRM_CRUD from '../script/f0011_20_ParticipanteCrm_CRUD';


let myDataBase = new clsBase();



export default class modelParticipanteCrm extends tbparticipanteCrm {

    constructor() {
        super();

    }

    async consultar(parametro: any) : Promise<void> {
        
        let result : any
        
        try { 

            let crm_email = parametro?.crm_email || ''
            if (!crm_email) { 
                throw new Error("E-mail do CRM não informado")
            }   

            let sql = `select 	c.crm_seq					
                            ,	c.crm_status_cd			
                            ,	c.crm_email				
                            ,	c.crm_dt_cadastro			
                            ,	c.cpf						
                            ,	c.cdparticipante 			
                            ,	c.nome					
                            ,	c.sobre_nome
                            ,   c.data_nascimento				
                            ,   c.pf_sexo
                            ,   x.pf_sexo_descricao
                        from        tbparticipante_crm c
                        left join   tbparticipante_pf_sexo x on x.pf_sexo = coalesce(c.pf_sexo, 'N')   
                        where 1 = 1
                        and   crm_email = '${crm_email}'
                        `

            result = await myDataBase.myDataBase.RecordItem(await myDataBase.myDataBase.pag.DataGet(sql),0)
            this.binding(result)



        } catch(e) { 
            clsTools.PagErrorException("M0090_ParticipanteCRM", "modelParticipanteCrm _ consultar", e)
            throw e
        }
        finally {
            if (result) { 
                this.binding(result)
            }
        }
    }

    async checkExists(parametro: any) : Promise<boolean> { 
        
        let chekExist : boolean = false
        
        try { 

            this.crm_seq = 0;
            await this.consultar(parametro)
            if (this.crm_seq > 0) { 
                chekExist = true
            }



        } catch(e) { 
            clsTools.PagErrorException("M0090_ParticipanteCRM", "modelParticipanteCrm _ conferirCadastro", e)
            throw e
        }
        finally {
            return chekExist
        }
    }

    async incluir(parametro: any) : Promise<boolean> {

        

        let registroIncluidoComSucesso : boolean = false

        try { 

            let result = await myDataBase.myDataBase.RecordItem(await myDataBase.myDataBase.pag.DataGet(f0011_20_ParticipanteCRM_CRUD.get(parametro)),0)
            
            if (result) { 
                this.binding(result)
                registroIncluidoComSucesso = true
            } 
        } catch(e) { 
            clsTools.PagErrorException("M0090_ParticipanteCRM", "modelParticipanteCrm _ incluir", e)
            throw e
        }
        finally {
            return registroIncluidoComSucesso
        }
    }

}
