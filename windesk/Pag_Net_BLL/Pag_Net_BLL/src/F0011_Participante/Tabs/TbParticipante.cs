using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipante : Pag_Net.Bll.Tb
    {

        public int      cdparticipante                  { get; set; }
        private string  _CPF_CNPJ  = ""; 
        public string   cpf_cnpj                        
        {
            get
            {
                return BDTools.DoCPF_CNPJ_Get_FormatZERO(_CPF_CNPJ);
            }
            set 
            {
                _CPF_CNPJ = value; // BDTools.DoCPF_CNPJ_Get_FormatZERO(value);
            }
        
        }
        public int      cdpessoabluesoft                { get; set; }
        public int      funcionario_cd                  { get; set; }

        private string __nome_razao;
        public string nome_razao
        {
            get
            {
                return __nome_razao;
            }
            set
            {
                __nome_razao = value.ToString().ToUpper().Replace("'", "");
            }
        }

        private string __nome_abreviado;
        public string nome_abreviado
        {
            get { return __nome_abreviado; }
            set { __nome_abreviado = value.ToString().ToUpper().Replace("'", ""); }
        }

        public int      pessoajuridica                  { get; set; }
        public int      participante_status             { get; set; }
        
        private string __email_main;
        public string email_main
        {
            get { return __email_main; }
            set { __email_main = value.ToString().Trim().Replace("'", ""); }
        }
 
        public int      bluesoftcliente                 { get; set; }
        public int      bluesoftvendedor                { get; set; }
        public int      bluesoftfornecedor              { get; set; }
        public int      bluesoftfabricante              { get; set; }
        public int      cdgrupoeconomico                { get; set; }
        public int      cdpessoabluesoft_vendedor       { get; set; }
        public string   erptargetcd_vend                { get; set;  }
        public int      erptargetcd_clien               { get; set; }
        public int      tipo_clienteloja                { get; set; }
        public int      johnson_cliente_top             { get; set; }

        public int celular_dd { get; set;  }
        public int celular_numero { get; set; }


        
        public TbParticipante() { _constructor(); }
        public void _constructor()
        {
            cdparticipante = 0;
            cpf_cnpj = "00000000000000";
            cdpessoabluesoft = 0;
            nome_razao = "";
            pessoajuridica = 0;
            participante_status = 1;
            email_main = "";
            celular_dd = 0;
            celular_numero = 0;
            /*
            bluesoftcliente = 0;
            bluesoftvendedor = 0;
            bluesoftfornecedor = 0;
            bluesoftfabricante = 0;
            cdgrupoeconomico = 0;
            cdpessoabluesoft_vendedor = 0;
            erptargetcd_vend = "";
            erptargetcd_clien = 0;
            tipo_clienteloja = 0;
            johnson_cliente_top = 0;
            */
            


        }
        public override void __Binding(DataRow i)
        {
            try
            {
                _CPF_CNPJ = i["cpf_cnpj"].ToString();
                this.nome_razao = i["nome_razao"].ToString();
                this.nome_abreviado = i["nome_abreviado"].ToString();
                this.celular_dd = Convert.ToInt32(i["celular_dd"].ToString());
                this.celular_numero = Convert.ToInt32(i["celular_numero"].ToString()); 
                this.email_main = i["email_main"].ToString();
                this.pessoajuridica = Convert.ToInt32(i["pessoajuridica"].ToString());
                this.participante_status = Convert.ToInt16(i["participante_status"].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("TbParticipantes _ Binding " + ex.Message);
            }
        }
        public override string __Db_Pg_script(BDCommandTypes BDCommnadType)
        {

            
            string __Db_Pg_script = "";
            __Db_Pg_script = string.Format("SELECT * FROM " + Pag_Net.Bll.F0011_Participante.F0011_01_Participante._VERSION() + 
                "  (        sqlcommand:= '" + BDCommnadType.ToString() + "'" + 
                "       ,   vcdparticipante:= " + this.cdparticipante  + ""  + 
                "       ,   vcpf_cnpj:= '" + this.cpf_cnpj.ToString() + "'" + 
                "       ,   vcdpessoabluesoft:= " + this.cdpessoabluesoft  + 
                "       ,   vfuncionario_cd:= " + this.funcionario_cd + 
                "       ,   vnome_razao:=  '" + this.nome_razao + "'" + 		
                "       ,   vnome_abreviado:= '" + this.nome_abreviado + "'" + 
                "       ,   vpessoajuridica:= " + this.pessoajuridica +  	
                "       ,   vparticipante_status:= " +  this.participante_status +
                "       ,   vemail_main:=  '" + this.email_main + "'" + 		
                "       ,   vcelular_dd:=  " + this.celular_dd +			
                "       ,   vcelular_numero:= " + this.celular_numero +	
                "  );") ; 

            return __Db_Pg_script;
        }

   
    }
}

