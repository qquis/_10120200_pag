
import { clsTools, clsBase} from '../../../model/modelbase'

let myBase = new clsBase()


import apiVip from '../../Apis/vipApi/api';

//import modelParticipante from '../model/model_participante';
import modelparticipanteVip from '../model/modelparticipanteVip';


export default class serviceParticipanteVipImport { 
    static async start(parametros: any): Promise<void> {


        let resultSucess : number = 0;
        try { 



            clsTools.pagConsole(`F0011 - Participante - Service serviceParticipanteVipImport - Inicializado`)

            let parametrosVIP : any = {
                    page: 1,
                    data_ultima_alteracao_ini: parametros.data_ultima_alteracao_ini,
                    data_ultima_alteracao_fim: parametros.data_ultima_alteracao_fim
            }

            if (parametros.id) {
                parametrosVIP = {
                    page: 1,
                    id: parametros.id
                }
            }


            let numeroPaginas : number = 0
            if (parametrosVIP.id) {
                numeroPaginas = 1
            } else {
                numeroPaginas = await apiVip.clientes.pagination(parametrosVIP)
                clsTools.pagConsole(`F0011 - Participante - Service serviceParticipanteVipImport - Inicializado _ N de Paginas: ${numeroPaginas}`)
            }


            let i = 0;
            let maxInsert = 1
            if (parametrosVIP.id) {
                maxInsert = 50
            }


            let sqlinsertBlock = ''

            
            for (let p = 1; p <= numeroPaginas; p++) {

                parametrosVIP.page = p
                

                if(numeroPaginas > 1) {
                    clsTools.pagConsole(`F0011 - Participante - Service serviceParticipanteVipImport Processando página ${p} de ${numeroPaginas}`)
                }

                
                
                let result : object = await apiVip.clientes.get(parametrosVIP)

                for await ( const[key, value] of Object.entries(result)) {
                            let myitem : modelparticipanteVip = new modelparticipanteVip()            
                            myitem.vip_binding_api(value)


                            // Monta bloco de insert
                            
                            sqlinsertBlock += myitem.vip_getSqlCrud()
                            if (i >= maxInsert) {
                                i = 0;

                                resultSucess = await this.updateSqlBlock(sqlinsertBlock)
                            
                                if (resultSucess == 0) {
                                     throw new Error(`Erro ao inserir bloco de Participante VIP`) 
                                }
                                sqlinsertBlock = ''
                            }
                            i++
                    }
            }
            
            if (sqlinsertBlock !== '') {
                let resultSucess = await this.updateSqlBlock(sqlinsertBlock)
                if (resultSucess == 0) {
                    throw new Error(`Erro ao inserir bloco de Participante VIP`)
                }
            }

            //list.map(item => { console.log(item.participante_vip.vip_nome) } )
            clsTools.pagConsole(`F0011 - Participante - Service serviceParticipanteVipImport - Finalizado`)

        } catch (e: any) {
            clsTools.PagErrorException(`F0011 - Participante`, `serviceParticipanteVipImport.start()`, e, true);
            throw new Error(`modules | Participante | Error ${e.message}`);
    
        }
    }


    static async updateSqlBlock( sql : string ) : Promise<number> { 
        
        let executado: number = 0
        try { 
            executado = await myBase.myDataBase.pag.Execute(sql)
        } catch (e: any) {
            clsTools.PagErrorException(`modules | Participante`, `serviceParticipanteVipImport.updateSqlBlock()`, e, true);
            throw new Error(`modules | Participante | Error ${e.message}`);
        }
        finally {
            return executado
        }   
    }
}
