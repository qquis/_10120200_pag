using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0070_Faturamento.tbs
{
    public class tbFaturamentoOrigem
    {
            public int seqfaturamentoorigem        {get;set;} 
            public int sat_ecf                     {get;set;}
            public int cupomfiscal                 {get;set;}
            public int numeropedido                {get;set;}
            public int numeronfe                   {get;set;}
            public int nfeseq                      {get;set;}
            public int prazopgtomedio              {get;set;}
            public int numeronfedevolucao          {get;set;}

            public tbFaturamentoOrigem() 
          {
              //base.seqfaturamento = 0;
              this.seqfaturamentoorigem      = 0; 
              this.sat_ecf                   = 0; 
              this.cupomfiscal               = 0; 
              this.numeropedido              = 0; 
              this.numeronfe                 = 0; 
              this.nfeseq                    = 0; 
              this.prazopgtomedio            = 0;
              this.numeronfedevolucao = 0; 
          }

    }



}
