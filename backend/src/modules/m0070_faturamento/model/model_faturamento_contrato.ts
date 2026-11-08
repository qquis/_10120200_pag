const LOGINFO: any = { 
    SISTEMA_NUCLEO_PRC_CD : 0,
    FLG_DEBUG_CONSOLE_LOG : true,
    FLG_MODULO : "M0070 FaturamentoContrato | MODEL CONTRATO",
    FLG_NOPRINT_TIME : false,
    FLG_DEBUG_FILE_CONSOLE_LOG : ``

}



import { clsBase, clsTools } from "../../../model/modelbase";

export default class model_faturamentoContrato {

    static async post(dados : any) : Promise<any> {
        let result : any = {}
        try { 
            
            let dadosContrato = dados
            dadosContrato = await this.constratoInserirAtualizar(dadosContrato)
            if (Array.isArray(dadosContrato.itens)) {
                await this.contratoProdutoInserirAtualizar(dadosContrato)
            }
            return dadosContrato

        } catch (e) {   
            throw new Error(e as string);
        }
        
    }
    static async get(parametro : any) : Promise<any> {
        try {
            const contrato_seq = Number(parametro?.contrato_seq)
            if (!(contrato_seq > 0)) { throw new Error("contrato_seq não informado") }

            const contrato = await this.consultarContrato({ contrato_seq })
            if (!contrato) { throw new Error(`Contrato ${contrato_seq} não encontrado`) }
            contrato.itens = await this.consultarContratoItens(contrato_seq)
            return contrato
        } catch (e) {
            await this.__log(`Erro ao consultar contrato ${e}`)
            throw new Error(e as string);
        }
    }
    static async consultarContratoItens(contrato_seq: number) {
        let sql = `
            SELECT  i.contrato_seq
            ,    i.pr_cdproduto
            ,    i.prb_cdprodutobluesoft
            ,    pb.prb_descricao as descricao
            ,    pb.prb_embalagemestoque
            ,    i.valor_unitario
            FROM tbfaturamentocontrato_produto i
            inner join  tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
            WHERE i.contrato_seq = ${Number(contrato_seq)}
            `
        return await this.__databaseGet(sql)
    }
    static async consultarContrato(parametro: any) { 
        let dados : any = parametro
        try { 

              let sql = `	select f.contrato_seq
                ,  f.competencia_cd
                ,  f.contrato_descricao 
                ,  f.contrato_data
                ,  f.contrato_tipo_cd
                ,  f.contrato_data_val_ini
                ,  f.contrato_data_val_fim
                ,  f.op_cdoperacao
                ,  f.cdparticipante_contratante
                ,  f.seqfaturamento
                ,  f.seqfaturamentoorigem
                ,  f.faturamento_controle_seq
                ,  f.contrato_valor
                ,  f.contrato_uuid
                ,  l.numeropedido_fv
                ,  l.numeropedido
                ,  l.numeronfe
                ,  b.nome_razao
            from   tbfaturamentocontrato f
            left join tbfaturamento_controle l 
                    on l.faturamento_controle_seq = f.faturamento_controle_seq
            left join tbparticipante_bluesoft b on b.cdpessoabluesoft = l.cdpessoabluesoft_cliente
            where 1 = 1
              and f.contrato_seq = ${Number(dados.contrato_seq)}
            `
            let result : any = await this.__databaseGet(sql)
            return Array.isArray(result) ? result[0] : result

        } catch (e) {
            await this.__log(e as string)
            throw new Error(e as string);
        }
    }

