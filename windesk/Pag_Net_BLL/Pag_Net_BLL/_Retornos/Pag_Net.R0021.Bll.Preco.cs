using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;
using Pag_Net.R0021.Models;

/*
 *  
 *  
 * OBS
 * Funções ativas: r0021_0001_preco
 * Funções inativadas: r0021_01_1011842_preco
 * 
 * 
 * 
 * 
 * 
 */




namespace Pag_Net.R0021.Bll
{
    public class Execute  
    {

        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        
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
            set { try { if (value != string.Empty) _vdescricao = value.ToString().Replace("'", ""); else _vdescricao = ""; } catch (Exception ex) { throw new Exception("Valor inválido: " + ex.Message); } }
        }


        private string _vdescricao_fiscal = "";
        public string Descricao_Fiscal
        {
            get { return _vdescricao; }
            set { try { if (value != string.Empty) _vdescricao_fiscal = value.ToString().Replace("'", ""); else _vdescricao_fiscal = ""; } catch (Exception ex) { throw new Exception("Valor inválido: " + ex.Message); } }
        }

        public int Prd_cddepartamento; 
        public int Prd_cdsecao;
        public int Prd_cdgrupo;
        public int Prd_subcdgrupo;

        public DateTime Dt_cadastro_ini { get; set; }
        public DateTime Dt_cadastro_fim { get; set; }
        public bool Seleciona_Data_Cadastro { get; set; }
        public bool Status_Ativo { get; set; }
        public bool Status_Inativo { get; set; }
        public DataTable Dt_Preco { get; set; }
        public DataTable Dt_PrecoEmbalagem { get; set; }
        public r0021_precos[] Lista_Geral;


        public Execute(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            MyConnect = _myConnect;
            Prd_cddepartamento = 0;
            Prd_cdsecao = 0;
            Prd_cdgrupo = 0;
            Prd_subcdgrupo = 0; 
        }

        public void Public()
        {
            _0001_Preco();

        }

        public r0021_precos[] _0001_Preco()
        {
            try
            {
                _validate();
                
                List<r0021_precos> _list = new List<r0021_precos>();

                string SQL_POSTGRE = string.Format("select * from r0021_0001_preco({0} , {1} ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, {10}, {11}, {12}  )",
                                                      CdProduto.ToString(),
                                                      CdProdutoBluesoft.ToString(),
                                                      Seleciona_Data_Cadastro.ToString(),
                                                      Dt_cadastro_ini.ToString("yyyy-MM-dd"),
                                                      Dt_cadastro_fim.ToString("yyyy-MM-dd"),
                                                      Descricao, 
                                                      Descricao_Fiscal,
                                                      Status_Ativo.ToString(),
                                                      Status_Inativo.ToString(), 
                                                      Prd_cddepartamento.ToString(), 
                                                      Prd_cdsecao.ToString(), 
                                                      Prd_cdgrupo.ToString(), 
                                                      Prd_subcdgrupo.ToString() 
                                                      );

                Dt_Preco = _Select(SQL_POSTGRE, "PRECO");
                Dt_Preco.PrimaryKey = new DataColumn[] { Dt_Preco.Columns["pr_cdproduto"] };
                
                foreach(DataRow dr in Dt_Preco.Rows)
                {
                    _list.Add(new r0021_precos(dr));
                }
                
                return _list.ToArray();




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
  
        }
        public DataTable _0002_Preco_Embalagem(string cdprodutoSELECIONADO)
        {

            try
            {
                _validate();
                string SQL_POSTGRE = string.Format("select * from r0021_0002_preco_embalagem({0} , {1} ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}' )",
                                                      cdprodutoSELECIONADO.ToString(),
                                                      CdProdutoBluesoft.ToString(),
                                                      Seleciona_Data_Cadastro.ToString(),
                                                      Dt_cadastro_ini.ToString("yyyy-MM-dd"),
                                                      Dt_cadastro_fim.ToString("yyyy-MM-dd"),
                                                      Descricao,
                                                      Descricao_Fiscal,
                                                      Status_Ativo.ToString(),
                                                      Status_Inativo.ToString()
                                                      );
                Dt_PrecoEmbalagem = _Select(SQL_POSTGRE, "EMBALAGEM");
                return Dt_PrecoEmbalagem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void _validate()
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
        private DataTable _Select(string _ScriptSQL, string table)
        {
            try
            {
                DataSet DT = new DataSet();
                DT = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, _ScriptSQL, "");
                return DT.Tables[0];
        
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message.ToString());
            }

        }
    }

