const dir_file_name_resolve = require ('path')
const fs = require ('fs')
const {utcToZonedTime} = require('date-fns-tz')
const {format} = require('date-fns')
const addDays = require('date-fns/addDays')
require('dotenv/config')




function log_file(file, message)
{
    return new Promise ((resolve, reject) => {
       try {
        if (message !== '') {

            _data = new Date().toISOString(); 
            _dataformat = format(utcToZonedTime(_data, "America/Sao_Paulo"), "yyyy-MM-dd HH:mm:ss");

            messageLOG  = `${_dataformat} _ ${message}` + "\n"
            log_file_path = process.env.SERVICE_PAG_LOG_PATH;
            log_file_name = `${file}.txt` 

            let arquivo = dir_file_name_resolve.resolve(log_file_path, log_file_name)
            
            fs.appendFile(arquivo, messageLOG, (err) => {
                if (err)
                {
                    reject(new Error(`Não foi possível gravar o arquivo de Log: ${err}`))
                }
                resolve("Arquivo Processado")
            })

        }}
        catch(e)
        {
            console.log(e);
        }
    })

}

function pagGetDate(_data = "") { if (!_data) {_data = new Date().toISOString()} return _data}
function pagDateAddDays(_days = 1, _date = "")
{
    if (!_date) {
        _date = new Date();
        
    }
    return addDays(_date, _days) 
}

function pagDateTime_getDateStringLong(_data) { return format(utcToZonedTime(pagGetDate(_data), "America/Sao_Paulo"), "yyyy-MM-dd HH:mm:ss"); }
function pagDateTime_getDateStringShort(_data) { return format(utcToZonedTime(pagGetDate(_data), "America/Sao_Paulo"), "yyyy-MM-dd");}
function pagDateTime_getDateStringShortBr(_data) { return format(utcToZonedTime(pagGetDate(_data), "America/Sao_Paulo"), "dd-MM-yyyy");}
function pagDateTime_getTime(_data) { return format(utcToZonedTime(pagGetDate(_data), "America/Sao_Paulo"), "HH:mm:ss");}
function pagDateTime_getTimeSecond(_data) { return format(utcToZonedTime(pagGetDate(_data), "America/Sao_Paulo"), "ss");}

function pagEnv_getWHATS_FILE_SEND_PATH()
{
    return process.env.WHATS_FILE_SEND_PATH;
}

/*TESTE----------------------------------*/
//console.log(pagDateTime_getDateStringLong(pagDateAddDays(10)))

module.exports = {      log_file
                    ,   pagDateTime_getDateStringLong
                    ,   pagDateTime_getDateStringShort
                    ,   pagDateTime_getDateStringShortBr
                    ,   pagDateTime_getTime
                    ,   pagDateTime_getTimeSecond
                    ,   pagDateAddDays
                    ,   pagEnv_getWHATS_FILE_SEND_PATH
                
                
                }