import { clsTools } from '../../../model/modelbase'

export default class f0011_20_ParticipanteCRM_CRUD {
        public static sqlScript_VERSION(): string {return `f0011_20_1012015_tbparticipante_crm_crud`}
        public static get(parametros : any): string {




                let data : Date = clsTools._datemomentDatStrToDate(parametros?.data_nascimento ? parametros.data_nascimento : '1900-01-01', 'YYYY-MM-DD HH:mm:ss');
                


                let sql =  `SELECT * from ` +  this.sqlScript_VERSION() + 
                        `(              sqlcommand := 'DBINSERT'				
                                ,	vcrm_seq:= ${parametros?.crm_seq ? parametros.crm_seq : 0}
                                ,       vcrm_status_cd:= '${parametros?.crm_status_cd ? parametros.crm_status_cd : 'A'}'
                                ,	vcrm_email:= '${parametros?.crm_email}'
                                ,       vcpf:= '${parametros?.cpf ? parametros.cpf : ''}'
                                ,       vcdparticipante:= ${parametros?.cdparticipante ? parametros.cdparticipante : 0}
                                ,	vnome:= '${parametros?.nome ? parametros.nome : ''}'
                                ,	vsobre_nome:= '${parametros?.sobre_nome ? parametros.sobre_nome : ''}'
                                ,       vdata_nascimento:= '${clsTools._datemomentDateToStr(data, 'YYYY-MM-DD')}'
                                ,       vpf_sexo:= '${parametros?.pf_sexo ? parametros.pf_sexo : 'N'}'
                        );
                       `
                
                return sql 
        }
}