using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Linq;
using System.Reflection;
using Pag_Net.Models;
using Pag_Net.Dal;
using Pag_Net.Tools.CryptFile;
using Pag_Net.Tools.CryptPassWord;
namespace Pag_Net.Bll.Tables
{
    public class bllTbUsuarios
    {
        private ModelSystemUserInfoConnect myConnect;
        public bllTbUsuarios(ModelSystemUserInfoConnect MyConnect)
        {
            myConnect = MyConnect;
        }
        public ModelTbSisUsuarios[] GetList(string _Nome, DateTime? _DtcadIni, DateTime? _DtCadFim, string _Ativo)
        {
  
            try
            {
                if (_DtcadIni > _DtCadFim) throw new Exception("Período Inválido");
                DaSisUsuarios _dal = new DaSisUsuarios(myConnect);
                return _dal.GetList(_Nome.ToString().ToUpper(), _DtcadIni, _DtCadFim, _Ativo.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public int Update(ModelTbSisUsuarios modelTbUsuario)
        {
            DaSisUsuarios _dal = new DaSisUsuarios(myConnect);
            return _dal.Update(modelTbUsuario);
        }
        public int Insert(ModelTbSisUsuarios modelTbUsuario)
        {
            DaSisUsuarios _dal = new DaSisUsuarios(myConnect);
            return _dal.Insert(modelTbUsuario);
        }
    }
    public class bllTbLogTransacoes
    {
        private ModelSystemUserInfoConnect myConnect;
        public bllTbLogTransacoes(ModelSystemUserInfoConnect MyConnect)
        {
            myConnect = MyConnect;
        }

        public Models.ModelTbLogTransacoes[]  GetList(string datainicial, string datafinal)
        {
            try
            {
                DateTime? _datetimedatainicial = bllUtil.ToDbDateTime(datainicial);
                DateTime? _datetimedatafinal = bllUtil.ToDbDateTime(datafinal);

                DaLogTransacoes _TbLogTransacoes = new DaLogTransacoes(myConnect);
                return _TbLogTransacoes.GetList(0, _datetimedatainicial, _datetimedatafinal).ToArray();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
    public class bllTbErpZanthusLogProdutoPreco
    {
        private ModelSystemUserInfoConnect myConnect;
        public bllTbErpZanthusLogProdutoPreco(ModelSystemUserInfoConnect MyConnect)
        {
            myConnect = MyConnect;
        }
        public Models.ModelTbErpZanthusLogProdutoPreco[] GetList(string  seqlogtransacao,
                          string codigoproduto,
                          string descricaoProduto,
                          string tipoLogTransacao,
                          string dttransacaoInicial,
                          string dttransacaoFinal,
                          string codigobarra)
        {
            try
            {
                int? _intSeqLogTransacao = bllUtil.ToDbInt32(seqlogtransacao);
                int? _intCodigoProduto = bllUtil.ToDbInt32(codigoproduto);
                int? _intTipoLogTransacao = bllUtil.ToDbInt32(tipoLogTransacao);
                DateTime? _datetimeTransacaoInicial = bllUtil.ToDbDateTime(dttransacaoInicial);
                DateTime? _datetimeTransacaoFinal = bllUtil.ToDbDateTime(dttransacaoFinal);
                DaErpZanthusLogProdutoPreco _tbErpZanthusLogProdutoPreco = new DaErpZanthusLogProdutoPreco(myConnect);
                return _tbErpZanthusLogProdutoPreco.GetList(_intSeqLogTransacao, _intCodigoProduto, descricaoProduto, _intTipoLogTransacao, _datetimeTransacaoInicial, _datetimeTransacaoFinal, codigobarra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
    public class bllTbErpZanthusStatusProdutoPreco
    {
         private ModelSystemUserInfoConnect MyConnect;
         public bllTbErpZanthusStatusProdutoPreco(ModelSystemUserInfoConnect myConnect)
         {
             MyConnect = myConnect;
         }

         public Models.ModeloBase.TbStatusProdutoPreco[] GetList()
         {
             try
             {
                 return Dal.DaStatusProdutoPreco.GetList(MyConnect);
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message.ToString());
             }

         }
    }
    public class bllTbComercioInformacoesGerais
    {
         private ModelSystemUserInfoConnect MyConnect;
         public bllTbComercioInformacoesGerais(ModelSystemUserInfoConnect myConnect)
         {
             MyConnect = myConnect;
         }
         public Models.TbComercioInformacoesGerais[] GetList(bool _TotalRegistos,
                                                                    string _TipoConsulta,
                                                                    string _TipoVolume,
                                                                    string _TipoData,
                                                                    int? _CdEmpresa,
                                                                    int? _CdOperacao,
                                                                    DateTime _DataInicial,
                                                                    DateTime _DataFinal,
                                                                    int _fCdPessoaEquipeVendas,
                                                                    int _fCdPessoaVendedor,
                                                                    int _fCdPessoaCliente,
                                                                    int _fCdPessoaFabricante,
                                                                    string _fCdAreaVenda,
                                                                    int _fCepInit,
                                                                    int _fCepFim,
                                                                    int _fCdLinha,
                                                                    int _fCdSecao,
                                                                    int _fCdDepartamento,
                                                                    string _fListaCdProduto,
                                                                    string _fNomeCliente,
                                                                    string _fDescricaoProduto,
                                                                    int? _fQtdeIni,
                                                                    int? _fQtdeFim,
                                                                    double? _fVlPrecoAplicadoIni,
                                                                    double? _fVlPrecoAplicadoFim,
                                                                    double? _fVlTotalIni,
                                                                    double? _fVlTotalFim,
                                                                    decimal? _fMargemIniItem,
                                                                    decimal? _fMargemFimItem,
                                                                    decimal? _fMargemIniPesquisa,
                                                                    decimal? _fMargemFimPesquisa)
         {
             try
             {
                 Dal.DaOperacaoInformacoesGerais x = new Dal.DaOperacaoInformacoesGerais(MyConnect);
                 return x.GetList( _TotalRegistos,
                                                                     _TipoConsulta, 
                                                                     _TipoVolume, 
                                                                     _TipoData,
                                                                     _CdEmpresa,
                                                                     _CdOperacao,
                                                                     _DataInicial , 
                                                                     _DataFinal,
                                                                     _fCdPessoaEquipeVendas,
                                                                     _fCdPessoaVendedor,
                                                                     _fCdPessoaCliente,
                                                                     _fCdPessoaFabricante,
                                                                     _fCdAreaVenda,
                                                                     _fCepInit,
                                                                     _fCepFim,
                                                                     _fCdLinha,
                                                                     _fCdSecao,
                                                                     _fCdDepartamento,
                                                                     _fListaCdProduto,	
                                                                     _fNomeCliente,		
                                                                     _fDescricaoProduto,	
                                                                      _fQtdeIni,			
                                                                     _fQtdeFim,			
                                                                     _fVlPrecoAplicadoIni,	
                                                                     _fVlPrecoAplicadoFim,
                                                                     _fVlTotalIni,	
                                                                     _fVlTotalFim,
                                                                     _fMargemIniItem,	
                                                                     _fMargemFimItem,	
                                                                     _fMargemIniPesquisa,
                                                                     _fMargemFimPesquisa );

             }


             catch (Exception ex)
             {
                 throw new Exception(ex.Message.ToString());
             }

         }
    }
    public class BllTbTipos
    {
        private ModelSystemUserInfoConnect myConnect;
        public BllTbTipos(ModelSystemUserInfoConnect MyConnect)
        {
            myConnect = MyConnect;
        }
        public ModelTbTipos[] GetList (string _NomeTabela, string _NomeCampo)
        {
            DaTipos  _dal = new DaTipos(myConnect);
            return _dal.GetList(_NomeTabela, _NomeCampo);
        }
    }
    public class bllTbFuncao
    {
        private ModelSystemUserInfoConnect myConnect;
        public bllTbFuncao(ModelSystemUserInfoConnect MyConnect)
        {
            myConnect = MyConnect;
        }
        public ModelTbSisFuncao[] GetList(string _Descricao, string _Ativo)
        {
            DaSisFuncao _dal = new DaSisFuncao(myConnect);
            return _dal.GetList(_Descricao.ToString());
        }
    }
    public class bllTbCrmTerminal
    {
        private ModelSystemUserInfoConnect MyConnect;
        public bllTbCrmTerminal(ModelSystemUserInfoConnect myConnect)
        {
            MyConnect = myConnect;
        }

        public int Insert(TbCrmTerminal modelTbCrmTerminal)
        {
            DaCrmTerminal _dal = new DaCrmTerminal(MyConnect);
            return _dal.Insert(modelTbCrmTerminal);
        }
    }

    /* Complementares ***********************************************************/
    public static class bllTbFabricante
    {
        public static  TbFabricante[] GetList(ModelSystemUserInfoConnect  myConnect)
        {
            return Dal.DaFabricante.GetList(myConnect);
            
        }

    }
    public static class bllTbVendedor
    {
        public static TbVendedor[] GetList(ModelSystemUserInfoConnect myconnect)
        {
            return Dal.DaVendedor.GetList(myconnect);
        }
    }
    public static class bllTbEquipe
    {
        public static TbEquipe[] GetList(ModelSystemUserInfoConnect myconnect)
        {
            return Dal.DaEquipe.GetList(myconnect);
        }
    }
    public static class bllTbArea
    {
        public static TbArea[] GetList(ModelSystemUserInfoConnect myconnect)
        {
            return Dal.DaArea.GetList(myconnect);
        }
    }
    public static class bllTbDepartamento
    {
        public static TbDepartamento[] GetList(ModelSystemUserInfoConnect myconnect)
        {
            return Dal.DaDepartamento.GetList(myconnect);
        }
    }
    public static class bllTbSecao
    {
        public static TbSecao[] GetList(ModelSystemUserInfoConnect myconnect, int _cdDepto)
        {
            return Dal.DaSecao.GetList(myconnect, _cdDepto);
        }
    }
    public static class bllTbLinha
    {
        public static TbLinha[] GetList(ModelSystemUserInfoConnect myconnect, int _cdDepto, int _cdSecao)
        {
            return Dal.DaLinha.GetList(myconnect,_cdDepto, _cdSecao);
        }
    }
    public static class bllTbDeptoSecaoLinha
    {
        public static TbDeptoSecaoLinha[] GetList(ModelSystemUserInfoConnect myconnect)
        {
            return Dal.DaDepartamentoSecaoLinha.GetList(myconnect);
        }
    }
    public static class bllTbEmpresas
    {
        public static TbEmpresas[] GetList(ModelSystemUserInfoConnect myconnect)
        {
            return Dal.DaEmpresas.GetList(myconnect);
        }
    }
    public static class bllTbOperacoes
    {
        public static TbOperacoes[] GetList(ModelSystemUserInfoConnect myconnect, int _CdEmpresa)
        {
            return Dal.DaOperacoes.GetList(myconnect, _CdEmpresa);
        }
    }
    public static class bllTbCupons
    {
        public static TbCupons[] GetList(ModelSystemUserInfoConnect myconnect, DateTime _dtInicial, DateTime _dtFinal,
                                                    double? _VlCupomFiscalIni,
                                                    double? _VlCupomFiscalFim,
                                                    double? _VlCupomPagamentoIni,
                                                    double? _VlCupomPagamentoFim,
                                                    bool? _Cancelados,
                                                    int? _CdOperador,
                                                    int? _ECF,
                                                    int? _CupomFiscal)
        {
            return Dal.DaCupons.GetList(myconnect, _dtInicial, _dtFinal,
                _VlCupomFiscalIni,
                _VlCupomFiscalFim,
                _VlCupomPagamentoIni,
                _VlCupomPagamentoFim,
                _Cancelados,
                _CdOperador,
                _ECF,
                _CupomFiscal);   
        }


        //public static bool Devolucao(ModelSystemUserInfoConnect myconnect, int ecf, int cupomfiscal, int cdpessoacliente, TbCuponsItens[] itens)
        //{
            //return Dal.DaCupons.Devolucao(myconnect, ecf, cupomfiscal, cdpessoacliente, itens);
        //}

    }
    public static class bllTbOperadores
    {
        public static TbOperadores[] GetList(ModelSystemUserInfoConnect myconnect)
        {
            return Dal.DaOperadores.GetList(myconnect);
        }
    }
    public static class bllTbECF
    {
        public static TbECF[] GetList(ModelSystemUserInfoConnect myconnect)
        {
            return Dal.DaECF.GetList(myconnect);
        }
    }


    public static class bllTbCuponsItens
    {
        public static TbCuponsItens[] GetList(ModelSystemUserInfoConnect myconnect, 
                                                    int _ECF, 
                                                    int _Cupom)
        {
            return Dal.DaCuponsItens.GetList(myconnect, _ECF, _Cupom);
        }
    }
    public static class bllTbCuponsPagamentos
    {
        public static TbCuponsPagamentos[] GetList(ModelSystemUserInfoConnect myconnect, int _ECF, int _Cupom)
        {
            return Dal.DaCuponsPagamentos.GetList(myconnect, _ECF, _Cupom);
        }
    }
    public class bllTbPedido
    {

        public double NumeroPedidos { get; set; }
        public double BaseValor { get; set; }
        public double BaseMargem { get; set; }
        public double TabelaValor { get; set; }
        public double TabelaMargem { get; set; }
        public double AplicadoValor { get; set; }
        public double AplicadoMargem { get; set; }
        public double FinanceiroValor { get; set; }
        public double FinanceiroMargem { get; set; }
        public double VerbaVendedor { get; set; }
        public double VerbaFornecedor { get; set; }
        public double CustoValor { get; set; }
        public double MargemLiquida { get; set; }
        private Dal.DaPedido _TbPedido;


        public bllTbPedido(ModelSystemUserInfoConnect myconnect, DateTime _dtini, DateTime _dtfim, int? _numeropedido, int? _codigocliente, string _codigovendedor, string _NomeCliente, string _DescricaoFabricante)
        {
            _TbPedido = new DaPedido(myconnect, _dtini, _dtfim, _numeropedido, _codigocliente, _codigovendedor, _NomeCliente, _DescricaoFabricante);
        }
        public TbPedido[] GetList()
        {
            return _TbPedido.PedidoGetList();
        }
        public TbPedidoItens[] GetListItens(int _NumeroPedidoSelecionado)
        {
            return _TbPedido.PedidoItensGetList( _NumeroPedidoSelecionado);
        }

        public TbPedidoFabricante[] GetListFabricante(int _NumeroPedidoSelecionado)
        {
            return _TbPedido.PedidoFabricanteGetList(_NumeroPedidoSelecionado);
        }
    }
    public static class bllTbDisponibilidade
    {
        public static TbDisponibilidadeEmpresa[] GetListDisponibilidadeEmpresa(ModelSystemUserInfoConnect myconnect, int _CdEmpresa,
                                                                                                                            int _CdOperacao,
                                                                                                                            int _CdDepartamento,
                                                                                                                            int _CdSecao,
                                                                                                                            int _CdLinha,
                                                                                                                            string _CdProduto,
                                                                                                                            string _DescricaoProduto,
                                                                                                                            string _CdBarra,
                                                                                                                            int _CdEquipeRepositor
                                                                                                                            )
        {
            return Dal.DaDisponibilidade.GetListDisponibilidadeEmpresa(myconnect, _CdEmpresa, _CdOperacao, _CdDepartamento, _CdSecao, _CdLinha, _CdProduto, _DescricaoProduto, _CdBarra, _CdEquipeRepositor);
        }
        /*
        public static ModelTbDisponibilidadeOperacao[] GetListDisponibilidadeOperacao(ModelSystemUserInfoConnect myconnect, int _CdEmpresa,
                                                                                                                            int _CdOperacao,
                                                                                                                            int _TipoPesquisa
                                                                                      )
        {
            return Dal.TbDisponibilidade.GetListDisponibilidadeOperacao(myconnect, _CdEmpresa, _CdOperacao, _TipoPesquisa);
        }
         */
    }
    public static class bllTbEquipeRepositor
    {
        public static TbEquipeRepositor[] GetList(ModelSystemUserInfoConnect myconnect)
        {
            return Dal.DaEquipeRepositor.GetList(myconnect);
        }
    }
    public class bllPessoa
    {
        public ModelSystemUserInfoConnect MyConnect;
        public TbPessoas[] TbPessoas { get; set; }
        public bllPessoa(ModelSystemUserInfoConnect _MyConnect)
        {
            MyConnect = _MyConnect;
        }
        public void GetList( TbPessoas.TiposPessoa tipopessoa)
        {
            GetList(tipopessoa, "", "", 0);
        }
        public void GetList(TbPessoas.TiposPessoa tipopessoa, string _RazaoSocialNome, string _DocumentoIdentificador, int _CdErpCliente)
        {
            this.TbPessoas = Dal.DaPessoa.GetList(MyConnect, tipopessoa, _RazaoSocialNome, _DocumentoIdentificador, _CdErpCliente);
        }
        public void Insert(int cdpessoa, 
                            string razaosocialnome, 
                            TbDocumentos documento)
        {
           TbPessoas = (TbPessoas[])Pag_Net.Bll.bllUtil.AddItemList(TbPessoas, (Object)Dal.DaPessoa.Insert(MyConnect, new TbPessoas(razaosocialnome, documento)));
        }
    }


    


}

