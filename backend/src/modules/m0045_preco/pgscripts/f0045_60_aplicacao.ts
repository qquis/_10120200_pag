

export default class f0045_60_aplicacao {
    public static sqlScript_VERSION(): string {return `f0045_60_1012020_produto_preco_aplicacao`}
    public static SELECT(filter: any = null) : string {
        let sqlscript = `Select * from ${this.sqlScript_VERSION()} ()`;
         return sqlscript;
    }
}


