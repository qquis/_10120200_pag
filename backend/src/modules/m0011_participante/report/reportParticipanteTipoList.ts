import { clsTools, clsBase } from "../../../model/modelbase";



export default class reportParticipanteTipoList { 

    public static sql(par: any) : string {
        let sql = `SELECT 	participante_tipo_cd 
						,	participante_tipo_descricao 
					FROM 	TBPARTICIPANTE_TIPO
					ORDER BY participante_tipo_descricao asc
            `


            return sql;
    }

    public static async get(par: any) : Promise<any> {
        let myBase = new clsBase()
        try {
            let result = await myBase.myDataBase.pag.DataGet(this.sql(par)) 
            return result
        } catch (e) {
            clsTools.PagErrorException('reportParticipanteTipoList', 'get', e)
            throw new Error('Error in reportParticipanteTipoList.get')
        }

    } 
}

