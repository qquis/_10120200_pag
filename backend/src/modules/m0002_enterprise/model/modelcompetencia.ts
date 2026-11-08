import tbcompetencia from "../tbs/tbcompetencia";

export default class modelcompetencia extends tbcompetencia {
 
    constructor() {
        super();
    }

    async binding(item: any): Promise<void> {
        if (item) {
            super.binding(item);
        }
    }
}