import { clsBase, clsTools } from '../../../model/modelbase';
import tbproduto from '../tbs/tbprodutos';



export default class modelprodutoEmbalagemGtin extends tbproduto { 
    constructor() { 
        super();
    }



    async ConsultarDataQuery( gtin : string ) { 
        
        let dataGtin : any = {};
        
        try { 

            dataGtin = await this.ConsultarGtinDadosBasicos(gtin);



        } catch (e) { 
            clsTools.PagErrorException(`M0020 - PRODUTO | modelproduto`,'consultar gtin', e );
        }

        finally {
            return dataGtin;
        }   



    }

    
    async ConsultarGtinDadosBasicos (gtin : string) : Promise<any> {

        let gtinDadosBasicos : any = {};


        const myBase = new clsBase();

        try { 
             
            let sql = `
            
            select 	g.pr_cdproduto 
                ,	g.prb_cdprodutobluesoft 
                ,	g.preg_cdbarra
                ,   g.pre_embalagem
                ,	gb.prbg_cdbarra_pk
                ,	coalesce(gb.prbg_embalagemdescricao, 'SEM DESCRICAO') as prbg_embalagemdescricao
                ,	pb.prb_cdprodutobluesoftunitario 
                ,	z.zanthus_tributacao_nfce_seq 
                ,	z.api_regra_fiscal	
                ,	z.ncm_codigo
                ,	z.cest
                ,	z.pis_cst
                ,	z.pis_aliquota
                ,	z.cofins_cst
                ,	z.cofins_aliquota
                ,	z.icms_cst
                ,	z.icms_aliquota
                ,	z.icms_reducao 
                ,	z.icms_aliquota_final 
                ,	z.r_cod_sit_tributaria_ibs_cbs

            from 		tbprodutoembalagem_gtins g 					
            left join 	tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = g.prb_cdprodutobluesoft 
            left join   tbprodutobluesoft_gtins gb on gb.prbg_cdbarra_pk = g.preg_cdbarra 
            left join   tbzanthus_tributacao_nfce z on lpad(z.cod_mercadoria, 17, '0') = lpad(g.preg_cdbarra, 17, '0')
            where 1 = 1
            and   lpad(g.preg_cdbarra, 14, '0') = lpad('${gtin}', 14, '0')
                    `

            gtinDadosBasicos = await myBase.myDataBase.RecordItem( await myBase.myDataBase.pag.DataGet(sql), 0 )


        } catch (e) { 
            clsTools.PagErrorException(`M0020 - PRODUTO | modelproduto`,'consultar embalagens', e );
        }

        finally {
            return gtinDadosBasicos;
        }


    }

    
}