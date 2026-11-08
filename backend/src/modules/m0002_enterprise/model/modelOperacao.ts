import TbOperacao from "../tbs/tboperacao";

export default class modelOperacao extends TbOperacao {
 
    em_descricao: string

     constructor() {
        super();
        this.em_descricao = ''
    }   


    async binding(item: any): Promise<void> {
        if (item) {
            super.binding(item);
            this.em_descricao = item?.em_descricao
        }
    }
}