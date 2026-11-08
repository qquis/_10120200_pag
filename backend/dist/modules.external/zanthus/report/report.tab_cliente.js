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
class reportExternalZanthusTabFinalizadora {
    static sql(parametro) {
        let sql = ``;
        try {
            sql = `
                    SELECT 
                        cod_cliente
                        , des_cliente
                        , des_fantasia
                        , num_cgc
                        , flg_empresa
                        , flg_enviar_carga
                        , loja_cadastro
                        , status_cliente
                        , origem_cadastro
                        , flg_fidelidade
                        , senha_pdv
                        , situacao_cadastro
                        , flg_habilitado_compra
                        , flg_revenda
                        , des_endereco
                        , id_municipio
                        , numero
                        , des_bairro
                        , compl_endereco
                        , cod_pais
                        , des_cidade
                        , num_cep
                        , des_sigla
                        , num_insc_est
                        , dta_alteracao 
                        , dta_cadastro
                    FROM tab_cliente
                    WHERE 1 = 1
            `;
            if (parametro.cod_cliente && parametro.cod_cliente !== "0") {
                sql += ` AND cod_cliente = ${parametro.cod_cliente} `;
            }
            if (parametro.des_cliente) {
                sql += ` AND des_cliente LIKE '%${parametro.des_cliente}%' `;
            }
            if (parametro.filtrar_data_alteracao && parametro.filtrar_data_alteracao == "1") {
                if (parametro.data_alteracao_ini) {
                    sql += ` AND dta_alteracao >= '${parametro.data_alteracao_ini}' `;
                }
                if (parametro.data_alteracao_fim) {
                    sql += ` AND dta_alteracao <= '${parametro.data_alteracao_fim}' `;
                }
            }
            if (parametro.filtrar_data_cadastro && parametro.filtrar_data_cadastro == "1") {
                if (parametro.data_cadastro_ini) {
                    sql += ` AND dta_cadastro >= '${parametro.data_cadastro_ini}' `;
                }
                if (parametro.data_cadastro_fim) {
                    sql += ` AND dta_cadastro <= '${parametro.data_cadastro_fim}' `;
                }
            }
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusTabFinalizadora - sql", e);
        }
        finally {
            return sql;
        }
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let mylist = [];
            try {
                let myBase = new modelbase_1.clsBase();
                mylist = yield myBase.myDataBase.zanthusPostgre.DataGet(this.sql(parametro));
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("External.Zanthus", "reportExternalZanthusTabFinalizadora - get", e);
            }
            finally {
                return mylist;
            }
        });
    }
}
exports.default = reportExternalZanthusTabFinalizadora;
