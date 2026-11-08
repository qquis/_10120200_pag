import {modelTb} from '../../../model/model'
import { clsBase, clsTools } from '../../../model/modelbase'


export default 
  class tbAutorizacaoPagamento extends modelTb {
      em_cdempresa: number
      autpgto_seq_pk: number 
      autpgto_cdpessoabluesoft : number 
      autpgto_tipo: string  
      descritivo: string  
      autpgto_dataemissao: Date 
      autpgto_datavencimento: Date 
      autpgto_dataquitacao: Date 
      autpgto_valorfatura: number 
      autpgto_valortotal: number  
      autpgto_valorpago: number  
      autpgto_nf_numero: string  
      autpgto_valorDescontoFinanceiro: number  
      autpgto_numeroparcela: number  
      autpgto_datapagamento: Date 
      autpgto_nf_dataemissao: Date  
      autpgto_valorliquido: number 
      autpgto_datacriacao: Date   
      autpgto_datacancelamento: Date   
      autpgto_DtLog_update_redshift: Date   
      autpgto_status_cd: number
      autpgto_cancelada: number 
      autpgto_codigobarra: string 
      competencia_cd: number 
      plc_conta_cd: number 
      plc_conta_cd_destino: number  
      bordero_seq: number  	                			
      autpgto_juro_diario: number  	        	
      autpgto_valor_multa: number  	        	
      autpgto_valor_abatimento: number       
      autpgto_valor_juros: number  		    
      autpgto_valor_juros_fixo: number       
      contrato_bluesoft_seq: number
      em_cdpessoabluesoft: number 
      constructor() {
        super()

        this.em_cdempresa = 0
        this.autpgto_seq_pk= 0
        this.autpgto_cdpessoabluesoft= 0
        this.autpgto_tipo = "R"
        this.descritivo = ""
        this.autpgto_dataemissao = this.__defaultDateNow;
        this.autpgto_datavencimento = clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_dataquitacao = clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_valorfatura = 0; 
        this.autpgto_valortotal = 0;  
        this.autpgto_valorpago = 0;  
        this.autpgto_nf_numero = `0`;  
        this.autpgto_valorDescontoFinanceiro = 0;  
        this.autpgto_numeroparcela = 0;  
        this.autpgto_datapagamento = clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_nf_dataemissao = clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_valorliquido = 0; 
        this.autpgto_datacriacao = clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_datacancelamento = clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_DtLog_update_redshift = clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        this.autpgto_status_cd = 0;
        this.autpgto_cancelada = 0; 
        this.autpgto_codigobarra =  ""
        this.competencia_cd = 0; 
        this.plc_conta_cd = 0; 
        this.plc_conta_cd_destino = 0;  
        this.bordero_seq = 0;  	                			
        this.autpgto_juro_diario = 0;  	        	
        this.autpgto_valor_multa = 0;  	        	
        this.autpgto_valor_abatimento = 0;       
        this.autpgto_valor_juros = 0;  		    
        this.autpgto_valor_juros_fixo = 0;       
        this.contrato_bluesoft_seq = 0;
        this.em_cdpessoabluesoft = 0; 
      }





}


