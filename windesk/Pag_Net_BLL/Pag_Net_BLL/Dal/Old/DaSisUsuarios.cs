using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Xml;
using System.IO;
using System.Linq;
using Pag_Net.Models;
using Pag_Net.Dal;
using System.Reflection;

namespace Pag_Net.Dal
{
    public class DaSisUsuarios
    {
        private SqlParameter _sqlparameterNome;
        private SqlParameter _sqlparameterDtCadIni;
        private SqlParameter _sqlparameterDtCadFim;
        private SqlParameter _sqlparameterCdUsr;
        private SqlParameter _sqlparameterEmail;
        private SqlParameter _sqlparameterCdvend;
        private SqlParameter _sqlparameterAutorizacao;
        private SqlParameter _sqlparameterAtivo;
        private SqlParameter _sqlparameterCdFuncao;
        private SqlParameter _sqlparameterSenha;
        private SqlParameter _sqlparameterCdUsrMoinho;

        private modelSistemaUsuario MyConnect;
        public DaSisUsuarios(modelSistemaUsuario myConnect, ModelTbSisUsuarios TbSisUsuarioGet = null)
        {
            MyConnect = myConnect;
            _sqlparameterNome = new SqlParameter("Nome", SqlDbType.VarChar); _sqlparameterNome.IsNullable = true;
            _sqlparameterDtCadIni = new SqlParameter("dt_cad_ini", SqlDbType.DateTime); _sqlparameterDtCadIni.IsNullable = true;
            _sqlparameterDtCadFim = new SqlParameter("dt_cad_fim", SqlDbType.DateTime); _sqlparameterDtCadFim.IsNullable = true;
            _sqlparameterCdUsr = new SqlParameter("cd_usr", SqlDbType.VarChar); _sqlparameterCdUsr.IsNullable = true;
            _sqlparameterEmail = new SqlParameter("email", SqlDbType.VarChar); _sqlparameterEmail.IsNullable = true;
            _sqlparameterCdvend = new SqlParameter("cdvend", SqlDbType.VarChar); _sqlparameterCdvend.IsNullable = true;
            _sqlparameterAutorizacao = new SqlParameter("autorizacao", SqlDbType.VarChar); _sqlparameterAutorizacao.IsNullable = true;
            _sqlparameterAtivo = new SqlParameter("ativo", SqlDbType.Bit); _sqlparameterAtivo.IsNullable = true;
            _sqlparameterCdFuncao = new SqlParameter("cdfuncao", SqlDbType.Int); _sqlparameterCdFuncao.IsNullable = true;
            _sqlparameterSenha = new SqlParameter("senha", SqlDbType.VarChar); _sqlparameterSenha.IsNullable = true;
            _sqlparameterCdUsrMoinho = new SqlParameter("cdusrmoinho", SqlDbType.VarChar); _sqlparameterCdUsrMoinho.IsNullable = true;
        }
        public ModelTbSisUsuarios[] GetList
            (string _NomeUsuario,
                DateTime? _DtCadIni,
                DateTime? _DtCadFim,
                string _Ativo
            )
        {

            _sqlparameterNome.Value = _NomeUsuario;
            _sqlparameterDtCadIni.Value = _DtCadIni;
            _sqlparameterDtCadFim.Value = _DtCadFim;

            SqlCommand SqlCommandTbUsers = new SqlCommand("PrSistemaUsuarios");
            SqlCommandTbUsers.CommandType = CommandType.StoredProcedure;
            SqlCommandTbUsers.Parameters.Add(_sqlparameterNome);
            SqlCommandTbUsers.Parameters.Add(_sqlparameterDtCadIni);
            SqlCommandTbUsers.Parameters.Add(_sqlparameterDtCadFim);
            dalConnectX dalConnectXTbUsers = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, SqlCommandTbUsers, IsolationLevel.Unspecified);
            SqlDataReader sqlDataReaderTbUser = dalConnectXTbUsers.SqlDataReader_Select();



