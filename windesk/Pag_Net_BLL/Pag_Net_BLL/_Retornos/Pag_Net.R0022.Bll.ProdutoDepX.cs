using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;
using Pag_Net.R0022;
using Pag_Net.R0022.Models;

namespace Pag_Net.R0022.Bll
{
    public class Execute  
    {

        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        private DataTable Dt_Dep_Sec_Grupo_SubGrupo;
        public produto_Dep_Sec_Grupo_SubGrupo[] Dep_Sec_Grupo_SubGrupo;

        public produto_Dep_Sec_Grupo_SubGrupo[] Departamento()
        {
       

                var GroupBy_List = (from t in Dep_Sec_Grupo_SubGrupo
                                    group t by new { t.prd_cddepartamento, t.prd_descricao } into TabDepartamento
                                    select new { TabDepartamento.Key.prd_cddepartamento, TabDepartamento.Key.prd_descricao });
                List<produto_Dep_Sec_Grupo_SubGrupo> _list = new List<produto_Dep_Sec_Grupo_SubGrupo>();
                if (GroupBy_List.Count() > 1)
                {
                    _list.Add(new produto_Dep_Sec_Grupo_SubGrupo());
                }
                foreach (var i in GroupBy_List)
                {
                    _list.Add(new produto_Dep_Sec_Grupo_SubGrupo(i.prd_cddepartamento, i.prd_descricao, 0, "", 0, "", 0, ""));
                }
                return _list.ToArray();
            
        }
        public produto_Dep_Sec_Grupo_SubGrupo[] Secao(int _prd_cddepartamento)
        {



            var GroupBy_List = (from t in Dep_Sec_Grupo_SubGrupo
                                orderby t.prs_descricao ascending
                                               group t by new {t.prd_cddepartamento, t.prd_descricao,   t.prs_cdsecao, t.prs_descricao } into TabDepartamento
                                               select new {TabDepartamento.Key.prd_cddepartamento, TabDepartamento.Key.prd_descricao, TabDepartamento.Key.prs_cdsecao, TabDepartamento.Key.prs_descricao });

            if (_prd_cddepartamento > 0)
            {
                GroupBy_List = GroupBy_List.Where(x => x.prd_cddepartamento == _prd_cddepartamento);
            }

            


            List<produto_Dep_Sec_Grupo_SubGrupo> _list = new List<produto_Dep_Sec_Grupo_SubGrupo>();
            if (GroupBy_List.Count() > 1)
            {
                _list.Add(new produto_Dep_Sec_Grupo_SubGrupo());
            }
            foreach (var i in GroupBy_List)
            {
                _list.Add(new produto_Dep_Sec_Grupo_SubGrupo(i.prd_cddepartamento, i.prd_descricao, i.prs_cdsecao, i.prs_descricao, 0, "", 0, ""));
            }
            return _list.ToArray();

        }

        public produto_Dep_Sec_Grupo_SubGrupo[] Grupo(int _prd_cddepartamento, int _prs_cdsecao) 
        {
            var GroupBy_List = (from t in Dep_Sec_Grupo_SubGrupo
                                orderby t.prg_descricao ascending
                                group t by new { 
                                    t.prd_cddepartamento, 
                                    t.prd_descricao, 
                                    t.prs_cdsecao, 
                                    t.prs_descricao, 
                                    t.prg_cdgrupo, 
                                    t.prg_descricao } into Tab
                                select new { 
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




            List<produto_Dep_Sec_Grupo_SubGrupo> _list = new List<produto_Dep_Sec_Grupo_SubGrupo>();
            if (GroupBy_List.Count() > 1)
            {
                _list.Add(new produto_Dep_Sec_Grupo_SubGrupo());
            }
            foreach (var i in GroupBy_List)
            {
                _list.Add(new produto_Dep_Sec_Grupo_SubGrupo(i.prd_cddepartamento, i.prd_descricao, i.prs_cdsecao, i.prs_descricao, i.prg_cdgrupo, i.prg_descricao, 0, ""));
            }
            return _list.ToArray();

        }
        public produto_Dep_Sec_Grupo_SubGrupo[] SubGrupo(int _prd_cddepartamento, int _prs_cdsecao, int _prg_cdgrupo)
        {
            var GroupBy_List = (from t in Dep_Sec_Grupo_SubGrupo
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


            List<produto_Dep_Sec_Grupo_SubGrupo> _list = new List<produto_Dep_Sec_Grupo_SubGrupo>();
            if (GroupBy_List.Count() > 1)
            {
                _list.Add(new produto_Dep_Sec_Grupo_SubGrupo());
            }
            foreach (var i in GroupBy_List)
            {
                _list.Add(new produto_Dep_Sec_Grupo_SubGrupo(i.prd_cddepartamento, i.prd_descricao, i.prs_cdsecao, i.prs_descricao, i.prg_cdgrupo, i.prg_descricao, i.prsg_cdsubgrupo, i.prsg_descricao));
            }
            return _list.ToArray();
        }
        
        public Execute(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {

            MyConnect = _myConnect;
            Dt_Dep_Sec_Grupo_SubGrupo = _0001_Produto_Dep_Sec_Grupo_SubGrupo();
            
            List<Pag_Net.R0022.Models.produto_Dep_Sec_Grupo_SubGrupo> _list = new List<Models.produto_Dep_Sec_Grupo_SubGrupo>();
            foreach (DataRow dr in Dt_Dep_Sec_Grupo_SubGrupo.Rows )
            {
                _list.Add(new Models.produto_Dep_Sec_Grupo_SubGrupo(dr));
            }
            Dep_Sec_Grupo_SubGrupo = _list.ToArray();

        }

        public DataTable _0001_Produto_Dep_Sec_Grupo_SubGrupo()
        {
            try
            {
                ///select * from r0020_0001_produto(0,0,true, '2021-01-01', '2021-01-31', '','','0','0'  );
                string SQL_POSTGRE = string.Format("select * from r0022_0001_Produto_Dep_Sec_Grupo_SubGrupo()");
                Dt_Dep_Sec_Grupo_SubGrupo = _Select(SQL_POSTGRE);
                return Dt_Dep_Sec_Grupo_SubGrupo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
  
        }

        private DataTable _Select(string _ScriptSQL)
        {
            try
            {
                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, _ScriptSQL, "");
                return DX.Tables[0];
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message.ToString());
            }

        }
    }
}

namespace Pag_Net.R0022.Models
{
    public class produto_Dep_Sec_Grupo_SubGrupo
    {


        public int prd_cddepartamento { get; set; }
        public string prd_descricao { get; set; }
        public int prs_cdsecao { get; set; }
        public string prs_descricao { get; set; }
        public int prg_cdgrupo { get; set; }
        public string prg_descricao { get; set; }

        public int prsg_cdsubgrupo { get; set; }
        public string prsg_descricao { get; set; }

        public produto_Dep_Sec_Grupo_SubGrupo() 
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

        public produto_Dep_Sec_Grupo_SubGrupo(
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


        public produto_Dep_Sec_Grupo_SubGrupo(DataRow i)
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