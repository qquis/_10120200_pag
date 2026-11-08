import { clsBase, clsTools } from "../../../model/modelbase";
import tbfc_icms  from "../tbs/tbfc_icms";



export default class modelfc_icms extends tbfc_icms {

    
    constructor() { 
        super();

    }

    script_insert(): string { 

        let sql = ``;
        
        if (this.icms_cd > 0) {
            sql = `insert into tbfc_icms 
            (
                    icms_cd 			
                ,   icms_descricao 	
                ,   codigoOrigem 		
                ,   codigoTributacao 		
                ,   sigla 		
                ,   aliquota 		
                ,   reducao 		
                ,   porcentagemDiferimento 		
            )
                SELECT   ${this.icms_cd}
                        , '${this.icms_descricao}'
                        ,  ${this.codigoOrigem}
                        ,  ${this.codigoTributacao}
                        , '${this.sigla}'
                        ,  ${this.aliquota}
                        ,  ${this.reducao}
                        ,  ${this.porcentagemDiferimento}
                
                WHERE NOT EXISTS (SELECT 1 FROM tbfc_icms WHERE icms_cd = ${this.icms_cd})
                ;

                UPDATE tbfc_icms
                SET   icms_descricao = '${this.icms_descricao}'
                    , codigoOrigem = ${this.codigoOrigem}
                    , codigoTributacao = ${this.codigoTributacao}
                    , sigla = '${this.sigla}'
                    , aliquota = ${this.aliquota}
                    , reducao = ${this.reducao}
                    , porcentagemDiferimento = ${this.porcentagemDiferimento}
                    , dtlog_update = current_timestamp
                WHERE icms_cd = ${this.icms_cd}
                ;

                `
        }
        return sql;
    }

    bindingApiBluesoft(item: any) {
        if (item) { 
            this.icms_cd = item.codigo? item.codigo: 0 
            this.codigoOrigem = item.codigoOrigem? item.codigoOrigem: 0
            this.codigoTributacao = item.codigoTributacao? item.codigoTributacao: 0
            this.icms_descricao = item.descricao? clsTools.stringToDabase(item.descricao) : 'SEM DESCRICAO';
            this.sigla = item.sigla? clsTools.stringToDabase(item.sigla) : 'SEM SIGLA';
            this.aliquota = item.aliquota? item.aliquota : 0;
            this.reducao = item.reducao? item.reducao : 0;
            this.porcentagemDiferimento = item.porcentagemDiferimento? item.porcentagemDiferimento : 0;


        }


    }


}