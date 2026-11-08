using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0050_Faturamento_BlueSoft
{
    public class _index
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public _indexReport report;

        public _index(Pag_Net.Models.modelSistemaUsuario myConnect)
        {
            MyConnect = myConnect;
            report = new _indexReport(MyConnect);
        }
    }
}
