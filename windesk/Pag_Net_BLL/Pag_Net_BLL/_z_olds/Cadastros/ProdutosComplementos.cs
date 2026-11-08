using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Pag_Net.Bll.Cadastros
{
    public class ProdutosComplementos
    {

        private DeptoSecaoLinha DeptoSecaoLinha { get; set; }
        private Departamento[] _Departamento;
        public Departamento[] Departamento 
        {
            get
            {
                return _Departamento;
            }
            set
            {
                if (value != null)
                {
                    _Departamento = value;
                }
            }
                
        }
        public Secao[] Secao { get; set; }
        public Linha[] Linha { get; set; }


        private string _CdProdutoDepartamentoSelecionado;
        public string CdProdutoDepartamentoSelecionado
        {
            get
            {
                if (_CdProdutoDepartamentoSelecionado == null)
                {
                    return "";
                }
                else
                {
                    return _CdProdutoDepartamentoSelecionado;
                }
            }
            set
            {
                if (value != null)
                {
                    _CdProdutoDepartamentoSelecionado = value;
                    FillSecao(_CdProdutoDepartamentoSelecionado );
                    FillLinha(_CdProdutoDepartamentoSelecionado, CdProdutoSecaoSelecionada);
                }

            }
        }
        private string _CdProdutoSecaoSelecionada;
        public string CdProdutoSecaoSelecionada 
        {
            get
            {
                if (_CdProdutoSecaoSelecionada == null)
                {
                    return "";
                }
                else
                {
                    return _CdProdutoSecaoSelecionada;
                }
            }
            set
            {
                if (value != null)
                {
                    _CdProdutoSecaoSelecionada = value;
                    FillLinha(CdProdutoDepartamentoSelecionado, _CdProdutoSecaoSelecionada);
                }
            }
        }
        
        public ProdutosComplementos(Models.modelSistemaUsuario _myConnect) 
        {
            DeptoSecaoLinha = new DeptoSecaoLinha(_myConnect);

            DeptoSecaoLinha.Select();
            FillDepartamento();
            FillSecao("");
            FillLinha("", "");
        }

        

        private void FillDepartamento()
        {

            UVWProdutoComplementoDeptoSecaoLinha[] List = (UVWProdutoComplementoDeptoSecaoLinha[])DeptoSecaoLinha.ViewData;


            var TempTbDepartamento = (from t in List
                                     group t by new { t.CdProdutoDepartamento, t.DescricaoDepartamento } into TabDepartamento
                                     select new { TabDepartamento.Key.CdProdutoDepartamento, TabDepartamento.Key.DescricaoDepartamento });


          
                List<Departamento> ListaDepartamento = new List<Departamento>();
                if (TempTbDepartamento.Count() > 1)
                {
                    ListaDepartamento.Add(new Departamento("", ""));
                }
            foreach (var i in TempTbDepartamento)
            {
                ListaDepartamento.Add(new Departamento(i.CdProdutoDepartamento, i.DescricaoDepartamento ));
            }
            Departamento = ListaDepartamento.ToArray();
        }
        private void FillSecao(string _cdProdutoDepartamento)
        {
            UVWProdutoComplementoDeptoSecaoLinha[] List = (UVWProdutoComplementoDeptoSecaoLinha[])DeptoSecaoLinha.ViewData;
            var TempTbSecao = (from t in List
                              group t by new { t.CdProdutoDepartamento, t.CdProdutoSecao, t.DescricaoSecao } into TabSecao
                              select new { TabSecao.Key.CdProdutoDepartamento, TabSecao.Key.CdProdutoSecao, TabSecao.Key.DescricaoSecao });
            List<Secao> ListaSecao = new List<Secao>();
            if (TempTbSecao.Count() > 1)
            {
                ListaSecao.Add(new Secao("", ""));
            }
            foreach (var x in TempTbSecao)
            {
                if (_cdProdutoDepartamento.Trim() != "")
                {
                    if (x.CdProdutoDepartamento == _cdProdutoDepartamento)
                    {
                        ListaSecao.Add(new Secao(x.CdProdutoSecao, x.DescricaoSecao));
                    }
                }

                else
                {
                    ListaSecao.Add(new Secao(x.CdProdutoSecao, x.DescricaoSecao));
                }
            }
            Secao = ListaSecao.ToArray();
            //cmbSecao.ItemsSource = Pag_Net.Bll.Tables.bllTbSecao.GetList(MyConnection, ((ModelTbDepartamento)cmbDepartamento.SelectedItem).CodigoDepartamento);

        }
        private void FillLinha(string _cdProdutoDepartamento, string _cdProdutoSecao)
        {
            UVWProdutoComplementoDeptoSecaoLinha[] List = (UVWProdutoComplementoDeptoSecaoLinha[])DeptoSecaoLinha.ViewData;
            var TempTbLinha = (from t in List group t by new { t.CdProdutoDepartamento, t.CdProdutoSecao, t.CdProdutoLinha, t.DescricaoLinha } 
                                   into TabLinha
                              select new { TabLinha.Key.CdProdutoDepartamento, TabLinha.Key.CdProdutoSecao, TabLinha.Key.CdProdutoLinha, TabLinha.Key.DescricaoLinha });
            List<Linha> ListaLinha = new List<Linha>();
            if (TempTbLinha.Count() > 1)
            {
                ListaLinha.Add(new Linha("", ""));
            }
            foreach (var x in TempTbLinha)
            {
                if (x.CdProdutoLinha == "") ListaLinha.Add(new Linha(x.CdProdutoLinha, x.DescricaoLinha));
                if (x.CdProdutoLinha != "")
                {
                    if (_cdProdutoDepartamento.Trim() != "" && _cdProdutoSecao.Trim() != "")
                    {
                        if (x.CdProdutoDepartamento == _cdProdutoDepartamento && x.CdProdutoSecao == _cdProdutoSecao) ListaLinha.Add(new Linha(x.CdProdutoLinha, x.DescricaoLinha));
                    }
                    if (_cdProdutoDepartamento.Trim() != "" && _cdProdutoSecao.Trim() == "")
                    {
                        if (x.CdProdutoDepartamento == _cdProdutoDepartamento) ListaLinha.Add(new Linha(x.CdProdutoLinha, x.DescricaoLinha));
                    }

                    if (_cdProdutoDepartamento.Trim() == "" && _cdProdutoSecao.Trim() != "")
                    {
                        if (x.CdProdutoSecao == _cdProdutoSecao) ListaLinha.Add(new Linha(x.CdProdutoLinha, x.DescricaoLinha));
                    }

                    if (_cdProdutoDepartamento.Trim() == "" && _cdProdutoSecao.Trim() == "")
                    {
                        ListaLinha.Add(new Linha(x.CdProdutoLinha, x.DescricaoLinha));
                    }
                }
            }
            Linha = ListaLinha.ToArray();
        }
    }
    public class Departamento
    {
        public string CdProdutoDepartamento { get; set; }
        public string DescricaoDepartamento { get; set; }
        public Departamento() { }
        public Departamento(string cdProdutoDepartamento, string descricaodepartamento)
        {
            this.CdProdutoDepartamento = cdProdutoDepartamento;
            this.DescricaoDepartamento = descricaodepartamento;
        }
    }
    public class Secao
    {
        public string CdProdutoSecao { get; set; }
        public string DescricaoSecao { get; set; }
        public string CdProdutoDepartamento { get; set; }
        public Secao() { }
        public Secao( string _cdProdutoSecao, string _descricaoSecao) 
        {
            this.CdProdutoSecao = _cdProdutoSecao;
            this.DescricaoSecao = _descricaoSecao;

        }
    }
    public class Linha
    {
        public string CdProdutoLinha { get; set; }
        public string DescricaoLinha { get; set; }
        public Linha() { }
        public Linha(string _cdProdutoLinha, string _descricaoLinha) 
        {
            this.CdProdutoLinha = _cdProdutoLinha;
            this.DescricaoLinha = _descricaoLinha;
        }
    }
}
