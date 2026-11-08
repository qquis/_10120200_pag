import { clsTools, clsBase } from "../../../model/modelbase";



export default class reportExternalZanthusTabFinalizadora { 

    static sql (parametro: any) : string { 

        let sql = ``
        try { 

        
        sql = `
                    SELECT 
                        cod_cliente
                        , des_cliente
                        , des_fantasia
                        , num_cgc
                        , flg_empresa
                        , flg_enviar_carga
                        , loja_cadastro
                        , status_cliente
                        , origem_cadastro
                        , flg_fidelidade
                        , senha_pdv
                        , situacao_cadastro
                        , flg_habilitado_compra
                        , flg_revenda
                        , des_endereco
                        , id_municipio
                        , numero
                        , des_bairro
                        , compl_endereco
                        , cod_pais
                        , des_cidade
                        , num_cep
                        , des_sigla
                        , num_insc_est
                        , dta_alteracao 
                        , dta_cadastro
                    FROM tab_cliente
                    WHERE 1 = 1
            `

            if (parametro.cod_cliente && parametro.cod_cliente !== "0") {
                sql += ` AND cod_cliente = ${parametro.cod_cliente} `
            }

            if (parametro.des_cliente) {
                sql += ` AND des_cliente LIKE '%${parametro.des_cliente}%' `
            }

            if (parametro.filtrar_data_alteracao && parametro.filtrar_data_alteracao == "1") {
                if (parametro.data_alteracao_ini) {
                    sql += ` AND dta_alteracao >= '${parametro.data_alteracao_ini}' `
                }
                if (parametro.data_alteracao_fim) {
                    sql += ` AND dta_alteracao <= '${parametro.data_alteracao_fim}' `
                }
            }
            
            if (parametro.filtrar_data_cadastro && parametro.filtrar_data_cadastro == "1") {
                if (parametro.data_cadastro_ini) {
                    sql += ` AND dta_cadastro >= '${parametro.data_cadastro_ini}' `
                }
                if (parametro.data_cadastro_fim) {
                    sql += ` AND dta_cadastro <= '${parametro.data_cadastro_fim}' `
                }
            }

       

        } catch(e) {
            
            clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusTabFinalizadora - sql", e)
        } finally {

            return sql 
        }
    }

    static async get(parametro: any) : Promise<any[]> {
        let mylist : any = []
        try { 
          
            let myBase = new clsBase()
            mylist = await myBase.myDataBase.zanthusPostgre.DataGet( this.sql(parametro) )
        } 
         catch(e) { 
            await clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusTabFinalizadora - get", e)
        } finally { 
            return mylist
        }
    }

    

}