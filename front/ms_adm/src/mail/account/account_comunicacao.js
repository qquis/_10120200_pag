const nodemalier = require('nodemailer'); 

//https://myaccount.google.com/apppasswords
const mail_comunicacao = nodemalier.createTransport({
    service: 'gmail', 
    host: 'smtp.gmail.com',
    port: 465,
    secure: true,    
    auth : {
        user: 'comunicacao@oxan.com.br', 
        pass: "okqa jsjl pwzz ylqz"
    }

})


module.exports = mail_comunicacao;