const Tools = require ("../../../../tools")
const html_mail = require('../mail/Html/HtmlMail')

const NF1100045001_PRECO_ALTERADO = async function (notificacao) {

    let list = JSON.parse(notificacao.notificacao_send_message.notificacao_send_message);
    let listaITENS = `` 
    await list.map(async i => {
        listaITENS += 
        `<tr> 
            <td style="text-align: left;"> ${i.user_name} </td>
            <td style="text-align: left;" > ${i.proc_tipo_descricao} </td>
            <td style="text-align: right;"> ${Tools.pagDateTime_getDateStringShortBrBarra(i.dataaplicacaoprevista)} </td>
            <td style="text-align: right;"> ${i.pr_cdproduto} </td>
            <td style="text-align: left;" > ${i.pr_descricao} </td>
            <td style="text-align: right;"> ${i.prb_cdprodutobluesoft} </td>
            <td style="text-align: left;">${i.prb_embalagemestoque} </td>        
            <td style="text-align: right;"> ${i.prc_valor} </td>      
            <td style="text-align: right;"> ${i.prc_qtde_promocional} </td>                      
        </tr> `

    })

    return html_mail(notificacao,`
    <div align="left">Olá! Segue relatório de Preços alterados hoje, até o momento </div>
    <div align="left"> </div>    
    <table border="1" cellpadding="0" cellspacing="0" class="image_block block-1" role="presentation" style="mso-table-lspace: 0pt; mso-table-rspace: 0pt;" width="100%">
        <thread> 
            <tr>
                <th style="text-align: left;">Usuário </th>
                <th style="text-align: left;">Tipo de Alteração</th>
                <th style="text-align: left;">Data Aplicação</th> 
                <th style="text-align: left;">Produto</th>
                <th style="text-align: left;">Descrição</th>
                <th style="text-align: left;">Cd (Filho)</th>
                <th style="text-align: left;">Emb</th>
                <th style="text-align: left;">Valor</th>
                <th style="text-align: left;">Qtde Prom</th>
            </tr>
        </thread>
        <tbody>
            ${listaITENS}
            
        </tbody>
    </table>
    
    `)
}


module.exports = NF1100045001_PRECO_ALTERADO

/*
${  (
                DADOS.map(async item => {

                    `<tr> 
                        <td> ${item.prb_cdprodutobluesoft} </td>
                        <td> ${item.prb_descricao} </td>
                    </tr> `
                })  
            */