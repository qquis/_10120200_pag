using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;

namespace Pag_Net.Bll.Voucher
{
    public static class Pool
    {
        public static void Atualizar(
                Pag_Net.Models.modelSistemaUsuario MyConnect,
                string cpf_cnpj,  
                int Tipo_Voucher
            ) 
        {
            try
            {
                if (!Pag_Net.Bll.Pessoa.Pool.ValidaDocumento_CPF_CNPJ(cpf_cnpj, false))
                {
                    throw new Exception("CPF INVÁLIDO");
                }


                string _hh = DateTime.Now.ToString("hh").Substring(0, 1) == "0" ? "9" + DateTime.Now.ToString("hh").Substring(1, 1) : DateTime.Now.ToString("hh");
                string _mm = DateTime.Now.ToString("mm").Substring(0, 1) == "0" ? "8" + DateTime.Now.ToString("mm").Substring(1, 1) : DateTime.Now.ToString("mm");
                string _ss = DateTime.Now.ToString("ss").Substring(0, 1) == "0" ? "7" + DateTime.Now.ToString("ss").Substring(1, 1) : DateTime.Now.ToString("ss");

                string _dd = DateTime.Now.ToString("dd").Substring(0, 1) == "0" ? "0" + DateTime.Now.ToString("dd").Substring(1, 1) : DateTime.Now.ToString("dd");
 
                //string __voucher_seq = _hh + _ss + _mm + cpf_cnpj.Substring(0, 2);

                string __voucher_cd = "";
                if (Tipo_Voucher == 1)
                {
                    __voucher_cd = cpf_cnpj.Substring(cpf_cnpj.Length - 4, 4) + _dd;
                }
                else
                {
                    __voucher_cd = Math.Round( Convert.ToDouble(cpf_cnpj),0).ToString();
                }

               

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(Pag_Net.Bll.F0110_01.Postgres.post(MyConnect, "DBINSERT", false, __voucher_cd, cpf_cnpj, "", Tipo_Voucher), null, DataBaseName.ODBCOXAN);
                
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();



                DbUpdate BDExecute_SQL;
                BDExecute_SQL = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                string SQL_SQLSERVER = string.Format("EXEC SPP0990_ZanthusVoucher           " +
                                           "            @cod_voucher          =    '{0}'      " +
                                           "          , @descricao_parceiro   =   '{1}'      " + 
                                           "          , @voucher_tipo_cd      =  {2} ", 
                                           __voucher_cd.ToString(),
                                           Pag_Net.Models.PagInfo.VERSAO.ToString(),
                                           Tipo_Voucher.ToString()
                
                );
                BDExecute_SQL.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);
                BDExecute_SQL.Close(DataBaseName.DBAMAINADM);
                BDExecute_SQL.Dispose();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Listar(
                Pag_Net.Models.modelSistemaUsuario MyConnect,
                _model_parametro_filter __filtro_voucher 
            )
        {
            return Pag_Net.Bll.R0110_01.Postgre.get(
                                    MyConnect,
                                     __filtro_voucher.voucher_seq ,
                                     __filtro_voucher.voucher_cd,
                                     __filtro_voucher.voucher_data_ini,
                                     __filtro_voucher.voucher_data_fim, 
                                     __filtro_voucher.cdpessoa ,
                                     __filtro_voucher.voucher_cpf_cnpj
                                );
        }

        public static string NumeroVoucher( 
                    Pag_Net.Models.modelSistemaUsuario MyConnect,
                _model_parametro_filter __filtro_voucher )
        {
            try
            {
                DataTable _LIST = Listar(MyConnect, __filtro_voucher);
                string SEQ_VOUCHER = "";
                if (_LIST.Rows.Count > 0)
                {
                    SEQ_VOUCHER = _LIST.Rows[_LIST.Rows.Count - 1]["voucher_seq"].ToString();
                }
                else
                {
                    SEQ_VOUCHER = "";
                }
                _LIST.Dispose();
                return SEQ_VOUCHER;
            }
            catch (Exception EX)
            {
                throw new Exception("Erro na captação do VOUCHER: " + EX.Message);
            }
        }

        public static bool Voucher_Valid_Insert(
                Pag_Net.Models.modelSistemaUsuario MyConnect
            , string cpf_cnpj
            , int voucher_tipo_cd
            )
        {
            bool _valid_voucher = false;
            try
            {
                DataTable dt = Pag_Net.Bll.R0110_02.Postgre.get(MyConnect, cpf_cnpj, voucher_tipo_cd);
                if (dt.Rows.Count > 0)
                {
                    _valid_voucher = false;
                }
                else
                {
                    _valid_voucher = true;
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return _valid_voucher;
        }
  
    
    
    }
    public class _model_voucher
    {
       public DateTime dtlog_insert { get; set; }
       public int voucher_seq 	 { get; set; }
       public string voucher_cd { get; set; }
       public DateTime voucher_data { get; set; }
       public int cdpessoa	 { get; set; }
       public string nome_razao	 { get; set; }
       public string cpf_cnpj		 { get; set; }
       public string documento_cnh { get; set; }
       public DateTime data_nascimento { get; set; }


        public _model_voucher()
        {
            data_nascimento = DateTime.Now;
            voucher_data = DateTime.Now;
            dtlog_insert = DateTime.Now;
        }

        public _model_voucher(DataRow i)
        {
            cdpessoa = Convert.ToInt32(i["cdpessoa"]);
            cpf_cnpj = i["cpf_cnpj"].ToString();
            nome_razao = i["nome_razao"].ToString();
            data_nascimento = Convert.ToDateTime(i["data_nascimento"]);
            documento_cnh = i["documento_cnh"].ToString();
            voucher_data = Convert.ToDateTime(i["voucher_data"]);

        }



    }
    public class _model_parametro_filter
    {
            public int         voucher_seq             {get;set;}
            public string      voucher_cd { get; set; }
            public DateTime    voucher_data_ini        {get;set;}
            public DateTime    voucher_data_fim        {get;set;}
	        public int         cdpessoa                {get;set;}
            public string      voucher_cpf_cnpj        {get;set;}
            public string      voucher_documento_cnh   {get;set;}    
        public _model_parametro_filter () { }
        public _model_parametro_filter (

            int         _voucher_seq             
        ,   DateTime    _voucher_data_ini        
        ,   DateTime    _voucher_data_fim        
        ,   int         _cdpessoa                
        ,   string      _voucher_cpf_cnpj        
        ,   string      _voucher_documento_cnh   
            )
        {
            voucher_seq                 =  _voucher_seq                 ;
            voucher_data_ini            =  _voucher_data_ini            ;
            voucher_data_fim            =  _voucher_data_fim            ;
            cdpessoa                    =  _cdpessoa                    ;
            voucher_cpf_cnpj            =  _voucher_cpf_cnpj            ;
            voucher_documento_cnh       =  _voucher_documento_cnh       ;
        }

        public _model_parametro_filter(string cpf_cnpj, string documento_cnh)
        {
            voucher_seq = 0;
            voucher_cd = "";
            voucher_data_ini = DateTime.Now;
            voucher_data_fim = DateTime.Now;
            cdpessoa = 0;
            voucher_cpf_cnpj = cpf_cnpj;
            voucher_documento_cnh = documento_cnh;
        }

        public _model_parametro_filter(DateTime DataUnica)
        {
            voucher_seq = 0;
            voucher_cd = "";
            voucher_data_ini = DataUnica;
            voucher_data_fim = DataUnica;
            cdpessoa = 0;
            voucher_cpf_cnpj = "";
            voucher_documento_cnh = "";
        }
    }
   
    
}