    /*
    public static class Select
    {

        public static DataTable get(
                Pag_Net.Models.TbSysUserInfo MyConnect
            ,   int _cdProduto
            ,   int _cdProdutoBluesoft
            ,   bool _selecionaDataCadastro
            ,   DateTime _dt_cadastro_ini
            ,   DateTime _dt_cadastro_fim
            ,   string _descricao 
            ,   string _descricao_fiscal
            ,   bool Status_Ativo
            ,   bool Status_Inativo
            ,   int _prd_cddepartamento
            ,   int _prd_cdsecao
            ,   int _prd_cdgrupo
            ,   int _prd_subcdgrupo
            ,   int _tab_pre_cd
            ,   bool _agendamento_consulta
            ,   DateTime _data_agendamento
            ,   bool _Seleciona_data_mov_entrada
            ,   DateTime _vdt_data_entrada_ini
            ,   DateTime _vdt_data_entrada_fim

            )
        {

            string SQL_POSTGRE = "";

            try
            {
                SQL_POSTGRE = string.Format("SELECT * FROM r0021_01_1011842_preco({0} , {1} ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, {10}, {11}, {12}, {13}, '{14}', '{15}', '{16}', '{17}', '{18}'  )",
                                                      _cdProduto.ToString(),
                                                      _cdProdutoBluesoft.ToString(),
                                                      _selecionaDataCadastro.ToString(),
                                                      _dt_cadastro_ini.ToString("yyyy-MM-dd"),
                                                      _dt_cadastro_fim.ToString("yyyy-MM-dd"),
                                                      _descricao,
                                                      _descricao_fiscal,
                                                      Status_Ativo.ToString(),
                                                      Status_Inativo.ToString(),
                                                           _prd_cddepartamento.ToString(), 
                                                      _prd_cdsecao.ToString(), 
                                                      _prd_cdgrupo.ToString(), 
                                                      _prd_subcdgrupo.ToString(),
                                                      _tab_pre_cd.ToString(),
                                                      _agendamento_consulta.ToString(),
                                                      _data_agendamento.ToString("yyyy-MM-dd"),
                                                      _Seleciona_data_mov_entrada,
                                                      _vdt_data_entrada_ini.ToString("yyyy-MM-dd"),
                                                      _vdt_data_entrada_fim.ToString("yyyy-MM-dd")
                                                      );

                DataSet DT = new DataSet();
                DT = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DT.Tables[0];
            }
            catch (Exception Ex)
            {
                throw new Exception("Pag_Net.R0021.Bll " + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "ScriptSQL: " + SQL_POSTGRE + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "Erro Message: " + Ex.Message);
            }

        }

    }*/


}

namespace Pag_Net.R0021.Models
{
    public class r0021_precos
    {
        public int      pr_cdproduto                    { get; set; }
        public int      prb_cdprodutobluesoft { get; set; }
        public string   pr_descricao { get; set; }
        public bool     pr_status { get; set; }
        public string   pr_embalagemestoque { get; set; }
        public string   pre_embalagem { get; set; }
        public double   pre_fatorestoque { get; set; }
        public double   pre_fatorpreco { get; set; }
        public double   prc_valor { get; set; }
        public double   ec_valor_custo_precificacao { get; set; }
        public double   ec_valor_custo_faturamento { get; set; }
        public double prca_qtde_promocional { get; set; }
        public double prca_valor_promocional { get; set; }
        

        public r0021_precos() { }

        public r0021_precos(
                 int     _pr_cdproduto                   
             ,   int     _prb_cdprodutobluesoft          
             ,   string  _pr_descricao                   
             ,   bool    _pr_status                      
             ,   string  _pr_embalagemestoque            
             ,   string  _pre_embalagem                  
             ,   double  _pre_fatorestoque               
             ,   double  _pre_fatorpreco                 
             ,   double  _prc_valor                      
             ,   double  _ec_valor_custo_precificacao    
             ,   double  _ec_valor_custo_faturamento  
             ,   double  _prca_qtde_promocional
             ,   double  _prca_valor_promocional
            )
        {

            pr_cdproduto                  =          _pr_cdproduto                   ;
            prb_cdprodutobluesoft         =          _prb_cdprodutobluesoft          ;
            pr_descricao                  =          _pr_descricao                   ;
            pr_status                     =          _pr_status                      ;
            pr_embalagemestoque           =          _pr_embalagemestoque            ;
            pre_embalagem                 =          _pre_embalagem                  ;
            pre_fatorestoque              =          _pre_fatorestoque               ;
            pre_fatorpreco                =          _pre_fatorpreco                 ;
            prc_valor                     =          _prc_valor                      ;
            ec_valor_custo_precificacao   =          _ec_valor_custo_precificacao    ;
            ec_valor_custo_faturamento    =          _ec_valor_custo_faturamento;
            prca_qtde_promocional = _prca_qtde_promocional;
            prca_valor_promocional = _prca_valor_promocional;
                
        }

        public r0021_precos(DataRow i) 
        {
            pr_cdproduto = Convert.ToInt32(i["pr_cdproduto"]);
            prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"]);
            pr_descricao = i["pr_descricao"].ToString();
            pr_status = Pag_Net.Models.BDTools.boolColumnResult(i["pr_status"].ToString());
            pr_embalagemestoque = i["pr_embalagemestoque"].ToString();
            pre_embalagem = i["pre_embalagem"].ToString();
            pre_fatorestoque = Convert.ToDouble(i["pre_fatorestoque"]);
            pre_fatorpreco = Convert.ToDouble(i["pre_fatorpreco"]);
            prc_valor = Convert.ToDouble(i["prc_valor"]);
            ec_valor_custo_precificacao = Convert.ToDouble(i["ec_valor_custo_precificacao"]);
            ec_valor_custo_faturamento = Convert.ToDouble(i["ec_valor_custo_faturamento"]);
            prca_qtde_promocional = Convert.ToDouble(i["prca_qtde_promocional"]);
            prca_valor_promocional = Convert.ToDouble(i["prca_valor_promocional"]);
        }

    }

}
