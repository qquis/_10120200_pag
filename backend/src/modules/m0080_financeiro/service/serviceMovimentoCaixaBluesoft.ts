import myTools from "../../../tools/Tools";
import { clsBase, clsTools } from "../../../model/modelbase";
import { modelmovimento_caixa_bluesoft } from "../model/modelmovimento_caixa_bluesoft";
import modelsistema_nucleo_procedimento from "../../../modules/m9030_sistema_batch/model/modelsistema_nucleo_procedimento";
import redshift_movimento_caixa_bluesoft from '../scriptpg/redhisft_select_movimento_caixa_bluesoft'


const myClsBase = new clsBase();

export default class serviceMovimentoCaixaBluesoftImportar {



    public static async start(nucleo_procedimento: modelsistema_nucleo_procedimento) : Promise<object> {
        
        if (!nucleo_procedimento.__atualizado)
            nucleo_procedimento.consultar();
        //await nucleo_procedimento.iniciarExecucao()
        
        let listMovimentoCaixaBluesoft: modelmovimento_caixa_bluesoft[] = []
        try {
            
            let dataInicial = await nucleo_procedimento.dataInicial();
            let dataFinal = await nucleo_procedimento.dataFinal();
            
            /*SELECIONANDO REGISTROS PENDENTES*/    
            let result = await myClsBase.myDataBase.redshift.DataGet(redshift_movimento_caixa_bluesoft.get({dataInicial: dataInicial, dataFinal: dataFinal}));

            //--------------------------------------------------

            let scriptsql = `` 
            let i = 0
            let intContador = 0;
            let intTootalExecute = 100;


            for (const [key, value] of Object.entries(result)) {
                let registroMovimentoCaixaBluesoft : modelmovimento_caixa_bluesoft  = new modelmovimento_caixa_bluesoft();
                registroMovimentoCaixaBluesoft.binding(value)
                listMovimentoCaixaBluesoft.push(registroMovimentoCaixaBluesoft)
                scriptsql += registroMovimentoCaixaBluesoft.integSql_get();
                
                if (intContador >= intTootalExecute || intContador === result.length - 1) {
                    await myClsBase.myDataBase.pag.Execute(scriptsql)
                    scriptsql = ``;
                    intContador = 0;
                }
                intContador++;
                i++;

            }
            

            return listMovimentoCaixaBluesoft
        }
        catch (e) {
            clsTools.PagErrorException(`M0080`, `ServiceFinanceiro | Atualizar`, e)
            nucleo_procedimento.ErrorMessage = `Error: ${e}`;
        }

        finally {
            //await nucleo_procedimento.finalizarExecucao()
            return listMovimentoCaixaBluesoft;

        }
    } 



}


