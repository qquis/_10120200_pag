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
    public class DaPessoa
    {
        public static TbPessoas[] GetList(ModelSysUserInfo MyConnect, TbPessoas.TiposPessoa tipopessoa, string _RazaoSocialNome, string _DocumentoIdentificador, int _CdErpCliente)
        {
            SqlCommand _SqlCommand = new SqlCommand("prpessoa");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "seqTipoPessoa", tipopessoa, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "RazaoSocialNome", _RazaoSocialNome, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "DocumentoIdentificador", _DocumentoIdentificador, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "cderpcliente", _CdErpCliente, true, _SqlCommand);
            dalConnectX _dalConnectX = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _sqlDataReader = _dalConnectX.SqlDataReader_Select();
            return Pop(_sqlDataReader);
        }
        public static TbPessoas Insert(ModelSysUserInfo MyConnect, TbPessoas TbPessoaNew)
        {
            if (TbPessoaNew.Status == StatusRegistro.Insert)
            {
                int _IdentityInsert = 0;
                SqlCommand _SqlCommandx = new SqlCommand("prpessoa");
                _SqlCommandx.CommandType = CommandType.StoredProcedure;
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "tipoprocessamento", "INSERT", true, _SqlCommandx);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "razaosocialnome", TbPessoaNew.RazaoSocialNome.ToString(), true, _SqlCommandx);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "seqtipopessoa", TbPessoaNew.TipoPessoa, true, _SqlCommandx);
                dalUtil.SqlParameterCreatorAdd(SqlDbType.Char, "DocumentoIdentificador", TbPessoaNew.Documento.Documento, true, _SqlCommandx);
                Dal.dalConnectX _SqldalConnect = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommandx, IsolationLevel.Unspecified);
                SqlDataReader _SqlDataReader = _SqldalConnect.SqlDataReader_Select();
                try
                {
                    TbPessoaNew = Pop(_SqlDataReader)[0];
                    if (TbPessoaNew.CdPessoa == 0)
                    {
                        TbPessoaNew.Status = StatusRegistro.NoInsert;
                    }
                    else
                    {
                        TbPessoaNew.CdPessoa = _IdentityInsert;
                        TbPessoaNew.Status = StatusRegistro.Inserted;
                    }
                }
                catch (Exception)
                {
                    TbPessoaNew.Status = StatusRegistro.NoInsert;
                }
                return TbPessoaNew;
            }

            return TbPessoaNew;
        }
        public int Update() { return 1; }
        public int Delete() { return 1; }
        private static TbPessoas[] Pop(SqlDataReader _sqldatareader)
        {
            List<TbPessoas> _list = new List<TbPessoas>();
            while (_sqldatareader.Read())
            {
                TbPessoas x = new TbPessoas();
                x.CdPessoa = Convert.ToInt32(_sqldatareader["CdPessoa"].ToString());
                x.RazaoSocialNome = _sqldatareader["RazaoSocialNome"].ToString();
                x.Documento = new TbDocumentos(Convert.ToInt32(_sqldatareader["TipoDocumentoIdentificador"].ToString()), _sqldatareader["DocumentoIdentificador"].ToString());
                x.DescricaoEquipeRepositor = _sqldatareader["DescricaoEquipeRepositor"].ToString();
                x.CdErpFornecedor = Convert.ToInt32(_sqldatareader["CdErpFornecedor"].ToString());
                
                //x.CdEquipeRepositor = Convert.ToInt32(_sqlDataReader["CdEquipeRepositor"].ToString());
                _list.Add(x);
            }
            return _list.ToArray();
        }
    }
}
