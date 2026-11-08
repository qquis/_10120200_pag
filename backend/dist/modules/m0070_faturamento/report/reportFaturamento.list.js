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
class reportFaturamentoList {
    static sql(parametro) {
        let sql = ``;
        sql += `	
           select       c.seqfaturamento_uuid
                    ,   c.faturamento_controle_seq
                    ,   c.fat_controle_tipo_cd
                    ,   t.fat_controle_tipo_descricao
                    ,   c.dataemissao
                    ,   c.datafaturamento
                    ,   c.numeropedido_fv
                    ,   c.numeropedido
                    ,   c.sat_ecf
                    ,   c.cupomfiscal
                    ,   cv.cdparticipante as cdparticipante_vendedor
                    ,   cv.cdpessoabluesoft as cdpessoabluesoft_vendedor
                    ,   cv.nome_razao as vendedor_nome_razao
                    ,   cl.cdparticipante as cdparticipante_cliente
                    ,   cl.cdpessoabluesoft as cdpessoabluesoft_cliente
                    ,   cl.nome_razao as cliente_nome_razao
                    ,   cl.cdgrupoeconomico as cdgrupoeconomico_cliente
                    ,   g.descricao as descricaogrupoeconomico
                    ,   nf.df_valor_total
                    ,   nf.df_nf_tipo
                    ,   tn.df_nf_tipo_descricao `;
        if (parametro.tipo_view === 'RESUMO_POR_FABRICANTE') {
            sql += `	,   ff.cdparticipante
                    ,   ff.cdpessoabluesoft
                    ,   coalesce(ff.nome_razao, '') as fabricante_nome_razao
                `;
        }
        sql += `
                    ,   sum(i.valortotalfaturamentobase) as valorfaturamentobase
                    ,   sum(i.valortotalsubsidioscorrentes) as subsidioscorrentes
                    ,   sum(i.valortotalfaturamento) as valorfaturamento
                    ,   sum(i.valortotaldescontofinanceiro) as valortotaldescontofinanceiro
                    ,   sum(i.valortotalfaturamentobruto) as valorfaturamentobruto
                    ,   sum(i.valortotalsubsidiosaplicados) as valortotalsubsidiosaplicados
                    ,   sum(i.valortotalfaturamentoliquido) as valortotalfaturamentoliquido

            from    tbfaturamento_controle c
            inner join tbfaturamento_controle_tipo t on t.fat_controle_tipo_cd = c.fat_controle_tipo_cd
            inner join tbfaturamento        f on f.faturamento_controle_seq = c.faturamento_controle_seq
            inner join tbfaturamentoorigem  o on o.seqfaturamento = f.seqfaturamento
            inner join tbfaturamentoitens    i on i.seqfaturamentoorigem = o.seqfaturamentoorigem
            inner join tbproduto pr on pr.pr_cdproduto = i.pr_cdproduto
            inner join tbprodutobluesoft     pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
            left join  tbparticipante_bluesoft ff on ff.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fabricante

            left join  tbparticipante_bluesoft       cl on cl.cdparticipante = f.cdparticipantecliente
            left join  tbgrupoeconomico     g on g.cdgrupoeconomico = cl.cdgrupoeconomico
         
            left join  tbparticipante_bluesoft       cv on cv.cdparticipante = f.cdparticipantevendedor
         
            left join  tbdocumentofiscal    nf on nf.df_nf_seq_blue = c.df_nf_seq_blue
            left join  tbdocumentofiscal_tipo tn on tn.df_nf_tipo = nf.df_nf_tipo
            where 1 = 1
        `;
        if (parametro.faturamento_controle_seq && parseInt(parametro.faturamento_controle_seq) > 0) {
            sql += ` and c.faturamento_controle_seq = ${parametro.faturamento_controle_seq}`;
        }
        if (parametro.statusfaturamentoFiltrar && parametro.statusfaturamentoFiltrar == 1) {
            sql += ` and f.statusfaturamento = ${parametro.statusfaturamentoFiltrar}`;
        }
        if (parametro.op_cdoperacao) {
            sql += ` and c.op_cdoperacao = ${parametro.op_cdoperacao}`;
        }
        if (parametro.numeropedido && parseInt(parametro.numeropedido) > 0) {
            sql += ` and c.numeropedido = ${parametro.numeropedido}`;
        }
        if (parametro.datafaturamento_ini) {
            sql += ` and f.datafaturamento >= '${parametro.datafaturamento_ini}'`;
        }
        if (parametro.datafaturamento_fim) {
            sql += ` and f.datafaturamento <= '${parametro.datafaturamento_fim}'`;
        }
        sql += ` group by c.seqfaturamento_uuid
                    ,   c.faturamento_controle_seq
                    ,   c.fat_controle_tipo_cd
                    ,   t.fat_controle_tipo_descricao
                    ,   c.dataemissao
                    ,   c.datafaturamento
                    ,   c.numeropedido_fv
                    ,   c.numeropedido
                    ,   c.sat_ecf
                    ,   c.cupomfiscal
                    ,   cv.cdparticipante 
                    ,   cv.cdpessoabluesoft 
                    ,   cv.nome_razao 
                    ,   cl.cdparticipante 
                    ,   cl.cdpessoabluesoft 
                    ,   cl.nome_razao
                    ,   cl.cdgrupoeconomico     
                    ,   g.descricao     
                    ,   nf.df_valor_total
                    ,   nf.df_nf_tipo
                    ,   tn.df_nf_tipo_descricao`;
        if (parametro.tipo_view === 'RESUMO_POR_FABRICANTE') {
            sql += `,   coalesce(ff.nome_razao, '') 
                    ,   ff.cdparticipante
                    ,   ff.cdpessoabluesoft
            
            `;
        }
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                result = yield new modelbase_1.clsBase().myDataBase.pag.DataGet(this.sql(filter));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportFaturamentoStatus | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportFaturamentoList;
