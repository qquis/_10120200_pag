import { clsBase, clsTools } from "../../../model/modelbase";
import f0040_05_fiscal_mapeamento from "../script/F0040_05_fiscal_mapeamento";
const myBase = new clsBase();

export default class serviceFiscal_AtualizaMapeamentoFiscal { 
    static async start() : Promise<void> { 
        try  { 

            await myBase.myDataBase.pag.Execute(f0040_05_fiscal_mapeamento.defaultExecution());

        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Figura', e);
        }
        finally {
            clsTools.pagConsole('M0040_FISCAL',true, false);
        }
    }
}