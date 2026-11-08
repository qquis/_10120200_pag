using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0050_Faturamento_BlueSoft
{

    


    public class _indexReport
    {


        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public Pag_Net.src.F0050_Faturamento_BlueSoft.interfaces.iF0050_FaturamentoFilter filter;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


       

        private DBDataTable __dbList_Faturamento;
        public DBDataTable dbList_Faturamento { 
                get { return __dbList_Faturamento; } 
                set { __dbList_Faturamento = value; 
                        RaisePropertyChanged("dbList_Faturamento"); } }

        private DBDataTable __dbList_Faturamento_Status;
        public DBDataTable dbList_Faturamento_Status
        {
            get { return __dbList_Faturamento_Status; }
            set
            {
                __dbList_Faturamento_Status = value;
                RaisePropertyChanged("dbList_Faturamento_Status");
            }
        }

        
        public _indexReport(Pag_Net.Models.modelSistemaUsuario _MyConnect) { _constructor(_MyConnect); }
        private void _constructor(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            filter = new interfaces.iF0050_FaturamentoFilter();

        }
       


        public void filtroClear()
        {

        }
        public void getFaturamento() 
        {
            try 
            {
               dbList_Faturamento = BDCommand.DBDataTableGet(MyConnect, Sql.Faturamento(filter)); 
            } 
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void getFaturamentoStatus()
        {
            try
            {
                dbList_Faturamento_Status = BDCommand.DBDataTableGet(MyConnect, Sql.Faturamento_Status());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }

    public static class Sql
    {
        public static string Faturamento(Pag_Net.src.F0050_Faturamento_BlueSoft.interfaces.iF0050_FaturamentoFilter filter)
        {
            string sql = "SELECT 		em.em_cdempresa                                    "
                      + "           ,	em.em_descricao                                    "
                      + "           ,	f.op_cdoperacao                                    "
                      + "           ,	op.op_descricao                                    "
                      + "           ,	f.fat_blue_seq                                     "
                      + "           ,	f.numeropedido                                     "
                      + "           ,	f.numeropedido_fv                                  "
                      + "           ,	f.fat_blue_status_cd                               "
                      + "           ,	st.fat_blue_status_descricao                       "
                      + "           ,	f.fat_blue_tipo_cd                                 "
                      + "           ,   tp.fat_blue_tipo_descricao                         "
                      + "           ,	f.cdpessoabluesoft_cliente  as cdpessoabluesoft_cliente  "
                      + "           ,	cb.nome_razao               as cliente_nome_razao        "
                      + "           ,	cp.cdparticipante           as cliente_cdparticipante    "
                      + "           ,	f.cdpessoabluesoft_vendedor                              "
                      + "           ,	f.tabelapreco_cd                                   "
                      + "           ,	vb.nome_razao               as vendedor_nome_razao        "
                      + "           ,	vp.cdparticipante           as vendedor_cdparticipante    "
                      + "           ,	f.tabelapreco_versao_cd                            "
                      + "           ,	f.fv_prazopgto_cd                                  "
                      + "           ,	f.tipo_entrega_descricao                           "
                      + "           ,	f.origem_pedido                                    "
                      + "           ,	f.data_emissao                                     "
                      + "           ,	f.data_faturamento                                 "
                      + "           ,	f.numero_itens                                     "
                      + "           ,	f.valor_pedido                                     "
                      + "           ,	f.valor_faturamento                                "
                      + "           ,	COALESCE(f.transportadora_descricao,'') AS transportadora_descricao "
                      + "           ,	COALESCE(f.transportadora_placaveiculo, '') AS transportadora_placaveiculo "
                      + "   FROM 		tbfaturamento_bluesoft			f "
                      + "   left join 	tboperacao						op on op.op_cdoperacao = f.op_cdoperacao "
                      + "   left join   tbempresa						em on em.em_cdempresa = op.em_cdempresa "
                      + "   left join   tbfaturamento_bluesoft_status   st on st.fat_blue_status_cd = f.fat_blue_status_cd "
                      + "   left join   tbfaturamento_bluesoft_tipo     tp on tp.fat_blue_tipo_cd = f.fat_blue_tipo_cd "
                      + "   left join   tbpessoabluesoft				cb on cb.cdpessoabluesoft = f.cdpessoabluesoft_cliente "
                      + "   left join   tbparticipante_bluesoft         cp on cp.cdpessoabluesoft = f.cdpessoabluesoft_cliente "
                      + "   left join   tbpessoabluesoft                vb on vb.cdpessoabluesoft = f.cdpessoabluesoft_vendedor "
                      + "   left join   tbparticipante_bluesoft         vp on vp.cdpessoabluesoft = f.cdpessoabluesoft_vendedor "
                      + "   where		1 = 1 ";
                      
                      if (filter.em_cdempresa != 0 )
                          sql += " and em.em_cdempresa = " + filter.em_cdempresa.ToString();
                      
                      if (filter.op_cdoperacao != 0)
                          sql += " and op.op_cdoperacao = " + filter.op_cdoperacao.ToString();


                      if (filter.dataPedidoEmissao_filter)
                      {
                          sql += "     and f.data_emissao >= '" + filter.dataPedidoEmissao_ini.ToString("yyyy-MM-dd") + "'";
                          sql += "     and f.data_emissao <= '" + filter.dataPedidoEmissao_fim.ToString("yyyy-MM-dd") + "'";
                      }

                      if (filter.dataFaturamento_filter)
                      {
                          sql += "     and coalesce(f.data_faturamento,'1900-01-01') >= '" + filter.dataFaturamento_ini.ToString("yyyy-MM-dd") + "'";
                          sql += "     and coalesce(f.data_faturamento,'1900-01-01') <= '" + filter.dataFaturamento_fim.ToString("yyyy-MM-dd") + "'";
                      }

                      if (filter.TipoStatusFiltro == "SELECIONAR" && filter.TipoStatusFiltro_fat_blue_status_cd != 0 )
                      {
                          sql += "     and f.fat_blue_status_cd = " + filter.TipoStatusFiltro_fat_blue_status_cd.ToString();
                      }
                      if (filter.TipoStatusFiltro == "ABERTO")
                      {
                          sql += "     and f.fat_blue_status_cd IN (20, 25, 27, 30, 40, 45 ) "; 
                      }

                      if (filter.TipoStatusFiltro == "FATURADO")
                      {
                          sql += "     and f.fat_blue_status_cd IN (50,55,70) ";
                      }


            return sql;
        }

        public static string Faturamento_Status()
        {
            string sql = "Select CAST(0 AS INT) AS fat_blue_status_cd , '* TODOS *' AS fat_blue_status_descricao UNION select fat_blue_status_cd, fat_blue_status_descricao from tbfaturamento_bluesoft_status order by 1 asc";
            return sql;
        }
    }


    public static class DBDataTables
    {

      

    }

    public static class ArrayTabs
    {


    }
}
