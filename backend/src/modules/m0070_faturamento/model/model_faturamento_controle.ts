
import { clsBase, clsTools } from '../../../model/modelbase';
import filter from '../types';

import tbfaturamento from '../tbs/tbfaturamento';
import tbfaturamento_controle from '../tbs/tbfaturamento_controle';
import tbfaturamentoorigem from '../tbs/tbfaturamentoorigem';

/*scripts*/

import f0070_23_faturamentoitem_processar from '../scriptdb/pg.f0070_23_faturamentoitem_processar';
import f0070_24_faturamentoitem_rateiocomplemento from '../scriptdb/pg.f0070_24_faturamentoitem_rateiocomplemento';
import f0070_26_faturamento_recusa_processar from '../scriptdb/pg.f0070_26_faturamento_recusa_processar';

/*
    Testar nova solução de model, sendo seus métodos estaticos 
*/

export default class model_faturamento_controle {

    FaturamentoPorFabricante : any

    constructor() {


        this.FaturamentoPorFabricante = [];

    }

    static async get(parametro: any) {
        let dados : any = {}



        dados.controle = await this.faturamentoControleConsultar(parametro);
        dados.itens = await this.faturamentoItensConsultar(parametro);

        return dados;
    }


    static faturamentoControleBindingGet(item: any) : tbfaturamento_controle {

        let result : tbfaturamento_controle = new tbfaturamento_controle();
        result.binding(item)
        return result;
    }

    static async faturamentoItensConsultar(parametro: any) { 
        try { 
            let myDatBase : clsBase = new clsBase();
            let result = await myDatBase.myDataBase.pag.DataGet(this._sqlconsultarItens(parametro))
            return Array.isArray(result) ? result : []
        } catch (e) {
            clsTools.pagConsole("Erro ao consultar itens de faturamento")
            return []
        }

    }

    static async faturamentoControleConsultar(parametro: any) : Promise<any> {
        try { 

            let myDatBase : clsBase = new clsBase();
            let result = myDatBase.myDataBase.RecordItem(await myDatBase.myDataBase.pag.DataGet(this._sqlConsultarControle(parametro)),0)

            return result;

        } catch (error) {
            console.log(error)
            throw error;
        }
    }


    static sqlProcessarFaturamentoPorControle(item: tbfaturamento_controle) : string {
        let sql: string = ` ` 
            
            sql += f0070_23_faturamentoitem_processar.get(item)
            
            if (item.op_cdoperacao == 4) { 
                sql += f0070_24_faturamentoitem_rateiocomplemento.get(item)
            }

            if (item.fat_controle_tipo_cd == 2) { 
                sql += f0070_26_faturamento_recusa_processar.get(item)
            }

            sql += " update tbfaturamento_controle set processamento_pendente = 0 where faturamento_controle_seq = " + item.faturamento_controle_seq + "; "


        return sql;
  

    }


    private static _sqlConsultarControle(parametro: any) : string {
        let sql: string = ` `
        
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
       
        `


        return sql
    }

    private static _sqlconsultarItens(parametro: any) { 
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
        `
        return sql


    }

    

 
}