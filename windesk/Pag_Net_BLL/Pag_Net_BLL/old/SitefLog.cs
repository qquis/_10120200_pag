using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using Pag_Net.Dal;
using Pag_Net.Bll.Tables;

namespace Pag_Net.Bll.SitefLog
{
    public class bllSitefLogs
    {
        public ModelSystemUserInfoConnect MyConnect { get; set; }
        public DateTime FiltroDataEmissaoIni { get; set; }
        public DateTime FiltroDataEmissaoFim { get; set; }
        public TbECF FiltroEcf { get; set; }
        public string FiltroCupomFiscal { get; set; }
        public TbOperadores FiltroOperador { get; set; }
        public string FiltroValorIni { get; set; }
        public string FiltroValorFim { get; set; }
        public string FiltroEstadoTransacao { get; set; }
        public string FiltroCartaoReferencia { get; set; }
        public TbSitefLogs[] RegistrosNaoGravados { get; set; }
        public bllSitefLogs(ModelSystemUserInfoConnect _myconnect)
        {
            MyConnect = _myconnect;
        }
        
        public TbSitefLogs[] ListSitefLogs
        {
             get
             {
                 try
                 {
                     return Select();
                 }
                 catch (Exception ex)
                 {
                     throw new Exception("BllSitefLogs: " + ex.Message.ToString());
                 }
             }

             set 
             {
            
             }

       

        }
        public TbSitefLogs[] ListSitefAssociados
        {
            get
            {
                try
                {
                    if (FiltroEcf == null || FiltroCupomFiscal == null)
                    {

                        throw new Exception("Favor informar a ECF!");
                    }
                    return Select();
                }
                catch (Exception ex)
                {
                    throw new Exception("BllSitefLogs: " + ex.Message.ToString());
                }
            }
        }
        public TbOperadores[] Operadores
        {
            get { return DaOperadores.GetList(MyConnect); }
        }
        public TbECF[] Ecfs
        {
            get { return DaECF.GetList(MyConnect); }
        }

        private TbSitefLogs[] Select()
        {
            int? _cdoperador = null;
            double? _valorini = null;
            double? _valorfim = null;
            int? _ecf = null;
            int? _cupomfiscal = null;


            if (FiltroOperador != null)
            {
                _cdoperador = FiltroOperador.CdOperador;
            }

            if (FiltroValorIni != "")
            {
                _valorini = Convert.ToDouble(FiltroValorIni);
            }

            if (FiltroValorFim != "")
            {
                _valorfim = Convert.ToDouble(FiltroValorFim);
            }

            if (FiltroEcf != null)
            {
                _ecf = FiltroEcf.ECF;
            }

            if (FiltroCupomFiscal != null && FiltroCupomFiscal != "")
            {
                _cupomfiscal = Convert.ToInt32(FiltroCupomFiscal);
            }
            return DaSitefLog.Select(MyConnect, FiltroDataEmissaoIni, FiltroDataEmissaoFim, _ecf, _cupomfiscal, _cdoperador, _valorini, _valorfim, FiltroEstadoTransacao, "");
        }
        private TbCuponsPagamentos[] PagamentoDoCupom;
        public double VlPagamentoFinalizadoraPos = 0;
        public double VlPagamentosFinalizadoraPosLancados = 0;



        public void Add(TbSitefLogs item)
        {
            if (item.OrigemLancamento == "POS")
            {
                double VlTotalPgtoPosItens = 0;

                if (PagamentoDoCupom == null)
                {
                    PagamentoDoCupom = DaCuponsPagamentos.GetList(MyConnect, item.Ecf, item.CupomFiscal, 3, item.SeqZanthusTransacao);
                    item.DataEmissao = PagamentoDoCupom[0].DataEmissao;

                    if (PagamentoDoCupom.Count() == 0)
                    {
                        throw new Exception("Não Existe Lançamento de Finalizadora POS para o Cupom Selecionado!");
                    }


                    VlPagamentoFinalizadoraPos = PagamentoDoCupom[0].Valor;
                }
                if (PagamentoDoCupom[0].EstadoTransacao.Trim() == "EFETUADA")
                {
                    
                    throw new Exception("Já Existe Pagamentos para Finalizadora POS deste CUPOM! Operação Inválida!" );
                }

                if (item.CupomFiscal != PagamentoDoCupom[0].CupomFiscal || item.Ecf != PagamentoDoCupom[0].Ecf)
                {
                    PagamentoDoCupom = DaCuponsPagamentos.GetList(MyConnect, item.Ecf, item.CupomFiscal, 3, item.SeqZanthusTransacao);
                    
                    VlPagamentoFinalizadoraPos = PagamentoDoCupom[0].Valor;
                    
                }
                item.DataEmissao = PagamentoDoCupom[0].DataEmissao;

                if (RegistrosNaoGravados != null)
                {
                    if (RegistrosNaoGravados.Count() > 0)
                    {
                        foreach (TbSitefLogs i in RegistrosNaoGravados)
                        {
                            if (i.CupomFiscal == PagamentoDoCupom[0].CupomFiscal && i.Ecf == PagamentoDoCupom[0].Ecf)
                            {
                                VlTotalPgtoPosItens += i.Valor;
                            }
                        }
                    }
                }
                VlTotalPgtoPosItens += item.Valor;
                if (VlPagamentoFinalizadoraPos < VlTotalPgtoPosItens)
                {
                    throw new Exception("Valor dos itens POS lançados, supera valor informado na filizadora CUPOM - POS");
                }
                VlPagamentosFinalizadoraPosLancados = VlTotalPgtoPosItens;
            }

            item.StatusRegistro = StatusRegistro.Insert;
            List<TbSitefLogs> _list = new List<TbSitefLogs>();
            if (RegistrosNaoGravados != null)
            {
                _list = RegistrosNaoGravados.ToList();
            }
            _list.Add(item);
            RegistrosNaoGravados = _list.ToArray();
        }
        public void Del(int index)
        {
            List<TbSitefLogs> RemoveItem = RegistrosNaoGravados.ToList();
            RemoveItem.RemoveRange(index, 1);
            RegistrosNaoGravados = RemoveItem.ToArray();
            this.VlPagamentosFinalizadoraPosLancados = 0;
            foreach (TbSitefLogs i in RegistrosNaoGravados)
            {
                this.VlPagamentosFinalizadoraPosLancados += i.Valor;
            }

        }




    }
}
