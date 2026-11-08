import { clsTools, clsBase} from '../../../model/modelbase';
import ModelUserPermissao from '../model/modelUserPermissao';


export default class reportPermissaolist{
    static sql (parametros: any = {}) : string { 
        try { 


            if (!parametros.relatorio) { 
                parametros.relatorio = 0
            }


            
            let sql = `	SELECT 	s.sis_cd_pk	as sis_cd
                            ,   s.sis_descricao
                            ,   us.sis_us_seq 
   							,	us.sis_fc_cd
                            ,	fc.sis_fc_descricao
							,	ac.sis_ac_cd
							,	ac.sis_ac_descricao 
							,	ac.sis_ac_menu
							,	ta.sis_ta_cd
							,	ta.sis_ta_descricao 
							,	s.sis_cd_pk 
							,	ac.sis_ac_gmenu_cd
							,	sis_ac_gmenu			
							,	sis_ac_gmenu_sub		
							,	sis_ac_gmenu_sub_item	
                            ,   md.sis_ac_modulo_menu_cd
                            ,   md.sis_ac_modulo_menu_descricao 
                            ,   ac.sis_ac_href  							
					FROM 		TBSISTEMA_USUARIO 		us
					inner join  tbsistema_funcao 		fc on fc.sis_fc_cd = us.sis_fc_cd
					inner join  tbsistema_permissao     pm on pm.sis_fc_cd = fc.sis_fc_Cd 
					inner join  tbsistema_acesso        ac on ac.sis_ac_cd = pm.sis_ac_cd 
                                                and ac.sis_cd = pm.sis_cd
					inner join  tbsistema_tarefa        ta on ta.sis_ta_cd = pm.sis_ta_cd 
					inner join  tbsistema				 s on s.sis_cd_pk = ac.sis_cd 
					inner join  tbsistema_acesso_grupomenu x on x.sis_ac_gmenu_cd = ac.sis_ac_gmenu_cd
                    inner join  tbsistema_acesso_modulomenu md on md.sis_ac_modulo_menu_cd = x.sis_ac_modulo_menu_cd
					left  join  tbparticipante_bluesoft pb on pb.cdpessoabluesoft = us.cdpessoabluesoft 
					left  join  tbparticipante          p on p.cdparticipante = pb.cdparticipante 
					WHERE      	1 = 1
                        ${parametros.sis_us_seq ? `and us.sis_us_seq = ${parametros.sis_us_seq}` : '' }
                        ${parametros.sis_cd && parametros.sis_cd !== '0' ? `and pm.sis_cd = ${parametros.sis_cd}` : '' }
                        ${parametros.sis_fc_cd ? `and pm.sis_fc_cd = ${parametros.sis_fc_cd}` : '' }
                        ${parametros.sis_ac_cd ? `and pm.sis_ac_cd = ${parametros.sis_ac_cd}` : '' }                                
                        ${parametros.sis_ta_cd ? `and pm.sis_ta_cd = ${parametros.sis_ta_cd}` : '' }
                    `


        if (parametros.__systemUserConnect && parametros.relatorio === 0)
        {
            if (parametros.__systemUserConnect.user_name !== '' && parametros.__systemUserConnect.user_name !== undefined) { 
                sql += ` and us.user_name = '${parametros.__systemUserConnect.user_name}'`
            }

            if (parametros.__systemUserConnect.user_credential !== '' 
                && parametros.__systemUserConnect.user_credential !== 'undefined'
                && parametros.__systemUserConnect.usuario_login_uuid !== ''
                && parametros.__systemUserConnect.usuario_login_uuid !== 'undefined') {
                    
                sql += ` and us.sis_us_seq = (select max(x.sis_us_seq) 
                                              from tbsistema_usuario_login x
                                              where 1 = 1 
                                                and x.usuario_login_uuid = '${parametros.__systemUserConnect.usuario_login_uuid}'
                                                and x.user_credential = '${parametros.__systemUserConnect.user_credential}')`
            }

            if (parametros.__systemUserConnect.sis_ac_cd !== '' && parametros.__systemUserConnect.sis_ac_cd !== undefined) {
                sql += ` and ac.sis_ac_cd = ${parametros.__systemUserConnect.sis_ac_cd}`
            }
            if (parametros.__systemUserConnect.sis_cd !== '' && parametros.__systemUserConnect.sis_cd !== undefined) {
                sql += ` and s.sis_cd_pk = ${parametros.__systemUserConnect.sis_cd}`
            }
        }




        return sql



        } catch (e) { 
            clsTools.PagErrorException(`reportPermissaolist`, 'sql', e);   
            return ''       
        }
    }
    static async get(parametros: any = {}) : Promise<any> {
        let list : any
        try {
            const myTools = new clsBase();
            list = await myTools.myDataBase.pag.DataGet(this.sql(parametros));
  
        } catch (e) {
            clsTools.PagErrorException(`M0001 - Sistema`, 'reportPermissaolist', e);
            throw new Error(`reportPermissaolist.get`)
        }
        finally {
            return list
        }
    }
    static async getModel(parametros: any = {}) : Promise<ModelUserPermissao[]> {
        let list : ModelUserPermissao[] = []
        try {
            const myTools = new clsBase();
            let data = await this.get(parametros)
            if (data && data.length > 0) {
                let item : ModelUserPermissao
                for (let i = 0; i < data.length; i++) {
                    item = new ModelUserPermissao()
                    item.binding(data[i])
                    list.push(item)
                }
            }
  
        } catch (e) {
            clsTools.PagErrorException(`M0001 - Sistema`, 'reportPermissaolist', e);
            throw new Error(`reportPermissaolist.getModel`)
        }
        finally {
            return list
        }   
    }

}