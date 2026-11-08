import 'dotenv/config'
const {log_file, pagDateTime_getDateStringShort} = require('../../../_resource/js/index')

const Tools = require('../../../tools')

const pjson = require('../../package.json')

class myTools extends Tools {

    static async pagConsolex(message : string, consolelog : boolean = false) {
        await super.pagConsoleLog_backend(message, consolelog)        
    }
}



function pagConsole(message: string) 
{

    
    return new Promise ((resolve, reject) => {
        if (message !== '') {
            Tools.pagConsoleLog(message, true)
        }
    })

}

function Tools_Date_toShortDataSelect(_data?: Date): string 
{
    return pagDateTime_getDateStringShort(_data);
}

export {myTools, pagConsole as Tools_Log, Tools_Date_toShortDataSelect as Tools_pagDateTime_getDateStringShort}

  