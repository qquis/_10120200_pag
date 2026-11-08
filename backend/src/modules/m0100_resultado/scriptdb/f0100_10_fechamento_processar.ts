import { clsBase, clsTools } from "../../../model/modelbase";

/*f0100_10_1012011_fechamento_processar*/
export default class f0100_10_fechamento_processar {
        public static sqlScript_VERSION(): string {return `f0100_10_1012013_fechamento_processar`}
        public static post(parametros: any) : string { 
            let sql : string = '';
            try { 
                if (!parametros || !parametros.competencia_cd) {
                    throw new Error("Parâmetros inválidos: 'competencia_cd' é obrigatório.");   
                }

                sql =  `SELECT * FROM ${f0100_10_fechamento_processar.sqlScript_VERSION()}
                        (
                                vcompetencia_cd:= ${parametros.competencia_cd}
                        
                        )`
            } catch (e) {
                clsTools.PagErrorException('f0100_10_fechamento_processar', 'get', e);
            } finally {
                return sql;
            }
        }

}