import { clsTools, clsBase} from '../../../model/modelbase';
export default class reportResultadoGruopoList{
    static sql (parametros: any = {}) : string 
    { 
        let sql = `
                        select  g.r_grupo_cd
                        ,       g.r_grupo_descricao
                        ,       coalesce(g.r_grupo_origem_blue,0) as r_grupo_origem_blue
                        from    tbresultado_grupo g
                        order by g.r_grupo_descricao 
                `
        return sql

    }
    static async get(parametros: any = {}, sql : string = ``) : Promise<any> {
        const myTools = new clsBase();
        try {
                let result = await myTools.myDataBase.pag.DataGet(sql || this.sql(parametros));
                    return result
                
        } catch (e) {
            clsTools.PagErrorException(`reportDREOperacaoList`, 'sql', e);
        }
    }

}