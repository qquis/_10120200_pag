import { promises } from "dns";
import { clsBase, clsTools } from "../../../model/modelbase";
import tbfc_regrafiscal_nfce_produto from "../tbs/tbfc_regrafiscalNfceProduto";

const myBase : clsBase = new clsBase();

export default class modelfc_regrafiscalNfceProduto extends tbfc_regrafiscal_nfce_produto {
   
   LerDadosDaAPI(item: any, NFEC_PRODUTO_TIPO_CD : number = 1) { 

     if (item) {

                this.LOCAL_STATUS_API = 1;

                this.nfce_produto_tipo_cd = NFEC_PRODUTO_TIPO_CD

                // CBS - Reforma Tributária
                this.cbs_aliquota_ad_rem = item?.reformaTributaria?.cbs?.aliquotaAdRem || 0
                this.cbs_aliquota_desoneracao = item?.reformaTributaria?.cbs?.aliquotaDesoneracao || 0
                this.cbs_aliquota_efetiva = item?.reformaTributaria?.cbs?.aliquotaEfetiva || 0
                this.cbs_aliquota = item?.reformaTributaria?.cbs?.aliquota || 0
                this.cbs_cd = item?.reformaTributaria?.cbs?.cbsKey || 0
                this.cbs_descricao_abreviada = item?.reformaTributaria?.cbs?.descricaoAbreviada || ''
                this.cbs_descricao = item?.reformaTributaria?.cbs?.descricao || ''
                this.cbs_percentual_credito_presumido = item?.reformaTributaria?.cbs?.percentualCreditoPresumido || 0
                this.cbs_percentual_credito_presumido_monofasico = item?.reformaTributaria?.cbs?.percentualCreditoPresumidoMonofasico || 0
                this.cbs_percentual_diferimento = item?.reformaTributaria?.cbs?.percentualDiferimento || 0
                this.cbs_percentual_diferimento_monofasico = item?.reformaTributaria?.cbs?.percentualDiferimentoMonofasico || 0
                this.cbs_percentual_reducao = item?.reformaTributaria?.cbs?.percentualReducao || 0
                
                // CFOP
                this.cfop = item?.cfopKey || 0
                
                // Códigos de regra fiscal
                this.codigo_figura_regra_fiscal = item?.codigoFiguraRegraFiscal || 0
                this.codigo_regra_fiscal = item?.codigoRegraFiscal || 0
                
                // COFINS
                this.cofins_aliquota = item?.cofins?.aliquota || 0
                this.cofins_cst = item?.cofins?.cst || 0
                
                // Datas
                this.data_hora_geracao = this.myTools._datemomentDatStrToDate(item?.dataHoraGeracao, `YYYY-MM-DDTHH:mm:ss.SSSSSS`)
                this.data_referencia = item?.dataReferencia || ''
                
                // Sequencial
                this.fc_rf_nfce_seq = item?.produtoKey || 0
                
                // IBS - Reforma Tributária
                this.ibs_aliquota_ad_rem = item?.reformaTributaria?.ibs?.aliquotaAdRem || 0
                this.ibs_aliquota_desoneracao = item?.reformaTributaria?.ibs?.aliquotaDesoneracao || 0
                this.ibs_aliquota_efetiva = item?.reformaTributaria?.ibs?.aliquotaEfetiva || 0
                this.ibs_aliquota = item?.reformaTributaria?.ibs?.aliquota || 0
                this.ibs_cd = item?.reformaTributaria?.ibs?.ibsKey || 0
                this.ibs_descricao_abreviada = item?.reformaTributaria?.ibs?.descricaoAbreviada || ''
                this.ibs_descricao = item?.reformaTributaria?.ibs?.descricao || ''
                this.ibs_percentual_credito_presumido = item?.reformaTributaria?.ibs?.percentualCreditoPresumido || 0
                this.ibs_percentual_credito_presumido_monofasico = item?.reformaTributaria?.ibs?.percentualCreditoPresumidoMonofasico || 0
                this.ibs_percentual_diferimento = item?.reformaTributaria?.ibs?.percentualDiferimento || 0
                this.ibs_percentual_diferimento_monofasico = item?.reformaTributaria?.ibs?.percentualDiferimentoMonofasico || 0
                this.ibs_percentual_reducao = item?.reformaTributaria?.ibs?.percentualReducao || 0



                // IBS - Reforma Tributária Municipal
                this.ibs_mun_aliquota_ad_rem = item?.reformaTributaria?.ibsMun?.aliquotaAdRem || 0
                this.ibs_mun_aliquota_desoneracao = item?.reformaTributaria?.ibsMun?.aliquotaDesoneracao || 0
                this.ibs_mun_aliquota_efetiva = item?.reformaTributaria?.ibsMun?.aliquotaEfetiva || 0
                this.ibs_mun_aliquota = item?.reformaTributaria?.ibsMun?.aliquota || 0
                this.ibs_mun_cd = item?.reformaTributaria?.ibsMun?.ibsKey || 0
                this.ibs_mun_descricao_abreviada = item?.reformaTributaria?.ibsMun?.descricaoAbreviada || ''
                this.ibs_mun_descricao = item?.reformaTributaria?.ibsMun?.descricao || ''
                this.ibs_mun_percentual_credito_presumido = item?.reformaTributaria?.ibsMun?.percentualCreditoPresumido || 0
                this.ibs_mun_percentual_credito_presumido_monofasico = item?.reformaTributaria?.ibsMun?.percentualCreditoPresumidoMonofasico || 0
                this.ibs_mun_percentual_diferimento = item?.reformaTributaria?.ibsMun?.percentualDiferimento || 0
                this.ibs_mun_percentual_diferimento_monofasico = item?.reformaTributaria?.ibsMun?.percentualDiferimentoMonofasico || 0
                this.ibs_mun_percentual_reducao = item?.reformaTributaria?.ibsMun?.percentualReducao || 0



                
                // ICMS
                this.icms_aliquota_desoneracao = item?.icms?.aliquotaDesoneracao || 0
                this.icms_aliquota_efetiva = item?.icms?.aliquotaEfetiva || 0
                this.icms_aliquota_final = item?.icms?.aliquotaFinal || 0
                this.icms_aliquota_interna = item?.icms?.aliquotaInterna || 0
                this.icms_aliquota = item?.icms?.aliquota || 0
                this.icms_codigo_icms = item?.icms?.codigoIcms || 0
                this.icms_codigo_origem = item?.icms?.codigoOrigem || 0
                this.icms_codigo_tributacao_final = item?.icms?.codigoTributacaoFinal || 0
                this.icms_codigo_tributacao = item?.icms?.codigoTributacao || 0
                this.icms_csosn = item?.icms?.csosn || ''
                this.icms_decreto_de_lei = item?.icms?.decretoDeLei || ''
                this.icms_desconto_icms_desonerado = item?.icms?.descontoIcmsDesonerado || ''
                this.icms_fcp_agregado = item?.icms?.fcpAgregado || 0
                this.icms_fcp_segregado = item?.icms?.fcpSegregado || 0
                this.icms_percentual_diferimento = item?.icms?.percentualDiferimento || 0
                this.icms_reducao_aliquota_efetiva = item?.icms?.reducaoAliquotaEfetiva || 0
                this.icms_reducao = item?.icms?.reducao || 0
                
                // IPI
                this.ipi_aliquota = item?.ipi?.aliquota || 0
                this.ipi_cst = item?.ipi?.cst || 0
                
                // NCM
                this.ncm_codigo = item?.ncm?.codigo || ''
                this.ncm_excecao = item?.ncm?.excecao || 0
                this.ncm_variacao = item?.ncm?.variacao || 0
                
                // PIS
                this.pis_aliquota = item?.pis?.aliquota || 0
                this.pis_cst = item?.pis?.cst || 0
                
                // Produto
                this.prb_cdprodutobluesoft = item?.produtoKey || 0
                
                // Reforma Tributária - CST
                this.rt_codigo_class_trib_ibs_cbs = item?.reformaTributaria?.codigoClassTribIbsCbs || ''
                this.rt_codigo_cst_ibs_cbs = item?.reformaTributaria?.codigoCstIbsCbs || ''
                this.rt_descricao_class_trib_ibs_cbs = item?.reformaTributaria?.descricaoClassTribIbsCbs || ''
                this.rt_descricao_cst_ibs_cbs = item?.reformaTributaria?.descricaoCstIbsCbs || ''
            }
   }

   async script_CRUD() : Promise<string> { 
          
        let scriptSQL: string = ``
    
        if (this.LOCAL_STATUS_API == 1) {

            return this.sql_CRUD();

        }
        else { 
            scriptSQL = `delete from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft};`
        }

        return scriptSQL;
   }


   async ChamadaLeituraApiBlueSoftSatNfcePorProduto(prb_cdprodutobluesoft: number) {
            
            let sqlscript : string = ``;

            try { 

                let url = `/modulos/fiscal/regra-fiscal/pdv/sat-nfces?lojaKey=1&page=1&produtoKey=${prb_cdprodutobluesoft}`;
                
                const ItemData = await myBase.blueSoftApi.api_get(url)

                
                if (ItemData && ItemData.data && ItemData.data.length > 0)
                {
                    
                    this.LerDadosDaAPI(ItemData.data[0]);
                }
                else { 
                    this.prb_cdprodutobluesoft = prb_cdprodutobluesoft;
                    this.LOCAL_STATUS_API = 0;
                }


            } catch (e) { 
                await clsTools.PagErrorException('M0040_FISCAL', 'modelfc_regrafiscalNfceProduto.ChamadaLeituraApiBlueSoftSatNfcePorProduto', e);
            }


   }

}