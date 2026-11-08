using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Models
{
    public class TbSysUserAccess
    {
        public string System_Id { get; set; }
        public string CdFormProc { get; set; }
        public string Menu { get; set; }
        public string MenuIndex { get; set; }
        public string CdFuncao { get; set; }
        public string DescFuncao { get; set; }
        public string CdTarefa { get; set; }
        public string DescTarefa { get; set; }
        public string CdParametro { get; set; }
        public string DescParametro { get; set; }
        public string TipoParametro { get; set; }
        public string Valor { get; set; }
        public string DescFormProc { get; set; }
        public TbSysUserAccess(
            string system_Id,
            string cdFormProc,
            string menu,
            string menuIndex,
            string cdFuncao,
            string descFuncao,
            string cdTarefa,
            string descTarefa,
            string cdParametro,
            string descParametro,
            string tipoParametro,
            string valor,
            string descformproc)
        {
            this.System_Id = system_Id.ToString();
            this.CdFormProc = cdFormProc.ToString();
            this.Menu = menu.ToString();
            this.MenuIndex = menuIndex.ToString();
            this.CdFuncao = cdFuncao.ToString();
            this.DescFuncao = descFuncao.ToString();
            this.CdTarefa = cdTarefa.ToString();
            this.DescTarefa = descTarefa.ToString();
            this.CdParametro = cdParametro.ToString();
            this.TipoParametro = tipoParametro.ToString();
            this.Valor = valor.ToString();
            this.DescParametro = descParametro.ToString();
            this.DescFormProc = descformproc.ToString();
        }

    }
}