            List<ModelTbSisUsuarios> listModelUsers = new List<ModelTbSisUsuarios>();
            while (sqlDataReaderTbUser.Read())
            {
                bool ativo = false;
                ModelTbSisFuncao UserFuncao = null;

                if (sqlDataReaderTbUser["cd_funcao"].ToString() != null)
                    UserFuncao = new ModelTbSisFuncao(sqlDataReaderTbUser["cd_funcao"].ToString(), sqlDataReaderTbUser["DescricaoFuncao"].ToString(), "true");
                if (sqlDataReaderTbUser["ativo"].ToString().Trim() == "1")
                {
                    ativo = true;
                }
                else
                {
                    ativo = false;
                }
                listModelUsers.Add(new ModelTbSisUsuarios(sqlDataReaderTbUser["cd_usr"].ToString(),
                                                    sqlDataReaderTbUser["nome"].ToString(),
                                                    "",
                                                    sqlDataReaderTbUser["dt_cad"].ToString(),
                                                    sqlDataReaderTbUser["e_mail"].ToString(),
                                                    UserFuncao,
                                                    ativo,
                                                    sqlDataReaderTbUser["usuariomoinho"].ToString(),
                                                    sqlDataReaderTbUser["autorizacao"].ToString(),
                                                    sqlDataReaderTbUser["cd_vend"].ToString()
                                                    )
                                  );
            }
            sqlDataReaderTbUser.Close();
            return listModelUsers.ToArray();
        }

        public int Update(ModelTbSisUsuarios regModelTbSisUsuario)
        {
            return InsertUpdate(regModelTbSisUsuario, PagdataTipoProcedimento.Update);
        }

        public int Insert(ModelTbSisUsuarios regModelTbSisUsuario)
        {
            return InsertUpdate(regModelTbSisUsuario, PagdataTipoProcedimento.Insert);
        }

        private int InsertUpdate(ModelTbSisUsuarios regModelTbSisUsuario, PagdataTipoProcedimento TipoProcedimento)
        {

            try
            {

                string tipoproc = "";
                if (TipoProcedimento == PagdataTipoProcedimento.Update)
                {
                    tipoproc = "UPDATE";
                }
                if (TipoProcedimento == PagdataTipoProcedimento.Insert)
                {
                    tipoproc = "INSERT";
                }

                SqlParameter _TIPOPROC;
                _TIPOPROC = new SqlParameter("PROC", tipoproc.ToString());


                _sqlparameterNome.Value = regModelTbSisUsuario.Nome;
                _sqlparameterCdUsr.Value = regModelTbSisUsuario.Userid;
                _sqlparameterEmail.Value = regModelTbSisUsuario.Email;
                _sqlparameterCdvend.Value = regModelTbSisUsuario.CdVend;
                _sqlparameterAutorizacao.Value = regModelTbSisUsuario.Autorizacao;
                _sqlparameterAtivo.Value = regModelTbSisUsuario.Status ? 1 : 0;
                _sqlparameterCdFuncao.Value = regModelTbSisUsuario.Funcao.CdFuncao;
                _sqlparameterSenha.Value = regModelTbSisUsuario.PassWord;
                _sqlparameterCdUsrMoinho.Value = regModelTbSisUsuario.UsuarioMoinho;
                SqlCommand SqlCommandTbUsers = new SqlCommand("PrUsuarios");
                SqlCommandTbUsers.CommandType = CommandType.StoredProcedure;
                SqlCommandTbUsers.Parameters.Add(_sqlparameterCdUsr);
                SqlCommandTbUsers.Parameters.Add(_sqlparameterNome);
                SqlCommandTbUsers.Parameters.Add(_sqlparameterEmail);
                SqlCommandTbUsers.Parameters.Add(_sqlparameterCdvend);
                SqlCommandTbUsers.Parameters.Add(_sqlparameterAutorizacao);
                SqlCommandTbUsers.Parameters.Add(_sqlparameterAtivo);
                SqlCommandTbUsers.Parameters.Add(_sqlparameterCdFuncao);
                SqlCommandTbUsers.Parameters.Add(_sqlparameterSenha);
                SqlCommandTbUsers.Parameters.Add(_sqlparameterCdUsrMoinho);
                SqlCommandTbUsers.Parameters.Add(_TIPOPROC);

                dalConnectX dalConnectXTbUsers = new dalConnectX(MyConnect, DataBaseName.DATABASE_AUT, SqlCommandTbUsers, IsolationLevel.Unspecified);
                return dalConnectXTbUsers.SqlExecuteCommandClosed();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
