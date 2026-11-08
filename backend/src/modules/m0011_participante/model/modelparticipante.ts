import { clsTools, clsBase} from '../../../model/modelbase'



/*Tabela Principal de Participante */
import tbparticipante from '../tbs/tbparticipante'
import f0011_01_ParticipanteBlueSoft_CRUD from '../script/f0011_01_ParticipanteBlueSoft_CRUD'



/*reports*/
import reportParticipanteRhList from '../report/reportParticipanteRhList'
import reportParticipanteVipList from '../report/reportParticipanteVipList'
import reportParticipanteBlueSoftList from '../report/reportParticipanteBlueSoftList'
/*services*/

import serviceSistemaPermissao from '../../m0001_sistema/service/serviceSistemaPermissao'




/*Tipos de Participantes*/

const dataManager : clsBase = new clsBase()


type participanteinfo = { 
    info: string
    resume: string
}

export default class modelParticipante extends tbparticipante { 
    

    filter: any 
    infoRh: any
    infoVip: any
    infoBlueSoft: any
    listInfo : participanteinfo[] 
    listEnderecos : any[]
    dados : any
    contatos : any[]
    
    constructor(filter: any) {
        super()
        this.listInfo = []
        this.listEnderecos = []
        this.filter = filter
        this.dados = {}
        this.contatos = []

    }


    async Consultar() { 
        try { 


            await this.ConsultarListInfo();
            await this.ConsultarParticipantePag();
            if (this.cdparticipante && this.cdparticipante > 0) {
                await this.ConsultarParticipanteRh();
                await this.ConsultarParticipanteVIP();
                await this.ConsultarParticipanteBlueSoft();
            }
            
            
  



        }

        catch(e) {
            clsTools.PagErrorException("modelParticipante", "dataBinding", e)
        }   
    }


    async ConsultarListInfo() { 
        try { 

            this.listInfo = [
                {info: "BLUE", resume: "Informações BlueSoft"},
                
                {info: "VIP", resume: "Informações VIP/E-commerce"}
                
                
            ]

            /* CONFERE SE O USUÁRIO TEM PERMISSÃO PARA VER INFORMAÇÕES RH / DATAMACE */
            if (await serviceSistemaPermissao.getFindPermissaoTarefa(this.filter, 99915100)) {
                    this.listInfo.push({info: "RH", resume: "Informações RH / DATAMACE"});
            }


        } catch(e) { 
            clsTools.PagErrorException("modelParticipante", "dataBindingListInfo", e)
        }

    }

    async ConsultarParticipantePag() { 
        try { 
            let sql = `select 	cdparticipante 
                        ,	nome_razao 
                        ,	email_main
                        ,	celular_dd
                        ,	celular_numero
                    from tbparticipante t
                    where 1 = 1
                    and   t.cdparticipante = ${this.cdparticipante}
                    `
            if (this.cdparticipante && this.cdparticipante > 0) {
                let dataItem = await dataManager.myDataBase.RecordItem(await dataManager.myDataBase.pag.DataGet(sql), 0)
                if (dataItem) {
                    this.bindingFromRedShift(dataItem)
               }
            }
        } catch(e) { 
            clsTools.PagErrorException("modelParticipante", "dataBindingBase", e)   

        }
    }
    async ConsultarParticipanteRh() { 
        try { 

            if (this.cdparticipante && this.cdparticipante > 0) {
                        this.infoRh = await reportParticipanteRhList.get({cdparticipante: this.cdparticipante})
               }
            
        } catch(e) { 
            clsTools.PagErrorException("modelParticipante", "dataBindingRh", e)
        }
    }

    async ConsultarParticipanteVIP() {
        try {

            if (this.cdparticipante && this.cdparticipante > 0) {
                this.infoVip = await reportParticipanteVipList.get({cdparticipante: this.cdparticipante})
            }

        } catch(e) { 
            clsTools.PagErrorException("modelParticipante", "dataBindingVip", e)
        }
     }

    async ConsultarParticipanteBlueSoft() {
        try {
            
            if (this.cdparticipante && this.cdparticipante > 0) {
                this.infoBlueSoft = await reportParticipanteBlueSoftList.get({cdparticipante: this.cdparticipante})
            }   
        } catch(e) {
            clsTools.PagErrorException("modelParticipante", "dataBindingBlueSoft", e)
        }
     }




