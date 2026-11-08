import myTools from '../../../tools/Tools';
import tbprodutobluesoft from "../tbs/tbprodutobluesoft"
import tbprodutobluesof_tributacao from '../tbs/tbprodutobluesofttributacao';
import tbprodutobluesoft_gtins from '../tbs/tbprodutobluesoft_gtins';
import tbprodutobluesoft_composicao from '../tbs/tbprodutobluesoft_composicao';
import modelfc_figurafiscal_produto from '../../../modules/m0040_fiscal/model/modelfc_figura_produto';
import bluesoftApi from "../../Apis/bluesoftApi/url/bluesoftApiUrl";
import model0040_fiscal from '../../m0040_fiscal/model/model';
import { clsBase, clsTools } from "../../../model/modelbase";
import sql from 'msnodesqlv8';



export default class modelProdutoBluesoft extends tbprodutobluesoft { 
        Tributacao : tbprodutobluesof_tributacao
        gtinsList: tbprodutobluesoft_gtins[]
        listCebef: string[]
        ComposicaoList : tbprodutobluesoft_composicao[]

        constructor() {
            super();
            this.gtinsList = []
            this.listCebef = []
            this.Tributacao = new tbprodutobluesof_tributacao();
            this.ComposicaoList = []
        }

        async LerOsDadosDaAPI(item : any) {

            try { 

                if (item) {

                    this.prb_cdprodutobluesoft_pk = parseInt(item.produtoKey)
                    this.prb_cdprodutobluesoftunitario = parseInt(item.produtoUnitarioKey)
                    this.prb_descricao = (item.descricao || "PRODUTO SEM DESCRICAO").replace(`'`, ``)  
                    this.prb_embalagemestoque = item.embalagemKey
                    this.prb_fatorestoque = item.fatorEstoque
                    this.prb_status_embalagemcaixa = item.caixa 
                    this.prb_embalagemcompra = ""
                    this.prb_embalagemcompra_qtdeunitaria = 0
                    this.prb_cdbarra_principal = item.gtinPrincipal
                    this.prb_cdprodutobluesoft_controleestoque = 0
                    this.prb_cdprodutobluesoft_controlepreco = 0
                    this.prb_cdsubgrupo	= item.subGrupoProdutoKey
                    this.prb_dt_cadastro = myTools._dataConvertStrtoDate(item.dataCadastro)
                    this.prb_dt_ultimaalteracao = myTools._dataConvertStrtoDate(item.ultimaAlteracao)
                    this.prb_cdpessoabluesoft_fabricante = (item.fabricanteKey || 0 )
                    this.prb_vendaexterna =	 false
                    this.prb_cdproduto_compra_padrao = 0
                    this.prbf_seq = 0
                    this.prb_status = item.status
                    this.prb_descricao_fiscal = (item.observacaoFiscal || "").replace(`'`, ``)  
                    this.prb_descricao_gondola = (item.descricaoGondola || "").replace(`'`, ``)  
                    this.prb_descricao_cupom  = (item.descricaoCupom || "").replace(`'`, ``)  
                    this.prb_descricao_balanca  = (item.descricaoBalanca || "").replace(`'`, ``)
                    this.prb_pesobruto = item.pesoBruto || 0
                    this.prb_pesoliquido = item.pesoLiquido || 0
                    this.prb_pesoaproximado = item.pesoAproximado || 0
                    this.prb_altura = item.altura || 0
                    this.prb_largura = item.largura || 0
                    this.prb_comprimento = item.comprimento || 0
                    this.prb_ncm =  item.ncm? item.ncm : "00000000"
                    this.prb_cest = item.cest? item.cest : "0000000"

                    /* OBTENDO TRIBUTAÇÃO DA API DA BLUESOFT */    
                    const itemTributacao : [] = item.tributacaoEstadual
                    let itemTributacaoSP : Object = {}
                    itemTributacao.map(async ( dadosSP : any) => {
                        if (dadosSP.uf == 'SP') { 
                            //console.log(dadosSP)
                            let dadosSPClienteFINAL: any = dadosSP.icmsDeSaidaClienteFinal
                            this.Tributacao.prb_cdprodutobluesoft = this.prb_cdprodutobluesoft_pk;
                            this.Tributacao.prbt_icms_saida_cst = dadosSPClienteFINAL.cst.length == 2? `0${dadosSPClienteFINAL.cst}` : dadosSPClienteFINAL.length == 1? `00${dadosSPClienteFINAL.cst}`: dadosSPClienteFINAL.cst
                            this.Tributacao.prbt_icms_aliquota_interna = dadosSPClienteFINAL.aliquota
                            this.Tributacao.prbt_icms_reducao = dadosSPClienteFINAL.reducao
                        }

                    })


                    let pisCofinsSaida = item.pisCofinsSaidaNaoCumulativo
                    this.Tributacao.prbt_pis_saida_cst = pisCofinsSaida.cst 
                    this.Tributacao.prbt_pis_saida_aliquota = pisCofinsSaida.pisAliquota 
                    this.Tributacao.prbt_cofins_saida_cst = pisCofinsSaida.cst 
                    this.Tributacao.prbt_cofins_saida_aliquota = pisCofinsSaida.cofinsAliquota
                    this.Tributacao.prbt_ncm = item.ncm? item.ncm : "00000000"
                    this.Tributacao.prbt_cest = item.cest? item.cest : "0000000"



                    let anyListItemgtins : [] = item.gtins
                    
                    anyListItemgtins.map(x => {
                        let itemGtin : tbprodutobluesoft_gtins = new tbprodutobluesoft_gtins();
                        itemGtin.prb_cdprodutobluesoft = this.prb_cdprodutobluesoft_pk
                        itemGtin.prbg_embalagem = this.prb_embalagemestoque
                        itemGtin.prbg_cdbarra_pk = x 
                        itemGtin.prbg_embalagemdescricao = `` 
                        if (x) {
                            if (`${x}`.length >= 1)
                            this.gtinsList.push(itemGtin) 
                        }
                    })




                    if (item.beneficiosFiscais) {
                        for await (const itemBenefiicoFiscal of item.beneficiosFiscais as any[]) {
                            if (itemBenefiicoFiscal.uf === "SP") {
                                this.listCebef.push(itemBenefiicoFiscal.codigoBeneficioFiscal)
                            }
                        }
                    }

                    if (item.tipoComposicao === "Kits") {
                        if (item.composicaoItens) {
                            for await (const itemComposicao of item.composicaoItens as any[]) {
                                let composicao: tbprodutobluesoft_composicao = new tbprodutobluesoft_composicao();
                                composicao.prb_cdprodutobluesoft_unitario = this.prb_cdprodutobluesoftunitario;
                                composicao.prb_cdprodutobluesoft = itemComposicao.produtoParteKey;
                                composicao.prbc_qtde = itemComposicao.pesoBrutoQuantidade || 0;
                                composicao.prbc_descricao = itemComposicao.descricao || 'SEM DESCRICAO';
                                composicao.prbc_percentual_composicao = itemComposicao.participacaoKitCesta || 1;
                                this.ComposicaoList.push(composicao);
                            }
                        }
                    }
                
                }
            } catch (e) {
                await clsTools.PagErrorException('M0021', 'modelProdutoBluesoft.getApiBluesoft', e);
                throw new Error(` Classe modelProdutoBluesoft ${e}` )
             }
        }

