"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class modelfc_Complemento {
    getStringCBSfromNFCE(item) {
        let sql = ``;
        if (item.cbs_cd == 0) {
            sql = `insert into tbfc_cbs
                        (
                                    cbs_cd      					
                                ,	cbs_descricao					
                                ,	cbs_descricao_abreviada			
            
                        )
                                SELECT  ${item.cbs_cd}  
                                ,       '${item.cbs_descricao}'
                                ,       '${item.cbs_descricao_abreviada}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_cbs WHERE cbs_cd = ${item.cbs_cd} );
                        ;
                        update tbfc_cbs
                        set 
                                    cbs_descricao = '${item.cbs_descricao}'					
                                ,	cbs_descricao_abreviada = '${item.cbs_descricao_abreviada}'			
                        where cbs_cd = ${item.cbs_cd};
            `;
        }
        return sql;
    }
    getStringIBSfromNFCE(item) {
        let sql = ``;
        if (item.ibs_cd == 0) {
            sql = `insert into tbfc_ibs
                        (
                                    ibs_cd      					
                                ,	ibs_descricao					
                                ,	ibs_descricao_abreviada			
            
                        )
                                SELECT  ${item.ibs_cd}  
                                ,       '${item.ibs_descricao}'
                                ,       '${item.ibs_descricao_abreviada}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_ibs WHERE ibs_cd = ${item.ibs_cd} );
                        ;
                        update tbfc_ibs
                        set 
                                    ibs_descricao = '${item.ibs_descricao}'					
                                ,	ibs_descricao_abreviada = '${item.ibs_descricao_abreviada}'			
                        where ibs_cd = ${item.ibs_cd};
            `;
        }
        return sql;
    }
}
exports.default = modelfc_Complemento;
