using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Models;

namespace Pag_Net.Bll.Operacionais.Locacao
{
    public static class UspContratoLocacaoFaturamentoParcela
    {
        public static void Faturar (Models.modelSistemaUsuario __myConnect, int __seqContratoLocacaoParcela)
        {
            Pag_Net.Dal.DbUpdate dal = new Dal.DbUpdate(__myConnect, Dal.DataBaseName.DBAMAINADM);
            try
            {
                dal.Begin();
                List<ParameterQuey> ListParametros = new List<ParameterQuey>();
                ListParametros.Add(new ParameterQuey("Command", System.Data.SqlDbType.VarChar, true, "INSERT"));
                ListParametros.Add(new ParameterQuey("SeqContratoLocacaoParcela", System.Data.SqlDbType.Int, true, __seqContratoLocacaoParcela ));
                dal.Execute("UspContratoLocacaoFaturamentoParcela",  ListParametros.ToArray());
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

