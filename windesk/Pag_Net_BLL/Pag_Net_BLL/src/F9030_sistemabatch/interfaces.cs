using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F9030_sistemabatch.interfaces
{
    public class iFilter
    {
        public int sis_batch_cd { get; set; }
        public int sis_batch_run_status_cd { get; set; }
        public int sis_batch_run_seq { get; set; }

        public iFilter()
        {
            sis_batch_cd = 0;
            sis_batch_run_status_cd = 0;
            sis_batch_run_seq = 0;


        }

    }
}
