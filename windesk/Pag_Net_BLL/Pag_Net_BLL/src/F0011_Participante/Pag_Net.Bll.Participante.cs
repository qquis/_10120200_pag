using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{

    public class Filter
    {
        public int	    cdparticipante 			            {get;set;}
		public int	    cdpessoa					        {get;set;}
		public int	    cdpessoabluesoft 			        {get;set;}
        public int      funcionario_cd                      {get;set;}
		public string	cpf_cnpj 					        {get;set;}
		public string	nome_razao 				            {get;set;}
		public string	email_main 				            {get;set;}
		public int	    bluesoftcliente 			        {get;set;}
		public int	    bluesoftvendedor			        {get;set;}
		public int	    bluesoftfornecedor			        {get;set;}
		public int	    bluesoftfabricante			        {get;set;}
        public int      bluesoftmotorista                   {get;set;}
		public int	    cdpessoabluesoft_vendedor           {get;set;}
        public int      cdgrupoeconomico                    {get;set;}
        public string   list_participante_tipo              {get;set;}
        public bool     List_registro_zero                  { get; set; }
        public Filter()
        {

            cdparticipante 			    = 0;   
            cdpessoa					= 0;
            cdpessoabluesoft 			= 0;
            cpf_cnpj 					= "";
            nome_razao 				    = "";
            email_main 				    = "";
            bluesoftcliente 			=  0; 
            bluesoftvendedor			= 0; 
            bluesoftfornecedor			= 0;  
            bluesoftfabricante			= 0;
            bluesoftmotorista = 0;
            cdpessoabluesoft_vendedor   = 0;
            funcionario_cd = 0;
            list_participante_tipo = "";
            List_registro_zero          = true;
                
        }

        public void list_participante_tipo_clean()
        {
            this.list_participante_tipo = "";
        }

        public void list_participante_tipo_add(TbParticipanteTipo _ParticipanteTipo)
        {
            if (this.list_participante_tipo == "")
            {
                this.list_participante_tipo = _ParticipanteTipo.participante_tipo_cd.ToString(); 
            }
            else
            {
                this.list_participante_tipo = "," + _ParticipanteTipo.participante_tipo_cd.ToString(); 
            }

        }
    }

    public enum enumParticipanteTipoCd
    {
        todos = 0, 
        adm_usuario = 100, 
        adm_funcionario = 101, 
        adm_contador = 102,
        forca_venda_cliente = 120, 
        forca_venda_vendedor = 121, 
        forca_venda_motorista = 122, 
        fabricante = 140, 
        fornecedor = 141,
        fornecedor_representante = 142, 
        loja_cliente = 150,
        loja_encarregado = 151

    }

    public class Wk: INotifyPropertyChanged
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbParticipanteList;
        public DBDataTable DbParticipanteList
        {
            get { return __dbParticipanteList; }
            set
            {
                __dbParticipanteList = value;
                RaisePropertyChanged("DbParticipanteList");
            }
        }
        public ModelParticipante mParticipante;
        public TbParticipanteTipo mParticipanteTipoList;



        public ModelParticipante[] Participantes;
        public Filter Filtros;
        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Filtros = new Filter();
            mParticipante = new ModelParticipante();
        }

        public void ParticipantePessoaList_Get()
        {
            try
            {
                DbParticipanteList = Dts.F0011_60_ParticipanteList_Get(MyConnect, Filtros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
   
        
        public DataTable Pessoa_Consultar(                
                string CPF_CNPJ, 
                int vCdParticipante, 
                int vCdPessoaBlueSoft, 
                int vRh_Funcionario_Cd)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0011_05_Pessoa_Consultar.Postgre.Get(CPF_CNPJ, vCdParticipante, vCdPessoaBlueSoft, vRh_Funcionario_Cd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }

    public static class MyGets
    {
        public static ModelParticipante[] mParticipantes(Pag_Net.Models.modelSistemaUsuario MyConnect, enumParticipanteTipoCd tipo)
        {
            try
            {
                Filter Filtro = new Filter();

                TbParticipanteTipo MyParticipanteTipo = new TbParticipanteTipo(); 
                MyParticipanteTipo.participante_tipo_cd = Convert.ToInt32(tipo.ToString());

                Filtro.list_participante_tipo_add(MyParticipanteTipo);
                return mParticipantes(MyConnect, Filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ModelParticipante[] mParticipantes(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter filtros)
        {
            try
            {


                List<ModelParticipante> myList = new List<ModelParticipante>();
                DataTable dtList = Dts.F0011_60_ParticipanteList_Get(MyConnect, filtros).List;
                foreach(DataRow i in dtList.Rows)
                {
                    ModelParticipante ITEM = new ModelParticipante();
                    ITEM._BindingList(i);
                    myList.Add(ITEM);
                }

                if (filtros.List_registro_zero)
                {
                    ModelParticipante TODOS = new ModelParticipante();
                    TODOS.nome_razao = " * TODOS * ";
                    TODOS.nome_abreviado = " * TODOS * ";
                    TODOS.cdparticipante = 0;
                    myList.Add(TODOS);
                }
                return myList.ToArray();

            }

            catch ( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static TbParticipanteTipo[] mParticipante_Tipos(Pag_Net.Models.modelSistemaUsuario MyConnect, enumParticipanteTipoCd tipo)
        {
            try
            {
                Filter Filtro = new Filter();
                Filtro.list_participante_tipo = enumParticipanteTipoCd_get(tipo);

                List<TbParticipanteTipo> myList = new List<TbParticipanteTipo>();
                foreach (DataRow i in Dts.F0011_61_ParticipantesTipos_Get(MyConnect, Filtro).List.Rows)
                {
                    TbParticipanteTipo ITEM = new TbParticipanteTipo();
                    ITEM.__Binding(i);
                    myList.Add(ITEM);

                }
                return myList.ToArray();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string enumParticipanteTipoCd_get(enumParticipanteTipoCd __enumParticipanteTipoCd)
        {
            string participantetipocd = "100";
            switch (__enumParticipanteTipoCd)
            {
                case enumParticipanteTipoCd.todos: participantetipocd = ""; break;
                case enumParticipanteTipoCd.adm_usuario: participantetipocd = "100"; break;
                case enumParticipanteTipoCd.adm_funcionario: participantetipocd = "101"; break;
                case enumParticipanteTipoCd.adm_contador: participantetipocd = "102"; break;
                case enumParticipanteTipoCd.forca_venda_cliente: participantetipocd = "120"; break;
                case enumParticipanteTipoCd.forca_venda_vendedor: participantetipocd = "121"; break;
                case enumParticipanteTipoCd.forca_venda_motorista: participantetipocd = "122"; break;
                case enumParticipanteTipoCd.fabricante: participantetipocd = "140"; break;
                case enumParticipanteTipoCd.fornecedor: participantetipocd = "141"; break;
                case enumParticipanteTipoCd.fornecedor_representante: participantetipocd = "142"; break;
                case enumParticipanteTipoCd.loja_cliente: participantetipocd = "150"; break;
                case enumParticipanteTipoCd.loja_encarregado: participantetipocd = "151"; break;
            }
            return participantetipocd;

        }

    }

    public static class ComboBox
    {

        public static ModelParticipante[] Vendedores (Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Filter FILTER = new Filter();
                FILTER.list_participante_tipo = "121";
                return Get(MyConnect, FILTER);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ModelParticipante[] Fabricante (Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Filter FILTER = new Filter();
                FILTER.bluesoftfabricante = 1;
                return Get(MyConnect, FILTER);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ModelParticipante[] Motorista (Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Filter FILTER = new Filter();
                FILTER.bluesoftmotorista = 1;
                return Get(MyConnect, FILTER);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static ModelParticipante[] Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter Filtros)
        {
            try
            {
                DataTable _DataTable = Pag_Net.Bll.F0011_Participante.Dts.F0011_60_ParticipanteList_Get(MyConnect, Filtros).List;
                List<ModelParticipante> ParticipantePessoa_List = new List<ModelParticipante>();

                ModelParticipante TODOS = new ModelParticipante();
                TODOS.nome_razao = " * TODOS * ";
                TODOS.nome_abreviado = " * TODOS * ";
                TODOS.cdparticipante = 0;

                ParticipantePessoa_List.Add(TODOS);
                foreach (DataRow i in _DataTable.Rows)
                {
                    ModelParticipante ITEM = new ModelParticipante();
                    ITEM._BindingList(i);


                    ParticipantePessoa_List.Add(ITEM);
                }
                return ParticipantePessoa_List.ToArray();
            }
            catch( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

      
    }

    public class Model_LOCAL_Tipo_Sexo
    {
        public string sexo { get; set;  }
        public int index { get; set; }
        public string sexo_descricao { get; set; }
    }

    
}

