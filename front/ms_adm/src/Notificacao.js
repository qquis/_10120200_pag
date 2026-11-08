const NF1100045001_PRECO_ALTERADO = require('./Nfs/NF1100045001_PRECO_ALTERADO')
const NF1000000009_GENERICO = require('./Nfs/NF1000000009_GENERICO')

const notificacao = async function (notificacao) { 
    
    let bodyMAIL = `` 

    try  {
        switch(notificacao.notificacao_cd) { 
            case 1100045001: 
                bodyMAIL = await NF1100045001_PRECO_ALTERADO(notificacao)
                break;
            case 1000000009: 
                bodyMAIL = await NF1000000009_GENERICO(notificacao)
                break;                
            default: 
                bodyMAIL = await NF1000000009_GENERICO(notificacao)
                break;
        }

    } catch (e) { 
        console.log(`Erro ${e}`)
    } finally {
        return bodyMAIL;
    }   

}

module.exports = notificacao