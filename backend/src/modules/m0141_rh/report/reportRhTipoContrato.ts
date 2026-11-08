import { clsBase } from '../../../model/modelbase';
import tbrh_tipo_contrato from "../tbs/tbth_tipo_contrato";
export default class reportRhTipoContrato  {

    static sql() : string  {
        const sql = `SELECT * FROM tbrh_tipo_contrato order by rh_tipo_contrato_descricao`;
        return sql 
    }

    static async get() : Promise<tbrh_tipo_contrato[]> {
        const list : tbrh_tipo_contrato[] = [];
        try {
            
            let myTools = new clsBase();

            let result = await myTools.myDataBase.pag.DataGet(this.sql());
            for await ( const[key, value] of Object.entries(result)) {
                const item = new tbrh_tipo_contrato
                await item.binding(value);
                list.push(item);
            }

            return list

        } catch (e) {
            throw new Error(`Error in setorOpercional: ${e}`);
        }
    }
}