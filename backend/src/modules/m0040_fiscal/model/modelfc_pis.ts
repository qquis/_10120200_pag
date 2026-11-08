import { clsBase, clsTools } from "../../../model/modelbase";
import tbfc_pis from "../tbs/tbfc_pis";



export default class modelfc_pis extends tbfc_pis {

    
    constructor() { 
        super();

    }

    script_insert(): string { 

        let sql = ``;
        
        if (this.pis_cd > 0) {
            sql = `insert into tbfc_pis 
            (
                    pis_cd 			
                ,   cst
                ,   pis_descricao 		
                ,   pisAliquota 		
                ,   pisReducao 	
                ,   cofinsrelacionado	
                ,   tipo_entrada
            )
                SELECT   ${this.pis_cd}
                        ,  ${this.cst}
                        ,  '${this.pis_descricao}'
                        ,  ${this.pisAliquota}
                        ,  ${this.pisReducao}
                        ,  ${this.cofinsRelacionado}
                        ,  ${this.tipo_entrada}

                
                WHERE NOT EXISTS (SELECT 1 FROM tbfc_pis WHERE pis_cd = ${this.pis_cd})
                ;

                UPDATE tbfc_pis
                SET   cst = ${this.cst}
                    , pisAliquota = ${this.pisAliquota}
                    , pisReducao = ${this.pisReducao}
                    , pis_descricao = '${this.pis_descricao}'
                    , cofinsRelacionado = ${this.cofinsRelacionado} 
                    , dtlog_update = current_timestamp
                    , tipo_entrada = ${this.tipo_entrada}
                WHERE pis_cd = ${this.pis_cd}
                ;

                `
        }
        return sql;
    }

    bindingApiBluesoft_urlFiscalPis(item: any) {
        if (item) { 
            this.pis_cd = item.codigo? item.codigo: 0 
            this.pis_descricao = item.descricao? item.descricao: ''
            this.cst = item.cst? item.cst: 0
            this.pisAliquota = item.aliquota && item.aliquota != undefined ? item.aliquota: 0
            this.cofinsRelacionado = item.cofinsRelacionado? item.cofinsRelacionado: 0

        }


    }


}