

import { clsBase, clsTools } from "../../../../model/modelbase";


//Temporada ativa de Sorteio 
import modelcrm_sorteio_temporada from "../../model/modelcrm_soterio_temporada";
import reportCRMSorteioTemporada from "../../report/ReportCRMSorteio/reportCRMSorteioTemporada";

//Operações com os cupons zanthus
import reportZanthusCupom from "../../../../modules/m0055_faturamento_zanthus/report/reportZanthusCupom";
import modelzanthus_cupom from "../../../../modules/m0055_faturamento_zanthus/model/modelzanthus_cupom";
import modelcrm_sorteio_cupom from "../../model/modelcrm_sorteio_cupom";

//Scripts

const modeldb = new clsBase();

export default class serviceCrmSorteioAtualizarBase { 




    static async start(parametro: any = null) : Promise<void> { 
        try { 

            /*Processa as vendas do E-COMMERCE*/

 


            clsTools.pagConsole(`Atualizando base de sorteiors | Cupons`);
            let iTemporadaAtiva : modelcrm_sorteio_temporada = new modelcrm_sorteio_temporada();
            iTemporadaAtiva = await reportCRMSorteioTemporada.getTemporadaAtiva();


            clsTools.pagConsole(`Atualizando base de sorteiors | E-commerce`);
            await this.importEcommerceDataBaseBlueSoft(iTemporadaAtiva);      


            let lresultZanthusCupom : modelzanthus_cupom[] = [];


            if (parametro.data_emissao && parametro.data_emissao != '') {
                
                
                let data_parametro : Date = clsTools._datemomentDatStrToDate(parametro.data_emissao, "YYYY-MM-DD");




                lresultZanthusCupom = await reportZanthusCupom.get({
                    filtrar_data_cupom : 1,
                    data_cupom_ini : data_parametro,
                    data_cupom_fim : data_parametro, 
                    filtrar_valor : 1, 
                    valor_inicial : iTemporadaAtiva.crm_so_temp_valor_minimo, 
                    valor_final : 100000,
                    status_cancelado: 0
                });
                
            }

            else { 
                lresultZanthusCupom = await reportZanthusCupom.get({
                    filtrar_data_cupom : 1,
                    data_cupom_ini : iTemporadaAtiva.crm_so_temp_data_ini,
                    data_cupom_fim : iTemporadaAtiva.crm_so_temp_data_fim, 
                    filtrar_valor : 1, 
                    valor_inicial : iTemporadaAtiva.crm_so_temp_valor_minimo, 
                    valor_final : 100000,
                    status_cancelado: 0
                });

            }


            let numeroTotalCuponsZanthus : number = lresultZanthusCupom.length;
            let numerodeBlocos : number = Math.ceil(numeroTotalCuponsZanthus / 200);
            let numeroblocoo : number = 0;

            let icontrolInsert : number = 0;
            let icontrolInsertMax : number = 200;
            let icontrolInsertSQL: string = ``;
            
            for await (const itemZanthusCupom of lresultZanthusCupom) {

                let imodelcrm_sorteio_cupom : modelcrm_sorteio_cupom = new modelcrm_sorteio_cupom();
                

                icontrolInsertSQL += imodelcrm_sorteio_cupom.script_insert_cupom_zanthus(iTemporadaAtiva.crm_so_temp_cd, iTemporadaAtiva.crm_so_temp_valor_minimo, itemZanthusCupom);

                
                if (icontrolInsert >= icontrolInsertMax) {
                    await modeldb.myDataBase.pag.Execute(icontrolInsertSQL);
                    icontrolInsertSQL = ``;
                    icontrolInsert = 0;
                    numeroblocoo += 1;
                }
                icontrolInsert += 1;

            }

            if (icontrolInsertSQL != ``) {
                await modeldb.myDataBase.pag.Execute(icontrolInsertSQL);
                icontrolInsertSQL = ``;
                icontrolInsert = 0;
            }

            clsTools.pagConsole(`Atualização da base de sorteios realizada! NUmero de registros a processar ${lresultZanthusCupom.length}`);


        } catch (error) {
            clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioAtualizarBase - start", error);
            throw error;
        }
    }

    static async importEcommerceDataBaseBlueSoft(iTemporadaAtiva: any) : Promise<void> { 
        try { 
            let scriptSQL : string = `insert into tbcrm_sorteio_cupom
                                        (
                                                crm_so_temp_cd
                                            ,	numero_cupom 
                                            ,	numero_pedido 
                                            ,	data_emissao 
                                            ,	data_emissao_hora 
                                            ,	sat_ecf 
                                            ,	nf_numero
                                            ,	nf_data_emissao 
                                            ,	nf_chave
                                            , 	valor
                                            , 	cpf_cnpj 
                                        )
                                    select 	${iTemporadaAtiva.crm_so_temp_cd} as crm_so_temp_cd
                                        ,	nf.numeropedido as numero_cupom
                                        ,	nf.numeropedido as numero_pedido
                                        ,	nf.data_emissao as data_emissao
                                        ,	cast(nf.data_emissao || ' 08:01:01' as timestamp) as data_emissao_hora
                                        ,	99 as sat_ecf
                                        ,	df.df_nf_numero as nf_numero  
                                        ,	nf.data_faturamento as nf_data_emissao 
                                        ,	df.df_chave  as nf_chave
                                        ,  	nf.valor_faturamento as valor
                                        ,	ps.cpf_cnpj as cpf_cnpj 

                                    from 		tbfaturamento_bluesoft nf
                                    inner join 	tbpessoabluesoft ps on ps.cdpessoabluesoft = nf.cdpessoabluesoft_cliente
                                    inner join  tbdocumentofiscal df on df.df_nf_seq_blue = nf.df_nf_seq_blue 
                                    where op_cdoperacao = 4
                                    and data_faturamento >= '${clsTools._datemomentDateToStr(iTemporadaAtiva.crm_so_temp_data_ini, 'YYYY-MM-DD')}'
                                    and valor_faturamento >= ${iTemporadaAtiva.crm_so_temp_valor_minimo}
                                    and not exists (select 1
                                                    from tbcrm_sorteio_cupom x 
                                                    where x.numero_pedido = nf.numeropedido
                                                    and x.sat_ecf = 99 
                                                )	
                                    ;                

                                    `

                await modeldb.myDataBase.pag.Execute(scriptSQL);

        } catch (error) {
            clsTools.PagErrorException("M0090_CRM", "serviceCrmSorteioAtualizarBase - importEcommerceDataBaseBlueSoft", error);
            throw error;
        }
    }

}