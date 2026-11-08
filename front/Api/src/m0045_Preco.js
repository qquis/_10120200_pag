const Tools = require ("../../../tools/index")
const {ApiGet, ApiPost} = require("../src/Api/pag")

class m0045_preco {
    
    url_bluesoftintegrarprodutospendentes () {
        return '/preco/cmd/bluesoftintegrarprodutospendentes'
    }

    url_bluesoftintegrarprodutosall () {
        return `bluesoftintegrarprodutosall`
    }

     constructor() { }

    async bluesoftintegrarprodutospendentes () {
        try {
        const dados = await ApiPost(`${this.url_bluesoftintegrarprodutospendentes()}`, null)
        const list = dados.data
        return list
        } catch (e) {
            throw Error(e)
        }
    }
    async bluesoftintegrarprodutosall () {
        try {
        const dados = await ApiPost(`${this.url_bluesoftintegrarprodutosall()}`, null)
        const list = dados.data
        return list
        } catch (e) {
            throw Error(e)
        }
    }
   
}

module.exports = m0045_preco;
