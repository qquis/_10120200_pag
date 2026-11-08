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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const tbfaturamento_controle_1 = __importDefault(require("../tbs/tbfaturamento_controle"));
/*scripts*/
const pg_f0070_23_faturamentoitem_processar_1 = __importDefault(require("../scriptdb/pg.f0070_23_faturamentoitem_processar"));
const pg_f0070_24_faturamentoitem_rateiocomplemento_1 = __importDefault(require("../scriptdb/pg.f0070_24_faturamentoitem_rateiocomplemento"));
const pg_f0070_26_faturamento_recusa_processar_1 = __importDefault(require("../scriptdb/pg.f0070_26_faturamento_recusa_processar"));
/*
    Testar nova solução de model, sendo seus métodos estaticos
*/
class model_faturamento_controle {
    constructor() {
        this.FaturamentoPorFabricante = [];
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let dados = {};
            dados.controle = yield this.faturamentoControleConsultar(parametro);
            dados.itens = yield this.faturamentoItensConsultar(parametro);
            return dados;
        });
    }
    static faturamentoControleBindingGet(item) {
        let result = new tbfaturamento_controle_1.default();
        result.binding(item);
        return result;
    }
    static faturamentoItensConsultar(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myDatBase = new modelbase_1.clsBase();
                let result = yield myDatBase.myDataBase.pag.DataGet(this._sqlconsultarItens(parametro));
                return Array.isArray(result) ? result : [];
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole("Erro ao consultar itens de faturamento");
                return [];
            }
        });
    }
    static faturamentoControleConsultar(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myDatBase = new modelbase_1.clsBase();
                let result = myDatBase.myDataBase.RecordItem(yield myDatBase.myDataBase.pag.DataGet(this._sqlConsultarControle(parametro)), 0);
                return result;
            }
            catch (error) {
                console.log(error);
                throw error;
            }
        });
    }
    static sqlProcessarFaturamentoPorControle(item) {
        let sql = ` `;
        sql += pg_f0070_23_faturamentoitem_processar_1.default.get(item);
        if (item.op_cdoperacao == 4) {
            sql += pg_f0070_24_faturamentoitem_rateiocomplemento_1.default.get(item);
        }
        if (item.fat_controle_tipo_cd == 2) {
            sql += pg_f0070_26_faturamento_recusa_processar_1.default.get(item);
        }
        sql += " update tbfaturamento_controle set processamento_pendente = 0 where faturamento_controle_seq = " + item.faturamento_controle_seq + "; ";
        return sql;
    }
    static _sqlConsultarControle(parametro) {
        let sql = ` `;
        sql = `
        
        
         select         c.seqfaturamento_uuid
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
                    ,   tn.df_nf_tipo_descricao

            from    tbfaturamento_controle c
            inner join tbfaturamento_controle_tipo t on t.fat_controle_tipo_cd = c.fat_controle_tipo_cd
            inner join tbfaturamento        f on f.faturamento_controle_seq = c.faturamento_controle_seq
            inner join tbfaturamentoorigem  o on o.faturamento_controle_seq = c.faturamento_controle_seq

            left join  tbparticipante_bluesoft       cl on cl.cdparticipante = f.cdparticipantecliente
            left join  tbgrupoeconomico     g on g.cdgrupoeconomico = cl.cdgrupoeconomico
         
            left join  tbparticipante_bluesoft       cv on cv.cdparticipante = f.cdparticipantevendedor
         
            left join  tbdocumentofiscal    nf on nf.df_nf_seq_blue = c.df_nf_seq_blue
            left join  tbdocumentofiscal_tipo tn on tn.df_nf_tipo = nf.df_nf_tipo
            where 1 = 1
            and   c.numeropedido = ${parametro.numeropedido}
            and   c.faturamento_controle_seq = ${parametro.faturamento_controle_seq}
       
        `;
        return sql;
    }
    static _sqlconsultarItens(parametro) {
        let sql = `
        
           select           i.pr_cdproduto 
                ,   pb.prb_cdprodutobluesoft_pk as prb_cdprodutobluesoft 
                ,   pr.pr_descricao 
                ,   pr.pr_embalagemestoque
                ,   pr.pr_embalagemcompra
                ,   pr.pr_embalagemcompra_fator
                ,   i.embalagemcompraqtde 
                ,   i.embalagemestoqueqtde
                ,   i.valortotalfaturamentobase as valorfaturamentobase
                ,   i.valortotalsubsidioscorrentes as subsidioscorrentes
                ,   i.valortotalfaturamento as valorfaturamento
                ,   i.valortotaldescontofinanceiro as valortotaldescontofinanceiro
                ,   i.valortotalfaturamentobruto as valorfaturamentobruto
                ,   i.valortotalsubsidiosaplicados as valortotalsubsidiosaplicados
                ,   i.valortotalfaturamentoliquido as valortotalfaturamentoliquido

            from    tbfaturamento_controle c
            inner join tbfaturamentoorigem  o on o.faturamento_controle_seq = c.faturamento_controle_seq
            inner join tbfaturamentoitens   i on i.seqfaturamentoorigem = o.seqfaturamentoorigem
            inner join tbproduto           pr on pr.pr_cdproduto = i.pr_cdproduto
            inner join tbprodutobluesoft   pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
            where   1 = 1
              and   c.faturamento_controle_seq = ${parametro.faturamento_controle_seq}
            order by pr.pr_descricao
        `;
        return sql;
    }
}
exports.default = model_faturamento_controle;
