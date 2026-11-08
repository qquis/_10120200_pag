using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0133_Comercial_PedidoBlueSoft
{
    public class Filter
    {
        public int cm_pedblue_cdpessoabluesoft_fornecedor { get; set; }
        public DateTime cm_pedblue_dataemissao_inicial { get; set; }
        public DateTime cm_pedblue_dataemissao_final { get; set; }
        public string cnpj_cnpj { get; set;  }

        public Filter()
        {
            cm_pedblue_cdpessoabluesoft_fornecedor = 0;
            cm_pedblue_dataemissao_inicial = DateTime.Now;
            cm_pedblue_dataemissao_final = DateTime.Now;
            cnpj_cnpj = "";
        }

        public Filter(
            int _cm_pedblue_cdpessoabluesoft_fornecedor,
            DateTime _cm_pedblue_dataemissao_inicial,
            DateTime _cm_pedblue_dataemissao_final,
            string _cnpj_cnpj)
        {
            cm_pedblue_cdpessoabluesoft_fornecedor = cm_pedblue_cdpessoabluesoft_fornecedor;
            cm_pedblue_dataemissao_inicial = _cm_pedblue_dataemissao_inicial;
            cm_pedblue_dataemissao_final = _cm_pedblue_dataemissao_final;
            cnpj_cnpj = _cnpj_cnpj;

        }


    }
    public class WkComercial_PedidoBlueSoft
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Filter filter;
        public Wkdb_Comercial_PedidoBluesot[] List;
        public WkComercial_PedidoBlueSoft(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            filter = new Filter();
        }

        public TbComercial_PedidoBlueSoft[] Consultar()
        {
            DataTable DatatableComercial_PedidoBlueSoft = Tool.DataTableComercial_PedidoBluesoft_List(MyConnect, filter);
            List<Wkdb_Comercial_PedidoBluesot> _list = new List<Wkdb_Comercial_PedidoBluesot>();
            foreach(DataRow i in DatatableComercial_PedidoBlueSoft.Rows)
            {
                _list.Add(new Wkdb_Comercial_PedidoBluesot(i));
            }
            List = _list.ToArray();
            return List;
        }
    }



    public static class Tool
    {
        static public DataTable DataTableComercial_PedidoBluesoft_List(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter _filter)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0133_10_Comercial_PedidoBlusoft_List.Postgre.Get(MyConnect, _filter));
            }
            catch (Exception ex)
            {
                throw new Exception("Produto_Secao_Encarregado_Consultar \n" +
                                    "----------------------------------- \n " +
                                    "Tool \n " +
                                    ex.Message
                            );
            }
        }
    }



    public class Wkdb_Comercial_PedidoBluesot: TbComercial_PedidoBlueSoft
    {
        public string Nome_Razao { get; set; }
        public string cpf_cnpj { get; set; }

        public Wkdb_Comercial_PedidoBluesot()
        {
            Nome_Razao = "";
            cpf_cnpj = "";
        }

        public Wkdb_Comercial_PedidoBluesot(DataRow i)
        {
            cm_pedblue_seq = Convert.ToInt32(i["cm_pedblue_seq"].ToString());
            cm_pedblue_numeropedido = Convert.ToInt32(i["cm_pedblue_numeropedido"].ToString());
            cm_pedblue_dataemissao = Convert.ToDateTime(i["cm_pedblue_dataemissao"].ToString());
            cm_pedblue_datafechamento = Convert.ToDateTime(i["cm_pedblue_datafechamento"].ToString());
            cm_pedblue_dataentregainicial = Convert.ToDateTime(i["cm_pedblue_dataentregainicial"].ToString());
            cm_pedblue_dataentregafinal = Convert.ToDateTime(i["cm_pedblue_dataentregafinal"].ToString());
            cm_pedblue_cdpessoabluesoft_fornecedor = Convert.ToInt32(i["cm_pedblue_cdpessoabluesoft_fornecedor"].ToString());
            cm_pedblue_divisao_cd = Convert.ToInt32(i["cm_pedblue_divisao_cd"].ToString());
            cm_pedblue_status_cd = Convert.ToInt32(i["cm_pedblue_status_cd"].ToString());
            cm_pedblue_status_bluesoft = i["cm_pedblue_status_bluesoft"].ToString();
            Nome_Razao = i["Nome_Razao"].ToString();
            cpf_cnpj = i["cpf_cnpj"].ToString();
        }
    

    }
}
