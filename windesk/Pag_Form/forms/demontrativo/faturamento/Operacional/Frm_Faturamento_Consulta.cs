using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.demontrativo.faturamento.Operacional
{
    public partial class frm_faturamentoConsulta : Form
    {
        private static int _SIS_AC_CD = 5111;

        Pag_Net.Models.modelSistemaUsuario MyConnect;


        /// <summary>
        /// CLASSES MANAGMENT 
        /// </summary>
        Pag_Net.Bll.F0002_Enterprise.WkEmpresaOperacao __srcEmpresaOperacao;
        Pag_Net.src.F0070_Faturamento._indexReport F0070_Faturamento_Report;


        public frm_faturamentoConsulta(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
        }

        public frm_faturamentoConsulta(Pag_Net.Models.modelSistemaUsuario _MyConnect, int seqFaturamento)
        {
            InitializeComponent();
            MyConnect = _MyConnect;

            if (seqFaturamento != 0)
            {
                txtSeqFaturamento.Text = seqFaturamento.ToString();
            }

            _Screen_load();
        }

        /// <summary>
        /// Screen_FORMAT 
        /// </summary>
        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_Form_Open(this);
                _Screen_load_format();

                /*Class Management open*/
                F0070_Faturamento_Report = new Pag_Net.src.F0070_Faturamento._indexReport(MyConnect);
                F0070_Faturamento_Report.PropertyChanged += _dataBinding;

                __srcEmpresaOperacao = new Pag_Net.Bll.F0002_Enterprise.WkEmpresaOperacao(MyConnect);
                __srcEmpresaOperacao.Filter_EmpresaOperacao.sis_ac_cd = _SIS_AC_CD;
                __srcEmpresaOperacao.EmpresaOperacoes_User_List_DataBindings();


                //if (txtSeqFaturamento.Text != "")
                    

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _Screen_load_format()
        {
            foreach (System.Windows.Forms.DataGridViewColumn col in dtgf.Columns)
            {
                col.DataPropertyName = col.Name.Substring(5, col.Name.Length - 5);

            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {

            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


        private void _dataBinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {

                //rptfaturamentoItensList
                if (e.PropertyName == "rptFaturamentoConsulta")
                {
                    lbl_seqfaturamento.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.seqfaturamento.ToString();
                    lbl_seqfaturamentoorigem.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.seqfaturamentoorigem.ToString();
                    lbl_cdempresa.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.em_cdempresa.ToString();
                    lbl_em_descricao.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.em_descricao.ToString();
                    lbl_op_cdoperacao.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.op_cdoperacao.ToString();
                    lbl_op_descricao.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.op_descricao.ToString();
                    lbl_statusfaturamentodescricao.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.statusfaturamento_descricao.ToString();
                    lbl_statusfaturamento.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.statusfaturamento.ToString();
                    lbl_cdparticipantecliente.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.cdparticipantecliente.ToString();
                    lbl_cliente_cpf_cnpj.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.cliente_cpf_cnpj.ToString();
                    lbl_cliente_nome_razao.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.cliente_nome_razao.ToString();

                    lbl_cdparticipantevendedor.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.cdparticipantevendedor.ToString();
                    lbl_vendedor_cpf_cnpj.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.vendedor_cpf_cnpj.ToString();
                    lbl_vendedor_nome_razao.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.vendedor_nome_razao.ToString();
                    lbl_numeropedido.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.numeropedido.ToString();
                    lbl_df_nf_seq_blue.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.df_nf_seq_blue.ToString();
                    lbl_df_nf_numero.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.df_nf_numero.ToString();
                    lbl_df_valor_total.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.df_valor_total.ToString();
                    txt_df_chave.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.df_chave.ToString();
                    lbl_df_data_emissao.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.df_data_emissao.ToString("dd/MM/yyyy");

                    lbl_sat_ecf.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.sat_ecf.ToString();
                    lbl_cupomfiscal.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.cupomfiscal.ToString();
                    lbl_cupomfiscal_valor.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.cupomfiscal_valor.ToString();
                    txt_cupomfiscal_chave.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.cupomfiscal_chave.ToString();

                    lbl_faturamento_pag_itens_qtde.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.faturamento_pag_itens_qtde.ToString();


                    lbl_cliente_cdpessoabluesoft.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.cliente_cdpessoabluesoft.ToString();
                    lbl_vendedor_cdpessoabluesoft.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.vendedor_cdpessoabluesoft.ToString();

                    lbl_dataemissao.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.dataemissao.ToString("dd/MM/yyyy");
                    lbl_datafaturamento.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.datafaturamento.ToString("dd/MM/yyyy");


                    lbl_faturamento_pag_valortotalfaturamentoliquido.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.valortotalfaturamentoliquido.ToString("0.00");
                    lbl_faturamento_pag_ec_valorcusto_faturamento_total.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.ec_valorcusto_faturamento_total.ToString("0.00");
                    lbl_faturamento_pag_ec_valorcusto_precificacao_total.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.ec_valorcusto_precificacao_total.ToString("0.00");
                    lbl_faturamento_pag_ec_valorcusto_precificacao_total.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.ec_valorcusto_precificacao_total.ToString("0.00");
                    lbl_faturamento_pag_itens_valortotalfaturamentobase.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.valortotalfaturamentobase.ToString("0.00");
                    lbl_faturamento_pag_valortotalsubsidioscorrentes.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.valortotalsubsidioscorrentes.ToString("0.00");
                    lbl_faturamento_pag_valortotalfaturamento.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.valortotalfaturamento.ToString("0.00");
                    lbl_faturamento_pag_valortotaldescontofinanceiro.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.valortotaldescontofinanceiro.ToString("0.00");
                    lbl_faturamento_pag_valortotalfaturamentobruto.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.valortotalfaturamentobruto.ToString("0.00");
                    lbl_faturamento_pag_valortotalsubsidiosaplicados.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.valortotalsubsidiosaplicados.ToString("0.00");
                    lbl_faturamento_pag_valortotalfaturamentoliquido.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.valortotalfaturamentoliquido.ToString("0.00");


                    lbl_df_nf_tipo.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.df_nf_tipo.ToString();
                    lbl_df_nf_tipo_descricao.Text = F0070_Faturamento_Report.rptfaturamentoConsulta.registro.df_nf_tipo_descricao.ToString();

                }

                if (e.PropertyName == "rptfaturamentoItensList")
                {
                    dtgf.DataSource = F0070_Faturamento_Report.rptfaturamentoItensList.report;
                    UserTools._Screen_DataBinding_Set(lbl_pr_cdproduto, dtgf.DataSource, "pr_cdproduto");
                    UserTools._Screen_DataBinding_Set(lbl_prb_cdprodutobluesoft, dtgf.DataSource, "prb_cdprodutobluesoft");
                    UserTools._Screen_DataBinding_Set(lbl_pr_descricao, dtgf.DataSource, "pr_descricao");
                    UserTools._Screen_DataBinding_Set(lbl_pr_embalagemestoque, dtgf.DataSource, "pr_embalagemestoque");
                    UserTools._Screen_DataBinding_Set(lbl_embalagemestoqueqtde, dtgf.DataSource, "embalagemestoqueqtde");
                    UserTools._Screen_DataBinding_Set(lbl_pr_embalagemcompra, dtgf.DataSource, "pr_embalagemcompra");
                    UserTools._Screen_DataBinding_Set(lbl_embalagemcompraqtde, dtgf.DataSource, "embalagemestoquecompra");
                    UserTools._Screen_DataBinding_Set(lbl_ec_valorcusto_faturamento_total, dtgf.DataSource, "ec_valorcusto_faturamento_total");
                    UserTools._Screen_DataBinding_Set(lbl_ec_valorcusto_precificacao_total, dtgf.DataSource, "ec_valorcusto_precificacao_total");

                    UserTools._Screen_DataBinding_Set(lbl_valortotalfaturamentobase, dtgf.DataSource, "valortotalfaturamentobase");
                    UserTools._Screen_DataBinding_Set(lbl_valortotalsubsidioscorrentes, dtgf.DataSource, "valortotalsubsidioscorrentes");
                    UserTools._Screen_DataBinding_Set(lbl_valortotalfaturamento, dtgf.DataSource, "valortotalfaturamento");
                    UserTools._Screen_DataBinding_Set(lbl_valortotaldescontofinanceiro, dtgf.DataSource, "valortotaldescontofinanceiro");
                    UserTools._Screen_DataBinding_Set(lbl_valortotalfaturamentobruto, dtgf.DataSource, "valortotalfaturamentobruto");
                    UserTools._Screen_DataBinding_Set(lbl_valortotalsubsidiosaplicados, dtgf.DataSource, "valortotalsubsidiosaplicados");
                    UserTools._Screen_DataBinding_Set(lbl_valortotalfaturamentoliquido, dtgf.DataSource, "valortotalfaturamentoliquido");
                }

            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try 
            {
                if (txtSeqFaturamento.Text != "")
                {
                    F0070_Faturamento_Report.filterFaturamento.seqfaturamento = Convert.ToInt32(txtSeqFaturamento.Text);
                    UserTools._Screen_Wait(this);
                    F0070_Faturamento_Report.getFaturamento();
                    UserTools._Screen_Wait(this);
                }
                else
                {
                    UserTools._Screen_MessageBox(this,UserTools.PagTipoMessageBox.Atencao, "Informe o Sequencial de Faturamento");
                }
            }
            catch (Exception ex) 
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }




    }
}
