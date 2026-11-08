using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;
using Pag_Net.Bll;

namespace Pag_Net.Bll.Financeiro.Titulos
{
    public class UspPagamentoLancamento
    {
        Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Financeiro.Titulos.UVWTitulo[] Titulos;

        public int StatusProcessamento;
        public int CdEmpresa;
        public int CdContaFinanceira;
        public int SeqPagamento;
        public int CdTituloEspecie;
        public int SeqProdutoFinanceiro;
        public double Valor;
        public string Observacao;
        public DateTime DataPagamento;
        public DateTime DataConfirmacao;
        public int SeqTitulo;
        public int QtdeTitulos;

        public enum FormaPgto
        {
            DINHEIRO,
            DUPLICATA,
            CHEQUE,
            DEPOSITO_BANCARIO,
            NOTA_PROMISSORIA,
            CARTAO_DE_CREDITO,
            CARTAO_DE_DEBITO,
            TÍTULO_ADMINISTRATIVO,
            FLOAT_DE_DUPLICATA,
        }


        private List<ParameterQuey> Parametros;

        public UspPagamentoLancamento(Models.modelSistemaUsuario __myConnect, Pag_Net.Bll.Financeiro.Titulos.UVWTitulo[]  __titulosList)
        {
            try
            {
                MyConnect = __myConnect;
                Titulos = __titulosList;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Liquidar( FormaPgto __formaPgto )
        {
            Dal.DbUpdate DalUpdate = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);
            try
            {

                if (__formaPgto == FormaPgto.DINHEIRO) this.CdTituloEspecie = 0;
                Parametros.Add(new ParameterQuey("STATUSPROCESSAMENTO", SqlDbType.Int, false, 0));
                Parametros.Add(new ParameterQuey("CdEmpresa", SqlDbType.Int, false, "CdEmpresa"));
                Parametros.Add(new ParameterQuey("CdContaFinanceira", SqlDbType.Int, false, CdContaFinanceira));
                Parametros.Add(new ParameterQuey("CdTituloEspecie", SqlDbType.Int, false, this.CdTituloEspecie));
                Parametros.Add(new ParameterQuey("SeqProdutoFinanceiro", SqlDbType.Int, false, this.SeqProdutoFinanceiro));
                Parametros.Add(new ParameterQuey("Valor", SqlDbType.Decimal, false, this.Valor));





                int RegistrosAffetados = DalUpdate.Execute("CdTituloEspecie", Parametros.ToArray());
                DalUpdate.Begin();
                

            }

            catch (Exception)
            {
                DalUpdate.RollBack();   
            }

        }
    
    }

}
