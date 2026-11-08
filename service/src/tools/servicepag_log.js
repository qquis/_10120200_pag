require('dotenv/config')
const pjson = require('../../package.json')
const _resource = require('../../../_resource/js/index')
const Tools = require('../../../tools')

const dir_file_name_resolve = require ('path')
const fs = require ('fs')
const {dateFormat_yymmdd_hhmmss} = require ('./dateFormat')


function service_pag_log(message)
{
    return new Promise ((resolve, reject) => {
        try {
             //Tools.pagConsoleLog_service(pjson.name, `${pjson.name}_${pjson.version} _ ${message}`)
             console.log(message)
             resolve(Tools.pagConsoleLog_service(`${message}`))
    }
    catch(e)
    {
        console.log(`Erro ${e}`);
        reject((new Error(`Não foi possível gravar o arquivo de log ${e}`)))
    }
    
    /*if (message !== '') {
            message = `${process.env.PAG_VERSION}_${dateFormat_yymmdd_hhmmss(Date())} - ${process.env.SERVICE_PAG_LOG_REF}  ${message}` + "\n"
            log_file_path = process.env.SERVICE_PAG_LOG_PATH
            log_file_name = process.env.SERVICE_PAG_LOG_FILE_NAME
            let arquivo = dir_file_name_resolve.resolve(log_file_path, log_file_name)
            fs.appendFile(arquivo, message, (err) => {
                if (err)
                {
                    reject(new Error(`Não foi possível gravar o arquivo de Log: ${err}`))
                }
                resolve("Arquivo Processado")
            })

        }*/
    })

}

module.exports = service_pag_log