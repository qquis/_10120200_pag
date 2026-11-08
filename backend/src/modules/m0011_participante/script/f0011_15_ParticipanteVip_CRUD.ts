import { clsTools } from '../../../model/modelbase'

export default class f0011_15_ParticipanteVip_CRUD {
        public static sqlScript_VERSION(): string {return `f0011_15_1012017_tbparticipante_vip_crud`}
        public static get(parametros : any): string {
                let sql =  `SELECT ` +  this.sqlScript_VERSION() + 
                        `(              sqlcommand := 'DBINSERT'
                                ,       vvip_id := ${parametros.vip_id ? parametros.vip_id : 0}				
                                ,	vvip_cliente_id:= '${parametros.vip_cliente_id ? parametros.vip_cliente_id : '0'}'
                                ,       vvip_cpf_cnpj:= '${parametros?.vvip_cpf_cnpj}'
                                ,	vvip_cpf:= '${parametros?.vvip_cpf}'
                                ,	vvip_cnpj:= '${parametros?.vvip_cnpj}'
                                ,	vcdparticipante:= ${parametros?.vcdparticipante ? parametros.vcdparticipante : 0}
                                ,	vvip_nome_completo:= '${parametros?.vvip_nome_completo}'
                                ,	vvip_nome:= '${parametros?.vvip_nome}'
                                ,	vvip_sobre_nome:= '${parametros?.vvip_sobre_nome}'
                                ,	vvip_email:= '${parametros?.vvip_email}'
                                ,       vvip_data_nascimento:= '${parametros.vvip_data_nascimento ? clsTools._datemomentDateToStr(parametros.vvip_data_nascimento, "YYYY-MM-DD") === "Data inválida"? '1900-01-01' : clsTools._datemomentDateToStr(parametros.vvip_data_nascimento, "YYYY-MM-DD") : '1900-01-01'}'
                                ,       vvip_telefone_celular:= '${parametros?.vvip_telefone_celular ? parametros.vvip_telefone_celular : ''}'
                        );
                       `

                return sql 
        }
}