
const {Pool} = require ('pg');
require('dotenv/config')
const service_pag_log = require('../tools/servicepag_log')

const Tools = require('../tools/Tools')


const pool = new Pool({
    host: process.env.SERVER_POSTGRESQL_HOST,
    user: process.env.SERVER_POSTGRESQL_USER,
    database: process.env.SERVER_POSTGRESQL_DATABASE,
    password: process.env.SERVER_POSTGRESQL_PWD,
    port: process.env.SERVER_POSTGRESQL_PORT,
    CommandTimeout: 5000
})


const postgre_pool = async function(script_sql){
    const SQLCOMMAND = script_sql
    try{
        await pool.query(script_sql)
    }
    catch (e)
    {
        Tools.pagConsoleLog(`POSTGRE.JS | Erro pool.query: ${e} \n Script SQL: ${script_sql.substring(0,60)}`, true)
    }
}

module.exports = postgre_pool 



