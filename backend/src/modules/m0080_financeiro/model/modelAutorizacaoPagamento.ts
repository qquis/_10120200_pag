import {Request, response, Response, Router} from 'express'

// class tools
import myTools from '../../../tools/Tools';
import { clsBase, clsTools } from '../../../model/modelbase'


// Class tbs
import tbAutorizacaoPagamento from "../tbs/TbAutorizacaoPagamento";
import tbautorizacaopagamento_abatimento from "../tbs/tbautorizacaopagamento_abatimento";

// Class scripts
import f0080_01_autorizacaopagamento_integ from '../scriptpg/f0080_01_autorizacaopagamento_integ'
import { ca, fi } from 'date-fns/locale';
import scriptSQLSelectAutorizacaoPgto from '../scriptpg/scriptSelectAutorizacaoPgto';


const myClsBase = new clsBase();
const modelAutorizacaoPagamentoRouter = Router()


modelAutorizacaoPagamentoRouter.get("/", async (req: Request, res: Response) => { 
    let item: modelAutorizacaoPagamento = new modelAutorizacaoPagamento()
    let itemResult : object = {}
    

    try {
        if (req.query) {
            if (req.query.autpgto_seq_pk) {
              
              itemResult =   await item.select({autpgto_seq_pk: req.query.autpgto_seq_pk})
            }
          }

    }
    catch (e) {
        clsTools.PagErrorException("M0080", "modelAutorizacaoPagamentoRouter", e)
    }
    finally {
      return res.send(itemResult)
    }

})


modelAutorizacaoPagamentoRouter.post("/", async (req: Request, res: Response) => { 
    let item: modelAutorizacaoPagamento = new modelAutorizacaoPagamento()
    let itemResult : object = {}
    

    try {
        if (req.query) {
            if (req.query.autpgto_seq_pk) {
              console.log("Parâmetros recebidos: ", req.query)
              await item.atualizarDadosPag(req.query)
              console.log("itemResult: ", itemResult)
            }
          }

    }
    catch (e) {
        clsTools.PagErrorException("M0080", "modelAutorizacaoPagamentoRouter", e)
    }
    finally {
      return res.send(itemResult)
    }

})



class modelAutorizacaoPagamento extends tbAutorizacaoPagamento {
    abatimentoList: tbautorizacaopagamento_abatimento[]
    constructor() {
        super();
        this.abatimentoList = []
    }

    async select(parametros: any) : Promise<object> { 

        //Por enquanto não retornaremos o próprio objeto, mas sim o resultado da consulta. Posteriomente
        //poderemos retornar o objeto já preenchido com os dados da consulta.

        let resultItem : object = {}
        try {
            const myTools = new clsBase();
            let result = await myTools.myDataBase.pag.DataGet(scriptSQLSelectAutorizacaoPgto.sql({autpgto_seq_pk: parametros.autpgto_seq_pk}, false));
            resultItem =  myTools.myDataBase.RecordItem(result,0)
            
        } catch (e) {
            clsTools.PagErrorException(`modelAutorizacaoPagamento`, 'consultar', e);
        } finally { 
          return resultItem
        }


    }

    async atualizarDadosPag(parametros: any) : Promise<void> {
      try { 



            console.log(parametros)

            if (!parametros.autpgto_seq_pk || parametros.autpgto_seq_pk == 0) {
              throw new Error("Parâmetros inválidos para vincular conta de pagamento.");
            }
              
            let sql = ` update tbautorizacaopagamento set dtlog_update = current_timestamp where autpgto_seq_pk = ${parametros.autpgto_seq_pk} ;`

            if (parametros.competencia_cd && parseInt(parametros.competencia_cd) !==0) { 
              console.log("Atualizando competência na autorização de pagamento: ", parametros.competencia_cd)
              sql += `  update tbautorizacaopagamento 
                            set competencia_cd = ${parametros.competencia_cd}
                            where autpgto_seq_pk = ${parametros.autpgto_seq_pk}    
                        ; `
            }
        
            await myClsBase.myDataBase.pag.Execute(sql)
            console.log("dados atualizados com sucesso.")

        } catch (e) {
          clsTools.PagErrorException(`modelAutorizacaoPagamento`, 'vincularContaPag', e);
      }
    
    }

