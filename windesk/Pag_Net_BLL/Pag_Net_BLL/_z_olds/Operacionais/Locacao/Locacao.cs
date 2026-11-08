using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;


namespace Pag_Net.Bll.Operacionais.Locacao
{
    public class Collection
    {

        public Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacao Contratos;
        public Pag_Net.Bll.Administrativo.UspContratoParticipante Participantes;
        public Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacaoRubricas Rubricas;
        public Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacaoFaturamento Composicao;
        public Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacaoParcela Parcelas;
        public Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacaoFinanceiro Financeiro;
        public Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacaoAtivo Ativo;
        private modelSistemaUsuario MyConnect;
        public Collection (modelSistemaUsuario __myConnect)
        {
            MyConnect = __myConnect;
            Contratos = new UspContratoLocacao(MyConnect);
            Participantes = new Administrativo.UspContratoParticipante(MyConnect);
            Rubricas = new UspContratoLocacaoRubricas(MyConnect);
            Composicao = new UspContratoLocacaoFaturamento(MyConnect);
            Parcelas = new UspContratoLocacaoParcela(MyConnect);
            Financeiro = new UspContratoLocacaoFinanceiro(MyConnect);
            Ativo = new UspContratoLocacaoAtivo(MyConnect);
            
        }
        public void Faturamento(int  __seqContratoLocacaoParcela)
        {
            try
            {
                Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacaoFaturamentoParcela.Faturar(MyConnect, __seqContratoLocacaoParcela);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
