using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0070_Faturamento.tbs
{
    public class tbFaturamento
    {
          public int        seqfaturamento                            {get;set;}
          public DateTime   datafaturamento                 {get;set;}
          public DateTime   dataemissao                     {get;set;}
          public int        em_cdempresa                      {get;set;}
          public int        op_cdoperacao                     {get;set;}
          public int        cdparticipantecliente             {get;set;}
          public int        cdparticipantevendedor            {get;set;}
          public int        statusfaturamento                {get;set;}
          public Boolean    bluesoft                       {get;set;}

          public tbFaturamento() 
          { 
              this.seqfaturamento             = 0;
              this.datafaturamento            = DateTime.Now;
              this.dataemissao = DateTime.Now;
              this.em_cdempresa               = 0;
              this.op_cdoperacao              = 0;
              this.cdparticipantecliente      = 0;
              this.cdparticipantevendedor     = 0;
              this.statusfaturamento          = 1;
              this.bluesoft = true;  
          
          }

    }



}
