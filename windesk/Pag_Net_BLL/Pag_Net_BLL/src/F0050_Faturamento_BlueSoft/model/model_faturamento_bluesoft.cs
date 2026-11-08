using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0050_Faturamento_BlueSoft.model
{
    public class model_faturamento_bluesoft
    {
        public tbs.tbfaturamento_bluesoft faturamento_bluesoft { get; set; }
        public Pag_Net.src.F0004_Forca_Venda.tbs.tbforca_venda_prazopgto forca_venda_prazo { get; set; }
        public tbs.tbfaturamento_bluesoft_origem faturamento_bluesoft_origem { get; set; }

        public model_faturamento_bluesoft()
        {
            faturamento_bluesoft = new tbs.tbfaturamento_bluesoft();
            faturamento_bluesoft_origem = new tbs.tbfaturamento_bluesoft_origem();
            forca_venda_prazo = new F0004_Forca_Venda.tbs.tbforca_venda_prazopgto();
            
        }

        public void binding_redShift_faturamento(DataRow i)
        {
            try
            {
                this.faturamento_bluesoft.binding(i);
                this.faturamento_bluesoft_origem.binding(i);
                this.forca_venda_prazo.fv_prazopgto_descricao = i["fv_prazopgto_descricao"].ToString();

            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }




        public string script_faturamento_crud(BDCommandTypes BDCommnadType)
        {
            string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT " + scripts.F0050_10_Faturamento_Bluesoft_CRUD._VERSION() + "( " 
                                            + "   sqlcommand:= '" + BDCommnadType.ToString() + "'"
                                            + " , vop_cdoperacao:= " + this.faturamento_bluesoft.op_cdoperacao.ToString()
                                            + " , vfat_blue_seq:= " + this.faturamento_bluesoft.fat_blue_seq.ToString()
                                            + " , vnumeropedido:= " + this.faturamento_bluesoft.numeropedido.ToString() 
                                            + " , vnumeropedido_fv:= " + this.faturamento_bluesoft.numeropedido_fv.ToString()
                                            + " , vdf_nf_seq_blue:= " + this.faturamento_bluesoft.df_nf_seq_blue.ToString()
                                            + " , vdf_nf_seq_blue_dev:= " + this.faturamento_bluesoft.df_nf_seq_blue_dev.ToString()
                                            + " , vfat_blue_status_cd:= " + this.faturamento_bluesoft.fat_blue_status_cd.ToString() 
                                            + " , vfat_blue_tipo_cd:= " + this.faturamento_bluesoft.fat_blue_tipo_cd.ToString() 
                                            + " , vcdpessoabluesoft_cliente:= " + this.faturamento_bluesoft.cdpessoabluesoft_cliente.ToString() 
                                            + " , vcdpessoabluesoft_vendedor:= " + this.faturamento_bluesoft.cdpessoabluesoft_vendedor.ToString() 
                                            + " , vtabelapreco_cd:= " + this.faturamento_bluesoft.tabelapreco_cd.ToString()  
                                            + " , vtabelapreco_versao_cd:= " + this.faturamento_bluesoft.tabelapreco_versao_cd.ToString()  
                                            + " , vfv_prazopgto_cd:= " + this.faturamento_bluesoft.fv_prazopgto_cd.ToString() 
                                            + " , vtipo_entrega_descricao:= '" + this.faturamento_bluesoft.tipo_entrega_descricao.ToString().Replace("'","") + "'"
                                            + " , vorigem_pedido:= '" + this.faturamento_bluesoft.origem_pedido.ToString().Replace("'", "") + "'"
                                            + " , vdata_solicitacao:= '" + this.faturamento_bluesoft.data_solicitacao.ToString("yyyy-MM-dd") + "'"
                                            + " , vdata_emissao:= '" + this.faturamento_bluesoft.data_emissao.ToString("yyyy-MM-dd") + "'"
                                            + " , vdata_faturamento:= '" + this.faturamento_bluesoft.data_faturamento.ToString("yyyy-MM-dd") + "'"
                                            + " , vnumero_itens:= " + this.faturamento_bluesoft.numero_itens.ToString() 
                                            + " , vvalor_pedido:= " + this.faturamento_bluesoft.valor_pedido.ToString("0.00").Replace(",",".")
                                            + " , vvalor_faturamento:= " + this.faturamento_bluesoft.valor_faturamento.ToString("0.00").Replace(",",".")
                                            + " , vfv_prazopgto_descricao:= '" + this.forca_venda_prazo.fv_prazopgto_descricao.ToString().Replace("'","") + "'"
                                                + "); " /*
                                            "SELECT " + scripts.F0050_10_Faturamento_Bluesoft_Origem_CRUD._VERSION() + "( "
                                            + "   sqlcommand:= '" + BDCommnadType.ToString() + "'"
                                            + " , vop_cdoperacao:= " + this.faturamento_bluesoft_origem.op_cdoperacao.ToString()
                                            + " , vfat_blue_origem_seq:= " + this.faturamento_bluesoft_origem.fat_blue_origem_seq.ToString()
                                            + " , vnumeropedido:= " + this.faturamento_bluesoft_origem.numeropedido.ToString()
                                            + " , vnumeropedido_fv:= " + this.faturamento_bluesoft_origem.numeropedido_fv.ToString()
                                            + " , vdf_nf_seq_blue:= " + this.faturamento_bluesoft_origem.df_nf_seq_blue.ToString()
                                            + " , vdf_nf_seq_blue_dev:= " + this.faturamento_bluesoft_origem.df_nf_seq_blue_dev.ToString() 
                                            + " ); "*/
                                             
                    );

                return SQL_POSTGRE;
        }
    }
}
