import modelParticipanteCrm from "../../m0011_participante/model/modelParticipanteCrm";
import { clsBase, clsTools } from "../../../model/modelbase";



export default class reportCRMCliente {
        public static sql(parametros: any) : string { 
                let sql = `
                        select      p.crm_seq
                                ,   p.cdparticipante
                                ,   p.crm_status_cd 
                                ,   s.crm_status_descricao
                                ,   p.crm_email 
                                ,   p.crm_dt_cadastro 
                                ,   p.cpf 
                                ,   p.nome 
                                ,   p.sobre_nome 
                                ,   p.data_nascimento 
                                ,   p.pf_sexo 
                                ,   p.endereco_cep 
                                ,   p.endereco_logradouro
                                ,   p.endereco_numero
                                ,   p.endereco_complemento
                                ,   p.endereco_municipio 
                                ,   p.endereco_uf
                        from       tbparticipante_crm p
                        left join  tbparticipante_crm_status s on s.crm_status_cd = p.crm_status_cd

                        where 1 = 1
                        ${ parametros.cdparticipante ? ` and p.cdparticipante = ${parametros.cdparticipante} ` : '' }
                        ${ parametros.crm_status_cd ? ` and p.crm_status_cd = ${parametros.crm_status_cd} ` : '' }
                        ${ parametros.dt_cadastro_inicio ? ` and p.crm_dt_cadastro >= '${parametros.dt_cadastro_inicio}' ` : '' }
                        ${ parametros.dt_cadastro_fim ? ` and p.crm_dt_cadastro <= '${parametros.dt_cadastro_fim}' ` : '' }
                        
                `;

                return sql;
        }

        static async get(parametros: any) : Promise <modelParticipanteCrm[]> { 
                let list : modelParticipanteCrm[] = [];
            
                try { 
                            const modeldb = new clsBase(); 
                            let result = await modeldb.myDataBase.pag.DataGet(this.sql(parametros));

                            for await (const[key, value] of result.entries()) { 
                                    let model = new modelParticipanteCrm();
                                    model.binding(value)
                                    list.push(model);
                            }


                } catch (e) {
                      clsTools.PagErrorException(`reportCRMClientes.get`,`get`, e);
         
                } finally { 
                        return list;
                }

        }
}