    static async constratoInserirAtualizar(dadosContrato : any) : Promise<any> {

        let dados = dadosContrato
        let dataBase : clsBase = new clsBase()

        let sql_insert = ``
        try {
            if (!dados) { throw new Error("Dados do contrato não informados") }

            const txt = (v: any) => clsTools.stringToDabase(String(v ?? ''))
            const num = (v: any, def: string = 'null') => {
                const n = Number(v)
                return v === undefined || v === null || v === '' || isNaN(n) ? def : String(n)
            }
            const data = (v: any) => {
                if (!/^\d{4}-\d{2}-\d{2}/.test(String(v ?? ''))) { throw new Error(`Data inválida: ${v}`) }
                return String(v).substring(0, 10)
            }

            const contrato_uuid = dados.contrato_uuid ? txt(dados.contrato_uuid) : clsTools.uuid(32).replace(/-/g, '').substring(0, 10).toUpperCase()
            if (contrato_uuid.length > 10) { throw new Error('contrato_uuid excede 10 caracteres') }

            if (!dados.contrato_seq || (dados.contrato_seq && parseInt(dados.contrato_seq) == 0 )) {
                    sql_insert = 
                    `insert into tbfaturamentocontrato  (
                                competencia_cd
                            ,   contrato_uuid
                            ,   contrato_descricao 
                            ,   contrato_data
                            ,   contrato_data_val_ini
                            ,   contrato_data_val_fim
                            ,   contrato_valor  
                            ,   faturamento_controle_Seq
                            ,   seqfaturamento
                            ,   seqfaturamentoorigem
                            ,   contrato_tipo_cd 
                            ,   op_cdoperacao
                            ,   cdparticipante_contratante
                            ,   contrato_status
                        )
                        SELECT ${num(dados.competencia_cd)}
                            ,  '${contrato_uuid}'
                            ,  '${txt(dados.contrato_descricao)}'
                            ,  '${data(dados.contrato_data)}'
                            ,  '${data(dados.contrato_data_val_ini)}'
                            ,  '${data(dados.contrato_data_val_fim)}'
                            ,   ${num(dados.contrato_valor, '0')}
                            ,   ${num(dados.faturamento_controle_seq)}
                            ,   ${num(dados.seqfaturamento)}
                            ,   ${num(dados.seqfaturamentoorigem)}
                            ,   ${num(dados.contrato_tipo_cd)}
                            ,   ${num(dados.op_cdoperacao)}
                            ,   ${num(dados.cdparticipante_contratante)}
                            ,   ${num(dados.contrato_status)}
                        where not exists (select 1 from tbfaturamentocontrato xx where xx.contrato_uuid = '${contrato_uuid}')`


            } else { 
                sql_insert = `update tbfaturamentocontrato 
                             set    contrato_data = '${data(dados.contrato_data)}'
                                ,   contrato_data_val_ini = '${data(dados.contrato_data_val_ini)}'
                                ,   contrato_data_val_fim = '${data(dados.contrato_data_val_fim)}'
                             where contrato_seq = ${dados.contrato_seq}
                
                
                `
            }
            
            await this.__databaseExecute(sql_insert)



            if (!dados.contrato_seq || (dados.contrato_seq && parseInt(dados.contrato_seq) == 0 )) {

                let scriptConferirSeqContato = `select contrato_seq from tbfaturamentocontrato where contrato_uuid = '${contrato_uuid}'`
                
                let dadoRegistroContrato : any = await this.__databaseGet(scriptConferirSeqContato)

                if (dadoRegistroContrato) {
                    let contrato_seq = (dadoRegistroContrato as any[])[0].contrato_seq
                    dados.contrato_seq = contrato_seq
                } else {
                    throw new Error('Contrato não inserido')
                }
            }
            return dados
        } catch (e) {
            await this.__log(`Erro ao inserir contrato ${e}`)
            throw new Error(e as string);
        }

    }

    static async contratoInativar(dados: any) { 
        try { 
                let sqlUpdate = `UPDATE tbfaturamentocontrato
                                    set constrato_status = 0 
                                    ,   contrato_data_val_ini = '1900-01-01'
                                    ,   contrato_data_val_fim = '1900-01-01'
                                    where contrato_seq = ${dados.contrato_seq}`;
                
                await this.__databaseExecute(sqlUpdate)
        } catch (e) {
            await this.__log(`Erro ao inativar contrato ${e}`)
        }
    }

    static async contratoProdutoInserirAtualizar(dados: any) { 
                let dataBase : clsBase = new clsBase()
        try { 

                let script_atualizacao = `
                
                                update tbfaturamentocontrato_produto
                                  set  valor_unitario = 0 
                                  where contrato_seq = ${dados.contrato_seq}
                                ;
                
                                `
                if (dados && dados.itens && dados.itens.length > 0) { 

                    for (const item of dados.itens as any[]) {
                        script_atualizacao += `
                        
                                insert into tbfaturamentocontrato_produto 
                                (
                                        contrato_seq
                                    ,   pr_cdproduto 
                                    ,   prb_cdprodutobluesoft 
                                    ,   valor_unitario
                                )
                                select ${dados.contrato_seq}
                                        , ${item.pr_cdproduto}
                                        , ${item.prb_cdprodutobluesoft} 
                                        , ${item.valor_unitario}
                                    where not exists( select 1 
                                                    from tbfaturamentocontrato_produto b
                                                    where b.contrato_seq = ${dados.contrato_seq}
                                                    and b.pr_cdproduto = ${item.pr_cdproduto}
                                                    and b.prb_cdprodutobluesoft = ${item.prb_cdprodutobluesoft}
                                                    )                                        
                                        
                                        ;
                                        
                                update tbfaturamentocontrato_produto
                                   set valor_unitario = ${item.valor_unitario}
                                   where contrato_seq = ${dados.contrato_seq}
                                   and pr_cdproduto = ${item.pr_cdproduto}
                                   and prb_cdprodutobluesoft = ${item.prb_cdprodutobluesoft}
                        
                                ;
                                 
                                 
                                 `
                    } 
                }

                await dataBase.myDataBase.pag.Execute(script_atualizacao)
        } catch (e) { 
            await this.__log(`Erro ao inserir produto do contrato ${dados.contrato_seq} ${e}`)
        }
    }

