import bluesoftapi from "..";
import blueSoftApiPrecoPadrao from "./blueSoftApiPrecoPadrao";
import blueSoftApiPrecoPromocional from "./blueSoftApiPrecoPromocional";

export default class bluesoftApiPreco  {
    apiPrecoPadrao : blueSoftApiPrecoPadrao 
    apiPrecoPromocional: blueSoftApiPrecoPromocional 
    constructor() {
        this.apiPrecoPadrao = new blueSoftApiPrecoPadrao();
        this.apiPrecoPromocional = new blueSoftApiPrecoPromocional();
        
    }
}