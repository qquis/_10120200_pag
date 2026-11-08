using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using Pag_Net.Dal;
using Pag_Net.Bll.Tables;
using Pag_Net.Bll.SitefLog;

namespace Pag_Net.Bll.Sac
{
    public class bllOperacaoSac 
    {
        public ModelSystemUserInfoConnect MyConnect;
        public TbOperacoesSac[] TbOperacaoSac { get; set; }
        public TbItem[] ItemsDevolvidos { get; set; }
        public TbCuponsPagamentos[] PosList { get; set; }
        
        public TbProdutosFinanceiros[] TbProdutosFinanceiros
        {
            get
            {
                return DaProdutosFinanceiros.Select(MyConnect);
            }
        }
        public TbAutorizadorFinanceiro[] TbAutorizadoresFinanceiros
        {
            get
            {
                return DaAutorizadorFinanceiro.Select(MyConnect);
            }

        }
        public TbSitefLogs[] TbSitefLogsNaoGravados
        {
            get
            {
                return _SitefLogs.RegistrosNaoGravados;
            }
            set
            {
                _SitefLogs.RegistrosNaoGravados = value;
            }
        }
        private TbPessoas _TbPessoa;
        private bllSitefLogs _SitefLogs;

        public double ValorPagamentoPosLancados 
        {
            get { return _SitefLogs.VlPagamentosFinalizadoraPosLancados; } 
            
        }
        public double ValorPagamentoPosFinalizadora
        {
            get { return _SitefLogs.VlPagamentoFinalizadoraPos; }
            
        }


        public string NumeroEcf { get; set; }
        public string NumeroCupomFiscal { get; set; }
        public string SeqZanthusTransacao { get; set; }
        public string CartaoReferencia { get; set; }
        public string NumeroCartaoIdentificador { get; set; }
        public string NumeroCartaoIdentificadorDireito { get; set; }
        public string CodigoAutorizacao { get; set; }

        public string Valor { get; set; }

        public object ProdutoFinanceiro { get; set; }
        public object Autorizador { get; set; }




        public bllOperacaoSac(ModelSystemUserInfoConnect myconnect)
        {
            MyConnect = myconnect;
            _SitefLogs = new bllSitefLogs(MyConnect);
            //_TbProdutosFinanceiros = DaProdutosFinanceiros.Select(MyConnect);
        }