    getSqlBlueSoftIntegrar() : string {
        let sql : string =  `select  ${f0080_01_autorizacaopagamento_integ.sqlScript_VERSION()}
        (   sqlcommand:= 'INTEG_API' 
          , vautpgto_seq_pk:= ${this.autpgto_seq_pk} 
          , vautpgto_cdpessoabluesoft:= ${this.autpgto_cdpessoabluesoft}
          , vautpgto_tipo:= '${this.autpgto_tipo}'
          , vautpgto_dataemissao:= '${myTools.format_Date_toStr_ShortDataBase(this?.autpgto_dataemissao)}'        
          , vautpgto_datavencimento:= '${myTools.format_Date_toStr_ShortDataBase(this.autpgto_datavencimento)}' 
          , vautpgto_dataquitacao:= '${myTools.format_Date_toStr_ShortDataBase(this.autpgto_dataquitacao)}' 
          , vautpgto_valorfatura:= ${this.autpgto_valorfatura}
          , vautpgto_valortotal:= ${this.autpgto_valortotal}
          , vautpgto_valorpago:= ${this.autpgto_valorpago}
          , vautpgto_nf_numero:= '${this.autpgto_nf_numero}'
          , vautpgto_valordescontofinanceiro:= ${this.autpgto_valorDescontoFinanceiro}  
          , vautpgto_numeroparcela:= ${this.autpgto_numeroparcela}   
          , vautpgto_datapagamento:= '${myTools.format_Date_toStr_ShortDataBase(this.autpgto_datapagamento)}' 
          , vautpgto_nf_dataemissao:= '${myTools.format_Date_toStr_ShortDataBase(this.autpgto_nf_dataemissao)}' 
          , vautpgto_valorliquido:= ${this.autpgto_valorliquido}   
          , vautpgto_datacriacao:= '${myTools.format_Date_toStr_ShortDataBase(this.autpgto_datacriacao)}' 
          , vautpgto_datacancelamento:= '${myTools.format_Date_toStr_ShortDataBase(this.autpgto_datacancelamento)}'
          , vautpgto_dtlog_update_redshift:= '${myTools.pagDateTime_getDateStringLong(this.__defaultDateNow)}'
          , vautpgto_status_bluesoft_cd:= 99
          , vdescritivo:= '${this.descritivo.length > 115? this.descritivo.substring(0,115): this.descritivo}'
          , vautpgto_cancelada:= ${this.autpgto_cancelada} 
          , vautpgto_codigobarra:= '${this.autpgto_codigobarra}'
          , vcompetencia_cd:= 202405 
          , vplc_conta_cd:= ${this.plc_conta_cd} 
          , vplc_conta_cd_destino:= ${this.plc_conta_cd_destino}  
          , vbordero_seq:= ${this.bordero_seq}   
          , vautpgto_juro_diario:= ${this.autpgto_juro_diario}   
          , vautpgto_valor_multa:= ${this.autpgto_valor_multa}   
          , vautpgto_valor_abatimento:= ${this.autpgto_valor_abatimento}   
          , vautpgto_valor_juros:= ${this.autpgto_valor_juros}   
          , vautpgto_valor_juros_fixo:= ${this.autpgto_valor_juros_fixo}   
          , vem_cdempresa:= ${this.em_cdempresa}  
          , vcontrato_bluesoft_seq:= ${this.contrato_bluesoft_seq}
          , vem_cdpessoabluesoft:= ${this.em_cdpessoabluesoft} 
          );` 

        if (this.abatimentoList.length > 0) {
            let sqlitemabatimento = `` 
            this.abatimentoList.forEach((abatimento: tbautorizacaopagamento_abatimento) => {
                sqlitemabatimento += `INSERT INTO tbautorizacaopagamento_abatimento (autpgto_seq_pk, autpgto_seq_pk_origem, autpgto_ab_valor)
                        SELECT ${abatimento.autpgto_seq_pk}, ${abatimento.autpgto_seq_pk_origem}, ${abatimento.autpgto_ab_valor}
                        WHERE NOT EXISTS (SELECT 1 FROM tbautorizacaopagamento_abatimento WHERE autpgto_seq_pk_origem = ${abatimento.autpgto_seq_pk_origem});
                        `
            });
            sql = sqlitemabatimento + sql;
            /*OBS 
              Incluir sempre os abatimentos primeiro para posteriormente o registro da duplicata em si, 
              já que no processamento da duplicata, iremos fazer a leitura dos possíveis abatimentos.
              
            */
          }
           
        return sql;
    }
    
