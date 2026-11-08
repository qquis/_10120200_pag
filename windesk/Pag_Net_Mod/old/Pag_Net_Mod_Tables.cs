using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Models
{

    public enum StatusRegistro
    {
        Null = 0,
        Insert = 1,
        Change = 2,
        Delete = 3,
        Changed = 4,
        Deleted = 5,
        Inserted = 6,
        NoInsert = 7,
        NoChange =8,
        NoDelete = 9


    }
    public enum  PagdataTipoProcedimento
    {
        Update,
        Select,
        Delete,
        Insert
    }
    public class TbItens
    {
        public string Id { get; set; }
        public string Cd_vend { get; set; }
        public string Nu_ped_local { get; set; }
        public string Cd_prod { get; set; }
        public string Unid_ped { get; set; }
        public string Qtde { get; set; }
        public string Preco_unit { get; set; }
        public string Preco_tabela { get; set; }
        public string Desc_apl { get; set; }
        public string Vl_verba { get; set; }
        public string Bonificado { get; set; }
        public TbItens(string Id,
                     string Cd_vend,
                     string Nu_ped_local,
                     string Cd_prod,
                     string Unid_ped,
                     string Qtde,
                     string Preco_unit,
                     string Preco_tabela,
                     string Desc_apl,
                     string Vl_verba,
                     string Bonificado)
        {
            this.Id = Id;
            this.Cd_vend = Cd_vend;
            this.Nu_ped_local = Nu_ped_local;
            this.Cd_prod = Cd_prod;
            this.Unid_ped = Unid_ped;
            this.Qtde = Qtde;
            this.Preco_unit = Preco_unit;
            this.Preco_tabela = Preco_tabela;
            this.Desc_apl = Desc_apl;
            this.Vl_verba = Vl_verba;
            this.Bonificado = Bonificado;
        }
    }
    public class TbPedidos
    {
        public string Id { get; set; }
        public string Cd_Clien { get; set; }
        public string Dt_ped { get; set; }
        public string Dt_Prev_Fatu { get; set; }
        public string Dt_Entrega { get; set; }
        public string FormPgto { get; set; }
        public string Cd_Tabela { get; set; }
        public string Seq_Prom { get; set; }
        public string Tp_Entrega { get; set; }
        public string Tp_Ped { get; set; }
        public string Tp_Frete { get; set; }
        public string Nu_ped_Cli { get; set; }
        public string Msg_Credito { get; set; }
        public string Msg_Comercial { get; set; }
        public string Msg_Adm { get; set; }
        public string Msg_Fatur { get; set; }
        public string Msg_Expedicao { get; set; }
        public string Dt_Ped_Hora { get; set; }
        public string Cd_Vend { get; set; }
        public string Nu_Ped_local { get; set; }
        public string StatusExportEletronico { get; set; }

        public TbPedidos(string Id,
                       string Cd_Clien,
                       string Dt_ped,
                       string Dt_Prev_Fatu,
                       string Dt_Entrega,
                       string FormPgto,
                       string Cd_Tabela,
                       string Seq_Prom,
                       string Tp_Entrega,
                       string Tp_Ped,
                       string Tp_Frete,
                       string Nu_ped_Cli,
                       string Msg_Credito,
                       string Msg_Comercial,
                       string Msg_Adm,
                       string Msg_Fatur,
                       string Msg_Expedicao,
                       string Dt_Ped_Hora,
                       string Cd_Vend,
                       string Nu_Ped_Local )
        {
            this.Id = Id.Trim();
            this.Cd_Clien = Cd_Clien;
            this.Dt_ped = Dt_ped;
            this.Dt_Ped_Hora = Dt_Ped_Hora;


            this.Dt_Prev_Fatu = Dt_Prev_Fatu;
            this.Dt_Entrega = Dt_Entrega;
            this.FormPgto = FormPgto;
            this.Cd_Tabela = Cd_Tabela;
            this.Seq_Prom = Seq_Prom;
            this.Tp_Entrega = Tp_Entrega;
            this.Tp_Ped = Tp_Ped;
            this.Tp_Frete = Tp_Frete;
            this.Nu_ped_Cli = Nu_ped_Cli;
            this.Msg_Credito = Msg_Credito;
            this.Msg_Comercial = Msg_Comercial;
            this.Msg_Adm = Msg_Adm;
            this.Msg_Fatur = Msg_Fatur;
            this.Msg_Expedicao = Msg_Expedicao;
            this.Cd_Vend = Cd_Vend;
            this.Nu_Ped_local = Nu_Ped_Local;
        }
    }
    public class TbClientes
    {
        public string Cd_Clien { get; set; }
        public string Razao_Social { get; set; }

        public TbClientes(
                    string Cd_Clien,
                    string Razao_Social)
        {
            this.Cd_Clien = Cd_Clien;
            this.Razao_Social = Razao_Social;
        }
    }
    public class TbServicesTime
    {
        public string Id { get; set; }
        public string TimeId { get; set; }
        public string DateIni { get; set; }
        public string DateFin { get; set; }
        public string Hor { get; set; }
        public string Min { get; set; }
        public string Second { get; set; }
        public string WeekDay { get; set; }

        public TbServicesTime(string id,
                                        string timeId,
                                        string dateIni,
                                        string dateFin,
                                        string hor,
                                        string min,
                                        string second,
                                        string weekday)
        {
            this.Id = id.ToString();
            this.TimeId = timeId.ToString();
            this.DateIni = dateIni.ToString();
            this.DateFin = dateFin.ToString();
            this.Hor = hor.ToString();
            this.Min = min.ToString();
            this.Second = second.ToString();
            this.WeekDay = weekday.ToString();
        }

    }
    public class TbCrmTerminal
    {
        public int SeqLancamento {get; set;}
        public ModelTbTipos TipoLancamento { get; set; }
        public String Cep { get; set; }
        public String ProdutoNaoEncontrado { get; set; }
        public String ObservacaoCritica { get; set; }

        public TbCrmTerminal(ModelTbTipos tipolancamento)
        {
            TipoLancamento = tipolancamento;
        }
    }
    public class TbComercioInformacoesGerais
    {
        public string CodigoInformacao { get; set; }
        public string Descricao { get; set; }
        public int Pos { get; set; }
        public int Mix { get; set; }
        public double Volume { get; set; }
        public double Venda { get; set; }
        public double Custo { get; set; }
        public double Margem { get; set; }
        public int Clientes { get; set; }
        public double Participacao { get; set; }
        public string Unidade { get; set; }
        public double Estoque { get; set; }
        public double VlCustoUnitario { get; set; }
        public double ParticipacaoEstoque { get; set; }
        public TbComercioInformacoesGerais
            (string codigoinformacao,
            string descricao,
            int pos,
            int mix,
            double volume,
            double venda,
            double custo,
            int clientes,
            double margem,
            double participacao,
            string unidade,
            double estoque,
            double vlcustounitario,
            double participacaoestoque)
        {
            this.CodigoInformacao = codigoinformacao;
            this.Descricao = descricao;
            this.Pos = pos;
            this.Mix = mix;
            this.Volume = volume;
            this.Venda = venda;
            this.Custo = custo;
            this.Margem = margem;
            this.Clientes = clientes;
            this.Participacao = participacao;
            this.Unidade = unidade;
            this.Estoque = estoque;
            this.VlCustoUnitario = vlcustounitario;
            this.ParticipacaoEstoque = participacaoestoque;
        }
    }
    public class TbCupons
    {
        public DateTime DataCupom { get; set; }
        public int CdOperador { get; set; }
        public string NomeOperador { get; set; }
        public int Ecf { get; set; }
        public int Cupom { get; set; }
        public double Valor { get; set; }
        public double ValorDevolucao { get; set; }
        public bool Devolucao { get; set; }
        public bool Nfe { get; set; }
        public TbCupons(){}
        public TbCupons(int ecf, int numerocupom)
        {
            this.Ecf = ecf;
            this.Cupom = numerocupom;
        }
        public TbCupons(DateTime datacupom, int cdoperador, string nomeoperador, int ecf, int cupom, double valor)
        {
            this.DataCupom = datacupom;
            this.CdOperador = cdoperador;
            this.NomeOperador = nomeoperador;
            this.Ecf = ecf;
            this.Cupom = cupom;
            this.Valor = valor;
        }
    }
    public class TbOperadores
    {
        public int CdOperador { get; set; }
        public string NomeOperador { get; set; }
        public TbOperadores(int cdoperador, string nomeoperador)
        {
            this.CdOperador = cdoperador;
            this.NomeOperador = nomeoperador;
        }
        public TbOperadores() { }
    }
    public class TbECF
    {
        public int ECF { get; set; }
        public TbECF(int ecf)
        {
            this.ECF = ecf;
        }
    }
    public class TbCuponsPagamentos
    {
        public int Ecf { get; set; }
        public int CupomFiscal { get; set; }
        public string Autorizador { get; set; }
        public int SeqProdutoFinanceiro { get; set; }
        public string CdProdutoFinanceiro { get; set; }
        public string DescricaoProdutoFinanceiro { get; set; }
        public int CdFinalizadora { get; set; }
        public string DescricaoFinalizadora { get; set; }
        public double Valor { get; set; }
        public string EstadoTransacao { get; set; }
        public string DocumentoTransacao { get; set; }
        public string CodigoAutorizacao { get; set; }
        public double ValorTransacao { get; set; }
        public DateTime DataEmissao { get; set; }
        public string NomeOperador { get; set; }
        public int SeqZanthusTransacao { get; set; }
        public bool LancamentoPos
        {
            get
            {
                if (EstadoTransacao.Trim() == "EFETUADA")
                    return true;
                else
                    return false;
            }
        }
        public TbCuponsPagamentos() { }
        public TbCuponsPagamentos(int cdfinalizadora, string descricaofinalizadora, double valor)
        {
            this.CdFinalizadora = cdfinalizadora;
            this.DescricaoFinalizadora = descricaofinalizadora;
            this.Valor = valor;
        }
        public TbCuponsPagamentos(int cdfinalizadora, string descricaofinalizadora, double valor,
                                    string autorizador,
                                    int seqprodutofinanceiro,
                                    string cdprodutofinanceiro,
                                    string descricaoprodutofinanceiro,
                                    string estadotransacao,
                                    string documentotransacao,
                                    string codigoautorizacao,
                                    double valortransacao)
        {
            this.CdFinalizadora = cdfinalizadora;
            this.DescricaoFinalizadora = descricaofinalizadora;
            this.Valor = valor;
            this.Autorizador = autorizador;
            this.SeqProdutoFinanceiro = seqprodutofinanceiro;
            this.CdProdutoFinanceiro = cdprodutofinanceiro;
            this.DescricaoProdutoFinanceiro = descricaoprodutofinanceiro;
            this.EstadoTransacao = estadotransacao;
            this.DocumentoTransacao = documentotransacao;
            this.CodigoAutorizacao = codigoautorizacao;
            this.ValorTransacao = valortransacao;

        }
    }
    public class TbCuponsItens
    {
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public string CodigoBarra { get; set; }
        public decimal Qtde { get; set; }
        public decimal QtdeDevolvida { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public string Embalagem { get; set; }
        public bool Devolucao { get; set; }
        public TbCuponsItens(int cdproduto, string descricao, string codigobarra, string embalagem, decimal qtde, decimal valor, decimal desconto, decimal valortotal)
        {
            this.CdProduto = cdproduto;
            this.CodigoBarra = codigobarra;
            this.Descricao = descricao;
            this.Qtde = qtde;
            this.Valor = Math.Round( valortotal / qtde,4) ;
            this.Desconto = desconto;
            this.ValorTotal = valortotal;
            this.Embalagem = embalagem;
        }
    }
    public class TbPedido
    {
        public int NumeroPedido { get; set; }
        public int CodigoCliente { get; set; }
        
        public string NomeCliente { get; set; }
        public string CodigoVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string PrazoPagamento { get; set; }
        public DateTime Data { get; set; }
        public string TipoPedido { get; set; }
        public string TipoEntrega { get; set; }
        public string TipoTabela { get; set; }
        public string Regiao { get; set; }
        public string StatusPedido { get; set; }


        public double ValorPedido { get; set; }
        public double ValorFaturamentoBruto { get; set; }
        public double ValorFaturamento { get; set; }
        public double ValorFaturamentoAplicado { get; set; }
        public double ValorFaturamentoFinanceiro { get; set; }

        public double VolumeTotal { get; set; }
        
        public double ValorDescontoTotal { get; set; }
        public double ValorDescontoFinanceiroTotal {get; set;}

        
        public double ValorCustoTotal { get; set; }
        public double ValorVerbaTotal { get; set; }
        public double ValorVerbaFabricanteTotal { get; set; }

        public double MargemBruta { get; set; }
        public double MargemFinanceira { get; set; }
        public double MargemAplicada { get; set; }
        public double MargemAplicadaFinanceira { get; set; }
        public double MargemLiquida { get; set; }

        public TbPedido()
        {

        }
    

    }
    public class TbPedidoItens
    {
        public int NumeroPedido { get; set; }
        public int CdProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public double ValorPrecoBasico { get; set; }
        public double ValorPrecoTabela { get; set; }
        public double ValorPrecoAplicado { get; set; }
        public double Qtde { get; set; }
        public decimal PercentualDescontoAplicado { get; set; }
        public decimal PercentualDescontoFinanceiro { get; set; }
        public decimal PercentualDescontoGeral { get; set; }
        public double CustoTotalItem { get; set; }
        public double ValorVerbaAplicada { get; set; }
        public double ValorVerbaFornecedor { get; set; }
        public double ValorVendaBruta { get; set; }
        public double ValorItemPrecoBasico { get; set; }
        public double ValorItemPrecoTabela { get; set; }
        public double ValorItemPrecoAplicado { get; set; }
        public double ValorItemPrecoFinanceiroAplicado { get; set; }
        public decimal PercentualMargemBruta { get; set; }
        public decimal PercentualMargemFinanceira { get; set; }
        public decimal PercentualMargemAplicada { get; set; }
        public decimal PercentualMargemFinanceiraAplicada { get; set; }
        public decimal PercentualMargemLiquida { get; set; }
        public TbPedidoItens()
        { }
    }
    public class TbPedidoFabricante
    {
        public int NumeroPedido { get; set; }
        public string Descricao { get; set; }
        public int NumeroItens { get; set; }
        public double Qtde { get; set; }
        public double CustoTotalItem { get; set; }
        public double ValorVerbaAplicada { get; set; }
        public double ValorVerbaFornecedor { get; set; }
        public double ValorVendaBruta { get; set; }
        public double ValorItemPrecoBasico { get; set; }
        public double ValorItemPrecoTabela { get; set; }
        public double ValorItemPrecoAplicado { get; set; }
        public double ValorItemPrecoFinanceiroAplicado { get; set; }
        public decimal PercentualMargemBruta { get; set; }
        public decimal PercentualMargemFinanceira { get; set; }
        public decimal PercentualMargemAplicada { get; set; }
        public decimal PercentualMargemFinanceiraAplicada { get; set; }
        public decimal PercentualMargemLiquida { get; set; }
        public TbPedidoFabricante()
        {

        }
    }
    public class TbFabricante
    {
        public int CodigoFabricante { get; set; }
        public string DescricaoFabricante { get; set; }

        public TbFabricante(int codigofabricante,
                                string descricaofabricante
            )
        {
            this.CodigoFabricante = codigofabricante;
            this.DescricaoFabricante = descricaofabricante.TrimEnd();
        }


    }
    public class TbVendedor
    {
        public int CodigoVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string CdERPVendedor { get; set; }

        public TbVendedor(int codigovendedor,
                                string nomevendedor,
                                string cderpvendedor
            )
        {
            this.CodigoVendedor = codigovendedor;
            this.NomeVendedor = nomevendedor.TrimEnd();
            this.CdERPVendedor = cderpvendedor.ToString();
        }
    }
    public class TbEquipe
    {
        public int CodigoEquipe { get; set; }
        public string DescricaoEquipe { get; set; }

        public TbEquipe(int codigoequipe,
                             string descricaoequipe
            )
        {
            this.CodigoEquipe = codigoequipe;
            this.DescricaoEquipe = descricaoequipe.TrimEnd();
        }
    }
    public class TbArea
    {
        public string CodigoArea { get; set; }
        public string DescricaoArea { get; set; }

        public TbArea(string codigoarea,
                            string descricaoarea
            )
        {
            this.CodigoArea = codigoarea.Trim();
            this.DescricaoArea = descricaoarea.TrimEnd();
        }
    }
    public class TbDeptoSecaoLinha
    {
        public int CdDepartamento { get; set; }
        public int CdSecao { get; set; }
        public int CdLinha { get; set; }
        public string DescricaoDepartamento { get; set; }
        public string DescricaoSecao { get; set; }
        public string DescricaoLinha { get; set; }
        public TbDeptoSecaoLinha (int cddepartamento, int cdsecao, int cdlinha, string descricaodepartamento, string descricaosecao, string descricaolinha )
        {
            this.CdDepartamento = cddepartamento;
            this.CdSecao = cdsecao;
            this.CdLinha = cdlinha;
            this.DescricaoDepartamento = descricaodepartamento;
            this.DescricaoSecao = descricaosecao;
            this.DescricaoLinha = descricaolinha;

        }

    }
    public class TbDepartamento
    {
        public int CodigoDepartamento { get; set; }
        public string DescricaoDepartamento { get; set; }

        public TbDepartamento(int codigodepartamento,
                            string descricaodepartamento
            )
        {
            this.CodigoDepartamento = codigodepartamento;
            this.DescricaoDepartamento = descricaodepartamento;
        }
    }
    public class TbSecao
    {
        public int CodigoSecao { get; set; }
        public string DescricaoSecao { get; set; }

        public TbSecao(int codigosecao,
                            string descricaosecao
            )
        {
            this.CodigoSecao = codigosecao;
            this.DescricaoSecao = descricaosecao.TrimEnd();
        }
    }
    public class TbLinha
    {
        public int CodigoLinha { get; set; }
        public string DescricaoLinha { get; set; }

        public TbLinha(int codigolinha,
                            string descricaolinha
            )
        {
            this.CodigoLinha = codigolinha;
            this.DescricaoLinha = descricaolinha.TrimEnd();
        }
    }
    public class TbEmpresas
    {
        public int CdEmpresa { get; set; }
        public string DescricaoEmpresa { get; set; }
        public TbEmpresas(string descricaoempresa)
        {
            this.DescricaoEmpresa = descricaoempresa;
        }
    }
    public class TbOperacoes
    {
        public int CdOperacao { get; set; }
        public string DescricaoOperacao { get; set; }
        public int CdEmpresa { get; set; }
        public TbOperacoes(int cdoperacao, string descricaooperacao, int cdempresa)
        {
            this.CdOperacao = cdoperacao;
            this.DescricaoOperacao = descricaooperacao;
            this.CdEmpresa = cdempresa;
        }
    }
    public class TbProduto
    {
        public int CdProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string EmbalagemEstoque { get; set; }
        public bool StatusProduto { get; set; }
        public TbProduto(){ }
    }
    public class TbDisponibilidade
    {
        public int CdEmpresa { get; set; }
        public int CdOperacao { get; set; }
        public int CdProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public double ValorPrecoBase { get; set; }
        public TbDisponibilidade()
        {

        }
    }
    public class TbDisponibilidadeEmpresa : TbDisponibilidade
    {
        public string CdBarra { get; set; }
        public double Qtde { get; set; }
        public string UndCmp { get; set; }
        public string UndEst { get; set; }
        public double Fator { get; set; }
        public double EstoqueAtual { get; set; }
        public double ValorCusto { get; set; }
        public TbDisponibilidadeEmpresa()
        {

        }
    }
    public class TbDisponibilidadeOperacao : TbDisponibilidade
    {
        public string EmbalagemEstoque { get; set; }
        public string TipoCodigoBarra { get; set; }
        public string CodigoBarra { get; set; }
        public double Qtde { get; set; }
        public string EmbalagemVenda { get; set; }
        public double FatorEmbalagemVenda { get; set; }
        public string RelacaoEmbalagemVenda { get; set; }
        public string EmbalagemCompra { get; set; }
        public string FatorEmbalagemCompra { get; set; }
        public double FatorPrecoAplicado { get; set; }
        public double ValorPrecoEmabaLogFileem { get; set; }
        public double ValorDespesaEmbalagem { get; set; }
        public TbDisponibilidadeOperacao()
        {

        }
    }
    public class TbPessoas
    {
        public enum TiposPessoa
        {
            Cliente = 10,
            Fornecedor = 11,
            Fabricante = 12,
            FornecedorCliente = 13,
            GrupoCliente = 14,
            RepComercialOxan = 15,
            RepComercialFornecedor = 16,
            EquipeDeVendas = 17,
            Repositor = 18
        }
        public int CdPessoa { get; set; }
        public string RazaoSocialNome { get; set; }
        public TiposPessoa TipoPessoa { get; set; }
        public bool StatusPessoa { get; set; }
        public TbDocumentos Documento { get; set; }

        public int CdErpCliente { get; set; }
        public int CdErpFornecedor { get; set; }
        public int CdEquipeRepositor { get; set; }
        public string DescricaoEquipeRepositor { get; set; }
        //public TbEnderecos[] Enderecos { get; set; }
        public StatusRegistro Status { get; set; }
        public TbPessoas() { }
        public TbPessoas(string razaosocialnome, TbDocumentos documentoidentificador)
        {
            this.RazaoSocialNome = razaosocialnome;
            this.Documento = documentoidentificador;

        }
        public TbPessoas(int cdpessoa, string razaosocialnome, TbDocumentos documentoidentificador, bool statuspessoa, TiposPessoa tipopessoa, int cderpcliente, 
            int cdequiperepositor, string descricaoequiperepositor
            ) 
        {
            
            this.CdPessoa = cdpessoa;
            this.RazaoSocialNome = razaosocialnome.ToString();
            this.Documento = documentoidentificador;
            this.StatusPessoa = statuspessoa;
            this.TipoPessoa = tipopessoa;
            this.CdErpCliente = cderpcliente;
            this.CdEquipeRepositor = cdequiperepositor;
            this.DescricaoEquipeRepositor = descricaoequiperepositor;
        }
    }
    public class TbEnderecos
    {
        public enum TiposEndereco
        {
            Faturamento = 1,
            Cobranca = 2,
            Entrega = 3,
            Outros = 4
        }
        public int SeqEndereco { get; set; }
        public TiposEndereco TipoEndereco {get;set;}
        public int CdPessoa { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public TbEnderecos(int seqendereco, TiposEndereco tipoendereco, int cdpessoa, string logradouro, int numero, int cep, string bairro, string municipio, string estado, string pais)
        {
            SeqEndereco = seqendereco;
            TipoEndereco = tipoendereco;



        }
    }
    public class TbEquipeRepositor
    {
        public int CodigoEquipeRepositor { get; set; }
        public string DescricaoEquipeRepositor { get; set; }

        public TbEquipeRepositor(int codigoequiperepositor,
                                        string descricaoequiperepositor
            )
        {
            this.CodigoEquipeRepositor = codigoequiperepositor;
            this.DescricaoEquipeRepositor = descricaoequiperepositor.TrimEnd();
        }
    }
    public class TbOperacoesSac
    {
        public enum TiposOperacaoSac
        {
            Devolucao = 19,
            EmiteNfe = 20,
            DevolucaoDinheiro = 21,
            PagamentoPos = 23,
        }
        public int SeqOperacaoSac { get; set; }
        public DateTime DataLancamento {get; set; }
        public TiposOperacaoSac TipoOperacaoSac { get; set; }
        public string TipoOperacaoSacGetDescricao
        {
            get
            {
                string DescricaoTipoOperacao = "Sem definição";
                if (TipoOperacaoSac == TiposOperacaoSac.Devolucao) DescricaoTipoOperacao = "Devolução de Produto";
                if (TipoOperacaoSac == TiposOperacaoSac.DevolucaoDinheiro) DescricaoTipoOperacao = "Devolução C/ Dinheiro";
                if (TipoOperacaoSac == TiposOperacaoSac.EmiteNfe) DescricaoTipoOperacao = "Emissão de Nota Fiscal Eletrônica";
                if (TipoOperacaoSac == TiposOperacaoSac.PagamentoPos) DescricaoTipoOperacao = "Pagamento POS";
                return DescricaoTipoOperacao;
            }
        }
        public TbCupons TbCupomFiscal { get; set; }
        public TbCuponsItens[] TbCupomFiscalItens { get; set; }
        public int Ecf { get { return TbCupomFiscal.Ecf; } }
        public int CupomFiscal { get { return TbCupomFiscal.Cupom; } }
        public int CdOperador { get { return TbCupomFiscal.CdOperador; } }
        public string NomeOperador { get { return TbCupomFiscal.NomeOperador; } }
        public TbPessoas TbPessoa { get; set; }
        public string TbPessoaGetNome { get { return TbPessoa.RazaoSocialNome.ToString(); } }
        public int SequencialDocumento {get; set;}
        public bool NfeStatus {get; set;}
        public int Nfe {get; set;}
        public int NumeroPedidoErpMoinho {get; set;}
        public StatusRegistro Status { get; set; }
        public double ValorOperacao { get; set; }
        public TbOperacoesSac() {}
    }
    public class TbOperacoesSacOperadoresAtivos
    {
        public int CdOperador { get; set; }
        public int ECF { get; set; }
        public string NomeOperador { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }
        public int Registros { get; set; }
        public double ValorEntrada { get; set; }
        public double ValorFaturamentoDinheiro { get; set; }
        public double ValorReforco { get; set; }
        public double ValorSangria { get; set; }
        public double ValorSaldo
        {
            get { return ValorEntrada + ValorFaturamentoDinheiro + ValorReforco - ValorSangria; } 
        }
        public bool ExigeSangria
        {
            get
            {
                if (ValorSaldo > 1000)
                    return true;
                else
                    return false;
            } 
        }


    }
    public class TbOperacoesSacFinanceiro
    {
        public enum TipoInformacao
        {
            DetalheRecebimentos = 0,
            ResumoRecebimentoFinalizadora = 1,
            ResumoRecebimentoProdutoFinanceiro = 2,
            ResumoRecebimentoAutorizador = 3,
            ResumoFinalizadoraProdutoFinanceiro = 4
        }
        public int CdOperador { get; set; }
        public string NomeOperador { get; set; }
        public DateTime DataEmissao { get; set; }
        public int Ecf { get; set; }
        public int CupomFiscal { get; set; }
        public string Finalizadora { get; set; }
        public string Autorizador { get; set; }
        public string ProdutoFinanceiro { get; set; }
        public string CartaoReferencia { get; set; }
        public double Valor { get; set; }
        public double ValorRecebido { get; set; }
        public double ValorDevolvido { get; set; }
        public double ValorCancelado { get; set; }
        public double ValorLiquido { get; set; }
    }

    /*Tabelas de Processamento*/
    public class ModelTbErpZanthusLogProdutoPreco
    {
        public int SeqLogTransacao { get; set; }
        public DateTime Data { get; set; }
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string UnidadeVenda { get; set; }
        public double PrecoAplicado { get; set; }
        public double PrecoAnterior { get; set; }
        public string TipoTransacao { get; set; }
        public string CodigoBarra { get; set; }
        public ModelTbErpZanthusLogProdutoPreco(int seqlogtransacao
                                                , DateTime data 
                                                , int    codigoproduto 
                                                , string    descricaoproduto
                                                , string    unidadevenda 
                                                , double    precoaplicado  
                                                , double    precoanterior  
                                                , string    tipotransacao 
                                                , string codigobarra                        
            )
        {
            this.SeqLogTransacao = seqlogtransacao;
            this.Data = data;
            this.CodigoProduto = codigoproduto;
            this.DescricaoProduto = descricaoproduto.ToString();
            this.UnidadeVenda = unidadevenda.ToString();
            this.PrecoAplicado = precoaplicado;
            this.PrecoAnterior = precoanterior;
            this.TipoTransacao = tipotransacao;
            this.CodigoBarra = codigobarra;
        }
    }
    public class ModelTbLogTransacoes
    {
        public int SeqLogTransacao { get; set; }
        public DateTime Data { get; set; }
        public int ItensProcessados { get; set; }
        public int ItensAlterados { get; set; }
        public int ItensIncluidos { get; set; }
        public int ItensExcluidos { get; set; }
        public string TransacaoObservacao { get; set; }
        public bool TransacaoResultado { get; set; }
        public string CdTipo { get; set; }
        public string TransacaoTipo { get; set; }

        public string Usuario { get; set; }
        public ModelTbLogTransacoes(int seqlogtransacao, DateTime data)
        {
            this.Data = data;
            this.SeqLogTransacao = seqlogtransacao;


        }

    }
    
    /* Tabelas de Sistema */
    public class ModelTbSisUsuarios
    {
        public string Userid { get; set; }
        public string Nome { get; set; }
        public string PassWord { get; set; }
        public DateTime Dt_cad { get; set; }
        public string Email { get; set; }
        public ModelTbSisFuncao Funcao { get; set; }
        public bool Status {get;set;}
        public string UsuarioMoinho { get; set; }
        public string CdVend { get; set; }
        public string Autorizacao { get; set; }
        public ModelTbSisUsuarios(string userid,
                                string nome,
                                string passWord,
                                string dt_cad,
                                string email,
                                ModelTbSisFuncao funcao,
                                bool status,
                                string usuariomoinho,
                                string autorizacao,
                                string cd_vend
            )
        {
            this.Userid = userid;
            this.Nome = nome;
            this.PassWord = passWord;
            this.Dt_cad = Convert.ToDateTime(dt_cad.ToString()) ;
            this.Email = email;
            this.Funcao = funcao;
            this.Status = status;
            this.UsuarioMoinho = usuariomoinho.ToString();
            this.Autorizacao = autorizacao.ToString();
            this.CdVend = cd_vend.ToString();

        }
    }
    public class ModelTbSisFuncao
    {
        public int CdFuncao { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public ModelTbSisFuncao
            (string cdfuncao,
             string descricao,
             string ativo
            )
        {
            if (cdfuncao.ToString() == null || cdfuncao.ToString() == "")
            {
                this.CdFuncao = 0;
                this.Descricao = "SEM FUNÇÃO DEFINIDA";
                this.Ativo = true;
            }
            else
            {
                this.CdFuncao = Convert.ToInt32(cdfuncao.ToString());
                this.Descricao = descricao.ToUpper().ToString();
                this.Ativo = Convert.ToBoolean(ativo.ToString());
            }

            
       }


    }
    public class ModelTbTipos
    {
        public string DescricaoTipo { get; set; }
        public int SeqTipo { get; set; }
        public string ObservacaoTipo { get; set; }
        public string CdTipo { get; set; }

        public ModelTbTipos()
        {

        }
    }
    public class TbStatusProdutoPreco
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime Cadastro { get; set; }
        public string CodigoBarra { get; set; }
        public string Unidade { get; set; }
        public double PrecoOn { get; set; }
        public double PrecoOx { get; set; }
        public double PrecoZanthus { get; set; }
        public string Situacao { get; set; }
        public double EstoqueAtual { get; set; }

        public TbStatusProdutoPreco() { }

        public TbStatusProdutoPreco
            (int codigo,
            string descricao,
            DateTime cadastro,
            string codigobarra,
            string unidade,
            double precoon,
            double precoox,
            double precozanthus,
            string situacao)
        {
            Codigo = codigo;
            Descricao = descricao;
            Cadastro = cadastro;
            CodigoBarra = codigobarra;
            Unidade = unidade;
            PrecoOn = precoon;
            PrecoOx = precoox;
            PrecoZanthus = precozanthus;
            Situacao = situacao;
        }
    }

    /* Expotacao de Arquivos */
    public class ModelExportFile
    {
        public string NomeArquivo { get; set; }
        public int SeqLinha { get; set; }
        public string Linha { get; set; }

        public ModelExportFile
            (string nomearquivo,
            int seqlinha,
                string linha
            )
        {
            this.NomeArquivo = nomearquivo;
            this.SeqLinha = seqlinha;
            this.Linha = linha;
        }
    }

    //Structs
    public class TbDocumentos
    {
        public enum TiposDocumentos{Cpf = 1,Cnpj = 2,Outros = 3}
        public TiposDocumentos TipoDocumento;
        public string Documento;
        public TbDocumentos(int codtipodocumento, string documento)
        {
            TiposDocumentos _tipodocumento = TiposDocumentos.Outros;
            if (codtipodocumento == 1){ _tipodocumento = TiposDocumentos.Cpf;}
            if (codtipodocumento == 2){ _tipodocumento = TiposDocumentos.Cnpj;}
            this.TipoDocumento = _tipodocumento;
            this.Documento = documento;
        }
        public TbDocumentos(TiposDocumentos _tipodocumento , string documento)
        {
            this.TipoDocumento = _tipodocumento;
            this.Documento = documento;
        }
        public override string ToString()
        {
            string message = "";
            if (this.TipoDocumento == TiposDocumentos.Cnpj) message =  Documento.ToString();
            if (this.TipoDocumento == TiposDocumentos.Cpf) message = Documento.ToString();
            if (this.TipoDocumento == TiposDocumentos.Outros) message = Documento.ToString();
            return message.ToString();
        }
    }
    public class TbSitefLogs
    {
        public int SeqSitefLog { get; set; }
        public DateTime DataEmissao { get; set; }
        public string  Autorizador { get; set; }
        public DateTime DataHora { get; set; }
        public string CdProdutoFinanceiro { get; set; }
        public string DescricaoProdutoFinanceiro { get; set; }
        public string EstadoTransacao { get; set; }
        public string CartaoReferencia { get; set; }
        public string IdentificacaoPdv { get; set; }
        public double Valor { get; set; }
        public string CodigoAutorizacao { get; set; }
        public int CodigoEmpresa { get; set; }
        public int Ecf { get; set; }
        public int CupomFiscal { get; set; }
        public int StatusProcessamento { get; set; }
        public string IdProcessamento { get; set; }
        public string OrigemLancamento { get; set; }
        public int SeqZanthusTransacao { get; set; }
        public int NumeroCartaoIdentificador { get; set; }
        public string NumeroCartaoIdentificadorDireito { get; set; }
        public StatusRegistro StatusRegistro { get; set; }
        public string LogTipoTransacao { get; set; }
        public string LogNSUHost { get; set; }
        public TbSitefLogs()
        {
            StatusRegistro = StatusRegistro.Insert;
            DataEmissao = DateTime.Now;
            DataHora = DateTime.Now;
            OrigemLancamento = "SITEF";


        }

    }
    public class TbItem
    {
        public int CdProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string Embalagem { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        public double Qtde { get; set; }
        public TbItem()
        {

        }

    }
    public class TbProdutosFinanceiros
    {
        public int SeqProdutoFinanceiro { get; set; }
        public string CdProdutoFinanceiro { get; set; }
        public string DescricaoProdutoFinanceiro { get; set; }

    }
    public class TbAutorizadorFinanceiro
    {
        public string CdAutorizadorFinanceiro { get; set; }
        public string DescricaoAutorizadorFinanceiro { get; set; }
    }
    
}   


