import 'dotenv/config'
import express, { response } from 'express';
import cors from 'cors';
import routes from './routes/router';
import myTools from "./tools/Tools"
//import myTools from '@myTool/Tools'

//import DataBase from './database/DataBase';
import serviceSistema from './modules/m0001_sistema/service/serviceSistema';

//import servicePatch from './modules/m9030_sistema_batch/service/service_sistema_batch';

const port: number = parseInt(`${process.env.SERVER_API_PORT}`)
const packgeJoson = require('../package.json')

//const myDataBase : DataBase = new DataBase()
//const myservicePatch : servicePatch = new servicePatch();



    try {
        const app = express();

        // Configurar CORS
        /*const corsOptions = {
            origin: 'http://localhost:3000', // Substitua pela origem que deseja permitir
            optionsSuccessStatus: 200 // Para compatibilidade com navegadores mais antigos
        };*/
    
        app.use(cors())

        app.use(express.json());



        app.use("/", routes);
        app.listen(port);
        if (process.env.ENVIRONMENT == "DES") {
            console.log(``)
            console.log(``)
            console.log(``)
        }

        myTools.pagConsole(`Pag BackEnd - Start`, true, true)
        myTools.pagConsole(`------------------------------------------------`, true, true)
        myTools.pagConsole(`Enviroment........................: ${process.env.ENVIRONMENT}`, true, true)
        myTools.pagConsole(`Mirror............................: ${process.env.BACKEND_MIRROR}`, true, true)
        myTools.pagConsole(`Tocken Persist....................: ${process.env.HEADER_TOCKEN_PERSIST}`, true, true)
        myTools.pagConsole(`Running in port...................: ${port}`, true, true)
        myTools.pagConsole(`Version...........................: ${packgeJoson.version}`, true, true)
        myTools.pagConsole(`Utiliza Base ZANTHUS SQL SERVER...: ${myTools.myENV().BASE_ZANTHUS_SQL.toString()}`, true, true)
        myTools.pagConsole(`------------------------------------------------`, true, true)
        myTools.pagConsole(`Data Hora ${new Date().toLocaleString('pt-BR')}`, true, true)

        serviceSistema.BackendStart.defaultStartBackEnd(`${process.env.ENVIRONMENT}`, `${process.env.BACKEND_MIRROR}`)
            .catch((e) => 
                { throw new Error(`Erro ao iniciar o sistema ${e}`) })

    } catch (e) {
        console.error(`Error BackEnd start ${e}`)
        process.exit(1)               
    }


