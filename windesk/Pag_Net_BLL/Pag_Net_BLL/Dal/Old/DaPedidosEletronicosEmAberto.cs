using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Xml;
using System.IO;
using System.Linq;
using Pag_Net.Models;
using Pag_Net.Dal;
using System.Reflection;

namespace Pag_Net.Dal
{
    public class DaPedidosEletronicosEmAberto
    {

        private modelSistemaUsuario MyConnect;
        public DaPedidosEletronicosEmAberto(modelSistemaUsuario myConnect)
        {
            MyConnect = myConnect;
        }
        public ModelTbPedidosEletronicosEmAberto GetPedidosEletronicosEmAberto()
        {
            ModelTbPedidosEletronicosEmAberto pedidosEletronicosEmAberto = new ModelTbPedidosEletronicosEmAberto();
            SqlCommand sqlCommandPedEleAberto = new SqlCommand("prPedidosEletronicosEmAberto");

            try
            {

                dalConnectX dalx = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, sqlCommandPedEleAberto, IsolationLevel.RepeatableRead);
                DataSet dtsetpedidosEmAberto = dalx.DataSet_Select();
                dalx.Close();

                List<TbPedidos> tbpedidos = new List<TbPedidos>();
                List<TbItens> tbItens = new List<TbItens>();

                if (dtsetpedidosEmAberto.Tables[0].Rows.Count > 0 && dtsetpedidosEmAberto.Tables[1].Rows.Count > 0)
                {
                    for (int item = 0; item <= dtsetpedidosEmAberto.Tables[0].Rows.Count - 1; item++)
                    {
                        tbpedidos.Add(new TbPedidos(dtsetpedidosEmAberto.Tables[0].Rows[item]["NU_PED_E"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["CD_CLIEN"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["DT_PED"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["DT_PREV_FATU"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["DT_ENTREGA"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["FORMPGTO"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["CD_TABELA"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["SEQ_PROM"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["TP_ENTREGA"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["TP_PED"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["TP_FRETE"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["NU_PED_CLI"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["MSG_CREDITO"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["MSG_COMERCIAL"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["MSG_ADM"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["MSG_FATUR"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["MSG_EXPEDICAO"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["DT_PED_HORA"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["CD_VEND"].ToString(),
                                          dtsetpedidosEmAberto.Tables[0].Rows[item]["NU_PED_LOCAL"].ToString()));
                    }
                    for (int item = 0; item <= dtsetpedidosEmAberto.Tables[1].Rows.Count - 1; item++)
                    {
                        tbItens.Add(new TbItens(dtsetpedidosEmAberto.Tables[1].Rows[item]["NU_PED_E"].ToString(),
                                                      dtsetpedidosEmAberto.Tables[1].Rows[item]["CD_VEND"].ToString(),
                                                      dtsetpedidosEmAberto.Tables[1].Rows[item]["NU_PED_LOCAL"].ToString(),
                                                      dtsetpedidosEmAberto.Tables[1].Rows[item]["CD_PROD"].ToString(),
                                                      dtsetpedidosEmAberto.Tables[1].Rows[item]["UNID_PED"].ToString(),
                                                      dtsetpedidosEmAberto.Tables[1].Rows[item]["QTDE"].ToString(),
                                                      dtsetpedidosEmAberto.Tables[1].Rows[item]["PRECO_UNIT"].ToString(),
                                                      dtsetpedidosEmAberto.Tables[1].Rows[item]["PRECO_TABELA"].ToString(),
                                                      dtsetpedidosEmAberto.Tables[1].Rows[item]["DESC_APL"].ToString(),
                                                      dtsetpedidosEmAberto.Tables[1].Rows[item]["VL_VERBA"].ToString(),
                                                      dtsetpedidosEmAberto.Tables[1].Rows[item]["BONIFICADO"].ToString()));
                    }
                    pedidosEletronicosEmAberto.ArrayListItens = tbItens.ToArray();
                    pedidosEletronicosEmAberto.ArrayListPedidos = tbpedidos.ToArray();
                    return pedidosEletronicosEmAberto;
                }
                else
                {
                    return new ModelTbPedidosEletronicosEmAberto();
                }


            }

            catch (Exception ex)
            {
                throw new Exception("ERRO NA LEITURA: " + ex.Message.ToString());
            }


        }
        public void UpdateStatusAll(ModelTbPedidosEletronicosEmAberto tbPedidosEletronicosEmAberto)
        {
            if (Convert.ToInt32(tbPedidosEletronicosEmAberto.ArrayListPedidos.Count()) > 0)
            {
                List<TbPedidos> tbPedidosEmAberto = tbPedidosEletronicosEmAberto.ArrayListPedidos.ToList();
                for (int i = 0; i <= tbPedidosEmAberto.Count - 1; i++)
                {
                    string strNu_Ped = "";
                    string strCd_Vend = "";
                    string strNu_Ped_Local = "";
                    string strCd_Clien = "";


                    strNu_Ped = tbPedidosEmAberto[i].Id.ToString().Trim();
                    strCd_Vend = tbPedidosEmAberto[i].Cd_Vend.ToString().Trim();
                    strNu_Ped_Local = tbPedidosEmAberto[i].Nu_Ped_local.Trim();
                    strCd_Clien = tbPedidosEmAberto[i].Cd_Clien.ToString();

                    SqlCommand sqlCommandPedEleAberto = new SqlCommand("prPedidosEletronicosEmAberto");
                    sqlCommandPedEleAberto.CommandType = CommandType.StoredProcedure;
                    sqlCommandPedEleAberto.Parameters.AddWithValue("@processo", "UPDATE");
                    sqlCommandPedEleAberto.Parameters.AddWithValue("@NU_PED_E", strNu_Ped.ToString());
                    sqlCommandPedEleAberto.Parameters.AddWithValue("@Cd_vend", strCd_Vend.ToString());
                    sqlCommandPedEleAberto.Parameters.AddWithValue("@Nu_ped_local", strNu_Ped_Local.ToString());
                    sqlCommandPedEleAberto.Parameters.AddWithValue("@Cd_clien", strCd_Clien.ToString());

                    dalConnectX dalx = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, sqlCommandPedEleAberto, IsolationLevel.RepeatableRead);

                    int RecordAffected = dalx.SqlExecuteCommandClosed();

                    if (RecordAffected > 0)
                        tbPedidosEletronicosEmAberto.ArrayListPedidos[i].StatusExportEletronico = "1";

                }
            }
        }
    }
}