    async bindingBlueSoftApi(item: any) {
        if (item != undefined) {
            this.em_cdpessoabluesoft = item.lojaKey != undefined? parseInt(`${item.lojaKey}`): 0
            this.autpgto_seq_pk = item.duplicataKey != undefined? parseInt(`${item.duplicataKey}`): 0
            this.autpgto_cdpessoabluesoft = parseInt( `${item.especie == "PAGAMENTO"? item.cedenteKey: item.sacadoKey}`)
            this.autpgto_tipo = item.especie == "PAGAMENTO"? "P": "R";
            this.descritivo = item.descritivo != "" ? `${item.descritivo}`.replace("'",""): ""
            this.autpgto_dataemissao = myTools._dataConvertStrtoDate(`${item.dataEmissao? item.dataEmissao : "01/01/1900"}`, `item.dataEmissao`) 
            this.autpgto_datavencimento = myTools._dataConvertStrtoDate(`${item.dataVencimento? item.dataVencimento : "01/01/1900"}`, `item.dataVencimento`) 
            //this.autpgto_dataquitacao = myTools.Date_br_timestamp(`${item.dataQuitacao? item.dataQuitacao : "01/01/1900"}`) 
            this.autpgto_valorfatura = parseFloat(`${item.valorNominal}`)
            this.autpgto_valortotal = 0;  
            this.autpgto_valorpago = parseFloat(`${item.valorPago}`)
            if (item.notaFiscal)
              this.autpgto_nf_numero = `${item.notaFiscal.numeroNfe? item.notaFiscal.numeroNfe: "0"}`
            this.autpgto_valorDescontoFinanceiro = parseFloat(`${item.valorDesconto}`)  
            this.autpgto_numeroparcela = parseInt(`${item.numeroParcelas}`)
            this.autpgto_datapagamento = myTools._dataConvertStrtoDate(`${item.autpgto_datapagamento? item.autpgto_datapagamento : "01/01/1900"}`) 
            this.autpgto_nf_dataemissao = myTools._dataConvertStrtoDate(`${item.dataEmissao? item.dataEmissao: "01/01/1900"}`);
  
            this.autpgto_valorliquido =  parseFloat(`${item.valorLiquido? item.valorLiquido: 0}`)
            this.autpgto_datacriacao = myTools._dataConvertStrtoDate(`${item.dataCriacao}`);   
            this.autpgto_datacancelamento = myTools._dataConvertStrtoDate(`${item.dataCancelamento? item.dataCancelamento : "01/01/1900"}`) 
            this.autpgto_DtLog_update_redshift = this.__defaultDateNow;   
            this.autpgto_status_cd = 0;
            this.autpgto_cancelada = item.dataCancelamento? 1: 0; 
            this.autpgto_codigobarra =  item.codigoBarras? item.codigoBarras: "";
            this.competencia_cd = 0; 
            this.plc_conta_cd = parseInt(`${item.contaContabilKey}`)
            this.plc_conta_cd_destino = 0;  
            this.bordero_seq = 0;  	                			
            this.autpgto_juro_diario = 0;  	        	
            this.autpgto_valor_multa = 0;  	        	
            this.autpgto_valor_abatimento = 0;       
            this.autpgto_valor_juros = 0;  		    
            this.autpgto_valor_juros_fixo = 0;  

            if (item.abatimentos) { 
              item.abatimentos.forEach((ab: any) => {
                const abatimento = new tbautorizacaopagamento_abatimento();
                abatimento.autpgto_seq_pk = item.duplicataKey; /*Numero da propria duplicata*/
                abatimento.autpgto_seq_pk_origem = ab.duplicataKey; /*Numero da duplicata original*/
                abatimento.autpgto_ab_valor = ab.valor;
                this.abatimentoList.push(abatimento);
              });
            }


          }

     }

}

export { modelAutorizacaoPagamento, modelAutorizacaoPagamentoRouter }