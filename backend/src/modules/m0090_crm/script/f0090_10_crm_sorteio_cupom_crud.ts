import { clsTools } from '../../../model/modelbase'

export default class f0090_10_crm_sorteio_cupom_crud {
        public static sqlScript_VERSION(): string {return `f0090_10_1012015_crm_sorteio_cupom_crud`}
        public static get(parametros : any): string {




                let data : Date = clsTools._datemomentDatStrToDate(parametros?.data_nascimento ? parametros.data_nascimento : '1900-01-01', 'YYYY-MM-DD HH:mm:ss');



                let sql =  `SELECT * from ` +  this.sqlScript_VERSION() + 
                        `(              sqlcommand := 'DBINSERT'				
                                ,       vcrm_so_temp_cd:= ${parametros?.crm_so_temp_cd ? parametros.crm_so_temp_cd : 0}			
                                ,	vnumero_cupom:= ${parametros?.numero_cupom ? parametros.numero_cupom : '0'}			
                                ,	vnumero_pedido:= ${parametros?.numero_pedido ? parametros.numero_pedido : '0'} 			
                                ,	vdata_emissao:= '${clsTools._datemomentDateToStr(parametros.data_emissao, 'YYYY-MM-DD')}'
                                ,       vdata_emissao_hora:= '${clsTools._datemomentDateToStr(parametros.data_emissao_hora, 'YYYY-MM-DD HH:mm:ss')}'			
                                ,       vsat_ecf:= ${parametros?.sat_ecf ? parametros.sat_ecf : 0}			
                                ,	vnf_numero:= ${parametros?.nf_numero ? parametros.nf_numero : 0}			
                                ,	vnf_data_emissao:= '${clsTools._datemomentDateToStr(parametros.nf_data_emissao, 'YYYY-MM-DD')}'		
                                ,	vnf_chave:= '${parametros?.nf_chave ? parametros.nf_chave : ''}'			
                                ,	vvalor:= ${parametros?.valor ? parametros.valor : 0}				
                                ,	vcpf_cnpj:= '${parametros?.cpf_cnpj ? parametros.cpf_cnpj : ''}'			
                                ,       vcrm_so_cpf:= '${parametros?.crm_so_cpf ? parametros.crm_so_cpf : ''}'			
                                ,       vcdparticipante:= ${parametros?.cdparticipante ? parametros.cdparticipante : 0}			
                                ,       vcrm_so_qtde_numero_sorteio:= ${parametros?.crm_so_qtde_numero_sorteio ? parametros.crm_so_qtde_numero_sorteio : 0}	
                        );
                       `

                       
                return sql 
        }
}