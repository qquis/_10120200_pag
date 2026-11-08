
import { clsTools, clsBase} from '../../../model/modelbase'



/*Tabela Principal de Participante */
import tbparticipante from '../tbs/tbparticipante'
import tbparticipanteBluesoft from '../tbs/tbparticipanteBluesoft'
import f0011_01_ParticipanteBlueSoft_CRUD from '../script/f0011_01_ParticipanteBlueSoft_CRUD'

const dataManager : clsBase = new clsBase()

/*reports*/
import reportParticipanteRhList from '../report/reportParticipanteRhList'
import reportParticipanteVipList from '../report/reportParticipanteVipList'
import reportParticipanteBlueSoftList from '../report/reportParticipanteBlueSoftList'

/*services*/

import serviceSistemaPermissao from '../../m0001_sistema/service/serviceSistemaPermissao'


export default class modelParticipanteBase { 

    
    static async Consultar(par : any) : Promise<any> { 
        
        let data : any = {}
        try { 
            
            
            
            data = await this.ConsultarParticipante(par)
            data.listInfo = await this.ConsultarListInfo(par)
            if (data && data.cdparticipante && data.cdparticipante > 0) {
                data.infoRh = await this.ConsultarParticipanteRh(par);
                data.infoVip = await this.ConsultarParticipanteVIP(par);
                data.infoBlueSoft = await this.ConsultarParticipanteBlueSoft(par);
            }
            
        }

        catch(e) {
            clsTools.PagErrorException("modelParticipante", "dataBinding", e)
        }   
    
        finally {

            return data
        }
        
    
    }

    static async ConsultarListInfo(par: any) : Promise<any> { 
            let listInfo = [
                {info: "BLUE", resume: "Informações BlueSoft"},
                
                {info: "VIP", resume: "Informações VIP/E-commerce"}
                
                
            ]

        try { 
            /* CONFERE SE O USUÁRIO TEM PERMISSÃO PARA VER INFORMAÇÕES RH / DATAMACE */
            if (await serviceSistemaPermissao.getFindPermissaoTarefa(par, 99915100)) {
                    listInfo.push({info: "RH", resume: "Informações RH / DATAMACE"});
            }
        } catch(e) { 
            clsTools.PagErrorException("modelParticipante", "dataBindingListInfo", e)
        }
        finally {
            return listInfo
        }

    }

    static async ConsultarParticipante(par : any) : Promise<any> { 
        let ParticipantePag : any = null
        try { 
            let sql = `select 	cdparticipante 
                        ,	nome_razao 
                        ,	email_main
                        ,	celular_dd
                        ,	celular_numero
                    from tbparticipante t
                    where 1 = 1
                    and   t.cdparticipante = ${par.cdparticipante}
                    `
            if (par.cdparticipante && par.cdparticipante > 0) {
                let dataItem = await dataManager.myDataBase.RecordItem(await dataManager.myDataBase.pag.DataGet(sql), 0)
                if (dataItem) {
                    ParticipantePag =  dataItem
               }
            }
        } catch(e) { 
            clsTools.PagErrorException("modelParticipante", "dataBindingBase", e)   

        }
        finally {
            return ParticipantePag
        }
    }
    
    static async ConsultarParticipanteRh(par : any) : Promise<any> { 
        try { 

            if (par.cdparticipante && par.cdparticipante > 0) {
                        return await reportParticipanteRhList.get({cdparticipante: par.cdparticipante})
               }
            
        } catch(e) { 
            clsTools.PagErrorException("modelParticipante", "dataBindingRh", e)
        }
    }

    static async ConsultarParticipanteVIP(par : any) : Promise<any> {
        let ParticipanteVIP : any = null
        try {

            if (par.cdparticipante && par.cdparticipante > 0) {
                ParticipanteVIP = await reportParticipanteVipList.get({cdparticipante: par.cdparticipante})
            }

        } catch(e) { 
            clsTools.PagErrorException("modelParticipante", "dataBindingVip", e)
        }
        finally {
            return ParticipanteVIP
        }
    }

    static async ConsultarParticipanteBlueSoft(par : any) : Promise<any> {
        try {
            
            if (par.cdparticipante && par.cdparticipante > 0) {
                return await reportParticipanteBlueSoftList.get({cdparticipante: par.cdparticipante})
            }   
        } catch(e) {
            clsTools.PagErrorException("modelParticipante", "dataBindingBlueSoft", e)
        }
    }

    static async ScriptIncluirParticipanteBlueSoft(itemRedShift : any, source : string = "REDSHIFT") : Promise<string> {

        let script : string = ""
        try  {
            script = f0011_01_ParticipanteBlueSoft_CRUD.get(itemRedShift, source)
        }
        catch(e) {
            clsTools.PagErrorException("modelParticipante", "ScriptIncluirParticipanteBlueSoft", e)
        }

        finally {
            return script
        }
     }  


    
   
}






