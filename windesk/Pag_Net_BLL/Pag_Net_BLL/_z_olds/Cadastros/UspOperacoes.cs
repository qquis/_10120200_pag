using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;


namespace Pag_Net.Bll.Cadastros
{
    public class UspOperacoes: Bll.USPDataContext
    {
       
        public UspOperacoes(Models.modelSistemaUsuario _myConnect)
            :base(_myConnect)
        {
            this.Select();
        }

        public void Select()
        {
            List<TbSysTbOperacoes> L = new List<TbSysTbOperacoes>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                TbSysTbOperacoes l = new TbSysTbOperacoes();
                l.CdOperacao = Convert.ToInt32(i["CdOperacao"].ToString());
                l.DescricaoOperacao = i["DescricaoOperacao"].ToString();
                l.SeqTipoOperacao = Convert.ToInt32(i["SeqTipoOperacao"].ToString());
                l.DescricaoTipoOperacao = i["DescricaoTipoOperacao"].ToString();
                l.CdTipo = i["CdTipo"].ToString();
                l.Menu = i["Menu"].ToString();
                l.Cd_Form_Proc = Convert.ToInt32( i["Cd_Form_Proc"].ToString());
                l.Cd_Tarefa = Convert.ToInt32(i["Cd_Tarefa"].ToString());
                l.Formulario = i["Formulario"].ToString();
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
            return "UspOperacoes";
        }
    }

    public class UVWOperacoes
    {
        public int CdOperacao {get;set;}
        public string DescricaoOperacao {get;set;}
        public UVWOperacoes() { }

    }
  
}

  