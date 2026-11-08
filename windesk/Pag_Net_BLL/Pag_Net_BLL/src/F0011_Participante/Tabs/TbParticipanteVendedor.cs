using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipanteVendedor : Pag_Net.Bll.Tb
    {
        public TbParticipante VendedorPJ { get; set; }
        public TbParticipante VendedorContabilidade { get; set; }
        public int cdparticipante { get; set; }
        public int vendedor_status { get; set;  }
        public int vendedor_cdparticipante_pj { get; set; }
        public int vendedor_cdparticipante_contador { get; set; }
        public int vendedor_fv_comis_mail { get; set;  }
        

        public TbParticipanteVendedor() { _constructor(); }


        public void _constructor()
        {
            VendedorPJ = new TbParticipante();
            VendedorContabilidade = new TbParticipante();
            this.cdparticipante = 0;
            this.vendedor_status = 0;
            this.vendedor_cdparticipante_pj = 0;
            this.vendedor_cdparticipante_contador = 0;
            this.vendedor_fv_comis_mail = 0;

        }
        public override void __Binding(DataRow i)
        {
            try
            {
                _constructor();
                this.cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                this.vendedor_status = Convert.ToInt32(i["vendedor_status"].ToString());
                this.vendedor_cdparticipante_pj = Convert.ToInt32(i["vendedor_cdparticipante_pj"].ToString());
                this.vendedor_cdparticipante_contador = Convert.ToInt32(i["vendedor_cdparticipante_contador"].ToString());
                this.vendedor_fv_comis_mail = Convert.ToInt32(i["vendedor_fv_comis_mail"].ToString());
                this.VendedorPJ.cdparticipante = this.vendedor_cdparticipante_pj;
                this.VendedorPJ.nome_razao = i["vendedor_pj_nome_razao"].ToString();
                this.VendedorContabilidade.cdparticipante = this.vendedor_cdparticipante_contador;
                this.VendedorContabilidade.nome_razao = i["vendedor_contador_nome_razao"].ToString();
             }
            catch (Exception ex)
            {
                throw new Exception("TbParticipante_Tipo | Error \n " + ex.Message);
            }

        }
        public override string __Db_Pg_script(BDCommandTypes __BDCommnadType)
        {

            
            string __Db_Pg_script = "";

            __Db_Pg_script = string.Format("select * from " + F0011_Participante.F0011_07_ParticipanteVendedor._VERSION() + 
                " (		sqlcommand:= '" + __BDCommnadType.ToString()  + "'" + 
	            "     ,	vcdparticipante:= " + this.cdparticipante.ToString() + 
 	            "     ,	vvendedor_seq:= 0 " + 
	            "     ,	vvendedor_status:= " + this.vendedor_status.ToString() + 
 	            "     ,	vvendedor_cdparticipante_pj:= " + this.vendedor_cdparticipante_pj.ToString() + 
 	            "     ,	vvendedor_cdparticipante_contador:= " + this.vendedor_cdparticipante_contador.ToString() +
 	            "     ,	vvendedor_fv_comis_mail:= " + this.vendedor_fv_comis_mail.ToString() + 
                " ) "); 
            return __Db_Pg_script;
        }


    }
}
