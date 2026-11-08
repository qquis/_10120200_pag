using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0020_Produto;


namespace Pag_Net.src.F0020_Produto 
{
    public class _index
    {
        public reports._indexReport reports;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public _index(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            
            MyConnect = _MyConnect;
            reports = new reports._indexReport(MyConnect);
        }
    }
}

namespace Pag_Net.Bll.F0020_Produto
{
    public class WkProduto
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public int sis_ac_cd = 0;

        public Defaut_Filter filters_produto;
        public DataTable DataTable_Produto;
        public Model_Produto[] Dt_Produto;
        public Model_ProdutoEmbalagem[] Dt_ProdutoEmbalagem;
        public Model_ProdutoEmbalagemGtins[] Dt_ProdutoEmbalagem_Gtins;



        public WkProduto(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            filters_produto = new Defaut_Filter();
        }
        public DataTable ProdutoEmbalagem_List_Get(int pr_cdproduto, int prb_cdprodutobluesoft, string  preg_cdbarra)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect,  F0020_55_ProdutoEmbalagem_List.Get(pr_cdproduto, prb_cdprodutobluesoft, preg_cdbarra));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void Consultar()
        {
            try
            {
                List<Model_Produto> _list = new List<Model_Produto>();
                DataTable_Produto = BDCommand.get_DataTable(MyConnect, F0020_10_ProdutoConsultar.Get(MyConnect, filters_produto));
                foreach (DataRow dr in DataTable_Produto.Rows)
                {
                    _list.Add(new Model_Produto(dr));
                }
                Dt_Produto = _list.ToArray();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarEmbalagens()
        {
            try
            {
                List<Model_ProdutoEmbalagem> _list = new List<Model_ProdutoEmbalagem>();
                DataTable DataTable_Produto = BDCommand.get_DataTable(MyConnect, F0020_11_PodutoEmbalagem_Consultar.Get(MyConnect, filters_produto));
                foreach (DataRow dr in DataTable_Produto.Rows)
                {
                    _list.Add(new Model_ProdutoEmbalagem(dr));
                }
                Dt_ProdutoEmbalagem = _list.ToArray();


            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Produto.Consultar" + ex.Message);
            }
        }

        public void ConsultarGetins()
        {
            try
            {
                List<Model_ProdutoEmbalagemGtins> _list = new List<Model_ProdutoEmbalagemGtins>();
                DataTable DataTable_Produto = BDCommand.get_DataTable(MyConnect, F0020_12_ProdutoEmbalagemGtins_Consultar.Get(MyConnect, filters_produto));
                foreach (DataRow dr in DataTable_Produto.Rows)
                {
                    _list.Add(new Model_ProdutoEmbalagemGtins(dr));
                }
                Dt_ProdutoEmbalagem_Gtins = _list.ToArray();


            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Produto.Consultar" + ex.Message);
            }
        }

    }
   
    public class WkComplementos: WkProduto
    {
        public Pag_Net.src.F0020_Produto.tbs.TbProdutoSecaoEncarregado[] Secao_Encarregado;
        public Pag_Net.Bll.F0011_Participante.ModelParticipante[] Encarregados;

        Pag_Net.src.F0020_Produto.tbs.TbProdutoSecaoEncarregado[] All_Produto_Secao_Encarregados;
        public WkComplementos(Pag_Net.Models.modelSistemaUsuario _MyConnect, int vsis_ac_cd): base(_MyConnect)
        {
            base.sis_ac_cd = vsis_ac_cd;
            DataTable DatatableProduto_Secao_Encarregado = BDCommand.get_DataTable(MyConnect, Pag_Net.Bll.F0020_Produto.F0020_21_ProdutoSecaoEncarregadoConsultar.Get(MyConnect, base.sis_ac_cd));
            List<Pag_Net.src.F0020_Produto.tbs.TbProdutoSecaoEncarregado> List_TbProduto_Secao_Encarregado = new List<Pag_Net.src.F0020_Produto.tbs.TbProdutoSecaoEncarregado>();
            foreach( DataRow i in DatatableProduto_Secao_Encarregado.Rows )
            {
                List_TbProduto_Secao_Encarregado.Add(new Pag_Net.src.F0020_Produto.tbs.TbProdutoSecaoEncarregado(i));
            }
            All_Produto_Secao_Encarregados = List_TbProduto_Secao_Encarregado.ToArray();

        }
        public Pag_Net.src.F0020_Produto.tbs.TbProdutoSecaoEncarregado[] DataBindings_Secao_Encarregado(int em_cdempresa, int op_cdoperacao)
        {
            Secao_Encarregado = (from t in this.All_Produto_Secao_Encarregados
                    where (t.em_cdempresa == (em_cdempresa > 0 ? em_cdempresa : t.em_cdempresa))
                    where (t.op_cdoperacao == (op_cdoperacao > 0 ? op_cdoperacao : t.op_cdoperacao))
                    select t).ToArray();
            return Secao_Encarregado;
        }

        public Pag_Net.Bll.F0011_Participante.ModelParticipante[] DataBindings_Encarregados(int em_cdempresa, int op_cdoperacao)
        {
            DataBindings_Secao_Encarregado(em_cdempresa, op_cdoperacao);
            var GroupBy_List = (from t in Secao_Encarregado
                                group t by new { t.cdpessoabluesoft, t.nome_razao } into TabGroupBy
                                select new { TabGroupBy.Key.cdpessoabluesoft, TabGroupBy.Key.nome_razao });
            List<Pag_Net.Bll.F0011_Participante.ModelParticipante> _list = new List<Pag_Net.Bll.F0011_Participante.ModelParticipante>();
            if (GroupBy_List.Count() > 1)
            {
                _list.Add(new Pag_Net.Bll.F0011_Participante.ModelParticipante(0, "TODOS"));
            }
            foreach (var i in GroupBy_List)
            {
                _list.Add(new Pag_Net.Bll.F0011_Participante.ModelParticipante(i.cdpessoabluesoft, i.nome_razao));
            }
            Encarregados = _list.ToArray();
            return Encarregados;
        }



    }
    
    public class WKDepto
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        private DataTable DtTable_Depto;
        public Model_Local_Departamento[] ListDepto;

        public Model_Local_Departamento[] Departamento()
        {


            var GroupBy_List = (from t in ListDepto
                                group t by new { t.prd_cddepartamento, t.prd_descricao } into TabDepartamento
                                select new { TabDepartamento.Key.prd_cddepartamento, TabDepartamento.Key.prd_descricao });
            List<Model_Local_Departamento> _list = new List<Model_Local_Departamento>();
            if (GroupBy_List.Count() > 1)
            {
                _list.Add(new Model_Local_Departamento());
            }
            foreach (var i in GroupBy_List)
            {
                _list.Add(new Model_Local_Departamento(i.prd_cddepartamento, i.prd_descricao, 0, "", 0, "", 0, ""));
            }
            return _list.ToArray();

        }
        public Model_Local_Departamento[] Secao(int _prd_cddepartamento)
        {



            var GroupBy_List = (from t in ListDepto
                                orderby t.prs_descricao ascending
                                group t by new { t.prd_cddepartamento, t.prd_descricao, t.prs_cdsecao, t.prs_descricao } into TabDepartamento
                                select new { TabDepartamento.Key.prd_cddepartamento, TabDepartamento.Key.prd_descricao, TabDepartamento.Key.prs_cdsecao, TabDepartamento.Key.prs_descricao });

            if (_prd_cddepartamento > 0)
            {
                GroupBy_List = GroupBy_List.Where(x => x.prd_cddepartamento == _prd_cddepartamento);
            }




            List<Model_Local_Departamento> _list = new List<Model_Local_Departamento>();
            if (GroupBy_List.Count() > 1)
            {
                _list.Add(new Model_Local_Departamento());
            }
            foreach (var i in GroupBy_List)
            {
                _list.Add(new Model_Local_Departamento(i.prd_cddepartamento, i.prd_descricao, i.prs_cdsecao, i.prs_descricao, 0, "", 0, ""));
            }
            return _list.ToArray();

        }
        public Model_Local_Departamento[] Grupo(int _prd_cddepartamento, int _prs_cdsecao)
        {
            var GroupBy_List = (from t in ListDepto
                                orderby t.prg_descricao ascending
                                group t by new
                                {
                                    t.prd_cddepartamento,
                                    t.prd_descricao,
                                    t.prs_cdsecao,
                                    t.prs_descricao,
                                    t.prg_cdgrupo,
                                    t.prg_descricao
                                } into Tab
                                select new
                                {
                                    Tab.Key.prd_cddepartamento,
                                    Tab.Key.prd_descricao,
                                    Tab.Key.prs_cdsecao,
                                    Tab.Key.prs_descricao,
                                    Tab.Key.prg_cdgrupo,
                                    Tab.Key.prg_descricao
                                });

            if (_prd_cddepartamento > 0)
            {
                GroupBy_List = GroupBy_List.Where(
                    x => x.prd_cddepartamento == _prd_cddepartamento);
            }

            if (_prs_cdsecao > 0)
            {
                GroupBy_List = GroupBy_List.Where(
                    x => x.prs_cdsecao == _prs_cdsecao);
            }




            List<Model_Local_Departamento> _list = new List<Model_Local_Departamento>();
            if (GroupBy_List.Count() > 1)
            {
                _list.Add(new Model_Local_Departamento());
            }
            foreach (var i in GroupBy_List)
            {
                _list.Add(new Model_Local_Departamento(i.prd_cddepartamento, i.prd_descricao, i.prs_cdsecao, i.prs_descricao, i.prg_cdgrupo, i.prg_descricao, 0, ""));
            }
            return _list.ToArray();

        }
        public Model_Local_Departamento[] SubGrupo(int _prd_cddepartamento, int _prs_cdsecao, int _prg_cdgrupo)
        {
            var GroupBy_List = (from t in ListDepto
                                orderby t.prsg_descricao ascending
                                select new
                                {
                                    t.prd_cddepartamento,
                                    t.prd_descricao,
                                    t.prs_cdsecao,
                                    t.prs_descricao,
                                    t.prg_cdgrupo,
                                    t.prg_descricao,
                                    t.prsg_cdsubgrupo,
                                    t.prsg_descricao
                                });

            if (_prd_cddepartamento > 0)
            {
                GroupBy_List = GroupBy_List.Where(
                    x => x.prd_cddepartamento == _prd_cddepartamento);
            }

            if (_prs_cdsecao > 0)
            {
                GroupBy_List = GroupBy_List.Where(
                    x => x.prs_cdsecao == _prs_cdsecao);
            }

            if (_prg_cdgrupo > 0)
            {
                GroupBy_List = GroupBy_List.Where(
                    x => x.prg_cdgrupo == _prg_cdgrupo);
            }


            List<Model_Local_Departamento> _list = new List<Model_Local_Departamento>();
            if (GroupBy_List.Count() > 1)
            {
                _list.Add(new Model_Local_Departamento());
            }
            foreach (var i in GroupBy_List)
            {
                _list.Add(new Model_Local_Departamento(i.prd_cddepartamento, i.prd_descricao, i.prs_cdsecao, i.prs_descricao, i.prg_cdgrupo, i.prg_descricao, i.prsg_cdsubgrupo, i.prsg_descricao));
            }
            return _list.ToArray();
        }

        public WKDepto(Pag_Net.Models.modelSistemaUsuario _myConnect, int vsis_cd_ac)
        {
            MyConnect = _myConnect;
            DtTable_Depto = Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, F0020_21_ProdutoDepartamentoConsultar.Get(MyConnect, vsis_cd_ac));
            List<Model_Local_Departamento> _list = new List<Model_Local_Departamento>();
            foreach (DataRow dr in DtTable_Depto.Rows)
            {
                _list.Add(new Model_Local_Departamento(dr));
            }
            ListDepto = _list.ToArray();
        }
    }

    public class Defaut_Filter
    {
        public Defaut_Filter() { constructor(); }
        public Defaut_Filter(int _pr_cdproduto)
        {
            constructor();
            CdProduto = _pr_cdproduto.ToString();
        }

        private void constructor()
        {
            this.Dt_cadastro_ini = Convert.ToDateTime("1900-01-01");
            this.Dt_cadastro_fim = Convert.ToDateTime("1900-01-01");
        }


        private string _vcdproduto = "0";
        public string CdProduto
        {
            get { return _vcdproduto; }
            set { try { if (Convert.ToInt32(value) > 0) _vcdproduto = value.ToString(); else _vcdproduto = "0"; } catch (Exception ex) { throw new Exception("Valor inválido: " + ex.Message); } }
        }


        private string vcdprodutobluesoft = "0";
        public string CdProdutoBluesoft
        {
            get { return vcdprodutobluesoft; }
            set { try { if (Convert.ToInt32(value) > 0) vcdprodutobluesoft = value.ToString(); else vcdprodutobluesoft = "0"; } catch (Exception ex) { throw new Exception("Valor inválido: " + ex.Message); } }
        }


        private string _vdescricao = "";
        public string Descricao
        {
            get { return _vdescricao; }
            set { try { if (value != string.Empty) _vdescricao = value.ToString().Replace("'", "").ToUpper(); else _vdescricao = ""; } catch (Exception ex) { throw new Exception("Valor inválido: " + ex.Message); } }
        }


        private string _vdescricao_fiscal = "";
        public string Descricao_Fiscal
        {
            get { return _vdescricao; }
            set { try { if (value != string.Empty) _vdescricao_fiscal = value.ToString().Replace("'", "").ToUpper(); else _vdescricao_fiscal = ""; } catch (Exception ex) { throw new Exception("Valor inválido: " + ex.Message); } }
        }

        public DateTime Dt_cadastro_ini { get; set; }
        public DateTime Dt_cadastro_fim { get; set; }

        public bool Seleciona_Data_Cadastro { get; set; }

        public bool Status_Ativo { get; set; }
        public bool Status_Inativo { get; set; }


        public int Prd_cddepartamento { get; set; }
        public int Prd_cdsecao { get; set; }
        public int Prd_cdgrupo { get; set; }
        public int Prd_subcdgrupo { get; set; }

        private string _Codigo_de_Barra = "";
        public string Codigo_de_Barra
        {
            get { return _Codigo_de_Barra; }
            set
            {
                try
                {
                    if (value.Where(c => char.IsLetter(c)).Count() > 0)
                    {
                        throw new Exception("Valor inválido");
                    }
                    else
                    {
                        _Codigo_de_Barra = value.Trim();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

        public void _ValidarFiltros()
        {
            int validate_cdproduto = Convert.ToInt32(CdProduto);
            int validate_cdprodutobluesoft = Convert.ToInt32(CdProdutoBluesoft);
            string validate_descricao = Descricao;
            DateTime validate_dt_cadastro_ini = DateTime.Now;
            DateTime validate_dt_cadastro_fim = DateTime.Now;
            if (Seleciona_Data_Cadastro)
            {
                if (Dt_cadastro_ini > Dt_cadastro_fim)
                {
                    throw new Exception("Período informado para a busca pela data de cadatro incorreto: Data inicial maior que a final");
                }
            }
            else
            {
                Dt_cadastro_ini = DateTime.Now;
                Dt_cadastro_fim = DateTime.Now;
            }
        }


    }

    public class Model_Produto : Pag_Net.src.F0020_Produto.tbs.TbProduto
    {
        public Model_Produto() : base() 
        { 
        
        }
        public Model_Produto(DataRow i)
            : base(i)
        {

        }
    }
    public class Model_ProdutoEmbalagem : Pag_Net.src.F0020_Produto.tbs.TbProdutoEmbalagem
    {

        public Model_ProdutoEmbalagem(DataRow i) : base(i)  {   }
    }
    public class Model_ProdutoEmbalagemGtins : Pag_Net.src.F0020_Produto.tbs.TbProdutoEmbalagemGtins
    {
        public Model_ProdutoEmbalagemGtins(DataRow i) : base(i) { }
    }
    public class Model_Local_Departamento
    {


        public int prd_cddepartamento { get; set; }
        public string prd_descricao { get; set; }
        public int prs_cdsecao { get; set; }
        public string prs_descricao { get; set; }
        public int prg_cdgrupo { get; set; }
        public string prg_descricao { get; set; }

        public int prsg_cdsubgrupo { get; set; }
        public string prsg_descricao { get; set; }

        public Model_Local_Departamento()
        {
            prd_cddepartamento = 0;
            prd_descricao = "*SELECIONE*";
            prs_cdsecao = 0;
            prs_descricao = "*SELECIONE*";
            prg_cdgrupo = 0;
            prg_descricao = "*SELECIONE*";
            prsg_cdsubgrupo = 0;
            prsg_descricao = "*SELECIONE*";
        }

        public Model_Local_Departamento(
                                int _prd_cddepartamento
                               , string _prd_descricao
                               , int _prs_cdsecao
                               , string _prs_descricao
                               , int _prg_cdgrupo
                               , string _prg_descricao
                               , int _prsg_cdsubgrupo
                               , string _prsg_descricao
                        )
        {
            prd_cddepartamento = _prd_cddepartamento;
            prd_descricao = _prd_descricao;
            prs_cdsecao = _prs_cdsecao;
            prs_descricao = _prs_descricao;
            prg_cdgrupo = _prg_cdgrupo;
            prg_descricao = _prg_descricao;
            prsg_cdsubgrupo = _prsg_cdsubgrupo;
            prsg_descricao = _prsg_descricao;
        }


        public Model_Local_Departamento(DataRow i)
        {
            prd_cddepartamento = Convert.ToInt32(i["prd_cddepartamento"].ToString());
            prd_descricao = i["prd_descricao"].ToString();
            prs_cdsecao = Convert.ToInt32(i["prs_cdsecao"].ToString());
            prs_descricao = i["prs_descricao"].ToString();

            prg_cdgrupo = Convert.ToInt32(i["prg_cdgrupo"].ToString());
            prg_descricao = i["prg_descricao"].ToString();

            prsg_cdsubgrupo = Convert.ToInt32(i["prsg_cdsubgrupo"].ToString());
            prsg_descricao = i["prsg_descricao"].ToString();

        }
    }
  
}
