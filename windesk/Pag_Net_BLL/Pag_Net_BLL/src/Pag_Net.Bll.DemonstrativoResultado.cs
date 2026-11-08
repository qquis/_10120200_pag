using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll
{
    public class Bll_DemonstrativoResultado
    {
        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        public int CompetenciaCD_SELECIONADA;
        public int Op_CdOperacao_SELECIONADO;
        public int Centrodr_SubGrupo_SELECIONADO;
        public int centrodr_resumo_cd;

        public double Valor_A_ReceitaBrutaFaturamento = 0;
        public double Valor_CMV;
        public double Valor_B_ReceitaSemCMV = 0;
        public double Valor_C_ReceitaSemImpostos = 0;
        public double Valor_D_ReceitaSemDescontosFinanceiros = 0;
        public double Valor_E_ReceitaComAcordosComerciais = 0;
        public double Valor_F_ReceitaSemDespesasVariaveis = 0;
        public double Valor_G_ReceitaSemCustosFixosDiretos = 0;
        public double Valor_H_ReceitaSemCustosFixosIndiretos = 0;
        public double Valor_DESPESAS_GERAIS          = 0;
        public double Valor_DESPESAS_LOJA            = 0;
        public double Valor_DESPESAS_DISTRIBUICAO = 0;



        public double Valor_ReceitaBruta;
        
        public double Valor_ReceitaBruta_Operacional;
        public double Valor_ReceitaBruta_Operacional_Margem;
        public double Valor_Operacao_ICMS;
        public double Valor_Operacao_PIS;
        public double Valor_Operacao_COFINS;
        public double Valor_ReceitaBruta_Operacional_SemImpostos;
        public double Valor_ReceitaBruta_Operacional_SemImpostos_Margem;

        public double Valor_DescontosFinanceiros;
        public double Valor_ReceitaBruta_Operacional_SemImpostos_Financeiro;
        public double Valor_ReceitaBruta_Operacional_SemImpostos_Financeiro_Margem;



        public double Valor_SubsidioBonificacao;

        public double Valor_ReceitaBruta_Comercial;
        public double Valor_ReceitaBruta_Comercial_Margem;

        public double Valor_SubsidioBonificacao_PIS;
        public double Valor_SubsidioBonificacao_COFINS;

        public double Valor_ReceitaBruta_Comercial_SemImpostos;
        public double Valor_ReceitaBruta_Comercial_SemImpostos_Margem;


        public double Valor_DESPESA_Cartao_CreditoDebito;
        public double Valor_DESPESA_Comissao_Representante;
        public double Valor_DESPESA_Frete;
        public double Valor_DESPESA_Outros;
        public double Valor_Resceita_Sem_CustoVariavel;
        public double Valor_Resceita_Sem_CustoVariavel_Margem;


        public double Valor_DESPESA_Valor_CF_Direto_Folha;
        public double Valor_DESPESA_Valor_CF_Indireto_folha;

        public double Valor_DESPESA_AguaGasEnergia;
        public double Valor_DESPESA_Inventario;
        

        
        
        
        public double Valor_RESULTADO;
        public double Valor_RESULTADO_Margem; 




        public Pag_Net.Models.Mdo_DemonstrativoResultado[] ListDemonstrativoResultado;

        public Bll_DemonstrativoResultado(Pag_Net.Models.modelSistemaUsuario _MyConnect) 
        {
            MyConnect = _MyConnect;
            Valor_RESULTADO = 0;

        }

        public DataTable Consultar_CentroDR_Resumo_Tipo()
        {

            try
            {
                return Pag_Net.Bll.R0078.Select.get(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable ConsultaOperacoes()
        {
            try
            {
                return Pag_Net.Bll.R0003.Select._0001_Operacoes(MyConnect, 1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable Consultar_Centrodr_SubGrupo()
        {
            try
            {
                return Pag_Net.Bll.R0051.Select._0001_Centrodr_lancamento(MyConnect, Op_CdOperacao_SELECIONADO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable Competencias()
        {
            try
            {
                return Pag_Net.Bll.R0005.Select._0001_competencia(MyConnect, 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable CentroDrFechamento_Item(int vcdr_fechamento_cd)
        {

            try
            {
                return Pag_Net.Bll.R0080.Select.Dt(MyConnect, CompetenciaCD_SELECIONADA, vcdr_fechamento_cd, Op_CdOperacao_SELECIONADO, Centrodr_SubGrupo_SELECIONADO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable CentroDrFechamento_BY_Tipo(int vcdr_fechamento_cd)
        {

            try
            {
                return Pag_Net.Bll.R0081.Select.Dt(MyConnect, CompetenciaCD_SELECIONADA, vcdr_fechamento_cd, Op_CdOperacao_SELECIONADO, Centrodr_SubGrupo_SELECIONADO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ConsultaDemonstrativoFechamento()
        {
            try
            {
                DataTable dataTABLE = Pag_Net.Bll.R0059.Select.Dt(MyConnect, CompetenciaCD_SELECIONADA, Op_CdOperacao_SELECIONADO, Centrodr_SubGrupo_SELECIONADO, 0);


                Valor_A_ReceitaBrutaFaturamento = 0;
                Valor_CMV = 0;
                Valor_B_ReceitaSemCMV = 0;
                Valor_C_ReceitaSemImpostos = 0;
                Valor_D_ReceitaSemDescontosFinanceiros = 0;
                Valor_E_ReceitaComAcordosComerciais = 0;
                Valor_F_ReceitaSemDespesasVariaveis = 0;
                Valor_G_ReceitaSemCustosFixosDiretos = 0;
                Valor_H_ReceitaSemCustosFixosIndiretos = 0;
                Valor_DESPESAS_GERAIS = 0;
                Valor_DESPESAS_LOJA = 0;
                Valor_DESPESAS_DISTRIBUICAO = 0;

                
                foreach( DataRow i in  dataTABLE.Rows )
                {
                    switch (Convert.ToInt32(i["cdr_fechamento_linha"]))
                    {
                        case 10:  Valor_A_ReceitaBrutaFaturamento               = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 20:  Valor_CMV                                     = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 30:  Valor_B_ReceitaSemCMV                         = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 70:  Valor_C_ReceitaSemImpostos                    = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 90:  Valor_D_ReceitaSemDescontosFinanceiros        = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 130: Valor_E_ReceitaComAcordosComerciais           = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 190: Valor_F_ReceitaSemDespesasVariaveis           = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 300: Valor_G_ReceitaSemCustosFixosDiretos          = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 550: Valor_H_ReceitaSemCustosFixosIndiretos        = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 800: Valor_DESPESAS_GERAIS                         = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 805: Valor_DESPESAS_LOJA                           = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 825: Valor_DESPESAS_DISTRIBUICAO                   = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                        case 5000: Valor_RESULTADO                              = Convert.ToDouble(i["cdr_valor"].ToString()); break;
                    }
                }

                return dataTABLE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable ConsultaDemonstrativoResultado_Lancamentos()
        {
            try
            {
                Valor_RESULTADO = 0;
                List<Pag_Net.Models.Mdo_DemonstrativoResultado> _list = new List<Models.Mdo_DemonstrativoResultado>();
                DataTable DT = Pag_Net.Bll.R0050.Select._0001_Centrodr_lancamento(MyConnect, Op_CdOperacao_SELECIONADO, Centrodr_SubGrupo_SELECIONADO, CompetenciaCD_SELECIONADA);
                foreach (DataRow i in DT.Rows)
                {
                    _list.Add(new Models.Mdo_DemonstrativoResultado(i));
                    Valor_RESULTADO += Convert.ToDouble(i["cdr_valor"].ToString());
                }
                ListDemonstrativoResultado = _list.ToArray();

                
                Valor_ReceitaBruta = DemonstrativoResultadoTipoValor(100);
                
                Valor_CMV = DemonstrativoResultadoTipoValor(500);


                /* OPERAÇÃO ***************************************************************************************************************/
                Valor_ReceitaBruta_Operacional =  Valor_ReceitaBruta + Valor_CMV;
                Valor_ReceitaBruta_Operacional_Margem = Valor_ReceitaBruta_Operacional / Valor_ReceitaBruta * 100;

                Valor_Operacao_ICMS = DemonstrativoResultadoTipoValor(105); 
                Valor_Operacao_PIS = DemonstrativoResultadoTipoValor(110); 
                Valor_Operacao_COFINS = DemonstrativoResultadoTipoValor(115);
                Valor_ReceitaBruta_Operacional_SemImpostos = Valor_ReceitaBruta + Valor_Operacao_ICMS + Valor_Operacao_PIS + Valor_Operacao_COFINS;
                Valor_ReceitaBruta_Operacional_SemImpostos_Margem = (Valor_ReceitaBruta_Operacional_SemImpostos + Valor_CMV) / Valor_ReceitaBruta_Operacional_SemImpostos * 100;

                Valor_DescontosFinanceiros = DemonstrativoResultadoTipoValor(200);
                Valor_ReceitaBruta_Operacional_SemImpostos_Financeiro = Valor_ReceitaBruta_Operacional_SemImpostos + Valor_DescontosFinanceiros;
                Valor_ReceitaBruta_Operacional_SemImpostos_Financeiro_Margem = (Valor_ReceitaBruta_Operacional_SemImpostos_Financeiro + Valor_CMV) / Valor_ReceitaBruta_Operacional_SemImpostos_Financeiro * 100;


                /* COMERCIAL**************************************************************************************************************/
                Valor_SubsidioBonificacao = DemonstrativoResultadoTipoValor(300);

                Valor_ReceitaBruta_Comercial = Valor_ReceitaBruta_Operacional_SemImpostos + Valor_SubsidioBonificacao;
                Valor_ReceitaBruta_Comercial_Margem = (Valor_ReceitaBruta_Comercial + Valor_CMV) / Valor_ReceitaBruta_Comercial * 100;

                Valor_SubsidioBonificacao_PIS = DemonstrativoResultadoTipoValor(310);
                Valor_SubsidioBonificacao_COFINS = DemonstrativoResultadoTipoValor(315);

                Valor_ReceitaBruta_Comercial_SemImpostos = Valor_ReceitaBruta_Comercial + Valor_SubsidioBonificacao_PIS + Valor_SubsidioBonificacao_COFINS;
                Valor_ReceitaBruta_Comercial_SemImpostos_Margem = (Valor_ReceitaBruta_Comercial_SemImpostos + Valor_CMV) / Valor_ReceitaBruta_Comercial_SemImpostos * 100;


                /* CUSTOS VARIÁVEIS********************************************************************************************************/
                Valor_DESPESA_Cartao_CreditoDebito = DemonstrativoResultadoTipoValor(410);
                Valor_DESPESA_Comissao_Representante = 0;
                Valor_DESPESA_Frete = 0;
                Valor_DESPESA_Outros = 0;


                Valor_Resceita_Sem_CustoVariavel = 
                    Valor_ReceitaBruta_Comercial_SemImpostos +
                    Valor_DESPESA_Cartao_CreditoDebito +
                    Valor_DESPESA_Frete +
                    Valor_DESPESA_Outros;

                Valor_Resceita_Sem_CustoVariavel_Margem = (Valor_Resceita_Sem_CustoVariavel + Valor_CMV) / Valor_Resceita_Sem_CustoVariavel * 100;



                /* CUSTOS FIXOS DIRETOS*****************************************************************************************************/

                Valor_DESPESA_Valor_CF_Direto_Folha = DemonstrativoResultadoTipoValor(601);

                /* CUSTOS FIXOS INDIRETOS*****************************************************************************************************/

                Valor_DESPESA_Valor_CF_Indireto_folha = DemonstrativoResultadoTipoValor(701);

                /* OUTROS CUSTOS*****************************************************************************************************/
                Valor_DESPESA_Inventario = DemonstrativoResultadoTipoValor(505);
                Valor_DESPESA_AguaGasEnergia = DemonstrativoResultadoTipoValor(411);

                





                



                Valor_RESULTADO_Margem = Valor_RESULTADO / Valor_ReceitaBruta * 100;

                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ConsultaDemonstrativoResultado_Lancamento_Mapa(int vcentrodr_resumo_cd, int vcdr_tipo_cd)
        {
            try
            {
                return Pag_Net.Bll.R0054.Select.Dt(MyConnect, CompetenciaCD_SELECIONADA, Op_CdOperacao_SELECIONADO, Centrodr_SubGrupo_SELECIONADO, vcentrodr_resumo_cd, vcdr_tipo_cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   
        public DataTable ConsultaDemonstrativoResultado_Resumo(int vcentrodr_tipo_cd, int _vcentrodr_resumo_tipo_cd)
        {
            try
            {
                return Pag_Net.Bll.R0053.Select.Dt(MyConnect, CompetenciaCD_SELECIONADA, vcentrodr_tipo_cd, _vcentrodr_resumo_tipo_cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConsultaDemonstrativoResultado_PorTIPO(int vcentrodr_tipo_cd, int _vcentrodr_resumo_tipo_cd)
        {
            try
            {
                return Pag_Net.Bll.R0079.Select.Dt(MyConnect, CompetenciaCD_SELECIONADA, vcentrodr_tipo_cd, _vcentrodr_resumo_tipo_cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public double DemonstrativoResultadoTipoValor(int _cdr_tipo_cd)
        {
            try
            {
                double _valor = 0;

                Pag_Net.Models.Mdo_DemonstrativoResultado _registro = Array.Find(ListDemonstrativoResultado, rs => rs.cdr_tipo_cd == _cdr_tipo_cd);
                if (_registro == null)
                    _valor = 0;
                else
                    _valor = _registro.cdr_valor;
                return _valor;
                
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Consultar_CentroDr_Tipo(int centrodr_tipo_cd)
        {
            try
            {
                return Pag_Net.Bll.R0076.Select.get(MyConnect, centrodr_tipo_cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 


    }
}


namespace Pag_Net.Models
{

    public class Mdo_DemonstrativoResultado
    {
        /// <summary>
        /// r0021_0001_produto
        /// </summary>
        public int 				cdr_cd						{get; set;}
		public string 			cdr_descricao 				{get; set;}
		public int		    	cdr_subgrupo_cd 			{get; set;}
		public string			cdr_subgrupo_descricao 		{get; set;}
		public int	            cdr_tipo_cd					{get; set;}
		public string       	cdr_tipo_descricao 			{get; set;}
		public int          	competencia_cd		{get; set;}
        public double       	cdr_valor					{get; set;}
        public Mdo_DemonstrativoResultado()
        {

        }

        public Mdo_DemonstrativoResultado(DataRow i)
        {
            cdr_cd = Convert.ToInt32(i["cdr_cd"]);
            cdr_descricao = i["cdr_descricao"].ToString();
            cdr_subgrupo_cd = Convert.ToInt32(i["cdr_subgrupo_cd"]);
            cdr_subgrupo_descricao = i["cdr_subgrupo_descricao"].ToString();
            cdr_tipo_cd = Convert.ToInt32(i["cdr_tipo_cd"]);
            cdr_tipo_descricao = i["cdr_tipo_descricao"].ToString();
            competencia_cd = Convert.ToInt32(i["competencia_cd"]);
            cdr_valor = Convert.ToDouble(i["cdr_valor"].ToString());
        }

    }
  
}