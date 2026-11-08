using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0210_Notificacao;
using System.Data;
using Pag_Net.Bll.F0004_Distribuicao;
namespace Pag_Net.Bll.F0004_Distribuicao
{
    public class Wk
    {
        
    }

    public static class Distribuicao
    {
        public static DataTable Comissao_List(Pag_Net.Models.TbSysUserInfo MyConnect, int competencia, int cdParticipanteVendedor, DateTime DataFechamentoInicial , DateTime DataFechamentoFinal)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_50_Distribuicao_Comissao_List.Get(competencia, cdParticipanteVendedor, DataFechamentoInicial , DataFechamentoFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Premio_List(Pag_Net.Models.TbSysUserInfo MyConnect, int competencia, int cdParticipanteVendedor)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_70_Distribuicao_Premio_List.Get(competencia, cdParticipanteVendedor));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Comissao_Detalhe(Pag_Net.Models.TbSysUserInfo MyConnect, int competencia, int cdParticipanteVendedor, int fvc_seq)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_51_Distribuicao_Comissao_Detalhe.Get(competencia, cdParticipanteVendedor, fvc_seq));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Comissao_Apuracao(Pag_Net.Models.TbSysUserInfo MyConnect, int competencia, int cdParticipanteVendedor, DateTime DataFaturamentoInicial, DateTime DataFaturamentoFinal)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_55_Distribuicao_Comissao_Apuracao.Get(competencia, cdParticipanteVendedor, DataFaturamentoInicial, DataFaturamentoFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Comissao_Apuracao_Item(Pag_Net.Models.TbSysUserInfo MyConnect, int competencia, int cdParticipanteVendedor, DateTime DataFaturamentoInicial, DateTime DataFaturamentoFinal)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0004_55_Distribuicao_Comissao_Apuracao_Item.Get(competencia, cdParticipanteVendedor, DataFaturamentoInicial, DataFaturamentoFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Comissao_Consolidar(Pag_Net.Models.TbSysUserInfo MyConnect, int competencia, int cdParticipanteVendedor, DateTime DataFaturamentoInicial, DateTime DataFaturamentoFinal)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0004_60_Distribuicao_Comissao_Consolidar.Post(competencia, cdParticipanteVendedor, DataFaturamentoInicial, DataFaturamentoFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Comissao_Altera_Item(Pag_Net.Models.TbSysUserInfo MyConnect, int vfvc_it_seq, double vpercentual_valor)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0004_20_Distribuicao_Comissao_Alterar_Item.Post(vfvc_it_seq, vpercentual_valor));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Comissao_Altera(Pag_Net.Models.TbSysUserInfo MyConnect, int vfvc_seq, double vfvc_fat_valor_pgto_complemento)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0004_21_Distribuicao_Comissao_Alterar.Post(vfvc_seq, vfvc_fat_valor_pgto_complemento));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
