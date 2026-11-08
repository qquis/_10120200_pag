
type f0001_01_parametros = {
        venvironment?: string
        vbackend_mirror?: string
}

export default class f0001_01_sistema_backend_start {
        public static sqlScript_VERSION(): string {return `f0001_01_1012014_sistema_backend_start`}
        public static get(parametros : f0001_01_parametros): string {
                let sql =  `SELECT ` +  this.sqlScript_VERSION() + 
                        `(         venvironment:= '${parametros.venvironment}'
                                ,  vbackend_mirror:= '${parametros.vbackend_mirror ? parametros.vbackend_mirror : '0'}'
                        )
                       `
                return sql 
        }
}