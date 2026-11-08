using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Cadastros
{
    public class UspProdutoList : Bll.USPDataContext
    {
        public ProdutoFiltros Filtros;
        public UspProdutoList(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new ProdutoFiltros();
            
        }
        public void Select()
        {
            try
            {
                List<UVWProduto> L = new List<UVWProduto>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {

                    UVWProduto l = new UVWProduto();
                    l.CdProduto  = Convert.ToInt32(i["CdProduto"]);
                    l.DataCadastro = Convert.ToDateTime(i["DataCadastro"]);
                    l.Descricao = i["Descricao"].ToString();
                    l.DescricaoDepartamento = i["DescricaoDepartamento"].ToString();
                    l.DescricaoSecao = i["DescricaoSecao"].ToString();
                    l.DescricaoLinha = i["DescricaoLinha"].ToString();
                    l.StatusProduto = Convert.ToBoolean(i["StatusProduto"]);
                    l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                    l.EmbalagemCompra  = i["EmbalagemCompra"].ToString();
                    l.EmbalagemCompraQtdeUnitaria = Convert.ToDouble( i["EmbalagemCompraQtdeUnitaria"].ToString());

                    L.Add(l);
                    index = index + 1;
                }
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("DataCadastro", SqlDbType.Bit, true, this.Filtros.DataCadastro));
            if (this.Filtros.DataCadastro)
            {
                ListParameters.Add(new Models.ParameterQuey("DataCadastroInicial", SqlDbType.DateTime, true, this.Filtros.DataCadastroInicial));
                ListParameters.Add(new Models.ParameterQuey("DataCadastroFinal", SqlDbType.DateTime, true, this.Filtros.DataCadastroFinal));
            }
            ListParameters.Add(new Models.ParameterQuey("StatusProduto", SqlDbType.Bit, true, this.Filtros.StatusProduto));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoDepartamento", SqlDbType.VarChar, true, this.Filtros.CdProdutoDepartamento ));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoSecao", SqlDbType.VarChar, true, this.Filtros.CdProdutoSecao));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoLinha", SqlDbType.VarChar, true, this.Filtros.CdProdutoLinha));
            ListParameters.Add(new Models.ParameterQuey("CdFabricante", SqlDbType.VarChar, true, this.Filtros.CdFabricante));
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, this.Filtros.Descricao));
            ListParameters.Add(new Models.ParameterQuey("Codigos", SqlDbType.VarChar, true, this.Filtros.Codigos));
            ListParameters.Add(new Models.ParameterQuey("SeqProdutoCategoria", SqlDbType.Int , true, this.Filtros.SeqProdutoCategoria ));
            ListParameters.Add(new Models.ParameterQuey("SeqProdutoGestor", SqlDbType.Int, true, this.Filtros.SeqProdutoGestor));

            
            
            return ListParameters.ToArray();
                
        }
        public override string SQLCommnad()
        {
            return "UspProdutoList";
        }

    }

    public class UVWProduto
    {
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public bool StatusProduto {get;set;}
        public string DescricaoDepartamento { get; set; }
        public string DescricaoSecao { get; set; }
        public string DescricaoLinha { get; set; }
        public DateTime DataCadastro { get; set; }
        public string EmbalagemEstoque { get; set; }
        public string EmbalagemCompra { get; set; }
        public double EmbalagemCompraQtdeUnitaria { get; set; }
    }
    public class ProdutoFiltros
    {
        public bool DataCadastro { get; set; }
        public DateTime DataCadastroInicial { get; set; }
        public DateTime DataCadastroFinal { get; set; }
        public bool StatusProduto { get; set; }
        public string CdProdutoDepartamento { get; set; }
        public string CdProdutoSecao { get; set; }
        public string CdProdutoLinha { get; set; }
        public string Descricao { get; set; }
        public string Codigos { get; set; }
        public string CdFabricante { get; set; }
        public int SeqProdutoCategoria { get; set; }
        public int SeqProdutoGestor { get; set; }
    }
}
