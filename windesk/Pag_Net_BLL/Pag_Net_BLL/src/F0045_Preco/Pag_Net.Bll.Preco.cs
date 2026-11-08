using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0045_Preco
{

    public enum F0045_10_PrecoAplicacao_Option
    {
        LOG_BLUE_ALL = 0,
        LOG_BLUE_D1 = 1,
        CUSTOM = 2
    }
    public enum F0045_10_PrecoAplicacao_OptionProduto_Unitario
    {
        UNITARIO = 0,
        ASSOCIADO = 1,
        TODOS = 2
    }
    public class filter
    {
        public int tab_pre_cd  {get; set; }
        public int data_log_filter {get;set; }
        public DateTime data_log_ini {get; set; }
        public DateTime data_log_fim {get; set; }
        public int pr_cdproduto {get; set; }
        public int prb_cdprodutobluesoft_unitario {get; set; }
        public int prb_cdprodutobluesoft {get; set; }
        public string pr_descricao {get; set; }
        public string prb_descricao {get; set; }

        public filter () 
        {
            tab_pre_cd = 1; 
            data_log_filter = 1; 
            data_log_ini = DateTime.Now; 
            data_log_fim = DateTime.Now; 
            pr_cdproduto = 0; 
            prb_cdprodutobluesoft_unitario = 0; 
            prb_cdprodutobluesoft = 0; 
            pr_descricao = ""; 
            prb_descricao = ""; 

        }

    }


    public class Wk
    {
        public Pag_Net.Models.TbSysUserInfo MyConnect;
        public Wk(Pag_Net.Models.TbSysUserInfo _MyConnect)
        {
            MyConnect = _MyConnect;
        }
        public void BlueSoft_Update(int Filtrar_Data_Alteracao)
        {

            try
            {
                src.F9030_sistemabatch.wk wk = new src.F9030_sistemabatch.wk(MyConnect);
                //wk.NewRunFromBatch(45011);

                if (Filtrar_Data_Alteracao == 0) wk.NewRunFromBatch(45011); //Alteração dos registros D1
                if (Filtrar_Data_Alteracao == 1) wk.NewRunFromBatch(45021); //Alteração dos registros ALL
      
   

                /*

                F0045_10_PrecoAplicacao_Option TipoRelatorio = F0045_10_PrecoAplicacao_Option.LOG_BLUE_D1;
                if (Filtrar_Data_Alteracao == 1) TipoRelatorio = F0045_10_PrecoAplicacao_Option.LOG_BLUE_ALL;
               
                filter FilterPrecos = new filter(); 
                FilterPrecos.tab_pre_cd = 1; 
                FilterPrecos.data_log_filter = 1; 
                FilterPrecos.data_log_ini = DateTime.Now;
                FilterPrecos.data_log_fim = DateTime.Now;
               
                DataTable DT = Report_F045_10_Preco_Aplicacao_list.DataTableGet(MyConnect, FilterPrecos, TipoRelatorio, F0045_10_PrecoAplicacao_OptionProduto_Unitario.UNITARIO);


                foreach (DataRow ITEM in DT.Rows)
                {

                    int prb_cdprodutobluesoft = Convert.ToInt32(ITEM["prb_cdprodutobluesoft"].ToString());
                    double prc_valor = Convert.ToDouble(ITEM["prc_valor"].ToString());

                    string url = string.Format("{0}/preco/get/blue_update_export?prb_cdprodutobluesoft={1}&prc_valor={2}",
                        MyConnect.PAG_API,
                        prb_cdprodutobluesoft.ToString(), 
                        prc_valor.ToString("0.00").Replace(",", ".")
                        );

                    Pag_Net.Bll.RESTAPI.post(url, null);
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public static class Report_F045_10_Preco_Aplicacao_list 
    {
        public static DataTable DataTableGet(Pag_Net.Models.TbSysUserInfo MyConnect,
                    Pag_Net.Bll.F0045_Preco.filter Filter,
                    F0045_10_PrecoAplicacao_Option TipoRelatorio,
                    F0045_10_PrecoAplicacao_OptionProduto_Unitario TipoProdutoUnitario
            
            )
        {
            try 
            {
                return BDCommand.get_DataTable(MyConnect, Report_F045_10_Preco_Aplicacao_list.Get(Filter, TipoRelatorio, TipoProdutoUnitario)); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static string Get(
                    Pag_Net.Bll.F0045_Preco.filter Filter,
                    F0045_10_PrecoAplicacao_Option TipoRelatorio,
                    F0045_10_PrecoAplicacao_OptionProduto_Unitario TipoProdutoUnitario
            )
        {

            string vtipo_relatorio = "LOG_BLUE_D1";

            switch (TipoRelatorio)
            {
                case F0045_10_PrecoAplicacao_Option.LOG_BLUE_ALL:
                    vtipo_relatorio = "LOG_BLUE_ALL";
                    break;
                case F0045_10_PrecoAplicacao_Option.LOG_BLUE_D1:
                    vtipo_relatorio = "LOG_BLUE_D1";
                    break;
                case F0045_10_PrecoAplicacao_Option.CUSTOM:
                    vtipo_relatorio = "CUSTOM";
                    break;
            }
            
            string vtipo_produtounitario = "UNITARIO";
            switch(TipoProdutoUnitario)
            {
                case F0045_10_PrecoAplicacao_OptionProduto_Unitario.UNITARIO:
                    vtipo_produtounitario = "UNITARIO";
                    break;
                case F0045_10_PrecoAplicacao_OptionProduto_Unitario.ASSOCIADO:
                    vtipo_produtounitario = "UNI_ASSOC";
                    break;
                case F0045_10_PrecoAplicacao_OptionProduto_Unitario.TODOS:
                    vtipo_produtounitario = "TODOS";
                    break;
            }
            


            string QUERY_SELECT = "SELECT * FROM " +  F0045_10_Preco_Aplicacao_List._VERSION() + " ( " +
                                  "    vtipo_relatorio:= '" + vtipo_relatorio + "'" +
                                  "  , vtab_pre_cd:= " + Filter.tab_pre_cd.ToString() +
                                  "  , vdata_log_filter:= " + Filter.data_log_filter.ToString() +
                                  "  , vdata_log_ini:= '" + Filter.data_log_ini.ToString("yyyy-MM-dd") + "'" +
                                  "  , vdata_log_fim:= '" + Filter.data_log_ini.ToString("yyyy-MM-dd") + "'" +
                                  "  , vpr_cdproduto:= " + Filter.pr_cdproduto.ToString() +
                                  "  , vprb_cdprodutobluesoft_unitario:= " + Filter.prb_cdprodutobluesoft_unitario.ToString() +
                                  "  , vprb_cdprodutobluesoft:= " + Filter.prb_cdprodutobluesoft.ToString() +
                                  "  , vpr_descricao:= '' " + Filter.pr_descricao.ToString() +
                                  "  , vprb_descricao:= '' " + Filter.prb_descricao.ToString() + 
                                  "  , vtipo_produto:= '" + vtipo_produtounitario.ToString() + "' )";
            return QUERY_SELECT;
        }

    }



 }