    async ObterDadosAPIBlueSoft(item : any) : Promise<any> { 
        let result: any = null
        try {
            if (item) {
                await this.bindingFromBlueSoftAPI(item)
                this.dados.tipocliente = item.tipoCliente
                this.dados.data_nascimento = item.dataNascimento? clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(item.dataNascimento, "DD/MM/YYYY"), "YYYY-MM-DD") : "1900-01-01"
                this.dados.dataNascimento = item.dataNascimento
                
                this.dados.bluesoftclientestatus = item?.clienteStatus? item?.clienteStatus == 'ATIVO'?  1 :0 : 0
                this.dados.bluesoft_pessoa_status = 1;
                this.dados.bluesoft_pessoa_data_cadastro = item?.dataCadastro? clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(item.dataCadastro, "DD/MM/YYYY HH:mm"), "YYYY-MM-DD") : "1900-01-01"


                
                /*
                 
                1	"CREDITO OK"	"CREDITO_OK"
                2	"BLOQUEADO"	"BLOQUEADO"
                3	"DEVEDOR"	"DEVEDOR"
                4	"PROTESTADO"	"PROTESTADO"
                5	"EM ANALISE"	"EM_ANALISE"
                
                */

                if (item?.saldosDoCliente){
                    if (item?.saldosDoCliente?.statusCredito) {
                        let statusCreditoBlue = item?.saldosDoCliente?.statusCredito

                        switch (statusCreditoBlue) {
                            case 'CREDITO_OK':
                                this.dados.bluesoftcliente_creditostatus_cd = 1
                                break;
                            case 'BLOQUEADO':
                                this.dados.bluesoftcliente_creditostatus_cd = 2
                                break;
                            case 'DEVEDOR':
                                this.dados.bluesoftcliente_creditostatus_cd = 3
                                break;
                            case 'PROTESTADO':
                                this.dados.bluesoftcliente_creditostatus_cd = 4
                                break;
                            case 'EM_ANALISE':
                                this.dados.bluesoftcliente_creditostatus_cd = 5
                                break;
                        }
                    }
                }

                
                if (item.enderecos && item.enderecos.length > 0) {
                        
                        for await (const endereco of item.enderecos) {
                            /*Selecionar qualquer tipo de endereço*/

                            let itemEndereco : any = {}

                            itemEndereco.descricaobluesoft_api = endereco.tipoDeEndereco
                            itemEndereco.ibge_municipio_cd = endereco?.codigoDoMunicipioNoIBGE? endereco?.codigoDoMunicipioNoIBGE : ''
                            itemEndereco.endereco_cep = endereco?.cep? endereco?.cep.replace("-","") : '00000000'
                            itemEndereco.endereco_logradouro = endereco?.rua? endereco?.rua.replace("'", "").toUpperCase() : ''
                            itemEndereco.endereco_bairro = endereco?.bairro? endereco?.bairro.replace("'", "").toUpperCase() : ''
                            itemEndereco.endereco_municipio = endereco?.cidade? endereco?.cidade
                                            .replace("'", "").toUpperCase()
                                            .replace("Ç", "C")
                                            .replace("Á", "A")
                                            .replace("É", "E")
                                            .replace("Í", "I")
                                            .replace("Ó", "O")
                                            .replace("Ú", "U") : ''
                            itemEndereco.endereco_numero = endereco?.numero? endereco?.numero.replace("'", "").toUpperCase() : ''
                            itemEndereco.endereco_uf = endereco?.uf? endereco?.uf.toUpperCase() : ''
                            itemEndereco.endereco_longitude = endereco?.longitude? endereco?.longitude : '0'
                            itemEndereco.endereco_latitude = endereco?.latitude? endereco?.latitude : '0'
                            itemEndereco.endereco_complemento = endereco?.complemento? endereco?.complemento.replace("'", "").toUpperCase() : ''


                            this.listEnderecos.push(itemEndereco)

                            if (endereco.tipoDeEndereco === "FATURAMENTO") {
                                this.dados = { ...this.dados, ...itemEndereco }
                            }
                        }
           

                    }
                    if (this.dados.endereco_cep == undefined || !this.dados.endereco_cep || this.dados.endereco_cep == '') {

                            let itemEndereco : any = {}
                            itemEndereco.descricaobluesoft_api = 'FATURAMENTO'
                            itemEndereco.endereco_cep = '03453000'
                            itemEndereco.endereco_logradouro = 'AV. RIO DAS PEDRAS'
                            itemEndereco.endereco_bairro = 'JARDIM ARICANDUVA'
                            itemEndereco.endereco_municipio = 'SAO PAULO'
                            itemEndereco.endereco_numero = '729'
                            itemEndereco.endereco_uf = 'SP'
                            itemEndereco.endereco_longitude = -23.562537
                            itemEndereco.endereco_latitude = -23.501337
                            itemEndereco.endereco_complemento = ''
                            itemEndereco.descricaobluesoft_api = '3550308'
                            this.dados = {...this.dados, ...itemEndereco}
                            
                        }
                if (item.contatos && item.contatos.length > 0) {
                    let itemContato : any = {}
                    for await (const contato of item.contatos) {
                        if (contato?.tipoContato == `EMAIL_NOTA_FISCAL_ELETRONICA`) {
                            itemContato.contato_tipo_cd = 3
                            itemContato.contato_tipo_descricao = ``
                            itemContato.contato_tipo_bluesoft_api = contato?.tipoContato? contato?.tipoContato : ''
                            itemContato.contato_email = contato?.valor? contato?.valor : ''
                            break;
                        }
                    }
                    this.contatos.push(itemContato)
                }


            }
        } catch(e) {
            clsTools.PagErrorException("modelParticipante", "ObterDadosAPIBlueSoft", e)
        }
        finally {
            return result
        }
    }

    async ObterDadosRedShift(item : any) : Promise<any> { 
        let result: any = null
        try {
            if (item) {
                await this.bindingFromRedShift(item)
                

                this.dados.bluesoft_pessoa_status = item?.bluesoftpessoastatus
                this.dados.bluesoftclientestatus = item?.bluesoftclientestatus
                this.dados.bluesoft_pessoa_data_cadastro =  clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(item?.bluesoftpessoa_data_cadastro, "YYYY-MM-DDTHH:mm:ss"), "YYYY-MM-DD")  
                this.dados.email_main = item?.email_main
                this.dados.sexo = item?.sexo
                this.dados.data_nascimento = clsTools._datemomentDateToStr(clsTools._datemomentDatStrToDate(item?.data_nascimento, "YYYY-MM-DDTHH:mm:ss"), "YYYY-MM-DD")
                this.dados.endereco_cep = item?.endereco_cep? `${item?.endereco_cep}`.replace("-", "") : "0"
                this.dados.endereco_logradouro = item?.endereco_logradouro? item?.endereco_logradouro.replace("'", "") : ""
                this.dados.endereco_numero = item?.endereco_numero? item?.endereco_numero.replace("'", "") : ""
                this.dados.endereco_complemento = item?.endereco_complemento? item?.endereco_complemento.replace("'", "") : ""
                this.dados.endereco_bairro = item?.endereco_bairro? item?.endereco_bairro.replace("'", "") : ""
                this.dados.endereco_municipio = item?.endereco_municipio? item?.endereco_municipio.replace("'", "") : ""
                this.dados.endereco_uf = item?.endereco_uf? item?.endereco_uf.replace("'", "") : ""
                this.dados.endereco_latitude = item?.endereco_latitude
                this.dados.endereco_longitude = item?.endereco_longitude
                
           
            }
                




        } catch(e) {
            clsTools.PagErrorException("modelParticipante", "ObterDadosRedShift", e)
        }
        finally {
            return result
        }
    }



    async ScriptIncluirParticipanteFromRedShift(item: any): Promise<string> {
            return this.ScriptCRUD("REDSHIFT")
    }

    async ScriptIncluirParticipanteFromAPI(): Promise<string> {
        let sql: string = ""
        try {


            sql = this.ScriptCRUD("API")
            for await (const endereco of this.listEnderecos) {

                sql += `insert into tbparticipante_endereco 
                        (       endereco_tipo_cd 
                            ,   cdparticipante 
                            ,   endereco_cep 
                            ,   endereco_logradouro
                            ,   endereco_numero 
                            ,   endereco_complemento
                            ,   endereco_bairro
                            ,   endereco_municipio
                            ,   endereco_uf
                            ,   endereco_latitude
                            ,   endereco_longitude
                            ,   ibge_municipio_cd
                        )
                        select 
                               t.endereco_tipo_cd
                            ,  p.cdparticipante
                            , '${endereco.endereco_cep}'
                            , '${endereco.endereco_logradouro}'
                            , '${endereco.endereco_numero}'
                            , '${endereco.endereco_complemento}'
                            , '${endereco.endereco_bairro}'
                            , '${endereco.endereco_municipio}'
                            , '${endereco.endereco_uf}'
                            , ${endereco.endereco_latitude}
                            , ${endereco.endereco_longitude}
                            , '${endereco.ibge_municipio_cd}'
                        from   tbparticipante p, tbparticipante_endereco_tipo t
                        where  p.cdpessoabluesoft = ${this.cdpessoabluesoft}
                          and  t.descricaobluesoft_api = '${endereco.descricaobluesoft_api}'
                          and  not exists (select 1 
                                            from        tbparticipante_endereco e 
                                            where       e.cdparticipante = p.cdparticipante 
                                              and       e.endereco_tipo_cd = t.endereco_tipo_cd
                                          );
                        update tbparticipante_endereco e
                        set    endereco_cep = '${endereco.endereco_cep}',
                               endereco_logradouro = '${endereco.endereco_logradouro}',
                               endereco_numero = '${endereco.endereco_numero}',
                               endereco_complemento = '${endereco.endereco_complemento}',
                               endereco_bairro = '${endereco.endereco_bairro}',
                               endereco_municipio = '${endereco.endereco_municipio}',
                               endereco_uf = '${endereco.endereco_uf}',
                               endereco_latitude = ${endereco.endereco_latitude},
                               endereco_longitude = ${endereco.endereco_longitude},
                               ibge_municipio_cd = '${endereco.ibge_municipio_cd}',
                               dtlog_update = current_timestamp
                        from   tbparticipante p, tbparticipante_endereco_tipo t
                        where  e.cdparticipante = p.cdparticipante
                          and  e.endereco_tipo_cd = t.endereco_tipo_cd
                          and  p.cdpessoabluesoft = ${this.cdpessoabluesoft}
                          and  t.descricaobluesoft_api = '${endereco.descricaobluesoft_api}';



                        `

            }


            if (this.contatos && this.contatos.length > 0) {
                for (const contato of this.contatos) {
                    if (contato?.contato_tipo_cd == 3) {
                        sql += `insert into tbparticipante_contato (cdparticipante, contato_tipo_cd, contato_email)
                                select p.cdparticipante, ${contato.contato_tipo_cd}, '${contato.contato_email}'
                                from tbparticipante p
                                where p.cdpessoabluesoft = ${this.cdpessoabluesoft}
                                  and not exists (
                                      select 1
                                      from tbparticipante_contato c
                                      where c.cdparticipante = p.cdparticipante
                                        and c.contato_tipo_cd = ${contato.contato_tipo_cd}
                                  );
                                update tbparticipante_contato x
                                set contato_email = '${contato.contato_email}'
                                  , dtlog_update = current_timestamp
                                from tbparticipante p
                                where x.cdparticipante = p.cdparticipante
                                  and x.contato_tipo_cd = ${contato.contato_tipo_cd}
                                  and p.cdpessoabluesoft = ${this.cdpessoabluesoft};
                                
                                `
                                
                    }
                }
            }
        } catch (e) {
            clsTools.PagErrorException("modelParticipante", "ScriptIncluirParticipanteFromAPI", e)
        }
        finally {
            return sql
        }
    }
     

    private ScriptCRUD(TipoScript: string) : string { 
        let sql: string = "";
        let registro: any = {...this, ...this.dados}
        

            return f0011_01_ParticipanteBlueSoft_CRUD.get(registro, TipoScript)
        
    }

    

}
