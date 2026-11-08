import { clsTools, clsBase} from '../../../model/modelbase'
import tbsistemanucleoprocedimento from '../tbs/tbsistemanucleoprocedimento'

export default class modelSistemaRelational { 
    static async limiteRegBloqUpdateGet(sis_nucleo_prc_cd : number) : Promise<number> {
        let sql : string = tbsistemanucleoprocedimento.sqlSelectLimiteRegBloqUpdate(sis_nucleo_prc_cd)
        let myclsBase = new clsBase()

        let result = await myclsBase.myDataBase.pag.DataGet(sql)
        if (result && result.length > 0) { 
            return result[0].limite_reg_bloq_update
        } else { 
            return 0
        }
    }
}