    static async consultarContratoProdutoItensFornecedor(dados: any) { 
        try { 

                let sql = ``



                if (!dados.faturamento_controle_seq || parseInt(dados.faturamento_controle_seq) == 0) {
                    sql = `
                    
                    
                        SELECT     ${dados.contrato_seq > 0 ? dados.contrato_seq : 0} as contrato_seq
                                ,    pr.pr_cdproduto
                                ,    pb.prb_cdprodutobluesoft_pk 
                                ,    un.prb_descricao as descricao 
                                ,    pb.prb_embalagemestoque
                                ,    cast(0 as numeric(13,2)) as valor_unitario

                        from        tbprodutobluesoft pb 
                        inner join  tbprodutobluesoft un on un.prb_cdprodutobluesoft_pk = pb.prb_cdprodutobluesoftunitario
                        left join   tbparticipante_bluesoft p on p.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
                        left join   tbproduto_subgrupo sb on sb.prsg_cdsubgrupo = pb.prb_cdsubgrupo
                        left join   tbproduto_grupo g on g.prg_cdgrupo = sb.prg_cdgrupo
                        left join   tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
                        left join   tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento
                        left join   tbproduto pr on pr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario
                        where 1 = 1
                        AND  pb.prb_cdpessoabluesoft_fornecedor = ${dados.prb_cdpessoabluesoft_fornecedor}
                        and  pb.prb_cdprodutobluesoft_pk = pb.prb_cdprodutobluesoftunitario
                        and  pb.prb_status = true


                        `
                        
                    if (dados.contrato_seq && dados.contrato_seq > 0){
                        sql += `
                            UNION 

                            SELECT  i.contrato_seq
                            ,    i.pr_cdproduto
                            ,    i.prb_cdprodutobluesoft
                            ,    pb.prb_descricao as descricao
                            ,    pb.prb_embalagemestoque               
                            ,    i.valor_unitario 
                            FROM tbfaturamentocontrato_produto i
                            inner join  tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
                            left join   tbproduto pr on pr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario             
                            WHERE CONTRATO_SEQ = ${dados.contrato_seq}
                            `
                    }
                }

                if (dados.faturamento_controle_seq && parseInt(dados.faturamento_controle_seq) > 0) {
                    sql = ` select          0 as contrato_seq
                                        ,   i.pr_cdproduto 
                                        ,   pb.prb_cdprodutobluesoft_pk as prb_cdprodutobluesoft 
                                        ,   pr.pr_descricao 
                                        ,   pb.prb_embalagemestoque
                                        ,   0 as valor_unitario
                                        ,   i.ec_valorcusto_faturamento_total as valor_custo
                                    from    tbfaturamento_controle c
                                    inner join tbfaturamentoorigem  o on o.faturamento_controle_seq = c.faturamento_controle_seq
                                    inner join tbfaturamentoitens   i on i.seqfaturamentoorigem = o.seqfaturamentoorigem
                                    inner join tbproduto           pr on pr.pr_cdproduto = i.pr_cdproduto
                                    inner join tbprodutobluesoft   pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
                                    where   1 = 1
                                    and   c.faturamento_controle_seq = ${dados.faturamento_controle_seq}
                                    AND  pb.prb_cdpessoabluesoft_fornecedor = ${dados.prb_cdpessoabluesoft_fornecedor}
                                    order by pr.pr_descricao`
                }

                let result = await this.__databaseGet(sql);
                return result;


        } catch (e)
        {
            await this.__log(`Erro ao consultar itens do fornecedor ${e}`)
        }
    }

    static async __log(message: string) {
        await clsTools.pagLogInfo(message, LOGINFO)
    }

    static async __databaseGet(sql: string) { 
        try { 

            let mydb : clsBase = new clsBase();
            let dados = await mydb.myDataBase.pag.DataGet(sql)
            return dados;
        } catch (e) {
            await this.__log(`Erro ao consultar banco de dados ${e}`)
            throw new Error(e as string)
        }
    }

    static async __databaseExecute(sql : string) { 
        try {
            let mydb : clsBase = new clsBase();
            await mydb.myDataBase.pag.Execute(sql)
        }
        catch (e) {
            await this.__log(`Erro ao executar comando no banco de dados ${e}`)
            throw new Error(e as string)
        }
    }



}
