

import { clsBase, clsTools } from "../../../../model/modelbase";



//Operações com os cupons zanthus
import reportCRMSorteioConsultarCupom from "../../report/ReportCRMSorteio/reportCRMSorteioConsultarCupom";
import modelcrm_sorteio_cupom from "../../model/modelcrm_sorteio_cupom";




type itemSorteioExterno = { 
    idorigem : number;
    doc_num: string 
    loja: number;
    cupom: number
    data_hora: string
    data: string
    fidelidade: number
    tipo_venda: number
    valor: number
}


type apiSorteioExterno = { 
    akey: string;
    data: itemSorteioExterno[];
}

export default class serviceCrmSorteioExportar { 

    static async start(parametro: any) : Promise<void> { 
            const LOGFILENAME = `.export_sorteio_${parametro.data_emissao? parametro.data_emissao :"ERRO_DATA_NAO_INFORMADA.log"}`;
        try { 

            const modeldb = new clsBase();



            let listCupons : modelcrm_sorteio_cupom[] = [];
            listCupons = await reportCRMSorteioConsultarCupom.get({
                status_envio_sorteio: 0,
                data_emissao: parametro.data_emissao ? parametro.data_emissao : '',
                crm_so_cupom_seq: parametro.crm_so_cupom_seq ? parametro.crm_so_cupom_seq : 0
            });

            if (   listCupons.length == 0) { 
                clsTools.pagConsole("Nenhum cupom pendente para envio ao sistema externo de sorteio.");
                return;
            }

            let myLIST_itemSorteioExterno: itemSorteioExterno[] = [];
            let i : number = 0;
            let icontrolInsertMax : number = 200;
            let icontrolTotalBloco : number = listCupons.length / icontrolInsertMax;
            let icontrolBloco: number= 1



            for await (const itemCupom of listCupons) {
                
                myLIST_itemSorteioExterno.push(this.mapearPropriedades(itemCupom));

                clsTools.pagConsoleFile(`${clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ Exportação SORTEIO EXTERNO SEQ ${itemCupom.crm_so_cupom_seq} _ CP ${itemCupom.numero_cupom} _ CPF ${itemCupom.cpf_cnpj}`, LOGFILENAME );
               
                if (i >= icontrolInsertMax) {
                    await this.ProcessarEnvio(myLIST_itemSorteioExterno, LOGFILENAME);
                    myLIST_itemSorteioExterno = []
                    icontrolBloco++;
                    i = 0;
                }
                i++
            }

            if (myLIST_itemSorteioExterno.length > 0) {
                await this.ProcessarEnvio(myLIST_itemSorteioExterno, LOGFILENAME);
            }

        } catch (error) {
            clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioAtualizarBase - start", error);
            throw error;
        }
        finally {
            clsTools.pagConsole("Finalizando processo de exportação de cupons para sistema externo de sorteio.");
            clsTools.pagConsoleFile(`${clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ PROCESSO FINALIZADO`, LOGFILENAME );
        }
    }

    static mapearPropriedades(itemCupom: modelcrm_sorteio_cupom) : itemSorteioExterno {
                
            let itemSorteioExterno : itemSorteioExterno = { 
                    idorigem: itemCupom.crm_so_cupom_seq,
                    doc_num: itemCupom.cpf_cnpj ? itemCupom.cpf_cnpj.substring(itemCupom.cpf_cnpj.length - 11) : '',
                    loja: 1,
                    cupom: itemCupom.numero_cupom ? itemCupom.numero_cupom : 0,
                    data_hora: clsTools._datemomentDateToStr(itemCupom.data_emissao_hora ? itemCupom.data_emissao_hora : new Date(), 'YYYY-MM-DD HH:mm:ss'),
                    data: clsTools._datemomentDateToStr(itemCupom.data_emissao ? itemCupom.data_emissao : new Date(), 'YYYY-MM-DD'),
                    fidelidade: 0,
                    tipo_venda: 1,
                    valor: itemCupom.valor ? itemCupom.valor : 0
                }


                return itemSorteioExterno;
    }

    static async ProcessarEnvio(myLIST_itemSorteioExterno: itemSorteioExterno[], LOGFILENAME: string) : Promise<[]> {
        

        let NaoProcessados : [] = [];

        try { 

            clsTools.pagConsoleFile(`${clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ ACESSANDO API`, LOGFILENAME );
            let apiSorteioExterno_envio : apiSorteioExterno = { 
            akey: "55bf55e11f060db80f2dd4ea885f1ce8592eb4edaf896dbe71e4cc6cf5ff044c",
                        data: myLIST_itemSorteioExterno
            }

            



            let myBase : clsBase = new clsBase();
            let result = await myBase.sorteioExternoApi.sorteioExternoApi_post("/api-services/sales", apiSorteioExterno_envio)
           
            if (result.data.extra) { 

                clsTools.pagConsoleFile(`${clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ NÚMERO NÃO PROCESSADOS: ${result.data.extra.length}`, LOGFILENAME );

                NaoProcessados = result.data.extra;
                clsTools.pagConsoleFile(`${clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ Exportação SORTEIO EXTERNO - Não processados: ${JSON.stringify(NaoProcessados)}`, LOGFILENAME );
            } else { 
                clsTools.pagConsoleFile(`${clsTools._datemomentDateToStr(new Date(), 'YYYY-MM-DD HH:mm:ss')} _ TODOS OS CUPONS FORAM PROCESSADOS COM SUCESSO. NÃO FOI ENCONTRADO O REGISTRO EXTRA`, LOGFILENAME );
            }


        
            await this.RegistrarLogEnvio( myLIST_itemSorteioExterno,NaoProcessados);




        } catch (error) {
            clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioExportar - ProcessarEnvio", error);
            throw error;
   
        } finally {
            console.log("Envio API - Finalizando [Não Processados", NaoProcessados);
            return NaoProcessados;
        }
    }

    static async RegistrarLogEnvio(myLIST_itemSorteioExterno: itemSorteioExterno[], NaoProcessados : [])  { 
        try {

                console.log("Iniciando registro de log de envio...");
                
                let iCountUpdateMax : number = 200;
                let iCount: number = 0;
                let sql = ``;
                for await (const item of myLIST_itemSorteioExterno) {

                    let statusNaoProcessado = NaoProcessados.find((x: any) => x == item.idorigem);
                    
                    sql += `update tbcrm_sorteio_cupom 
                            set crm_so_externo_enviado = ${(statusNaoProcessado) ? 9 : 1}
                        ,   crm_so_externo_enviado_data = current_timestamp
                        where crm_so_cupom_seq = ${item.idorigem} ;

                    `
                    if (iCount >= iCountUpdateMax) {
                        iCount = 0;
                        await this.updateCupomExternoEnviado(sql);
                        sql = ``;
                    }
                    iCount++;
                }
                /*Execucao dos itens restantes*/
                if (sql != ``) {
                    await this.updateCupomExternoEnviado(sql);
                }

                

            } catch (error) {
                clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioExportar - RegistrarLogEnvio", error);
                throw error;
            }
    }

    static async updateCupomExternoEnviado(sql: string) : Promise<void> {
        try {
            const modeldb = new clsBase();
            await modeldb.myDataBase.pag.Execute(sql)

        }   catch (error) {
            clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioExportar - updateCupomExternoEnviado", error);
            throw error;
        }
    }

}