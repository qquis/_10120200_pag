import TbEmpresa from "../tbs/tbempresa";

export default class modelEmpresa extends TbEmpresa {
 
    constructor() {
        super();
    }

    async binding(item: any): Promise<void> {
        if (item) {
            super.binding(item);
        }
    }
}