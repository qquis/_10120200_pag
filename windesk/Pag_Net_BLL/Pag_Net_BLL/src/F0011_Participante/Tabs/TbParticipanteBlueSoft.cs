using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipanteBlueSoft : Pag_Net.Bll.Tb
    {

        public int      cdpessoabluesoft                                { get; set; }
        public int      cdparticipante                                  { get; set; }
        public string   cpf_cnpj                                        { get; set; }
        public int      pessoajuridica                                  { get; set; }
        public string   nome_razao                                      { get; set; }
        public int      bluesoft_pessoa_status                          { get; set; }
        public DateTime bluesoft_pessoa_data_cadastro                   { get; set; }

        public int      bluesoftcliente                                 { get; set; }        
        public int      bluesoftclientestatus                           { get; set; }
        public int      cdgrupoeconomico                                { get; set; }
        public int      cdpessoabluesoft_vendedor                       { get; set; }


        public int      bluesoftvendedor                                { get; set; }
        public int      bluesoftfornecedor                              { get; set; }
        public int      bluesoftfabricante                              { get; set; }
        public int      bluesoftmotorista                               { get; set; }


        public double   bluesoftcliente_creditolimite_valor             { get; set; }
        public double   bluesoftcliente_creditolimite_valor_reservado   { get; set; }
        public int      bluesoftcliente_creditostatus_cd                { get; set; }
        public int      bluesoftcliente_ramoatividade_cd                { get; set; }

        public TbParticipanteBlueSoft() 
        {
            _constructor();
        
        }
        public TbParticipanteBlueSoft(DataRow i)
        {
            try
            {
                _constructor();
                __Binding(i);
            }
            catch (Exception ex )
            {
                throw new Exception("Pag_Net.Bll.F0011_Participante.TbPessoBluesoft: " + ex.Message);
            }
        }

        public void _constructor()
        {
            cdpessoabluesoft = 0;
            cdparticipante = 0;
            cpf_cnpj = "";
            pessoajuridica = 0;
            nome_razao  = "";
            bluesoft_pessoa_status = 0;
            //DateTime bluesoftpessoa_data_cadastro = Convert.ToDateTime("1900-01-01");
            
            bluesoftcliente = 0;
            bluesoftclientestatus= 0;
            cdgrupoeconomico= 0;
            cdpessoabluesoft_vendedor= 0;
            
            bluesoftvendedor = 0;
            bluesoftfornecedor= 0;
            bluesoftfabricante= 0;
            bluesoftmotorista= 0;
            
            bluesoftcliente_creditolimite_valor = 0;
            bluesoftcliente_creditolimite_valor_reservado =  0;
            bluesoftcliente_creditostatus_cd= 0;
            bluesoftcliente_ramoatividade_cd = 0;               
        }
        public override void __Binding(DataRow i)
        {
            try
            {
                this.cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());
                this.cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                this.cpf_cnpj = i["cpf_cnpj"].ToString();
                this.pessoajuridica = Convert.ToInt32(i["pessoajuridica"].ToString());
                this.nome_razao = i["nome_razao"].ToString();
                this.bluesoft_pessoa_status = Convert.ToInt32(i["bluesoft_pessoa_status"].ToString());
                this.bluesoft_pessoa_data_cadastro = Convert.ToDateTime(i["bluesoft_pessoa_data_cadastro"].ToString());

                this.bluesoftcliente = Convert.ToInt32(i["bluesoftcliente"].ToString());
                this.bluesoftclientestatus = Convert.ToInt32(i["bluesoftclientestatus"].ToString());
                this.cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"].ToString());
                this.cdpessoabluesoft_vendedor = Convert.ToInt32(i["cdpessoabluesoft_vendedor"].ToString());


                this.bluesoftvendedor = Convert.ToInt32(i["bluesoftvendedor"].ToString());
                this.bluesoftfornecedor = Convert.ToInt32(i["bluesoftfornecedor"].ToString());
                this.bluesoftfabricante = Convert.ToInt32(i["bluesoftfabricante"].ToString());
                this.bluesoftmotorista = Convert.ToInt32(i["bluesoftmotorista"].ToString());

                
                this.bluesoft_pessoa_data_cadastro = Convert.ToDateTime(i["bluesoftpessoa_data_cadastro"].ToString());
                this.bluesoftcliente_creditolimite_valor = Convert.ToDouble(i["bluesoftcliente_creditolimite_valor"].ToString());
                this.bluesoftcliente_creditolimite_valor_reservado = Convert.ToDouble(i["bluesoftcliente_creditolimite_valor_reservado"].ToString());
                this.bluesoftcliente_creditostatus_cd = Convert.ToInt32(i["bluesoftcliente_creditolimite_valor_reservado"].ToString());
                this.bluesoftcliente_ramoatividade_cd = Convert.ToInt32(i["bluesoftcliente_ramoatividade_cd"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


    }
}
