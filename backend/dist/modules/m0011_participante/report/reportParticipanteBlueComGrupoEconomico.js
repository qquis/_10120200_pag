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
class reportParticipanteBlueComGrupoEconomico {
    static sql(par) {
        const creditoStatusCd = par.bluesoftcliente_creditostatus_cd === undefined || par.bluesoftcliente_creditostatus_cd === ''
            ? undefined
            : Number(par.bluesoftcliente_creditostatus_cd);
        if (creditoStatusCd !== undefined && (!Number.isInteger(creditoStatusCd) || creditoStatusCd < 1)) {
            throw new Error('Invalid bluesoftcliente_creditostatus_cd filter');
        }
        let sql = `
        				WITH parametros AS (
							SELECT DATE '2026-09-30' AS data_referencia
						),
						faturamento_3_meses AS (
							SELECT
								f.cdparticipantecliente,

								SUM(
									CASE
										WHEN f.datafaturamento >= DATE_TRUNC(
											'month',
											p.data_referencia - INTERVAL '2 months'
										)
										AND f.datafaturamento < DATE_TRUNC(
											'month',
											p.data_referencia - INTERVAL '1 month'
										)
										THEN i.valortotalfaturamento
										ELSE 0
									END
								) AS mes01,

								SUM(
									CASE
										WHEN f.datafaturamento >= DATE_TRUNC(
											'month',
											p.data_referencia - INTERVAL '1 month'
										)
										AND f.datafaturamento < DATE_TRUNC(
											'month',
											p.data_referencia
										)
										THEN i.valortotalfaturamento
										ELSE 0
									END
								) AS mes02,

								SUM(
									CASE
										WHEN f.datafaturamento >= DATE_TRUNC(
											'month',
											p.data_referencia
										)
										AND f.datafaturamento < DATE_TRUNC(
											'month',
											p.data_referencia + INTERVAL '1 month'
										)
										THEN i.valortotalfaturamento
										ELSE 0
									END
								) AS mes03

							FROM tbfaturamento f
							INNER JOIN tbfaturamentoorigem o
								ON o.seqfaturamento = f.seqfaturamento
							INNER JOIN tbfaturamentoitens i
								ON i.seqfaturamentoorigem = o.seqfaturamentoorigem
							CROSS JOIN parametros p
							WHERE f.datafaturamento >= DATE_TRUNC(
								'month',
								p.data_referencia - INTERVAL '2 months'
							)
							AND f.datafaturamento < DATE_TRUNC(
								'month',
								p.data_referencia + INTERVAL '1 month'
							)
							AND f.statusfaturamento = 1
							AND i.statusfaturamentoitem = 1
							AND f.op_cdoperacao = 1
							AND f.em_cdempresa = 1
							GROUP BY
								f.cdparticipantecliente
						)
						SELECT
							b.cdparticipante,
							b.cdpessoabluesoft,
							b.cpf_cnpj,
							b.pessoajuridica,
							b.bluesoft_pessoa_data_cadastro,
							b.bluesoft_pessoa_status,
							b.nome_razao,
							b.nome_abreviado,
							b.bluesoftclientestatus,
							b.bluesoftcliente_creditostatus_cd,
							b.cdgrupoeconomico,
							ge.descricao,
							b.cdpessoabluesoft_vendedor,
							pv.nome_razao AS nome_vendedor,
							coalesce(fp.forma_pgto_descricao, 'NAO DEFINIDA') as forma_pgto_descricao,
							sc.bluesoftcliente_creditostatus_descricao,
							COALESCE(m.mes01, 0) AS mes01,
							COALESCE(m.mes02, 0) AS mes02,
							COALESCE(m.mes03, 0) AS mes03

						FROM tbparticipante_bluesoft b
						INNER JOIN tbgrupoeconomico ge ON ge.cdgrupoeconomico = b.cdgrupoeconomico
						INNER JOIN tbparticipante   pv ON pv.cdpessoabluesoft = b.cdpessoabluesoft_vendedor AND b.cdpessoabluesoft_vendedor > 0
						LEFT JOIN faturamento_3_meses m ON m.cdparticipantecliente = b.cdparticipante
						LEFT JOIN tbforma_pgto_bluesoft fp ON fp.forma_pgto_cd = ge.forma_pgto_cd_padrao
						LEFT JOIN tbpessoabluesoft_status_credito sc on sc.bluesoftcliente_creditostatus_cd = b.bluesoftcliente_creditostatus_cd
						WHERE 1 = 1
			${par.cdparticipante ? `and b.cdparticipante = ${par.cdparticipante}` : ''}
			${par.cpf_cnpj ? `and LPAD(b.cpf_cnpj,14,'0') = LPAD(${par.cpf_cnpj},14,'0')` : ''}
			${par.nome_razao ? `and UPPER(b.nome_razao) like UPPER('%${par.nome_razao}%')` : ''}
			${par.bluesoftcliente_creditostatus_cd !== undefined ? `and b.bluesoftcliente_creditostatus_cd = ${par.bluesoftcliente_creditostatus_cd}` : ''}


            `;
        if (par.cdparticipante_vendedor && par.cdparticipante_vendedor > 0) {
            sql += ` and pv.cdparticipante = ${par.cdparticipante_vendedor}`;
        }
        if (par.forma_pgto_cd_grupo_economico_padrao && par.forma_pgto_cd_grupo_economico_padrao !== 0) {
            sql += ` and ge.forma_pgto_cd_padrao = ${par.forma_pgto_cd_grupo_economico_padrao}`;
        }
        return sql;
    }
    static get(par) {
        return __awaiter(this, void 0, void 0, function* () {
            //let myBase = new clsBase()
            try {
                let result = yield modelbase_1.clsTools.PagDataBaseGet(this.sql(par));
                return result;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('reportParticipanteBlueComGrupoEconomico', 'get', e);
                throw new Error('Error in reportParticipanteBlueComGrupoEconomico.get');
            }
        });
    }
}
exports.default = reportParticipanteBlueComGrupoEconomico;
