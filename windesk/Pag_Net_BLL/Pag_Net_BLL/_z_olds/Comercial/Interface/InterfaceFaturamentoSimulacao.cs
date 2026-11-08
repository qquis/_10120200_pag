using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll; 
using Pag_Net.Models;

namespace Pag_Net.Bll.Comercial.Interface
{
    public class InterfaceFaturamentoSimulacao
    {
        private modelSistemaUsuario MyConnect;
        public UspInterfaceInfo Cadastro;
        public UspInterfaceFaturamentoAgendamentoSimuladoInfoItem FaturamentoSimulado;
        public Pag_Net.Bll.Cadastros.UspParticipante Vendedores;
        public InterfaceFaturamentoSimulacao( Models.modelSistemaUsuario __myConnect )
        {
            MyConnect = __myConnect;
            Vendedores = new Cadastros.UspParticipante(MyConnect);
            Vendedores.Parametros.SeqTipoParticipanteEmpresa = Bll.Util.TiposGetSeq(MyConnect.Tipos, "TbParticipanteEmpresa", "SeqTipoParticipanteEmpresa", "DISTR_VENDEDOR");
            Vendedores.Select();

            Cadastro = new UspInterfaceInfo(MyConnect);
            FaturamentoSimulado = new UspInterfaceFaturamentoAgendamentoSimuladoInfoItem(MyConnect);
        }

        public void Inserir(Pag_Net.Bll.Comercial.Interface.UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem[] Lista)
        {
            Pag_Net.Dal.DbUpdate dal = new Dal.DbUpdate(MyConnect, Dal.DataBaseName.DBAMAINADM);
            try
            {
                dal.Begin();
                foreach (Pag_Net.Bll.Comercial.Interface.UVWInterfaceFaturamentoAgendamentoSimuladoInfoItem item in Lista)
                {
                    List<ParameterQuey> ListParametros = new List<ParameterQuey>();
                    ListParametros.Add(new ParameterQuey("Command", System.Data.SqlDbType.VarChar, true, "INSERT"));
                    ListParametros.Add(new ParameterQuey("SeqInterfaceInfo", System.Data.SqlDbType.Int, true, 1 ));
                    ListParametros.Add(new ParameterQuey("DataFaturamento", System.Data.SqlDbType.Date, true, item.DataFaturamento));
                    ListParametros.Add(new ParameterQuey("CdProduto", System.Data.SqlDbType.Int, true, item.CdProduto));
                    ListParametros.Add(new ParameterQuey("EmbalagemEstoqueQtde", System.Data.SqlDbType.Decimal, true, item.EmbalagemEstoqueQtde));
                    ListParametros.Add(new ParameterQuey("CdParticipanteVendedor", System.Data.SqlDbType.Int, true, item.CdParticipanteVendedor));
                    ListParametros.Add(new ParameterQuey("CdParticipanteCliente", System.Data.SqlDbType.Int, true, item.CdParticipanteCliente));
                    dal.Execute("UspInterfaceFaturamentoAgendamentoSimuladoInfoItem", ListParametros.ToArray());
                }

                dal.Commit();
            }
            catch( Exception ex)
            {
                dal.RollBack();
                throw new Exception(ex.Message);
            }
        }
    }
}
