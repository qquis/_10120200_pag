using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspTipos: Bll.USPDataContext
    {

        public UspTipos(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Select();
        }
        public void Select()
        {
            List<Models.TbSysTbTipos > L = new List<Models.TbSysTbTipos>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                Models.TbSysTbTipos l = new Models.TbSysTbTipos();
                l.DescricaoTipo  = i["Descricao"].ToString();
                l.CdTipo = i["CdTipo"].ToString();
                l.SeqTipo = Convert.ToInt32(i["SeqTipo"].ToString());
                l.Tabela = i["NomeTabela"].ToString();
                l.Campo = i["NomeCampo"].ToString();
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            return null;
        }
        public override string SQLCommnad()
        {
            return "UspTipos";
        }

    }

}
