import { clsBase } from '../../../model/modelbase';
import tbrh_setor_operacional from "../tbs/tbrh_setor_operacional";
export default class reportRhSetorOpercional  {

    static sql() : string  {
        const sql = `SELECT * FROM tbrh_setor_operacional `;
        return sql 
    }

    static async get() : Promise<tbrh_setor_operacional[]> {
        const list : tbrh_setor_operacional[] = [];
        try {
            
            let myTools = new clsBase();

            let result = await myTools.myDataBase.pag.DataGet(reportRhSetorOpercional.sql());
            for await ( const[key, value] of Object.entries(result)) {
                const item = new tbrh_setor_operacional();
                await item.binding(value);
                list.push(item);
            }

            return list

        } catch (e) {
            throw new Error(`Error in setorOpercional: ${e}`);
        }
    }
}