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
    public class DaTipos
    {
        private modelSistemaUsuario MyConnect;
        public DaTipos(modelSistemaUsuario myconnect)
        {
            MyConnect = myconnect;
        }
        public TbSysTbTipos[] GetList(string _stringNomeTabela, string _stringNomeCampo)
        {
            SqlParameter _sqlparameterNomeTabela = dalUtil.SqlParameterCreator(SqlDbType.VarChar, "NomeTabela", _stringNomeTabela, false);
            SqlParameter _sqlparameterNomeCampo = dalUtil.SqlParameterCreator(SqlDbType.VarChar, "NomeCampo", _stringNomeCampo, false);
            SqlCommand _SqlCommand = new SqlCommand("prgetsistematipos");
            _SqlCommand.Parameters.Add(_sqlparameterNomeTabela);
            _SqlCommand.Parameters.Add(_sqlparameterNomeCampo);
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            dalConnectX _dalConnectX = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _sqlDataReader = _dalConnectX.SqlDataReader_Select();
            List<TbSysTbTipos> _list = new List<TbSysTbTipos>();
            while (_sqlDataReader.Read())
            {
                TbSysTbTipos x = new TbSysTbTipos();
                x.DescricaoTipo = _sqlDataReader["Descricao"].ToString();
                x.ObservacaoTipo = _sqlDataReader["Observacao"].ToString();
                x.SeqTipo = Convert.ToInt32(_sqlDataReader["SeqTipo"]);

                _list.Add(x);
            }
            return _list.ToArray();
        }
    }
}
