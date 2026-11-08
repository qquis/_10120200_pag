
import pagN2011001 from "./console/pagN2011001"

const argsProcessService = process.argv.slice(1)


const backConsole = async (ExecucaoNumero: string) => {
    if (ExecucaoNumero == "2011001") await pagN2011001.execute()
}

backConsole(argsProcessService[1])
    .then((result) => {console.log("Executado com sucesso")})
    .catch((error) => {console.log(error); process.exit(1)}) 
    .finally(() => {console.log("Execução finalizada"); process.exit(1)})
    



