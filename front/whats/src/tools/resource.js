require ('dotenv/config')
const pjson = require('../../package.json')
const _resource = require('../../../../_resource/js/index')
const info_log = function (message)
{
    try {
            _resource.log_file(pjson.name, `${pjson.name}_${pjson.version} _ ${message}`)
    }
    catch(e)
    {
        console.log(e);
    }
}

const info_log_console = function (message)
{
    try {
        info_log(message)
        console.log(message)

    } catch (e) {
        console.log(e)
    }
}

module.exports =  {info_log, info_log_console}