        async LerDadosRedShift(item: any) : Promise<void> {
 try {
        if (!item) return;

            const toBoolean = (value: any): boolean =>
                value === true || value === 1 || value === "1";

            this.prb_cdprodutobluesoft_pk = item?.prb_cdprodutobluesoft_pk;
            this.prb_cdprodutobluesoftunitario = item?.prb_cdprodutobluesoftunitario;
            this.prb_descricao = item?.prb_descricao;
            this.prb_embalagemestoque = item?.prb_embalagemestoque;
            this.prb_fatorestoque = item?.prb_fatorestoque;
            this.prb_status_embalagemcaixa = item?.prb_status_embalagemcaixa;
            this.prb_embalagemcompra = item?.prb_embalagemcompra;
            this.prb_embalagemcompra_qtdeunitaria = item?.prb_embalagemcompra_qtdeunitaria;
            this.prb_cdbarra_principal = item?.prb_cdbarra_principal;
            this.prb_cdprodutobluesoft_controleestoque = item?.prb_cdprodutobluesoft_controleestoque;
            this.prb_cdprodutobluesoft_controlepreco = item?.prb_cdprodutobluesoft_controlepreco;
            this.prb_cdsubgrupo = item?.prb_cdsubgrupo;
            this.prb_dt_cadastro = clsTools._datemomentDatStrToDate(item?.prb_dt_cadastro, "YYYY-MM-DD");
            this.prb_dt_ultimaalteracao = clsTools._datemomentDatStrToDate(item?.prb_dt_ultimaalteracao, "YYYY-MM-DD");
            this.prb_cdpessoabluesoft_fabricante = item?.prb_cdpessoabluesoft_fabricante;
            this.prb_vendaexterna = item?.prb_vendaexterna;
            this.prb_descricao_fiscal = " - ";
            this.prb_cdproduto_compra_padrao = item?.prb_cdproduto_compra_padrao;
            this.prbf_seq = item?.prbf_seq;
            this.prb_status = item?.prb_status;
            this.prb_tipo_composicao_cd = item?.prb_tipo_composicao_cd;
            this.prb_descricao_gondola = item?.prb_descricao_gondola;
            this.prb_descricao_cupom = item?.prb_descricao_cupom;
            this.prb_descricao_balanca = item?.prb_descricao_balanca;
            this.prb_cdpessoabluesoft_fornecedor = item?.prb_cdpessoabluesoft_fornecedor;
            this.prb_cdpessoabluesoft_troca = item?.prb_cdpessoabluesoft_fornecedor_troca;
            this.prb_pesobruto = item?.prb_pesobruto;
            this.prb_pesoliquido = item?.prb_pesoliquido;
    } catch (e) {
        await clsTools.PagErrorException("M0021", "modelProdutoBluesoft.LerDadosRedShift", e);
        throw new Error(` Classe modelProdutoBluesoft ${e}`);
    }
        }

