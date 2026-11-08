const Tools = require ("../../../../tools")
const html_mail = require('../mail/Html/HtmlMail')

const NF1000000009_GENERICO = async function (notificacao) {

    

    return html_mail(notificacao,`
    <div align="left">Olá </div>
    <div align="left"> 
        <h1> ${notificacao.notificacao_send_message.notificacao_send_message} </h1>
    </div>    
    
    `)
}


module.exports = NF1000000009_GENERICO

/*
${  (
                DADOS.map(async item => {

                    `<tr> 
                        <td> ${item.prb_cdprodutobluesoft} </td>
                        <td> ${item.prb_descricao} </td>
                    </tr> `
                })  
            */