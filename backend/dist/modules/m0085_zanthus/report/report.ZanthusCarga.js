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
class reportZanthusCarga {
    static sql(parametro) {
        let sql = `
                select  c.carga_uuid 
                    ,   c.carga_tipo_cd
                    ,   t.carga_tipo_descricao
                    ,   c.carga_seq 
                    ,   c.carga_data 
                    ,   c.carga_status_cd
                    ,   s.carga_status_descricao
                    ,   c.carga_hora_ini 
                    ,   c.carga_hora_fim 
                    ,   p.nome_razao as usuario_nome_razao
                    ,   cp.qtd_unitario
                    ,   cp.qtd_bluesoft
                    ,   cp.qtd_mercadoria
                from        tbzanthus_carga c
                inner join  tbzanthus_carga_tipo t on t.carga_tipo_cd = c.carga_tipo_cd
                inner join  tbzanthus_carga_status s on s.carga_status_cd = c.carga_status_cd 
                left join   ( select    carga_uuid
                                    ,   count(distinct (prb_cdprodutobluesoftunitario)) as qtd_unitario
                                    ,   count(distinct (prb_cdprodutobluesoft)) as qtd_bluesoft
                                    ,   count(distinct (cod_mercadoria)) as qtd_mercadoria
                              from    tbzanthus_carga_produto
                              group by carga_uuid
                ) cp on cp.carga_uuid = c.carga_uuid
                left join tbsistema_usuario u on u.sis_us_seq = c.carga_usr_seq_create
                left join tbparticipante p on p.cdpessoabluesoft = u.cdpessoabluesoft
                where 1 = 1

        `;
        if (parametro.carga_uuid && parametro.carga_uuid != '') {
            sql += ` and c.carga_uuid = '${parametro.carga_uuid}' `;
        }
        if (parametro.data_carga_ini && parametro.data_carga_ini != '') {
            sql += ` and c.carga_data >= '${parametro.data_carga_ini}' `;
        }
        if (parametro.data_carga_fim && parametro.data_carga_fim != '') {
            sql += ` and c.carga_data <= '${parametro.data_carga_fim}' `;
        }
        return sql;
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let report = {};
            try {
                let myBase = new modelbase_1.clsBase();
                report = yield myBase.myDataBase.pag.DataGet(this.sql(parametro));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('reportZanthusCarga', 'get', e);
            }
            finally {
                return report;
            }
        });
    }
}
exports.default = reportZanthusCarga;
