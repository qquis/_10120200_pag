using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_ParticipantePessoa
{

    public class Filter
    {
      
        public int	    cdparticipante 			            {get;set;}
		public int	    cdpessoa					        {get;set;}
		public int	    cdpessoabluesoft 			        {get;set;}
		public string	cpf_cnpj 					        {get;set;}
		public string	nome_razao 				            {get;set;}
		public string	email_main 				            {get;set;}
		public int	    bluesoftcliente 			        {get;set;}
		public int	    bluesoftvendedor			        {get;set;}
		public int	    bluesoftfornecedor			        {get;set;}
		public int	    bluesoftfabricante			        {get;set;}
		public int	    cdpessoabluesoft_vendedor           {get;set;}
        public int      cdgrupoeconomico { get; set; }
        public Filter()
        {

            cdparticipante 			    = 0;   
            cdpessoa					= 0;
            cdpessoabluesoft 			= 0;
            cpf_cnpj 					= "";
            nome_razao 				    = "";
            email_main 				    = "";
            bluesoftcliente 			=0; 
            bluesoftvendedor			= 0; 
            bluesoftfornecedor			= 0;  
            bluesoftfabricante			= 0;  
            cdpessoabluesoft_vendedor   = 0;  

        }


    }

    public class Wk
    {
        Pag_Net.Models.TbSysUserInfo MyConnect;
        Pag_Net.Bll.F0011_ParticipantePessoa.Tb.ParticipantePessoa[] ParticipantePessoaList;
        public Filter Filtros;
        public Wk(Pag_Net.Models.TbSysUserInfo _MyConnect)
        {
            MyConnect = _MyConnect;
            Filtros = new Filter();
        }

        public Pag_Net.Bll.F0011_ParticipantePessoa.Tb.ParticipantePessoa[] ParticipantePessoaList_Get()
        {
            try
            {
                DataTable _DataTable = Tool.ParticipantePessoaList_Get(MyConnect, Filtros);
                List<Tb.ParticipantePessoa> ParticipantePessoa_List = new List<Tb.ParticipantePessoa>();
                ParticipantePessoa_List.Add(new Tb.ParticipantePessoa(0, 0, "TODOS"));
                foreach(DataRow i in _DataTable.Rows)
                {
                    ParticipantePessoa_List.Add(new Tb.ParticipantePessoa(Convert.ToInt32(i["cdparticipante"]), Convert.ToInt32(i["cdpessoabluesoft"]), i["nome_razao"].ToString(), i["nome_abreviado"].ToString()));
                }
                ParticipantePessoaList = ParticipantePessoa_List.ToArray();
                return ParticipantePessoaList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable Pessoa_Consultar(                string CPF_CNPJ, 
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



    public static class Tool
    {
        public static DataTable ParticipantePessoaList_Get(Pag_Net.Models.TbSysUserInfo MyConnect, Filter _filter)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, Pag_Net.Bll.F0011_ParticipantePessoa.F0011_60_ParticipantePessoaList.Postgre.Get(MyConnect, _filter));
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0141_Rh.Tool.Funcionario_list_Obter: \n" + ex.Message);
            }
        }
    }
}
