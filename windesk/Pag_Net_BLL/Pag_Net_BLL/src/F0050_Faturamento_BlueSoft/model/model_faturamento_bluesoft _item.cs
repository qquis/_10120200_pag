using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0050_Faturamento_BlueSoft.model
{
    public class model_faturamento_bluesoft_item
    {
        public tbs.tbfaturamento_bluesoft_item faturamento_bluesoft_item { get; set; }

        public model_faturamento_bluesoft_item()
        {
            this.faturamento_bluesoft_item = new tbs.tbfaturamento_bluesoft_item();            
        }

        public void binding_redShift_faturamento(DataRow i)
        {
            try
            {
                this.faturamento_bluesoft_item.binding(i);
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }




        public string script_faturamento_item_crud(BDCommandTypes BDCommnadType)
        {
            string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT " + scripts.F0050_12_Faturamento_Bluesoft_Item_CRUD._VERSION() + "( " 
                                            + "     sqlcommand:= '" + BDCommnadType.ToString() + "'"
                                            // CHAVES
                                            + ",	vfat_blue_origem_seq:= 0 "
                                            + ",	vfat_blue_item_seq:= 0 "
                                            + ",	vop_cdoperacao:= " + this.faturamento_bluesoft_item.op_cdoperacao.ToString()  							
                                            + ",	vnumeropedido:= " + this.faturamento_bluesoft_item.numeropedido.ToString()  							
                                            + ",	vnumeropedido_fv:= " + this.faturamento_bluesoft_item.numeropedido_fv.ToString()  							
                                            + ",	vdf_nf_seq_blue:= " + this.faturamento_bluesoft_item.df_nf_seq_blue.ToString()
                                            + ",    vcdpessoabluesoft_cliente:= " + this.faturamento_bluesoft_item.cdpessoabluesoft_cliente.ToString()
                                            // PRODUTO 
                                            + ",	vprb_cdprodutobluesoft:= " + this.faturamento_bluesoft_item.prb_cdprodutobluesoft.ToString()  				
                                            + ",	vprb_cdprodutobluesoft_unitario:= " + this.faturamento_bluesoft_item.prb_cdprodutobluesoft_unitario.ToString()	
                                            + ",	vprb_embalagem:= '" + this.faturamento_bluesoft_item.prb_embalagem.ToString() + "'"
                                            + ",	vprb_fatorestoque:= " + this.faturamento_bluesoft_item.prb_fatorestoque.ToString("0.00").Replace(",", ".")	 						
                                            + ",	vembalagem_descricao:= '" + this.faturamento_bluesoft_item.embalagem_descricao.ToString() + "'"

                                            /*qtde */
                                            + ",	vqtde_unitaria_solicitada:= " + this.faturamento_bluesoft_item.qtde_unitaria_solicitada.ToString("0.00").Replace(",", ".")
                                            + ",	vqtde_unitaria_faturada:= " + this.faturamento_bluesoft_item.qtde_unitaria_faturada.ToString("0.00").Replace(",", ".")
                                            + ",	vqtde_solicitada:= " + this.faturamento_bluesoft_item.qtde_solicitada.ToString("0.00").Replace(",", ".")
                                            + ",	vqtde_faturada:= " + this.faturamento_bluesoft_item.qtde_faturada.ToString("0.00").Replace(",", ".")

                                            /*qtde */
                                            + ",	vvalor_custo_com_icm_unit:= " + this.faturamento_bluesoft_item.valor_custo_com_icm_unit.ToString("0.00").Replace(",", ".")
                                            + ",	vvalor_custo_com_icm:= " + this.faturamento_bluesoft_item.valor_custo_com_icm.ToString("0.00").Replace(",", ".")
                                            + ",	vvalor_custo:= " + this.faturamento_bluesoft_item.valor_custo.ToString("0.00").Replace(",", ".")

                                            /*precos */
                                            + ",	vvalor_preco_tabela:= " + this.faturamento_bluesoft_item.valor_preco_tabela.ToString("0.00").Replace(",", ".")													
                                            + ",	vvalor_preco:= " + this.faturamento_bluesoft_item.valor_preco.ToString("0.00").Replace(",", ".")							
                                            + ",	vvalor_preco_aplicado:= " + this.faturamento_bluesoft_item.valor_preco_aplicado.ToString("0.00").Replace(",", ".")

                                            /*verbas */
                                            + ",	vvalor_verba:= " + this.faturamento_bluesoft_item.valor_verba.ToString("0.00").Replace(",", ".")
                                            + ",	vvalor_verba_gerencia:= " + this.faturamento_bluesoft_item.valor_verba_gerencia.ToString("0.00").Replace(",", ".")
                                            + ",	vvalor_verba_supervisao:= " + this.faturamento_bluesoft_item.valor_verba_supervisao.ToString("0.00").Replace(",", ".")
                                            + ",	vvalor_verba_calculada:= " + this.faturamento_bluesoft_item.valor_verba_calculada.ToString("0.00").Replace(",", ".")					


                                            /*DESCONTO FINANCEIRO */
                                            + ",	vpercentual_desconto_financeiro:= " + this.faturamento_bluesoft_item.percentual_desconto_financeiro.ToString("0.00").Replace(",", ".")					

                                            /* nota */
                                            + ",	vvalor_nf_item_bruto:= " + this.faturamento_bluesoft_item.valor_nf_item_bruto.ToString("0.00").Replace(",", ".")
                                            + ",	vvalor_nf_item:= " + this.faturamento_bluesoft_item.valor_nf_item.ToString("0.00").Replace(",", ".")
                                            + ",	vitem_nf_bonificado:= " + this.faturamento_bluesoft_item.item_nf_bonificado.ToString()


                                            
                                            + " ); "
                                             
                    );

                return SQL_POSTGRE;
        }
    }
}
