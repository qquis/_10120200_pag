using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Financeiro
{
    public partial class frmConsultarDuplicata : Form
    {

        Pag_Net.src.F0080_Financeiro._index Financeiro;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        int autpgto_seq_pk;


        public frmConsultarDuplicata(Pag_Net.Models.modelSistemaUsuario _MyConnect, int __autpgto_seq_pk)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            autpgto_seq_pk = __autpgto_seq_pk;
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                Financeiro = new Pag_Net.src.F0080_Financeiro._index(MyConnect);
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                
                Financeiro.ConsultarAutorizacaoPagamento(autpgto_seq_pk);

                lbl_autpgto_cdpessoabluesoft.Text = Financeiro.AutorizacaoPagamento.autpgto_cdpessoabluesoft.ToString();
                lbl_autpgto_seq_pk.Text = Financeiro.AutorizacaoPagamento.autpgto_seq_pk.ToString();
                lbl_autpgto_codigobarra.Text = Financeiro.AutorizacaoPagamento.autpgto_codigobarra.ToString();
                lbl_autpgto_datacriacao.Text = Financeiro.AutorizacaoPagamento.autpgto_datacriacao.ToString("dd/MM/yyyy");
                lbl_autpgto_dataemissao.Text = Financeiro.AutorizacaoPagamento.autpgto_dataemissao.ToString("dd/MM/yyyy");
                lbl_autpgto_datapagamento.Text = Financeiro.AutorizacaoPagamento.autpgto_datapagamento.ToString("dd/MM/yyyy");
                lbl_autpgto_dataquitacao.Text = Financeiro.AutorizacaoPagamento.autpgto_dataquitacao.ToString("dd/MM/yyyy");
                lbl_autpgto_datavencimento.Text = Financeiro.AutorizacaoPagamento.autpgto_datavencimento.ToString("dd/MM/yyyy");
                lbl_autpgto_descritivo.Text = Financeiro.AutorizacaoPagamento.descritivo;
                lbl_autpgto_juro_diario.Text = Financeiro.AutorizacaoPagamento.autpgto_juro_diario.ToString("0.00");
                lbl_autpgto_nf_dataemissao.Text = Financeiro.AutorizacaoPagamento.autpgto_nf_dataemissao.ToString("dd/MM/yyyy");
                lbl_autpgto_nf_numero.Text = Financeiro.AutorizacaoPagamento.autpgto_nf_numero.ToString();
                lbl_autpgto_tipo.Text = Financeiro.AutorizacaoPagamento.autpgto_tipo.ToString();
                lbl_autpgto_valor_abatimento.Text = Financeiro.AutorizacaoPagamento.autpgto_valor_abatimento.ToString("0.00");
                lbl_autpgto_valor_juros.Text = Financeiro.AutorizacaoPagamento.autpgto_valor_juros.ToString("0.00");
                lbl_autpgto_valor_juros_fixo.Text = Financeiro.AutorizacaoPagamento.autpgto_valor_juros_fixo.ToString("0.00");
                lbl_autpgto_valor_multa.Text = Financeiro.AutorizacaoPagamento.autpgto_valor_multa.ToString("0.00");
                lbl_autpgto_valordescontofinanceiro.Text = Financeiro.AutorizacaoPagamento.autpgto_valorDescontoFinanceiro.ToString("0.00");
                lbl_autpgto_valorfatura.Text = Financeiro.AutorizacaoPagamento.autpgto_valorfatura.ToString("0.00");
                lbl_autpgto_valorliquido.Text = Financeiro.AutorizacaoPagamento.autpgto_valorliquido.ToString("0.00");
                lbl_autpgto_valorpago.Text = Financeiro.AutorizacaoPagamento.autpgto_valorpago.ToString("0.00");
                lbl_autpgto_valortotal.Text = Financeiro.AutorizacaoPagamento.autpgto_valortotal.ToString("0.00");
                lbl_competencia_cd.Text = Financeiro.AutorizacaoPagamento.competencia_cd.ToString();
                lbl_Nome_Razao.Text = Financeiro.AutorizacaoPagamento.Nome_Razao.ToString();
                lbl_plc_conta_cd.Text = Financeiro.AutorizacaoPagamento.plc_conta_cd.ToString();
                lbl_plc_conta_cd_destino.Text = Financeiro.AutorizacaoPagamento.plc_conta_cd_destino.ToString();
                lbl_plc_descricao.Text = Financeiro.AutorizacaoPagamento.plc_descricao.ToString();
                lbl_plc_descricao_destino.Text = Financeiro.AutorizacaoPagamento.plc_descricao_destino.ToString();
                lbl_contrato_servico_key.Text = Financeiro.AutorizacaoPagamento.contrato_bluesoft_seq.ToString(); 


            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }
    }
}

