using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Varejo.Sac
{
    public class UspOperacaoSac: Bll.USPDataContext
    {
        public OperacaoSacFiltros Filtros { get; set; }
        public UspOperacaoSac(Models.modelSistemaUsuario _myconnect)
            : base(_myconnect)
        {
            Filtros = new OperacaoSacFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWOperacaoSac> L = new List<UVWOperacaoSac>();
                base.Select();
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWOperacaoSac l = new UVWOperacaoSac();
                    l.SeqOperacaoSac  = Convert.ToInt32(i["SeqOperacaoSac"].ToString());
                    l.DataLancamento = Convert.ToDateTime (i["DataLancamento"].ToString());
                    l.TipoDescricao = i["TipoDescricao"].ToString();
                    l.Situacao = i["Situacao"].ToString();
                    l.DescricaoSituacao = i["DescricaoSituacao"].ToString();
                    l.UsuarioNome  = i["UsuarioNome"].ToString();

                    L.Add(l);
                }
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("SITUACAO", SqlDbType.Char, true, Filtros.Situacao));
                    
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspOperacaoSAC";
        }

    }

    public class UVWOperacaoSac
    {
        public int SeqOperacaoSac { get; set; }
        public DateTime DataLancamento { get; set; }
        public string TipoDescricao { get; set; }
        public string Situacao { get; set; }
        public string DescricaoSituacao { get; set; }
        public string UsuarioNome { get; set; }


    }

    public class OperacaoSacFiltros
    {
        public string Situacao { get; set; }
    }
}
