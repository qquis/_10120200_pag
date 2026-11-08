import { clsTools, clsBase} from '../../../model/modelbase'

export default class reportParticipanteRhList { 

    public static sql(par: any) : string {
        let sql = `select 
                        t.cdparticipante
                    , 	t.rh_funcionario_cd
                    ,	t.data_admissao 
                    ,	t.data_rescisao
                    ,	t.rh_status
                    ,	t.rh_setor_operacional_cd 
                    ,	t.rh_tipo_contrato_cd
                    from tbparticipante_rh t
                    where 1 = 1
                    and   t.cdparticipante = ${par.cdparticipante}
                    `


            return sql;
    }

    public static async get(par: any) : Promise<any> {
        let myBase = new clsBase()
        try {
            let result = await myBase.myDataBase.pag.DataGet(this.sql(par)) 
            return result
        } catch (e) {
            clsTools.PagErrorException('reportParticipanteRhList', 'get', e)
            throw new Error('Error in reportParticipanteRhList.get')
        }

    } 
}

