using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0002_Enterprise
{
    public class WkEmpresaOperacao
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        
        public F0002_20_Empresa_Operacao_User_consulta.filter Filter_EmpresaOperacao;
        TbOperacao[] List_User_EmpresaOperacao;
        public TbEmpresa[] List_User_Empresa;
        public TbOperacao[] List_User_Operacao;

        public WkEmpresaOperacao (Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Filter_EmpresaOperacao = new F0002_20_Empresa_Operacao_User_consulta.filter(0);
            //EmpresaOperacoes_User_List_DataBindings();

        }
        public void EmpresaOperacoes_User_List_DataBindings()
        {
            try
            {
                List<TbOperacao> _EmpresaOperacao = new List<TbOperacao>();

                DataTable DtEmpresaOperacao = Tool.DataTable_EmpresaOperacao_Consultar(MyConnect, Filter_EmpresaOperacao);
                /*
                if (DtEmpresaOperacao.Rows.Count > 1 )
                {
                    TbOperacao _TbOperacaoPadrao = new TbOperacao();
                    _TbOperacaoPadrao.em_cdempresa = 0;
                    _TbOperacaoPadrao.em_descricao =" TODOS ";
                    _TbOperacaoPadrao.op_cdoperacao = 0;
                    _TbOperacaoPadrao.op_descricao = " TODOS ";
                    _EmpresaOperacao.Add(new TbOperacao());
                }*/

                foreach (DataRow i in Tool.DataTable_EmpresaOperacao_Consultar(MyConnect, Filter_EmpresaOperacao).Rows)
                {
                    _EmpresaOperacao.Add(new TbOperacao(i));
                }
                List_User_EmpresaOperacao =  _EmpresaOperacao.ToArray();

                /*
                    var GroupBy_List = (from t in ListDepto
                                group t by new { t.prd_cddepartamento, t.prd_descricao } into TabDepartamento
                                select new { TabDepartamento.Key.prd_cddepartamento, TabDepartamento.Key.prd_descricao });
                 */

                var GrouByEmpresa = (from t in List_User_EmpresaOperacao
                                     group t by new { t.em_cdempresa, t.em_descricao }
                                         into TabEmpresa
                                         select new { TabEmpresa.Key.em_cdempresa, TabEmpresa.Key.em_descricao });

                List<TbEmpresa> _EMPRESA = new List<TbEmpresa>();
                foreach (var i  in GrouByEmpresa)
                {
                    _EMPRESA.Add(new TbEmpresa(i.em_cdempresa, i.em_descricao));
                }

                if (_EMPRESA.Count > 1) _EMPRESA.Add(new TbEmpresa(0, " TODOS "));

                List_User_Empresa = _EMPRESA.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0002_EmpresaOperacao \n" + 
                                    "----------------------------------- \n " + 
                                    "Tool \n " +
                                    "WkEmpresaOperacao \n " +
                                    "EmpresaOperacoes_User_List_Get \n " + 
                                    ex.Message);
            }
        }
        public TbOperacao[] Operacao_User_List_Get(TbEmpresa _TbEmpresa_SELECT)
        {
            List<TbOperacao> _Operacoes_list = new List<TbOperacao>();

            List<TbOperacao> GrouByOPERACAO = new List<TbOperacao>();
            
            if (_TbEmpresa_SELECT.em_cdempresa == 0)
            {
                GrouByOPERACAO = (from t in List_User_EmpresaOperacao
                                      group t by new { t.op_cdoperacao, t.op_descricao }
                                          into TabEmpresa
                                      select new TbOperacao { op_cdoperacao = TabEmpresa.Key.op_cdoperacao, op_descricao = TabEmpresa.Key.op_descricao }).ToList();
            }
            else
            {
                GrouByOPERACAO = (from t in List_User_EmpresaOperacao
                                      where t.em_cdempresa == _TbEmpresa_SELECT.em_cdempresa
                                      group t by new { t.op_cdoperacao, t.op_descricao }
                                          into TabEmpresa
                                          select new TbOperacao { op_cdoperacao =  TabEmpresa.Key.op_cdoperacao, op_descricao =  TabEmpresa.Key.op_descricao }).ToList();
            }


            /*
            foreach( TbOperacao i in List_User_EmpresaOperacao)
            {
                if (_TbEmpresa_SELECT.em_cdempresa != 0)
                {
                    if (i.em_cdempresa == _TbEmpresa_SELECT.em_cdempresa || i.em_cdempresa == 0)
                    {
                        _Operacoes_list.Add(i);
                    }
                }
                else
                {
                    _Operacoes_list.Add(i);
                }

            }*/

            if (GrouByOPERACAO.Count() > 1) _Operacoes_list.Add(new TbOperacao(0, " TODOS ")); 
            foreach(var i in GrouByOPERACAO)
            {
                _Operacoes_list.Add(new TbOperacao(i.op_cdoperacao, i.op_descricao));
            }

            


            List_User_Operacao = _Operacoes_list.ToArray();
            return List_User_Operacao.ToArray();
        }

    }

    public static class Tool
    {
        public static DataTable DataTable_EmpresaOperacao_Consultar (Pag_Net.Models.modelSistemaUsuario MyConnect, F0002_20_Empresa_Operacao_User_consulta.filter _filter)
        {
            try {
                return BDCommand.get_DataTable(MyConnect, F0002_20_Empresa_Operacao_User_consulta.Postgre.Get(_filter, MyConnect));
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0002_EmpresaOperacao \n" + 
                                    "----------------------------------- \n " + 
                                    "Tool \n " + 
                                    "EmpresaOperacao_Consultar \n " + 
                                    "F0002_20_Empresa_Operacao_User_consulta \n " + 
                                    ex.Message
                            );
            }
        }
    }

    public class Model_Operacao_Setor: TbOperacao_Setor
    {
        public string em_descricao { get; set;  }
        public string op_descricao { get; set;  }
        public Model_Operacao_Setor()
        {
            
        }

        public Model_Operacao_Setor(DataRow i) : base(i)
        {
            em_descricao = i["em_descricao"].ToString();
            op_descricao = i["op_descricao"].ToString();
        }    
    }

}
