"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class reportForcaVendaMetaFabricanteResultadoVendedor {
    static sql(filter) {
        let sql = `	select 	fv_fab_meta_cd
	,	case seqinterface
			when 0 then 'DADOS OXAN'
			when 1 then 'DADOS JOHNSON'
			end
	,   p.nome_razao 
            ,	x.cdparticipantevendedor 
    
	,	sum(case when fv_fab_meta_mix_cd = 2 then qtde_positivacao else 0 end ) as MIX02
	,	sum(case when fv_fab_meta_mix_cd = 7 then qtde_positivacao else 0 end ) as MIX07	
	,	sum(case when fv_fab_meta_mix_cd = 17 then qtde_positivacao else 0 end ) as MIX17		
	,	sum(case when fv_fab_meta_mix_cd = 17 then qtde_positivacao else 0 end ) as MIX28			

from   tbforca_venda_fab_meta_res_vendedor x
left join tbparticipante_bluesoft p on p.cdparticipante = x.cdparticipantevendedor
`;
        if (filter.fv_fab_meta_cd) {
            sql += ` where x.fv_fab_meta_cd = ${filter.fv_fab_meta_cd} `;
        }
        if (filter.seqinterface !== undefined) {
            sql += ` and x.seqinterface = ${filter.seqinterface} `;
        }
        sql += `
        group by x.fv_fab_meta_cd
            ,	p.nome_razao 
            ,	case x.seqinterface
                    when 0 then 'DADOS OXAN'
                    when 1 then 'DADOS JOHNSON'
                    end
            ,	x.cdparticipantevendedor 
        order by 1,2,3

        `;
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                result = yield new modelbase_1.clsBase().myDataBase.pag.DataGet(this.sql(filter));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportForcaVendaMetaFabricante | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportForcaVendaMetaFabricanteResultadoVendedor;