        async SqlDeAtualizacaoGeralProdutoBluesoftApi(_scriptSqlCommand : string = `DBINSERT_API`, parametro: any = {}) : Promise<string> {
            let sqlScript =  ``
            let scriptRegraFiscal = ``

            if (_scriptSqlCommand == "DBUPDATE") { 

                let mfiguraFiscal : modelfc_figurafiscal_produto = new modelfc_figurafiscal_produto();


                mfiguraFiscal.prb_cdprodutobluesoft = this.prb_cdprodutobluesoft_pk;

                scriptRegraFiscal = ``;
                scriptRegraFiscal = await mfiguraFiscal.getInsertScriptByProdutoBluesoft(this.prb_cdprodutobluesoft_pk);
                



                _scriptSqlCommand = `DBINSERT_API`
            }

            if (_scriptSqlCommand == ``)
                _scriptSqlCommand = `DBINSERT_API`



            try {
                
                /*  CADASTRO BASICO DO PRODUTO BLUESOFT ----<<<<<< 
                    ---------------------------------------------------------------------------
                    ---------------------------------------------------------------------------
                    ---------------------------------------------------------------------------
                */

                 sqlScript = super._Db_Pg_script(_scriptSqlCommand, parametro, 'true')
                /*  ---------------------------------------------------------------------------  */
                
                                
                
                
                /*  DADOS COMPLEMENTARES 
                    ---------------------------------------------------------------------------
                    ---------------------------------------------------------------------------
                    ---------------------------------------------------------------------------
                */
                
                 if (!this.prb_status_embalagemcaixa)  { 
                    //Ler as tributações se não for do tipo caixa
                    sqlScript += await this.Tributacao._Db_Pg_script(_scriptSqlCommand)
                 }

                 if (this.gtinsList) {
                    for (let i = 0; i <= this.gtinsList.length -1; i++) {
                        sqlScript += await this.gtinsList[i]._Db_Pg_script(_scriptSqlCommand)
                    }
                 }
                 if (this.ComposicaoList.length > 0) {
                    for (let i = 0; i <= this.ComposicaoList.length -1; i++) {
                        sqlScript += await this.ComposicaoList[i]._Db_Pg_script(_scriptSqlCommand)
                    }

                 }
                /*  ---------------------------------------------------------------------------  */




                sqlScript += scriptRegraFiscal;


                sqlScript += model0040_fiscal.sqlDELETE_tbfc_cbenef_produtobluesoft_PorProduto(this.prb_cdprodutobluesoft_pk)    

                if (this.listCebef && this.listCebef.length > 0) {
                    
                    sqlScript += await model0040_fiscal.sqlINSERT_TbFC_CBENEF_PRODUTO_FromList_PorProduto(this.listCebef, this.prb_cdprodutobluesoft_pk)
                }

                
                return sqlScript;
            }
            catch (e) {
                await clsTools.PagErrorException('M0021', 'modelProdutoBluesoft.getApiBluesoftSqlCRUD', e);
            }
            finally {

               
                return sqlScript
            }  
        }

        async AtualizarProdutoBluesoftComDadosDaApi(data : any) : Promise<void> { 
            
            let prb_cdProdutoBluesoft : number = 0;
            try {

                if(data.prb_cdProdutoBluesoft && data.prb_cdProdutoBluesoft != 0) {
                    prb_cdProdutoBluesoft = parseInt(data.prb_cdProdutoBluesoft)
                } else { 
                    throw new Error(` Classe modelProdutoBluesoft | Código do Produto Não informado `)
                }



                let url = `/comercial/produtos?produtoKey=${prb_cdProdutoBluesoft}`
                const item =  await bluesoftApi.api_get(url)


                let database : clsBase = new clsBase();

                this.LerOsDadosDaAPI(item.data.data[0])
                
                let sqlScriptUpdate = await this.SqlDeAtualizacaoGeralProdutoBluesoftApi(`DBUPDATE`)



                await database.myDataBase.pag.Execute(sqlScriptUpdate)


             
            } catch (e) {
                await clsTools.PagErrorException('M0021', 'modelProdutoBluesoft.getApiBluesoft', e);
                throw new Error(` Classe modelProdutoBluesoft
                    Método: getApiBluesoft
                    -----------------------------------------------------------
                    Produto Bluesoft: ${prb_cdProdutoBluesoft}
                    -----------------------------------------------------------
                    Error ${e} \n 
                  `)
            }
        }
}