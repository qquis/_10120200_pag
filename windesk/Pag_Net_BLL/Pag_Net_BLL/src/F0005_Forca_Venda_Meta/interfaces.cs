using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.f0005_forca_venda_meta.interfaces
{
    public class iFilter
    {
        public int fv_meta_tipo_cd { get; set;  }

        public iFilter()
        {
            this.fv_meta_tipo_cd = 0; 

        }

    }
}
