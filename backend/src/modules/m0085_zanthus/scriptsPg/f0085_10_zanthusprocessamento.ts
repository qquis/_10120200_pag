
export default class f0085_10_zanthusprocessamento {
    public static sqlScript_VERSION(): string {return `f0085_10_1012014_zanthusprocessamento`}
    public static ScriptExecute() : string {
                let sqlscript = `Select ${this.sqlScript_VERSION()}() `;
         return sqlscript;
    }
}


