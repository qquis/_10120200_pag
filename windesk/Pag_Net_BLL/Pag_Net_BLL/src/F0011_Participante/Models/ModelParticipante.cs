using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class ModelParticipante : TbParticipante
    {

        
        public TbParticipanteBlueSoft ParticipanteBlueSoft { get; set; }
        public TbParticipante_PF ParticipantePf { get; set; }
        
        public TbParticipanteVendedor ParticipanteVendedor { get; set; }

        public TbParticipanteEndereco[] ListParticipanteEndereco { get; set; }
        public TbParticipanteTipoReg[] ListParticipanteTiposRegs { get; set; }
        public TbParticipanteContato[] ListParticipanteContato { get; set; }
        public TbParticipanteFuncionario[] ListParticipanteFuncinario { get; set; }

        public string LOCAL_bluesoftcliente { get { return ParticipanteBlueSoft.bluesoftcliente == 1 ? "Sim" : "Não"; } }
        public string LOCAL_bluesoftvendedor { get { return ParticipanteBlueSoft.bluesoftvendedor == 1 ? "Sim" : "Não"; } }
        public string LOCAL_bluesoftfornecedor { get { return ParticipanteBlueSoft.bluesoftfornecedor == 1 ? "Sim" : "Não"; } }
        public string LOCAL_bluesoftfabricante { get { return ParticipanteBlueSoft.bluesoftfabricante == 1 ? "Sim" : "Não"; } }
        public bool LOCAL_Status_Participante
        {
            get
            {
                if (this.participante_status == 1)
                    return true;
                else
                    return false;
            }
        }
        public bool LOCAL_PessoaJuridica
        {
            get
            {
                if (this.pessoajuridica == 1)
                    return true;
                else
                    return false;
            }
        }

        public ModelParticipante() : base() 
        {
            _Modelconstructor();
        
        }

        public ModelParticipante(int __cdparticipante)
        {
            try
            {
                _Modelconstructor();
                if (__cdparticipante != 0)
                    this.cdparticipante = __cdparticipante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ModelParticipante(int _cdpessoabluesoft, string _nome_razao)
        {
            this.cdpessoabluesoft = _cdpessoabluesoft;
            this.nome_razao = _nome_razao.ToUpper();

        }
        public ModelParticipante(DataRow i)
        {
            try
            {
                _constructor();
                cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                participante_status = Convert.ToInt32(i["participante_status"].ToString());
                erptargetcd_vend = i["erptargetcd_vend"].ToString();
                erptargetcd_clien = Convert.ToInt32(i["erptargetcd_clien"].ToString());
                tipo_clienteloja = Convert.ToInt32(i["tipo_clienteloja"].ToString());
                johnson_cliente_top = Convert.ToInt32(i["johnson_cliente_top"].ToString());

   
            }
            catch (Exception ex )
            {
                throw new Exception("TbParticipante " + ex.Message);
            }


        }

  
     
        public void _Modelconstructor()
        {


            
            base._constructor();

            ListParticipanteContato = null;
            ListParticipanteEndereco = null;
            ListParticipanteTiposRegs = null;
            ListParticipanteFuncinario = null; 
            cdparticipante = 0;
            cpf_cnpj = "00000000000000";
            cdpessoabluesoft = 0;
            nome_razao = "";
            pessoajuridica = 0;
            participante_status = 1;
            email_main = "";
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
            celular_dd = 0;
            celular_numero = 0;

            
            ParticipanteBlueSoft = new TbParticipanteBlueSoft();
            ParticipantePf = new TbParticipante_PF();
            ParticipanteVendedor = new TbParticipanteVendedor();


        }

        public void Model_Consultar(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                __Consultar(_MyConnect);
                __Model_Consultar_ParticipanteTiposRegs(_MyConnect);
                __Model_Consultar_ParticipanteBlueSoft(_MyConnect);
                __Model_Consultar_Enderecos(_MyConnect);
                __Model_Consultar_Contatos(_MyConnect);
                __Model_Consultar_PF(_MyConnect);

                if (this.__Model_ConferirTipoPessoa(101))
                __Model_Consultar_Funcionario(_MyConnect);


                if (this.__Model_ConferirTipoPessoa(121))
                    __Model_Consultar_Vendedor(_MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Model_Atualizar_ParticipanteTiposRegs(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                //Atualizando os dados do TIPO DE REGISTRO 
                foreach(TbParticipanteTipoReg itemParticipanteTipoReg in ListParticipanteTiposRegs)
                {
                    itemParticipanteTipoReg.__Atualizar(_MyConnect);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Model_Atualizar_Enderecos(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                //Atualizando os dados do TIPO DE REGISTRO 
                foreach (TbParticipanteEndereco itemParticipanteEndereco in ListParticipanteEndereco)
                {
                    itemParticipanteEndereco.__Atualizar(_MyConnect);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Model_Atualizar_Funcionario(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                //Atualizando os dados do TIPO DE REGISTRO 
                foreach (TbParticipanteFuncionario itemParticipanteFuncionario in ListParticipanteFuncinario)
                {
                    itemParticipanteFuncionario.__Atualizar(_MyConnect);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Model_Atualizar_Contatos(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                //Atualizando os dados do TIPO DE REGISTRO 
                foreach (TbParticipanteContato itemParticipanteContato in ListParticipanteContato)
                {
                    itemParticipanteContato.__Atualizar(_MyConnect);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Model_Atualiza_PF(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                if (this.pessoajuridica == 0)
                ParticipantePf.__Atualizar(_MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Model_Atualiza_Vendedor(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                
                ParticipanteVendedor.__Atualizar(_MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void __Model_Consultar_ParticipanteTiposRegs(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {

                List<TbParticipanteTipoReg> MylistModel_ParticipanteTipoReg = new List<TbParticipanteTipoReg>();
                string SQL = "SELECT      coalesce(r.participante_tipo_reg_seq,0)  as participante_tipo_reg_seq" + 
                             "      , "   + this.cdparticipante.ToString() +  " as cdparticipante " + 
                             "      ,     t.participante_tipo_cd as participante_tipo_cd " +
                             "      ,     coalesce(cast(r.participante_tipo_reg_status as int),0) as participante_tipo_reg_status" +
                             "      ,     t.participante_tipo_descricao as participante_tipo_descricao" +
                             " from       tbparticipante_tipo t " +
                             " left join  tbparticipante_tipo_reg r on r.participante_tipo_cd = t.participante_tipo_cd and r.cdparticipante = " + this.cdparticipante.ToString() + 
                             " order by t.participante_tipo_descricao asc ";
                DataTable dtTiposRegs = BDCommand.get_DataTable(_MyConnect, SQL);
                foreach (DataRow i in dtTiposRegs.Rows)
                {
                    
                    TbParticipanteTipoReg ITEM = new TbParticipanteTipoReg();
                    /*ITEM.cdparticipante = this.cdparticipante;
                    ITEM.participante_tipo_cd = Convert.ToInt32(i["participante_tipo_cd"].ToString());
                    ITEM.Tipo.participante_tipo_descricao = i["participante_tipo_descricao"].ToString();
                    ITEM.participante_tipo_reg_status = Convert.ToInt32(i["status_tipo_participante"].ToString());
                     */
                    ITEM.__Binding(i);
                    MylistModel_ParticipanteTipoReg.Add(ITEM);
                }

                this.ListParticipanteTiposRegs = MylistModel_ParticipanteTipoReg.ToArray();

            }

            catch (Exception ex)
            {
                throw new Exception("_Binding_Model_Tipos | Erro \n " + ex.Message);
            }
        }
        public void __Model_Consultar_Enderecos(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            List<TbParticipanteEndereco> MylistModelParticipanteEndereco = new List<TbParticipanteEndereco>();
            string SQL = "SELECT 		" + this.cdparticipante.ToString() + " as cdparticipante " + 
                        " 				,	coalesce(e.endereco_seq,0) as endereco_seq" +
                        " 				,	t.endereco_tipo_cd	" +
                        " 				,	t.endereco_tipo_descricao " +
                        " 				,	coalesce(e.endereco_cep,0) as endereco_cep " +
                        " 				,	coalesce(e.endereco_numero , " + "'') as endereco_numero " +
                        " 				,	coalesce(e.endereco_logradouro , " + "'') as endereco_logradouro " +
                        " 				,	coalesce(e.endereco_bairro , " + "'') as endereco_bairro " +
                        " 				,	coalesce(e.endereco_municipio , " + "'') as endereco_municipio " +
                        " 				,	coalesce(e.endereco_complemento , " + "'') as endereco_complemento " +
                        " 				,	coalesce(e.endereco_uf , " + "'') as endereco_uf " +
                        " 				,	coalesce(e.endereco_latitude,0) as endereco_latitude" +
                        " 				,	coalesce(e.endereco_longitude,0) as endereco_longitude " +
                        "  FROM 		tbparticipante_endereco_tipo 	 t " +
                        "  LEFT JOIN 	TbParticipante_Endereco  		 e on t.endereco_tipo_cd = e.endereco_tipo_cd and e.cdparticipante = " + this.cdparticipante.ToString() +
                        "  ORDER BY 	e.cdparticipante , e.endereco_tipo_cd asc ";

            DataTable dtTiposRegs = BDCommand.get_DataTable(_MyConnect, SQL);
            foreach (DataRow i in dtTiposRegs.Rows)
            {
                TbParticipanteEndereco ITEM = new TbParticipanteEndereco();
                ITEM.__Binding(i);
                MylistModelParticipanteEndereco.Add(ITEM);
            }

            this.ListParticipanteEndereco = MylistModelParticipanteEndereco.ToArray();
            RaisePropertyChanged("ListParticipanteEndereco");

        }
        public void __Model_Consultar_Contatos(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            List<TbParticipanteContato> MylistModelParticipanteContato = new List<TbParticipanteContato>();
            string SQL = "SELECT 		" + this.cdparticipante.ToString() + " as cdparticipante " +
                        " 				,	coalesce(e.contato_seq,0) as contato_seq" +
                        " 				,	t.contato_tipo_cd	" +
                        " 				,	t.contato_tipo_descricao " +
                        " 				,	coalesce(e.contato_email , " + "'') as contato_email " +
                        " 				,	coalesce(e.contato_celular_dd,0) as contato_celular_dd" +
                        " 				,	coalesce(e.contato_celular_numero,0) as contato_celular_numero " +
                        " 				,	coalesce(e.contato_instagram , " + "'') as contato_instagram " +
                        " 				,	coalesce(e.contato_facebook , " + "'') as contato_facebook " +
                        "  FROM 		tbparticipante_contato_tipo 	 t " +
                        "  LEFT JOIN 	TbParticipante_contato  		 e on t.contato_tipo_cd = e.contato_tipo_cd and e.cdparticipante = " + this.cdparticipante.ToString() +
                        "  ORDER BY 	e.cdparticipante , e.contato_tipo_cd asc ";

            DataTable dtTiposRegs = BDCommand.get_DataTable(_MyConnect, SQL);
            foreach (DataRow i in dtTiposRegs.Rows)
            {
                TbParticipanteContato ITEM = new TbParticipanteContato();
                ITEM.__Binding(i);
                MylistModelParticipanteContato.Add(ITEM);
            }

            this.ListParticipanteContato = MylistModelParticipanteContato.ToArray();
            RaisePropertyChanged("ListParticipanteContato");

        }
        public void __Model_Consultar_ParticipanteBlueSoft(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                TbParticipanteBlueSoft ITEM = new TbParticipanteBlueSoft();
                string SQL = " select 		tb.cdparticipante                  " +
                             "           ,	tb.cdpessoabluesoft                " +
                             "           ,	tb.cpf_cnpj                        " +
                             "           ,	tb.nome_razao 		               " +
                             "           ,	tb.nome_abreviado                  " +
                             "           ,	tb.pessoajuridica                  " +
                             "           ,	tb.bluesoft_pessoa_data_cadastro   " +
                             "           ,	tb.bluesoft_pessoa_status          " +
                             "           ,	tb.bluesoftcliente                 " +
                             "           ,	tb.bluesoftclientestatus           " +
                             "           ,	tb.cdgrupoeconomico                " +
                             "           ,	tb.cdpessoabluesoft_vendedor       " +
                             "           ,	tb.bluesoftvendedor                " +
                             "           ,	tb.bluesoftfornecedor              " +
                             "           ,	tb.bluesoftfabricante              " +
                             "           ,	tb.bluesoftmotorista               " +
                             "           ,  es.descricao as grupoeconomico_descricao " +
                             " from 		tbparticipante_bluesoft   tb       " +
                             " left join    tbgrupoeconomico          es  on es.cdgrupoeconomico = tb.cdgrupoeconomico     " +
                             " where   1 = 1 " +
                             "   and   tb.cdparticipante = " + this.cdparticipante.ToString();

                DataTable DtParticipanteBlueSoft = BDCommand.get_DataTable(_MyConnect, SQL);

                if (DtParticipanteBlueSoft.Rows.Count > 0)
                {
                    DataRow i = DtParticipanteBlueSoft.Rows[0];
                    this.ParticipanteBlueSoft.bluesoft_pessoa_data_cadastro = Convert.ToDateTime(i["bluesoft_pessoa_data_cadastro"].ToString());
                    this.ParticipanteBlueSoft.bluesoft_pessoa_status = Convert.ToInt32(i["bluesoft_pessoa_status"].ToString());
                    this.ParticipanteBlueSoft.bluesoftcliente = Convert.ToInt32(i["bluesoftcliente"].ToString());
                    this.ParticipanteBlueSoft.bluesoftclientestatus = Convert.ToInt32(i["bluesoftclientestatus"].ToString());
                    this.ParticipanteBlueSoft.bluesoftfabricante = Convert.ToInt32(i["bluesoftfabricante"].ToString());
                    this.ParticipanteBlueSoft.bluesoftfornecedor = Convert.ToInt32(i["bluesoftfornecedor"].ToString());
                    this.ParticipanteBlueSoft.bluesoftmotorista = Convert.ToInt32(i["bluesoftmotorista"].ToString());
                    this.ParticipanteBlueSoft.bluesoftvendedor = Convert.ToInt32(i["bluesoftvendedor"].ToString());
                    this.ParticipanteBlueSoft.cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"].ToString());
                    this.ParticipanteBlueSoft.cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                    this.ParticipanteBlueSoft.cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());
                    this.ParticipanteBlueSoft.cdpessoabluesoft_vendedor = Convert.ToInt32(i["cdpessoabluesoft_vendedor"].ToString());
                    this.ParticipanteBlueSoft.cpf_cnpj = i["cpf_cnpj"].ToString();
                    this.ParticipanteBlueSoft.nome_razao = i["nome_razao"].ToString();
                    this.ParticipanteBlueSoft.pessoajuridica = Convert.ToInt32(i["pessoajuridica"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("_Binding_Model_Tipos | Erro \n " + ex.Message);
            }
        }
        public void __Model_Consultar_PF(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                ParticipantePf.cdparticipante = this.cdparticipante;
                ParticipantePf.__Consultar(_MyConnect);
            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void __Model_Consultar_Vendedor(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                ParticipanteVendedor.cdparticipante = this.cdparticipante;
                ParticipanteVendedor.__Consultar(_MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void __Model_Consultar_Funcionario(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {

                List<TbParticipanteFuncionario> MyListTbParticipanteFuncionario = new List<TbParticipanteFuncionario>();
                string SQL = " select 	f.cdparticipante " +
                             "   ,	    f.rh_funcionario_cd " +
                             "   ,	    coalesce(f.rh_funcionario_dv,0) as rh_funcionario_dv " +
                             "   ,	    t.nome_razao  " +
                             "   ,	    coalesce(f.data_admissao, '1900-01-01') as data_admissao" +
                             "   ,	    coalesce(f.data_rescisao, '1900-01-01') as data_rescisao " +
                             " from 		tbparticipante_rh 	        f " +
                             " inner join 	tbparticipante 				t on t.cdparticipante = f.cdparticipante" + 
                             " WHERE  t.cdparticipante = " + this.cdparticipante.ToString() 
                             ;
                DataTable dtFuncionario = BDCommand.get_DataTable(_MyConnect, SQL);
                foreach (DataRow i in dtFuncionario.Rows)
                {
                    TbParticipanteFuncionario item = new TbParticipanteFuncionario();
                    
                    item.cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                    item.rh_funcionario_cd = Convert.ToInt32(i["rh_funcionario_cd"].ToString());
                    item.rh_funcionario_dv = Convert.ToInt32(i["rh_funcionario_dv"].ToString());
                    item.__Consultar(_MyConnect);
                    MyListTbParticipanteFuncionario.Add(item);
                }
                this.ListParticipanteFuncinario = MyListTbParticipanteFuncionario.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool __Model_ConferirTipoPessoa(int participante_tipo_cd)
        {
            try
            {
                bool TipoPessoa = false; 
                foreach(  TbParticipanteTipoReg item in this.ListParticipanteTiposRegs)
                {
                    if (item.participante_tipo_cd == participante_tipo_cd)
                        TipoPessoa = item.participante_tipo_reg_status == 1 ? true : false;
                }
                return TipoPessoa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*
        public void __Consultar(Pag_Net.Models.TbSysUserInfo _MyConnect) { _Binding(_DBSELECT(_MyConnect)); }
        public void __Atualizar(Pag_Net.Models.TbSysUserInfo _MyConnect)
        {
            try
            {
                this._DBCRUD(_MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        
        private void _Binding(DataRow i)
        {
            try
            {
                this.cpf_cnpj = i["cpf_cnpj"].ToString();
                this.nome_razao = i["nome_razao"].ToString();
                this.email_main = i["email_main"].ToString();
                this.celular_dd = Convert.ToInt32(i["celular_dd"].ToString());
                this.celular_numero = Convert.ToInt32(i["celular_numero"].ToString());
                this.participante_status = Convert.ToInt32(i["participante_status"].ToString());
            }

            catch (Exception ex)
            {
                throw new Exception("_Binding_Model_Tipos | Erro \n " + ex.Message);
            }
        }*/



        public void _Binding_BaseBlueSoft(DataRow i)
        {
            try
            {
                _constructor();
                this.cdparticipante = 0;
                this.cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());
                this.cpf_cnpj = i["cpf_cnpj"].ToString();
                this.nome_razao = i["nome_razao"].ToString();
                this.nome_abreviado = i["nome_abreviado"].ToString();
                this.pessoajuridica = Convert.ToInt32(i["pessoajuridica"].ToString());
                this.email_main = i["email_main"].ToString();

                this.ParticipantePf.pf_sexo = i["sexo"].ToString();
                this.ParticipantePf.pf_data_nascimento = Convert.ToDateTime(i["data_nascimento"].ToString());


                List<TbParticipanteEndereco> ListModelParticipanteEndereco = new List<TbParticipanteEndereco>();
                TbParticipanteEndereco ItemEndereco = new TbParticipanteEndereco();
                
                ItemEndereco.endereco_cep = Convert.ToInt32(i["endereco_cep"].ToString());
                ItemEndereco.endereco_logradouro = Convert.ToString(i["endereco_logradouro"].ToString());
                ItemEndereco.endereco_numero = Convert.ToString(i["endereco_numero"].ToString());
                ItemEndereco.endereco_bairro = Convert.ToString(i["endereco_bairro"].ToString());
                ItemEndereco.endereco_municipio = Convert.ToString(i["endereco_municipio"].ToString());
                ItemEndereco.endereco_uf = Convert.ToString(i["endereco_uf"].ToString());
                ItemEndereco.endereco_complemento = Convert.ToString(i["endereco_complemento"].ToString());
                ItemEndereco.endereco_latitude = Convert.ToDouble(i["endereco_latitude"].ToString());
                ItemEndereco.endereco_longitude = Convert.ToDouble(i["endereco_longitude"].ToString());

                ListModelParticipanteEndereco.Add(ItemEndereco);
                ListParticipanteEndereco = ListModelParticipanteEndereco.ToArray();

                this.ParticipanteBlueSoft.bluesoft_pessoa_status = Convert.ToInt32(i["bluesoftpessoastatus"].ToString());
                this.ParticipanteBlueSoft.bluesoft_pessoa_data_cadastro = Convert.ToDateTime(i["bluesoftpessoa_data_cadastro"].ToString());
                this.ParticipanteBlueSoft.bluesoftcliente = Convert.ToInt32(i["bluesoftcliente"].ToString());
                this.ParticipanteBlueSoft.bluesoftclientestatus = Convert.ToInt32(i["bluesoftclientestatus"].ToString());
                this.ParticipanteBlueSoft.cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"].ToString());
                this.ParticipanteBlueSoft.cdpessoabluesoft_vendedor = Convert.ToInt32(i["cdpessoabluesoft_vendedor"].ToString());
                this.ParticipanteBlueSoft.bluesoftvendedor = Convert.ToInt32(i["bluesoftvendedor"].ToString());
                this.ParticipanteBlueSoft.bluesoftfornecedor = Convert.ToInt32(i["bluesoftfornecedor"].ToString());
                this.ParticipanteBlueSoft.bluesoftfabricante = Convert.ToInt32(i["bluesoftfabricante"].ToString());
                this.ParticipanteBlueSoft.bluesoftmotorista = 0;
                //this.Participante_BlueSoft.bluesoftmotorista = Convert.ToInt32(i["bluesoftmotorista"].ToString());

                this.ParticipanteBlueSoft.bluesoftcliente_creditolimite_valor = Convert.ToDouble(i["bluesoftcliente_creditolimite_valor"].ToString());
                this.ParticipanteBlueSoft.bluesoftcliente_creditolimite_valor_reservado = Convert.ToDouble(i["bluesoftcliente_creditolimite_valor_reservado"].ToString());
                this.ParticipanteBlueSoft.bluesoftcliente_creditostatus_cd = Convert.ToInt32(i["bluesoftcliente_creditostatus_cd"].ToString());
                this.ParticipanteBlueSoft.bluesoftcliente_ramoatividade_cd = Convert.ToInt32(i["bluesoftcliente_ramoatividade_cd"].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("_DataBinding_BaseBlueSoft | Erro \n " + ex.Message);
            }
        }


        //------------------------------------------------------------------------------------------------------

        public void _Participante_SELECT(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                __Binding(BDCommand.get_DataTable(_MyConnect, F0011_10_ParticipanteConsultar.Get(
                               this.cpf_cnpj
                             , this.cdparticipante
                             , this.cdpessoabluesoft
                             , this.funcionario_cd

                     )).Rows[0]);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void _BindingList(DataRow i)
        {
            string info_error = "";
            try
            {

                this.cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString();

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "Código Blue";
                this.cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());

                //info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "Rh Funcionário cd";
                //this.funcionario_cd = Convert.ToInt32(i["rh_funcionario_cd"].ToString());

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "CPF/CNPJ";
                this.cpf_cnpj = i["cpf_cnpj"].ToString();

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "Nome Razão";
                this.nome_razao = i["nome_razao"].ToString();

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "Nome Abreviado";
                this.nome_abreviado = i["nome_abreviado"].ToString();

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "Email";
                this.email_main = i["email_main"].ToString();

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "BlueCliente";
                this.bluesoftcliente = Convert.ToInt32(i["bluesoftcliente"].ToString());

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "BlueVendedor";
                this.bluesoftvendedor = Convert.ToInt32(i["bluesoftvendedor"].ToString());

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "bluesoftfornecedor";
                this.bluesoftfornecedor = Convert.ToInt32(i["bluesoftfornecedor"].ToString());

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "bluesoftfabricante";
                this.bluesoftfabricante = Convert.ToInt32(i["bluesoftfabricante"].ToString());

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "bluesoftpessoastatus";
                this.ParticipanteBlueSoft.bluesoft_pessoa_status = Convert.ToInt32(i["bluesoftfabricante"].ToString());

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "bluesoftclientestatus";
                this.ParticipanteBlueSoft.bluesoftclientestatus = Convert.ToInt32(i["bluesoftclientestatus"].ToString());

                info_error = "Processando o Registro Código do Participante " + cdparticipante.ToString() + " \n " + "participante_status";
                this.participante_status = Convert.ToInt32(i["participante_status"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Model_TbParticipante._BindingParticipante_list | Erro: " + info_error + "\n" + ex.Message);
            }




        }

    }
}

