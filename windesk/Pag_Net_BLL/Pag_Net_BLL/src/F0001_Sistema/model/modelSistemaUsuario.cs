using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;
using RestSharp;
using System.ComponentModel;
using System.Xml;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.ComponentModel.DataAnnotations;
using Pag_Net.Tools.CryptFile;
using Pag_Net.Tools.CryptPassWord;

using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Windows.Controls;
using System.Data.OleDb;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


/*
  Data........: 07/11/2024
  Alteração...: 07/11/2024  
  Nmae........: Pag_Net.Models.modelSistemaUsuario
  Objetivo: - tratar das questões do usuário do sistema
            - tratar do login
  Obs.........: Por ser uma classe antiga esta vinculada ao namespace Pag_Net.Models e não a um namespace exclusivo.
 * 
 
 */


namespace Pag_Net.Models
{
    [DataContract]
    public class modelSistemaUsuario
    {


        public int sis_us_seq { get; set; }

        public string passwd { get; set; }
        public string email_main { get; set; }
        public string user_name { get; set; } //Antigo user_id
        public string Email { get; set; }
        public string sis_cd { get; set; } //antigo System_id
        public string User_environment { get; set; }
        public string NetWork { get; set; }
        public string ZEBRA { get; set; }
        public string ZEBRACMD { get; set; }
        public string ZEBRACMDL { get; set; }
        public int SEQUENCIAL_DE_PROCESSO { get; set; }
        public string PAG_API { get; set; }
        public string Path_Spool { get; set; }

        public TbSysDatabase AuthenticateInfo { get; set; }
        public TbSysDatabase[] ListConnections { get; set; }
        public TbSysUserAccess[] ListAccess { get; set; }
        public TbSysTbTipos[] Tipos { get; set; }
        public TbSysTbOperacoes[] Operacoes { get; set; }




        public RestClient clientPagApi;
        public ModelSistemaPermissoes[] Acessos;
        public ModelSistemaPermissoes[] Permissoes;

        public Pag_Net.src.F0001_Sistema.model.ModelBackEndStatus myBackEndStatus;
        public Pag_Net.src.F0001_Sistema.model.ModelBackEndLogin myBackEndLogin;



        public modelSistemaUsuario() { constructor();  }
        public modelSistemaUsuario(string sis_cd, string User_environment, string user_name, string passWord) 
        {
            constructor();

            this.User_environment = User_environment;
            this.sis_cd = sis_cd;
            this.user_name = user_name;
            
            Pag_Net.Tools.CryptPassWord.Criptp cr = new Criptp(CryptProvider.TripleDES);
            this.passwd = cr.Encrypt(passWord);
        
            
        }
        private void constructor()
        {
            myBackEndStatus = new src.F0001_Sistema.model.ModelBackEndStatus();
            myBackEndLogin = new src.F0001_Sistema.model.ModelBackEndLogin();

        }
        public bool login(string sis_cd, string User_environment, string user_name, string passWord)
        {
            return login(sis_cd, User_environment, user_name, passWord, false);
        }
        public bool login(string sis_cd, string User_environment, string user_name, string passWord, bool tiposervice)
        {
            bool loginOk = false;

            try
            {
                if (tiposervice)
                {
                    return true;
                }
                myBackEndLogin = new Pag_Net.src.F0001_Sistema.model.ModelBackEndLogin();
                var BackEndLoginCredenciais = new
                {
                    sis_id = sis_cd,
                    mail = user_name,
                    password = passWord
                };     
                myBackEndLogin = Pag_Net.src.F0001_Sistema.model.ModelBackEndLogin.getJson(apiPost("/sistema/service/login", BackEndLoginCredenciais).ToString());

                this.User_environment = User_environment;
                this.sis_cd = sis_cd;
                this.user_name = user_name;

                Pag_Net.Tools.CryptPassWord.Criptp cr = new Criptp(CryptProvider.TripleDES);
                this.passwd = cr.Encrypt(passWord);

                DataSet DataSetLOGIN = new DataSet();
                DataSetLOGIN = DbSelect.GetDataSet(this, DataBaseName.ODBCOXAN, Pag_Net.src.F0001_Sistema.sql.F0001_10_Login_Acesso_List.Post(this), "");

                List<ModelSistemaPermissoes> listAcessos = new List<ModelSistemaPermissoes>();
                List<ModelSistemaPermissoes> listPermissoes = new List<ModelSistemaPermissoes>();

                if (DataSetLOGIN.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in DataSetLOGIN.Tables[0].Rows)
                    {
                        if (dr["sis_ta_cd"].ToString() == "1")
                           listAcessos.Add(new ModelSistemaPermissoes(dr));
                        else
                            listPermissoes.Add(new ModelSistemaPermissoes(dr)); 



                        this.sis_us_seq = Convert.ToInt32(dr["sis_us_seq"].ToString());
                    }
                    loginOk = true;
                }
                this.Acessos = listAcessos.ToArray();
                this.Permissoes = listPermissoes.ToArray();

                return loginOk;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool PermissaoConsultar(int vsis_ta_cd)
        {
            try
            {
                bool valor = false;

                ModelSistemaPermissoes PermissaoLocalizada = Array.Find(this.Permissoes, x => x.sis_ta_cd == vsis_ta_cd);
                if (PermissaoLocalizada != null)
                {
                    valor = true;
                }

                return valor;

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll _ ConsultarPostgreTarefas |  " + ex.Message);
            }

        }

        public bool getStatusBackend()
        {
            bool statusBackEnd = false;
            myBackEndStatus = Pag_Net.src.F0001_Sistema.model.ModelBackEndStatus.getJson(this.apiGet("/status").ToString());
            if (myBackEndStatus.status.ToString() == "1")
                statusBackEnd = true;

            return statusBackEnd;
        }

        public object apiGet(string url_metodo)
        {
            try
            {
                return apiGet(url_metodo, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public object apiGet(string url_metodo, object bodyitem)
        {
            try 
            {
                string url = string.Format("{0}" + url_metodo, this.PAG_API);
                return apiConstructor(url, Method.GET, bodyitem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public object apiPost(string url_metodo)
        {
            try
            {
                return apiPost(url_metodo, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public object apiPost(string url_metodo, object bodyitem)
        {
            try
            {
                
                string url = string.Format("{0}" + url_metodo, this.PAG_API);
                return apiConstructor(url, Method.POST, bodyitem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private object apiConstructor(string url, Method method, object bodyitem)
        {
            this.clientPagApi = new RestClient(url);
            this.clientPagApi.UserAgent = "PAG";
            
            this.clientPagApi.AddDefaultHeader("X-Customtoken", "10003ff9ec87814c80c505e8ccd80c43b6ff620");
            this.clientPagApi.AddDefaultHeader("usuario-login-uuid", this.myBackEndLogin.usuario_login_uuid);
            this.clientPagApi.Timeout = 100000000;

            RestRequest request = new RestRequest(method);
            if (bodyitem != null)
            {
                request.AddJsonBody(bodyitem);
            }
            var response = clientPagApi.Execute(request).Content;
            return response;
        }


        public static modelSistemaUsuario getJson(string json)
        {
            var x = new DataContractJsonSerializer(typeof(modelSistemaUsuario));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                return (modelSistemaUsuario)x.ReadObject(ms);

            }
        }
    }
}
