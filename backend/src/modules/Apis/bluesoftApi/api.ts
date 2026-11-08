import blueSoftApiPreco from "./preco/blueSoftApiPreco";
import blueSoftApiProduto from "./produto/blueSoftApiProduto";

export default class bluesoftApi {
    produto : blueSoftApiProduto 
    preco : blueSoftApiPreco
    constructor() {
        this.produto = new blueSoftApiProduto();
        this.preco = new blueSoftApiPreco();
        
        
    }
}