        public void PosAddNewItem()
        {
            try
            {

                if (NumeroEcf.Trim() == "" || NumeroCupomFiscal.Trim() == "" || SeqZanthusTransacao == "" || Autorizador == null || ProdutoFinanceiro == null || CartaoReferencia == "" || NumeroCartaoIdentificador == "" || NumeroCartaoIdentificadorDireito == "")
                {
                    throw new Exception("Favor informar os dados necessários para a inclusão do Pagamento");
                }

                TbSitefLogs item = new Models.TbSitefLogs();
                item.StatusRegistro = StatusRegistro.Insert;
                item.Valor = Convert.ToDouble(Valor);
                item.CdProdutoFinanceiro = ((TbProdutosFinanceiros)ProdutoFinanceiro).CdProdutoFinanceiro;
                item.DescricaoProdutoFinanceiro = ((TbProdutosFinanceiros)ProdutoFinanceiro).DescricaoProdutoFinanceiro;
                item.Autorizador = ((TbAutorizadorFinanceiro)Autorizador).CdAutorizadorFinanceiro;
                item.Ecf = Convert.ToInt32(NumeroEcf);
                item.CartaoReferencia = CartaoReferencia;
                item.CupomFiscal = Convert.ToInt32(NumeroCupomFiscal);
                item.IdentificacaoPdv = NumeroEcf.ToString();
                item.OrigemLancamento = "POS";
                item.SeqZanthusTransacao = Convert.ToInt32(SeqZanthusTransacao);
                item.NumeroCartaoIdentificador = Convert.ToInt32(NumeroCartaoIdentificador);
                item.NumeroCartaoIdentificadorDireito = NumeroCartaoIdentificadorDireito;
                item.CodigoAutorizacao = CodigoAutorizacao;
                _SitefLogs.Add(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
        public void PosDelItemCollecion(int index)
        {
            _SitefLogs.Del(index);

        }



        public void setTbPessoa(TbPessoas tbpessoa)
        {
            try
            {
                
                //tbpessoa = new TbPessoas();
                //tbpessoa.RazaoSocialNome = razaosocialnome.ToString();
                //tbpessoa.Documento = documentoidentificador;
                //tbpessoa.TipoPessoa = tipopessoa;
                if (tbpessoa.CdPessoa == 0)
                {
                    string _DocumentoIdentificador = _TbPessoa.Documento.Documento.ToString();
                    if (Dal.DaPessoa.GetList(MyConnect, TbPessoas.TiposPessoa.Cliente, "", _DocumentoIdentificador, 0).Count() <= 0)
                    {
                        tbpessoa.Status = StatusRegistro.Inserted;
                        _TbPessoa = Dal.DaPessoa.Insert(MyConnect, tbpessoa);
                    }
                }
                else
                {
                    _TbPessoa = tbpessoa;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public void Insert(TbOperacoesSac.TiposOperacaoSac tipooperacao)
        {
            Insert(tipooperacao, null, null);
        }
        public void Insert(TbOperacoesSac.TiposOperacaoSac tipooperacao, TbCupons cupomfiscaldevolvido, TbCuponsItens[] itenscupomfiscaldevolvido)
        {
            try
            {
                TbOperacoesSac regoperacaosac = new TbOperacoesSac();
                regoperacaosac.Status = StatusRegistro.Inserted;
                regoperacaosac.TipoOperacaoSac = tipooperacao;

                switch (tipooperacao)
                {
                    case TbOperacoesSac.TiposOperacaoSac.Devolucao:
                        if (cupomfiscaldevolvido.Devolucao)
                        {
                            throw new Exception("Cupom Fiscal com Registro de Devolução/Emissão de Nfe. Operação Não permitida!");
                        }
                        regoperacaosac.TbPessoa = _TbPessoa;
                        regoperacaosac.TbCupomFiscal = cupomfiscaldevolvido;
                        regoperacaosac.TbCupomFiscalItens = itenscupomfiscaldevolvido;
                        double vl_total = 0;
                        foreach (TbCuponsItens i in itenscupomfiscaldevolvido)
                        {
                            vl_total += Convert.ToDouble(i.QtdeDevolvida * i.Valor);
                        }
                        regoperacaosac.ValorOperacao = vl_total;

                        
                        //TbOperacaoSac = (TbOperacoesSac[])Bll.bllUtil.AddItemList(TbOperacaoSac, regoperacaosac);
                        break;
                    case TbOperacoesSac.TiposOperacaoSac.PagamentoPos:
                        regoperacaosac.ValorOperacao = _SitefLogs.VlPagamentosFinalizadoraPosLancados;
                        regoperacaosac.TbCupomFiscal = new TbCupons(Convert.ToInt32(this.NumeroEcf), Convert.ToInt32(this.NumeroCupomFiscal));
                        if (TbSitefLogsNaoGravados.Count() < 1)
                        {
                            throw new Exception("Não existem itens a serem gravados!");
                        }

                        if (_SitefLogs.VlPagamentoFinalizadoraPos != _SitefLogs.VlPagamentosFinalizadoraPosLancados)
                        {
                            throw new Exception("Valor total dos pagamentos lançados difere do pagamento POS");
                        }

                        foreach (TbSitefLogs i in TbSitefLogsNaoGravados)
                        {   
                            DaSitefLog.Insert(MyConnect, i);
                        }
                        break;


          
                }
                regoperacaosac = Dal.DaOperacaoSac.Insert(MyConnect, regoperacaosac);


            }
            catch (Exception ex)
            {
                throw new Exception(Bll.bllUtil.ErrorString(ex, "Inserindo Operação SAC"));
            }
        }
        public void Select(int Ecf, int CupomFiscal)
        {
            TbOperacaoSac = DaOperacaoSac.Select(MyConnect, Ecf, CupomFiscal, null, null, null, null);
        }
        public void Select(int? Ecf, int? CupomFiscal, DateTime? _dataOperacaoSacIni, DateTime? _dataOperacaoSacFim, int? _cdoperador, int? tipooperacao)
        {
            TbOperacaoSac = DaOperacaoSac.Select(MyConnect, Ecf, CupomFiscal, _dataOperacaoSacIni, _dataOperacaoSacFim, _cdoperador, tipooperacao);
        }
        public void SelectDevolucao(int? Ecf, int? CupomFiscal, DateTime? _dataOperacaoSacIni, DateTime? _dataOperacaoSacFim, int? _cdoperador, int? tipooperacao)
        {
            ItemsDevolvidos = DaOperacaoSac.SelectDevolucoes(MyConnect, Ecf, CupomFiscal, _dataOperacaoSacIni, _dataOperacaoSacFim, _cdoperador, tipooperacao);
        }
        public void SelectPos(int? _ECF, int? _CupomFiscal, int? _cdFinalizadora, int? _seqZanthusTransacao, DateTime? _dataInicial, DateTime? _dataFinal, int? _operador, double? _valorinicial, double? _valorfinal)
        {

            PosList = DaCuponsPagamentos.GetList(MyConnect, _ECF, _CupomFiscal, _cdFinalizadora, _seqZanthusTransacao, _dataInicial, _dataFinal, _operador, _valorinicial, _valorfinal);
        }

    }

    public static class bllOperacaoSacOperadoresAtivos
    {

        public static TbOperacoesSacOperadoresAtivos[] Select(ModelSystemUserInfoConnect _myConnect, DateTime _dataOperacao)
        {
            return Dal.DaOperacaoSacOperadoresAtivos.Select(_myConnect, _dataOperacao);
        }
    }

    public static class bllOperacaoSacFinanceiro
    {
        public static TbOperacoesSacFinanceiro[] Select(ModelSystemUserInfoConnect MyConnect, DateTime _dataOperacao, TbOperacoesSacFinanceiro.TipoInformacao _tipoRelatorio)
        {
            return Select(MyConnect, _dataOperacao, _tipoRelatorio, null, null, null);
        }

        public static TbOperacoesSacFinanceiro[] Select(ModelSystemUserInfoConnect MyConnect, DateTime _dataOperacao, TbOperacoesSacFinanceiro.TipoInformacao _tipoRelatorio, int _cdOperador)
        {
            return Select(MyConnect, _dataOperacao, _tipoRelatorio, _cdOperador, null, null);
        }

        public static TbOperacoesSacFinanceiro[] Select(ModelSystemUserInfoConnect _myConnect, DateTime _dataOperacao, TbOperacoesSacFinanceiro.TipoInformacao _tipoInformacao, int? _cdOperador, int? _eCF, int? _cupomFiscal)
        {
            return Dal.DaOperacaoSacFinanceiro.Select(_myConnect, _dataOperacao, _tipoInformacao, _cdOperador, _eCF, _cupomFiscal);
        }
    }
}
