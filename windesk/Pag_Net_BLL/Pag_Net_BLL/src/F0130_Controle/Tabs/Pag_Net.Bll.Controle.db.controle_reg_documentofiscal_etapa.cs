using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class TbControle_Reg_DocumentoFiscal_Etapa
    {
        
        public int      dfr_seq                     {get; set;}
        public int      controle_reg_seq            { get; set; }
        public int controle_reg_fila_seq { get; set; }
        public int      controle_reg_etapa_seq      {get; set;}



        public TbControle_Reg_DocumentoFiscal_Etapa()
        {
            dfr_seq = 0;                 
            controle_reg_seq = 0;         
            controle_reg_etapa_seq = 0;
            controle_reg_fila_seq = 0;

        }

        public TbControle_Reg_DocumentoFiscal_Etapa(

             int      _dfr_seq
          ,  int      _controle_reg_seq
            , int _controle_reg_fila_seq
          ,  int      _controle_reg_etapa_seq     


            )
        {

            dfr_seq                     =   _dfr_seq         ;
            controle_reg_seq            =   _controle_reg_seq  ;
            controle_reg_etapa_seq      =   _controle_reg_etapa_seq              ;
            controle_reg_fila_seq = _controle_reg_fila_seq;
        }


        public TbControle_Reg_DocumentoFiscal_Etapa(DataRow i)
        {
            dfr_seq = Convert.ToInt32(i["dfr_seq"].ToString());
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());
            controle_reg_etapa_seq = Convert.ToInt32(i["controle_reg_etapa_seq"].ToString());
            controle_reg_fila_seq = Convert.ToInt32(i["controle_reg_etapa_seq"].ToString());
        }


    }
}
