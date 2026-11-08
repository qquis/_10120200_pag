using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pag_Form
{
    public static class UserReports
    {

        public static void ControleFin_Recibo(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Bll.F0135_Trasnporte_Ctrl.Model_Transporte_Ctrl TRANSPORTE_CTRL)
        {
            try
            {
                TRANSPORTE_CTRL.Controle_Reg.Binding_Fin(MyConnect);


                if (TRANSPORTE_CTRL.Controle_Reg.Financeiro_Total_Debito == 0)
                    throw new Exception("Impressão do Recibo não permitida - Não Existe Lançamentos de Serviços/Produtos");

                if (TRANSPORTE_CTRL.Controle_Reg.Financeiro_Total_Saldo < 0 && TRANSPORTE_CTRL.Controle_Reg.Financeiro_Total_Debito != 0)
                    throw new Exception("Impressão do Recibo não permitida - Pagamentos insuficientes");

                //pFornecedor_Razao_Social
                string localVALOR_EXTENSO = Pag_Net.Tools.Calculo.NumberText.toExtenso(Convert.ToDecimal(TRANSPORTE_CTRL.Controle_Reg.Financeiro_Total_Credito));

                Microsoft.Reporting.WinForms.ReportParameterCollection ReporteParametros = new Microsoft.Reporting.WinForms.ReportParameterCollection();

                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pFornecedor_Razao_Social", TRANSPORTE_CTRL.Transportadora.nome_razao));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pControle_Reg_Seq", TRANSPORTE_CTRL.Controle_Reg.controle_reg_seq.ToString()));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pFinanceiro_Total_Credito", TRANSPORTE_CTRL.Controle_Reg.Financeiro_Total_Credito.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pFinanceiro_Total_Credito_Extenso", localVALOR_EXTENSO));


                List<report.PagReportDataSource> DataSourceReportes = new List<report.PagReportDataSource>();

                DataSourceReportes.Add(new report.PagReportDataSource(TRANSPORTE_CTRL.Controle_Reg.Financeiro_Lancamentos, "DataSet1"));
                DataSourceReportes.Add(new report.PagReportDataSource(TRANSPORTE_CTRL.DocumentosFiscais, "DataSet2"));
                //DataSourceReportes.Add(new report.PagReportDataSource(Frete.Itens, "DataSet2"));


                /*
                report.frmReportView frm = 
                    new report.frmReportView(TRANSPORTE_CTRL.Controle_Reg.Financeiro_Lancamentos
                        , "Pag_Form.report.Rtp_Controle_Reg_Recibo.rdlc", "DataSet1", ReporteParametros);
                */

                report.frmReportView frm = new report.frmReportView(DataSourceReportes, "Pag_Form.report.Rtp_Controle_Reg_Recibo.rdlc", ReporteParametros);
                
                
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CartaoAcesso(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Bll.F0137_CartaoAcesso.model_cartao_acesso CARTAO_ACESSO, string cdbarra_picture)
        {
            try
            {
                //TRANSPORTE_CTRL.Controle_Reg.Binding_Fin(MyConnect);

                //pFornecedor_Razao_Social
         
                Microsoft.Reporting.WinForms.ReportParameterCollection ReporteParametros = new Microsoft.Reporting.WinForms.ReportParameterCollection();

                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pcartao_acesso_numero", CARTAO_ACESSO.cartao_acesso_numero.ToString()));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("ppath_cdbarra", cdbarra_picture));
                
                report.frmReportView frm = new report.frmReportView(null, "Pag_Form.report.Rpt_Cartao_Acesso_PrestadorServico.rdlc", "DataSet1", ReporteParametros);



                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ForcaVenda_Frete_Capa(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Bll.F0004_Forca_Venda.ModelTbForca_Venda_Frete Frete)
        {

            try {
                Microsoft.Reporting.WinForms.ReportParameterCollection ReporteParametros = new Microsoft.Reporting.WinForms.ReportParameterCollection();
                
                //ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pcpf_cnpj", Frete.cpf_cnpj));


                List<report.PagReportDataSource> DataSourceReportes = new List<report.PagReportDataSource>();

                DataSourceReportes.Add(new report.PagReportDataSource(Frete.Complementos, "DataSet1"));
                DataSourceReportes.Add(new report.PagReportDataSource(Frete.Itens, "DataSet2"));


                double pCALC_total_ajuste_complemento = Frete.fv_frete_ajuste_adicao - Frete.fv_frete_ajuste_desconto + Frete.fv_frete_vl_compl;
                double pCALC_total_impostos = Frete.fv_frete_vl_inss + Frete.fv_frete_vl_sest + Frete.fv_frete_vl_senat + Frete.fv_frete_vl_irpf;
                double pCALC_Total_Adiantamento_Vales = Frete.fv_frete_vl_antec_bb + Frete.fv_frete_vl_antec_especie;
                double pCALC_Total_Valor_Pendente = Frete.fv_frete_valor_liq - pCALC_Total_Adiantamento_Vales;

                

                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pnome_razao", Frete.nome_razao));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pcnpj_cpf", Frete.cpf_cnpj));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_valor", Frete.fv_frete_valor.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_vl_inss", Frete.fv_frete_vl_inss.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_vl_irpf", Frete.fv_frete_vl_irpf.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_vl_sest", Frete.fv_frete_vl_sest.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_vl_senat", Frete.fv_frete_vl_senat.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_vl_senat", Frete.fv_frete_vl_senat.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_vl_senat", Frete.fv_frete_vl_senat.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_vl_compl", Frete.fv_frete_vl_compl.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_valor_liq", Frete.fv_frete_valor_liq.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_ajuste_adicao", Frete.fv_frete_ajuste_adicao.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_ajuste_desconto", Frete.fv_frete_ajuste_desconto.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pCALC_total_ajuste_complemento", pCALC_total_ajuste_complemento.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pCALC_total_impostos", pCALC_total_impostos.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_vl_antec_bb", Frete.fv_frete_vl_antec_bb.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_vl_antec_especie", Frete.fv_frete_vl_antec_especie.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pCALC_Total_Adiantamento_Vales", pCALC_Total_Adiantamento_Vales.ToString("0.00")));
                ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pCALC_Total_Valor_Pendente", pCALC_Total_Valor_Pendente.ToString("0.00")));
                //ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pcompetencia_cd", Frete.competencia_cd.ToString()));
                //ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_dt_fechamento_ini", Frete.fv_frete_dt_fechamento_ini.ToString("dd/MM/yyyy")));
                //ReporteParametros.Add(new Microsoft.Reporting.WinForms.ReportParameter("pfv_frete_dt_fechamento_fim", Frete.fv_frete_dt_fechamento_fim.ToString("dd/MM/yyyy")));

                //report.frmReportView frm = new report.frmReportView(Frete.Complementos, "Pag_Form.report.Rpt_Forca_Venda_Frete.rdlc", "DataSet1", ReporteParametros);
                report.frmReportView frm = new report.frmReportView(DataSourceReportes, "Pag_Form.report.Rpt_Forca_Venda_Frete.rdlc", ReporteParametros);
                
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}
